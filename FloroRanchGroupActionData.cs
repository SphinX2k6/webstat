using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001BB3 RID: 7091
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchGroupActionData : FloroRanchAsyncActionBase
{
	// Token: 0x0600CE0C RID: 52748 RVA: 0x0036E134 File Offset: 0x0036C334
	public void InitActionData(List<FloroRanchUnitActionMsg> actionDataList)
	{
		this.ActionDataList.Clear();
		foreach (FloroRanchUnitActionMsg actionData in actionDataList)
		{
			FloroRanchActionDataBase item = FloroRanchEntityActionSystem.CreateActionData(actionData);
			this.ActionDataList.Add(item);
		}
	}

	// Token: 0x0600CE0D RID: 52749 RVA: 0x0036E198 File Offset: 0x0036C398
	public override UniTask OnExecute()
	{
		FloroRanchGroupActionData.<OnExecute>d__3 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<FloroRanchGroupActionData.<OnExecute>d__3>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x0600CE0E RID: 52750 RVA: 0x0036E1DB File Offset: 0x0036C3DB
	protected override void OnPause()
	{
		if (this.CurActionData != null)
		{
			this.CurActionData.Pause();
		}
	}

	// Token: 0x0600CE0F RID: 52751 RVA: 0x0036E1F0 File Offset: 0x0036C3F0
	protected override void OnResume()
	{
		if (this.CurActionData != null)
		{
			this.CurActionData.Resume();
		}
	}

	// Token: 0x0600CE10 RID: 52752 RVA: 0x0036E208 File Offset: 0x0036C408
	protected override void OnExit()
	{
		if (this.CurActionData != null)
		{
			this.CurActionData.Exit();
		}
		foreach (FloroRanchAsyncActionBase floroRanchAsyncActionBase in this.ActionDataList)
		{
			floroRanchAsyncActionBase.Exit();
		}
		this.ActionDataList.Clear();
	}

	// Token: 0x0600CE11 RID: 52753 RVA: 0x0036E278 File Offset: 0x0036C478
	public void SetIgnoreCasterEntityAnim(int entityId)
	{
		foreach (FloroRanchAsyncActionBase floroRanchAsyncActionBase in this.ActionDataList)
		{
			if (floroRanchAsyncActionBase is FloroRanchActionDataBase)
			{
				((FloroRanchActionDataBase)floroRanchAsyncActionBase).SetIgnoreCasterEntityAnim(entityId);
			}
		}
	}

	// Token: 0x0400625D RID: 25181
	private readonly List<FloroRanchAsyncActionBase> ActionDataList = new List<FloroRanchAsyncActionBase>();

	// Token: 0x0400625E RID: 25182
	[Nullable(2)]
	private FloroRanchAsyncActionBase CurActionData;
}
