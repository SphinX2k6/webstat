using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001BB7 RID: 7095
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchStageTributeChange : FloroRanchActionDataBase
{
	// Token: 0x0600CE1A RID: 52762 RVA: 0x0036E40B File Offset: 0x0036C60B
	public FloroRanchStageTributeChange(FloroRanchUnitActionMsg actionData) : base(actionData)
	{
		this.ActionData = actionData.TributeChange;
	}

	// Token: 0x0600CE1B RID: 52763 RVA: 0x0036E420 File Offset: 0x0036C620
	public override UniTask OnExecute()
	{
		FloroRanchStageTributeChange.<OnExecute>d__2 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<FloroRanchStageTributeChange.<OnExecute>d__2>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x04006263 RID: 25187
	private readonly FRActionStageTributeChange ActionData;
}
