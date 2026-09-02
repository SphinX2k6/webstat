using System;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace KuroSimpleCombat.KscAction
{
	// Token: 0x020043D9 RID: 17369
	public class KscActionEntityForget : KscActionBase
	{
		// Token: 0x0602E27C RID: 189052 RVA: 0x00ADAD3C File Offset: 0x00AD8F3C
		public KscActionEntityForget(long creatureId) : base(creatureId)
		{
		}

		// Token: 0x0602E27D RID: 189053 RVA: 0x00ADAD48 File Offset: 0x00AD8F48
		protected override UniTask RunContent()
		{
			KscActionEntityForget.<RunContent>d__1 <RunContent>d__;
			<RunContent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunContent>d__.<>4__this = this;
			<RunContent>d__.<>1__state = -1;
			<RunContent>d__.<>t__builder.Start<KscActionEntityForget.<RunContent>d__1>(ref <RunContent>d__);
			return <RunContent>d__.<>t__builder.Task;
		}
	}
}
