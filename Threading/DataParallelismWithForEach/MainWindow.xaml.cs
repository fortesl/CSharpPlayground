using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataParallelismWithForEach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Load up all *.jpg files, and make a new folder for the modified data.
        static readonly string[] _files = Directory.GetFiles(@"C:\Users\lfortes\Pictures", "*.png", SearchOption.AllDirectories);
        static readonly string _newDir = @"C:\Users\lfortes\Pictures\ModifiedPictures";

        // New Window-level variable.
        private CancellationTokenSource cancelToken = new CancellationTokenSource();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            // This will be used to tell all the worker threads to stop!
            cancelToken.Cancel();
        }

        private void cmdProcess_Click(object sender, RoutedEventArgs e)
        {
            Directory.CreateDirectory(_newDir);

            StartTime.Content = DateTime.Now.Second;
            Task.Factory.StartNew(() => ProcessFiles());
 //           ProcessFiles();
 //           ProcessFilesAsync();
            EndTime.Content = DateTime.Now.Second;
        }

        private void ProcessFiles()
        {
            // Process the image data in a blocking manner.
            foreach (string currentFile in _files)
            {
                string filename = System.IO.Path.GetFileName(currentFile);

                using (Bitmap bitmap = new Bitmap(currentFile))
                {
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bitmap.Save(System.IO.Path.Combine(_newDir, filename));

                    // Print out the ID of the thread processing the current image.
                    Console.WriteLine($"Processing {filename} on thread {Thread.CurrentThread.ManagedThreadId}");
                }
            }
        }

        private void ProcessFilesAsync()
        {
            ParallelOptions parOpts = new ParallelOptions();
            parOpts.CancellationToken = cancelToken.Token;
            parOpts.MaxDegreeOfParallelism = System.Environment.ProcessorCount;
            try
            {
                // Process the image data in a parallel manner!
                Parallel.ForEach(_files, parOpts, currentFile =>
                {
                    parOpts.CancellationToken.ThrowIfCancellationRequested();

                    string filename = System.IO.Path.GetFileName(currentFile);
                    using (Bitmap bitmap = new Bitmap(currentFile))
                    {
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        bitmap.Save(System.IO.Path.Combine(_newDir, filename));
                        Console.WriteLine($"Processing {filename} on thread {Thread.CurrentThread.ManagedThreadId}");
                    }
                });
                Console.WriteLine($"Done");
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine($"Threw: {ex.Message}");
            }
        }
    }
}

