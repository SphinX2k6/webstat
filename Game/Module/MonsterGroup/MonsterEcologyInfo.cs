using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.MonsterGroup
{
	// Token: 0x02005726 RID: 22310
	[NullableContext(1)]
	[Nullable(0)]
	public class MonsterEcologyInfo
	{
		// Token: 0x06038C67 RID: 232551 RVA: 0x00E6019C File Offset: 0x00E5E39C
		public MonsterEcologyInfo(int id, CharacterActorComponent actorComp, MonsterGroupEcologyInfo group, bool isCaptain)
		{
			this.PbDataId = id;
			this.EntityId = actorComp.Entity.Id;
			this.ActorComp = actorComp;
			this.MoveComp = this.ActorComp.Entity.GetComponent<BaseMoveComponent>();
			this.GroupAiComp = this.ActorComp.Entity.GetComponent<BaseGroupAiComponent>();
			this.Group = group;
			this.IsCaptain = isCaptain;
		}

		// Token: 0x17009124 RID: 37156
		// (get) Token: 0x06038C68 RID: 232552 RVA: 0x00E6021F File Offset: 0x00E5E41F
		// (set) Token: 0x06038C69 RID: 232553 RVA: 0x00E60228 File Offset: 0x00E5E428
		public EGroupEcologyState GroupEcologyState
		{
			get
			{
				return this.GroupEcologyStateInternal;
			}
			set
			{
				EGroupEcologyState groupEcologyStateInternal = this.GroupEcologyStateInternal;
				if (value == groupEcologyStateInternal)
				{
					return;
				}
				this.GroupEcologyStateInternal = value;
				if (groupEcologyStateInternal == EGroupEcologyState.Ecology)
				{
					BaseGroupAiComponent groupAiComp = this.GroupAiComp;
					if (groupAiComp == null)
					{
						return;
					}
					groupAiComp.StopEcologyAction();
				}
			}
		}

		// Token: 0x06038C6A RID: 232554 RVA: 0x00E6025C File Offset: 0x00E5E45C
		public static string StateToString(EGroupEcologyState state)
		{
			switch (state)
			{
			case EGroupEcologyState.None:
				return "None";
			case EGroupEcologyState.Ready:
				return "Ready";
			case EGroupEcologyState.Ecology:
				return "Ecology";
			default:
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Unknown(");
				defaultInterpolatedStringHandler.AppendFormatted<EGroupEcologyState>(state);
				defaultInterpolatedStringHandler.AppendLiteral(")");
				return defaultInterpolatedStringHandler.ToStringAndClear();
			}
			}
		}

		// Token: 0x0402057C RID: 132476
		private const float TARGET_END_DISTANCE = 30f;

		// Token: 0x0402057D RID: 132477
		public readonly int PbDataId;

		// Token: 0x0402057E RID: 132478
		public readonly int EntityId;

		// Token: 0x0402057F RID: 132479
		[Nullable(2)]
		public CharacterActorComponent ActorComp;

		// Token: 0x04020580 RID: 132480
		[Nullable(2)]
		public BaseMoveComponent MoveComp;

		// Token: 0x04020581 RID: 132481
		[Nullable(2)]
		public BaseGroupAiComponent GroupAiComp;

		// Token: 0x04020582 RID: 132482
		[Nullable(2)]
		public MonsterGroupEcologyInfo Group;

		// Token: 0x04020583 RID: 132483
		public bool IsCaptain;

		// Token: 0x04020584 RID: 132484
		public Vector TargetLocation = Vector.Create();

		// Token: 0x04020585 RID: 132485
		public Rotator TargetRotator = Rotator.Create();

		// Token: 0x04020586 RID: 132486
		private EGroupEcologyState GroupEcologyStateInternal;
	}
}
