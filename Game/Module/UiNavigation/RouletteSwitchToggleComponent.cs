using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D4E RID: 19790
	public class RouletteSwitchToggleComponent : HotKeyComponent
	{
		// Token: 0x06033575 RID: 210293 RVA: 0x00CD82F4 File Offset: 0x00CD64F4
		public RouletteSwitchToggleComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033576 RID: 210294 RVA: 0x00CD82FD File Offset: 0x00CD64FD
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
		}

		// Token: 0x06033577 RID: 210295 RVA: 0x00CD8308 File Offset: 0x00CD6508
		protected override void OnPress(HotKeyMap config)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.RouletteSwitchToggleComponentEmit);
		}
	}
}
