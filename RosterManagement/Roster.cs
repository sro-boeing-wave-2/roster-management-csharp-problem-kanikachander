using System;
using System.Linq;
using System.Collections.Generic;

namespace RosterManagement
{
    public class CodeSchool
    {
        Dictionary<int, List<string>> _roster;

        public CodeSchool()
        {
            _roster = new Dictionary<int, List<String>>();
        }
        
        /// <summary>
        /// Should be able to Add Student to a Particular Wave
        /// </summary>
        /// <param name="cadet">Refers to the name of the Cadet</param>
        /// <param name="wave">Refers to the Wave number</param>
        public void Add(string cadet, int wave)
        {
            List<string> list = new List<string>();
            if (_roster.ContainsKey(wave))
            {
                _roster[wave].Add(cadet);
            }
            else
            {
                list.Add(cadet);
                _roster.Add(wave, list);
            }
            _roster[wave].Sort();
        }

        /// <summary>
        /// Returns all the Cadets in a given wave
        /// </summary>
        /// <param name="wave">Refers to the wave number from where cadet list is to be fetched</param>
        /// <returns>List of Cadet's Name</returns>
        public List<string> Grade(int wave)
        {
            var list = new List<string>();
            if (_roster.ContainsKey(wave))
            {
                list = _roster[wave];
                list.Sort();
            }
            return list;
        }

        /// <summary>
        /// Return all the cadets in the CodeSchool
        /// </summary>
        /// <returns>List of Cadet's Name</returns>
        public List<string> Roster()
        {
            var cadets = new List<string>();
            foreach(int wave in _roster.Keys.OrderBy(i => i).ToList())
            {
                var list = new List<string>();
                list = _roster[wave];
                list.OrderBy(p => p).ToList();
                cadets.AddRange(list);
            };
            return cadets;
        }
    }
}
