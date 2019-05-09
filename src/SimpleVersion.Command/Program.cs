// Licensed under the MIT license. See https://kieranties.mit-license.org/ for full license information.

using Newtonsoft.Json;
using SimpleVersion.Pipeline;
using System;

namespace SimpleVersion.Command
{
    /// <summary>
    /// Commandline entry point.
    /// </summary>
    public sealed class Program
    {
        /// <summary>
        /// Entry point for SimpleVersion invocation.
        /// </summary>
        /// <param name="args">The array of arguments.</param>
        /// <returns>0 if success, otherwise an error exit code.</returns>
        public static int Main(string[] args)
        {
            var exitCode = 0;
            try
            {
                var path = System.IO.Directory.GetCurrentDirectory();
                if (args.Length > 0)
                    path = args[0];

                var result = VersionCalculator
                    .Default()
                    .GetResult(path);

                Console.Out.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
            {
                Console.Error.WriteLine($"[Error] {ex.Message}");
                exitCode = -1;
            }
#pragma warning restore CA1031 // Do not catch general exception types

            return exitCode;
        }
    }
}