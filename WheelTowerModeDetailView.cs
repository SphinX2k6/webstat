using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020016D0 RID: 5840
[NullableContext(2)]
[Nullable(0)]
public class WheelTowerModeDetailView : UiViewBase
{
	// Token: 0x0600A215 RID: 41493 RVA: 0x002AAB1C File Offset: 0x002A8D1C
	[NullableContext(1)]
	public WheelTowerModeDetailView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600A216 RID: 41494 RVA: 0x002AAB28 File Offset: 0x002A8D28
	protected unsafe override void OnRegisterComponent()
	{
		int num = 30;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(26, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(27, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(28, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(29, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.OnRecordBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnRankLevelRuleBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(15, new Action(this.OnResetBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A217 RID: 41495 RVA: 0x002AAFC8 File Offset: 0x002A91C8
	protected override UniTask OnBeforeStartAsync()
	{
		WheelTowerModeDetailView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerModeDetailView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A218 RID: 41496 RVA: 0x002AB00B File Offset: 0x002A920B
	protected override void OnBeforeShow()
	{
		WheelTowerBossHandBookButtonItem bossHandBookButtonItem = this.BossHandBookButtonItem;
		if (bossHandBookButtonItem != null)
		{
			bossHandBookButtonItem.RefreshRedDot();
		}
		this.RefreshDefaultRound();
	}

	// Token: 0x0600A219 RID: 41497 RVA: 0x002AB024 File Offset: 0x002A9224
	[return: Nullable(new byte[]
	{
		1,
		2
	})]
	private List<TeamChallengeInfo> GetTeamList()
	{
		List<TeamChallengeInfo> list = ModelBase<WheelTowerModel>.Instance.GetCurrentLevelRecord(null).TeamChallengeInfos.Cast<TeamChallengeInfo>().ToList<TeamChallengeInfo>();
		if (ModelBase<WheelTowerModel>.Instance.EndlessMode)
		{
			list.Add(null);
			return list;
		}
		while (list.Count < 3)
		{
			list.Add(null);
		}
		return list;
	}

	// Token: 0x0600A21A RID: 41498 RVA: 0x002AB07C File Offset: 0x002A927C
	private void UpdateShareBtnItem()
	{
		if (this.ShareBtnItem == null)
		{
			return;
		}
		bool flag = ModelBase<WheelTowerModel>.Instance.GetTotalScore() != 0 && ModelBase<WheelTowerModel>.Instance.EndlessMode;
		ShareBtnItem shareBtnItem = this.ShareBtnItem;
		if (shareBtnItem != null)
		{
			shareBtnItem.SetUiActive(flag);
		}
		if (flag)
		{
			this.ShareBtnItem.SetShareActionId(EShareActionId.WheelTowerTotalScore);
			this.ShareBtnItem.SetClickCallBack(delegate
			{
				PhotoSaveViewParam param = new PhotoSaveViewParam
				{
					ScreenShot = false,
					IsHiddenBattleView = false,
					ShareId = 11
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.PhotoSaveView, param, null);
			});
		}
	}

	// Token: 0x0600A21B RID: 41499 RVA: 0x002AB0F8 File Offset: 0x002A92F8
	private void RefreshDefaultRound()
	{
		int maxChallengeRound = ModelBase<WheelTowerModel>.Instance.GetMaxChallengeRound(null);
		int round = maxChallengeRound;
		object openParam = this.OpenParam;
		if (openParam is int)
		{
			int value = (int)openParam;
			round = Math.Clamp(value, 0, maxChallengeRound);
		}
		this.RefreshRound(round, true);
	}

	// Token: 0x0600A21C RID: 41500 RVA: 0x002AB148 File Offset: 0x002A9348
	private void RefreshRound(int round, bool force = true)
	{
		WheelTowerModel instance = ModelBase<WheelTowerModel>.Instance;
		if (!force && round == instance.SelectedRound)
		{
			return;
		}
		instance.UpdateSelectRound(round, force);
		List<TeamChallengeInfo> teamList = this.GetTeamList();
		GenericScrollViewNew<WheelTowerNewTeamItem, TeamChallengeInfo> teamScrollView = this.TeamScrollView;
		if (teamScrollView != null)
		{
			teamScrollView.SelectGridProxy(-1, false);
		}
		GenericScrollViewNew<WheelTowerNewTeamItem, TeamChallengeInfo> teamScrollView2 = this.TeamScrollView;
		if (teamScrollView2 != null)
		{
			teamScrollView2.RefreshByData(teamList, delegate
			{
				GenericScrollViewNew<WheelTowerNewTeamItem, TeamChallengeInfo> teamScrollView3 = this.TeamScrollView;
				if (teamScrollView3 != null)
				{
					teamScrollView3.SelectGridProxy(round, false);
				}
				GenericScrollViewNew<WheelTowerNewTeamItem, TeamChallengeInfo> teamScrollView4 = this.TeamScrollView;
				UUIItem uuiitem = (teamScrollView4 != null) ? teamScrollView4.GetItemByIndex(round) : null;
				if (uuiitem != null)
				{
					GenericScrollViewNew<WheelTowerNewTeamItem, TeamChallengeInfo> teamScrollView5 = this.TeamScrollView;
					if (teamScrollView5 == null)
					{
						return;
					}
					teamScrollView5.LateScrollTo(uuiitem, null, false);
				}
			}, false);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "WheelTower_RoundSelect_ScoreTitle", new <>z__ReadOnlySingleElementList<object>(round + 1));
		int roundTotalScore = instance.GetRoundTotalScore(round);
		UUIText text = base.GetText(4);
		if (text != null)
		{
			text.SetText(roundTotalScore.ToString(), true);
		}
		EScoreLevel totalScoreLevel = instance.GetTotalScoreLevel(roundTotalScore, null, null);
		this.RefreshScoreLevel((int)totalScoreLevel);
		ValueTuple<int, int> scoreRange = instance.GetScoreRange(roundTotalScore);
		UUIText text2 = base.GetText(6);
		if (text2 != null)
		{
			text2.SetText(scoreRange.Item2.ToString(), true);
		}
		float fillAmount = (scoreRange.Item2 == scoreRange.Item1) ? 1f : ((float)(roundTotalScore - scoreRange.Item1) / (float)(scoreRange.Item2 - scoreRange.Item1));
		UUISprite sprite = base.GetSprite(7);
		if (sprite != null)
		{
			sprite.SetFillAmount(fillAmount);
		}
		this.RefreshBossList(round);
		this.RefreshButton(round);
		this.UpdateShareBtnItem();
	}

	// Token: 0x0600A21D RID: 41501 RVA: 0x002AB2CC File Offset: 0x002A94CC
	private void RefreshScoreLevel(int scoreLevel)
	{
		NewTowerScoreLevel? scoreLevelConfigById = ConfigBase<WheelTowerConfig>.Instance.GetScoreLevelConfigById(scoreLevel);
		if (scoreLevelConfigById == null)
		{
			return;
		}
		base.SetTextureByPath(scoreLevelConfigById.Value.Icon, base.GetTexture(2), null, null);
		UUITexture texture = base.GetTexture(17);
		if (texture != null)
		{
			texture.SetColor(FColor.FromHex(scoreLevelConfigById.Value.GridColor));
		}
		UUITexture texture2 = base.GetTexture(18);
		if (texture2 != null)
		{
			texture2.SetColor(FColor.FromHex(scoreLevelConfigById.Value.CircleColor));
		}
		UUITexture texture3 = base.GetTexture(19);
		if (texture3 != null)
		{
			texture3.SetColor(FColor.FromHex(scoreLevelConfigById.Value.CircleColor));
		}
		UUITexture texture4 = base.GetTexture(20);
		if (texture4 != null)
		{
			texture4.SetColor(FColor.FromHex(scoreLevelConfigById.Value.BgColor));
		}
		UUITexture texture5 = base.GetTexture(21);
		if (texture5 != null)
		{
			texture5.SetColor(FColor.FromHex(scoreLevelConfigById.Value.BgLightColor));
		}
		bool flag = scoreLevel == 7;
		UUITexture texture6 = base.GetTexture(21);
		if (texture6 != null)
		{
			texture6.SetUIActive(!flag);
		}
		UUITexture texture7 = base.GetTexture(22);
		if (texture7 == null)
		{
			return;
		}
		texture7.SetUIActive(flag);
	}

	// Token: 0x0600A21E RID: 41502 RVA: 0x002AB408 File Offset: 0x002A9608
	private void RefreshBossList(int round)
	{
		WheelTowerModel model = ModelBase<WheelTowerModel>.Instance;
		List<IBossInfo> bossList = model.GetRoundBossInfo(round, null);
		ValueTuple<int, int> bossProgress = model.GetBossProgress(round, null);
		if (model.EndlessMode)
		{
			MonsterInfoPreview bossInfoByRound = model.GetBossInfoByRound(round, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "WheelTower_Endless_CurProgress", new <>z__ReadOnlyArray<object>(new object[]
			{
				bossInfoByRound.Round,
				bossProgress.Item1,
				bossProgress.Item2
			}));
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "WheelTower_BossProgress_Normal", new <>z__ReadOnlyArray<object>(new object[]
			{
				bossProgress.Item1,
				bossProgress.Item2
			}));
		}
		List<IBossInfo> prevRoundBossInfo = model.GetPrevRoundBossInfo(round);
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
			GenericScrollViewNew<WheelTowerSmallBossItem, IBossItemData> bossScrollView3 = this.BossScrollView;
			if (bossScrollView3 != null)
			{
				bossScrollView3.SelectGridProxy(currentChallengeIndex, false);
			}
			if (currentChallengeIndex >= 0 && currentChallengeIndex < bossList.Count)
			{
				WheelTowerBossHandBookButtonItem bossHandBookButtonItem = this.BossHandBookButtonItem;
				if (bossHandBookButtonItem == null)
				{
					return;
				}
				bossHandBookButtonItem.SetJumpInfo(bossList[currentChallengeIndex].WaveConfigId, model.SelectedRound, model.EndlessMode);
			}
		}, false);
	}

	// Token: 0x0600A21F RID: 41503 RVA: 0x002AB5F4 File Offset: 0x002A97F4
	private void RefreshButton(int round)
	{
		WheelTowerModel instance = ModelBase<WheelTowerModel>.Instance;
		bool uiactive = instance.HasChallengeAnyRound(null);
		UUIItem uuiitem = base.GetButton(15).RootUIComp.Get();
		if (uuiitem != null)
		{
			uuiitem.SetUIActive(uiactive);
		}
		bool flag = instance.IsRoundChallenged(round, null);
		ButtonItem goButton = this.GoButton;
		if (goButton != null)
		{
			goButton.SetLocalTextNew(flag ? "WheelTower_RoundSelect_Retry" : "WheelTower_RoundSelect_Start", Array.Empty<object>());
		}
		bool enableClick = instance.IsTeamRoundCanChallenge(round);
		ButtonItem goButton2 = this.GoButton;
		if (goButton2 != null)
		{
			goButton2.SetEnableClick(enableClick);
		}
		UUIItem item = base.GetItem(13);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(flag);
	}

	// Token: 0x0600A220 RID: 41504 RVA: 0x002AB69A File Offset: 0x002A989A
	private void BossToggleClick(int index, int bossId)
	{
		GenericScrollViewNew<WheelTowerSmallBossItem, IBossItemData> bossScrollView = this.BossScrollView;
		if (bossScrollView == null)
		{
			return;
		}
		bossScrollView.SelectGridProxy(index, false);
	}

	// Token: 0x0600A221 RID: 41505 RVA: 0x002AB6B0 File Offset: 0x002A98B0
	private void TeamToggleClick(int round)
	{
		base.PlayOrReplaySequence("Switch", false, null);
		this.RefreshRound(round, true);
	}

	// Token: 0x0600A222 RID: 41506 RVA: 0x002AB6DC File Offset: 0x002A98DC
	private void OnCloseBtnClick()
	{
		if (ControllerBase<GameModeController>.Instance.IsInInstance() && !Singleton<UiManager>.Instance.IsViewHide(EUiViewName.WheelTowerMainView))
		{
			Singleton<UiManager>.Instance.CloseAndOpenView(this.ViewInfo.Name, EUiViewName.WheelTowerMainView, null, null, true);
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x0600A223 RID: 41507 RVA: 0x002AB72B File Offset: 0x002A992B
	private void OnRecordBtnClick()
	{
		if (ModelBase<WheelTowerModel>.Instance.GetTotalScore() == 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("WheelTower_NoRecord", Array.Empty<object>());
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerRecordView, null, null);
	}

	// Token: 0x0600A224 RID: 41508 RVA: 0x002AB75F File Offset: 0x002A995F
	private void OnRankLevelRuleBtnClick()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerScoreLevelRuleView, null, null);
	}

	// Token: 0x0600A225 RID: 41509 RVA: 0x002AB774 File Offset: 0x002A9974
	private void OnResetBtnClick()
	{
		if (!ModelBase<WheelTowerModel>.Instance.HasChallengeAnyRound(null))
		{
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.WheelTowerRoundResetAllConfirm);
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			NewTowerClimbingLevelRecord currentLevelRecord = ModelBase<WheelTowerModel>.Instance.GetCurrentLevelRecord(null);
			ControllerBase<WheelTowerController>.Instance.RequestResetLevelRecord(currentLevelRecord.LevelId).ContinueWith(new Action(this.RefreshDefaultRound)).Forget();
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600A226 RID: 41510 RVA: 0x002AB7C8 File Offset: 0x002A99C8
	private void OnContinueBtnClick()
	{
		WheelTowerModel instance = ModelBase<WheelTowerModel>.Instance;
		if (instance.IsRoundChallenged(instance.SelectedRound, null))
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.WheelTowerReChallengeConfirm);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerPrepareView, null, null);
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerPrepareView, null, null);
	}

	// Token: 0x0600A227 RID: 41511 RVA: 0x002AB844 File Offset: 0x002A9A44
	[NullableContext(1)]
	private WheelTowerSmallBossItem CreateBossItem()
	{
		WheelTowerSmallBossItem wheelTowerSmallBossItem = new WheelTowerSmallBossItem();
		wheelTowerSmallBossItem.IsSmall = true;
		wheelTowerSmallBossItem.SetClickCallback(new Action<int, int>(this.BossToggleClick));
		return wheelTowerSmallBossItem;
	}

	// Token: 0x0600A228 RID: 41512 RVA: 0x002AB864 File Offset: 0x002A9A64
	[NullableContext(1)]
	private WheelTowerNewTeamItem CreateTeamItem()
	{
		return new WheelTowerNewTeamItem
		{
			OnToggleCallback = new Action<int>(this.TeamToggleClick)
		};
	}

	// Token: 0x0600A229 RID: 41513 RVA: 0x002AB87D File Offset: 0x002A9A7D
	private void AddHomeBtnExtraCallback()
	{
		UiBehaviourHomeBtn uiBehaviourHomeBtn = this.UiBehaviourHomeBtn;
		if (uiBehaviourHomeBtn == null)
		{
			return;
		}
		uiBehaviourHomeBtn.AddExtraAsyncCallback(delegate
		{
			WheelTowerModeDetailView.<>c.<<AddHomeBtnExtraCallback>b__27_0>d <<AddHomeBtnExtraCallback>b__27_0>d;
			<<AddHomeBtnExtraCallback>b__27_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<AddHomeBtnExtraCallback>b__27_0>d.<>1__state = -1;
			<<AddHomeBtnExtraCallback>b__27_0>d.<>t__builder.Start<WheelTowerModeDetailView.<>c.<<AddHomeBtnExtraCallback>b__27_0>d>(ref <<AddHomeBtnExtraCallback>b__27_0>d);
			return <<AddHomeBtnExtraCallback>b__27_0>d.<>t__builder.Task;
		});
	}

	// Token: 0x04004C5B RID: 19547
	private const int NormalModeTeamMaxNum = 3;

	// Token: 0x04004C5C RID: 19548
	private PopupCaptionItem CaptionItem;

	// Token: 0x04004C5D RID: 19549
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<WheelTowerSmallBossItem, IBossItemData> BossScrollView;

	// Token: 0x04004C5E RID: 19550
	[Nullable(new byte[]
	{
		2,
		1,
		2
	})]
	private GenericScrollViewNew<WheelTowerNewTeamItem, TeamChallengeInfo> TeamScrollView;

	// Token: 0x04004C5F RID: 19551
	private ButtonItem GoButton;

	// Token: 0x04004C60 RID: 19552
	private WheelTowerBossHandBookButtonItem BossHandBookButtonItem;

	// Token: 0x04004C61 RID: 19553
	private ShareBtnItem ShareBtnItem;
}
