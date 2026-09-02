using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002060 RID: 8288
public class ItemHintPanel<T, [Nullable(2)] TData> : UiPanelBase where T : ItemHintItemBase<TData>
{
	// Token: 0x0600FCB8 RID: 64696 RVA: 0x00455B60 File Offset: 0x00453D60
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x0600FCB9 RID: 64697 RVA: 0x00455BBA File Offset: 0x00453DBA
	[NullableContext(1)]
	public ItemHintPanel(IItemHintPanelData<T, TData> data)
	{
		this.Data = data;
	}

	// Token: 0x0600FCBA RID: 64698 RVA: 0x00455BC9 File Offset: 0x00453DC9
	protected override void OnBeforeDestroy()
	{
		if (this.ListSlideControl != null)
		{
			this.ListSlideControl.DestroyMe();
			this.ListSlideControl = null;
		}
	}

	// Token: 0x0600FCBB RID: 64699 RVA: 0x00455BE8 File Offset: 0x00453DE8
	protected override void OnStart()
	{
		if (!this.CheckNext())
		{
			Singleton<Log>.Instance.Warn(ELogModule.ItemHint, ELogAuthor.ZJC, "进包列表为空, 但打开了界面!", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		UUIItem item = base.GetItem(0);
		if (item != null)
		{
			IItemHintPanelData<T, TData> data = this.Data;
			item.SetUIActive(((data != null) ? data.TitleTextId : null) != null);
		}
		if (item != null && item.IsUIActiveSelf())
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), this.Data.TitleTextId, Array.Empty<object>());
		}
		ListSliderControlData<T> listSliderControlData = new ListSliderControlData<T>(base.GetItem(2), new Func<T>(this.CreateProxyFunction), new Func<bool>(this.CheckNext));
		ListSliderControlData<T> listSliderControlData2 = listSliderControlData;
		IItemHintPanelData<T, TData> data2 = this.Data;
		listSliderControlData2.ChildTemplate = ((data2 != null) ? data2.ChildTemplate : null);
		ListSliderControlData<T> listSliderControlData3 = listSliderControlData;
		IItemHintPanelData<T, TData> data3 = this.Data;
		listSliderControlData3.ChildResourceId = ((data3 != null) ? data3.ChildResourceId : null);
		ListSliderControlData<T> listSliderControlData4 = listSliderControlData;
		IItemHintPanelData<T, TData> data4 = this.Data;
		listSliderControlData4.MaxShowCount = ((data4 != null) ? data4.MaxShowCount : null);
		ListSliderControlData<T> listSliderControlData5 = listSliderControlData;
		IItemHintPanelData<T, TData> data5 = this.Data;
		int? num = (data5 != null) ? data5.AddItemTime : null;
		listSliderControlData5.AddItemTime = ((num != null) ? new float?((float)num.GetValueOrDefault()) : null);
		ListSliderControlData<T> listSliderControlData6 = listSliderControlData;
		IItemHintPanelData<T, TData> data6 = this.Data;
		num = ((data6 != null) ? data6.ItemSliderTime : null);
		listSliderControlData6.ItemSliderTime = ((num != null) ? new float?((float)num.GetValueOrDefault()) : null);
		ListSliderControlData<T> listSliderControlData7 = listSliderControlData;
		IItemHintPanelData<T, TData> data7 = this.Data;
		num = ((data7 != null) ? data7.ItemShowTime : null);
		listSliderControlData7.ItemShowTime = ((num != null) ? new float?((float)num.GetValueOrDefault()) : null);
		ListSliderControlData<T> listSliderControlData8 = listSliderControlData;
		IItemHintPanelData<T, TData> data8 = this.Data;
		listSliderControlData8.SliderMode = ((data8 != null) ? data8.SliderMode : null);
		ListSliderControlData<T> listSliderControlData9 = listSliderControlData;
		IItemHintPanelData<T, TData> data9 = this.Data;
		listSliderControlData9.TickMode = ((data9 != null) ? data9.TickMode : null);
		ListSliderControlData<T> listSliderControlData10 = listSliderControlData;
		IItemHintPanelData<T, TData> data10 = this.Data;
		listSliderControlData10.FinishCallback = ((data10 != null) ? data10.FinishCallback : null);
		this.ListSlideControl = new ListSliderControl<T>(listSliderControlData);
		this.ListSlideControl.DisEnableParentLayout();
	}

	// Token: 0x0600FCBC RID: 64700 RVA: 0x00455E1F File Offset: 0x0045401F
	public void OnTick(float delta)
	{
		if (this.ListSlideControl != null)
		{
			this.ListSlideControl.Tick(delta);
		}
	}

	// Token: 0x0600FCBD RID: 64701 RVA: 0x00455E35 File Offset: 0x00454035
	[NullableContext(1)]
	private T CreateProxyFunction()
	{
		T t = this.Data.CreateProxyFunction();
		t.SetShiftData(new Func<TData>(this.ShiftItem));
		return t;
	}

	// Token: 0x0600FCBE RID: 64702 RVA: 0x00455E60 File Offset: 0x00454060
	private bool CheckNext()
	{
		IItemHintPanelData<T, TData> data = this.Data;
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

	// Token: 0x0600FCBF RID: 64703 RVA: 0x00455EA8 File Offset: 0x004540A8
	[NullableContext(2)]
	private TData ShiftItem()
	{
		if (this.Data == null)
		{
			return default(TData);
		}
		return this.Data.ShiftItem();
	}

	// Token: 0x0400792B RID: 31019
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private readonly IItemHintPanelData<T, TData> Data;

	// Token: 0x0400792C RID: 31020
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ListSliderControl<T> ListSlideControl;

	// Token: 0x020083FB RID: 33787
	private enum EItemHintViewCom
	{
		// Token: 0x0402CBCD RID: 183245
		TitleRoot,
		// Token: 0x0402CBCE RID: 183246
		TextTitle,
		// Token: 0x0402CBCF RID: 183247
		ItemLayout
	}
}
