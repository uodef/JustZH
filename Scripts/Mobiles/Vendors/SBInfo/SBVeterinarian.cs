using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
    public class SBVeterinarian : SBInfo
    {
        private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();
        public SBVeterinarian()
        {
        }

        public override IShopSellInfo SellInfo
        {
            get
            {
                return base.m_SellInfo;
            }
        }
        public override List<GenericBuyInfo> BuyInfo
        {
            get
            {
                return this.m_BuyInfo;
            }
        }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
               // this.Add(new GenericBuyInfo(typeof(Bandage), 6, 20, 0xE21, 0));
                this.Add(new AnimalBuyInfo(1, typeof(Cat), 130, 10, 201, 0));
                this.Add(new AnimalBuyInfo(1, typeof(Dog), 170, 10, 217, 0));
                this.Add(new AnimalBuyInfo(1, typeof(Horse), 550, 10, 204, 0));
                this.Add(new AnimalBuyInfo(1, typeof(PackHorse), 630, 10, 291, 0));
                this.Add(new AnimalBuyInfo(1, typeof(PackLlama), 550, 10, 292, 0));
                this.Add(new AnimalBuyInfo(1, typeof(Rabbit), 100, 10, 205, 0));
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                this.Add(typeof(Bandage), 1);
            }
        }
    }
}