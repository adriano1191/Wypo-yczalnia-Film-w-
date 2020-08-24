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
    public partial class Raport_Bazy_Filmowej : Form
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
        public Raport_Bazy_Filmowej()
        {
            InitializeComponent();
            Deserializacja();
            //liczba filmow
            int count = FilmList.Count;
            int suma = FilmList.Count;
            label1.Text = suma.ToString();
            //liczba kopii
            
            for (int i = 0; i < count; i++)
            {

                x = x + FilmList[i].IloscKopii;

            }
            labelKopii.Text = x.ToString();
            //Najdrozszy film
            var najdrozszy = FilmList.Max(item => item.Cena);
            labelNajdrozszy.Text = najdrozszy.ToString() + "zł";
            var tytul = FilmList.FindIndex(item => item.Cena == najdrozszy);
            labelTytujDrogi.Text = FilmList[tytul].Tytul;

            //Najtanszy film
            var najtanszy = FilmList.Min(item => item.Cena);
            labelNajtanszy.Text = najtanszy.ToString() + "zł";
            var tytul2 = FilmList.FindIndex(item => item.Cena == najtanszy);
            labelTytulTani.Text = FilmList[tytul2].Tytul;

            //Najwiecej kopii
            var najwiecej = FilmList.Max(item => item.IloscKopii);
            labelNajKopii.Text = najwiecej.ToString() + " sztuk";
            var tytul3 = FilmList.FindIndex(item => item.IloscKopii == najwiecej);
            labelNajKopiiTytul.Text = FilmList[tytul3].Tytul;

            //Najmniej kopii
            var najmniej = FilmList.Min(item => item.IloscKopii);
            labelNajmniejKopi.Text = najmniej.ToString() + " sztuk";
            var tytul4 = FilmList.FindIndex(item => item.IloscKopii == najmniej);
            labelNajmniejKopiiTytul.Text = FilmList[tytul4].Tytul;

            //Najwiecej wypozyczonych
            var najwyp = FilmList.Max(item => item.Wypozyczonych);
            labelWypozyczonychTytul.Text = najwyp.ToString() + " sztuk";
            var tytul5 = FilmList.FindIndex(item => item.Wypozyczonych == najwyp);
            labelWypozyczonychKopii.Text = FilmList[tytul5].Tytul;

            
        }
int x;
List<Film> tmpList = new List<Film>();
List<Film> FilmList = new List<Film>();
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
    }
}
