using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F80 RID: 8064
public class HonamiStorySettleSuccessView : UiViewBase
{
	// Token: 0x0600F1A2 RID: 61858 RVA: 0x00420264 File Offset: 0x0041E464
	[NullableContext(1)]
	public HonamiStorySettleSuccessView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600F1A3 RID: 61859 RVA: 0x00420270 File Offset: 0x0041E470
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
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
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnConfirmClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F1A4 RID: 61860 RVA: 0x00420358 File Offset: 0x0041E558
	protected override void OnStart()
	{
		this.ScrollView = new GenericScrollViewNew<HonamiStorySettleItem, IHonamiStorySettleItemParams>(base.GetScrollViewWithScrollbar(0), new Func<HonamiStorySettleItem>(this.InitItem), null, false, null);
	}

	// Token: 0x0600F1A5 RID: 61861 RVA: 0x0042037C File Offset: 0x0041E57C
	protected override void OnBeforeShow()
	{
		IHonamiStorySettleSuccessViewParams honamiStorySettleSuccessViewParams = this.OpenParam as IHonamiStorySettleSuccessViewParams;
		if (honamiStorySettleSuccessViewParams == null)
		{
			return;
		}
		GenericScrollViewNew<HonamiStorySettleItem, IHonamiStorySettleItemParams> scrollView = this.ScrollView;
		if (scrollView != null)
		{
			scrollView.RefreshByData(honamiStorySettleSuccessViewParams.DisplayItems, null, true);
		}
		base.GetText(1).SetText(honamiStorySettleSuccessViewParams.TotalReward.ToString(), true);
		base.GetItem(2).SetUIActive(honamiStorySettleSuccessViewParams.IsNewRecord);
		this.SetDialogAndSound();
	}

	// Token: 0x0600F1A6 RID: 61862 RVA: 0x004203E5 File Offset: 0x0041E5E5
	[NullableContext(1)]
	private HonamiStorySettleItem InitItem()
	{
		return new HonamiStorySettleItem();
	}

	// Token: 0x0600F1A7 RID: 61863 RVA: 0x004203EC File Offset: 0x0041E5EC
	private void OnConfirmClick()
	{
		ControllerBase<HonamiStoryController>.Instance.LeaveHonamiDungeon();
	}

	// Token: 0x0600F1A8 RID: 61864 RVA: 0x004203FC File Offset: 0x0041E5FC
	private void SetDialogAndSound()
	{
		HonamiStoryOutDialog? randomDialogData = ModelBase<HonamiStoryModel>.Instance.GetRandomDialogData(2);
		Singleton<AudioSystem>.Instance.PostEvent(randomDialogData.Value.AudioEvent);
	}

	// Token: 0x040073FB RID: 29691
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<HonamiStorySettleItem, IHonamiStorySettleItemParams> ScrollView;

	// Token: 0x0200831B RID: 33563
	private enum EComponentType
	{
		// Token: 0x0402C74B RID: 182091
		ScrollView,
		// Token: 0x0402C74C RID: 182092
		RewardText,
		// Token: 0x0402C74D RID: 182093
		NewRecordItem,
		// Token: 0x0402C74E RID: 182094
		ConfirmButton
	}
}
