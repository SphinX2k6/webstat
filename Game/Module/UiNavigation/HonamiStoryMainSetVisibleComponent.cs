using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D00 RID: 19712
	public class HonamiStoryMainSetVisibleComponent : HotKeyComponent
	{
		// Token: 0x0603341A RID: 209946 RVA: 0x00CD500C File Offset: 0x00CD320C
		public HonamiStoryMainSetVisibleComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x0603341B RID: 209947 RVA: 0x00CD5015 File Offset: 0x00CD3215
		protected override void OnPress(HotKeyMap config)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnPhotographSetVisible);
		}

		// Token: 0x0603341C RID: 209948 RVA: 0x00CD5027 File Offset: 0x00CD3227
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
		}
	}
}
