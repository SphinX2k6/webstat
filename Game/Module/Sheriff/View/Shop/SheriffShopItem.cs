using System;

namespace CSharpScript.Game.Module.Sheriff.View.Shop
{
	// Token: 0x02004FD9 RID: 20441
	public class SheriffShopItem : PayShopItem
	{
		// Token: 0x06034B4B RID: 215883 RVA: 0x00D37F0A File Offset: 0x00D3610A
		protected override void OnStart()
		{
			base.OnStart();
			base.SetRedDotState(false);
		}
	}
}
