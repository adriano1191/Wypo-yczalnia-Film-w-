using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;

namespace BazaFilmów
{
    public partial class FormFilmView : Form
    {
        [Serializable]
        public class Film
        {
            public string Tytul { get; set; }
            public string Rezyser { get; set; }
            public string Gatunek { get; set; }
            public int Rok { get; set; }
            public int Cena { get; set; }
            public string Nosnik { get; set; }
            public int IloscKopii { get; set; }
            public int Wypozyczonych { get; set; }
            public int Dostepnosc { get; set; }

            public Film()
            {
            }

            public Film(string nTytul, string nRezyser, string nGatunek, int nRok, int nCena, string nNosnik, int nIloscKopii, int nWypozyczonych, int nDostepnosc)
            {
                Tytul = nTytul;
                Rezyser = nRezyser;
                Gatunek = nGatunek;
                Rok = nRok;
                Cena = nCena;
                Nosnik = nNosnik;
                IloscKopii = nIloscKopii;
                Wypozyczonych = nWypozyczonych;
                Dostepnosc = nDostepnosc;
            }


        }

 public class Termin
 {
     public string KtoWypozycza { get; set; }
     public string Tytul { get; set; }
     public string Wypozyczono { get; set; }
     public string Zwrot { get; set; }
     public int Ilosc { get; set; }
     
     public Termin()
     {
     }
     public Termin(string nKtoWypozycza, string nTytul, string nWypozyczono, string nZwrot, int nIlosc)
     {
         KtoWypozycza = nKtoWypozycza;
         Tytul = nTytul;
         Wypozyczono = nWypozyczono;
         Zwrot = nZwrot;
         Ilosc = nIlosc;
     }
 }

 public class Aktor
        {
            public string Imie { get; set; }
            public string Nazwisko { get; set; }
            public int Data { get; set; }
            public string Miejsce { get; set; }
            public string Filmy { get; set; }


            public Aktor()
            {
            }

            public Aktor(string nImie, string nNazwisko, int nData, string nMiejsce, string nFilmy)
            {
                Imie = nImie;
                Nazwisko = nNazwisko;
                Data = nData;
                Miejsce = nMiejsce;
                Filmy = nFilmy;

            }
        }

        public FormFilmView()
        {
            InitializeComponent();
            Deserializacja();
            AktorDeserializacja();
            int i = dataContainer.index;


            Obrazek();
            if (File.Exists(@"Image/Films/" + FilmList[i].Tytul + ".bmp"))
            {
                
                string imagePatch = @"Image/Films/" + FilmList[i].Tytul + ".bmp";
                Image image = new Bitmap(imagePatch);
                int width = image.Width;
                int height = image.Height;

                pictureBox1.Image = Image.FromFile(imagePatch);
            }
            else
            {
                pictureBox1.Image = Image.FromFile(@"Image/Films/Brak.bmp");
            }
            Wyswietlanie();
            
            //Wyswietlanie Aktorów

            List<Aktor> findAktor = new List<Aktor>();
            //findAktor = AktorList.FindAll(item => item.Filmy.IndexOf(FilmList[i].Tytul, StringComparison.OrdinalIgnoreCase) >= 0);
            findAktor = AktorList.FindAll(item => item.Filmy.Contains(FilmList[i].Tytul));
            dataGridViewAktor.DataSource = findAktor;
        }
        public void Obrazek()
        {

        }
        public void Wyswietlanie()
        {

            int i = dataContainer.index;
            labelTytul.Text = FilmList[i].Tytul;
            labelRezyser.Text = FilmList[i].Rezyser;
            labelGatunek.Text = FilmList[i].Gatunek;
            labelRok.Text = Convert.ToString(FilmList[i].Rok);
            labelCena.Text = Convert.ToString(FilmList[i].Cena);
            labelNosnik.Text = FilmList[i].Nosnik;
            labelIloscKopii.Text = Convert.ToString(FilmList[i].IloscKopii);
            labelDostepnosc.Text = Convert.ToString(FilmList[i].Dostepnosc);
            labelWypozyczonych.Text = Convert.ToString(FilmList[i].Wypozyczonych); ;
            labelRok.Location = new Point(labelTytul.Right, labelRok.Top);
        }
        public void Deserializacja()
        {
            XmlRootAttribute oRootAttr = new XmlRootAttribute();
            oRootAttr.ElementName = "Film";
            oRootAttr.IsNullable = true;
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Film>), oRootAttr);
            TextReader reader = new StreamReader("BazaFilmow.xml");
            object obj = deserializer.Deserialize(reader);
            FilmList = (List<Film>)obj;
            reader.Close();

        }
        public void Serializacja()
        {
            XmlRootAttribute oRootAttr = new XmlRootAttribute();
            oRootAttr.ElementName = "Film";
            oRootAttr.IsNullable = true;
            XmlSerializer oSerializer = new XmlSerializer(typeof(List<Film>), oRootAttr);
            StreamWriter oStreamWriter = null;
            oStreamWriter = new StreamWriter("BazaFilmow.xml");
            oSerializer.Serialize(oStreamWriter, FilmList);
            oStreamWriter.Dispose();
        }
        public void AktorDeserializacja()
{
    XmlRootAttribute oRootAttr = new XmlRootAttribute();
    oRootAttr.ElementName = "Aktor";
    oRootAttr.IsNullable = true;
    XmlSerializer deserializer = new XmlSerializer(typeof(List<Aktor>), oRootAttr);
    TextReader reader = new StreamReader("BazaAktorow.xml");
    object obj = deserializer.Deserialize(reader);
    AktorList = (List<Aktor>)obj;
    reader.Close();

}
        public void AktorSerializacja()
{
    XmlRootAttribute oRootAttr = new XmlRootAttribute();
    oRootAttr.ElementName = "Aktor";
    oRootAttr.IsNullable = true;
    XmlSerializer oSerializer = new XmlSerializer(typeof(List<Aktor>), oRootAttr);
    StreamWriter oStreamWriter = null;
    oStreamWriter = new StreamWriter("BazaAktorow.xml");
    oSerializer.Serialize(oStreamWriter, AktorList);
    oStreamWriter.Dispose();

}
        public void TerminDeserializacja()
        {
            XmlRootAttribute oRootAttr = new XmlRootAttribute();
            oRootAttr.ElementName = "Termin";
            oRootAttr.IsNullable = true;
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Termin>), oRootAttr);
            TextReader reader = new StreamReader("Terminy.xml");
            object obj = deserializer.Deserialize(reader);
            TerminList = (List<Termin>)obj;
            reader.Close();

        }
        public void TerminSerializacja()
        {
            XmlRootAttribute oRootAttr = new XmlRootAttribute();
            oRootAttr.ElementName = "Termin";
            oRootAttr.IsNullable = true;
            XmlSerializer oSerializer = new XmlSerializer(typeof(List<Termin>), oRootAttr);
            StreamWriter oStreamWriter = null;
            oStreamWriter = new StreamWriter("Terminy.xml");
            oSerializer.Serialize(oStreamWriter, TerminList);
            oStreamWriter.Dispose();
        }
        List<Termin> TerminList = new List<Termin>();
        List<Film> FilmList = new List<Film>();
        List<Aktor> AktorList = new List<Aktor>();
        
        private void buttonWypozycz_Click(object sender, EventArgs e)
        {
            int ile = Convert.ToInt32(textBoxIle.Text);
            Deserializacja();
            TerminDeserializacja();
            int i = dataContainer.index;
            int dostepnosc = FilmList[i].Dostepnosc;
            FilmList[i] = (new Film(
            labelTytul.Text,
            labelRezyser.Text,
            labelGatunek.Text,
            Convert.ToInt32(labelRok.Text),
            Convert.ToInt32(labelCena.Text),
            labelNosnik.Text,
            Convert.ToInt32(labelIloscKopii.Text),
            Convert.ToInt32(labelWypozyczonych.Text) + ile,
            Convert.ToInt32(labelDostepnosc.Text) - ile
            ));
            string wypozyczenie = DateTime.UtcNow.Date.ToString("dd.MM.yy");
            string zwrot = DateTime.Now.AddDays(14).ToString("dd.MM.yy");
            
            TerminList.Add(new Termin(
                textBoxKto.Text,
                labelTytul.Text,
                wypozyczenie,
                zwrot,
                ile
                ));

            if (ile <= dostepnosc)
                
        {
                
            Serializacja();
            TerminSerializacja();
            this.Close();
                
        }
            else 
            {
                MessageBox.Show("Brak wystarczającej ilości kopii", "Błąd",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            

               
        }
    }
}
