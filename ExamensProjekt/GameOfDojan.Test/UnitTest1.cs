using GameOfDojan.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GameOfDojan.Test
{
    [TestClass]
    public class UnitTest1
    {
        ShoePicService shoePicService = new ShoePicService();
        [TestMethod]
        public void ShouldReturnFilePathNameThatEndsWithJpg()
        {
            string filePath = shoePicService.GetNewFilePath("validate.jpg");
            Assert.AreEqual(".jpg", filePath.Substring(filePath.Length-4));
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldReturnExceptionWhenFilePathNameDontEndWithJpgOrPng()
        {
          shoePicService.GetNewFilePath("DontValidate.pdf");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void xxxxxxxx()
        {
            shoePicService.GetNewFilePath(null);
        }

    }
    
}
