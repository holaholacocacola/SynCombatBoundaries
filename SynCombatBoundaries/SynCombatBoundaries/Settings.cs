using System.Collections.Generic;

using Mutagen.Bethesda;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.FormKeys.SkyrimSE;
using Mutagen.Bethesda.Synthesis.Settings;

namespace SynCombatBoundaries
{
    class Settings
    {
        // default settings will allow for npcs and vampire npcs
        [SynthesisOrder]
        [SynthesisSettingName("Enable NPC Swimming in Combat")]
        [SynthesisDescription("Allows NPCS to Swim in combat")]
        [SynthesisTooltip("Allows NPCS to Swim in combat")]
        public bool AllowNpcs { get; set; } = true;
        [SynthesisOrder]
        [SynthesisSettingName("Enable Undead Swimming in Combat")]
        [SynthesisDescription("Allows Undead(e.g Draugr) to Swim in combat")]
        [SynthesisTooltip("Allows Undead(e.g Draugr) to Swim in combat")]
        public bool AllowUndead { get; set; } = true;
        [SynthesisOrder]
        [SynthesisSettingName("Enable Vampire Swimming in Combat")]
        [SynthesisDescription("Allows Vampires to Swim in combat")]
        [SynthesisTooltip("Allows Vampires to Swim in combat")]
        public bool AllowVampire { get; set; } = true;
        [SynthesisOrder]
        [SynthesisSettingName("Enable Creatures Swimming in Combat")]
        [SynthesisDescription("Allows Creature(e.g Wolves, Falmer) to Swim in combat")]
        [SynthesisTooltip("Allows Creatures(e.g. Wolves, Falmer) to Swim in combat")]
        public bool AllowCreatures { get; set; } = false;
        [SynthesisOrder]
        [SynthesisSettingName("Enable Trolls Swimming in Combat")]
        [SynthesisDescription("Allows Trolls(Not Nexus Trolls) to Swim in combat")]
        [SynthesisTooltip("Allows Trolls(Not nexus trolls) to Swim in combat")]
        public bool AllowTrolls { get; set; } = false;
        [SynthesisOrder]
        [SynthesisSettingName("Enable Horse Swimming in Combat")]
        [SynthesisDescription("Allows Horses to Swim in combat")]
        [SynthesisTooltip("Allows Horses to Swim in combat")]
        public bool AllowHorse { get; set; } = false;
        [SynthesisOrder]
        [SynthesisSettingName("Enable Giant Swimming in Combat")]
        [SynthesisDescription("Allows Giants to Swim in combat")]
        [SynthesisTooltip("Allows Giants to Swim in combat")]
        public bool AllowGiant { get; set; } = false;
        [SynthesisOrder]
        [SynthesisSettingName("Enable Daedra Swimming in Combat")]
        [SynthesisDescription("Allows Daedra to Swim in combat")]
        [SynthesisTooltip("Allows Daedra to Swim in combat")]
        public bool AllowDaedra { get; set; } = false;
        [SynthesisOrder]
        [SynthesisSettingName("Enable Dwarven Machines Swimming in Combat")]
        [SynthesisDescription("Allows Dwarven Machines to Swim in combat")]
        [SynthesisTooltip("Allows Dwarven Machines to Swim in combat")]
        public bool AllowDwarven { get; set; } = false;
        
        private HashSet<FormLink<Keyword>> allowedKeywords, disallowedKeywords;

        public Settings() 
        {
            allowedKeywords = new() ; // We process any races that has these keywords
            disallowedKeywords = new(); // We skip any race that has these keywords
            // Fun part :|

            SetAllowable(this.AllowNpcs, Skyrim.Keyword.ActorTypeNPC.FormKey);
            SetAllowable(this.AllowUndead, Skyrim.Keyword.ActorTypeUndead.FormKey);
            SetAllowable(this.AllowVampire, Skyrim.Keyword.Vampire.FormKey);
            SetAllowable(this.AllowCreatures, Skyrim.Keyword.ActorTypeCreature.FormKey);
            SetAllowable(this.AllowTrolls, Skyrim.Keyword.ActorTypeTroll.FormKey);
            SetAllowable(this.AllowHorse, Skyrim.Keyword.ActorTypeHorse.FormKey);
            SetAllowable(this.AllowGiant, Skyrim.Keyword.ActorTypeGiant.FormKey);
            SetAllowable(this.AllowDwarven, Skyrim.Keyword.ActorTypeDwarven.FormKey);


        }

        private void SetAllowable(bool allowType, FormLink<Keyword> kwyd)
        {
            if (allowType)
                allowedKeywords.Add(kwyd.FormKey);
            else
                disallowedKeywords.Add(kwyd.FormKey);
        }

        public bool EnableWaterCombatTracking()
        {
            return this.allowedKeywords.Count > 0;
        }

        public HashSet<FormLink<Keyword>> GetAllowedWaterCombatKeys()
        {
            return this.allowedKeywords;
        }

        public HashSet<FormLink<Keyword>> GetNoWaterCombatKeys()
        {
            return this.disallowedKeywords;
        }
    }
}
