using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020026BC RID: 9916
[NullableContext(1)]
[Nullable(0)]
public class QuestTreeNodeItemPool
{
	// Token: 0x060138CC RID: 80076 RVA: 0x005730FC File Offset: 0x005712FC
	public QuestTreeNodeItemPool(IQuestTreeNodeItemLoader loader, UUIItem parent)
	{
		this.Loader = loader;
		this.Parent = parent;
		for (int i = 0; i < 5; i++)
		{
			this.Pool[i] = new List<IQuestTreeNodeItem>();
			this.InUseCountMap[i] = 0;
		}
	}

	// Token: 0x060138CD RID: 80077 RVA: 0x00573174 File Offset: 0x00571374
	[NullableContext(0)]
	public UniTask<bool> RefreshByData([Nullable(1)] List<QuestTreeNodeData> dataList)
	{
		QuestTreeNodeItemPool.<RefreshByData>d__10 <RefreshByData>d__;
		<RefreshByData>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RefreshByData>d__.<>4__this = this;
		<RefreshByData>d__.dataList = dataList;
		<RefreshByData>d__.<>1__state = -1;
		<RefreshByData>d__.<>t__builder.Start<QuestTreeNodeItemPool.<RefreshByData>d__10>(ref <RefreshByData>d__);
		return <RefreshByData>d__.<>t__builder.Task;
	}

	// Token: 0x060138CE RID: 80078 RVA: 0x005731C0 File Offset: 0x005713C0
	private UniTask RefreshByDataInternal(List<QuestTreeNodeData> dataList)
	{
		QuestTreeNodeItemPool.<RefreshByDataInternal>d__11 <RefreshByDataInternal>d__;
		<RefreshByDataInternal>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshByDataInternal>d__.<>4__this = this;
		<RefreshByDataInternal>d__.dataList = dataList;
		<RefreshByDataInternal>d__.<>1__state = -1;
		<RefreshByDataInternal>d__.<>t__builder.Start<QuestTreeNodeItemPool.<RefreshByDataInternal>d__11>(ref <RefreshByDataInternal>d__);
		return <RefreshByDataInternal>d__.<>t__builder.Task;
	}

	// Token: 0x060138CF RID: 80079 RVA: 0x0057320B File Offset: 0x0057140B
	public void ClearPool()
	{
		this.IsCleared = true;
		this.Pool.Clear();
		this.InUseCountMap.Clear();
	}

	// Token: 0x060138D0 RID: 80080 RVA: 0x0057322C File Offset: 0x0057142C
	public IQuestTreeNodeItem GetItemByData(QuestTreeNodeData data)
	{
		IQuestTreeNodeItem result;
		this.DataItemMap.TryGetValue(data, out result);
		return result;
	}

	// Token: 0x060138D1 RID: 80081 RVA: 0x0057324C File Offset: 0x0057144C
	private UniTask LoadItems([Nullable(new byte[]
	{
		1,
		0,
		1
	})] List<ValueTuple<QuestTreeNodeData, int>> loadTasks)
	{
		QuestTreeNodeItemPool.<LoadItems>d__14 <LoadItems>d__;
		<LoadItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadItems>d__.<>4__this = this;
		<LoadItems>d__.loadTasks = loadTasks;
		<LoadItems>d__.<>1__state = -1;
		<LoadItems>d__.<>t__builder.Start<QuestTreeNodeItemPool.<LoadItems>d__14>(ref <LoadItems>d__);
		return <LoadItems>d__.<>t__builder.Task;
	}

	// Token: 0x060138D2 RID: 80082 RVA: 0x00573298 File Offset: 0x00571498
	private UniTask ProcessTask([Nullable(new byte[]
	{
		0,
		1
	})] ValueTuple<QuestTreeNodeData, int> task)
	{
		QuestTreeNodeItemPool.<ProcessTask>d__15 <ProcessTask>d__;
		<ProcessTask>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ProcessTask>d__.<>4__this = this;
		<ProcessTask>d__.task = task;
		<ProcessTask>d__.<>1__state = -1;
		<ProcessTask>d__.<>t__builder.Start<QuestTreeNodeItemPool.<ProcessTask>d__15>(ref <ProcessTask>d__);
		return <ProcessTask>d__.<>t__builder.Task;
	}

	// Token: 0x060138D3 RID: 80083 RVA: 0x005732E4 File Offset: 0x005714E4
	private void ResetPool()
	{
		this.DataItemMap.Clear();
		foreach (KeyValuePair<int, List<IQuestTreeNodeItem>> keyValuePair in this.Pool)
		{
			int num;
			List<IQuestTreeNodeItem> list;
			keyValuePair.Deconstruct(out num, out list);
			int key = num;
			foreach (IQuestTreeNodeItem questTreeNodeItem in list)
			{
				(questTreeNodeItem as UiPanelBase).SetUiActive(false);
			}
			this.InUseCountMap[key] = 0;
		}
	}

	// Token: 0x04009843 RID: 38979
	private const int HIERARCHY_START_INDEX = 2;

	// Token: 0x04009844 RID: 38980
	private readonly Dictionary<int, List<IQuestTreeNodeItem>> Pool = new Dictionary<int, List<IQuestTreeNodeItem>>();

	// Token: 0x04009845 RID: 38981
	private readonly Dictionary<int, int> InUseCountMap = new Dictionary<int, int>();

	// Token: 0x04009846 RID: 38982
	private readonly Dictionary<QuestTreeNodeData, IQuestTreeNodeItem> DataItemMap = new Dictionary<QuestTreeNodeData, IQuestTreeNodeItem>();

	// Token: 0x04009847 RID: 38983
	private int RefreshVersion;

	// Token: 0x04009848 RID: 38984
	private UniTask RefreshTail = UniTask.CompletedTask;

	// Token: 0x04009849 RID: 38985
	private bool IsCleared;

	// Token: 0x0400984A RID: 38986
	private readonly IQuestTreeNodeItemLoader Loader;

	// Token: 0x0400984B RID: 38987
	private readonly UUIItem Parent;
}
