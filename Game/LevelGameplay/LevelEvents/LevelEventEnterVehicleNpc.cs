using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B96 RID: 27542
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventEnterVehicleNpc : LevelEventBase
	{
		// Token: 0x06043F65 RID: 278373 RVA: 0x0119BAC7 File Offset: 0x01199CC7
		public LevelEventEnterVehicleNpc(int id) : base(id)
		{
		}

		// Token: 0x06043F66 RID: 278374 RVA: 0x0119BAD0 File Offset: 0x01199CD0
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			this.Params = (inParams as EnterNpcVehicle);
			this.Context = context;
			if (this.Params == null)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			int target = this.Params.Target;
			base.CreateWaitEntityTask(this.Params.Target);
		}

		// Token: 0x06043F67 RID: 278375 RVA: 0x0119BB20 File Offset: 0x01199D20
		protected override void ExecuteWhenEntitiesReady()
		{
			EnterNpcVehicle @params = this.Params;
			GeneralContext context = this.Context;
			if (@params == null || context == null)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			this.ExecuteEnterVehicle(@params, context);
		}

		// Token: 0x06043F68 RID: 278376 RVA: 0x0119BB54 File Offset: 0x01199D54
		private void ExecuteEnterVehicle(EnterNpcVehicle config, GeneralContext context)
		{
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
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(config.Target);
			WorldEntity worldEntity = (entityByPbDataId != null) ? entityByPbDataId.Entity : null;
			if (entity2 == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Vehicle, ELogAuthor.YJX, "进入载具NPC时无法获取目标乘客", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false, false, true);
				return;
			}
			BaseVehiclePerformComponent baseVehiclePerformComponent = (worldEntity != null) ? worldEntity.GetComponent<BaseVehiclePerformComponent>() : null;
			if (baseVehiclePerformComponent == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Vehicle;
				ELogAuthor author = ELogAuthor.YJX;
				string message = "进入载具NPC时获取目标载具实体失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TargetVehicle", config.Target);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.FinishExecute(false, false, true);
				return;
			}
			baseVehiclePerformComponent.TryEnter(entity2, config.Seat);
			base.FinishExecute(true, false, true);
		}

		// Token: 0x04026010 RID: 155664
		[Nullable(2)]
		private EnterNpcVehicle Params;

		// Token: 0x04026011 RID: 155665
		[Nullable(2)]
		private GeneralContext Context;
	}
}
