using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CC7 RID: 19655
	public class NavigationRoleResonanceToggle : NavigationToggle
	{
		// Token: 0x060332AE RID: 209582 RVA: 0x00CCF4F3 File Offset: 0x00CCD6F3
		[NullableContext(1)]
		public NavigationRoleResonanceToggle(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x060332AF RID: 209583 RVA: 0x00CCF500 File Offset: 0x00CCD700
		protected override void OnStart()
		{
			UUIExtendToggle uuiextendToggle = this.Selectable as UUIExtendToggle;
			RoleResonancePanelHandle roleResonancePanelHandle = this.PanelHandle as RoleResonancePanelHandle;
			if (roleResonancePanelHandle != null)
			{
				roleResonancePanelHandle.AddUnLockNavigationListener(this.Listener);
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

		// Token: 0x060332B0 RID: 209584 RVA: 0x00CCF568 File Offset: 0x00CCD768
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
