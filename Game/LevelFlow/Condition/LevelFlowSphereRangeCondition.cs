using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelFlow.Condition
{
	// Token: 0x02006F83 RID: 28547
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelFlowSphereRangeCondition : LevelFlowConditionBase
	{
		// Token: 0x06045156 RID: 282966 RVA: 0x01203B0C File Offset: 0x01201D0C
		public LevelFlowSphereRangeCondition Init(float radius, Vector center)
		{
			if (Global.BaseCharacter == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.LevelFlow, ELogAuthor.BB, "Invalid BaseCharacter", default(ReadOnlySpan<ValueTuple<string, object>>));
				return this;
			}
			EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(Global.BaseCharacter.EntityId);
			if (entityById == null || !entityById.Valid)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelFlow;
				ELogAuthor author = ELogAuthor.BB;
				string message = "Invalid EntityId";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("targetEntityId", Global.BaseCharacter.EntityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return this;
			}
			this.TargetActorComponent = entityById.Entity.CheckGetComponent<BaseActorComponent>();
			if (this.TargetActorComponent == null)
			{
				return this;
			}
			this.RadiusSquared = radius * radius;
			this.Center = center;
			return this;
		}

		// Token: 0x06045157 RID: 282967 RVA: 0x01203BC8 File Offset: 0x01201DC8
		protected override void OnTick(float delta)
		{
			if (this.TargetActorComponent == null || !this.TargetActorComponent.Valid)
			{
				Singleton<Log>.Instance.Error(ELogModule.LevelFlow, ELogAuthor.BB, "TargetActorComponent is invalid", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false);
				return;
			}
			if (Vector.DistSquared(this.TargetActorComponent.ActorLocationProxy, this.Center) <= (double)this.RadiusSquared)
			{
				base.FinishExecute(true);
			}
		}

		// Token: 0x040268CB RID: 157899
		private float RadiusSquared;

		// Token: 0x040268CC RID: 157900
		private Vector Center = Vector.ZeroVectorProxy;

		// Token: 0x040268CD RID: 157901
		[Nullable(2)]
		private BaseActorComponent TargetActorComponent;
	}
}
