// Licensed under the MIT license. See https://kieranties.mit-license.org/ for full license information.

using SimpleVersion.Model;

namespace SimpleVersion.Pipeline
{
    /// <summary>
    /// Contract for the calculation process.
    /// Enables collection of processes and invocation to get version results.
    /// </summary>
    public interface IVersionCalculator
    {
        /// <summary>
        /// Adds a  processor to the calculation process.
        /// </summary>
        /// <typeparam name="T">The processor to add.</typeparam>
        /// <returns>An instance of <see cref="IVersionCalculator"/> with the processor addded.</returns>
        IVersionCalculator AddProcessor<T>() where T : IVersionProcessor, new();

        /// <summary>
        /// Invokes the chain of processors to get a <see cref="VersionResult"/>.
        /// </summary>
        /// <param name="path">The path to the repository to version.</param>
        /// <returns>The resulting <see cref="VersionResult"/>.</returns>
        VersionResult GetResult(string path);
    }
}