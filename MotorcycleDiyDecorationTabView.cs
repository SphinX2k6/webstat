using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Motorcycle.Model;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020022F9 RID: 8953
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleDiyDecorationTabView : UiTabViewBase, IMotorcycleDiyTabViewRegister
{
	// Token: 0x1700150A RID: 5386
	// (get) Token: 0x06010F4C RID: 69452 RVA: 0x004A53EA File Offset: 0x004A35EA
	// (set) Token: 0x06010F4D RID: 69453 RVA: 0x004A53F2 File Offset: 0x004A35F2
	[Nullable(2)]
	public Action<int> OnTabCameraClick { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x1700150B RID: 5387
	// (get) Token: 0x06010F4E RID: 69454 RVA: 0x004A53FB File Offset: 0x004A35FB
	// (set) Token: 0x06010F4F RID: 69455 RVA: 0x004A5403 File Offset: 0x004A3603
	[Nullable(2)]
	public Action<EOutlookType, int, int> OnSelectItemClick { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x06010F50 RID: 69456 RVA: 0x004A540C File Offset: 0x004A360C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIText)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIText)),
			new ValueTuple<int, Type>(14, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUIItem)),
			new ValueTuple<int, Type>(18, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(9, new Action(this.OnBtnJumpClick))
		};
	}

	// Token: 0x06010F51 RID: 69457 RVA: 0x004A55E0 File Offset: 0x004A37E0
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleDiyDecorationTabView.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleDiyDecorationTabView.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010F52 RID: 69458 RVA: 0x004A5624 File Offset: 0x004A3824
	protected override void OnBeforeShow()
	{
		int index = (this.CurrentSelectDecorationPart > 0) ? (this.CurrentSelectDecorationPart - 1) : 0;
		this.PartTabComponent.SelectToggleByIndex(index, true, true);
	}

	// Token: 0x06010F53 RID: 69459 RVA: 0x004A5654 File Offset: 0x004A3854
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiyInfoUpdate, new Action(this.OnDecorationInfoUpdate));
	}

	// Token: 0x06010F54 RID: 69460 RVA: 0x004A5672 File Offset: 0x004A3872
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiyInfoUpdate, new Action(this.OnDecorationInfoUpdate));
	}

	// Token: 0x06010F55 RID: 69461 RVA: 0x004A5690 File Offset: 0x004A3890
	private MotorcycleDiyPartTabItem InitDecorationTabItem([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new MotorcycleDiyPartTabItem();
	}

	// Token: 0x06010F56 RID: 69462 RVA: 0x004A5698 File Offset: 0x004A3898
	private void ToggleCallBack(int index)
	{
		MotorcycleDiyPartTabItemData motorcycleDiyPartTabItemData = this.PartTabItemDataList[index];
		this.CurrentSelectDecorationPart = motorcycleDiyPartTabItemData.PartId;
		this.RefreshScrollViewByData(motorcycleDiyPartTabItemData.PartId, true);
		Action<int> onTabCameraClick = this.OnTabCameraClick;
		if (onTabCameraClick == null)
		{
			return;
		}
		onTabCameraClick(this.CurrentSelectDecorationPart);
	}

	// Token: 0x06010F57 RID: 69463 RVA: 0x004A56E1 File Offset: 0x004A38E1
	private MotorcycleDiyStickerDecoItem CreateDecorationItem()
	{
		return new MotorcycleDiyStickerDecoItem
		{
			OnClickToggleBack = new Action<int, UUIExtendToggle, UUIItem>(this.OnClickDecoration)
		};
	}

	// Token: 0x06010F58 RID: 69464 RVA: 0x004A56FA File Offset: 0x004A38FA
	public void RefreshItemScrollView()
	{
		if (this.DecorationScrollView != null)
		{
			this.RefreshScrollViewByData(this.CurrentSelectDecorationPart, true);
		}
	}

	// Token: 0x06010F59 RID: 69465 RVA: 0x004A5714 File Offset: 0x004A3914
	private List<MotorcycleDiyStickerDecoItemData> GetDecorationItemDataList(int partId)
	{
		List<MotorcycleDiyStickerDecoItemData> list = new List<MotorcycleDiyStickerDecoItemData>();
		list.Add(new MotorcycleDiyStickerDecoItemData
		{
			Part = partId
		});
		int? num = new int?(ModelBase<MotorcycleDiyModel>.Instance.GetEquippedDecorationId(partId));
		if (num != null && num.Value > 0)
		{
			MotorDecorations? motorDecorationConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorDecorationConfig(num.Value);
			list.Add(new MotorcycleDiyStickerDecoItemData
			{
				Part = partId,
				ItemId = num.Value,
				QualityId = ((motorDecorationConfig != null) ? motorDecorationConfig.Value.QualityId : 0),
				SortIndex = ((motorDecorationConfig != null) ? motorDecorationConfig.Value.SortIndex : 0)
			});
		}
		foreach (int num2 in ModelBase<MotorcycleDiyModel>.Instance.GetCanUseDecorationsIdsInRegion())
		{
			MotorDecorations? motorDecorationConfig2 = ConfigBase<MotorDiyConfig>.Instance.GetMotorDecorationConfig(num2);
			if (motorDecorationConfig2 != null && motorDecorationConfig2.Value.PartId == partId)
			{
				EOutLookState decorationState = ModelBase<MotorcycleDiyModel>.Instance.GetDecorationState(num2);
				if (decorationState != EOutLookState.IsHide && decorationState != EOutLookState.IsEquipped)
				{
					list.Add(new MotorcycleDiyStickerDecoItemData
					{
						Part = partId,
						ItemId = num2,
						QualityId = motorDecorationConfig2.Value.QualityId,
						SortIndex = motorDecorationConfig2.Value.SortIndex
					});
				}
			}
		}
		return list;
	}

	// Token: 0x06010F5A RID: 69466 RVA: 0x004A58BC File Offset: 0x004A3ABC
	private int GetDecorationSortPriority(MotorcycleDiyStickerDecoItemData data)
	{
		if (data.ItemId == 0)
		{
			return 0;
		}
		EOutLookState decorationState = ModelBase<MotorcycleDiyModel>.Instance.GetDecorationState(data.ItemId);
		if (decorationState == EOutLookState.IsEquipped)
		{
			return 1;
		}
		if (ModelBase<MotorcycleDiyModel>.Instance.CheckRedDotInViewOpenCache(data.ItemId))
		{
			return 2;
		}
		if (decorationState == EOutLookState.CanEquipped)
		{
			return 3;
		}
		if (decorationState == EOutLookState.IsLock)
		{
			return 4;
		}
		if (decorationState == EOutLookState.IsBan)
		{
			return 5;
		}
		return 6;
	}

	// Token: 0x06010F5B RID: 69467 RVA: 0x004A5914 File Offset: 0x004A3B14
	private int SortDecorationItemFunc(MotorcycleDiyStickerDecoItemData dataA, MotorcycleDiyStickerDecoItemData dataB)
	{
		int decorationSortPriority = this.GetDecorationSortPriority(dataA);
		int decorationSortPriority2 = this.GetDecorationSortPriority(dataB);
		if (decorationSortPriority != decorationSortPriority2)
		{
			return decorationSortPriority - decorationSortPriority2;
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

	// Token: 0x06010F5C RID: 69468 RVA: 0x004A5960 File Offset: 0x004A3B60
	private void RefreshScrollViewByData(int partId, bool isNeedRefresh)
	{
		if (isNeedRefresh)
		{
			ModelBase<MotorcycleDiyModel>.Instance.CollectRedDotOnViewOpen(EOutlookType.Decoration, new int?(partId));
			List<MotorcycleDiyStickerDecoItemData> decorationDataList = this.GetDecorationItemDataList(partId);
			decorationDataList.Sort(new Comparison<MotorcycleDiyStickerDecoItemData>(this.SortDecorationItemFunc));
			this.CachedDecorationDataList = decorationDataList;
			this.DecorationScrollView.RefreshByData(decorationDataList, true, delegate
			{
				this.AutoSelectGridByDataList(partId, decorationDataList);
			}, false);
			return;
		}
		this.DecorationScrollView.RefreshByData(this.CachedDecorationDataList, true, null, false);
	}

	// Token: 0x06010F5D RID: 69469 RVA: 0x004A5A04 File Offset: 0x004A3C04
	private void AutoSelectGridByDataList(int decorationPart, List<MotorcycleDiyStickerDecoItemData> decorationDataList)
	{
		int gridIndex = 0;
		int selectDecorationId = 0;
		int selectedDecorationId = ModelBase<MotorcycleDiyModel>.Instance.GetSelectedDecorationId(decorationPart);
		if (selectedDecorationId != 0)
		{
			selectDecorationId = selectedDecorationId;
		}
		else
		{
			int? num = new int?(ModelBase<MotorcycleDiyModel>.Instance.GetEquippedDecorationId(decorationPart));
			selectDecorationId = ((num != null) ? num.Value : 0);
		}
		MotorcycleDiyStickerDecoItemData motorcycleDiyStickerDecoItemData = decorationDataList.FirstOrDefault((MotorcycleDiyStickerDecoItemData data) => data.ItemId == selectDecorationId);
		if (motorcycleDiyStickerDecoItemData != null)
		{
			gridIndex = decorationDataList.IndexOf(motorcycleDiyStickerDecoItemData);
		}
		if (!this.DecorationScrollView.IsGridDisplaying(gridIndex))
		{
			this.DecorationScrollView.ScrollToGridIndex(gridIndex, false);
		}
		this.DecorationScrollView.DeselectCurrentGridProxy(false);
		this.DecorationScrollView.SelectGridProxy(gridIndex, false);
	}

	// Token: 0x06010F5E RID: 69470 RVA: 0x004A5AB8 File Offset: 0x004A3CB8
	private void OnDecorationInfoUpdate()
	{
		ModelBase<MotorcycleDiyModel>.Instance.CollectRedDotOnViewOpen(EOutlookType.Decoration, null);
		this.RefreshScrollViewByData(this.CurrentSelectDecorationPart, false);
	}

	// Token: 0x06010F5F RID: 69471 RVA: 0x004A5AE8 File Offset: 0x004A3CE8
	private void OnClickDecoration(int decorationId, UUIExtendToggle toggle, UUIItem newItem)
	{
		EOutLookState decorationState = ModelBase<MotorcycleDiyModel>.Instance.GetDecorationState(decorationId);
		if (decorationState == EOutLookState.IsBan)
		{
			toggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			ValueTuple<string, string>? banTips = ModelBase<MotorcycleDiyModel>.Instance.GetBanTips(EOutlookType.Decoration, decorationId);
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
		this.UiViewSequence.StopSequenceByKey("Switch", false, false);
		this.UiViewSequence.PlaySequencePurely("Switch", false, false);
		if (decorationId == 0)
		{
			Singleton<MotorcycleUiModelUtil>.Instance.SetEmptyDecoration(this.CurrentSelectDecorationPart);
		}
		else
		{
			Singleton<MotorcycleUiModelUtil>.Instance.AddDecoration(decorationId, null);
		}
		bool flag = ModelBase<MotorcycleDiyModel>.Instance.IsEquipDefaultDecoration(this.CurrentSelectDecorationPart);
		bool flag2 = decorationId == 0 && !flag;
		ModelBase<MotorcycleDiyModel>.Instance.SetSelectDecorationInfo(this.CurrentSelectDecorationPart, decorationId);
		if (decorationState == EOutLookState.CanEquipped || flag2)
		{
			List<int> selectedDecorationIdList = ModelBase<MotorcycleDiyModel>.Instance.GetSelectedDecorationIdList(true);
			ControllerBase<MotorcycleDiyController>.Instance.EquipMotorDecorationRequest(selectedDecorationIdList, null);
		}
		Action<EOutlookType, int, int> onSelectItemClick = this.OnSelectItemClick;
		if (onSelectItemClick != null)
		{
			onSelectItemClick(EOutlookType.Decoration, this.CurrentSelectDecorationPart, decorationId);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.MotorDiyInfoRedDotUpdate);
		this.RefreshScrollViewByData(this.CurrentSelectDecorationPart, false);
		UUIItem item = base.GetItem(7);
		UUIItem item2 = base.GetItem(10);
		UUIItem item3 = base.GetItem(12);
		UUIText text = base.GetText(11);
		UUIButtonComponent button = base.GetButton(9);
		UUIText text2 = base.GetText(13);
		UUIText text3 = base.GetText(6);
		UUIText text4 = base.GetText(8);
		item.SetUIActive(false);
		item2.SetUIActive(false);
		item3.SetUIActive(false);
		button.RootUIComp.Get().SetUIActive(false);
		if (decorationId <= 0)
		{
			string stringConfig = ConfigCommonParamById.GetStringConfig("MotorEmptyDecorationName");
			text4.SetUIActive(false);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text3, stringConfig, Array.Empty<object>());
			return;
		}
		text4.SetUIActive(true);
		MotorDecorations? motorDecorationConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorDecorationConfig(decorationId);
		if (motorDecorationConfig == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text4, motorDecorationConfig.Value.SubTitle, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text3, motorDecorationConfig.Value.Title, Array.Empty<object>());
		base.GetItem(7).SetUIActive(decorationState == EOutLookState.IsLock);
		int[] itemAccessArray = motorDecorationConfig.Value.GetItemAccessArray();
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
		button.RootUIComp.Get().SetUIActive(skipName != ESkipName.NoSkip && decorationState == EOutLookState.IsLock);
		item3.SetUIActive(decorationState == EOutLookState.IsLock);
		item2.SetUIActive(skipName == ESkipName.NoSkip && decorationState == EOutLookState.IsLock);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, accessPathConfig.Value.Description, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, accessPathConfig.Value.Description, Array.Empty<object>());
	}

	// Token: 0x06010F60 RID: 69472 RVA: 0x004A5E44 File Offset: 0x004A4044
	private void OnBtnJumpClick()
	{
		if (this.JumpId <= 0)
		{
			return;
		}
		SkipTaskManager.RunByConfigId(this.JumpId, null);
	}

	// Token: 0x04008584 RID: 34180
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponent<MotorcycleDiyPartTabItem> PartTabComponent;

	// Token: 0x04008585 RID: 34181
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<MotorcycleDiyStickerDecoItem, MotorcycleDiyStickerDecoItemData> DecorationScrollView;

	// Token: 0x04008586 RID: 34182
	private readonly List<MotorcycleDiyPartTabItemData> PartTabItemDataList = new List<MotorcycleDiyPartTabItemData>();

	// Token: 0x04008587 RID: 34183
	private List<MotorcycleDiyStickerDecoItemData> CachedDecorationDataList = new List<MotorcycleDiyStickerDecoItemData>();

	// Token: 0x04008588 RID: 34184
	[Nullable(2)]
	private UUIExtendToggle CurrentSelectToggle;

	// Token: 0x04008589 RID: 34185
	private int CurrentSelectDecorationPart;

	// Token: 0x0400858A RID: 34186
	private int JumpId;

	// Token: 0x020085D6 RID: 34262
	[NullableContext(0)]
	private class EMotorDecorationScrollViewComponent
	{
		// Token: 0x0402D460 RID: 185440
		public const int TabContent = 0;

		// Token: 0x0402D461 RID: 185441
		public const int TabItem = 1;

		// Token: 0x0402D462 RID: 185442
		public const int LoopScrollView = 2;

		// Token: 0x0402D463 RID: 185443
		public const int SVContent = 3;

		// Token: 0x0402D464 RID: 185444
		public const int TogMotoDiyStickerOrDecoTabItem = 4;

		// Token: 0x0402D465 RID: 185445
		public const int RightLayout = 5;

		// Token: 0x0402D466 RID: 185446
		public const int TxtDecorationName = 6;

		// Token: 0x0402D467 RID: 185447
		public const int LockItem = 7;

		// Token: 0x0402D468 RID: 185448
		public const int TxtCurEquip = 8;

		// Token: 0x0402D469 RID: 185449
		public const int BtnJump = 9;

		// Token: 0x0402D46A RID: 185450
		public const int TipsItem = 10;

		// Token: 0x0402D46B RID: 185451
		public const int TxtTipsName = 11;

		// Token: 0x0402D46C RID: 185452
		public const int TitleGetItem = 12;

		// Token: 0x0402D46D RID: 185453
		public const int TxtJump = 13;

		// Token: 0x0402D46E RID: 185454
		public const int BtnOverview = 14;

		// Token: 0x0402D46F RID: 185455
		public const int MenuItem = 15;

		// Token: 0x0402D470 RID: 185456
		public const int SmallTitleItem = 16;

		// Token: 0x0402D471 RID: 185457
		public const int NormalPanel = 17;

		// Token: 0x0402D472 RID: 185458
		public const int EditPresetPanel = 18;
	}
}
