using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace HolidayOffice.Core.Models
{
    public partial class Foglalas : ObservableObject
    {
        [ObservableProperty]
        private string nev;

        [ObservableProperty]
        private decimal osszeg;

        [ObservableProperty]
        private int foglalasokSzama;
    }
}
