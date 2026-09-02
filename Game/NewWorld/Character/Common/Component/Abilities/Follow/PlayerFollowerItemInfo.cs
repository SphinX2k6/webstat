using System;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow
{
	// Token: 0x02004979 RID: 18809
	public class PlayerFollowerItemInfo : IPlayerFollowerItemInfo
	{
		// Token: 0x170083D7 RID: 33751
		// (get) Token: 0x06031297 RID: 201367 RVA: 0x00C3DE8B File Offset: 0x00C3C08B
		// (set) Token: 0x06031298 RID: 201368 RVA: 0x00C3DE93 File Offset: 0x00C3C093
		public int Type { get; set; }

		// Token: 0x170083D8 RID: 33752
		// (get) Token: 0x06031299 RID: 201369 RVA: 0x00C3DE9C File Offset: 0x00C3C09C
		// (set) Token: 0x0603129A RID: 201370 RVA: 0x00C3DEA4 File Offset: 0x00C3C0A4
		public long EntityId { get; set; }
	}
}
