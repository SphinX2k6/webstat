using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A47 RID: 27207
	public class EntityContext : GeneralContext
	{
		// Token: 0x060434FB RID: 275707 RVA: 0x0114D814 File Offset: 0x0114BA14
		public EntityContext()
		{
			this.Type = new EGeneralContextType?(EGeneralContextType.Entity);
		}

		// Token: 0x060434FC RID: 275708 RVA: 0x0114D834 File Offset: 0x0114BA34
		public override void Reset()
		{
			this.EntityId = new int?(0);
		}

		// Token: 0x060434FD RID: 275709 RVA: 0x0114D842 File Offset: 0x0114BA42
		[NullableContext(1)]
		public static EntityContext Create(int entityId = 0, GameCtxType? subType = null)
		{
			EntityContext entityContext = GeneralContext.GetObj(EGeneralContextType.Entity, subType, () => new EntityContext()) as EntityContext;
			entityContext.EntityId = new int?(entityId);
			return entityContext;
		}

		// Token: 0x04025891 RID: 153745
		public int? EntityId = new int?(0);

		// Token: 0x04025892 RID: 153746
		public bool ClientExecuteActions;

		// Token: 0x04025893 RID: 153747
		[Nullable(2)]
		public string SequencePath;
	}
}
