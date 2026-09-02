using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001BB2 RID: 7090
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchFusionActionData : FloroRanchActionDataBase
{
	// Token: 0x0600CE0A RID: 52746 RVA: 0x0036E0DB File Offset: 0x0036C2DB
	public FloroRanchFusionActionData(FloroRanchUnitActionMsg actionData) : base(actionData)
	{
		this.FusionActionData = actionData.MixAction;
	}

	// Token: 0x0600CE0B RID: 52747 RVA: 0x0036E0F0 File Offset: 0x0036C2F0
	public override UniTask OnExecute()
	{
		FloroRanchFusionActionData.<OnExecute>d__2 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<FloroRanchFusionActionData.<OnExecute>d__2>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x0400625C RID: 25180
	private readonly FRMixAction FusionActionData;
}
