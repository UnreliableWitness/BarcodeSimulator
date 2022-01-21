using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace BarcodeSimulator.Ui
{
    public class BarcodeSequencer : IBarcodeSequencer
    {
        private readonly IInputSimulator _inputSimilator ;

        public BarcodeSequencer(IInputSimulator inputSimulator)
        {
            _inputSimilator = inputSimulator;
        }

        public void EmitBarcodes(BarcodeSequence sequence, VirtualKeyCode endWith)
        {
            const char stx = (char)0x02;
            const char etx = (char)0x03;

            _inputSimilator.Keyboard.TextEntry(stx);
            foreach (var character in sequence.Barcode)
            {
                _inputSimilator.Keyboard.TextEntry(character);
            }
            _inputSimilator.Keyboard.TextEntry(etx);
            _inputSimilator.Keyboard.KeyPress(endWith);
        }

        public async Task EmitBarcodesAsync(List<BarcodeSequence> sequences, VirtualKeyCode endWith, int speed, CancellationToken cancellationToken)
        {
            await Task.Run(async () =>
            {
                foreach (var barcodeSequence in sequences)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    EmitBarcodes(barcodeSequence, endWith);
                    await Task.Delay(speed, cancellationToken);
                }
            }, cancellationToken);

        }
    }
}
