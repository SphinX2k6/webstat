using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CC8 RID: 19656
	public class NavigationRoleSkillPreviewExitButton : NavigationButton
	{
		// Token: 0x060332B1 RID: 209585 RVA: 0x00CCF5BF File Offset: 0x00CCD7BF
		[NullableContext(1)]
		public NavigationRoleSkillPreviewExitButton(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x060332B2 RID: 209586 RVA: 0x00CCF5CC File Offset: 0x00CCD7CC
		protected override void OnButtonClick()
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
				roleSkillPanelHandle.IsInPreview = false;
				roleSkillPanelHandle.SetSkillTreeToggleCursorActive(true);
			}
		}
	}
}
