namespace TTT.Gui.Builder;

public class LineLabelTextButton : Line
{
    public LineLabelTextButton(string label,
        string text,
        string button,
        int labelSize = 2,
        int textSize = 6,
        int buttonSize = 2) : base(
        CreateLabel(label, labelSize),
        CreateTextBox(text, textSize),
        CreateButton(button, buttonSize))
    {
        Text = (TextBox)Items[1].Control;
        Button = (Button)Items[2].Control;
    }

    public Button Button { get; set; }

    public TextBox Text { get; set; }
}