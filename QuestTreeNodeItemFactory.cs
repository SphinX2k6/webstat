using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020026B5 RID: 9909
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class QuestTreeNodeItemFactory : Singleton<QuestTreeNodeItemFactory>
{
	// Token: 0x06013880 RID: 80000 RVA: 0x00571CA6 File Offset: 0x0056FEA6
	protected override bool OnInit()
	{
		this.InitializeLoader();
		return true;
	}

	// Token: 0x06013881 RID: 80001 RVA: 0x00571CB0 File Offset: 0x0056FEB0
	public void InitializeLoader()
	{
		this.Loader = new QuestTreeNodeItemLoader();
		this.Loader.RegisterNodeType(EQuestTreeNodeType.Picture, typeof(QuestTreePictureNodeItem));
		this.Loader.RegisterNodeType(EQuestTreeNodeType.Text, typeof(QuestTreeTextNodeItem));
		this.Loader.RegisterNodeType(EQuestTreeNodeType.Series, typeof(QuestTreeSeriesNodeItem));
		this.Loader.RegisterNodeType(EQuestTreeNodeType.Container, typeof(QuestTreeNodeContainer));
	}

	// Token: 0x06013882 RID: 80002 RVA: 0x00571D20 File Offset: 0x0056FF20
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public UniTask<IQuestTreeNodeItem> CreateAndLoadNode(QuestTreeNodeData nodeData, UUIItem parent)
	{
		QuestTreeNodeItemFactory.<CreateAndLoadNode>d__3 <CreateAndLoadNode>d__;
		<CreateAndLoadNode>d__.<>t__builder = AsyncUniTaskMethodBuilder<IQuestTreeNodeItem>.Create();
		<CreateAndLoadNode>d__.<>4__this = this;
		<CreateAndLoadNode>d__.nodeData = nodeData;
		<CreateAndLoadNode>d__.parent = parent;
		<CreateAndLoadNode>d__.<>1__state = -1;
		<CreateAndLoadNode>d__.<>t__builder.Start<QuestTreeNodeItemFactory.<CreateAndLoadNode>d__3>(ref <CreateAndLoadNode>d__);
		return <CreateAndLoadNode>d__.<>t__builder.Task;
	}

	// Token: 0x06013883 RID: 80003 RVA: 0x00571D73 File Offset: 0x0056FF73
	[NullableContext(2)]
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public QuestTreeNodeItemBase<TData> CreateLogicalNodeItem<TData>(EQuestTreeNodeType type)
	{
		return this.Loader.CreateLogicalNodeItem<TData>(type);
	}

	// Token: 0x04009826 RID: 38950
	private QuestTreeNodeItemLoader Loader;
}
