using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200606D RID: 24685
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PendingProcessControllerRuleConfigInstance : Singleton<PendingProcessControllerRuleConfigInstance>
	{
		// Token: 0x04022E55 RID: 142933
		public readonly IReadOnlyList<PendingProcessControllerRuleConfigBase> PendingProcessExCheckList = new <>z__ReadOnlySingleElementList<PendingProcessControllerRuleConfigBase>(new SpringManorPendingProcessControllerRuleConfig());
	}
}
