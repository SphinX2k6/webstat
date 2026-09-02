using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002208 RID: 8712
public class LordGymSecondDifficultySelectView : LordGymDifficultySelectView
{
	// Token: 0x06010714 RID: 67348 RVA: 0x0047DAE6 File Offset: 0x0047BCE6
	[NullableContext(1)]
	public LordGymSecondDifficultySelectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06010715 RID: 67349 RVA: 0x0047DAEF File Offset: 0x0047BCEF
	protected override void OnStart()
	{
		this.AddHomeBtnExitDungeonCallback();
	}

	// Token: 0x06010716 RID: 67350 RVA: 0x0047DAF7 File Offset: 0x0047BCF7
	private void AddHomeBtnExitDungeonCallback()
	{
		UiBehaviourHomeBtn uiBehaviourHomeBtn = this.UiBehaviourHomeBtn;
		if (uiBehaviourHomeBtn == null)
		{
			return;
		}
		uiBehaviourHomeBtn.AddExtraAsyncCallback(delegate
		{
			LordGymSecondDifficultySelectView.<>c.<<AddHomeBtnExitDungeonCallback>b__2_0>d <<AddHomeBtnExitDungeonCallback>b__2_0>d;
			<<AddHomeBtnExitDungeonCallback>b__2_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<AddHomeBtnExitDungeonCallback>b__2_0>d.<>1__state = -1;
			<<AddHomeBtnExitDungeonCallback>b__2_0>d.<>t__builder.Start<LordGymSecondDifficultySelectView.<>c.<<AddHomeBtnExitDungeonCallback>b__2_0>d>(ref <<AddHomeBtnExitDungeonCallback>b__2_0>d);
			return <<AddHomeBtnExitDungeonCallback>b__2_0>d.<>t__builder.Task;
		});
	}

	// Token: 0x06010717 RID: 67351 RVA: 0x0047DB28 File Offset: 0x0047BD28
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

	// Token: 0x06010718 RID: 67352 RVA: 0x0047DBE0 File Offset: 0x0047BDE0
	protected override void OnCloseBtnClick()
	{
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.LordGymSecondBossSelectView) || Singleton<UiManager>.Instance.IsViewHide(EUiViewName.LordGymSecondBossSelectView))
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
		Singleton<UiManager>.Instance.OpenView(EUiViewName.LordGymSecondBossSelectView, param, delegate(bool _, int _)
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.LordGymSecondDifficultySelectView, null);
		});
	}
}
