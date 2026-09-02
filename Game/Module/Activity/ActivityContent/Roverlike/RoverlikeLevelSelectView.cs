using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006428 RID: 25640
	[NullableContext(2)]
	[Nullable(0)]
	public class RoverlikeLevelSelectView : UiViewBase
	{
		// Token: 0x17009DF2 RID: 40434
		// (get) Token: 0x060405C5 RID: 263621 RVA: 0x0107F39E File Offset: 0x0107D59E
		private RoverlikeActivityData ActivityData
		{
			get
			{
				return ControllerBase<RoverlikeActivityController>.Instance.GetCurrentActivityData();
			}
		}

		// Token: 0x060405C6 RID: 263622 RVA: 0x0107F3AA File Offset: 0x0107D5AA
		[NullableContext(1)]
		public RoverlikeLevelSelectView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x060405C7 RID: 263623 RVA: 0x0107F3B4 File Offset: 0x0107D5B4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 22;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUITexture));
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
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060405C8 RID: 263624 RVA: 0x0107F6C0 File Offset: 0x0107D8C0
		protected override UniTask OnBeforeStartAsync()
		{
			RoverlikeLevelSelectView.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoverlikeLevelSelectView.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060405C9 RID: 263625 RVA: 0x0107F704 File Offset: 0x0107D904
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RoverlikeEquippedLootChange, new Action<int>(this.OnEquippedLootChange));
			Singleton<EventSystem>.Instance.Add(EEventName.RoverlikeLootInfoUpdate, new Action(this.OnLootInfoUpdate));
			Singleton<EventSystem>.Instance.Add(EEventName.RoverlikeLevelInfoUpdate, new Action(this.OnLevelInfoUpdate));
		}

		// Token: 0x060405CA RID: 263626 RVA: 0x0107F768 File Offset: 0x0107D968
		protected override void OnStart()
		{
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.CaptionItem.SetCloseCallBack(new Action(this.OnCloseBtnClick));
			RoverlikeActivityData activityData = this.ActivityData;
			this.LevelData = ((activityData != null) ? activityData.LevelSelectData : null);
			if (this.LevelData == null)
			{
				return;
			}
			if (activityData != null)
			{
				activityData.MarkLevelUnlockRedDotRead();
			}
			this.BuildDetailButtons();
			this.BuildLevelLayout();
			this.BuildInfoLayout();
			this.RefreshLevelList();
		}

		// Token: 0x060405CB RID: 263627 RVA: 0x0107F7E1 File Offset: 0x0107D9E1
		private void OnEquippedLootChange(int lootId)
		{
			this.RefreshDetailButtonTexts();
		}

		// Token: 0x060405CC RID: 263628 RVA: 0x0107F7E9 File Offset: 0x0107D9E9
		private void OnLootInfoUpdate()
		{
			this.RefreshDetailButtonTexts();
		}

		// Token: 0x060405CD RID: 263629 RVA: 0x0107F7F1 File Offset: 0x0107D9F1
		private void OnLevelInfoUpdate()
		{
			this.RefreshLevelList();
		}

		// Token: 0x060405CE RID: 263630 RVA: 0x0107F7FC File Offset: 0x0107D9FC
		private void BuildDetailButtons()
		{
			RoverlikeSelectButton lootButton = this.LootButton;
			if (lootButton != null)
			{
				lootButton.SetClickCallback(new Action(this.OnClickLoot));
			}
			RoverlikeSelectButton attributeButton = this.AttributeButton;
			if (attributeButton != null)
			{
				attributeButton.SetClickCallback(new Action(this.OnClickAttribute));
			}
			RoverlikeCommonButton commonButton = this.CommonButton;
			if (commonButton != null)
			{
				commonButton.SetClickCallback(new Action(this.OnClickGo));
			}
			RoverlikeSelectButton lootButton2 = this.LootButton;
			if (lootButton2 != null)
			{
				lootButton2.SetStarListActive(true);
			}
			RoverlikeSelectButton attributeButton2 = this.AttributeButton;
			if (attributeButton2 == null)
			{
				return;
			}
			attributeButton2.SetStarListActive(false);
		}

		// Token: 0x060405CF RID: 263631 RVA: 0x0107F883 File Offset: 0x0107DA83
		public void Refresh()
		{
			this.RefreshLevelList();
		}

		// Token: 0x060405D0 RID: 263632 RVA: 0x0107F88C File Offset: 0x0107DA8C
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RoverlikeEquippedLootChange, new Action<int>(this.OnEquippedLootChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.RoverlikeLootInfoUpdate, new Action(this.OnLootInfoUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.RoverlikeLevelInfoUpdate, new Action(this.OnLevelInfoUpdate));
		}

		// Token: 0x060405D1 RID: 263633 RVA: 0x0107F8F0 File Offset: 0x0107DAF0
		protected override void OnBeforeDestroy()
		{
			if (this.LevelData != null)
			{
				this.LevelData.LastSelectedInstId = this.CurSelectInstId;
			}
			this.LevelLayout = null;
			this.InfoList = null;
			this.LootButton = null;
			this.AttributeButton = null;
			this.CommonButton = null;
			this.LockedPanel = null;
		}

		// Token: 0x060405D2 RID: 263634 RVA: 0x0107F940 File Offset: 0x0107DB40
		private void BuildLevelLayout()
		{
			UUILayoutBase layout = base.GetScrollViewWithScrollbar(1).GetContent().GetComponentByClass(UUILayoutBase.StaticClass()) as UUILayoutBase;
			this.LevelLayout = new GenericLayout<RoverlikeLevelItem, RoverlikeLevelSelectItemData>(layout, () => new RoverlikeLevelItem
			{
				OnSelectCallback = new Action<int>(this.OnSelectLevel)
			}, null, false, true);
		}

		// Token: 0x060405D3 RID: 263635 RVA: 0x0107F989 File Offset: 0x0107DB89
		private void BuildInfoLayout()
		{
			this.InfoList = new RoverlikeLevelInfoList(base.GetScrollViewWithScrollbar(5));
		}

		// Token: 0x060405D4 RID: 263636 RVA: 0x0107F99D File Offset: 0x0107DB9D
		private void RefreshLevelList()
		{
			if (this.LevelLayout == null || this.LevelData == null)
			{
				return;
			}
			this.LevelLayout.RefreshByData(this.LevelData.GetItemDataList(), delegate
			{
				if (this.CurSelectInstId <= 0)
				{
					this.SelectDefault(true);
					return;
				}
				this.SelectByInstId(this.CurSelectInstId, true);
			}, false);
		}

		// Token: 0x060405D5 RID: 263637 RVA: 0x0107F9D4 File Offset: 0x0107DBD4
		private void SelectDefault(bool scrollToView = false)
		{
			RoverlikeLevelSelectData levelData = this.LevelData;
			int num = (levelData != null) ? levelData.GetDefaultSelectInstId() : 0;
			if (num > 0)
			{
				this.SelectByInstId(num, scrollToView);
			}
		}

		// Token: 0x060405D6 RID: 263638 RVA: 0x0107FA00 File Offset: 0x0107DC00
		private void OnSelectLevel(int instId)
		{
			this.SelectByInstId(instId, false);
		}

		// Token: 0x060405D7 RID: 263639 RVA: 0x0107FA0C File Offset: 0x0107DC0C
		private void SelectByInstId(int instId, bool scrollToView = false)
		{
			if (instId <= 0 || this.LevelLayout == null || this.LevelData == null)
			{
				return;
			}
			RoverlikeLevelSelectItemData itemData = this.LevelData.GetItemData(instId);
			if (itemData == null)
			{
				return;
			}
			bool flag = this.CurSelectInstId > 0 && this.CurSelectInstId != instId;
			int? gridIndexByKey = this.LevelLayout.GetGridIndexByKey<int>(instId);
			if (gridIndexByKey != null)
			{
				this.LevelLayout.SelectGridProxy(gridIndexByKey.Value, false);
			}
			this.CurSelectInstId = instId;
			if (scrollToView)
			{
				this.ScrollToSelectedLevel(instId);
			}
			this.RefreshDetailPanel(itemData);
			if (flag)
			{
				base.PlayOrReplaySequence("Switch", false, null);
			}
		}

		// Token: 0x060405D8 RID: 263640 RVA: 0x0107FAB0 File Offset: 0x0107DCB0
		private void ScrollToSelectedLevel(int instId)
		{
			if (this.LevelLayout == null)
			{
				return;
			}
			TTimerAction <>9__1;
			this.LevelLayout.BindLateUpdate(delegate(float _)
			{
				TimerSystemInstance gameplayTimeInstance = TimerSystem.GameplayTimeInstance;
				TTimerAction action;
				if ((action = <>9__1) == null)
				{
					action = (<>9__1 = delegate(float __)
					{
						GenericLayout<RoverlikeLevelItem, RoverlikeLevelSelectItemData> levelLayout2 = this.LevelLayout;
						UUIItem uuiitem = (levelLayout2 != null) ? levelLayout2.GetItemByKey(instId) : null;
						if (uuiitem != null)
						{
							UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = this.GetScrollViewWithScrollbar(1);
							if (scrollViewWithScrollbar == null)
							{
								return;
							}
							scrollViewWithScrollbar.ScrollTo(uuiitem, true);
						}
					});
				}
				gameplayTimeInstance.Next(action, null, null);
				GenericLayout<RoverlikeLevelItem, RoverlikeLevelSelectItemData> levelLayout = this.LevelLayout;
				if (levelLayout == null)
				{
					return;
				}
				levelLayout.UnBindLateUpdate();
			});
		}

		// Token: 0x060405D9 RID: 263641 RVA: 0x0107FAF1 File Offset: 0x0107DCF1
		private RoverlikeLevelSelectItemData GetCurrentItemData()
		{
			if (this.CurSelectInstId <= 0)
			{
				return null;
			}
			RoverlikeLevelSelectData levelData = this.LevelData;
			if (levelData == null)
			{
				return null;
			}
			return levelData.GetItemData(this.CurSelectInstId);
		}

		// Token: 0x060405DA RID: 263642 RVA: 0x0107FB18 File Offset: 0x0107DD18
		private void RefreshDetailPanel(RoverlikeLevelSelectItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			RoverRogueIns? insConfig = ConfigBase<RoverlikeConfig>.Instance.GetInsConfig(itemData.InstId);
			IReadOnlyList<RoverRogueBlessRole> blessRoleConfigListByUnlockInsId = ConfigBase<RoverlikeConfig>.Instance.GetBlessRoleConfigListByUnlockInsId(itemData.InstId);
			this.RefreshNumTexts(itemData, insConfig);
			this.RefreshUnlockText(itemData, blessRoleConfigListByUnlockInsId);
			this.RefreshInfoList(insConfig);
			this.RefreshBlessRolePanel(blessRoleConfigListByUnlockInsId);
			UUIItem item = base.GetItem(14);
			if (item != null)
			{
				item.SetUIActive(itemData.Passed);
			}
			UUIItem item2 = base.GetItem(18);
			if (item2 != null)
			{
				item2.SetUIActive(blessRoleConfigListByUnlockInsId.Count > 0);
			}
			UUIText text = base.GetText(8);
			if (text != null)
			{
				UUIItem uuiitem = text;
				bool passed = itemData.Passed;
				FColor? fcolor = new FColor?(text.changeColor);
				uuiitem.SetChangeColor(passed, fcolor);
			}
			this.RefreshLockedPanel(itemData.Unlocked);
			this.RefreshDetailButtons(itemData.Unlocked);
		}

		// Token: 0x060405DB RID: 263643 RVA: 0x0107FBDB File Offset: 0x0107DDDB
		private void RefreshLockedPanel(bool isUnlocked)
		{
			RoverlikeRoleSelectUnlockPanel lockedPanel = this.LockedPanel;
			if (lockedPanel != null)
			{
				UUIItem rootItem = lockedPanel.GetRootItem();
				if (rootItem != null)
				{
					rootItem.SetUIActive(!isUnlocked);
				}
			}
			if (!isUnlocked)
			{
				RoverlikeRoleSelectUnlockPanel lockedPanel2 = this.LockedPanel;
				if (lockedPanel2 == null)
				{
					return;
				}
				lockedPanel2.RefreshUnlockDesc("RoverRogue_StageLockedHint");
			}
		}

		// Token: 0x060405DC RID: 263644 RVA: 0x0107FC18 File Offset: 0x0107DE18
		[NullableContext(1)]
		private void RefreshNumTexts(RoverlikeLevelSelectItemData itemData, RoverRogueIns? cfg)
		{
			int index = Math.Min(Math.Max(((cfg != null) ? cfg.GetValueOrDefault().Difficulty : 1) - 1, 0), 2);
			FColor color = RoverlikeLevelSelectView.TierTextColors[index];
			UUIText text = base.GetText(4);
			if (text != null)
			{
				text.SetText(this.FormatLevelNum((cfg != null) ? cfg.GetValueOrDefault().SortId : 0), true);
			}
			UUIText text2 = base.GetText(4);
			if (text2 != null)
			{
				text2.SetColor(color);
			}
			UUIText text3 = base.GetText(3);
			if (text3 == null)
			{
				return;
			}
			string str = "/";
			RoverlikeLevelSelectData levelData = this.LevelData;
			text3.SetText(str + this.FormatLevelNum((levelData != null) ? levelData.GetMaxLevelSortId() : 0), true);
		}

		// Token: 0x060405DD RID: 263645 RVA: 0x0107FCD8 File Offset: 0x0107DED8
		[NullableContext(1)]
		private void RefreshUnlockText(RoverlikeLevelSelectItemData itemData, IReadOnlyList<RoverRogueBlessRole> blessRoleList)
		{
			UUIText text = base.GetText(8);
			if (text == null)
			{
				return;
			}
			if (blessRoleList.Count >= 3)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RoverRogue_GodUnlock_Triple", new <>z__ReadOnlyArray<object>(new object[]
				{
					this.GetBlessRoleName(blessRoleList[0]),
					this.GetBlessRoleName(blessRoleList[1]),
					this.GetBlessRoleName(blessRoleList[2])
				}));
				return;
			}
			if (blessRoleList.Count == 2)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RoverRogue_GodUnlock_Double", new <>z__ReadOnlyArray<object>(new object[]
				{
					this.GetBlessRoleName(blessRoleList[0]),
					this.GetBlessRoleName(blessRoleList[1])
				}));
				return;
			}
			if (blessRoleList.Count == 1)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RoverRogue_GodUnlock_Single", new <>z__ReadOnlySingleElementList<object>(this.GetBlessRoleName(blessRoleList[0])));
				return;
			}
			text.SetText("", true);
		}

		// Token: 0x060405DE RID: 263646 RVA: 0x0107FDC3 File Offset: 0x0107DFC3
		[NullableContext(1)]
		private string GetBlessRoleName(RoverRogueBlessRole blessRole)
		{
			return ConfigMultiTextLang.GetLocalTextNew(blessRole.BlessRoleName, null) ?? "";
		}

		// Token: 0x060405DF RID: 263647 RVA: 0x0107FDDC File Offset: 0x0107DFDC
		private void RefreshInfoList(RoverRogueIns? cfg)
		{
			RoverlikeLevelInfoList infoList = this.InfoList;
			if (infoList != null)
			{
				infoList.RefreshByConfig(cfg);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(17), (cfg != null) ? cfg.GetValueOrDefault().LevelName : null, Array.Empty<object>());
		}

		// Token: 0x060405E0 RID: 263648 RVA: 0x0107FE30 File Offset: 0x0107E030
		[NullableContext(1)]
		private void RefreshBlessRolePanel(IReadOnlyList<RoverRogueBlessRole> blessRoleList)
		{
			this.RefreshSingleBlessRole(16, 7, (blessRoleList.Count > 0) ? new RoverRogueBlessRole?(blessRoleList[0]) : null);
			this.RefreshSingleBlessRole(12, 13, (blessRoleList.Count > 1) ? new RoverRogueBlessRole?(blessRoleList[1]) : null);
			this.RefreshSingleBlessRole(20, 21, (blessRoleList.Count > 2) ? new RoverRogueBlessRole?(blessRoleList[2]) : null);
		}

		// Token: 0x060405E1 RID: 263649 RVA: 0x0107FEBC File Offset: 0x0107E0BC
		private void RefreshSingleBlessRole(int pnlComp, int texComp, RoverRogueBlessRole? blessRole)
		{
			UUIItem item = base.GetItem(pnlComp);
			if (blessRole != null && !string.IsNullOrEmpty(blessRole.Value.RoleIcon))
			{
				if (item != null)
				{
					item.SetUIActive(true);
				}
				UUITexture texture = base.GetTexture(texComp);
				if (texture != null)
				{
					texture.SetUIActive(true);
					base.SetTextureByPath(blessRole.Value.RoleIcon, texture, null, null);
					return;
				}
			}
			else if (item != null)
			{
				item.SetUIActive(false);
			}
		}

		// Token: 0x060405E2 RID: 263650 RVA: 0x0107FF38 File Offset: 0x0107E138
		private void RefreshDetailButtons(bool isUnlocked)
		{
			RoverlikeCommonButton commonButton = this.CommonButton;
			if (commonButton != null)
			{
				UUIItem rootItem = commonButton.GetRootItem();
				if (rootItem != null)
				{
					rootItem.SetUIActive(isUnlocked);
				}
			}
			if (isUnlocked)
			{
				RoverRogueIns? insConfig = ConfigBase<RoverlikeConfig>.Instance.GetInsConfig(this.CurSelectInstId);
				RoverlikeCommonButton commonButton2 = this.CommonButton;
				if (commonButton2 != null)
				{
					commonButton2.RefreshByDifficulty((insConfig != null) ? insConfig.GetValueOrDefault().Difficulty : 1);
				}
			}
			this.RefreshDetailButtonTexts();
		}

		// Token: 0x060405E3 RID: 263651 RVA: 0x0107FFA8 File Offset: 0x0107E1A8
		private void RefreshDetailButtonTexts()
		{
			bool flag = !this.IsLootFeatureUnlocked();
			RoverlikeSelectButton lootButton = this.LootButton;
			if (lootButton != null)
			{
				lootButton.SetLock(flag, true);
			}
			if (flag)
			{
				RoverlikeSelectButton lootButton2 = this.LootButton;
				if (lootButton2 != null)
				{
					lootButton2.SetLocalTextNew("RoverRogue_LootUnlockHint", Array.Empty<object>());
				}
				RoverlikeSelectButton lootButton3 = this.LootButton;
				if (lootButton3 != null)
				{
					lootButton3.SetImage("");
				}
				RoverlikeSelectButton lootButton4 = this.LootButton;
				if (lootButton4 != null)
				{
					lootButton4.SetStars(0, 0);
				}
				this.RefreshAttributeButtonText();
				return;
			}
			RoverlikeLevelSelectData levelData = this.LevelData;
			int num = (levelData != null) ? levelData.SelectedLootId : 0;
			RoverRogueLoot? roverRogueLoot = (num > 0) ? ConfigBase<RoverlikeConfig>.Instance.GetLootConfig(num) : null;
			if (roverRogueLoot != null)
			{
				RoverlikeSelectButton lootButton5 = this.LootButton;
				if (lootButton5 != null)
				{
					lootButton5.SetLocalTextNew(roverRogueLoot.Value.Name, Array.Empty<object>());
				}
				RoverlikeSelectButton lootButton6 = this.LootButton;
				if (lootButton6 != null)
				{
					lootButton6.SetImage(roverRogueLoot.Value.Icon);
				}
				this.RefreshLootStars(roverRogueLoot.Value.MaxLevel);
			}
			else
			{
				RoverlikeSelectButton lootButton7 = this.LootButton;
				if (lootButton7 != null)
				{
					lootButton7.SetLocalTextNew("RoverRogue_DefaultLoot", Array.Empty<object>());
				}
				RoverlikeSelectButton lootButton8 = this.LootButton;
				if (lootButton8 != null)
				{
					lootButton8.SetImage("");
				}
				RoverlikeSelectButton lootButton9 = this.LootButton;
				if (lootButton9 != null)
				{
					lootButton9.SetStars(0, 0);
				}
			}
			this.RefreshAttributeButtonText();
		}

		// Token: 0x060405E4 RID: 263652 RVA: 0x01080100 File Offset: 0x0107E300
		private void RefreshLootStars(int maxLevel)
		{
			RoverlikeSelectButton lootButton = this.LootButton;
			if (lootButton == null)
			{
				return;
			}
			lootButton.SetStars(ControllerBase<RoverlikeController>.Instance.GetEquippedLootLevel(), maxLevel);
		}

		// Token: 0x060405E5 RID: 263653 RVA: 0x0108011D File Offset: 0x0107E31D
		private bool IsLootFeatureUnlocked()
		{
			RoverlikeActivityData activityData = this.ActivityData;
			return activityData != null && activityData.IsLootFeatureUnlocked();
		}

		// Token: 0x060405E6 RID: 263654 RVA: 0x01080130 File Offset: 0x0107E330
		private void RefreshAttributeButtonText()
		{
			RoverlikeSelectButton attributeButton = this.AttributeButton;
			if (attributeButton != null)
			{
				attributeButton.SetLock(false, true);
			}
			RoverRogueRoleType? roleTypeConfig = ConfigBase<RoverlikeConfig>.Instance.GetRoleTypeConfig(this.GetSelectedRoleTypeId());
			if (!string.IsNullOrEmpty((roleTypeConfig != null) ? roleTypeConfig.GetValueOrDefault().Element : null))
			{
				RoverlikeSelectButton attributeButton2 = this.AttributeButton;
				if (attributeButton2 != null)
				{
					attributeButton2.SetLocalTextNew(roleTypeConfig.Value.Element, Array.Empty<object>());
				}
				RoverlikeSelectButton attributeButton3 = this.AttributeButton;
				if (attributeButton3 != null)
				{
					attributeButton3.SetImage(roleTypeConfig.Value.ElementIcon);
				}
			}
			else
			{
				RoverlikeSelectButton attributeButton4 = this.AttributeButton;
				if (attributeButton4 != null)
				{
					attributeButton4.SetLocalTextNew("RoverRogue_DefaultElement", Array.Empty<object>());
				}
				RoverlikeSelectButton attributeButton5 = this.AttributeButton;
				if (attributeButton5 != null)
				{
					attributeButton5.SetImage("");
				}
			}
			this.RefreshAttributeBubble();
		}

		// Token: 0x060405E7 RID: 263655 RVA: 0x01080204 File Offset: 0x0107E404
		private void RefreshAttributeBubble()
		{
			UUIItem item = base.GetItem(19);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(this.IsLootRoleTypeMismatch());
		}

		// Token: 0x060405E8 RID: 263656 RVA: 0x0108022C File Offset: 0x0107E42C
		private bool IsRoleSelectLocked()
		{
			RoverRogueIns? insConfig = ConfigBase<RoverlikeConfig>.Instance.GetInsConfig(this.CurSelectInstId);
			return ((insConfig != null) ? insConfig.GetValueOrDefault().RoverListLength : 0) <= 1;
		}

		// Token: 0x060405E9 RID: 263657 RVA: 0x0108026C File Offset: 0x0107E46C
		private int GetSelectedRoleTypeId()
		{
			if (this.IsRoleSelectLocked())
			{
				return this.GetUniqueAllowedRoleTypeId();
			}
			RoverlikeLevelSelectData levelData = this.LevelData;
			int num = (levelData != null) ? levelData.GetSelectedRoleTypeId(this.CurSelectInstId) : 0;
			if (num > 0)
			{
				return num;
			}
			int lastPassRoleTypeId = ModelBase<RoverlikeModel>.Instance.GetLastPassRoleTypeId();
			if (lastPassRoleTypeId > 0 && ConfigBase<RoverlikeConfig>.Instance.GetRoleTypeConfig(lastPassRoleTypeId) != null)
			{
				return lastPassRoleTypeId;
			}
			IReadOnlyList<RoverRogueRoleType> roleTypeConfigList = ConfigBase<RoverlikeConfig>.Instance.GetRoleTypeConfigList();
			if (roleTypeConfigList.Count <= 0)
			{
				return 0;
			}
			return roleTypeConfigList[0].Id;
		}

		// Token: 0x060405EA RID: 263658 RVA: 0x010802F4 File Offset: 0x0107E4F4
		private int GetUniqueAllowedRoleTypeId()
		{
			IReadOnlyList<RoverRogueRoleType> roleTypeConfigList = ConfigBase<RoverlikeConfig>.Instance.GetRoleTypeConfigList();
			int result = (roleTypeConfigList.Count > 0) ? roleTypeConfigList[0].Id : 0;
			RoverRogueIns? insConfig = ConfigBase<RoverlikeConfig>.Instance.GetInsConfig(this.CurSelectInstId);
			int num = (insConfig != null && insConfig.Value.RoverListLength > 0) ? insConfig.Value.RoverList(0) : 0;
			if (num <= 0)
			{
				return result;
			}
			return num;
		}

		// Token: 0x060405EB RID: 263659 RVA: 0x01080374 File Offset: 0x0107E574
		[NullableContext(1)]
		private string FormatLevelNum(int level)
		{
			int num = (level > 0) ? level : 0;
			if (num >= 10)
			{
				return num.ToString();
			}
			return "0" + num.ToString();
		}

		// Token: 0x060405EC RID: 263660 RVA: 0x010803A8 File Offset: 0x0107E5A8
		private void OnClickGo()
		{
			RoverlikeLevelSelectItemData itemData = this.GetCurrentItemData();
			if (itemData == null || !itemData.Unlocked)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RoverRogue_LevelSelect_LockedTip", Array.Empty<object>());
				return;
			}
			if (this.IsLootRoleTypeMismatch())
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RoverRogueLootNotMatchConfirm);
				confirmBoxDataNew.FunctionMap[2] = delegate()
				{
					this.EnterLevel(itemData);
				};
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			this.EnterLevel(itemData);
		}

		// Token: 0x060405ED RID: 263661 RVA: 0x0108043C File Offset: 0x0107E63C
		private bool IsLootRoleTypeMismatch()
		{
			RoverlikeLevelSelectData levelData = this.LevelData;
			int num = (levelData != null) ? levelData.SelectedLootId : 0;
			RoverRogueLoot? roverRogueLoot = (num > 0) ? ConfigBase<RoverlikeConfig>.Instance.GetLootConfig(num) : null;
			int num2 = (roverRogueLoot != null) ? roverRogueLoot.GetValueOrDefault().ApplyRoleType : 0;
			return num2 != 0 && num2 != this.GetSelectedRoleTypeId();
		}

		// Token: 0x060405EE RID: 263662 RVA: 0x010804A8 File Offset: 0x0107E6A8
		[NullableContext(1)]
		private void EnterLevel(RoverlikeLevelSelectItemData itemData)
		{
			int mainRoleId = ModelBase<RoverlikeModel>.Instance.GetMainRoleId();
			int roleType = this.GetSelectedRoleTypeId();
			bool continueLastProgress = false;
			RoverlikeLevelSelectData levelData = this.LevelData;
			int lootId = (levelData != null) ? levelData.SelectedLootId : 0;
			ControllerBase<RoverlikeController>.Instance.RoverRogueStartRequest(itemData.InstId, mainRoleId, roleType, continueLastProgress, lootId, delegate(bool success)
			{
				if (!success)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Activity;
					ELogAuthor author = ELogAuthor.SWC;
					string message = "RoverlikeLevelSelectView 前往失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("InstId", itemData.InstId);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				ModelBase<RoverlikeModel>.Instance.SetCurrentRunRoleTypeId(roleType);
			});
		}

		// Token: 0x060405EF RID: 263663 RVA: 0x01080518 File Offset: 0x0107E718
		private void OnClickAttribute()
		{
			RoverlikeLevelSelectItemData currentItemData = this.GetCurrentItemData();
			if (currentItemData == null || !currentItemData.Unlocked)
			{
				return;
			}
			RoverlikeRoleSelectViewOpenParam param = new RoverlikeRoleSelectViewOpenParam
			{
				DefaultRoleTypeId = this.GetSelectedRoleTypeId(),
				InstId = this.CurSelectInstId,
				OnConfirm = new Action<int>(this.OnRoleTypeConfirm)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikeRoleSelectView, param, null);
		}

		// Token: 0x060405F0 RID: 263664 RVA: 0x01080579 File Offset: 0x0107E779
		private void OnRoleTypeConfirm(int roleTypeId)
		{
			RoverlikeLevelSelectData levelData = this.LevelData;
			if (levelData != null)
			{
				levelData.SetSelectedRoleTypeId(this.CurSelectInstId, roleTypeId);
			}
			this.RefreshAttributeButtonText();
		}

		// Token: 0x060405F1 RID: 263665 RVA: 0x0108059C File Offset: 0x0107E79C
		private void OnClickLoot()
		{
			RoverlikeLevelSelectItemData currentItemData = this.GetCurrentItemData();
			if (currentItemData == null || !currentItemData.Unlocked)
			{
				return;
			}
			if (!this.IsLootFeatureUnlocked())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RoverRogue_LootUnlockHint", Array.Empty<object>());
				return;
			}
			RoverlikeController instance = ControllerBase<RoverlikeController>.Instance;
			RoverlikeLevelSelectData levelData = this.LevelData;
			instance.OpenRoverRogueLootSelectView((levelData != null) ? levelData.SelectedLootId : 0, new Action<int, int>(this.OnLootConfirm));
		}

		// Token: 0x060405F2 RID: 263666 RVA: 0x01080601 File Offset: 0x0107E801
		private void OnLootConfirm(int lootId, int lootLv)
		{
			ControllerBase<RoverlikeController>.Instance.RoverRogueOutGameLootChangeRequest(lootId, lootLv, delegate(bool success)
			{
				if (!success)
				{
					return;
				}
				this.RefreshDetailButtonTexts();
			});
		}

		// Token: 0x060405F3 RID: 263667 RVA: 0x0108061B File Offset: 0x0107E81B
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x040240F4 RID: 147700
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly IReadOnlyList<FColor> TierTextColors = new List<FColor>
		{
			FColor.FromHex("#469FFBFF"),
			FColor.FromHex("#856FF8FF"),
			FColor.FromHex("#F22647FF")
		};

		// Token: 0x040240F5 RID: 147701
		private PopupCaptionItem CaptionItem;

		// Token: 0x040240F6 RID: 147702
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RoverlikeLevelItem, RoverlikeLevelSelectItemData> LevelLayout;

		// Token: 0x040240F7 RID: 147703
		private RoverlikeLevelInfoList InfoList;

		// Token: 0x040240F8 RID: 147704
		private RoverlikeLevelSelectData LevelData;

		// Token: 0x040240F9 RID: 147705
		private int CurSelectInstId;

		// Token: 0x040240FA RID: 147706
		private RoverlikeSelectButton LootButton;

		// Token: 0x040240FB RID: 147707
		private RoverlikeSelectButton AttributeButton;

		// Token: 0x040240FC RID: 147708
		private RoverlikeCommonButton CommonButton;

		// Token: 0x040240FD RID: 147709
		private RoverlikeRoleSelectUnlockPanel LockedPanel;

		// Token: 0x0200C493 RID: 50323
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C80F RID: 247823
			public const int UiItemCaption = 0;

			// Token: 0x0403C810 RID: 247824
			public const int SvTab = 1;

			// Token: 0x0403C811 RID: 247825
			public const int TogTabLevelTemplate = 2;

			// Token: 0x0403C812 RID: 247826
			public const int TxtNum1 = 3;

			// Token: 0x0403C813 RID: 247827
			public const int TxtNum2 = 4;

			// Token: 0x0403C814 RID: 247828
			public const int SvInfo = 5;

			// Token: 0x0403C815 RID: 247829
			public const int PnlInfo = 6;

			// Token: 0x0403C816 RID: 247830
			public const int TexRole1 = 7;

			// Token: 0x0403C817 RID: 247831
			public const int TxtUnlock = 8;

			// Token: 0x0403C818 RID: 247832
			public const int BtnRogueConfirm2 = 9;

			// Token: 0x0403C819 RID: 247833
			public const int BtnRogueConfirm = 10;

			// Token: 0x0403C81A RID: 247834
			public const int BtnRogueCommon = 11;

			// Token: 0x0403C81B RID: 247835
			public const int PnlRole2 = 12;

			// Token: 0x0403C81C RID: 247836
			public const int TexRole2 = 13;

			// Token: 0x0403C81D RID: 247837
			public const int PnlMaskDone = 14;

			// Token: 0x0403C81E RID: 247838
			public const int PnlAactivedB = 15;

			// Token: 0x0403C81F RID: 247839
			public const int PnlRole1 = 16;

			// Token: 0x0403C820 RID: 247840
			public const int TitleText = 17;

			// Token: 0x0403C821 RID: 247841
			public const int UnlockItem = 18;

			// Token: 0x0403C822 RID: 247842
			public const int BubbleItem = 19;

			// Token: 0x0403C823 RID: 247843
			public const int PnlRole3 = 20;

			// Token: 0x0403C824 RID: 247844
			public const int TexRole3 = 21;
		}
	}
}
