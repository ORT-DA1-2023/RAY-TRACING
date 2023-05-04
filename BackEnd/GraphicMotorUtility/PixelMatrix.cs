﻿using System.Drawing;

namespace Render3D.BackEnd.GraphicMotorUtility
{
    public class PixelMatrix
    {
        private Vector3D[,] _matrix;
        private int _width;
        private int _height;

        public PixelMatrix()
        {
            
        }

        public PixelMatrix(int width, int height)
        {
            _width = width;
            _height = height;
            _matrix = new Vector3D[height, width];
        }

        public Vector3D[,] Matrix
        {
            get { return _matrix; }
            set { _matrix = value; }
        }
       
    }
}