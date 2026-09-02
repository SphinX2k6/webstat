using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CF9 RID: 19705
	public class GamepadInteractComponentBase : HotKeyComponent
	{
		// Token: 0x06033407 RID: 209927 RVA: 0x00CD4CB2 File Offset: 0x00CD2EB2
		public GamepadInteractComponentBase(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033408 RID: 209928 RVA: 0x00CD4CBC File Offset: 0x00CD2EBC
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			if (!viewHandle.HasGamepadControlMouse())
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			TsUiNavigationPanelConfig mainPanel = viewHandle.MainPanel;
			bool? flag;
			if (mainPanel == null)
			{
				flag = null;
			}
			else
			{
				UUIItem gamepadMouseItem = mainPanel.GamepadMouseItem;
				flag = ((gamepadMouseItem != null) ? new bool?(gamepadMouseItem.IsUIActiveInHierarchy()) : null);
			}
			bool? flag2 = flag;
			bool valueOrDefault = flag2.GetValueOrDefault();
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, valueOrDefault, false);
		}
	}
}
