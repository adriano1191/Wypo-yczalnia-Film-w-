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
    public partial class Szukaj : Form
    {[Serializable]
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
        public Szukaj()
        {
            InitializeComponent();
        }
        public class AcessStuff
        {
            public static List<Film> tmpList = new List<Film>();
        }
        
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
        private void buttonSzukaj_Click(object sender, EventArgs e)
        {
            Deserializacja();
            List<Film> findFilm = new List<Film>();
            List<string> tmpFilm = new List<string>();
            string input = textBoxTytul.Text.Trim();
            //int intRok;
            //intRok = Convert.ToInt32(input);
            //findFilm = FilmList.FindAll(item => item.Tytul.Contains(input));
            //Ignorowanie wielkich Liter
            //findFilm = FilmList.FindAll(item => item.Tytul.IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0);
            tmpFilm = FilmList.ConvertAll(x => x.ToString());
            findFilm.AddRange(FilmList.FindAll(item => item.Tytul.IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0));
            findFilm.AddRange(FilmList.FindAll(item => item.Rezyser.IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0));

            AcessStuff.tmpList = findFilm.Distinct().ToList();
            Form1 f = new Form1();
            f.dataGridView1.DataSource = AcessStuff.tmpList;
        }
    }
}
