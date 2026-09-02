using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020021FE RID: 8702
[NullableContext(1)]
[Nullable(0)]
public class LordGymFirstDifficultySelectView : LordGymDifficultySelectView
{
	// Token: 0x060106B4 RID: 67252 RVA: 0x0047CC59 File Offset: 0x0047AE59
	public LordGymFirstDifficultySelectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060106B5 RID: 67253 RVA: 0x0047CC64 File Offset: 0x0047AE64
	protected override UniTask OnBeforeStartAsync()
	{
		LordGymFirstDifficultySelectView.<OnBeforeStartAsync>d__1 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<LordGymFirstDifficultySelectView.<OnBeforeStartAsync>d__1>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060106B6 RID: 67254 RVA: 0x0047CCA7 File Offset: 0x0047AEA7
	protected override void OnStart()
	{
		this.AddHomeBtnExitDungeonCallback();
	}

	// Token: 0x060106B7 RID: 67255 RVA: 0x0047CCB0 File Offset: 0x0047AEB0
	protected override UniTask OnHandlePostLoadSceneAsync(bool isSceneLoad)
	{
		LordGymFirstDifficultySelectView.<OnHandlePostLoadSceneAsync>d__3 <OnHandlePostLoadSceneAsync>d__;
		<OnHandlePostLoadSceneAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnHandlePostLoadSceneAsync>d__.isSceneLoad = isSceneLoad;
		<OnHandlePostLoadSceneAsync>d__.<>1__state = -1;
		<OnHandlePostLoadSceneAsync>d__.<>t__builder.Start<LordGymFirstDifficultySelectView.<OnHandlePostLoadSceneAsync>d__3>(ref <OnHandlePostLoadSceneAsync>d__);
		return <OnHandlePostLoadSceneAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060106B8 RID: 67256 RVA: 0x0047CCF4 File Offset: 0x0047AEF4
	protected override UniTask OnHandlePreReleaseSceneAsync(bool isSceneRelease)
	{
		LordGymFirstDifficultySelectView.<OnHandlePreReleaseSceneAsync>d__4 <OnHandlePreReleaseSceneAsync>d__;
		<OnHandlePreReleaseSceneAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnHandlePreReleaseSceneAsync>d__.isSceneRelease = isSceneRelease;
		<OnHandlePreReleaseSceneAsync>d__.<>1__state = -1;
		<OnHandlePreReleaseSceneAsync>d__.<>t__builder.Start<LordGymFirstDifficultySelectView.<OnHandlePreReleaseSceneAsync>d__4>(ref <OnHandlePreReleaseSceneAsync>d__);
		return <OnHandlePreReleaseSceneAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060106B9 RID: 67257 RVA: 0x0047CD37 File Offset: 0x0047AF37
	private void AddHomeBtnExitDungeonCallback()
	{
		UiBehaviourHomeBtn uiBehaviourHomeBtn = this.UiBehaviourHomeBtn;
		if (uiBehaviourHomeBtn == null)
		{
			return;
		}
		uiBehaviourHomeBtn.AddExtraAsyncCallback(delegate
		{
			LordGymFirstDifficultySelectView.<>c.<<AddHomeBtnExitDungeonCallback>b__5_0>d <<AddHomeBtnExitDungeonCallback>b__5_0>d;
			<<AddHomeBtnExitDungeonCallback>b__5_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<AddHomeBtnExitDungeonCallback>b__5_0>d.<>1__state = -1;
			<<AddHomeBtnExitDungeonCallback>b__5_0>d.<>t__builder.Start<LordGymFirstDifficultySelectView.<>c.<<AddHomeBtnExitDungeonCallback>b__5_0>d>(ref <<AddHomeBtnExitDungeonCallback>b__5_0>d);
			return <<AddHomeBtnExitDungeonCallback>b__5_0>d.<>t__builder.Task;
		});
	}

	// Token: 0x060106BA RID: 67258 RVA: 0x0047CD68 File Offset: 0x0047AF68
	protected override LordGymDifficultyItem CreateItem()
	{
		return new LordGymFirstDifficultyItem
		{
			OnToggleClick = new Action<int>(base.OnLordDifficultyToggleClick),
			CanExecuteChangeCallBack = new Func<int, bool>(base.CanLordDifficultyToggleChange)
		};
	}

	// Token: 0x060106BB RID: 67259 RVA: 0x0047CD94 File Offset: 0x0047AF94
	protected override void OnStartChallenge()
	{
		if (!ModelBase<LordGymModel>.Instance.LastChallengeEntryFromGuide)
		{
			base.OnStartChallenge();
			return;
		}
		if (!ControllerBase<LordGymController>.Instance.IsInEntranceEntity())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("LordGymOpen_ErrorTipText", Array.Empty<object>());
			return;
		}
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

	// Token: 0x060106BC RID: 67260 RVA: 0x0047CE4C File Offset: 0x0047B04C
	protected override void OnCloseBtnClick()
	{
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.LordGymFirstBossSelectView) || Singleton<UiManager>.Instance.IsViewHide(EUiViewName.LordGymFirstBossSelectView))
		{
			base.CloseMe(null);
			return;
		}
		LordGymLordEntranceSelectViewParam param = new LordGymLordEntranceSelectViewParam
		{
			EntranceSetId = this.LordEntranceSetId,
			IsPlaySpecialSequence = new bool?(false),
			NeedBlackScreenAnim = false
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.LordGymFirstBossSelectView, param, delegate(bool _, int _)
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.LordGymFirstDifficultySelectView, null);
		});
	}
}
