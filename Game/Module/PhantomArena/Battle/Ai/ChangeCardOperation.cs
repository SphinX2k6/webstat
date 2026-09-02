using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Ai
{
	// Token: 0x0200563C RID: 22076
	[NullableContext(1)]
	[Nullable(0)]
	public class ChangeCardOperation : NpcAiOperation
	{
		// Token: 0x17009078 RID: 36984
		// (get) Token: 0x0603849D RID: 230557 RVA: 0x00E4065F File Offset: 0x00E3E85F
		// (set) Token: 0x0603849E RID: 230558 RVA: 0x00E40667 File Offset: 0x00E3E867
		public NpcPhantomBattleSlotInsteadInfo Info { get; private set; }

		// Token: 0x0603849F RID: 230559 RVA: 0x00E40670 File Offset: 0x00E3E870
		public ChangeCardOperation(NpcPhantomBattleSlotInsteadInfo info)
		{
			this.Info = info;
		}

		// Token: 0x060384A0 RID: 230560 RVA: 0x00E40680 File Offset: 0x00E3E880
		public override UniTask ExecuteAiOperation(PhantomArenaBattleProxy proxy)
		{
			ChangeCardOperation.<ExecuteAiOperation>d__5 <ExecuteAiOperation>d__;
			<ExecuteAiOperation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteAiOperation>d__.<>4__this = this;
			<ExecuteAiOperation>d__.proxy = proxy;
			<ExecuteAiOperation>d__.<>1__state = -1;
			<ExecuteAiOperation>d__.<>t__builder.Start<ChangeCardOperation.<ExecuteAiOperation>d__5>(ref <ExecuteAiOperation>d__);
			return <ExecuteAiOperation>d__.<>t__builder.Task;
		}
	}
}
