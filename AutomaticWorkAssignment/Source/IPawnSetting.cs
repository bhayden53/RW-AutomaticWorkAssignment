using Lomzie.AutomaticWorkAssignment.Defs;
using Verse;

namespace Lomzie.AutomaticWorkAssignment
{
    /// <summary>
    /// Base interface for all plugin settings in the Def-based plugin system.
    /// All plugin types (IPawnFitness, IPawnCondition, IPawnPostProcessor) extend this interface.
    /// Requires IExposable for save/load functionality.
    /// </summary>
    public interface IPawnSetting : IExposable
    {
        PawnSettingDef Def { get; }
        string Label { get; }
        string Description { get; }
    }
}
