using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001BB5 RID: 7093
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchSacrificeActionData : FloroRanchActionDataBase
{
	// Token: 0x0600CE15 RID: 52757 RVA: 0x0036E343 File Offset: 0x0036C543
	public FloroRanchSacrificeActionData(FloroRanchUnitActionMsg actionData) : base(actionData)
	{
		this.SacrificeData = actionData.SacrificeAction;
	}

	// Token: 0x0600CE16 RID: 52758 RVA: 0x0036E358 File Offset: 0x0036C558
	public override UniTask OnExecute()
	{
		FloroRanchSacrificeActionData.<OnExecute>d__3 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<FloroRanchSacrificeActionData.<OnExecute>d__3>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x0600CE17 RID: 52759 RVA: 0x0036E39B File Offset: 0x0036C59B
	protected override void OnExit()
	{
		if (this.GroupActionData != null)
		{
			this.GroupActionData.Exit();
		}
	}

	// Token: 0x04006260 RID: 25184
	private readonly FRSacrifice SacrificeData;

	// Token: 0x04006261 RID: 25185
	private FloroRanchGroupActionData GroupActionData;
}
