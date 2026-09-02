using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Module.Manufacture.Compose.QuicklyPopup;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020027B2 RID: 10162
[NullableContext(1)]
[Nullable(0)]
public class RoleBreachView : UiViewBase
{
	// Token: 0x06014128 RID: 82216 RVA: 0x0059A825 File Offset: 0x00598A25
	public RoleBreachView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06014129 RID: 82217 RVA: 0x0059A830 File Offset: 0x00598A30
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0601412A RID: 82218 RVA: 0x0059A984 File Offset: 0x00598B84
	protected override UniTask OnBeforeStartAsync()
	{
		RoleBreachView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleBreachView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601412B RID: 82219 RVA: 0x0059A9C8 File Offset: 0x00598BC8
	private void RefreshCostItemButton()
	{
		if (this.RoleBreachState.GetValueOrDefault() == ERoleBreachState.CanBreach)
		{
			this.CostItemGridComponent.SetButtonItemLocalText("RoleBreakup");
			this.CostItemGridComponent.SetButtonItemInteractive(true);
			return;
		}
		ERoleBreachState? roleBreachState = this.RoleBreachState;
		ERoleBreachState eroleBreachState = ERoleBreachState.NoEnoughMaterial;
		if ((roleBreachState.GetValueOrDefault() == eroleBreachState & roleBreachState != null) || this.RoleBreachState.GetValueOrDefault() == ERoleBreachState.NoEnoughMoney)
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
			this.CostItemGridComponent.SetButtonItemInteractive(flag);
		}
	}

	// Token: 0x0601412C RID: 82220 RVA: 0x0059AA6D File Offset: 0x00598C6D
	protected override void OnBeforeShow()
	{
		this.UpdateView();
	}

	// Token: 0x0601412D RID: 82221 RVA: 0x0059AA78 File Offset: 0x00598C78
	protected override UniTask OnPlayingStartSequenceAsync()
	{
		RoleBreachView.<OnPlayingStartSequenceAsync>d__14 <OnPlayingStartSequenceAsync>d__;
		<OnPlayingStartSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlayingStartSequenceAsync>d__.<>4__this = this;
		<OnPlayingStartSequenceAsync>d__.<>1__state = -1;
		<OnPlayingStartSequenceAsync>d__.<>t__builder.Start<RoleBreachView.<OnPlayingStartSequenceAsync>d__14>(ref <OnPlayingStartSequenceAsync>d__);
		return <OnPlayingStartSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601412E RID: 82222 RVA: 0x0059AABC File Offset: 0x00598CBC
	protected override UniTask OnPlayingCloseSequenceAsync()
	{
		RoleBreachView.<OnPlayingCloseSequenceAsync>d__15 <OnPlayingCloseSequenceAsync>d__;
		<OnPlayingCloseSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlayingCloseSequenceAsync>d__.<>4__this = this;
		<OnPlayingCloseSequenceAsync>d__.<>1__state = -1;
		<OnPlayingCloseSequenceAsync>d__.<>t__builder.Start<RoleBreachView.<OnPlayingCloseSequenceAsync>d__15>(ref <OnPlayingCloseSequenceAsync>d__);
		return <OnPlayingCloseSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601412F RID: 82223 RVA: 0x0059AAFF File Offset: 0x00598CFF
	protected override void OnHandleLoadScene()
	{
		this.ViewModel.HandleLoadScene(delegate
		{
			ControllerBase<RoleController>.Instance.PlayRoleMontage(EPerformanceRoleState.Attribute_Perform, false, true, false);
		});
	}

	// Token: 0x06014130 RID: 82224 RVA: 0x0059AB2B File Offset: 0x00598D2B
	protected override void OnHandleReleaseScene()
	{
		this.ViewModel.HandleReleaseScene();
	}

	// Token: 0x06014131 RID: 82225 RVA: 0x0059AB38 File Offset: 0x00598D38
	protected void CloseClick()
	{
		UiInteractLogReport.ReportSpaceKeyInteract(EUiInteractSpaceKeyType.RoleBreach);
		Singleton<UiManager>.Instance.CloseView(EUiViewName.RoleLevelUpView, null);
		base.CloseMe(null);
	}

	// Token: 0x06014132 RID: 82226 RVA: 0x0059AB58 File Offset: 0x00598D58
	protected void LevelUpClick(int _)
	{
		Action action = delegate()
		{
			RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId);
			ControllerBase<RoleController>.Instance.SendPbOverRoleRequest(roleInstanceById.GetRoleId());
		};
		ERoleBreachState? roleBreachState = this.RoleBreachState;
		ERoleBreachState eroleBreachState = ERoleBreachState.NoEnoughMaterial;
		if ((roleBreachState.GetValueOrDefault() == eroleBreachState & roleBreachState != null) || this.RoleBreachState.GetValueOrDefault() == ERoleBreachState.NoEnoughMoney)
		{
			List<ISelectedData> selectedDataList = this.GetSelectedDataList();
			IComposePopupViewData param = new ComposePopupViewData
			{
				SelectedItemList = selectedDataList,
				ClickConfirm = action,
				BelongView = new EUiViewName?(EUiViewName.RoleBreachView)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SynthesisTipsInfoView, param, delegate(bool isSuccess, int viewId)
			{
				if (isSuccess)
				{
					base.AddChildViewById(viewId);
				}
			});
			return;
		}
		action();
	}

	// Token: 0x06014133 RID: 82227 RVA: 0x0059ABED File Offset: 0x00598DED
	private List<ISelectedData> GetSelectedDataList()
	{
		return this.CachedConsumeList ?? new List<ISelectedData>();
	}

	// Token: 0x06014134 RID: 82228 RVA: 0x0059AC00 File Offset: 0x00598E00
	protected void LevelUpLockTipClick()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RoleBreakUpTip);
		int curQuestId = ModelBase<QuestNewModel>.Instance.GetCurWorldLevelBreakQuest();
		if (curQuestId < 0)
		{
			confirmBoxDataNew.InteractionMap[1] = false;
		}
		else
		{
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, curQuestId, null);
			};
			confirmBoxDataNew.InteractionMap[1] = true;
		}
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06014135 RID: 82229 RVA: 0x0059AC77 File Offset: 0x00598E77
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.RoleBreakUp, new Action<int, int>(this.RoleBreakUp));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
	}

	// Token: 0x06014136 RID: 82230 RVA: 0x0059ACB1 File Offset: 0x00598EB1
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RoleBreakUp, new Action<int, int>(this.RoleBreakUp));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
	}

	// Token: 0x06014137 RID: 82231 RVA: 0x0059ACEC File Offset: 0x00598EEC
	private void UpdateView()
	{
		RoleLevelData levelData = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId).GetLevelData();
		int breachLevel = levelData.GetBreachLevel();
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(4), "RoleBreakUpLevel", new <>z__ReadOnlySingleElementList<object>(breachLevel + 1));
		RoleBreach value = levelData.GetBreachConfig(breachLevel + 1).Value;
		base.GetText(0).SetText(value.MaxLevel.ToString(), true);
		int num = 0;
		List<ISelectedData> list = new List<ISelectedData>();
		Dictionary<int, int> dictionary = value.BreachConsume();
		if (dictionary != null)
		{
			foreach (KeyValuePair<int, int> keyValuePair in dictionary)
			{
				int key = keyValuePair.Key;
				int value2 = keyValuePair.Value;
				if (key == 2)
				{
					num = value2;
				}
				else
				{
					SelectedData item = new SelectedData
					{
						ItemId = key,
						IncId = 0,
						SelectedCount = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(key, 0),
						Count = value2
					};
					list.Add(item);
				}
			}
		}
		this.CachedConsumeList = new List<ISelectedData>();
		foreach (ISelectedData selectedData in list)
		{
			this.CachedConsumeList.Add(new SelectedData
			{
				ItemId = selectedData.ItemId,
				IncId = selectedData.IncId,
				Count = selectedData.Count,
				SelectedCount = selectedData.SelectedCount,
				OnlyTextFlag = selectedData.OnlyTextFlag
			});
		}
		if (num > 0)
		{
			this.CachedConsumeList.Add(new SelectedData
			{
				ItemId = 2,
				IncId = 0,
				Count = num,
				SelectedCount = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(2, 0)
			});
		}
		this.RoleBreachState = new ERoleBreachState?(ModelBase<RoleModel>.Instance.GetRoleBreachState(this.RoleId));
		if (this.RoleBreachState.GetValueOrDefault() == ERoleBreachState.NoEnoughCondition)
		{
			string conditionGroupHintText = LevelGeneralCommons.GetConditionGroupHintText(value.ConditionId);
			this.CostItemGridComponent.SetButtonItemActive(false);
			this.CostItemGridComponent.SetLockItemActive(true);
			this.CostItemGridComponent.SetLockLocalText(conditionGroupHintText, Array.Empty<object>());
		}
		else
		{
			this.CostItemGridComponent.SetButtonItemActive(true);
			this.CostItemGridComponent.SetLockItemActive(false);
		}
		this.CostItemGridComponent.Update(list, 2, num);
		this.UpdateStar(breachLevel, levelData.GetMaxBreachLevel());
		this.UpdateAttribute();
		this.RefreshCostItemButton();
	}

	// Token: 0x06014138 RID: 82232 RVA: 0x0059AF88 File Offset: 0x00599188
	private void UpdateAttribute()
	{
		IEnumerable<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("RoleAttributeDisplay3");
		RoleLevelData levelData = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId).GetLevelData();
		int level = levelData.GetLevel();
		int breachLevel = levelData.GetBreachLevel();
		int maxBreachLevel = levelData.GetMaxBreachLevel();
		List<CSharpScript.Game.Module.Common.AttributeData> list = new List<CSharpScript.Game.Module.Common.AttributeData>();
		foreach (int num in intArrayConfig)
		{
			float num2 = (float)ModelBase<RoleModel>.Instance.GetAttributeByLevel(this.RoleId, (EAttributeType)num, level, breachLevel);
			int num3 = 0;
			if (breachLevel < maxBreachLevel)
			{
				int addAttrLevelUp = ModelBase<RoleModel>.Instance.GetAddAttrLevelUp(this.RoleId, level, breachLevel, level, breachLevel + 1, num);
				if (addAttrLevelUp > 0)
				{
					num3 = (int)(num2 + (float)addAttrLevelUp);
				}
			}
			CSharpScript.Game.Module.Common.AttributeData item = new CSharpScript.Game.Module.Common.AttributeData
			{
				Id = num,
				IsRatio = false,
				CurValue = num2,
				BgActive = new bool?(false),
				ShowNext = new bool?((float)num3 > num2),
				NextValue = new float?((float)num3),
				UseAnotherName = new bool?(true)
			};
			list.Add(item);
		}
		this.AttributeLayout.RefreshByData(list, null, false);
	}

	// Token: 0x06014139 RID: 82233 RVA: 0x0059B0C0 File Offset: 0x005992C0
	private AttributeItem InitAttributeItem()
	{
		return new AttributeItem();
	}

	// Token: 0x0601413A RID: 82234 RVA: 0x0059B0C8 File Offset: 0x005992C8
	private void UpdateStar(int breachLevel, int maxLevel)
	{
		List<IStarItemData> list = new List<IStarItemData>(maxLevel);
		for (int i = 0; i < maxLevel; i++)
		{
			StarItemData item = new StarItemData
			{
				StarOnActive = (i < breachLevel),
				StarOffActive = (i > breachLevel),
				StarNextActive = (i == breachLevel),
				StarLoopActive = (i == breachLevel),
				PlayLoopSequence = (i == breachLevel),
				PlayActivateSequence = false
			};
			list.Add(item);
		}
		this.StarLayout.RefreshByData(list, null, false);
	}

	// Token: 0x0601413B RID: 82235 RVA: 0x0059B13C File Offset: 0x0059933C
	private CSharpScript.Game.Module.RoleUi.StarItem InitStarItem()
	{
		return new CSharpScript.Game.Module.RoleUi.StarItem();
	}

	// Token: 0x0601413C RID: 82236 RVA: 0x0059B144 File Offset: 0x00599344
	private void BreakUpSuccess()
	{
		RoleBreachSuccessViewData param = new RoleBreachSuccessViewData(this.RoleId, new Action(this.OnBreachSuccessViewMaskClick));
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleBreachSuccessView, param, null);
	}

	// Token: 0x0601413D RID: 82237 RVA: 0x0059B17C File Offset: 0x0059937C
	private void OnBreachSuccessViewMaskClick()
	{
		if (!ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId).GetLevelData().GetRoleIsMaxLevel())
		{
			RoleViewViewModel viewModel = new RoleViewViewModel(this.RoleId, false, ERoleViewSource.Normal)
			{
				FadeInCurveId = this.ViewModel.FadeInCurveId,
				NeedHideOnViewPlayingCloseSequence = this.ViewModel.NeedHideOnViewPlayingCloseSequence
			};
			this.ViewModel.NeedHideOnViewPlayingCloseSequence = false;
			base.CloseMe(null);
			ControllerBase<RoleController>.Instance.CloseAndOpenRoleViewByViewModel(EUiViewName.RoleBreachSuccessView, EUiViewName.RoleLevelUpView, viewModel);
			return;
		}
		base.CloseMe(null);
		Singleton<UiManager>.Instance.CloseView(EUiViewName.RoleBreachSuccessView, null);
	}

	// Token: 0x0601413E RID: 82238 RVA: 0x0059B218 File Offset: 0x00599418
	private void RoleBreakUp(int roleId, int level)
	{
		base.GetItem(3).SetUIActive(false);
		this.CostItemGridComponent.GetRootItem().SetUIActive(false);
		this.CaptionItem.GetRootItem().SetUIActive(false);
		UiRoleUtils.PlayRoleBreachFinishEffect(this.ViewModel.TsUiSceneRoleActor);
		int? roleBreachSuccessDelayTime = ConfigBase<RoleConfig>.Instance.GetRoleBreachSuccessDelayTime();
		TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			ControllerBase<RoleController>.Instance.PlayRoleMontage(EPerformanceRoleState.Attribute_Perform, false, false, false);
			this.BreakUpSuccess();
		}, (float)roleBreachSuccessDelayTime.Value, null, null, true, 1f);
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
		int? num = (roleDataById != null) ? new int?(roleDataById.GetRoleSkinId()) : null;
		if (num == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Audio;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "[Game.RoleBreachView] 没有皮肤ID";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", roleId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		RoleSkinAudio? roleConfig = ConfigBase<AudioConfig>.Instance.GetRoleConfig(num.Value);
		if (roleConfig != null && level < roleConfig.Value.BreakUpEventListLength)
		{
			string text = roleConfig.Value.BreakUpEventList(level);
			if (!string.IsNullOrEmpty(text))
			{
				Singleton<AudioSystem>.Instance.PostEvent(text);
			}
		}
	}

	// Token: 0x0601413F RID: 82239 RVA: 0x0059B34A File Offset: 0x0059954A
	private void OnCommonItemCountAnyChange(int i, int i1)
	{
		this.UpdateView();
	}

	// Token: 0x04009C58 RID: 40024
	private int RoleId;

	// Token: 0x04009C59 RID: 40025
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericLayout<AttributeItem, CSharpScript.Game.Module.Common.AttributeData> AttributeLayout;

	// Token: 0x04009C5A RID: 40026
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericLayout<CSharpScript.Game.Module.RoleUi.StarItem, IStarItemData> StarLayout;

	// Token: 0x04009C5B RID: 40027
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04009C5C RID: 40028
	[Nullable(2)]
	private CostItemGridComponent CostItemGridComponent;

	// Token: 0x04009C5D RID: 40029
	private ERoleBreachState? RoleBreachState;

	// Token: 0x04009C5E RID: 40030
	[Nullable(2)]
	private RoleViewViewModel ViewModel;

	// Token: 0x04009C5F RID: 40031
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<ISelectedData> CachedConsumeList;

	// Token: 0x02008B72 RID: 35698
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x0402F029 RID: 192553
		NewLevelLimitText,
		// Token: 0x0402F02A RID: 192554
		SkillRewardPanel,
		// Token: 0x0402F02B RID: 192555
		NewSkillIconTexture,
		// Token: 0x0402F02C RID: 192556
		BreachPanel,
		// Token: 0x0402F02D RID: 192557
		DescText,
		// Token: 0x0402F02E RID: 192558
		StarHorizontalLayout,
		// Token: 0x0402F02F RID: 192559
		AttributeLayout,
		// Token: 0x0402F030 RID: 192560
		CaptionItem,
		// Token: 0x0402F031 RID: 192561
		ConsumeItem
	}
}
