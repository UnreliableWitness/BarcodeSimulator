﻿using System.Linq;
using BarcodeSimulator.Ui;
using BarcodeSimulator.Ui.ViewModels;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BarcodeSimulator.Tests
{
    [TestClass]
    public class ShellViewModelTests
    {
        [TestMethod]
        public void NewBarcodeShouldBeAddedToList()
        {
            var shellVm = new ShellViewModel(A.Fake<IBarcodeSequencer>());

            shellVm.Barcode = "0001";
            shellVm.AddSequence();

            Assert.AreEqual(shellVm.BarcodeSequenceCollection.First().Barcode, "0001");
        }

        [TestMethod]
        public void NewSpeedShouldBeSet()
        {
            var shellVm = new ShellViewModel(A.Fake<IBarcodeSequencer>());

            shellVm.Speed = 2000;

            Assert.AreEqual(shellVm.Speed, 2000);
        }

        [TestMethod]
        public void RemoveBarcodeShouldRemoveFromList()
        {
            var shellVm = new ShellViewModel(A.Fake<IBarcodeSequencer>());

            shellVm.Barcode = "0001";
            shellVm.AddSequence();

            shellVm.Remove(shellVm.BarcodeSequenceCollection.First());
            Assert.AreEqual(shellVm.BarcodeSequenceCollection.Count, 0);
        }


    }


}
