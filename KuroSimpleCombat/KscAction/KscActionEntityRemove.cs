using System;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace KuroSimpleCombat.KscAction
{
	// Token: 0x020043DA RID: 17370
	public class KscActionEntityRemove : KscActionBase
	{
		// Token: 0x0602E27E RID: 189054 RVA: 0x00ADAD8B File Offset: 0x00AD8F8B
		public KscActionEntityRemove(long entityId, FName? removeReason, EKscEntityRemoveReasonType removeReasonType = EKscEntityRemoveReasonType.None) : base(entityId)
		{
			this.RemoveReason = removeReason;
			this.RemoveReasonType = removeReasonType;
		}

		// Token: 0x0602E27F RID: 189055 RVA: 0x00ADADAC File Offset: 0x00AD8FAC
		protected override UniTask RunContent()
		{
			KscActionEntityRemove.<RunContent>d__3 <RunContent>d__;
			<RunContent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunContent>d__.<>4__this = this;
			<RunContent>d__.<>1__state = -1;
			<RunContent>d__.<>t__builder.Start<KscActionEntityRemove.<RunContent>d__3>(ref <RunContent>d__);
			return <RunContent>d__.<>t__builder.Task;
		}

		// Token: 0x0401A1AC RID: 106924
		public FName? RemoveReason;

		// Token: 0x0401A1AD RID: 106925
		public EKscEntityRemoveReasonType RemoveReasonType = EKscEntityRemoveReasonType.None;
	}
}
