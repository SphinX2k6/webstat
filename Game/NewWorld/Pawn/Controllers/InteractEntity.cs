using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Pawn.Controllers
{
	// Token: 0x020048A7 RID: 18599
	[NullableContext(1)]
	[Nullable(0)]
	public class InteractEntity
	{
		// Token: 0x0603075C RID: 198492 RVA: 0x00BE1350 File Offset: 0x00BDF550
		public InteractEntity(Entity entity)
		{
			this.Entity = entity;
			this.EntityId = ((entity != null) ? new int?(entity.Id) : null);
			this.IsAdvice = (entity.GetComponent<CreatureDataComponent>().GetAdviceInfo() != null);
			this.ActorComp = entity.GetComponent<BaseActorComponent>();
			this.DirectOptionInstanceIds = new List<int>();
			this.DirectOptionNames = new List<string>();
		}

		// Token: 0x170082A4 RID: 33444
		// (get) Token: 0x0603075D RID: 198493 RVA: 0x00BE13EC File Offset: 0x00BDF5EC
		public int Priority
		{
			get
			{
				if (this.Entity == null)
				{
					return -9999;
				}
				if (this.IsAdvice)
				{
					Vector actorLocationProxy = this.ActorComp.ActorLocationProxy;
					Vector actorLocationProxy2 = Global.BaseCharacter.CharacterActorComponent.ActorLocationProxy;
					double num = Vector.Distance(actorLocationProxy, actorLocationProxy2);
					this.PriorityInternal = (int)(MathCommon.Clamp(num / (double)this.InteractRange, 0.0, 1.0) * -100.0);
				}
				return this.PriorityInternal;
			}
		}

		// Token: 0x0603075E RID: 198494 RVA: 0x00BE1468 File Offset: 0x00BDF668
		public Entity GetEntity()
		{
			return this.Entity;
		}

		// Token: 0x0401BD5C RID: 114012
		private const int AdvicePriority = -100;

		// Token: 0x0401BD5D RID: 114013
		private const int MinPriority = -9999;

		// Token: 0x0401BD5E RID: 114014
		public readonly bool IsAdvice;

		// Token: 0x0401BD5F RID: 114015
		[Nullable(2)]
		private readonly Entity Entity;

		// Token: 0x0401BD60 RID: 114016
		[Nullable(2)]
		private readonly BaseActorComponent ActorComp;

		// Token: 0x0401BD61 RID: 114017
		public int? EntityId;

		// Token: 0x0401BD62 RID: 114018
		public float InteractRange;

		// Token: 0x0401BD63 RID: 114019
		private int PriorityInternal;

		// Token: 0x0401BD64 RID: 114020
		public List<int> DirectOptionInstanceIds = new List<int>();

		// Token: 0x0401BD65 RID: 114021
		[Nullable(new byte[]
		{
			1,
			2
		})]
		public List<string> DirectOptionNames = new List<string>();

		// Token: 0x0401BD66 RID: 114022
		[Nullable(new byte[]
		{
			1,
			2
		})]
		public List<string> DirectOptionConditionIcon = new List<string>();

		// Token: 0x0401BD67 RID: 114023
		public List<bool> DirectOptionGray = new List<bool>();
	}
}
