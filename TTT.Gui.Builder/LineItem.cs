namespace TTT.Gui.Builder;

public class LineItem
{
    public Control Control { get; set; }
    public int Row { get; set; }
    public int Col { get; set; }
    public int RowSpan { get; set; }
    public int ColSpan { get; set; }

    /// <summary>
    /// </summary>
    /// <param name="control"></param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <param name="rowSpan"></param>
    /// <param name="colSpan"></param>
    public LineItem(Control control, int row = -1, int col = -1, int rowSpan = -1, int colSpan = -1)
    {
        Control = control;
        Row = row;
        Col = col;
        RowSpan = rowSpan;
        ColSpan = colSpan;
    }
}