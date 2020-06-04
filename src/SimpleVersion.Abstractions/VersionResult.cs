// Licensed under the MIT license. See https://kieranties.mit-license.org/ for full license information.

using System.Collections.Generic;

namespace SimpleVersion
{
    /// <summary>
    /// Models the result object returned from version calculation.
    /// </summary>
    public class VersionResult
    {
        private string _sha = default!;

        /// <summary>
        /// Gets or sets the generated version.
        /// </summary>
        public string Version { get; set; } = default!;

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
        /// Gets the height as a 0 padded four digit string.
        /// </summary>
        public string HeightPadded => Height.ToString("D4", System.Globalization.CultureInfo.CurrentCulture);

        /// <summary>
        /// Gets or sets the full sha of the current commit.
        /// </summary>
        public string Sha
        {
            get => _sha;
            set
            {
                _sha = value;
                if (_sha != null)
                {
                    Sha7 = _sha.Length > 7 ? _sha.Substring(0, 7) : _sha;
                }
            }
        }

        /// <summary>
        /// Gets the shortened (7 char) sha of the current commit.
        /// </summary>
        public string Sha7 { get; private set; } = default!;

        /// <summary>
        /// Gets or sets the friendly branch name of the current branch.
        /// </summary>
        public string BranchName { get; set; } = default!;

        /// <summary>
        /// Gets or sets the full canonical name of the current branch.
        /// </summary>
        public string CanonicalBranchName { get; set; } = default!;

        /// <summary>
        /// Gets a value indicating whether the current branch is a pull request.
        /// </summary>
        public bool IsPullRequest => PullRequestNumber > 0;

        /// <summary>
        /// Gets or sets the pull request number (if the current branch is a pull request).
        /// </summary>
        public int PullRequestNumber { get; set; } = 0;

        /// <summary>
        /// Gets or sets the path to the repository.
        /// </summary>
        public string RepositoryPath { get; set; } = default!;

        /// <summary>
        /// Gets or sets a value indicating whether the result is from a release configuration.
        /// </summary>
        public bool IsRelease { get; set; } = false;

        /// <summary>
        /// Gets the collection of generated version strings.
        /// </summary>
        public IDictionary<string, string> Formats { get; } = new Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
    }
}
