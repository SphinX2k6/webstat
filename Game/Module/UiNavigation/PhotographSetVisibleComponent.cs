using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D40 RID: 19776
	public class PhotographSetVisibleComponent : HotKeyComponent
	{
		// Token: 0x06033545 RID: 210245 RVA: 0x00CD7DAE File Offset: 0x00CD5FAE
		public PhotographSetVisibleComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033546 RID: 210246 RVA: 0x00CD7DB7 File Offset: 0x00CD5FB7
		protected override void OnPress(HotKeyMap config)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnPhotographSetVisible);
		}

		// Token: 0x06033547 RID: 210247 RVA: 0x00CD7DC9 File Offset: 0x00CD5FC9
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
		}
	}
}
