using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A4F RID: 27215
	public class PlotContext : GeneralContext
	{
		// Token: 0x06043511 RID: 275729 RVA: 0x0114DB25 File Offset: 0x0114BD25
		public PlotContext()
		{
			this.Type = new EGeneralContextType?(EGeneralContextType.Plot);
		}

		// Token: 0x06043512 RID: 275730 RVA: 0x0114DB3A File Offset: 0x0114BD3A
		public override void Reset()
		{
			this.FlowIncId = 0L;
		}

		// Token: 0x06043513 RID: 275731 RVA: 0x0114DB44 File Offset: 0x0114BD44
		[NullableContext(1)]
		public static PlotContext Create(long flowIncId, GameCtxType? subType = null)
		{
			PlotContext plotContext = GeneralContext.GetObj(EGeneralContextType.Plot, subType, () => new PlotContext()) as PlotContext;
			plotContext.FlowIncId = flowIncId;
			return plotContext;
		}

		// Token: 0x0402589E RID: 153758
		public long FlowIncId;
	}
}
