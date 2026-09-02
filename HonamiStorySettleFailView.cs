using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F7A RID: 8058
public class HonamiStorySettleFailView : UiViewBase
{
	// Token: 0x0600F184 RID: 61828 RVA: 0x0041FE97 File Offset: 0x0041E097
	[NullableContext(1)]
	public HonamiStorySettleFailView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600F185 RID: 61829 RVA: 0x0041FEA0 File Offset: 0x0041E0A0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnConfirmClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F186 RID: 61830 RVA: 0x0041FFEB File Offset: 0x0041E1EB
	protected override void OnStart()
	{
		this.ScrollView = new GenericScrollViewNew<HonamiStorySettleItem, IHonamiStorySettleItemParams>(base.GetScrollViewWithScrollbar(0), new Func<HonamiStorySettleItem>(this.InitItem), null, false, null);
	}

	// Token: 0x0600F187 RID: 61831 RVA: 0x00420010 File Offset: 0x0041E210
	protected override void OnBeforeShow()
	{
		IHonamiStorySettleFailViewParams honamiStorySettleFailViewParams = this.OpenParam as IHonamiStorySettleFailViewParams;
		if (honamiStorySettleFailViewParams == null)
		{
			return;
		}
		base.GetItem(6).SetUIActive(false);
		GenericScrollViewNew<HonamiStorySettleItem, IHonamiStorySettleItemParams> scrollView = this.ScrollView;
		if (scrollView != null)
		{
			scrollView.RefreshByData(honamiStorySettleFailViewParams.DisplayItems, delegate
			{
				if (this.ScrollView != null && this.ScrollView.IsExpand)
				{
					base.GetItem(6).SetUIActive(true);
				}
			}, true);
		}
		base.GetText(1).SetText(honamiStorySettleFailViewParams.TotalReward.ToString(), true);
		base.GetItem(2).SetUIActive(honamiStorySettleFailViewParams.IsNewRecord);
		int failAddProportion = honamiStorySettleFailViewParams.FailAddProportion;
		bool flag = failAddProportion > 0;
		base.GetItem(4).SetUIActive(flag);
		if (flag)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "HonamiStory_EvacuationInterface_4", new <>z__ReadOnlySingleElementList<object>(failAddProportion));
		}
		this.SetDialogAndSound();
	}

	// Token: 0x0600F188 RID: 61832 RVA: 0x004200CE File Offset: 0x0041E2CE
	[NullableContext(1)]
	private HonamiStorySettleItem InitItem()
	{
		return new HonamiStorySettleItem();
	}

	// Token: 0x0600F189 RID: 61833 RVA: 0x004200D5 File Offset: 0x0041E2D5
	private void OnConfirmClick()
	{
		ControllerBase<HonamiStoryController>.Instance.LeaveHonamiDungeon();
	}

	// Token: 0x0600F18A RID: 61834 RVA: 0x004200E4 File Offset: 0x0041E2E4
	private void SetDialogAndSound()
	{
		HonamiStoryOutDialog? randomDialogData = ModelBase<HonamiStoryModel>.Instance.GetRandomDialogData(3);
		Singleton<AudioSystem>.Instance.PostEvent(randomDialogData.Value.AudioEvent);
	}

	// Token: 0x040073F5 RID: 29685
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<HonamiStorySettleItem, IHonamiStorySettleItemParams> ScrollView;

	// Token: 0x02008319 RID: 33561
	private enum EComponentType
	{
		// Token: 0x0402C740 RID: 182080
		ScrollView,
		// Token: 0x0402C741 RID: 182081
		RewardText,
		// Token: 0x0402C742 RID: 182082
		NewRecordItem,
		// Token: 0x0402C743 RID: 182083
		ConfirmButton,
		// Token: 0x0402C744 RID: 182084
		FailItem,
		// Token: 0x0402C745 RID: 182085
		FailItemValueText,
		// Token: 0x0402C746 RID: 182086
		BottomArrowItem
	}
}
