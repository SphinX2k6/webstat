using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.SplineMoveTask
{
	// Token: 0x02006AD9 RID: 27353
	[NullableContext(1)]
	[Nullable(0)]
	public class SplineMoveTaskBase
	{
		// Token: 0x060439FA RID: 276986 RVA: 0x01171AB8 File Offset: 0x0116FCB8
		protected SplineMoveTaskBase(EntityHandle entityHandle)
		{
			this.EntityHandle = entityHandle;
		}

		// Token: 0x060439FB RID: 276987 RVA: 0x01171AC8 File Offset: 0x0116FCC8
		public void StartTask()
		{
			if ((this.TaskState & ESplineMoveTaskState.Start) != ESplineMoveTaskState.None)
			{
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LevelEvent;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "[SplineMoveTaskBase] StartTask";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", this.EntityHandle.Id);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (!ControllerBase<SplineMoveTaskController>.Instance.RegisterTask(this))
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.LevelEvent;
				ELogAuthor author2 = ELogAuthor.ZYL;
				string message2 = "[SplineMoveTaskBase] Task注册失败，停止";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("EntityId", this.EntityHandle.Id);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			this.OnStartTask();
			this.TaskState |= ESplineMoveTaskState.Start;
		}

		// Token: 0x060439FC RID: 276988 RVA: 0x01171B70 File Offset: 0x0116FD70
		public unsafe void EndTask(bool success)
		{
			if ((this.TaskState & ESplineMoveTaskState.End) != ESplineMoveTaskState.None)
			{
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LevelEvent;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "[SplineMoveTaskBase] EndTask";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", this.EntityHandle.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Success", success);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			ControllerBase<SplineMoveTaskController>.Instance.UnregisterTask(this);
			this.OnEndTask(success);
			this.TaskState |= ESplineMoveTaskState.End;
		}

		// Token: 0x060439FD RID: 276989 RVA: 0x01171C10 File Offset: 0x0116FE10
		public void TickTask(double delta)
		{
			this.OnTickTask(delta);
		}

		// Token: 0x060439FE RID: 276990 RVA: 0x01171C19 File Offset: 0x0116FE19
		protected virtual void OnStartTask()
		{
		}

		// Token: 0x060439FF RID: 276991 RVA: 0x01171C1B File Offset: 0x0116FE1B
		protected virtual void OnEndTask(bool success)
		{
		}

		// Token: 0x06043A00 RID: 276992 RVA: 0x01171C1D File Offset: 0x0116FE1D
		protected virtual void OnTickTask(double delta)
		{
		}

		// Token: 0x04025C92 RID: 154770
		public readonly EntityHandle EntityHandle;

		// Token: 0x04025C93 RID: 154771
		private ESplineMoveTaskState TaskState;
	}
}
