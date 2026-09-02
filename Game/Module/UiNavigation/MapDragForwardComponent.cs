using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D19 RID: 19737
	[NullableContext(1)]
	[Nullable(0)]
	public class MapDragForwardComponent : HotKeyComponent
	{
		// Token: 0x060334C0 RID: 210112 RVA: 0x00CD6A2A File Offset: 0x00CD4C2A
		public MapDragForwardComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060334C1 RID: 210113 RVA: 0x00CD6A33 File Offset: 0x00CD4C33
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			viewHandle.GetFocusListener();
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
		}

		// Token: 0x060334C2 RID: 210114 RVA: 0x00CD6A45 File Offset: 0x00CD4C45
		protected override void OnInputAxis(string axisName, float value)
		{
			if (value == 0f)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit<float>(EEventName.MapDragMoveForward, value);
		}
	}
}
