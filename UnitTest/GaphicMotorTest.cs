﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;
using System;
using System.Drawing;

namespace Render3D.UnitTest
{
    [TestClass]
    public class GraphicMotorTest
    {
        private GraphicMotor graphicMotorSample;
        private Scene sceneSample;

        private const int resolutionHeightSample = 500;
        private const int resolutionHeightSampleDefault = 3;
        private const int negativeResolutionHeightSample = -1;
        private const int zeroResolutionHeightSample = 0;

        private const int pixelSamplingSample = 79;
        private const int pixelSamplingSampleDefault = 50;
        private const int negativePixelSamplingSample = -1;
        private const int zeroPixelSamplingSample = 0;

        private const int maximumDepthSample = 30;
        private const int maximumDepthSampleDefault = 20;
        private const int negativeMaximumDepth = -1;
        private const int zeroMaximumDepth = 0;

        [TestInitialize]
        public void Initialize()
        {
            graphicMotorSample = new GraphicMotor();
        }

        [TestMethod]
        public void GivenValidSceneRenderMethodReturnsBitmap()
        {
            sceneSample = new Scene();
            Assert.AreNotEqual(graphicMotorSample.Render(sceneSample), null);
        }

        [TestMethod]
        public void GivenNonEmptySceneCreatesNonNullPreview()
        {
            Model model = new Model()
            {
                Figure = new Sphere() { Position = new Vector3D(0, 0, 0), Radius = 3 },
                Material = new LambertianMaterial() { Attenuation = new Colour(1, 1, 1) },
            };
           
            GraphicMotor graphicMotor = new GraphicMotor();
            Bitmap bitmap = graphicMotor.RenderModelPreview(model);
            Assert.IsNotNull(bitmap);
        }

        [TestMethod]
        public void GivenDefaultGraphicMotorItHasDefaultPixelSampling()
        {
            Assert.AreEqual(graphicMotorSample.PixelSampling, pixelSamplingSampleDefault);
        }

        [TestMethod]
        public void givenDefaultGraphicMotorItHasDefaultMaximumDepth()
        {
            Assert.AreEqual(graphicMotorSample.MaximumDepth, maximumDepthSampleDefault);
        }

        [TestMethod]
        public void GivenDefaultGraphicMotorItHasTheDefaultResolution()
        {
            Assert.AreEqual(graphicMotorSample.ResolutionHeight, resolutionHeightSampleDefault);
        }

        [TestMethod]
        public void GivenValidResolutionAssignsToGraphicMotor()
        {
            graphicMotorSample.ResolutionHeight = resolutionHeightSample;
            Assert.AreEqual(resolutionHeightSample, graphicMotorSample.ResolutionHeight);
        }

        [TestMethod]
        public void GivenValidPixelSamplingAssignsToGraphicMotor()
        {
            graphicMotorSample.PixelSampling = pixelSamplingSample;
            Assert.AreEqual(pixelSamplingSample, graphicMotorSample.PixelSampling);
        }

        [TestMethod]
        public void GivenValidMaximumDepthAssignsToGraphicMotor()
        {
            graphicMotorSample.MaximumDepth = maximumDepthSample;
            Assert.AreEqual(maximumDepthSample, graphicMotorSample.MaximumDepth);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The maximum depth must be greater than 0.")]
        public void GivenNegativeMaximumDepthThrowsBackEndException()
        {
            graphicMotorSample.MaximumDepth = negativeMaximumDepth;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The maximum depth must be greater than 0.")]
        public void GivenZeroMaximumDepthThrowsBackEndException()
        {
            graphicMotorSample.MaximumDepth = zeroMaximumDepth;
        }


        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The pixel sampling must be greater than 0.")]
        public void GivenNegativePixelSamplingThrowsBackEndException()
        {
            graphicMotorSample.PixelSampling = negativePixelSamplingSample;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The pixel sampling must be greater than 0.")]
        public void GivenZeroPixelSamplingThrowsBackEndException()
        {
            graphicMotorSample.PixelSampling = zeroPixelSamplingSample;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The resolution must be greater than 0.")]
        public void GivenNegativeResolutionThrowsABackEndException()
        {
            graphicMotorSample.ResolutionHeight = negativeResolutionHeightSample;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The resolution must be greater than 0.")]
        public void GivenZeroResolutionThrowsBackEndException()
        {
            graphicMotorSample.ResolutionHeight = zeroResolutionHeightSample;
        }

        [TestMethod]
        public void GivenGraphicMotorReturnsAspectRatio()
        {
            GraphicMotor motor = new GraphicMotor() { ResolutionHeight=300};
            double ratio=  motor.AspectRatio();
            Assert.AreEqual(1.5,ratio);
        }
    }
}
