using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A4B RID: 27211
	public class InstanceDungeonContext : GeneralContext
	{
		// Token: 0x06043507 RID: 275719 RVA: 0x0114D99A File Offset: 0x0114BB9A
		public InstanceDungeonContext()
		{
			this.Type = new EGeneralContextType?(EGeneralContextType.InstanceDungeon);
		}

		// Token: 0x06043508 RID: 275720 RVA: 0x0114D9BA File Offset: 0x0114BBBA
		public override void Reset()
		{
			this.InstanceDungeonId = new int?(0);
		}

		// Token: 0x06043509 RID: 275721 RVA: 0x0114D9C8 File Offset: 0x0114BBC8
		[NullableContext(1)]
		public static InstanceDungeonContext Create(int instanceDungeonId = 0, int nodeId = 0, GameCtxType? subType = null)
		{
			InstanceDungeonContext instanceDungeonContext = GeneralContext.GetObj(EGeneralContextType.InstanceDungeon, subType, () => new InstanceDungeonContext()) as InstanceDungeonContext;
			instanceDungeonContext.InstanceDungeonId = new int?(instanceDungeonId);
			return instanceDungeonContext;
		}

		// Token: 0x04025898 RID: 153752
		public int? InstanceDungeonId = new int?(0);
	}
}
