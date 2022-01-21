using System.Linq;
using BarcodeSimulator.Ui;
using BarcodeSimulator.Ui.Services;
using BarcodeSimulator.Ui.ViewModels;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsInput.Native;

namespace BarcodeSimulator.Tests
{
    [TestClass]
    public class ShellViewModelTests
    {
        [TestMethod]
        public void NewBarcodeShouldBeAddedToList()
        {
            var shellVm = new ShellViewModel(A.Fake<IBarcodeSequencer>(), A.Fake<IFileDialogService>());

            shellVm.Barcode = "0001";
            shellVm.AddSequence();

            Assert.AreEqual(shellVm.BarcodeSequenceCollection.First().Barcode, "0001");
        }

        [TestMethod]
        public void NewSpeedShouldBeSet()
        {
            var shellVm = new ShellViewModel(A.Fake<IBarcodeSequencer>(), A.Fake<IFileDialogService>());

            shellVm.Speed = 2000;

            Assert.AreEqual(shellVm.Speed, 2000);
        }

        [TestMethod]
        public void NewEndWithShouldBeSet()
        {
            var shellVm = new ShellViewModel(A.Fake<IBarcodeSequencer>(), A.Fake<IFileDialogService>());

            shellVm.EndWith = VirtualKeyCode.TAB;

            Assert.AreEqual(shellVm.EndWith, VirtualKeyCode.TAB);
        }

        [TestMethod]
        public void RemoveBarcodeShouldRemoveFromList()
        {
            var shellVm = new ShellViewModel(A.Fake<IBarcodeSequencer>(), A.Fake<IFileDialogService>());

            shellVm.Barcode = "0001";
            shellVm.AddSequence();

            shellVm.Remove(shellVm.BarcodeSequenceCollection.First());
            Assert.AreEqual(shellVm.BarcodeSequenceCollection.Count, 0);
        }


    }


}
