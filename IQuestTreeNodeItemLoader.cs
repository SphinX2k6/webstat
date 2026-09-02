using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x020026B4 RID: 9908
[NullableContext(1)]
public interface IQuestTreeNodeItemLoader
{
	// Token: 0x0601387D RID: 79997
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	UniTask<IQuestTreeNodeItem> LoadNodeItem(QuestTreeNodeData nodeData, UUIItem parent);

	// Token: 0x0601387E RID: 79998
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	UniTask<IQuestTreeNodeItem> LoadNodeContainer(List<QuestTreeNodeData> nodeDataList, UUIItem parent);

	// Token: 0x0601387F RID: 79999
	[NullableContext(2)]
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	QuestTreeNodeItemBase<TData> CreateLogicalNodeItem<TData>(EQuestTreeNodeType type);
}
