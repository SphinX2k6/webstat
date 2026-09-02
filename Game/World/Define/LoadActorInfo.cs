using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.World.Define
{
	// Token: 0x020046DE RID: 18142
	[NullableContext(2)]
	[Nullable(0)]
	public class LoadActorInfo
	{
		// Token: 0x0602F308 RID: 193288 RVA: 0x00B2E26F File Offset: 0x00B2C46F
		private LoadActorInfo(long entityId, Entity entity, AActor actor)
		{
			this.EntityId = entityId;
			this.Entity = entity;
			this.Actor = actor;
		}

		// Token: 0x0602F309 RID: 193289 RVA: 0x00B2E28C File Offset: 0x00B2C48C
		public bool IsValid()
		{
			return this.EntityId != 0L && this.Entity != null && this.Actor != null;
		}

		// Token: 0x0602F30A RID: 193290 RVA: 0x00B2E2AD File Offset: 0x00B2C4AD
		[return: Nullable(1)]
		public static LoadActorInfo Create(long entityId, Entity entity = null, AActor actor = null)
		{
			return new LoadActorInfo(entityId, entity, actor);
		}

		// Token: 0x0401AE28 RID: 110120
		private const long zero = 0L;

		// Token: 0x0401AE29 RID: 110121
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static readonly LoadActorInfo Undefined = new LoadActorInfo(0L, null, null);

		// Token: 0x0401AE2A RID: 110122
		public readonly long EntityId;

		// Token: 0x0401AE2B RID: 110123
		public readonly Entity Entity;

		// Token: 0x0401AE2C RID: 110124
		public readonly AActor Actor;
	}
}
