using System;
using Microsoft.Maui.Controls;

namespace OlivoExamenP2
{
    public partial class MainPage : ContentPage
    {
        private readonly Dictionary<string, double> _conversionFactors = new()
        {
            {"metros", 1.0 },
            {"kilometros", 1000.0 },
            {"millas", 1609.34 }

        };

        public List<String> Units { get; set; }

        public MainPage() 
        {
            InitializeComponent();
            Units = new List<String> { "metros", "kilometros", "millas"};
            BindingContext = this;
        }

        private void OnConvertButtonClicked(object sender, EventArgs e) 
        {
            try 
            {
                //Obtiene los valores
                string? fromUnit = FromUnitPicker.SelectedItem?.ToString();
                string? toUnit = ToUnitPicker.SelectedItem?.ToString();
                string inputText = InputEntry.Text;

                if (string.IsNullOrWhiteSpace(inputText) || fromUnit == null || toUnit == null) 
                {
                    ResultLabel.Text = "Completa todos los campos";
                    return;
                }

                //conversor
                double inputValue = double.Parse(inputText);
                double fromFactor = _conversionFactors[fromUnit];
                double toFactor = _conversionFactors[toUnit];
                double result = (inputValue * fromFactor) / toFactor;

                //resultado
                ResultLabel.Text = $"{inputValue} {fromUnit} son {result:F2} {toUnit}";

            }
            catch 
            {
                ResultLabel.Text = "entrada invalida. intente de nuevo";
            }

        }
        private void OnClearButtonClicked(object sender, EventArgs e) 
        {
            InputEntry.Text = string.Empty;
            ResultLabel.Text = string.Empty;
            FromUnitPicker.SelectedIndex = 0;
            ToUnitPicker.SelectedIndex = 1;
        }
    }

}
