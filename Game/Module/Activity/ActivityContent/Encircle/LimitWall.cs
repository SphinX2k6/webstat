using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Encircle
{
	// Token: 0x0200686A RID: 26730
	[NullableContext(2)]
	[Nullable(0)]
	public class LimitWall
	{
		// Token: 0x060429C9 RID: 272841 RVA: 0x01118733 File Offset: 0x01116933
		[NullableContext(1)]
		public LimitWall(IHexPos pos, int limitRound)
		{
			this.PosInternal = pos;
			this.LimitRoundInternal = limitRound;
		}

		// Token: 0x1700A1B1 RID: 41393
		// (get) Token: 0x060429CA RID: 272842 RVA: 0x01118749 File Offset: 0x01116949
		// (set) Token: 0x060429CB RID: 272843 RVA: 0x01118751 File Offset: 0x01116951
		public IHexPos Pos
		{
			get
			{
				return this.PosInternal;
			}
			set
			{
				this.PosInternal = value;
			}
		}

		// Token: 0x1700A1B2 RID: 41394
		// (get) Token: 0x060429CC RID: 272844 RVA: 0x0111875A File Offset: 0x0111695A
		// (set) Token: 0x060429CD RID: 272845 RVA: 0x01118762 File Offset: 0x01116962
		public int LimitRound
		{
			get
			{
				return this.LimitRoundInternal;
			}
			set
			{
				this.LimitRoundInternal = value;
			}
		}

		// Token: 0x04025128 RID: 151848
		private IHexPos PosInternal;

		// Token: 0x04025129 RID: 151849
		private int LimitRoundInternal;
	}
}
