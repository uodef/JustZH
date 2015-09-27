﻿using Server.Mobiles;
using Server.Targeting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Spells.Zulu.EarthSpells
{
    public class SummonMammal : EarthSpell
    {
        private static readonly SpellInfo m_Info = new SpellInfo(
            "Summon Mammals", "Chame O Mamifero Agora",
            16,
            false,
            Reagent.SerpentsScales,
            Reagent.PigIron,
            Reagent.EyeofNewt);
        // NOTE: Creature list based on 1hr of summon/release on OSI.
        // JustZH fix this list
        private static readonly Type[] m_Types = new Type[] // fix this list
        {
            typeof(PolarBear),
            typeof(GrizzlyBear),
            typeof(BlackBear),
            typeof(Walrus),
            typeof(Scorpion),
            typeof(GiantSerpent),
            typeof(Llama),
            typeof(Alligator),
            typeof(GreyWolf),
            typeof(Slime),
            typeof(Gorilla),
            typeof(SnowLeopard)
        };
        public SummonMammal(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override bool CheckCast()
        {
            if (!base.CheckCast())
                return false;

            if ((this.Caster.Followers + 3) > this.Caster.FollowersMax)
            {
                this.Caster.SendLocalizedMessage(1049645); // You have too many followers to summon that creature.
                return false;
            }

            return true;
        }

        public override TimeSpan CastDelayBase
        {
            get
            {
                return TimeSpan.FromSeconds(2);
            }
        }
        public override double RequiredSkill
        {
            get
            {
                return 85; // dunno about this, gotta check
            }
        }
        public override int RequiredMana
        {
            get
            {
                return 5;
            }
        }

        public override void OnCast()
        {
            setCords(Caster.Y, Caster.X);
            if (this.CheckSequence())
            {
                int count = 0;
                do{
                try
                {
                    BaseCreature creature = (BaseCreature)Activator.CreateInstance(m_Types[Utility.Random(m_Types.Length)]);

                    //creature.ControlSlots = 2;

                    TimeSpan duration;

                    if (Core.AOS)
                        duration = TimeSpan.FromSeconds((2 * this.Caster.Skills.Magery.Fixed) / 5);
                    else
                        duration = TimeSpan.FromSeconds(4.0 * this.Caster.Skills[SkillName.Magery].Value);

                    SpellHelper.Summon(creature, this.Caster, 0x215, duration, false, false);
                    count++;
                }
                catch
                {
                }
                    }while( count > 3 );
            }

            this.FinishSequence();
        }

        public override TimeSpan GetCastDelay()
        {
            if (Core.AOS)
                return TimeSpan.FromTicks(base.GetCastDelay().Ticks * 5);

            return base.GetCastDelay() + TimeSpan.FromSeconds(6.0);
        }
    }
}