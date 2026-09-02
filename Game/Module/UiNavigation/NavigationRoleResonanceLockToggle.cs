using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CC6 RID: 19654
	public class NavigationRoleResonanceLockToggle : NavigationToggle
	{
		// Token: 0x060332AB RID: 209579 RVA: 0x00CCF427 File Offset: 0x00CCD627
		[NullableContext(1)]
		public NavigationRoleResonanceLockToggle(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x060332AC RID: 209580 RVA: 0x00CCF434 File Offset: 0x00CCD634
		protected override void OnStart()
		{
			UUIExtendToggle uuiextendToggle = this.Selectable as UUIExtendToggle;
			RoleResonancePanelHandle roleResonancePanelHandle = this.PanelHandle as RoleResonancePanelHandle;
			if (roleResonancePanelHandle != null)
			{
				roleResonancePanelHandle.AddLockNavigationListener(this.Listener);
			}
			if (StringUtils.IsBlank((roleResonancePanelHandle != null) ? roleResonancePanelHandle.GroupName : null))
			{
				return;
			}
			uuiextendToggle.bToggleOnSelect = true;
			if (roleResonancePanelHandle != null)
			{
				roleResonancePanelHandle.SetDefaultNavigationListener(this.Listener);
			}
			ControllerBase<UiNavigationNewController>.Instance.MarkViewHandleRefreshNavigationDirty();
		}

		// Token: 0x060332AD RID: 209581 RVA: 0x00CCF49C File Offset: 0x00CCD69C
		protected override void OnToggleClick(EToggleState state)
		{
			RoleResonancePanelHandle roleResonancePanelHandle = this.PanelHandle as RoleResonancePanelHandle;
			if (roleResonancePanelHandle != null)
			{
				roleResonancePanelHandle.SetDefaultNavigationListener(this.Listener);
			}
			if (!StringUtils.IsBlank((roleResonancePanelHandle != null) ? roleResonancePanelHandle.GroupName : null))
			{
				return;
			}
			if (roleResonancePanelHandle != null)
			{
				RoleResonancePanelHandle roleResonancePanelHandle2 = roleResonancePanelHandle;
				TsUiNavigationBehaviorListener listener = this.Listener;
				roleResonancePanelHandle2.SetToggleSelectByGroupName((listener != null) ? listener.GroupName : null);
			}
		}
	}
}
