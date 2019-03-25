using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    /// <summary>
    /// An interface for a trie.
    /// </summary>
    public interface ITrie
    {
        /// <summary>
        /// Determines whether this trie contains the given string.
        /// </summary>
        /// <param name="s">The string to look for.</param>
        /// <returns>Whether this trie contains s.</returns>
        bool Contains(string s);

        /// <summary>
        /// Adds the given string to this trie.
        /// </summary>
        /// <param name="s">The string to add.</param>
        /// <returns>The resulting trie.</returns>
        ITrie Add(string s);
    }

    public class TrieWithNoChildren : ITrie
    {
        private bool _hasEmpty = false;
        public ITrie Add(string s)
        {

            if (s == "")
            {
                _hasEmpty = true;
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            else
            {
                TrieWithOneChild t = new TrieWithOneChild(s, _hasEmpty);
                return t;
            }
            return this;
        }

        public bool Contains(string s)
        {
           return false;
        }
    }
}
