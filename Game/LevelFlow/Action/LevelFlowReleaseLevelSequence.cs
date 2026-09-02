using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006FA3 RID: 28579
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelFlowReleaseLevelSequence : LevelFlowActionBase
	{
		// Token: 0x0604520C RID: 283148 RVA: 0x012093AC File Offset: 0x012075AC
		public LevelFlowReleaseLevelSequence Init(string sequencePath)
		{
			this.SequencePath = sequencePath;
			return this;
		}

		// Token: 0x0604520D RID: 283149 RVA: 0x012093B6 File Offset: 0x012075B6
		protected override void OnExecute()
		{
			LevelFlowResourceManager.ReleaseSequence(this.SequencePath);
			base.FinishExecute(true);
		}

		// Token: 0x0402691E RID: 157982
		private string SequencePath = string.Empty;
	}
}
