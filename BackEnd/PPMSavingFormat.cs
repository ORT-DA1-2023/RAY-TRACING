﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Render3D.BackEnd
{
    public class PPMSavingFormat : ISavingFormat
    {
        public  void Save(Bitmap ppm, string directory)
        {
            ppm.Save(directory);
        }
    }
}