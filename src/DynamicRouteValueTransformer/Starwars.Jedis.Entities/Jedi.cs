using System;
using System.Text;

namespace Starwars.Jedis.Entities
{
    public class Jedi
    {
        private const char WHITESPACE_CHAR = ' ';
        private const char HYPHEN_CHAR = '-'; 

        public int Id { get; set; }
        public string Name { get; set; }

        public Jedi(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Return the name to format url. 
        /// Example: Obi-Wan Kenobi > obi-wan-kenobi
        /// </summary>
        public string Endpoint { 
            get{
                return RemoveSpecialCharacters(Name.Replace(WHITESPACE_CHAR, HYPHEN_CHAR))
                       .ToLower();
            } 
        }

        private string RemoveSpecialCharacters(string str)
        {
            var sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') 
                    || (c >= 'A' && c <= 'Z') 
                    || (c >= 'a' && c <= 'z') 
                    || c == '-')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
