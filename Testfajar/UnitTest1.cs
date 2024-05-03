using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace ConsoleApp;
[TestClass]
public class GuruManagerTests
{
    private StateGuru stateGuru;

    [TestInitialize]
    public void Setup()
    {
        stateGuru = new StateGuru();
    }

    [TestMethod]
    public void TambahGuru()
    {
        // Arrange
        int jumlahGuru = 2;

        // Act
        stateGuru.TambahGuru();

        // Assert
        Assert.AreEqual(jumlahGuru, stateGuru.tasks.Count);
    }
}
