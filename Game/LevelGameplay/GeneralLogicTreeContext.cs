using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A51 RID: 27217
	public class GeneralLogicTreeContext : GeneralContext
	{
		// Token: 0x06043517 RID: 275735 RVA: 0x0114DC25 File Offset: 0x0114BE25
		public GeneralLogicTreeContext()
		{
			this.Type = new EGeneralContextType?(EGeneralContextType.GeneralLogicTree);
		}

		// Token: 0x06043518 RID: 275736 RVA: 0x0114DC39 File Offset: 0x0114BE39
		public override void Reset()
		{
			this.TreeIncId = 0L;
			this.NodeId = 0;
		}

		// Token: 0x06043519 RID: 275737 RVA: 0x0114DC4C File Offset: 0x0114BE4C
		[NullableContext(1)]
		public static GeneralLogicTreeContext Create(BtType btType, long treeIncId = 0L, int treeConfigId = 0, int nodeId = 0, GameCtxType? subType = null)
		{
			GeneralLogicTreeContext generalLogicTreeContext = GeneralContext.GetObj(EGeneralContextType.GeneralLogicTree, subType, () => new GeneralLogicTreeContext()) as GeneralLogicTreeContext;
			generalLogicTreeContext.BtType = btType;
			generalLogicTreeContext.TreeIncId = treeIncId;
			generalLogicTreeContext.TreeConfigId = treeConfigId;
			generalLogicTreeContext.NodeId = nodeId;
			return generalLogicTreeContext;
		}

		// Token: 0x040258A3 RID: 153763
		public long TreeIncId;

		// Token: 0x040258A4 RID: 153764
		public int TreeConfigId;

		// Token: 0x040258A5 RID: 153765
		public int NodeId;

		// Token: 0x040258A6 RID: 153766
		public BtType BtType;
	}
}
