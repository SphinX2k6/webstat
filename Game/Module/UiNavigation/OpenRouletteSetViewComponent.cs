using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D36 RID: 19766
	public class OpenRouletteSetViewComponent : HotKeyComponent
	{
		// Token: 0x0603351C RID: 210204 RVA: 0x00CD755D File Offset: 0x00CD575D
		public OpenRouletteSetViewComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x0603351D RID: 210205 RVA: 0x00CD7566 File Offset: 0x00CD5766
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
		}

		// Token: 0x0603351E RID: 210206 RVA: 0x00CD7571 File Offset: 0x00CD5771
		protected override void OnPress(HotKeyMap config)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OpenRouletteSetView);
		}
	}
}
