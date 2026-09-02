using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Motorcycle.Model;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020022F7 RID: 8951
[NullableContext(2)]
[Nullable(0)]
public class MotorcycleDiyEditFrameTabView : UiTabViewBase, IMotorcycleDiyEditTabViewRegister, IMotorcycleDiyTabViewRegister
{
	// Token: 0x17001502 RID: 5378
	// (get) Token: 0x06010F1A RID: 69402 RVA: 0x004A41D0 File Offset: 0x004A23D0
	// (set) Token: 0x06010F1B RID: 69403 RVA: 0x004A41D8 File Offset: 0x004A23D8
	public Action<int> OnTabCameraClick { get; set; }

	// Token: 0x17001503 RID: 5379
	// (get) Token: 0x06010F1C RID: 69404 RVA: 0x004A41E1 File Offset: 0x004A23E1
	// (set) Token: 0x06010F1D RID: 69405 RVA: 0x004A41E9 File Offset: 0x004A23E9
	public Action<EOutlookType, int, int> OnSelectItemClick { get; set; }

	// Token: 0x17001504 RID: 5380
	// (get) Token: 0x06010F1E RID: 69406 RVA: 0x004A41F2 File Offset: 0x004A23F2
	// (set) Token: 0x06010F1F RID: 69407 RVA: 0x004A41FA File Offset: 0x004A23FA
	public Func<MotorcycleDiyPresetData> GetLocalPresetData { get; set; }

	// Token: 0x17001505 RID: 5381
	// (get) Token: 0x06010F20 RID: 69408 RVA: 0x004A4203 File Offset: 0x004A2403
	// (set) Token: 0x06010F21 RID: 69409 RVA: 0x004A420B File Offset: 0x004A240B
	public Action<EOutlookType, bool> OnEditPresetChanged { get; set; }

	// Token: 0x06010F22 RID: 69410 RVA: 0x004A4214 File Offset: 0x004A2414
	protected unsafe override void OnRegisterComponent()
	{
		int num = 13;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06010F23 RID: 69411 RVA: 0x004A43F0 File Offset: 0x004A25F0
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleDiyEditFrameTabView.<OnBeforeStartAsync>d__22 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleDiyEditFrameTabView.<OnBeforeStartAsync>d__22>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010F24 RID: 69412 RVA: 0x004A4434 File Offset: 0x004A2634
	protected override void OnStart()
	{
		this.FrameScrollView = new LoopScrollView<MotorcycleDiyEditFrameItem, MotorcycleDiyEditFrameItemData>(base.GetLoopScrollViewComponent(0), base.GetItem(2).GetOwner() as AUIBaseActor, new Func<MotorcycleDiyEditFrameItem>(this.CreateFrameItem), true);
		base.GetButton(3).RootUIComp.Get().SetUIActive(false);
		base.GetItem(12).SetUIActive(true);
		MotorcycleDiyEditPresetPanel editPresetPanel = this.EditPresetPanel;
		if (editPresetPanel == null)
		{
			return;
		}
		editPresetPanel.SetUiActive(false);
	}

	// Token: 0x06010F25 RID: 69413 RVA: 0x004A44AA File Offset: 0x004A26AA
	protected override void OnBeforeShow()
	{
		this.RefreshScrollViewByData(true);
		Action<int> onTabCameraClick = this.OnTabCameraClick;
		if (onTabCameraClick == null)
		{
			return;
		}
		onTabCameraClick(0);
	}

	// Token: 0x06010F26 RID: 69414 RVA: 0x004A44C4 File Offset: 0x004A26C4
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiyInfoUpdate, new Action(this.OnFrameInfoUpdate));
	}

	// Token: 0x06010F27 RID: 69415 RVA: 0x004A44E2 File Offset: 0x004A26E2
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiyInfoUpdate, new Action(this.OnFrameInfoUpdate));
	}

	// Token: 0x06010F28 RID: 69416 RVA: 0x004A4500 File Offset: 0x004A2700
	[NullableContext(1)]
	private MotorcycleDiyEditFrameItem CreateFrameItem()
	{
		return new MotorcycleDiyEditFrameItem
		{
			OnClickToggleBack = new Action<int, UUIExtendToggle, UUIItem>(this.OnClickFrame)
		};
	}

	// Token: 0x06010F29 RID: 69417 RVA: 0x004A4519 File Offset: 0x004A2719
	public void RefreshItemScrollView()
	{
		if (this.FrameScrollView != null)
		{
			this.RefreshScrollViewByData(true);
		}
	}

	// Token: 0x06010F2A RID: 69418 RVA: 0x004A452C File Offset: 0x004A272C
	[NullableContext(1)]
	private List<MotorcycleDiyEditFrameItemData> GetFrameItemDataList()
	{
		List<MotorcycleDiyEditFrameItemData> list = new List<MotorcycleDiyEditFrameItemData>();
		foreach (int num in ModelBase<MotorcycleDiyModel>.Instance.GetCanUseFrameIdsInRegion())
		{
			MotorFrame? motorFrameConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorFrameConfig(num);
			if (motorFrameConfig != null)
			{
				int frameState = (int)ModelBase<MotorcycleDiyModel>.Instance.GetFrameState(num);
				bool flag = ModelBase<MotorcycleDiyModel>.Instance.HasFrame(num);
				if (frameState != 0 && flag)
				{
					MotorcycleDiyEditFrameItemData item = new MotorcycleDiyEditFrameItemData
					{
						ItemId = num,
						QualityId = motorFrameConfig.Value.QualityId,
						SortIndex = motorFrameConfig.Value.SortIndex,
						IsDefault = (num == ModelBase<MotorcycleDiyModel>.Instance.GetDefaultFrameId())
					};
					list.Add(item);
				}
			}
		}
		return list;
	}

	// Token: 0x06010F2B RID: 69419 RVA: 0x004A4614 File Offset: 0x004A2814
	[NullableContext(1)]
	private int SortFrameItemFunc(MotorcycleDiyEditFrameItemData dataA, MotorcycleDiyEditFrameItemData dataB)
	{
		int num = (!dataA.IsDefault) ? 1 : 0;
		int num2 = (!dataB.IsDefault) ? 1 : 0;
		if (num != num2)
		{
			return num - num2;
		}
		EOutLookState frameState = ModelBase<MotorcycleDiyModel>.Instance.GetFrameState(dataA.ItemId);
		EOutLookState frameState2 = ModelBase<MotorcycleDiyModel>.Instance.GetFrameState(dataB.ItemId);
		if (frameState != frameState2)
		{
			return frameState - frameState2;
		}
		int qualityId = dataA.QualityId;
		int qualityId2 = dataB.QualityId;
		if (qualityId != qualityId2)
		{
			return qualityId2 - qualityId;
		}
		return dataB.SortIndex - dataA.SortIndex;
	}

	// Token: 0x06010F2C RID: 69420 RVA: 0x004A4690 File Offset: 0x004A2890
	private void RefreshScrollViewByData(bool isNeedRefresh)
	{
		if (isNeedRefresh)
		{
			List<MotorcycleDiyEditFrameItemData> frameDataList = this.GetFrameItemDataList();
			frameDataList.Sort(new Comparison<MotorcycleDiyEditFrameItemData>(this.SortFrameItemFunc));
			this.FrameScrollView.RefreshByData(frameDataList, true, delegate
			{
				this.AutoSelectGridByDataList(frameDataList);
			}, false);
			this.CachedFrameDataList = frameDataList;
			return;
		}
		this.FrameScrollView.RefreshByData(this.CachedFrameDataList, true, null, false);
	}

	// Token: 0x06010F2D RID: 69421 RVA: 0x004A4710 File Offset: 0x004A2910
	[NullableContext(1)]
	private void AutoSelectGridByDataList(List<MotorcycleDiyEditFrameItemData> frameDataList)
	{
		int gridIndex = 0;
		int selectFrameId = 0;
		int selectedFrameId = ModelBase<MotorcycleDiyModel>.Instance.GetSelectedFrameId();
		if (selectedFrameId != 0)
		{
			selectFrameId = selectedFrameId;
		}
		int num = frameDataList.FindIndex((MotorcycleDiyEditFrameItemData frameData) => frameData.ItemId == selectFrameId);
		if (num >= 0)
		{
			gridIndex = num;
		}
		if (!this.FrameScrollView.IsGridDisplaying(gridIndex))
		{
			this.FrameScrollView.ScrollToGridIndex(gridIndex, false);
		}
		this.FrameScrollView.DeselectCurrentGridProxy(false);
		this.FrameScrollView.SelectGridProxy(gridIndex, false);
	}

	// Token: 0x06010F2E RID: 69422 RVA: 0x004A478E File Offset: 0x004A298E
	private void OnFrameInfoUpdate()
	{
		this.RefreshScrollViewByData(false);
	}

	// Token: 0x06010F2F RID: 69423 RVA: 0x004A4798 File Offset: 0x004A2998
	[NullableContext(1)]
	private void OnClickFrame(int frameId, UUIExtendToggle toggle, UUIItem newItem)
	{
		MotorcycleDiyModel instance = ModelBase<MotorcycleDiyModel>.Instance;
		if (instance.GetFrameState(frameId) == EOutLookState.IsBan)
		{
			toggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			ValueTuple<string, string>? banTips = instance.GetBanTips(EOutlookType.Frame, frameId);
			if (banTips != null)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("MotorDIYWarning01", new object[]
				{
					banTips.Value.Item1,
					banTips.Value.Item2
				});
			}
			return;
		}
		if (this.CurrentSelectToggle != null)
		{
			this.CurrentSelectToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.CurrentSelectToggle = toggle;
		this.CurrentSelectToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
		List<int> selectedStickerIdList = ModelBase<MotorcycleDiyModel>.Instance.GetSelectedStickerIdList(false);
		List<int> selectedDecorationIdList = ModelBase<MotorcycleDiyModel>.Instance.GetSelectedDecorationIdList(false);
		MotorcycleUiModelParam param = new MotorcycleUiModelParam
		{
			FrameId = frameId,
			StickerIds = selectedStickerIdList.ToArray(),
			DecorationIds = selectedDecorationIdList.ToArray()
		};
		Singleton<MotorcycleUiModelUtil>.Instance.LoadMotorByParam(param, null);
		instance.SetSelectFrame(frameId);
		Func<MotorcycleDiyPresetData> getLocalPresetData = this.GetLocalPresetData;
		MotorcycleDiyPresetData motorcycleDiyPresetData = (getLocalPresetData != null) ? getLocalPresetData() : null;
		Action<EOutlookType, bool> onEditPresetChanged = this.OnEditPresetChanged;
		if (onEditPresetChanged != null)
		{
			onEditPresetChanged(EOutlookType.Frame, motorcycleDiyPresetData != null && frameId != motorcycleDiyPresetData.FrameId);
		}
		Action<EOutlookType, int, int> onSelectItemClick = this.OnSelectItemClick;
		if (onSelectItemClick != null)
		{
			onSelectItemClick(EOutlookType.Frame, 0, frameId);
		}
		this.RefreshScrollViewByData(false);
		UUIItem item = base.GetItem(5);
		UUIItem item2 = base.GetItem(9);
		UUIItem item3 = base.GetItem(7);
		ULGUIBehaviour button = base.GetButton(8);
		UUIText text = base.GetText(4);
		UUIText text2 = base.GetText(6);
		item.SetUIActive(false);
		item2.SetUIActive(false);
		item3.SetUIActive(false);
		button.RootUIComp.Get().SetUIActive(false);
		MotorFrame? motorFrameConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorFrameConfig(frameId);
		if (motorFrameConfig == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, motorFrameConfig.Value.SubTitle, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, motorFrameConfig.Value.Title, Array.Empty<object>());
	}

	// Token: 0x04008573 RID: 34163
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<MotorcycleDiyEditFrameItem, MotorcycleDiyEditFrameItemData> FrameScrollView;

	// Token: 0x04008574 RID: 34164
	[Nullable(1)]
	private List<MotorcycleDiyEditFrameItemData> CachedFrameDataList = new List<MotorcycleDiyEditFrameItemData>();

	// Token: 0x04008575 RID: 34165
	private UUIExtendToggle CurrentSelectToggle;

	// Token: 0x04008576 RID: 34166
	private MotorcycleDiyEditPresetPanel EditPresetPanel;

	// Token: 0x020085CE RID: 34254
	[NullableContext(0)]
	private class EMotorFrameTabViewComponent
	{
		// Token: 0x0402D430 RID: 185392
		public const int LoopScrollView = 0;

		// Token: 0x0402D431 RID: 185393
		public const int SVContent = 1;

		// Token: 0x0402D432 RID: 185394
		public const int TogMotorDiyFrameItem = 2;

		// Token: 0x0402D433 RID: 185395
		public const int BtnOverview = 3;

		// Token: 0x0402D434 RID: 185396
		public const int TxtTitle = 4;

		// Token: 0x0402D435 RID: 185397
		public const int LockItem = 5;

		// Token: 0x0402D436 RID: 185398
		public const int TxtSubTitle = 6;

		// Token: 0x0402D437 RID: 185399
		public const int TitleGetItem = 7;

		// Token: 0x0402D438 RID: 185400
		public const int BtnJump = 8;

		// Token: 0x0402D439 RID: 185401
		public const int TipsItem = 9;

		// Token: 0x0402D43A RID: 185402
		public const int TxtTipsName = 10;

		// Token: 0x0402D43B RID: 185403
		public const int TxtJump = 11;

		// Token: 0x0402D43C RID: 185404
		public const int NormalPanel = 12;

		// Token: 0x0402D43D RID: 185405
		public const int EditPresetPanel = 13;
	}
}
