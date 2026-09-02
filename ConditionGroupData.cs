using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x0200172F RID: 5935
[NullableContext(1)]
[Nullable(0)]
public class ConditionGroupData : UiPopViewData, IViewOpenParamMultipleView
{
	// Token: 0x17000DC1 RID: 3521
	// (get) Token: 0x0600A589 RID: 42377 RVA: 0x002BC5CE File Offset: 0x002BA7CE
	// (set) Token: 0x0600A58A RID: 42378 RVA: 0x002BC5D6 File Offset: 0x002BA7D6
	public bool IsMultipleView { get; set; }

	// Token: 0x0600A58B RID: 42379 RVA: 0x002BC5DF File Offset: 0x002BA7DF
	public ConditionGroupData(int conditionGroupId, List<IActivityConditionData> dataList, [Nullable(2)] string titleId = "", bool isPreOpen = false)
	{
		this.ConditionGroupId = conditionGroupId;
		this.DataList = dataList;
		this.TitleId = titleId;
		this.IsPreOpen = isPreOpen;
		this.DataList.Sort(new Comparison<IActivityConditionData>(this.SortConditionData));
	}

	// Token: 0x17000DC2 RID: 3522
	// (get) Token: 0x0600A58C RID: 42380 RVA: 0x002BC61B File Offset: 0x002BA81B
	// (set) Token: 0x0600A58D RID: 42381 RVA: 0x002BC623 File Offset: 0x002BA823
	public int ConditionGroupId { get; set; }

	// Token: 0x17000DC3 RID: 3523
	// (get) Token: 0x0600A58E RID: 42382 RVA: 0x002BC62C File Offset: 0x002BA82C
	// (set) Token: 0x0600A58F RID: 42383 RVA: 0x002BC634 File Offset: 0x002BA834
	public List<IActivityConditionData> DataList { get; set; }

	// Token: 0x17000DC4 RID: 3524
	// (get) Token: 0x0600A590 RID: 42384 RVA: 0x002BC63D File Offset: 0x002BA83D
	// (set) Token: 0x0600A591 RID: 42385 RVA: 0x002BC645 File Offset: 0x002BA845
	[Nullable(2)]
	public string TitleId { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x17000DC5 RID: 3525
	// (get) Token: 0x0600A592 RID: 42386 RVA: 0x002BC64E File Offset: 0x002BA84E
	// (set) Token: 0x0600A593 RID: 42387 RVA: 0x002BC656 File Offset: 0x002BA856
	public bool IsPreOpen { get; set; }

	// Token: 0x0600A594 RID: 42388 RVA: 0x002BC660 File Offset: 0x002BA860
	private int SortConditionData(IActivityConditionData a, IActivityConditionData b)
	{
		int num = (a.IsFinished > false) ? 1 : 0;
		int num2 = (b.IsFinished > false) ? 1 : 0;
		if (num != num2)
		{
			return num - num2;
		}
		int[] array = new int[]
		{
			a.AccessType,
			b.AccessType
		};
		List<int> list = new List<int>();
		foreach (int num3 in array)
		{
			int item = 2;
			if (num3 != 7)
			{
				if (num3 == 16)
				{
					item = 1;
				}
			}
			else
			{
				item = 0;
			}
			list.Add(item);
		}
		return list[0] - list[1];
	}
}
