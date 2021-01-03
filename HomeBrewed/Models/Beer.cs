using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBrewed.Models
{
    /// <summary>
    /// A beer object.
    /// </summary>
    public class Beer
    {
        /// <summary>
        /// The beer identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Human-friendly beer name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Intantiates a beer with the given properties.
        /// </summary>
        /// <param name="id">The beer identifier.</param>
        /// <param name="name">Human-friendly beer name.</param>
        public Beer(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
