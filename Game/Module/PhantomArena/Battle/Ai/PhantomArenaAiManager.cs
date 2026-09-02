using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Ai
{
	// Token: 0x02005646 RID: 22086
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaAiManager
	{
		// Token: 0x17009080 RID: 36992
		// (get) Token: 0x060384BF RID: 230591 RVA: 0x00E40A07 File Offset: 0x00E3EC07
		// (set) Token: 0x060384C0 RID: 230592 RVA: 0x00E40A0F File Offset: 0x00E3EC0F
		private protected PhantomArenaBattleProxy BattleProxy { protected get; private set; }

		// Token: 0x060384C1 RID: 230593 RVA: 0x00E40A18 File Offset: 0x00E3EC18
		public PhantomArenaAiManager(PhantomArenaBattleProxy battleProxy)
		{
			this.BattleProxy = battleProxy;
		}

		// Token: 0x060384C2 RID: 230594 RVA: 0x00E40A34 File Offset: 0x00E3EC34
		public void SetOperationList(List<NpcAiOperation> operationList)
		{
			foreach (NpcAiOperation element in operationList)
			{
				this.OperationQueue.Push(element);
			}
			this.ExecCount = 0;
		}

		// Token: 0x060384C3 RID: 230595 RVA: 0x00E40A90 File Offset: 0x00E3EC90
		public UniTask ExecuteAllOperation()
		{
			PhantomArenaAiManager.<ExecuteAllOperation>d__9 <ExecuteAllOperation>d__;
			<ExecuteAllOperation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteAllOperation>d__.<>4__this = this;
			<ExecuteAllOperation>d__.<>1__state = -1;
			<ExecuteAllOperation>d__.<>t__builder.Start<PhantomArenaAiManager.<ExecuteAllOperation>d__9>(ref <ExecuteAllOperation>d__);
			return <ExecuteAllOperation>d__.<>t__builder.Task;
		}

		// Token: 0x060384C4 RID: 230596 RVA: 0x00E40AD3 File Offset: 0x00E3ECD3
		public void ClearAllOperation()
		{
			this.OperationQueue.Clear();
		}

		// Token: 0x060384C5 RID: 230597 RVA: 0x00E40AE0 File Offset: 0x00E3ECE0
		public void Clear()
		{
			this.OperationQueue.Clear();
			this.IsClear = true;
		}

		// Token: 0x040201FC RID: 131580
		private readonly Queue<NpcAiOperation> OperationQueue = new Queue<NpcAiOperation>(4);

		// Token: 0x040201FD RID: 131581
		public bool IsClear;

		// Token: 0x040201FF RID: 131583
		public int ExecCount;
	}
}
