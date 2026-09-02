using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001BB9 RID: 7097
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchWageSettleAction : FloroRanchAsyncActionBase
{
	// Token: 0x0600CE1E RID: 52766 RVA: 0x0036E4BB File Offset: 0x0036C6BB
	public FloroRanchWageSettleAction(FloroRanchWageSettleTask wageSettleData)
	{
		this.WageSettleData = wageSettleData;
	}

	// Token: 0x0600CE1F RID: 52767 RVA: 0x0036E4CC File Offset: 0x0036C6CC
	public override UniTask OnExecute()
	{
		FloroRanchWageSettleAction.<OnExecute>d__2 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<FloroRanchWageSettleAction.<OnExecute>d__2>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x0600CE20 RID: 52768 RVA: 0x0036E510 File Offset: 0x0036C710
	private UniTask ExecuteWageSettle(FRUnitResourcesChangeAction changeData)
	{
		FloroRanchWageSettleAction.<ExecuteWageSettle>d__3 <ExecuteWageSettle>d__;
		<ExecuteWageSettle>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ExecuteWageSettle>d__.<>4__this = this;
		<ExecuteWageSettle>d__.changeData = changeData;
		<ExecuteWageSettle>d__.<>1__state = -1;
		<ExecuteWageSettle>d__.<>t__builder.Start<FloroRanchWageSettleAction.<ExecuteWageSettle>d__3>(ref <ExecuteWageSettle>d__);
		return <ExecuteWageSettle>d__.<>t__builder.Task;
	}

	// Token: 0x04006265 RID: 25189
	private readonly FloroRanchWageSettleTask WageSettleData;
}
