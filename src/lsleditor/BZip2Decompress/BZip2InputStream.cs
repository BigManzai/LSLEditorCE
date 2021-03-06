// <copyright file="gpl-2.0.txt">
// ORIGINAL CODE BASE IS Copyright (C) 2006-2010 by Alphons van der Heijden.
// The code was donated on 2010-04-28 by Alphons van der Heijden to Brandon 'Dimentox Travanti' Husbands &
// Malcolm J. Kudra, who in turn License under the GPLv2 in agreement with Alphons van der Heijden's wishes.
//
// The community would like to thank Alphons for all of his hard work, blood sweat and tears. Without his work
// the community would be stuck with crappy editors.
//
// The source code in this file ("Source Code") is provided by The LSLEditor Group to you under the terms of the GNU
// General Public License, version 2.0 ("GPL"), unless you have obtained a separate licensing agreement ("Other
// License"), formally executed by you and The LSLEditor Group.
// Terms of the GPL can be found in the gplv2.txt document.
//
// GPLv2 Header
// ************
// LSLEditor, a External editor for the LSL Language.
// Copyright (C) 2010 The LSLEditor Group.
//
// This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public
// License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any
// later version.
//
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more
// details.
//
// You should have received a copy of the GNU General Public License along with this program; if not, write to the Free
// Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// ********************************************************************************************************************
// The above copyright notice and this permission notice shall be included in copies or substantial portions of the
// Software.
// ********************************************************************************************************************
// </copyright>
//
// <summary>
//
//
// </summary>

using System;
using System.IO;

namespace LSLEditor.Decompressor
{
	/// <summary>
	/// An input stream that decompresses files in the BZip2 format
	/// </summary>
	public class BZip2InputStream : Stream
	{
		#region Constants

		private const int START_BLOCK_STATE = 1;
		private const int RAND_PART_A_STATE = 2;
		private const int RAND_PART_B_STATE = 3;
		private const int RAND_PART_C_STATE = 4;
		private const int NO_RAND_PART_A_STATE = 5;
		private const int NO_RAND_PART_B_STATE = 6;
		private const int NO_RAND_PART_C_STATE = 7;

		#endregion Constants

		#region Constructors

		/// <summary>
		/// Construct instance for reading from stream
		/// </summary>
		/// <param name="stream">Data source</param>
		public BZip2InputStream(Stream stream)
        {
            // init arrays
            for (int i = 0; i < BZip2Constants.N_GROUPS; ++i) {
                limit[i] = new int[BZip2Constants.MAX_ALPHA_SIZE];
                baseArray[i] = new int[BZip2Constants.MAX_ALPHA_SIZE];
                perm[i] = new int[BZip2Constants.MAX_ALPHA_SIZE];
            }

            BsSetStream(stream);
            Initialize();
            InitBlock();
            SetupBlock();
        }

        #endregion Constructors

        /// <summary>
        /// Get/set flag indicating ownership of underlying stream.
        /// When the flag is true <see cref="Close"></see> will close the underlying stream also.
        /// </summary>
        public bool IsStreamOwner {
            get { return isStreamOwner; }
            set { isStreamOwner = value; }
        }

        #region Stream Overrides

        /// <summary>
        /// Gets a value indicating if the stream supports reading
        /// </summary>
        public override bool CanRead {
            get {
                return baseStream.CanRead;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the current stream supports seeking.
        /// </summary>
        public override bool CanSeek {
            get {
                return baseStream.CanSeek;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the current stream supports writing.
        /// This property always returns false
        /// </summary>
        public override bool CanWrite {
            get {
                return false;
            }
        }

        /// <summary>
        /// Gets the length in bytes of the stream.
        /// </summary>
        public override long Length {
            get {
                return baseStream.Length;
            }
        }

        /// <summary>
        /// Gets or sets the streams position.
        /// Setting the position is not supported and will throw a NotSupportException
        /// </summary>
        /// <exception cref="NotSupportedException">Any attempt to set the position</exception>
        public override long Position {
            get {
                return baseStream.Position;
            }
            set {
                throw new NotSupportedException("BZip2InputStream position cannot be set");
            }
        }

        /// <summary>
        /// Flushes the stream.
        /// </summary>
        public override void Flush()
        {
            if (baseStream != null) {
                baseStream.Flush();
            }
        }

        /// <summary>
        /// Set the streams position.  This operation is not supported and will throw a NotSupportedException
        /// </summary>
        /// <exception cref="NotSupportedException">Any access</exception>
        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException("BZip2InputStream Seek not supported");
        }

        /// <summary>
        /// Sets the length of this stream to the given value.
        /// This operation is not supported and will throw a NotSupportedExceptionortedException
        /// </summary>
        /// <exception cref="NotSupportedException">Any access</exception>
        public override void SetLength(long value)
        {
            throw new NotSupportedException("BZip2InputStream SetLength not supported");
        }

        /// <summary>
        /// Writes a block of bytes to this stream using data from a buffer.
        /// This operation is not supported and will throw a NotSupportedException
        /// </summary>
        /// <exception cref="NotSupportedException">Any access</exception>
        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException("BZip2InputStream Write not supported");
        }

        /// <summary>
        /// Writes a byte to the current position in the file stream.
        /// This operation is not supported and will throw a NotSupportedException
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <exception cref="NotSupportedException">Any access</exception>
        public override void WriteByte(byte value)
        {
            throw new NotSupportedException("BZip2InputStream WriteByte not supported");
        }

        /// <summary>
        /// Read a sequence of bytes and advances the read position by one byte.
        /// </summary>
        /// <param name="buffer">Array of bytes to store values in</param>
        /// <param name="offset">Offset in array to begin storing data</param>
        /// <param name="count">The maximum number of bytes to read</param>
        /// <returns>The total number of bytes read into the buffer. This might be less
        /// than the number of bytes requested if that number of bytes are not
        /// currently available or zero if the end of the stream is reached.
        /// </returns>
        public override int Read(byte[] buffer, int offset, int count)
        {
            if (buffer == null) {
                throw new ArgumentNullException("buffer");
            }

            for (int i = 0; i < count; ++i) {
                int rb = ReadByte();
                if (rb == -1) {
                    return i;
                }
                buffer[offset + i] = (byte)rb;
            }
            return count;
        }

        /// <summary>
        /// Closes the stream, releasing any associated resources.
        /// </summary>
        public override void Close()
        {
            if (IsStreamOwner && (baseStream != null)) {
                baseStream.Close();
            }
        }

        /// <summary>
        /// Read a byte from stream advancing position
        /// </summary>
        /// <returns>byte read or -1 on end of stream</returns>
        public override int ReadByte()
        {
            if (streamEnd) {
                return -1; // ok
            }

            int retChar = currentChar;
            switch (currentState) {
                case RAND_PART_B_STATE:
                    SetupRandPartB();
                    break;

                case RAND_PART_C_STATE:
                    SetupRandPartC();
                    break;

                case NO_RAND_PART_B_STATE:
                    SetupNoRandPartB();
                    break;

                case NO_RAND_PART_C_STATE:
                    SetupNoRandPartC();
                    break;

                case START_BLOCK_STATE:
                case NO_RAND_PART_A_STATE:
                case RAND_PART_A_STATE:
                    break;

                default:
                    break;
            }
            return retChar;
        }

		#endregion Stream Overrides

		private void MakeMaps()
		{
			nInUse = 0;
			for (int i = 0; i < 256; ++i) {
				if (inUse[i]) {
					seqToUnseq[nInUse] = (byte)i;
					unseqToSeq[i] = (byte)nInUse;
					nInUse++;
				}
			}
		}

		private void Initialize()
		{
			char magic1 = BsGetUChar();
			char magic2 = BsGetUChar();

			char magic3 = BsGetUChar();
			char magic4 = BsGetUChar();

			if (magic1 != 'B' || magic2 != 'Z' || magic3 != 'h' || magic4 < '1' || magic4 > '9') {
				streamEnd = true;
				return;
			}

			SetDecompressStructureSizes(magic4 - '0');
			computedCombinedCRC = 0;
		}

		private void InitBlock()
		{
			char magic1 = BsGetUChar();
			char magic2 = BsGetUChar();
			char magic3 = BsGetUChar();
			char magic4 = BsGetUChar();
			char magic5 = BsGetUChar();
			char magic6 = BsGetUChar();

			if (magic1 == 0x17 && magic2 == 0x72 && magic3 == 0x45 && magic4 == 0x38 && magic5 == 0x50 && magic6 == 0x90) {
				Complete();
				return;
			}

			if (magic1 != 0x31 || magic2 != 0x41 || magic3 != 0x59 || magic4 != 0x26 || magic5 != 0x53 || magic6 != 0x59) {
				BadBlockHeader();
				streamEnd = true;
				return;
			}

			storedBlockCRC = BsGetInt32();

			blockRandomised = (BsR(1) == 1);

			GetAndMoveToFrontDecode();

			mCrc.Reset();
			currentState = START_BLOCK_STATE;
		}

		private void EndBlock()
		{
			computedBlockCRC = (int)mCrc.Value;

			// -- A bad CRC is considered a fatal error. --
			if (storedBlockCRC != computedBlockCRC) {
				CrcError();
			}

			// 1528150659
			computedCombinedCRC = ((computedCombinedCRC << 1) & 0xFFFFFFFF) | (computedCombinedCRC >> 31);
			computedCombinedCRC = computedCombinedCRC ^ (uint)computedBlockCRC;
		}

		private void Complete()
		{
			storedCombinedCRC = BsGetInt32();
			if (storedCombinedCRC != (int)computedCombinedCRC) {
				CrcError();
			}

			streamEnd = true;
		}

		private void BsSetStream(Stream stream)
		{
			baseStream = stream;
			bsLive = 0;
			bsBuff = 0;
		}

		private void FillBuffer()
		{
			int thech = 0;

			try {
				thech = baseStream.ReadByte();
			} catch (Exception) {
				CompressedStreamEOF();
			}

			if (thech == -1) {
				CompressedStreamEOF();
			}

			bsBuff = (bsBuff << 8) | (thech & 0xFF);
			bsLive += 8;
		}

		private int BsR(int n)
		{
			while (bsLive < n) {
				FillBuffer();
			}

			int v = (bsBuff >> (bsLive - n)) & ((1 << n) - 1);
			bsLive -= n;
			return v;
		}

		private char BsGetUChar()
		{
			return (char)BsR(8);
		}

		private int BsGetint()
		{
			int u = BsR(8);
			u = (u << 8) | BsR(8);
			u = (u << 8) | BsR(8);
			u = (u << 8) | BsR(8);
			return u;
		}

		private int BsGetIntVS(int numBits)
		{
			return BsR(numBits);
		}

		private int BsGetInt32()
		{
			return BsGetint();
		}

		private void RecvDecodingTables()
		{
			char[][] len = new char[BZip2Constants.N_GROUPS][];
			for (int i = 0; i < BZip2Constants.N_GROUPS; ++i) {
				len[i] = new char[BZip2Constants.MAX_ALPHA_SIZE];
			}

			bool[] inUse16 = new bool[16];

			//--- Receive the mapping table ---
			for (int i = 0; i < 16; i++) {
				inUse16[i] = (BsR(1) == 1);
			}

			for (int i = 0; i < 16; i++) {
				if (inUse16[i]) {
					for (int j = 0; j < 16; j++) {
						inUse[i * 16 + j] = (BsR(1) == 1);
					}
				} else {
					for (int j = 0; j < 16; j++) {
						inUse[i * 16 + j] = false;
					}
				}
			}

			MakeMaps();
			int alphaSize = nInUse + 2;

			//--- Now the selectors ---
			int nGroups = BsR(3);
			int nSelectors = BsR(15);

			for (int i = 0; i < nSelectors; i++) {
				int j = 0;
				while (BsR(1) == 1) {
					j++;
				}
				selectorMtf[i] = (byte)j;
			}

			//--- Undo the MTF values for the selectors. ---
			byte[] pos = new byte[BZip2Constants.N_GROUPS];
			for (int v = 0; v < nGroups; v++) {
				pos[v] = (byte)v;
			}

			for (int i = 0; i < nSelectors; i++) {
				int v = selectorMtf[i];
				byte tmp = pos[v];
				while (v > 0) {
					pos[v] = pos[v - 1];
					v--;
				}
				pos[0] = tmp;
				selector[i] = tmp;
			}

			//--- Now the coding tables ---
			for (int t = 0; t < nGroups; t++) {
				int curr = BsR(5);
				for (int i = 0; i < alphaSize; i++) {
					while (BsR(1) == 1) {
						if (BsR(1) == 0) {
							curr++;
						} else {
							curr--;
						}
					}
					len[t][i] = (char)curr;
				}
			}

			//--- Create the Huffman decoding tables ---
			for (int t = 0; t < nGroups; t++) {
				int minLen = 32;
				int maxLen = 0;
				for (int i = 0; i < alphaSize; i++) {
					maxLen = Math.Max(maxLen, len[t][i]);
					minLen = Math.Min(minLen, len[t][i]);
				}
				HbCreateDecodeTables(limit[t], baseArray[t], perm[t], len[t], minLen, maxLen, alphaSize);
				minLens[t] = minLen;
			}
		}

		private void GetAndMoveToFrontDecode()
		{
			byte[] yy = new byte[256];
			int nextSym;

			int limitLast = BZip2Constants.baseBlockSize * blockSize100k;
			origPtr = BsGetIntVS(24);

			RecvDecodingTables();
			int EOB = nInUse + 1;
			int groupNo = -1;
			int groupPos = 0;

			/*--
			Setting up the unzftab entries here is not strictly
			necessary, but it does save having to do it later
			in a separate pass, and so saves a block's worth of
			cache misses.
			--*/
			for (int i = 0; i <= 255; i++) {
				unzftab[i] = 0;
			}

			for (int i = 0; i <= 255; i++) {
				yy[i] = (byte)i;
			}

			last = -1;

			if (groupPos == 0) {
				groupNo++;
				groupPos = BZip2Constants.G_SIZE;
			}

			groupPos--;
			int zt = selector[groupNo];
			int zn = minLens[zt];
			int zvec = BsR(zn);
			int zj;

			while (zvec > limit[zt][zn]) {
				if (zn > 20) { // the longest code
					throw new Exception("Bzip data error");
				}
				zn++;
				while (bsLive < 1) {
					FillBuffer();
				}
				zj = (bsBuff >> (bsLive - 1)) & 1;
				bsLive--;
				zvec = (zvec << 1) | zj;
			}
			if (zvec - baseArray[zt][zn] < 0 || zvec - baseArray[zt][zn] >= BZip2Constants.MAX_ALPHA_SIZE) {
				throw new Exception("Bzip data error");
			}
			nextSym = perm[zt][zvec - baseArray[zt][zn]];

			while (true) {
				if (nextSym == EOB) {
					break;
				}

				if (nextSym == BZip2Constants.RUNA || nextSym == BZip2Constants.RUNB) {
					int s = -1;
					int n = 1;
					do {
						if (nextSym == BZip2Constants.RUNA) {
							s += (0 + 1) * n;
						} else if (nextSym == BZip2Constants.RUNB) {
							s += (1 + 1) * n;
						}

						n <<= 1;

						if (groupPos == 0) {
							groupNo++;
							groupPos = BZip2Constants.G_SIZE;
						}

						groupPos--;

						zt = selector[groupNo];
						zn = minLens[zt];
						zvec = BsR(zn);

						while (zvec > limit[zt][zn]) {
							zn++;
							while (bsLive < 1) {
								FillBuffer();
							}
							zj = (bsBuff >> (bsLive - 1)) & 1;
							bsLive--;
							zvec = (zvec << 1) | zj;
						}
						nextSym = perm[zt][zvec - baseArray[zt][zn]];
					} while (nextSym == BZip2Constants.RUNA || nextSym == BZip2Constants.RUNB);

					s++;
					byte ch = seqToUnseq[yy[0]];
					unzftab[ch] += s;

					while (s > 0) {
						last++;
						ll8[last] = ch;
						s--;
					}

					if (last >= limitLast) {
						BlockOverrun();
					}
					continue;
				} else {
					last++;
					if (last >= limitLast) {
						BlockOverrun();
					}

					byte tmp = yy[nextSym - 1];
					unzftab[seqToUnseq[tmp]]++;
					ll8[last] = seqToUnseq[tmp];

					for (int j = nextSym - 1; j > 0; --j) {
						yy[j] = yy[j - 1];
					}
					yy[0] = tmp;

					if (groupPos == 0) {
						groupNo++;
						groupPos = BZip2Constants.G_SIZE;
					}

					groupPos--;
					zt = selector[groupNo];
					zn = minLens[zt];
					zvec = BsR(zn);
					while (zvec > limit[zt][zn]) {
						zn++;
						while (bsLive < 1) {
							FillBuffer();
						}
						zj = (bsBuff >> (bsLive - 1)) & 1;
						bsLive--;
						zvec = (zvec << 1) | zj;
					}
					nextSym = perm[zt][zvec - baseArray[zt][zn]];
					continue;
				}
			}
		}

		private void SetupBlock()
		{
			int[] cftab = new int[257];

			cftab[0] = 0;
			Array.Copy(unzftab, 0, cftab, 1, 256);

			for (int i = 1; i <= 256; i++) {
				cftab[i] += cftab[i - 1];
			}

			for (int i = 0; i <= last; i++) {
				byte ch = ll8[i];
				tt[cftab[ch]] = i;
				cftab[ch]++;
			}

			cftab = null;

			tPos = tt[origPtr];

			count = 0;
			i2 = 0;
			ch2 = 256;   /*-- not a char and not EOF --*/

			if (blockRandomised) {
				rNToGo = 0;
				rTPos = 0;
				SetupRandPartA();
			} else {
				SetupNoRandPartA();
			}
		}

		private void SetupRandPartA()
		{
			if (i2 <= last) {
				chPrev = ch2;
				ch2 = ll8[tPos];
				tPos = tt[tPos];
				if (rNToGo == 0) {
					rNToGo = BZip2Constants.rNums[rTPos];
					rTPos++;
					if (rTPos == 512) {
						rTPos = 0;
					}
				}
				rNToGo--;
				ch2 ^= (int)((rNToGo == 1) ? 1 : 0);
				i2++;

				currentChar = ch2;
				currentState = RAND_PART_B_STATE;
				mCrc.Update(ch2);
			} else {
				EndBlock();
				InitBlock();
				SetupBlock();
			}
		}

		private void SetupNoRandPartA()
		{
			if (i2 <= last) {
				chPrev = ch2;
				ch2 = ll8[tPos];
				tPos = tt[tPos];
				i2++;

				currentChar = ch2;
				currentState = NO_RAND_PART_B_STATE;
				mCrc.Update(ch2);
			} else {
				EndBlock();
				InitBlock();
				SetupBlock();
			}
		}

		private void SetupRandPartB()
		{
			if (ch2 != chPrev) {
				currentState = RAND_PART_A_STATE;
				count = 1;
				SetupRandPartA();
			} else {
				count++;
				if (count >= 4) {
					z = ll8[tPos];
					tPos = tt[tPos];
					if (rNToGo == 0) {
						rNToGo = BZip2Constants.rNums[rTPos];
						rTPos++;
						if (rTPos == 512) {
							rTPos = 0;
						}
					}
					rNToGo--;
					z ^= (byte)((rNToGo == 1) ? 1 : 0);
					j2 = 0;
					currentState = RAND_PART_C_STATE;
					SetupRandPartC();
				} else {
					currentState = RAND_PART_A_STATE;
					SetupRandPartA();
				}
			}
		}

		private void SetupRandPartC()
		{
			if (j2 < (int)z) {
				currentChar = ch2;
				mCrc.Update(ch2);
				j2++;
			} else {
				currentState = RAND_PART_A_STATE;
				i2++;
				count = 0;
				SetupRandPartA();
			}
		}

		private void SetupNoRandPartB()
		{
			if (ch2 != chPrev) {
				currentState = NO_RAND_PART_A_STATE;
				count = 1;
				SetupNoRandPartA();
			} else {
				count++;
				if (count >= 4) {
					z = ll8[tPos];
					tPos = tt[tPos];
					currentState = NO_RAND_PART_C_STATE;
					j2 = 0;
					SetupNoRandPartC();
				} else {
					currentState = NO_RAND_PART_A_STATE;
					SetupNoRandPartA();
				}
			}
		}

		private void SetupNoRandPartC()
		{
			if (j2 < (int)z) {
				currentChar = ch2;
				mCrc.Update(ch2);
				j2++;
			} else {
				currentState = NO_RAND_PART_A_STATE;
				i2++;
				count = 0;
				SetupNoRandPartA();
			}
		}

		private void SetDecompressStructureSizes(int newSize100k)
		{
			if (!(0 <= newSize100k && newSize100k <= 9 && 0 <= blockSize100k && blockSize100k <= 9)) {
				throw new Exception("Invalid block size");
			}

			blockSize100k = newSize100k;

			if (newSize100k == 0) {
				return;
			}

			int n = BZip2Constants.baseBlockSize * newSize100k;
			ll8 = new byte[n];
			tt = new int[n];
		}

		private static void CompressedStreamEOF()
		{
			throw new Exception("BZip2 input stream end of compressed stream");
		}

		private static void BlockOverrun()
		{
			throw new Exception("BZip2 input stream block overrun");
		}

		private static void BadBlockHeader()
		{
			throw new Exception("BZip2 input stream bad block header");
		}

		private static void CrcError()
		{
			throw new Exception("BZip2 input stream crc error");
		}

		private static void HbCreateDecodeTables(int[] limit, int[] baseArray, int[] perm, char[] length, int minLen, int maxLen, int alphaSize)
		{
			int pp = 0;

			for (int i = minLen; i <= maxLen; ++i) {
				for (int j = 0; j < alphaSize; ++j) {
					if (length[j] == i) {
						perm[pp] = j;
						++pp;
					}
				}
			}

			for (int i = 0; i < BZip2Constants.MAX_CODE_LEN; i++) {
				baseArray[i] = 0;
			}

			for (int i = 0; i < alphaSize; i++) {
				++baseArray[length[i] + 1];
			}

			for (int i = 1; i < BZip2Constants.MAX_CODE_LEN; i++) {
				baseArray[i] += baseArray[i - 1];
			}

			for (int i = 0; i < BZip2Constants.MAX_CODE_LEN; i++) {
				limit[i] = 0;
			}

			int vec = 0;

			for (int i = minLen; i <= maxLen; i++) {
				vec += (baseArray[i + 1] - baseArray[i]);
				limit[i] = vec - 1;
				vec <<= 1;
			}

			for (int i = minLen + 1; i <= maxLen; i++) {
				baseArray[i] = ((limit[i - 1] + 1) << 1) - baseArray[i];
			}
		}

		#region Instance Fields

		/*--
		index of the last char in the block, so
		the block size == last + 1.
		--*/
		private int last;

		/*--
		index in zptr[] of original string after sorting.
		--*/
		private int origPtr;

		/*--
		always: in the range 0 .. 9.
		The current block size is 100000 * this number.
		--*/
		private int blockSize100k;

		private bool blockRandomised;

		private int bsBuff;
		private int bsLive;
		private IChecksum mCrc = new StrangeCRC();

		private bool[] inUse = new bool[256];
		private int nInUse;

		private byte[] seqToUnseq = new byte[256];
		private byte[] unseqToSeq = new byte[256];

		private byte[] selector = new byte[BZip2Constants.MAX_SELECTORS];
		private byte[] selectorMtf = new byte[BZip2Constants.MAX_SELECTORS];

		private int[] tt;
		private byte[] ll8;

		/*--
		freq table collected to save a pass over the data
		during decompression.
		--*/
		private int[] unzftab = new int[256];

		private int[][] limit = new int[BZip2Constants.N_GROUPS][];
		private int[][] baseArray = new int[BZip2Constants.N_GROUPS][];
		private int[][] perm = new int[BZip2Constants.N_GROUPS][];
		private int[] minLens = new int[BZip2Constants.N_GROUPS];

		private Stream baseStream;
		private bool streamEnd;

		private int currentChar = -1;

		private int currentState = START_BLOCK_STATE;

		private int storedBlockCRC, storedCombinedCRC;
		private int computedBlockCRC;
		private uint computedCombinedCRC;

		private int count, chPrev, ch2;
		private int tPos;
		private int rNToGo;
		private int rTPos;
		private int i2, j2;
		private byte z;
		private bool isStreamOwner = true;

		#endregion Instance Fields
	}
}
