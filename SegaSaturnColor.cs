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
using System.Drawing;

namespace SegaSaturn.NET
{
    public class SegaSaturnColor
    {
        public SegaSaturnColor()
        {
        }

        public SegaSaturnColor(Color c)
        {
            this.DotNetColor = c;
        }

        public SegaSaturnColor(int argb32Bits) : this(Color.FromArgb(argb32Bits))
        {
        }

        public SegaSaturnColor(ushort saturnColor)
        {
            this.SaturnColor = saturnColor;
        }

        public SegaSaturnColor(string saturnHexaString) : this(Convert.ToUInt16(saturnHexaString, 16))
        {
        }

        public static implicit operator SegaSaturnColor(Color c) => new SegaSaturnColor(c);
        public static implicit operator SegaSaturnColor(int argb32Bits) => new SegaSaturnColor(argb32Bits);
        public static implicit operator SegaSaturnColor(ushort saturnColor) => new SegaSaturnColor(saturnColor);
        public static implicit operator SegaSaturnColor(string saturnHexaString) => new SegaSaturnColor(saturnHexaString);

        public static implicit operator Color(SegaSaturnColor c) => c.DotNetColor;
        public static implicit operator int(SegaSaturnColor c) => c.DotNetColor.ToArgb();
        public static implicit operator ushort(SegaSaturnColor c) => c.SaturnColor;
        public static implicit operator string(SegaSaturnColor c) => c.SaturnHexaString;

        public byte R
        {
            get => this.DotNetColor.R;
            set => this.DotNetColor = Color.FromArgb(this.A, value, this.G, this.B);
        }
        public byte G
        {
            get => this.DotNetColor.G;
            set => this.DotNetColor = Color.FromArgb(this.A, this.R, value, this.B);
        }
        public byte B
        {
            get => this.DotNetColor.B;
            set => this.DotNetColor = Color.FromArgb(this.A, this.R, this.G, value);
        }
        public byte A
        {
            get => this.DotNetColor.A;
            set => this.DotNetColor = Color.FromArgb(value, this.R, this.G, this.B);
        }

        private const float ByteToFloatFactor = 1.0f / 255.0f;

        public float Rf
        {
            get => this.R * SegaSaturnColor.ByteToFloatFactor;
            set => this.R = (byte)(value / SegaSaturnColor.ByteToFloatFactor);
        }
        public float Gf
        {
            get => this.G * SegaSaturnColor.ByteToFloatFactor;
            set => this.G = (byte)(value / SegaSaturnColor.ByteToFloatFactor);
        }
        public float Bf
        {
            get => this.B * SegaSaturnColor.ByteToFloatFactor;
            set => this.B = (byte)(value / SegaSaturnColor.ByteToFloatFactor);
        }
        public float Af
        {
            get => this.A * SegaSaturnColor.ByteToFloatFactor;
            set => this.A = (byte)(value / SegaSaturnColor.ByteToFloatFactor);
        }

        public Color DotNetColor { get; set; }

        public int ToArgb() => this.DotNetColor.ToArgb();

        private const float ColorConvertionFactor = 8.225806f;

        public ushort SaturnColor
        {
            get => this.DotNetColor.A == 0 ? (ushort)0 : (ushort)(0x8000 | ((this.DotNetColor.B / 8) << 10) | ((this.DotNetColor.G / 8) << 5) | (this.DotNetColor.R / 8));
            set
            {
                if (value == 0)
                {
                    this.DotNetColor = Color.Transparent;
                    return;
                }
                int tmp = value & ~0x8000;
                int blue = (int)(((tmp >> 10) & 0X1F) * SegaSaturnColor.ColorConvertionFactor);
                int green = (int)(((tmp >> 5) & 0X1F) * SegaSaturnColor.ColorConvertionFactor);
                int red = (int)(((tmp >> 0) & 0X1F) * SegaSaturnColor.ColorConvertionFactor);
                if (red < 0)
                    red = 0;
                else if (red > 0xFF)
                    red = 0xFF;
                if (green < 0)
                    green = 0;
                else if (green > 0xFF)
                    green = 255;
                if (blue < 0)
                    blue = 0;
                else if (blue > 0xFF)
                    blue = 0xFF;
                this.DotNetColor = Color.FromArgb(red, green, blue);
            }
        }

        public string SaturnHexaString
        {
            get => String.Format("0x{0:x}", this.SaturnColor);
            set => this.SaturnColor = Convert.ToUInt16(value, 16);
        }

        public override string ToString() => this.SaturnHexaString;

        public static SegaSaturnColor White => Color.White;
        public static SegaSaturnColor Black => Color.Black;
        public static SegaSaturnColor DarkGray => Color.DarkGray;
        public static SegaSaturnColor Red => Color.Red;
        public static SegaSaturnColor Green => Color.FromArgb(255, 0, 255, 0);
        public static SegaSaturnColor Blue => Color.Blue;
        public static SegaSaturnColor Magenta => Color.Magenta;
        public static SegaSaturnColor Transparent => Color.Transparent;
    }
}
