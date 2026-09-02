using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062AE RID: 25262
	public class TetrisCellData
	{
		// Token: 0x0603F941 RID: 260417 RVA: 0x0104BE1B File Offset: 0x0104A01B
		public void Reset()
		{
			this.Type = ECellType.Empty;
			this.SealState = ESealState.None;
			this.GemType = EGemType.None;
			this.ColorId = 0;
		}

		// Token: 0x17009C8D RID: 40077
		// (get) Token: 0x0603F942 RID: 260418 RVA: 0x0104BE39 File Offset: 0x0104A039
		public bool IsOccupied
		{
			get
			{
				return this.Type > ECellType.Empty;
			}
		}

		// Token: 0x17009C8E RID: 40078
		// (get) Token: 0x0603F943 RID: 260419 RVA: 0x0104BE44 File Offset: 0x0104A044
		public bool CanBeCleared
		{
			get
			{
				return this.Type != ECellType.Fixed;
			}
		}

		// Token: 0x0603F944 RID: 260420 RVA: 0x0104BE52 File Offset: 0x0104A052
		[NullableContext(1)]
		public TetrisCellData Clone()
		{
			return new TetrisCellData
			{
				Type = this.Type,
				SealState = this.SealState,
				GemType = this.GemType,
				ColorId = this.ColorId
			};
		}

		// Token: 0x04023AF8 RID: 146168
		public ECellType Type;

		// Token: 0x04023AF9 RID: 146169
		public ESealState SealState;

		// Token: 0x04023AFA RID: 146170
		public EGemType GemType;

		// Token: 0x04023AFB RID: 146171
		public int ColorId;
	}
}
