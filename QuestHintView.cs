using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002668 RID: 9832
public class QuestHintView : UiViewBase
{
	// Token: 0x060135D5 RID: 79317 RVA: 0x00563AA8 File Offset: 0x00561CA8
	[NullableContext(1)]
	public QuestHintView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060135D6 RID: 79318 RVA: 0x00563AB4 File Offset: 0x00561CB4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060135D7 RID: 79319 RVA: 0x00563B5F File Offset: 0x00561D5F
	protected override void OnStart()
	{
		this.UiViewSequence.AddSequenceFinishEvent("PopUp", new Action<string>(this.FinishSequenceEvent), false);
	}

	// Token: 0x060135D8 RID: 79320 RVA: 0x00563B7E File Offset: 0x00561D7E
	[NullableContext(1)]
	private void FinishSequenceEvent(string _)
	{
		this.OnPopUpEnd();
	}

	// Token: 0x060135D9 RID: 79321 RVA: 0x00563B88 File Offset: 0x00561D88
	protected override void OnAfterShow()
	{
		this.InitComponent();
		this.UiViewSequence.PlaySequence("PopUp", false, null);
	}

	// Token: 0x060135DA RID: 79322 RVA: 0x00563BB5 File Offset: 0x00561DB5
	private void OnPopUpEnd()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.QuestHintView, null);
	}

	// Token: 0x060135DB RID: 79323 RVA: 0x00563BC7 File Offset: 0x00561DC7
	private void InitComponent()
	{
		this.ToggleButton(false);
		this.RootItem.SetAnchorOffsetX(0f);
	}

	// Token: 0x060135DC RID: 79324 RVA: 0x00563BE0 File Offset: 0x00561DE0
	private void ToggleButton(bool inEnable)
	{
		base.GetText(3).SetUIActive(inEnable);
		base.GetSprite(2).SetUIActive(inEnable);
	}

	// Token: 0x020089FA RID: 35322
	private class EQuestHintChildCom
	{
		// Token: 0x0402E89C RID: 190620
		public const int QuestDesc = 0;

		// Token: 0x0402E89D RID: 190621
		public const int QuestHintType = 1;

		// Token: 0x0402E89E RID: 190622
		public const int ButtonHint = 2;

		// Token: 0x0402E89F RID: 190623
		public const int ButtonDesc = 3;
	}
}
