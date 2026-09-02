using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200289D RID: 10397
[NullableContext(1)]
[Nullable(0)]
public class RoleLevelUpView : UiViewBase
{
	// Token: 0x06014961 RID: 84321 RVA: 0x005B31F1 File Offset: 0x005B13F1
	public RoleLevelUpView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06014962 RID: 84322 RVA: 0x005B3208 File Offset: 0x005B1408
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIGridLayout)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x06014963 RID: 84323 RVA: 0x005B3278 File Offset: 0x005B1478
	protected void CloseClick()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.RoleLevelUpView, null);
	}

	// Token: 0x06014964 RID: 84324 RVA: 0x005B328C File Offset: 0x005B148C
	protected override UniTask OnBeforeStartAsync()
	{
		RoleLevelUpView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleLevelUpView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014965 RID: 84325 RVA: 0x005B32D0 File Offset: 0x005B14D0
	protected override UniTask OnPlayingStartSequenceAsync()
	{
		RoleLevelUpView.<OnPlayingStartSequenceAsync>d__14 <OnPlayingStartSequenceAsync>d__;
		<OnPlayingStartSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlayingStartSequenceAsync>d__.<>4__this = this;
		<OnPlayingStartSequenceAsync>d__.<>1__state = -1;
		<OnPlayingStartSequenceAsync>d__.<>t__builder.Start<RoleLevelUpView.<OnPlayingStartSequenceAsync>d__14>(ref <OnPlayingStartSequenceAsync>d__);
		return <OnPlayingStartSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014966 RID: 84326 RVA: 0x005B3314 File Offset: 0x005B1514
	protected override UniTask OnPlayingCloseSequenceAsync()
	{
		RoleLevelUpView.<OnPlayingCloseSequenceAsync>d__15 <OnPlayingCloseSequenceAsync>d__;
		<OnPlayingCloseSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlayingCloseSequenceAsync>d__.<>4__this = this;
		<OnPlayingCloseSequenceAsync>d__.<>1__state = -1;
		<OnPlayingCloseSequenceAsync>d__.<>t__builder.Start<RoleLevelUpView.<OnPlayingCloseSequenceAsync>d__15>(ref <OnPlayingCloseSequenceAsync>d__);
		return <OnPlayingCloseSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014967 RID: 84327 RVA: 0x005B3357 File Offset: 0x005B1557
	protected override void OnHandleLoadScene()
	{
		this.ViewModel.HandleLoadScene(delegate
		{
			ControllerBase<RoleController>.Instance.PlayRoleMontage(EPerformanceRoleState.Attribute_Perform, false, true, false);
		});
	}

	// Token: 0x06014968 RID: 84328 RVA: 0x005B3383 File Offset: 0x005B1583
	protected override void OnHandleReleaseScene()
	{
		this.ViewModel.HandleReleaseScene();
	}

	// Token: 0x06014969 RID: 84329 RVA: 0x005B3390 File Offset: 0x005B1590
	private void InitDataList()
	{
		this.DataList = new List<ISelectedData>().ToArray();
		ItemInfo[] roleCostExpList = ModelBase<RoleModel>.Instance.GetRoleCostExpList();
		List<ISelectedData> list = new List<ISelectedData>();
		foreach (ItemInfo itemInfo in roleCostExpList)
		{
			SelectedData item = new SelectedData
			{
				IncId = 0,
				ItemId = itemInfo.Id,
				Count = ModelBase<InventoryModel>.Instance.GetCommonItemCount(itemInfo.Id, 0),
				SelectedCount = 0
			};
			list.Add(item);
		}
		this.DataList = list.ToArray();
		this.RoleExpItemGridComponent.Update(RoleLevelUpView.ArrayToList<ISelectedData>(this.DataList), 2, 0);
	}

	// Token: 0x0601496A RID: 84330 RVA: 0x005B343C File Offset: 0x005B163C
	protected void OnClickItemAdd(int configId)
	{
		ISelectedData[] dataList = this.DataList;
		int i = dataList.Length - 1;
		while (i >= 0)
		{
			ISelectedData selectedData = dataList[i];
			if (selectedData.ItemId == configId)
			{
				if (selectedData.Count == 0)
				{
					ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(configId, true, null);
					return;
				}
				if (this.CheckIsMaxLevel())
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("WeaponAddExpTipsText", Array.Empty<object>());
					return;
				}
				if (selectedData.Count > selectedData.SelectedCount)
				{
					ISelectedData selectedData2 = selectedData;
					int selectedCount = selectedData2.SelectedCount;
					selectedData2.SelectedCount = selectedCount + 1;
					this.RefreshItemAndExp();
					return;
				}
				break;
			}
			else
			{
				i--;
			}
		}
	}

	// Token: 0x0601496B RID: 84331 RVA: 0x005B34C8 File Offset: 0x005B16C8
	protected void OnClickItemReduce(int configId)
	{
		ISelectedData[] dataList = this.DataList;
		int i = dataList.Length - 1;
		while (i >= 0)
		{
			ISelectedData selectedData = dataList[i];
			if (selectedData.ItemId == configId)
			{
				if (selectedData.SelectedCount > 0)
				{
					ISelectedData selectedData2 = selectedData;
					int selectedCount = selectedData2.SelectedCount;
					selectedData2.SelectedCount = selectedCount - 1;
					break;
				}
				break;
			}
			else
			{
				i--;
			}
		}
		this.RefreshItemAndExp();
	}

	// Token: 0x0601496C RID: 84332 RVA: 0x005B351C File Offset: 0x005B171C
	private void OnClickAutoFunction()
	{
		EAutoButtonState autoButtonState = this.RoleExpItemGridComponent.GetAutoButtonState();
		ISelectedData[] dataList = this.DataList;
		if (autoButtonState == EAutoButtonState.AutoAdd)
		{
			bool flag = false;
			ISelectedData[] array = dataList;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].Count > 0)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("RoleNoMaterial", Array.Empty<object>());
				return;
			}
			int expDistanceToMax = this.CurrentExpData.GetExpDistanceToMax();
			ModelBase<WeaponModel>.Instance.AutoAddExpItemEx(expDistanceToMax, dataList, new Func<ISelectedData, int>(this.GetItemExp));
			this.RefreshItemAndExp();
		}
		else if (autoButtonState == EAutoButtonState.Clear)
		{
			ISelectedData[] array = dataList;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SelectedCount = 0;
			}
		}
		this.RefreshItemAndExp();
	}

	// Token: 0x0601496D RID: 84333 RVA: 0x005B35D8 File Offset: 0x005B17D8
	private bool CanItemLongPress(int configId)
	{
		ISelectedData[] dataList = this.DataList;
		for (int i = dataList.Length - 1; i >= 0; i--)
		{
			ISelectedData selectedData = dataList[i];
			if (selectedData.ItemId == configId && selectedData.Count > 0 && selectedData.SelectedCount < selectedData.Count && !this.CheckIsMaxLevel())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0601496E RID: 84334 RVA: 0x005B362C File Offset: 0x005B182C
	private bool CanItemReduceLongPress(int configId)
	{
		ISelectedData[] dataList = this.DataList;
		for (int i = dataList.Length - 1; i >= 0; i--)
		{
			ISelectedData selectedData = dataList[i];
			if (selectedData.ItemId == configId && selectedData.SelectedCount <= 0)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0601496F RID: 84335 RVA: 0x005B366C File Offset: 0x005B186C
	private void RefreshItemAndExp()
	{
		int num = 0;
		ISelectedData[] dataList = this.DataList;
		foreach (ISelectedData selectedData in dataList)
		{
			selectedData.Count = ModelBase<InventoryModel>.Instance.GetCommonItemCount(selectedData.ItemId, 0);
		}
		this.RoleExpItemGridComponent.UpdateByDataList(RoleLevelUpView.ArrayToList<ISelectedData>(dataList));
		foreach (ISelectedData selectedData2 in dataList)
		{
			num += this.GetItemExp(selectedData2) * selectedData2.SelectedCount;
		}
		this.CurrentExpData.UpdateExp(num);
		this.ExpComponent.Update(this.CurrentExpData, true);
		int expDistanceToMax = this.CurrentExpData.GetExpDistanceToMax();
		int moneyToLevelUp = ModelBase<RoleModel>.Instance.GetMoneyToLevelUp(Math.Min(expDistanceToMax, num));
		this.RoleExpItemGridComponent.UpdateMoney(2, moneyToLevelUp);
		if (num > 0)
		{
			this.RoleExpItemGridComponent.SetAutoButtonText("PrefabTextItem_3035508725_Text");
		}
		else
		{
			this.RoleExpItemGridComponent.SetAutoButtonText("PrefabTextItem_744293929_Text");
		}
		this.UpdateAttribute();
	}

	// Token: 0x06014970 RID: 84336 RVA: 0x005B3770 File Offset: 0x005B1970
	private int GetItemExp(ISelectedData data)
	{
		return ModelBase<RoleModel>.Instance.GetRoleExpItemExp(data.ItemId).Value;
	}

	// Token: 0x06014971 RID: 84337 RVA: 0x005B3795 File Offset: 0x005B1995
	private AttributeItem InitAttributeItem()
	{
		return new AttributeItem();
	}

	// Token: 0x06014972 RID: 84338 RVA: 0x005B379C File Offset: 0x005B199C
	private void OnExpTweenComplete(bool _)
	{
		this.InitExp();
		this.ResetDataList();
		this.RefreshItemAndExp();
	}

	// Token: 0x06014973 RID: 84339 RVA: 0x005B37B0 File Offset: 0x005B19B0
	private IAttributeInfo[] GetLevelUpAttributeDataList(int currentLevel, int arrivedLevel)
	{
		List<AttributeItem> layoutItemList = this.AttributeLayout.GetLayoutItemList();
		List<IAttributeInfo> list = new List<IAttributeInfo>();
		RoleLevelData levelData = this.RoleInstance.GetLevelData();
		int roleId = this.RoleInstance.GetRoleId();
		int breachLevel = levelData.GetBreachLevel();
		foreach (AttributeItem attributeItem in layoutItemList)
		{
			int attributeId = attributeItem.GetAttributeId();
			int attributeByLevel = ModelBase<RoleModel>.Instance.GetAttributeByLevel(roleId, (EAttributeType)attributeId, currentLevel, breachLevel);
			int attributeByLevel2 = ModelBase<RoleModel>.Instance.GetAttributeByLevel(roleId, (EAttributeType)attributeId, arrivedLevel, breachLevel);
			if (attributeByLevel != attributeByLevel2)
			{
				IAttributeInfo attributeInfo = RoleLevelUpSuccessController.ConvertsAttrListScrollDataToAttributeInfo(new AttrListScrollData(attributeId, (double)attributeByLevel, (double)attributeByLevel2, 0, false, CommonComponentDefine.EAttributeType.NormalType));
				attributeInfo.Name = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(attributeId).Value.AnotherName;
				list.Add(attributeInfo);
			}
		}
		return list.ToArray();
	}

	// Token: 0x06014974 RID: 84340 RVA: 0x005B38A0 File Offset: 0x005B1AA0
	private void ShowReturnRootReward()
	{
		UiInteractLogReport.ReportSpaceKeyInteract(EUiInteractSpaceKeyType.RoleLevelUp);
		List<RewardItemData> list = new List<RewardItemData>();
		foreach (TItem titem in this.ReceiveItemList)
		{
			InventoryDefine.IGetItemData itemData = titem.ItemData;
			int count = titem.Count;
			RewardItemData item = new RewardItemData(itemData.ItemId, count, new int?(itemData.IncId), EDropItemType.Normal);
			list.Add(item);
		}
		ControllerBase<ItemRewardController>.Instance.OpenCommonRewardView(1010, list, new Action(this.ReturnRootViewFromReward));
	}

	// Token: 0x06014975 RID: 84341 RVA: 0x005B3924 File Offset: 0x005B1B24
	private void ShowToBreachReward()
	{
		UiInteractLogReport.ReportSpaceKeyInteract(EUiInteractSpaceKeyType.RoleBreach);
		List<RewardItemData> list = new List<RewardItemData>();
		foreach (TItem titem in this.ReceiveItemList)
		{
			InventoryDefine.IGetItemData itemData = titem.ItemData;
			int count = titem.Count;
			RewardItemData item = new RewardItemData(itemData.ItemId, count, new int?(itemData.IncId), EDropItemType.Normal);
			list.Add(item);
		}
		ControllerBase<ItemRewardController>.Instance.OpenCommonRewardView(1010, list, new Action(this.TurnToBreachViewFromReward));
	}

	// Token: 0x06014976 RID: 84342 RVA: 0x005B39A6 File Offset: 0x005B1BA6
	private int MaxExpFunction(int level)
	{
		return ModelBase<RoleModel>.Instance.GetRoleLevelUpExp(this.RoleInstance.GetRoleId(), level + 1);
	}

	// Token: 0x06014977 RID: 84343 RVA: 0x005B39C0 File Offset: 0x005B1BC0
	private void ReturnRootViewFromReward()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.RoleLevelUpView, null);
	}

	// Token: 0x06014978 RID: 84344 RVA: 0x005B39D2 File Offset: 0x005B1BD2
	private void ReturnRootView()
	{
		UiInteractLogReport.ReportSpaceKeyInteract(EUiInteractSpaceKeyType.RoleLevelUp);
		Singleton<UiManager>.Instance.CloseView(EUiViewName.RoleLevelUpView, null);
	}

	// Token: 0x06014979 RID: 84345 RVA: 0x005B39EC File Offset: 0x005B1BEC
	private void TurnToBreachViewFromReward()
	{
		RoleViewViewModel roleViewViewModel = new RoleViewViewModel(this.RoleInstance.GetRoleId(), false, ERoleViewSource.Normal);
		roleViewViewModel.FadeInCurveId = this.ViewModel.FadeInCurveId;
		roleViewViewModel.NeedHideOnViewPlayingCloseSequence = this.ViewModel.NeedHideOnViewPlayingCloseSequence;
		this.ViewModel.NeedHideOnViewPlayingCloseSequence = false;
		ControllerBase<RoleController>.Instance.CloseAndOpenRoleViewByViewModel(EUiViewName.RoleLevelUpView, EUiViewName.RoleBreachView, roleViewViewModel);
	}

	// Token: 0x0601497A RID: 84346 RVA: 0x005B3A50 File Offset: 0x005B1C50
	private void TurnToBreachView()
	{
		UiInteractLogReport.ReportSpaceKeyInteract(EUiInteractSpaceKeyType.RoleBreach);
		RoleViewViewModel roleViewViewModel = new RoleViewViewModel(this.RoleInstance.GetRoleId(), false, ERoleViewSource.Normal);
		roleViewViewModel.FadeInCurveId = this.ViewModel.FadeInCurveId;
		roleViewViewModel.NeedHideOnViewPlayingCloseSequence = this.ViewModel.NeedHideOnViewPlayingCloseSequence;
		this.ViewModel.NeedHideOnViewPlayingCloseSequence = false;
		ControllerBase<RoleController>.Instance.CloseAndOpenRoleViewByViewModel(EUiViewName.RoleLevelUpView, EUiViewName.RoleBreachView, roleViewViewModel);
	}

	// Token: 0x0601497B RID: 84347 RVA: 0x005B3ABC File Offset: 0x005B1CBC
	private UniTask Init()
	{
		RoleLevelUpView.<Init>d__36 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<RoleLevelUpView.<Init>d__36>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0601497C RID: 84348 RVA: 0x005B3B00 File Offset: 0x005B1D00
	private UniTask InitAttribute()
	{
		RoleLevelUpView.<InitAttribute>d__37 <InitAttribute>d__;
		<InitAttribute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitAttribute>d__.<>4__this = this;
		<InitAttribute>d__.<>1__state = -1;
		<InitAttribute>d__.<>t__builder.Start<RoleLevelUpView.<InitAttribute>d__37>(ref <InitAttribute>d__);
		return <InitAttribute>d__.<>t__builder.Task;
	}

	// Token: 0x0601497D RID: 84349 RVA: 0x005B3B43 File Offset: 0x005B1D43
	public void InitExp()
	{
		this.UpdateExpData();
		this.ExpComponent.UpdateInitState(this.CurrentExpData);
	}

	// Token: 0x0601497E RID: 84350 RVA: 0x005B3B5C File Offset: 0x005B1D5C
	private void Update()
	{
		this.UpdateAttribute();
		this.UpdateButtonState();
		this.RefreshItemAndExp();
	}

	// Token: 0x0601497F RID: 84351 RVA: 0x005B3B70 File Offset: 0x005B1D70
	public void ResetDataList()
	{
		foreach (ISelectedData selectedData in this.DataList)
		{
			selectedData.SelectedCount = 0;
			selectedData.Count = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(selectedData.ItemId, 0);
		}
	}

	// Token: 0x06014980 RID: 84352 RVA: 0x005B3BB4 File Offset: 0x005B1DB4
	private void UpdateAttribute()
	{
		foreach (AttributeItem attributeItem in this.AttributeLayout.GetLayoutItemList())
		{
			this.UpdateAttributeItemValue(attributeItem);
		}
	}

	// Token: 0x06014981 RID: 84353 RVA: 0x005B3C0C File Offset: 0x005B1E0C
	protected void UpdateExpData()
	{
		RoleLevelData levelData = this.RoleInstance.GetLevelData();
		int level = levelData.GetLevel();
		int currentMaxLevel = levelData.GetCurrentMaxLevel();
		int exp = levelData.GetExp();
		int roleMaxLevel = levelData.GetRoleMaxLevel();
		this.CurrentExpData.UpdateComponent(level, currentMaxLevel, exp, new int?(roleMaxLevel), false);
	}

	// Token: 0x06014982 RID: 84354 RVA: 0x005B3C54 File Offset: 0x005B1E54
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RoleInfoUpdate, new Action(this.RoleInfoUpdate));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<TItem>>(EEventName.RoleLevelUpReceiveItem, new Action<IReadOnlyList<TItem>>(this.RoleLevelUpReceiveItem));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
	}

	// Token: 0x06014983 RID: 84355 RVA: 0x005B3CB8 File Offset: 0x005B1EB8
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RoleInfoUpdate, new Action(this.RoleInfoUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.RoleLevelUpReceiveItem, new Action<IReadOnlyList<TItem>>(this.RoleLevelUpReceiveItem));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
	}

	// Token: 0x06014984 RID: 84356 RVA: 0x005B3D19 File Offset: 0x005B1F19
	private void RoleInfoUpdate()
	{
		this.OnLevelUpSuccess();
		this.ExpComponent.PlayExpTween(this.CurrentExpData);
	}

	// Token: 0x06014985 RID: 84357 RVA: 0x005B3D34 File Offset: 0x005B1F34
	private void OnLevelUpSuccess()
	{
		int currentLevel = this.CurrentExpData.GetCurrentLevel();
		RoleLevelData levelData = this.RoleInstance.GetLevelData();
		int level = levelData.GetLevel();
		if (level == currentLevel)
		{
			return;
		}
		this.UpdateAttribute();
		bool flag = this.ReceiveItemList != null && this.ReceiveItemList.Length != 0;
		IAttributeInfo[] levelUpAttributeDataList = this.GetLevelUpAttributeDataList(currentLevel, level);
		ILevelUpSuccessAttributeData data = null;
		if (levelData.GetRoleIsMaxLevel())
		{
			data = new LevelUpSuccessAttributeData
			{
				LevelInfo = new LevelInfo
				{
					PreUpgradeLv = currentLevel,
					UpgradeLv = level,
					FormatStringId = "Text_LevelShow_Text",
					IsMaxLevel = new bool?(true)
				},
				AttributeInfo = RoleLevelUpView.ArrayToList<IAttributeInfo>(levelUpAttributeDataList)
			};
			if (!flag)
			{
				data.ClickFunction = new Action(this.ReturnRootView);
			}
			else
			{
				data.ClickFunction = new Action(this.ShowReturnRootReward);
			}
		}
		else if (levelData.GetRoleNeedBreakUp())
		{
			data = new LevelUpSuccessAttributeData
			{
				LevelInfo = new LevelInfo
				{
					PreUpgradeLv = currentLevel,
					UpgradeLv = level,
					FormatStringId = "Text_LevelShow_Text",
					IsMaxLevel = new bool?(true)
				},
				ClickText = "Text_TurnToRoleBreach_Text",
				AttributeInfo = RoleLevelUpView.ArrayToList<IAttributeInfo>(levelUpAttributeDataList)
			};
			if (!flag)
			{
				data.ClickFunction = new Action(this.TurnToBreachView);
			}
			else
			{
				data.ClickFunction = new Action(this.ShowToBreachReward);
			}
		}
		else
		{
			data = new LevelUpSuccessAttributeData
			{
				LevelInfo = new LevelInfo
				{
					PreUpgradeLv = currentLevel,
					UpgradeLv = level,
					FormatStringId = "Text_LevelShow_Text"
				},
				AttributeInfo = RoleLevelUpView.ArrayToList<IAttributeInfo>(levelUpAttributeDataList)
			};
		}
		if (data == null)
		{
			return;
		}
		int? roleLevelUpSuccessDelayTime = ConfigBase<RoleConfig>.Instance.GetRoleLevelUpSuccessDelayTime();
		Singleton<UiLayer>.Instance.SetShowMaskLayer("OpenLevelUpSuccessView", true);
		TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			ControllerBase<RoleLevelUpSuccessController>.Instance.OpenSuccessAttributeView(data, null);
			Singleton<UiLayer>.Instance.SetShowMaskLayer("OpenLevelUpSuccessView", false);
		}, (float)roleLevelUpSuccessDelayTime.Value, null, null, true, 1f);
	}

	// Token: 0x06014986 RID: 84358 RVA: 0x005B3F44 File Offset: 0x005B2144
	private void RoleLevelUpReceiveItem(IReadOnlyList<TItem> itemList)
	{
		this.ReceiveItemList = itemList.ToArray<TItem>();
	}

	// Token: 0x06014987 RID: 84359 RVA: 0x005B3F52 File Offset: 0x005B2152
	private void OnCommonItemCountAnyChange(int i, int i1)
	{
		this.Update();
	}

	// Token: 0x06014988 RID: 84360 RVA: 0x005B3F5C File Offset: 0x005B215C
	private static List<T> ArrayToList<[Nullable(2)] T>(T[] source)
	{
		List<T> list = new List<T>(source.Length);
		for (int i = 0; i < source.Length; i++)
		{
			list.Add(source[i]);
		}
		return list;
	}

	// Token: 0x06014989 RID: 84361 RVA: 0x005B3F90 File Offset: 0x005B2190
	private bool CheckIsMaxLevel()
	{
		int arrivedLevel = this.CurrentExpData.GetArrivedLevel();
		int currentMaxLevel = this.RoleInstance.GetLevelData().GetCurrentMaxLevel();
		return arrivedLevel >= currentMaxLevel;
	}

	// Token: 0x0601498A RID: 84362 RVA: 0x005B3FC0 File Offset: 0x005B21C0
	private void LevelUpClick()
	{
		ISelectedData[] dataList = this.DataList;
		bool flag = false;
		ISelectedData[] array = dataList;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].SelectedCount > 0)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("WeaponSelectMaterialTipsText", Array.Empty<object>());
			return;
		}
		if (!this.RoleExpItemGridComponent.GetIsMoneyEnough())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("RoleNoMoney", Array.Empty<object>());
			return;
		}
		List<ArrayIntInt> itemList = new List<ArrayIntInt>();
		foreach (ISelectedData selectedData in dataList)
		{
			if (selectedData.SelectedCount > 0)
			{
				ArrayIntInt arrayIntInt = ArrayIntInt.Create();
				arrayIntInt.Key = selectedData.ItemId;
				arrayIntInt.Value = selectedData.SelectedCount;
				itemList.Add(arrayIntInt);
			}
		}
		int overExp = this.CurrentExpData.GetOverExp();
		if (overExp <= 0)
		{
			ControllerBase<RoleController>.Instance.SendPbUpLevelRoleRequest(this.RoleInstance.GetRoleId(), itemList.ToArray(), delegate
			{
				UiRoleUtils.PlayRoleLevelUpEffect(this.ViewModel.TsUiSceneRoleActor);
			});
			return;
		}
		Dictionary<int, int> dictionary = ModelBase<RoleModel>.Instance.CalculateExpBackItem(overExp);
		if (dictionary.Count > 0)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.WeaponOverflowExpTip);
			confirmBoxDataNew.ItemIdMap = dictionary;
			Action <>9__3;
			Action value = delegate()
			{
				RoleController instance = ControllerBase<RoleController>.Instance;
				int roleId = this.RoleInstance.GetRoleId();
				ArrayIntInt[] itemList = itemList.ToArray();
				Action successCallback;
				if ((successCallback = <>9__3) == null)
				{
					successCallback = (<>9__3 = delegate()
					{
						UiRoleUtils.PlayRoleLevelUpEffect(this.ViewModel.TsUiSceneRoleActor);
					});
				}
				instance.SendPbUpLevelRoleRequest(roleId, itemList, successCallback);
			};
			confirmBoxDataNew.FunctionMap.Add(2, value);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		ControllerBase<RoleController>.Instance.SendPbUpLevelRoleRequest(this.RoleInstance.GetRoleId(), itemList.ToArray(), delegate
		{
			UiRoleUtils.PlayRoleLevelUpEffect(this.ViewModel.TsUiSceneRoleActor);
		});
	}

	// Token: 0x0601498B RID: 84363 RVA: 0x005B4168 File Offset: 0x005B2368
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		RoleExpItemGridComponent roleExpItemGridComponent = this.RoleExpItemGridComponent;
		GenericLayout<RoleLevelUpCostMediumItemGrid, ISelectedData> genericLayout;
		if (roleExpItemGridComponent == null)
		{
			genericLayout = null;
		}
		else
		{
			GenericScrollViewNew<RoleLevelUpCostMediumItemGrid, ISelectedData> genericScrollView = roleExpItemGridComponent.GetGenericScrollView();
			genericLayout = ((genericScrollView != null) ? genericScrollView.GetGenericLayout() : null);
		}
		GenericLayout<RoleLevelUpCostMediumItemGrid, ISelectedData> genericLayout2 = genericLayout;
		if (genericLayout2 == null)
		{
			return null;
		}
		RoleLevelUpCostMediumItemGrid layoutItemByIndex = genericLayout2.GetLayoutItemByIndex(int.Parse(configParams[1]));
		if (layoutItemByIndex == null)
		{
			return null;
		}
		UUIItem uiItemForGuide = layoutItemByIndex.GetUiItemForGuide();
		if (uiItemForGuide == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			uiItemForGuide,
			uiItemForGuide
		};
	}

	// Token: 0x0601498C RID: 84364 RVA: 0x005B41C7 File Offset: 0x005B23C7
	protected void OnAttributeChangeSequenceFinished(AttributeItem attributeItem)
	{
		this.UpdateAttributeItemValue(attributeItem);
	}

	// Token: 0x0601498D RID: 84365 RVA: 0x005B41D0 File Offset: 0x005B23D0
	protected void UpdateAttributeItemValue(AttributeItem attributeItem)
	{
		int attributeId = attributeItem.GetAttributeId();
		int arrivedLevel = this.CurrentExpData.GetArrivedLevel();
		int currentLevel = this.CurrentExpData.GetCurrentLevel();
		int breachLevel = this.RoleInstance.GetLevelData().GetBreachLevel();
		int attributeByLevel = ModelBase<RoleModel>.Instance.GetAttributeByLevel(this.RoleInstance.GetRoleId(), (EAttributeType)attributeId, currentLevel, breachLevel);
		attributeItem.SetCurrentValue((float)attributeByLevel);
		bool flag = false;
		int num = 0;
		if (arrivedLevel > currentLevel)
		{
			int addAttrLevelUp = ModelBase<RoleModel>.Instance.GetAddAttrLevelUp(this.RoleInstance.GetRoleId(), currentLevel, breachLevel, arrivedLevel, breachLevel, attributeId);
			if (addAttrLevelUp > 0)
			{
				num = attributeByLevel + addAttrLevelUp;
				flag = true;
			}
		}
		else
		{
			flag = false;
		}
		attributeItem.SetNextItemActive(flag);
		if (flag)
		{
			attributeItem.SetNextValue((float)num);
		}
	}

	// Token: 0x0601498E RID: 84366 RVA: 0x005B4280 File Offset: 0x005B2480
	protected void UpdateButtonState()
	{
		bool roleIsMaxLevel = this.RoleInstance.GetLevelData().GetRoleIsMaxLevel();
		this.RoleExpItemGridComponent.SetMaxItemActive(roleIsMaxLevel);
		this.RoleExpItemGridComponent.SetButtonItemActive(!roleIsMaxLevel);
	}

	// Token: 0x04009F23 RID: 40739
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericLayout<AttributeItem, CSharpScript.Game.Module.Common.AttributeData> AttributeLayout;

	// Token: 0x04009F24 RID: 40740
	[Nullable(2)]
	protected RoleDataBase RoleInstance;

	// Token: 0x04009F25 RID: 40741
	[Nullable(2)]
	private RoleExpItemGridComponent RoleExpItemGridComponent;

	// Token: 0x04009F26 RID: 40742
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ISelectedData[] DataList;

	// Token: 0x04009F27 RID: 40743
	private readonly SelectableExpData CurrentExpData = new SelectableExpData();

	// Token: 0x04009F28 RID: 40744
	[Nullable(2)]
	private ExpComponent ExpComponent;

	// Token: 0x04009F29 RID: 40745
	[Nullable(2)]
	private TItem[] ReceiveItemList;

	// Token: 0x04009F2A RID: 40746
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04009F2B RID: 40747
	[Nullable(2)]
	private RoleViewViewModel ViewModel;

	// Token: 0x02008BE0 RID: 35808
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402F206 RID: 193030
		ExpItem,
		// Token: 0x0402F207 RID: 193031
		ConsumeItem,
		// Token: 0x0402F208 RID: 193032
		AttributeItem,
		// Token: 0x0402F209 RID: 193033
		MaskItem,
		// Token: 0x0402F20A RID: 193034
		CaptionItem
	}
}
