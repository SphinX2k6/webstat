using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.KuroSimpleCombat;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace KuroSimpleCombat.KscAction
{
	// Token: 0x020043D3 RID: 17363
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class KscActionBase
	{
		// Token: 0x0602E259 RID: 189017 RVA: 0x00AD9F4B File Offset: 0x00AD814B
		public KscActionBase(long entityId)
		{
			this.EntityId = entityId;
			this.KscCtrl = ControllerBase<KuroSimpleCombatController>.Instance;
		}

		// Token: 0x17007F0F RID: 32527
		// (get) Token: 0x0602E25A RID: 189018 RVA: 0x00AD9F68 File Offset: 0x00AD8168
		public string Name
		{
			get
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
				defaultInterpolatedStringHandler.AppendLiteral("KscAction_[");
				defaultInterpolatedStringHandler.AppendFormatted<long>(this.EntityId);
				defaultInterpolatedStringHandler.AppendLiteral("]");
				return defaultInterpolatedStringHandler.ToStringAndClear();
			}
		}

		// Token: 0x0602E25B RID: 189019 RVA: 0x00AD9FAC File Offset: 0x00AD81AC
		public UniTask Run()
		{
			KscActionBase.<Run>d__8 <Run>d__;
			<Run>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Run>d__.<>4__this = this;
			<Run>d__.<>1__state = -1;
			<Run>d__.<>t__builder.Start<KscActionBase.<Run>d__8>(ref <Run>d__);
			return <Run>d__.<>t__builder.Task;
		}

		// Token: 0x0602E25C RID: 189020 RVA: 0x00AD9FF0 File Offset: 0x00AD81F0
		public unsafe void Cancel()
		{
			this.IsCancel = true;
			KscLog.EModule flag = KscLog.EModule.Load;
			string log = "KscAction 取消执行";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.EntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Class", base.GetType().Name);
			this.Debug(flag, log, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.CancelContent();
		}

		// Token: 0x0602E25D RID: 189021 RVA: 0x00ADA06A File Offset: 0x00AD826A
		protected void SetResult()
		{
			UniTaskCompletionSource promiseInternal = this.PromiseInternal;
			if (promiseInternal == null)
			{
				return;
			}
			promiseInternal.TrySetResult();
		}

		// Token: 0x17007F10 RID: 32528
		// (get) Token: 0x0602E25E RID: 189022 RVA: 0x00ADA07D File Offset: 0x00AD827D
		public UiAsyncTask Task
		{
			get
			{
				if (this.TaskInternal == null)
				{
					this.TaskInternal = new UiAsyncTask(this.Name, new Func<UniTask>(this.Run), new Action(this.Cancel));
				}
				return this.TaskInternal;
			}
		}

		// Token: 0x0602E25F RID: 189023 RVA: 0x00ADA0B8 File Offset: 0x00AD82B8
		public string LogInfo()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(5, 2);
			defaultInterpolatedStringHandler.AppendFormatted(base.GetType().Name);
			defaultInterpolatedStringHandler.AppendLiteral("[S: ");
			UiAsyncTask taskInternal = this.TaskInternal;
			defaultInterpolatedStringHandler.AppendFormatted<EUiAsyncTaskStatus?>((taskInternal != null) ? new EUiAsyncTaskStatus?(taskInternal.Status) : null);
			defaultInterpolatedStringHandler.AppendLiteral("]");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0602E260 RID: 189024 RVA: 0x00ADA125 File Offset: 0x00AD8325
		protected void Debug(KscLog.EModule flag, string log, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
			KscLog.Debug(flag, ELogAuthor.CX, Singleton<KscEnv>.Instance.KscWorld, log, pairs);
		}

		// Token: 0x0602E261 RID: 189025 RVA: 0x00ADA13B File Offset: 0x00AD833B
		protected void Info(KscLog.EModule flag, string log, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
			KscLog.Info(flag, ELogAuthor.CX, Singleton<KscEnv>.Instance.KscWorld, log, pairs);
		}

		// Token: 0x0602E262 RID: 189026 RVA: 0x00ADA151 File Offset: 0x00AD8351
		protected void Warn(KscLog.EModule flag, string log, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
			KscLog.Warn(flag, ELogAuthor.CX, Singleton<KscEnv>.Instance.KscWorld, log, pairs);
		}

		// Token: 0x0602E263 RID: 189027 RVA: 0x00ADA167 File Offset: 0x00AD8367
		protected void Error(KscLog.EModule flag, string log, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
			KscLog.Error(flag, ELogAuthor.CX, Singleton<KscEnv>.Instance.KscWorld, log, pairs);
		}

		// Token: 0x0602E264 RID: 189028
		protected abstract UniTask RunContent();

		// Token: 0x0602E265 RID: 189029 RVA: 0x00ADA17D File Offset: 0x00AD837D
		protected virtual void CancelContent()
		{
		}

		// Token: 0x0401A19D RID: 106909
		public long EntityId;

		// Token: 0x0401A19E RID: 106910
		[Nullable(2)]
		protected UniTaskCompletionSource PromiseInternal;

		// Token: 0x0401A19F RID: 106911
		protected bool IsCancel;

		// Token: 0x0401A1A0 RID: 106912
		[Nullable(2)]
		protected UiAsyncTask TaskInternal;

		// Token: 0x0401A1A1 RID: 106913
		protected KuroSimpleCombatController KscCtrl;
	}
}
