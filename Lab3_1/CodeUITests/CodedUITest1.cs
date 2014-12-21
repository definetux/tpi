using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITest.Common.UIMap;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace CodeUITests
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        public CodedUITest1()
        {
        }

        [TestMethod]
        public void AddGoodPathTest()
        {
            this.UIMap.AddGoodPath();
            this.UIMap.AssertTruePathList();
        }

        [TestMethod]
        public void AddBadPathTest()
        {
            this.UIMap.AddBadPath();
            this.UIMap.AssertBadPathList();
        }

        [TestMethod]
        public void MoveTruePathTest()
        {
            this.UIMap.AddGoodPath();
            this.UIMap.MoveTruePath();
            this.UIMap.AssertBadPathListAfterMove();
        }

        [TestMethod]
        public void RemovePathFromBadPathListTest()
        {
            this.UIMap.AddBadPath();
            this.UIMap.RemoveBadPath();
            this.UIMap.AssertBadPathListAfterRemove();
        }

        [TestMethod]
        public void RemovePathFromTruePathListTest()
        {
            this.UIMap.AddGoodPath();
            this.UIMap.RemoveTruePath();
            this.UIMap.AssertTruePathListAfterRemoving();
        }

        [TestMethod]
        public void BackBadPathTest()
        {
            this.UIMap.AddBadPath();
            this.UIMap.BackBadPath();
            this.UIMap.AssertInputAfterBacking();
        }

        [TestMethod]
        public void AddEmptyInputTest()
        {

            this.UIMap.AddEmptyPath();
            this.UIMap.AssertMessageAfterAddingEmptyPath();
        }

        [TestMethod]
        public void BackEmptyBadPathTest()
        {

            this.UIMap.BackEmptyBadPath();
            this.UIMap.AssertMessageAfterBackingEmptyBadPath();

        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
