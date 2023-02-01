namespace LightningReturnFFXIII_pt_BR;

public partial class CreditUi : Form
{
    public CreditUi()
    {
        InitializeComponent();
    }

    private void CreditUI_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        Hide();
    }
}