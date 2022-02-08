using Caliburn.Micro;
using Client.Models;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcProto;
using Microsoft.Win32;
using Ookii.Dialogs.Wpf;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace Client.ViewModels
{
    public class PalindromeClientWindowViewModel : Conductor<object>
    {
        private BindableCollection<MyFile> _files=new BindableCollection<MyFile>();       
        public BindableCollection<MyFile> Files
        {
            get { return _files; }
            set
            { 
                _files = value;
            }
        }       
        public async Task GetCheckText(string nameFile, string textFile)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new PalindromeService.PalindromeServiceClient(channel);

            using var call = client.GetCheckForPalindrome();

            var readTask = Task.Run(async () =>
              {
                  int i = 0;
                  await foreach (var response in call.ResponseStream.ReadAllAsync())
                  {
                      Files[i].CheckText = response.Check ? "Palindrome" : "Not Palindrome"; i++;
                  }
              });

            foreach (var file in Files)
            {
                try
                {
                    await call.RequestStream.WriteAsync(new PalindromeRequest() { Text = file.Text });
                }
                catch (RpcException)
                {
                    MessageBox.Show("Server overloaded, not all requests can be processed at the moment \n please try later");
                }

            }
            await call.RequestStream.CompleteAsync();
            await readTask;
        }
       
        public void SelectFolder()
        {            
            string folderName;
            OpenFileDialog fileDialog = new OpenFileDialog();
            VistaFolderBrowserDialog dialog = new VistaFolderBrowserDialog();
            dialog.Description = "Select a folder with text files to check for polyndrom";
            dialog.UseDescriptionForTitle = true;
            if (dialog.ShowDialog() == true)
            {
                folderName = dialog.SelectedPath;
                Files.Clear();
                ScanFolderForFiles(folderName);
            }
            else folderName = "";
        }
        private void ScanFolderForFiles(string folderName)
        {           
            string[] files_paths = Directory.GetFiles(folderName, searchPattern: "*.txt");
            foreach (string fileName in files_paths)
            {
                Files.Add(new MyFile { Name = Path.GetFileName(fileName), Text = File.ReadAllText(fileName)});
            }
        }

    }
}
