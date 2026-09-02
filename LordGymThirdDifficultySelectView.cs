using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.InstanceDungeon.Define;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200220F RID: 8719
public class LordGymThirdDifficultySelectView : LordGymDifficultySelectView
{
	// Token: 0x0601076B RID: 67435 RVA: 0x0047F06E File Offset: 0x0047D26E
	[NullableContext(1)]
	public LordGymThirdDifficultySelectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601076C RID: 67436 RVA: 0x0047F077 File Offset: 0x0047D277
	[NullableContext(1)]
	protected override LordGymDifficultyItem CreateItem()
	{
		return new LordGymThirdLevelItem
		{
			OnToggleClick = new Action<int>(base.OnLordDifficultyToggleClick),
			CanExecuteChangeCallBack = new Func<int, bool>(base.CanLordDifficultyToggleChange)
		};
	}

	// Token: 0x0601076D RID: 67437 RVA: 0x0047F0A4 File Offset: 0x0047D2A4
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem != null)
		{
			captionItem.SetHomeBtnShowState(true);
		}
		base.GetButton(14).OnClickCallBack.Unbind();
		base.GetButton(14).OnClickCallBack.Bind(new Action(this.OnClickClose));
		this.AddHomeBtnExitDungeonCallback();
		ILordGymDifficultySelectViewParam lordGymDifficultySelectViewParam = this.OpenParam as ILordGymDifficultySelectViewParam;
		if (lordGymDifficultySelectViewParam != null && lordGymDifficultySelectViewParam.IsPlaySpecialSequence)
		{
			this.UiViewSequence.StartSequenceName = "StartZ";
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_daoguan_3_1_efx_boss");
			return;
		}
		this.UiViewSequence.StartSequenceName = "Start01";
	}

	// Token: 0x0601076E RID: 67438 RVA: 0x0047F154 File Offset: 0x0047D354
	protected override void OnStartChallenge()
	{
		double serverTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		if (this.NextCanClickButtonTime > serverTimeStamp)
		{
			return;
		}
		this.NextCanClickButtonTime = serverTimeStamp + 500.0;
		int selectedGridIndex = this.LordDifficultyScrollView.GetSelectedGridIndex();
		int entryChallengeId = this.LordList[selectedGridIndex];
		ModelBase<LordGymModel>.Instance.EntryChallengeId = entryChallengeId;
		LordGymEntranceSet? config = ConfigLordGymEntranceSetById.GetConfig(this.LordEntranceSetId, true);
		if (config == null)
		{
			return;
		}
		ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId = config.Value.DungeonId;
		if (ControllerBase<LordGymController>.Instance.IsInLordGymDungeon())
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.RestartEntranceFlow();
		}
		ControllerBase<InstanceDungeonEntranceController>.Instance.ContinueEntranceFlow();
	}

	// Token: 0x0601076F RID: 67439 RVA: 0x0047F1FC File Offset: 0x0047D3FC
	public override void RefreshDetail()
	{
		base.RefreshDetail();
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (((levelSequencePlayer != null) ? levelSequencePlayer.GetCurrentSequence() : null) == "Switch")
		{
			this.LevelSequencePlayer.ReplaySequenceByKey("Switch");
			return;
		}
		LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
		if (levelSequencePlayer2 == null)
		{
			return;
		}
		levelSequencePlayer2.PlayLevelSequenceByName("Switch", false, null, false);
	}

	// Token: 0x06010770 RID: 67440 RVA: 0x0047F260 File Offset: 0x0047D460
	protected override UniTask OnHandlePostLoadSceneAsync(bool isSceneLoad)
	{
		LordGymThirdDifficultySelectView.<OnHandlePostLoadSceneAsync>d__11 <OnHandlePostLoadSceneAsync>d__;
		<OnHandlePostLoadSceneAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnHandlePostLoadSceneAsync>d__.isSceneLoad = isSceneLoad;
		<OnHandlePostLoadSceneAsync>d__.<>1__state = -1;
		<OnHandlePostLoadSceneAsync>d__.<>t__builder.Start<LordGymThirdDifficultySelectView.<OnHandlePostLoadSceneAsync>d__11>(ref <OnHandlePostLoadSceneAsync>d__);
		return <OnHandlePostLoadSceneAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010771 RID: 67441 RVA: 0x0047F2A4 File Offset: 0x0047D4A4
	protected override UniTask OnHandlePreReleaseSceneAsync(bool isSceneRelease)
	{
		LordGymThirdDifficultySelectView.<OnHandlePreReleaseSceneAsync>d__12 <OnHandlePreReleaseSceneAsync>d__;
		<OnHandlePreReleaseSceneAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnHandlePreReleaseSceneAsync>d__.isSceneRelease = isSceneRelease;
		<OnHandlePreReleaseSceneAsync>d__.<>1__state = -1;
		<OnHandlePreReleaseSceneAsync>d__.<>t__builder.Start<LordGymThirdDifficultySelectView.<OnHandlePreReleaseSceneAsync>d__12>(ref <OnHandlePreReleaseSceneAsync>d__);
		return <OnHandlePreReleaseSceneAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010772 RID: 67442 RVA: 0x0047F2E7 File Offset: 0x0047D4E7
	protected override void OnHandleLoadScene()
	{
		Singleton<UiSceneManager>.Instance.InitLordSkeletalHandle();
		ControllerBase<LordGymController>.Instance.CreateLordModelByEntranceId();
		ControllerBase<LordGymController>.Instance.LoadLordModelByEntranceId(this.LordEntranceId, true, true);
	}

	// Token: 0x06010773 RID: 67443 RVA: 0x0047F310 File Offset: 0x0047D510
	private void AddHomeBtnExitDungeonCallback()
	{
		UiBehaviourHomeBtn uiBehaviourHomeBtn = this.UiBehaviourHomeBtn;
		if (uiBehaviourHomeBtn == null)
		{
			return;
		}
		uiBehaviourHomeBtn.AddExtraAsyncCallback(delegate
		{
			LordGymThirdDifficultySelectView.<>c.<<AddHomeBtnExitDungeonCallback>b__14_0>d <<AddHomeBtnExitDungeonCallback>b__14_0>d;
			<<AddHomeBtnExitDungeonCallback>b__14_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<AddHomeBtnExitDungeonCallback>b__14_0>d.<>1__state = -1;
			<<AddHomeBtnExitDungeonCallback>b__14_0>d.<>t__builder.Start<LordGymThirdDifficultySelectView.<>c.<<AddHomeBtnExitDungeonCallback>b__14_0>d>(ref <<AddHomeBtnExitDungeonCallback>b__14_0>d);
			return <<AddHomeBtnExitDungeonCallback>b__14_0>d.<>t__builder.Task;
		});
	}

	// Token: 0x06010774 RID: 67444 RVA: 0x0047F344 File Offset: 0x0047D544
	private void OnClickClose()
	{
		LordGymLordEntranceSelectViewParam param = new LordGymLordEntranceSelectViewParam
		{
			EntranceSetId = this.LordEntranceSetId,
			IsPlaySpecialSequence = new bool?(false),
			NeedBlackScreenAnim = true
		};
		ALevelSequenceActor lordGymThirdBossSequenceActor = ModelBase<LordGymModel>.Instance.GetLordGymThirdBossSequenceActor();
		if (lordGymThirdBossSequenceActor != null)
		{
			ULevelSequencePlayer sequencePlayer = lordGymThirdBossSequenceActor.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.PlayReverse();
			}
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.LordGymThirdBossSelectView, param, delegate(bool _, int _)
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.LordGymThirdDifficultySelectView, null);
		});
	}

	// Token: 0x0400818B RID: 33163
	private const int CLICK_CHALLENGE_BUTTON_CD = 500;

	// Token: 0x0400818C RID: 33164
	[Nullable(2)]
	protected InstanceDungeonEntranceFlowLordGym Flow;

	// Token: 0x0400818D RID: 33165
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400818E RID: 33166
	private double NextCanClickButtonTime;

	// Token: 0x0400818F RID: 33167
	protected int LastHideLandscapeValue;

	// Token: 0x020084EE RID: 34030
	private class EComponent
	{
		// Token: 0x0402D05D RID: 184413
		public const int BackBtn = 14;
	}
}
