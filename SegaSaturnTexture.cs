/*
** SegaSaturn.NET
** Copyright (c) 2020-2021, Johannes Fetz (johannesfetz@gmail.com)
** All rights reserved.
**
** Redistribution and use in source and binary forms, with or without
** modification, are permitted provided that the following conditions are met:
**     * Redistributions of source code must retain the above copyright
**       notice, this list of conditions and the following disclaimer.
**     * Redistributions in binary form must reproduce the above copyright
**       notice, this list of conditions and the following disclaimer in the
**       documentation and/or other materials provided with the distribution.
**     * Neither the name of the Johannes Fetz nor the
**       names of its contributors may be used to endorse or promote products
**       derived from this software without specific prior written permission.
**
** THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
** ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
** WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
** DISCLAIMED. IN NO EVENT SHALL Johannes Fetz BE LIABLE FOR ANY
** DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
** (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
** LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
** ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
** (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
** SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using System;

namespace SegaSaturn.NET
{
    public class SegaSaturnTexture
    {
        public SegaSaturnTexture()
        {
        }

        public SegaSaturnTexture(int width, int height)
        {
            this.InitArgb32BitsPixelsA(width, height);
        }

        public int Width { get; set; }
        public int Height { get; set; }

        #region Image Contents (just one need to be filled)

        /// <summary>
        /// pixel = (x + y * width)
        /// </summary>
        public SegaSaturnColor[] Argb32BitsPixelsA { get; set; }
        /// <summary>
        /// pixel = [y][x]
        /// </summary>
        public SegaSaturnColor[][] Argb32BitsPixelsB { get; set; }
        /// <summary>
        /// pixel = [x][y]
        /// </summary>
        public SegaSaturnColor[][] Argb32BitsPixelsC { get; set; }

        #endregion

        public SegaSaturnColor GetPixel(int x, int y)
        {
            if (this.Argb32BitsPixelsA != null && this.Argb32BitsPixelsA.Length > 0)
                return this.Argb32BitsPixelsA[x + y * this.Width];
            if (this.Argb32BitsPixelsB != null && this.Argb32BitsPixelsB.Length > 0)
                return this.Argb32BitsPixelsB[y][x];
            if (this.Argb32BitsPixelsC != null && this.Argb32BitsPixelsC.Length > 0)
                return this.Argb32BitsPixelsC[x][y];
            throw new InvalidOperationException("Pixel array not set");
        }

        public void SetPixel(int x, int y, SegaSaturnColor color)
        {
            if (this.Argb32BitsPixelsA != null && this.Argb32BitsPixelsA.Length > 0)
                this.Argb32BitsPixelsA[x + y * this.Width] = color;
            else if (this.Argb32BitsPixelsB != null && this.Argb32BitsPixelsB.Length > 0)
                this.Argb32BitsPixelsB[y][x] = color;
            else if (this.Argb32BitsPixelsC != null && this.Argb32BitsPixelsC.Length > 0)
                this.Argb32BitsPixelsC[x][y] = color;
            throw new InvalidOperationException("Pixel array not set");
        }

        public void InitArgb32BitsPixelsA(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.Argb32BitsPixelsA = new SegaSaturnColor[width * height];
            this.Argb32BitsPixelsB = null;
            this.Argb32BitsPixelsC = null;
        }

        public string Name { get; set; }
    }
}
