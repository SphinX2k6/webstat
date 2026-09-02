using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A48 RID: 27208
	public class DynamicInteractContext : GeneralContext
	{
		// Token: 0x060434FE RID: 275710 RVA: 0x0114D87B File Offset: 0x0114BA7B
		public DynamicInteractContext()
		{
			this.Type = new EGeneralContextType?(EGeneralContextType.DynamicInteract);
		}

		// Token: 0x060434FF RID: 275711 RVA: 0x0114D89C File Offset: 0x0114BA9C
		public override void Reset()
		{
			this.EntityId = new int?(0);
		}

		// Token: 0x06043500 RID: 275712 RVA: 0x0114D8AC File Offset: 0x0114BAAC
		[NullableContext(1)]
		public static DynamicInteractContext Create(int entityId = 0, [Nullable(2)] GeneralContext finalContexrpb = null, GameCtxType? subType = null)
		{
			DynamicInteractContext dynamicInteractContext = GeneralContext.GetObj(EGeneralContextType.DynamicInteract, subType, () => new DynamicInteractContext()) as DynamicInteractContext;
			dynamicInteractContext.EntityId = new int?(entityId);
			dynamicInteractContext.FinalContext = finalContexrpb;
			return dynamicInteractContext;
		}

		// Token: 0x04025894 RID: 153748
		public int? EntityId = new int?(0);

		// Token: 0x04025895 RID: 153749
		[Nullable(2)]
		public GeneralContext FinalContext;
	}
}
