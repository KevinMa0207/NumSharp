﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using NumSharp.Core.Extensions;
using System.Linq;
using NumSharp.Core;

namespace NumSharp.UnitTest.Extensions
{
    [TestClass]
    public class NdArrayInvTest
    {
        [TestMethod]
        public void Simple2x2()
        {
            NDArrayGeneric<double> np1 = new NDArrayGeneric<double>().arange(4).reshape(2,2);

            NDArrayGeneric<double> np1Inv = np1.inv();

            var OncesMatrix = np1.dot(np1Inv);

             Assert.IsTrue(OncesMatrix[0,0] == 1);
             Assert.IsTrue(OncesMatrix[1,1] == 1);
             Assert.IsTrue(OncesMatrix[1,0] == 0);
             Assert.IsTrue(OncesMatrix[0,1] == 0);
        }
        [TestMethod]
        public void Simple3x3()
        {
            NDArrayGeneric<double> np1 = new NDArrayGeneric<double>().Zeros(3,3);

            np1[0,0] = 5;
            np1[0,1] = 1;
            np1[0,2] = 2;
            np1[1,0] = 1;
            np1[1,1] = 0;
            np1[1,2] = 1;
            np1[2,0] = 1;
            np1[2,1] = 1;
            np1[2,2] = 0;

            NDArrayGeneric<double> np1Inv = np1.inv();

            var OncesMatrix = np1.dot(np1Inv);

            Assert.IsTrue(Math.Abs(OncesMatrix[0,0]) < 1.000001);
            Assert.IsTrue(Math.Abs(OncesMatrix[1,1]) < 1.000001);
            Assert.IsTrue(Math.Abs(OncesMatrix[2,2]) < 1.000001);
            
            Assert.IsTrue(Math.Abs(OncesMatrix[0,1]) < 0.000001);
            Assert.IsTrue(Math.Abs(OncesMatrix[0,2]) < 0.000001);
            Assert.IsTrue(Math.Abs(OncesMatrix[1,0]) < 0.000001);
            Assert.IsTrue(Math.Abs(OncesMatrix[1,2]) < 0.000001);
            Assert.IsTrue(Math.Abs(OncesMatrix[2,0]) < 0.000001);
            Assert.IsTrue(Math.Abs(OncesMatrix[2,1]) < 0.000001);
            
        }
    }
}
