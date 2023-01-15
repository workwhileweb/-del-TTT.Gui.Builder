namespace TTT.Gui.Builder.Sample
{
    internal static class Program
    {
        public static Form Test3()
        {
            var lineImage = new LineLabelTextButton("hình ảnh", "...", "load");
            lineImage.Button.Click += (_, _) =>
            {
                MessageBox.Show(lineImage.Text.Text);
            };
            var buttonLoadLanguage = Line.CreateButton("nạp", 2, (_, _) =>
            {
                var ofd = new OpenFileDialog
                {
                    DefaultExt = @"traineddata",
                    Filter = @"language file|*.traineddata|All files|*.*"
                };
                ofd.ShowDialog();
            });
            var combo = Line.CreateComboBox(6, "Full Page OCR", "Text Region Detection");
            var lineLanguage = GuiBuilder.CreateLine(buttonLoadLanguage, combo);
            var image = GuiBuilder.CreateControl<PictureBox>();
            var pageImage = GuiBuilder.CreateTabPage("hình ảnh", image);
            var textBoxOcr = GuiBuilder.CreateTextBox("", true, false);
            var pageOcr = GuiBuilder.CreateTabPage("ocr", textBoxOcr);
            var textBoxHOcr = GuiBuilder.CreateTextBox("", true, false);
            var pageHOcr = GuiBuilder.CreateTabPage("hOcr", textBoxHOcr);
            var tab = GuiBuilder.CreateTabControl(pageImage, pageOcr, pageHOcr);
            var lineTab = GuiBuilder.CreateLine(Line.Create(tab, 10, 10));
            var table = GuiBuilder.CreateTable(lineImage, lineLanguage, lineTab);
            return GuiBuilder.CreateForm("OCR", 400, 600, table);
        }

        public static Form Test2()
        {
            var line = new LineLabelTextButton("điền giá trị", "nhập giá trị ở đây", "bấm tui");
            line.Button.Click += (_, _) =>
            {
                MessageBox.Show(line.Text.Text);
            };
            return GuiBuilder.CreateForm("xin chào", 400, 600, GuiBuilder.CreateTable(line, new Line()));
        }

        public static Form Test()
        {
            var lbl = Line.CreateLabel("điền giá trị", 2);
            var txt = GuiBuilder.CreateTextBox("nhập giá trị ở đây");
            var btn = Line.CreateButton("bấm tui", 2, (_, _) =>
            {
                MessageBox.Show(txt.Text);
            });
            var line = GuiBuilder.CreateLine(lbl, Line.Create(txt, 6), btn);
            var table = GuiBuilder.CreateTable(line,new Line());
            return GuiBuilder.CreateForm("xin chào", 400, 600, table);
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //TODO : chưa tương thích chế độ HiDPI
            //ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(GuiBuilder.CreateForm("thử nghiệm",
                200,
                300,
                GuiBuilder.CreateTable(
                    GuiBuilder.CreateLine(Line.CreateButton("thử nghiệm 1", 10, (_, _) => { Test().Show(); })),
                    GuiBuilder.CreateLine(Line.CreateButton("thử nghiệm 2",10,(_, _) => {Test2().Show();})),
                    GuiBuilder.CreateLine(Line.CreateButton("thử nghiệm 3",10,(_, _) => {Test3().Show();})))));
        }
    }
}