using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D1A RID: 19738
	[NullableContext(1)]
	[Nullable(0)]
	public class MapDragRightComponent : HotKeyComponent
	{
		// Token: 0x060334C3 RID: 210115 RVA: 0x00CD6A61 File Offset: 0x00CD4C61
		public MapDragRightComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060334C4 RID: 210116 RVA: 0x00CD6A6A File Offset: 0x00CD4C6A
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			viewHandle.GetFocusListener();
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
		}

		// Token: 0x060334C5 RID: 210117 RVA: 0x00CD6A7C File Offset: 0x00CD4C7C
		protected override void OnInputAxis(string axisName, float value)
		{
			if (value == 0f)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit<float>(EEventName.MapDragMoveRight, value);
		}
	}
}
