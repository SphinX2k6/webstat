using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001BB4 RID: 7092
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchResourceChangeActionData : FloroRanchActionDataBase
{
	// Token: 0x0600CE13 RID: 52755 RVA: 0x0036E2EB File Offset: 0x0036C4EB
	public FloroRanchResourceChangeActionData(FloroRanchUnitActionMsg actionData) : base(actionData)
	{
		this.ChangeData = actionData.ResourcesChange;
	}

	// Token: 0x0600CE14 RID: 52756 RVA: 0x0036E300 File Offset: 0x0036C500
	public override UniTask OnExecute()
	{
		FloroRanchResourceChangeActionData.<OnExecute>d__2 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<FloroRanchResourceChangeActionData.<OnExecute>d__2>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x0400625F RID: 25183
	private readonly FRUnitResourcesChangeAction ChangeData;
}
