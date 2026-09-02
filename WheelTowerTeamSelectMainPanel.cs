using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020016AA RID: 5802
[NullableContext(2)]
[Nullable(0)]
public class WheelTowerTeamSelectMainPanel : UiPanelBase
{
	// Token: 0x0600A175 RID: 41333 RVA: 0x002A6E60 File Offset: 0x002A5060
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A176 RID: 41334 RVA: 0x002A6F2C File Offset: 0x002A512C
	protected override UniTask OnBeforeStartAsync()
	{
		WheelTowerTeamSelectMainPanel.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerTeamSelectMainPanel.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A177 RID: 41335 RVA: 0x002A6F6F File Offset: 0x002A516F
	protected override void OnBeforeShow()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnRoleSkillBranchChanged, new Action<int>(this.OnRoleSkillBranchChanged));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnRoleSkillBranchInGamePlayChanged, new Action<int>(this.OnRoleSkillBranchChanged));
	}

	// Token: 0x0600A178 RID: 41336 RVA: 0x002A6FA9 File Offset: 0x002A51A9
	protected override void OnAfterHide()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnRoleSkillBranchChanged, new Action<int>(this.OnRoleSkillBranchChanged));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnRoleSkillBranchInGamePlayChanged, new Action<int>(this.OnRoleSkillBranchChanged));
	}

	// Token: 0x0600A179 RID: 41337 RVA: 0x002A6FE4 File Offset: 0x002A51E4
	protected override void OnStart()
	{
		this.TabComponent = new GenericLayout<TeamTabItem, string>(base.GetHorizontalLayout(0), new Func<TeamTabItem>(this.CreateTab), null, false, true);
		this.TabComponent.RefreshByData(new <>z__ReadOnlyArray<string>(new string[]
		{
			"WheelBattleSelect_Role",
			"WheelBattleSelect_Team",
			"WheelBattleSelect_Template"
		}), delegate
		{
			this.OnClickTab(0);
		}, false);
		this.RoleSelectPanel.OnRoleSelect = delegate(int roleId)
		{
			Action<int> onRoleSelect = this.OnRoleSelect;
			if (onRoleSelect == null)
			{
				return;
			}
			onRoleSelect(roleId);
		};
		this.TeamSelectPanel.OnTeamSelectCallback = delegate(int teamId)
		{
			Action<int> onTeamSelect = this.OnTeamSelect;
			if (onTeamSelect == null)
			{
				return;
			}
			onTeamSelect(teamId);
		};
		this.TemplateSelectPanel.OnTemplateSelect = delegate(int roleId)
		{
			Action<int> onRoleSelect = this.OnRoleSelect;
			if (onRoleSelect == null)
			{
				return;
			}
			onRoleSelect(roleId);
		};
	}

	// Token: 0x0600A17A RID: 41338 RVA: 0x002A7094 File Offset: 0x002A5294
	public void RefreshPanel()
	{
		GenericLayout<TeamTabItem, string> tabComponent = this.TabComponent;
		int num = (tabComponent != null) ? tabComponent.GetSelectedGridIndex() : -1;
		if (num < 0)
		{
			return;
		}
		switch (num)
		{
		case 0:
		{
			WheelTowerRoleSelectPanel roleSelectPanel = this.RoleSelectPanel;
			if (roleSelectPanel == null)
			{
				return;
			}
			roleSelectPanel.OnlyRefreshScroll();
			return;
		}
		case 1:
		{
			WheelTowerTeamSelectPanel teamSelectPanel = this.TeamSelectPanel;
			if (teamSelectPanel == null)
			{
				return;
			}
			teamSelectPanel.Refresh();
			return;
		}
		case 2:
		{
			WheelTowerTemplateSelectPanel templateSelectPanel = this.TemplateSelectPanel;
			if (templateSelectPanel == null)
			{
				return;
			}
			templateSelectPanel.OnlyRefreshScroll();
			return;
		}
		default:
			return;
		}
	}

	// Token: 0x0600A17B RID: 41339 RVA: 0x002A7100 File Offset: 0x002A5300
	public UUIItem GetTabItem(int index)
	{
		GenericLayout<TeamTabItem, string> tabComponent = this.TabComponent;
		if (tabComponent == null)
		{
			return null;
		}
		return tabComponent.GetGridByDisplayIndex(index);
	}

	// Token: 0x0600A17C RID: 41340 RVA: 0x002A7114 File Offset: 0x002A5314
	private void OnRoleSkillBranchChanged(int roleId)
	{
		GenericLayout<TeamTabItem, string> tabComponent = this.TabComponent;
		int num = (tabComponent != null) ? tabComponent.GetSelectedGridIndex() : -1;
		if (num < 0)
		{
			return;
		}
		switch (num)
		{
		case 0:
		{
			WheelTowerRoleSelectPanel roleSelectPanel = this.RoleSelectPanel;
			if (roleSelectPanel == null)
			{
				return;
			}
			roleSelectPanel.RefreshRoleSkillBranch(roleId);
			return;
		}
		case 1:
		{
			WheelTowerTeamSelectPanel teamSelectPanel = this.TeamSelectPanel;
			if (teamSelectPanel == null)
			{
				return;
			}
			teamSelectPanel.Refresh();
			return;
		}
		case 2:
		{
			WheelTowerTemplateSelectPanel templateSelectPanel = this.TemplateSelectPanel;
			if (templateSelectPanel == null)
			{
				return;
			}
			templateSelectPanel.RefreshRoleSkillBranch(roleId);
			return;
		}
		default:
			return;
		}
	}

	// Token: 0x0600A17D RID: 41341 RVA: 0x002A7182 File Offset: 0x002A5382
	[NullableContext(1)]
	private TeamTabItem CreateTab()
	{
		TeamTabItem teamTabItem = new TeamTabItem();
		teamTabItem.SetToggleClickCallback(new Action<int>(this.OnClickTab));
		return teamTabItem;
	}

	// Token: 0x0600A17E RID: 41342 RVA: 0x002A719C File Offset: 0x002A539C
	private void OnClickTab(int index)
	{
		GenericLayout<TeamTabItem, string> tabComponent = this.TabComponent;
		if (tabComponent != null)
		{
			tabComponent.SelectGridProxy(index, false);
		}
		WheelTowerRoleSelectPanel roleSelectPanel = this.RoleSelectPanel;
		if (roleSelectPanel != null)
		{
			roleSelectPanel.SetUiActive(index == 0);
		}
		WheelTowerTeamSelectPanel teamSelectPanel = this.TeamSelectPanel;
		if (teamSelectPanel != null)
		{
			teamSelectPanel.SetUiActive(index == 1);
		}
		WheelTowerTemplateSelectPanel templateSelectPanel = this.TemplateSelectPanel;
		if (templateSelectPanel != null)
		{
			templateSelectPanel.SetUiActive(index == 2);
		}
		int arg = 0;
		switch (index)
		{
		case 0:
		{
			WheelTowerRoleSelectPanel roleSelectPanel2 = this.RoleSelectPanel;
			if (roleSelectPanel2 != null)
			{
				roleSelectPanel2.Refresh();
			}
			WheelTowerRoleSelectPanel roleSelectPanel3 = this.RoleSelectPanel;
			arg = ((roleSelectPanel3 != null) ? roleSelectPanel3.GetFirstRoleId() : 0);
			break;
		}
		case 1:
		{
			WheelTowerTeamSelectPanel teamSelectPanel2 = this.TeamSelectPanel;
			if (teamSelectPanel2 != null)
			{
				teamSelectPanel2.Refresh();
			}
			break;
		}
		case 2:
		{
			WheelTowerTemplateSelectPanel templateSelectPanel2 = this.TemplateSelectPanel;
			if (templateSelectPanel2 != null)
			{
				templateSelectPanel2.Refresh();
			}
			WheelTowerTemplateSelectPanel templateSelectPanel3 = this.TemplateSelectPanel;
			arg = ((templateSelectPanel3 != null) ? templateSelectPanel3.GetFirstRoleId() : 0);
			break;
		}
		}
		Action<ESelectMode, int> onSelectModeChange = this.OnSelectModeChange;
		if (onSelectModeChange == null)
		{
			return;
		}
		onSelectModeChange((ESelectMode)index, arg);
	}

	// Token: 0x04004B73 RID: 19315
	public Action<ESelectMode, int> OnSelectModeChange;

	// Token: 0x04004B74 RID: 19316
	public Action<int> OnRoleSelect;

	// Token: 0x04004B75 RID: 19317
	public Action<int> OnTeamSelect;

	// Token: 0x04004B76 RID: 19318
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<TeamTabItem, string> TabComponent;

	// Token: 0x04004B77 RID: 19319
	private WheelTowerRoleSelectPanel RoleSelectPanel;

	// Token: 0x04004B78 RID: 19320
	private WheelTowerTeamSelectPanel TeamSelectPanel;

	// Token: 0x04004B79 RID: 19321
	private WheelTowerTemplateSelectPanel TemplateSelectPanel;
}
