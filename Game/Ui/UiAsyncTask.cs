using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x0200499E RID: 18846
	[NullableContext(1)]
	[Nullable(0)]
	public class UiAsyncTask
	{
		// Token: 0x06031376 RID: 201590 RVA: 0x00C41975 File Offset: 0x00C3FB75
		public UiAsyncTask(string name, Func<UniTask> runHandle, [Nullable(2)] Action onTaskCancel = null)
		{
		}

		// Token: 0x170083FC RID: 33788
		// (get) Token: 0x06031377 RID: 201591 RVA: 0x00C4199D File Offset: 0x00C3FB9D
		[Nullable(0)]
		public UniTask<bool> Promise
		{
			[NullableContext(0)]
			get
			{
				return this.TaskPromise.Promise;
			}
		}

		// Token: 0x170083FD RID: 33789
		// (get) Token: 0x06031378 RID: 201592 RVA: 0x00C419AA File Offset: 0x00C3FBAA
		public EUiAsyncTaskStatus Status
		{
			get
			{
				return this.StatusInternal;
			}
		}

		// Token: 0x06031379 RID: 201593 RVA: 0x00C419B4 File Offset: 0x00C3FBB4
		public UniTask Run()
		{
			UiAsyncTask.<Run>d__11 <Run>d__;
			<Run>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Run>d__.<>4__this = this;
			<Run>d__.<>1__state = -1;
			<Run>d__.<>t__builder.Start<UiAsyncTask.<Run>d__11>(ref <Run>d__);
			return <Run>d__.<>t__builder.Task;
		}

		// Token: 0x0603137A RID: 201594 RVA: 0x00C419F7 File Offset: 0x00C3FBF7
		public void Cancel()
		{
			if (this.StatusInternal != EUiAsyncTaskStatus.Pending && this.StatusInternal != EUiAsyncTaskStatus.Running)
			{
				return;
			}
			this.Canceled = true;
			Action action = this.<onTaskCancel>P;
			if (action != null)
			{
				action();
			}
			EUiAsyncTaskStatus statusInternal = this.StatusInternal;
		}

		// Token: 0x0401C519 RID: 115993
		[CompilerGenerated]
		private Func<UniTask> <runHandle>P = runHandle;

		// Token: 0x0401C51A RID: 115994
		[Nullable(2)]
		[CompilerGenerated]
		private Action <onTaskCancel>P = onTaskCancel;

		// Token: 0x0401C51B RID: 115995
		private EUiAsyncTaskStatus StatusInternal;

		// Token: 0x0401C51C RID: 115996
		private bool Canceled;

		// Token: 0x0401C51D RID: 115997
		private readonly CustomPromise<bool> TaskPromise = new CustomPromise<bool>();

		// Token: 0x0401C51E RID: 115998
		public readonly string Name = name;
	}
}
