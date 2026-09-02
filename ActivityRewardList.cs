using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020015FF RID: 5631
[NullableContext(1)]
[Nullable(0)]
public class ActivityRewardList<TProxy, [Nullable(2)] TData> : UiPanelBase where TProxy : class, IGridProxy<TData>
{
	// Token: 0x06009EAE RID: 40622 RVA: 0x00298450 File Offset: 0x00296650
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06009EAF RID: 40623 RVA: 0x002984FB File Offset: 0x002966FB
	public void InitGridLayout(Func<TProxy> gridProxyCreateFunction)
	{
		this.GridProxyCreateFunction = gridProxyCreateFunction;
		if (this.ItemLayout == null)
		{
			this.ItemLayout = new GenericLayout<TProxy, TData>(base.GetHorizontalLayout(2), this.GridProxyCreateFunction, null, false, true);
		}
	}

	// Token: 0x06009EB0 RID: 40624 RVA: 0x00298527 File Offset: 0x00296727
	public CommonItemSmallItemGrid InitCommonGridItem()
	{
		return new CommonItemSmallItemGrid
		{
			ShowReceivedCallBack = this.ShowReceivedCallBack
		};
	}

	// Token: 0x06009EB1 RID: 40625 RVA: 0x0029853A File Offset: 0x0029673A
	public void SetCommonTitle()
	{
		base.GetText(1).ShowTextNew("CollectActivity_reward");
	}

	// Token: 0x06009EB2 RID: 40626 RVA: 0x0029854D File Offset: 0x0029674D
	public void SetTitleByTextId(string textId)
	{
		base.GetText(1).ShowTextNew(textId);
	}

	// Token: 0x06009EB3 RID: 40627 RVA: 0x0029855C File Offset: 0x0029675C
	public void SetTitleByText(string text)
	{
		base.GetText(1).SetText(text, true);
	}

	// Token: 0x06009EB4 RID: 40628 RVA: 0x0029856C File Offset: 0x0029676C
	public UUITexture GetBgTexture()
	{
		return base.GetTexture(0);
	}

	// Token: 0x06009EB5 RID: 40629 RVA: 0x00298575 File Offset: 0x00296775
	public void RefreshItemLayout(IReadOnlyList<TData> dataList, [Nullable(2)] Action callBack = null)
	{
		this.ItemLayout.RefreshByData(dataList, callBack, false);
	}

	// Token: 0x06009EB6 RID: 40630 RVA: 0x00298585 File Offset: 0x00296785
	public TProxy[] GetLayoutItemList()
	{
		return this.ItemLayout.GetLayoutItemList().ToArray();
	}

	// Token: 0x06009EB7 RID: 40631 RVA: 0x00298597 File Offset: 0x00296797
	public void SetItemLayoutVisible(bool bVisible)
	{
		this.ItemLayout.SetActive(bVisible);
	}

	// Token: 0x040048F0 RID: 18672
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<TProxy, TData> ItemLayout;

	// Token: 0x040048F1 RID: 18673
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Func<TProxy> GridProxyCreateFunction;

	// Token: 0x040048F2 RID: 18674
	[Nullable(2)]
	public Func<TItem, bool> ShowReceivedCallBack;

	// Token: 0x020079BF RID: 31167
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029CD5 RID: 171221
		public const int BgTexture = 0;

		// Token: 0x04029CD6 RID: 171222
		public const int Title = 1;

		// Token: 0x04029CD7 RID: 171223
		public const int Layout = 2;

		// Token: 0x04029CD8 RID: 171224
		public const int GridItem = 3;
	}
}
