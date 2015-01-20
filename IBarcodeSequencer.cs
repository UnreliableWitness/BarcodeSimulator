using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BarcodeSimulator.Ui
{
    public interface IBarcodeSequencer
    {
        void EmitBarcodes(BarcodeSequence sequence);
        Task EmitBarcodesAsync(List<BarcodeSequence> sequences, int speed, CancellationToken cancellationToken);
    }
}