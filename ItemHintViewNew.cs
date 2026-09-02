using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002063 RID: 8291
[NullableContext(1)]
[Nullable(0)]
public class ItemHintViewNew : UiTickViewBase
{
	// Token: 0x0600FCCE RID: 64718 RVA: 0x004561B7 File Offset: 0x004543B7
	public ItemHintViewNew(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600FCCF RID: 64719 RVA: 0x004561C0 File Offset: 0x004543C0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText))
		};
	}

	// Token: 0x0600FCD0 RID: 64720 RVA: 0x00456230 File Offset: 0x00454430
	protected override void OnBeforeCreate()
	{
		base.OnBeforeCreate();
		this.Data = (this.OpenParam as ItemHintViewNewData);
	}

	// Token: 0x0600FCD1 RID: 64721 RVA: 0x00456249 File Offset: 0x00454449
	protected override void OnBeforeDestroy()
	{
		if (this.ListSlideControl != null)
		{
			this.ListSlideControl.DestroyMe();
			this.ListSlideControl = null;
		}
		if (this.ListPriorSlideControl != null)
		{
			this.ListPriorSlideControl.DestroyMe();
			this.ListPriorSlideControl = null;
		}
	}

	// Token: 0x0600FCD2 RID: 64722 RVA: 0x00456280 File Offset: 0x00454480
	protected override void OnStart()
	{
		if (!this.CheckNext() && !this.CheckPriorNext())
		{
			Singleton<Log>.Instance.Warn(ELogModule.ItemHint, ELogAuthor.ZJC, "进包列表为空, 但打开了界面!", default(ReadOnlySpan<ValueTuple<string, object>>));
			base.CloseMe(null);
			return;
		}
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			ItemHintViewNewData data = this.Data;
			item.SetUIActive(((data != null) ? data.TitleTextId : null) != null);
		}
		if (item != null && item.IsUIActiveSelf())
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), this.Data.TitleTextId, Array.Empty<object>());
		}
		UUIItem item2 = base.GetItem(1);
		UUIItem item3 = base.GetItem(0);
		item2.SetUIActive(false);
		item3.SetUIActive(false);
		if (this.CheckNext())
		{
			ListSliderControlData<ItemHintItem> listSliderControlData = new ListSliderControlData<ItemHintItem>(item2.GetParentAsUIItem(), new Func<ItemHintItem>(this.CreateItemProxy), new Func<bool>(this.CheckNext));
			ListSliderControlData<ItemHintItem> listSliderControlData2 = listSliderControlData;
			ItemHintViewNewData data2 = this.Data;
			listSliderControlData2.MaxShowCount = ((data2 != null) ? data2.MaxShowCount : null);
			ListSliderControlData<ItemHintItem> listSliderControlData3 = listSliderControlData;
			ItemHintViewNewData data3 = this.Data;
			int? num = (data3 != null) ? data3.AddItemTime : null;
			listSliderControlData3.AddItemTime = ((num != null) ? new float?((float)num.GetValueOrDefault()) : null);
			ListSliderControlData<ItemHintItem> listSliderControlData4 = listSliderControlData;
			ItemHintViewNewData data4 = this.Data;
			num = ((data4 != null) ? data4.ItemSliderTime : null);
			listSliderControlData4.ItemSliderTime = ((num != null) ? new float?((float)num.GetValueOrDefault()) : null);
			ListSliderControlData<ItemHintItem> listSliderControlData5 = listSliderControlData;
			ItemHintViewNewData data5 = this.Data;
			num = ((data5 != null) ? data5.ItemShowTime : null);
			listSliderControlData5.ItemShowTime = ((num != null) ? new float?((float)num.GetValueOrDefault()) : null);
			listSliderControlData.FinishCallback = new Action(this.FinishCallback);
			listSliderControlData.SliderMode = new ESliderMode?(ESliderMode.SliderWhenPlayEnd);
			ListSliderControlData<ItemHintItem> listSliderControlData6 = listSliderControlData;
			ItemHintViewNewData data6 = this.Data;
			listSliderControlData6.ChildResourceId = (((data6 != null) ? data6.SlotResourceId : null) ?? "UiItem_ItemListB");
			this.ListSlideControl = new ListSliderControl<ItemHintItem>(listSliderControlData);
			this.ListSlideControl.DisEnableParentLayout();
		}
		if (this.CheckPriorNext())
		{
			ListSliderControlData<ItemPriorHintItem> listSliderControlData7 = new ListSliderControlData<ItemPriorHintItem>(item3.GetParentAsUIItem(), new Func<ItemPriorHintItem>(this.CreatePriorItemProxy), new Func<bool>(this.CheckPriorNext));
			ListSliderControlData<ItemPriorHintItem> listSliderControlData8 = listSliderControlData7;
			ItemHintViewNewData data7 = this.Data;
			listSliderControlData8.MaxShowCount = ((data7 != null) ? data7.PriorMaxShowCount : null);
			ListSliderControlData<ItemPriorHintItem> listSliderControlData9 = listSliderControlData7;
			ItemHintViewNewData data8 = this.Data;
			int? num = (data8 != null) ? data8.AddPriorItemTime : null;
			listSliderControlData9.AddItemTime = ((num != null) ? new float?((float)num.GetValueOrDefault()) : null);
			ListSliderControlData<ItemPriorHintItem> listSliderControlData10 = listSliderControlData7;
			ItemHintViewNewData data9 = this.Data;
			num = ((data9 != null) ? data9.PriorItemSliderTime : null);
			listSliderControlData10.ItemSliderTime = ((num != null) ? new float?((float)num.GetValueOrDefault()) : null);
			ListSliderControlData<ItemPriorHintItem> listSliderControlData11 = listSliderControlData7;
			ItemHintViewNewData data10 = this.Data;
			num = ((data10 != null) ? data10.PriorItemShowTime : null);
			listSliderControlData11.ItemShowTime = ((num != null) ? new float?((float)num.GetValueOrDefault()) : null);
			listSliderControlData7.FinishCallback = new Action(this.FinishCallback);
			listSliderControlData7.SliderMode = new ESliderMode?(ESliderMode.SliderWhenPlayEnd);
			ListSliderControlData<ItemPriorHintItem> listSliderControlData12 = listSliderControlData7;
			ItemHintViewNewData data11 = this.Data;
			listSliderControlData12.ChildResourceId = (((data11 != null) ? data11.PriorSlotResourceId : null) ?? "UiItem_ItemListA");
			this.ListPriorSlideControl = new ListSliderControl<ItemPriorHintItem>(listSliderControlData7);
			this.ListPriorSlideControl.DisEnableParentLayout();
		}
	}

	// Token: 0x0600FCD3 RID: 64723 RVA: 0x00456628 File Offset: 0x00454828
	protected override void OnTick(float delta)
	{
		if (this.ListPriorSlideControl != null)
		{
			this.ListPriorSlideControl.Tick(delta);
		}
		if (this.ListSlideControl != null)
		{
			this.ListSlideControl.Tick(delta);
		}
	}

	// Token: 0x0600FCD4 RID: 64724 RVA: 0x00456652 File Offset: 0x00454852
	private ItemHintItem CreateItemProxy()
	{
		ItemHintItem itemHintItem = new ItemHintItem();
		itemHintItem.SetShiftData(new Func<ItemRewardInfo>(this.ShiftItem));
		return itemHintItem;
	}

	// Token: 0x0600FCD5 RID: 64725 RVA: 0x0045666B File Offset: 0x0045486B
	private ItemPriorHintItem CreatePriorItemProxy()
	{
		ItemPriorHintItem itemPriorHintItem = new ItemPriorHintItem();
		itemPriorHintItem.SetShiftData(new Func<ItemRewardInfo>(this.ShiftPriorItem));
		return itemPriorHintItem;
	}

	// Token: 0x0600FCD6 RID: 64726 RVA: 0x00456684 File Offset: 0x00454884
	private void FinishCallback()
	{
		if (this.ListPriorSlideControl != null)
		{
			ListSliderControl<ItemPriorHintItem> listPriorSlideControl = this.ListPriorSlideControl;
			if (listPriorSlideControl == null || !listPriorSlideControl.IsFinish)
			{
				return;
			}
		}
		if (this.ListSlideControl != null)
		{
			ListSliderControl<ItemHintItem> listSlideControl = this.ListSlideControl;
			if (listSlideControl == null || !listSlideControl.IsFinish)
			{
				return;
			}
		}
		base.CloseMe(null);
	}

	// Token: 0x0600FCD7 RID: 64727 RVA: 0x004566D0 File Offset: 0x004548D0
	private bool CheckNext()
	{
		ItemHintViewNewData data = this.Data;
		bool? flag;
		if (data == null)
		{
			flag = null;
		}
		else
		{
			Func<bool> checkNext = data.CheckNext;
			flag = ((checkNext != null) ? new bool?(checkNext()) : null);
		}
		bool? flag2 = flag;
		return flag2.GetValueOrDefault();
	}

	// Token: 0x0600FCD8 RID: 64728 RVA: 0x00456718 File Offset: 0x00454918
	[NullableContext(2)]
	private ItemRewardInfo ShiftItem()
	{
		ItemHintViewNewData data = this.Data;
		if (data == null)
		{
			return null;
		}
		Func<ItemRewardInfo> shiftItem = data.ShiftItem;
		if (shiftItem == null)
		{
			return null;
		}
		return shiftItem();
	}

	// Token: 0x0600FCD9 RID: 64729 RVA: 0x00456738 File Offset: 0x00454938
	private bool CheckPriorNext()
	{
		ItemHintViewNewData data = this.Data;
		bool? flag;
		if (data == null)
		{
			flag = null;
		}
		else
		{
			Func<bool> checkPriorNext = data.CheckPriorNext;
			flag = ((checkPriorNext != null) ? new bool?(checkPriorNext()) : null);
		}
		bool? flag2 = flag;
		return flag2.GetValueOrDefault();
	}

	// Token: 0x0600FCDA RID: 64730 RVA: 0x00456780 File Offset: 0x00454980
	[NullableContext(2)]
	private ItemRewardInfo ShiftPriorItem()
	{
		ItemHintViewNewData data = this.Data;
		if (data == null)
		{
			return null;
		}
		Func<ItemRewardInfo> shiftPriorItem = data.ShiftPriorItem;
		if (shiftPriorItem == null)
		{
			return null;
		}
		return shiftPriorItem();
	}

	// Token: 0x0400793E RID: 31038
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ListSliderControl<ItemHintItem> ListSlideControl;

	// Token: 0x0400793F RID: 31039
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ListSliderControl<ItemPriorHintItem> ListPriorSlideControl;

	// Token: 0x04007940 RID: 31040
	[Nullable(2)]
	private ItemHintViewNewData Data;

	// Token: 0x020083FD RID: 33789
	[NullableContext(0)]
	private enum EItemHintViewCom
	{
		// Token: 0x0402CBD4 RID: 183252
		ItemPriorHintItem,
		// Token: 0x0402CBD5 RID: 183253
		ItemHintItem,
		// Token: 0x0402CBD6 RID: 183254
		TitleRoot,
		// Token: 0x0402CBD7 RID: 183255
		TextTitle
	}
}
