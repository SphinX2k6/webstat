using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A49 RID: 27209
	public class QuestContext : GeneralContext
	{
		// Token: 0x06043501 RID: 275713 RVA: 0x0114D8F8 File Offset: 0x0114BAF8
		public QuestContext()
		{
			this.Type = new EGeneralContextType?(EGeneralContextType.Quest);
		}

		// Token: 0x06043502 RID: 275714 RVA: 0x0114D90C File Offset: 0x0114BB0C
		public override void Reset()
		{
			this.QuestId = 0;
		}

		// Token: 0x06043503 RID: 275715 RVA: 0x0114D915 File Offset: 0x0114BB15
		[NullableContext(1)]
		public static QuestContext Create(int questId = 0, GameCtxType? subType = null)
		{
			QuestContext questContext = GeneralContext.GetObj(EGeneralContextType.Quest, subType, () => new QuestContext()) as QuestContext;
			questContext.QuestId = questId;
			return questContext;
		}

		// Token: 0x04025896 RID: 153750
		public int QuestId;
	}
}
