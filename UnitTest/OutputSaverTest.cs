﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Render3D.BackEnd;
using Render3D.BackEnd.GraphicMotorUtility;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


namespace Render3D.UnitTest
{
    [TestClass]
    public class OutputSaverTest
    {
        private const string outputPath = "salida";



        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Could not save the file")]
        public void GivenNullDestinationJPGThrowsBackEndException()
        {
            Bitmap bitmap = new Bitmap(10, 10);

            string destinationPath = null;
            SavingFormat savingFormat = new JPGSavingFormat();
            OutputSaver outputSaver = new OutputSaver(bitmap, destinationPath, savingFormat);

            outputSaver.Save();
        }

        [TestMethod]
        public void givenBitmapSavesItAsJPG()
        {
            // Arrange
            Bitmap bitmap = new Bitmap(100, 100);
            string destinationPath = "test.jpg";
            SavingFormat format = new JPGSavingFormat();
            OutputSaver outputSaver = new OutputSaver(bitmap, destinationPath, format);
            outputSaver.Save();
            try
            {

                Assert.IsTrue(File.Exists(destinationPath));
                Assert.AreEqual(".jpg", Path.GetExtension(destinationPath).ToLower());
            }
            finally
            {
                if (File.Exists(destinationPath))
                    File.Delete(destinationPath);
            }
        }


        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Could not save the file")]
        public void GivenBitmapAndInvalidPathThrowsBackEndExceptionCaseJPG()
        {
            Bitmap bitmap = new Bitmap(100, 100);
            string destinationPath = "invalid/path/test.jpg";
            SavingFormat format = new JPGSavingFormat();
            OutputSaver outputSaver = new OutputSaver(bitmap, destinationPath, format);

            outputSaver.Save();
        }

        [TestMethod]
        public void GivenBitmapSavesItAsPDF()
        {
            Bitmap bitmap = new Bitmap(10, 10);
            string destinationPath = "test.pdf";
            SavingFormat format = new PDFSavingFormat();
            OutputSaver outputSaver = new OutputSaver(bitmap, destinationPath, format);

            outputSaver.Save();
            Assert.IsTrue(File.Exists(destinationPath));
            Assert.AreEqual(".pdf", Path.GetExtension(destinationPath).ToLower());

            if (File.Exists(destinationPath)) File.Delete(destinationPath);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Could not save the file")]
        public void GivenBitmapAndInvalidPathThrowsBackEndExceptionCasePDF()
        {
            Bitmap bitmap = new Bitmap(100, 100);
            string invalidDirectory = "invalid/path/test.pdf";
            SavingFormat format = new PDFSavingFormat();
            OutputSaver outputSaver = new OutputSaver(bitmap, invalidDirectory, format);

            outputSaver.Save();
        }
    }
}


