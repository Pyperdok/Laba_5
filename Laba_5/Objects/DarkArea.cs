using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Laba_5.Objects
{
    //Класс темной области
    class DarkArea : BaseObject
    {
        public float Width  { get;}
        public float Height { get; }
        public DarkArea(float x, float y, float width, float height) : base(x, y, 0) 
        {
            Width = width;
            Height = height;
        }

        //Отрисовывает объект
        public override void Render(Graphics g)
        {
            g.FillRectangle(Brushes.Black, new RectangleF(0, 0, Width, Height));
        }

        //Возвращает контур объекта
        public override GraphicsPath GetGraphicsPath()
        {
            var path = new GraphicsPath();
            RectangleF rect = new RectangleF(0, 0, Width, Height);
            path.AddRectangle(rect);
            return path;
        }

        //Проверяет и обесцвечивает список объектов BaseObject, если они пересекают темную область
        public void OverlapCheck(List<BaseObject> objects, Graphics g)
        {
            foreach(var obj in objects.ToList())
            {
                if (obj is DarkArea) continue;

                bool IsOverlaped = false;
                if(Overlaps(obj, g))
                {
                    IsOverlaped = true;
                }
                obj.IsOverlaped = IsOverlaped;
            }
        }
    }
}
