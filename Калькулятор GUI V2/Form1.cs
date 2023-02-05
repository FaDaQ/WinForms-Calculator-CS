using System.Data;
using System.Runtime.InteropServices;

namespace Калькулятор_GUI_V2
{
    public partial class Form1 : Form
    {
        abstract class ACalcButton : Button
        {
            public ACalcButton()
            {
                mainButton.Font = new Font("Comic Sans MS", 20);
                mainButton.FlatStyle = FlatStyle.Flat;
                mainButton.FlatAppearance.BorderSize = 0;
            }

            public void Place(Form form)
            {
                form.Controls.Add(mainButton);
            }
            new protected virtual void Click(object sender, EventArgs e)
            {
                Label.Text = (Label.Text == "0")
                                       ? mainButton.Text
                                       : Label.Text + mainButton.Text;
            }

            public Button mainButton { get; protected set; } = new Button();
            public Label Label { get; protected set; } = new Label();
        }
        class StdCalcButton : ACalcButton
        {
            public StdCalcButton(int digit, Label label, Point location, int width, int height)
            {
                mainButton.Size = new Size(width, height);
                mainButton.Location = location;
                mainButton.Text = digit.ToString();
                mainButton.BackColor = Color.FromArgb(19, 20, 19);
                mainButton.ForeColor = Color.White;
                Label = label;
                mainButton.Click += Click;
            }
        }
        class EqualButton : ACalcButton
        {
            public EqualButton(Label label, Point location, int width, int height)
            {
                mainButton.Size = new Size(width, height);
                mainButton.Location = location;
                mainButton.Text = "=";
                mainButton.BackColor = Color.FromArgb(19, 20, 19);
                mainButton.ForeColor = Color.White;
                mainButton.Click += Click;
                Label = label;
            }
            protected override void Click(object sender, EventArgs e)
            {
                try
                {
                    Label.Text = new DataTable().Compute(Label.Text, null).ToString().Replace(',', '.');
                    if (Label.Text == "∞")
                    {
                        MessageBox.Show("Ошибка!");
                        Label.Text = "0";
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка!");
                    Label.Text = "0";
                }
            }
        }
        class ActionSignButton : ACalcButton
        {
            public ActionSignButton(string actSign, Label label, Point location, int width, int height)
            {
                mainButton.Size = new Size(width, height);
                mainButton.Location = location;
                mainButton.Text = actSign;
                mainButton.BackColor = Color.FromArgb(201, 121, 34);
                Label = label;
                mainButton.Click += Click;
            }
        }
        class EraseButton : ACalcButton
        {
            public EraseButton(string text, Label label, Point location, int width, int height)
            {
                mainButton.Size = new Size(width, height);
                mainButton.Location = location;
                mainButton.Text = text;
                Label = label;
                mainButton.BackColor = Color.FromArgb(19, 20, 19);
                mainButton.ForeColor = Color.White;
                mainButton.Click += Click;
            }

            new private void Click(object sender, EventArgs e)
            {
                try
                {
                    Label.Text = Label.Text.Substring(0, Label.Text.Length - 1);
                }
                catch
                {

                }
            }
        } 
        class ClearButton : ACalcButton
        {
            public ClearButton(string clearSymbol, Label label, Point location, int width, int height)
            {
                mainButton.Size = new Size(width, height);
                mainButton.Location = location;
                mainButton.Text = clearSymbol;
                mainButton.BackColor = Color.FromArgb(19, 20, 19);
                mainButton.ForeColor = Color.White;
                Label = label;
                mainButton.Click += Click;
            }

            new private void Click(object sender, EventArgs e)
            {
                Label.Text = "0";
            }
        }

        public Form1()
        {
            InitializeComponent();
            this.Text = "GUI Калькулятор v2";
            this.BackColor = Color.FromArgb(43, 42, 40);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ExpressionPanel.BackColor = Color.Transparent;
            this.CloseButton.Click += Close;
            this.MinimizeButton.Click += Minimize;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.MinimizeButton.FlatAppearance.BorderSize = 0;
            this.MouseDown += DragWindow;

            List<ACalcButton> calcBtns = new List<ACalcButton>();

            int startBtnPosX = (this.Size.Width / 2) - 200;
            int endBtnPosX = 300;
            int startBtnPosY = 140;
            int stdBtnWidth = 100;
            int stdBtnHeight = 100;
            Point btnPos = new Point(startBtnPosX, startBtnPosY);

            foreach (int digit in "123456789".Select(digit => int.Parse(digit.ToString())))
            {
                calcBtns.Add(new StdCalcButton(digit, Expression, btnPos, stdBtnWidth, stdBtnHeight));
                btnPos = (btnPos.X >= endBtnPosX) ? new Point(startBtnPosX, btnPos.Y + stdBtnHeight)
                                                  : new Point(btnPos.X + stdBtnWidth, btnPos.Y);
                switch (digit)
                {
                    case 2:
                        int posY = 0; //Дополнительная позиция по Y, чтобы смещать кнопки вниз
                        int posX = btnPos.X + 100; //Дополнительная позиция по X, чтобы смещать кнопки влево
                        foreach (char symb in "+-*/")
                        {
                            calcBtns.Add(new ActionSignButton(symb.ToString(), Expression,
                                         new Point(btnPos.X + 100, btnPos.Y + posY), stdBtnWidth - 10, stdBtnHeight));
                            posY += 100;
                        }
                        calcBtns.Add(new EraseButton("<", Expression,
                                     new Point(btnPos.X + stdBtnWidth, btnPos.Y + posY), stdBtnWidth - 10, stdBtnHeight));

                        posY -= 100;
                        calcBtns.Add(new ActionSignButton(".", Expression,
                                     new Point(posX -= stdBtnWidth, btnPos.Y + posY), stdBtnWidth, stdBtnHeight));
                        calcBtns.Add(new EqualButton(Expression,
                                     new Point(posX, btnPos.Y + posY + stdBtnHeight), stdBtnWidth, stdBtnHeight));
                        calcBtns.Add(new StdCalcButton(0, Expression,
                                     new Point(posX -= stdBtnWidth, btnPos.Y + posY), stdBtnWidth, stdBtnHeight));
                        calcBtns.Add(new ClearButton("C", Expression,
                                     new Point(posX -= stdBtnWidth, btnPos.Y + posY), stdBtnWidth, stdBtnHeight));
                        calcBtns.Add(new ActionSignButton("(", Expression,
                                     new Point(posX, btnPos.Y + (posY += stdBtnHeight)),
                                     stdBtnWidth, stdBtnHeight));
                        calcBtns.Add(new ActionSignButton(")", Expression,
                                     new Point(posX += stdBtnWidth, btnPos.Y + posY),
                                     stdBtnWidth, stdBtnHeight));
                        break;
                }
                
            }

            foreach (var button in calcBtns)
                button.Place(this);

        }

        private void Minimize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DragWindow(object sender,
        System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
    }
}