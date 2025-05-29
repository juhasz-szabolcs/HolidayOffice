using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HolidayOffice.Core.Models;

namespace HolidayOffice.Core.ViewModels
{
    public partial class FoglalasViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Foglalas> foglalasok = new()
        {
            new Foglalas { Nev = "Abigail_Cooper", Osszeg = 427550, FoglalasokSzama = 2 },
            new Foglalas { Nev = "Isabella_Garcia", Osszeg = 322100, FoglalasokSzama = 1 }
        };

        [ObservableProperty]
        private Foglalas? kivalasztottFoglalas;

        [ObservableProperty]
        private bool szerkesztesLatszik;

        [ObservableProperty]
        private Foglalas szerkesztettFoglalas = new();

        // Új foglalás hozzáadása
        [RelayCommand]
        private void UjFoglalas()
        {
            SzerkesztettFoglalas = new Foglalas();
            SzerkesztesLatszik = true;
            KivalasztottFoglalas = null;
        }

        // Szerkesztés
        [RelayCommand]
        private void Szerkesztes(Foglalas foglalas)
        {
            if (foglalas != null)
            {
                SzerkesztettFoglalas = new Foglalas
                {
                    Nev = foglalas.Nev,
                    Osszeg = foglalas.Osszeg,
                    FoglalasokSzama = foglalas.FoglalasokSzama
                };
                KivalasztottFoglalas = foglalas;
                SzerkesztesLatszik = true;
            }
        }

        // Törlés
        [RelayCommand]
        private void Torles(Foglalas foglalas)
        {
            if (foglalas != null)
            {
                Foglalasok.Remove(foglalas);
                if (KivalasztottFoglalas == foglalas)
                    KivalasztottFoglalas = null;
            }
        }

        // Mentés (új vagy szerkesztett)
        [RelayCommand]
        private void Mentes()
        {
            if (KivalasztottFoglalas != null)
            {
                // Szerkesztés
                KivalasztottFoglalas.Nev = SzerkesztettFoglalas.Nev;
                KivalasztottFoglalas.Osszeg = SzerkesztettFoglalas.Osszeg;
                KivalasztottFoglalas.FoglalasokSzama = SzerkesztettFoglalas.FoglalasokSzama;
            }
            else
            {
                // Új hozzáadása
                Foglalasok.Add(new Foglalas
                {
                    Nev = SzerkesztettFoglalas.Nev,
                    Osszeg = SzerkesztettFoglalas.Osszeg,
                    FoglalasokSzama = SzerkesztettFoglalas.FoglalasokSzama
                });
            }
            SzerkesztesLatszik = false;
            SzerkesztettFoglalas = new Foglalas();
            KivalasztottFoglalas = null;
        }
    }
}
