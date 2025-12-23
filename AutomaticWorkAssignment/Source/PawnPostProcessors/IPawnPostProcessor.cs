using Verse;

namespace Lomzie.AutomaticWorkAssignment.PawnPostProcessors
{
    /// <summary>
    /// Executes side effects when a pawn is assigned to a work specification.
    /// Examples: set apparel policy, allowed area, schedule, etc.
    /// </summary>
    public interface IPawnPostProcessor : IPawnSetting
    {
        void PostProcess(Pawn pawn, WorkSpecification workSpecification, ResolveWorkRequest request);
    }
}
