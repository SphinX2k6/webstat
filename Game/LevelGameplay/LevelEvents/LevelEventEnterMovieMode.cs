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
	// Token: 0x02006B93 RID: 27539
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventEnterMovieMode : LevelEventBase
	{
		// Token: 0x06043F5B RID: 278363 RVA: 0x0119B678 File Offset: 0x01199878
		public LevelEventEnterMovieMode(int id) : base(id)
		{
		}

		// Token: 0x06043F5C RID: 278364 RVA: 0x0119B684 File Offset: 0x01199884
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			EnterMovieMode enterMovieMode = inParams as EnterMovieMode;
			float blendTime = enterMovieMode.BorderAnimDuration ?? ((float)ConfigCommonParamById.GetIntConfig("EnterMovieModeTimeThreshold").GetValueOrDefault(1));
			EnterMovieModeParams enterMovieModeParams = new EnterMovieModeParams();
			enterMovieModeParams.BlendTime = blendTime;
			enterMovieModeParams.MovieCameraConfig = enterMovieMode.MovieCameraConfig;
			IEnableFuncConfig enableFuncConfig = enterMovieMode.EnableFuncConfig;
			enterMovieModeParams.DelayDuration = ((enableFuncConfig != null) ? enableFuncConfig.DelayDuration : null);
			IEnableFuncConfig enableFuncConfig2 = enterMovieMode.EnableFuncConfig;
			enterMovieModeParams.IsEnableEsc = ((enableFuncConfig2 != null) ? enableFuncConfig2.IsEnableEsc : null);
			IEnableFuncConfig enableFuncConfig3 = enterMovieMode.EnableFuncConfig;
			enterMovieModeParams.IsEnablePhoto = ((enableFuncConfig3 != null) ? enableFuncConfig3.IsEnablePhoto : null);
			enterMovieModeParams.IsAutoExitInFlowSequence = enterMovieMode.AutoExitInFlow;
			bool value = (Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.FlowAdaptation, true, true) ?? 0) == 0;
			enterMovieModeParams.IsBanAdaptation = new bool?(value);
			EnterMovieModeParams @params = enterMovieModeParams;
			this.ExecuteEnterMovieMode(@params, enterMovieMode.DurationType);
		}

		// Token: 0x06043F5D RID: 278365 RVA: 0x0119B798 File Offset: 0x01199998
		private UniTask ExecuteEnterMovieMode(EnterMovieModeParams @params, [Nullable(2)] IEnterMovieModeDurationType durationType)
		{
			LevelEventEnterMovieMode.<ExecuteEnterMovieMode>d__2 <ExecuteEnterMovieMode>d__;
			<ExecuteEnterMovieMode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteEnterMovieMode>d__.<>4__this = this;
			<ExecuteEnterMovieMode>d__.@params = @params;
			<ExecuteEnterMovieMode>d__.durationType = durationType;
			<ExecuteEnterMovieMode>d__.<>1__state = -1;
			<ExecuteEnterMovieMode>d__.<>t__builder.Start<LevelEventEnterMovieMode.<ExecuteEnterMovieMode>d__2>(ref <ExecuteEnterMovieMode>d__);
			return <ExecuteEnterMovieMode>d__.<>t__builder.Task;
		}

		// Token: 0x06043F5E RID: 278366 RVA: 0x0119B7EB File Offset: 0x011999EB
		protected override void ExecuteInGm(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06043F5F RID: 278367 RVA: 0x0119B7F8 File Offset: 0x011999F8
		protected override void OnUpdateGuarantee()
		{
			GuaranteeActionInfo p = new GuaranteeActionInfo
			{
				Name = EGuaranteeAction.ActionExitMovieMode
			};
			Singleton<EventSystem>.Instance.Emit<string, GeneralContext, GuaranteeActionInfo, bool?>(EEventName.AddGuaranteeAction, this.Type, this.BaseContext, p, null);
		}
	}
}
