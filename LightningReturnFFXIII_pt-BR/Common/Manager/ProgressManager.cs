using SaaUI;

namespace LightningReturnFFXIII_pt_BR.Common;

public class ProgressManager
{
    private readonly SaaProgressBar _progressB;

    private int Current { get; set; }

    public ProgressManager(SaaProgressBar progressBar)
    {
        Current = 0;
        _progressB = progressBar;
    }

    public void Increase(double value, string text = "")
    {
        Current += (int)Math.Ceiling(value);
        _ = _progressB.BeginInvoke((MethodInvoker)(() =>
        {
            if (Current < 100)
            {
                _progressB.Value = Current;
                _progressB.Prefix = SetTextSpace(text);
            }
            else
            {
                _progressB.Value = 100;
                _progressB.Text = "";
            }
        }));
    }
    public void PrgressOnlyText(string text = "")
    {
        try
        {
            _ = _progressB.BeginInvoke((MethodInvoker)(() =>
            {
                _progressB.Display = SaaCircularProgressDisplayValue.None;
                _progressB.Suffix = "";
                _progressB.Prefix = text;
            }));
        }
        finally
        {
            _progressB.Prefix = "";
        }
    }
    public void SetPercentAndText(int value, string text)
    {
        _ = _progressB.BeginInvoke((MethodInvoker)(() =>
        {
            if (value < 100)
            {
                _progressB.Value = value;
                _progressB.Prefix = SetTextSpace(text);
            }
            else
            {
                _progressB.Value = 100;
                _progressB.Text = "";
            }
        }));
    }
    public void SetPercent(int value)
    {
        _ = _progressB.BeginInvoke((MethodInvoker)(() => _progressB.Value = value < 100 ? value : 100));
    }
    public void Begin()
    {
        Current = 0;
        _ = _progressB.BeginInvoke((MethodInvoker)(() => _progressB.Value = 0));
    }
    public void Finish()
    {
        Current = 100;
        _ = _progressB.BeginInvoke((MethodInvoker)(() =>
        {
            _progressB.Value = 100;
            _progressB.Prefix = "";
        }));
    }

    private string SetTextSpace(string text) => $"{text} ";
}