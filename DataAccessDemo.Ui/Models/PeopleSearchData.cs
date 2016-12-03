//  --------------------------------------------------------------------------------------
// DataAccessDemo.Ui.PeopleSearchData.cs
// 2016/12/03
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace DataAccessDemo.Ui.Models
{
    public class PeopleSearchData
    {
        public PeopleSearchData(IEnumerable<Person> people)
        {
            People = people.ToList();
            HeaderText = $"{People.Count()} result(s) found:";
        }

        public IEnumerable<Person> People { get; }
        public string HeaderText { get; }
    }
}