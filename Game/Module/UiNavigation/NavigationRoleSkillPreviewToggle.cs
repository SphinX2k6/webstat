using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CC9 RID: 19657
	public class NavigationRoleSkillPreviewToggle : NavigationToggle
	{
		// Token: 0x060332B3 RID: 209587 RVA: 0x00CCF616 File Offset: 0x00CCD816
		[NullableContext(1)]
		public NavigationRoleSkillPreviewToggle(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x060332B4 RID: 209588 RVA: 0x00CCF624 File Offset: 0x00CCD824
		protected override void OnToggleClick(EToggleState state)
		{
			UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
			TsUiNavigationPanelConfig tsUiNavigationPanelConfig = (currentViewHandle != null) ? currentViewHandle.GetPanelConfigByType(ESpecialPanelHandleDefine.RoleSkill) : null;
			if (tsUiNavigationPanelConfig == null)
			{
				return;
			}
			RoleSkillPanelHandle roleSkillPanelHandle = tsUiNavigationPanelConfig.GetPanelHandle() as RoleSkillPanelHandle;
			if (roleSkillPanelHandle != null)
			{
				roleSkillPanelHandle.IsInPreview = (state == EToggleState.ETT_Checked);
				roleSkillPanelHandle.SetSkillTreeToggleCursorActive(state != EToggleState.ETT_Checked);
			}
		}
	}
}
