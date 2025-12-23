using Lomzie.AutomaticWorkAssignment.Defs;
using System;
using System.Linq;
using Verse;

namespace Lomzie.AutomaticWorkAssignment
{
    /// <summary>
    /// Abstract base class for all plugin settings.
    /// Handles Def linkage and common serialization patterns.
    /// Most plugin implementations (IPawnFitness, IPawnCondition, IPawnPostProcessor) inherit from this.
    /// See CLAUDE.md "Base Class Pattern" section for usage examples.
    /// </summary>
    public abstract class PawnSetting : IPawnSetting
    {
        public string Label => Def.LabelCap;
        public string Description => Def.description;

        private PawnSettingDef _def;
        public PawnSettingDef Def { get => _def; private set => _def = value; }

        public static T CreateFrom<T>(PawnSettingDef def) where T : IPawnSetting
        {
            T setting = (T)Activator.CreateInstance(def.settingClass);
            if (setting is PawnSetting pawnSetting)
            {
                pawnSetting.Def = def;
            }
            return setting;
        }

        public virtual void ExposeData()
        {
            Scribe_Defs.Look(ref _def, "def");
            if (Scribe.mode == LoadSaveMode.PostLoadInit)
            {
                if (Def == null)
                {
                    Def = DefDatabase<PawnSettingDef>.AllDefs.First(x => x.settingClass == GetType());
                }
            }
        }
    }
}
