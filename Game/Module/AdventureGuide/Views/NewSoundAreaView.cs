using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon.ExchangeReward;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.RoleUi.RoleDevelop.View;
using CSharpScript.Game.Module.UiNavigation;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.AdventureGuide.Views
{
	// Token: 0x020061A9 RID: 25001
	[NullableContext(1)]
	[Nullable(0)]
	public class NewSoundAreaView : UiTabViewBase
	{
		// Token: 0x0603F1F1 RID: 258545 RVA: 0x0102F768 File Offset: 0x0102D968
		protected unsafe override void OnRegisterComponent()
		{
			int num = 33;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIMultiTemplateScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIMultiTemplateScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(27, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(28, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(29, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(30, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(31, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(32, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(13, new Action(this.OnClickLordGymBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603F1F2 RID: 258546 RVA: 0x0102FC27 File Offset: 0x0102DE27
		protected override void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RedDotAdventureSecondaryUpdate, new Action<int>(this.OnRedDotAdventureSecondaryUpdate));
		}

		// Token: 0x0603F1F3 RID: 258547 RVA: 0x0102FC45 File Offset: 0x0102DE45
		protected override void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RedDotAdventureSecondaryUpdate, new Action<int>(this.OnRedDotAdventureSecondaryUpdate));
		}

		// Token: 0x0603F1F4 RID: 258548 RVA: 0x0102FC64 File Offset: 0x0102DE64
		private void OnRedDotAdventureSecondaryUpdate(int secondary)
		{
			if (this.TypeList == null)
			{
				return;
			}
			for (int i = 0; i < this.TypeList.Count; i++)
			{
				if (this.TypeList[i] == secondary)
				{
					MultiTemplateScrollView typeScroll = this.TypeScroll;
					NewSoundTypeItem newSoundTypeItem = ((typeScroll != null) ? typeScroll.GetProxyByGridIndex(i) : null) as NewSoundTypeItem;
					if (newSoundTypeItem != null)
					{
						newSoundTypeItem.RefreshRedDotState();
					}
				}
			}
		}

		// Token: 0x0603F1F5 RID: 258549 RVA: 0x0102FCC2 File Offset: 0x0102DEC2
		private void OnRoleDevTargetRoleIdChange()
		{
			if (this.HasRoleDevTab)
			{
				MultiTemplateScrollView typeScroll = this.TypeScroll;
				if (typeScroll != null)
				{
					typeScroll.RefreshProxyDirectly(0);
				}
			}
			RoleDevelopOverviewPanel roleDevelopPanel = this.RoleDevelopPanel;
			if (roleDevelopPanel != null)
			{
				roleDevelopPanel.RefreshView(true);
			}
			if (this.CurrentType != (EDungeonType)(-1))
			{
				this.BuildDungeonList();
			}
		}

		// Token: 0x0603F1F6 RID: 258550 RVA: 0x0102FD00 File Offset: 0x0102DF00
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer startLevelSequencePlayer = this.StartLevelSequencePlayer;
			if (startLevelSequencePlayer != null)
			{
				startLevelSequencePlayer.Clear();
			}
			this.StartLevelSequencePlayer = null;
			LevelSequencePlayer switchLevelSequencePlayer = this.SwitchLevelSequencePlayer;
			if (switchLevelSequencePlayer != null)
			{
				switchLevelSequencePlayer.Clear();
			}
			this.SwitchLevelSequencePlayer = null;
			CommonDropDown<int, int> suitDropDown = this.SuitDropDown;
			if (suitDropDown != null)
			{
				suitDropDown.Destroy(null);
			}
			CommonDropDown<int, int> weaponDropDown = this.WeaponDropDown;
			if (weaponDropDown != null)
			{
				weaponDropDown.Destroy(null);
			}
			CommonDropDown<TableTextArgNew, int> levelDropDown = this.LevelDropDown;
			if (levelDropDown != null)
			{
				levelDropDown.Destroy(null);
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.RoleDevTargetRoleIdChange, new Action(this.OnRoleDevTargetRoleIdChange));
		}

		// Token: 0x0603F1F7 RID: 258551 RVA: 0x0102FD8F File Offset: 0x0102DF8F
		private OneTextTitleItem CreateLevelTitleItem(UUIItem uiItem)
		{
			return new OneTextTitleItem(uiItem);
		}

		// Token: 0x0603F1F8 RID: 258552 RVA: 0x0102FD97 File Offset: 0x0102DF97
		private OneTextDropDownItem CreateLevelDropDownItem(UUIItem uiItem, int data)
		{
			return new OneTextDropDownItem(uiItem);
		}

		// Token: 0x0603F1F9 RID: 258553 RVA: 0x0102FD9F File Offset: 0x0102DF9F
		private NewSoundSuitDropDownTitle CreateSuitTitleItem(UUIItem uiItem)
		{
			return new NewSoundSuitDropDownTitle(uiItem);
		}

		// Token: 0x0603F1FA RID: 258554 RVA: 0x0102FDA7 File Offset: 0x0102DFA7
		private NewSoundSuitDropDownItem CreateSuitDropDownItem(UUIItem uiItem, int data)
		{
			return new NewSoundSuitDropDownItem(uiItem);
		}

		// Token: 0x0603F1FB RID: 258555 RVA: 0x0102FDAF File Offset: 0x0102DFAF
		private WeaponTitleItem CreateWeaponTitleItem(UUIItem uiItem)
		{
			return new WeaponTitleItem(uiItem);
		}

		// Token: 0x0603F1FC RID: 258556 RVA: 0x0102FDB7 File Offset: 0x0102DFB7
		private NewSoundWeaponDropDownItem CreateWeaponDropDownItem(UUIItem uiItem, int data)
		{
			return new NewSoundWeaponDropDownItem(uiItem);
		}

		// Token: 0x0603F1FD RID: 258557 RVA: 0x0102FDC0 File Offset: 0x0102DFC0
		protected override UniTask OnBeforeStartAsync()
		{
			NewSoundAreaView.<OnBeforeStartAsync>d__40 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<NewSoundAreaView.<OnBeforeStartAsync>d__40>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F1FE RID: 258558 RVA: 0x0102FE04 File Offset: 0x0102E004
		protected override void OnStart()
		{
			Action<int, UUIExtendToggle> typeToggleFunc = delegate(int currentType, UUIExtendToggle toggle)
			{
				if (this.CurrentType == EDungeonType.Tutorial || this.CurrentType == EDungeonType.SkillTeach)
				{
					foreach (SoundAreaDetectionRecord soundAreaDetectionRecord in ModelBase<AdventureGuideModel>.Instance.GetCanShowDungeonRecordsByType(this.CurrentType, null, true).Item2)
					{
						ModelBase<AdventureGuideModel>.Instance.SetRoleTutorialNew(soundAreaDetectionRecord.Id);
					}
				}
				this.CurrentType = (EDungeonType)currentType;
				this.HasUserSelectedType = true;
				if (currentType == -1)
				{
					RegressPanel regressPanel = this.RegressPanel;
					if (regressPanel != null)
					{
						regressPanel.SetUiActive(false);
					}
					this.CurrentDropDownType = EDetectionDropDownType.None;
					this.RefreshCommonDropDown();
					UUIExtendToggle currentSelectedToggle = this.CurrentSelectedToggle;
					if (currentSelectedToggle != null)
					{
						currentSelectedToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
					}
					this.CurrentSelectedToggle = toggle;
					this.RefreshDungeonType();
					UUIItem item = base.GetItem(26);
					if (item != null)
					{
						item.SetUIActive(false);
					}
					UUIItem item2 = base.GetItem(31);
					if (item2 != null)
					{
						item2.SetUIActive(true);
					}
					RoleDevelopOverviewPanel roleDevelopPanel = this.RoleDevelopPanel;
					if (roleDevelopPanel != null)
					{
						roleDevelopPanel.RefreshView(false);
					}
					UUIItem item3 = base.GetItem(16);
					if (item3 != null)
					{
						item3.SetUIActive(false);
					}
					LevelSequencePlayer switchLevelSequencePlayer = this.SwitchLevelSequencePlayer;
					if (((switchLevelSequencePlayer != null) ? switchLevelSequencePlayer.GetCurrentSequence() : null) == null)
					{
						LevelSequencePlayer switchLevelSequencePlayer2 = this.SwitchLevelSequencePlayer;
						if (switchLevelSequencePlayer2 == null)
						{
							return;
						}
						switchLevelSequencePlayer2.PlayLevelSequenceByName("Switch", false, null, false);
						return;
					}
					else
					{
						LevelSequencePlayer switchLevelSequencePlayer3 = this.SwitchLevelSequencePlayer;
						if (switchLevelSequencePlayer3 == null)
						{
							return;
						}
						switchLevelSequencePlayer3.ReplaySequenceByKey("Switch");
						return;
					}
				}
				else
				{
					UUIItem item4 = base.GetItem(31);
					if (item4 != null)
					{
						item4.SetUIActive(false);
					}
					List<EAdventurePreOpenPlayType> playerType = ControllerBase<AdventureGuideController>.Instance.GetPlayerType();
					RegressPanel regressPanel2 = this.RegressPanel;
					if (regressPanel2 != null)
					{
						regressPanel2.SetUiActive((playerType.Contains(EAdventurePreOpenPlayType.Regress) || playerType.Contains(EAdventurePreOpenPlayType.Beginner)) && this.CurrentType == EDungeonType.NoSoundArea);
					}
					SecondaryGuideData value = ConfigBase<AdventureGuideConfig>.Instance.GetSecondaryGuideDataConf(currentType).Value;
					this.CurrentDropDownType = (EDetectionDropDownType)value.DropDownTypeId;
					this.RefreshCommonDropDown();
					UUIExtendToggle currentSelectedToggle2 = this.CurrentSelectedToggle;
					if (currentSelectedToggle2 != null)
					{
						currentSelectedToggle2.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
					}
					this.CurrentSelectedToggle = toggle;
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.AdventureHelpBtn, value.HelpGroupId);
					this.HelpId = value.HelpGroupId;
					this.RefreshDungeonType();
					if (this.CurrentDropDownType != EDetectionDropDownType.Suit && this.CurrentDropDownType != EDetectionDropDownType.Weapon)
					{
						this.BuildDungeonList();
					}
					if (this.CurrentDropDownType == EDetectionDropDownType.Level)
					{
						this.LevelDropDownCall(ModelBase<AdventureGuideModel>.Instance.CurrentShowLevel);
					}
					else if (this.CurrentDropDownType == EDetectionDropDownType.Suit)
					{
						if (ModelBase<AdventureGuideModel>.Instance.HandleShowNightMareParam != 0)
						{
							ModelBase<AdventureGuideModel>.Instance.CurrentSelectSuitIndex = 0;
							CommonDropDown<int, int> suitDropDown = this.SuitDropDown;
							if (suitDropDown != null)
							{
								suitDropDown.SetSelectedIndex(0, true);
							}
						}
						this.SuitDropDownCall(ModelBase<AdventureGuideModel>.Instance.CurrentSelectSuitIndex);
					}
					else if (this.CurrentDropDownType == EDetectionDropDownType.Weapon)
					{
						this.WeaponDropDownCall(this.CurrentSelectWeaponIndex);
					}
					LevelSequencePlayer switchLevelSequencePlayer4 = this.SwitchLevelSequencePlayer;
					if (((switchLevelSequencePlayer4 != null) ? switchLevelSequencePlayer4.GetCurrentSequence() : null) == null)
					{
						LevelSequencePlayer switchLevelSequencePlayer5 = this.SwitchLevelSequencePlayer;
						if (switchLevelSequencePlayer5 != null)
						{
							switchLevelSequencePlayer5.PlayLevelSequenceByName("Switch", false, null, false);
						}
					}
					else
					{
						LevelSequencePlayer switchLevelSequencePlayer6 = this.SwitchLevelSequencePlayer;
						if (switchLevelSequencePlayer6 != null)
						{
							switchLevelSequencePlayer6.ReplaySequenceByKey("Switch");
						}
					}
					ActivityDoubleRewardData adventureUpActivity = ControllerBase<ActivityDoubleRewardController>.Instance.GetAdventureUpActivity(this.CurrentType);
					if (adventureUpActivity != null)
					{
						base.GetItem(16).SetUIActive(true);
						ValueTuple<string, int, int> numTxtAndParam = adventureUpActivity.GetNumTxtAndParam();
						Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(23), (numTxtAndParam.Item2 > 0) ? "Reward_doubling_tips" : "Reward_doubling_end_tips", new <>z__ReadOnlyArray<object>(new object[]
						{
							numTxtAndParam.Item2,
							numTxtAndParam.Item3
						}));
						base.GetText(17).SetUIActive(false);
						return;
					}
					ValueTuple<bool, int, int, string, string> detectionDoubleDropTuple = ModelBase<ActivityRegressModel>.Instance.GetDetectionDoubleDropTuple(this.CurrentType);
					bool item5 = detectionDoubleDropTuple.Item1;
					int item6 = detectionDoubleDropTuple.Item2;
					int item7 = detectionDoubleDropTuple.Item3;
					string item8 = detectionDoubleDropTuple.Item4;
					string item9 = detectionDoubleDropTuple.Item5;
					if (item5)
					{
						Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(17), item8, new <>z__ReadOnlyArray<object>(new object[]
						{
							item6,
							item7
						}));
						Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(23), item9, Array.Empty<object>());
						base.GetText(17).SetUIActive(true);
					}
					base.GetItem(16).SetUIActive(item5);
					return;
				}
			};
			Func<int, bool> typeCanToggleChange = (int currentType) => this.CurrentType != (EDungeonType)currentType;
			this.TypeToggleFunc = typeToggleFunc;
			this.TypeCanToggleChange = typeCanToggleChange;
			this.TypeScroll = new MultiTemplateScrollView(base.GetMultiTemplateScrollViewComponent(1));
			this.SoundAreaScroll = new MultiTemplateScrollView(base.GetMultiTemplateScrollViewComponent(24));
			foreach (PhantomFetterGroup phantomFetterGroup in ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupArray())
			{
				this.FetterSuitFilterArray.Add(phantomFetterGroup.Id);
			}
			this.FetterSuitFilterArray.Sort((int a, int b) => a - b);
			this.FetterSuitFilterArray.Insert(0, 0);
			this.SuitDropDown.SetOnSelectCall(new Action<int, int>(this.OnSuitDropDownSelectCall));
			this.SuitDropDown.SetShowType(ECommonDropDownShowType.Down);
			this.SuitDropDown.InitScroll(this.FetterSuitFilterArray, new Func<int, int>(this.GetSuitDropDownTextId), this.FetterSuitFilterArray.IndexOf(ModelBase<AdventureGuideModel>.Instance.CurrentSelectSuitIndex), false);
			IReadOnlyList<Mapping> weaponConfList = ConfigBase<MappingConfig>.Instance.GetWeaponConfList();
			if (weaponConfList != null)
			{
				foreach (Mapping mapping in weaponConfList)
				{
					this.WeaponFilterArray.Add(mapping.Value);
				}
			}
			this.WeaponFilterArray.Sort((int a, int b) => a - b);
			this.WeaponFilterArray.Insert(0, 0);
			this.WeaponDropDown.SetOnSelectCall(new Action<int, int>(this.OnWeaponDropDownSelectCall));
			this.WeaponDropDown.SetShowType(ECommonDropDownShowType.Down);
			this.WeaponDropDown.InitScroll(this.WeaponFilterArray, new Func<int, int>(this.GetWeaponDropDownTextId), 0, false);
			this.DefaultDropDownSelectIndex = ModelBase<WorldLevelModel>.Instance.CurWorldLevel - 1;
			List<int> list = new List<int>();
			for (int i = 1; i <= 8; i++)
			{
				list.Add(i);
			}
			this.LevelDropDown.SetOnSelectCall(new Action<int, int>(this.OnLevelDropDownSelectCall));
			this.LevelDropDown.SetShowType(ECommonDropDownShowType.Down);
			this.LevelDropDown.InitScroll(list, new Func<int, TableTextArgNew>(this.GetLevelDropDownTextId), this.DefaultDropDownSelectIndex, false);
			ModelBase<AdventureGuideModel>.Instance.CurrentShowLevel = ModelBase<WorldLevelModel>.Instance.CurWorldLevel;
			this.TypeList = ModelBase<AdventureGuideModel>.Instance.GetAllCanShowDungeonTypeList(null, true);
			this.StartLevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.SwitchLevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.InitNavigationParam();
			Singleton<EventSystem>.Instance.Add(EEventName.RoleDevTargetRoleIdChange, new Action(this.OnRoleDevTargetRoleIdChange));
		}

		// Token: 0x0603F1FF RID: 258559 RVA: 0x010300F4 File Offset: 0x0102E2F4
		private void InitNavigationParam()
		{
			AdventureGuideViewOpenData adventureGuideViewOpenData = this.ExtraParams as AdventureGuideViewOpenData;
			int? num = (((adventureGuideViewOpenData != null) ? adventureGuideViewOpenData.OpenTabViewName : null) == EUiTabViewName.NewSoundAreaView) ? adventureGuideViewOpenData.OpenParam : new int?(0);
			int num2 = 0;
			if (num.GetValueOrDefault() > num2 & num != null)
			{
				this.IsNavigationJumpToGrid = true;
			}
		}

		// Token: 0x0603F200 RID: 258560 RVA: 0x01030174 File Offset: 0x0102E374
		private void NavigationJumpToGrid()
		{
			if (!this.IsNavigationJumpToGrid)
			{
				return;
			}
			this.IsNavigationJumpToGrid = false;
			MultiTemplateScrollView soundAreaScroll = this.SoundAreaScroll;
			NewSoundDetectTabItemDungeonItem newSoundDetectTabItemDungeonItem = ((soundAreaScroll != null) ? soundAreaScroll.GetProxyByGridIndex(0) : null) as NewSoundDetectTabItemDungeonItem;
			if (newSoundDetectTabItemDungeonItem == null)
			{
				return;
			}
			ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForViewByRootItem(newSoundDetectTabItemDungeonItem.GetRootItem(), ENavigationGroupName.NewSoundDetectItemGroup, true);
		}

		// Token: 0x0603F201 RID: 258561 RVA: 0x010301CC File Offset: 0x0102E3CC
		private void LevelDropDownCall(int index)
		{
			ModelBase<AdventureGuideModel>.Instance.CurrentShowLevel = index;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.NewSoundAreaRefreshReward, index);
			LevelSequencePlayer switchLevelSequencePlayer = this.SwitchLevelSequencePlayer;
			if (((switchLevelSequencePlayer != null) ? switchLevelSequencePlayer.GetCurrentSequence() : null) == null)
			{
				LevelSequencePlayer switchLevelSequencePlayer2 = this.SwitchLevelSequencePlayer;
				if (switchLevelSequencePlayer2 == null)
				{
					return;
				}
				switchLevelSequencePlayer2.PlayLevelSequenceByName("Switch", false, null, false);
				return;
			}
			else
			{
				LevelSequencePlayer switchLevelSequencePlayer3 = this.SwitchLevelSequencePlayer;
				if (switchLevelSequencePlayer3 == null)
				{
					return;
				}
				switchLevelSequencePlayer3.ReplaySequenceByKey("Switch");
				return;
			}
		}

		// Token: 0x0603F202 RID: 258562 RVA: 0x01030240 File Offset: 0x0102E440
		private void SuitDropDownCall(int index)
		{
			ModelBase<AdventureGuideModel>.Instance.CurrentSelectSuitIndex = index;
			this.BuildListBySuitData();
			LevelSequencePlayer switchLevelSequencePlayer = this.SwitchLevelSequencePlayer;
			if (((switchLevelSequencePlayer != null) ? switchLevelSequencePlayer.GetCurrentSequence() : null) == null)
			{
				LevelSequencePlayer switchLevelSequencePlayer2 = this.SwitchLevelSequencePlayer;
				if (switchLevelSequencePlayer2 == null)
				{
					return;
				}
				switchLevelSequencePlayer2.PlayLevelSequenceByName("Switch", false, null, false);
				return;
			}
			else
			{
				LevelSequencePlayer switchLevelSequencePlayer3 = this.SwitchLevelSequencePlayer;
				if (switchLevelSequencePlayer3 == null)
				{
					return;
				}
				switchLevelSequencePlayer3.ReplaySequenceByKey("Switch");
				return;
			}
		}

		// Token: 0x0603F203 RID: 258563 RVA: 0x010302A8 File Offset: 0x0102E4A8
		private void OnLevelDropDownSelectCall(int index, int data)
		{
			this.LevelDropDownCall(data);
		}

		// Token: 0x0603F204 RID: 258564 RVA: 0x010302B1 File Offset: 0x0102E4B1
		private void OnSuitDropDownSelectCall(int index, int data)
		{
			this.SuitDropDownCall(data);
		}

		// Token: 0x0603F205 RID: 258565 RVA: 0x010302BA File Offset: 0x0102E4BA
		private TableTextArgNew GetLevelDropDownTextId(int data)
		{
			return new TableTextArgNew((data == ModelBase<WorldLevelModel>.Instance.CurWorldLevel) ? "Text_WorldCurrentLevelTag_Text" : "Text_WorldLevelTag_Text", new <>z__ReadOnlySingleElementList<object>(data));
		}

		// Token: 0x0603F206 RID: 258566 RVA: 0x010302E5 File Offset: 0x0102E4E5
		private int GetSuitDropDownTextId(int data)
		{
			return data;
		}

		// Token: 0x0603F207 RID: 258567 RVA: 0x010302E8 File Offset: 0x0102E4E8
		private void WeaponDropDownCall(int weaponId)
		{
			this.CurrentSelectWeaponIndex = weaponId;
			this.BuildListByWeaponData();
			LevelSequencePlayer switchLevelSequencePlayer = this.SwitchLevelSequencePlayer;
			if (((switchLevelSequencePlayer != null) ? switchLevelSequencePlayer.GetCurrentSequence() : null) == null)
			{
				LevelSequencePlayer switchLevelSequencePlayer2 = this.SwitchLevelSequencePlayer;
				if (switchLevelSequencePlayer2 == null)
				{
					return;
				}
				switchLevelSequencePlayer2.PlayLevelSequenceByName("Switch", false, null, false);
				return;
			}
			else
			{
				LevelSequencePlayer switchLevelSequencePlayer3 = this.SwitchLevelSequencePlayer;
				if (switchLevelSequencePlayer3 == null)
				{
					return;
				}
				switchLevelSequencePlayer3.ReplaySequenceByKey("Switch");
				return;
			}
		}

		// Token: 0x0603F208 RID: 258568 RVA: 0x0103034C File Offset: 0x0102E54C
		private void OnWeaponDropDownSelectCall(int index, int data)
		{
			this.WeaponDropDownCall(data);
		}

		// Token: 0x0603F209 RID: 258569 RVA: 0x01030355 File Offset: 0x0102E555
		private int GetWeaponDropDownTextId(int data)
		{
			return data;
		}

		// Token: 0x0603F20A RID: 258570 RVA: 0x01030358 File Offset: 0x0102E558
		private void BuildDungeonList()
		{
			ValueTuple<bool, List<SoundAreaDetectionRecord>> canShowDungeonRecordsByType = ModelBase<AdventureGuideModel>.Instance.GetCanShowDungeonRecordsByType(this.CurrentType, null, true);
			bool item = canShowDungeonRecordsByType.Item1;
			List<SoundAreaDetectionRecord> item2 = canShowDungeonRecordsByType.Item2;
			if (!item)
			{
				this.BuildDungeonNormalList(item2.ToList<SoundAreaDetectionRecord>());
			}
			else
			{
				this.BuildDungeonTabList(item2.ToList<SoundAreaDetectionRecord>());
			}
			this.CurrentData = null;
		}

		// Token: 0x0603F20B RID: 258571 RVA: 0x010303B0 File Offset: 0x0102E5B0
		private void BuildDungeonNormalList(List<SoundAreaDetectionRecord> records)
		{
			NewSoundAreaView.<>c__DisplayClass54_0 CS$<>8__locals1 = new NewSoundAreaView.<>c__DisplayClass54_0();
			int count = records.Count;
			base.GetItem(26).SetUIActive(true);
			if (count != 0)
			{
				NewSoundAreaView.<>c__DisplayClass54_0 CS$<>8__locals2 = CS$<>8__locals1;
				AdventureGuideViewOpenData currentData = this.CurrentData;
				CS$<>8__locals2.currentTracingId = ((currentData != null) ? currentData.NewSoundDetectTracingIdList : null);
				List<SoundAreaDetectionRecord> list = records.OrderByDescending(delegate(SoundAreaDetectionRecord r)
				{
					int[] currentTracingId2 = CS$<>8__locals1.currentTracingId;
					return currentTracingId2 != null && currentTracingId2.Contains(r.Id);
				}).ToList<SoundAreaDetectionRecord>();
				List<IMultiTemplateGridData> list2 = new List<IMultiTemplateGridData>();
				int cycleId = ModelBase<WeeklyRogueModel>.Instance.CycleId;
				for (int i = 0; i < count; i++)
				{
					SoundAreaDetectionRecord soundAreaDetectionRecord = list[i];
					if (soundAreaDetectionRecord == null || soundAreaDetectionRecord.Secondary != 29 || cycleId != 0)
					{
						NewSoundDetectItemData newSoundDetectItemData = new NewSoundDetectItemData();
						newSoundDetectItemData.DetectRecordData = list[i];
						NewSoundDetectItemData newSoundDetectItemData2 = newSoundDetectItemData;
						int[] currentTracingId = CS$<>8__locals1.currentTracingId;
						newSoundDetectItemData2.TracingList = ((currentTracingId != null) ? currentTracingId.ToList<int>() : null);
						list2.Add(new NewSoundDetectTabItemDungeonData(new NewSoundDetectTabItemData
						{
							Dungeon = newSoundDetectItemData
						}));
					}
				}
				MultiTemplateScrollViewRefreshContext multiTemplateScrollViewRefreshContext = new MultiTemplateScrollViewRefreshContext(list2);
				multiTemplateScrollViewRefreshContext.ScrollToGridIndex = 0;
				MultiTemplateScrollView soundAreaScroll = this.SoundAreaScroll;
				if (soundAreaScroll != null)
				{
					soundAreaScroll.RefreshByData(multiTemplateScrollViewRefreshContext);
				}
				this.NavigationJumpToGrid();
				return;
			}
			MultiTemplateScrollViewRefreshContext context = new MultiTemplateScrollViewRefreshContext(new List<IMultiTemplateGridData>());
			MultiTemplateScrollView soundAreaScroll2 = this.SoundAreaScroll;
			if (soundAreaScroll2 == null)
			{
				return;
			}
			soundAreaScroll2.RefreshByData(context);
		}

		// Token: 0x0603F20C RID: 258572 RVA: 0x010304E0 File Offset: 0x0102E6E0
		private void BuildDungeonTabList(List<SoundAreaDetectionRecord> records)
		{
			NewSoundAreaView.<>c__DisplayClass55_0 CS$<>8__locals1 = new NewSoundAreaView.<>c__DisplayClass55_0();
			base.GetItem(26).SetUIActive(true);
			Dictionary<int, IMultiTemplateGridData> dictionary = new Dictionary<int, IMultiTemplateGridData>();
			List<IMultiTemplateGridData> list = new List<IMultiTemplateGridData>();
			NewSoundAreaView.<>c__DisplayClass55_0 CS$<>8__locals2 = CS$<>8__locals1;
			AdventureGuideViewOpenData currentData = this.CurrentData;
			CS$<>8__locals2.currentTracingId = ((currentData != null) ? currentData.NewSoundDetectTracingIdList : null);
			int handleShowNightMareParam = ModelBase<AdventureGuideModel>.Instance.HandleShowNightMareParam;
			ModelBase<AdventureGuideModel>.Instance.HandleShowNightMareParam = 0;
			List<SoundAreaDetectionRecord> list2 = records.OrderByDescending(delegate(SoundAreaDetectionRecord r)
			{
				int[] currentTracingId3 = CS$<>8__locals1.currentTracingId;
				return currentTracingId3 != null && currentTracingId3.Contains(r.Id);
			}).ToList<SoundAreaDetectionRecord>();
			List<SoundAreaDetectionRecord> list3 = new List<SoundAreaDetectionRecord>();
			List<SoundAreaDetectionRecord> list4 = new List<SoundAreaDetectionRecord>();
			foreach (SoundAreaDetectionRecord soundAreaDetectionRecord in list2)
			{
				if (ModelBase<AdventureGuideModel>.Instance.GetIsDetectionPreOpenByData(soundAreaDetectionRecord))
				{
					list3.Add(soundAreaDetectionRecord);
				}
				else
				{
					list4.Add(soundAreaDetectionRecord);
				}
			}
			if (list3.Count > 0)
			{
				NewSoundDetectPreOpenTitleData newSoundDetectPreOpenTitleData = new NewSoundDetectPreOpenTitleData(new NewSoundDetectTabItemData
				{
					Area = -1,
					TabTextId = "AdventurePreOpenTab",
					IconPath = "",
					Sort = 9999,
					IsVisible = true
				});
				newSoundDetectPreOpenTitleData.OnClickCallBack = new Action<int, bool>(this.OnClickNewSoundDetectTabItemTitleItemCallBack);
				dictionary[-1] = newSoundDetectPreOpenTitleData;
				list.Add(newSoundDetectPreOpenTitleData);
				foreach (SoundAreaDetectionRecord soundAreaDetectionRecord2 in list3)
				{
					NewSoundDetectItemData newSoundDetectItemData = new NewSoundDetectItemData();
					newSoundDetectItemData.DetectRecordData = soundAreaDetectionRecord2;
					NewSoundDetectItemData newSoundDetectItemData2 = newSoundDetectItemData;
					int[] currentTracingId = CS$<>8__locals1.currentTracingId;
					newSoundDetectItemData2.TracingList = ((currentTracingId != null) ? currentTracingId.ToList<int>() : null);
					newSoundDetectItemData.NightMareParam = new int?(handleShowNightMareParam);
					NewSoundDetectTabItemData newSoundDetectTabItemData = new NewSoundDetectTabItemData();
					newSoundDetectTabItemData.Area = -1;
					newSoundDetectTabItemData.Dungeon = newSoundDetectItemData;
					newSoundDetectTabItemData.Sort = 9999;
					newSoundDetectTabItemData.IsVisible = true;
					dictionary[soundAreaDetectionRecord2.Id] = new NewSoundDetectTabItemDungeonData(newSoundDetectTabItemData);
					list.Add(dictionary[soundAreaDetectionRecord2.Id]);
				}
			}
			foreach (SoundAreaDetectionRecord soundAreaDetectionRecord3 in list4)
			{
				int num;
				if (soundAreaDetectionRecord3.DungeonDetectionRecord == null)
				{
					SilentAreaDetectionRecord silentAreaDetectionRecord = soundAreaDetectionRecord3.SilentAreaDetectionRecord;
					num = ((silentAreaDetectionRecord != null) ? silentAreaDetectionRecord.Conf.DetectionTabType : 0);
				}
				else
				{
					num = soundAreaDetectionRecord3.DungeonDetectionRecord.Conf.DetectionTabType;
				}
				int num2 = num;
				if (num2 != 0)
				{
					if (!dictionary.ContainsKey(num2))
					{
						DetectionTabType? config = ConfigDetectionTabTypeById.GetConfig(num2, true);
						if (config == null)
						{
							continue;
						}
						NewSoundDetectTabItemTitleData newSoundDetectTabItemTitleData = new NewSoundDetectTabItemTitleData(new NewSoundDetectTabItemData
						{
							Area = num2,
							TabTextId = config.Value.Text,
							IconPath = config.Value.Icon,
							Sort = config.Value.Order,
							IsVisible = true
						});
						newSoundDetectTabItemTitleData.OnClickCallBack = new Action<int, bool>(this.OnClickNewSoundDetectTabItemTitleItemCallBack);
						dictionary[num2] = newSoundDetectTabItemTitleData;
						list.Add(newSoundDetectTabItemTitleData);
					}
					int sort = ((NewSoundDetectTabItemData)dictionary[num2].Data).Sort;
					NewSoundDetectItemData newSoundDetectItemData3 = new NewSoundDetectItemData();
					newSoundDetectItemData3.DetectRecordData = soundAreaDetectionRecord3;
					NewSoundDetectItemData newSoundDetectItemData4 = newSoundDetectItemData3;
					int[] currentTracingId2 = CS$<>8__locals1.currentTracingId;
					newSoundDetectItemData4.TracingList = ((currentTracingId2 != null) ? currentTracingId2.ToList<int>() : null);
					newSoundDetectItemData3.NightMareParam = new int?(handleShowNightMareParam);
					NewSoundDetectTabItemDungeonData newSoundDetectTabItemDungeonData = new NewSoundDetectTabItemDungeonData(new NewSoundDetectTabItemData
					{
						Area = num2,
						Dungeon = newSoundDetectItemData3,
						Sort = sort,
						IsVisible = true
					});
					dictionary[(soundAreaDetectionRecord3.DungeonDetectionRecord != null) ? soundAreaDetectionRecord3.DungeonDetectionRecord.Conf.Id : soundAreaDetectionRecord3.SilentAreaDetectionRecord.Conf.Id] = newSoundDetectTabItemDungeonData;
					list.Add(newSoundDetectTabItemDungeonData);
				}
			}
			this.ScrollDataList = (from d in list
			orderby ((NewSoundDetectTabItemData)d.Data).Sort descending
			select d).ToList<IMultiTemplateGridData>();
			MultiTemplateScrollViewRefreshContext multiTemplateScrollViewRefreshContext = new MultiTemplateScrollViewRefreshContext(this.ScrollDataList);
			multiTemplateScrollViewRefreshContext.ScrollToGridIndex = 0;
			MultiTemplateScrollView soundAreaScroll = this.SoundAreaScroll;
			if (soundAreaScroll == null)
			{
				return;
			}
			soundAreaScroll.RefreshByData(multiTemplateScrollViewRefreshContext);
		}

		// Token: 0x0603F20D RID: 258573 RVA: 0x01030954 File Offset: 0x0102EB54
		private void OnClickNewSoundDetectTabItemTitleItemCallBack(int area, bool isVisible)
		{
			List<IMultiTemplateGridData> list = new List<IMultiTemplateGridData>();
			foreach (IMultiTemplateGridData multiTemplateGridData in this.ScrollDataList)
			{
				NewSoundDetectTabItemData newSoundDetectTabItemData = multiTemplateGridData.Data as NewSoundDetectTabItemData;
				if (newSoundDetectTabItemData.Area != area)
				{
					if (newSoundDetectTabItemData.IsVisible || newSoundDetectTabItemData.TabTextId != "")
					{
						list.Add(multiTemplateGridData);
					}
				}
				else
				{
					newSoundDetectTabItemData.IsVisible = isVisible;
					if (isVisible)
					{
						list.Add(multiTemplateGridData);
					}
					else if (newSoundDetectTabItemData.TabTextId != "")
					{
						list.Add(multiTemplateGridData);
					}
				}
			}
			MultiTemplateScrollViewRefreshContext context = new MultiTemplateScrollViewRefreshContext(list);
			MultiTemplateScrollView soundAreaScroll = this.SoundAreaScroll;
			if (soundAreaScroll == null)
			{
				return;
			}
			soundAreaScroll.RefreshByData(context);
		}

		// Token: 0x0603F20E RID: 258574 RVA: 0x01030A28 File Offset: 0x0102EC28
		protected override void OnBeforeShow()
		{
			if (!this.HaveRefreshTypeScroll || this.HasNavigationParam())
			{
				this.RefreshType();
				this.HaveRefreshTypeScroll = true;
			}
			LevelSequencePlayer startLevelSequencePlayer = this.StartLevelSequencePlayer;
			if (startLevelSequencePlayer != null)
			{
				startLevelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.AdventureHelpBtn, this.HelpId);
		}

		// Token: 0x0603F20F RID: 258575 RVA: 0x01030A8C File Offset: 0x0102EC8C
		private bool HasNavigationParam()
		{
			AdventureGuideViewOpenData adventureGuideViewOpenData = this.ExtraParams as AdventureGuideViewOpenData;
			return (((adventureGuideViewOpenData != null) ? adventureGuideViewOpenData.OpenTabViewName : null) == EUiTabViewName.NewSoundAreaView || ((adventureGuideViewOpenData != null) ? adventureGuideViewOpenData.OpenTabViewName : null) == EUiTabViewName.DisposableChallengeView) && ((adventureGuideViewOpenData != null) ? adventureGuideViewOpenData.OpenParam : null).GetValueOrDefault() > 0;
		}

		// Token: 0x0603F210 RID: 258576 RVA: 0x01030B38 File Offset: 0x0102ED38
		private void RefreshType()
		{
			this.CurrentData = (this.ExtraParams as AdventureGuideViewOpenData);
			AdventureGuideViewOpenData currentData = this.CurrentData;
			bool flag = ((currentData != null) ? currentData.OpenTabViewName : null) == EUiTabViewName.NewSoundAreaView || ((currentData != null) ? currentData.OpenTabViewName : null) == EUiTabViewName.DisposableChallengeView;
			string viewName = base.GetViewName();
			bool flag2 = viewName == EUiTabViewName.NewSoundAreaView && ModelBase<FunctionModel>.Instance.IsOpen(10097);
			int? num;
			if (flag)
			{
				num = ((currentData != null) ? currentData.OpenParam : null);
				if (currentData != null)
				{
					currentData.OpenParam = null;
				}
			}
			else if (this.HasUserSelectedType)
			{
				num = new int?((int)this.CurrentType);
			}
			else if (flag2)
			{
				num = new int?(-1);
			}
			else
			{
				num = new int?(4);
			}
			int dungeonIndex = 0;
			bool flag3 = num.GetValueOrDefault() == -1;
			if (!flag3 && num != null)
			{
				int? num2 = num;
				int num3 = 0;
				if (!(num2.GetValueOrDefault() == num3 & num2 != null))
				{
					int num4 = this.TypeList.IndexOf(num.Value);
					if (num4 >= 0)
					{
						dungeonIndex = num4;
					}
				}
			}
			int count = this.TypeList.Count;
			List<INewSoundTypeItemData> list = new List<INewSoundTypeItemData>();
			for (int i = 0; i < count; i++)
			{
				int cycleId = ModelBase<WeeklyRogueModel>.Instance.CycleId;
				if (this.TypeList[i] != 29 || cycleId != 0)
				{
					NewSoundTypeItemData item = new NewSoundTypeItemData
					{
						FromTabViewName = new EUiTabViewName?((EUiTabViewName)viewName),
						TypeId = (EDungeonType)this.TypeList[i]
					};
					list.Add(item);
				}
			}
			this.RefreshTypeScroll(list, dungeonIndex, flag3);
			if (viewName == EUiTabViewName.NewSoundAreaView)
			{
				RedDotBase redDot = ModelBase<RedDotModel>.Instance.GetRedDot(ERedDotName.AdventureNewSoundAreaTab);
				if (redDot != null && redDot.IsRedDotActive())
				{
					ControllerBase<AdventureGuideController>.Instance.RecordAdventureNewSoundAreaTabClick();
				}
			}
		}

		// Token: 0x0603F211 RID: 258577 RVA: 0x01030D64 File Offset: 0x0102EF64
		private void RefreshTypeScroll(List<INewSoundTypeItemData> dataList, int dungeonIndex, bool isSelectingRoleDev)
		{
			List<IMultiTemplateGridData> list = new List<IMultiTemplateGridData>();
			int num = dungeonIndex;
			string viewName = base.GetViewName();
			this.HasRoleDevTab = (viewName == EUiTabViewName.NewSoundAreaView && ModelBase<FunctionModel>.Instance.IsOpen(10097));
			if (this.HasRoleDevTab)
			{
				RoleDevelopTabItemCellData data = new RoleDevelopTabItemCellData
				{
					TypeId = -1
				};
				list.Add(new RoleDevelopTabItemData(data, this.TypeToggleFunc, this.TypeCanToggleChange));
				if (!isSelectingRoleDev)
				{
					num++;
				}
			}
			foreach (INewSoundTypeItemData data2 in dataList)
			{
				list.Add(new NewSoundTypeItemGridData(data2, this.TypeToggleFunc, this.TypeCanToggleChange));
			}
			MultiTemplateScrollViewRefreshContext multiTemplateScrollViewRefreshContext = new MultiTemplateScrollViewRefreshContext(list);
			multiTemplateScrollViewRefreshContext.ScrollToGridIndex = num;
			this.TypeScroll.RefreshByData(multiTemplateScrollViewRefreshContext);
			int selectIndex = num;
			this.SelectToggleAfterRefreshAsync(selectIndex, isSelectingRoleDev).Forget();
		}

		// Token: 0x0603F212 RID: 258578 RVA: 0x01030E60 File Offset: 0x0102F060
		private UniTask SelectToggleAfterRefreshAsync(int selectIndex, bool isSelectingRoleDev)
		{
			NewSoundAreaView.<SelectToggleAfterRefreshAsync>d__62 <SelectToggleAfterRefreshAsync>d__;
			<SelectToggleAfterRefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SelectToggleAfterRefreshAsync>d__.<>4__this = this;
			<SelectToggleAfterRefreshAsync>d__.selectIndex = selectIndex;
			<SelectToggleAfterRefreshAsync>d__.isSelectingRoleDev = isSelectingRoleDev;
			<SelectToggleAfterRefreshAsync>d__.<>1__state = -1;
			<SelectToggleAfterRefreshAsync>d__.<>t__builder.Start<NewSoundAreaView.<SelectToggleAfterRefreshAsync>d__62>(ref <SelectToggleAfterRefreshAsync>d__);
			return <SelectToggleAfterRefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F213 RID: 258579 RVA: 0x01030EB4 File Offset: 0x0102F0B4
		protected void RefreshDungeonType()
		{
			base.GetItem(3).SetUIActive(false);
			base.GetItem(6).SetUIActive(false);
			base.GetItem(10).SetUIActive(false);
			base.GetItem(12).SetUIActive(false);
			base.GetItem(14).SetUIActive(false);
			base.GetItem(9).SetUIActive(false);
			base.GetItem(18).SetUIActive(false);
			base.GetItem(20).SetUIActive(false);
			EDungeonType currentType = this.CurrentType;
			if (currentType <= EDungeonType.ShipTower)
			{
				switch (currentType)
				{
				case EDungeonType.Mat:
					break;
				case EDungeonType.Tower:
					this.ShowTimeAndCountPart();
					this.ShowTowerPart();
					return;
				case EDungeonType.Tutorial:
					this.ShowTeachPart();
					return;
				case EDungeonType.Weekly:
					this.ShowTimeAndCountPart();
					return;
				default:
					switch (currentType)
					{
					case EDungeonType.Rouge:
						this.ShowRoguePart();
						return;
					case EDungeonType.Simulation:
					case (EDungeonType)20:
					case EDungeonType.Boss:
					case EDungeonType.NoSoundArea:
						break;
					default:
						if (currentType != EDungeonType.ShipTower)
						{
							return;
						}
						this.ShowTimeAndCountPart();
						this.ShowShipTowerPart();
						return;
					}
					break;
				}
			}
			else if (currentType != EDungeonType.WeeklyRogue)
			{
				if (currentType == EDungeonType.LordGym)
				{
					this.ShowLordGymPart();
					return;
				}
				if (currentType != EDungeonType.SkillTeach)
				{
					return;
				}
				this.ShowTeachSkillPart();
				return;
			}
			else
			{
				this.ShowTimeAndCountPart();
				this.ShowWeeklyRoguePart();
			}
		}

		// Token: 0x0603F214 RID: 258580 RVA: 0x01030FD0 File Offset: 0x0102F1D0
		private void ShowWeeklyRoguePart()
		{
			base.GetItem(9).SetUIActive(true);
			base.GetItem(20).SetUIActive(true);
			WeeklyRogueData activityData = ModelBase<WeeklyRogueModel>.Instance.ActivityData;
			RogueWeeklyCycle? rogueWeeklyCycle = (activityData != null) ? activityData.GetCycleConfig() : null;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(21), rogueWeeklyCycle.Value.CycleName, Array.Empty<object>());
		}

		// Token: 0x0603F215 RID: 258581 RVA: 0x01031040 File Offset: 0x0102F240
		private void ShowRoguePart()
		{
			base.GetItem(3).SetUIActive(true);
			RogueParam? paramConfigBySeasonId = ModelBase<RoguelikeModel>.Instance.GetParamConfigBySeasonId(null);
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(paramConfigBySeasonId.Value.TokenItem, 0);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "Roguelike_ActivityMain_Score", new <>z__ReadOnlyArray<object>(new object[]
			{
				itemCountByConfigId,
				paramConfigBySeasonId.Value.WeekTokenMaxCount
			}));
		}

		// Token: 0x0603F216 RID: 258582 RVA: 0x010310CC File Offset: 0x0102F2CC
		private void ShowTowerPart()
		{
			base.GetItem(9).SetUIActive(true);
			base.GetItem(10).SetUIActive(true);
			int maxDifficulty = ModelBase<TowerModel>.Instance.GetMaxDifficulty();
			string newTowerDifficultTitle = ConfigBase<TowerClimbConfig>.Instance.GetNewTowerDifficultTitle(maxDifficulty);
			UUIText text = base.GetText(11);
			if (text != null)
			{
				text.SetText(newTowerDifficultTitle, true);
			}
			this.SetTowerBg("T_DevelopmentFrame7");
		}

		// Token: 0x0603F217 RID: 258583 RVA: 0x0103112C File Offset: 0x0102F32C
		private void ShowShipTowerPart()
		{
			base.GetItem(9).SetUIActive(true);
			base.GetItem(10).SetUIActive(true);
			string currentStageSeasonName = ModelBase<ShipTowerModel>.Instance.GetCurrentStageSeasonName2();
			UUIText text = base.GetText(11);
			if (text != null)
			{
				text.SetText(currentStageSeasonName, true);
			}
			this.SetTowerBg("T_DevelopmentTitle6");
		}

		// Token: 0x0603F218 RID: 258584 RVA: 0x01031180 File Offset: 0x0102F380
		public void SetTowerBg(string res)
		{
			UUITexture texture = base.GetTexture(22);
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(res);
			base.SetTextureShowUntilLoaded(resourcePath, texture, null);
		}

		// Token: 0x0603F219 RID: 258585 RVA: 0x010311AB File Offset: 0x0102F3AB
		private void ShowLordGymPart()
		{
			base.GetItem(9).SetUIActive(true);
			base.GetItem(12).SetUIActive(true);
		}

		// Token: 0x0603F21A RID: 258586 RVA: 0x010311C9 File Offset: 0x0102F3C9
		private void ShowTeachSkillPart()
		{
			base.GetItem(9).SetUIActive(true);
			base.GetItem(18).SetUIActive(true);
		}

		// Token: 0x0603F21B RID: 258587 RVA: 0x010311E7 File Offset: 0x0102F3E7
		private void ShowTeachPart()
		{
			base.GetItem(9).SetUIActive(true);
			base.GetItem(14).SetUIActive(true);
		}

		// Token: 0x0603F21C RID: 258588 RVA: 0x01031208 File Offset: 0x0102F408
		private void ShowTimeAndCountPart()
		{
			UUIItem item = base.GetItem(6);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIText text = base.GetText(8);
			UUIText text2 = base.GetText(7);
			if (this.CurrentType == EDungeonType.Weekly)
			{
				text2.SetUIActive(false);
				List<SoundAreaDetectionRecord> item2 = ModelBase<AdventureGuideModel>.Instance.GetCanShowDungeonRecordsByType(this.CurrentType, null, true).Item2;
				int? num = new int?(0);
				if (item2[0].Type.GetValueOrDefault() == ESoundAreaDataType.SilentArea)
				{
					int markId = ((T2)item2[0].Conf.Value).MarkId;
					if (markId == 0)
					{
						item.SetUIActive(false);
						return;
					}
					MapMark? mapMark;
					num = ((ConfigBase<MapConfig>.Instance.GetConfigMark(markId) != null) ? new int?(mapMark.GetValueOrDefault().Reward) : null);
				}
				else
				{
					if (((T1)item2[0].Conf.Value).DungeonId == 0)
					{
						item.SetUIActive(false);
						return;
					}
					InstanceDungeon? instanceDungeon;
					num = ((ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(((T1)item2[0].Conf.Value).SubDungeonId) != null) ? new int?(instanceDungeon.GetValueOrDefault().RewardId) : null);
				}
				text.SetUIActive(true);
				ExchangeReward? exchangeReward;
				int? num2 = (ConfigBase<ExchangeRewardConfig>.Instance.GetExchangeRewardConfig(new int?(num.GetValueOrDefault())) != null) ? new int?(exchangeReward.GetValueOrDefault().SharedId) : null;
				if (num2 != null)
				{
					int? num3 = num2;
					int num4 = 0;
					if (num3.GetValueOrDefault() > num4 & num3 != null)
					{
						ExchangeShared value = ConfigBase<ExchangeRewardConfig>.Instance.GetExchangeShareConfig(new int?(num2.Value)).Value;
						int exchangeRewardShareCount = ModelBase<ExchangeRewardModel>.Instance.GetExchangeRewardShareCount(num2.Value);
						int maxCount = value.MaxCount;
						int value2 = maxCount - exchangeRewardShareCount;
						LguiUtil instance = Singleton<LguiUtil>.Instance;
						UUIText uiText = text;
						string textTableId = "ReceivedCount";
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
						defaultInterpolatedStringHandler.AppendFormatted<int>(value2);
						defaultInterpolatedStringHandler.AppendLiteral("/");
						defaultInterpolatedStringHandler.AppendFormatted<int>(maxCount);
						instance.SetLocalText(uiText, textTableId, new <>z__ReadOnlySingleElementList<object>(defaultInterpolatedStringHandler.ToStringAndClear()));
						return;
					}
				}
				item.SetUIActive(false);
				return;
			}
			if (this.CurrentType == EDungeonType.Tower)
			{
				if (text != null)
				{
					text.SetUIActive(false);
				}
				text2.SetUIActive(true);
				string countDownText = ModelBase<TowerModel>.Instance.GetSeasonCountDownData().CountDownText;
				text2.SetText(countDownText, true);
				return;
			}
			if (this.CurrentType == EDungeonType.ShipTower)
			{
				if (text != null)
				{
					text.SetUIActive(false);
				}
				text2.SetUIActive(true);
				string countDownText2 = ModelBase<ShipTowerModel>.Instance.GetSeasonCountDownData().CountDownText;
				text2.SetText(countDownText2, true);
				return;
			}
			if (this.CurrentType == EDungeonType.WeeklyRogue)
			{
				if (text != null)
				{
					text.SetUIActive(false);
				}
				text2.SetUIActive(true);
				string countDownText3 = ModelBase<WeeklyRogueModel>.Instance.ActivityData.GetCycleCountDownData().CountDownText;
				text2.SetText(countDownText3, true);
			}
		}

		// Token: 0x0603F21D RID: 258589 RVA: 0x0103152A File Offset: 0x0102F72A
		protected override void OnBeforeHide()
		{
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.PowerView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.PowerView, null);
			}
			base.SetExtraParams(null);
		}

		// Token: 0x0603F21E RID: 258590 RVA: 0x01031554 File Offset: 0x0102F754
		private void OnClickLordGymBtn()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.LordGymChallengeRecordView, null, null);
		}

		// Token: 0x0603F21F RID: 258591 RVA: 0x01031568 File Offset: 0x0102F768
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			int num;
			if (configParams.Length != 1 || !int.TryParse(configParams[0], out num))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Guide;
				ELogAuthor author = ELogAuthor.JT;
				string message = "聚焦引导extraParam项配置有误";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("configParams", configParams);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			if (num != 0)
			{
				int num2 = this.TypeList.IndexOf(num);
				if (num2 >= 0)
				{
					MultiTemplateScrollView typeScroll = this.TypeScroll;
					NewSoundTypeItem newSoundTypeItem = ((typeScroll != null) ? typeScroll.GetProxyByGridIndex(num2) : null) as NewSoundTypeItem;
					if (newSoundTypeItem != null)
					{
						UUIItem buttonItem = newSoundTypeItem.GetButtonItem();
						if (buttonItem != null)
						{
							MultiTemplateScrollView typeScroll2 = this.TypeScroll;
							if (typeScroll2 != null)
							{
								typeScroll2.ScrollView.ScrollToGridIndex(num2, true);
							}
							return new UUIItem[]
							{
								buttonItem,
								buttonItem
							};
						}
					}
				}
				return null;
			}
			MultiTemplateScrollView soundAreaScroll = this.SoundAreaScroll;
			NewSoundDetectTabItemDungeonItem newSoundDetectTabItemDungeonItem = ((soundAreaScroll != null) ? soundAreaScroll.GetProxyByGridIndex(0) : null) as NewSoundDetectTabItemDungeonItem;
			if (newSoundDetectTabItemDungeonItem == null)
			{
				return null;
			}
			UUIItem rootItem = newSoundDetectTabItemDungeonItem.GetRootItem();
			if (rootItem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				rootItem,
				rootItem
			};
		}

		// Token: 0x0603F220 RID: 258592 RVA: 0x01031658 File Offset: 0x0102F858
		private void RefreshCommonDropDown()
		{
			if (this.CurrentDropDownType == EDetectionDropDownType.None)
			{
				base.GetItem(19).SetUIActive(false);
				return;
			}
			base.GetItem(19).SetUIActive(true);
			UUIItem item = base.GetItem(15);
			if (item != null)
			{
				item.SetUIActive(this.CurrentDropDownType == EDetectionDropDownType.Level);
			}
			bool flag = this.CurrentDropDownType == EDetectionDropDownType.Suit;
			bool uiactive = this.CurrentDropDownType == EDetectionDropDownType.Weapon;
			if (flag)
			{
				this.RefreshSuitDropDownItems();
			}
			CommonDropDown<int, int> suitDropDown = this.SuitDropDown;
			if (suitDropDown != null)
			{
				suitDropDown.GetRootItem().SetUIActive(flag);
			}
			CommonDropDown<int, int> weaponDropDown = this.WeaponDropDown;
			if (weaponDropDown != null)
			{
				weaponDropDown.GetRootItem().SetUIActive(uiactive);
			}
			DetectionDropDownType? detectionDropDownType;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(28), ((ConfigBase<AdventureGuideConfig>.Instance.GetDropDownConfig((int)this.CurrentDropDownType) != null) ? detectionDropDownType.GetValueOrDefault().Text : null) ?? "", Array.Empty<object>());
		}

		// Token: 0x0603F221 RID: 258593 RVA: 0x01031740 File Offset: 0x0102F940
		private void RefreshSuitDropDownItems()
		{
			List<SoundAreaDetectionRecord> item = ModelBase<AdventureGuideModel>.Instance.GetCanShowDungeonRecordsByType(this.CurrentType, null, true).Item2;
			HashSet<int> hashSet = new HashSet<int>();
			foreach (SoundAreaDetectionRecord soundAreaDetectionRecord in item)
			{
				foreach (int item2 in soundAreaDetectionRecord.PhantomFetterGroup)
				{
					hashSet.Add(item2);
				}
			}
			List<int> list = new List<int>
			{
				0
			};
			foreach (int num in this.FetterSuitFilterArray)
			{
				if (num != 0 && hashSet.Contains(num))
				{
					list.Add(num);
				}
			}
			int currentSelectSuitIndex = ModelBase<AdventureGuideModel>.Instance.CurrentSelectSuitIndex;
			if (currentSelectSuitIndex != 0 && !hashSet.Contains(currentSelectSuitIndex))
			{
				ModelBase<AdventureGuideModel>.Instance.CurrentSelectSuitIndex = 0;
			}
			int num2 = list.IndexOf(ModelBase<AdventureGuideModel>.Instance.CurrentSelectSuitIndex);
			this.SuitDropDown.InitScroll(list, new Func<int, int>(this.GetSuitDropDownTextId), (num2 >= 0) ? num2 : 0, false);
		}

		// Token: 0x0603F222 RID: 258594 RVA: 0x0103188C File Offset: 0x0102FA8C
		private void BuildListBySuitData()
		{
			ValueTuple<bool, List<SoundAreaDetectionRecord>> canShowDungeonRecordsByType = ModelBase<AdventureGuideModel>.Instance.GetCanShowDungeonRecordsByType(this.CurrentType, null, true);
			bool item = canShowDungeonRecordsByType.Item1;
			List<SoundAreaDetectionRecord> item2 = canShowDungeonRecordsByType.Item2;
			List<SoundAreaDetectionRecord> list = new List<SoundAreaDetectionRecord>();
			if (ModelBase<AdventureGuideModel>.Instance.CurrentSelectSuitIndex != 0)
			{
				using (List<SoundAreaDetectionRecord>.Enumerator enumerator = item2.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						SoundAreaDetectionRecord soundAreaDetectionRecord = enumerator.Current;
						if (soundAreaDetectionRecord.PhantomFetterGroup.Contains(ModelBase<AdventureGuideModel>.Instance.CurrentSelectSuitIndex))
						{
							list.Add(soundAreaDetectionRecord);
						}
					}
					goto IL_8C;
				}
			}
			list = item2.ToList<SoundAreaDetectionRecord>();
			IL_8C:
			if (!item)
			{
				this.BuildDungeonNormalList(list);
			}
			else
			{
				this.BuildDungeonTabList(list);
			}
			this.CurrentData = null;
		}

		// Token: 0x0603F223 RID: 258595 RVA: 0x01031950 File Offset: 0x0102FB50
		private void BuildListByWeaponData()
		{
			ValueTuple<bool, List<SoundAreaDetectionRecord>> canShowDungeonRecordsByType = ModelBase<AdventureGuideModel>.Instance.GetCanShowDungeonRecordsByType(this.CurrentType, null, true);
			bool item = canShowDungeonRecordsByType.Item1;
			List<SoundAreaDetectionRecord> item2 = canShowDungeonRecordsByType.Item2;
			List<SoundAreaDetectionRecord> list = new List<SoundAreaDetectionRecord>();
			if (this.CurrentSelectWeaponIndex != 0)
			{
				using (List<SoundAreaDetectionRecord>.Enumerator enumerator = item2.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						SoundAreaDetectionRecord soundAreaDetectionRecord = enumerator.Current;
						if (soundAreaDetectionRecord.WeaponFetterGroup.Contains(this.CurrentSelectWeaponIndex))
						{
							list.Add(soundAreaDetectionRecord);
						}
					}
					goto IL_84;
				}
			}
			list = item2.ToList<SoundAreaDetectionRecord>();
			IL_84:
			if (!item)
			{
				this.BuildDungeonNormalList(list);
			}
			else
			{
				this.BuildDungeonTabList(list);
			}
			this.CurrentData = null;
		}

		// Token: 0x040236EE RID: 145134
		private const int ROLE_DEVELOP_TYPE = -1;

		// Token: 0x040236EF RID: 145135
		private const int PRE_OPEN_TAB_AREA = -1;

		// Token: 0x040236F0 RID: 145136
		private const int PRE_OPEN_TAB_SORT = 9999;

		// Token: 0x040236F1 RID: 145137
		[Nullable(2)]
		private AdventureGuideViewOpenData CurrentData;

		// Token: 0x040236F2 RID: 145138
		[Nullable(2)]
		private MultiTemplateScrollView TypeScroll;

		// Token: 0x040236F3 RID: 145139
		[Nullable(2)]
		private MultiTemplateScrollView SoundAreaScroll;

		// Token: 0x040236F4 RID: 145140
		private List<IMultiTemplateGridData> ScrollDataList = new List<IMultiTemplateGridData>();

		// Token: 0x040236F5 RID: 145141
		private IReadOnlyList<int> TypeList = Array.Empty<int>();

		// Token: 0x040236F6 RID: 145142
		private EDungeonType CurrentType = EDungeonType.Mat;

		// Token: 0x040236F7 RID: 145143
		[Nullable(2)]
		private UUIExtendToggle CurrentSelectedToggle;

		// Token: 0x040236F8 RID: 145144
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private CommonDropDown<TableTextArgNew, int> LevelDropDown;

		// Token: 0x040236F9 RID: 145145
		[Nullable(2)]
		private CommonDropDown<int, int> SuitDropDown;

		// Token: 0x040236FA RID: 145146
		[Nullable(2)]
		private CommonDropDown<int, int> WeaponDropDown;

		// Token: 0x040236FB RID: 145147
		private EDetectionDropDownType CurrentDropDownType;

		// Token: 0x040236FC RID: 145148
		private int CurrentSelectWeaponIndex;

		// Token: 0x040236FD RID: 145149
		private readonly List<int> WeaponFilterArray = new List<int>();

		// Token: 0x040236FE RID: 145150
		[Nullable(2)]
		private LevelSequencePlayer StartLevelSequencePlayer;

		// Token: 0x040236FF RID: 145151
		[Nullable(2)]
		private LevelSequencePlayer SwitchLevelSequencePlayer;

		// Token: 0x04023700 RID: 145152
		private int DefaultDropDownSelectIndex;

		// Token: 0x04023701 RID: 145153
		private int HelpId;

		// Token: 0x04023702 RID: 145154
		private readonly List<int> FetterSuitFilterArray = new List<int>();

		// Token: 0x04023703 RID: 145155
		private bool IsNavigationJumpToGrid;

		// Token: 0x04023704 RID: 145156
		private bool HasRoleDevTab;

		// Token: 0x04023705 RID: 145157
		private bool HasUserSelectedType;

		// Token: 0x04023706 RID: 145158
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<int, UUIExtendToggle> TypeToggleFunc;

		// Token: 0x04023707 RID: 145159
		[Nullable(2)]
		private Func<int, bool> TypeCanToggleChange;

		// Token: 0x04023708 RID: 145160
		[Nullable(2)]
		private RegressPanel RegressPanel;

		// Token: 0x04023709 RID: 145161
		[Nullable(2)]
		private RoleDevelopOverviewPanel RoleDevelopPanel;

		// Token: 0x0402370A RID: 145162
		private bool HaveRefreshTypeScroll;
	}
}
