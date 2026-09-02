using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CCA RID: 19658
	public class NavigationRoleSkillTreeExitButton : NavigationButton
	{
		// Token: 0x060332B5 RID: 209589 RVA: 0x00CCF677 File Offset: 0x00CCD877
		[NullableContext(1)]
		public NavigationRoleSkillTreeExitButton(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x060332B6 RID: 209590 RVA: 0x00CCF684 File Offset: 0x00CCD884
		protected override void OnButtonClick()
		{
			UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
			TsUiNavigationPanelConfig tsUiNavigationPanelConfig = (currentViewHandle != null) ? currentViewHandle.GetPanelConfigByType(ESpecialPanelHandleDefine.RoleSkill) : null;
			if (tsUiNavigationPanelConfig == null)
			{
				return;
			}
			RoleSkillPanelHandle roleSkillPanelHandle = tsUiNavigationPanelConfig.GetPanelHandle() as RoleSkillPanelHandle;
			if (roleSkillPanelHandle == null)
			{
				return;
			}
			roleSkillPanelHandle.ResetToggleSelect();
		}
	}
}
