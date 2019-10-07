using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaugeDemo
{
    class MainWindowModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged == null) return;

            PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private string _gaugeTitle;
        private string _gaugeUnit;
        private double _max;
        private double _min;
        private double _value;
        private double _settingValue;

        public string GaugeTitle
        {
            get { return _gaugeTitle; }
            set
            {
                _gaugeTitle = value;
                OnPropertyChanged("GaugeTitle");
            }
        }

        public string GaugeUnit
        {
            get { return _gaugeUnit; }
            set
            {
                _gaugeUnit = value;
                OnPropertyChanged("GaugeUnit");
            }
        }

        public double Max
        {
            get { return _max; }
            set
            {
                _max = value;
                OnPropertyChanged("Max");
            }
        }

        public double Min
        {
            get { return _min; }
            set
            {
                _min = value;
                OnPropertyChanged("Min");
            }
        }

        public double Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }

        public double SettingValue
        {
            get { return _settingValue; }
            set
            {
                _settingValue = value;
                OnPropertyChanged("SettingValue");
            }
        }
    }
}
