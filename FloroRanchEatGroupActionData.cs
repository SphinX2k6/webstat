using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001BAE RID: 7086
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchEatGroupActionData : FloroRanchActionDataBase
{
	// Token: 0x0600CDFA RID: 52730 RVA: 0x0036DD7B File Offset: 0x0036BF7B
	public FloroRanchEatGroupActionData(FloroRanchUnitActionMsg actionData) : base(actionData)
	{
		this.EatingActionGroupData = actionData.EatingGroup;
	}

	// Token: 0x0600CDFB RID: 52731 RVA: 0x0036DD90 File Offset: 0x0036BF90
	public override UniTask OnExecute()
	{
		FloroRanchEatGroupActionData.<OnExecute>d__3 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<FloroRanchEatGroupActionData.<OnExecute>d__3>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x0600CDFC RID: 52732 RVA: 0x0036DDD3 File Offset: 0x0036BFD3
	protected override void OnPause()
	{
		if (this.GroupActionData != null)
		{
			this.GroupActionData.Pause();
		}
	}

	// Token: 0x0600CDFD RID: 52733 RVA: 0x0036DDE8 File Offset: 0x0036BFE8
	protected override void OnResume()
	{
		if (this.GroupActionData != null)
		{
			this.GroupActionData.Resume();
		}
	}

	// Token: 0x04006255 RID: 25173
	private readonly FRUnitEatingActionGroup EatingActionGroupData;

	// Token: 0x04006256 RID: 25174
	private FloroRanchGroupActionData GroupActionData;
}
