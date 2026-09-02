using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02000FE8 RID: 4072
[NullableContext(1)]
[Nullable(0)]
public class AchievementRewardItemView : UiTickViewBase
{
	// Token: 0x06006911 RID: 26897 RVA: 0x001B6365 File Offset: 0x001B4565
	public AchievementRewardItemView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06006912 RID: 26898 RVA: 0x001B6384 File Offset: 0x001B4584
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILayoutBase));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06006913 RID: 26899 RVA: 0x001B640E File Offset: 0x001B460E
	protected override void OnStart()
	{
		this.Initialize();
		this.RefreshRewardItem();
	}

	// Token: 0x06006914 RID: 26900 RVA: 0x001B641C File Offset: 0x001B461C
	private ILayoutItem<CommonItemDropGrid> InitItem(object tempData, UUIItem uiItem, int index)
	{
		ItemRewardInfo itemRewardInfo = (ItemRewardInfo)tempData;
		CommonItemDropGrid commonItemDropGrid = new CommonItemDropGrid();
		commonItemDropGrid.Initialize(uiItem.GetOwner());
		this.PromiseList.Add(commonItemDropGrid.AsyncRefreshByItemInfo(itemRewardInfo.ItemId.Value, itemRewardInfo.ItemCount.Value, null));
		return new LayoutItem<CommonItemDropGrid>
		{
			Key = index,
			Value = commonItemDropGrid
		};
	}

	// Token: 0x06006915 RID: 26901 RVA: 0x001B648C File Offset: 0x001B468C
	private void Initialize()
	{
		this.RestTime = 0f;
		this.Layout = new GenericLayoutNew<CommonItemDropGrid>(base.GetLayoutBase(0), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<CommonItemDropGrid>(this.InitItem), base.GetItem(1));
		if (ModelBase<ItemHintModel>.Instance.IsAchievementItemRewardListEmpty)
		{
			return;
		}
		this.ItemRewardData = ModelBase<ItemHintModel>.Instance.ShiftAchievementItemRewardListFirst();
		this.ItemRewardInfoList = ControllerBase<ItemHintController>.Instance.CombineAllShowItems(this.ItemRewardData.ItemReward, true).ToList<ItemRewardInfo>();
		this.DropShowPlan = ControllerBase<ItemHintController>.Instance.GetFirstShowBgDropGroup(this.ItemRewardData.ItemReward);
		string title = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(this.ItemRewardData.ItemReward.DropId).Value.Title;
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), StringUtils.IsEmpty(title) ? "MiddleRequirementDefault" : title, Array.Empty<object>());
	}

	// Token: 0x06006916 RID: 26902 RVA: 0x001B6574 File Offset: 0x001B4774
	private void RefreshRewardItem()
	{
		this.PromiseList = new List<UniTask>();
		if (this.ItemRewardInfoList.Count <= 0)
		{
			this.RestTime = 0f;
			base.CloseMe(null);
			return;
		}
		base.SetUiActive(false);
		int count = Math.Min(this.ItemRewardInfoList.Count, 3);
		List<ItemRewardInfo> range = this.ItemRewardInfoList.GetRange(0, count);
		this.ItemRewardInfoList.RemoveRange(0, count);
		this.Layout.RebuildLayoutByDataNew<ItemRewardInfo>(range.ToArray(), null);
		UniTask.WhenAll(this.PromiseList).GetAwaiter().OnCompleted(delegate
		{
			base.SetUiActive(true);
		});
	}

	// Token: 0x06006917 RID: 26903 RVA: 0x001B6623 File Offset: 0x001B4823
	protected override void OnBeforeDestroy()
	{
		this.Layout.ClearChildren();
		this.ItemRewardData = null;
	}

	// Token: 0x06006918 RID: 26904 RVA: 0x001B6637 File Offset: 0x001B4837
	protected override void OnAfterPlayStartSequence()
	{
		this.SetResetTime();
	}

	// Token: 0x06006919 RID: 26905 RVA: 0x001B6640 File Offset: 0x001B4840
	protected unsafe void SetResetTime()
	{
		int showTime = this.DropShowPlan.Value.ShowTime;
		if (showTime < 20)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ItemHint;
			ELogAuthor author = ELogAuthor.LJQ;
			string message = "AchievementRewardItemView ShowTime 小于100";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("DropGroupId", this.DropShowPlan.Value.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ShowTime", showTime);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		this.RestTime = (float)showTime;
	}

	// Token: 0x0600691A RID: 26906 RVA: 0x001B66E0 File Offset: 0x001B48E0
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

	// Token: 0x040031F0 RID: 12784
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayoutNew<CommonItemDropGrid> Layout;

	// Token: 0x040031F1 RID: 12785
	[Nullable(2)]
	private ItemRewardData ItemRewardData;

	// Token: 0x040031F2 RID: 12786
	private DropShowPlan? DropShowPlan;

	// Token: 0x040031F3 RID: 12787
	private float RestTime = -1f;

	// Token: 0x040031F4 RID: 12788
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<ItemRewardInfo> ItemRewardInfoList;

	// Token: 0x040031F5 RID: 12789
	private List<UniTask> PromiseList = new List<UniTask>();

	// Token: 0x040031F6 RID: 12790
	private const int MAX_LENGTH = 3;

	// Token: 0x040031F7 RID: 12791
	public float TickDelta;

	// Token: 0x020073C6 RID: 29638
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x040280EE RID: 164078
		ItemHorizontal,
		// Token: 0x040280EF RID: 164079
		SourceItemGrid,
		// Token: 0x040280F0 RID: 164080
		TxtTitle
	}
}
