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

namespace SegaSaturn.NET
{
    public class SegaSaturnNormal
    {
        public SegaSaturnNormal()
        {
        }

        public SegaSaturnNormal(float x, float y, float z)
        {
            this.FloatX = x;
            this.FloatY = y;
            this.FloatZ = z;
        }

        public SegaSaturnNormal(int fixedX, int fixedY, int fixedZ)
        {
            this.FixedX = fixedX;
            this.FixedY = fixedY;
            this.FixedZ = fixedZ;
        }

        public float FloatX { get; set; }
        public float FloatY { get; set; }
        public float FloatZ { get; set; }

        public int FixedX
        {
            get => (int)(this.FloatX * 65536.0f);
            set => this.FloatX = value / 65536.0f;
        }

        public int FixedY
        {
            get => (int)(this.FloatY * 65536.0f);
            set => this.FloatY = value / 65536.0f;
        }

        public int FixedZ
        {
            get => (int)(this.FloatZ * 65536.0f);
            set => this.FloatZ = value / 65536.0f;
        }

        public override string ToString() => $"{this.FloatX};{this.FloatY};{this.FloatZ}";

        public string HashKey => $"{this.FixedX};{this.FixedY};{this.FixedZ}";
    }
}
