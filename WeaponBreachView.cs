using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Manufacture.Compose.QuicklyPopup;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002CF0 RID: 11504
[NullableContext(2)]
[Nullable(0)]
public class WeaponBreachView : UiTabViewBase
{
	// Token: 0x06017320 RID: 95008 RVA: 0x0066D8C4 File Offset: 0x0066BAC4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06017321 RID: 95009 RVA: 0x0066D9D2 File Offset: 0x0066BBD2
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
	}

	// Token: 0x06017322 RID: 95010 RVA: 0x0066D9F0 File Offset: 0x0066BBF0
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
	}

	// Token: 0x06017323 RID: 95011 RVA: 0x0066DA10 File Offset: 0x0066BC10
	protected override void OnStart()
	{
		this.StarLayout = new GenericLayout<CSharpScript.Game.Module.RoleUi.StarItem, IStarItemData>(base.GetHorizontalLayout(2), new Func<CSharpScript.Game.Module.RoleUi.StarItem>(this.InitStarItem), null, false, true);
		this.CostItemGridComponent = new CostItemGridComponent(base.GetItem(4), new Action<int>(this.BreachClick), new Action(this.LevelUpLockTipClick), new EUiViewName?(EUiViewName.WeaponRootView));
		this.CostItemGridComponent.SetMaxItemActive(false);
		this.CostItemGridComponent.SetButtonItemLocalText("RoleBreakup");
		this.AttributeLayout = new GenericLayout<AttributeItem, CSharpScript.Game.Module.Common.AttributeData>(base.GetVerticalLayout(3), new Func<AttributeItem>(this.InitAttributeItem), base.GetItem(5).GetOwner() as AUIBaseActor, false, true);
	}

	// Token: 0x06017324 RID: 95012 RVA: 0x0066DAC0 File Offset: 0x0066BCC0
	private void BreachClick(int _)
	{
		if (this.WeaponBreachState == EWeaponBreachState.NoEnoughMaterial || this.WeaponBreachState == EWeaponBreachState.NoEnoughMoney)
		{
			List<ISelectedData> selectedDataList = this.GetSelectedDataList();
			ComposePopupViewData param = new ComposePopupViewData
			{
				SelectedItemList = selectedDataList,
				ClickConfirm = new Action(this.BreachRequest),
				BelongView = new EUiViewName?(EUiViewName.WeaponRootView)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SynthesisTipsInfoView, param, delegate(bool isSuccess, int viewId)
			{
				if (isSuccess)
				{
					UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.WeaponRootView);
					if (viewByName == null)
					{
						return;
					}
					viewByName.AddChildViewById(viewId);
				}
			});
			return;
		}
		this.BreachRequest();
	}

	// Token: 0x06017325 RID: 95013 RVA: 0x0066DB4C File Offset: 0x0066BD4C
	private void BreachRequest()
	{
		this.WeaponObserver = Singleton<UiSceneManager>.Instance.GetWeaponObserver();
		this.WeaponScabbardObserver = Singleton<UiSceneManager>.Instance.GetWeaponScabbardObserver();
		this.TsUiSceneRoleActor = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor();
		WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(this.WeaponIncId);
		if (weaponDataByIncId != null)
		{
			weaponDataByIncId.GetRoleId();
		}
		ControllerBase<WeaponController>.Instance.SendPbWeaponBreachRequest(this.WeaponIncId, delegate(int weaponBreach)
		{
			UiModelBase model = this.WeaponObserver.Model;
			Singleton<UiModelUtil>.Instance.PlayEffectAtRootComponent(model, "WeaponBreachEffect");
			ControllerBase<WeaponController>.Instance.PlayWeaponRenderingMaterial("WeaponBreachMaterialController", this.WeaponObserver, this.WeaponScabbardObserver);
			int? weaponBreachDaDelayTime = ConfigBase<RoleConfig>.Instance.GetWeaponBreachDaDelayTime();
			TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				foreach (SkeletalObserverHandle skeletalObserverHandle in new SkeletalObserverHandle[]
				{
					this.WeaponObserver,
					this.WeaponScabbardObserver
				})
				{
					if (((skeletalObserverHandle != null) ? skeletalObserverHandle.Model : null) != null)
					{
						Singleton<UiModelUtil>.Instance.SetWeaponLevelMaterialBreachLevel(skeletalObserverHandle.Model, weaponBreach);
						Singleton<UiModelUtil>.Instance.TryApplyWeaponLevelMaterial(skeletalObserverHandle.Model);
					}
				}
				TsUiSceneRoleActor tsUiSceneRoleActor = this.TsUiSceneRoleActor;
				if (tsUiSceneRoleActor == null)
				{
					return;
				}
				UiModelBase model2 = tsUiSceneRoleActor.Model;
				if (model2 == null)
				{
					return;
				}
				UiRoleWeaponComponent uiRoleWeaponComponent = model2.CheckGetComponent<UiRoleWeaponComponent>();
				if (uiRoleWeaponComponent == null)
				{
					return;
				}
				uiRoleWeaponComponent.RefreshWeaponDa();
			}, (float)weaponBreachDaDelayTime.Value, null, null, true, 1f);
		});
	}

	// Token: 0x06017326 RID: 95014 RVA: 0x0066DBC1 File Offset: 0x0066BDC1
	[NullableContext(1)]
	private List<ISelectedData> GetSelectedDataList()
	{
		return this.CachedConsumeList ?? new List<ISelectedData>();
	}

	// Token: 0x06017327 RID: 95015 RVA: 0x0066DBD4 File Offset: 0x0066BDD4
	protected void LevelUpLockTipClick()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RoleBreakUpTip);
		int curQuestId = ModelBase<QuestNewModel>.Instance.GetCurWorldLevelBreakQuest();
		if (curQuestId < 0)
		{
			confirmBoxDataNew.InteractionMap.Add(1, false);
		}
		else
		{
			confirmBoxDataNew.FunctionMap.Add(2, delegate
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, curQuestId, null);
			});
			confirmBoxDataNew.InteractionMap.Add(1, true);
		}
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06017328 RID: 95016 RVA: 0x0066DC4B File Offset: 0x0066BE4B
	protected override void OnBeforeShow()
	{
		this.WeaponIncId = (int)this.ExtraParams;
		this.UpdateView();
		this.RefreshName();
	}

	// Token: 0x06017329 RID: 95017 RVA: 0x0066DC6A File Offset: 0x0066BE6A
	private void OnCommonItemCountAnyChange(int i, int i1)
	{
		this.UpdateView();
	}

	// Token: 0x0601732A RID: 95018 RVA: 0x0066DC74 File Offset: 0x0066BE74
	private void UpdateView()
	{
		WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(this.WeaponIncId);
		WeaponBreach? breachConfig = weaponDataByIncId.GetBreachConfig();
		WeaponConf value = weaponDataByIncId.GetWeaponConfig().Value;
		WeaponBreach? weaponBreach = ConfigBase<WeaponConfig>.Instance.GetWeaponBreach(value.BreachId, weaponDataByIncId.GetBreachLevel() + 1);
		UUIText text = base.GetText(0);
		int levelLimit = weaponBreach.Value.LevelLimit;
		text.SetText(levelLimit.ToString(), true);
		int breachId = value.BreachId;
		int weaponBreachMaxLevel = ModelBase<WeaponModel>.Instance.GetWeaponBreachMaxLevel(breachId);
		this.UpdateStar(weaponDataByIncId.GetBreachLevel(), weaponBreachMaxLevel);
		this.WeaponBreachState = ModelBase<WeaponModel>.Instance.GetWeaponBreachState(this.WeaponIncId);
		if (this.WeaponBreachState == EWeaponBreachState.NoEnoughCondition)
		{
			string conditionGroupHintText = LevelGeneralCommons.GetConditionGroupHintText(breachConfig.Value.ConditionId);
			this.CostItemGridComponent.SetButtonItemActive(false);
			this.CostItemGridComponent.SetLockItemActive(true);
			this.CostItemGridComponent.SetLockLocalText(conditionGroupHintText ?? "", Array.Empty<object>());
		}
		else
		{
			this.CostItemGridComponent.SetButtonItemActive(true);
			this.CostItemGridComponent.SetLockItemActive(false);
		}
		List<ISelectedData> list = new List<ISelectedData>();
		Dictionary<int, int> dictionary = breachConfig.Value.Consume();
		if (dictionary != null)
		{
			foreach (KeyValuePair<int, int> keyValuePair in dictionary)
			{
				int num;
				keyValuePair.Deconstruct(out levelLimit, out num);
				int num2 = levelLimit;
				int count = num;
				SelectedData item = new SelectedData
				{
					ItemId = num2,
					IncId = 0,
					SelectedCount = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(num2, 0),
					Count = count
				};
				list.Add(item);
			}
		}
		int goldConsume = breachConfig.Value.GoldConsume;
		this.CachedConsumeList = new List<ISelectedData>();
		foreach (ISelectedData selectedData in list)
		{
			this.CachedConsumeList.Add(new SelectedData
			{
				ItemId = selectedData.ItemId,
				IncId = selectedData.IncId,
				SelectedCount = selectedData.SelectedCount,
				Count = selectedData.Count
			});
		}
		if (goldConsume > 0)
		{
			this.CachedConsumeList.Add(new SelectedData
			{
				ItemId = 2,
				IncId = 0,
				Count = goldConsume,
				SelectedCount = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(2, 0)
			});
		}
		this.CostItemGridComponent.Update(list, 2, goldConsume);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "RoleBreakUpLevel", new <>z__ReadOnlySingleElementList<object>(weaponDataByIncId.GetBreachLevel() + 1));
		this.UpdateAttribute();
		this.RefreshCostItemButton();
	}

	// Token: 0x0601732B RID: 95019 RVA: 0x0066DF54 File Offset: 0x0066C154
	private void RefreshCostItemButton()
	{
		if (this.WeaponBreachState != EWeaponBreachState.CanBreach)
		{
			if (this.WeaponBreachState == EWeaponBreachState.NoEnoughMaterial || this.WeaponBreachState == EWeaponBreachState.NoEnoughMoney)
			{
				bool flag = ModelBase<ComposePopupModel>.Instance.CheckOpenResult(this.GetSelectedDataList());
				if (flag)
				{
					this.CostItemGridComponent.SetButtonItemLocalTextNew("AutoSynthesis_MaterialReplenishBtn_Text");
				}
				else
				{
					this.CostItemGridComponent.SetButtonItemLocalTextNew("AutoSynthesis_MaterialMissingBtn_Text");
				}
				CostItemGridComponent costItemGridComponent = this.CostItemGridComponent;
				if (costItemGridComponent == null)
				{
					return;
				}
				costItemGridComponent.SetButtonItemInteractive(flag);
			}
			return;
		}
		this.CostItemGridComponent.SetButtonItemLocalText("RoleBreakup");
		CostItemGridComponent costItemGridComponent2 = this.CostItemGridComponent;
		if (costItemGridComponent2 == null)
		{
			return;
		}
		costItemGridComponent2.SetButtonItemInteractive(true);
	}

	// Token: 0x0601732C RID: 95020 RVA: 0x0066DFE4 File Offset: 0x0066C1E4
	private void UpdateStar(int breachLevel, int maxLevel)
	{
		if (this.StarLayout == null)
		{
			this.StarLayout = new GenericLayout<CSharpScript.Game.Module.RoleUi.StarItem, IStarItemData>(base.GetHorizontalLayout(2), new Func<CSharpScript.Game.Module.RoleUi.StarItem>(this.InitStarItem), null, false, true);
		}
		IStarItemData[] array = new IStarItemData[maxLevel];
		for (int i = 0; i < maxLevel; i++)
		{
			StarItemData starItemData = new StarItemData
			{
				StarOnActive = (i < breachLevel),
				StarOffActive = (i > breachLevel),
				StarNextActive = (i == breachLevel),
				StarLoopActive = (i == breachLevel),
				PlayLoopSequence = (i == breachLevel),
				PlayActivateSequence = false
			};
			array[i] = starItemData;
		}
		this.StarLayout.RefreshByData(array.ToList<IStarItemData>(), null, false);
	}

	// Token: 0x0601732D RID: 95021 RVA: 0x0066E083 File Offset: 0x0066C283
	[NullableContext(1)]
	private CSharpScript.Game.Module.RoleUi.StarItem InitStarItem()
	{
		return new CSharpScript.Game.Module.RoleUi.StarItem();
	}

	// Token: 0x0601732E RID: 95022 RVA: 0x0066E08C File Offset: 0x0066C28C
	private void UpdateAttribute()
	{
		WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(this.WeaponIncId);
		WeaponConf value = weaponDataByIncId.GetWeaponConfig().Value;
		this.AttributeParamList = ModelBase<WeaponModel>.Instance.GetWeaponAttributeParamList(value).ToList<IWeaponAttributeParam>();
		int breachLevel = weaponDataByIncId.GetBreachLevel();
		int num = breachLevel + 1;
		int level = weaponDataByIncId.GetLevel();
		List<CSharpScript.Game.Module.Common.AttributeData> list = new List<CSharpScript.Game.Module.Common.AttributeData>();
		foreach (IWeaponAttributeParam weaponAttributeParam in this.AttributeParamList)
		{
			int curveId = weaponAttributeParam.CurveId;
			ConfigPropValue propId = weaponAttributeParam.PropId;
			float value2 = propId.Value;
			float curveValue = ModelBase<WeaponModel>.Instance.GetCurveValue(curveId, value2, level, breachLevel);
			float num2 = 0f;
			if (num > breachLevel)
			{
				num2 = ModelBase<WeaponModel>.Instance.GetCurveValue(curveId, value2, level, num);
			}
			CSharpScript.Game.Module.Common.AttributeData item = new CSharpScript.Game.Module.Common.AttributeData
			{
				Id = propId.Id,
				IsRatio = propId.IsRatio,
				CurValue = curveValue,
				BgActive = new bool?(true),
				ShowNext = new bool?(num2 > curveValue),
				NextValue = new float?(num2)
			};
			list.Add(item);
		}
		this.AttributeLayout.RefreshByData(list, null, false);
	}

	// Token: 0x0601732F RID: 95023 RVA: 0x0066E1E0 File Offset: 0x0066C3E0
	private void RefreshName()
	{
		WeaponConf value = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(this.WeaponIncId).GetWeaponConfig().Value;
		string weaponName = value.WeaponName;
		FColor color = FColor.FromHex(ConfigBase<ItemConfig>.Instance.GetQualityConfig(value.QualityId).Value.DropColor);
		base.GetText(6).SetColor(color);
		base.GetText(6).ShowTextNew(weaponName);
	}

	// Token: 0x06017330 RID: 95024 RVA: 0x0066E256 File Offset: 0x0066C456
	[NullableContext(1)]
	private AttributeItem InitAttributeItem()
	{
		return new AttributeItem();
	}

	// Token: 0x06017331 RID: 95025 RVA: 0x0066E25D File Offset: 0x0066C45D
	protected override void OnBeforeDestroy()
	{
		this.CostItemGridComponent.Destroy(null);
	}

	// Token: 0x0400B276 RID: 45686
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericLayout<AttributeItem, CSharpScript.Game.Module.Common.AttributeData> AttributeLayout;

	// Token: 0x0400B277 RID: 45687
	private CostItemGridComponent CostItemGridComponent;

	// Token: 0x0400B278 RID: 45688
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericLayout<CSharpScript.Game.Module.RoleUi.StarItem, IStarItemData> StarLayout;

	// Token: 0x0400B279 RID: 45689
	private EWeaponBreachState WeaponBreachState;

	// Token: 0x0400B27A RID: 45690
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<IWeaponAttributeParam> AttributeParamList;

	// Token: 0x0400B27B RID: 45691
	private int WeaponIncId;

	// Token: 0x0400B27C RID: 45692
	private SkeletalObserverHandle WeaponObserver;

	// Token: 0x0400B27D RID: 45693
	private SkeletalObserverHandle WeaponScabbardObserver;

	// Token: 0x0400B27E RID: 45694
	private TsUiSceneRoleActor TsUiSceneRoleActor;

	// Token: 0x0400B27F RID: 45695
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<ISelectedData> CachedConsumeList;

	// Token: 0x02008FB8 RID: 36792
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x040303E0 RID: 197600
		NewLevelLimitText,
		// Token: 0x040303E1 RID: 197601
		LevelText,
		// Token: 0x040303E2 RID: 197602
		StarHorizontalLayout,
		// Token: 0x040303E3 RID: 197603
		AttributeLayout,
		// Token: 0x040303E4 RID: 197604
		ConsumeItem,
		// Token: 0x040303E5 RID: 197605
		AttributeItem,
		// Token: 0x040303E6 RID: 197606
		WeaponNameText
	}
}
