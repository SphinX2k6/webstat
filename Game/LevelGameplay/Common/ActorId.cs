using System;

namespace CSharpScript.Game.LevelGamePlay.Common
{
	// Token: 0x02006F29 RID: 28457
	public class ActorId
	{
		// Token: 0x06044E90 RID: 282256 RVA: 0x011F07FC File Offset: 0x011EE9FC
		public ActorId(int id, EIdType type)
		{
			this.Id = id;
			this.Type = type;
		}

		// Token: 0x040266BC RID: 157372
		public int Id;

		// Token: 0x040266BD RID: 157373
		public EIdType Type;
	}
}
