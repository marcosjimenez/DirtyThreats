using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyThreats.Services.Model
{
    public class UrlCheck
    {
        /// <summary>
        /// Target url
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public string Url { get; set; }

        /// <summary>
        /// Total number of validations
        /// </summary>
        public int CheckCount { get; set; }

        /// <summary>
        /// Number of positives found
        /// </summary>
        public int Positives { get; set; }

        /// <summary>
        /// Sources checked
        /// </summary>
        public List<CheckResult> Sources { get; set; }

    }

    /// <summary>
    /// Check results
    /// </summary>
    public class CheckResult
    {

        /// <summary>
        /// Source name
        /// </summary>
        public string SourceName { get; set; }

        /// <summary>
        /// Total number of validations
        /// </summary>
        public int CheckCount { get; set; }

        /// <summary>
        /// Number of positives found
        /// </summary>
        public int Positives { get; set; }

        /// <summary>
        /// Result messages
        /// </summary>
        public List<string> Messages { get; set; }

    }
}
