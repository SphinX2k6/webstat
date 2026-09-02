using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020026C3 RID: 9923
[NullableContext(1)]
[Nullable(0)]
public class QuestTreeNodeDetailTipsItem : UiPanelBase
{
	// Token: 0x0601392F RID: 80175 RVA: 0x00575CCB File Offset: 0x00573ECB
	public QuestTreeNodeDetailTipsItem(QuestTreeNodeData Data)
	{
	}

	// Token: 0x06013930 RID: 80176 RVA: 0x00575CDC File Offset: 0x00573EDC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06013931 RID: 80177 RVA: 0x00575DA3 File Offset: 0x00573FA3
	public void SetLocalText(string textId)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, Array.Empty<object>());
	}

	// Token: 0x06013932 RID: 80178 RVA: 0x00575DBC File Offset: 0x00573FBC
	public void SetBtnActive(bool active)
	{
		base.GetButton(2).GetRootComponent().SetUIActive(active);
	}

	// Token: 0x06013933 RID: 80179 RVA: 0x00575DD0 File Offset: 0x00573FD0
	public void UpdateData(QuestTreeNodeData data)
	{
		this.Data = data;
	}

	// Token: 0x06013934 RID: 80180 RVA: 0x00575DDC File Offset: 0x00573FDC
	private void OnBtnClick()
	{
		Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(this.Data.QuestId);
		if (quest == null)
		{
			return;
		}
		if (quest.IsSuspend())
		{
			IReadOnlyList<IOccupationInfo> occupations = quest.GetOccupations();
			ModelBase<QuestTreeModel>.Instance.ViewModelChapter.SetOverrideLockReasonGoto(true);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestLockPreview, occupations, null);
		}
	}

	// Token: 0x04009869 RID: 39017
	private QuestTreeNodeData Data = Data;

	// Token: 0x02008A6E RID: 35438
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402EB05 RID: 191237
		public const int SpriteLock = 0;

		// Token: 0x0402EB06 RID: 191238
		public const int TextContent = 1;

		// Token: 0x0402EB07 RID: 191239
		public const int BtnTips = 2;
	}
}
