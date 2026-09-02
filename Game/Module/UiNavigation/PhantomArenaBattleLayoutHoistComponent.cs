using System;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D3C RID: 19772
	public class PhantomArenaBattleLayoutHoistComponent : PhantomArenaBattleComponentBase
	{
		// Token: 0x0603353B RID: 210235 RVA: 0x00CD7C72 File Offset: 0x00CD5E72
		public PhantomArenaBattleLayoutHoistComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x0603353C RID: 210236 RVA: 0x00CD7C7B File Offset: 0x00CD5E7B
		protected override void OnPress(HotKeyMap _)
		{
			if (base.Proxy != null)
			{
				base.Proxy.GamepadLogic.SwitchCardLayoutHoist();
				ModelBase<UiNavigationModel>.Instance.RepeatMove();
			}
		}

		// Token: 0x0603353D RID: 210237 RVA: 0x00CD7C9F File Offset: 0x00CD5E9F
		protected override void OnRefreshSelfHotKeyStateIsMainInVisible()
		{
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
		}
	}
}
