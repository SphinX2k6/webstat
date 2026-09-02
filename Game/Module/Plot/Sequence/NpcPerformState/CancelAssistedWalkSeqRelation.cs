using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Plot.Sequence.NpcPerformState
{
	// Token: 0x0200539B RID: 21403
	public class CancelAssistedWalkSeqRelation : NpcRelation
	{
		// Token: 0x17008DAA RID: 36266
		// (get) Token: 0x0603694B RID: 223563 RVA: 0x00DCCA9B File Offset: 0x00DCAC9B
		public override ENpcRelationType RelationType
		{
			get
			{
				return ENpcRelationType.CancelAssistedWalk;
			}
		}

		// Token: 0x0401F717 RID: 128791
		[Nullable(1)]
		public string Key = "";
	}
}
