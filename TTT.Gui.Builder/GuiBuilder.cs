namespace TTT.Gui.Builder;

public class GuiBuilder
{
    
    // ReSharper disable once UnusedMember.Global
    public static SplitContainer CreateSplitContainer(Control panel1, Control panel2)
    {
        var splitContainer1 = new SplitContainer();

        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();

        splitContainer1.Dock = DockStyle.Fill;
        splitContainer1.Location = new Point(0, 0);
        splitContainer1.Margin = new Padding(4);
        splitContainer1.Name = nameof(SplitContainer);
        splitContainer1.Orientation = Orientation.Horizontal;
        splitContainer1.Size = new Size(0, 0);
        splitContainer1.SplitterDistance = 100;
        splitContainer1.SplitterWidth = 5;
        splitContainer1.TabIndex = 0;

        splitContainer1.Panel1.Controls.Add(panel1);
        splitContainer1.Panel2.Controls.Add(panel2);

        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel1.PerformLayout();
        splitContainer1.Panel2.ResumeLayout(false);
        splitContainer1.Panel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        splitContainer1.PerformLayout();
        return splitContainer1;
    }

    public static T CreateControl<T>() where T : Control, new()
    {
        return new T
        {
            Dock = DockStyle.Fill,
            Location = new Point(0, 0),
            Margin = new Padding(4),
            Size = new Size(0, 0),
            Name = nameof(CreateControl),
            TabIndex = 0,
            TabStop = false,
        };
    }

    public static TabControl CreateTabControl(params TabPage[] pages)
    {
        var tabControl = new TabControl();
        tabControl.SuspendLayout();
        tabControl.Controls.AddRange(pages.Cast<Control>().ToArray());
        tabControl.Location = new Point(0, 0);
        tabControl.Name = nameof(TabControl);
        tabControl.SelectedIndex = 0;
        tabControl.Size = new Size(0, 0);
        tabControl.TabIndex = 0;
        tabControl.Dock = DockStyle.Fill;
        tabControl.ResumeLayout(false);
        tabControl.PerformLayout();
        return tabControl;
    }

    // ReSharper disable once UnusedMember.Global
    public static MenuStrip CreateMenu(params ToolStripItem[] items)
    {
        var menuStrip1 = new MenuStrip();
        menuStrip1.SuspendLayout();
        menuStrip1.GripMargin = new Padding(2, 2, 0, 2);
        menuStrip1.ImageScalingSize = new Size(24, 24);
        menuStrip1.Items.AddRange(items);
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = nameof(MenuStrip);
        menuStrip1.Size = new Size(0, 0);
        menuStrip1.TabIndex = 0;
        menuStrip1.Text = "";
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        return menuStrip1;
    }

    // ReSharper disable once UnusedMember.Global
    public static ToolStripMenuItem CreateMenuItem(string text, EventHandler onClick, params ToolStripItem[] dropItems)
    {
        var item = new ToolStripMenuItem
        {
            Name = nameof(ToolStripMenuItem),
            Size = new Size(0, 0),
            Text = text
        };
        if(dropItems.Length>0) item.DropDownItems.AddRange(dropItems);
        item.Click += onClick;
        return item;
    }

    public static TabPage CreateTabPage(string text, params Control[] controls)
    {
        var page = new TabPage();
        page.SuspendLayout();
        page.Controls.AddRange(controls);
        page.Location = new Point(0, 0);
        page.Name = nameof(TabPage);
        page.Padding = new Padding(3);
        page.Size = new Size(0, 0);
        page.TabIndex = 0;
        page.Text = text;
        page.UseVisualStyleBackColor = true;
        page.ResumeLayout(false);
        page.PerformLayout();
        return page;
    }

    public static Line CreateLine(params LineItem[] items)
    {
        return new Line(items);
    }

    public static Form CreateForm(string text,int width, int height, params Control[] controls)
    {
        var form = new Form();
        //foreach (var control in controls) if (control is System.ComponentModel.ISupportInitialize o) o.BeginInit();
        form.SuspendLayout();
        form.AutoScaleDimensions = new SizeF(15F, 33F);
        form.AutoScaleMode = AutoScaleMode.Inherit;
        form.ClientSize = new Size(width, height);
        form.Font = new Font("Tahoma",
            10.125F,
            FontStyle.Regular,
            GraphicsUnit.Point,
            0);
        form.Margin = new Padding(4, 4, 4, 4);
        form.Name = nameof(Form);
        form.StartPosition = FormStartPosition.CenterScreen;
        form.Text = text;
        
        form.Controls.AddRange(controls);

        var menu = controls.FirstOrDefault(control => control is MenuStrip);
        if (menu is not null) form.MainMenuStrip = (MenuStrip)menu;

        form.ResumeLayout(false);
        form.PerformLayout();
        //foreach (var control in controls) if (control is System.ComponentModel.ISupportInitialize o) o.EndInit();
        return form;
    }

    public static TextBox CreateTextBox(string text, bool multiLines = false, bool border = true)
    {
        var textBox = new TextBox
        {
            Multiline = multiLines,
            Dock = DockStyle.Fill,
            Location = new Point(0, 0),
            Margin = new Padding(4, 4, 4, 4),
            Name = nameof(TextBox),
            Size = new Size(0, 0),
            TabIndex = 0,
            Text = text,
            BorderStyle = border?BorderStyle.FixedSingle:BorderStyle.None,
            ReadOnly = false,
            WordWrap = false,
        };
        return textBox;
    }

    public static ComboBox CreateComboBox(params object[] texts)
    {
        var comboBox = new ComboBox
        {
            Dock = DockStyle.Fill,
            Location = new Point(0, 0),
            Margin = new Padding(4, 4, 4, 4),
            Name = nameof(TextBox),
            Size = new Size(0, 0),
            TabIndex = 0,
        };
        comboBox.Items.AddRange(texts);
        comboBox.SelectedIndex = 0;
        return comboBox;
    }

    public static Button CreateButton(string text)
    {
        var button = new Button
        {
            Dock = DockStyle.Fill,
            Location = new Point(0, 0),
            Name = nameof(Button),
            Size = new Size(0, 0),
            TabIndex = 0,
            Text = text,
            UseVisualStyleBackColor = true
        };
        return button;
    }

    public static Label CreateLabel(string text, Font font, Color backColor)
    {
        var label = CreateLabel(text);
        label.Font = font;
        label.BackColor = backColor;
        return label;
    }

    // ReSharper disable once UnusedMember.Global
    public static Label CreateTitle(string text)
    {
        var font = new Font("Tahoma",
            13.875F,
            FontStyle.Bold,
            GraphicsUnit.Point,
            0);
        return CreateLabel(text, font, Color.White);
    }

    public static Label CreateLabel(string text)
    {
        var label = new Label
        {
            AutoSize = true,
            Dock = DockStyle.Fill,
            Location = new Point(0, 0),
            Margin = new Padding(4, 0, 4, 0),
            Name = nameof(Label),
            Size = new Size(0, 0),
            TabIndex = 0,
            Text = text,
            TextAlign = ContentAlignment.MiddleLeft
        };
        return label;
    }

    private static void CreateTableColumns(TableLayoutPanel table, nint count = 10)
    {
        table.ColumnCount = (int)count;
        for (var i = 0; i < count; i++) table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100/ count));
    }

    private static void CreateTableRows(TableLayoutPanel table, nint count, float height = 33f)
    {
        table.RowCount = (int)count;
        for (var i = 0; i < count; i++) table.RowStyles.Add(new RowStyle(SizeType.Absolute, height));
    }

    public static TableLayoutPanel CreateTable(params Line[] lines)
    {
        var table = new TableLayoutPanel
        {
            Name = nameof(TableLayoutPanel) + DateTime.Now.Ticks,
            Location = new Point(0, 0),
            Margin = new Padding(4, 4, 4, 4),
            Size = new Size(100, 100),
            TabIndex = 0,
            Dock = DockStyle.Fill,
            //BorderStyle = BorderStyle.FixedSingle
            //CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
        };
        
        table.SuspendLayout();

        var row = 0;
        foreach (var line in lines)
        {
            foreach (var item in line.Items)
            {
                if (item.Row >= 0) continue;
                item.Row = row;
            }

            row += line.Items.Length>0? line.Items.Max(item => item.RowSpan):1;
        }
        
        CreateTableColumns(table);
        CreateTableRows(table, row);

        foreach (var line in lines)
        {
            foreach (var item in line.Items)
            {
                table.Controls.Add(item.Control,item.Col, item.Row);
                if (item.ColSpan > 1) table.SetColumnSpan(item.Control, item.ColSpan);
                if (item.RowSpan > 1) table.SetRowSpan(item.Control, item.RowSpan);
            }
        }

        table.ResumeLayout(false);
        table.PerformLayout();
        return table;
    }
}