using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleDev;
using CSharpScript.Game.Module.RoleUi.RoleSkill;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020028C5 RID: 10437
[NullableContext(1)]
[Nullable(0)]
public class RoleSkillMergeView : UiViewBase
{
	// Token: 0x06014B46 RID: 84806 RVA: 0x005BBBD7 File Offset: 0x005B9DD7
	public RoleSkillMergeView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06014B47 RID: 84807 RVA: 0x005BBC00 File Offset: 0x005B9E00
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x06014B48 RID: 84808 RVA: 0x005BBC5C File Offset: 0x005B9E5C
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<RoleSkillTreeSkillItemBase>(EEventName.OnSkillTreeNodeToggleClick, new Action<RoleSkillTreeSkillItemBase>(this.OnNodeToggleClick));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.SkillTreeNodeActive, new Action<int>(this.OnSkillNodeLevelUp));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.SkillTreeNodeLevelUp, new Action<int>(this.OnSkillNodeLevelUp));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemList, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnAddCommonItemList));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnRoleSkillBranchChanged, new Action<int>(this.OnRoleSkillBranchChanged));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRoleSkillInputPanelVisible, new Action<bool>(this.OnRoleSkillInputPanelVisible));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnSkillShowTagToggleChanged, new Action<bool>(this.OnSkillShowTagToggleChanged));
	}

	// Token: 0x06014B49 RID: 84809 RVA: 0x005BBD4C File Offset: 0x005B9F4C
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<RoleSkillTreeSkillItemBase>(EEventName.OnSkillTreeNodeToggleClick, new Action<RoleSkillTreeSkillItemBase>(this.OnNodeToggleClick));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.SkillTreeNodeActive, new Action<int>(this.OnSkillNodeLevelUp));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.SkillTreeNodeLevelUp, new Action<int>(this.OnSkillNodeLevelUp));
		Singleton<EventSystem>.Instance.Remove<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemList, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnAddCommonItemList));
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnRoleSkillBranchChanged, new Action<int>(this.OnRoleSkillBranchChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleSkillInputPanelVisible, new Action<bool>(this.OnRoleSkillInputPanelVisible));
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnSkillShowTagToggleChanged, new Action<bool>(this.OnSkillShowTagToggleChanged));
	}

	// Token: 0x06014B4A RID: 84810 RVA: 0x005BBE3C File Offset: 0x005BA03C
	protected override UniTask OnBeforeStartAsync()
	{
		RoleSkillMergeView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleSkillMergeView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014B4B RID: 84811 RVA: 0x005BBE80 File Offset: 0x005BA080
	protected override void OnBeforeShow()
	{
		this.Refresh();
		if (this.WaitToSelectNodeIndex >= 0)
		{
			this.SelectNodeByNodeIndex(this.WaitToSelectNodeIndex);
			this.WaitToSelectNodeIndex = -1;
		}
		RoleSkillTreeItem roleSkillTreeItem = this.RoleSkillTreeItem;
		if (roleSkillTreeItem != null)
		{
			roleSkillTreeItem.PlayItemSequence("MoveRight");
		}
		RoleSkillTreeInfoItem roleSkillTreeInfoItem = this.RoleSkillTreeInfoItem;
		if (roleSkillTreeInfoItem == null)
		{
			return;
		}
		roleSkillTreeInfoItem.PlayItemSequence("Start");
	}

	// Token: 0x06014B4C RID: 84812 RVA: 0x005BBEDC File Offset: 0x005BA0DC
	private UniTask InitializeItems()
	{
		RoleSkillMergeView.<InitializeItems>d__12 <InitializeItems>d__;
		<InitializeItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitializeItems>d__.<>4__this = this;
		<InitializeItems>d__.<>1__state = -1;
		<InitializeItems>d__.<>t__builder.Start<RoleSkillMergeView.<InitializeItems>d__12>(ref <InitializeItems>d__);
		return <InitializeItems>d__.<>t__builder.Task;
	}

	// Token: 0x06014B4D RID: 84813 RVA: 0x005BBF20 File Offset: 0x005BA120
	protected override UniTask OnPlayingStartSequenceAsync()
	{
		RoleSkillMergeView.<OnPlayingStartSequenceAsync>d__13 <OnPlayingStartSequenceAsync>d__;
		<OnPlayingStartSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlayingStartSequenceAsync>d__.<>4__this = this;
		<OnPlayingStartSequenceAsync>d__.<>1__state = -1;
		<OnPlayingStartSequenceAsync>d__.<>t__builder.Start<RoleSkillMergeView.<OnPlayingStartSequenceAsync>d__13>(ref <OnPlayingStartSequenceAsync>d__);
		return <OnPlayingStartSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014B4E RID: 84814 RVA: 0x005BBF64 File Offset: 0x005BA164
	protected override UniTask OnPlayingCloseSequenceAsync()
	{
		RoleSkillMergeView.<OnPlayingCloseSequenceAsync>d__14 <OnPlayingCloseSequenceAsync>d__;
		<OnPlayingCloseSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlayingCloseSequenceAsync>d__.<>4__this = this;
		<OnPlayingCloseSequenceAsync>d__.<>1__state = -1;
		<OnPlayingCloseSequenceAsync>d__.<>t__builder.Start<RoleSkillMergeView.<OnPlayingCloseSequenceAsync>d__14>(ref <OnPlayingCloseSequenceAsync>d__);
		return <OnPlayingCloseSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014B4F RID: 84815 RVA: 0x005BBFA7 File Offset: 0x005BA1A7
	private void OnBackButtonClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x06014B50 RID: 84816 RVA: 0x005BBFB0 File Offset: 0x005BA1B0
	private void Init()
	{
		IRoleDevSkillMergeViewParams roleDevSkillMergeViewParams = this.OpenParam as IRoleDevSkillMergeViewParams;
		this.RoleSkillTreeItemData.RoleId = roleDevSkillMergeViewParams.RoleId;
		this.RoleSkillTreeInfoItemData.RoleId = roleDevSkillMergeViewParams.RoleId;
		this.WaitToSelectNodeIndex = roleDevSkillMergeViewParams.SkillNodeIndex;
	}

	// Token: 0x06014B51 RID: 84817 RVA: 0x005BBFF8 File Offset: 0x005BA1F8
	private void SelectNodeByNodeIndex(int nodeIndex)
	{
		RoleSkillTreeSkillItemBase skillItemByIndex = this.RoleSkillTreeItem.GetSkillItemByIndex(nodeIndex);
		if (skillItemByIndex == null)
		{
			return;
		}
		this.RoleSkillTreeItem.SelectSkillItem(skillItemByIndex, true);
		this.UpdateSkillTreeInfo();
	}

	// Token: 0x06014B52 RID: 84818 RVA: 0x005BC029 File Offset: 0x005BA229
	private void Refresh()
	{
		RoleSkillTreeItem roleSkillTreeItem = this.RoleSkillTreeItem;
		if (roleSkillTreeItem != null)
		{
			roleSkillTreeItem.UpdateRole(this.RoleSkillTreeItemData.RoleId);
		}
		RoleSkillTreeItem roleSkillTreeItem2 = this.RoleSkillTreeItem;
		if (roleSkillTreeItem2 != null)
		{
			roleSkillTreeItem2.SetSkillInputButtonVisible(false);
		}
		this.UpdateSkillTreeInfo();
	}

	// Token: 0x06014B53 RID: 84819 RVA: 0x005BC05F File Offset: 0x005BA25F
	private void OnNodeToggleClick(RoleSkillTreeSkillItemBase skillItem)
	{
		RoleSkillTreeItem roleSkillTreeItem = this.RoleSkillTreeItem;
		if (roleSkillTreeItem != null)
		{
			roleSkillTreeItem.SelectSkillItem(skillItem, false);
		}
		this.UpdateSkillTreeInfo();
	}

	// Token: 0x06014B54 RID: 84820 RVA: 0x005BC07C File Offset: 0x005BA27C
	private void UpdateSkillTreeInfo()
	{
		RoleSkillTreeItem roleSkillTreeItem = this.RoleSkillTreeItem;
		RoleSkillTreeSkillItemBase roleSkillTreeSkillItemBase = (roleSkillTreeItem != null) ? roleSkillTreeItem.GetCurrentSelectedSkillItem() : null;
		if (roleSkillTreeSkillItemBase == null)
		{
			return;
		}
		ESkillTreeNodeType value = roleSkillTreeSkillItemBase.GetType().Value;
		if (value == ESkillTreeNodeType.OuterAttribute || value == ESkillTreeNodeType.OuterPassiveSkill)
		{
			this.UpdateTreeInfoItem();
			return;
		}
		int roleId = roleSkillTreeSkillItemBase.GetRoleId();
		int upgradeSkillId = roleSkillTreeSkillItemBase.GetUpgradeSkillId();
		int skillId = (upgradeSkillId > 0) ? upgradeSkillId : roleSkillTreeSkillItemBase.GetSkillId();
		ControllerBase<RoleController>.Instance.SendRoleSkillViewRequest(roleId, skillId, new Action(this.UpdateTreeInfoItem));
	}

	// Token: 0x06014B55 RID: 84821 RVA: 0x005BC0F8 File Offset: 0x005BA2F8
	private void UpdateTreeInfoItem()
	{
		RoleSkillTreeItem roleSkillTreeItem = this.RoleSkillTreeItem;
		RoleSkillTreeSkillItemBase roleSkillTreeSkillItemBase = (roleSkillTreeItem != null) ? roleSkillTreeItem.GetCurrentSelectedSkillItem() : null;
		if (roleSkillTreeSkillItemBase == null)
		{
			return;
		}
		int skillNodeId = roleSkillTreeSkillItemBase.GetSkillNodeId();
		this.RoleSkillTreeInfoItemData.SkillNodeId = skillNodeId;
		this.RoleSkillTreeInfoItem.Update(this.RoleSkillTreeInfoItemData);
		this.RoleSkillTreeInfoItem.ShowLeftPanelByTabType(this.RoleSkillTreeInfoItem.GetCurSkillTabShowType());
	}

	// Token: 0x06014B56 RID: 84822 RVA: 0x005BC156 File Offset: 0x005BA356
	private void OnSkillNodeLevelUp(int nodeId)
	{
		RoleSkillTreeItem roleSkillTreeItem = this.RoleSkillTreeItem;
		if (roleSkillTreeItem != null)
		{
			roleSkillTreeItem.OnSkillNodeLevelUp(nodeId);
		}
		this.UpdateSkillTreeInfo();
	}

	// Token: 0x06014B57 RID: 84823 RVA: 0x005BC170 File Offset: 0x005BA370
	private void OnAddCommonItemList(IReadOnlyList<IProto_NormalItem> _)
	{
		RoleSkillTreeItem roleSkillTreeItem = this.RoleSkillTreeItem;
		if (roleSkillTreeItem == null)
		{
			return;
		}
		roleSkillTreeItem.OnAddCommonItemList();
	}

	// Token: 0x06014B58 RID: 84824 RVA: 0x005BC182 File Offset: 0x005BA382
	private void OnCommonItemCountAnyChange(int i, int i1)
	{
		RoleSkillTreeInfoItem roleSkillTreeInfoItem = this.RoleSkillTreeInfoItem;
		if (roleSkillTreeInfoItem == null)
		{
			return;
		}
		roleSkillTreeInfoItem.OnCommonItemCountAnyChange();
	}

	// Token: 0x06014B59 RID: 84825 RVA: 0x005BC194 File Offset: 0x005BA394
	private void OnRoleSkillBranchChanged(int i)
	{
		RoleSkillTreeItem roleSkillTreeItem = this.RoleSkillTreeItem;
		if (roleSkillTreeItem != null)
		{
			roleSkillTreeItem.OnRoleSkillBranchChanged();
		}
		this.UpdateSkillTreeInfo();
	}

	// Token: 0x06014B5A RID: 84826 RVA: 0x005BC1AD File Offset: 0x005BA3AD
	private void OnRoleSkillInputPanelVisible(bool visible)
	{
		RoleSkillTreeItem roleSkillTreeItem = this.RoleSkillTreeItem;
		if (roleSkillTreeItem == null)
		{
			return;
		}
		roleSkillTreeItem.SetSkillBranchVisible(ESkillBranchInvisibleReason.SkillInputPanel, !visible);
	}

	// Token: 0x06014B5B RID: 84827 RVA: 0x005BC1C4 File Offset: 0x005BA3C4
	private void OnSkillShowTagToggleChanged(bool isVisible)
	{
		RoleSkillTreeItem roleSkillTreeItem = this.RoleSkillTreeItem;
		if (roleSkillTreeItem == null)
		{
			return;
		}
		roleSkillTreeItem.RefreshAllShowTags();
	}

	// Token: 0x04009FA8 RID: 40872
	[Nullable(2)]
	private RoleSkillTreeItem RoleSkillTreeItem;

	// Token: 0x04009FA9 RID: 40873
	[Nullable(2)]
	private RoleSkillTreeInfoItem RoleSkillTreeInfoItem;

	// Token: 0x04009FAA RID: 40874
	private readonly RoleSkillTreeItemData RoleSkillTreeItemData = new RoleSkillTreeItemData();

	// Token: 0x04009FAB RID: 40875
	private readonly IRoleSkillTreeInfoItemData RoleSkillTreeInfoItemData = new RoleSkillTreeInfoItemData();

	// Token: 0x04009FAC RID: 40876
	private int WaitToSelectNodeIndex = -1;

	// Token: 0x02008C0D RID: 35853
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402F2D6 RID: 193238
		RoleSkillTreeItem,
		// Token: 0x0402F2D7 RID: 193239
		RoleSkillTreeInfoItem,
		// Token: 0x0402F2D8 RID: 193240
		CaptionItem
	}
}
