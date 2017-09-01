using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace VTTtoSRT
{
	public partial class Root : Form
	{

		public Root() => InitializeComponent();

		private async void OnConvert(object sender, EventArgs e)
		{
			var dialog = new OpenFileDialog
			{
				Filter = "VTT files|*.vtt",
				RestoreDirectory = true,
				Multiselect = true
			};

			if (dialog.ShowDialog() != DialogResult.OK) return;

			string time_line = null, new_line = null;
			string pattern = @"\d{2}:\d{2}:\d{2}\.\d{1,3}\s-->\s\d{2}:\d{2}:\d{2}\.\d{1,3}";
			Match match = null;
			var regex = new Regex(pattern);

			foreach (var vttFile in dialog.FileNames)
			{

				int i = 0, x = 0;
				var dest_file = Path.Combine(Path.GetDirectoryName(vttFile), $"{Path.GetFileNameWithoutExtension(vttFile)}.srt");
				using (var srt = new StreamWriter(dest_file))
				{
					var lines = File.ReadLines(vttFile);
					foreach (string line in lines)
					{
						++i;
						match = regex.Match(line);
						if (match.Success)
						{
							++x;
							time_line = match.Value.Replace(".", ",");
							new_line = x == 1 ? "" : "\r\n";
							await srt.WriteLineAsync($"{new_line}{x}\r\n{time_line}");
						}
						else if (line.Length > 0)
						{
							if (i == 1) continue; //Skip first line WEBTTV
							await srt.WriteLineAsync(line);
						}
					}

					File.Delete(vttFile);
				}

			}
			MessageBox.Show("Done!");
		}
	}
}