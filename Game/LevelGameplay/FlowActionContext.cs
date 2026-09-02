using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A50 RID: 27216
	[NullableContext(1)]
	[Nullable(0)]
	public class FlowActionContext : GeneralContext
	{
		// Token: 0x06043514 RID: 275732 RVA: 0x0114DB79 File Offset: 0x0114BD79
		public FlowActionContext()
		{
			this.Type = new EGeneralContextType?(EGeneralContextType.FlowAction);
		}

		// Token: 0x06043515 RID: 275733 RVA: 0x0114DB99 File Offset: 0x0114BD99
		public override void Reset()
		{
			this.FlowActionId = 0;
			this.FlowListName = "";
			this.FlowId = 0;
			this.StateId = 0;
		}

		// Token: 0x06043516 RID: 275734 RVA: 0x0114DBBC File Offset: 0x0114BDBC
		public static FlowActionContext Create(FlowActionCtxPb gameCtx, GameCtxType? subType = null)
		{
			FlowActionContext flowActionContext = GeneralContext.GetObj(EGeneralContextType.FlowAction, subType, () => new FlowActionContext()) as FlowActionContext;
			flowActionContext.FlowActionId = gameCtx.ActionId;
			flowActionContext.FlowListName = gameCtx.FlowListName;
			flowActionContext.FlowId = gameCtx.FlowId;
			flowActionContext.StateId = gameCtx.StateId;
			return flowActionContext;
		}

		// Token: 0x0402589F RID: 153759
		public int FlowActionId;

		// Token: 0x040258A0 RID: 153760
		public string FlowListName = "";

		// Token: 0x040258A1 RID: 153761
		public int FlowId;

		// Token: 0x040258A2 RID: 153762
		public int StateId;
	}
}
