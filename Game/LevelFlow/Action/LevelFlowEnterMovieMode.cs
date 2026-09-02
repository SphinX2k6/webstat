using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.MovieMode;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006F90 RID: 28560
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelFlowEnterMovieMode : LevelFlowActionBase
	{
		// Token: 0x06045199 RID: 283033 RVA: 0x0120650E File Offset: 0x0120470E
		public LevelFlowEnterMovieMode Init(EnterMovieMode params_)
		{
			this.Params = params_;
			return this;
		}

		// Token: 0x0604519A RID: 283034 RVA: 0x01206518 File Offset: 0x01204718
		protected override void OnExecute()
		{
			if (this.Params == null)
			{
				base.FinishExecute(false);
				return;
			}
			float blendTime = this.Params.BorderAnimDuration ?? ((float)ConfigCommonParamById.GetIntConfig("EnterMovieModeTimeThreshold").GetValueOrDefault(1));
			EnterMovieModeParams enterMovieModeParams = new EnterMovieModeParams();
			enterMovieModeParams.BlendTime = blendTime;
			enterMovieModeParams.MovieCameraConfig = this.Params.MovieCameraConfig;
			IEnableFuncConfig enableFuncConfig = this.Params.EnableFuncConfig;
			enterMovieModeParams.DelayDuration = ((enableFuncConfig != null) ? enableFuncConfig.DelayDuration : null);
			IEnableFuncConfig enableFuncConfig2 = this.Params.EnableFuncConfig;
			enterMovieModeParams.IsEnableEsc = ((enableFuncConfig2 != null) ? enableFuncConfig2.IsEnableEsc : null);
			IEnableFuncConfig enableFuncConfig3 = this.Params.EnableFuncConfig;
			enterMovieModeParams.IsEnablePhoto = ((enableFuncConfig3 != null) ? enableFuncConfig3.IsEnablePhoto : null);
			enterMovieModeParams.IsAutoExitInFlowSequence = this.Params.AutoExitInFlow;
			EnterMovieModeParams params_ = enterMovieModeParams;
			this.ExecuteEnterMovieMode(params_, this.Params.DurationType);
		}

		// Token: 0x0604519B RID: 283035 RVA: 0x0120661C File Offset: 0x0120481C
		private UniTask ExecuteEnterMovieMode(IEnterMovieModeParams params_, [Nullable(2)] IEnterMovieModeDurationType durationType)
		{
			LevelFlowEnterMovieMode.<ExecuteEnterMovieMode>d__3 <ExecuteEnterMovieMode>d__;
			<ExecuteEnterMovieMode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteEnterMovieMode>d__.<>4__this = this;
			<ExecuteEnterMovieMode>d__.params_ = params_;
			<ExecuteEnterMovieMode>d__.durationType = durationType;
			<ExecuteEnterMovieMode>d__.<>1__state = -1;
			<ExecuteEnterMovieMode>d__.<>t__builder.Start<LevelFlowEnterMovieMode.<ExecuteEnterMovieMode>d__3>(ref <ExecuteEnterMovieMode>d__);
			return <ExecuteEnterMovieMode>d__.<>t__builder.Task;
		}

		// Token: 0x040268F2 RID: 157938
		[Nullable(2)]
		private EnterMovieMode Params;
	}
}
