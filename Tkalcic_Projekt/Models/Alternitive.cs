using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tkalcic_Projekt.Models
{
    public class Alternative : INotifyPropertyChanged
    {
        private string name;
        public string Name { get 
            {
                return name;
            } set 
            {
                name = value;
                NotifyPropertyChanged();
            } 
        }
        public double Usefulness { get; set; }
        public double Result { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Alternative()
        {

        }

        public Alternative(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
