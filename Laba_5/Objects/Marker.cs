using System.Drawing;
using System.Drawing.Drawing2D;

namespace Laba_5.Objects
{
    //Класс маркера
    class Marker : BaseObject
    {
        private Pen penRed = new Pen(Brushes.Red, 2);
        private Pen penWhite = new Pen(Brushes.White, 2);
        public Marker(float x, float y, float angle) : base(x, y, angle) { }

        //Отрисовывает объект
        public override void Render(Graphics g)
        {
            g.FillEllipse(IsOverlaped ? Brushes.White : Brushes.Red, -3, -3, 6, 6);
            g.DrawEllipse(IsOverlaped ? penWhite : penRed, -6, -6, 12, 12);
            g.DrawEllipse(IsOverlaped ? penWhite : penRed, -10, -10, 20, 20);
        }

        //Возвращает контур объекта
        public override GraphicsPath GetGraphicsPath()
        {
            var path = new GraphicsPath();
            path.AddEllipse(-3, -3, 6, 6);
            return path;
        }
    }
}
