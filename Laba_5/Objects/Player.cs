using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Laba_5.Objects
{
    //Класс игрока
    class Player : BaseObject
    {
        private Pen outlineBlack = new Pen(Brushes.Black, 2);
        private Pen outlineWhite = new Pen(Brushes.White, 2);

        private Pen direction = new Pen(Brushes.Purple, 3);
        public Action<Marker> OnMarkerOverlap;
        public Action<Apple> OnAppleOverlap;

        public float vX { get; set; }
        public float vY { get; set; }
        public Player(float x, float y, float angle) : base(x, y, angle){}

        //Отрисовывает объект
        public override void Render(Graphics g)
        {
            Brush color = IsOverlaped ? Brushes.White : Brushes.LightSkyBlue;
            g.FillEllipse(color, new RectangleF(-15, -15, 30, 30));
            g.DrawEllipse(IsOverlaped ? outlineWhite : outlineBlack, -15, -15, 30, 30);
            g.DrawLine(direction, 0, 0, 0, -25);
        }

        //Возвращает контур объекта
        public override GraphicsPath GetGraphicsPath()
        {
            var path = new GraphicsPath();
            path.AddEllipse(-15, -15, 30, 30);
            return path;
        }

        //Событие пересечения игрока с каким-то объектом наследником BaseObject
        public void Overlap(BaseObject obj)
        {
            if (obj is Marker)
            {
                OnMarkerOverlap(obj as Marker);
            }

            if(obj is Apple)
            {
                OnAppleOverlap(obj as Apple);
            }
        }
    }
}
