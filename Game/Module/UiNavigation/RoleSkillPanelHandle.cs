using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004C9B RID: 19611
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleSkillPanelHandle : SpecialPanelHandleBase
	{
		// Token: 0x060331B1 RID: 209329 RVA: 0x00CCCA1F File Offset: 0x00CCAC1F
		public RoleSkillPanelHandle(string type) : base(type)
		{
		}

		// Token: 0x060331B2 RID: 209330 RVA: 0x00CCCA34 File Offset: 0x00CCAC34
		public void SetToggleSelectByGroupName(string groupName)
		{
			NavigationGroup navigationGroup = base.GetNavigationGroup(groupName);
			if (navigationGroup == null)
			{
				return;
			}
			this.GroupName = groupName;
			foreach (TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener in navigationGroup.ListenerList)
			{
				UUIExtendToggle uuiextendToggle = tsUiNavigationBehaviorListener.GetBehaviorComponent() as UUIExtendToggle;
				if (uuiextendToggle != null)
				{
					uuiextendToggle.bToggleOnSelect = true;
				}
			}
		}

		// Token: 0x060331B3 RID: 209331 RVA: 0x00CCCAA8 File Offset: 0x00CCACA8
		public void ResetToggleSelect()
		{
			NavigationGroup navigationGroup = base.GetNavigationGroup(this.GroupName);
			if (navigationGroup == null)
			{
				return;
			}
			this.GroupName = "";
			foreach (TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener in navigationGroup.ListenerList)
			{
				UUIExtendToggle uuiextendToggle = tsUiNavigationBehaviorListener.GetBehaviorComponent() as UUIExtendToggle;
				if (uuiextendToggle != null)
				{
					uuiextendToggle.bToggleOnSelect = false;
				}
			}
		}

		// Token: 0x060331B4 RID: 209332 RVA: 0x00CCCB24 File Offset: 0x00CCAD24
		public void SetSkillTreeToggleCursorActive(bool isActive)
		{
			NavigationGroup navigationGroup = base.GetNavigationGroup(this.GroupName);
			if (navigationGroup == null)
			{
				return;
			}
			foreach (TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener in navigationGroup.ListenerList)
			{
				if (tsUiNavigationBehaviorListener.Cursor != null)
				{
					tsUiNavigationBehaviorListener.Cursor.Switch = isActive;
				}
			}
			ModelBase<UiNavigationModel>.Instance.RefreshCursorActive();
		}

		// Token: 0x0401DB71 RID: 121713
		public string GroupName = "";

		// Token: 0x0401DB72 RID: 121714
		public bool IsInPreview;
	}
}
