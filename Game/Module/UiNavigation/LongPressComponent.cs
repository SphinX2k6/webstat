using System;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D15 RID: 19733
	public class LongPressComponent : HotKeyComponent
	{
		// Token: 0x060334A2 RID: 210082 RVA: 0x00CD6597 File Offset: 0x00CD4797
		public LongPressComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060334A3 RID: 210083 RVA: 0x00CD65A0 File Offset: 0x00CD47A0
		protected override void OnRelease(HotKeyMap config)
		{
			ControllerBase<UiNavigationNewController>.Instance.SimulationPointUp(config.BindButtonTag, config.Id, null);
		}

		// Token: 0x060334A4 RID: 210084 RVA: 0x00CD65BB File Offset: 0x00CD47BB
		protected override void OnPress(HotKeyMap config)
		{
			ControllerBase<UiNavigationNewController>.Instance.SimulationPointDown(config.BindButtonTag, config.Id, null);
		}
	}
}
