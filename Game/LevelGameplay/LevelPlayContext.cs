using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A4A RID: 27210
	public class LevelPlayContext : GeneralContext
	{
		// Token: 0x06043504 RID: 275716 RVA: 0x0114D949 File Offset: 0x0114BB49
		public LevelPlayContext()
		{
			this.Type = new EGeneralContextType?(EGeneralContextType.LevelPlay);
		}

		// Token: 0x06043505 RID: 275717 RVA: 0x0114D95D File Offset: 0x0114BB5D
		public override void Reset()
		{
			this.LevelPlayId = 0;
		}

		// Token: 0x06043506 RID: 275718 RVA: 0x0114D966 File Offset: 0x0114BB66
		[NullableContext(1)]
		public static LevelPlayContext Create(int levelPlayId = 0, GameCtxType? subType = null)
		{
			LevelPlayContext levelPlayContext = GeneralContext.GetObj(EGeneralContextType.LevelPlay, subType, () => new LevelPlayContext()) as LevelPlayContext;
			levelPlayContext.LevelPlayId = levelPlayId;
			return levelPlayContext;
		}

		// Token: 0x04025897 RID: 153751
		public int LevelPlayId;
	}
}
