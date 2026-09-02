using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.Guarantee;
using CSharpScript.Game.Module.Gamepad;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C21 RID: 27681
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventTriggerGamepadShake : LevelEventBase
	{
		// Token: 0x060441AC RID: 278956 RVA: 0x011AF3E8 File Offset: 0x011AD5E8
		public LevelEventTriggerGamepadShake(int id) : base(id)
		{
		}

		// Token: 0x060441AD RID: 278957 RVA: 0x011AF3FC File Offset: 0x011AD5FC
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			TriggerGamepadShake triggerGamepadShake = inParams as TriggerGamepadShake;
			if (triggerGamepadShake == null || StringUtils.IsBlank(triggerGamepadShake.KuroForceFeedbackEffect))
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YSQ, "执行行为LevelEventTriggerGamepadShake失败，参数错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			ControllerBase<GamepadController>.Instance.TriggerGamepadShakeEvent(new IGamepadShakeOptions
			{
				KuroForceFeedbackEffect = triggerGamepadShake.KuroForceFeedbackEffect,
				GamepadShakeConfig = triggerGamepadShake.GamepadShakeConfig
			}, this.StopGamepadShake);
		}

		// Token: 0x060441AE RID: 278958 RVA: 0x011AF46C File Offset: 0x011AD66C
		protected override void OnUpdateGuarantee()
		{
			GuaranteeActionInfo p = new GuaranteeActionInfo
			{
				Name = EGuaranteeAction.StopGamepadShake,
				Params = this.StopGamepadShake
			};
			Singleton<EventSystem>.Instance.Emit<string, GeneralContext, GuaranteeActionInfo, bool?>(EEventName.AddGuaranteeAction, this.Type, this.BaseContext, p, null);
		}

		// Token: 0x04026093 RID: 155795
		private readonly StopGamepadShakeImpl StopGamepadShake = new StopGamepadShakeImpl();
	}
}
