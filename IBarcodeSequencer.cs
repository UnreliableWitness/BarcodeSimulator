using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput.Native;

namespace BarcodeSimulator.Ui
{
    /// <summary>
    /// Mimics keyboard input, emits barcode start and stop chars (stx etx)
    /// </summary>
    public interface IBarcodeSequencer
    {

        /// <summary>
        /// Emits a single barcode
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        void EmitBarcodes(BarcodeSequence sequence, VirtualKeyCode endWith);

        /// <summary>
        /// Emits a collection of barcodes at a set interval.
        /// </summary>
        /// <param name="sequences">The sequences to emit.</param>
        /// <param name="speed">The speed in milliseconds.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task EmitBarcodesAsync(List<BarcodeSequence> sequences, VirtualKeyCode endWith, int speed, CancellationToken cancellationToken);
    }
}