using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.Plot.PlotView;

// Token: 0x02001E8B RID: 7819
[NullableContext(2)]
[Nullable(0)]
public class HandBookQuestPlotTalkAudioUtil : IStaticVariableResetter
{
	// Token: 0x0600E701 RID: 59137 RVA: 0x003E54A2 File Offset: 0x003E36A2
	static HandBookQuestPlotTalkAudioUtil()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(HandBookQuestPlotTalkAudioUtil.CreateStaticDefaultValue), new Action(HandBookQuestPlotTalkAudioUtil.ResetStaticDefaultValue));
	}

	// Token: 0x0600E702 RID: 59138 RVA: 0x003E54DD File Offset: 0x003E36DD
	public static void CreateStaticDefaultValue()
	{
		HandBookQuestPlotTalkAudioUtil.PlotPlayEventResult = new PlayResult();
		HandBookQuestPlotTalkAudioUtil.AudioDelegate = new PlotAudioDelegate();
	}

	// Token: 0x0600E703 RID: 59139 RVA: 0x003E54F3 File Offset: 0x003E36F3
	public static void ResetStaticDefaultValue()
	{
		HandBookQuestPlotTalkAudioUtil.PlotPlayEventResult = null;
		HandBookQuestPlotTalkAudioUtil.AudioDelegate = null;
		HandBookQuestPlotTalkAudioUtil.WaitAudioLoadTimerId = null;
		HandBookQuestPlotTalkAudioUtil.PlayEndCallBackTimerId = null;
		HandBookQuestPlotTalkAudioUtil.CurrentPlayAudio = "";
		HandBookQuestPlotTalkAudioUtil.LastCallBack = null;
	}

	// Token: 0x0600E704 RID: 59140 RVA: 0x003E5520 File Offset: 0x003E3720
	public static void PlayAudio(PlotAudio config, [Nullable(new byte[]
	{
		1,
		2
	})] Action<string> callback)
	{
		HandBookQuestPlotTalkAudioUtil.AudioDelegate.Init(delegate(float duration)
		{
			HandBookQuestPlotTalkAudioUtil.RemoveWaitAudioLoadTimer();
			if (HandBookQuestPlotTalkAudioUtil.PlayEndCallBackTimerId != null)
			{
				HandBookQuestPlotTalkAudioUtil.RemovePlayEndCallBackTimer(true, config.Id);
			}
			HandBookQuestPlotTalkAudioUtil.LastCallBack = callback;
			HandBookQuestPlotTalkAudioUtil.CurrentPlayAudio = config.Id;
			HandBookQuestPlotTalkAudioUtil.PlayEndCallBackTimerId = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				HandBookQuestPlotTalkAudioUtil.RemovePlayEndCallBackTimer(true, null);
			}, duration, null, null, true, 1f);
		});
		HandBookQuestPlotTalkAudioUtil.AudioDelegate.Enable();
		ExternalSourceSetting? config2 = ConfigExternalSourceSettingById.GetConfig(config.ExternalSourceSetting, true);
		string externalSourcesMediaName = ModelBase<PlotAudioModel>.Instance.GetExternalSourcesMediaName(config);
		Singleton<AudioController>.Instance.PostEventByExternalSourcesByUi(config2.Value.SubtitleEvent, externalSourcesMediaName, config2.Value.SubtitleSrc, HandBookQuestPlotTalkAudioUtil.PlotPlayEventResult, null, new int?(8), HandBookQuestPlotTalkAudioUtil.AudioDelegate.AudioDelegate);
		HandBookQuestPlotTalkAudioUtil.WaitAudioLoadTimerId = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.LJQ, "加载剧情音频超时", default(ReadOnlySpan<ValueTuple<string, object>>));
			HandBookQuestPlotTalkAudioUtil.ClearCurPlayAudio();
		}, 3000f, null, null, true, 1f);
	}

	// Token: 0x0600E705 RID: 59141 RVA: 0x003E55FE File Offset: 0x003E37FE
	public static void ClearCurPlayAudio()
	{
		HandBookQuestPlotTalkAudioUtil.CurrentPlayAudio = "";
		HandBookQuestPlotTalkAudioUtil.AudioDelegate.Disable();
		Singleton<AudioController>.Instance.StopEvent(HandBookQuestPlotTalkAudioUtil.PlotPlayEventResult, true, new int?(1000));
		HandBookQuestPlotTalkAudioUtil.RemoveWaitAudioLoadTimer();
		HandBookQuestPlotTalkAudioUtil.RemovePlayEndCallBackTimer(false, null);
	}

	// Token: 0x0600E706 RID: 59142 RVA: 0x003E563A File Offset: 0x003E383A
	private static void RemoveWaitAudioLoadTimer()
	{
		if (TimerSystem.GameplayTimeInstance.Has(HandBookQuestPlotTalkAudioUtil.WaitAudioLoadTimerId))
		{
			TimerSystem.GameplayTimeInstance.Remove(HandBookQuestPlotTalkAudioUtil.WaitAudioLoadTimerId);
		}
		HandBookQuestPlotTalkAudioUtil.WaitAudioLoadTimerId = null;
	}

	// Token: 0x0600E707 RID: 59143 RVA: 0x003E5664 File Offset: 0x003E3864
	private static void RemovePlayEndCallBackTimer(bool callBack = true, string nextAudio = null)
	{
		if (HandBookQuestPlotTalkAudioUtil.LastCallBack != null && callBack)
		{
			HandBookQuestPlotTalkAudioUtil.LastCallBack(nextAudio);
			HandBookQuestPlotTalkAudioUtil.LastCallBack = null;
		}
		if (TimerSystem.GameplayTimeInstance.Has(HandBookQuestPlotTalkAudioUtil.PlayEndCallBackTimerId))
		{
			TimerSystem.GameplayTimeInstance.Remove(HandBookQuestPlotTalkAudioUtil.PlayEndCallBackTimerId);
		}
		HandBookQuestPlotTalkAudioUtil.CurrentPlayAudio = "";
		HandBookQuestPlotTalkAudioUtil.PlayEndCallBackTimerId = null;
	}

	// Token: 0x0600E708 RID: 59144 RVA: 0x003E56BF File Offset: 0x003E38BF
	public static bool IsPlayingAudio(string audioId)
	{
		return HandBookQuestPlotTalkAudioUtil.CurrentPlayAudio == audioId;
	}

	// Token: 0x0600E709 RID: 59145 RVA: 0x003E56CC File Offset: 0x003E38CC
	public static void ResetPlayEndCallBack([Nullable(new byte[]
	{
		1,
		2
	})] Action<string> callback)
	{
		HandBookQuestPlotTalkAudioUtil.LastCallBack = callback;
	}

	// Token: 0x04006F6A RID: 28522
	private const int BREAK_TIME = 1000;

	// Token: 0x04006F6B RID: 28523
	private const int MAX_LOAD_AUDIO_TIME = 3000;

	// Token: 0x04006F6C RID: 28524
	private const int PLAY_FLAG = 8;

	// Token: 0x04006F6D RID: 28525
	[Nullable(1)]
	private static PlayResult PlotPlayEventResult;

	// Token: 0x04006F6E RID: 28526
	[Nullable(1)]
	private static PlotAudioDelegate AudioDelegate;

	// Token: 0x04006F6F RID: 28527
	private static TimerHandle WaitAudioLoadTimerId = null;

	// Token: 0x04006F70 RID: 28528
	private static TimerHandle PlayEndCallBackTimerId = null;

	// Token: 0x04006F71 RID: 28529
	[Nullable(1)]
	private static string CurrentPlayAudio = "";

	// Token: 0x04006F72 RID: 28530
	private static Action<string> LastCallBack = null;
}
