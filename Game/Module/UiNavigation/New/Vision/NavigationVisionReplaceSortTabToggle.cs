using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation.New.Vision
{
	// Token: 0x02004D85 RID: 19845
	public class NavigationVisionReplaceSortTabToggle : NavigationToggle
	{
		// Token: 0x06033638 RID: 210488 RVA: 0x00CDA8A3 File Offset: 0x00CD8AA3
		[NullableContext(1)]
		public NavigationVisionReplaceSortTabToggle(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x06033639 RID: 210489 RVA: 0x00CDA8B0 File Offset: 0x00CD8AB0
		protected override void OnToggleClick(EToggleState _)
		{
			VisionChooseMainPanelHandle visionChooseMainPanelHandle = this.PanelHandle as VisionChooseMainPanelHandle;
			TsUiNavigationBehaviorListener currentNavigationFocusListener = ControllerBase<UiNavigationNewController>.Instance.GetCurrentNavigationFocusListener();
			if (currentNavigationFocusListener == null || visionChooseMainPanelHandle == null)
			{
				return;
			}
			if (currentNavigationFocusListener.GroupName == visionChooseMainPanelHandle.ChangeListenerList[0].GroupName)
			{
				visionChooseMainPanelHandle.IsFindChangeListenerList = true;
				ControllerBase<UiNavigationNewController>.Instance.MarkViewHandleRefreshNavigationDirty();
			}
		}
	}
}
