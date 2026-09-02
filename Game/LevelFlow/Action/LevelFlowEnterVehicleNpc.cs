using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006F91 RID: 28561
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelFlowEnterVehicleNpc : LevelFlowActionBase
	{
		// Token: 0x0604519D RID: 283037 RVA: 0x01206677 File Offset: 0x01204877
		public LevelFlowEnterVehicleNpc Init(EnterNpcVehicle params_)
		{
			this.Params = params_;
			return this;
		}

		// Token: 0x0604519E RID: 283038 RVA: 0x01206681 File Offset: 0x01204881
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<VehiclePassengerInfo, bool>(EEventName.OnEnterVehicle, new Action<VehiclePassengerInfo, bool>(this.OnEnterVehicle));
		}

		// Token: 0x0604519F RID: 283039 RVA: 0x0120669F File Offset: 0x0120489F
		protected override void OnExecute()
		{
			if (this.Params == null)
			{
				base.FinishExecute(false);
				return;
			}
			if (this.Params.Target == 0)
			{
				base.FinishExecute(false);
				return;
			}
			base.CreateWaitEntityTask(this.Params.Target);
		}

		// Token: 0x060451A0 RID: 283040 RVA: 0x012066DC File Offset: 0x012048DC
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<VehiclePassengerInfo, bool>(EEventName.OnEnterVehicle, new Action<VehiclePassengerInfo, bool>(this.OnEnterVehicle));
		}

		// Token: 0x060451A1 RID: 283041 RVA: 0x012066FC File Offset: 0x012048FC
		protected override void ExecuteWhenEntitiesReady()
		{
			if (this.Params == null)
			{
				base.FinishExecute(false);
				return;
			}
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			Entity entity;
			if (baseCharacter == null)
			{
				entity = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
				entity = ((characterActorComponent != null) ? characterActorComponent.Entity : null);
			}
			Entity entity2 = entity;
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(this.Params.Target);
			WorldEntity worldEntity = (entityByPbDataId != null) ? entityByPbDataId.Entity : null;
			if (entity2 == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelFlow, ELogAuthor.BB, "进入载具NPC时无法获取目标乘客", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false);
				return;
			}
			if (worldEntity == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelFlow, ELogAuthor.BB, "进入载具NPC时无法获取目标载具", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false);
				return;
			}
			BaseVehiclePerformComponent component = worldEntity.GetComponent<BaseVehiclePerformComponent>();
			if (component == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelFlow;
				ELogAuthor author = ELogAuthor.BB;
				string message = "进入载具NPC时获取目标载具实体失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TargetVehicle", this.Params.Target);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.FinishExecute(false);
				return;
			}
			CharacterDriveVehicleComponent component2 = entity2.GetComponent<CharacterDriveVehicleComponent>();
			if (component2 == null)
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.LevelFlow;
				ELogAuthor author2 = ELogAuthor.BB;
				string message2 = "进入载具NPC时获取目标载具实体失败";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("TargetVehicle", this.Params.Target);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				base.FinishExecute(false);
				return;
			}
			if (component2.IsOnVehicle)
			{
				base.FinishExecute(true);
				return;
			}
			if (!component.TryEnter(entity2, this.Params.Seat))
			{
				global::Log instance3 = Singleton<global::Log>.Instance;
				ELogModule module3 = ELogModule.LevelFlow;
				ELogAuthor author3 = ELogAuthor.BB;
				string message3 = "进入载具NPC时尝试进入载具失败";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("TargetVehicle", this.Params.Target);
				instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				base.FinishExecute(false);
			}
		}

		// Token: 0x060451A2 RID: 283042 RVA: 0x012068AC File Offset: 0x01204AAC
		private void OnEnterVehicle(VehiclePassengerInfo info, bool byChangeRole)
		{
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(this.Params.Target);
			WorldEntity worldEntity = (entityByPbDataId != null) ? entityByPbDataId.Entity : null;
			if (info.VehicleEntity != null)
			{
				int id = info.VehicleEntity.Id;
				int? num = (worldEntity != null) ? new int?(worldEntity.Id) : null;
				if (id == num.GetValueOrDefault() & num != null)
				{
					base.FinishExecute(true);
				}
			}
		}

		// Token: 0x040268F3 RID: 157939
		[Nullable(2)]
		private EnterNpcVehicle Params;
	}
}
