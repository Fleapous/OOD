using System;
using System.Text;

namespace Lab1
{
    public interface IParcel
    {
        public string Name { get; }

        public DateTime DeliveryDate { get; }

        public float Weight { get; }

        public string GetDescription();

        public float GetCubature();

        public string ToString();
    }
}