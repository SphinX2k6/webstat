using System;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Cook
{
	// Token: 0x02005DFE RID: 24062
	public class CookRewardPopData : UiPopViewData
	{
		// Token: 0x0603C8D0 RID: 248016 RVA: 0x00F621B0 File Offset: 0x00F603B0
		public CookRewardPopData()
		{
			this.CookRewardPopType = ECookPopType.Unlock;
		}

		// Token: 0x040220B3 RID: 139443
		public ECookPopType CookRewardPopType;
	}
}
