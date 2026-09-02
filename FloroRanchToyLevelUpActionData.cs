using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001BB8 RID: 7096
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchToyLevelUpActionData : FloroRanchActionDataBase
{
	// Token: 0x0600CE1C RID: 52764 RVA: 0x0036E463 File Offset: 0x0036C663
	public FloroRanchToyLevelUpActionData(FloroRanchUnitActionMsg actionData) : base(actionData)
	{
		this.ActionData = actionData.ToyLvUp;
	}

	// Token: 0x0600CE1D RID: 52765 RVA: 0x0036E478 File Offset: 0x0036C678
	public override UniTask OnExecute()
	{
		FloroRanchToyLevelUpActionData.<OnExecute>d__2 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<FloroRanchToyLevelUpActionData.<OnExecute>d__2>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x04006264 RID: 25188
	private readonly FRActionToyLvUp ActionData;
}
