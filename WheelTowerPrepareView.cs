using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020016D8 RID: 5848
[NullableContext(1)]
[Nullable(0)]
public class WheelTowerPrepareView : UiViewBase
{
	// Token: 0x0600A25C RID: 41564 RVA: 0x002ACB1D File Offset: 0x002AAD1D
	public WheelTowerPrepareView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600A25D RID: 41565 RVA: 0x002ACB28 File Offset: 0x002AAD28
	protected unsafe override void OnRegisterComponent()
	{
		int num = 30;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUILayoutBase));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(24, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(25, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(26, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(29, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(27, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(28, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(13, new Action(this.OnStartBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(23, new Action(this.OnBtnSkillBranchPopClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A25E RID: 41566 RVA: 0x002ACFA5 File Offset: 0x002AB1A5
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
	}

	// Token: 0x0600A25F RID: 41567 RVA: 0x002ACFC0 File Offset: 0x002AB1C0
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
	}

	// Token: 0x0600A260 RID: 41568 RVA: 0x002ACFDC File Offset: 0x002AB1DC
	protected override UniTask OnBeforeStartAsync()
	{
		WheelTowerPrepareView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerPrepareView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A261 RID: 41569 RVA: 0x002AD01F File Offset: 0x002AB21F
	protected override void OnBeforeShow()
	{
		WheelTowerBossHandBookButtonItem bossHandBookButtonItem = this.BossHandBookButtonItem;
		if (bossHandBookButtonItem != null)
		{
			bossHandBookButtonItem.RefreshRedDot();
		}
		this.RefreshView();
		ControllerBase<WheelTowerController>.Instance.TryOpenOverridePopupView(delegate
		{
			WheelTowerModel instance = ModelBase<WheelTowerModel>.Instance;
			instance.UpdateSelectRound(instance.SelectedRound, true);
			this.RefreshView();
		});
	}

	// Token: 0x0600A262 RID: 41570 RVA: 0x002AD050 File Offset: 0x002AB250
	private void InitSkillBranch()
	{
		ModelBase<RoleModel>.Instance.StartGamePlayRoleEdit(ESkillBranchCacheType.WheelTower);
		EnergyInfo selectedEnergyInfo = ModelBase<WheelTowerModel>.Instance.SelectedEnergyInfo;
		foreach (int num in ModelBase<WheelTowerModel>.Instance.SelectedRoleList)
		{
			int num2;
			int branchId = selectedEnergyInfo.SkillBranchMap.TryGetValue(num, out num2) ? num2 : 0;
			ModelBase<RoleModel>.Instance.SetRoleSkillBranchGamePlayCache(num, branchId, ESkillBranchCacheType.WheelTower);
		}
	}

	// Token: 0x0600A263 RID: 41571 RVA: 0x002AD0DC File Offset: 0x002AB2DC
	private void RefreshView()
	{
		WheelTowerModel instance = ModelBase<WheelTowerModel>.Instance;
		int totalScore = instance.GetTotalScore();
		UUIText text = base.GetText(4);
		if (text != null)
		{
			text.SetText(totalScore.ToString(), true);
		}
		this.RefreshScoreLevel((int)instance.GetTotalScoreLevel(totalScore, null, null));
		int selectedRound = instance.SelectedRound;
		int roundScore = instance.GetRoundScore(selectedRound);
		UUIText text2 = base.GetText(5);
		if (text2 != null)
		{
			text2.SetText(roundScore.ToString(), true);
		}
		bool endlessMode = instance.EndlessMode;
		UUIText text3 = base.GetText(6);
		if (text3 != null)
		{
			text3.SetUIActive(endlessMode);
		}
		int roundBossRound = instance.GetRoundBossRound(selectedRound);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "WheelTower_Endless_CurProgress", new <>z__ReadOnlySingleElementList<object>(roundBossRound));
		string textStringId = endlessMode ? "WheelTower_BossListTitle_Endless" : "WheelTower_BossListTitle_Normal";
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), textStringId, Array.Empty<object>());
		this.RefreshSelectData();
		this.RefreshBossList();
	}

	// Token: 0x0600A264 RID: 41572 RVA: 0x002AD1D8 File Offset: 0x002AB3D8
	private void RefreshScoreLevel(int scoreLevel)
	{
		NewTowerScoreLevel? scoreLevelConfigById = ConfigBase<WheelTowerConfig>.Instance.GetScoreLevelConfigById(scoreLevel);
		if (scoreLevelConfigById == null)
		{
			return;
		}
		base.SetTextureByPath(scoreLevelConfigById.Value.Icon, base.GetTexture(3), null, null);
		UUITexture texture = base.GetTexture(15);
		if (texture != null)
		{
			texture.SetColor(FColor.FromHex(scoreLevelConfigById.Value.CircleColor));
		}
		UUITexture texture2 = base.GetTexture(16);
		if (texture2 != null)
		{
			texture2.SetColor(FColor.FromHex(scoreLevelConfigById.Value.CircleColor));
		}
		UUITexture texture3 = base.GetTexture(17);
		if (texture3 != null)
		{
			texture3.SetColor(FColor.FromHex(scoreLevelConfigById.Value.BgColor));
		}
		UUITexture texture4 = base.GetTexture(18);
		if (texture4 != null)
		{
			texture4.SetColor(FColor.FromHex(scoreLevelConfigById.Value.BgLightColor));
		}
		bool flag = scoreLevel == 7;
		UUITexture texture5 = base.GetTexture(18);
		if (texture5 != null)
		{
			texture5.SetUIActive(!flag);
		}
		UUITexture texture6 = base.GetTexture(19);
		if (texture6 != null)
		{
			texture6.SetUIActive(flag);
		}
		UUIText text = base.GetText(4);
		if (text == null)
		{
			return;
		}
		text.SetColor(FColor.FromHex(scoreLevelConfigById.Value.TextColor));
	}

	// Token: 0x0600A265 RID: 41573 RVA: 0x002AD314 File Offset: 0x002AB514
	private void RefreshSelectData()
	{
		List<int> selectedRoleList = ModelBase<WheelTowerModel>.Instance.SelectedRoleList;
		List<RoleDataWithBranch> list = new List<RoleDataWithBranch>();
		for (int i = 0; i < ModelBase<WheelTowerModel>.Instance.GetTeamMaxRoleCount(); i++)
		{
			list.Add(new RoleDataWithBranch(0, 0));
		}
		for (int j = 0; j < selectedRoleList.Count; j++)
		{
			int roleId = selectedRoleList[j];
			int roleSkillBranchIdInCurrentGamePlay = ModelBase<RoleModel>.Instance.GetRoleSkillBranchIdInCurrentGamePlay(roleId);
			list[j] = new RoleDataWithBranch(roleId, roleSkillBranchIdInCurrentGamePlay);
		}
		WheelTowerTeamInfoPanel teamInfoPanel = this.TeamInfoPanel;
		if (teamInfoPanel != null)
		{
			teamInfoPanel.RefreshRoleList(list);
		}
		WheelTowerTeamInfoPanel teamInfoPanel2 = this.TeamInfoPanel;
		if (teamInfoPanel2 != null)
		{
			teamInfoPanel2.RefreshBuff(ModelBase<WheelTowerModel>.Instance.SelectedBuff);
		}
		this.UpdateSkillBranchBtn();
		bool flag = ModelBase<WheelTowerModel>.Instance.CheckSelectTeamIsFull();
		bool flag2 = ModelBase<WheelTowerModel>.Instance.CheckSelectedIsConflict();
		UUIButtonComponent button = base.GetButton(13);
		if (button != null)
		{
			button.SetSelfInteractive(flag && !flag2);
		}
		int num = (selectedRoleList.Count > 0) ? ModelBase<WheelTowerModel>.Instance.GetRoleCost(selectedRoleList[0]) : ModelBase<WheelTowerModel>.Instance.GetTowerConfig().DefaultCostEnergy;
		UUIText text = base.GetText(22);
		if (text == null)
		{
			return;
		}
		text.SetText(num.ToString(), true);
	}

	// Token: 0x0600A266 RID: 41574 RVA: 0x002AD448 File Offset: 0x002AB648
	private void RefreshBossList()
	{
		int selectedRound = ModelBase<WheelTowerModel>.Instance.SelectedRound;
		List<IBossInfo> bossList = ModelBase<WheelTowerModel>.Instance.GetRoundBossInfo(selectedRound, null);
		List<IBossInfo> prevRoundBossInfo = ModelBase<WheelTowerModel>.Instance.GetPrevRoundBossInfo(selectedRound);
		List<IBossItemData> list = new List<IBossItemData>();
		for (int i = 0; i < bossList.Count; i++)
		{
			list.Add(new BossItemData
			{
				BossInfo = bossList[i],
				StartPercent = new float?((float)prevRoundBossInfo[i].HpPercentage)
			});
		}
		int currentChallengeIndex = bossList.FindIndex((IBossInfo info) => info.HpPercentage > 0.0);
		if (currentChallengeIndex < 0)
		{
			currentChallengeIndex = bossList.Count - 1;
		}
		GenericScrollViewNew<WheelTowerSmallBossItem, IBossItemData> bossScrollView = this.BossScrollView;
		if (bossScrollView != null)
		{
			bossScrollView.SelectGridProxy(-1, false);
		}
		GenericScrollViewNew<WheelTowerSmallBossItem, IBossItemData> bossScrollView2 = this.BossScrollView;
		if (bossScrollView2 == null)
		{
			return;
		}
		bossScrollView2.RefreshByData(list, delegate
		{
			if (currentChallengeIndex >= 0 && currentChallengeIndex < bossList.Count)
			{
				this.BossToggleClick(currentChallengeIndex, bossList[currentChallengeIndex].WaveConfigId);
			}
		}, false);
	}

	// Token: 0x0600A267 RID: 41575 RVA: 0x002AD568 File Offset: 0x002AB768
	private void RefreshBossInfo(int bossId)
	{
		ModelBase<WheelTowerModel>.Instance.SelectedBossId = bossId;
		NewTowerWave? waveConfigById = ConfigBase<WheelTowerConfig>.Instance.GetWaveConfigById(bossId);
		if (waveConfigById == null)
		{
			return;
		}
		base.SetTextureByPath(waveConfigById.Value.MonsterPortrait, base.GetTexture(1), null, null);
		WheelTowerBossAttrItem attrItem = this.AttrItem;
		if (attrItem != null)
		{
			attrItem.Refresh(new WheelTowerBossAttrData
			{
				AttrName = waveConfigById.Value.Name,
				AttrLevel = waveConfigById.Value.MonsterLevel,
				ElementId = waveConfigById.Value.ElementId,
				TagIdList = (waveConfigById.Value.GetTagIdListArray() ?? Array.Empty<int>()).ToList<int>()
			});
		}
		GenericLayout<WheelTowerBossBuffSmallItem, int> bossBuffLayout = this.BossBuffLayout;
		if (bossBuffLayout != null)
		{
			bossBuffLayout.RefreshByData((waveConfigById.Value.GetShowBuffIdsArray() ?? Array.Empty<int>()).ToList<int>(), null, false);
		}
		GenericLayout<WheelTowerTeamFeatureItem, int> teamFeatureLayout = this.TeamFeatureLayout;
		if (teamFeatureLayout != null)
		{
			teamFeatureLayout.RefreshByData((waveConfigById.Value.GetRecommendTeamFeatureArray() ?? Array.Empty<int>()).ToList<int>(), null, false);
		}
		this.UpdateMultiDesc();
	}

	// Token: 0x0600A268 RID: 41576 RVA: 0x002AD69C File Offset: 0x002AB89C
	private void UpdateMultiDesc()
	{
		int selectedBossId = ModelBase<WheelTowerModel>.Instance.SelectedBossId;
		if (selectedBossId <= 0)
		{
			UUIItem item = base.GetItem(27);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
			return;
		}
		else
		{
			NewTowerWave? waveConfigById = ConfigBase<WheelTowerConfig>.Instance.GetWaveConfigById(selectedBossId);
			if (waveConfigById != null)
			{
				float damegaRateShow = waveConfigById.Value.DamegaRateShow;
				bool flag = damegaRateShow > 0f;
				UUIItem item2 = base.GetItem(27);
				if (item2 != null)
				{
					item2.SetUIActive(flag);
				}
				if (flag)
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(28), "NewTower_Scorept", new <>z__ReadOnlySingleElementList<object>(damegaRateShow.ToString("F2")));
				}
				return;
			}
			UUIItem item3 = base.GetItem(27);
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(false);
			return;
		}
	}

	// Token: 0x0600A269 RID: 41577 RVA: 0x002AD750 File Offset: 0x002AB950
	private void OnCloseBtnClick()
	{
		if (ControllerBase<GameModeController>.Instance.IsInInstance() && !Singleton<UiManager>.Instance.IsViewHide(EUiViewName.WheelTowerModeDetailView))
		{
			Singleton<UiManager>.Instance.CloseAndOpenView(this.ViewInfo.Name, EUiViewName.WheelTowerModeDetailView, null, null, true);
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x0600A26A RID: 41578 RVA: 0x002AD7A0 File Offset: 0x002AB9A0
	private void OnStartBtnClick()
	{
		WheelTowerModel instance = ModelBase<WheelTowerModel>.Instance;
		if (!instance.CheckSelectedRoleEnergyEnough())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("WheelBattleTips_NoFatiguevalue", Array.Empty<object>());
			return;
		}
		if (!instance.CheckBuffIsSelected())
		{
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(new ConfirmBoxDataNew(EConfirmBoxConfigId.WheelTowerTeamBuffNotSelectTips));
			return;
		}
		if (instance.CheckSelectedIsConflict())
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.WheelTowerSelectConflictConfirm);
			confirmBoxDataNew.FunctionMap[2] = new Action(this.RequestChallenge);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		this.RequestChallenge();
	}

	// Token: 0x0600A26B RID: 41579 RVA: 0x002AD82C File Offset: 0x002ABA2C
	private void RequestChallenge()
	{
		ModelBase<RoleModel>.Instance.ClearGamePlayRoleEdit(ESkillBranchCacheType.WheeTowerLoading);
		foreach (int roleId in ModelBase<WheelTowerModel>.Instance.SelectedRoleList)
		{
			int roleSkillBranchIdInCurrentGamePlay = ModelBase<RoleModel>.Instance.GetRoleSkillBranchIdInCurrentGamePlay(roleId);
			ModelBase<RoleModel>.Instance.SetRoleSkillBranchGamePlayCache(roleId, roleSkillBranchIdInCurrentGamePlay, ESkillBranchCacheType.WheeTowerLoading);
		}
		ControllerBase<WheelTowerController>.Instance.RequestSelectedRoundChallenge();
	}

	// Token: 0x0600A26C RID: 41580 RVA: 0x002AD8AC File Offset: 0x002ABAAC
	private void BossToggleClick(int index, int bossId)
	{
		GenericScrollViewNew<WheelTowerSmallBossItem, IBossItemData> bossScrollView = this.BossScrollView;
		if (bossScrollView != null)
		{
			bossScrollView.SelectGridProxy(index, false);
		}
		this.RefreshBossInfo(bossId);
		WheelTowerModel instance = ModelBase<WheelTowerModel>.Instance;
		WheelTowerBossHandBookButtonItem bossHandBookButtonItem = this.BossHandBookButtonItem;
		if (bossHandBookButtonItem == null)
		{
			return;
		}
		bossHandBookButtonItem.SetJumpInfo(bossId, instance.SelectedRound, instance.EndlessMode);
	}

	// Token: 0x0600A26D RID: 41581 RVA: 0x002AD8F6 File Offset: 0x002ABAF6
	private void OnClickTeamItem()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerTeamSelectView, null, delegate(bool isSuccess, int viewId)
		{
			if (isSuccess)
			{
				base.AddChildViewById(viewId);
			}
		});
	}

	// Token: 0x0600A26E RID: 41582 RVA: 0x002AD914 File Offset: 0x002ABB14
	private void OnCloseView(EUiViewName viewName, int viewId)
	{
		if (viewName == EUiViewName.WheelTowerTeamSelectView || viewName == EUiViewName.WheelTowerRecommendView || viewName == EUiViewName.RoleSkillBranchPopView)
		{
			this.RefreshSelectData();
		}
	}

	// Token: 0x0600A26F RID: 41583 RVA: 0x002AD943 File Offset: 0x002ABB43
	private WheelTowerSmallBossItem CreateBossItem()
	{
		WheelTowerSmallBossItem wheelTowerSmallBossItem = new WheelTowerSmallBossItem();
		wheelTowerSmallBossItem.SetClickCallback(new Action<int, int>(this.BossToggleClick));
		return wheelTowerSmallBossItem;
	}

	// Token: 0x0600A270 RID: 41584 RVA: 0x002AD95C File Offset: 0x002ABB5C
	private void AddHomeBtnExtraCallback()
	{
		UiBehaviourHomeBtn uiBehaviourHomeBtn = this.UiBehaviourHomeBtn;
		if (uiBehaviourHomeBtn == null)
		{
			return;
		}
		uiBehaviourHomeBtn.AddExtraAsyncCallback(delegate
		{
			WheelTowerPrepareView.<>c.<<AddHomeBtnExtraCallback>b__30_0>d <<AddHomeBtnExtraCallback>b__30_0>d;
			<<AddHomeBtnExtraCallback>b__30_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<AddHomeBtnExtraCallback>b__30_0>d.<>1__state = -1;
			<<AddHomeBtnExtraCallback>b__30_0>d.<>t__builder.Start<WheelTowerPrepareView.<>c.<<AddHomeBtnExtraCallback>b__30_0>d>(ref <<AddHomeBtnExtraCallback>b__30_0>d);
			return <<AddHomeBtnExtraCallback>b__30_0>d.<>t__builder.Task;
		});
	}

	// Token: 0x0600A271 RID: 41585 RVA: 0x002AD990 File Offset: 0x002ABB90
	private void OnBtnSkillBranchPopClick()
	{
		RoleSkillBranchPopViewParams param = this.BuildSkillBranchPopViewParams();
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleSkillBranchPopView, param, null);
	}

	// Token: 0x0600A272 RID: 41586 RVA: 0x002AD9B8 File Offset: 0x002ABBB8
	private RoleSkillBranchPopViewParams BuildSkillBranchPopViewParams()
	{
		RoleSkillBranchPopViewParams roleSkillBranchPopViewParams = new RoleSkillBranchPopViewParams();
		roleSkillBranchPopViewParams.Load(new int[][]
		{
			ModelBase<WheelTowerModel>.Instance.SelectedRoleList.ToArray()
		});
		return roleSkillBranchPopViewParams;
	}

	// Token: 0x0600A273 RID: 41587 RVA: 0x002AD9EA File Offset: 0x002ABBEA
	private bool CheckHasSkillBranchInRoleEdit()
	{
		return ModelBase<WheelTowerModel>.Instance.SelectedRoleList.Any((int roleId) => ModelBase<RoleModel>.Instance.GetRoleSkillBranchIndexInCurrentGamePlay(roleId) > -1);
	}

	// Token: 0x0600A274 RID: 41588 RVA: 0x002ADA1C File Offset: 0x002ABC1C
	private void UpdateSkillBranchBtn()
	{
		UUIItem uuiitem = base.GetButton(23).RootUIComp.Get();
		if (uuiitem == null)
		{
			return;
		}
		uuiitem.SetUIActive(this.CheckHasSkillBranchInRoleEdit());
	}

	// Token: 0x04004CB8 RID: 19640
	private const string NormalTeamBgLightPath = "/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/MowingTower/LevelMode/Normal/T_LevelModeNormalTeamBgLight.T_LevelModeNormalTeamBgLight";

	// Token: 0x04004CB9 RID: 19641
	private const string EndlessTeamBgLightPath = "/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/MowingTower/LevelMode/Endless/T_LevelModeEndlessTeamBgLight.T_LevelModeEndlessTeamBgLight";

	// Token: 0x04004CBA RID: 19642
	private const string TEXT_SCORE_MULTI_DESC = "NewTower_Scorept";

	// Token: 0x04004CBB RID: 19643
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04004CBC RID: 19644
	[Nullable(2)]
	private WheelTowerBossAttrItem AttrItem;

	// Token: 0x04004CBD RID: 19645
	[Nullable(2)]
	private WheelTowerTeamInfoPanel TeamInfoPanel;

	// Token: 0x04004CBE RID: 19646
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<WheelTowerSmallBossItem, IBossItemData> BossScrollView;

	// Token: 0x04004CBF RID: 19647
	[Nullable(2)]
	private WheelTowerBossHandBookButtonItem BossHandBookButtonItem;

	// Token: 0x04004CC0 RID: 19648
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<WheelTowerBossBuffSmallItem, int> BossBuffLayout;

	// Token: 0x04004CC1 RID: 19649
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<WheelTowerTeamFeatureItem, int> TeamFeatureLayout;
}
