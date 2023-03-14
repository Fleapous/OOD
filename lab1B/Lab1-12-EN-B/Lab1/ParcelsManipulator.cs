using System;

namespace Lab1
{
    public static class ParcelsManipulator
    {
        public static IParcel ChangeParcelWeight(IParcel parcel, float weight)
        {
            return new ChangeWeight(parcel, weight);
        }

        public static IParcel ChangeParcelCubature(IParcel parcel, float cubature)
        {
            return new ChangeCubature(parcel, cubature);
        }
    
        public static IParcel MakeParcelFragile(IParcel parcel, FragilityType fr
        )
        {
            return new MakeFragile(parcel, fr);
        }

        public static IParcel MakeParcelExpress(IParcel parcel, int daysDecrease)
        {
            return new MakeExpress(parcel, daysDecrease);
        }
    
        public static IParcel SetParcelAsForgotten(IParcel parcel)
        {
            return new SetAsForgotten(parcel);
        }
        
    }

    public class mainParcel : IParcel
    {
        protected IParcel _parcel;

        public mainParcel(IParcel Parcel)
        {
            _parcel = Parcel;
        }

        string IParcel.Name => _parcel.Name;

        DateTime IParcel.DeliveryDate => _parcel.DeliveryDate;

        float IParcel.Weight => _parcel.Weight;

        public virtual string GetDescription()
        {
            return _parcel.GetDescription();
        }

        public virtual float GetCubature()
        {
            return _parcel.GetCubature();
        }

        public virtual string ToString()
        {
            return _parcel.ToString();
        }


    }

    public class ChangeWeight : mainParcel
    {
        public float _weight;

        public float Weight
        {
            get
            {
                return _weight;
            }
        }

        public ChangeWeight(IParcel Parcel, float Weight) : base(Parcel)
        {
            _weight = Weight;
        }


        public override float GetCubature()
        {
            return base.GetCubature();
        }

        public override string GetDescription()
        {
            return base.GetDescription();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class ChangeCubature : mainParcel
    {
        public float _cubature;

        public DateTime DeliveryDate
        {
            get
            {
                float tmp = _cubature / _parcel.GetCubature() * 2;
                return DeliveryDate.AddDays(tmp);
            }
        }


        public ChangeCubature(IParcel p, float c) : base(p)
        {
            _cubature = c;
        }

        public override float GetCubature()
        {
            return _cubature;
        }


    }

    public class MakeFragile : mainParcel
    {
        public float Weight
        {
            get
            {
                return _parcel.Weight * 2;
            }
        }

        FragilityType fr;
        
        public MakeFragile(IParcel p, FragilityType f) : base(p)
        {
            fr = f;
        }

        public override string GetDescription()
        {
            return fr.ToString();
        }
    }

    public class MakeExpress : mainParcel
    {
        int _days;
        public DateTime DeliveryDate
        {
            get
            {
                return DeliveryDate.AddDays(-_days);
            }
        }

        public MakeExpress(IParcel p, int days) : base(p)
        {
            _days = days;
        }

        public override float GetCubature()
        {
            return _parcel.Weight / 2;
        }
    }

    public class SetAsForgotten : mainParcel
    {
        public DateTime Max = DateTime.MaxValue;

        public float Weight
        {
            get
            {
                Random rnd = new Random();
                double tmp = rnd.Next(0, 2);
                tmp = tmp * 3 + 0.5;
                float ans = (float)tmp;
                return ans;
                
            }
        }

        public SetAsForgotten(IParcel Parcel) : base(Parcel)
        {
        }

        public DateTime DeliveryDate
        {
            get
            {
                return Max;
            }
        }
    }
}