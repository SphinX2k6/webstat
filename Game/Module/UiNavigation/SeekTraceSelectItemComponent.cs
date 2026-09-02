using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D5A RID: 19802
	public class SeekTraceSelectItemComponent : HotKeyComponent
	{
		// Token: 0x06033597 RID: 210327 RVA: 0x00CD8641 File Offset: 0x00CD6841
		public SeekTraceSelectItemComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033598 RID: 210328 RVA: 0x00CD864A File Offset: 0x00CD684A
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
		}

		// Token: 0x06033599 RID: 210329 RVA: 0x00CD8655 File Offset: 0x00CD6855
		protected override void OnPress(HotKeyMap config)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.SeekTraceSelectItemInput);
		}
	}
}
