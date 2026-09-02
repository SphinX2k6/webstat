using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F63 RID: 8035
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryQuestItemChildItem : UiPanelBase, IGridProxy<HonamiStoryQuestDataBase>
{
	// Token: 0x0600F09A RID: 61594 RVA: 0x0041C0FC File Offset: 0x0041A2FC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action<EToggleState>(this.OnClickToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F09B RID: 61595 RVA: 0x0041C2AC File Offset: 0x0041A4AC
	protected override void OnStart()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(4);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChange));
	}

	// Token: 0x0600F09C RID: 61596 RVA: 0x0041C2D0 File Offset: 0x0041A4D0
	protected override void OnBeforeDestroy()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(4);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.OnStateChange.Remove(new Action<EToggleState>(this.OnToggleStateChange));
	}

	// Token: 0x17001258 RID: 4696
	// (get) Token: 0x0600F09D RID: 61597 RVA: 0x0041C2F4 File Offset: 0x0041A4F4
	[Nullable(2)]
	public HonamiStoryQuestDataBase Data
	{
		[NullableContext(2)]
		get
		{
			return this.TaskData;
		}
	}

	// Token: 0x17001259 RID: 4697
	// (get) Token: 0x0600F09E RID: 61598 RVA: 0x0041C2FC File Offset: 0x0041A4FC
	// (set) Token: 0x0600F09F RID: 61599 RVA: 0x0041C304 File Offset: 0x0041A504
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	public IScrollViewDelegate<IGridProxy<HonamiStoryQuestDataBase>, HonamiStoryQuestDataBase> ScrollViewDelegate { [return: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] set; }

	// Token: 0x1700125A RID: 4698
	// (get) Token: 0x0600F0A0 RID: 61600 RVA: 0x0041C30D File Offset: 0x0041A50D
	// (set) Token: 0x0600F0A1 RID: 61601 RVA: 0x0041C315 File Offset: 0x0041A515
	public int GridIndex { get; set; }

	// Token: 0x1700125B RID: 4699
	// (get) Token: 0x0600F0A2 RID: 61602 RVA: 0x0041C31E File Offset: 0x0041A51E
	// (set) Token: 0x0600F0A3 RID: 61603 RVA: 0x0041C326 File Offset: 0x0041A526
	public int DisplayIndex { get; set; }

	// Token: 0x0600F0A4 RID: 61604 RVA: 0x0041C330 File Offset: 0x0041A530
	public void Refresh(HonamiStoryQuestDataBase data, bool isSelected, int gridIndex)
	{
		if (this.ActivityData == null)
		{
			this.ActivityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(true);
		}
		this.TaskData = data;
		this.RefreshTaskInfo();
		base.GetText(3).SetUIActive(false);
		base.GetText(8).SetUIActive(false);
	}

	// Token: 0x0600F0A5 RID: 61605 RVA: 0x0041C380 File Offset: 0x0041A580
	private void RefreshTaskInfo()
	{
		string text = ConfigMultiTextLang.GetLocalTextNew(this.TaskData.GetNameKey(), null) ?? this.TaskData.GetNameKey();
		UUIText text2 = base.GetText(2);
		string newText;
		if (this.TaskData.TaskType == EHonamiStoryQuestType.Main)
		{
			newText = StringUtils.Format((base.GetExtendToggle(4).GetToggleState() == EToggleState.ETT_Checked) ? "<color=#5988a5>{0}</color>" : "<color=#b3dffa>{0}</color>", new string[]
			{
				text
			});
			if (text2 != null)
			{
				text2.SetRichText(true);
			}
		}
		else if ((this.TaskData as HonamiStorySubQuestData).Config.Value.TaskType != 1)
		{
			if (text2 != null)
			{
				text2.SetRichText(false);
			}
			newText = text;
		}
		else
		{
			if (text2 != null)
			{
				text2.SetRichText(true);
			}
			newText = StringUtils.Format((base.GetExtendToggle(4).GetToggleState() == EToggleState.ETT_Checked) ? "<color=#5988a5>{0}</color>" : "<color=#b3dffa>{0}</color>", new string[]
			{
				text
			});
		}
		if (text2 != null)
		{
			text2.SetText(newText, true);
		}
		base.GetItem(9).SetUIActive(this.TaskData.IsFinished());
	}

	// Token: 0x0600F0A6 RID: 61606 RVA: 0x0041C489 File Offset: 0x0041A689
	public void BindOnClickTask(Action<HonamiStoryQuestItemChildItem> callback)
	{
		this.OnClickTask = callback;
	}

	// Token: 0x0600F0A7 RID: 61607 RVA: 0x0041C492 File Offset: 0x0041A692
	private void OnClickToggle(EToggleState toggleState)
	{
		Action<HonamiStoryQuestItemChildItem> onClickTask = this.OnClickTask;
		if (onClickTask == null)
		{
			return;
		}
		onClickTask(this);
	}

	// Token: 0x0600F0A8 RID: 61608 RVA: 0x0041C4A5 File Offset: 0x0041A6A5
	public void Clear()
	{
	}

	// Token: 0x0600F0A9 RID: 61609 RVA: 0x0041C4A7 File Offset: 0x0041A6A7
	public void OnSelected(bool fireEvent)
	{
	}

	// Token: 0x0600F0AA RID: 61610 RVA: 0x0041C4A9 File Offset: 0x0041A6A9
	public void OnDeselected(bool fireEvent)
	{
	}

	// Token: 0x0600F0AB RID: 61611 RVA: 0x0041C4AB File Offset: 0x0041A6AB
	public void OnSelected()
	{
		base.GetExtendToggle(4).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		this.RefreshTaskInfo();
	}

	// Token: 0x0600F0AC RID: 61612 RVA: 0x0041C4C4 File Offset: 0x0041A6C4
	public void OnDeselected()
	{
		base.GetExtendToggle(4).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		this.RefreshTaskInfo();
	}

	// Token: 0x0600F0AD RID: 61613 RVA: 0x0041C4DD File Offset: 0x0041A6DD
	public object GetKey(HonamiStoryQuestDataBase data, int gridIndex)
	{
		return this.GridIndex;
	}

	// Token: 0x0600F0AE RID: 61614 RVA: 0x0041C4EA File Offset: 0x0041A6EA
	private void OnToggleStateChange(EToggleState _)
	{
		this.RefreshTaskInfo();
	}

	// Token: 0x0400739D RID: 29597
	private const string RICHTXT_SELECTED = "<color=#5988a5>{0}</color>";

	// Token: 0x0400739E RID: 29598
	private const string RICHTXT_DESELECTED = "<color=#b3dffa>{0}</color>";

	// Token: 0x0400739F RID: 29599
	[Nullable(2)]
	private HonamiStoryActivityData ActivityData;

	// Token: 0x040073A0 RID: 29600
	[Nullable(2)]
	private HonamiStoryQuestDataBase TaskData;

	// Token: 0x040073A1 RID: 29601
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<HonamiStoryQuestItemChildItem> OnClickTask;

	// Token: 0x020082F3 RID: 33523
	[NullableContext(0)]
	private enum EHonamiStoryQuestItemChildItemComponent
	{
		// Token: 0x0402C65F RID: 181855
		TraceItem,
		// Token: 0x0402C660 RID: 181856
		LockItem,
		// Token: 0x0402C661 RID: 181857
		NameText,
		// Token: 0x0402C662 RID: 181858
		DistanceText,
		// Token: 0x0402C663 RID: 181859
		Toggle,
		// Token: 0x0402C664 RID: 181860
		QualityColorItem,
		// Token: 0x0402C665 RID: 181861
		RedDotItem,
		// Token: 0x0402C666 RID: 181862
		CircleSprite,
		// Token: 0x0402C667 RID: 181863
		LockText,
		// Token: 0x0402C668 RID: 181864
		FinishItem
	}
}
