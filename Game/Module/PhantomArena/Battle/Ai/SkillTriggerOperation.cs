using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Ai
{
	// Token: 0x0200564A RID: 22090
	[NullableContext(1)]
	[Nullable(0)]
	public class SkillTriggerOperation : NpcAiOperation
	{
		// Token: 0x17009083 RID: 36995
		// (get) Token: 0x060384D1 RID: 230609 RVA: 0x00E40E03 File Offset: 0x00E3F003
		// (set) Token: 0x060384D2 RID: 230610 RVA: 0x00E40E0B File Offset: 0x00E3F00B
		public PhantomBattleSkillTriggerInfo Info { get; private set; }

		// Token: 0x060384D3 RID: 230611 RVA: 0x00E40E14 File Offset: 0x00E3F014
		public SkillTriggerOperation(PhantomBattleSkillTriggerInfo info)
		{
			this.Info = info;
		}

		// Token: 0x060384D4 RID: 230612 RVA: 0x00E40E24 File Offset: 0x00E3F024
		public override UniTask ExecuteAiOperation(PhantomArenaBattleProxy proxy)
		{
			SkillTriggerOperation.<ExecuteAiOperation>d__5 <ExecuteAiOperation>d__;
			<ExecuteAiOperation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteAiOperation>d__.<>4__this = this;
			<ExecuteAiOperation>d__.proxy = proxy;
			<ExecuteAiOperation>d__.<>1__state = -1;
			<ExecuteAiOperation>d__.<>t__builder.Start<SkillTriggerOperation.<ExecuteAiOperation>d__5>(ref <ExecuteAiOperation>d__);
			return <ExecuteAiOperation>d__.<>t__builder.Task;
		}
	}
}
