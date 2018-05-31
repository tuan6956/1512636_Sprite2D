using _1512636_Sprite2D.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1512636_Sprite2D
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        const int widthPlayer = 64;
        const int heightPlayer = 64;
        bool _changeImage = false;
        Bitmap _bm = new Bitmap(Resources.Monster);


        Sprite _player = new Sprite(50, 50, 0, 0, widthPlayer, heightPlayer, StateAction.Down, StateAction.Standing);
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        object syncPlayer = new object();
        private void draw()
        {
            Graphics g = this.CreateGraphics();
            //g.DrawImage(bm,0,0);
            BufferedGraphicsContext doubleBuffer = BufferedGraphicsManager.Current;
            BufferedGraphics buf = doubleBuffer.Allocate(g, this.ClientRectangle);
            buf.Graphics.Clear(Color.White);
            _player.movePlayer(buf, _bm);
            buf.Render(g);
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (!_isMovePlayer)
                draw();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            _player.action = StateAction.Standing;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    _player.action = StateAction.Down;
                    break;
                case Keys.Up:
                    _player.action = StateAction.Up;
                    break;
                case Keys.Left:
                    _player.action = StateAction.Left;
                    break;
                case Keys.Right:
                    _player.action = StateAction.Right;
                    break;
                case Keys.Oemplus:
                    timer.Interval -= 5;
                    break;
                case Keys.OemMinus:
                    timer.Interval += 5;
                    break;
                case Keys.S:
                    timer.Stop();
                    break;
                case Keys.P:
                    timer.Start();
                    break;
                case Keys.B:
                    _bm = !_changeImage ? new Bitmap(Resources.images) : new Bitmap(Resources.Monster);
                    _changeImage = !_changeImage;
                    _player.heightActor = _bm.Height / 4;
                    _player.widthtActor = _bm.Height / 4;
                    _player.realHeight = _player.heightActor;
                    _player.realWidth = _player.realWidth;
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;
                case Keys.Oem4:
                    _player.realWidth -= 2;
                    _player.realHeight -= 2;
                    break;
                case Keys.Oem6:
                    _player.realWidth += 2;
                    _player.realHeight += 2;
                    break;
                default:
                    break;
            }
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMovePlayer)
            {
                _player.x = e.X - _player.realWidth / 2;
                _player.y = e.Y - _player.realHeight / 2;
                draw();
            }
        }
        bool _isMovePlayer = false;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.X > _player.x && e.X < (_player.x + _player.realWidth)) && (e.Y > _player.y && (e.Y < _player.y + _player.realHeight)))
            {
                _isMovePlayer = true;

            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            _isMovePlayer = false;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add("Tăng tốc độ");
                menu.Items.Add("Giảm tốc độ");
                menu.Items.Add("Phóng to");
                menu.Items.Add("Thu nhỏ");
                menu.Items.Add("Tiếp tục hoạt đông");
                menu.Items.Add("Tạm dừng hoạt đông");
                menu.Items.Add("Thay đổi nhân vật");
                menu.Items.Add("Thoát chương trình");
                menu.ItemClicked += Menu_ItemClicked;
                menu.Show(new Point(e.X + 150, e.Y + 100));

            }
        }

        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            if (item.Text.Contains("Tăng tốc độ"))
                timer.Interval -= 5;
            if (item.Text.Contains("Giảm tốc độ"))
                timer.Interval -= 5;
            if (item.Text.Contains("Phóng to"))
            {
                _player.realWidth += 2;
                _player.realHeight += 2;
            }
            if (item.Text.Contains("Thu nhỏ"))
            {
                _player.realWidth -= 2;
                _player.realHeight -= 2;
            }
            if (item.Text.Contains("Tiếp tục hoạt đông"))
                timer.Start();
            if (item.Text.Contains("Tạm dừng hoạt đông"))
                timer.Stop();
            if (item.Text.Contains("Thay đổi nhân vật"))
            {
                _bm = !_changeImage ? new Bitmap(Resources.images) : new Bitmap(Resources.Monster);
                _changeImage = !_changeImage;
                _player.heightActor = _bm.Height / 4;
                _player.widthtActor = _bm.Height / 4;
                _player.realHeight = _player.heightActor;
                _player.realWidth = _player.realWidth;
            }
            if (item.Text.Contains("Thoát chương trình"))
                Application.Exit();

        }
    }
}
