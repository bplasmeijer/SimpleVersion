// Licensed under the MIT license. See https://kieranties.mit-license.org/ for full license information.

using System.Linq;
using SimpleVersion.Pipeline;

namespace SimpleVersion.Tokens
{
    /// <summary>
    /// Handles formatting of label parts.
    /// </summary>
    public class LabelTokenHandler : ITokenHandler
    {
        /// <inheritdoc/>
        public string Key => "label";

        /// <inheritdoc/>
        public string Process(string? optionValue, IVersionContext context, ITokenEvaluator evaluator)
        {
            Assert.ArgumentNotNull(context, nameof(context));
            Assert.ArgumentNotNull(evaluator, nameof(evaluator));

            if (optionValue == null)
            {
                optionValue = ".";
            }

            var parts = context.Configuration.Label.Select(l => evaluator.Process(l, context)).ToList();
            if (!context.Result.IsRelease)
            {
                parts.Add(evaluator.Process("c{sha:7}", context));
            }

            return string.Join(optionValue, parts);
        }
    }
}
