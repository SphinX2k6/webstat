using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x0200540C RID: 21516
	[NullableContext(1)]
	[Nullable(0)]
	public class FlowActionAvgPlayRoleAction : FlowActionBase
	{
		// Token: 0x06036EFC RID: 225020 RVA: 0x00DF1BE0 File Offset: 0x00DEFDE0
		protected override void OnExecute()
		{
			List<IAvgPlayRoleActionItem> roleActionList = (this.ActionInfo.Params as AvgPlayRoleAction).RoleActionList;
			List<UniTask> list = new List<UniTask>();
			foreach (IAvgPlayRoleActionItem roleAction in roleActionList)
			{
				list.Add(this.ExecuteRoleAction(roleAction));
			}
			if (this.ActionInfo.Async.GetValueOrDefault())
			{
				base.FinishExecute(true, true);
				return;
			}
			UniTask.WhenAll(list).ContinueWith(delegate()
			{
				base.FinishExecute(true, true);
			}).Forget();
		}

		// Token: 0x06036EFD RID: 225021 RVA: 0x00DF1C88 File Offset: 0x00DEFE88
		private UniTask ExecuteRoleAction(IAvgPlayRoleActionItem roleAction)
		{
			FlowActionAvgPlayRoleAction.<ExecuteRoleAction>d__1 <ExecuteRoleAction>d__;
			<ExecuteRoleAction>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteRoleAction>d__.<>4__this = this;
			<ExecuteRoleAction>d__.roleAction = roleAction;
			<ExecuteRoleAction>d__.<>1__state = -1;
			<ExecuteRoleAction>d__.<>t__builder.Start<FlowActionAvgPlayRoleAction.<ExecuteRoleAction>d__1>(ref <ExecuteRoleAction>d__);
			return <ExecuteRoleAction>d__.<>t__builder.Task;
		}

		// Token: 0x06036EFE RID: 225022 RVA: 0x00DF1CD4 File Offset: 0x00DEFED4
		private UniTask EnterAsync(IAvgPlayRoleActionItem roleAction)
		{
			FlowActionAvgPlayRoleAction.<EnterAsync>d__2 <EnterAsync>d__;
			<EnterAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<EnterAsync>d__.roleAction = roleAction;
			<EnterAsync>d__.<>1__state = -1;
			<EnterAsync>d__.<>t__builder.Start<FlowActionAvgPlayRoleAction.<EnterAsync>d__2>(ref <EnterAsync>d__);
			return <EnterAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036EFF RID: 225023 RVA: 0x00DF1D18 File Offset: 0x00DEFF18
		private UniTask ExitAsync(IAvgPlayRoleActionItem roleAction)
		{
			FlowActionAvgPlayRoleAction.<ExitAsync>d__3 <ExitAsync>d__;
			<ExitAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExitAsync>d__.roleAction = roleAction;
			<ExitAsync>d__.<>1__state = -1;
			<ExitAsync>d__.<>t__builder.Start<FlowActionAvgPlayRoleAction.<ExitAsync>d__3>(ref <ExitAsync>d__);
			return <ExitAsync>d__.<>t__builder.Task;
		}
	}
}
