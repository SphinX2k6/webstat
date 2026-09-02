using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Motorcycle.Model;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020022FA RID: 8954
[NullableContext(2)]
[Nullable(0)]
public class MotorcycleDiyFrameTabView : UiTabViewBase, IMotorcycleDiyTabViewRegister
{
	// Token: 0x1700150C RID: 5388
	// (get) Token: 0x06010F62 RID: 69474 RVA: 0x004A5E7A File Offset: 0x004A407A
	// (set) Token: 0x06010F63 RID: 69475 RVA: 0x004A5E82 File Offset: 0x004A4082
	public Action<int> OnTabCameraClick { get; set; }

	// Token: 0x1700150D RID: 5389
	// (get) Token: 0x06010F64 RID: 69476 RVA: 0x004A5E8B File Offset: 0x004A408B
	// (set) Token: 0x06010F65 RID: 69477 RVA: 0x004A5E93 File Offset: 0x004A4093
	public Action<EOutlookType, int, int> OnSelectItemClick { get; set; }

	// Token: 0x06010F66 RID: 69478 RVA: 0x004A5E9C File Offset: 0x004A409C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIText)),
			new ValueTuple<int, Type>(11, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(8, new Action(this.OnBtnJumpClick))
		};
	}

	// Token: 0x06010F67 RID: 69479 RVA: 0x004A5FCC File Offset: 0x004A41CC
	protected override void OnStart()
	{
		this.FrameScrollView = new LoopScrollView<MotorcycleDiyFrameItem, MotorcycleDiyFrameItemData>(base.GetLoopScrollViewComponent(0), base.GetItem(2).GetOwner() as AUIBaseActor, new Func<MotorcycleDiyFrameItem>(this.CreateFrameItem), true);
		base.GetButton(3).SetActive(false, false);
	}

	// Token: 0x06010F68 RID: 69480 RVA: 0x004A600C File Offset: 0x004A420C
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

	// Token: 0x06010F69 RID: 69481 RVA: 0x004A6026 File Offset: 0x004A4226
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiyInfoUpdate, new Action(this.OnFrameInfoUpdate));
	}

	// Token: 0x06010F6A RID: 69482 RVA: 0x004A6044 File Offset: 0x004A4244
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiyInfoUpdate, new Action(this.OnFrameInfoUpdate));
	}

	// Token: 0x06010F6B RID: 69483 RVA: 0x004A6062 File Offset: 0x004A4262
	[NullableContext(1)]
	private MotorcycleDiyFrameItem CreateFrameItem()
	{
		return new MotorcycleDiyFrameItem
		{
			OnClickToggleBack = new Action<int, UUIExtendToggle, UUIItem>(this.OnClickFrame)
		};
	}

	// Token: 0x06010F6C RID: 69484 RVA: 0x004A607B File Offset: 0x004A427B
	public void RefreshItemScrollView()
	{
		if (this.FrameScrollView != null)
		{
			this.RefreshScrollViewByData(true);
		}
	}

	// Token: 0x06010F6D RID: 69485 RVA: 0x004A608C File Offset: 0x004A428C
	private bool IsSkinBindFrameId(int targetFrameId, int defaultFrameId)
	{
		foreach (MotorSkin motorSkin in ConfigBase<MotorDiyConfig>.Instance.GetAllMotorSkinList())
		{
			if (motorSkin.BindFrame == targetFrameId && targetFrameId != defaultFrameId)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06010F6E RID: 69486 RVA: 0x004A60EC File Offset: 0x004A42EC
	[NullableContext(1)]
	private List<MotorcycleDiyFrameItemData> GetFrameItemDataList()
	{
		List<MotorcycleDiyFrameItemData> list = new List<MotorcycleDiyFrameItemData>();
		List<int> canUseFrameIdsInRegion = ModelBase<MotorcycleDiyModel>.Instance.GetCanUseFrameIdsInRegion();
		int defaultFrameId = ModelBase<MotorcycleDiyModel>.Instance.GetDefaultFrameId();
		foreach (int num in canUseFrameIdsInRegion)
		{
			MotorFrame? motorFrameConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorFrameConfig(num);
			if (motorFrameConfig != null && ModelBase<MotorcycleDiyModel>.Instance.GetFrameState(num) != EOutLookState.IsHide && !this.IsSkinBindFrameId(num, defaultFrameId))
			{
				list.Add(new MotorcycleDiyFrameItemData
				{
					ItemId = num,
					QualityId = motorFrameConfig.Value.QualityId,
					SortIndex = motorFrameConfig.Value.SortIndex,
					IsDefault = (num == defaultFrameId)
				});
			}
		}
		return list;
	}

	// Token: 0x06010F6F RID: 69487 RVA: 0x004A61D4 File Offset: 0x004A43D4
	[NullableContext(1)]
	private int SortFrameItemFunc(MotorcycleDiyFrameItemData dataA, MotorcycleDiyFrameItemData dataB)
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
		int num3 = (ModelBase<MotorcycleDiyModel>.Instance.CheckRedDotInViewOpenCache(dataA.ItemId) > false) ? 1 : 0;
		int num4 = (ModelBase<MotorcycleDiyModel>.Instance.CheckRedDotInViewOpenCache(dataB.ItemId) > false) ? 1 : 0;
		if (num3 != num4)
		{
			return num4 - num3;
		}
		int qualityId = dataA.QualityId;
		int qualityId2 = dataB.QualityId;
		if (qualityId != qualityId2)
		{
			return qualityId2 - qualityId;
		}
		int sortIndex = dataA.SortIndex;
		return dataB.SortIndex - sortIndex;
	}

	// Token: 0x06010F70 RID: 69488 RVA: 0x004A628C File Offset: 0x004A448C
	private void RefreshScrollViewByData(bool isNeedRefresh)
	{
		if (isNeedRefresh)
		{
			ModelBase<MotorcycleDiyModel>.Instance.CollectRedDotOnViewOpen(EOutlookType.Frame, null);
			List<MotorcycleDiyFrameItemData> frameDataList = this.GetFrameItemDataList();
			frameDataList.Sort(new Comparison<MotorcycleDiyFrameItemData>(this.SortFrameItemFunc));
			this.CachedFrameDataList = frameDataList;
			this.FrameScrollView.RefreshByData(frameDataList, true, delegate
			{
				this.AutoSelectGridByDataList(frameDataList);
			}, false);
			return;
		}
		this.FrameScrollView.RefreshByData(this.CachedFrameDataList, true, null, false);
	}

	// Token: 0x06010F71 RID: 69489 RVA: 0x004A6320 File Offset: 0x004A4520
	[NullableContext(1)]
	private void AutoSelectGridByDataList(List<MotorcycleDiyFrameItemData> frameDataList)
	{
		int gridIndex = 0;
		int selectFrameId = 0;
		int selectedFrameId = ModelBase<MotorcycleDiyModel>.Instance.GetSelectedFrameId();
		if (selectedFrameId != 0)
		{
			selectFrameId = selectedFrameId;
		}
		else
		{
			selectFrameId = ModelBase<MotorcycleDiyModel>.Instance.GetEquippedFrameId();
		}
		int num = frameDataList.FindIndex((MotorcycleDiyFrameItemData frameData) => frameData.ItemId == selectFrameId);
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

	// Token: 0x06010F72 RID: 69490 RVA: 0x004A63B0 File Offset: 0x004A45B0
	private void OnFrameInfoUpdate()
	{
		ModelBase<MotorcycleDiyModel>.Instance.CollectRedDotOnViewOpen(EOutlookType.Frame, null);
		this.RefreshScrollViewByData(false);
	}

	// Token: 0x06010F73 RID: 69491 RVA: 0x004A63D8 File Offset: 0x004A45D8
	[NullableContext(1)]
	private void OnClickFrame(int frameId, UUIExtendToggle toggle, UUIItem newItem)
	{
		EOutLookState frameState = ModelBase<MotorcycleDiyModel>.Instance.GetFrameState(frameId);
		if (frameState == EOutLookState.IsBan)
		{
			toggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			ValueTuple<string, string>? banTips = ModelBase<MotorcycleDiyModel>.Instance.GetBanTips(EOutlookType.Frame, frameId);
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
		if (ModelBase<MotorcycleDiyModel>.Instance.IsEquipFrameLockedByPlayer() && frameState == EOutLookState.CanEquipped)
		{
			toggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("MotorDIYWarning02", Array.Empty<object>());
			return;
		}
		if (this.CurrentSelectToggle != null)
		{
			this.CurrentSelectToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.CurrentSelectToggle = toggle;
		this.CurrentSelectToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
		this.UiViewSequence.StopSequenceByKey("Switch", false, false);
		this.UiViewSequence.PlaySequencePurely("Switch", false, false);
		List<int> selectedStickerIdList = ModelBase<MotorcycleDiyModel>.Instance.GetSelectedStickerIdList(false);
		List<int> selectedDecorationIdList = ModelBase<MotorcycleDiyModel>.Instance.GetSelectedDecorationIdList(false);
		MotorcycleUiModelParam param = new MotorcycleUiModelParam
		{
			FrameId = frameId,
			StickerIds = selectedStickerIdList.ToArray(),
			DecorationIds = selectedDecorationIdList.ToArray()
		};
		Singleton<MotorcycleUiModelUtil>.Instance.LoadMotorByParam(param, null);
		ModelBase<MotorcycleDiyModel>.Instance.SetSelectFrame(frameId);
		if (frameState == EOutLookState.CanEquipped)
		{
			ControllerBase<MotorcycleDiyController>.Instance.EquipMotorFrameRequest(frameId, null);
		}
		Action<EOutlookType, int, int> onSelectItemClick = this.OnSelectItemClick;
		if (onSelectItemClick != null)
		{
			onSelectItemClick(EOutlookType.Frame, 0, frameId);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.MotorDiyInfoRedDotUpdate);
		this.RefreshScrollViewByData(false);
		UUIItem item = base.GetItem(5);
		UUIItem item2 = base.GetItem(9);
		UUIItem item3 = base.GetItem(7);
		UUIText text = base.GetText(10);
		UUIButtonComponent button = base.GetButton(8);
		UUIText text2 = base.GetText(11);
		UUIText text3 = base.GetText(4);
		UUIText text4 = base.GetText(6);
		item.SetUIActive(false);
		item2.SetUIActive(false);
		item3.SetUIActive(false);
		button.RootUIComp.Get().SetUIActive(false);
		MotorFrame? motorFrameConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorFrameConfig(frameId);
		if (motorFrameConfig == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text4, motorFrameConfig.Value.SubTitle, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text3, motorFrameConfig.Value.Title, Array.Empty<object>());
		item.SetUIActive(frameState == EOutLookState.IsLock);
		int[] itemAccessArray = motorFrameConfig.Value.GetItemAccessArray();
		if (itemAccessArray == null || itemAccessArray.Length == 0)
		{
			return;
		}
		int num = itemAccessArray[0];
		if (num == 0)
		{
			return;
		}
		AccessPath? accessPathConfig = ConfigBase<SkipInterfaceConfig>.Instance.GetAccessPathConfig(num);
		if (accessPathConfig == null)
		{
			return;
		}
		this.JumpId = num;
		ESkipName skipName = (ESkipName)accessPathConfig.Value.SkipName;
		button.RootUIComp.Get().SetUIActive(skipName != ESkipName.NoSkip && frameState == EOutLookState.IsLock);
		item3.SetUIActive(frameState == EOutLookState.IsLock);
		item2.SetUIActive(skipName == ESkipName.NoSkip && frameState == EOutLookState.IsLock);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, accessPathConfig.Value.Description, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, accessPathConfig.Value.Description, Array.Empty<object>());
	}

	// Token: 0x06010F74 RID: 69492 RVA: 0x004A6714 File Offset: 0x004A4914
	private void OnBtnJumpClick()
	{
		if (this.JumpId <= 0)
		{
			return;
		}
		SkipTaskManager.RunByConfigId(this.JumpId, null);
	}

	// Token: 0x0400858D RID: 34189
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<MotorcycleDiyFrameItem, MotorcycleDiyFrameItemData> FrameScrollView;

	// Token: 0x0400858E RID: 34190
	[Nullable(1)]
	private List<MotorcycleDiyFrameItemData> CachedFrameDataList = new List<MotorcycleDiyFrameItemData>();

	// Token: 0x0400858F RID: 34191
	private UUIExtendToggle CurrentSelectToggle;

	// Token: 0x04008590 RID: 34192
	private int JumpId;

	// Token: 0x020085DA RID: 34266
	[NullableContext(0)]
	private class EMotorFrameScrollViewComponent
	{
		// Token: 0x0402D47B RID: 185467
		public const int LoopScrollView = 0;

		// Token: 0x0402D47C RID: 185468
		public const int SVContent = 1;

		// Token: 0x0402D47D RID: 185469
		public const int TogMotorDiyFrameItem = 2;

		// Token: 0x0402D47E RID: 185470
		public const int BtnOverview = 3;

		// Token: 0x0402D47F RID: 185471
		public const int TxtTitle = 4;

		// Token: 0x0402D480 RID: 185472
		public const int LockItem = 5;

		// Token: 0x0402D481 RID: 185473
		public const int TxtSubTitle = 6;

		// Token: 0x0402D482 RID: 185474
		public const int TitleGetItem = 7;

		// Token: 0x0402D483 RID: 185475
		public const int BtnJump = 8;

		// Token: 0x0402D484 RID: 185476
		public const int TipsItem = 9;

		// Token: 0x0402D485 RID: 185477
		public const int TxtTipsName = 10;

		// Token: 0x0402D486 RID: 185478
		public const int TxtJump = 11;
	}
}
