using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    class TrieWithOneChild : ITrie
    {
        
            private bool _hasEmptyString;
            private ITrie _child;
            private char _childLabel;

            public TrieWithOneChild(string s, bool hasEmpty)
            {
                if (s == "" || s[0] < 'a' || s[0] > 'z')
                {
                    throw new ArgumentException();
                }
            _hasEmptyString = hasEmpty;
            _childLabel = s[0];
            _child = new TrieWithNoChildren().Add(s.Substring(1));
            }

        public ITrie Add(string s)
        {
            if (s == "")
            {
                _hasEmptyString = true;
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            else if (s[0].Equals(_childLabel))
            {
                _child = _child.Add(s.Substring(1));
            }
            else
            {
                return new TrieWithManyChildren(s, _hasEmptyString, _childLabel, _child);
            }
            return this;
        }

        public bool Contains(string s)
            {
                if (s == "")
                {
                    return false;
                }
                else if (s[0].Equals(_childLabel))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
    }

