using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C42 RID: 7234
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchShopTipView : UiViewBase
{
	// Token: 0x0600D2DF RID: 53983 RVA: 0x00381B80 File Offset: 0x0037FD80
	public FloroRanchShopTipView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600D2E0 RID: 53984 RVA: 0x00381BF0 File Offset: 0x0037FDF0
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

	// Token: 0x0600D2E1 RID: 53985 RVA: 0x00381CD8 File Offset: 0x0037FED8
	protected override UniTask OnBeforeStartAsync()
	{
		FloroRanchShopTipView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FloroRanchShopTipView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D2E2 RID: 53986 RVA: 0x00381D1C File Offset: 0x0037FF1C
	protected override void OnBeforeShow()
	{
		if (this.OpenParam == null)
		{
			return;
		}
		FloroRanchShopTipViewParam floroRanchShopTipViewParam = (FloroRanchShopTipViewParam)this.OpenParam;
		int toyPoint = floroRanchShopTipViewParam.ToyPoint;
		this.SellCallback = floroRanchShopTipViewParam.SellCallback;
		this.ShowToyListCallback = floroRanchShopTipViewParam.ShowToyListCallback;
		if (this.SellCallback == null || this.ShowToyListCallback == null)
		{
			return;
		}
		this.ShowToyListCallback(false);
		this.RefreshToyView();
		this.ShowToyTip(toyPoint);
	}

	// Token: 0x0600D2E3 RID: 53987 RVA: 0x00381D87 File Offset: 0x0037FF87
	protected override void OnBeforeHide()
	{
		this.ShowToyListCallback(true);
	}

	// Token: 0x0600D2E4 RID: 53988 RVA: 0x00381D98 File Offset: 0x0037FF98
	private UniTask CreateToyItem()
	{
		FloroRanchShopTipView.<CreateToyItem>d__11 <CreateToyItem>d__;
		<CreateToyItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateToyItem>d__.<>4__this = this;
		<CreateToyItem>d__.<>1__state = -1;
		<CreateToyItem>d__.<>t__builder.Start<FloroRanchShopTipView.<CreateToyItem>d__11>(ref <CreateToyItem>d__);
		return <CreateToyItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600D2E5 RID: 53989 RVA: 0x00381DDC File Offset: 0x0037FFDC
	private void RefreshToyView()
	{
		int enableToyCount = ModelBase<FloroRanchGamePlayModel>.Instance.EnableToyCount;
		List<FloroRanchEntityBase> list = new List<FloroRanchEntityBase>();
		for (int i = 0; i < enableToyCount; i++)
		{
			FloroRanchEntityBase toyEntityByPoint = ModelBase<FloroRanchGamePlayModel>.Instance.GetToyEntityByPoint(i);
			if (toyEntityByPoint != null)
			{
				list.Add(toyEntityByPoint);
			}
			else
			{
				list.Add(null);
			}
		}
		for (int j = 0; j < this.ToyItemList.Count; j++)
		{
			FloroRanchToyGridItem floroRanchToyGridItem = this.ToyItemList[j];
			if (list[j] != null)
			{
				floroRanchToyGridItem.RefreshItemGrid(list[j]);
			}
			else
			{
				floroRanchToyGridItem.RefreshItemGrid(null);
			}
		}
	}

	// Token: 0x0600D2E6 RID: 53990 RVA: 0x00381E71 File Offset: 0x00380071
	private void OnSellCallback(FloroRanchEntityBase entity)
	{
		base.CloseMe(null);
		Action<int> sellCallback = this.SellCallback;
		if (sellCallback == null)
		{
			return;
		}
		sellCallback(this.CurSelectToyPoint);
	}

	// Token: 0x0600D2E7 RID: 53991 RVA: 0x00381E90 File Offset: 0x00380090
	private void OnClickToyItem(int point)
	{
		this.ShowToyTip(point);
	}

	// Token: 0x0600D2E8 RID: 53992 RVA: 0x00381E9C File Offset: 0x0038009C
	private void HideToyTip()
	{
		if (this.CurSelectToyPoint == -1)
		{
			return;
		}
		FloroRanchToyGridItem floroRanchToyGridItem = this.ToyItemList[this.CurSelectToyPoint];
		if (floroRanchToyGridItem != null)
		{
			floroRanchToyGridItem.SetSelectState(false);
		}
	}

	// Token: 0x0600D2E9 RID: 53993 RVA: 0x00381ED0 File Offset: 0x003800D0
	private void ShowToyTip(int point)
	{
		this.HideToyTip();
		if (this.CurSelectToyPoint != point)
		{
			this.CurSelectToyPoint = point;
		}
		FloroRanchToyGridItem floroRanchToyGridItem = this.ToyItemList[this.CurSelectToyPoint];
		if (floroRanchToyGridItem != null)
		{
			floroRanchToyGridItem.SetSelectState(true);
		}
		FloroRanchEntityBase toyEntityByPoint = ModelBase<FloroRanchGamePlayModel>.Instance.GetToyEntityByPoint(point);
		if (toyEntityByPoint != null)
		{
			this.ToyTipItem.RefreshInfoTipByParam(new FloroRanchCommonTipParam
			{
				TipType = EFloroRanchCommonTipType.Entity,
				EntityData = toyEntityByPoint,
				RemoveCallback = new Action<FloroRanchEntityBase>(this.OnSellCallback)
			});
		}
	}

	// Token: 0x0600D2EA RID: 53994 RVA: 0x00381F4E File Offset: 0x0038014E
	private void ClearData()
	{
		this.CurSelectToyPoint = -1;
	}

	// Token: 0x0600D2EB RID: 53995 RVA: 0x00381F57 File Offset: 0x00380157
	private void OnClickCloseButton()
	{
		base.CloseMe(null);
		this.ClearData();
	}

	// Token: 0x04006478 RID: 25720
	private readonly List<FloroRanchToyGridItem> ToyItemList = new List<FloroRanchToyGridItem>();

	// Token: 0x04006479 RID: 25721
	private int CurSelectToyPoint = -1;

	// Token: 0x0400647A RID: 25722
	private Action<int> SellCallback = delegate(int point)
	{
	};

	// Token: 0x0400647B RID: 25723
	private Action<bool> ShowToyListCallback = delegate(bool isActive)
	{
	};

	// Token: 0x0400647C RID: 25724
	private FloroRanchCommonTipItem ToyTipItem;

	// Token: 0x02007F48 RID: 32584
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402B523 RID: 177443
		public const int CloseButton = 0;

		// Token: 0x0402B524 RID: 177444
		public const int ToyTipItem = 1;

		// Token: 0x0402B525 RID: 177445
		public const int ToyLayout = 2;

		// Token: 0x0402B526 RID: 177446
		public const int ToyItemTemplate = 3;
	}
}
