using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200606E RID: 24686
	public abstract class PendingProcessControllerRuleConfigBase
	{
		// Token: 0x0603E40E RID: 254990
		public abstract bool IsActive();

		// Token: 0x0603E40F RID: 254991
		[NullableContext(1)]
		public abstract bool PendingProgressExCheck(TPendingProcess process);
	}
}
