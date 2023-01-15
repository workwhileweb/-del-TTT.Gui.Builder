namespace TTT.Gui.Builder;

// ReSharper disable once UnusedMember.Global
public class LineLabelText : Line
{
    public LineLabelText(string label,
        string text,
        int labelSize = 2,
        int textSize = 8) : base(
        CreateLabel(label, labelSize),
        CreateTextBox(text, textSize))
    {
        Text = (TextBox)Items[1].Control;
    }

    public TextBox Text { get; set; }
}