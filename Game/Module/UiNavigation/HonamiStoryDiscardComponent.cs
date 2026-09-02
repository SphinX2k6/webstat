using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.HonamiStory;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D05 RID: 19717
	public class HonamiStoryDiscardComponent : HonamiStoryComponentBase
	{
		// Token: 0x06033427 RID: 209959 RVA: 0x00CD5165 File Offset: 0x00CD3365
		public HonamiStoryDiscardComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033428 RID: 209960 RVA: 0x00CD516E File Offset: 0x00CD336E
		protected override void OnPress(HotKeyMap config)
		{
			if (base.Logic == null)
			{
				return;
			}
			base.Logic.Discard();
		}

		// Token: 0x06033429 RID: 209961 RVA: 0x00CD5184 File Offset: 0x00CD3384
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			if (base.Logic == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			if (!base.Logic.IsInGame())
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			if (!viewHandle.HasGamepadControlMouse())
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			if (viewHandle.IsNavigationMousePositionDragging())
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			HonamiStoryItemGridItem curItem = base.Logic.GetCurItem();
			if (curItem == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			if (curItem.GetBackpackType() == EHonamiStoryBackpackType.PickUpBox)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
		}
	}
}
