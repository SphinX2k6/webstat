using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.LevelGamePlay.Guarantee;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A4D RID: 27213
	public class GuaranteeContext : GeneralContext
	{
		// Token: 0x0604350C RID: 275724 RVA: 0x0114DA9A File Offset: 0x0114BC9A
		public GuaranteeContext()
		{
			this.Type = new EGeneralContextType?(EGeneralContextType.Guarantee);
		}

		// Token: 0x0604350D RID: 275725 RVA: 0x0114DAAE File Offset: 0x0114BCAE
		[NullableContext(1)]
		public static GuaranteeContext Create(GameCtxType? subType = null, EGuaranteeReason guaranteeReason = EGuaranteeReason.Unknown)
		{
			GuaranteeContext guaranteeContext = GeneralContext.GetObj(EGeneralContextType.Guarantee, subType, () => new GuaranteeContext()) as GuaranteeContext;
			guaranteeContext.GuaranteeReason = guaranteeReason;
			return guaranteeContext;
		}

		// Token: 0x0402589D RID: 153757
		public EGuaranteeReason GuaranteeReason;
	}
}
