using System.Collections.Generic;
using System.Net.Sockets;

namespace Converter
{
    public partial class Form1 : Form
    {
        const double x_pi = 3.14159265358979324 * 3000.0 / 180.0;
        const double pi = 3.1415926535897932384626;
        const double a = 6378245.0;
        const double ee = 0.00669342162296594323;
        List<double[]> coors = new List<double[]>();
        List<double[]> res = new List<double[]>();


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            res.Clear();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    foreach (double[] xy in coors)
                    {
                        res.Add(Gcj02ToBd09(xy[0], xy[1]));
                    };
                    break;
                case 1:
                    foreach (double[] xy in coors)
                    {
                        res.Add(Gcj02ToWgs84(xy[0], xy[1]));
                    };
                    break;
                case 2:
                    foreach (double[] xy in coors)
                    {
                        res.Add(Bd09ToGcj02(xy[0], xy[1]));
                    };
                    break;
                case 3:
                    foreach (double[] xy in coors)
                    {
                        res.Add(Bd09ToWgs84(xy[0], xy[1]));
                    };
                    break;
                case 4:
                    foreach (double[] xy in coors)
                    {
                        res.Add(Wgs84ToGcj02(xy[0], xy[1]));
                    };
                    break;
                case 5:
                    foreach (double[] xy in coors)
                    {
                        res.Add(Wgs84ToBd09(xy[0], xy[1]));
                    };
                    break;
            }
            textBox2.Text = "";
            foreach (var array in res)
            {
                try
                {
                    double[] round = [Math.Round(array[0], int.Parse(textBox1.Text)), Math.Round(array[1], int.Parse(textBox1.Text))];
                    string message = string.Join(", ", round);
                    textBox2.AppendText(message + Environment.NewLine);
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        public static double[] Gcj02ToBd09(double lng, double lat)
        {
            double z = Math.Sqrt(lng * lng + lat * lat) + 0.00002 * Math.Sin(lat * x_pi);
            double theta = Math.Atan2(lat, lng) + 0.000003 * Math.Cos(lng * x_pi);
            double bd_lng = z * Math.Cos(theta) + 0.0065;
            double bd_lat = z * Math.Sin(theta) + 0.006;
            return new double[] { bd_lng, bd_lat };
        }

        public static double[] Bd09ToGcj02(double bd_lon, double bd_lat)
        {
            double x = bd_lon - 0.0065;
            double y = bd_lat - 0.006;
            double z = Math.Sqrt(x * x + y * y) - 0.00002 * Math.Sin(y * x_pi);
            double theta = Math.Atan2(y, x) - 0.000003 * Math.Cos(x * x_pi);
            double gg_lng = z * Math.Cos(theta);
            double gg_lat = z * Math.Sin(theta);
            return new double[] { gg_lng, gg_lat };
        }

        public static double[] Wgs84ToGcj02(double lng, double lat)
        {
            if (OutOfChina(lng, lat))
                return new double[] { lng, lat };

            double dlat = TransformLat(lng - 105.0, lat - 35.0);
            double dlng = TransformLng(lng - 105.0, lat - 35.0);
            double radlat = lat / 180.0 * pi;
            double magic = Math.Sin(radlat);
            magic = 1 - ee * magic * magic;
            double sqrtmagic = Math.Sqrt(magic);
            dlat = (dlat * 180.0) / ((a * (1 - ee)) / (magic * sqrtmagic) * pi);
            dlng = (dlng * 180.0) / (a / sqrtmagic * Math.Cos(radlat) * pi);
            double mglat = lat + dlat;
            double mglng = lng + dlng;
            return new double[] { mglng, mglat };
        }

        public static double[] Gcj02ToWgs84(double lng, double lat)
        {
            if (OutOfChina(lng, lat))
                return new double[] { lng, lat };

            double dlat = TransformLat(lng - 105.0, lat - 35.0);
            double dlng = TransformLng(lng - 105.0, lat - 35.0);
            double radlat = lat / 180.0 * pi;
            double magic = Math.Sin(radlat);
            magic = 1 - ee * magic * magic;
            double sqrtmagic = Math.Sqrt(magic);
            dlat = (dlat * 180.0) / ((a * (1 - ee)) / (magic * sqrtmagic) * pi);
            dlng = (dlng * 180.0) / (a / sqrtmagic * Math.Cos(radlat) * pi);
            double mglat = lat + dlat;
            double mglng = lng + dlng;
            return new double[] { lng * 2 - mglng, lat * 2 - mglat };
        }

        public static double[] Bd09ToWgs84(double bd_lon, double bd_lat)
        {
            double[] gcj02 = Bd09ToGcj02(bd_lon, bd_lat);
            return Gcj02ToWgs84(gcj02[0], gcj02[1]);
        }

        public static double[] Wgs84ToBd09(double lon, double lat)
        {
            double[] gcj02 = Wgs84ToGcj02(lon, lat);
            return Gcj02ToBd09(gcj02[0], gcj02[1]);
        }

        private static double TransformLat(double lng, double lat)
        {
            double ret = -100.0 + 2.0 * lng + 3.0 * lat + 0.2 * lat * lat +
                0.1 * lng * lat + 0.2 * Math.Sqrt(Math.Abs(lng));
            ret += (20.0 * Math.Sin(6.0 * lng * pi) + 20.0 * Math.Sin(2.0 * lng * pi)) * 2.0 / 3.0;
            ret += (20.0 * Math.Sin(lat * pi) + 40.0 * Math.Sin(lat / 3.0 * pi)) * 2.0 / 3.0;
            ret += (160.0 * Math.Sin(lat / 12.0 * pi) + 320 * Math.Sin(lat * pi / 30.0)) * 2.0 / 3.0;
            return ret;
        }


        private static double TransformLng(double lng, double lat)
        {
            double ret = 300.0 + lng + 2.0 * lat + 0.1 * lng * lng +
                0.1 * lng * lat + 0.1 * Math.Sqrt(Math.Abs(lng));
            ret += (20.0 * Math.Sin(6.0 * lng * pi) + 20.0 * Math.Sin(2.0 * lng * pi)) * 2.0 / 3.0;
            ret += (20.0 * Math.Sin(lng * pi) + 40.0 * Math.Sin(lng / 3.0 * pi)) * 2.0 / 3.0;
            ret += (150.0 * Math.Sin(lng / 12.0 * pi) + 300.0 * Math.Sin(lng / 30.0 * pi)) * 2.0 / 3.0;
            return ret;
        }

        private static bool OutOfChina(double lng, double lat)
        {
            return !(lng > 73.66 && lng < 135.05 && lat > 3.86 && lat < 53.55);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "文本文件 (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                coors.Clear();
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    string line;
                    try
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] parts = line.Split(',');
                            double[] values = new double[2];

                            for (int i = 0; i < parts.Length; i++)
                            {
                                values[i] = double.Parse(parts[i]);
                            }

                            coors.Add(values);
                        }
                        MessageBox.Show("导入成功", "信息");
                        button1.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                Clipboard.SetText(textBox2.Text);
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                int num = int.Parse(textBox1.Text);
                if (num > 14)
                {
                    textBox1.Text = "14";
                }
                else if (num < 3)
                {
                    textBox1.Text = "3";
                }
            }catch(Exception ep)
            {
                MessageBox.Show(ep.Message);
            }

        }
    }

}

