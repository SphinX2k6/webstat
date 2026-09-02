using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A4E RID: 27214
	public class GmLevelActionContext : GeneralContext
	{
		// Token: 0x0604350E RID: 275726 RVA: 0x0114DAE2 File Offset: 0x0114BCE2
		public GmLevelActionContext()
		{
			this.Type = new EGeneralContextType?(EGeneralContextType.GmLevelAction);
		}

		// Token: 0x0604350F RID: 275727 RVA: 0x0114DAF6 File Offset: 0x0114BCF6
		public override void Reset()
		{
		}

		// Token: 0x06043510 RID: 275728 RVA: 0x0114DAF8 File Offset: 0x0114BCF8
		[NullableContext(1)]
		public static GmLevelActionContext Create(GameCtxType? subType = null)
		{
			return GeneralContext.GetObj(EGeneralContextType.GmLevelAction, subType, () => new GmLevelActionContext()) as GmLevelActionContext;
		}
	}
}
