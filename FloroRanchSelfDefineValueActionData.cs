using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001BB6 RID: 7094
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchSelfDefineValueActionData : FloroRanchActionDataBase
{
	// Token: 0x0600CE18 RID: 52760 RVA: 0x0036E3B0 File Offset: 0x0036C5B0
	public FloroRanchSelfDefineValueActionData(FloroRanchUnitActionMsg actionData) : base(actionData)
	{
		this.ActionData = actionData.SelfDefineValue;
	}

	// Token: 0x0600CE19 RID: 52761 RVA: 0x0036E3C8 File Offset: 0x0036C5C8
	public override UniTask OnExecute()
	{
		FloroRanchSelfDefineValueActionData.<OnExecute>d__2 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<FloroRanchSelfDefineValueActionData.<OnExecute>d__2>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x04006262 RID: 25186
	private readonly FRActionSelfDefineValue ActionData;
}
