namespace TTT.Gui.Builder;

public class Line
{
    public Line(params LineItem[] items)
    {
        Items = items;
        var col = 0;
        foreach (var item in items)
        {
            //if (item.ColSpan < 0) item.ColSpan = 1;
            if (item.Col >= 0) continue;
            item.Col = col;
            col += item.ColSpan;
        }
    }

    public LineItem[] Items { get; }

    public static LineItem Create(Control control, int width, int height = 1)
    {
        return new LineItem(control, colSpan: width, rowSpan: height);
    }

    public static LineItem CreateButton(string text, int size, EventHandler? onClick = null)
    {
        if (onClick is null) return Create(GuiBuilder.CreateButton(text), size);
        var button = GuiBuilder.CreateButton(text);
        button.Click += onClick;
        return Create(button, size);
    }

    public static LineItem CreateLabel(string text, int size)
    {
        return Create(GuiBuilder.CreateLabel(text), size);
    }

    // ReSharper disable once UnusedMember.Global
    public static LineItem CreateTextBox(string text, int size, bool multiLines = false)
    {
        return Create(GuiBuilder.CreateTextBox(text, multiLines), size);
    }

    public static LineItem CreateComboBox(int size, params object[] texts)
    {
        return Create(GuiBuilder.CreateComboBox(texts), size);
    }
}