using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200177C RID: 6012
public class AdviceCreateChangeBtnItem : UiPanelBase
{
	// Token: 0x0600A96A RID: 43370 RVA: 0x002D2C51 File Offset: 0x002D0E51
	[NullableContext(1)]
	public AdviceCreateChangeBtnItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600A96B RID: 43371 RVA: 0x002D2C68 File Offset: 0x002D0E68
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnChangeBtn))
		};
	}

	// Token: 0x0600A96C RID: 43372 RVA: 0x002D2CE5 File Offset: 0x002D0EE5
	private void OnChangeBtn()
	{
		this.InitWordViewParam();
		Singleton<UiManager>.Instance.OpenView(EUiViewName.AdviceWordView, null, null);
	}

	// Token: 0x0600A96D RID: 43373 RVA: 0x002D2D00 File Offset: 0x002D0F00
	private void InitWordViewParam()
	{
		AdviceModel instance = ModelBase<AdviceModel>.Instance;
		instance.CurrentChangeWordType = EChangeWordType.Sentence;
		int currentSelectWordId;
		instance.CurrentSentenceWordMap.TryGetValue(this.Index, out currentSelectWordId);
		instance.CurrentSelectWordId = currentSelectWordId;
		instance.CurrentPreSelectSentenceIndex = this.Index;
	}

	// Token: 0x0600A96E RID: 43374 RVA: 0x002D2D3F File Offset: 0x002D0F3F
	public void SetIndex(int index)
	{
		this.Index = index;
	}

	// Token: 0x0600A96F RID: 43375 RVA: 0x002D2D48 File Offset: 0x002D0F48
	public void UpdateCurrentLineMode(ELineMode lineMode)
	{
		this.RefreshViewText(lineMode);
	}

	// Token: 0x0600A970 RID: 43376 RVA: 0x002D2D54 File Offset: 0x002D0F54
	private void RefreshViewText(ELineMode lineMode)
	{
		if (lineMode == ELineMode.SingleLine)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "ChangeOneLineWord", Array.Empty<object>());
			return;
		}
		if (this.Index == 0)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "ChangeFirstLineWord", Array.Empty<object>());
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "ChangeLastLineWord", Array.Empty<object>());
	}

	// Token: 0x04004FD4 RID: 20436
	private int Index;

	// Token: 0x02007ADF RID: 31455
	private static class EComponents
	{
		// Token: 0x0402A144 RID: 172356
		public const int ChangeBtn = 0;

		// Token: 0x0402A145 RID: 172357
		public const int ChangeText = 1;

		// Token: 0x0402A146 RID: 172358
		public const int ItemSelf = 2;
	}
}
