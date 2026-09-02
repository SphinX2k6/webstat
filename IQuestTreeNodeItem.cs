using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x020026B6 RID: 9910
[NullableContext(1)]
public interface IQuestTreeNodeItem
{
	// Token: 0x170018B4 RID: 6324
	// (get) Token: 0x06013885 RID: 80005
	EQuestTreeNodeType Type { get; }

	// Token: 0x170018B5 RID: 6325
	// (get) Token: 0x06013886 RID: 80006
	// (set) Token: 0x06013887 RID: 80007
	int HierarchyIndex { get; set; }

	// Token: 0x06013888 RID: 80008
	void Init(IQuestTreeNodeItemLoader loader);

	// Token: 0x06013889 RID: 80009
	UniTask CreateSelf(UUIItem parent);

	// Token: 0x0601388A RID: 80010
	void UpdateData(QuestTreeNodeData data);

	// Token: 0x0601388B RID: 80011
	float GetAdditionalHeight();

	// Token: 0x0601388C RID: 80012
	void UpdateDataList(List<QuestTreeNodeData> data);
}
