using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Advice;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001780 RID: 6016
public class AdviceCreateWordItem : UiPanelBase
{
	// Token: 0x0600A97A RID: 43386 RVA: 0x002D3009 File Offset: 0x002D1209
	[NullableContext(1)]
	public AdviceCreateWordItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600A97B RID: 43387 RVA: 0x002D302C File Offset: 0x002D122C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x0600A97C RID: 43388 RVA: 0x002D3086 File Offset: 0x002D1286
	protected override void OnStart()
	{
		this.CreateTextItems();
		this.CreateConjunctionItem();
		this.CreateMiddleItemItem();
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIText text = base.GetText(0);
		if (text == null)
		{
			return;
		}
		text.SetUIActive(false);
	}

	// Token: 0x0600A97D RID: 43389 RVA: 0x002D30C0 File Offset: 0x002D12C0
	private void CreateTextItems()
	{
		for (int i = 0; i < 2; i++)
		{
			UUIText uuitext = Singleton<LguiUtil>.Instance.CopyItem(base.GetText(0), this.RootItem) as UUIText;
			if (uuitext != null)
			{
				this.TextArray.Add(uuitext);
			}
		}
	}

	// Token: 0x0600A97E RID: 43390 RVA: 0x002D3108 File Offset: 0x002D1308
	private void CreateConjunctionItem()
	{
		UUIItem item = base.GetItem(1);
		if (item == null)
		{
			return;
		}
		AdviceCreateWordBtnItem conjunctionBtnItem = new AdviceCreateWordBtnItem(Singleton<LguiUtil>.Instance.CopyItem(item, this.RootItem));
		this.ConjunctionBtnItem = conjunctionBtnItem;
		this.ConjunctionBtnItem.SetType(EActiveCreateWordType.Conjunction);
	}

	// Token: 0x0600A97F RID: 43391 RVA: 0x002D314C File Offset: 0x002D134C
	private void CreateMiddleItemItem()
	{
		UUIItem item = base.GetItem(1);
		if (item == null)
		{
			return;
		}
		AdviceCreateWordBtnItem middleBtnItem = new AdviceCreateWordBtnItem(Singleton<LguiUtil>.Instance.CopyItem(item, this.RootItem));
		this.MiddleBtnItem = middleBtnItem;
		this.MiddleBtnItem.SetType(EActiveCreateWordType.NormalWord);
	}

	// Token: 0x0600A980 RID: 43392 RVA: 0x002D318F File Offset: 0x002D138F
	public void SetIndex(int index)
	{
		this.Index = index;
		AdviceCreateWordBtnItem conjunctionBtnItem = this.ConjunctionBtnItem;
		if (conjunctionBtnItem != null)
		{
			conjunctionBtnItem.SetIndex(index);
		}
		AdviceCreateWordBtnItem middleBtnItem = this.MiddleBtnItem;
		if (middleBtnItem == null)
		{
			return;
		}
		middleBtnItem.SetIndex(index);
	}

	// Token: 0x0600A981 RID: 43393 RVA: 0x002D31BB File Offset: 0x002D13BB
	public void RefreshView()
	{
		this.ResetView();
		this.RefreshWord();
	}

	// Token: 0x0600A982 RID: 43394 RVA: 0x002D31CC File Offset: 0x002D13CC
	private void ResetView()
	{
		UUIItem item = base.GetItem(2);
		foreach (UUIText uuitext in this.TextArray)
		{
			uuitext.SetUIActive(false);
			uuitext.SetUIParent(item, false);
		}
		if (this.ConjunctionBtnItem != null)
		{
			this.ConjunctionBtnItem.GetRootItem().SetUIParent(item, false);
			this.ConjunctionBtnItem.GetRootItem().SetUIActive(false);
		}
		if (this.MiddleBtnItem != null)
		{
			this.MiddleBtnItem.GetRootItem().SetUIParent(item, false);
			this.MiddleBtnItem.GetRootItem().SetUIActive(false);
		}
	}

	// Token: 0x0600A983 RID: 43395 RVA: 0x002D3284 File Offset: 0x002D1484
	private void RefreshWord()
	{
		int num;
		ModelBase<AdviceModel>.Instance.CurrentSentenceWordMap.TryGetValue(this.Index, out num);
		if (num <= 0)
		{
			return;
		}
		if (this.Index > 0 && this.ConjunctionBtnItem != null)
		{
			this.ConjunctionBtnItem.GetRootItem().SetUIParent(this.RootItem, false);
			this.ConjunctionBtnItem.GetRootItem().SetUIActive(true);
			this.ConjunctionBtnItem.RefreshView();
		}
		string adviceSentenceText = ConfigBase<AdviceConfig>.Instance.GetAdviceSentenceText(num);
		if (adviceSentenceText == null)
		{
			return;
		}
		string[] array = adviceSentenceText.Split(new string[]
		{
			"{}"
		}, StringSplitOptions.None);
		for (int i = 0; i < array.Length; i++)
		{
			this.TextArray[i].SetText(array[i], true);
			this.TextArray[i].SetUIParent(this.RootItem, false);
			if (i + 1 < array.Length && this.MiddleBtnItem != null)
			{
				this.MiddleBtnItem.GetRootItem().SetUIParent(this.RootItem, false);
				this.MiddleBtnItem.GetRootItem().SetUIActive(true);
				this.MiddleBtnItem.RefreshView();
			}
			this.TextArray[i].SetUIActive(true);
		}
	}

	// Token: 0x04004FDD RID: 20445
	private int Index;

	// Token: 0x04004FDE RID: 20446
	[Nullable(1)]
	private readonly List<UUIText> TextArray = new List<UUIText>();

	// Token: 0x04004FDF RID: 20447
	[Nullable(2)]
	private AdviceCreateWordBtnItem ConjunctionBtnItem;

	// Token: 0x04004FE0 RID: 20448
	[Nullable(2)]
	private AdviceCreateWordBtnItem MiddleBtnItem;

	// Token: 0x02007AE1 RID: 31457
	private static class EComponents
	{
		// Token: 0x0402A149 RID: 172361
		public const int TextTemplate = 0;

		// Token: 0x0402A14A RID: 172362
		public const int WordItem = 1;

		// Token: 0x0402A14B RID: 172363
		public const int HideItem = 2;
	}
}
