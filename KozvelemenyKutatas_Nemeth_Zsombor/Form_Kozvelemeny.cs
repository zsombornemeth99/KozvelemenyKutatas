using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KozvelemenyKutatas_Nemeth_Zsombor
{
    public partial class Form_Kozvelemeny : Form
    {
        int korhatar;
        public Form_Kozvelemeny()
        {
            InitializeComponent();
            korhatar = (int)(DateTime.Now.Year - nmrcUpDown_Eletkor.Value) + 13;//14 a minimum kor a játékvezetői vizsgához
            for (int i = DateTime.Now.Year; i > korhatar; i--)
            {
                lstBx_Ev.Items.Add(i);
            }
        }

        private void nmrcUpDown_Eletkor_ValueChanged(object sender, EventArgs e)
        {
            grpBx_Vizsga.Enabled = true;
            lstBx_Ev.Items.Clear();
            korhatar = (int)(DateTime.Now.Year - nmrcUpDown_Eletkor.Value) + 13;
            if (korhatar<2020)
            {
                for (int i = DateTime.Now.Year; i > korhatar; i--)
                {
                    lstBx_Ev.Items.Add(i);
                }
                radioBttn_Nem.Checked = false;
            }
            else 
            {
                lstBx_Ev.Items.Clear();
                lstBx_Ev.Items.Add("Nem elég idős");
                lstBx_Ev.SetSelected(0,true);
                radioBttn_Nem.Checked=true;
                grpBx_Vizsga.Enabled = false;
            }
        }

        private void cmbBx_Szint_SelectedIndexChanged(object sender, EventArgs e)
        {
            grpBx_Megye.Enabled = true;
            if (cmbBx_Szint.SelectedItem=="FIFA" || cmbBx_Szint.SelectedItem == "NB1" ||
                cmbBx_Szint.SelectedItem == "NB2" || cmbBx_Szint.SelectedItem == "NB3")
            {
                txtBx_Megye.Text = "országos kerettag";
                grpBx_Megye.Enabled = false;
            }
        }

        private void chckBx_Szabalyok1_CheckedChanged(object sender, EventArgs e)
        {
            chckBx_Haszontalan1.Enabled = true;
            if (chckBx_Szabaly1.Checked)
            {
                chckBx_Haszontalan1.Enabled = false;
            }
        }
        
        private void chckBx_Szabaly2_CheckedChanged(object sender, EventArgs e)
        {
            chckBx_Haszontalan2.Enabled = true;
            if (chckBx_Szabaly2.Checked)
            {
                chckBx_Haszontalan2.Enabled = false;
            }
        }

        private void chckBx_Szabaly3_CheckedChanged(object sender, EventArgs e)
        {
            chckBx_Haszontalan3.Enabled = true;
            if (chckBx_Szabaly3.Checked)
            {
                chckBx_Haszontalan3.Enabled = false;
            }
        }

        private void chckBx_Szabaly4_CheckedChanged(object sender, EventArgs e)
        {
            chckBx_Haszontalan4.Enabled = true;
            if (chckBx_Szabaly4.Checked)
            {
                chckBx_Haszontalan4.Enabled = false;
            }
        }

        private void chckBx_Szabaly5_CheckedChanged(object sender, EventArgs e)
        {
            chckBx_Haszontalan5.Enabled = true;
            if (chckBx_Szabaly5.Checked)
            {
                chckBx_Haszontalan5.Enabled = false;
            }
        }

        private void chckBx_Haszontalan1_CheckedChanged(object sender, EventArgs e)
        {
            chckBx_Szabaly1.Enabled = true;
            if (chckBx_Haszontalan1.Checked)
            {
                chckBx_Szabaly1.Enabled = false;
            }
        }

        private void chckBx_Haszontalan2_CheckedChanged(object sender, EventArgs e)
        {
            chckBx_Szabaly2.Enabled = true;
            if (chckBx_Haszontalan2.Checked)
            {
                chckBx_Szabaly2.Enabled = false;
            }
        }

        private void chckBx_Haszontalan3_CheckedChanged(object sender, EventArgs e)
        {
            chckBx_Szabaly3.Enabled = true;
            if (chckBx_Haszontalan3.Checked)
            {
                chckBx_Szabaly3.Enabled = false;
            }
        }

        private void chckBx_Haszontalan4_CheckedChanged(object sender, EventArgs e)
        {
            chckBx_Szabaly4.Enabled = true;
            if (chckBx_Haszontalan4.Checked)
            {
                chckBx_Szabaly4.Enabled = false;
            }
        }

        private void chckBx_Haszontalan5_CheckedChanged(object sender, EventArgs e)
        {
            chckBx_Szabaly5.Enabled = true;
            if (chckBx_Haszontalan5.Checked)
            {
                chckBx_Szabaly5.Enabled = false;
            }
        }

        private void radioBttn_Nem_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBttn_Nem.Checked)
            {
                grpBx_Ev.Enabled = false;
                cmbBx_Szint.Enabled = false;
                cmbBx_poszt.Enabled = false;
                grpBx_Megye.Enabled = false;
                grpBx_Legmagasabb.Enabled = false;
                pnl2.Enabled = false;
            }
            else
            {
                grpBx_Ev.Enabled = true;
                cmbBx_Szint.Enabled = true;
                cmbBx_poszt.Enabled = true;
                grpBx_Megye.Enabled = true;
                grpBx_Legmagasabb.Enabled = true;
                pnl2.Enabled = true;
            }

        }

        private void radioBttn_Igen_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBttn_Igen.Checked)
                pnl1.Enabled = false;
            else
                pnl1.Enabled = true;
        }

        private void bttn_kesz_Click(object sender, EventArgs e)
        {
            if (nmrcUpDown_Eletkor.Value<=14 || radioBttn_Nem.Checked)
            {
                if ((!chckBx_Haszontalan1.Checked && !chckBx_Szabaly1.Checked) || (!chckBx_Haszontalan2.Checked && !chckBx_Szabaly2.Checked) ||
                    (!chckBx_Haszontalan3.Checked && !chckBx_Szabaly3.Checked) || (!chckBx_Haszontalan4.Checked && !chckBx_Szabaly4.Checked) ||
                    (!chckBx_Haszontalan5.Checked && !chckBx_Szabaly5.Checked) ||  txtBx_Peldakep.Text=="" || txtBx_miert_szeretne.Text=="" || 
                    (!radioBttn_Ferfi.Checked && !radioBttn_No.Checked))
                    MessageBox.Show("Ellenőrizze, hogy mindent kitöltött!");
                else
                {
                    StreamWriter r = new StreamWriter("export.txt", false, Encoding.UTF8);

                    r.WriteLine("KÖZVÉLEMÉNYKUTATÁS JÁTÉKVEZETŐKNEK\n");

                    r.Write("NEME:");
                    if (radioBttn_Ferfi.Checked)
                        r.Write("\t\t\t\tférfi");
                    else
                        r.Write("\t\t\t\tnő");

                    r.Write("\nÉLETKORA:\t\t\t" + nmrcUpDown_Eletkor.Value);

                    r.Write("\nVIZSGA ÉVE:\t\t\t" + "Nem vizsgázott");

                    r.Write("\nPÉLDAKÉPE:\t\t\t" + txtBx_Peldakep.Text);

                    r.WriteLine("\nHASZNOSNAK VÉLT ÚJ SZABÁLYOK:");
                    if (chckBx_Szabaly1.Checked)
                        r.WriteLine("\t-" + chckBx_Szabaly1.Text);
                    if(chckBx_Szabaly2.Checked)
                        r.WriteLine("\t-" + chckBx_Szabaly2.Text);
                    if (chckBx_Szabaly3.Checked)
                        r.WriteLine("\t-" + chckBx_Szabaly3.Text);
                    if (chckBx_Szabaly4.Checked)
                        r.WriteLine("\t-" + chckBx_Szabaly4.Text);
                    if (chckBx_Szabaly5.Checked)
                        r.WriteLine("\t-" + chckBx_Szabaly5.Text);
                    if (!chckBx_Szabaly1.Checked && !chckBx_Szabaly2.Checked && !chckBx_Szabaly3.Checked &&
                        !chckBx_Szabaly4.Checked && !chckBx_Szabaly5.Checked)
                        r.WriteLine("\tNem volt ilyen!");

                    r.WriteLine("\nHASZONTALANNAK VÉLT ÚJ SZABÁLYOK:");
                    if (chckBx_Haszontalan1.Checked)
                        r.WriteLine("\t-" + chckBx_Haszontalan1.Text);
                    if (chckBx_Haszontalan2.Checked)
                        r.WriteLine("\t-" + chckBx_Haszontalan2.Text);
                    if (chckBx_Haszontalan3.Checked)
                        r.WriteLine("\t-" + chckBx_Haszontalan3.Text);
                    if (chckBx_Haszontalan4.Checked)
                        r.WriteLine("\t-" + chckBx_Haszontalan4.Text);
                    if (chckBx_Haszontalan5.Checked)
                        r.WriteLine("\t-" + chckBx_Haszontalan5.Text);
                    if (!chckBx_Haszontalan1.Checked && !chckBx_Haszontalan2.Checked && !chckBx_Haszontalan3.Checked &&
                        !chckBx_Haszontalan4.Checked && !chckBx_Haszontalan5.Checked)
                        r.WriteLine("\tNem volt ilyen!");

                    r.WriteLine("\nMIÉRT SZERETNE JÁTÉKVEZETŐ LENNI?");
                    r.WriteLine("\t" + txtBx_miert_szeretne.Text);

                    r.WriteLine("\n\n\nKitöltve: {0}", DateTime.Now);
                    r.Close();

                    MessageBox.Show("Sikeres kitöltés!");
                    ActiveForm.Close();
                }
            }
            else
            {
                if ((!chckBx_Haszontalan1.Checked && !chckBx_Szabaly1.Checked) || (!chckBx_Haszontalan2.Checked && !chckBx_Szabaly2.Checked) ||
                    (!chckBx_Haszontalan3.Checked && !chckBx_Szabaly3.Checked) || (!chckBx_Haszontalan4.Checked && !chckBx_Szabaly4.Checked) ||
                    (!chckBx_Haszontalan5.Checked && !chckBx_Szabaly5.Checked) || txtBx_Peldakep.Text == "" || txtBx_miert_valasztotta.Text == "" ||
                    (!radioBttn_Ferfi.Checked && !radioBttn_No.Checked) || lstBx_Ev.SelectedItem == null || cmbBx_poszt.SelectedItem == null ||
                    cmbBx_Szint.SelectedItem == null || cmbBx1_Legmagasabb.SelectedItem == null || txtBx_Megye.Text=="")
                    MessageBox.Show("Ellenőrizze, hogy mindent kitöltött!");
                else
                {
                    StreamWriter r = new StreamWriter("export.txt", false, Encoding.UTF8);

                    r.WriteLine("KÖZVÉLEMÉNYKUTATÁS JÁTÉKVEZETŐKNEK\n");

                    r.Write("NEME:");
                    if (radioBttn_Ferfi.Checked)
                        r.Write("\t\t\t\tférfi");
                    else
                        r.Write("\t\t\t\tnő");

                    r.Write("\nÉLETKORA:\t\t\t" + nmrcUpDown_Eletkor.Value);

                    r.Write("\nVIZSGA ÉVE:\t\t\t" + lstBx_Ev.SelectedItem);

                    r.Write("\nSZEREPKÖRE:\t\t\t" + cmbBx_poszt.SelectedItem);

                    r.Write("\nSZINT:\t\t\t\t" + cmbBx_Szint.SelectedItem);

                    r.Write("\nMEGYE:\t\t\t\t" + txtBx_Megye.Text);

                    r.Write("\nLEGMAGASABB OSZTÁLY:\t\t" + cmbBx1_Legmagasabb.SelectedItem);

                    r.Write("\nPÉLDAKÉPE:\t\t\t" + txtBx_Peldakep.Text);

                    r.WriteLine("\nHASZNOSNAK VÉLT ÚJ SZABÁLYOK:");
                    if (chckBx_Szabaly1.Checked)
                        r.WriteLine("\t-" + chckBx_Szabaly1.Text);
                    if (chckBx_Szabaly2.Checked)
                        r.WriteLine("\t-" + chckBx_Szabaly2.Text);
                    if (chckBx_Szabaly3.Checked)
                        r.WriteLine("\t-" + chckBx_Szabaly3.Text);
                    if (chckBx_Szabaly4.Checked)
                        r.WriteLine("\t-" + chckBx_Szabaly4.Text);
                    if (chckBx_Szabaly5.Checked)
                        r.WriteLine("\t-" + chckBx_Szabaly5.Text);
                    if (!chckBx_Szabaly1.Checked && !chckBx_Szabaly2.Checked && !chckBx_Szabaly3.Checked &&
                        !chckBx_Szabaly4.Checked && !chckBx_Szabaly5.Checked)
                        r.WriteLine("\tNem volt ilyen!");

                    r.WriteLine("\nHASZONTALANNAK VÉLT ÚJ SZABÁLYOK:");
                    if (chckBx_Haszontalan1.Checked)
                        r.WriteLine("\t-" + chckBx_Haszontalan1.Text);
                    if (chckBx_Haszontalan2.Checked)
                        r.WriteLine("\t-" + chckBx_Haszontalan2.Text);
                    if (chckBx_Haszontalan3.Checked)
                        r.WriteLine("\t-" + chckBx_Haszontalan3.Text);
                    if (chckBx_Haszontalan4.Checked)
                        r.WriteLine("\t-" + chckBx_Haszontalan4.Text);
                    if (chckBx_Haszontalan5.Checked)
                        r.WriteLine("\t-" + chckBx_Haszontalan5.Text);
                    if (!chckBx_Haszontalan1.Checked && !chckBx_Haszontalan2.Checked && !chckBx_Haszontalan3.Checked &&
                        !chckBx_Haszontalan4.Checked && !chckBx_Haszontalan5.Checked)
                        r.WriteLine("\tNem volt ilyen!");

                    r.WriteLine("\nMIÉRT LETT JÁTÉKVEZETŐ?");
                    r.WriteLine("\t" + txtBx_miert_valasztotta.Text);


                    r.WriteLine("\n\n\nKitöltve: {0}", DateTime.Now);
                    r.Close();
                    MessageBox.Show("Sikeres kitöltés!");
                    ActiveForm.Close();
                }              
            }
        }
    }
}
