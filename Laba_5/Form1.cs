using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Laba_5.Objects;

namespace Laba_5
{
    //Класс формы
    public partial class Form1 : Form
    {
        Player player;
        Marker marker;
        DarkArea DarkArea;

        List<BaseObject> objects = new List<BaseObject>();
        Random random = new Random();
        private int score = 0;

        private int RandX { get => random.Next(0, PB_Main.Width); }
        private int RandY { get => random.Next(0, PB_Main.Height); }

        private bool DarkAreaDirection = true;

        //Конструктор окна Form1
        public Form1()
        {           
            InitializeComponent();
            player = new Player(PB_Main.Width / 2f, PB_Main.Height / 2f, 0);
            DarkArea = new DarkArea(-500, 0, PB_Main.Width / 3f, PB_Main.Height);

            player.OnAppleOverlap += (a) =>
            {
                objects.Remove(a);
                objects.Add(new Apple(RandX, RandY, 0));
                L_Score.Text = $"Score: {++score}";
            };

            player.OnMarkerOverlap += (m) =>
            {
                player.vX = 2.5f;
                player.vY = 2.5f;
                objects.Remove(m);
                marker = null;
            };

            objects.Add(DarkArea);
            objects.Add(new Apple(RandX, RandY, 0));
            objects.Add(new Apple(RandX, RandY, 0));
            objects.Add(player);
        }

        //Перерисовывает форму
        private void PB_Main_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.White);

            //Overlap check
            foreach (var obj in objects.ToList())
            {
                if (obj != player && player.Overlaps(obj, g))
                {
                    player.Overlap(obj);
                }

                if(obj is DarkArea) //Dark Area Check
                {
                    (obj as DarkArea).OverlapCheck(objects, g);
                }
            }

            //Render
            foreach (var obj in objects)
            {
                g.Transform = obj.GetTransform();
                obj.Render(g);
            }
        }

        //Обновляет положение игрока
        private void UpdatePlayer()
        {
            if (marker != null)
            {
                float dx = marker.X - player.X;
                float dy = marker.Y - player.Y;

                float length = (float)Math.Sqrt(dx * dx + dy * dy);
                dx /= length;
                dy /= length;

                player.vX += dx * 1.5f;
                player.vY += dy * 1.5f;

                player.Angle = (float)(180 - Math.Atan2(player.vX, player.vY) * 180 / Math.PI);

                player.vX -= player.vX * 0.1f;
                player.vY -= player.vY * 0.1f;

                player.X += player.vX;
                player.Y += player.vY;
            }
        }

        //Обновляет положение темной области
        public void UpdateDarkArea()
        {
            DarkAreaDirection = DarkArea.X < PB_Main.Width ? true : false;
            if (DarkAreaDirection) {
                DarkArea.X += 5;
            }
            else
            {
                DarkArea.X = -500;
            }
        }

        //Таймер. Срабатывает каждые 30 милисекунд
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdatePlayer();
            UpdateDarkArea();
            PB_Main.Invalidate();
        }

        //Вызывается каждый раз, когда пользователь кликает на форму 
        //(В основном это попытка установить маркер для движения игрока)
        private void PB_Main_MouseClick(object sender, MouseEventArgs e)
        {
            if (marker == null)
            {
                marker = new Marker(e.X, e.Y, 0);
                objects.Add(marker);
            }

            marker.X = e.X;
            marker.Y = e.Y;
        }
    }
}
