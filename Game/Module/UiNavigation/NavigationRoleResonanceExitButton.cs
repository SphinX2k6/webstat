using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CC5 RID: 19653
	public class NavigationRoleResonanceExitButton : NavigationButton
	{
		// Token: 0x060332A9 RID: 209577 RVA: 0x00CCF3CA File Offset: 0x00CCD5CA
		[NullableContext(1)]
		public NavigationRoleResonanceExitButton(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x060332AA RID: 209578 RVA: 0x00CCF3D8 File Offset: 0x00CCD5D8
		protected override void OnButtonClick()
		{
			UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
			TsUiNavigationPanelConfig tsUiNavigationPanelConfig = (currentViewHandle != null) ? currentViewHandle.GetPanelConfigByType(ESpecialPanelHandleDefine.RoleResonance) : null;
			if (tsUiNavigationPanelConfig == null)
			{
				return;
			}
			RoleResonancePanelHandle roleResonancePanelHandle = tsUiNavigationPanelConfig.GetPanelHandle() as RoleResonancePanelHandle;
			if (roleResonancePanelHandle != null)
			{
				roleResonancePanelHandle.ResetToggleSelect();
			}
			if (roleResonancePanelHandle == null)
			{
				return;
			}
			roleResonancePanelHandle.SetDefaultNavigationListener(null);
		}
	}
}
