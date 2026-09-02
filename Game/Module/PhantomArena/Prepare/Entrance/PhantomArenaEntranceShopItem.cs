using System;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054CA RID: 21706
	public class PhantomArenaEntranceShopItem : PayShopItem
	{
		// Token: 0x060374B2 RID: 226482 RVA: 0x00E07402 File Offset: 0x00E05602
		protected override void OnStart()
		{
			base.OnStart();
			base.SetRedDotState(false);
			base.SetResellShowState(true);
		}
	}
}
