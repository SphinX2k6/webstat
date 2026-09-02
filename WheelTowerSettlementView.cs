using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using AkiClient.Game.Aki.Scene.NewGacha.BP;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020016FF RID: 5887
[NullableContext(2)]
[Nullable(0)]
public class WheelTowerSettlementView : UiViewBase
{
	// Token: 0x0600A313 RID: 41747 RVA: 0x002B0FC4 File Offset: 0x002AF1C4
	[NullableContext(1)]
	public WheelTowerSettlementView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600A314 RID: 41748 RVA: 0x002B0FD4 File Offset: 0x002AF1D4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 13;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A315 RID: 41749 RVA: 0x002B11AD File Offset: 0x002AF3AD
	protected override void OnBeforeCreate()
	{
		this.GachaSequence = new UiBehaviorGachaSequence();
		base.AddUiBehavior(this.GachaSequence);
	}

	// Token: 0x0600A316 RID: 41750 RVA: 0x002B11C8 File Offset: 0x002AF3C8
	protected override UniTask OnBeforeStartAsync()
	{
		WheelTowerSettlementView.<OnBeforeStartAsync>d__21 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerSettlementView.<OnBeforeStartAsync>d__21>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A317 RID: 41751 RVA: 0x002B120C File Offset: 0x002AF40C
	private void UpdateShareBtnItem()
	{
		if (this.DataInternal == null || this.ShareBtnItem == null)
		{
			return;
		}
		ShareBtnItem shareBtnItem = this.ShareBtnItem;
		if (shareBtnItem != null)
		{
			shareBtnItem.SetUiActive(this.DataInternal.EndlessMode);
		}
		if (this.DataInternal.EndlessMode)
		{
			this.ShareBtnItem.SetShareActionId(EShareActionId.WheelTowerRoundScore);
			this.ShareBtnItem.SetClickCallBack(delegate
			{
				PhotoSaveViewParam param = new PhotoSaveViewParam
				{
					ScreenShot = false,
					IsHiddenBattleView = false,
					ShareId = 12,
					WheelTowerSettlementViewData = this.DataInternal
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.PhotoSaveView, param, null);
			});
		}
	}

	// Token: 0x0600A318 RID: 41752 RVA: 0x002B1277 File Offset: 0x002AF477
	protected override void OnHandleLoadScene()
	{
		this.BindGachaSequenceSceneActors();
	}

	// Token: 0x0600A319 RID: 41753 RVA: 0x002B1280 File Offset: 0x002AF480
	protected override void OnBeforeShow()
	{
		this.TryPlayRoleSequence();
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence == null)
		{
			return;
		}
		uiViewSequence.PlaySequence("Start01", false, null);
	}

	// Token: 0x0600A31A RID: 41754 RVA: 0x002B12B2 File Offset: 0x002AF4B2
	protected override void OnBeforeDestroy()
	{
		LguiIntTween totalScoreTween = this.TotalScoreTween;
		if (totalScoreTween == null)
		{
			return;
		}
		totalScoreTween.Destroy();
	}

	// Token: 0x0600A31B RID: 41755 RVA: 0x002B12C4 File Offset: 0x002AF4C4
	private void TryPlayRoleSequence()
	{
		if (this.IsPlayingRoleSequence)
		{
			return;
		}
		if (this.SceneSequenceCamera == null)
		{
			this.BindGachaSequenceSceneActors();
		}
		if (this.SceneSequenceCamera == null)
		{
			return;
		}
		this.IsPlayingRoleSequence = true;
		this.GachaSequence.PlayRoleSequence(this.SequenceRoleId, 0);
	}

	// Token: 0x0600A31C RID: 41756 RVA: 0x002B1300 File Offset: 0x002AF500
	private void BindGachaSequenceSceneActors()
	{
		if (this.SceneSequenceCamera == null)
		{
			this.SceneSequenceCamera = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("SceneCamera1").Value, ECollectActorType.Default);
			if (this.SceneSequenceCamera != null)
			{
				this.GachaSequence.BindSceneSequenceCamera(this.SceneSequenceCamera);
			}
		}
		if (this.UpdateInteractBp == null)
		{
			this.UpdateInteractBp = (UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("UpdateInteractBP").Value, ECollectActorType.Default) as BP_UpdateInteract_C);
			if (this.UpdateInteractBp != null)
			{
				this.UpdateInteractBp.SetTickableWhenPaused(true);
				this.GachaSequence.BindUpdateInteractBp(this.UpdateInteractBp);
			}
		}
	}

	// Token: 0x0600A31D RID: 41757 RVA: 0x002B139C File Offset: 0x002AF59C
	private void BindTween()
	{
		this.TotalScoreTween = new LguiIntTween();
		this.TotalScoreTween.UpdateTween = delegate(int value)
		{
			int totalScoreLevel = (int)ModelBase<WheelTowerModel>.Instance.GetTotalScoreLevel(value, null, null);
			if (totalScoreLevel != this.LastScoreLevel)
			{
				this.LastScoreLevel = totalScoreLevel;
				UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
				if (uiViewSequence2 != null)
				{
					uiViewSequence2.PlaySequence("LevelUp", false, null);
				}
				WheelTowerSettlementScorePanel scorePanel = this.ScorePanel;
				if (scorePanel != null)
				{
					scorePanel.RefreshScoreLevel(totalScoreLevel);
				}
			}
			WheelTowerSettlementScorePanel scorePanel2 = this.ScorePanel;
			if (scorePanel2 == null)
			{
				return;
			}
			scorePanel2.RefreshTotalScore(value);
		};
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence == null)
		{
			return;
		}
		uiViewSequence.AddSequenceFinishEvent("Start01", new Action<string>(this.OnSequenceStartFinish), false);
	}

	// Token: 0x0600A31E RID: 41758 RVA: 0x002B13F0 File Offset: 0x002AF5F0
	[NullableContext(0)]
	private ValueTuple<int, int> GetBossRoundAndWave([Nullable(1)] List<IBossItemData> bossInfoList)
	{
		int num = 1;
		int item = 0;
		foreach (IBossItemData bossItemData in bossInfoList)
		{
			if (bossItemData.BossInfo.Round > num)
			{
				num = bossItemData.BossInfo.Round;
			}
			NewTowerWave? waveConfigById = ConfigBase<WheelTowerConfig>.Instance.GetWaveConfigById(bossItemData.BossInfo.WaveConfigId);
			if (waveConfigById != null)
			{
				item = waveConfigById.Value.Wave;
			}
		}
		return new ValueTuple<int, int>(num, item);
	}

	// Token: 0x0600A31F RID: 41759 RVA: 0x002B1490 File Offset: 0x002AF690
	private void UpdateSettlementInfo()
	{
		if (this.DataInternal == null)
		{
			return;
		}
		ValueTuple<int, int> bossRoundAndWave = this.GetBossRoundAndWave(this.DataInternal.BossInfoList);
		int item = bossRoundAndWave.Item1;
		int num = bossRoundAndWave.Item2 % this.DataInternal.MaxBossWaveNum;
		int curBossWave = (num != 0) ? num : this.DataInternal.MaxBossWaveNum;
		EScoreLevel totalScoreLevel = ModelBase<WheelTowerModel>.Instance.GetTotalScoreLevel(0, null, null);
		WheelTowerModeSettlementTitleItem modeTitleItem = this.ModeTitleItem;
		if (modeTitleItem != null)
		{
			modeTitleItem.Refresh(this.DataInternal.EndlessMode);
		}
		WheelTowerSettlementRoundPanel roundPanel = this.RoundPanel;
		if (roundPanel != null)
		{
			roundPanel.RefreshRoundScore(this.DataInternal.CurrentScore);
		}
		WheelTowerSettlementScorePanel scorePanel = this.ScorePanel;
		if (scorePanel != null)
		{
			scorePanel.RefreshTotalScore(0);
		}
		WheelTowerSettlementScorePanel scorePanel2 = this.ScorePanel;
		if (scorePanel2 != null)
		{
			scorePanel2.RefreshScoreLevel((int)totalScoreLevel);
		}
		WheelTowerSettlementScorePanel scorePanel3 = this.ScorePanel;
		if (scorePanel3 != null)
		{
			scorePanel3.RefreshRoundWave(this.DataInternal.EndlessMode, item, curBossWave, this.DataInternal.MaxBossWaveNum);
		}
		WheelTowerSettlementBossResultPanel bossResultPanel = this.BossResultPanel;
		if (bossResultPanel != null)
		{
			bossResultPanel.Refresh(this.DataInternal.BossInfoList);
		}
		GenericLayout<WheelTowerSettlementRoleItem, RoleDataWithBranch> roleLayout = this.RoleLayout;
		if (roleLayout != null)
		{
			roleLayout.RefreshByData(this.DataInternal.RoleList, null, false);
		}
		ButtonItem reBattleBtnItem = this.ReBattleBtnItem;
		if (reBattleBtnItem != null)
		{
			reBattleBtnItem.SetUiActive(this.DataInternal.CenterButtonData != null);
		}
		ButtonItem backBtnItem = this.BackBtnItem;
		if (backBtnItem != null)
		{
			backBtnItem.SetUiActive(this.DataInternal.LeftButtonData != null);
		}
		ButtonItem continueBtnItem = this.ContinueBtnItem;
		if (continueBtnItem != null)
		{
			continueBtnItem.SetUiActive(this.DataInternal.RightButtonData != null);
		}
		if (this.DataInternal.CenterButtonData != null)
		{
			ButtonItem reBattleBtnItem2 = this.ReBattleBtnItem;
			if (reBattleBtnItem2 != null)
			{
				reBattleBtnItem2.SetLocalTextNew(this.DataInternal.CenterButtonData.Name, Array.Empty<object>());
			}
		}
		if (this.DataInternal.LeftButtonData != null)
		{
			ButtonItem backBtnItem2 = this.BackBtnItem;
			if (backBtnItem2 != null)
			{
				backBtnItem2.SetLocalTextNew(this.DataInternal.LeftButtonData.Name, Array.Empty<object>());
			}
		}
		if (this.DataInternal.RightButtonData != null)
		{
			ButtonItem continueBtnItem2 = this.ContinueBtnItem;
			if (continueBtnItem2 != null)
			{
				continueBtnItem2.SetLocalTextNew(this.DataInternal.RightButtonData.Name, Array.Empty<object>());
			}
		}
		List<int> finishedSeasonTaskIds = this.DataInternal.FinishedSeasonTaskIds;
		UUIItem item2 = base.GetItem(11);
		if (item2 != null)
		{
			item2.SetUIActive(finishedSeasonTaskIds.Count > 0);
		}
		if (finishedSeasonTaskIds.Count <= 0)
		{
			return;
		}
		NewTowerSeasonAward? seasonTaskRewardConfig = ConfigBase<WheelTowerConfig>.Instance.GetSeasonTaskRewardConfig(finishedSeasonTaskIds[0]);
		if (seasonTaskRewardConfig == null)
		{
			return;
		}
		if (finishedSeasonTaskIds.Count > 1)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "WheelTower_Settlement_SeasonTask", new <>z__ReadOnlyArray<object>(new object[]
			{
				ConfigMultiTextLang.GetLocalTextNew(seasonTaskRewardConfig.Value.Desc, null),
				finishedSeasonTaskIds.Count
			}));
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), seasonTaskRewardConfig.Value.Desc, Array.Empty<object>());
	}

	// Token: 0x0600A320 RID: 41760 RVA: 0x002B1784 File Offset: 0x002AF984
	[NullableContext(1)]
	private void OnSequenceStartFinish(string name)
	{
		if (this.DataInternal == null)
		{
			return;
		}
		this.TotalScoreTween.PlayTween(0, this.DataInternal.TotalScore, 0.4f, null);
	}

	// Token: 0x0600A321 RID: 41761 RVA: 0x002B17AC File Offset: 0x002AF9AC
	private void OnBtnReBattleClick()
	{
		IWheelTowerSettlementViewData dataInternal = this.DataInternal;
		this.HandleButtonClick((dataInternal != null) ? dataInternal.CenterButtonData : null);
	}

	// Token: 0x0600A322 RID: 41762 RVA: 0x002B17C6 File Offset: 0x002AF9C6
	private void OnBtnBackClick()
	{
		IWheelTowerSettlementViewData dataInternal = this.DataInternal;
		this.HandleButtonClick((dataInternal != null) ? dataInternal.LeftButtonData : null);
	}

	// Token: 0x0600A323 RID: 41763 RVA: 0x002B17E0 File Offset: 0x002AF9E0
	private void OnBtnContinueClick()
	{
		IWheelTowerSettlementViewData dataInternal = this.DataInternal;
		this.HandleButtonClick((dataInternal != null) ? dataInternal.RightButtonData : null);
	}

	// Token: 0x0600A324 RID: 41764 RVA: 0x002B17FC File Offset: 0x002AF9FC
	private void HandleButtonClick(IWheelTowerSettlementViewButtonData buttonData)
	{
		if (buttonData == null)
		{
			return;
		}
		if (buttonData.ConfirmBoxId != null)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(buttonData.ConfirmBoxId.Value);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				buttonData.OnClick();
				this.CloseMe(null);
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		buttonData.OnClick();
		base.CloseMe(null);
	}

	// Token: 0x04004D94 RID: 19860
	private PopupCaptionItem CaptionItem;

	// Token: 0x04004D95 RID: 19861
	private WheelTowerModeSettlementTitleItem ModeTitleItem;

	// Token: 0x04004D96 RID: 19862
	private WheelTowerSettlementRoundPanel RoundPanel;

	// Token: 0x04004D97 RID: 19863
	private WheelTowerSettlementScorePanel ScorePanel;

	// Token: 0x04004D98 RID: 19864
	private WheelTowerSettlementBossResultPanel BossResultPanel;

	// Token: 0x04004D99 RID: 19865
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<WheelTowerSettlementRoleItem, RoleDataWithBranch> RoleLayout;

	// Token: 0x04004D9A RID: 19866
	private ButtonItem ReBattleBtnItem;

	// Token: 0x04004D9B RID: 19867
	private ButtonItem BackBtnItem;

	// Token: 0x04004D9C RID: 19868
	private ButtonItem ContinueBtnItem;

	// Token: 0x04004D9D RID: 19869
	private IWheelTowerSettlementViewData DataInternal;

	// Token: 0x04004D9E RID: 19870
	[Nullable(1)]
	private UiBehaviorGachaSequence GachaSequence;

	// Token: 0x04004D9F RID: 19871
	private AActor SceneSequenceCamera;

	// Token: 0x04004DA0 RID: 19872
	private BP_UpdateInteract_C UpdateInteractBp;

	// Token: 0x04004DA1 RID: 19873
	private bool IsPlayingRoleSequence;

	// Token: 0x04004DA2 RID: 19874
	private int SequenceRoleId;

	// Token: 0x04004DA3 RID: 19875
	[Nullable(1)]
	private LguiIntTween TotalScoreTween;

	// Token: 0x04004DA4 RID: 19876
	private int LastScoreLevel = -1;

	// Token: 0x04004DA5 RID: 19877
	[Nullable(1)]
	private ShareBtnItem ShareBtnItem;
}
