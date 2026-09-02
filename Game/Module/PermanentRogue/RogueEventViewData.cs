using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x02005662 RID: 22114
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueEventViewData
	{
		// Token: 0x060385F2 RID: 230898 RVA: 0x00E45BC7 File Offset: 0x00E43DC7
		public RogueEventViewData(IIllustratedTokenDataInfo tokenViewInfo)
		{
			this.TokenViewInfo = tokenViewInfo;
		}

		// Token: 0x060385F3 RID: 230899 RVA: 0x00E45BD6 File Offset: 0x00E43DD6
		public void SetTokenViewInfo(IIllustratedTokenDataInfo tokenViewInfo)
		{
			this.TokenViewInfo = tokenViewInfo;
		}

		// Token: 0x060385F4 RID: 230900 RVA: 0x00E45BDF File Offset: 0x00E43DDF
		public IIllustratedTokenDataInfo GetTokenViewInfo()
		{
			return this.TokenViewInfo;
		}

		// Token: 0x060385F5 RID: 230901 RVA: 0x00E45BE7 File Offset: 0x00E43DE7
		public void SetIsLock(bool bIsLock)
		{
			this.TokenViewInfo.IsLock = bIsLock;
		}

		// Token: 0x060385F6 RID: 230902 RVA: 0x00E45BF5 File Offset: 0x00E43DF5
		public int GetConfigId()
		{
			return this.TokenViewInfo.ConfigId;
		}

		// Token: 0x060385F7 RID: 230903 RVA: 0x00E45C02 File Offset: 0x00E43E02
		public void SetSelectOn(bool isSelectOn)
		{
			this.TokenViewInfo.IsSelectOn = isSelectOn;
		}

		// Token: 0x060385F8 RID: 230904 RVA: 0x00E45C10 File Offset: 0x00E43E10
		public bool GetSelectOn()
		{
			return this.TokenViewInfo.IsSelectOn;
		}

		// Token: 0x04020256 RID: 131670
		private IIllustratedTokenDataInfo TokenViewInfo;
	}
}
