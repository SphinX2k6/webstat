using System;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D1F RID: 19743
	public class MapCheckComponent : MapInteractComponentBase
	{
		// Token: 0x060334D2 RID: 210130 RVA: 0x00CD6CC1 File Offset: 0x00CD4EC1
		public MapCheckComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060334D3 RID: 210131 RVA: 0x00CD6CCA File Offset: 0x00CD4ECA
		protected override void OnPress(HotKeyMap config)
		{
			ControllerBase<UiNavigationNewController>.Instance.ClickButton(config.BindButtonTag);
		}
	}
}
