using Verse;

namespace Lomzie.AutomaticWorkAssignment.Amounts
{
    /// <summary>
    /// Calculates dynamic worker counts for work specifications.
    /// Examples: fixed number, percentage of colonists, based on stockpile size, farm area, etc.
    /// </summary>
    public interface IPawnAmount : IExposable
    {
        public string LabelCap { get; }
        public string Description { get; }
        public string Icon { get; }

        int GetCount(WorkSpecification workSpecification, ResolveWorkRequest request);
    }
}
