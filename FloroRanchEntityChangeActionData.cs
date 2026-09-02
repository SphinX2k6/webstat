using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001BB0 RID: 7088
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchEntityChangeActionData : FloroRanchActionDataBase
{
	// Token: 0x0600CE04 RID: 52740 RVA: 0x0036DF68 File Offset: 0x0036C168
	public void InitActionData(FRUnitOperateActionGroup actionDataList)
	{
		this.ActionDataList.Clear();
		foreach (FRUnitOperateAction frunitOperateAction in actionDataList.Actions)
		{
			FloroRanchEntityActionData item = new FloroRanchEntityActionData(frunitOperateAction.OpType, frunitOperateAction.Phantom);
			this.ActionDataList.Add(item);
		}
	}

	// Token: 0x0600CE05 RID: 52741 RVA: 0x0036DFD8 File Offset: 0x0036C1D8
	public FloroRanchEntityChangeActionData(FloroRanchUnitActionMsg actionData) : base(actionData)
	{
		this.ActionData = actionData;
	}

	// Token: 0x0600CE06 RID: 52742 RVA: 0x0036DFF4 File Offset: 0x0036C1F4
	public override UniTask OnExecute()
	{
		FloroRanchEntityChangeActionData.<OnExecute>d__4 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<FloroRanchEntityChangeActionData.<OnExecute>d__4>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x0600CE07 RID: 52743 RVA: 0x0036E038 File Offset: 0x0036C238
	private UniTask ExecuteEntityAction(FloroRanchEntityActionData actionData)
	{
		FloroRanchEntityChangeActionData.<ExecuteEntityAction>d__5 <ExecuteEntityAction>d__;
		<ExecuteEntityAction>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ExecuteEntityAction>d__.<>4__this = this;
		<ExecuteEntityAction>d__.actionData = actionData;
		<ExecuteEntityAction>d__.<>1__state = -1;
		<ExecuteEntityAction>d__.<>t__builder.Start<FloroRanchEntityChangeActionData.<ExecuteEntityAction>d__5>(ref <ExecuteEntityAction>d__);
		return <ExecuteEntityAction>d__.<>t__builder.Task;
	}

	// Token: 0x04006259 RID: 25177
	private readonly FloroRanchUnitActionMsg ActionData;

	// Token: 0x0400625A RID: 25178
	private readonly List<FloroRanchEntityActionData> ActionDataList = new List<FloroRanchEntityActionData>();
}
