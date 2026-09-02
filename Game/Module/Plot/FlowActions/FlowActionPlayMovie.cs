using System;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Plot.Flow;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x0200542C RID: 21548
	public class FlowActionPlayMovie : FlowActionBase
	{
		// Token: 0x06036F70 RID: 225136 RVA: 0x00DF3AB0 File Offset: 0x00DF1CB0
		protected override void OnExecute()
		{
			PlayMovie playMovie = this.ActionInfo.Params as PlayMovie;
			ActionInfo nextAction = ControllerBase<FlowController>.Instance.GetNextAction(true);
			bool value = nextAction != null && nextAction.Name == EAction.PlayMovie;
			string videoName = (playMovie != null) ? playMovie.VideoName : null;
			Action videoCloseCb = delegate()
			{
				VideoLauncher.SetupFrameEvent(null);
				ControllerBase<FlowController>.Instance.EnableSkip(false);
				base.FinishExecute(true, true);
			};
			ShowVideoCgConfig showVideoCgConfig = new ShowVideoCgConfig();
			showVideoCgConfig.BackgroundFade = playMovie.BackgroundFade;
			showVideoCgConfig.RemainViewWhenEnd = new bool?(value);
			showVideoCgConfig.InPlot = new bool?(true);
			showVideoCgConfig.ProgramSpecialConfig = playMovie.ProgramSpecialConfig;
			showVideoCgConfig.Mp4FadeOutTime = playMovie.Mp4FadeOutTime;
			showVideoCgConfig.BlackBorderFadeOutTime = playMovie.BlackBorderFadeOutTime;
			showVideoCgConfig.Mp4BlendAnim = playMovie.Mp4BlendAnim;
			FlowContext context = this.Context;
			showVideoCgConfig.SeamlessEndOnTick = new bool?(context != null && context.SeamlessPlot);
			VideoLauncher.ShowVideoCg(videoName, videoCloseCb, showVideoCgConfig);
			VideoLauncher.SetupFrameEvent(playMovie.Mp4FrameEvents);
		}

		// Token: 0x06036F71 RID: 225137 RVA: 0x00DF3B88 File Offset: 0x00DF1D88
		protected override void OnInterruptExecute()
		{
			VideoLauncher.CloseVideoCg(null);
			VideoLauncher.SetupFrameEvent(null);
			base.FinishExecute(true, true);
		}
	}
}
