using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020026BB RID: 9915
[NullableContext(1)]
[Nullable(0)]
public class QuestTreeCollectBtnItem : UiPanelBase
{
	// Token: 0x060138C6 RID: 80070 RVA: 0x00572F45 File Offset: 0x00571145
	public QuestTreeCollectBtnItem(QuestTreeChapterData data)
	{
		this.Data = data;
	}

	// Token: 0x060138C7 RID: 80071 RVA: 0x00572F54 File Offset: 0x00571154
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnCollectClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060138C8 RID: 80072 RVA: 0x0057301B File Offset: 0x0057121B
	protected override void OnStart()
	{
		this.Refresh();
	}

	// Token: 0x060138C9 RID: 80073 RVA: 0x00573024 File Offset: 0x00571224
	public void Refresh()
	{
		List<QuestTreeNodeData> acceptableNodeList = this.Data.GetAcceptableNodeList();
		bool uiactive = false;
		using (List<QuestTreeNodeData>.Enumerator enumerator = acceptableNodeList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.HasNewTag())
				{
					uiactive = true;
					break;
				}
			}
		}
		base.GetItem(2).SetUIActive(uiactive);
	}

	// Token: 0x060138CA RID: 80074 RVA: 0x00573090 File Offset: 0x00571290
	public void RefreshByData(QuestTreeChapterData data)
	{
		this.Data = data;
		this.Refresh();
	}

	// Token: 0x060138CB RID: 80075 RVA: 0x005730A0 File Offset: 0x005712A0
	private void OnCollectClick()
	{
		List<QuestTreeNodeData> acceptableNodeList = this.Data.GetAcceptableNodeList();
		if (acceptableNodeList.Count == 0)
		{
			return;
		}
		ControllerBase<QuestTreeController>.Instance.OpenAvailableListView(acceptableNodeList);
		base.GetItem(2).SetUIActive(false);
		QuestTreeClickAcceptableLogEvent questTreeClickAcceptableLogEvent = new QuestTreeClickAcceptableLogEvent();
		questTreeClickAcceptableLogEvent.i_chapter_id = this.Data.Id;
		ControllerBase<LogReportController>.Instance.LogReport(questTreeClickAcceptableLogEvent);
	}

	// Token: 0x04009842 RID: 38978
	private QuestTreeChapterData Data;

	// Token: 0x02008A55 RID: 35413
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402EA45 RID: 191045
		public const int BtnCollect = 0;

		// Token: 0x0402EA46 RID: 191046
		public const int ItemRedDot = 1;

		// Token: 0x0402EA47 RID: 191047
		public const int ItemNew = 2;
	}
}
