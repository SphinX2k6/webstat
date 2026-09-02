using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C27 RID: 27687
	[NullableContext(2)]
	[Nullable(0)]
	public class LevelEventVehicleMoveWithPathLine : LevelEventBase
	{
		// Token: 0x060441BA RID: 278970 RVA: 0x011AF8CC File Offset: 0x011ADACC
		public LevelEventVehicleMoveWithPathLine(int id) : base(id)
		{
		}

		// Token: 0x060441BB RID: 278971 RVA: 0x011AF8E0 File Offset: 0x011ADAE0
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			this.Params = (inParams as VehicleMoveWithPathLine);
			if (this.Params == null)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			switch (this.Params.TargetVehicle.Type)
			{
			case ETargetVehicle.Current:
			{
				TsBaseCharacter baseCharacter = Global.BaseCharacter;
				if (baseCharacter == null || !baseCharacter.IsValid())
				{
					this.DelayExecuteList.Add(new ValueTuple<ActionParams, GeneralContext>(inParams, context));
					if (this.DelayExecuteHandle == null)
					{
						this.DelayExecuteHandle = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnRefreshBaseCharacter), 500f, 1f, null, null, true);
					}
					return;
				}
				this.Entity = this.GetVehicleEntityFromPlayerRole();
				if (this.Entity == null && this.Params.ControlType.Type == EVehicleControlType.ExitPathMoving)
				{
					base.FinishExecute(true, false, true);
					return;
				}
				this.ChangeControlState();
				return;
			}
			case ETargetVehicle.Appointed:
				base.CreateWaitEntityTask((this.Params.TargetVehicle as IAppointedVehicle).VehicleId);
				return;
			case ETargetVehicle.Triggered:
				this.Entity = this.GetVehicleEntityFromTrigger(context);
				this.ChangeControlState();
				return;
			}
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.LevelEvent;
			ELogAuthor author = ELogAuthor.YJX;
			string message = "不支持的目标类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", this.Params.TargetVehicle.Type);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(false, false, true);
		}

		// Token: 0x060441BC RID: 278972 RVA: 0x011AFA3D File Offset: 0x011ADC3D
		protected override void ExecuteWhenEntitiesReady()
		{
			this.GetTargetVehicleEntity(this.Params.TargetVehicle);
			this.ChangeControlState();
		}

		// Token: 0x060441BD RID: 278973 RVA: 0x011AFA58 File Offset: 0x011ADC58
		[NullableContext(1)]
		private void GetTargetVehicleEntity(ITargetVehicle config)
		{
			ETargetVehicle type = config.Type;
			if (type == ETargetVehicle.Current)
			{
				this.Entity = this.GetVehicleEntityFromPlayerRole();
				return;
			}
			if (type != ETargetVehicle.Appointed)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.YJX;
				string message = "不支持的目标类型";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", config.Type);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId((config as IAppointedVehicle).VehicleId);
			this.Entity = ((entityByPbDataId != null) ? entityByPbDataId.Entity : null);
		}

		// Token: 0x060441BE RID: 278974 RVA: 0x011AFADC File Offset: 0x011ADCDC
		private Entity GetVehicleEntityFromPlayerRole()
		{
			if (Global.BaseCharacter == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YJX, "获取玩家载具失败，找不到全局玩家角色", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			CharacterDriveVehicleComponent component = Global.BaseCharacter.CharacterActorComponent.Entity.GetComponent<CharacterDriveVehicleComponent>();
			Entity entity = (component != null) ? component.VehicleEntity : null;
			if (entity == null)
			{
				Singleton<global::Log>.Instance.Warn(ELogModule.LevelEvent, ELogAuthor.YJX, "获取玩家载具失败，玩家当前表现上并未乘坐载具", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			return entity;
		}

		// Token: 0x060441BF RID: 278975 RVA: 0x011AFB54 File Offset: 0x011ADD54
		[NullableContext(1)]
		[return: Nullable(2)]
		private unsafe Entity GetVehicleEntityFromTrigger(GeneralContext context)
		{
			if (context.Type.GetValueOrDefault() != EGeneralContextType.Trigger)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.YJX;
				string message = "获取载具失败，尝试从非触发器获取触发实体对象";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Type", context.Type);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SubType", context.SubType);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return null;
			}
			TriggerContext triggerContext = context as TriggerContext;
			if (triggerContext.OtherEntityId == null)
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.LevelEvent;
				ELogAuthor author2 = ELogAuthor.YJX;
				string message2 = "获取载具失败，触发器实体ID不合法";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", triggerContext.OtherEntityId);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			Entity entity = Singleton<EntitySystem>.Instance.Get(triggerContext.OtherEntityId.GetValueOrDefault());
			if (entity == null)
			{
				global::Log instance3 = Singleton<global::Log>.Instance;
				ELogModule module3 = ELogModule.LevelEvent;
				ELogAuthor author3 = ELogAuthor.YJX;
				string message3 = "获取载具失败，无法获取实体对象";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("EntityId", triggerContext.OtherEntityId);
				instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			return entity;
		}

		// Token: 0x060441C0 RID: 278976 RVA: 0x011AFC68 File Offset: 0x011ADE68
		private void ChangeControlState()
		{
			if (this.Entity == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YJX, "设置载具控制状态失败，无法找到目标实体", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false, false, true);
				return;
			}
			EVehicleControlType type = this.Params.ControlType.Type;
			if (type != EVehicleControlType.EnterPathMoving)
			{
				if (type != EVehicleControlType.ExitPathMoving)
				{
					base.FinishExecute(false, false, true);
					return;
				}
				int splineEntityId = this.Params.SplineEntityId;
				VehicleSplineMoveComponent component = this.Entity.GetComponent<VehicleSplineMoveComponent>();
				if (component != null)
				{
					component.ResetExtraMoveParams();
				}
				if (component != null)
				{
					component.EndSplineMove(splineEntityId);
				}
			}
			else
			{
				int splineEntityId2 = this.Params.SplineEntityId;
				VehicleSplineMoveComponent component2 = this.Entity.GetComponent<VehicleSplineMoveComponent>();
				if (component2 != null)
				{
					component2.SetExtraMoveParams((this.Params.ControlType as IVehicleEnterPathMove).ControlParams);
				}
				if (component2 != null)
				{
					component2.StartSplineMove(splineEntityId2, (this.Params.ControlType as IVehicleEnterPathMove).Pattern, false);
				}
			}
			base.FinishExecute(true, false, true);
		}

		// Token: 0x060441C1 RID: 278977 RVA: 0x011AFD60 File Offset: 0x011ADF60
		private void OnRefreshBaseCharacter(float delta)
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter == null || !baseCharacter.IsValid())
			{
				return;
			}
			TimerSystem.GameplayTimeInstance.Remove(this.DelayExecuteHandle);
			this.DelayExecuteHandle = null;
			foreach (ValueTuple<ActionParams, GeneralContext> valueTuple in this.DelayExecuteList)
			{
				this.ExecuteNew(valueTuple.Item1, valueTuple.Item2, null);
			}
			this.DelayExecuteList.Clear();
		}

		// Token: 0x04026095 RID: 155797
		private const float CHECK_BASE_CHARACTER_INTERVAL = 500f;

		// Token: 0x04026096 RID: 155798
		private Entity Entity;

		// Token: 0x04026097 RID: 155799
		private VehicleMoveWithPathLine Params;

		// Token: 0x04026098 RID: 155800
		private TimerHandle DelayExecuteHandle;

		// Token: 0x04026099 RID: 155801
		[Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})]
		private readonly List<ValueTuple<ActionParams, GeneralContext>> DelayExecuteList = new List<ValueTuple<ActionParams, GeneralContext>>();
	}
}
