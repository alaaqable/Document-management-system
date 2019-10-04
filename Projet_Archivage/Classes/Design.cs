using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_Archivage
{
    class Design
    {
        public void HoverTextChanger(Button BtnMain, string ImageMain, Button BTN1, string ImageBTN1, Button BTN2, string ImageBTN2, Button BTN3, string ImageBTN3, Panel panel)
        {
            panel.Top = BtnMain.Top;
            panel.Height = BtnMain.Height;
            BtnMain.ForeColor = ColorTranslator.FromHtml("#004a93");
            BtnMain.BackColor = ColorTranslator.FromHtml("#1e1e1e");
            BtnMain.Image = Image.FromFile(ImageMain);
            
            BTN1.ForeColor = ColorTranslator.FromHtml("#848484");
            BTN1.BackColor = ColorTranslator.FromHtml("#333333");
            BTN1.Image = Image.FromFile(ImageBTN1);

            BTN2.ForeColor = ColorTranslator.FromHtml("#848484");
            BTN2.BackColor = ColorTranslator.FromHtml("#333333");
            BTN2.Image = Image.FromFile(ImageBTN2);

            BTN3.ForeColor = ColorTranslator.FromHtml("#848484");
            BTN3.BackColor = ColorTranslator.FromHtml("#333333");
            BTN3.Image = Image.FromFile(ImageBTN3);
        }
        public void Clickchanger(Button BtnMain,string BTNMainImage,Button Btn1, string Btn1Image, Button Btn2, string Btn2Image, Button Btn3, string Btn3Image, Button Btn4, string Btn4Image, Button Btn5, string Btn5Image, Button Btn6, string Btn6Image)
        {
            BtnMain.BackColor = ColorTranslator.FromHtml("#444444");
            BtnMain.ForeColor = ColorTranslator.FromHtml("#CFCDCE");
            BtnMain.Image = Image.FromFile(BTNMainImage);

            Btn1.BackColor = ColorTranslator.FromHtml("#CFCDCE");
            Btn1.ForeColor = ColorTranslator.FromHtml("#444444");
            Btn1.Image = Image.FromFile(Btn1Image);

            Btn2.BackColor = ColorTranslator.FromHtml("#CFCDCE");
            Btn2.ForeColor = ColorTranslator.FromHtml("#444444");
            Btn2.Image = Image.FromFile(Btn2Image);

            Btn3.BackColor = ColorTranslator.FromHtml("#CFCDCE");
            Btn3.ForeColor = ColorTranslator.FromHtml("#444444");
            Btn3.Image = Image.FromFile(Btn3Image);

            Btn4.BackColor = ColorTranslator.FromHtml("#CFCDCE");
            Btn4.ForeColor = ColorTranslator.FromHtml("#444444");
            Btn4.Image = Image.FromFile(Btn4Image);

            Btn5.BackColor = ColorTranslator.FromHtml("#CFCDCE");
            Btn5.ForeColor = ColorTranslator.FromHtml("#444444");
            Btn5.Image = Image.FromFile(Btn5Image);

            Btn6.BackColor = ColorTranslator.FromHtml("#CFCDCE");
            Btn6.ForeColor = ColorTranslator.FromHtml("#444444");
            Btn6.Image = Image.FromFile(Btn6Image);
        }
        public void CenterGestionPanelChanger(Panel panelMain,Panel panel)
        {
            panelMain.Controls.Clear();
            panelMain.Controls.Add(panel);
            panel.Dock = DockStyle.Fill;
        }
        public void UserControlChanger(Panel panelMain, UserControl control)
        {
            panelMain.Controls.Clear();
            panelMain.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }
        public void TextBox_PlaceHolder(TextBox textbox,string text)
        {
            if(textbox.Text == "")
            {
                textbox.Text = text;
                textbox.ForeColor = Color.Gray;
            }else if (textbox.Text == text)
            {
                textbox.Clear();
                textbox.ForeColor = ColorTranslator.FromHtml("#444444");
            }
        }
        public void BTNUPDown(Button button,Image image)
        {
            button.Image = image;
        }
        public void BTNUPDown(Button button, Image image,string text)
        {
            button.Image = image;
            button.ForeColor = ColorTranslator.FromHtml(text);
        }
        // Navigation Methods
        public void First(DataGridView data,int position,Label label)
        {
            
            data.ClearSelection();
            data.Rows[position].Selected = true;
            label.Text = position + 1 + "/" + data.Rows.Count;
            
        }
        public void Previous(DataGridView data, int position, Label label)
        {
            try
            {

                    if (position >= 0)
                    {
                        data.ClearSelection();
                        data.Rows[position].Selected = true;
                        label.Text = position + 1 + "/" + data.Rows.Count;
                    }
                    else
                    {
                        position++;
                    }
            }
            catch { }
        }
        public void Next(DataGridView data, int position, Label label)
        {
            try
            {
                    if (position < data.Rows.Count)
                    {
                        data.ClearSelection();
                        data.Rows[position].Selected = true;
                        label.Text = position + 1 + "/" + data.Rows.Count;
                    }
                    else
                    {
                        position--;
                    }
            }
            catch { }
        }
        public void Last(DataGridView data, int position, Label label)
        {
                data.ClearSelection();
                data.Rows[position].Selected = true;
                label.Text = position + 1 + "/" + data.Rows.Count;
        }
        public void LabelManager(Label label,int PositionMin,int PositionMax)
        {
            if (label.Text.Length >= 1 && label.Text.Length <= 2)
            {
                label.Location = new Point(PositionMin, label.Location.Y);
            }
            if (label.Text.Length >= 3)
            {
                label.Location = new Point(PositionMax, label.Location.Y);
            }
        }
    }
}
