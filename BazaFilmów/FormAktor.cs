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

namespace BazaFilmów
{
    public partial class FormAktor : Form
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





        
        

        public FormAktor()
        {
            InitializeComponent();
            if (File.Exists("BazaAktorow.xml"))
            {
                AktorDeserializacja();


            }
            else
            {
                AktorSerializacja();
            }

            Deserializacja();
            AktorDeserializacja();
            int i = dataContainer.index;
            if (buttonActive.active == true) { 
            
            //label1.Text = i.ToString();
            textBoxImie.Text = AktorList[i].Imie;
            textBoxNazwisko.Text = AktorList[i].Nazwisko;
            textBoxData.Text = Convert.ToString(AktorList[i].Data);
            textBoxMiejsce.Text  = AktorList[i].Nazwisko;
            labelFilmy.Text = AktorList[i].Filmy; 
            List<string> boxList = new List<string>();
            boxList.Add(AktorList[i].Filmy);
            listBoxFilmy.DataSource = boxList;

            buttonZapisz.Visible = buttonActive.active;
            }


            foreach (Film Film in FilmList)
            {
                comboBoxFilmList.Items.Add(Film.Tytul);
            }
            

        }
        List<Film> FilmList = new List<Film>();
        List<Aktor> AktorList = new List<Aktor>();
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
private void buttonPlus_Click(object sender, EventArgs e)
{
    labelFilmy.Text += this.comboBoxFilmList.GetItemText(this.comboBoxFilmList.SelectedItem + Environment.NewLine + " | " + Environment.NewLine);
    listBoxFilmy.Items.Add(this.comboBoxFilmList.GetItemText(this.comboBoxFilmList.SelectedItem));
}

private void buttonZamknij_Click(object sender, EventArgs e)
{
    if (MessageBox.Show("Czy na pewno chcesz zamknąć okno?", "Ostrzeżenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                this.Close();
            }
        }

private void buttonDodaj_Click(object sender, EventArgs e)
{
    if ((string.IsNullOrWhiteSpace(textBoxImie.Text)) || (string.IsNullOrWhiteSpace(textBoxNazwisko.Text)) || (string.IsNullOrWhiteSpace(textBoxMiejsce.Text)))
    {
        MessageBox.Show("Uzupełnij wszystkie dane");
        return;
    }
    else
    {
        int parsedValue;
        if ((!int.TryParse(textBoxData.Text, out parsedValue)))
        {
            MessageBox.Show("W polu Data Urodzenia musi znajdować się liczba");
            return;
        }
        else
        {
            AktorDeserializacja();
            //AktorList.Add(new Aktor("Adrian", "Michalski",1992,"Mrągowo", "Bóg"));
            int i = dataContainer.index;
            AktorList.Add(new Aktor(
                textBoxImie.Text,
                textBoxNazwisko.Text,
                Convert.ToInt32(textBoxData.Text),
                textBoxMiejsce.Text,
                //this.comboBoxFilmList.GetItemText(this.comboBoxFilmList.SelectedItem)
                labelFilmy.Text
                ));

            AktorSerializacja();
            this.Close();
        }
    }
}

private void buttonZapisz_Click(object sender, EventArgs e)
{
    if (MessageBox.Show("Czy na pewno chcesz Zapisać zmiany?", "Zapis", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
    {
        if ((string.IsNullOrWhiteSpace(textBoxImie.Text)) || (string.IsNullOrWhiteSpace(textBoxNazwisko.Text)) || (string.IsNullOrWhiteSpace(textBoxMiejsce.Text)))
        {
            MessageBox.Show("Uzupełnij wszystkie dane");
            return;
        }
        else
        {
            int parsedValue;
            if ((!int.TryParse(textBoxData.Text, out parsedValue)))
            {
                MessageBox.Show("W polu Data Urodzenia musi znajdować się liczba");
                return;
            }
            else
            {
                AktorDeserializacja();
                int i = dataContainer.index;

                AktorList[i] = (new Aktor(
                textBoxImie.Text,
                textBoxNazwisko.Text,
                Convert.ToInt32(textBoxData.Text),
                textBoxMiejsce.Text,
                    //this.comboBoxFilmList.GetItemText(this.comboBoxFilmList.SelectedItem)
                labelFilmy.Text));
                AktorSerializacja();
                this.Close();
            }
        }
    }
}

}



        
    }


