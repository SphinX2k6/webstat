using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C20 RID: 27680
	public class LevelEventTriggerDeadEyeMode : LevelEventBase
	{
		// Token: 0x060441AA RID: 278954 RVA: 0x011AF2AC File Offset: 0x011AD4AC
		public LevelEventTriggerDeadEyeMode(int id) : base(id)
		{
		}

		// Token: 0x060441AB RID: 278955 RVA: 0x011AF2B8 File Offset: 0x011AD4B8
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			TriggerDeadeyeMode triggerDeadeyeMode = inParams as TriggerDeadeyeMode;
			if (triggerDeadeyeMode == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YSQ, "执行行为LevelEventTriggerDeadEyeMode失败，参数错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YSQ, "执行行为LevelEventTriggerDeadEyeMode失败，CurrentEntity为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			CharacterDriveVehicleComponent component = getCurrentEntity.Entity.GetComponent<CharacterDriveVehicleComponent>();
			if (component == null || !component.IsDriver)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YSQ, "执行行为LevelEventTriggerDeadEyeMode失败，不在驾驶状态", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (context.Type.GetValueOrDefault() == EGeneralContextType.Trigger)
			{
				TriggerContext triggerContext = context as TriggerContext;
				if (triggerContext != null && triggerContext.TriggerEntityId != null)
				{
					Entity entity = Singleton<EntitySystem>.Instance.Get(triggerContext.TriggerEntityId.Value);
					if (entity == null)
					{
						Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YSQ, "执行行为LevelEventTriggerDeadEyeMode失败，触发器实体不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
						return;
					}
					CreatureDataComponent component2 = entity.GetComponent<CreatureDataComponent>();
					ControllerBase<DeadEyeModeController>.Instance.EnterDeadEyeJumpPlatform(triggerDeadeyeMode, component2.GetCreatureDataId());
					return;
				}
			}
			Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YSQ, "执行行为LevelEventTriggerDeadEyeMode失败，上下文参数不对", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}
}
