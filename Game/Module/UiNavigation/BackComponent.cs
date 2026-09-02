using System;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CE3 RID: 19683
	public class BackComponent : HotKeyComponent
	{
		// Token: 0x060333AF RID: 209839 RVA: 0x00CD40BE File Offset: 0x00CD22BE
		public BackComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060333B0 RID: 209840 RVA: 0x00CD40C7 File Offset: 0x00CD22C7
		protected override void OnPress(HotKeyMap config)
		{
			ControllerBase<UiNavigationNewController>.Instance.HotKeyCloseView();
		}
	}
}
