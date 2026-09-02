using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Ai
{
	// Token: 0x0200563E RID: 22078
	[NullableContext(1)]
	[Nullable(0)]
	public class DiscardCardOperation : NpcAiOperation
	{
		// Token: 0x1700907A RID: 36986
		// (get) Token: 0x060384A5 RID: 230565 RVA: 0x00E40737 File Offset: 0x00E3E937
		// (set) Token: 0x060384A6 RID: 230566 RVA: 0x00E4073F File Offset: 0x00E3E93F
		public NpcPhantomBattleDiscardInfo Info { get; private set; }

		// Token: 0x060384A7 RID: 230567 RVA: 0x00E40748 File Offset: 0x00E3E948
		public DiscardCardOperation(NpcPhantomBattleDiscardInfo info)
		{
			this.Info = info;
		}

		// Token: 0x060384A8 RID: 230568 RVA: 0x00E40758 File Offset: 0x00E3E958
		public override UniTask ExecuteAiOperation(PhantomArenaBattleProxy proxy)
		{
			DiscardCardOperation.<ExecuteAiOperation>d__5 <ExecuteAiOperation>d__;
			<ExecuteAiOperation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteAiOperation>d__.<>4__this = this;
			<ExecuteAiOperation>d__.proxy = proxy;
			<ExecuteAiOperation>d__.<>1__state = -1;
			<ExecuteAiOperation>d__.<>t__builder.Start<DiscardCardOperation.<ExecuteAiOperation>d__5>(ref <ExecuteAiOperation>d__);
			return <ExecuteAiOperation>d__.<>t__builder.Task;
		}
	}
}
