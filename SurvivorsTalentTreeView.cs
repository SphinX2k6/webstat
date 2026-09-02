using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002B5C RID: 11100
[NullableContext(2)]
[Nullable(0)]
public class SurvivorsTalentTreeView : UiViewBase
{
	// Token: 0x0601620D RID: 90637 RVA: 0x006242C7 File Offset: 0x006224C7
	[NullableContext(1)]
	public SurvivorsTalentTreeView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601620E RID: 90638 RVA: 0x006242D0 File Offset: 0x006224D0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x0601620F RID: 90639 RVA: 0x00624358 File Offset: 0x00622558
	protected override UniTask OnBeforeStartAsync()
	{
		SurvivorsTalentTreeView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SurvivorsTalentTreeView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06016210 RID: 90640 RVA: 0x0062439B File Offset: 0x0062259B
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.SurvivorsRogueTalentNodeUpdate, new Action<int>(this.OnTalentNodeUpdate));
	}

	// Token: 0x06016211 RID: 90641 RVA: 0x006243B9 File Offset: 0x006225B9
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.SurvivorsRogueTalentNodeUpdate, new Action<int>(this.OnTalentNodeUpdate));
	}

	// Token: 0x06016212 RID: 90642 RVA: 0x006243D8 File Offset: 0x006225D8
	private void OnTalentNodeUpdate(int selectNodeId)
	{
		SurvivorsTalentTreeView.<>c__DisplayClass13_0 CS$<>8__locals1 = new SurvivorsTalentTreeView.<>c__DisplayClass13_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.selectNodeId = selectNodeId;
		new UiAsyncTask("TalentNodeUpdate", delegate()
		{
			SurvivorsTalentTreeView.<>c__DisplayClass13_0.<<OnTalentNodeUpdate>b__0>d <<OnTalentNodeUpdate>b__0>d;
			<<OnTalentNodeUpdate>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<OnTalentNodeUpdate>b__0>d.<>4__this = CS$<>8__locals1;
			<<OnTalentNodeUpdate>b__0>d.<>1__state = -1;
			<<OnTalentNodeUpdate>b__0>d.<>t__builder.Start<SurvivorsTalentTreeView.<>c__DisplayClass13_0.<<OnTalentNodeUpdate>b__0>d>(ref <<OnTalentNodeUpdate>b__0>d);
			return <<OnTalentNodeUpdate>b__0>d.<>t__builder.Task;
		}, null).Run();
	}

	// Token: 0x06016213 RID: 90643 RVA: 0x00624418 File Offset: 0x00622618
	private UniTask OnNodeUpdateAsync(int selectNodeId)
	{
		SurvivorsTalentTreeView.<OnNodeUpdateAsync>d__14 <OnNodeUpdateAsync>d__;
		<OnNodeUpdateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnNodeUpdateAsync>d__.<>4__this = this;
		<OnNodeUpdateAsync>d__.selectNodeId = selectNodeId;
		<OnNodeUpdateAsync>d__.<>1__state = -1;
		<OnNodeUpdateAsync>d__.<>t__builder.Start<SurvivorsTalentTreeView.<OnNodeUpdateAsync>d__14>(ref <OnNodeUpdateAsync>d__);
		return <OnNodeUpdateAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06016214 RID: 90644 RVA: 0x00624463 File Offset: 0x00622663
	protected override void OnBeforeShow()
	{
		ControllerBase<SurvivorsActivityController>.Instance.CheckIsActivityClose();
	}

	// Token: 0x06016215 RID: 90645 RVA: 0x00624470 File Offset: 0x00622670
	private void OnAfterRefreshOneNode(SurvivorsTalentTreeSkillNodeItem nodeItem)
	{
		SurvivorsActivityData activityData = ModelBase<SurvivorsRogueModel>.Instance.ActivityData;
		if (activityData == null)
		{
			return;
		}
		if (nodeItem == null || nodeItem.Node == null)
		{
			return;
		}
		nodeItem.OnClickToggleBack = new Action<SurvivorsTalentNode, UUIExtendToggle>(this.OnClickNode);
		if (activityData.CurrentSelectNode.NodeId == this.FirstNodeItem.Node.NodeId && this.CurSelectNodeItem == null)
		{
			this.CurSelectNodeItem = this.FirstNodeItem;
			this.CurSelectNodeItem.SelectNode();
			return;
		}
		if (activityData.CurrentSelectNode.NodeId == nodeItem.Node.NodeId)
		{
			UUIItem itemByIndex = this.AreaScroll.GetItemByIndex(nodeItem.Node.AreaId - 1);
			if (itemByIndex != null)
			{
				this.AreaScroll.LateScrollTo(itemByIndex, null, false);
			}
			this.CurSelectNodeItem = nodeItem;
			this.CurSelectNodeItem.SelectNode();
		}
	}

	// Token: 0x06016216 RID: 90646 RVA: 0x0062453C File Offset: 0x0062273C
	[NullableContext(1)]
	private void OnClickNode(SurvivorsTalentNode node, UUIExtendToggle toggle)
	{
		SurvivorsTalentTreeView.<>c__DisplayClass17_0 CS$<>8__locals1 = new SurvivorsTalentTreeView.<>c__DisplayClass17_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.node = node;
		if (this.CurrentSelectToggle != null)
		{
			this.CurrentSelectToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.CurrentSelectToggle = toggle;
		this.CurrentSelectToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
		ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(this.CurrentSelectToggle.RootUIComp, false, false, false);
		this.SeqPlayer.StopSequenceByKey("Switch", false, false);
		this.SeqPlayer.PlayLevelSequenceByName("Switch", false, null, false);
		new UiAsyncTask("RefreshSkillInfo", delegate()
		{
			SurvivorsTalentTreeView.<>c__DisplayClass17_0.<<OnClickNode>b__0>d <<OnClickNode>b__0>d;
			<<OnClickNode>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<OnClickNode>b__0>d.<>4__this = CS$<>8__locals1;
			<<OnClickNode>b__0>d.<>1__state = -1;
			<<OnClickNode>b__0>d.<>t__builder.Start<SurvivorsTalentTreeView.<>c__DisplayClass17_0.<<OnClickNode>b__0>d>(ref <<OnClickNode>b__0>d);
			return <<OnClickNode>b__0>d.<>t__builder.Task;
		}, null).Run();
	}

	// Token: 0x06016217 RID: 90647 RVA: 0x006245F4 File Offset: 0x006227F4
	[NullableContext(1)]
	private SurvivorsTalentTreeAreaItem InitAreaItem()
	{
		return new SurvivorsTalentTreeAreaItem
		{
			OnAfterRefreshOneNode = new Action<SurvivorsTalentTreeSkillNodeItem>(this.OnAfterRefreshOneNode)
		};
	}

	// Token: 0x06016218 RID: 90648 RVA: 0x00624610 File Offset: 0x00622810
	private void OnClickHelpBtn()
	{
		int helpId = ModelBase<SurvivorsRogueModel>.Instance.GetRogueActivityConfig().Value.HelpId;
		ControllerBase<HelpController>.Instance.OpenHelpById(helpId);
	}

	// Token: 0x06016219 RID: 90649 RVA: 0x00624643 File Offset: 0x00622843
	private void OnClickCloseBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x0400AADD RID: 43741
	private const int TALENT_TREE_COST_ITEM_ID = 80400003;

	// Token: 0x0400AADE RID: 43742
	private SurvivorsTalentTreeSkillNodeItem CurSelectNodeItem;

	// Token: 0x0400AADF RID: 43743
	private SurvivorsTalentTreeSkillNodeItem FirstNodeItem;

	// Token: 0x0400AAE0 RID: 43744
	[Nullable(1)]
	private GenericScrollViewNew<SurvivorsTalentTreeAreaItem, SurvivorsTalentAreaData> AreaScroll;

	// Token: 0x0400AAE1 RID: 43745
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400AAE2 RID: 43746
	private SurvivorsTalentTreeSkillInfoPanel SkillInfoPanel;

	// Token: 0x0400AAE3 RID: 43747
	private UUIExtendToggle CurrentSelectToggle;

	// Token: 0x0400AAE4 RID: 43748
	[Nullable(1)]
	private LevelSequencePlayer SeqPlayer;
}
