using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001BAD RID: 7085
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchEatActionData : FloroRanchActionDataBase
{
	// Token: 0x0600CDF8 RID: 52728 RVA: 0x0036DD23 File Offset: 0x0036BF23
	public FloroRanchEatActionData(FloroRanchUnitActionMsg actionData) : base(actionData)
	{
		this.ActionDataList = actionData.UnitOpGroup;
	}

	// Token: 0x0600CDF9 RID: 52729 RVA: 0x0036DD38 File Offset: 0x0036BF38
	public override UniTask OnExecute()
	{
		FloroRanchEatActionData.<OnExecute>d__2 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<FloroRanchEatActionData.<OnExecute>d__2>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x04006254 RID: 25172
	private readonly FRUnitOperateActionGroup ActionDataList;
}
