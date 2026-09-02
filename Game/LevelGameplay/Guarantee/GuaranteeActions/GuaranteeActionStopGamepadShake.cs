using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.Guarantee.GuaranteeActions
{
	// Token: 0x02006E79 RID: 28281
	public class GuaranteeActionStopGamepadShake : GuaranteeActionBase
	{
		// Token: 0x06044998 RID: 280984 RVA: 0x011D5604 File Offset: 0x011D3804
		[NullableContext(2)]
		protected override void OnExecute(ActionParams @params)
		{
			IStopGamepadShake stopGamepadShake = @params as IStopGamepadShake;
			if (stopGamepadShake == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YSQ, "执行保底行为GuaranteeActionStopGamepadShake失败，参数错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			Global.CharacterController.StopKuroForceFeedback(stopGamepadShake.GamepadShakeAsset, stopGamepadShake.Tag);
			UForceFeedbackComponent feedbackComponent = stopGamepadShake.FeedbackComponent;
			if (feedbackComponent != null && feedbackComponent.IsValid())
			{
				stopGamepadShake.FeedbackComponent.Stop();
			}
			Singleton<global::Log>.Instance.Info(ELogModule.LevelEvent, ELogAuthor.CB, "保底终止", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}
}
