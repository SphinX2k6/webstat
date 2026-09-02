using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AutoAttach;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001800 RID: 6144
[NullableContext(1)]
[Nullable(0)]
public class CalabashLevelUpTabView : UiTabViewBase
{
	// Token: 0x0600AE74 RID: 44660 RVA: 0x002E6AFC File Offset: 0x002E4CFC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(5, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIText)),
			new ValueTuple<int, Type>(11, typeof(UUIText)),
			new ValueTuple<int, Type>(12, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(6, new Action(this.OnRewardBtnClick)),
			new ValueTuple<int, Delegate>(2, new Action(this.OnHelpBtnClick))
		};
	}

	// Token: 0x0600AE75 RID: 44661 RVA: 0x002E6C74 File Offset: 0x002E4E74
	private void OnHelpBtnClick()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.CalabashExpTipId);
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600AE76 RID: 44662 RVA: 0x002E6C98 File Offset: 0x002E4E98
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.GetCalabashReward, new Action(this.RefreshCalabash));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnRewardViewClose));
	}

	// Token: 0x0600AE77 RID: 44663 RVA: 0x002E6CCF File Offset: 0x002E4ECF
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.GetCalabashReward, new Action(this.RefreshCalabash));
		Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnRewardViewClose));
	}

	// Token: 0x0600AE78 RID: 44664 RVA: 0x002E6D08 File Offset: 0x002E4F08
	protected override UniTask OnCreateAsync()
	{
		CalabashLevelUpTabView.<OnCreateAsync>d__16 <OnCreateAsync>d__;
		<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnCreateAsync>d__.<>4__this = this;
		<OnCreateAsync>d__.<>1__state = -1;
		<OnCreateAsync>d__.<>t__builder.Start<CalabashLevelUpTabView.<OnCreateAsync>d__16>(ref <OnCreateAsync>d__);
		return <OnCreateAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600AE79 RID: 44665 RVA: 0x002E6D4C File Offset: 0x002E4F4C
	protected override void OnStart()
	{
		this.CurrentSelectDetailType = ECalabashAttributeDataType.Default;
		this.NoCircleExhibitionView = new NoCircleAttachView<CalabashGridData, CalabashGrid>(base.GetItem(0).GetOwner(), false);
		UUIItem item = base.GetItem(1);
		item.SetUIActive(false);
		this.NoCircleExhibitionView.CreateItems(item.GetOwner(), 0f, new Func<AActor, int, int, CalabashGrid>(this.InitGrid), EAttachDirection.Horizontal);
		this.RewardLayout = new GenericLayout<CalabashLevelUpRewardItemGrid, CalabashRewardItemData>(base.GetHorizontalLayout(5), new Func<CalabashLevelUpRewardItemGrid>(this.CreateRewardItem), null, false, true);
		this.AttributeLayout = new GenericLayout<CalabashAttributeItem, CalabashAttributeData>(base.GetVerticalLayout(4), new Func<CalabashAttributeItem>(this.CreateAttributeItem), null, false, true);
	}

	// Token: 0x0600AE7A RID: 44666 RVA: 0x002E6DEC File Offset: 0x002E4FEC
	private CalabashGrid InitGrid(AActor actor, int index, int showNum)
	{
		CalabashGrid calabashGrid = new CalabashGrid();
		calabashGrid.CreateThenShowByActor(actor, null);
		calabashGrid.ButtonFunction = new Action<int>(this.MoveCalabashGrid);
		calabashGrid.CheckToggleCanClick = new Func<bool>(this.CheckToggleCanClick);
		calabashGrid.ItemCurve = this.ItemCurve;
		return calabashGrid;
	}

	// Token: 0x0600AE7B RID: 44667 RVA: 0x002E6E2B File Offset: 0x002E502B
	private bool CheckToggleCanClick()
	{
		return !this.NoCircleExhibitionView.MovingState();
	}

	// Token: 0x0600AE7C RID: 44668 RVA: 0x002E6E3B File Offset: 0x002E503B
	private CalabashLevelUpRewardItemGrid CreateRewardItem()
	{
		return new CalabashLevelUpRewardItemGrid();
	}

	// Token: 0x0600AE7D RID: 44669 RVA: 0x002E6E42 File Offset: 0x002E5042
	private CalabashAttributeItem CreateAttributeItem()
	{
		return new CalabashAttributeItem();
	}

	// Token: 0x0600AE7E RID: 44670 RVA: 0x002E6E49 File Offset: 0x002E5049
	protected override void OnBeforeShow()
	{
		this.RefreshNoCircleExhibitionView(this.NeedInitExhibition);
		this.NeedInitExhibition = false;
		this.RefreshCalabashPlayerInfo();
	}

	// Token: 0x0600AE7F RID: 44671 RVA: 0x002E6E64 File Offset: 0x002E5064
	private void OnRewardBtnClick()
	{
		int calabashLevel = ModelBase<CalabashModel>.Instance.GetCalabashLevel();
		List<int> list = new List<int>();
		for (int i = 0; i <= calabashLevel; i++)
		{
			if (ModelBase<CalabashModel>.Instance.GetReceiveRewardStateByLevel(i) == ECalabashRewardState.CanReceive)
			{
				list.Add(i);
			}
		}
		ControllerBase<CalabashController>.Instance.RequestMultiCalabashLevelReward(list.ToArray());
	}

	// Token: 0x0600AE80 RID: 44672 RVA: 0x002E6EB4 File Offset: 0x002E50B4
	private void OnRewardViewClose(EUiViewName viewName, int _)
	{
		if (viewName != EUiViewName.CommonRewardView)
		{
			return;
		}
		int value = ConfigCommonParamById.GetIntConfig("StrengthItemId").Value;
		if (this.AchieveStrengthItemNum == 0)
		{
			return;
		}
		ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(value);
		if (itemConfig == null || itemConfig.Value.Parameters() == null)
		{
			return;
		}
		int num = 0;
		using (Dictionary<int, int>.Enumerator enumerator = itemConfig.Value.Parameters().GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				KeyValuePair<int, int> keyValuePair = enumerator.Current;
				num = keyValuePair.Value;
			}
		}
		if (num == 0)
		{
			return;
		}
		PropRewardConf? config = ConfigPropRewardConfById.GetConfig(num, true);
		if (config == null)
		{
			return;
		}
		float num2 = 0f;
		foreach (ConfigPropValue configPropValue in config.Value.Props())
		{
			if (configPropValue.Id == 69)
			{
				num2 = configPropValue.Value * (float)this.AchieveStrengthItemNum;
				break;
			}
		}
		if (num2 == 0f)
		{
			return;
		}
		int num3 = (int)ControllerBase<FormationAttributeController>.Instance.GetBaseMax(EFormationAttributeId.Strength);
		PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(69);
		AttributeInfo item = new AttributeInfo
		{
			Name = propertyIndexInfo.Value.Name,
			IconPath = propertyIndexInfo.Value.Icon,
			ShowArrow = new bool?(true),
			PreText = Math.Floor((double)((float)num3 - num2) / 100.0).ToString(),
			CurText = Math.Floor((double)num3 / 100.0).ToString()
		};
		LevelUpSuccessAttributeData data = new LevelUpSuccessAttributeData
		{
			Title = "PrefabTextItem_HuluStaminaUp_Text",
			StrengthUpgradeData = new StrengthUpgradeData
			{
				AttributeId = EFormationAttributeId.Strength,
				SingleStrengthValue = ConfigCommonParamById.GetIntConfig("SingleStrengthValue").Value,
				MaxSingleStrengthItemCount = ConfigCommonParamById.GetIntConfig("MaxSingleStrengthItemCount").Value,
				MaxStrength = num3
			},
			AttributeInfo = new List<IAttributeInfo>
			{
				item
			}
		};
		ControllerBase<RoleLevelUpSuccessController>.Instance.OpenSuccessAttributeView(data, null);
		this.RefreshStrengthItemNum();
	}

	// Token: 0x0600AE81 RID: 44673 RVA: 0x002E7108 File Offset: 0x002E5308
	private void MoveCalabashGrid(int showIndex)
	{
		this.CurrentSelectedLevel = showIndex;
		if (this.NoCircleExhibitionView.GetCurrentSelectIndex() != showIndex)
		{
			this.NoCircleExhibitionView.AttachToIndex(showIndex, false);
		}
		this.OnSelectedLevelChange();
	}

	// Token: 0x0600AE82 RID: 44674 RVA: 0x002E7132 File Offset: 0x002E5332
	private void OnSelectedLevelChange()
	{
		this.RefreshSelectedLevelInfo();
		this.RefreshStrengthItemNum();
	}

	// Token: 0x0600AE83 RID: 44675 RVA: 0x002E7140 File Offset: 0x002E5340
	private void RefreshSelectedLevelInfo()
	{
		this.RefreshReward();
		this.RefreshButtonState();
		this.RefreshAttribute();
	}

	// Token: 0x0600AE84 RID: 44676 RVA: 0x002E7154 File Offset: 0x002E5354
	private void RefreshCalabashPlayerInfo()
	{
		int calabashLevel = ModelBase<CalabashModel>.Instance.GetCalabashLevel();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), "PrefabTextItem_HuluCurrentLv_Text", new <>z__ReadOnlySingleElementList<object>(calabashLevel));
		int calabashAllSchedule = ModelBase<CalabashModel>.Instance.GetCalabashAllSchedule();
		int calabashOwnSchedule = ModelBase<CalabashModel>.Instance.GetCalabashOwnSchedule();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), "Phanton_CollectNum", new <>z__ReadOnlyArray<object>(new object[]
		{
			calabashOwnSchedule,
			calabashAllSchedule
		}));
		this.RefreshExpText(calabashLevel);
	}

	// Token: 0x0600AE85 RID: 44677 RVA: 0x002E71E0 File Offset: 0x002E53E0
	private void RefreshReward()
	{
		int rewardId = ConfigBase<CalabashConfig>.Instance.GetCalabashConfigByLevel(this.CurrentSelectedLevel).Value.RewardId;
		if (rewardId <= 0)
		{
			GenericLayout<CalabashLevelUpRewardItemGrid, CalabashRewardItemData> rewardLayout = this.RewardLayout;
			if (rewardLayout != null)
			{
				rewardLayout.SetActive(false);
			}
			base.GetItem(12).SetUIActive(true);
			return;
		}
		Dictionary<int, int> dropPackagePreview = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreview(rewardId);
		GenericLayout<CalabashLevelUpRewardItemGrid, CalabashRewardItemData> rewardLayout2 = this.RewardLayout;
		if (rewardLayout2 != null)
		{
			rewardLayout2.SetActive(true);
		}
		base.GetItem(12).SetUIActive(false);
		ECalabashRewardState receiveRewardStateByLevel = ModelBase<CalabashModel>.Instance.GetReceiveRewardStateByLevel(this.CurrentSelectedLevel);
		int num = 0;
		foreach (KeyValuePair<int, int> keyValuePair in dropPackagePreview)
		{
			CalabashRewardItemData calabashRewardItemData;
			if (num < this.RewardDataList.Count)
			{
				calabashRewardItemData = this.RewardDataList[num];
			}
			else
			{
				calabashRewardItemData = new CalabashRewardItemData();
				this.RewardDataList.Add(calabashRewardItemData);
			}
			calabashRewardItemData.ReceiveState = receiveRewardStateByLevel;
			calabashRewardItemData.ItemData = new TItem?(new TItem(new InventoryDefine.GetItemData(keyValuePair.Key, 0), keyValuePair.Value));
			num++;
		}
		GenericLayout<CalabashLevelUpRewardItemGrid, CalabashRewardItemData> rewardLayout3 = this.RewardLayout;
		if (rewardLayout3 == null)
		{
			return;
		}
		rewardLayout3.RefreshByData(this.RewardDataList, null, false);
	}

	// Token: 0x0600AE86 RID: 44678 RVA: 0x002E732C File Offset: 0x002E552C
	private void RefreshStrengthItemNum()
	{
		this.AchieveStrengthItemNum = 0;
		int value = ConfigCommonParamById.GetIntConfig("StrengthItemId").Value;
		int calabashLevel = ModelBase<CalabashModel>.Instance.GetCalabashLevel();
		for (int i = 0; i <= calabashLevel; i++)
		{
			if (ModelBase<CalabashModel>.Instance.GetReceiveRewardStateByLevel(i) == ECalabashRewardState.CanReceive)
			{
				int rewardId = ConfigBase<CalabashConfig>.Instance.GetCalabashConfigByLevel(i).Value.RewardId;
				if (rewardId > 0)
				{
					foreach (KeyValuePair<int, int> keyValuePair in ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreview(rewardId))
					{
						if (value == keyValuePair.Key)
						{
							this.AchieveStrengthItemNum += keyValuePair.Value;
							break;
						}
					}
				}
			}
		}
	}

	// Token: 0x0600AE87 RID: 44679 RVA: 0x002E740C File Offset: 0x002E560C
	private void RefreshButtonState()
	{
		ECalabashRewardState receiveRewardStateByLevel = ModelBase<CalabashModel>.Instance.GetReceiveRewardStateByLevel(this.CurrentSelectedLevel);
		base.GetButton(6).RootUIComp.Get().SetUIActive(receiveRewardStateByLevel == ECalabashRewardState.CanReceive);
		base.GetItem(8).SetUIActive(receiveRewardStateByLevel == ECalabashRewardState.CantReceive);
		base.GetItem(7).SetUIActive(receiveRewardStateByLevel == ECalabashRewardState.HasReceived);
		if (receiveRewardStateByLevel == ECalabashRewardState.CantReceive)
		{
			UUIText text = base.GetText(9);
			if (this.CalabashGridDataList[this.CurrentSelectedLevel].HasOverFlowExpReach)
			{
				ConditionGroup? config = ConfigConditionGroupById.GetConfig(ConfigBase<CalabashConfig>.Instance.GetCalabashConfigByLevel(this.CurrentSelectedLevel).Value.LevelUpCondition, true);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, config.Value.HintText, Array.Empty<object>());
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "PrefabTextItem_HuluLvNotEnough_Text", Array.Empty<object>());
		}
	}

	// Token: 0x0600AE88 RID: 44680 RVA: 0x002E74E8 File Offset: 0x002E56E8
	private void RefreshAttribute()
	{
		this.ClearAttributeData();
		this.CreateBasicAbsorptionData();
		this.CreateUpAbsorptionData();
		this.CreateLowCostAbsorptionData();
		this.CreateMaxQualityData();
		this.CreateMaxCostData();
		foreach (CalabashAttributeData calabashAttributeData in this.AttributeDataList)
		{
			calabashAttributeData.ClickCallBack = new Action<CalabashAttributeData>(this.OnClickDetailItem);
			calabashAttributeData.CurrentSelect = (this.CurrentSelectDetailType == calabashAttributeData.Type);
			calabashAttributeData.CurrentSelectLevel = this.CurrentSelectedLevel;
		}
		GenericLayout<CalabashAttributeItem, CalabashAttributeData> attributeLayout = this.AttributeLayout;
		if (attributeLayout == null)
		{
			return;
		}
		attributeLayout.RefreshByData(this.AttributeDataList, null, false);
	}

	// Token: 0x0600AE89 RID: 44681 RVA: 0x002E75A4 File Offset: 0x002E57A4
	private void CreateBasicAbsorptionData()
	{
		int calabashLevel = ModelBase<CalabashModel>.Instance.GetCalabashLevel();
		bool flag = calabashLevel >= this.CurrentSelectedLevel;
		CalabashAttributeData attributeData = this.GetAttributeData();
		attributeData.Type = ECalabashAttributeDataType.BasicAbsorption;
		attributeData.Name = "PrefabTextItem_1948060625_Text";
		attributeData.IsCost = false;
		attributeData.IsUp = false;
		int catchGainByLevel = ModelBase<CalabashModel>.Instance.GetCatchGainByLevel(this.CurrentSelectedLevel);
		attributeData.Value = new TableTextArgNew("Text_ExplorationDegree_Text", new <>z__ReadOnlySingleElementList<object>(Math.Ceiling((double)catchGainByLevel / 10.0).ToString()));
		attributeData.IsToggleRaycast = false;
		if (!flag)
		{
			int catchGainByLevel2 = ModelBase<CalabashModel>.Instance.GetCatchGainByLevel(calabashLevel);
			attributeData.IsUp = (catchGainByLevel > catchGainByLevel2);
		}
	}

	// Token: 0x0600AE8A RID: 44682 RVA: 0x002E7650 File Offset: 0x002E5850
	private void CreateUpAbsorptionData()
	{
		int calabashLevel = ModelBase<CalabashModel>.Instance.GetCalabashLevel();
		CalabashConfig instance = ConfigBase<CalabashConfig>.Instance;
		CalabashLevel? calabashLevel2 = (instance != null) ? instance.GetCalabashConfigByLevel(calabashLevel) : null;
		if (calabashLevel2 == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Calabash;
			ELogAuthor author = ELogAuthor.CB;
			string message = "找不到对应等级的配置信息";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("curLevel", calabashLevel);
			instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		CalabashConfig instance3 = ConfigBase<CalabashConfig>.Instance;
		CalabashLevel? calabashLevel3 = (instance3 != null) ? instance3.GetCalabashConfigByLevel(this.CurrentSelectedLevel) : null;
		bool flag = calabashLevel >= this.CurrentSelectedLevel;
		if (calabashLevel3 == null)
		{
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Calabash;
			ELogAuthor author2 = ELogAuthor.CB;
			string message2 = "找不到对应等级的配置信息";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("CurrentSelectedLevel", this.CurrentSelectedLevel);
			instance4.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		CalabashAttributeData attributeData = this.GetAttributeData();
		attributeData.Type = ECalabashAttributeDataType.UpAbsorption;
		attributeData.Name = ECalabashTxt.UpAbsorptionTargetAdvanced.ToString();
		attributeData.IsCost = false;
		attributeData.IsUp = false;
		attributeData.IsToggleRaycast = true;
		int catchGainByLevel = ModelBase<CalabashModel>.Instance.GetCatchGainByLevel(this.CurrentSelectedLevel);
		int tempCatchGain = calabashLevel3.Value.TempCatchGain;
		if (tempCatchGain <= catchGainByLevel)
		{
			attributeData.Value = new TableTextArgNew("PrefabTextItem_HuluTempCatchGainDisable_Text", Array.Empty<object>());
			return;
		}
		attributeData.Value = new TableTextArgNew("Text_ExplorationDegree_Text", new <>z__ReadOnlySingleElementList<object>(Math.Ceiling((double)tempCatchGain / 10.0).ToString()));
		if (!flag)
		{
			int tempCatchGain2 = calabashLevel2.Value.TempCatchGain;
			attributeData.IsUp = (tempCatchGain > tempCatchGain2);
		}
	}

	// Token: 0x0600AE8B RID: 44683 RVA: 0x002E77FC File Offset: 0x002E59FC
	private void CreateLowCostAbsorptionData()
	{
		CalabashConfig instance = ConfigBase<CalabashConfig>.Instance;
		CalabashLevel? calabashLevel = (instance != null) ? instance.GetCalabashConfigByLevel(this.CurrentSelectedLevel) : null;
		if (calabashLevel == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Calabash;
			ELogAuthor author = ELogAuthor.CB;
			string message = "找不到对应等级的配置信息";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CurrentSelectedLevel", this.CurrentSelectedLevel);
			instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		int lowCostTempCatchGain = calabashLevel.Value.LowCostTempCatchGain;
		if (lowCostTempCatchGain > 0)
		{
			CalabashAttributeData attributeData = this.GetAttributeData();
			attributeData.Type = ECalabashAttributeDataType.LowCostUpAbsorption;
			attributeData.Name = ECalabashTxt.UpAbsorptionTargetJunior.ToString();
			attributeData.IsCost = false;
			attributeData.IsUp = false;
			attributeData.IsToggleRaycast = true;
			attributeData.Value = new TableTextArgNew("Text_ExplorationDegree_Text", new <>z__ReadOnlySingleElementList<object>(Math.Ceiling((double)lowCostTempCatchGain / 10.0).ToString()));
		}
	}

	// Token: 0x0600AE8C RID: 44684 RVA: 0x002E78E4 File Offset: 0x002E5AE4
	private void CreateMaxQualityData()
	{
		int calabashLevel = ModelBase<CalabashModel>.Instance.GetCalabashLevel();
		CalabashConfig instance = ConfigBase<CalabashConfig>.Instance;
		CalabashLevel? calabashLevel2 = (instance != null) ? instance.GetCalabashConfigByLevel(calabashLevel) : null;
		if (calabashLevel2 == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Calabash;
			ELogAuthor author = ELogAuthor.CB;
			string message = "找不到对应等级的配置信息";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("curLevel", calabashLevel);
			instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		CalabashConfig instance3 = ConfigBase<CalabashConfig>.Instance;
		CalabashLevel? calabashLevel3 = (instance3 != null) ? instance3.GetCalabashConfigByLevel(this.CurrentSelectedLevel) : null;
		bool flag = calabashLevel >= this.CurrentSelectedLevel;
		if (calabashLevel3 == null)
		{
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Calabash;
			ELogAuthor author2 = ELogAuthor.CB;
			string message2 = "找不到对应等级的配置信息";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("CurrentSelectedLevel", this.CurrentSelectedLevel);
			instance4.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		CalabashAttributeData attributeData = this.GetAttributeData();
		attributeData.Type = ECalabashAttributeDataType.MaxQuality;
		attributeData.Name = "PrefabTextItem_3681645418_Text";
		attributeData.IsCost = false;
		attributeData.IsUp = false;
		string qualityDescription = calabashLevel3.Value.QualityDescription;
		attributeData.Value = new TableTextArgNew(qualityDescription, Array.Empty<object>());
		if (!flag)
		{
			string qualityDescription2 = calabashLevel2.Value.QualityDescription;
			attributeData.IsUp = (qualityDescription != qualityDescription2);
		}
		attributeData.IsToggleRaycast = true;
	}

	// Token: 0x0600AE8D RID: 44685 RVA: 0x002E7A3C File Offset: 0x002E5C3C
	private void CreateMaxCostData()
	{
		int calabashLevel = ModelBase<CalabashModel>.Instance.GetCalabashLevel();
		CalabashConfig instance = ConfigBase<CalabashConfig>.Instance;
		CalabashLevel? calabashLevel2 = (instance != null) ? instance.GetCalabashConfigByLevel(calabashLevel) : null;
		if (calabashLevel2 == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Calabash;
			ELogAuthor author = ELogAuthor.CB;
			string message = "找不到对应等级的配置信息";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("curLevel", calabashLevel);
			instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		CalabashConfig instance3 = ConfigBase<CalabashConfig>.Instance;
		CalabashLevel? calabashLevel3 = (instance3 != null) ? instance3.GetCalabashConfigByLevel(this.CurrentSelectedLevel) : null;
		bool flag = calabashLevel >= this.CurrentSelectedLevel;
		if (calabashLevel3 == null)
		{
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Calabash;
			ELogAuthor author2 = ELogAuthor.CB;
			string message2 = "找不到对应等级的配置信息";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("CurrentSelectedLevel", this.CurrentSelectedLevel);
			instance4.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		CalabashAttributeData attributeData = this.GetAttributeData();
		attributeData.Type = ECalabashAttributeDataType.MaxCost;
		attributeData.Name = "PrefabTextItem_HuluCostLimit_Text";
		attributeData.IsCost = true;
		attributeData.IsUp = false;
		int cost = calabashLevel3.Value.Cost;
		attributeData.CostCount = cost;
		if (!flag)
		{
			int cost2 = calabashLevel2.Value.Cost;
			attributeData.IsUp = (cost > cost2);
		}
		attributeData.IsToggleRaycast = false;
	}

	// Token: 0x0600AE8E RID: 44686 RVA: 0x002E7B88 File Offset: 0x002E5D88
	private void ClearAttributeData()
	{
		foreach (CalabashAttributeData item in this.AttributeDataList)
		{
			this.AttributeDataListPool.Add(item);
		}
		this.AttributeDataList.Clear();
	}

	// Token: 0x0600AE8F RID: 44687 RVA: 0x002E7BEC File Offset: 0x002E5DEC
	private CalabashAttributeData GetAttributeData()
	{
		CalabashAttributeData calabashAttributeData = null;
		if (this.AttributeDataListPool.Count > 0)
		{
			calabashAttributeData = this.AttributeDataListPool[0];
			this.AttributeDataListPool.RemoveAt(0);
		}
		if (calabashAttributeData == null)
		{
			calabashAttributeData = new CalabashAttributeData();
		}
		this.AttributeDataList.Add(calabashAttributeData);
		return calabashAttributeData;
	}

	// Token: 0x0600AE90 RID: 44688 RVA: 0x002E7C38 File Offset: 0x002E5E38
	private void OnClickDetailItem(CalabashAttributeData data)
	{
		this.CurrentSelectDetailType = ((data.Type == this.CurrentSelectDetailType) ? ECalabashAttributeDataType.Default : data.Type);
		this.RefreshAttribute();
	}

	// Token: 0x0600AE91 RID: 44689 RVA: 0x002E7C5D File Offset: 0x002E5E5D
	private void RefreshCalabash()
	{
		this.RefreshNoCircleExhibitionView(false);
		this.RefreshSelectedLevelInfo();
		this.RefreshCalabashPlayerInfo();
	}

	// Token: 0x0600AE92 RID: 44690 RVA: 0x002E7C74 File Offset: 0x002E5E74
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		int num;
		if (configParams.Length != 1 && int.TryParse(configParams[0], out num))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Guide;
			ELogAuthor author = ELogAuthor.JT;
			string message = "聚焦引导extraParam项配置有误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("configParams", configParams);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		GenericLayout<CalabashAttributeItem, CalabashAttributeData> attributeLayout = this.AttributeLayout;
		UUIItem uuiitem = (attributeLayout != null) ? attributeLayout.GetItemByIndex(int.Parse(configParams[0])) : null;
		if (uuiitem != null)
		{
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}
		return null;
	}

	// Token: 0x0600AE93 RID: 44691 RVA: 0x002E7CEC File Offset: 0x002E5EEC
	private void RefreshNoCircleExhibitionView(bool isInit = false)
	{
		int calabashLevel = ModelBase<CalabashModel>.Instance.GetCalabashLevel();
		int currentExp = ModelBase<CalabashModel>.Instance.GetCurrentExp();
		int calabashMaxLevel = ModelBase<CalabashModel>.Instance.GetCalabashMaxLevel();
		if (this.CalabashGridDataList == null)
		{
			this.CalabashGridDataList = new CalabashGridData[calabashMaxLevel + 1];
		}
		int num = 0;
		for (int i = 0; i <= calabashMaxLevel; i++)
		{
			int levelUpExp = ConfigBase<CalabashConfig>.Instance.GetCalabashConfigByLevel(i).Value.LevelUpExp;
			int overFlowExp;
			int limitExp;
			if (i < calabashLevel)
			{
				overFlowExp = levelUpExp;
				limitExp = levelUpExp;
			}
			else
			{
				overFlowExp = Math.Min(levelUpExp, currentExp - num);
				limitExp = 0;
				num += levelUpExp;
			}
			CalabashGridData calabashGridData = this.CalabashGridDataList[i];
			if (calabashGridData == null)
			{
				calabashGridData = new CalabashGridData();
				this.CalabashGridDataList[i] = calabashGridData;
			}
			calabashGridData.Level = i;
			calabashGridData.OverFlowExp = overFlowExp;
			calabashGridData.LimitExp = limitExp;
			calabashGridData.MaxExp = levelUpExp;
			calabashGridData.IsMaxLevel = (i == calabashMaxLevel);
			if (i == 0)
			{
				calabashGridData.HasOverFlowExpReach = true;
			}
			else
			{
				CalabashGridData calabashGridData2 = this.CalabashGridDataList[i - 1];
				calabashGridData.HasOverFlowExpReach = (calabashGridData2.OverFlowExp == calabashGridData2.MaxExp);
			}
		}
		if (isInit)
		{
			this.NoCircleExhibitionView.ReloadView(this.CalabashGridDataList.Length, this.CalabashGridDataList, 0);
			this.NoCircleExhibitionView.AttachToIndex(calabashLevel, true);
			return;
		}
		foreach (CalabashGrid calabashGrid in this.NoCircleExhibitionView.GetItems())
		{
			calabashGrid.SetData(this.CalabashGridDataList);
			calabashGrid.RefreshItem();
		}
	}

	// Token: 0x0600AE94 RID: 44692 RVA: 0x002E7E94 File Offset: 0x002E6094
	private void RefreshExpText(int curLevel)
	{
		int calabashMaxLevel = ModelBase<CalabashModel>.Instance.GetCalabashMaxLevel();
		if (curLevel >= calabashMaxLevel)
		{
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(3), "DataBankLevelTips_Max", Array.Empty<object>());
			return;
		}
		int currentExp = ModelBase<CalabashModel>.Instance.GetCurrentExp();
		CalabashLevel? calabashLevel;
		int? num = (ConfigBase<CalabashConfig>.Instance.GetCalabashConfigByLevel(curLevel) != null) ? new int?(calabashLevel.GetValueOrDefault().LevelUpExp) : null;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "CalabashLevelUpTabView_ExpText", new <>z__ReadOnlyArray<object>(new object[]
		{
			currentExp.ToString(),
			num.ToString()
		}));
	}

	// Token: 0x040052D6 RID: 21206
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private NoCircleAttachView<CalabashGridData, CalabashGrid> NoCircleExhibitionView;

	// Token: 0x040052D7 RID: 21207
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private CalabashGridData[] CalabashGridDataList;

	// Token: 0x040052D8 RID: 21208
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<CalabashAttributeItem, CalabashAttributeData> AttributeLayout;

	// Token: 0x040052D9 RID: 21209
	private readonly List<CalabashAttributeData> AttributeDataList = new List<CalabashAttributeData>();

	// Token: 0x040052DA RID: 21210
	private readonly List<CalabashAttributeData> AttributeDataListPool = new List<CalabashAttributeData>();

	// Token: 0x040052DB RID: 21211
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<CalabashLevelUpRewardItemGrid, CalabashRewardItemData> RewardLayout;

	// Token: 0x040052DC RID: 21212
	private int AchieveStrengthItemNum;

	// Token: 0x040052DD RID: 21213
	private readonly List<CalabashRewardItemData> RewardDataList = new List<CalabashRewardItemData>();

	// Token: 0x040052DE RID: 21214
	[Nullable(2)]
	private UCurveFloat ItemCurve;

	// Token: 0x040052DF RID: 21215
	private int CurrentSelectedLevel;

	// Token: 0x040052E0 RID: 21216
	private ECalabashAttributeDataType CurrentSelectDetailType = ECalabashAttributeDataType.Default;

	// Token: 0x040052E1 RID: 21217
	private bool NeedInitExhibition = true;
}
