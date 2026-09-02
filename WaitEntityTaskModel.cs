using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine.Extension;

// Token: 0x02002CEE RID: 11502
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class WaitEntityTaskModel : ModelBase<WaitEntityTaskModel>
{
	// Token: 0x06017311 RID: 94993 RVA: 0x0066D4C5 File Offset: 0x0066B6C5
	public void OnAddEntity(long creatureDataId, int pbDataId)
	{
		this.EntityEventHandler(creatureDataId, pbDataId, true);
	}

	// Token: 0x06017312 RID: 94994 RVA: 0x0066D4D0 File Offset: 0x0066B6D0
	public void OnRemoveEntity(long creatureDataId, int pbDataId)
	{
		this.EntityEventHandler(creatureDataId, pbDataId, false);
	}

	// Token: 0x06017313 RID: 94995 RVA: 0x0066D4DB File Offset: 0x0066B6DB
	protected override bool OnInit()
	{
		this.TaskMap = new Dictionary<int, WaitEntityTask>();
		return true;
	}

	// Token: 0x06017314 RID: 94996 RVA: 0x0066D4E9 File Offset: 0x0066B6E9
	protected override bool OnClear()
	{
		Dictionary<int, WaitEntityTask> taskMap = this.TaskMap;
		if (taskMap != null)
		{
			taskMap.Clear();
		}
		return true;
	}

	// Token: 0x06017315 RID: 94997 RVA: 0x0066D500 File Offset: 0x0066B700
	public unsafe void AddTask(int taskId, WaitEntityTask task)
	{
		Dictionary<int, WaitEntityTask> taskMap = this.TaskMap;
		if (taskMap == null || !taskMap.TryAdd(taskId, task))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.XDW;
			string message = "[WaitEntityTaskModel] AddTask 尝试用一个已经存在的任务ID添加新任务, 阻止添加";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("taskId", taskId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("task", task);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("TaskMap", this.TaskMap);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
	}

	// Token: 0x06017316 RID: 94998 RVA: 0x0066D59B File Offset: 0x0066B79B
	public void RemoveTask(int taskId)
	{
		Dictionary<int, WaitEntityTask> taskMap = this.TaskMap;
		if (taskMap == null)
		{
			return;
		}
		taskMap.Remove(taskId);
	}

	// Token: 0x06017317 RID: 94999 RVA: 0x0066D5B0 File Offset: 0x0066B7B0
	private unsafe void EntityEventHandler(long creatureDataId, int pbDataId, bool isAdd)
	{
		if (this.TaskMap == null)
		{
			return;
		}
		int count = this.TaskMap.Count;
		using (PoolArray<WaitEntityTask> poolArray = this.TaskMap.Values.ToPoolArray<WaitEntityTask>())
		{
			foreach (WaitEntityTask waitEntityTask in poolArray)
			{
				if (isAdd)
				{
					waitEntityTask.OnAddEntity(creatureDataId, pbDataId);
				}
				else
				{
					waitEntityTask.OnRemoveEntity(creatureDataId, pbDataId);
				}
				if (this.TaskMap.Count - count >= 10000)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Entity;
					ELogAuthor author = ELogAuthor.XDW;
					string message = "[WaitEntityTaskModel] 可能是WaitEntityTask的Callback中又创建了WaitEntityTask，导致死循环, 请检查";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("creatureDataId", creatureDataId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("pbDataId", pbDataId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("task", waitEntityTask);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					break;
				}
			}
		}
	}

	// Token: 0x0400B271 RID: 45681
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, WaitEntityTask> TaskMap;

	// Token: 0x0400B272 RID: 45682
	private const int MaxTraversingMapScale = 10000;
}
