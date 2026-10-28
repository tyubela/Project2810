
namespace Project2810
{
    public partial class MainPage : ContentPage
    {
        decimal razem = 0;
        bool obliczono = false;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string imie = imieEntry.Text;

            if (string.IsNullOrWhiteSpace(imie))
            {
                await DisplayAlertAsync("Uwaga", "Podaj imię.", "OK");
                return;
            }

            if (!int.TryParse(iloscEntry.Text, out int ilosc) || ilosc <= 0)
            {
                await DisplayAlertAsync("Uwaga", "Podaj poprawną liczbę napojów.", "OK");
                return;
            }

            decimal cena = 0;
            string napoj = "";

            if (czekoladaradio.IsChecked)
            {
                cena = 12;
                napoj = "Czekolada";
            }
            else if (kawaradio.IsChecked)
            {
                cena = 10;
                napoj = "Kawa";
            }
            else if (herbataradio.IsChecked)
            {
                cena = 8;
                napoj = "Herbata";
            }
            else
            {
                await DisplayAlertAsync("Uwaga", "Wybierz napój.", "OK");
                return;
            }

            string rozmiar = "";

            if (malyradio.IsChecked)
                rozmiar = "Mały";
            else if (sredniradio.IsChecked)
            {
                cena += 3;
                rozmiar = "Średni";
            }
            else if (duzyradio.IsChecked)
            {
                cena += 5;
                rozmiar = "Duży";
            }
            else
            {
                await DisplayAlertAsync("Uwaga", "Wybierz wielkość.", "OK");
                return;
            }

            string dodatki = "";

            if (mlekocheck.IsChecked)
            {
                cena += 2;
                dodatki += "Mleko roślinne, ";
            }

            if (syropcheck.IsChecked)
            {
                cena += 2.50m;
                dodatki += "Syrop, ";
            }

            if (espressocheck.IsChecked)
            {
                cena += 3;
                dodatki += "Espresso, ";
            }

            if (smietanacheck.IsChecked)
            {
                cena += 2;
                dodatki += "Bita śmietana, ";
            }

            if (dodatki == "")
                dodatki = "Brak";

            decimal cenaJednego = cena;
            decimal suma = cena * ilosc;
            decimal rabat = 0;

            if (suma > 50)
                rabat = suma * 0.10m;

            razem = suma - rabat;



            wypisywanie.Text =
                $"Klient: {imie}\n" +
                $"Napój: {napoj}\n" +
                $"Wielkość: {rozmiar}\n" +
                $"Liczba: {ilosc}\n" +
                $"Dodatki: {dodatki}\n" +
                $"Cena jednej sztuki: {cenaJednego:F2} zł\n" +
                $"Rabat: {rabat:F2} zł\n" +
                $"Razem: {razem:F2} zł";

            obliczono = true;
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            imieEntry.Text = "";
            iloscEntry.Text = "";

            kawaradio.IsChecked = false;
            herbataradio.IsChecked = false;
            czekoladaradio.IsChecked = false;

            malyradio.IsChecked = false;
            sredniradio.IsChecked = false;
            duzyradio.IsChecked = false;

            mlekocheck.IsChecked = false;
            syropcheck.IsChecked = false;
            espressocheck.IsChecked = false;
            smietanacheck.IsChecked = false;

            wypisywanie.Text = "";
            razem = 0;
            obliczono = false;
        }

        private async void Potwierdz_Clicked(object sender, EventArgs e)
        {
            if (!obliczono)
            {
                await DisplayAlertAsync("Uwaga", "Najpierw oblicz zamówienie.", "OK");
                return;
        }
        }
    }
}
