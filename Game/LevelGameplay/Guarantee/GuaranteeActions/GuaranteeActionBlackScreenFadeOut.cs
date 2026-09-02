using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Module.Plot;

namespace CSharpScript.Game.LevelGamePlay.Guarantee.GuaranteeActions
{
	// Token: 0x02006E70 RID: 28272
	[NullableContext(2)]
	[Nullable(0)]
	public class GuaranteeActionBlackScreenFadeOut : GuaranteeActionBase
	{
		// Token: 0x06044983 RID: 280963 RVA: 0x011D509C File Offset: 0x011D329C
		protected override void OnExecute(ActionParams @params = null)
		{
			if (ControllerBase<BlackScreenFadeController>.Instance.NeedGuarantee)
			{
				IGuaranteeFadeInParams guaranteeFadeInParams = @params as IGuaranteeFadeInParams;
				if (guaranteeFadeInParams != null && guaranteeFadeInParams.KeepFadeAfterTreeRollBack.GetValueOrDefault())
				{
					GuaranteeContext context = this.Context;
					if (context != null && context.GuaranteeReason == EGuaranteeReason.TreeRollback)
					{
						return;
					}
				}
				Singleton<global::Log>.Instance.Info(ELogModule.LevelEvent, ELogAuthor.JYS, "保底黑幕结束", default(ReadOnlySpan<ValueTuple<string, object>>));
				ModelBase<PlotModel>.Instance.IsFadeIn = false;
				Global.CharacterCameraManager.FadeAmount = 0f;
				ControllerBase<LevelLoadingController>.Instance.CloseLoading(ELoadingReason.Common, "GuaranteeActionBlackScreenFadeOut", delegate
				{
					ModelBase<LoadingModel>.Instance.ScreenEffect = new EScreenEffectType?(EScreenEffectType.ScreenEffectNone);
				}, new float?(1f));
				return;
			}
			Singleton<global::Log>.Instance.Info(ELogModule.LevelEvent, ELogAuthor.JYS, "执行到了保底黑幕结束,但因为不需要保底被return", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06044984 RID: 280964 RVA: 0x011D5178 File Offset: 0x011D3378
		protected override void OnClear(ActionParams @params = null, GeneralContext instigatorContext = null)
		{
			if (instigatorContext is GeneralLogicTreeContext)
			{
				GeneralLogicTreeContext generalLogicTreeContext = instigatorContext as GeneralLogicTreeContext;
				if (generalLogicTreeContext != null)
				{
					long treeIncId = generalLogicTreeContext.TreeIncId;
					if (ModelBase<GeneralLogicTreeModel>.Instance != null)
					{
						BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(generalLogicTreeContext.TreeIncId), false);
						if (behaviorTree != null && behaviorTree.GetRollbackPoint() <= 0)
						{
							return;
						}
					}
				}
			}
			IGuaranteeFadeInParams guaranteeFadeInParams = @params as IGuaranteeFadeInParams;
			if (guaranteeFadeInParams != null && guaranteeFadeInParams.KeepFadeAfterTreeRollBack.GetValueOrDefault() && ModelBase<GeneralLogicTreeModel>.Instance != null)
			{
				ModelBase<GeneralLogicTreeModel>.Instance.AddGuaranteeActionsWhenLogicTreeRemove(EGuaranteeAction.ActionBlackScreenFadeOut, @params, instigatorContext);
			}
		}
	}
}
