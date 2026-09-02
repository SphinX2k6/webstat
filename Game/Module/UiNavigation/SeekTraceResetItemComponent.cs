using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.SeekTrace;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D5B RID: 19803
	public class SeekTraceResetItemComponent : HotKeyComponent
	{
		// Token: 0x0603359A RID: 210330 RVA: 0x00CD8667 File Offset: 0x00CD6867
		public SeekTraceResetItemComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x0603359B RID: 210331 RVA: 0x00CD8670 File Offset: 0x00CD6870
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, ModelBase<SeekTraceModel>.Instance.SelectedItem != null, false);
		}

		// Token: 0x0603359C RID: 210332 RVA: 0x00CD8687 File Offset: 0x00CD6887
		protected override void OnPress(HotKeyMap config)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.SeekTraceResetItemInput);
		}
	}
}
