using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Ai
{
	// Token: 0x02005642 RID: 22082
	[NullableContext(1)]
	[Nullable(0)]
	public class LeaveSlotOperation : NpcAiOperation
	{
		// Token: 0x1700907E RID: 36990
		// (get) Token: 0x060384B5 RID: 230581 RVA: 0x00E40909 File Offset: 0x00E3EB09
		// (set) Token: 0x060384B6 RID: 230582 RVA: 0x00E40911 File Offset: 0x00E3EB11
		public NpcPhantomLeaveSlot Info { get; private set; }

		// Token: 0x060384B7 RID: 230583 RVA: 0x00E4091A File Offset: 0x00E3EB1A
		public LeaveSlotOperation(NpcPhantomLeaveSlot info)
		{
			this.Info = info;
		}

		// Token: 0x060384B8 RID: 230584 RVA: 0x00E4092C File Offset: 0x00E3EB2C
		public override UniTask ExecuteAiOperation(PhantomArenaBattleProxy proxy)
		{
			LeaveSlotOperation.<ExecuteAiOperation>d__5 <ExecuteAiOperation>d__;
			<ExecuteAiOperation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteAiOperation>d__.<>4__this = this;
			<ExecuteAiOperation>d__.proxy = proxy;
			<ExecuteAiOperation>d__.<>1__state = -1;
			<ExecuteAiOperation>d__.<>t__builder.Start<LeaveSlotOperation.<ExecuteAiOperation>d__5>(ref <ExecuteAiOperation>d__);
			return <ExecuteAiOperation>d__.<>t__builder.Task;
		}
	}
}
