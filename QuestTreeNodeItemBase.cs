using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x020026B7 RID: 9911
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public abstract class QuestTreeNodeItemBase<[Nullable(2)] TData> : GridProxyAbstract<TData>, IQuestTreeNodeItem
{
	// Token: 0x170018B6 RID: 6326
	// (get) Token: 0x0601388D RID: 80013
	public abstract EQuestTreeNodeType Type { get; }

	// Token: 0x170018B7 RID: 6327
	// (get) Token: 0x0601388E RID: 80014 RVA: 0x00571D89 File Offset: 0x0056FF89
	// (set) Token: 0x0601388F RID: 80015 RVA: 0x00571D91 File Offset: 0x0056FF91
	public int HierarchyIndex { get; set; }

	// Token: 0x170018B8 RID: 6328
	// (get) Token: 0x06013890 RID: 80016 RVA: 0x00571D9A File Offset: 0x0056FF9A
	// (set) Token: 0x06013891 RID: 80017 RVA: 0x00571DA2 File Offset: 0x0056FFA2
	private protected IQuestTreeNodeItemLoader Loader { protected get; private set; }

	// Token: 0x06013892 RID: 80018 RVA: 0x00571DAB File Offset: 0x0056FFAB
	public void Init(IQuestTreeNodeItemLoader loader)
	{
		this.Loader = loader;
	}

	// Token: 0x06013893 RID: 80019
	public abstract UniTask CreateSelf(UUIItem parent);

	// Token: 0x06013894 RID: 80020
	public abstract void UpdateData(QuestTreeNodeData data);

	// Token: 0x06013895 RID: 80021 RVA: 0x00571DB4 File Offset: 0x0056FFB4
	public virtual float GetAdditionalHeight()
	{
		return 0f;
	}

	// Token: 0x06013896 RID: 80022 RVA: 0x00571DBB File Offset: 0x0056FFBB
	public virtual void UpdateDataList(List<QuestTreeNodeData> data)
	{
	}

	// Token: 0x06013897 RID: 80023 RVA: 0x00571DBD File Offset: 0x0056FFBD
	protected virtual void LocateSelf(bool tween = true)
	{
		QuestTreeNodeLocatingHelper locatingHelper = ModelBase<QuestTreeModel>.Instance.ViewModelChapter.LocatingHelper;
		if (locatingHelper == null)
		{
			return;
		}
		locatingHelper.LocateToNode(base.GetRootItem(), tween, false);
	}
}
