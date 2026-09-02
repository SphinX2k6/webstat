using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001BA9 RID: 7081
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchBuffUpdateActionData : FloroRanchActionDataBase
{
	// Token: 0x0600CDF0 RID: 52720 RVA: 0x0036DBC7 File Offset: 0x0036BDC7
	public FloroRanchBuffUpdateActionData(FloroRanchUnitActionMsg actionData) : base(actionData)
	{
		this.BuffData = actionData.BuffOpGroup;
	}

	// Token: 0x0600CDF1 RID: 52721 RVA: 0x0036DBDC File Offset: 0x0036BDDC
	public override UniTask OnExecute()
	{
		FloroRanchBuffUpdateActionData.<OnExecute>d__2 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<FloroRanchBuffUpdateActionData.<OnExecute>d__2>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x04006250 RID: 25168
	private readonly FRUnitBuffOperateActionGroup BuffData;
}
