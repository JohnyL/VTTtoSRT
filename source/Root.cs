namespace VTTtoSRT;

public partial class Root : Form
{
  public Root() => InitializeComponent();

  private async void OnConvert(object sender, EventArgs e)
  {
    OpenFileDialog dialog = new()
    {
      Title = "Select one or more .SRT files",
      Filter = "VTT files|*.vtt",
      RestoreDirectory = true,
      Multiselect = true
    };

    if (dialog.ShowDialog() != DialogResult.OK)
      return;

    Match match;
    string time_line, new_line;
    Regex regex = new(@"(?'hoursStart'\d{2}:)?(?'start'\d{2}:\d{2}\.\d{1,3})\s-->\s(?'hoursEnd'\d{2}:)?(?'end'\d{2}:\d{2}\.\d{1,3})");
    bool to_delete_vtt = chkDeleteSrtFile.Checked;

    foreach (string vttFile in dialog.FileNames)
    {
      int i = 0, x = 0;
      string dest_file = Path.Combine(Path.GetDirectoryName(vttFile)!, $"{Path.GetFileNameWithoutExtension(vttFile)}.srt");
      if (File.Exists(dest_file))
        File.Delete(dest_file);
      using StreamWriter srt = new(dest_file);
      IEnumerable<string> lines = File.ReadLines(vttFile);

      foreach (string line in lines)
      {
        match = regex.Match(line);
        if (match.Success)
        {
          // Reconstruct timeline.
          // If hours are absent, add them back as "00".
          time_line = $"{(match.Groups["hoursStart"].Value == "" ? "00:" : "")}{match.Groups["start"].Value} --> {(match.Groups["hoursEnd"].Value == "" ? "00:" : "")}{match.Groups["end"].Value}";
          time_line = time_line.Replace(".", ",");
          new_line = ++x == 1 ? "" : "\r\n";
          await srt.WriteLineAsync($"{new_line}{x}\r\n{time_line}");
        }
        else if (line.Length > 0)
        {
          if (++i == 1)
            continue; //Skip first line WEBTTV
          await srt.WriteLineAsync(line);
        }
      }

      if (to_delete_vtt)
        File.Delete(vttFile);
    }
    MessageBox.Show("Done!", "VTT to SRT", MessageBoxButtons.OK, MessageBoxIcon.Information);
  }
}