using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006FAF RID: 28591
	public class LevelFlowTeleportAction : LevelFlowActionBase
	{
		// Token: 0x06045239 RID: 283193 RVA: 0x0120A5F0 File Offset: 0x012087F0
		[NullableContext(1)]
		public LevelFlowTeleportAction Init(int targetEntityId)
		{
			this.TargetEntityId = targetEntityId;
			return this;
		}

		// Token: 0x0604523A RID: 283194 RVA: 0x0120A5FA File Offset: 0x012087FA
		protected override void OnExecute()
		{
			if (ModelBase<LevelFlowModel>.Instance.IsEnd)
			{
				base.FinishExecute(true);
				return;
			}
			ControllerBase<LevelFlowController>.Instance.LevelFlowTeleportRequest(this.TargetEntityId, new Action<bool>(base.FinishExecute));
		}

		// Token: 0x04026935 RID: 158005
		private int TargetEntityId;
	}
}
