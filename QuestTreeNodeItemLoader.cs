using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020026B8 RID: 9912
[NullableContext(1)]
[Nullable(0)]
public class QuestTreeNodeItemLoader : IQuestTreeNodeItemLoader
{
	// Token: 0x06013899 RID: 80025 RVA: 0x00571DE8 File Offset: 0x0056FFE8
	public void RegisterNodeType(EQuestTreeNodeType type, Type ctorType)
	{
		this._nodeConstructors[type] = ctorType;
	}

	// Token: 0x0601389A RID: 80026 RVA: 0x00571DF8 File Offset: 0x0056FFF8
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public UniTask<IQuestTreeNodeItem> LoadNodeItem(QuestTreeNodeData nodeData, UUIItem parent)
	{
		QuestTreeNodeItemLoader.<LoadNodeItem>d__2 <LoadNodeItem>d__;
		<LoadNodeItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<IQuestTreeNodeItem>.Create();
		<LoadNodeItem>d__.<>4__this = this;
		<LoadNodeItem>d__.nodeData = nodeData;
		<LoadNodeItem>d__.parent = parent;
		<LoadNodeItem>d__.<>1__state = -1;
		<LoadNodeItem>d__.<>t__builder.Start<QuestTreeNodeItemLoader.<LoadNodeItem>d__2>(ref <LoadNodeItem>d__);
		return <LoadNodeItem>d__.<>t__builder.Task;
	}

	// Token: 0x0601389B RID: 80027 RVA: 0x00571E4C File Offset: 0x0057004C
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public UniTask<IQuestTreeNodeItem> LoadNodeContainer(List<QuestTreeNodeData> nodeDataList, UUIItem parent)
	{
		QuestTreeNodeItemLoader.<LoadNodeContainer>d__3 <LoadNodeContainer>d__;
		<LoadNodeContainer>d__.<>t__builder = AsyncUniTaskMethodBuilder<IQuestTreeNodeItem>.Create();
		<LoadNodeContainer>d__.<>4__this = this;
		<LoadNodeContainer>d__.nodeDataList = nodeDataList;
		<LoadNodeContainer>d__.parent = parent;
		<LoadNodeContainer>d__.<>1__state = -1;
		<LoadNodeContainer>d__.<>t__builder.Start<QuestTreeNodeItemLoader.<LoadNodeContainer>d__3>(ref <LoadNodeContainer>d__);
		return <LoadNodeContainer>d__.<>t__builder.Task;
	}

	// Token: 0x0601389C RID: 80028 RVA: 0x00571EA0 File Offset: 0x005700A0
	[NullableContext(2)]
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public QuestTreeNodeItemBase<TData> CreateLogicalNodeItem<TData>(EQuestTreeNodeType type)
	{
		Type type2;
		if (!this._nodeConstructors.TryGetValue(type, out type2))
		{
			return null;
		}
		QuestTreeNodeItemBase<TData> questTreeNodeItemBase = (QuestTreeNodeItemBase<TData>)Activator.CreateInstance(type2);
		questTreeNodeItemBase.Init(this);
		return questTreeNodeItemBase;
	}

	// Token: 0x04009829 RID: 38953
	private readonly Dictionary<EQuestTreeNodeType, Type> _nodeConstructors = new Dictionary<EQuestTreeNodeType, Type>();
}
