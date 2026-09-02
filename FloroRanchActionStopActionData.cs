using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001BA7 RID: 7079
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchActionStopActionData : FloroRanchActionDataBase
{
	// Token: 0x0600CDDF RID: 52703 RVA: 0x0036D859 File Offset: 0x0036BA59
	public FloroRanchActionStopActionData(FloroRanchUnitActionMsg actionData) : base(actionData)
	{
		this.ActionData = actionData.ActionStop;
	}

	// Token: 0x0600CDE0 RID: 52704 RVA: 0x0036D870 File Offset: 0x0036BA70
	public override UniTask OnExecute()
	{
		FloroRanchActionStopActionData.<OnExecute>d__2 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<FloroRanchActionStopActionData.<OnExecute>d__2>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x0400624B RID: 25163
	private readonly FRActionStop ActionData;
}
