using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavWinUi3App
{
    public class Contact
    {
        #region Properties
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Company { get; private set; }
        public string Name => FirstName + " " + LastName;
        #endregion

        public Contact(string firstName, string lastName, string company)
        {
            FirstName = firstName;
            LastName = lastName;
            Company = company;
        }

        #region Public Methods
        //public async static Task<ObservableCollection<Contact>> GetContactsAsync()
        //{
        //    IList<string> lines = await FileLoader.LoadLines("Assets/Contacts.txt");

        //    ObservableCollection<Contact> contacts = new ObservableCollection<Contact>();

        //    for (int i = 0; i < lines.Count - 2; i += 3)
        //    {
        //        contacts.Add(new Contact(lines[i], lines[i + 1], lines[i + 2]));
        //    }

        //    return contacts;
        //}

        //public static async Task<ObservableCollection<GroupInfoList>> GetContactsGroupedAsync()
        //{
        //    var query = from item in await GetContactsAsync()
        //                group item by item.LastName.Substring(0, 1).ToUpper() into g
        //                orderby g.Key
        //                select new GroupInfoList(g) { Key = g.Key };

        //    return new ObservableCollection<GroupInfoList>(query);
        //}

        public override string ToString()
        {
            return $"{Name}, {Company}";
        }
        #endregion
    }

    public class GroupInfoList : List<object>
    {
        public GroupInfoList(IEnumerable<object> items) : base(items)
        {
        }
        public object Key { get; set; }

        public override string ToString()
        {
            return "Group " + Key.ToString();
        }
    }
}

