using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006FAC RID: 28588
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelFlowShowHookEffectAction : LevelFlowActionBase
	{
		// Token: 0x0604522F RID: 283183 RVA: 0x01209FD6 File Offset: 0x012081D6
		public LevelFlowShowHookEffectAction Init(int entityId, string targetTag, int cueId)
		{
			this.EntityId = entityId;
			this.TargetTag = targetTag;
			this.CueId = cueId;
			return this;
		}

		// Token: 0x06045230 RID: 283184 RVA: 0x01209FEE File Offset: 0x012081EE
		protected override void OnExecute()
		{
			LevelFlowResourceManager.ShowHookEffect(this.EntityId, this.TargetTag, this.CueId);
			base.FinishExecute(true);
		}

		// Token: 0x0402692E RID: 157998
		private int EntityId;

		// Token: 0x0402692F RID: 157999
		private string TargetTag = string.Empty;

		// Token: 0x04026930 RID: 158000
		private int CueId;
	}
}
