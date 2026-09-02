using System;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058E2 RID: 22754
	public class PlayerMarkCreateInfo : MarkCreateInfo
	{
		// Token: 0x06039C01 RID: 236545 RVA: 0x00EA071A File Offset: 0x00E9E91A
		public PlayerMarkCreateInfo(int playerId, int playerIndex, FVector position, int mapId, EMapGravityDirection gravity = EMapGravityDirection.Down) : base(EMarkCreateType.PlayerMark)
		{
			this.PlayerId = playerId;
			this.PlayerIndex = playerIndex;
			this.Position = position;
			this.MapId = mapId;
			this.Gravity = gravity;
		}

		// Token: 0x04020BE6 RID: 134118
		public int PlayerId;

		// Token: 0x04020BE7 RID: 134119
		public int PlayerIndex;

		// Token: 0x04020BE8 RID: 134120
		public FVector Position;

		// Token: 0x04020BE9 RID: 134121
		public int MapId;

		// Token: 0x04020BEA RID: 134122
		public EMapGravityDirection Gravity;
	}
}
