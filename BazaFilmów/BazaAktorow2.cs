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
using System.Diagnostics;

namespace BazaFilmów
{ 
    public partial class BazaAktorow2 : Form
    {
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
        public BazaAktorow2()
        {
            InitializeComponent();
            AktorDeserializacja();
            Formatowanie();


        }
List<Aktor> AktorList = new List<Aktor>();
public void Formatowanie()
{
    dataGridView1.DataSource = AktorList;
    dataGridView1.Columns[0].Width = 70;
    dataGridView1.Columns[1].Width = 70;
    dataGridView1.Columns[2].Width = 50;
    dataGridView1.Columns[3].Width = 70;
    dataGridView1.Columns[4].Width = 100;
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

private void buttonDodaj_Click(object sender, EventArgs e)
{
    buttonActive.active = false;
    FormAktor newFormAktor = new FormAktor();
    newFormAktor.Show();
}

private void buttonEdytuj_Click(object sender, EventArgs e)
{
    dataContainer.index = dataGridView1.CurrentCell.RowIndex;
    int i = dataContainer.index;
    //licznik.liczba = AktorList[i].Wypozyczonych;
    buttonActive.active = true;
    FormAktor newFormAktor = new FormAktor();
    newFormAktor.Show();
}

private void buttonUsun_Click(object sender, EventArgs e)
{
    int i = dataGridView1.CurrentCell.RowIndex;

    if (MessageBox.Show("Czy na pewno chcesz usunąć zaznaczony obszar?", "Ostrzeżenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
    {

        int x = AktorList.Count;



        AktorList.RemoveAt(i);
        AktorSerializacja();
        AktorDeserializacja();
        dataGridView1.DataSource = AktorList;
    }
}

private void buttonZamknij_Click(object sender, EventArgs e)
{
    if (MessageBox.Show("Czy na pewno chcesz zamknąć program?", "Ostrzeżenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
    {
        this.Close();
    }
}
private void BazaAktorow2_Activated(object sender, EventArgs e)
{
    AktorDeserializacja();

    dataGridView1.DataSource = AktorList;


}
    }
}
