using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Movement.Model
{
	// Token: 0x020056F6 RID: 22262
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class AvoidanceModel : ModelBase<AvoidanceModel>
	{
		// Token: 0x17009113 RID: 37139
		// (get) Token: 0x06038A67 RID: 232039 RVA: 0x00E58460 File Offset: 0x00E56660
		public bool[] ZeroTuple32
		{
			get
			{
				if (this.ZeroTuple32Internal == null)
				{
					this.ZeroTuple32Internal = new bool[32];
					for (int i = 0; i < 32; i++)
					{
						this.ZeroTuple32Internal[i] = false;
					}
				}
				return this.ZeroTuple32Internal;
			}
		}

		// Token: 0x06038A68 RID: 232040 RVA: 0x00E584A0 File Offset: 0x00E566A0
		public FNavAvoidanceMask GetSingleBitMask(int bitIndex)
		{
			if (bitIndex < 0 || bitIndex >= 32)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Movement;
				ELogAuthor author = ELogAuthor.XDW;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(36, 1);
				defaultInterpolatedStringHandler.AppendLiteral("[AvoidanceModel.GetSingleBitMask] ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(bitIndex);
				defaultInterpolatedStringHandler.AppendLiteral("非法");
				instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return new FNavAvoidanceMask();
			}
			if (this.ReuseZeroTuple)
			{
				this.ZeroTuple32[bitIndex] = true;
				FNavAvoidanceMask result = new FNavAvoidanceMask(this.ZeroTuple32[0], this.ZeroTuple32[1], this.ZeroTuple32[2], this.ZeroTuple32[3], this.ZeroTuple32[4], this.ZeroTuple32[5], this.ZeroTuple32[6], this.ZeroTuple32[7], this.ZeroTuple32[8], this.ZeroTuple32[9], this.ZeroTuple32[10], this.ZeroTuple32[11], this.ZeroTuple32[12], this.ZeroTuple32[13], this.ZeroTuple32[14], this.ZeroTuple32[15], this.ZeroTuple32[16], this.ZeroTuple32[17], this.ZeroTuple32[18], this.ZeroTuple32[19], this.ZeroTuple32[20], this.ZeroTuple32[21], this.ZeroTuple32[22], this.ZeroTuple32[23], this.ZeroTuple32[24], this.ZeroTuple32[25], this.ZeroTuple32[26], this.ZeroTuple32[27], this.ZeroTuple32[28], this.ZeroTuple32[29], this.ZeroTuple32[30], this.ZeroTuple32[31]);
				this.ZeroTuple32[bitIndex] = false;
				return result;
			}
			if (this.SingleBitMask == null)
			{
				this.SingleBitMask = new bool[32][];
			}
			if (this.SingleBitMask[bitIndex].Length == 0)
			{
				this.SingleBitMask[bitIndex] = new bool[32];
				for (int i = 0; i < 32; i++)
				{
					this.SingleBitMask[bitIndex][i] = false;
				}
				this.SingleBitMask[bitIndex][bitIndex] = true;
			}
			return new FNavAvoidanceMask(this.SingleBitMask[bitIndex][0], this.SingleBitMask[bitIndex][1], this.SingleBitMask[bitIndex][2], this.SingleBitMask[bitIndex][3], this.SingleBitMask[bitIndex][4], this.SingleBitMask[bitIndex][5], this.SingleBitMask[bitIndex][6], this.SingleBitMask[bitIndex][7], this.SingleBitMask[bitIndex][8], this.SingleBitMask[bitIndex][9], this.SingleBitMask[bitIndex][10], this.SingleBitMask[bitIndex][11], this.SingleBitMask[bitIndex][12], this.SingleBitMask[bitIndex][13], this.SingleBitMask[bitIndex][14], this.SingleBitMask[bitIndex][15], this.SingleBitMask[bitIndex][16], this.SingleBitMask[bitIndex][17], this.SingleBitMask[bitIndex][18], this.SingleBitMask[bitIndex][19], this.SingleBitMask[bitIndex][20], this.SingleBitMask[bitIndex][21], this.SingleBitMask[bitIndex][22], this.SingleBitMask[bitIndex][23], this.SingleBitMask[bitIndex][24], this.SingleBitMask[bitIndex][25], this.SingleBitMask[bitIndex][26], this.SingleBitMask[bitIndex][27], this.SingleBitMask[bitIndex][28], this.SingleBitMask[bitIndex][29], this.SingleBitMask[bitIndex][30], this.SingleBitMask[bitIndex][31]);
		}

		// Token: 0x17009114 RID: 37140
		// (get) Token: 0x06038A69 RID: 232041 RVA: 0x00E587EC File Offset: 0x00E569EC
		public FNavAvoidanceMask PlayerAvoidanceGroupMask
		{
			get
			{
				return this.GetSingleBitMask(31);
			}
		}

		// Token: 0x17009115 RID: 37141
		// (get) Token: 0x06038A6A RID: 232042 RVA: 0x00E587F6 File Offset: 0x00E569F6
		public FNavAvoidanceMask SceneItemAvoidanceGroupMask
		{
			get
			{
				return this.GetSingleBitMask(6);
			}
		}

		// Token: 0x17009116 RID: 37142
		// (get) Token: 0x06038A6B RID: 232043 RVA: 0x00E587FF File Offset: 0x00E569FF
		public FNavAvoidanceMask SceneItemGroupsToAvoidMask
		{
			get
			{
				return this.GetSingleBitMask(31);
			}
		}

		// Token: 0x06038A6C RID: 232044 RVA: 0x00E58809 File Offset: 0x00E56A09
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x06038A6D RID: 232045 RVA: 0x00E5880C File Offset: 0x00E56A0C
		protected override bool OnClear()
		{
			return true;
		}

		// Token: 0x040204EB RID: 132331
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private bool[][] SingleBitMask;

		// Token: 0x040204EC RID: 132332
		[Nullable(2)]
		private bool[] ZeroTuple32Internal;

		// Token: 0x040204ED RID: 132333
		private readonly bool ReuseZeroTuple = true;

		// Token: 0x040204EE RID: 132334
		public readonly bool UseRVOAvoidance;

		// Token: 0x040204EF RID: 132335
		public readonly float SceneItemAvoidanceRadius = 200f;
	}
}
