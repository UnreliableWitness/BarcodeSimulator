using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using Caliburn.Micro;
using NHotkey;
using NHotkey.Wpf;

namespace BarcodeSimulator.Ui.ViewModels
{
    public class ShellViewModel : Screen
    {
        #region fields
        private readonly IBarcodeSequencer _barcodeSequencer;
        private string _barcode;
        private int _speed;
        private readonly CancellationTokenSource _cancellationTokenSource;

        #endregion

        #region bindings

        public int Speed
        {
            get { return _speed; }
            set
            {
                if (value == _speed) return;
                _speed = value;
                NotifyOfPropertyChange(() => Speed);
            }
        }

        public string Barcode
        {
            get { return _barcode; }
            set
            {
                if (value == _barcode) return;
                _barcode = value;
                NotifyOfPropertyChange(() => Barcode);
            }
        }

        public BindableCollection<BarcodeSequence> BarcodeSequenceCollection { get; private set; }
        #endregion bindings

        #region ctor
        public ShellViewModel(IBarcodeSequencer barcodeSequencer)
        {
            BarcodeSequenceCollection = new BindableCollection<BarcodeSequence>();
            Speed = 1000;
            _barcodeSequencer = barcodeSequencer;
            _cancellationTokenSource = new CancellationTokenSource();
        }
        #endregion

        protected override void OnViewLoaded(object view)
        {
            DisplayName = "BarcodeSimulator";
            HotkeyManager.Current.AddOrReplace("BarcodeRequest", Key.Insert, ModifierKeys.Shift, Handler);
        }

        private void Handler(object sender, HotkeyEventArgs hotkeyEventArgs)
        {
            var token = _cancellationTokenSource.Token;

            if (BarcodeSequenceCollection.Any())
            {
                if(BarcodeSequenceCollection.Count == 1)
                    _barcodeSequencer.EmitBarcodes(BarcodeSequenceCollection.Single());
                else
                    _barcodeSequencer.EmitBarcodesAsync(BarcodeSequenceCollection.ToList(), Speed, token).ConfigureAwait(false);
            }
        }

        public void AddSequence()
        {
            var newBarcodeSequence = new BarcodeSequence
            {
                Barcode = Barcode
            };
            BarcodeSequenceCollection.Add(newBarcodeSequence);

            Barcode = string.Empty;
        }

        public void Clear()
        {
            BarcodeSequenceCollection.Clear();
        }

        public void Save()
        {
            var dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "barcode-playlist"; // Default file name
            dlg.DefaultExt = ".text"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension 

            // Show save file dialog box
            bool? result = dlg.ShowDialog();

            // Process save file dialog box results 
            if (result == true)
            {
                // Save document 
                string filename = dlg.FileName;
                File.WriteAllLines(filename, BarcodeSequenceCollection.Select(b=>b.Barcode));
            }
        }

        public void Load()
        {
            var dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "barcode-playlist"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension 

            // Show open file dialog box
            bool? result = dlg.ShowDialog();

            // Process open file dialog box results 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                var lines = File.ReadAllLines(filename);
                BarcodeSequenceCollection.Clear();
                
                foreach (var line in lines)
                {
                    BarcodeSequenceCollection.Add(new BarcodeSequence{Barcode = line});
                }
            }
        }

        public void Remove(BarcodeSequence toRemove)
        {
            BarcodeSequenceCollection.Remove(toRemove);
        }
    }
}
