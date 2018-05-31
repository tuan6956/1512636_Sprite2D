using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1512636_Sprite2D
{
    public enum StateAction
    {
        Left, Right, Up, Down,
        Standing, Walking
    }
    class Sprite
    {
        public int x { get; set; }
        public int y { get; set; }

        public int dx { get; set; }
        public int dy { get; set; }


        public int widthtActor { get; set; }
        public int heightActor { get; set; }

        public int indexColumnImage { get; set; }
        public int indexRowImage { get; set; }

        public StateAction direction { get; set; }
        public StateAction action { get; set; }

        public int realHeight { get; set; }
        public int realWidth { get; set; }

        public Sprite(int x, int y, int dx, int dy, int width, int height, StateAction dir, StateAction act)
        {
            this.x = x;
            this.y = y;
            this.dx = dx;
            this.dy = dy;
            this.widthtActor = width;
            this.heightActor = height;
            direction = dir;
            action = act;
            realHeight = this.heightActor;
            realWidth = this.widthtActor;
        }
        public void drawPlayer(BufferedGraphics buffer, Bitmap bm)
        {
            Rectangle recPlayer = new Rectangle(indexColumnImage * this.widthtActor, this.indexRowImage * this.heightActor, widthtActor, heightActor);
            Rectangle size_player = new Rectangle(x, y, realWidth, realHeight);
            buffer.Graphics.DrawImage(bm, size_player, recPlayer, GraphicsUnit.Pixel);
            x += dx;
            y += dy;
        }
        public void movePlayer(BufferedGraphics buffer, Bitmap bm)
        {
            switch (action)
            {
                case StateAction.Left:
                    {
                        indexRowImage = 1;
                        if (indexColumnImage >= 0 && indexColumnImage < 3)
                            indexColumnImage++;
                        else
                        {
                            indexColumnImage = 0;
                            dx = -10; dy = 0;
                            direction = StateAction.Left;
                        }
                    }
                    break;
                case StateAction.Right:
                    {
                        indexRowImage = 2;
                        if (indexColumnImage >= 0 && indexColumnImage < 3)
                            indexColumnImage++;
                        else
                        {
                            indexColumnImage = 0;
                            dx = 10; dy = 0;
                            direction = StateAction.Right;
                        }
                    }
                    break;
                case StateAction.Up:
                    {
                        indexRowImage = 3;
                        if (indexColumnImage >= 0 && indexColumnImage < 3)
                            indexColumnImage++;
                        else
                        {
                            indexColumnImage = 0;
                            dx = 0; dy = -10;
                            direction = StateAction.Up;
                        }
                    }
                    break;
                case StateAction.Down:
                    {
                        indexRowImage = 0;
                        if (indexColumnImage >= 0 && indexColumnImage < 3)
                            indexColumnImage++;
                        else
                        {
                            indexColumnImage = 0;
                            dx = 0; dy = 10;
                            direction = StateAction.Down;
                        }
                    }
                    break;
                case StateAction.Standing:
                    {
                        dx = 0;
                        dy = 0;
                        switch (direction)
                        {   
                            case StateAction.Left:
                                indexColumnImage = 0;
                                indexRowImage = 1;
                                break;
                            case StateAction.Right:
                                indexColumnImage = 0;
                                indexRowImage = 2;
                                break;
                            case StateAction.Up:
                                indexColumnImage = 0;
                                indexRowImage = 3;
                                break;
                            case StateAction.Down:
                                indexColumnImage = 0;
                                indexRowImage = 0;
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }
            this.drawPlayer(buffer, bm);
        }
    }
}
