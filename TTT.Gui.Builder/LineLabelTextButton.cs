namespace TTT.Gui.Builder;

public class LineLabelTextButton : Line
{
    public LineLabelTextButton(params LineItem[] items) : base(items)
    {
    }

    public static LineLabelTextButton Create(string label,
        string text,
        string button,
        int labelSize = 2,
        int textSize = 6,
        int buttonSize = 2)
    {
        var textControl = GuiBuilder.CreateTextBox(text);
        var buttonControl = GuiBuilder.CreateButton(button);

        var result = new LineLabelTextButton(
            CreateLabel(label, labelSize), 
            Create(textControl, textSize), 
            Create(buttonControl,buttonSize))
        {
            TextControl = textControl,
            ButtonControl= buttonControl
        };
        return result;
    }

    public Button ButtonControl { get; set; }

    public TextBox TextControl { get; set; }
}