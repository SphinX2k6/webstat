using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F54 RID: 8020
[NullableContext(1)]
[Nullable(0)]
public class HonamiStorySellConfirmBoxView : UiViewBase
{
	// Token: 0x0600F011 RID: 61457 RVA: 0x00419664 File Offset: 0x00417864
	public HonamiStorySellConfirmBoxView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600F012 RID: 61458 RVA: 0x004196A0 File Offset: 0x004178A0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F013 RID: 61459 RVA: 0x00419790 File Offset: 0x00417990
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStorySellConfirmBoxView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStorySellConfirmBoxView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F014 RID: 61460 RVA: 0x004197D4 File Offset: 0x004179D4
	protected override void OnStart()
	{
		IHonamiStorySellConfirmBoxOpenParam honamiStorySellConfirmBoxOpenParam = (IHonamiStorySellConfirmBoxOpenParam)this.OpenParam;
		this.SellItemList = honamiStorySellConfirmBoxOpenParam.SellItemList;
		this.SellCallback = honamiStorySellConfirmBoxOpenParam.SellCallback;
	}

	// Token: 0x0600F015 RID: 61461 RVA: 0x00419805 File Offset: 0x00417A05
	protected override void OnBeforeShow()
	{
		this.RefreshView();
	}

	// Token: 0x0600F016 RID: 61462 RVA: 0x00419810 File Offset: 0x00417A10
	private void RefreshView()
	{
		List<IHonamiStoryItemSellItemInfo> list = new List<IHonamiStoryItemSellItemInfo>();
		int num = 0;
		Dictionary<HonamiStoryItemDataBase, int> dictionary = new Dictionary<HonamiStoryItemDataBase, int>();
		foreach (IHonamiStoryItemSellInfo honamiStoryItemSellInfo in this.SellItemList)
		{
			HonamiStoryItemDataBase itemData = honamiStoryItemSellInfo.ItemData;
			int num2;
			if (dictionary.TryGetValue(itemData, out num2))
			{
				dictionary[itemData] = num2 + 1;
			}
			else
			{
				dictionary[itemData] = 1;
			}
		}
		foreach (KeyValuePair<HonamiStoryItemDataBase, int> keyValuePair in dictionary)
		{
			HonamiStoryItemDataBase key = keyValuePair.Key;
			int value = keyValuePair.Value;
			list.Add(new HonamiStoryItemSellItemInfo
			{
				ItemData = key,
				Number = value
			});
			num += key.GetSellPrice() * value;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "HonamiStory_SumPriceConfirmText", new <>z__ReadOnlySingleElementList<object>(num.ToString()));
		this.LoopScrollView.RefreshByData(list, false, null, false);
	}

	// Token: 0x0600F017 RID: 61463 RVA: 0x00419938 File Offset: 0x00417B38
	private void OnClickConfirmButton(int _)
	{
		ControllerBase<HonamiStoryController>.Instance.RequestHonamiStorySellItem(this.SellItemList).ContinueWith(delegate(bool _)
		{
			this.SellCallback();
			base.CloseMe(null);
		});
	}

	// Token: 0x0600F018 RID: 61464 RVA: 0x0041995C File Offset: 0x00417B5C
	private void OnClickCancelButton(int _)
	{
		base.CloseMe(null);
	}

	// Token: 0x0600F019 RID: 61465 RVA: 0x00419965 File Offset: 0x00417B65
	private HonamiStorySellConfirmBoxItem OnGridProxyCreate()
	{
		return new HonamiStorySellConfirmBoxItem();
	}

	// Token: 0x04007363 RID: 29539
	private List<IHonamiStoryItemSellInfo> SellItemList = new List<IHonamiStoryItemSellInfo>();

	// Token: 0x04007364 RID: 29540
	private Action SellCallback = delegate()
	{
	};

	// Token: 0x04007365 RID: 29541
	[Nullable(2)]
	private ButtonItem ConfirmButton;

	// Token: 0x04007366 RID: 29542
	[Nullable(2)]
	private ButtonItem CancelButton;

	// Token: 0x04007367 RID: 29543
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<HonamiStorySellConfirmBoxItem, IHonamiStoryItemSellItemInfo> LoopScrollView;

	// Token: 0x020082DA RID: 33498
	[NullableContext(0)]
	private enum EHonamiSellConfirmComponents
	{
		// Token: 0x0402C5DE RID: 181726
		TextTitle,
		// Token: 0x0402C5DF RID: 181727
		ConfirmButton,
		// Token: 0x0402C5E0 RID: 181728
		LoopScrollView,
		// Token: 0x0402C5E1 RID: 181729
		ScrollItem,
		// Token: 0x0402C5E2 RID: 181730
		ConfirmText,
		// Token: 0x0402C5E3 RID: 181731
		CancelButton
	}
}
