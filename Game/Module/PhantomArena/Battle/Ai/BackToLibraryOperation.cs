using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Ai
{
	// Token: 0x0200563A RID: 22074
	[NullableContext(1)]
	[Nullable(0)]
	public class BackToLibraryOperation : NpcAiOperation
	{
		// Token: 0x17009076 RID: 36982
		// (get) Token: 0x06038495 RID: 230549 RVA: 0x00E405A7 File Offset: 0x00E3E7A7
		// (set) Token: 0x06038496 RID: 230550 RVA: 0x00E405AF File Offset: 0x00E3E7AF
		public NpcPhantomBattleBackCardLibrary Info { get; private set; }

		// Token: 0x06038497 RID: 230551 RVA: 0x00E405B8 File Offset: 0x00E3E7B8
		public BackToLibraryOperation(NpcPhantomBattleBackCardLibrary info)
		{
			this.Info = info;
		}

		// Token: 0x06038498 RID: 230552 RVA: 0x00E405C8 File Offset: 0x00E3E7C8
		public override UniTask ExecuteAiOperation(PhantomArenaBattleProxy proxy)
		{
			BackToLibraryOperation.<ExecuteAiOperation>d__5 <ExecuteAiOperation>d__;
			<ExecuteAiOperation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteAiOperation>d__.<>4__this = this;
			<ExecuteAiOperation>d__.proxy = proxy;
			<ExecuteAiOperation>d__.<>1__state = -1;
			<ExecuteAiOperation>d__.<>t__builder.Start<BackToLibraryOperation.<ExecuteAiOperation>d__5>(ref <ExecuteAiOperation>d__);
			return <ExecuteAiOperation>d__.<>t__builder.Task;
		}
	}
}
