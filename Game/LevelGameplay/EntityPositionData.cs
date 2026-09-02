using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A14 RID: 27156
	[NullableContext(1)]
	[Nullable(0)]
	public class EntityPositionData
	{
		// Token: 0x060433E8 RID: 275432 RVA: 0x0114A083 File Offset: 0x01148283
		public EntityPositionData(int entityId, PosA pos)
		{
			this.EntityId = entityId;
			this.Pos = pos;
		}

		// Token: 0x1700A207 RID: 41479
		// (get) Token: 0x060433E9 RID: 275433 RVA: 0x0114A099 File Offset: 0x01148299
		public int EntityId { get; }

		// Token: 0x1700A208 RID: 41480
		// (get) Token: 0x060433EA RID: 275434 RVA: 0x0114A0A1 File Offset: 0x011482A1
		public PosA Pos { get; }
	}
}
