using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x02005661 RID: 22113
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueTokenViewData
	{
		// Token: 0x060385EC RID: 230892 RVA: 0x00E45B7F File Offset: 0x00E43D7F
		public RogueTokenViewData(IIllustratedTokenDataInfo tokenViewInfo)
		{
			this.TokenViewInfo = tokenViewInfo;
		}

		// Token: 0x060385ED RID: 230893 RVA: 0x00E45B8E File Offset: 0x00E43D8E
		public void SetTokenViewInfo(IIllustratedTokenDataInfo tokenViewInfo)
		{
			this.TokenViewInfo = tokenViewInfo;
		}

		// Token: 0x060385EE RID: 230894 RVA: 0x00E45B97 File Offset: 0x00E43D97
		public IIllustratedTokenDataInfo GetTokenViewInfo()
		{
			return this.TokenViewInfo;
		}

		// Token: 0x060385EF RID: 230895 RVA: 0x00E45B9F File Offset: 0x00E43D9F
		public int GetConfigId()
		{
			return this.TokenViewInfo.ConfigId;
		}

		// Token: 0x060385F0 RID: 230896 RVA: 0x00E45BAC File Offset: 0x00E43DAC
		public int GetCollectionIndex()
		{
			return this.TokenViewInfo.CollectionIndex;
		}

		// Token: 0x060385F1 RID: 230897 RVA: 0x00E45BB9 File Offset: 0x00E43DB9
		public void SetSelectOn(bool isSelectOn)
		{
			this.TokenViewInfo.IsSelectOn = isSelectOn;
		}

		// Token: 0x04020255 RID: 131669
		private IIllustratedTokenDataInfo TokenViewInfo;
	}
}
