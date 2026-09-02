using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Plot.Sequence.NpcPerformState
{
	// Token: 0x02005399 RID: 21401
	public class AssistedWalkSeqRelation : NpcRelation
	{
		// Token: 0x17008DA7 RID: 36263
		// (get) Token: 0x06036941 RID: 223553 RVA: 0x00DCC3BE File Offset: 0x00DCA5BE
		public override ENpcRelationType RelationType
		{
			get
			{
				return ENpcRelationType.AssistedWalk;
			}
		}

		// Token: 0x0401F714 RID: 128788
		[Nullable(1)]
		public string Key = "";

		// Token: 0x0401F715 RID: 128789
		public int LeaderEntityId;

		// Token: 0x0401F716 RID: 128790
		public int FollowerEntityId;
	}
}
