using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Ai
{
	// Token: 0x02005639 RID: 22073
	[NullableContext(1)]
	[Nullable(0)]
	public class BackSlotCardLibraryOperation : NpcAiOperation
	{
		// Token: 0x17009075 RID: 36981
		// (get) Token: 0x06038491 RID: 230545 RVA: 0x00E40539 File Offset: 0x00E3E739
		// (set) Token: 0x06038492 RID: 230546 RVA: 0x00E40541 File Offset: 0x00E3E741
		public NpcPhantomBattleBackSlotCardLibrary Info { get; private set; }

		// Token: 0x06038493 RID: 230547 RVA: 0x00E4054A File Offset: 0x00E3E74A
		public BackSlotCardLibraryOperation(NpcPhantomBattleBackSlotCardLibrary info)
		{
			this.Info = info;
		}

		// Token: 0x06038494 RID: 230548 RVA: 0x00E4055C File Offset: 0x00E3E75C
		public override UniTask ExecuteAiOperation(PhantomArenaBattleProxy proxy)
		{
			BackSlotCardLibraryOperation.<ExecuteAiOperation>d__5 <ExecuteAiOperation>d__;
			<ExecuteAiOperation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteAiOperation>d__.<>4__this = this;
			<ExecuteAiOperation>d__.proxy = proxy;
			<ExecuteAiOperation>d__.<>1__state = -1;
			<ExecuteAiOperation>d__.<>t__builder.Start<BackSlotCardLibraryOperation.<ExecuteAiOperation>d__5>(ref <ExecuteAiOperation>d__);
			return <ExecuteAiOperation>d__.<>t__builder.Task;
		}
	}
}
