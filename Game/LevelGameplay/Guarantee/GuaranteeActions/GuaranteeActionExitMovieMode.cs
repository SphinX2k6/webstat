using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.MovieMode;

namespace CSharpScript.Game.LevelGamePlay.Guarantee.GuaranteeActions
{
	// Token: 0x02006E74 RID: 28276
	[NullableContext(2)]
	[Nullable(0)]
	public class GuaranteeActionExitMovieMode : GuaranteeActionBase
	{
		// Token: 0x0604498C RID: 280972 RVA: 0x011D532C File Offset: 0x011D352C
		protected override void OnExecute(ActionParams @params = null)
		{
			ExitMovieModeParams param = new ExitMovieModeParams
			{
				BlendTime = 1f
			};
			ControllerBase<MovieModeController>.Instance.ExitMovieMode(param, null);
			Singleton<global::Log>.Instance.Info(ELogModule.LevelEvent, ELogAuthor.CB, "保底退出电影模式", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0604498D RID: 280973 RVA: 0x011D5373 File Offset: 0x011D3573
		protected override void OnClear(ActionParams @params = null, GeneralContext instigatorContext = null)
		{
			ModelBase<GeneralLogicTreeModel>.Instance.AddGuaranteeActionsWhenLogicTreeRemove(EGuaranteeAction.ActionExitMovieMode, @params, instigatorContext);
		}
	}
}
