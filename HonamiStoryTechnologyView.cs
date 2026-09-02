using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F59 RID: 8025
[NullableContext(2)]
[Nullable(0)]
public class HonamiStoryTechnologyView : UiViewBase
{
	// Token: 0x0600F032 RID: 61490 RVA: 0x0041A066 File Offset: 0x00418266
	[NullableContext(1)]
	public HonamiStoryTechnologyView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600F033 RID: 61491 RVA: 0x0041A078 File Offset: 0x00418278
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F034 RID: 61492 RVA: 0x0041A188 File Offset: 0x00418388
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStoryTechnologyView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryTechnologyView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F035 RID: 61493 RVA: 0x0041A1CC File Offset: 0x004183CC
	private void OnAfterRefreshOneNode(HonamiStoryTechnologyNodeItem nodeItem)
	{
		if (nodeItem == null)
		{
			return;
		}
		if (nodeItem.OnClickToggleBack == null)
		{
			nodeItem.OnClickToggleBack = new Action<HonamiStoryTechnologyNodeItem, HonamiStoryTechNodeData, UUIExtendToggle>(this.OnClickItem);
		}
		if (this.IsInitSelect)
		{
			return;
		}
		if (this.InitSelectNodeId == this.FirstTreeNode.GetNodeDataConfig().Id)
		{
			this.FirstTreeNode.SelectNode();
			ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(this.FirstTreeNode.ToggleItem.RootUIComp, true, true, false);
			this.IsInitSelect = true;
			return;
		}
		if (this.InitSelectNodeId == nodeItem.GetNodeDataConfig().Id)
		{
			nodeItem.SelectNode();
			ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(nodeItem.ToggleItem.RootUIComp, true, true, false);
			UUIItem itemByIndex = this.PnlNodeList.GetItemByIndex(nodeItem.GetNodeDataConfig().Area - 1);
			if (itemByIndex != null)
			{
				this.PnlNodeList.LateScrollTo(itemByIndex, null, false);
			}
			this.IsInitSelect = true;
		}
	}

	// Token: 0x0600F036 RID: 61494 RVA: 0x0041A2BF File Offset: 0x004184BF
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnHonamiStoryTechNodeLevelUpdate, new Action(this.OnTechNodeUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.PlotNetworkEnd, new Action<PlotResultInfo>(this.OnPlotEnd));
	}

	// Token: 0x0600F037 RID: 61495 RVA: 0x0041A2F9 File Offset: 0x004184F9
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHonamiStoryTechNodeLevelUpdate, new Action(this.OnTechNodeUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.PlotNetworkEnd, new Action<PlotResultInfo>(this.OnPlotEnd));
	}

	// Token: 0x0600F038 RID: 61496 RVA: 0x0041A334 File Offset: 0x00418534
	private void OnTechNodeUpdate()
	{
		new UiAsyncTask("TechNodeUpdate", delegate()
		{
			HonamiStoryTechnologyView.<<OnTechNodeUpdate>b__16_0>d <<OnTechNodeUpdate>b__16_0>d;
			<<OnTechNodeUpdate>b__16_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<OnTechNodeUpdate>b__16_0>d.<>4__this = this;
			<<OnTechNodeUpdate>b__16_0>d.<>1__state = -1;
			<<OnTechNodeUpdate>b__16_0>d.<>t__builder.Start<HonamiStoryTechnologyView.<<OnTechNodeUpdate>b__16_0>d>(ref <<OnTechNodeUpdate>b__16_0>d);
			return <<OnTechNodeUpdate>b__16_0>d.<>t__builder.Task;
		}, null).Run();
		if (this.BoZaiTalk != null)
		{
			HonamiStoryOutDialog? randomDialogData = ModelBase<HonamiStoryModel>.Instance.GetRandomDialogData(5);
			this.BoZaiTalk.SetTalkInfoTextAndPlayAudio(randomDialogData);
		}
	}

	// Token: 0x0600F039 RID: 61497 RVA: 0x0041A380 File Offset: 0x00418580
	private UniTask OnNodeUpdateAsync()
	{
		HonamiStoryTechnologyView.<OnNodeUpdateAsync>d__17 <OnNodeUpdateAsync>d__;
		<OnNodeUpdateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnNodeUpdateAsync>d__.<>4__this = this;
		<OnNodeUpdateAsync>d__.<>1__state = -1;
		<OnNodeUpdateAsync>d__.<>t__builder.Start<HonamiStoryTechnologyView.<OnNodeUpdateAsync>d__17>(ref <OnNodeUpdateAsync>d__);
		return <OnNodeUpdateAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F03A RID: 61498 RVA: 0x0041A3C3 File Offset: 0x004185C3
	[NullableContext(1)]
	private HonamiStoryTechnologyAreaItem InitAreaItem()
	{
		return new HonamiStoryTechnologyAreaItem
		{
			OnAfterRefreshOneNode = new Action<HonamiStoryTechnologyNodeItem>(this.OnAfterRefreshOneNode)
		};
	}

	// Token: 0x0600F03B RID: 61499 RVA: 0x0041A3DC File Offset: 0x004185DC
	[NullableContext(1)]
	private void OnClickItem(HonamiStoryTechnologyNodeItem node, HonamiStoryTechNodeData data, UUIExtendToggle toggle)
	{
		if (this.CurrentSelectToggle != null && this.CurrentSelectToggle != toggle)
		{
			this.CurrentSelectToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.CurrentSelectToggle = toggle;
		ModelBase<HonamiStoryModel>.Instance.CurrentSelectNode = data;
		ModelBase<HonamiStoryModel>.Instance.CurrentSelectNodeItem = node;
		this.PnlTechnologyInfo.Refresh(data);
	}

	// Token: 0x0600F03C RID: 61500 RVA: 0x0041A433 File Offset: 0x00418633
	private void OnClickCloseBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600F03D RID: 61501 RVA: 0x0041A43C File Offset: 0x0041863C
	[NullableContext(1)]
	private void OnPlotEnd(PlotResultInfo plotResult)
	{
		HonamiStoryModel instance = ModelBase<HonamiStoryModel>.Instance;
		if (instance.CurrentSelectNode != null && instance.CurrentSelectNode.GetConfig.Type == 1)
		{
			Singleton<UiManager>.Instance.ResetToBattleView(null);
		}
	}

	// Token: 0x04007372 RID: 29554
	private const int COST_ITEM_ID = 80600001;

	// Token: 0x04007373 RID: 29555
	private PopupCaptionItem CaptionItem;

	// Token: 0x04007374 RID: 29556
	private HonamiStoryTechnologyNodeItem FirstTreeNode;

	// Token: 0x04007375 RID: 29557
	[Nullable(1)]
	private GenericScrollViewNew<HonamiStoryTechnologyAreaItem, HonamiStoryTechAreaData> PnlNodeList;

	// Token: 0x04007376 RID: 29558
	private HonamiStoryTechnologyInfoPanel PnlTechnologyInfo;

	// Token: 0x04007377 RID: 29559
	private UUIExtendToggle CurrentSelectToggle;

	// Token: 0x04007378 RID: 29560
	private HonamiStoryBozaiTalkPanel BoZaiTalk;

	// Token: 0x04007379 RID: 29561
	private bool IsInitSelect;

	// Token: 0x0400737A RID: 29562
	private int InitSelectNodeId = -1;

	// Token: 0x020082E1 RID: 33505
	[NullableContext(0)]
	private enum EHonamiStoryTechnologyComponent
	{
		// Token: 0x0402C5FD RID: 181757
		FirstTreeNode,
		// Token: 0x0402C5FE RID: 181758
		PnlTechnologyGrid,
		// Token: 0x0402C5FF RID: 181759
		PnlTechnologyInfo,
		// Token: 0x0402C600 RID: 181760
		SvTreeInfo,
		// Token: 0x0402C601 RID: 181761
		ContentRootNode,
		// Token: 0x0402C602 RID: 181762
		CaptionItem,
		// Token: 0x0402C603 RID: 181763
		BoZaiTalkPanel
	}
}
