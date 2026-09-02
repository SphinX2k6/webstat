using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.TrapDefense;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002C1B RID: 11291
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class TrapDefenseBdSumBuffListItem : GridProxyAbstract<TrapDefenseBdData>
{
	// Token: 0x0601697F RID: 92543 RVA: 0x00645484 File Offset: 0x00643684
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
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUILayoutBase));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06016980 RID: 92544 RVA: 0x00645530 File Offset: 0x00643730
	protected override UniTask OnBeforeStartAsync()
	{
		TrapDefenseBdSumBuffListItem.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseBdSumBuffListItem.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06016981 RID: 92545 RVA: 0x00645574 File Offset: 0x00643774
	public override UniTask RefreshAsync(TrapDefenseBdData data, bool isSelected, int gridIndex)
	{
		TrapDefenseBdSumBuffListItem.<RefreshAsync>d__11 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.data = data;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<TrapDefenseBdSumBuffListItem.<RefreshAsync>d__11>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06016982 RID: 92546 RVA: 0x006455BF File Offset: 0x006437BF
	private TrapDefenseBdBuffItem CreateItemBdBuff()
	{
		return new TrapDefenseBdBuffItem
		{
			OnSelectBuffItemCallback = new Action<TrapDefenseBdBuffData, TrapDefenseBdBuffItem>(this.OnSelectBdBuffItem),
			OnIsShowBdBuffLockStateCallback = this.OnIsShowBdBuffLockStateCallback,
			OnIsNewTagStateCallback = this.OnIsNewTagStateCallback,
			OnGetBdBuffConfig = this.OnGetBdBuffConfig
		};
	}

	// Token: 0x06016983 RID: 92547 RVA: 0x006455FC File Offset: 0x006437FC
	public override void OnSelected(bool isSelected)
	{
		if (!this.IsFireForBuffClick)
		{
			this.LayoutBdBuff.SelectGridProxy(Math.Max(this.LastSelectBuffIndex, 0), false);
		}
	}

	// Token: 0x06016984 RID: 92548 RVA: 0x0064561E File Offset: 0x0064381E
	public override void OnDeselected(bool isSelected)
	{
		this.LayoutBdBuff.DeselectCurrentGridProxy();
	}

	// Token: 0x06016985 RID: 92549 RVA: 0x0064562C File Offset: 0x0064382C
	private void OnSelectBdBuffItem(TrapDefenseBdBuffData data, TrapDefenseBdBuffItem item)
	{
		this.IsFireForBuffClick = true;
		IScrollViewDelegate<IGridProxy<TrapDefenseBdData>, TrapDefenseBdData> scrollViewDelegate = base.ScrollViewDelegate;
		if (scrollViewDelegate != null)
		{
			scrollViewDelegate.SelectGridProxy(base.GridIndex, base.DisplayIndex, false);
		}
		Action<TrapDefenseBdBuffData, TrapDefenseBdBuffItem> onSelectBdBuffItemCallBack = this.OnSelectBdBuffItemCallBack;
		if (onSelectBdBuffItemCallBack != null)
		{
			onSelectBdBuffItemCallBack(data, item);
		}
		this.IsFireForBuffClick = false;
	}

	// Token: 0x0400AE6C RID: 44652
	public TrapDefenseBdData ItemData;

	// Token: 0x0400AE6D RID: 44653
	public GenericLayout<TrapDefenseBdBuffItem, TrapDefenseBdBuffData> LayoutBdBuff;

	// Token: 0x0400AE6E RID: 44654
	public Action<TrapDefenseBdBuffData, TrapDefenseBdBuffItem> OnSelectBdBuffItemCallBack;

	// Token: 0x0400AE6F RID: 44655
	public int LastSelectBuffIndex = -1;

	// Token: 0x0400AE70 RID: 44656
	public bool IsFireForBuffClick;

	// Token: 0x0400AE71 RID: 44657
	public Func<TrapDefenseBdBuffData, bool> OnIsShowBdBuffLockStateCallback;

	// Token: 0x0400AE72 RID: 44658
	public Func<TrapDefenseBdBuffData, bool> OnIsNewTagStateCallback;

	// Token: 0x0400AE73 RID: 44659
	public Func<TrapDefenseBdBuffData, TrapDefenseBdBuff> OnGetBdBuffConfig;

	// Token: 0x02008F3A RID: 36666
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x040301A9 RID: 197033
		public const int TextureBdIcon = 0;

		// Token: 0x040301AA RID: 197034
		public const int TextTitle = 1;

		// Token: 0x040301AB RID: 197035
		public const int LayoutBdBuff = 2;

		// Token: 0x040301AC RID: 197036
		public const int ItemBdBuff = 3;
	}
}
