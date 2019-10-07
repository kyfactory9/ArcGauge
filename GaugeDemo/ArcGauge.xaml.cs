using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GaugeDemo
{
    /// <summary>
    /// Interaction logic for ArcGauge.xaml
    /// </summary>
    public partial class ArcGauge : UserControl
    {
        public static readonly DependencyProperty GaugeTitleProperty = DependencyProperty.Register("GaugeTitle", typeof(string), typeof(ArcGauge), new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty GaugeUnitProperty = DependencyProperty.Register("GaugeUnit", typeof(string), typeof(ArcGauge), new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty MaxProperty = DependencyProperty.Register("Max", typeof(double), typeof(ArcGauge), new PropertyMetadata(100.0, new PropertyChangedCallback(Rerender)));
        public static readonly DependencyProperty MinProperty = DependencyProperty.Register("Min", typeof(double), typeof(ArcGauge), new PropertyMetadata(0.0, new PropertyChangedCallback(Rerender)));
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double), typeof(ArcGauge), new PropertyMetadata(0.0, new PropertyChangedCallback(Rerender)));
        public static readonly DependencyProperty SettingValueProperty = DependencyProperty.Register("SettingValue", typeof(double), typeof(ArcGauge), new PropertyMetadata(0.0, new PropertyChangedCallback(Rerender)));
        public static readonly DependencyProperty GaugeColorProperty = DependencyProperty.Register("GaugeColor", typeof(Brush), typeof(ArcGauge), new PropertyMetadata(Brushes.Gray));
        public static readonly DependencyProperty SettingGaugeColorProperty = DependencyProperty.Register("SettingGaugeColor", typeof(Brush), typeof(ArcGauge), new PropertyMetadata(Brushes.Red));

        public string GaugeTitle
        {
            get { return (string)GetValue(GaugeTitleProperty); }
            set { SetValue(GaugeTitleProperty, value); }
        }

        public string GaugeUnit
        {
            get { return (string)GetValue(GaugeUnitProperty); }
            set { SetValue(GaugeUnitProperty, value); }
        }

        public double Max
        {
            get { return (double)GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value); }
        }

        public double Min
        {
            get { return (double)GetValue(MinProperty); }
            set { SetValue(MinProperty, value); }
        }

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public double SettingValue
        {
            get { return (double)GetValue(SettingValueProperty); }
            set { SetValue(SettingValueProperty, value); }
        }

        public Brush GaugeColor
        {
            get { return (Brush)GetValue(GaugeColorProperty); }
            set { SetValue(GaugeColorProperty, value); }
        }

        public Brush SettingGaugeColor
        {
            get { return (Brush)GetValue(SettingGaugeColorProperty); }
            set { SetValue(SettingGaugeColorProperty, value); }
        }

        private static void Rerender(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ArcGauge gauge = d as ArcGauge;
            gauge.RenderGauge();
        }

        readonly double FULLRANGE_ANGLE = 270;
        readonly double START_ANGLE_OFFSET = 90.0;

        public ArcGauge()
        {
            InitializeComponent();

            RenderGauge();
        }

        private void RenderGauge()
        {
            Point point;

            #region

            if(Value >= Max)
            {
                point = new Point(320, 160);
                arcGauge.IsLargeArc = true;
            }
            else if(Value <= Min)
            {
                point = new Point(160, 320);
                arcGauge.IsLargeArc = false;
            }
            else
            {
                double angle = FULLRANGE_ANGLE / (Max - Min) * (Value - Min);
                double rad = (Math.PI / 180.0) * (angle + START_ANGLE_OFFSET);
                double x = 160 * Math.Cos(rad) + 160;
                double y = 160 * Math.Sin(rad) + 160;

                point = new Point(x, y);
                arcGauge.IsLargeArc = angle > 180.0;
            }

            arcGauge.Point = point;

            #endregion

            #region Setting Gauge

            if(SettingValue >= Max)
            {
                RotateTransform rotate = new RotateTransform();
                rotate.Angle = -90;
                ptSetup.RenderTransform = rotate;
            }
            else if(SettingValue <= Min)
            {
                RotateTransform rotate = new RotateTransform();
                rotate.Angle = 0;
                ptSetup.RenderTransform = rotate;
            }
            else
            {
                double angle = FULLRANGE_ANGLE / (Max - Min) * (SettingValue - Min);
                if(angle <= 180)
                {
                    RotateTransform rotate = new RotateTransform();
                    rotate.Angle = angle;
                    ptSetup.RenderTransform = rotate;
                }
                else
                {
                    RotateTransform rotate = new RotateTransform();
                    rotate.Angle = -360 + angle;
                    ptSetup.RenderTransform = rotate;
                }
            }

            #endregion
        }
    }
}
