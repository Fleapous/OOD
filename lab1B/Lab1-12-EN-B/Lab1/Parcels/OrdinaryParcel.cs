using System;

namespace Lab1
{
    public class OrdinaryParcel: IParcel
    {
        private readonly string _name;
        public string Name
        {
            get => _name;
            init => _name = value;
        }

        private readonly DateTime _deliveryDate;
        public DateTime DeliveryDate
        {
            get => _deliveryDate;
            init => _deliveryDate = value;
        }

        private readonly float _weight;
        public float Weight
        {
            get => _weight;
            init => _weight = value;
        }
        public string GetDescription()
        {
            return "OrdinaryParcel";
        }
        
        public float GetCubature()
        {
            return 5.0f;
        }

        public override string ToString()
        {
            return
                $"\nParcel: {Name}\nWeight: {Weight}\nCubature: {GetCubature()}\nDescription: {GetDescription()}\nDelivery date: {DeliveryDate}\n";
        }
    }
}