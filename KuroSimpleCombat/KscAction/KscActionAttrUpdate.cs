using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace KuroSimpleCombat.KscAction
{
	// Token: 0x020043D2 RID: 17362
	[NullableContext(1)]
	[Nullable(0)]
	public class KscActionAttrUpdate : KscActionBase
	{
		// Token: 0x0602E257 RID: 189015 RVA: 0x00AD9EF5 File Offset: 0x00AD80F5
		public KscActionAttrUpdate(long creatureId, SimpleCombatEntityAttributeUpdateNotify data) : base(creatureId)
		{
			this.Data = data;
		}

		// Token: 0x0602E258 RID: 189016 RVA: 0x00AD9F08 File Offset: 0x00AD8108
		protected override UniTask RunContent()
		{
			KscActionAttrUpdate.<RunContent>d__2 <RunContent>d__;
			<RunContent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunContent>d__.<>4__this = this;
			<RunContent>d__.<>1__state = -1;
			<RunContent>d__.<>t__builder.Start<KscActionAttrUpdate.<RunContent>d__2>(ref <RunContent>d__);
			return <RunContent>d__.<>t__builder.Task;
		}

		// Token: 0x0401A19C RID: 106908
		public SimpleCombatEntityAttributeUpdateNotify Data;
	}
}
