using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006F98 RID: 28568
	public class LevelFlowHideHookEffectAction : LevelFlowActionBase
	{
		// Token: 0x060451CC RID: 283084 RVA: 0x01207527 File Offset: 0x01205727
		[NullableContext(1)]
		public LevelFlowHideHookEffectAction Init(int entityId)
		{
			this.EntityId = entityId;
			return this;
		}

		// Token: 0x060451CD RID: 283085 RVA: 0x01207531 File Offset: 0x01205731
		protected override void OnExecute()
		{
			LevelFlowResourceManager.HideHookEffect(this.EntityId);
			base.FinishExecute(true);
		}

		// Token: 0x040268FA RID: 157946
		private int EntityId;
	}
}
