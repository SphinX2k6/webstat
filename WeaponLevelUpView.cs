using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002CF4 RID: 11508
[NullableContext(1)]
[Nullable(0)]
public class WeaponLevelUpView : UiTabViewBase
{
	// Token: 0x06017364 RID: 95076 RVA: 0x0066EC10 File Offset: 0x0066CE10
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06017365 RID: 95077 RVA: 0x0066ECDC File Offset: 0x0066CEDC
	protected override UniTask OnBeforeStartAsync()
	{
		WeaponLevelUpView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WeaponLevelUpView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06017366 RID: 95078 RVA: 0x0066ED20 File Offset: 0x0066CF20
	protected override void OnStart()
	{
		int incId = (int)this.ExtraParams;
		this.WeaponInstance = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(incId);
		this.InitExpComponent();
		this.InitAttributeItemList();
		this.InitConsumeComponent();
	}

	// Token: 0x06017367 RID: 95079 RVA: 0x0066ED5C File Offset: 0x0066CF5C
	protected override void OnBeforeDestroy()
	{
		this.ExpComponent.Destroy(null);
		this.ItemGridConsumeComponent.Destroy(null);
		this.CheckAndCloseItemHintViewNew();
	}

	// Token: 0x06017368 RID: 95080 RVA: 0x0066ED7C File Offset: 0x0066CF7C
	protected override void OnBeforeShow()
	{
		this.RefreshSelectedList();
		this.InitExp();
		this.RefreshName();
		this.UpdateAttribute();
		this.UpdateConsumeComponent();
	}

	// Token: 0x06017369 RID: 95081 RVA: 0x0066ED9C File Offset: 0x0066CF9C
	private void RefreshSelectedList()
	{
		if (this.SelectedList == null || this.SelectedList.Count == 0)
		{
			return;
		}
		WeaponModel instance = ModelBase<WeaponModel>.Instance;
		InventoryModel instance2 = ModelBase<InventoryModel>.Instance;
		for (int i = this.SelectedList.Count - 1; i >= 0; i--)
		{
			ISelectedData selectedData = this.SelectedList[i];
			bool flag;
			if (selectedData.IncId > 0)
			{
				flag = (instance.GetWeaponDataByIncId(selectedData.IncId) != null);
			}
			else
			{
				List<ItemDataBase> itemDataBaseByConfigId = instance2.GetItemDataBaseByConfigId(selectedData.ItemId);
				if (itemDataBaseByConfigId.Count > 0)
				{
					int num = 0;
					foreach (ItemDataBase itemDataBase in itemDataBaseByConfigId)
					{
						num += itemDataBase.GetCount();
					}
					if (selectedData.SelectedCount > num)
					{
						selectedData.SelectedCount = num;
					}
					flag = (selectedData.SelectedCount > 0);
				}
				else
				{
					flag = false;
				}
			}
			if (!flag)
			{
				this.SelectedList.RemoveAt(i);
			}
		}
	}

	// Token: 0x0601736A RID: 95082 RVA: 0x0066EEAC File Offset: 0x0066D0AC
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WeaponLevelUp, new Action(this.WeaponLevelUpEvent));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<TItem>>(EEventName.WeaponLevelUpReceiveItem, new Action<IReadOnlyList<TItem>>(this.WeaponLevelUpReceiveItem));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPlayerCurrencyChange, new Action<int>(this.OnPlayerCurrencyChange));
	}

	// Token: 0x0601736B RID: 95083 RVA: 0x0066EF10 File Offset: 0x0066D110
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WeaponLevelUp, new Action(this.WeaponLevelUpEvent));
		Singleton<EventSystem>.Instance.Remove<IReadOnlyList<TItem>>(EEventName.WeaponLevelUpReceiveItem, new Action<IReadOnlyList<TItem>>(this.WeaponLevelUpReceiveItem));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnPlayerCurrencyChange, new Action<int>(this.OnPlayerCurrencyChange));
	}

	// Token: 0x0601736C RID: 95084 RVA: 0x0066EF71 File Offset: 0x0066D171
	private void OnPlayerCurrencyChange(int i)
	{
		this.UpdateConsumeComponent();
	}

	// Token: 0x0601736D RID: 95085 RVA: 0x0066EF79 File Offset: 0x0066D179
	protected override void OnHideUiTabViewBase(bool fromToggle)
	{
		if (fromToggle)
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.CommonItemSelectViewRight, null);
		}
	}

	// Token: 0x0601736E RID: 95086 RVA: 0x0066EF90 File Offset: 0x0066D190
	private void WeaponLevelUpEvent()
	{
		this.OnLevelUpSuccess();
		this.ExpComponent.PlayExpTween(this.CurrentExpData);
		this.SelectedList.Clear();
		this.ClearConsume();
		this.ItemGridConsumeComponent.UpdateComponent(2, 0, this.ConsumeList);
		this.ItemGridConsumeComponent.SetMaxState(this.WeaponInstance.IsLevelMax());
	}

	// Token: 0x0601736F RID: 95087 RVA: 0x0066EFEE File Offset: 0x0066D1EE
	private void WeaponLevelUpReceiveItem(IReadOnlyList<TItem> itemList)
	{
		this.ReceiveItemList = itemList.ToList<TItem>();
		this.ReceiveItemList.Sort(delegate(TItem a, TItem b)
		{
			CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(a.ItemData.ItemId);
			return ConfigBase<InventoryConfig>.Instance.GetItemConfigData(b.ItemData.ItemId).QualityId - itemConfigData.QualityId;
		});
	}

	// Token: 0x06017370 RID: 95088 RVA: 0x0066F028 File Offset: 0x0066D228
	private void InitExpComponent()
	{
		this.ExpComponent = new ExpComponent(base.GetItem(0), false);
		this.ExpComponent.Init();
		this.ExpComponent.SetLevelFormatText("LevelNumber");
		this.ExpComponent.BindPlayCompleteCallBack(new Action<bool>(this.OnExpTweenComplete));
		this.CurrentExpData = new SelectableExpData();
		this.CurrentExpData.SetMaxExpFunction(new Func<int, int>(this.GetCurLevelExp));
	}

	// Token: 0x06017371 RID: 95089 RVA: 0x0066F09C File Offset: 0x0066D29C
	private void InitExp()
	{
		this.UpdateExpData();
		this.ExpComponent.UpdateInitState(this.CurrentExpData);
	}

	// Token: 0x06017372 RID: 95090 RVA: 0x0066F0B8 File Offset: 0x0066D2B8
	private void UpdateExpData()
	{
		int level = this.WeaponInstance.GetLevel();
		int currentMaxLevel = this.WeaponInstance.GetCurrentMaxLevel();
		int exp = this.WeaponInstance.GetExp();
		int maxLevel = this.WeaponInstance.GetMaxLevel();
		this.CurrentExpData.UpdateComponent(level, currentMaxLevel, exp, new int?(maxLevel), false);
	}

	// Token: 0x06017373 RID: 95091 RVA: 0x0066F10A File Offset: 0x0066D30A
	private int GetCurLevelExp(int level)
	{
		return this.WeaponInstance.GetLevelExp(level);
	}

	// Token: 0x06017374 RID: 95092 RVA: 0x0066F118 File Offset: 0x0066D318
	private int GetItemExpFunction(ISelectedData selectedData)
	{
		return ModelBase<WeaponModel>.Instance.GetWeaponItemExp(selectedData.IncId, selectedData.ItemId);
	}

	// Token: 0x06017375 RID: 95093 RVA: 0x0066F130 File Offset: 0x0066D330
	private void OnExpTweenComplete(bool _)
	{
		this.InitExp();
		this.UpdateAttribute();
	}

	// Token: 0x06017376 RID: 95094 RVA: 0x0066F140 File Offset: 0x0066D340
	private void OnLevelUpSuccess()
	{
		int currentLevel = this.CurrentExpData.GetCurrentLevel();
		int level = this.WeaponInstance.GetLevel();
		this.WeaponObserver = Singleton<UiSceneManager>.Instance.GetWeaponObserver();
		this.WeaponScabbardObserver = Singleton<UiSceneManager>.Instance.GetWeaponScabbardObserver();
		ControllerBase<WeaponController>.Instance.PlayWeaponRenderingMaterial("WeaponLevelUpMaterialController", this.WeaponObserver, this.WeaponScabbardObserver);
		UiModelBase model = this.WeaponObserver.Model;
		Singleton<UiModelUtil>.Instance.PlayEffectAtRootComponent(model, "WeaponLevelUpEffect");
		if (currentLevel == level)
		{
			return;
		}
		List<IAttributeInfo> levelUpAttributeDataList = this.GetLevelUpAttributeDataList(currentLevel, level);
		ILevelUpSuccessAttributeData data = null;
		if (this.WeaponInstance.CanGoBreach())
		{
			data = new LevelUpSuccessAttributeData
			{
				Title = "Text_WeaponLevelUpSuccessText_Text",
				LevelInfo = new LevelInfo
				{
					PreUpgradeLv = currentLevel,
					UpgradeLv = level,
					FormatStringId = "Text_LevelShow_Text",
					IsMaxLevel = new bool?(true)
				},
				AttributeInfo = levelUpAttributeDataList,
				ClickText = "Text_TurnToBreach_Text",
				ClickFunction = new Action(this.TurnToBreachView)
			};
		}
		else
		{
			data = new LevelUpSuccessAttributeData
			{
				Title = "Text_WeaponLevelUpSuccessText_Text",
				LevelInfo = new LevelInfo
				{
					PreUpgradeLv = currentLevel,
					UpgradeLv = level,
					FormatStringId = "Text_LevelShow_Text",
					IsMaxLevel = new bool?(this.WeaponInstance.GetLevel() == this.WeaponInstance.GetMaxLevel())
				},
				AttributeInfo = levelUpAttributeDataList
			};
		}
		if (data == null)
		{
			return;
		}
		int? weaponLevelUpSuccessDelayTime = ConfigBase<RoleConfig>.Instance.GetWeaponLevelUpSuccessDelayTime();
		Singleton<UiLayer>.Instance.SetShowMaskLayer("OpenLevelUpSuccessView", true);
		TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			ControllerBase<RoleLevelUpSuccessController>.Instance.OpenSuccessAttributeView(data, null);
			Singleton<UiLayer>.Instance.SetShowMaskLayer("OpenLevelUpSuccessView", false);
			this.TryOpenItemHintView();
		}, (float)weaponLevelUpSuccessDelayTime.Value, null, null, true, 1f);
	}

	// Token: 0x06017377 RID: 95095 RVA: 0x0066F30A File Offset: 0x0066D50A
	private void InitAttributeItemList()
	{
		this.AttributeLayout = new GenericLayout<AttributeItem, CSharpScript.Game.Module.Common.AttributeData>(base.GetVerticalLayout(1), new Func<AttributeItem>(this.CreateAttributeItem), null, false, true);
	}

	// Token: 0x06017378 RID: 95096 RVA: 0x0066F32D File Offset: 0x0066D52D
	private AttributeItem CreateAttributeItem()
	{
		return new AttributeItem();
	}

	// Token: 0x06017379 RID: 95097 RVA: 0x0066F334 File Offset: 0x0066D534
	private void UpdateAttribute()
	{
		WeaponConf? weaponConfig = this.WeaponInstance.GetWeaponConfig();
		this.AttributeParamList = ModelBase<WeaponModel>.Instance.GetWeaponAttributeParamList(weaponConfig.Value).ToList<IWeaponAttributeParam>();
		int breachLevel = this.WeaponInstance.GetBreachLevel();
		int currentLevel = this.CurrentExpData.GetCurrentLevel();
		int arrivedLevel = this.CurrentExpData.GetArrivedLevel();
		List<CSharpScript.Game.Module.Common.AttributeData> list = new List<CSharpScript.Game.Module.Common.AttributeData>();
		foreach (IWeaponAttributeParam weaponAttributeParam in this.AttributeParamList)
		{
			int curveId = weaponAttributeParam.CurveId;
			float value = weaponAttributeParam.PropId.Value;
			float curveValue = ModelBase<WeaponModel>.Instance.GetCurveValue(curveId, value, currentLevel, breachLevel);
			float num = 0f;
			if (arrivedLevel > currentLevel)
			{
				num = ModelBase<WeaponModel>.Instance.GetCurveValue(curveId, value, arrivedLevel, breachLevel);
			}
			CSharpScript.Game.Module.Common.AttributeData item = new CSharpScript.Game.Module.Common.AttributeData
			{
				Id = weaponAttributeParam.PropId.Id,
				IsRatio = weaponAttributeParam.PropId.IsRatio,
				CurValue = curveValue,
				BgActive = new bool?(true),
				ShowNext = new bool?(num > curveValue),
				NextValue = new float?(num)
			};
			list.Add(item);
		}
		this.AttributeLayout.RefreshByData(list, null, false);
	}

	// Token: 0x0601737A RID: 95098 RVA: 0x0066F4A4 File Offset: 0x0066D6A4
	private List<IAttributeInfo> GetLevelUpAttributeDataList(int currentLevel, int arrivedLevel)
	{
		List<IAttributeInfo> list = new List<IAttributeInfo>();
		int breachLevel = this.WeaponInstance.GetBreachLevel();
		foreach (IWeaponAttributeParam weaponAttributeParam in this.AttributeParamList)
		{
			float curveValue = ModelBase<WeaponModel>.Instance.GetCurveValue(weaponAttributeParam.CurveId, weaponAttributeParam.PropId.Value, currentLevel, breachLevel);
			float curveValue2 = ModelBase<WeaponModel>.Instance.GetCurveValue(weaponAttributeParam.CurveId, weaponAttributeParam.PropId.Value, arrivedLevel, breachLevel);
			if (curveValue != curveValue2)
			{
				AttrListScrollData attrData = new AttrListScrollData(weaponAttributeParam.PropId.Id, (double)curveValue, (double)curveValue2, 0, weaponAttributeParam.PropId.IsRatio, CommonComponentDefine.EAttributeType.NormalType);
				list.Add(RoleLevelUpSuccessController.ConvertsAttrListScrollDataToAttributeInfo(attrData));
			}
		}
		return list;
	}

	// Token: 0x0601737B RID: 95099 RVA: 0x0066F590 File Offset: 0x0066D790
	private void InitConsumeComponent()
	{
		this.ItemGridConsumeComponent.InitFilter(EItemGridConsumeLocalDropDown.WeaponLevelUp, new Action<int>(this.ConditionFunction));
		this.ItemGridConsumeComponent.SetConsumeTexture(2);
		this.CurrentAutoQualityIndex = new int?(this.ItemGridConsumeComponent.GetCurrentDropDownSelectIndex());
		if (this.CurrentAutoQualityIndex != null)
		{
			this.RefreshConditionText();
		}
		int maxCount = this.ItemGridConsumeComponent.GetMaxCount();
		this.ConsumeList = new List<TCommonMultipleConsumeData>(maxCount);
		for (int i = 0; i < maxCount; i++)
		{
			this.ConsumeList.Add(new TCommonMultipleConsumeData(new InventoryDefine.GetItemData(0, 0), 0));
		}
	}

	// Token: 0x0601737C RID: 95100 RVA: 0x0066F626 File Offset: 0x0066D826
	private void UpdateConsumeComponent()
	{
		this.RefreshItemAndExp();
		this.ItemGridConsumeComponent.SetMaxState(this.WeaponInstance.IsLevelMax());
	}

	// Token: 0x0601737D RID: 95101 RVA: 0x0066F644 File Offset: 0x0066D844
	private void LevelUpClick(int data)
	{
		if (this.SelectedList == null || this.SelectedList.Count <= 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("WeaponSelectMaterialTipsText", Array.Empty<object>());
			return;
		}
		if (!this.ItemGridConsumeComponent.GetEnoughMoney())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("WeaponNoEnoughMoneyText", Array.Empty<object>());
			return;
		}
		Action action = delegate()
		{
			int? incId = this.WeaponInstance.GetIncId();
			ControllerBase<WeaponController>.Instance.SendPbWeaponLevelUpRequest(incId.Value, this.SelectedList.ToArray());
		};
		if (ModelBase<WeaponModel>.Instance.LevelUpConfirmTipsNotShow)
		{
			action();
			return;
		}
		List<string> conditionTextList = this.GetConditionTextList();
		Dictionary<int, int> overExpMap = this.GetOverExpMap();
		bool flag = overExpMap.Count > 0;
		bool flag2 = conditionTextList.Count > 0;
		ConfirmBoxDataNew confirmBoxDataNew = null;
		if (flag && flag2)
		{
			confirmBoxDataNew = this.CreateLevelUpTipsWithAll(conditionTextList, overExpMap);
		}
		else if (flag)
		{
			confirmBoxDataNew = this.CreateLevelUpTipsWithOverflow(overExpMap);
		}
		else if (flag2)
		{
			confirmBoxDataNew = this.CreateLevelUpTipsWithCondition(conditionTextList);
		}
		if (confirmBoxDataNew != null)
		{
			confirmBoxDataNew.FunctionMap.Add(2, action);
			confirmBoxDataNew.HasToggle = true;
			confirmBoxDataNew.ToggleText = ConfigMultiTextLang.GetLocalTextNew("Text_WeaponLevelUpTips_Text", null);
			confirmBoxDataNew.SetToggleFunction(delegate(bool isSelectOn)
			{
				ModelBase<WeaponModel>.Instance.LevelUpConfirmTipsNotShow = isSelectOn;
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		action();
	}

	// Token: 0x0601737E RID: 95102 RVA: 0x0066F778 File Offset: 0x0066D978
	private List<string> GetConditionTextList()
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		foreach (ISelectedData selectedData in this.SelectedList)
		{
			WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(selectedData.IncId);
			if (weaponDataByIncId != null)
			{
				if (!flag && ModelBase<WeaponModel>.Instance.IsWeaponHighQuality(weaponDataByIncId))
				{
					flag = true;
				}
				if (!flag2 && ModelBase<WeaponModel>.Instance.IsWeaponHighLevel(weaponDataByIncId))
				{
					flag2 = true;
				}
				if (!flag3 && ModelBase<WeaponModel>.Instance.IsWeaponHighResonanceLevel(weaponDataByIncId))
				{
					flag3 = true;
				}
			}
		}
		List<string> list = new List<string>();
		if (flag)
		{
			string textById = ConfigBase<TextConfig>.Instance.GetTextById("WeaponHighQuality");
			list.Add(textById);
		}
		if (flag2)
		{
			string textById2 = ConfigBase<TextConfig>.Instance.GetTextById("WeaponHasLevelUp");
			list.Add(textById2);
		}
		if (flag3)
		{
			string textById3 = ConfigBase<TextConfig>.Instance.GetTextById("WeaponHasResonance");
			list.Add(textById3);
		}
		return list;
	}

	// Token: 0x0601737F RID: 95103 RVA: 0x0066F878 File Offset: 0x0066DA78
	private Dictionary<int, int> GetOverExpMap()
	{
		int overExp = this.CurrentExpData.GetOverExp();
		Dictionary<int, int> result;
		if (overExp > 0)
		{
			result = ModelBase<WeaponModel>.Instance.GetCanChangeMaterialList(overExp);
		}
		else
		{
			result = new Dictionary<int, int>();
		}
		return result;
	}

	// Token: 0x06017380 RID: 95104 RVA: 0x0066F8AC File Offset: 0x0066DAAC
	private ConfirmBoxDataNew CreateLevelUpTipsWithCondition(List<string> words)
	{
		EConfirmBoxConfigId? econfirmBoxConfigId = null;
		switch (words.Count)
		{
		case 1:
			econfirmBoxConfigId = new EConfirmBoxConfigId?(EConfirmBoxConfigId.WeaponLevelUpOneCondition);
			break;
		case 2:
			econfirmBoxConfigId = new EConfirmBoxConfigId?(EConfirmBoxConfigId.WeaponLevelUpTwoCondition);
			break;
		case 3:
			econfirmBoxConfigId = new EConfirmBoxConfigId?(EConfirmBoxConfigId.WeaponLevelUpThreeCondition);
			break;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(econfirmBoxConfigId.Value);
		confirmBoxDataNew.SetTextArgs(words.ToArray());
		return confirmBoxDataNew;
	}

	// Token: 0x06017381 RID: 95105 RVA: 0x0066F912 File Offset: 0x0066DB12
	private ConfirmBoxDataNew CreateLevelUpTipsWithOverflow(Dictionary<int, int> overItemMap)
	{
		return new ConfirmBoxDataNew(EConfirmBoxConfigId.WeaponOverflowExpTip)
		{
			ItemIdMap = overItemMap
		};
	}

	// Token: 0x06017382 RID: 95106 RVA: 0x0066F924 File Offset: 0x0066DB24
	private ConfirmBoxDataNew CreateLevelUpTipsWithAll(List<string> words, Dictionary<int, int> overItemMap)
	{
		EConfirmBoxConfigId? econfirmBoxConfigId = null;
		switch (words.Count)
		{
		case 1:
			econfirmBoxConfigId = new EConfirmBoxConfigId?(EConfirmBoxConfigId.WeaponLevelUpTipsOverflow1);
			break;
		case 2:
			econfirmBoxConfigId = new EConfirmBoxConfigId?(EConfirmBoxConfigId.WeaponLevelUpTipsOverflow2);
			break;
		case 3:
			econfirmBoxConfigId = new EConfirmBoxConfigId?(EConfirmBoxConfigId.WeaponLevelUpTipsOverflow3);
			break;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(econfirmBoxConfigId.Value);
		confirmBoxDataNew.SetTextArgs(words.ToArray());
		confirmBoxDataNew.ItemIdMap = overItemMap;
		return confirmBoxDataNew;
	}

	// Token: 0x06017383 RID: 95107 RVA: 0x0066F9A0 File Offset: 0x0066DBA0
	private void MaterialItemFunction(int? incId, int? itemId)
	{
		CommonItemSelectViewOpenViewData<ItemDataBase> commonItemSelectViewOpenViewData = new CommonItemSelectViewOpenViewData<ItemDataBase>();
		List<ItemDataBase> weaponExpItemList = ModelBase<WeaponModel>.Instance.GetWeaponExpItemList(this.WeaponInstance.GetIncId());
		CommonIntensifyPropExpData commonIntensifyPropExpData = new CommonIntensifyPropExpData();
		commonIntensifyPropExpData.CurrentExp = this.CurrentExpData.GetCurrentExp();
		commonIntensifyPropExpData.CurrentLevel = this.CurrentExpData.GetCurrentLevel();
		commonIntensifyPropExpData.CurrentMaxLevel = this.CurrentExpData.GetCurrentMaxLevel();
		commonIntensifyPropExpData.MaxExpFunction = new Func<int, int>(this.GetCurLevelExp);
		commonIntensifyPropExpData.GetItemExpFunction = new Func<ISelectedData, int>(this.GetItemExpFunction);
		List<ISelectedData> selectedList = this.SelectedList;
		SelectableComponentData selectableComponentData = new SelectableComponentData();
		selectableComponentData.IsSingleSelected = false;
		selectableComponentData.OnChangeSelectedFunction = new Action<List<ISelectedData>, SelectableExpData>(this.OnChangeSelectedFunction);
		selectableComponentData.MaxSelectedGridNum = this.ItemGridConsumeComponent.GetMaxCount();
		commonItemSelectViewOpenViewData.ItemDataBaseList = weaponExpItemList;
		commonItemSelectViewOpenViewData.SelectedDataList = (selectedList ?? new List<ISelectedData>());
		commonItemSelectViewOpenViewData.ExpData = commonIntensifyPropExpData;
		commonItemSelectViewOpenViewData.SelectableComponentData = selectableComponentData;
		commonItemSelectViewOpenViewData.UseWayId = EFilterSortGroupId.UseWayWeaponStrength;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonItemSelectViewRight, commonItemSelectViewOpenViewData, null);
	}

	// Token: 0x06017384 RID: 95108 RVA: 0x0066FA9F File Offset: 0x0066DC9F
	private void OnChangeSelectedFunction(List<ISelectedData> currentSelectedData, SelectableExpData expData)
	{
		this.SelectedList = currentSelectedData;
		this.CurrentExpData = expData;
		this.RefreshItemAndExp();
	}

	// Token: 0x06017385 RID: 95109 RVA: 0x0066FAB5 File Offset: 0x0066DCB5
	private void ItemClickFunction()
	{
		this.MaterialItemFunction(new int?(0), new int?(0));
	}

	// Token: 0x06017386 RID: 95110 RVA: 0x0066FAC9 File Offset: 0x0066DCC9
	private void OnClickDeleteSelectFunction()
	{
		this.SelectedList = new List<ISelectedData>();
		this.RefreshItemAndExp();
	}

	// Token: 0x06017387 RID: 95111 RVA: 0x0066FADC File Offset: 0x0066DCDC
	private void OnClickAutoFunction(int qualityId)
	{
		List<ItemDataBase> weaponExpItemListUseToAuto = ModelBase<WeaponModel>.Instance.GetWeaponExpItemListUseToAuto(this.WeaponInstance.GetIncId());
		List<ISelectedData> list = new List<ISelectedData>();
		int qualityIdByIndex = this.GetQualityIdByIndex(this.CurrentAutoQualityIndex.Value);
		foreach (ItemDataBase itemDataBase in weaponExpItemListUseToAuto)
		{
			if (itemDataBase.GetQuality() <= qualityIdByIndex)
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
		}
		if (list.Count == 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("RoleNoMaterial", Array.Empty<object>());
			return;
		}
		int expDistanceToMax = this.CurrentExpData.GetExpDistanceToMax();
		int maxCount = this.ItemGridConsumeComponent.GetMaxCount();
		List<ISelectedData> selectedList = ModelBase<WeaponModel>.Instance.AutoAddExpItem(expDistanceToMax, maxCount, list.ToArray(), new Func<ISelectedData, int>(this.GetItemExpFunction));
		this.SelectedList = selectedList;
		this.SelectedList.Sort(delegate(ISelectedData a, ISelectedData b)
		{
			bool flag = a.IncId > 0;
			bool flag2 = b.IncId > 0;
			if (flag == flag2)
			{
				return 0;
			}
			if (!flag)
			{
				return -1;
			}
			return 1;
		});
		this.RefreshItemAndExp();
	}

	// Token: 0x06017388 RID: 95112 RVA: 0x0066FC28 File Offset: 0x0066DE28
	private void OnClickItemReduce(int? incId, int? itemId)
	{
		for (int i = this.SelectedList.Count - 1; i >= 0; i--)
		{
			int itemId2 = this.SelectedList[i].ItemId;
			int? num = itemId;
			if (itemId2 == num.GetValueOrDefault() & num != null)
			{
				int incId2 = this.SelectedList[i].IncId;
				num = incId;
				if (incId2 == num.GetValueOrDefault() & num != null)
				{
					ISelectedData selectedData = this.SelectedList[i];
					int selectedCount = selectedData.SelectedCount;
					selectedData.SelectedCount = selectedCount - 1;
					if (this.SelectedList[i].SelectedCount == 0)
					{
						this.SelectedList.RemoveAt(i);
					}
				}
			}
		}
		this.RefreshItemAndExp();
	}

	// Token: 0x06017389 RID: 95113 RVA: 0x0066FCDF File Offset: 0x0066DEDF
	private void ConditionFunction(int index)
	{
		this.CurrentAutoQualityIndex = new int?(index);
		this.RefreshConditionText();
	}

	// Token: 0x0601738A RID: 95114 RVA: 0x0066FCF4 File Offset: 0x0066DEF4
	private void RefreshConditionText()
	{
		int qualityIdByIndex = this.GetQualityIdByIndex(this.CurrentAutoQualityIndex.Value);
		this.ItemGridConsumeComponent.RefreshConditionText(ConfigBase<CommonConfig>.Instance.GetItemQualityById(qualityIdByIndex).Value.ConsumeFilterText);
	}

	// Token: 0x0601738B RID: 95115 RVA: 0x0066FD3C File Offset: 0x0066DF3C
	private int GetQualityIdByIndex(int index)
	{
		List<QualityInfo> itemQualityList = ConfigBase<CommonConfig>.Instance.GetItemQualityList();
		int index2 = Singleton<MathUtils>.Instance.Clamp(index, 0, itemQualityList.Count - 1);
		return itemQualityList[index2].Id;
	}

	// Token: 0x0601738C RID: 95116 RVA: 0x0066FD78 File Offset: 0x0066DF78
	private void RefreshItemAndExp()
	{
		int num = 0;
		this.ClearConsume();
		if (this.SelectedList != null)
		{
			for (int i = 0; i < this.SelectedList.Count; i++)
			{
				ISelectedData selectedData = this.SelectedList[i];
				TCommonMultipleConsumeData value = this.ConsumeList[i];
				value.ItemData = new InventoryDefine.GetItemData(selectedData.ItemId, selectedData.IncId);
				value.Count = selectedData.SelectedCount;
				this.ConsumeList[i] = value;
				num += this.GetItemExpFunction(selectedData) * selectedData.SelectedCount;
			}
		}
		int weaponExpItemListCost = ModelBase<WeaponModel>.Instance.GetWeaponExpItemListCost(this.ConsumeList.ToArray());
		this.ItemGridConsumeComponent.UpdateComponent(2, weaponExpItemListCost, this.ConsumeList);
		this.CurrentExpData.UpdateExp(num);
		this.ExpComponent.Update(this.CurrentExpData, true);
		this.UpdateAttribute();
	}

	// Token: 0x0601738D RID: 95117 RVA: 0x0066FE58 File Offset: 0x0066E058
	private void RefreshName()
	{
		WeaponConf value = this.WeaponInstance.GetWeaponConfig().Value;
		string weaponName = value.WeaponName;
		FColor color = FColor.FromHex(ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetQualityConfig(value.QualityId).Value.DropColor);
		base.GetText(4).SetColor(color);
		base.GetText(4).ShowTextNew(weaponName);
	}

	// Token: 0x0601738E RID: 95118 RVA: 0x0066FEC4 File Offset: 0x0066E0C4
	private void ClearConsume()
	{
		for (int i = 0; i < this.ConsumeList.Count; i++)
		{
			TCommonMultipleConsumeData value = this.ConsumeList[i];
			value.ItemData = new InventoryDefine.GetItemData(0, 0);
			value.Count = 0;
			this.ConsumeList[i] = value;
		}
	}

	// Token: 0x0601738F RID: 95119 RVA: 0x0066FF17 File Offset: 0x0066E117
	private void TurnToBreachView()
	{
		UiInteractLogReport.ReportSpaceKeyInteract(EUiInteractSpaceKeyType.WeaponLevelUp);
		this.CheckAndCloseItemHintViewNew();
		Singleton<EventSystem>.Instance.Emit(EEventName.WeaponCanGoBreach);
	}

	// Token: 0x06017390 RID: 95120 RVA: 0x0066FF35 File Offset: 0x0066E135
	private void CheckAndCloseItemHintViewNew()
	{
		if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ItemHintViewNew))
		{
			return;
		}
		Singleton<UiManager>.Instance.CloseView(EUiViewName.ItemHintViewNew, null);
	}

	// Token: 0x06017391 RID: 95121 RVA: 0x0066FF5C File Offset: 0x0066E15C
	private void TryOpenItemHintView()
	{
		if (this.ReceiveItemList.Count > 0)
		{
			ItemHintViewNewData itemHintViewNewData = new ItemHintViewNewData();
			itemHintViewNewData.CheckPriorNext = (() => this.ReceiveItemList.Count > 0);
			itemHintViewNewData.ShiftPriorItem = delegate()
			{
				TItem titem = this.ReceiveItemList[0];
				this.ReceiveItemList.RemoveAt(0);
				ItemRewardInfo itemRewardInfo = new ItemRewardInfo();
				itemRewardInfo.ItemId = new int?(titem.ItemData.ItemId);
				itemRewardInfo.ItemCount = new int?(titem.Count);
				CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(titem.ItemData.ItemId);
				itemRewardInfo.Quality = itemConfigData.QualityId;
				return itemRewardInfo;
			};
			itemHintViewNewData.TitleTextId = "Text_ItemReturnTitle_Text";
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ItemHintViewNew, itemHintViewNewData, null);
		}
	}

	// Token: 0x0400B285 RID: 45701
	[Nullable(2)]
	private ExpComponent ExpComponent;

	// Token: 0x0400B286 RID: 45702
	[Nullable(2)]
	private SelectableExpData CurrentExpData;

	// Token: 0x0400B287 RID: 45703
	[Nullable(2)]
	protected WeaponInstance WeaponInstance;

	// Token: 0x0400B288 RID: 45704
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<IWeaponAttributeParam> AttributeParamList;

	// Token: 0x0400B289 RID: 45705
	[Nullable(2)]
	private ItemGridConsumeComponent ItemGridConsumeComponent;

	// Token: 0x0400B28A RID: 45706
	[Nullable(2)]
	private List<TItem> ReceiveItemList = new List<TItem>();

	// Token: 0x0400B28B RID: 45707
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<ISelectedData> SelectedList;

	// Token: 0x0400B28C RID: 45708
	[Nullable(2)]
	private List<TCommonMultipleConsumeData> ConsumeList;

	// Token: 0x0400B28D RID: 45709
	private int? CurrentAutoQualityIndex;

	// Token: 0x0400B28E RID: 45710
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<AttributeItem, CSharpScript.Game.Module.Common.AttributeData> AttributeLayout;

	// Token: 0x0400B28F RID: 45711
	[Nullable(2)]
	private SkeletalObserverHandle WeaponObserver;

	// Token: 0x0400B290 RID: 45712
	[Nullable(2)]
	private SkeletalObserverHandle WeaponScabbardObserver;

	// Token: 0x02008FBD RID: 36797
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x040303F3 RID: 197619
		ExpItem,
		// Token: 0x040303F4 RID: 197620
		AttributeLayout,
		// Token: 0x040303F5 RID: 197621
		ConsumeItem,
		// Token: 0x040303F6 RID: 197622
		AttributeItem,
		// Token: 0x040303F7 RID: 197623
		WeaponNameText
	}
}
