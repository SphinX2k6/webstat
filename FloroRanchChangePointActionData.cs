using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001BAA RID: 7082
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchChangePointActionData : FloroRanchActionDataBase
{
	// Token: 0x0600CDF2 RID: 52722 RVA: 0x0036DC1F File Offset: 0x0036BE1F
	public FloroRanchChangePointActionData(FloroRanchUnitActionMsg actionData) : base(actionData)
	{
		this.ActionData = actionData.ChangePointAction;
	}

	// Token: 0x0600CDF3 RID: 52723 RVA: 0x0036DC34 File Offset: 0x0036BE34
	public override UniTask OnExecute()
	{
		FloroRanchChangePointActionData.<OnExecute>d__2 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<FloroRanchChangePointActionData.<OnExecute>d__2>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x04006251 RID: 25169
	private readonly FRChangePointAction ActionData;
}
