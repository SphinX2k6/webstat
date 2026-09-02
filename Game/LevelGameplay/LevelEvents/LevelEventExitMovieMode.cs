using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.Guarantee;
using CSharpScript.Game.Module.MovieMode;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B9E RID: 27550
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventExitMovieMode : LevelEventBase
	{
		// Token: 0x06043FA3 RID: 278435 RVA: 0x0119D59E File Offset: 0x0119B79E
		public LevelEventExitMovieMode(int id) : base(id)
		{
		}

		// Token: 0x06043FA4 RID: 278436 RVA: 0x0119D5A8 File Offset: 0x0119B7A8
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			ExitMovieMode exitMovieMode = inParams as ExitMovieMode;
			ExitMovieModeParams exitMovieModeParams = new ExitMovieModeParams();
			exitMovieModeParams.BlendTime = (exitMovieMode.BorderAnimDuration ?? ((float)ConfigCommonParamById.GetIntConfig("ExitMovieModeTimeThreshold").GetValueOrDefault(1)));
			IMovieModeFadeOutMaskConfig fadeOutMaskConfig = exitMovieMode.FadeOutMaskConfig;
			exitMovieModeParams.BlackFadeInTime = ((fadeOutMaskConfig != null) ? fadeOutMaskConfig.TransitionTime : null);
			ExitMovieModeParams @params = exitMovieModeParams;
			this.ExecuteExitMovieMode(@params, exitMovieMode.DurationType);
		}

		// Token: 0x06043FA5 RID: 278437 RVA: 0x0119D624 File Offset: 0x0119B824
		private UniTask ExecuteExitMovieMode(ExitMovieModeParams @params, [Nullable(2)] IEnterMovieModeDurationType durationType)
		{
			LevelEventExitMovieMode.<ExecuteExitMovieMode>d__2 <ExecuteExitMovieMode>d__;
			<ExecuteExitMovieMode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteExitMovieMode>d__.<>4__this = this;
			<ExecuteExitMovieMode>d__.@params = @params;
			<ExecuteExitMovieMode>d__.durationType = durationType;
			<ExecuteExitMovieMode>d__.<>1__state = -1;
			<ExecuteExitMovieMode>d__.<>t__builder.Start<LevelEventExitMovieMode.<ExecuteExitMovieMode>d__2>(ref <ExecuteExitMovieMode>d__);
			return <ExecuteExitMovieMode>d__.<>t__builder.Task;
		}

		// Token: 0x06043FA6 RID: 278438 RVA: 0x0119D677 File Offset: 0x0119B877
		protected override void ExecuteInGm(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06043FA7 RID: 278439 RVA: 0x0119D684 File Offset: 0x0119B884
		protected override void OnUpdateGuarantee()
		{
			GuaranteeActionInfo p = new GuaranteeActionInfo
			{
				Name = EGuaranteeAction.ActionExitMovieMode
			};
			Singleton<EventSystem>.Instance.Emit<string, GeneralContext, GuaranteeActionInfo, bool?>(EEventName.RemGuaranteeAction, this.Type, this.BaseContext, p, null);
		}
	}
}
