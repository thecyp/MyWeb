using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWinForm
{
    public partial class Form1 : Form
    {
        //建構子Constructor
        public Form1()
        {
            InitializeComponent();
            //執行階段建構一個按鈕個體物件
           Button myButton = new Button();
            //設定提示
            myButton.Text = "我是按鈕";//Property設定setter屬性設定程序
            Font f = new Font("新細明體", 24.0f);
            myButton.Font = f;            //設定座標
            myButton.Size = new Size(300, 50);
            myButton.Location = new Point(100, 100);
            //定義按鈕要呈現現在表單物件上 表單是一個容器Container(內含集合)
            //巢狀類別架構 class.class
            Control.ControlCollection col = this.Controls;//Property Xxxxs 往往問出一個集合物件

            //有事嗎? 被噹了...(+= 可以進行多重委派)
            //myButton.Click += new EventHandler(clickMe);
            //使用Lambda Expression(拉姆達表達式(可以程序 function))
            myButton.Click += (sender, args) =>
            {
                MessageBox.Show("被噹了..");
            };

            //透過集合參考 參考一個Control
            col.Add(myButton);

        }
        //事件程序Method
        public void clickMe(object sender, EventArgs args)
        {

        }
    }
}
