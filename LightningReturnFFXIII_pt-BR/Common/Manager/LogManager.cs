namespace LightningReturnFFXIII_pt_BR.Common
{
    public class LogManager
    {
        private readonly ListBox _log;

        public LogManager(ListBox listBox)
        {
            _log = listBox;
        }

        public void Push(ReadOnlySpan<char> content)
        {
            foreach (ReadOnlySpan<char> line in content.SplitLines())
            {
                Push(line.ToString());
            }
        }
        public void Push(string? content, bool log = false)
        {
            _log.BeginInvoke((MethodInvoker)delegate
            {
                if (log)
                {
                    string[]? lines = content?.Split(new[] { "\n" }, StringSplitOptions.None);
                    if (lines != null)
                        for (int index = 0; index < lines.Length; index++)
                        {
                            string line = lines[index];
                            _log.Items.Add(line);
                        }
                }
                else
                {
                    if (content != null) _log.Items.Add(content);
                }
                _log.SelectedIndex = _log.Items.Count - 1;
                _log.SelectedIndex = -1;
            });
        }
        public void Clear()
        {
            _log.BeginInvoke((MethodInvoker)delegate
            {
                _log.Items.Clear();
            });
        }
    }
}
