using System.Drawing;
using System.Drawing.Drawing2D;

namespace Laba_5.Objects
{
    //Супер-класс, который задает базовое состояние и поведение для объектов на форме(Игрока, Яблок, Маркеров и тд)
    abstract class BaseObject
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Angle { get; set; }
        public bool IsOverlaped { get; set; } //Перекрыт ли объект темной областью

        protected BaseObject(float x, float y, float angle)
        {
            X = x;
            Y = y;
            Angle = angle;
        }

        //Возвращает матрицу трансформации для объекта
        public Matrix GetTransform()
        {
            Matrix matrix = new Matrix();
            matrix.Translate(X, Y);
            matrix.Rotate(Angle);
            return matrix;
        }
        
        //Возвращает true если два объекта пересекаются друг с другом, иначе - false
        public bool Overlaps(BaseObject obj, Graphics g)
        {
            var path1 = GetGraphicsPath();
            var path2 = obj.GetGraphicsPath();

            path1.Transform(GetTransform());
            path2.Transform(obj.GetTransform());

            var region = new Region(path1);
            region.Intersect(path2);
            return !region.IsEmpty(g);
        }

        //Возвращает контур объекта
        public abstract GraphicsPath GetGraphicsPath();

        //Отрисовывает объект
        public abstract void Render(Graphics g);
    }
}
