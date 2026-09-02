using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace KuroSimpleCombat.KscAction
{
	// Token: 0x020043D6 RID: 17366
	[NullableContext(1)]
	[Nullable(0)]
	public class KscActionBuffsAdd : KscActionBase
	{
		// Token: 0x0602E26C RID: 189036 RVA: 0x00ADA682 File Offset: 0x00AD8882
		public KscActionBuffsAdd(SimpleCombatEntitySubTypeChangeNotify params_) : base(params_.EntityId)
		{
			this.Params = params_;
		}

		// Token: 0x0602E26D RID: 189037 RVA: 0x00ADA698 File Offset: 0x00AD8898
		protected override UniTask RunContent()
		{
			KscActionBuffsAdd.<RunContent>d__2 <RunContent>d__;
			<RunContent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunContent>d__.<>4__this = this;
			<RunContent>d__.<>1__state = -1;
			<RunContent>d__.<>t__builder.Start<KscActionBuffsAdd.<RunContent>d__2>(ref <RunContent>d__);
			return <RunContent>d__.<>t__builder.Task;
		}

		// Token: 0x0602E26E RID: 189038 RVA: 0x00ADA6DC File Offset: 0x00AD88DC
		private UniTask AddBuffsAsync(int kscEntityId)
		{
			KscActionBuffsAdd.<AddBuffsAsync>d__3 <AddBuffsAsync>d__;
			<AddBuffsAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<AddBuffsAsync>d__.<>4__this = this;
			<AddBuffsAsync>d__.kscEntityId = kscEntityId;
			<AddBuffsAsync>d__.<>1__state = -1;
			<AddBuffsAsync>d__.<>t__builder.Start<KscActionBuffsAdd.<AddBuffsAsync>d__3>(ref <AddBuffsAsync>d__);
			return <AddBuffsAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0401A1A6 RID: 106918
		public SimpleCombatEntitySubTypeChangeNotify Params;
	}
}
