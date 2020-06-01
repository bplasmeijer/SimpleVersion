// Licensed under the MIT license. See https://kieranties.mit-license.org/ for full license information.

using SimpleVersion.Pipeline;

namespace SimpleVersion.Tokens
{
    /// <summary>
    /// Represents a token which can be replaced for a value evaluated from the
    /// current version context.
    /// </summary>
    public interface ITokenHandler
    {
        /// <summary>
        /// Gets the key for this token.
        /// </summary>
        public abstract string Key { get; }

        /// <summary>
        /// When called will return a value based on the given option.
        /// </summary>
        /// <param name="optionValue">The optional value to modify the result.</param>
        /// <param name="context">The current version context.</param>
        /// <param name="evaluator">The <see cref="ITokenEvaluator"/> for chained evaluation.</param>
        /// <returns>A value resolved for this token.</returns>
        public abstract string Process(string? optionValue, IVersionContext context, ITokenEvaluator evaluator);
    }
}