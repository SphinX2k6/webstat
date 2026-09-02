using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001BAF RID: 7087
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchEntityActionData : FloroRanchAsyncActionBase
{
	// Token: 0x0600CDFE RID: 52734 RVA: 0x0036DDFD File Offset: 0x0036BFFD
	public FloroRanchEntityActionData(FRUnitOperate type, FloroRanchPlayUnit entityData)
	{
		this.OperateType = type;
		this.EntityData = entityData;
	}

	// Token: 0x0600CDFF RID: 52735 RVA: 0x0036DE14 File Offset: 0x0036C014
	public override UniTask OnExecute()
	{
		FloroRanchEntityActionData.<OnExecute>d__3 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<FloroRanchEntityActionData.<OnExecute>d__3>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x0600CE00 RID: 52736 RVA: 0x0036DE58 File Offset: 0x0036C058
	public UniTask AddEntityAction()
	{
		FloroRanchEntityActionData.<AddEntityAction>d__4 <AddEntityAction>d__;
		<AddEntityAction>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<AddEntityAction>d__.<>4__this = this;
		<AddEntityAction>d__.<>1__state = -1;
		<AddEntityAction>d__.<>t__builder.Start<FloroRanchEntityActionData.<AddEntityAction>d__4>(ref <AddEntityAction>d__);
		return <AddEntityAction>d__.<>t__builder.Task;
	}

	// Token: 0x0600CE01 RID: 52737 RVA: 0x0036DE9C File Offset: 0x0036C09C
	public UniTask RemoveEntityAction()
	{
		FloroRanchEntityActionData.<RemoveEntityAction>d__5 <RemoveEntityAction>d__;
		<RemoveEntityAction>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RemoveEntityAction>d__.<>4__this = this;
		<RemoveEntityAction>d__.<>1__state = -1;
		<RemoveEntityAction>d__.<>t__builder.Start<FloroRanchEntityActionData.<RemoveEntityAction>d__5>(ref <RemoveEntityAction>d__);
		return <RemoveEntityAction>d__.<>t__builder.Task;
	}

	// Token: 0x0600CE02 RID: 52738 RVA: 0x0036DEE0 File Offset: 0x0036C0E0
	public UniTask ChangeEntityAction()
	{
		FloroRanchEntityActionData.<ChangeEntityAction>d__6 <ChangeEntityAction>d__;
		<ChangeEntityAction>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ChangeEntityAction>d__.<>4__this = this;
		<ChangeEntityAction>d__.<>1__state = -1;
		<ChangeEntityAction>d__.<>t__builder.Start<FloroRanchEntityActionData.<ChangeEntityAction>d__6>(ref <ChangeEntityAction>d__);
		return <ChangeEntityAction>d__.<>t__builder.Task;
	}

	// Token: 0x0600CE03 RID: 52739 RVA: 0x0036DF24 File Offset: 0x0036C124
	public UniTask ReplaceEntityAction()
	{
		FloroRanchEntityActionData.<ReplaceEntityAction>d__7 <ReplaceEntityAction>d__;
		<ReplaceEntityAction>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ReplaceEntityAction>d__.<>4__this = this;
		<ReplaceEntityAction>d__.<>1__state = -1;
		<ReplaceEntityAction>d__.<>t__builder.Start<FloroRanchEntityActionData.<ReplaceEntityAction>d__7>(ref <ReplaceEntityAction>d__);
		return <ReplaceEntityAction>d__.<>t__builder.Task;
	}

	// Token: 0x04006257 RID: 25175
	public readonly FloroRanchPlayUnit EntityData;

	// Token: 0x04006258 RID: 25176
	public readonly FRUnitOperate OperateType;
}
