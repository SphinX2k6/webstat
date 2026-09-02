using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C33 RID: 7219
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchHandBookView : UiViewBase
{
	// Token: 0x0600D239 RID: 53817 RVA: 0x0037E1EA File Offset: 0x0037C3EA
	public FloroRanchHandBookView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600D23A RID: 53818 RVA: 0x0037E1F4 File Offset: 0x0037C3F4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnCloseBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnPhantomBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.OnToyBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D23B RID: 53819 RVA: 0x0037E40C File Offset: 0x0037C60C
	protected override UniTask OnBeforeStartAsync()
	{
		FloroRanchHandBookView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FloroRanchHandBookView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D23C RID: 53820 RVA: 0x0037E44F File Offset: 0x0037C64F
	private FloroRanchActivityData GetHandBookActivityData()
	{
		return ModelBase<FloroRanchModel>.Instance.GetActivityData(this.ActivityDataType, true);
	}

	// Token: 0x0600D23D RID: 53821 RVA: 0x0037E464 File Offset: 0x0037C664
	private UniTask RefreshView()
	{
		FloroRanchHandBookView.<RefreshView>d__10 <RefreshView>d__;
		<RefreshView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshView>d__.<>4__this = this;
		<RefreshView>d__.<>1__state = -1;
		<RefreshView>d__.<>t__builder.Start<FloroRanchHandBookView.<RefreshView>d__10>(ref <RefreshView>d__);
		return <RefreshView>d__.<>t__builder.Task;
	}

	// Token: 0x0600D23E RID: 53822 RVA: 0x0037E4A8 File Offset: 0x0037C6A8
	private void RefreshTabRedDot()
	{
		FloroRanchActivityData handBookActivityData = this.GetHandBookActivityData();
		UUIItem item = base.GetItem(9);
		if (item != null)
		{
			item.SetUIActive(handBookActivityData.IsCardHasRedDot());
		}
		UUIItem item2 = base.GetItem(10);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(handBookActivityData.IsToyHasRedDot());
	}

	// Token: 0x0600D23F RID: 53823 RVA: 0x0037E4ED File Offset: 0x0037C6ED
	private bool IsSelectedItem()
	{
		return this.CurrentSelectedItem != null;
	}

	// Token: 0x0600D240 RID: 53824 RVA: 0x0037E4F8 File Offset: 0x0037C6F8
	private void OnItemClick(FloroRanchHandBookSmallSlotItem item)
	{
		FloroRanchHandBookSmallSlotItem currentSelectedItem = this.CurrentSelectedItem;
		if (currentSelectedItem != null)
		{
			currentSelectedItem.OnDeselected(true);
		}
		this.CurrentSelectedItem = item;
		item.OnSelected(true);
		this.RefreshTabRedDot();
		this.RefreshCardItem(item.Data);
	}

	// Token: 0x0600D241 RID: 53825 RVA: 0x0037E52C File Offset: 0x0037C72C
	private void RefreshCardItem(FloroRanchUnlockDataBase data)
	{
		this.CardItem.CardType = this.CurrentType;
		this.CardItem.Refresh(data.Id, false, 0);
		this.CardItem.SetItemAlpha(1f);
		this.CardItem.HideNewLabel();
		if (!data.IsUnLock)
		{
			this.CardItem.SetLock();
		}
	}

	// Token: 0x0600D242 RID: 53826 RVA: 0x0037E58B File Offset: 0x0037C78B
	private bool OnPhantomCanExecuteChange()
	{
		return this.CurrentType > EFloroRanchCardType.Phantom;
	}

	// Token: 0x0600D243 RID: 53827 RVA: 0x0037E596 File Offset: 0x0037C796
	private bool OnToyCanExecuteChange()
	{
		return this.CurrentType != EFloroRanchCardType.Toy;
	}

	// Token: 0x0600D244 RID: 53828 RVA: 0x0037E5A4 File Offset: 0x0037C7A4
	private void OnPhantomBtnClick(EToggleState state)
	{
		this.CurrentType = EFloroRanchCardType.Phantom;
		UUIExtendToggle extendToggle = base.GetExtendToggle(3);
		if (extendToggle != null)
		{
			extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.RefreshView();
	}

	// Token: 0x0600D245 RID: 53829 RVA: 0x0037E5CA File Offset: 0x0037C7CA
	private void OnToyBtnClick(EToggleState state)
	{
		this.CurrentType = EFloroRanchCardType.Toy;
		UUIExtendToggle extendToggle = base.GetExtendToggle(2);
		if (extendToggle != null)
		{
			extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.RefreshView();
	}

	// Token: 0x0600D246 RID: 53830 RVA: 0x0037E5F0 File Offset: 0x0037C7F0
	private void OnCloseBtnClick()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.FloroRanchDataRedDot);
		base.CloseMe(null);
	}

	// Token: 0x0600D247 RID: 53831 RVA: 0x0037E609 File Offset: 0x0037C809
	private FloroRanchHandBookItem CreateHandBookItem()
	{
		return new FloroRanchHandBookItem
		{
			ActivityDataType = this.ActivityDataType,
			OnClickCallback = new Action<FloroRanchHandBookSmallSlotItem>(this.OnItemClick),
			IsSelectedItem = new Func<bool>(this.IsSelectedItem)
		};
	}

	// Token: 0x04006436 RID: 25654
	private EFloroRanchActivityDataType ActivityDataType;

	// Token: 0x04006437 RID: 25655
	private EFloroRanchCardType CurrentType;

	// Token: 0x04006438 RID: 25656
	[Nullable(2)]
	private FloroRanchHandBookSmallSlotItem CurrentSelectedItem;

	// Token: 0x04006439 RID: 25657
	private GenericScrollViewNew<FloroRanchHandBookItem, int> ItemScrollLayout;

	// Token: 0x0400643A RID: 25658
	private FloroRanchCardItem CardItem;

	// Token: 0x02007F2D RID: 32557
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402B483 RID: 177283
		public const int BtnClose = 0;

		// Token: 0x0402B484 RID: 177284
		public const int LayoutTab = 1;

		// Token: 0x0402B485 RID: 177285
		public const int TogglePhantom = 2;

		// Token: 0x0402B486 RID: 177286
		public const int ToggleToy = 3;

		// Token: 0x0402B487 RID: 177287
		public const int ScrollList = 4;

		// Token: 0x0402B488 RID: 177288
		public const int LayoutHandBook = 5;

		// Token: 0x0402B489 RID: 177289
		public const int ItemHandBook = 6;

		// Token: 0x0402B48A RID: 177290
		public const int ItemCardDetail = 7;

		// Token: 0x0402B48B RID: 177291
		public const int TextProgress = 8;

		// Token: 0x0402B48C RID: 177292
		public const int ItemPhantomRedDot = 9;

		// Token: 0x0402B48D RID: 177293
		public const int ItemToyRedDot = 10;
	}
}
