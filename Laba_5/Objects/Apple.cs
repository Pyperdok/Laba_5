using System.Drawing;
using System.Drawing.Drawing2D;

namespace Laba_5.Objects
{
    //Класс яблока
    class Apple : BaseObject
    {
        public Apple(float x, float y, float angle) : base(x, y, angle) { }

        //Отрисовывает объект
        public override void Render(Graphics g)
        {
            g.FillEllipse(IsOverlaped ? Brushes.White : Brushes.Lime, new RectangleF(-15, -15, 30, 30));
        }

        //Возвращает контур объекта
        public override GraphicsPath GetGraphicsPath()
        {
            var path = new GraphicsPath();
            path.AddEllipse(-15, -15, 30, 30);
            return path;
        }

    }
}
