namespace CreateButtons
{
    public partial class Form1 : Form
    {
        private static bool isClick = false;
        private static int amountBtn = 0;

        private Point startPoint;
        private Button b;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Run Button";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateButton()
        {
            // ������ ������
            b = new Button();
            b.Text = "button_" + (++amountBtn);
            this.Controls.Add(b);
        }

        private bool CheckBtnSize()
        {
            // �������� �� ���������� ������ ������
            return b.Width >= 25 && b.Height >= 25;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            isClick = true;
            startPoint = new Point(e.X, e.Y);  // ��������� ��������� �����

            CreateButton();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isClick = false;

            if (!CheckBtnSize())
            {
                MessageBox.Show("������ ������� ���������!", "��������������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Controls.Remove(b);
                amountBtn--;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // ���� ������ �� ���� ���� ������
            if (isClick)
            {
                // ���� ������ � ����� �������
                if (e.X < startPoint.X)
                {
                    // ���� ������ �����
                    if (e.Y < startPoint.Y)
                    {
                        b.Location = new Point(startPoint.X - b.Width, startPoint.Y - b.Height);
                        b.Size = new Size(startPoint.X - e.X, startPoint.Y - e.Y);
                    }

                    // ���� ������ ����
                    else
                    {
                        b.Location = new Point(startPoint.X - b.Width, startPoint.Y);
                        b.Size = new Size(startPoint.X - e.X, e.Y - startPoint.Y);
                    }
                }

                // ���� ������ � ������ �������
                else
                {
                    // ���� ������ �����
                    if (e.Y < startPoint.Y)
                    {
                        b.Location = new Point(startPoint.X, startPoint.Y - b.Height);
                        b.Size = new Size(e.X - startPoint.X, startPoint.Y - e.Y);
                    }

                    // ���� ������ ����
                    else
                    {
                        b.Location = new Point(startPoint.X, startPoint.Y);
                        b.Size = new Size(e.X - startPoint.X, e.Y - startPoint.Y);
                    }
                }
            }
        }
    }
}