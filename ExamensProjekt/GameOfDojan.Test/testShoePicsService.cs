using GameOfDojan.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GameOfDojan.Test
{
    [TestClass]
    public class TestShoePicsService
    {
        ShoePicService shoePicService = new ShoePicService();
        [TestMethod]
        public void ShouldReturnFilePathNameThatEndsWithJpg()
        {
            string filePath = shoePicService.GetNewFilePath("validate.jpg");
            Assert.AreEqual(".jpg", filePath.Substring(filePath.Length-4));
        }
        [TestMethod]
        public void ShouldReturnFilePathNameThatEndsWithPng()
        {
            string filePath = shoePicService.GetNewFilePath("validate.png");
            Assert.AreEqual(".png", filePath.Substring(filePath.Length - 4));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldReturnExceptionWhenFilePathNameDontEndWithJpgOrPng()
        {
          shoePicService.GetNewFilePath("DontValidate.pdf");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldReturnArgExceptionDueToNull()
        {
            shoePicService.GetNewFilePath(null);
        }

    }
    
}
