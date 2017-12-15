using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// reference Windows Forms so we can access the objects on the Form
using Week10_Calculator;
using System.Windows.Forms;

namespace Calculator_Tests
{
    [TestClass]
    public class Form1Tests
    {
        // reference Form1 in the calculator project
        Form1 frm;
        Button btnDisplay;

        [TestInitialize]
        public void TestInitialize()
        {
            // this runs automatically before each unit test
            // connect to the calculator form
            frm = new Form1();
            btnDisplay = frm.btnDisplay;
        }

        [TestMethod]
        public void SetTextValid()
        {
            // arrange - setup.  
            // Get initial text of the calculator display
            string CurrentDisplay = btnDisplay.Text;

            // act - execute or try a method
            frm.SetText("1");

            // assert - evaluate if we get the expected result or not
            Assert.AreEqual(CurrentDisplay + "1", btnDisplay.Text);
        }

        [TestMethod]
        public void AddValid()
        {
            // arrange
            frm.currentTotal = 10;
            frm.SetText("2");
            frm.firstInput = false;
            frm.op = "+";

            // act
            frm.Calculate(2);

            // assert
            Assert.AreEqual(12, frm.currentTotal);
        }

        [TestMethod]
        public void SubtractValid()
        {
            // arrange
            frm.currentTotal = 10;
            frm.SetText("2");
            frm.firstInput = false;
            frm.op = "-";

            // act
            frm.Calculate(2);

            // assert
            Assert.AreEqual(8, frm.currentTotal);
        }

        [TestMethod]
        public void MultipleValid()
        {
            // arrange
            frm.currentTotal = 10;
            frm.SetText("2");
            frm.firstInput = false;
            frm.op = "*";

            // act
            frm.Calculate(2);

            // assert
            Assert.AreEqual(20, frm.currentTotal);
        }

        [TestMethod]
        public void DivideValid()
        {
            // arrange
            frm.currentTotal = 10;
            frm.SetText("2");
            frm.firstInput = false;
            frm.op = "/";

            // act
            frm.Calculate(2);

            // assert
            Assert.AreEqual(5, frm.currentTotal);
        }

        [TestMethod]
        public void DivideByZeroInvalid()
        {
            // arrange
            frm.currentTotal = 10;
            frm.SetText("0");
            frm.firstInput = false;
            frm.op = "/";

            // act
            frm.Calculate(0);

            // assert
            Assert.AreEqual("ERROR", btnDisplay.Text);
        }

        [TestMethod]
        public void FirstInputValidTotal()
        {
            // arrange
            frm.firstInput = true;

            // act
            frm.Calculate(10);

            // assert
            Assert.AreEqual(10, frm.currentTotal);
        }

        [TestMethod]
        public void FirstInputBecomesFalse()
        {
            // arrange
            frm.firstInput = true;

            // act
            frm.Calculate(10);

            // assert - firstInput should now be changed to false
            Assert.AreEqual(false, frm.firstInput);

        }
    }
}
