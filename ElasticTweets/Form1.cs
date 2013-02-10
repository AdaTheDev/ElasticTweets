using System;
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

        private void btnImport_Click(object sender, EventArgs e)
        {
            var fileSystem = new FileSystem();
            var connectionSettings = new ElasticConnectionSettings(txtHost.Text, int.Parse(txtPort.Text), txtIndexName.Text);

            var importer = new Importer(fileSystem, new TweetDataFileParser(fileSystem), new ClientProvider(),
                                        connectionSettings, txtSourceDirectory.Text);

            var results = importer.Import();
        }
    }
}
