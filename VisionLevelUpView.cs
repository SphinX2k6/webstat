using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002526 RID: 9510
[NullableContext(1)]
[Nullable(0)]
public class VisionLevelUpView : UiTabViewBase
{
	// Token: 0x060127E0 RID: 75744 RVA: 0x00517540 File Offset: 0x00515740
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(6, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action<EToggleState>(this.OnClickLockToggle)),
			new ValueTuple<int, Delegate>(6, new Action<EToggleState>(this.OnClickDeprecateToggle))
		};
	}

	// Token: 0x060127E1 RID: 75745 RVA: 0x0051768C File Offset: 0x0051588C
	protected override UniTask OnBeforeStartAsync()
	{
		VisionLevelUpView.<OnBeforeStartAsync>d__20 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionLevelUpView.<OnBeforeStartAsync>d__20>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060127E2 RID: 75746 RVA: 0x005176D0 File Offset: 0x005158D0
	protected override void OnStart()
	{
		this.ExpComponent = new ExpComponent(base.GetItem(0), false);
		this.ExpComponent.Init();
		this.ExpComponent.SetLevelFormatText("VisionLevel");
		this.ExpComponent.BindPlayCompleteCallBack(new Action<bool>(this.OnTweenComplete));
		this.ItemGridConsumeComponent.InitFilter(EItemGridConsumeLocalDropDown.VisionLevelUp, new Action<int>(this.ConditionFunction));
		this.ItemGridConsumeComponent.SetConsumeTexture(2);
		this.ItemGridConsumeComponent.SetSettingButtonVisible(true);
		this.ItemGridConsumeComponent.BindSettingButtonRedDot(ERedDotName.VisionLevelUpSetting);
		this.ItemGridConsumeComponent.SetSettingButtonClickCallBack(delegate
		{
			RedDotBase redDot = ModelBase<RedDotModel>.Instance.GetRedDot(ERedDotName.VisionLevelUpSetting);
			if (redDot != null && redDot.IsRedDotActive())
			{
				ControllerBase<PhantomBattleController>.Instance.RecordVisionLevelUpSettingRedDot();
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.VisionLevelUpSettingPopView, null, null);
		});
		int maxCount = this.ItemGridConsumeComponent.GetMaxCount();
		this.ConsumeList = new List<TCommonMultipleConsumeData>(maxCount);
		for (int i = 0; i < maxCount; i++)
		{
			this.ConsumeList.Add(new TCommonMultipleConsumeData(new InventoryDefine.GetItemData(0, 0), 0));
		}
		this.VisionNameText = new VisionNameText(base.GetText(4));
	}

	// Token: 0x060127E3 RID: 75747 RVA: 0x005177DC File Offset: 0x005159DC
	private void ConditionFunction(int index)
	{
		this.CurrentAutoQualityIndex = index;
		int id = ConfigBase<CommonConfig>.Instance.GetItemQualityList()[this.CurrentAutoQualityIndex].Id;
		this.ItemGridConsumeComponent.RefreshConditionText(ConfigBase<CommonConfig>.Instance.GetItemQualityById(id).Value.ConsumeFilterText);
	}

	// Token: 0x060127E4 RID: 75748 RVA: 0x00517834 File Offset: 0x00515A34
	private void OnTweenComplete(bool isFinish)
	{
		if (!isFinish)
		{
			return;
		}
		Singleton<UiLayer>.Instance.SetShowMaskLayer("PhantomLevelUp", false);
		this.AnimateState = false;
		SelectableExpData currentExpData = this.GetCurrentExpData();
		this.CurrentExpData = currentExpData;
		this.ExpComponent.UpdateInitState(currentExpData);
	}

	// Token: 0x060127E5 RID: 75749 RVA: 0x00517878 File Offset: 0x00515A78
	private void ShowLevelSuccessView()
	{
		LevelUpPastVisionData cachePhantomLevelUpData = ModelBase<PhantomBattleModel>.Instance.GetCachePhantomLevelUpData();
		PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(this.CurrentVisionUniqueId);
		if (phantomItemDataByUniqueId == null)
		{
			return;
		}
		int phantomLevel = phantomItemDataByUniqueId.GetPhantomLevel();
		if (cachePhantomLevelUpData == null)
		{
			return;
		}
		if (cachePhantomLevelUpData.Level == phantomLevel)
		{
			List<Aki.Protocol.PhantomPropInfo> subProp = cachePhantomLevelUpData.SubProp;
			if (((subProp != null) ? subProp.Count : 0) >= phantomItemDataByUniqueId.GetPhantomSubProp().Count)
			{
				return;
			}
		}
		int visionLevelUpDelay = ConfigBase<PhantomBattleConfig>.Instance.GetVisionLevelUpDelay();
		TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			SkeletalObserverHandle visionSkeletalHandle = Singleton<UiSceneManager>.Instance.GetVisionSkeletalHandle();
			UiModelBase uiModelBase = (visionSkeletalHandle != null) ? visionSkeletalHandle.Model : null;
			if (uiModelBase != null)
			{
				Singleton<UiModelUtil>.Instance.SetRenderingMaterial(uiModelBase, "VisionStepupController");
			}
			ILevelUpSuccessAttributeData levelUpSuccessData = ModelBase<PhantomBattleModel>.Instance.GetLevelUpSuccessData(this.CurrentVisionUniqueId);
			levelUpSuccessData.ClickFunction = delegate()
			{
				UiInteractLogReport.ReportSpaceKeyInteract(EUiInteractSpaceKeyType.VisionLevelUp);
				this.CheckAndCloseItemHintViewNew();
			};
			ControllerBase<RoleLevelUpSuccessController>.Instance.OpenSuccessAttributeView(levelUpSuccessData, null);
			ItemHintViewNewData itemHintViewNewData = new ItemHintViewNewData();
			itemHintViewNewData.CheckPriorNext = (() => ModelBase<PhantomBattleModel>.Instance.GetTempSaveItemList().Length != 0);
			itemHintViewNewData.ShiftPriorItem = delegate()
			{
				TItem? titem = ModelBase<PhantomBattleModel>.Instance.ShiftTempSaveItemList();
				if (titem == null)
				{
					return new ItemRewardInfo();
				}
				ItemRewardInfo itemRewardInfo = new ItemRewardInfo();
				itemRewardInfo.ItemId = new int?(titem.Value.ItemData.ItemId);
				itemRewardInfo.ItemCount = new int?(titem.Value.Count);
				CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(titem.Value.ItemData.ItemId);
				itemRewardInfo.Quality = itemConfigData.QualityId;
				return itemRewardInfo;
			};
			itemHintViewNewData.TitleTextId = "Text_ItemReturnTitle_Text";
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ItemHintViewNew, itemHintViewNewData, null);
		}, (float)visionLevelUpDelay, null, null, true, 1f);
	}

	// Token: 0x060127E6 RID: 75750 RVA: 0x00517904 File Offset: 0x00515B04
	private void CheckAndCloseItemHintViewNew()
	{
		if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ItemHintViewNew))
		{
			return;
		}
		Singleton<UiManager>.Instance.CloseView(EUiViewName.ItemHintViewNew, null);
	}

	// Token: 0x060127E7 RID: 75751 RVA: 0x00517928 File Offset: 0x00515B28
	private void OnPhantomInfoUpdate()
	{
		this.CurrentSelectedMat.Clear();
		this.ClearConsume();
		this.ItemGridConsumeComponent.UpdateComponent(2, 0, this.ConsumeList);
		this.CurrentAddLevel = 0;
		this.PlayExpTween();
		this.RefreshItemGridConsume();
		this.RefreshAttributePreview();
		this.ShowLevelSuccessView();
	}

	// Token: 0x060127E8 RID: 75752 RVA: 0x00517978 File Offset: 0x00515B78
	private void PlayExpTween()
	{
		if (this.CurrentExpData.GetCurrentAddExp() > 0f)
		{
			Singleton<UiLayer>.Instance.SetShowMaskLayer("PhantomLevelUp", true);
			this.AnimateState = true;
			this.ExpComponent.PlayExpTween(this.CurrentExpData);
		}
	}

	// Token: 0x060127E9 RID: 75753 RVA: 0x005179B4 File Offset: 0x00515BB4
	private void OnItemFuncValueChange(int uniqueId)
	{
		if (uniqueId != this.CurrentVisionUniqueId)
		{
			return;
		}
		this.RefreshToggleState();
	}

	// Token: 0x060127EA RID: 75754 RVA: 0x005179C6 File Offset: 0x00515BC6
	private void OnVisionLevelUpMaterialPutInModeChange()
	{
		this.RefreshPutInModeState();
	}

	// Token: 0x060127EB RID: 75755 RVA: 0x005179CE File Offset: 0x00515BCE
	private void OnVisionLevelUpIdentifyChange()
	{
		this.RefreshItemAndExp();
	}

	// Token: 0x060127EC RID: 75756 RVA: 0x005179D8 File Offset: 0x00515BD8
	private void SetUniqueId(int uniqueId)
	{
		this.CurrentVisionUniqueId = uniqueId;
		SelectableExpData currentExpData = this.GetCurrentExpData();
		this.ExpComponent.UpdateInitState(currentExpData);
		this.OnChangeSelectedFunction(new List<ISelectedData>(), currentExpData);
	}

	// Token: 0x060127ED RID: 75757 RVA: 0x00517A0C File Offset: 0x00515C0C
	private SelectableExpData GetCurrentExpData()
	{
		CommonIntensifyPropExpData commonIntensifyPropExpData = new CommonIntensifyPropExpData();
		PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(this.CurrentVisionUniqueId);
		if (phantomItemDataByUniqueId == null)
		{
			return SelectableExpData.PhraseData(commonIntensifyPropExpData);
		}
		commonIntensifyPropExpData.CurrentExp = phantomItemDataByUniqueId.GetExp();
		commonIntensifyPropExpData.CurrentLevel = phantomItemDataByUniqueId.GetPhantomLevel();
		commonIntensifyPropExpData.CurrentMaxLevel = ControllerBase<PhantomBattleController>.Instance.GetMaxLevel(this.CurrentVisionUniqueId);
		commonIntensifyPropExpData.MaxExpFunction = new Func<int, int>(this.MaxExpFunction);
		return SelectableExpData.PhraseData(commonIntensifyPropExpData);
	}

	// Token: 0x060127EE RID: 75758 RVA: 0x00517A80 File Offset: 0x00515C80
	protected override void OnBeforeShow()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.PhantomLevelUp, new Action(this.OnPhantomInfoUpdate));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnItemFuncValueChange, new Action<int>(this.OnItemFuncValueChange));
		Singleton<EventSystem>.Instance.Add(EEventName.OnVisionLevelUpMaterialPutInModeChange, new Action(this.OnVisionLevelUpMaterialPutInModeChange));
		Singleton<EventSystem>.Instance.Add(EEventName.OnVisionLevelUpIdentifyChange, new Action(this.OnVisionLevelUpIdentifyChange));
		this.EventRegistState = true;
		this.CurrentVisionUniqueId = (int)(this.ExtraParams ?? 0);
		this.CurrentAddLevel = 0;
		this.SetUniqueId(this.CurrentVisionUniqueId);
		this.RefreshName();
		this.RefreshToggleState();
		this.RefreshPutInModeState();
	}

	// Token: 0x060127EF RID: 75759 RVA: 0x00517B44 File Offset: 0x00515D44
	private void RefreshName()
	{
		PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(this.CurrentVisionUniqueId);
		if (phantomItemDataByUniqueId == null)
		{
			return;
		}
		this.VisionNameText.Update(phantomItemDataByUniqueId);
	}

	// Token: 0x060127F0 RID: 75760 RVA: 0x00517B74 File Offset: 0x00515D74
	private void RefreshAttributePreview()
	{
		PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(this.CurrentVisionUniqueId);
		if (phantomItemDataByUniqueId == null)
		{
			return;
		}
		List<AttrListScrollData> levelUpPreviewData = phantomItemDataByUniqueId.GetLevelUpPreviewData(phantomItemDataByUniqueId.GetPhantomLevel() + this.CurrentAddLevel);
		this.VisionMainAttributeComponent.Update(levelUpPreviewData.ToArray());
		List<VisionSubPropData> levelSubPropPreviewData = phantomItemDataByUniqueId.GetLevelSubPropPreviewData(phantomItemDataByUniqueId.GetPhantomLevel(), phantomItemDataByUniqueId.GetPhantomLevel() + this.CurrentAddLevel);
		VisionSubPropData[] array = new VisionSubPropData[levelSubPropPreviewData.Count];
		for (int i = 0; i < levelSubPropPreviewData.Count; i++)
		{
			array[i] = levelSubPropPreviewData[i];
		}
		this.LevelUpIdentifyComponent.Update(array, false);
		this.LevelUpIdentifyComponent.GetRootItem().SetUIActive(levelSubPropPreviewData.Count > 0);
	}

	// Token: 0x060127F1 RID: 75761 RVA: 0x00517C28 File Offset: 0x00515E28
	private void RefreshToggleState()
	{
		AttributeItemData attributeItemData = ModelBase<InventoryModel>.Instance.GetAttributeItemData(this.CurrentVisionUniqueId);
		if (attributeItemData == null)
		{
			return;
		}
		EToggleState state = attributeItemData.GetIsLock() ? EToggleState.ETT_UnChecked : EToggleState.ETT_Checked;
		base.GetExtendToggle(5).SetToggleState(state, false, false, false);
		EToggleState state2 = attributeItemData.GetIsDeprecated() ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(6).SetToggleState(state2, false, false, false);
	}

	// Token: 0x060127F2 RID: 75762 RVA: 0x00517C88 File Offset: 0x00515E88
	private void RefreshPutInModeState()
	{
		string textId = (ModelBase<PhantomBattleModel>.Instance.GetVisionLevelUpMaterialPutInMode() == EVisionLevelUpMaterialPutInMode.AllIn) ? "Text_QuickInsertion_Text" : "Text_StageInsertion_Text";
		ItemGridConsumeComponent itemGridConsumeComponent = this.ItemGridConsumeComponent;
		if (itemGridConsumeComponent == null)
		{
			return;
		}
		itemGridConsumeComponent.UpdateAutoSelectTextByTextId(textId);
	}

	// Token: 0x060127F3 RID: 75763 RVA: 0x00517CC0 File Offset: 0x00515EC0
	private bool CheckEnableIdentify(PhantomDataBase data)
	{
		bool flag = ModelBase<PhantomBattleModel>.Instance.GetVisionLevelUpIdentify() == EVisionLevelUpIdentify.EnableIdentify;
		bool flag2 = data.GetQuality() > 2;
		return flag && flag2;
	}

	// Token: 0x060127F4 RID: 75764 RVA: 0x00517CE8 File Offset: 0x00515EE8
	private void RemoveEvent()
	{
		if (this.EventRegistState)
		{
			this.EventRegistState = false;
			Singleton<EventSystem>.Instance.Remove(EEventName.PhantomLevelUp, new Action(this.OnPhantomInfoUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnItemFuncValueChange, new Action<int>(this.OnItemFuncValueChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnVisionLevelUpMaterialPutInModeChange, new Action(this.OnVisionLevelUpMaterialPutInModeChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnVisionLevelUpIdentifyChange, new Action(this.OnVisionLevelUpIdentifyChange));
		}
	}

	// Token: 0x060127F5 RID: 75765 RVA: 0x00517D74 File Offset: 0x00515F74
	protected override void OnBeforeHide()
	{
		this.RemoveEvent();
	}

	// Token: 0x060127F6 RID: 75766 RVA: 0x00517D7C File Offset: 0x00515F7C
	private bool CheckSelectedMat()
	{
		if (this.CurrentSelectedMat == null || this.CurrentSelectedMat.Count == 0)
		{
			VisionLevelUpView.EStrengthBtnState? btnState = this.BtnState;
			VisionLevelUpView.EStrengthBtnState estrengthBtnState = VisionLevelUpView.EStrengthBtnState.Strength;
			if (btnState.GetValueOrDefault() == estrengthBtnState & btnState != null)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("VisionNotSelectItem", Array.Empty<object>());
				return false;
			}
		}
		return true;
	}

	// Token: 0x060127F7 RID: 75767 RVA: 0x00517DD2 File Offset: 0x00515FD2
	private bool CheckEnoughMoney()
	{
		if (!this.ItemGridConsumeComponent.GetEnoughMoney())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("WeaponNoEnoughMoneyText", Array.Empty<object>());
			return false;
		}
		return true;
	}

	// Token: 0x060127F8 RID: 75768 RVA: 0x00517DF8 File Offset: 0x00515FF8
	private void OnClickStrengthBtn(int _)
	{
		this.CheckCanLevelUp().Forget();
	}

	// Token: 0x060127F9 RID: 75769 RVA: 0x00517E08 File Offset: 0x00516008
	private UniTask CheckCanLevelUp()
	{
		VisionLevelUpView.<CheckCanLevelUp>d__44 <CheckCanLevelUp>d__;
		<CheckCanLevelUp>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CheckCanLevelUp>d__.<>4__this = this;
		<CheckCanLevelUp>d__.<>1__state = -1;
		<CheckCanLevelUp>d__.<>t__builder.Start<VisionLevelUpView.<CheckCanLevelUp>d__44>(ref <CheckCanLevelUp>d__);
		return <CheckCanLevelUp>d__.<>t__builder.Task;
	}

	// Token: 0x060127FA RID: 75770 RVA: 0x00517E4C File Offset: 0x0051604C
	[NullableContext(0)]
	private UniTask<bool> CheckIdentify()
	{
		CustomPromise<bool> customPromise = new CustomPromise<bool>();
		if (this.IdentifyConfirmBoxConfigId == null)
		{
			customPromise.SetResult(true);
			return customPromise.Promise;
		}
		if (this.CurrentSelectedMat.Count == 0 && this.IdentifyConfirmBoxConfigId.Value == EConfirmBoxConfigId.VisionLevelUpIdentifyLessMin)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("GenericPrompt_LevelUpMaterialShort_TipsText", Array.Empty<object>());
			customPromise.SetResult(false);
			return customPromise.Promise;
		}
		List<string> list = new List<string>();
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(this.IdentifyConfirmBoxConfigId.Value);
		list.Add(this.TargetIdentifyNum.ToString());
		confirmBoxDataNew.SetTextArgs(list.ToArray());
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			customPromise.SetResult(true);
		});
		confirmBoxDataNew.FunctionMap.Add(1, delegate
		{
			customPromise.SetResult(false);
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		return customPromise.Promise;
	}

	// Token: 0x060127FB RID: 75771 RVA: 0x00517F58 File Offset: 0x00516158
	private void LevelUpClick()
	{
		List<PhantomConsumeItem> data = new List<PhantomConsumeItem>();
		Dictionary<int, int> overItemMap = new Dictionary<int, int>();
		this.ProcessSelectedMat(data, overItemMap);
		this.ProcessAutoIdentity(overItemMap);
		this.ProcessOverExp(overItemMap);
		Action request = delegate()
		{
			if (!this.TryOpenLevelUpTipConfirmBox(data, overItemMap))
			{
				ControllerBase<PhantomBattleController>.Instance.SendPhantomLevelUpRequest(this.CurrentVisionUniqueId, data, this.TargetIdentifyNum);
			}
		};
		bool flag = false;
		foreach (PhantomConsumeItem phantomConsumeItem in data)
		{
			if (phantomConsumeItem.IncId > 0 && ModelBase<VisionEquipGroupModel>.Instance.CheckVisionListIfInGroup(new List<int>
			{
				phantomConsumeItem.IncId
			}))
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.DestroyVisionInGroup);
			confirmBoxDataNew.FunctionMap.Add(2, delegate
			{
				request();
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		request();
	}

	// Token: 0x060127FC RID: 75772 RVA: 0x00518070 File Offset: 0x00516270
	private void ProcessSelectedMat(List<PhantomConsumeItem> data, Dictionary<int, int> overItemMap)
	{
		foreach (ISelectedData selectedData in this.CurrentSelectedMat)
		{
			PhantomConsumeItem phantomConsumeItem = PhantomConsumeItem.Create();
			phantomConsumeItem.Count = selectedData.SelectedCount;
			phantomConsumeItem.IncId = selectedData.IncId;
			phantomConsumeItem.ItemId = selectedData.ItemId;
			data.Add(phantomConsumeItem);
			PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(selectedData.IncId);
			if (phantomItemDataByUniqueId != null)
			{
				Dictionary<int, int> identifyBackItem = phantomItemDataByUniqueId.GetIdentifyBackItem();
				this.AddBackItemToTargetMap(identifyBackItem, overItemMap);
			}
		}
	}

	// Token: 0x060127FD RID: 75773 RVA: 0x00518114 File Offset: 0x00516314
	private void ProcessAutoIdentity(Dictionary<int, int> overItemMap)
	{
		if (this.TargetIdentifyNum > 0)
		{
			PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(this.CurrentVisionUniqueId);
			if (phantomItemDataByUniqueId == null)
			{
				return;
			}
			int currentIdentifyCostId = phantomItemDataByUniqueId.GetCurrentIdentifyCostId();
			int num;
			overItemMap.TryGetValue(currentIdentifyCostId, out num);
			int currentIdentifyCostValue = phantomItemDataByUniqueId.GetCurrentIdentifyCostValue();
			int num2 = this.TargetIdentifyNum * currentIdentifyCostValue;
			if (num > num2)
			{
				overItemMap[currentIdentifyCostId] = num - num2;
				return;
			}
			overItemMap.Remove(currentIdentifyCostId);
		}
	}

	// Token: 0x060127FE RID: 75774 RVA: 0x0051817C File Offset: 0x0051637C
	private void ProcessOverExp(Dictionary<int, int> overItemMap)
	{
		int overExp = this.CurrentExpData.GetOverExp();
		if (overExp > 0)
		{
			Dictionary<int, int> source = ModelBase<PhantomBattleModel>.Instance.CalculateExpBackItem(overExp);
			this.AddBackItemToTargetMap(source, overItemMap);
		}
	}

	// Token: 0x060127FF RID: 75775 RVA: 0x005181B0 File Offset: 0x005163B0
	private bool TryOpenLevelUpTipConfirmBox(List<PhantomConsumeItem> data, Dictionary<int, int> overItemMap)
	{
		if (ModelBase<PhantomBattleModel>.Instance.LevelUpConfirmTipsNotShow)
		{
			return false;
		}
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		foreach (ISelectedData selectedData in this.CurrentSelectedMat)
		{
			PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(selectedData.IncId);
			if (phantomItemDataByUniqueId != null)
			{
				if (!flag && ModelBase<PhantomBattleModel>.Instance.IsVisionHighQuality(phantomItemDataByUniqueId))
				{
					flag = true;
				}
				if (!flag2 && ModelBase<PhantomBattleModel>.Instance.IsVisionHighLevel(phantomItemDataByUniqueId))
				{
					flag2 = true;
				}
				if (!flag3 && ModelBase<PhantomBattleModel>.Instance.IsVisionHighRare(phantomItemDataByUniqueId))
				{
					flag3 = true;
				}
			}
		}
		List<string> list = new List<string>();
		if (flag)
		{
			string textById = ConfigBase<TextConfig>.Instance.GetTextById("VisionHighQuality");
			if (textById != null && textById.Length > 0)
			{
				list.Add(textById);
			}
		}
		if (flag2)
		{
			string textById2 = ConfigBase<TextConfig>.Instance.GetTextById("VisionHighLevel");
			if (textById2 != null && textById2.Length > 0)
			{
				list.Add(textById2);
			}
		}
		if (flag3)
		{
			string textById3 = ConfigBase<TextConfig>.Instance.GetTextById("VisionHighRare");
			if (textById3 != null && textById3.Length > 0)
			{
				list.Add(textById3);
			}
		}
		bool flag4 = overItemMap.Count > 0;
		bool flag5 = list.Count > 0;
		ConfirmBoxDataNew confirmBoxDataNew = null;
		if (flag4 && flag5)
		{
			confirmBoxDataNew = this.CreateLevelUpTipsWithAll(list, overItemMap);
		}
		else if (flag4)
		{
			confirmBoxDataNew = this.CreateLevelUpTipsWithOverflow(overItemMap);
		}
		else if (flag5)
		{
			confirmBoxDataNew = this.CreateLevelUpTipsWithCondition(list);
		}
		if (confirmBoxDataNew == null)
		{
			return false;
		}
		confirmBoxDataNew.HasToggle = true;
		confirmBoxDataNew.ToggleText = ConfigMultiTextLang.GetLocalTextNew("Text_PhantomLevelUpTips_Text", null);
		confirmBoxDataNew.SetToggleFunction(delegate(bool isSelectOn)
		{
			ModelBase<PhantomBattleModel>.Instance.LevelUpConfirmTipsNotShow = isSelectOn;
		});
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			ControllerBase<PhantomBattleController>.Instance.SendPhantomLevelUpRequest(this.CurrentVisionUniqueId, data, this.TargetIdentifyNum);
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		return true;
	}

	// Token: 0x06012800 RID: 75776 RVA: 0x005183B8 File Offset: 0x005165B8
	private ConfirmBoxDataNew CreateLevelUpTipsWithCondition(List<string> words)
	{
		EConfirmBoxConfigId? econfirmBoxConfigId = null;
		switch (words.Count)
		{
		case 1:
			econfirmBoxConfigId = new EConfirmBoxConfigId?(EConfirmBoxConfigId.VisionLevelUpTips1);
			break;
		case 2:
			econfirmBoxConfigId = new EConfirmBoxConfigId?(EConfirmBoxConfigId.VisionLevelUpTips2);
			break;
		case 3:
			econfirmBoxConfigId = new EConfirmBoxConfigId?(EConfirmBoxConfigId.VisionLevelUpTips3);
			break;
		}
		if (econfirmBoxConfigId == null)
		{
			return new ConfirmBoxDataNew(EConfirmBoxConfigId.VisionLevelUpTips1);
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(econfirmBoxConfigId.Value);
		confirmBoxDataNew.SetTextArgs(words.ToArray());
		return confirmBoxDataNew;
	}

	// Token: 0x06012801 RID: 75777 RVA: 0x00518432 File Offset: 0x00516632
	private ConfirmBoxDataNew CreateLevelUpTipsWithOverflow(Dictionary<int, int> overItemMap)
	{
		return new ConfirmBoxDataNew(EConfirmBoxConfigId.WeaponOverflowExpTip)
		{
			ItemIdMap = overItemMap
		};
	}

	// Token: 0x06012802 RID: 75778 RVA: 0x00518444 File Offset: 0x00516644
	private ConfirmBoxDataNew CreateLevelUpTipsWithAll(List<string> words, Dictionary<int, int> overItemMap)
	{
		EConfirmBoxConfigId? econfirmBoxConfigId = null;
		switch (words.Count)
		{
		case 1:
			econfirmBoxConfigId = new EConfirmBoxConfigId?(EConfirmBoxConfigId.VisionLevelUpTipsOverflow1);
			break;
		case 2:
			econfirmBoxConfigId = new EConfirmBoxConfigId?(EConfirmBoxConfigId.VisionLevelUpTipsOverflow2);
			break;
		case 3:
			econfirmBoxConfigId = new EConfirmBoxConfigId?(EConfirmBoxConfigId.VisionLevelUpTipsOverflow3);
			break;
		}
		if (econfirmBoxConfigId == null)
		{
			return new ConfirmBoxDataNew(EConfirmBoxConfigId.VisionLevelUpTipsOverflow1);
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(econfirmBoxConfigId.Value);
		confirmBoxDataNew.SetTextArgs(words.ToArray());
		confirmBoxDataNew.ItemIdMap = overItemMap;
		return confirmBoxDataNew;
	}

	// Token: 0x06012803 RID: 75779 RVA: 0x005184D4 File Offset: 0x005166D4
	private void AddBackItemToTargetMap(Dictionary<int, int> source, Dictionary<int, int> target)
	{
		foreach (KeyValuePair<int, int> keyValuePair in source)
		{
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			int num;
			target.TryGetValue(key, out num);
			num += value;
			target[key] = num;
		}
	}

	// Token: 0x06012804 RID: 75780 RVA: 0x00518544 File Offset: 0x00516744
	private void OnClickDeleteSelectFunction()
	{
		this.CurrentSelectedMat.Clear();
		this.RefreshItemAndExp();
	}

	// Token: 0x06012805 RID: 75781 RVA: 0x00518558 File Offset: 0x00516758
	private void OnClickAutoFunction(int _)
	{
		int id = ConfigBase<CommonConfig>.Instance.GetItemQualityList()[this.CurrentAutoQualityIndex].Id;
		PhantomBattleModel instance = ModelBase<PhantomBattleModel>.Instance;
		EVisionLevelUpMaterialUseType visionLevelUpMaterialUseType = instance.GetVisionLevelUpMaterialUseType();
		ItemDataBase[] sortedExpMaterialList = instance.GetSortedExpMaterialList(this.CurrentVisionUniqueId, id, visionLevelUpMaterialUseType == EVisionLevelUpMaterialUseType.OnlyLevelUpMaterial);
		if (sortedExpMaterialList.Length == 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("RoleNoMaterial", Array.Empty<object>());
			return;
		}
		List<ISelectedData> list = new List<ISelectedData>();
		foreach (ItemDataBase itemDataBase in sortedExpMaterialList)
		{
			SelectedData item = new SelectedData
			{
				IncId = itemDataBase.GetUniqueId(),
				ItemId = itemDataBase.GetConfigId(),
				Count = itemDataBase.GetCount(),
				SelectedCount = 0
			};
			list.Add(item);
		}
		bool flag = instance.GetVisionLevelUpMaterialPutInMode() == EVisionLevelUpMaterialPutInMode.StepIn;
		int needExp = 0;
		if (flag)
		{
			IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("VisionLevelStageList");
			if (intArrayConfig == null || intArrayConfig.Count == 0)
			{
				return;
			}
			int currentLevel = this.CurrentExpData.GetCurrentLevel();
			int currentMaxLevel = this.CurrentExpData.GetCurrentMaxLevel();
			using (IEnumerator<int> enumerator = intArrayConfig.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int num = enumerator.Current;
					if (num > currentMaxLevel)
					{
						break;
					}
					if (num > currentLevel)
					{
						needExp = this.CurrentExpData.GetExpDistanceToLevel(num);
						break;
					}
				}
				goto IL_156;
			}
		}
		needExp = this.CurrentExpData.GetExpDistanceToMax();
		IL_156:
		WeaponModel instance2 = ModelBase<WeaponModel>.Instance;
		int maxCount = this.ItemGridConsumeComponent.GetMaxCount();
		if (flag && !instance2.CheckSatisfyExp(needExp, maxCount, list.ToArray(), new Func<ISelectedData, int>(this.GetItemExpFunction)))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_EchoMaterialLack_Text", Array.Empty<object>());
		}
		List<ISelectedData> currentSelectedMat = instance2.AutoAddExpItem(needExp, maxCount, list.ToArray(), new Func<ISelectedData, int>(this.GetItemExpFunction));
		this.CurrentSelectedMat = currentSelectedMat;
		this.RefreshItemAndExp();
	}

	// Token: 0x06012806 RID: 75782 RVA: 0x00518748 File Offset: 0x00516948
	private void RefreshItemAndExp()
	{
		int num = 0;
		this.ClearConsume();
		if (this.CurrentSelectedMat != null)
		{
			for (int i = 0; i < this.CurrentSelectedMat.Count; i++)
			{
				ISelectedData selectedData = this.CurrentSelectedMat[i];
				TCommonMultipleConsumeData value = this.ConsumeList[i];
				value.ItemData = new InventoryDefine.GetItemData(selectedData.ItemId, selectedData.IncId);
				value.Count = selectedData.SelectedCount;
				this.ConsumeList[i] = value;
				num += this.GetItemExpFunction(selectedData) * selectedData.SelectedCount;
			}
		}
		this.CurrentExpData.UpdateExp(num);
		this.ExpComponent.Update(this.CurrentExpData, true);
		this.CurrentAddLevel = this.CurrentExpData.GetArrivedLevel() - this.CurrentExpData.GetCurrentLevel();
		int expDistanceToMax = this.CurrentExpData.GetExpDistanceToMax();
		int levelUpNeedCost = ControllerBase<PhantomBattleController>.Instance.GetLevelUpNeedCost(Math.Min(num, expDistanceToMax));
		this.ItemGridConsumeComponent.UpdateComponent(2, levelUpNeedCost, this.ConsumeList);
		this.RefreshItemGridConsume();
		this.RefreshAttributePreview();
	}

	// Token: 0x06012807 RID: 75783 RVA: 0x0051885C File Offset: 0x00516A5C
	private void ClearConsume()
	{
		for (int i = 0; i < this.ConsumeList.Count; i++)
		{
			TCommonMultipleConsumeData value = new TCommonMultipleConsumeData(new InventoryDefine.GetItemData(0, 0), 0);
			this.ConsumeList[i] = value;
		}
	}

	// Token: 0x06012808 RID: 75784 RVA: 0x0051889C File Offset: 0x00516A9C
	private void OnClickItemReduce(int? incId, int? itemId)
	{
		for (int i = this.CurrentSelectedMat.Count - 1; i >= 0; i--)
		{
			int itemId2 = this.CurrentSelectedMat[i].ItemId;
			int? num = itemId;
			if (itemId2 == num.GetValueOrDefault() & num != null)
			{
				int incId2 = this.CurrentSelectedMat[i].IncId;
				num = incId;
				if (incId2 == num.GetValueOrDefault() & num != null)
				{
					ISelectedData selectedData = this.CurrentSelectedMat[i];
					int selectedCount = selectedData.SelectedCount;
					selectedData.SelectedCount = selectedCount - 1;
					if (this.CurrentSelectedMat[i].SelectedCount == 0)
					{
						this.CurrentSelectedMat.RemoveAt(i);
					}
				}
			}
		}
		this.RefreshItemAndExp();
	}

	// Token: 0x06012809 RID: 75785 RVA: 0x00518953 File Offset: 0x00516B53
	private void ItemClickFunction()
	{
		this.MaterialItemFunction(new int?(0), new int?(0));
	}

	// Token: 0x0601280A RID: 75786 RVA: 0x00518968 File Offset: 0x00516B68
	private void MaterialItemFunction(int? incId, int? itemId)
	{
		CommonItemSelectViewOpenViewData<ItemDataBase> commonItemSelectViewOpenViewData = new CommonItemSelectViewOpenViewData<ItemDataBase>();
		ItemDataBase[] expMaterialList = ModelBase<PhantomBattleModel>.Instance.GetExpMaterialList(this.CurrentVisionUniqueId, 0, false, false);
		PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(this.CurrentVisionUniqueId);
		if (phantomItemDataByUniqueId == null)
		{
			return;
		}
		CommonIntensifyPropExpData commonIntensifyPropExpData = new CommonIntensifyPropExpData();
		commonIntensifyPropExpData.CurrentExp = phantomItemDataByUniqueId.GetExp();
		commonIntensifyPropExpData.CurrentLevel = phantomItemDataByUniqueId.GetPhantomLevel();
		commonIntensifyPropExpData.CurrentMaxLevel = ControllerBase<PhantomBattleController>.Instance.GetMaxLevel(this.CurrentVisionUniqueId);
		commonIntensifyPropExpData.MaxExpFunction = new Func<int, int>(this.MaxExpFunction);
		commonIntensifyPropExpData.GetItemExpFunction = new Func<ISelectedData, int>(this.GetItemExpFunction);
		List<ISelectedData> currentSelectedMat = this.CurrentSelectedMat;
		commonItemSelectViewOpenViewData.ItemDataBaseList = expMaterialList.ToList<ItemDataBase>();
		commonItemSelectViewOpenViewData.SelectedDataList = (currentSelectedMat ?? new List<ISelectedData>());
		commonItemSelectViewOpenViewData.UseWayId = EFilterSortGroupId.VisionLevelUp;
		commonItemSelectViewOpenViewData.ExpData = commonIntensifyPropExpData;
		SelectableComponentData selectableComponentData = new SelectableComponentData();
		selectableComponentData.IsSingleSelected = false;
		selectableComponentData.MaxSelectedGridNum = this.ItemGridConsumeComponent.GetMaxCount();
		commonItemSelectViewOpenViewData.SelectableComponentData = selectableComponentData;
		selectableComponentData.OnChangeSelectedFunction = new Action<List<ISelectedData>, SelectableExpData>(this.OnChangeSelectedFunction);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonItemSelectViewRight, commonItemSelectViewOpenViewData, null);
	}

	// Token: 0x0601280B RID: 75787 RVA: 0x00518A80 File Offset: 0x00516C80
	private int MaxExpFunction(int level)
	{
		PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(this.CurrentVisionUniqueId);
		if (phantomItemDataByUniqueId == null)
		{
			return 0;
		}
		PhantomBattleInstance phantomInstanceByItemId = ModelBase<PhantomBattleModel>.Instance.GetPhantomInstanceByItemId(phantomItemDataByUniqueId.GetConfigId(false));
		if (phantomInstanceByItemId.PhantomItem == null)
		{
			return 0;
		}
		return ConfigBase<PhantomBattleConfig>.Instance.GetPhantomLevelExpByGroupIdAndLevel(phantomInstanceByItemId.PhantomItem.Value.LevelUpGroupId, level + 1);
	}

	// Token: 0x0601280C RID: 75788 RVA: 0x00518AEA File Offset: 0x00516CEA
	private void OnChangeSelectedFunction(List<ISelectedData> currentSelectedData, SelectableExpData expData)
	{
		this.CurrentSelectedMat = currentSelectedData;
		this.CurrentExpData = expData;
		this.RefreshItemAndExp();
	}

	// Token: 0x0601280D RID: 75789 RVA: 0x00518B00 File Offset: 0x00516D00
	private int GetItemExpFunction(ISelectedData selectedData)
	{
		PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(selectedData.IncId);
		if (phantomItemDataByUniqueId != null)
		{
			return phantomItemDataByUniqueId.GetEatFullExp();
		}
		return ConfigBase<PhantomBattleConfig>.Instance.GetPhantomExpItemById(selectedData.ItemId).Exp;
	}

	// Token: 0x0601280E RID: 75790 RVA: 0x00518B40 File Offset: 0x00516D40
	protected override void OnBeforeDestroy()
	{
		this.RemoveEvent();
		this.VisionMainAttributeComponent.Destroy(null);
		this.LevelUpIdentifyComponent.Destroy(null);
		this.CheckAndCloseItemHintViewNew();
		if (this.AnimateState)
		{
			Singleton<UiLayer>.Instance.SetShowMaskLayer("PhantomLevelUp", false);
		}
	}

	// Token: 0x0601280F RID: 75791 RVA: 0x00518B80 File Offset: 0x00516D80
	protected void OnClickLockToggle(EToggleState toggleState)
	{
		AttributeItemData attributeItemData = ModelBase<InventoryModel>.Instance.GetAttributeItemData(this.CurrentVisionUniqueId);
		if (attributeItemData == null)
		{
			return;
		}
		ControllerBase<InventoryController>.Instance.ItemLockRequest(this.CurrentVisionUniqueId, !attributeItemData.GetIsLock());
	}

	// Token: 0x06012810 RID: 75792 RVA: 0x00518BBC File Offset: 0x00516DBC
	protected void OnClickDeprecateToggle(EToggleState toggleState)
	{
		AttributeItemData attributeItemData = ModelBase<InventoryModel>.Instance.GetAttributeItemData(this.CurrentVisionUniqueId);
		if (attributeItemData == null)
		{
			return;
		}
		ControllerBase<InventoryController>.Instance.ItemDeprecateRequest(this.CurrentVisionUniqueId, !attributeItemData.GetIsDeprecated());
	}

	// Token: 0x06012811 RID: 75793 RVA: 0x00518BF8 File Offset: 0x00516DF8
	private void RefreshItemGridConsume()
	{
		PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(this.CurrentVisionUniqueId);
		if (phantomItemDataByUniqueId == null)
		{
			return;
		}
		bool enableIdentify = this.CheckEnableIdentify(phantomItemDataByUniqueId);
		this.RefreshStrengthBtnTxt(phantomItemDataByUniqueId, enableIdentify);
		this.RefreshIdentifyConsume(phantomItemDataByUniqueId, enableIdentify);
	}

	// Token: 0x06012812 RID: 75794 RVA: 0x00518C34 File Offset: 0x00516E34
	private void OnClickedRewardItem(MediumItemGridExtendCallback callbackParameter)
	{
		MediumItemGrid itemGridVariantSelect = this.ItemGridVariantSelect;
		if (itemGridVariantSelect != null)
		{
			itemGridVariantSelect.SetSelected(false, true);
		}
		PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(this.CurrentVisionUniqueId);
		if (phantomItemDataByUniqueId == null)
		{
			return;
		}
		int currentIdentifyCostId = phantomItemDataByUniqueId.GetCurrentIdentifyCostId();
		List<ItemDataBase> itemDataBaseByConfigId = ModelBase<InventoryModel>.Instance.GetItemDataBaseByConfigId(currentIdentifyCostId);
		int num = 0;
		if (itemDataBaseByConfigId.Count > 0)
		{
			num = itemDataBaseByConfigId[0].GetUniqueId();
		}
		if (num > 0)
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemUid(num, currentIdentifyCostId, true, null);
			return;
		}
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(currentIdentifyCostId, true, null);
	}

	// Token: 0x06012813 RID: 75795 RVA: 0x00518CB4 File Offset: 0x00516EB4
	private void RefreshIdentifyConsume(PhantomDataBase itemData, bool enableIdentify)
	{
		this.TargetIdentifyNum = 0;
		this.IdentifyConfirmBoxConfigId = null;
		if (!enableIdentify)
		{
			return;
		}
		foreach (VisionSubPropData visionSubPropData in itemData.GetLevelSubPropPreviewData(itemData.GetPhantomLevel(), itemData.GetPhantomLevel() + this.CurrentAddLevel))
		{
			if (visionSubPropData.SlotState == EVisionSlotState.PreviewUnLock || visionSubPropData.SlotState == EVisionSlotState.UnlockAndNoProp)
			{
				this.TargetIdentifyNum++;
			}
		}
		if (this.ItemGridVariantSelect == null)
		{
			this.ItemGridVariantSelect = new MediumItemGrid();
			this.ItemGridVariantSelect.Initialize(base.GetItem(10).GetOwner());
			this.ItemGridVariantSelect.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnClickedRewardItem));
		}
		int currentIdentifyCostId = itemData.GetCurrentIdentifyCostId();
		ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(currentIdentifyCostId);
		if (itemConfig == null)
		{
			return;
		}
		PropMediumItemGrid propMediumItemGrid = new PropMediumItemGrid
		{
			ItemConfigId = new int?(currentIdentifyCostId),
			StarLevel = new int?(itemConfig.Value.QualityId)
		};
		int currentIdentifyCostValue = itemData.GetCurrentIdentifyCostValue();
		List<ItemDataBase> itemDataBaseByConfigId = ModelBase<InventoryModel>.Instance.GetItemDataBaseByConfigId(currentIdentifyCostId);
		int num = 0;
		if (itemDataBaseByConfigId.Count > 0)
		{
			num = itemDataBaseByConfigId[0].GetCount();
		}
		int num2 = 0;
		if (this.TargetIdentifyNum > 0)
		{
			num2 = currentIdentifyCostValue * this.TargetIdentifyNum;
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			foreach (ISelectedData selectedData in this.CurrentSelectedMat)
			{
				PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(selectedData.IncId);
				if (phantomItemDataByUniqueId != null)
				{
					Dictionary<int, int> identifyBackItem = phantomItemDataByUniqueId.GetIdentifyBackItem();
					this.AddBackItemToTargetMap(identifyBackItem, dictionary);
				}
			}
			int currentIdentifyCostId2 = itemData.GetCurrentIdentifyCostId();
			int num3;
			dictionary.TryGetValue(currentIdentifyCostId2, out num3);
			int num4 = num;
			if (num3 > 0)
			{
				num2 = Math.Max(0, num2 - num3);
				num4 += num3;
			}
			if (num4 < currentIdentifyCostValue)
			{
				this.IdentifyConfirmBoxConfigId = new EConfirmBoxConfigId?(EConfirmBoxConfigId.VisionLevelUpIdentifyLessMin);
			}
			else if (num4 < this.TargetIdentifyNum * currentIdentifyCostValue)
			{
				this.IdentifyConfirmBoxConfigId = new EConfirmBoxConfigId?(EConfirmBoxConfigId.VisionLevelUpIdentifyLessTarget);
			}
			for (int i = this.TargetIdentifyNum; i >= 0; i--)
			{
				if (num4 >= i * currentIdentifyCostValue)
				{
					this.TargetIdentifyNum = i;
					break;
				}
			}
		}
		string id;
		if (num >= num2)
		{
			id = "Text_CollectProgress_Text";
		}
		else
		{
			id = "Text_ItemCostNotEnough_Text";
		}
		propMediumItemGrid.BottomText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew(id, null), new string[]
		{
			num.ToString(),
			num2.ToString()
		});
		MediumItemGrid itemGridVariantSelect = this.ItemGridVariantSelect;
		if (itemGridVariantSelect != null)
		{
			itemGridVariantSelect.Apply<PropMediumItemGrid>(propMediumItemGrid);
		}
		int num5 = this.GetIdentifyCostItemValue() * this.TargetIdentifyNum;
		int currentCostCount = this.ItemGridConsumeComponent.GetCurrentCostCount();
		this.ItemGridConsumeComponent.UpdateComponent(2, num5 + currentCostCount, this.ConsumeList);
	}

	// Token: 0x06012814 RID: 75796 RVA: 0x00518FA8 File Offset: 0x005171A8
	private int GetIdentifyCostItemValue()
	{
		PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(this.CurrentVisionUniqueId);
		if (phantomItemDataByUniqueId == null)
		{
			return 0;
		}
		return phantomItemDataByUniqueId.GetIdentifyCostItemValue();
	}

	// Token: 0x06012815 RID: 75797 RVA: 0x00518FD1 File Offset: 0x005171D1
	private void RefreshStrengthBtnTxt(PhantomDataBase itemData, bool enableIdentify)
	{
		this.BtnState = new VisionLevelUpView.EStrengthBtnState?(this.CalculateBtnState(itemData, enableIdentify));
		this.OnBtnState();
	}

	// Token: 0x06012816 RID: 75798 RVA: 0x00518FEC File Offset: 0x005171EC
	private VisionLevelUpView.EStrengthBtnState CalculateBtnState(PhantomDataBase itemData, bool enableIdentify)
	{
		int phantomLevel = itemData.GetPhantomLevel();
		int maxLevel = ControllerBase<PhantomBattleController>.Instance.GetMaxLevel(this.CurrentVisionUniqueId);
		bool flag = phantomLevel == maxLevel;
		bool flag2 = false;
		List<VisionSubPropData> levelSubPropData = itemData.GetLevelSubPropData(phantomLevel);
		using (List<VisionSubPropData>.Enumerator enumerator = levelSubPropData.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.SlotState == EVisionSlotState.UnlockAndNoProp)
				{
					flag2 = true;
					break;
				}
			}
		}
		bool flag3 = true;
		using (List<VisionSubPropData>.Enumerator enumerator = levelSubPropData.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.SlotState != EVisionSlotState.UnlockAndHaveProp)
				{
					flag3 = false;
					break;
				}
			}
		}
		bool flag4 = false;
		using (List<VisionSubPropData>.Enumerator enumerator = itemData.GetLevelSubPropPreviewData(phantomLevel, phantomLevel + this.CurrentAddLevel).GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.SlotState == EVisionSlotState.PreviewUnLock)
				{
					flag4 = true;
					break;
				}
			}
		}
		bool flag5 = this.CurrentSelectedMat.Count > 0;
		List<ValueTuple<bool, VisionLevelUpView.EStrengthBtnState>> list = new List<ValueTuple<bool, VisionLevelUpView.EStrengthBtnState>>();
		list.Add(new ValueTuple<bool, VisionLevelUpView.EStrengthBtnState>(enableIdentify && flag2 && !flag5, VisionLevelUpView.EStrengthBtnState.Identify));
		list.Add(new ValueTuple<bool, VisionLevelUpView.EStrengthBtnState>(enableIdentify && flag2 && flag5, VisionLevelUpView.EStrengthBtnState.StrengthAndIdentify));
		list.Add(new ValueTuple<bool, VisionLevelUpView.EStrengthBtnState>(enableIdentify && !flag2 && flag4, VisionLevelUpView.EStrengthBtnState.StrengthAndIdentify));
		list.Add(new ValueTuple<bool, VisionLevelUpView.EStrengthBtnState>(enableIdentify && flag && flag2, VisionLevelUpView.EStrengthBtnState.MaxLevelOnlyIdentify));
		list.Add(new ValueTuple<bool, VisionLevelUpView.EStrengthBtnState>(enableIdentify && flag && flag3, VisionLevelUpView.EStrengthBtnState.MaxLevelAndIdentify));
		list.Add(new ValueTuple<bool, VisionLevelUpView.EStrengthBtnState>(!enableIdentify && flag, VisionLevelUpView.EStrengthBtnState.MaxLevelNoIdentify));
		VisionLevelUpView.EStrengthBtnState result = VisionLevelUpView.EStrengthBtnState.Strength;
		foreach (ValueTuple<bool, VisionLevelUpView.EStrengthBtnState> valueTuple in list)
		{
			if (valueTuple.Item1)
			{
				result = valueTuple.Item2;
			}
		}
		return result;
	}

	// Token: 0x06012817 RID: 75799 RVA: 0x005191E0 File Offset: 0x005173E0
	private void SetMaxState(bool isMaxLevel, bool isMaxIdentify, string text)
	{
		PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(this.CurrentVisionUniqueId);
		if (phantomItemDataByUniqueId == null)
		{
			return;
		}
		bool costRootItemState;
		bool strengthItemEnable;
		bool maxItemEnable;
		bool consumeListEnable;
		bool uiactive;
		bool flag;
		bool uiactive2;
		bool uiactive3;
		if (this.CheckEnableIdentify(phantomItemDataByUniqueId))
		{
			costRootItemState = !isMaxIdentify;
			strengthItemEnable = !isMaxIdentify;
			maxItemEnable = (isMaxLevel && isMaxIdentify);
			consumeListEnable = !isMaxLevel;
			uiactive = isMaxLevel;
			flag = (isMaxLevel && isMaxIdentify);
			uiactive2 = !isMaxIdentify;
			uiactive3 = !isMaxIdentify;
		}
		else
		{
			costRootItemState = !isMaxLevel;
			strengthItemEnable = !isMaxLevel;
			maxItemEnable = isMaxLevel;
			consumeListEnable = !isMaxLevel;
			uiactive = isMaxLevel;
			flag = isMaxLevel;
			uiactive2 = false;
			uiactive3 = false;
		}
		ItemGridConsumeComponent itemGridConsumeComponent = this.ItemGridConsumeComponent;
		if (itemGridConsumeComponent != null)
		{
			itemGridConsumeComponent.SetCostRootItemState(costRootItemState);
		}
		ItemGridConsumeComponent itemGridConsumeComponent2 = this.ItemGridConsumeComponent;
		if (itemGridConsumeComponent2 != null)
		{
			itemGridConsumeComponent2.SetStrengthItemEnable(strengthItemEnable);
		}
		ItemGridConsumeComponent itemGridConsumeComponent3 = this.ItemGridConsumeComponent;
		if (itemGridConsumeComponent3 != null)
		{
			itemGridConsumeComponent3.SetMaxItemEnable(maxItemEnable);
		}
		ItemGridConsumeComponent itemGridConsumeComponent4 = this.ItemGridConsumeComponent;
		if (itemGridConsumeComponent4 != null)
		{
			itemGridConsumeComponent4.SetConsumeListEnable(consumeListEnable);
		}
		UUIItem item = base.GetItem(11);
		if (item != null)
		{
			item.SetUIActive(uiactive);
		}
		UUIItem item2 = base.GetItem(9);
		if (item2 != null)
		{
			item2.SetUIActive(uiactive2);
		}
		UUIItem item3 = base.GetItem(12);
		if (item3 != null)
		{
			item3.SetUIActive(uiactive3);
		}
		if (flag)
		{
			ItemGridConsumeComponent itemGridConsumeComponent5 = this.ItemGridConsumeComponent;
			if (itemGridConsumeComponent5 == null)
			{
				return;
			}
			itemGridConsumeComponent5.SetMaxItemText(text);
			return;
		}
		else
		{
			ItemGridConsumeComponent itemGridConsumeComponent6 = this.ItemGridConsumeComponent;
			if (itemGridConsumeComponent6 == null)
			{
				return;
			}
			itemGridConsumeComponent6.SetStrengthItemText(text);
			return;
		}
	}

	// Token: 0x06012818 RID: 75800 RVA: 0x00519304 File Offset: 0x00517504
	private void OnBtnState()
	{
		bool isMaxLevel = false;
		bool isMaxIdentify = false;
		VisionLevelUpView.EStrengthBtnState? btnState = this.BtnState;
		string text;
		if (btnState != null)
		{
			switch (btnState.GetValueOrDefault())
			{
			case VisionLevelUpView.EStrengthBtnState.Strength:
				text = "PrefabTextItem_1704419995_Text";
				goto IL_7E;
			case VisionLevelUpView.EStrengthBtnState.Identify:
				text = "IdentifyText";
				goto IL_7E;
			case VisionLevelUpView.EStrengthBtnState.StrengthAndIdentify:
				text = "TuneEchoesProject_Button2";
				goto IL_7E;
			case VisionLevelUpView.EStrengthBtnState.MaxLevelOnlyIdentify:
				text = "TuneEchoesProject_Button4";
				isMaxLevel = true;
				goto IL_7E;
			case VisionLevelUpView.EStrengthBtnState.MaxLevelNoIdentify:
				text = "PrefabTextItem_1826757657_Text";
				isMaxLevel = true;
				goto IL_7E;
			case VisionLevelUpView.EStrengthBtnState.MaxLevelAndIdentify:
				text = "PrefabTextItem_183779057_Text";
				isMaxLevel = true;
				isMaxIdentify = true;
				goto IL_7E;
			}
		}
		text = "PrefabTextItem_1704419995_Text";
		IL_7E:
		if (text == null)
		{
			return;
		}
		this.SetMaxState(isMaxLevel, isMaxIdentify, text);
	}

	// Token: 0x04009037 RID: 36919
	[Nullable(2)]
	private ExpComponent ExpComponent;

	// Token: 0x04009038 RID: 36920
	[Nullable(2)]
	private ItemGridConsumeComponent ItemGridConsumeComponent;

	// Token: 0x04009039 RID: 36921
	private int CurrentVisionUniqueId;

	// Token: 0x0400903A RID: 36922
	private int CurrentAddLevel;

	// Token: 0x0400903B RID: 36923
	private List<ISelectedData> CurrentSelectedMat = new List<ISelectedData>();

	// Token: 0x0400903C RID: 36924
	[Nullable(2)]
	private List<TCommonMultipleConsumeData> ConsumeList;

	// Token: 0x0400903D RID: 36925
	[Nullable(2)]
	private SelectableExpData CurrentExpData;

	// Token: 0x0400903E RID: 36926
	[Nullable(2)]
	private VisionMainAttributeComponent VisionMainAttributeComponent;

	// Token: 0x0400903F RID: 36927
	[Nullable(2)]
	private LevelUpIdentifyComponent LevelUpIdentifyComponent;

	// Token: 0x04009040 RID: 36928
	private int CurrentAutoQualityIndex;

	// Token: 0x04009041 RID: 36929
	private bool EventRegistState;

	// Token: 0x04009042 RID: 36930
	[Nullable(2)]
	private VisionNameText VisionNameText;

	// Token: 0x04009043 RID: 36931
	private bool AnimateState;

	// Token: 0x04009044 RID: 36932
	[Nullable(2)]
	private MediumItemGrid ItemGridVariantSelect;

	// Token: 0x04009045 RID: 36933
	private int TargetIdentifyNum;

	// Token: 0x04009046 RID: 36934
	private VisionLevelUpView.EStrengthBtnState? BtnState;

	// Token: 0x04009047 RID: 36935
	private EConfirmBoxConfigId? IdentifyConfirmBoxConfigId;

	// Token: 0x02008848 RID: 34888
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402E07E RID: 188542
		ExpItem,
		// Token: 0x0402E07F RID: 188543
		AttributeItem,
		// Token: 0x0402E080 RID: 188544
		ConsumeItem,
		// Token: 0x0402E081 RID: 188545
		SubAttributeItem,
		// Token: 0x0402E082 RID: 188546
		VisionName,
		// Token: 0x0402E083 RID: 188547
		LockToggle,
		// Token: 0x0402E084 RID: 188548
		DeprecateToggle,
		// Token: 0x0402E085 RID: 188549
		VisionIdentifyLayOutItem = 9,
		// Token: 0x0402E086 RID: 188550
		VisionIdentifyCostItem,
		// Token: 0x0402E087 RID: 188551
		MaxLevelTips,
		// Token: 0x0402E088 RID: 188552
		MaxLevelTipsText
	}

	// Token: 0x02008849 RID: 34889
	[NullableContext(0)]
	private enum EStrengthBtnState
	{
		// Token: 0x0402E08A RID: 188554
		Strength,
		// Token: 0x0402E08B RID: 188555
		Identify,
		// Token: 0x0402E08C RID: 188556
		StrengthAndIdentify,
		// Token: 0x0402E08D RID: 188557
		MaxLevelOnlyIdentify,
		// Token: 0x0402E08E RID: 188558
		MaxLevelNoIdentify,
		// Token: 0x0402E08F RID: 188559
		MaxLevelAndIdentify
	}
}
