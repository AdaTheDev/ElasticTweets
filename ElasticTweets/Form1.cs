using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElasticTweets.Library;
using ElasticTweets.Library.IO;
using ElasticTweets.Library.Providers;

namespace ElasticTweets
{
    public partial class frmImport : Form
    {
        public frmImport()
        {
            InitializeComponent();
        }        
        
        private void DoImport()
        {
            string validationResult = ValidateInputs();
            if (!String.IsNullOrWhiteSpace(validationResult))
            {
                MessageBox.Show(validationResult, @"Something's not quite right...");
                return;
            }

            var fileSystem = new FileSystem();
            var connectionSettings = new ElasticConnectionSettings(txtHost.Text, int.Parse(txtPort.Text), txtIndexName.Text);

            try
            {
                var stopwatch = Stopwatch.StartNew();
                var importer = new Importer(fileSystem, new TweetDataFileParser(fileSystem), new ClientProvider(),
                                            connectionSettings, txtSourceDirectory.Text);

                var results = importer.Import();
                stopwatch.Stop();

                var summary = new StringBuilder();
                summary.AppendFormat("Finished processing {0} files in {1}s.\n",
                    results.Files.Count().ToString(CultureInfo.InvariantCulture), stopwatch.Elapsed.TotalSeconds.ToString("F3"));
                summary.AppendFormat("{0} tweets have been imported.\n", results.Files.Sum(f => f.NumberOfTweets));

                if (results.Files.Any(f => !f.Success))
                {
                    summary.AppendFormat("{0} files failed to import. Errors (max of 3 will be shown):\n",
                                         results.Files.Count(f => !f.Success));

                    foreach (var failure in results.Files.Where(f => !f.Success).Take(3))
                    {
                        string fileName = failure.FileName.Substring(failure.FileName.LastIndexOf('\\') + 1);
                        summary.AppendFormat("{0} : {1}", fileName, failure.ErrorMessage);
                    }
                }
                MessageBox.Show(summary.ToString(), @"Finished");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, @"Something went pop...");
            }            
        }

        private void ToggleControls(bool enabled)
        {
            if (txtSourceDirectory.InvokeRequired)
            {                
                BeginInvoke(new MethodInvoker(() => ToggleControls(enabled)));
            }
            else
            {
                txtSourceDirectory.Enabled = enabled;
                btnChangeDirectory.Enabled = enabled;
                txtHost.Enabled = enabled;
                txtPort.Enabled = enabled;
                txtIndexName.Enabled = enabled;
                btnImport.Enabled = enabled;
            }
        }

        private string ValidateInputs()
        {
            if (String.IsNullOrWhiteSpace(txtSourceDirectory.Text))
                return "Please select the directory where the JS data files are";

            if (!Directory.Exists(txtSourceDirectory.Text))
                return "The chosen data directory doesn't exist";

            if (String.IsNullOrWhiteSpace(txtHost.Text))
                return "Please specify the ElasticSearch host name";

            int port;
            if (String.IsNullOrWhiteSpace(txtPort.Text) || !int.TryParse(txtPort.Text, out port))
                return "Please enter a valid ElasticSearch port number";

            if (String.IsNullOrWhiteSpace(txtIndexName.Text))
                return "Please enter the name of the index to import into";

            return String.Empty;
        }

        private void btnChangeDirectory_Click(object sender, EventArgs e)
        {
            folderDialog.ShowDialog();
            txtSourceDirectory.Text = folderDialog.SelectedPath;
        }        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Schhhhtop...it's not ready yet!");
        }   
     
        private void btnImport_Click(object sender, EventArgs e)
        {
            ToggleControls(false);

            Task.Factory.StartNew(DoImport).ContinueWith(_ => ToggleControls(true));
        }
    }
}
