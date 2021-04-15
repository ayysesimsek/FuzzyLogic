using _163311055_bm.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _163311055_bm
{
    public partial class Form1 : Form
    {
        #region Properties
        /// <summary>
        /// operations nesne türetilen property
        /// </summary>
        WashingMachineOperations operations = new WashingMachineOperations();
        /// <summary>
        /// Tanımlanan component ile list tanımlanmıştır.
        /// </summary>
        List<Rules> rules = new List<Rules>();
        #endregion

        #region Constructor

        /// <summary>
        /// the UI Fuzzy Logic Constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            LoadToInitialize();
        }

        #endregion

        #region Event / Click

        /// <summary>
        /// Trackbar kaydırıldığı zaman değerlerin yüklenmesi sağlanmaktadır.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //(e != null) Event tetiklenmesi dışında girilmemesi için

            TrackBar activeTrackBar = sender as TrackBar;
            NumericUpDown activeNumericUpDown = activeTrackBar.Parent.Controls.OfType<NumericUpDown>().First();
            int indis = int.Parse(Regex.Replace(activeTrackBar.Name, ConstantsValues.DFile, String.Empty));
            if (e == null && activeTrackBar.Value < 9975)
                activeTrackBar.Value = (int)(activeNumericUpDown.Value * 1000);
            var temp = (double)activeTrackBar.Value / 1000;
            double X = temp > 0 ? temp : 0.03;
            if (e != null)
                activeNumericUpDown.Value = (decimal)X;
            string lineStr = (operations.IntersectionCalculated(temp, (EnumValues.Intersection)(indis - 1)).Min().ToString());
            if (e != null)
                Calculated();
        }

        /// <summary>
        /// Numeric componenti ile trackbarım birlikte değeri iletmesi işlenmektedir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (!(sender as Control).Focused) return;
            TrackBar tb = (sender as Control).Parent.Controls.OfType<TrackBar>().First();
            trackBar1_Scroll(tb, null);
            Calculated();
        }

        #region Tam ekran modu
        private void ckMX_CheckedChanged(object sender, EventArgs e)
        {
            if (ckMX.Checked)
            {
                #region Tam Ekran Modunu Aç Tıklanılmış ise
                if (ckMX.Text == ConstantsValues.FullScreenModeOpened)
                {
                    this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                    ckMX.Text = ConstantsValues.FullScreenModeClosed;
                    ckMX.Checked = false;
                    return;
                }
                #endregion
                #region Tam Ekran Moduu Kapa Tıklanılmış ise
                if (ckMX.Text == ConstantsValues.FullScreenModeClosed)
                {
                    this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                    ckMX.Text = ConstantsValues.FullScreenModeOpened;
                    ckMX.Checked = false;
                    return;
                }
                #endregion
            }
        }
        #endregion

        #endregion

        #region Methods

        /// <summary>
        /// Hesaplama işlemleri yapılmaktadır.
        /// </summary>
        public void Calculated()
        {
            if (flowLayoutPanel1.Controls.Count != 8) return;
            int componentCounter = 0;

            #region numerikten hassaslık miktar ve kirlilik değerleri alınıp değişkene aktarılmaktadır.
            double hassaslik, miktar, kirlilik;
            hassaslik = (double)numericUpDown1.Value;
            miktar = (double)numericUpDown2.Value;
            kirlilik = (double)numericUpDown3.Value;
            #endregion

            CoordinatedCalculate(hassaslik, miktar, kirlilik, componentCounter);
            WeightAvarageCalculated();
            DetergentCalculated();
            TimeToCalculated();
        }

        /// <summary>
        /// Sayfa Yüklenmesi.
        /// </summary>
        public void LoadToInitialize()
        {
            trackBar1_Scroll(trackBar1, null);
            trackBar1_Scroll(trackBar2, null);
            trackBar1_Scroll(trackBar3, null);

            //Komponentlerin Calışma zamanında kasmaması için arkaplanda öncedn oluşturulur
            for (int i = 0; i < 8; i++)
                flowLayoutPanel1.Controls.Add(new RuleComponent() { Visible = false });
        }

        /// <summary>
        /// Hesaplama yapılmaktadır.
        /// </summary>
        /// <param name="hassaslik"></param>
        /// <param name="miktar"></param>
        /// <param name="kirlilik"></param>
        /// <param name="componentCounter"></param>
        public void CoordinatedCalculate(double hassaslik, double miktar, double kirlilik, int componentCounter)
        {
            #region  Koordinat hesaplama
            // flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.SuspendLayout();
            foreach (var list1 in operations.IntersectionList[0])
            {
                foreach (var list2 in operations.IntersectionList[1])
                {
                    foreach (var list3 in operations.IntersectionList[2])
                    {
                        Rules rule = new Rules(list1, list2, list3);
                        rule.XCoordinatValues(hassaslik, miktar, kirlilik);
                        rules.Add(rule);

                        RuleComponent ruleComponent = flowLayoutPanel1.Controls[componentCounter++] as RuleComponent;
                        ruleComponent.TheSetRules(rule);
                        ruleComponent.Visible = true;
                    }
                }
            }

            var count = flowLayoutPanel1.Controls.OfType<RuleComponent>().Where(a => a.Visible == true).Count();
            for (int i = componentCounter; i < 8; i++)
                flowLayoutPanel1.Controls[i].Visible = false;
            flowLayoutPanel1.ResumeLayout();
            #endregion
        }

        /// <summary>
        /// Ağırlık hesaplaması yapılmaktadır.
        /// </summary>
        public void WeightAvarageCalculated()
        {
            #region Ağırlık Merkezi
            // <<Kurala ait Minimum kesişimi> , <Minimum değere sahip ara değer grafiğinin ağırlığı>>
            List<Tuple<double, double>> WeightReturnAverage = new List<Tuple<double, double>>();
            for (int i = 0; i < 5; i++)
            {
                EnumValues.RotationalSpeed rotational = (EnumValues.RotationalSpeed)i;
                var item = rules.Where(a => a.RotationalSpeed == rotational); //Çıktı Grafiğinin Ara değer grafiklerine karşılık gelen Enumlarını getir
                Tuple<double, double> maxTupple = null;
                if (item.Count() > 0)
                {
                    var maxValue = item.Max(b => b.GetMinIntersectionX); //Min. Gelen değerin Maximum değer seçimi
                    var maxItem = item.First(a => a.GetMinIntersectionX == maxValue); // Maximum değere sahip nesnenin bulunması
                    maxTupple = new Tuple<double, double>(maxItem.GetMinIntersectionX, maxItem.BringWeight(EnumValues.CenterOfGravity.DonusHizi));
                    WeightReturnAverage.Add(maxTupple);
                }

                if (maxTupple != null)
                {
                    Series series = chart4.Series.Any(a => a.Name == ConstantsValues.Area + i) ? chart4.Series[ConstantsValues.Area + i] : new Series(ConstantsValues.Area + i);
                    series.ChartType = SeriesChartType.Area;
                    series.Color = Color.FromArgb(175, 255 - (i * 51), i * 51, 255 / (i + 1));
                    series.Points.Clear();

                    var list = operations.Calculated(EnumValues.CenterOfGravity.DonusHizi, maxTupple.Item1, i);
                    foreach (var l in list)
                        series.Points.AddXY(l.X, l.Y);

                    if (!chart4.Series.Contains(series))
                        chart4.Series.Add(series);
                }
            }
            #endregion
            label15.Text = WeightReturnAverage.WeightedAverageCalculation(a => a.Item1, b => b.Item2).ToString();
        }

        /// <summary>
        /// Deterjan hesaplaması yapılmaktadır.
        /// </summary>
        public void DetergentCalculated()
        {
            #region Deterjan
            List<Tuple<double, double>> WeightDetergentAverage = new List<Tuple<double, double>>();
            for (int i = 0; i < 5; i++)
            {
                EnumValues.Detergent deterjan = (EnumValues.Detergent)i;
                var item = rules.Where(a => a.Detergent == deterjan);
                Tuple<double, double> maxTupple = null;
                if (item.Count() > 0)
                {
                    var maximumValue = item.Max(b => b.GetMinIntersectionX);    //Maximum Seçimi
                    var maxItem = item.First(a => a.GetMinIntersectionX == maximumValue);
                    maxTupple = new Tuple<double, double>(maxItem.GetMinIntersectionX, maxItem.BringWeight(EnumValues.CenterOfGravity.Deterjan));
                    WeightDetergentAverage.Add(maxTupple);
                }

                if (maxTupple != null)
                {
                    Series series = chart5.Series.Any(a => a.Name == ConstantsValues.Area + i) ? chart5.Series[ConstantsValues.Area + i] : new Series(ConstantsValues.Area + i);
                    series.ChartType = SeriesChartType.Area;
                    series.Color = Color.FromArgb(175, 255 - (i * 51), i * 51, 255 / (i + 1));
                    series.Points.Clear();

                    var list = operations.Calculated(EnumValues.CenterOfGravity.Deterjan, maxTupple.Item1, i);
                    foreach (var l in list)
                        series.Points.AddXY(l.X, l.Y);

                    if (!chart5.Series.Contains(series))
                        chart5.Series.Add(series);
                }
            }
            #endregion
            label18.Text = WeightDetergentAverage.WeightedAverageCalculation(a => a.Item1, b => b.Item2).ToString();

        }

        /// <summary>
        /// Süre hesaplaması yapılmaktadır. 
        /// </summary>
        public void TimeToCalculated()
        {
            #region Süre
            List<Tuple<double, double>> WeightTimeAverage = new List<Tuple<double, double>>();
            for (int i = 0; i < 5; i++)
            {
                EnumValues.Time sure = (EnumValues.Time)i;
                var item = rules.Where(a => a.Time == sure);
                Tuple<double, double> maxTupple = null;
                if (item.Count() > 0)
                {
                    var maxValue = item.Max(b => b.GetMinIntersectionX);
                    var maxItem = item.First(a => a.GetMinIntersectionX == maxValue);
                    maxTupple = new Tuple<double, double>(maxItem.GetMinIntersectionX, maxItem.BringWeight(EnumValues.CenterOfGravity.Sure));
                    WeightTimeAverage.Add(maxTupple);
                }

                if (maxTupple != null)
                {
                    Series series = chart6.Series.Any(a => a.Name == ConstantsValues.Area + i) ? chart6.Series[ConstantsValues.Area + i] : new Series(ConstantsValues.Area + i);
                    series.ChartType = SeriesChartType.Area;
                    series.Color = Color.FromArgb(175, 255 - (i * 51), i * 51, 255 / (i + 1));
                    series.Points.Clear();

                    var list = operations.Calculated(EnumValues.CenterOfGravity.Sure, maxTupple.Item1, i);
                    foreach (var l in list)
                        series.Points.AddXY(l.X, l.Y);

                    if (!chart6.Series.Contains(series))
                        chart6.Series.Add(series);
                }
            }
            #endregion

            label17.Text = WeightTimeAverage.WeightedAverageCalculation(a => a.Item1, b => b.Item2).ToString();
        }

        #endregion
    }
}
