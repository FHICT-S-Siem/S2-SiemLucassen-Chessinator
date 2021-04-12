using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace CircusTrein
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        Train train = new Train();

        private List<Train> container;

        public List<Train> Container
        {
            get => container;
            set 
            { 
                container = value;
                NotifyPropertyChanged();
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        public void NotifyPropertyChanged([CallerMemberName] string propname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int amount = int.Parse(tbAmount.Text.ToString());

            ComboBoxItem sizeItem = (ComboBoxItem)cbSize.SelectedItem;
            string size = sizeItem.Content.ToString();
            ComboBoxItem typeItem = (ComboBoxItem)cbType.SelectedItem;
            string type = typeItem.Content.ToString();
            Enum.TryParse(type, out AnimalType animalType);
            Enum.TryParse(size, out AnimalSize animalSize);
            Animal a = new Animal(animalSize, animalType);
            for (int count = 0; count < amount; count++)
            {
                train.AddAnimalToTrain(a);
            }
        }
    }
}
