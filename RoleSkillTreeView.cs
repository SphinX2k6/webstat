using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi.RoleSkill;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020028D1 RID: 10449
[NullableContext(1)]
[Nullable(0)]
public class RoleSkillTreeView : UiTabViewBase
{
	// Token: 0x06014C1E RID: 85022 RVA: 0x005C0E44 File Offset: 0x005BF044
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06014C1F RID: 85023 RVA: 0x005C0E8C File Offset: 0x005BF08C
	protected override UniTask OnBeforeStartAsync()
	{
		RoleSkillTreeView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleSkillTreeView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014C20 RID: 85024 RVA: 0x005C0ED0 File Offset: 0x005BF0D0
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RoleSystemChangeRole, new Action<int>(this.OnRoleChange));
		Singleton<EventSystem>.Instance.Add<RoleSkillTreeSkillItemBase>(EEventName.OnSkillTreeNodeToggleClick, new Action<RoleSkillTreeSkillItemBase>(this.OnNodeToggleClick));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRoleInternalViewQuit, new Action(this.OnRoleInternalViewQuit));
		Singleton<EventSystem>.Instance.Add<EUiTabViewName, int>(EEventName.SelectRoleTabOutside, new Action<EUiTabViewName, int>(this.OnSelectRoleTabOutside));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.SkillTreeNodeActive, new Action<int>(this.OnAttributeNodeActive));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.SkillTreeNodeLevelUp, new Action<int>(this.OnSkillNodeLevelUp));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemList, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnAddCommonItemList));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnRoleSkillBranchChanged, new Action<int>(this.OnRoleSkillBranchChanged));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRoleSkillInputPanelVisible, new Action<bool>(this.OnRoleSkillInputPanelVisible));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnSkillShowTagToggleChanged, new Action<bool>(this.OnSkillShowTagToggleChanged));
	}

	// Token: 0x06014C21 RID: 85025 RVA: 0x005C0FF8 File Offset: 0x005BF1F8
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RoleSystemChangeRole, new Action<int>(this.OnRoleChange));
		Singleton<EventSystem>.Instance.Remove<RoleSkillTreeSkillItemBase>(EEventName.OnSkillTreeNodeToggleClick, new Action<RoleSkillTreeSkillItemBase>(this.OnNodeToggleClick));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleInternalViewQuit, new Action(this.OnRoleInternalViewQuit));
		Singleton<EventSystem>.Instance.Remove<EUiTabViewName, int>(EEventName.SelectRoleTabOutside, new Action<EUiTabViewName, int>(this.OnSelectRoleTabOutside));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.SkillTreeNodeActive, new Action<int>(this.OnAttributeNodeActive));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.SkillTreeNodeLevelUp, new Action<int>(this.OnSkillNodeLevelUp));
		Singleton<EventSystem>.Instance.Remove<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemList, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnAddCommonItemList));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnRoleSkillBranchChanged, new Action<int>(this.OnRoleSkillBranchChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleSkillInputPanelVisible, new Action<bool>(this.OnRoleSkillInputPanelVisible));
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnSkillShowTagToggleChanged, new Action<bool>(this.OnSkillShowTagToggleChanged));
	}

	// Token: 0x06014C22 RID: 85026 RVA: 0x005C1120 File Offset: 0x005BF320
	protected override void OnBeforeShow()
	{
		ControllerBase<RoleController>.Instance.PlayRoleMontage(EPerformanceRoleState.Skill, false, false, false);
		int curSelectRoleId = this.RoleViewAgent.GetCurSelectRoleId();
		this.UpdateRole(curSelectRoleId);
		UiModelBase model = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor().Model;
		UiModelLoadingIconComponent uiModelLoadingIconComponent = (model != null) ? model.CheckGetComponent<UiModelLoadingIconComponent>() : null;
		if (uiModelLoadingIconComponent == null)
		{
			return;
		}
		uiModelLoadingIconComponent.SetLoadingOpen(false);
	}

	// Token: 0x06014C23 RID: 85027 RVA: 0x005C1174 File Offset: 0x005BF374
	protected override void OnBeforeHide()
	{
		if (Singleton<UiSceneManager>.Instance.HasRoleSystemRoleActor())
		{
			UiModelBase model = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor().Model;
			UiModelLoadingIconComponent uiModelLoadingIconComponent = (model != null) ? model.CheckGetComponent<UiModelLoadingIconComponent>() : null;
			if (uiModelLoadingIconComponent != null)
			{
				uiModelLoadingIconComponent.SetLoadingOpen(true);
			}
		}
		RoleSkillTreeItem roleSkillTreeItem = this.RoleSkillTreeItem;
		if (roleSkillTreeItem == null)
		{
			return;
		}
		roleSkillTreeItem.SetSkillBranchTipsVisible(false);
	}

	// Token: 0x06014C24 RID: 85028 RVA: 0x005C11C8 File Offset: 0x005BF3C8
	protected override void OnAfterShow()
	{
		RoleSkillTreeLogEvent logData = new RoleSkillTreeLogEvent();
		ControllerBase<LogReportController>.Instance.LogReport(logData);
	}

	// Token: 0x06014C25 RID: 85029 RVA: 0x005C11E8 File Offset: 0x005BF3E8
	protected override void OnShowUiTabViewFromToggle()
	{
		EUiTabViewName? preSelectTabName = this.RoleViewAgent.GetPreSelectTabName();
		if (((preSelectTabName != null) ? preSelectTabName.GetValueOrDefault() : null) == base.GetViewName())
		{
			RoleSkillTreeItem roleSkillTreeItem = this.RoleSkillTreeItem;
			if (roleSkillTreeItem == null)
			{
				return;
			}
			roleSkillTreeItem.PlayItemSequence("ChangeRole");
			return;
		}
		else
		{
			RoleSkillTreeItem roleSkillTreeItem2 = this.RoleSkillTreeItem;
			if (roleSkillTreeItem2 == null)
			{
				return;
			}
			roleSkillTreeItem2.PlayItemSequence("Sle");
			return;
		}
	}

	// Token: 0x06014C26 RID: 85030 RVA: 0x005C1251 File Offset: 0x005BF451
	protected override void OnShowUiTabViewFromView()
	{
		RoleSkillTreeItem roleSkillTreeItem = this.RoleSkillTreeItem;
		if (roleSkillTreeItem == null)
		{
			return;
		}
		roleSkillTreeItem.PlayItemSequence("Start");
	}

	// Token: 0x06014C27 RID: 85031 RVA: 0x005C1268 File Offset: 0x005BF468
	private void OnRoleChange(int roleId)
	{
		this.RoleSkillTreeItem.PlayItemSequence("ChangeRole");
		this.UpdateRole(roleId);
		RoleSkillTreeItem roleSkillTreeItem = this.RoleSkillTreeItem;
		if (roleSkillTreeItem == null)
		{
			return;
		}
		roleSkillTreeItem.SetSkillBranchTipsVisible(false);
	}

	// Token: 0x06014C28 RID: 85032 RVA: 0x005C1292 File Offset: 0x005BF492
	private void OnRoleInternalViewQuit()
	{
		this.RoleSkillTreeItem.PlayItemSequence("MoveLeft");
		this.RoleSkillTreeItem.CancelToggleSelect();
		this.SetSkillInputButtonVisible(true);
		this.TreeInfoViewId = -1;
	}

	// Token: 0x06014C29 RID: 85033 RVA: 0x005C12BD File Offset: 0x005BF4BD
	private void OnSelectRoleTabOutside(EUiTabViewName eUiTabViewName, int i)
	{
		this.RoleSkillTreeItem.PlayItemSequence("MoveLeft");
		this.RoleSkillTreeItem.CancelToggleSelect();
		this.SetSkillInputButtonVisible(true);
	}

	// Token: 0x06014C2A RID: 85034 RVA: 0x005C12E1 File Offset: 0x005BF4E1
	private void OnAttributeNodeActive(int nodeId)
	{
		RoleSkillTreeItem roleSkillTreeItem = this.RoleSkillTreeItem;
		if (roleSkillTreeItem != null)
		{
			roleSkillTreeItem.OnAttributeNodeActive(nodeId);
		}
		if (this.RoleViewAgent.RoleViewState == ERoleViewState.Internal)
		{
			this.UpdateSkillTreeInfoView();
		}
	}

	// Token: 0x06014C2B RID: 85035 RVA: 0x005C130C File Offset: 0x005BF50C
	private void OnSkillNodeLevelUp(int nodeId)
	{
		RoleSkillTreeItem roleSkillTreeItem = this.RoleSkillTreeItem;
		if (roleSkillTreeItem != null)
		{
			roleSkillTreeItem.OnSkillNodeLevelUp(nodeId);
		}
		if (this.RoleViewAgent.RoleViewState == ERoleViewState.Internal)
		{
			int skillId = ConfigBase<RoleSkillConfig>.Instance.GetSkillTreeNode(nodeId).Value.SkillId;
			int upgradeSkillIdIfUpgraded = ModelBase<RoleModel>.Instance.GetUpgradeSkillIdIfUpgraded(skillId, this.RoleId);
			int skillId2 = (upgradeSkillIdIfUpgraded > 0) ? upgradeSkillIdIfUpgraded : skillId;
			ControllerBase<RoleController>.Instance.SendRoleSkillViewRequest(this.RoleId, skillId2, new Action(this.UpdateSkillTreeInfoView));
		}
	}

	// Token: 0x06014C2C RID: 85036 RVA: 0x005C138E File Offset: 0x005BF58E
	private void OnNodeToggleClick(RoleSkillTreeSkillItemBase skillItem)
	{
		RoleSkillTreeItem roleSkillTreeItem = this.RoleSkillTreeItem;
		if (roleSkillTreeItem != null)
		{
			roleSkillTreeItem.SelectSkillItem(skillItem, false);
		}
		this.ShowSkillTreeInfo();
	}

	// Token: 0x06014C2D RID: 85037 RVA: 0x005C13A9 File Offset: 0x005BF5A9
	private void OnAddCommonItemList(IReadOnlyList<IProto_NormalItem> _)
	{
		RoleSkillTreeItem roleSkillTreeItem = this.RoleSkillTreeItem;
		if (roleSkillTreeItem == null)
		{
			return;
		}
		roleSkillTreeItem.OnAddCommonItemList();
	}

	// Token: 0x06014C2E RID: 85038 RVA: 0x005C13BB File Offset: 0x005BF5BB
	private void UpdateRole(int roleId)
	{
		this.RoleId = roleId;
		this.Refresh();
	}

	// Token: 0x06014C2F RID: 85039 RVA: 0x005C13CA File Offset: 0x005BF5CA
	public void Refresh()
	{
		RoleSkillTreeItem roleSkillTreeItem = this.RoleSkillTreeItem;
		if (roleSkillTreeItem == null)
		{
			return;
		}
		roleSkillTreeItem.UpdateRole(this.RoleId);
	}

	// Token: 0x06014C30 RID: 85040 RVA: 0x005C13E4 File Offset: 0x005BF5E4
	private void ShowSkillTreeInfo()
	{
		RoleSkillTreeItem roleSkillTreeItem = this.RoleSkillTreeItem;
		RoleSkillTreeSkillItemBase roleSkillTreeSkillItemBase = (roleSkillTreeItem != null) ? roleSkillTreeItem.GetCurrentSelectedSkillItem() : null;
		if (roleSkillTreeSkillItemBase == null)
		{
			return;
		}
		int roleId = roleSkillTreeSkillItemBase.GetRoleId();
		int roleViewState = (int)this.RoleViewAgent.RoleViewState;
		ESkillTreeNodeType? type = roleSkillTreeSkillItemBase.GetType();
		Action action;
		if (roleViewState == 1)
		{
			action = new Action(this.UpdateSkillTreeInfoView);
		}
		else
		{
			action = new Action(this.OpenSkillTreeInfoView);
		}
		if (type.GetValueOrDefault() == ESkillTreeNodeType.OuterAttribute || type.GetValueOrDefault() == ESkillTreeNodeType.OuterPassiveSkill)
		{
			action();
			return;
		}
		int upgradeSkillId = roleSkillTreeSkillItemBase.GetUpgradeSkillId();
		int skillId = (upgradeSkillId > 0) ? upgradeSkillId : roleSkillTreeSkillItemBase.GetSkillId();
		ControllerBase<RoleController>.Instance.SendRoleSkillViewRequest(roleId, skillId, action);
	}

	// Token: 0x06014C31 RID: 85041 RVA: 0x005C1484 File Offset: 0x005BF684
	private void UpdateSkillTreeInfoView()
	{
		this.UpdateSkillTreeInfoViewData();
		if (this.RoleViewAgent.RoleViewState == ERoleViewState.External)
		{
			return;
		}
		if (this.TreeInfoViewId != -1)
		{
			RoleSkillTreeInfoView roleSkillTreeInfoView = Singleton<UiManager>.Instance.GetView(this.TreeInfoViewId) as RoleSkillTreeInfoView;
			if (roleSkillTreeInfoView == null)
			{
				return;
			}
			roleSkillTreeInfoView.Refresh();
		}
	}

	// Token: 0x06014C32 RID: 85042 RVA: 0x005C14C4 File Offset: 0x005BF6C4
	private void OpenSkillTreeInfoView()
	{
		RoleSkillTreeItem roleSkillTreeItem = this.RoleSkillTreeItem;
		if (((roleSkillTreeItem != null) ? roleSkillTreeItem.GetCurrentSelectedSkillItem() : null) == null)
		{
			return;
		}
		this.UpdateSkillTreeInfoViewData();
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleSkillTreeInfoView, this.TreeInfoViewData, delegate(bool success, int viewId)
		{
			this.TreeInfoViewId = viewId;
		});
		this.SetSkillInputButtonVisible(false);
		this.RoleSkillTreeItem.PlayItemSequence("MoveRight");
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRoleInternalViewEnter);
	}

	// Token: 0x06014C33 RID: 85043 RVA: 0x005C1534 File Offset: 0x005BF734
	private void UpdateSkillTreeInfoViewData()
	{
		RoleSkillTreeItem roleSkillTreeItem = this.RoleSkillTreeItem;
		RoleSkillTreeSkillItemBase roleSkillTreeSkillItemBase = (roleSkillTreeItem != null) ? roleSkillTreeItem.GetCurrentSelectedSkillItem() : null;
		if (roleSkillTreeSkillItemBase == null)
		{
			return;
		}
		int skillNodeId = roleSkillTreeSkillItemBase.GetSkillNodeId();
		this.TreeInfoViewData.RoleId = this.RoleId;
		this.TreeInfoViewData.SkillNodeId = skillNodeId;
		this.TreeInfoViewData.RoleViewAgent = this.RoleViewAgent;
	}

	// Token: 0x06014C34 RID: 85044 RVA: 0x005C158D File Offset: 0x005BF78D
	private void SetSkillInputButtonVisible(bool bVisible)
	{
		RoleSkillTreeItem roleSkillTreeItem = this.RoleSkillTreeItem;
		if (roleSkillTreeItem == null)
		{
			return;
		}
		roleSkillTreeItem.SetSkillInputButtonVisible(bVisible);
	}

	// Token: 0x06014C35 RID: 85045 RVA: 0x005C15A0 File Offset: 0x005BF7A0
	private void OnRoleSkillBranchChanged(int i)
	{
		RoleSkillTreeItem roleSkillTreeItem = this.RoleSkillTreeItem;
		if (roleSkillTreeItem == null)
		{
			return;
		}
		roleSkillTreeItem.OnRoleSkillBranchChanged();
	}

	// Token: 0x06014C36 RID: 85046 RVA: 0x005C15B2 File Offset: 0x005BF7B2
	private void OnRoleSkillInputPanelVisible(bool visible)
	{
		RoleSkillTreeItem roleSkillTreeItem = this.RoleSkillTreeItem;
		if (roleSkillTreeItem == null)
		{
			return;
		}
		roleSkillTreeItem.SetSkillBranchVisible(ESkillBranchInvisibleReason.SkillInputPanel, !visible);
	}

	// Token: 0x06014C37 RID: 85047 RVA: 0x005C15C9 File Offset: 0x005BF7C9
	private void OnSkillShowTagToggleChanged(bool isVisible)
	{
		RoleSkillTreeItem roleSkillTreeItem = this.RoleSkillTreeItem;
		if (roleSkillTreeItem == null)
		{
			return;
		}
		roleSkillTreeItem.RefreshAllShowTags();
	}

	// Token: 0x06014C38 RID: 85048 RVA: 0x005C15DB File Offset: 0x005BF7DB
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (!(configParams[0] == "FirstDoubleTag"))
		{
			return null;
		}
		RoleSkillTreeItem roleSkillTreeItem = this.RoleSkillTreeItem;
		if (roleSkillTreeItem == null)
		{
			return null;
		}
		return roleSkillTreeItem.GetGuideUiItemAndUiItemForShowEx(configParams);
	}

	// Token: 0x04009FEA RID: 40938
	[Nullable(2)]
	private RoleViewAgent RoleViewAgent;

	// Token: 0x04009FEB RID: 40939
	[Nullable(2)]
	private RoleSkillTreeItem RoleSkillTreeItem;

	// Token: 0x04009FEC RID: 40940
	private int RoleId;

	// Token: 0x04009FED RID: 40941
	private readonly RoleSkillTreeInfoViewData TreeInfoViewData = new RoleSkillTreeInfoViewData();

	// Token: 0x04009FEE RID: 40942
	private int TreeInfoViewId = -1;

	// Token: 0x02008C28 RID: 35880
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402F378 RID: 193400
		RoleSkillTreeItem
	}
}
