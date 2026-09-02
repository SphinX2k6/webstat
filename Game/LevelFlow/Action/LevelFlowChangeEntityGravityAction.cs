using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006F8B RID: 28555
	public class LevelFlowChangeEntityGravityAction : LevelFlowActionBase
	{
		// Token: 0x06045185 RID: 283013 RVA: 0x01205E61 File Offset: 0x01204061
		[NullableContext(1)]
		public LevelFlowChangeEntityGravityAction Init(int entityId, global::Vector gravity)
		{
			this.EntityId = entityId;
			this.Gravity = gravity;
			return this;
		}

		// Token: 0x06045186 RID: 283014 RVA: 0x01205E74 File Offset: 0x01204074
		protected override void OnExecute()
		{
			EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(this.EntityId);
			if (entityById == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelFlow;
				ELogAuthor author = ELogAuthor.BB;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 1);
				defaultInterpolatedStringHandler.AppendLiteral("EntityId: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.EntityId);
				defaultInterpolatedStringHandler.AppendLiteral(" not found");
				instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false);
				return;
			}
			CreatureDataComponent component = entityById.Entity.GetComponent<CreatureDataComponent>();
			if (component == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.LevelFlow;
				ELogAuthor author2 = ELogAuthor.BB;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(42, 1);
				defaultInterpolatedStringHandler.AppendLiteral("EntityId: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.EntityId);
				defaultInterpolatedStringHandler.AppendLiteral(" not found CreatureDataComponent");
				instance2.Error(module2, author2, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false);
				return;
			}
			if (component.GetEntityType() == EEntityType.Vehicle)
			{
				VehicleGravityComponent component2 = entityById.Entity.GetComponent<VehicleGravityComponent>();
				if (component2 != null)
				{
					component2.SetGravityDirectForVehicle(0, this.Gravity, false, -1f, false);
				}
			}
			else
			{
				BaseGravityComponent component3 = entityById.Entity.GetComponent<BaseGravityComponent>();
				if (component3 != null)
				{
					component3.SetGravityByPriority(0, this.Gravity, true, -1f, true);
				}
			}
			base.FinishExecute(true);
		}

		// Token: 0x040268E7 RID: 157927
		private int EntityId;

		// Token: 0x040268E8 RID: 157928
		[Nullable(2)]
		private global::Vector Gravity;
	}
}
