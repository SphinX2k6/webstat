using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.InstanceDungeon.Define;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x0200220A RID: 8714
public class LordGymThird5DifficultySelectView : LordGymDifficultySelectView
{
	// Token: 0x06010732 RID: 67378 RVA: 0x0047E17E File Offset: 0x0047C37E
	[NullableContext(1)]
	public LordGymThird5DifficultySelectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06010733 RID: 67379 RVA: 0x0047E187 File Offset: 0x0047C387
	[NullableContext(1)]
	protected override LordGymDifficultyItem CreateItem()
	{
		return new LordGymThirdLevelItem
		{
			OnToggleClick = new Action<int>(base.OnLordDifficultyToggleClick),
			CanExecuteChangeCallBack = new Func<int, bool>(base.CanLordDifficultyToggleChange)
		};
	}

	// Token: 0x06010734 RID: 67380 RVA: 0x0047E1B4 File Offset: 0x0047C3B4
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
			return;
		}
		this.UiViewSequence.StartSequenceName = "Start01";
	}

	// Token: 0x06010735 RID: 67381 RVA: 0x0047E254 File Offset: 0x0047C454
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

	// Token: 0x06010736 RID: 67382 RVA: 0x0047E2FC File Offset: 0x0047C4FC
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

	// Token: 0x06010737 RID: 67383 RVA: 0x0047E360 File Offset: 0x0047C560
	protected override UniTask OnHandlePostLoadSceneAsync(bool isSceneLoad)
	{
		LordGymThird5DifficultySelectView.<OnHandlePostLoadSceneAsync>d__11 <OnHandlePostLoadSceneAsync>d__;
		<OnHandlePostLoadSceneAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnHandlePostLoadSceneAsync>d__.isSceneLoad = isSceneLoad;
		<OnHandlePostLoadSceneAsync>d__.<>1__state = -1;
		<OnHandlePostLoadSceneAsync>d__.<>t__builder.Start<LordGymThird5DifficultySelectView.<OnHandlePostLoadSceneAsync>d__11>(ref <OnHandlePostLoadSceneAsync>d__);
		return <OnHandlePostLoadSceneAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010738 RID: 67384 RVA: 0x0047E3A4 File Offset: 0x0047C5A4
	protected override UniTask OnHandlePreReleaseSceneAsync(bool isSceneRelease)
	{
		LordGymThird5DifficultySelectView.<OnHandlePreReleaseSceneAsync>d__12 <OnHandlePreReleaseSceneAsync>d__;
		<OnHandlePreReleaseSceneAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnHandlePreReleaseSceneAsync>d__.isSceneRelease = isSceneRelease;
		<OnHandlePreReleaseSceneAsync>d__.<>1__state = -1;
		<OnHandlePreReleaseSceneAsync>d__.<>t__builder.Start<LordGymThird5DifficultySelectView.<OnHandlePreReleaseSceneAsync>d__12>(ref <OnHandlePreReleaseSceneAsync>d__);
		return <OnHandlePreReleaseSceneAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010739 RID: 67385 RVA: 0x0047E3E7 File Offset: 0x0047C5E7
	protected override void OnHandleLoadScene()
	{
		Singleton<UiSceneManager>.Instance.InitLordSkeletalHandle();
		ControllerBase<LordGymController>.Instance.CreateLordModelByEntranceId();
		ControllerBase<LordGymController>.Instance.LoadLordModelByEntranceIdThird5(this.LordEntranceId, true, true);
	}

	// Token: 0x0601073A RID: 67386 RVA: 0x0047E410 File Offset: 0x0047C610
	private void AddHomeBtnExitDungeonCallback()
	{
		UiBehaviourHomeBtn uiBehaviourHomeBtn = this.UiBehaviourHomeBtn;
		if (uiBehaviourHomeBtn == null)
		{
			return;
		}
		uiBehaviourHomeBtn.AddExtraAsyncCallback(delegate
		{
			LordGymThird5DifficultySelectView.<>c.<<AddHomeBtnExitDungeonCallback>b__14_0>d <<AddHomeBtnExitDungeonCallback>b__14_0>d;
			<<AddHomeBtnExitDungeonCallback>b__14_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<AddHomeBtnExitDungeonCallback>b__14_0>d.<>1__state = -1;
			<<AddHomeBtnExitDungeonCallback>b__14_0>d.<>t__builder.Start<LordGymThird5DifficultySelectView.<>c.<<AddHomeBtnExitDungeonCallback>b__14_0>d>(ref <<AddHomeBtnExitDungeonCallback>b__14_0>d);
			return <<AddHomeBtnExitDungeonCallback>b__14_0>d.<>t__builder.Task;
		});
	}

	// Token: 0x0601073B RID: 67387 RVA: 0x0047E444 File Offset: 0x0047C644
	private void OnClickClose()
	{
		LordGymLordEntranceSelectViewParam param = new LordGymLordEntranceSelectViewParam
		{
			EntranceSetId = this.LordEntranceSetId,
			IsPlaySpecialSequence = new bool?(false),
			NeedBlackScreenAnim = true
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.LordGymThird5BossSelectView, param, delegate(bool _, int _)
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.LordGymThird5DifficultySelectView, null);
		});
	}

	// Token: 0x04008180 RID: 33152
	private const int CLICK_CHALLENGE_BUTTON_CD = 500;

	// Token: 0x04008181 RID: 33153
	[Nullable(2)]
	protected InstanceDungeonEntranceFlowLordGym Flow;

	// Token: 0x04008182 RID: 33154
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04008183 RID: 33155
	private double NextCanClickButtonTime;

	// Token: 0x04008184 RID: 33156
	protected int LastHideLandscapeValue;

	// Token: 0x020084DE RID: 34014
	private class EComponent
	{
		// Token: 0x0402D026 RID: 184358
		public const int BackBtn = 14;
	}
}
