using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Naidis_IKTpv25_Windows_Forms
{

    public partial class Avavorm : Form
    {
        TreeView tree;
        Button nupp;
        Label silt;
        PictureBox pilt;
        CheckBox mruut1, mruut2;
        RadioButton rnupp1, rnupp2;
        TextBox tbox;
        TabControl tabs;
        TabPage tab1, tab2, tab3;
        ListBox lb;

        public Avavorm()
        {
            Height = 600;
            Width = 1000;
            Text = "Naidis IKTpv25 Windows Forms";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode tn = new TreeNode("Elemendid");
            tn.Nodes.Add(new TreeNode("Nupp"));
            tn.Nodes.Add(new TreeNode("Silt"));
            tn.Nodes.Add(new TreeNode("Pilt"));
            tn.Nodes.Add(new TreeNode("Märkeruut"));
            tn.Nodes.Add(new TreeNode("Radionupp"));
            tn.Nodes.Add(new TreeNode("Tekstiväli"));
            tn.Nodes.Add(new TreeNode("Vahekaardid"));
            tn.Nodes.Add(new TreeNode("ListBox"));
            tn.Nodes.Add(new TreeNode("DataGridView"));
            tn.Nodes.Add(new TreeNode("MainMenu"));
            tree.Nodes.Add(tn);

            //nupp,silt ja pilt
            nupp = new Button();
            nupp.Text = "Vajuta Siia";
            nupp.Location = new Point(300, 100);
            nupp.Height = 50;
            nupp.Width = 100;
            nupp.Click += (sender, e) => { MessageBox.Show("Nupp vajutati!"); };

            silt = new Label();
            silt.Text = "See on silt";
            silt.Location = new Point(300, 200);
            silt.Size = new Size(200, 30);
            silt.Font = new Font("Arial", 16, FontStyle.Bold);
            silt.AutoSize = true;
            silt.MouseLeave += Silt_MouseLeave;
            silt.MouseHover += Silt_MouseHover;

            pilt = new PictureBox();
            pilt.Image = Image.FromFile(@"..\..\Pildid\images.jpg");
            pilt.Location = new Point(300, 300);
            pilt.Size = new Size(200, 200);
            pilt.SizeMode = PictureBoxSizeMode.StretchImage;
            pilt.MouseDoubleClick += Pilt_MouseDoubleClick;


            Controls.Add(tree);
        }

        private void Pilt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Size väike = new Size(200, 200);
            Size suur = new Size(800, 50);
            if (pilt.Size == suur)
                pilt.Size = väike;

            else
                pilt.Size = suur;

        }

        private void Silt_MouseHover(object sender, EventArgs e)
        {
            silt.BackColor = Color.LightGray;
            silt.BorderStyle = BorderStyle.Fixed3D;
        }

        private void Silt_MouseLeave(object sender, EventArgs e)
        {
            silt.BackColor = Color.Black;

        }

        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp")
            {
                Controls.Add(nupp);
                tree.SelectedNode = null;
            }
            else if (e.Node.Text == "Silt")
            {
                Controls.Add(silt);
                tree.SelectedNode = null;
            }
            else if (e.Node.Text == "Pilt")
            {
                Controls.Add(pilt);
                tree.SelectedNode = null;
            }
            else if (e.Node.Text == "Märkeruut")
            {
                mruut1 = new CheckBox();
                mruut1.Text = "Märkeruut 1";
                mruut1.Location = new Point(200, 300);
                mruut1.CheckedChanged += Mruut1_CheckedChanged;
                mruut2 = new CheckBox();
                mruut2.Text = "Märkeruut 2";
                mruut2.Location = new Point(300, 300);
                mruut2.CheckedChanged += Mruut2_CheckedChanged;
                Controls.Add(mruut1);
                Controls.Add(mruut2);
                tree.SelectedNode = null;
            }
            else if (e.Node.Text == "Radionupp")
            {
                rnupp1 = new RadioButton();
                rnupp1.Text = "Bisque";
                rnupp1.Location = new Point(200, 400);
                rnupp1.CheckedChanged += Rnupp1_CheckedChanged;
                rnupp2 = new RadioButton();
                rnupp2.Text = "Hall";
                rnupp2.Location = new Point(200, 450);
                rnupp2.CheckedChanged += Rnupp1_CheckedChanged;
                Controls.Add(rnupp1);
                Controls.Add(rnupp2);
                tree.SelectedNode = null;
            }
            else if (e.Node.Text == "Tekstiväli")
            {
                tbox = new TextBox();
                tbox.Location = new Point(200, 500);
                tbox.Width = 200;
                tbox.TextChanged += (s, arg) =>
                {
                    Controls.Add(silt);
                    if (tbox.Text.Length > 0)
                    {
                        silt.Text = tbox.Text;
                    }
                    if (tbox.Text.Length == 0)
                    {
                        silt.Text = " See on silt";
                    }
                };
                Controls.Add(tbox);
                tree.SelectedNode = null;
            }
            else if (e.Node.Text == "Vahekaardid")
            {
                tabs = new TabControl();
                tabs.Location = new Point(500, 100);
                tabs.Size = new Size(1000, 500);
                tab1 = new TabPage("Techno+TLN");
                WebBrowser brauser = new WebBrowser();
                brauser.Dock = DockStyle.Fill;
                brauser.ScriptErrorsSuppressed = true;
                brauser.Url = new Uri("https://techno.ee/");
                tab1.Controls.Add(brauser);

                tab2 = new TabPage("ChatikGPs");
                WebBrowser browser = new WebBrowser();
                browser.Dock = DockStyle.Fill;
                browser.ScriptErrorsSuppressed = true;
                browser.Url = new Uri("https://chatgpt.com/");
                tab2.Controls.Add(browser);
                tab3 = new TabPage("+");
                tabs.SelectedIndexChanged += (s, arg) =>
                {
                    if (tabs.SelectedTab == tab3)
                    {
                        // 2. Küsitakse veebiaadressi (URL)
                        string veebiaadress = Interaction.InputBox(
                            "Sisesta veebiaadress, mida soovid avada:",
                            "Veebilehe avamine",
                            "https://www.google.com");
                        if (string.IsNullOrWhiteSpace(veebiaadress))
                        {
                            MessageBox.Show("Veebiaadress ei tohi olla tühi!");
                            tabs.SelectedTab = tab1;
                            return;
                        }
                        // Lisame automaatselt "https://", kui kasutaja unustas selle kirjutada
                        if (!veebiaadress.StartsWith("http://www.") && !veebiaadress.StartsWith("https://www."))
                        {
                            veebiaadress = "https://www." + veebiaadress;
                        }
                        Uri uri = new Uri(veebiaadress);
                        string uuskaardinimi = uri.Host; // Kasutame domeeninime vahekaardi nimeks
                        if (uuskaardinimi.StartsWith("www."))
                        {
                            uuskaardinimi = uuskaardinimi.Substring(4); // Eemaldame "www." algusest
                        }
                        int pos = uuskaardinimi.LastIndexOf('.');
                        if (pos > 0)
                        {
                            uuskaardinimi = uuskaardinimi.Substring(0, pos).ToUpper(); // Eemaldame domeeni lõpu
                        }
                        // 3. Kinnituse küsimine
                        var vastus = MessageBox.Show(
                                $"Kas soovid lisada uue vahekaardi nimega '{uuskaardinimi}'?",
                                "Kinnita",
                                MessageBoxButtons.YesNo);
                        if (vastus == DialogResult.No)
                        {
                            tabs.SelectedTab = tab1;
                            return;
                        }
                        TabPage uusVahekaart = new TabPage(uuskaardinimi);
                        brauser = new WebBrowser();
                        brauser.Dock = DockStyle.Fill;
                        brauser.ScriptErrorsSuppressed = true; // Peidab IE skriptitõrgete
                        try
                        {
                            brauser.Url = new Uri(veebiaadress);
                        }
                        catch (UriFormatException)
                        {
                            MessageBox.Show("Vigane veebiaadress! Avatakse tühi leht.");
                        }
                        uusVahekaart.Controls.Add(brauser);
                        tabs.TabPages.Insert(tabs.TabCount - 1, uusVahekaart);
                        tabs.SelectedTab = uusVahekaart;
                    }
                };
                tabs.TabPages.Add(tab1);
                tabs.TabPages.Add(tab2);
                tabs.TabPages.Add(tab3);
                Controls.Add(tabs);
                tree.SelectedNode = null;
            }
            else if (e.Node.Text == "Listbox")
            {
                lb = new ListBox();
                lb.Items.Add("Roheline");
                lb.Items.Add("Sinine");
                lb.Items.Add("Kollane");
                lb.Items.Add("Punane");
                lb.Location = new Point(150, 50);
                lb.SelectedIndexChanged += new EventHandler(Lb_SelectedIndexChanged);

                Controls.Add(lb);
            }
            else if (e.Node.Text == "DataGridView")
            {
                DataSet ds = new DataSet("XML fail"); // loeb faili 
                ds.ReadXml(@"..\..\raamat.xml");
                DataGridView dg = new DataGridView();
                dg.Width = 500;
                dg.Height = 150;
                dg.Location = new Point(500, 400);
                dg.AutoGenerateColumns = true;
                dg.DataSource = ds;
                dg.DataMember = "book";
                Controls.Add(dg);
            }
            else if (e.Node.Text == "MainMenu")
            {
                MainMenu menu = new MainMenu();
                MenuItem menuFile = new MenuItem("File");
                MenuItem menuOpen =new MenuItem ("&Open", new EventHandler(menuFile_Exit), Shortcut.CtrlO);
                menuFile.MenuItems.Add(menuOpen);
                menuFile.MenuItems.Add("Tee taust valgeks", new EventHandler(menu_MakeWhite));
                menuFile.MenuItems.Add("Minimeeri", new EventHandler(menu_Minimize));
                menuFile.MenuItems.Add("Kuva teade", new EventHandler(menu_ShowMessage));
                menuFile.MenuItems.Add("Suurenda akent", new EventHandler(menu_Maximize));

                MenuItem menuExit = new MenuItem("&Exit", new EventHandler(menuFile_Exit), Shortcut.CtrlQ);
                menuFile.MenuItems.Add(menuExit);
                menu.MenuItems.Add(menuFile);
                Menu = menu;
                

            }
        }
        private void menu_Minimize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void menu_Maximize (object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        private void menu_ShowMessage(object sender, EventArgs e)
        {
            MessageBox.Show("Tere tulemast!");
        }

        private void menu_ResizeWindow(object sender, EventArgs e)
        {
            this.Width = 800;
            this.Height = 600;
        }
        private void menu_MakeWhite(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
        }
        private void menu_Open(object sender, EventArgs e)
        {
            OpenForm();
        }
        private void OpenForm()
        {
            Form uusvorm = new Form();
            uusvorm.Text = "UUS VORM";
            uusvorm.Size = new Size(300, 300);
            uusvorm.StartPosition = FormStartPosition.CenterParent;
            uusvorm.Show();
        }
        private void menuFile_Exit(object sender,EventArgs e)
        {
            Close();
        }

        private void Lb_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (lb.SelectedItem.ToString())
            {
                case "Roheline": tree.BackColor = Color.Green; break;
                case "Sinine": tree.BackColor = Color.Blue; break;
                case "Kollane": tree.BackColor = Color.Yellow; break;
                case "Punane": tree.BackColor = Color.Red; break;

                default:
                    break;

            }
        }

        private void Rnupp1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton nupp = sender as RadioButton;
            if (nupp == rnupp1 && nupp.Checked)
            {
                BackColor = Color.Bisque;
            }
            else if (nupp == rnupp2 && nupp.Checked)
            {
                BackColor = Color.Gray;
            }
        }

        private void Mruut2_CheckedChanged(object sender, EventArgs e)
        {
            Controls.Add(pilt);
            if (mruut2.Checked)
            {
                pilt.Visible = true;
                mruut1.Text = "Peida pilt";

            }
            else
            {
                pilt.Visible = false;
                mruut1.Text = "Näita pilt";
            }
        }

        private void Mruut1_CheckedChanged(object sender, EventArgs e)
        {
            if (mruut1.Checked)
            {
                Size = new Size(500, 300);
                mruut1.Text = "Tee suuremaks";

            }
            else
            {
                Size = new Size(1000, 600);
                mruut1.Text = "Tee väiksemaks";
            }
        }
    }
}
