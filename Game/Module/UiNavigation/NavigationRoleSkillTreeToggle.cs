using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CCB RID: 19659
	[NullableContext(1)]
	[Nullable(0)]
	public class NavigationRoleSkillTreeToggle : NavigationToggle
	{
		// Token: 0x060332B7 RID: 209591 RVA: 0x00CCF6C6 File Offset: 0x00CCD8C6
		public NavigationRoleSkillTreeToggle(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x060332B8 RID: 209592 RVA: 0x00CCF6D1 File Offset: 0x00CCD8D1
		protected override void OnInit()
		{
			base.OnInit();
			Singleton<EventSystem>.Instance.Add<EUiTabViewName, int>(EEventName.SelectRoleTabOutside, new Action<EUiTabViewName, int>(this.HandleSkillTreeToggleState));
		}

		// Token: 0x060332B9 RID: 209593 RVA: 0x00CCF6F5 File Offset: 0x00CCD8F5
		protected override void OnClear()
		{
			base.OnClear();
			Singleton<EventSystem>.Instance.Remove(EEventName.SelectRoleTabOutside, new Action<EUiTabViewName, int>(this.HandleSkillTreeToggleState));
		}

		// Token: 0x060332BA RID: 209594 RVA: 0x00CCF719 File Offset: 0x00CCD919
		private void HandleSkillTreeToggleState(EUiTabViewName eUiTabViewName, int i)
		{
			UUIExtendToggle uuiextendToggle = this.Selectable as UUIExtendToggle;
			if (uuiextendToggle.GetToggleState() == EToggleState.ETT_Checked)
			{
				this.NeedSkipSetToggle = true;
			}
			uuiextendToggle.bToggleOnSelect = false;
		}

		// Token: 0x060332BB RID: 209595 RVA: 0x00CCF73C File Offset: 0x00CCD93C
		protected override void OnToggleClick(EToggleState state)
		{
			RoleSkillPanelHandle roleSkillPanelHandle = this.PanelHandle as RoleSkillPanelHandle;
			if (!StringUtils.IsBlank((roleSkillPanelHandle != null) ? roleSkillPanelHandle.GroupName : null))
			{
				return;
			}
			if (roleSkillPanelHandle != null)
			{
				RoleSkillPanelHandle roleSkillPanelHandle2 = roleSkillPanelHandle;
				TsUiNavigationBehaviorListener listener = this.Listener;
				roleSkillPanelHandle2.SetToggleSelectByGroupName((listener != null) ? listener.GroupName : null);
			}
		}

		// Token: 0x060332BC RID: 209596 RVA: 0x00CCF784 File Offset: 0x00CCD984
		protected override bool OnHandlePointerSelectInheritance(ULGUIPointerEventData eventData)
		{
			if (this.NeedSkipSetToggle)
			{
				this.NeedSkipSetToggle = false;
				return false;
			}
			return true;
		}

		// Token: 0x060332BD RID: 209597 RVA: 0x00CCF798 File Offset: 0x00CCD998
		protected override bool OnCheckFindNavigationBefore()
		{
			return !(this.PanelHandle as RoleSkillPanelHandle).IsInPreview;
		}

		// Token: 0x0401DB92 RID: 121746
		private bool NeedSkipSetToggle;
	}
}
