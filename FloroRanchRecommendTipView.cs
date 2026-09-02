using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C40 RID: 7232
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchRecommendTipView : UiViewBase
{
	// Token: 0x0600D2D4 RID: 53972 RVA: 0x00381815 File Offset: 0x0037FA15
	public FloroRanchRecommendTipView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600D2D5 RID: 53973 RVA: 0x0038183C File Offset: 0x0037FA3C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickCloseButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D2D6 RID: 53974 RVA: 0x00381924 File Offset: 0x0037FB24
	protected override UniTask OnBeforeStartAsync()
	{
		FloroRanchRecommendTipView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FloroRanchRecommendTipView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D2D7 RID: 53975 RVA: 0x00381968 File Offset: 0x0037FB68
	private UniTask CreateRecommendItem(FloroRanchUnlockDataBase data)
	{
		FloroRanchRecommendTipView.<CreateRecommendItem>d__9 <CreateRecommendItem>d__;
		<CreateRecommendItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateRecommendItem>d__.<>4__this = this;
		<CreateRecommendItem>d__.data = data;
		<CreateRecommendItem>d__.<>1__state = -1;
		<CreateRecommendItem>d__.<>t__builder.Start<FloroRanchRecommendTipView.<CreateRecommendItem>d__9>(ref <CreateRecommendItem>d__);
		return <CreateRecommendItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600D2D8 RID: 53976 RVA: 0x003819B4 File Offset: 0x0037FBB4
	private UniTask RefreshRecommendViewAsync()
	{
		FloroRanchRecommendTipView.<RefreshRecommendViewAsync>d__10 <RefreshRecommendViewAsync>d__;
		<RefreshRecommendViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshRecommendViewAsync>d__.<>4__this = this;
		<RefreshRecommendViewAsync>d__.<>1__state = -1;
		<RefreshRecommendViewAsync>d__.<>t__builder.Start<FloroRanchRecommendTipView.<RefreshRecommendViewAsync>d__10>(ref <RefreshRecommendViewAsync>d__);
		return <RefreshRecommendViewAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D2D9 RID: 53977 RVA: 0x003819F8 File Offset: 0x0037FBF8
	private void SetRecommendSlotItemsAlphaVisible()
	{
		foreach (FloroRanchHandBookSmallSlotItem floroRanchHandBookSmallSlotItem in this.RecommendItemList)
		{
			floroRanchHandBookSmallSlotItem.GetRootItem().SetAlpha(1f);
		}
	}

	// Token: 0x0600D2DA RID: 53978 RVA: 0x00381A54 File Offset: 0x0037FC54
	private void OnClickRecommendItem(FloroRanchHandBookSmallSlotItem item)
	{
		int num = this.RecommendItemList.IndexOf(item);
		if (num < 0)
		{
			return;
		}
		this.ShowRecommendTip(num);
	}

	// Token: 0x0600D2DB RID: 53979 RVA: 0x00381A7C File Offset: 0x0037FC7C
	private void HideRecommendTip()
	{
		if (this.CurSelectIndex < 0)
		{
			return;
		}
		FloroRanchHandBookSmallSlotItem floroRanchHandBookSmallSlotItem = this.RecommendItemList[this.CurSelectIndex];
		if (floroRanchHandBookSmallSlotItem != null)
		{
			floroRanchHandBookSmallSlotItem.OnDeselected(true);
		}
	}

	// Token: 0x0600D2DC RID: 53980 RVA: 0x00381AB0 File Offset: 0x0037FCB0
	private void ShowRecommendTip(int index)
	{
		if (index < 0 || index >= this.RefreshDataList.Count)
		{
			return;
		}
		this.HideRecommendTip();
		this.CurSelectIndex = index;
		FloroRanchHandBookSmallSlotItem floroRanchHandBookSmallSlotItem = this.RecommendItemList[index];
		if (floroRanchHandBookSmallSlotItem != null)
		{
			floroRanchHandBookSmallSlotItem.OnSelected(true);
		}
		FloroRanchUnlockDataBase data = this.RefreshDataList[index];
		FloroRanchCommonTipParam floroRanchCommonTipParam = this.BuildTipParam(data);
		if (floroRanchCommonTipParam == null)
		{
			return;
		}
		this.RecommendTipItem.RefreshInfoTipByParam(floroRanchCommonTipParam);
	}

	// Token: 0x0600D2DD RID: 53981 RVA: 0x00381B1C File Offset: 0x0037FD1C
	[return: Nullable(2)]
	private FloroRanchCommonTipParam BuildTipParam(FloroRanchUnlockDataBase data)
	{
		FloroRanchUnlockCardData floroRanchUnlockCardData = data as FloroRanchUnlockCardData;
		if (floroRanchUnlockCardData != null)
		{
			return new FloroRanchCommonTipParam
			{
				TipType = EFloroRanchCommonTipType.Card,
				CardData = floroRanchUnlockCardData.GetCardData()
			};
		}
		FloroRanchUnlockToyData floroRanchUnlockToyData = data as FloroRanchUnlockToyData;
		if (floroRanchUnlockToyData != null)
		{
			return new FloroRanchCommonTipParam
			{
				TipType = EFloroRanchCommonTipType.Toy,
				ToyData = floroRanchUnlockToyData.GetToyData()
			};
		}
		return null;
	}

	// Token: 0x0600D2DE RID: 53982 RVA: 0x00381B70 File Offset: 0x0037FD70
	private void OnClickCloseButton()
	{
		base.CloseMe(null);
		this.CurSelectIndex = -1;
	}

	// Token: 0x04006470 RID: 25712
	private readonly List<FloroRanchHandBookSmallSlotItem> RecommendItemList = new List<FloroRanchHandBookSmallSlotItem>();

	// Token: 0x04006471 RID: 25713
	private readonly List<FloroRanchUnlockDataBase> RefreshDataList = new List<FloroRanchUnlockDataBase>();

	// Token: 0x04006472 RID: 25714
	private int CurSelectIndex = -1;

	// Token: 0x04006473 RID: 25715
	private FloroRanchCommonTipItem RecommendTipItem;

	// Token: 0x04006474 RID: 25716
	private EFloroRanchActivityDataType ActivityDataType;

	// Token: 0x02007F44 RID: 32580
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402B510 RID: 177424
		public const int CloseButton = 0;

		// Token: 0x0402B511 RID: 177425
		public const int RecommendTipItem = 1;

		// Token: 0x0402B512 RID: 177426
		public const int RecommendLayout = 2;

		// Token: 0x0402B513 RID: 177427
		public const int RecommendItemTemplate = 3;
	}
}
