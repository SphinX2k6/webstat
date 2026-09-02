using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Plot.Flow;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x0200540F RID: 21519
	[NullableContext(2)]
	[Nullable(0)]
	public class FlowActionBase
	{
		// Token: 0x06036F0B RID: 225035 RVA: 0x00DF2174 File Offset: 0x00DF0374
		[NullableContext(1)]
		public virtual void Execute(ActionInfo actionInfo, FlowContext context, bool isAutoFinish)
		{
			this.Context = context;
			this.ActionInfo = actionInfo;
			if (context.IsBackground)
			{
				this.OnBackgroundExecute();
			}
			else
			{
				this.OnExecute();
			}
			if (isAutoFinish)
			{
				this.FinishExecute(true, true);
			}
		}

		// Token: 0x06036F0C RID: 225036 RVA: 0x00DF21A5 File Offset: 0x00DF03A5
		protected virtual void OnExecute()
		{
		}

		// Token: 0x06036F0D RID: 225037 RVA: 0x00DF21A7 File Offset: 0x00DF03A7
		protected virtual void OnBackgroundExecute()
		{
			this.FinishExecute(true, true);
		}

		// Token: 0x06036F0E RID: 225038 RVA: 0x00DF21B1 File Offset: 0x00DF03B1
		public void InterruptExecute()
		{
			this.OnInterruptExecute();
		}

		// Token: 0x06036F0F RID: 225039 RVA: 0x00DF21B9 File Offset: 0x00DF03B9
		protected virtual void OnInterruptExecute()
		{
		}

		// Token: 0x06036F10 RID: 225040 RVA: 0x00DF21BC File Offset: 0x00DF03BC
		protected void RecordAction(ActionRecord actionRecord = null)
		{
			if (this.Context == null)
			{
				return;
			}
			if (actionRecord == null)
			{
				this.Context.RollbackRecord.Add(new ActionRecord
				{
					ActionInfo = this.ActionInfo
				});
				return;
			}
			this.Context.RollbackRecord.Add(actionRecord);
		}

		// Token: 0x06036F11 RID: 225041 RVA: 0x00DF2208 File Offset: 0x00DF0408
		[NullableContext(1)]
		public unsafe void Rollback(ActionRecord actionRecord, FlowContext context)
		{
			ActionInfo actionInfo = actionRecord.ActionInfo;
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "剧情行为回退";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("name", actionInfo.Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("actionId", actionInfo.ActionId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.OnRollback(actionRecord, context);
		}

		// Token: 0x06036F12 RID: 225042 RVA: 0x00DF228B File Offset: 0x00DF048B
		[NullableContext(1)]
		protected virtual void OnRollback(ActionRecord actionInfo, FlowContext context)
		{
		}

		// Token: 0x06036F13 RID: 225043 RVA: 0x00DF2290 File Offset: 0x00DF0490
		protected void FinishExecute(bool isSuccess, bool isContinue = true)
		{
			if (this.ActionInfo == null || this.Runner == null)
			{
				return;
			}
			this.ActionInfo = null;
			this.Runner = null;
			this.Context = null;
			if (this.Callback != null)
			{
				Action<bool, bool> callback = this.Callback;
				this.Callback = null;
				callback(isSuccess, isContinue);
			}
		}

		// Token: 0x06036F14 RID: 225044 RVA: 0x00DF22DF File Offset: 0x00DF04DF
		public void Recycle()
		{
			FlowAction owner = this.Owner;
			if (owner == null)
			{
				return;
			}
			owner.RecycleAction(this);
		}

		// Token: 0x0401F9FA RID: 129530
		public EAction Type;

		// Token: 0x0401F9FB RID: 129531
		protected ActionInfo ActionInfo;

		// Token: 0x0401F9FC RID: 129532
		public Action<bool, bool> Callback;

		// Token: 0x0401F9FD RID: 129533
		public FlowActionRunner Runner;

		// Token: 0x0401F9FE RID: 129534
		public FlowAction Owner;

		// Token: 0x0401F9FF RID: 129535
		public FlowContext Context;
	}
}
