using Microsoft.CodeAnalysis.CSharp.Scripting;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Калькулятор_GUI_V2
{
    public partial class Form1 : Form
    {
        abstract class ACalcButton : Button
        {
            public ACalcButton()
            {
                mainButton.Font = new Font("Arial", 20);
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
        class DigitButton : ACalcButton
        {
            public DigitButton(int digit, Label label, Point location, int width, int height)
            {
                mainButton.Size = new Size(width, height);
                mainButton.Location = location;
                mainButton.Text = digit.ToString();
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
                mainButton.Click += Click;
                Label = label;
            }
            protected override void Click(object sender, EventArgs e)
            {
                try
                {
                    Label.Text = new DataTable().Compute(Label.Text, null).ToString().Replace(',', '.');
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
                Label = label;
                mainButton.Click += Click;
            }
        }

        public Form1()
        {
            InitializeComponent();
            this.Text = "GUI Калькулятор v2";

            List<ACalcButton> calcBtns = new List<ACalcButton>();

            int FirstBtnPosX = 40;
            int btnWidth = 100;
            int btnHeight = 100;
            Point buttonPos = new Point(FirstBtnPosX, 140);
            //calcBtns.Add(new ActionSignButton("(", Expression, new Point(buttonPos.X - 10, buttonPos.Y), 40, btnHeight));

            for (int i = 1; i <= 9; i++)
            {
                calcBtns.Add(new DigitButton(i, Expression, buttonPos, btnWidth, btnHeight));
                if (buttonPos.X < 212)
                    buttonPos.X += btnWidth;
                else
                {
                    buttonPos.X = FirstBtnPosX;
                    buttonPos.Y += btnHeight;
                }

            }
      
            calcBtns.Add(new ActionSignButton("%", Expression, new Point(FirstBtnPosX, buttonPos.Y), btnWidth, btnHeight));
            calcBtns.Add(new ActionSignButton("*", Expression, new Point(buttonPos.X + 300, buttonPos.Y), 80, 100));
            calcBtns.Add(new ActionSignButton("/", Expression, new Point(buttonPos.X + 300, buttonPos.Y -= 100), 80, 100));
            calcBtns.Add(new ActionSignButton("+", Expression, new Point(buttonPos.X + 300, buttonPos.Y -= 100), 80, 100));
            calcBtns.Add(new ActionSignButton("-", Expression, new Point(buttonPos.X + 300, buttonPos.Y -= 100), 80, 100));

            buttonPos = new Point(FirstBtnPosX, 440);
            calcBtns.Add(new DigitButton(0, Expression, new Point(buttonPos.X += btnWidth, buttonPos.Y), btnWidth, btnHeight));
            
            calcBtns.Add(new EqualButton(Expression, new Point(buttonPos.X += btnWidth, buttonPos.Y), btnWidth, btnHeight));

            buttonPos.X += 180; buttonPos.Y -= 300;
            calcBtns.Add(new ActionSignButton(")", Expression, buttonPos, 40, btnHeight));
            buttonPos.X = FirstBtnPosX - 40;
            calcBtns.Add(new ActionSignButton("(", Expression, buttonPos, 40, btnHeight));

            foreach (var button in calcBtns)
                button.Place(this);
        }
    }
}