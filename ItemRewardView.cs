using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02002065 RID: 8293
[NullableContext(1)]
[Nullable(0)]
public class ItemRewardView : UiTickViewBase
{
	// Token: 0x0600FCDE RID: 64734 RVA: 0x00456887 File Offset: 0x00454A87
	public ItemRewardView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600FCDF RID: 64735 RVA: 0x004568A8 File Offset: 0x00454AA8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(0, typeof(UUILayoutBase)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x0600FCE0 RID: 64736 RVA: 0x00456902 File Offset: 0x00454B02
	protected override void OnStart()
	{
		this.Initialize();
		this.RefreshRewardItem();
	}

	// Token: 0x0600FCE1 RID: 64737 RVA: 0x00456910 File Offset: 0x00454B10
	private ILayoutItem<CommonItemDropGrid> InitItem(object tempData, UUIItem uiItem, int index)
	{
		ItemRewardInfo itemRewardInfo = tempData as ItemRewardInfo;
		CommonItemDropGrid commonItemDropGrid = new CommonItemDropGrid();
		commonItemDropGrid.Initialize(uiItem.GetOwner());
		this.PromiseList.Add(commonItemDropGrid.AsyncRefreshByItemInfo(itemRewardInfo.ItemId.Value, itemRewardInfo.ItemCount.Value, null));
		return new LayoutItem<CommonItemDropGrid>
		{
			Key = index,
			Value = commonItemDropGrid
		};
	}

	// Token: 0x0600FCE2 RID: 64738 RVA: 0x00456980 File Offset: 0x00454B80
	private void Initialize()
	{
		this.RestTime = 0f;
		this.Layout = new GenericLayoutNew<CommonItemDropGrid>(base.GetLayoutBase(0), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<CommonItemDropGrid>(this.InitItem), base.GetItem(1));
		this.OpenNormal(true);
		if (ModelBase<ItemHintModel>.Instance.IsItemRewardListEmpty)
		{
			return;
		}
		this.ItemRewardData = ModelBase<ItemHintModel>.Instance.ShiftItemRewardListFirst();
		this.ItemRewardInfoList = ControllerBase<ItemHintController>.Instance.CombineAllShowItems(this.ItemRewardData.ItemReward, true);
		this.DropShowPlan = ControllerBase<ItemHintController>.Instance.GetFirstShowBgDropGroup(this.ItemRewardData.ItemReward);
		string title = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(this.ItemRewardData.ItemReward.DropId).Value.Title;
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), StringUtils.IsEmpty(title) ? "MiddleRequirementDefault" : title, Array.Empty<object>());
	}

	// Token: 0x0600FCE3 RID: 64739 RVA: 0x00456A6C File Offset: 0x00454C6C
	private void RefreshRewardItem()
	{
		this.PromiseList.Clear();
		if (this.ItemRewardInfoList.Length == 0)
		{
			this.RestTime = 0f;
			base.CloseMe(null);
			return;
		}
		base.SetUiActive(false);
		int num = Math.Min(this.ItemRewardInfoList.Length, 3);
		ItemRewardInfo[] array = new ItemRewardInfo[num];
		Array.Copy(this.ItemRewardInfoList, 0, array, 0, num);
		int num2 = this.ItemRewardInfoList.Length - num;
		ItemRewardInfo[] array2 = new ItemRewardInfo[num2];
		Array.Copy(this.ItemRewardInfoList, num, array2, 0, num2);
		this.ItemRewardInfoList = array2;
		this.Layout.RebuildLayoutByDataNew<ItemRewardInfo>(array, null);
		UniTask.WhenAll(this.PromiseList).ContinueWith(delegate()
		{
			base.SetUiActive(true);
		});
	}

	// Token: 0x0600FCE4 RID: 64740 RVA: 0x00456B27 File Offset: 0x00454D27
	protected override void OnBeforeDestroy()
	{
		this.OpenNormal(false);
		this.Layout.ClearChildren();
		this.ItemRewardData = null;
	}

	// Token: 0x0600FCE5 RID: 64741 RVA: 0x00456B42 File Offset: 0x00454D42
	private void OpenNormal(bool isOpen)
	{
		if (this.ViewInfo.Name == EUiViewName.ItemRewardView)
		{
			return;
		}
		Singleton<UiLayer>.Instance.SetShowNormalMaskLayer(isOpen, "");
	}

	// Token: 0x0600FCE6 RID: 64742 RVA: 0x00456B6C File Offset: 0x00454D6C
	protected override void OnAfterPlayStartSequence()
	{
		this.SetResetTime();
	}

	// Token: 0x0600FCE7 RID: 64743 RVA: 0x00456B74 File Offset: 0x00454D74
	protected unsafe void SetResetTime()
	{
		int showTime = this.DropShowPlan.Value.ShowTime;
		if (showTime < 20)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ItemHint;
			ELogAuthor author = ELogAuthor.ZJC;
			string message = "ItemRewardView ShowTime 小于100";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("DropGroupId", this.DropShowPlan.Value.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ShowTime", showTime);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		this.RestTime = (float)showTime;
	}

	// Token: 0x0600FCE8 RID: 64744 RVA: 0x00456C10 File Offset: 0x00454E10
	protected override void OnTick(float delta)
	{
		if (this.RestTime <= 0f)
		{
			return;
		}
		this.TickDelta += delta;
		if (this.TickDelta >= this.RestTime)
		{
			this.TickDelta = 0f;
			this.RestTime = 0f;
			this.SetResetTime();
			this.RefreshRewardItem();
		}
	}

	// Token: 0x04007941 RID: 31041
	private const int MAX_LENGTH = 3;

	// Token: 0x04007942 RID: 31042
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayoutNew<CommonItemDropGrid> Layout;

	// Token: 0x04007943 RID: 31043
	[Nullable(2)]
	private ItemRewardData ItemRewardData;

	// Token: 0x04007944 RID: 31044
	private DropShowPlan? DropShowPlan;

	// Token: 0x04007945 RID: 31045
	private float RestTime = -1f;

	// Token: 0x04007946 RID: 31046
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ItemRewardInfo[] ItemRewardInfoList;

	// Token: 0x04007947 RID: 31047
	private List<UniTask> PromiseList = new List<UniTask>();

	// Token: 0x04007948 RID: 31048
	public float TickDelta;

	// Token: 0x02008401 RID: 33793
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402CBE5 RID: 183269
		ItemHorizontal,
		// Token: 0x0402CBE6 RID: 183270
		SourceItemGrid,
		// Token: 0x0402CBE7 RID: 183271
		TxtTitle
	}
}
