using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001BAB RID: 7083
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchDayStartAction : FloroRanchAsyncActionBase
{
	// Token: 0x0600CDF4 RID: 52724 RVA: 0x0036DC77 File Offset: 0x0036BE77
	public FloroRanchDayStartAction(FloroRanchDayStart dayStartData)
	{
		this.DayStartData = dayStartData;
	}

	// Token: 0x0600CDF5 RID: 52725 RVA: 0x0036DC88 File Offset: 0x0036BE88
	public override UniTask OnExecute()
	{
		FloroRanchDayStartAction.<OnExecute>d__2 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<FloroRanchDayStartAction.<OnExecute>d__2>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x04006252 RID: 25170
	private readonly FloroRanchDayStart DayStartData;
}
