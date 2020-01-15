using Xamarin.Forms;

namespace RentApp.Controls
{
    public class GradientStop
    {
        private float offset;
        public float Offset
        {
            get => offset;
            set
            {
                if (value > 1)
                    value = 1;
                else if (value < 0)
                    value = 0;
                offset = value;
            }
        }
        public Color Color { get; set; }
    }
}
