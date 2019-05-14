// Licensed under the MIT license. See https://kieranties.mit-license.org/ for full license information.

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SimpleVersion.Model
{
    /// <summary>
    /// Models the result object returned from version calculation.
    /// </summary>
    public class VersionResult
    {
        private static readonly Regex _prRegex = new Regex(@"^refs\/pull\/(?<id>\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// Gets or sets the generated version.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the generated major version part.
        /// </summary>
        public int Major { get; set; } = 0;

        /// <summary>
        /// Gets or sets the generated minor version part.
        /// </summary>
        public int Minor { get; set; } = 0;

        /// <summary>
        /// Gets or sets the generated patch version part.
        /// </summary>
        public int Patch { get; set; } = 0;

        /// <summary>
        /// Gets or sets the generated revision version part.
        /// </summary>
        public int Revision { get; set; } = 0;

        /// <summary>
        /// Gets or sets the calculated height.
        /// </summary>
        public int Height { get; set; } = 0;

        /// <summary>
        /// Gets or sets the calculated height for the current branch.
        /// </summary>
        public int BranchHeight { get; set; } = 0;

        /// <summary>
        /// Gets the height as a 0 padded four digit string.
        /// </summary>
        public string HeightPadded => Height.ToString("D4", System.Globalization.CultureInfo.CurrentCulture);

        /// <summary>
        /// Gets or sets the full sha of the current commit.
        /// </summary>
        public string Sha { get; set; }

        /// <summary>
        /// Gets or sets the friendly branch name of the current branch.
        /// </summary>
        public string BranchName { get; set; }

        /// <summary>
        /// Gets or sets the full canonical name of the current branch.
        /// </summary>
        public string CanonicalBranchName { get; set; }

        /// <summary>
        /// Gets a value indicating whether the current branch is a pull request.
        /// </summary>
        public bool IsPullRequest => _prRegex.IsMatch(CanonicalBranchName);

        /// <summary>
        /// Gets the pull request number (if the current branch is a pull request).
        /// </summary>
        public int PullRequestNumber => int.TryParse(_prRegex.Match(CanonicalBranchName).Groups["id"].Value, out var id) ? id : 0;

        /// <summary>
        /// Gets or sets the path to the repository.
        /// </summary>
        public string RepositoryPath { get; set; }

        /// <summary>
        /// Gets the collection of generated version strings.
        /// </summary>
        public IDictionary<string, string> Formats { get; } = new Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
    }
}
