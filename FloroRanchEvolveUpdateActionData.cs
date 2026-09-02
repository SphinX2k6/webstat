using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001BB1 RID: 7089
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchEvolveUpdateActionData : FloroRanchActionDataBase
{
	// Token: 0x0600CE08 RID: 52744 RVA: 0x0036E083 File Offset: 0x0036C283
	public FloroRanchEvolveUpdateActionData(FloroRanchUnitActionMsg actionData) : base(actionData)
	{
		this.EvolveActionData = actionData.EvolveUpdate;
	}

	// Token: 0x0600CE09 RID: 52745 RVA: 0x0036E098 File Offset: 0x0036C298
	public override UniTask OnExecute()
	{
		FloroRanchEvolveUpdateActionData.<OnExecute>d__2 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<FloroRanchEvolveUpdateActionData.<OnExecute>d__2>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x0400625B RID: 25179
	private readonly FREvolveUpdateAction EvolveActionData;
}
