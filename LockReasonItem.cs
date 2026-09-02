using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002665 RID: 9829
[NullableContext(1)]
[Nullable(0)]
public class LockReasonItem : UiPanelBase
{
	// Token: 0x060135BE RID: 79294 RVA: 0x005630D8 File Offset: 0x005612D8
	public LockReasonItem(IOccupationInfo occupationInfo)
	{
		this.QuestName = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTreeName(occupationInfo.TreeIncId);
		this.ResourceName = ConfigBase<QuestNewConfig>.Instance.GetOccupationResourceName(occupationInfo.ResourceName);
		this.OccupationType = ConfigBase<QuestNewConfig>.Instance.GetOccupationType(occupationInfo.ResourceName);
		this.TreeIncId = occupationInfo.TreeIncId;
	}

	// Token: 0x060135BF RID: 79295 RVA: 0x0056315C File Offset: 0x0056135C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
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
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060135C0 RID: 79296 RVA: 0x00563223 File Offset: 0x00561423
	protected override void OnStart()
	{
		this.UpdateItem();
	}

	// Token: 0x060135C1 RID: 79297 RVA: 0x0056322C File Offset: 0x0056142C
	public void UpdateItem()
	{
		UUIText text = base.GetText(0);
		if (text != null)
		{
			text.SetText(this.QuestName, true);
		}
		string str = string.Empty;
		if (this.OccupationType == "Area")
		{
			str = (ConfigMultiTextLang.GetLocalTextNew("Text_OccupiedArea", null) ?? string.Empty);
		}
		else
		{
			str = (ConfigMultiTextLang.GetLocalTextNew("Text_OccupiedRole", null) ?? string.Empty);
		}
		string newText = str + ":" + this.ResourceName;
		UUIText text2 = base.GetText(1);
		if (text2 == null)
		{
			return;
		}
		text2.SetText(newText, true);
	}

	// Token: 0x060135C2 RID: 79298 RVA: 0x005632BC File Offset: 0x005614BC
	private void OnClickBtn()
	{
		BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(this.TreeIncId), false);
		if (behaviorTree == null)
		{
			return;
		}
		if (ModelBase<QuestTreeModel>.Instance.ViewModelChapter.OverrideLockReasonGoto)
		{
			ModelBase<QuestTreeModel>.Instance.ViewModelChapter.SetOverrideLockReasonGoto(false);
			ControllerBase<QuestTreeController>.Instance.JumpToQuest(behaviorTree.TreeConfigId);
			Singleton<UiManager>.Instance.CloseView(EUiViewName.QuestLockPreview, null);
			return;
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnNavigationQuest, behaviorTree.TreeConfigId);
		Singleton<UiManager>.Instance.CloseView(EUiViewName.QuestLockPreview, null);
	}

	// Token: 0x0400971E RID: 38686
	private readonly string QuestName = string.Empty;

	// Token: 0x0400971F RID: 38687
	private readonly string ResourceName = string.Empty;

	// Token: 0x04009720 RID: 38688
	private readonly string OccupationType = string.Empty;

	// Token: 0x04009721 RID: 38689
	private readonly long TreeIncId;

	// Token: 0x020089F7 RID: 35319
	[NullableContext(0)]
	private class EChildComponent
	{
		// Token: 0x0402E88F RID: 190607
		public const int QuestNameText = 0;

		// Token: 0x0402E890 RID: 190608
		public const int OccupationSourceText = 1;

		// Token: 0x0402E891 RID: 190609
		public const int GoToTaskBtn = 2;
	}
}
