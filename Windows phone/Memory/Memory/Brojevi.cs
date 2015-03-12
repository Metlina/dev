using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    public class Brojevi : INotifyPropertyChanged
    {
        Random random = new Random();

        public event PropertyChangedEventHandler PropertyChanged;

        private List<int> brojeviList = new List<int>()
        {
            '1', '1', '2', '2', '3', '3', '4', '4', '5', '5',
            '6', '6', '7', '7', '8', '8', '9', '9', '0', '0'
        };

        private int broj;

        public int BrojeviProp {
            get { return broj; }
            set
            {
                broj = random.Next(brojeviList.Count);
                broj = value;
                NotifyPropertyChanged("brojevi");
            }
        }
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
