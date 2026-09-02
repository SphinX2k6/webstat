using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001BAC RID: 7084
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchDebugInfoActionData : FloroRanchActionDataBase
{
	// Token: 0x0600CDF6 RID: 52726 RVA: 0x0036DCCB File Offset: 0x0036BECB
	public FloroRanchDebugInfoActionData(FloroRanchUnitActionMsg actionData) : base(actionData)
	{
		this.DebugInfo = actionData.ActionInfo;
	}

	// Token: 0x0600CDF7 RID: 52727 RVA: 0x0036DCE0 File Offset: 0x0036BEE0
	public override UniTask OnExecute()
	{
		FloroRanchDebugInfoActionData.<OnExecute>d__2 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<FloroRanchDebugInfoActionData.<OnExecute>d__2>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x04006253 RID: 25171
	private readonly FRDebugActionInfo DebugInfo;
}
