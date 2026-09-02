using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Advice;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001787 RID: 6023
[NullableContext(1)]
[Nullable(0)]
public class AdviceMutiSentenceSelectView : UiViewBase
{
	// Token: 0x0600A9DE RID: 43486 RVA: 0x002D4C40 File Offset: 0x002D2E40
	public AdviceMutiSentenceSelectView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600A9DF RID: 43487 RVA: 0x002D4C4C File Offset: 0x002D2E4C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIScrollbarComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickCancelBtn)),
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickConfirmBtn))
		};
	}

	// Token: 0x0600A9E0 RID: 43488 RVA: 0x002D4D50 File Offset: 0x002D2F50
	protected override void OnStart()
	{
		this.AdviceSentenceSelectScroller = new GenericScrollView<AdviceSentenceSelectItem>(base.GetScrollViewWithScrollbar(0), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<AdviceSentenceSelectItem>(this.CreateSortItem), null);
		this.AdviceWordScroller = new GenericScrollView<AdviceSentenceSelectItemContent>(base.GetScrollViewWithScrollbar(2), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<AdviceSentenceSelectItemContent>(this.CreateWordItem), null);
		UUIItem tempOriginalItem = this.AdviceWordScroller.TempOriginalItem;
		if (tempOriginalItem != null)
		{
			AActor owner = tempOriginalItem.GetOwner();
			if (owner != null)
			{
				UUIButtonComponent uuibuttonComponent = owner.GetComponentByClass(UUIButtonComponent.StaticClass()) as UUIButtonComponent;
				if (uuibuttonComponent != null)
				{
					owner.K2_DestroyComponent(uuibuttonComponent);
				}
			}
		}
		ModelBase<AdviceModel>.Instance.CurrentSentenceSelectIndex = 0;
		ModelBase<AdviceModel>.Instance.CurrentPreSentenceWordMap.Clear();
		foreach (KeyValuePair<int, int> keyValuePair in ModelBase<AdviceModel>.Instance.CurrentSentenceWordMap)
		{
			ModelBase<AdviceModel>.Instance.CurrentPreSentenceWordMap[keyValuePair.Key] = keyValuePair.Value;
		}
		this.RefreshAdviceSort();
		this.RefreshTitle();
	}

	// Token: 0x0600A9E1 RID: 43489 RVA: 0x002D4E5C File Offset: 0x002D305C
	private ILayoutItem<AdviceSentenceSelectItem> CreateSortItem(object data, UUIItem uiItem, int index)
	{
		AdviceSentenceSelectItem adviceSentenceSelectItem = new AdviceSentenceSelectItem(uiItem);
		adviceSentenceSelectItem.UpdateItem((int)data);
		return new LayoutItem<AdviceSentenceSelectItem>
		{
			Key = index,
			Value = adviceSentenceSelectItem
		};
	}

	// Token: 0x0600A9E2 RID: 43490 RVA: 0x002D4E94 File Offset: 0x002D3094
	private ILayoutItem<AdviceSentenceSelectItemContent> CreateWordItem(object data, UUIItem uiItem, int index)
	{
		AdviceSentenceSelectItemContent adviceSentenceSelectItemContent = new AdviceSentenceSelectItemContent(uiItem);
		adviceSentenceSelectItemContent.UpdateItem((int)data);
		return new LayoutItem<AdviceSentenceSelectItemContent>
		{
			Key = index,
			Value = adviceSentenceSelectItemContent
		};
	}

	// Token: 0x0600A9E3 RID: 43491 RVA: 0x002D4ECC File Offset: 0x002D30CC
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnClickAdviceSort, new Action(this.RefreshAdviceSort));
	}

	// Token: 0x0600A9E4 RID: 43492 RVA: 0x002D4EEA File Offset: 0x002D30EA
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnClickAdviceSort, new Action(this.RefreshAdviceSort));
	}

	// Token: 0x0600A9E5 RID: 43493 RVA: 0x002D4F08 File Offset: 0x002D3108
	private void OnClickConfirmBtn()
	{
		foreach (KeyValuePair<int, int> keyValuePair in ModelBase<AdviceModel>.Instance.CurrentPreSentenceWordMap)
		{
			int num;
			ModelBase<AdviceModel>.Instance.CurrentSentenceWordMap.TryGetValue(keyValuePair.Key, out num);
			if (num != keyValuePair.Value)
			{
				ModelBase<AdviceModel>.Instance.OnChangeSentence(keyValuePair.Key);
			}
		}
		foreach (KeyValuePair<int, int> keyValuePair2 in ModelBase<AdviceModel>.Instance.CurrentPreSentenceWordMap)
		{
			ModelBase<AdviceModel>.Instance.CurrentSentenceWordMap[keyValuePair2.Key] = keyValuePair2.Value;
		}
		base.CloseMe(null);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnChangeAdviceWord);
	}

	// Token: 0x0600A9E6 RID: 43494 RVA: 0x002D5000 File Offset: 0x002D3200
	private void OnClickCancelBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600A9E7 RID: 43495 RVA: 0x002D5009 File Offset: 0x002D3209
	private void RefreshTitle()
	{
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(7), "AdvicePutSentence", Array.Empty<object>());
	}

	// Token: 0x0600A9E8 RID: 43496 RVA: 0x002D5028 File Offset: 0x002D3228
	private void RefreshAdviceSort()
	{
		List<int> data = new List<int>
		{
			0,
			1
		};
		this.AdviceSentenceSelectScroller.RefreshByData<int>(data, null);
		this.RefreshAdviceSortWord();
		this.AdviceWordTypeFlag = 0;
		this.AdviceSentenceSelectScroller.UnBindLateUpdate();
		this.AdviceSentenceSelectScrollerScrollToDirty = true;
		this.AdviceSentenceSelectScroller.BindLateUpdate(new Action<float>(this.AdviceSentenceSelectScrollerLateUpdate));
	}

	// Token: 0x0600A9E9 RID: 43497 RVA: 0x002D5094 File Offset: 0x002D3294
	private void AdviceSentenceSelectScrollerLateUpdate(float deltaTime)
	{
		if (this.AdviceSentenceSelectScrollerScrollToDirty && this.AdviceWordTypeFlag >= 1)
		{
			this.AdviceSentenceSelectScrollerScrollToDirty = false;
			float wordTypeProgress = this.GetWordTypeProgress();
			base.GetScrollViewWithScrollbar(0).SetScrollProgress(wordTypeProgress);
			this.AdviceSentenceSelectScroller.UnBindLateUpdate();
		}
		this.AdviceWordTypeFlag++;
	}

	// Token: 0x0600A9EA RID: 43498 RVA: 0x002D50E6 File Offset: 0x002D32E6
	private float GetWordTypeProgress()
	{
		return (float)ModelBase<AdviceModel>.Instance.CurrentSentenceSelectIndex;
	}

	// Token: 0x0600A9EB RID: 43499 RVA: 0x002D50F4 File Offset: 0x002D32F4
	private void RefreshAdviceSortWord()
	{
		List<int> list = new List<int>();
		IReadOnlyList<AdviceSentence> adviceSentenceConfigs = ConfigBase<AdviceConfig>.Instance.GetAdviceSentenceConfigs();
		if (adviceSentenceConfigs != null)
		{
			foreach (AdviceSentence adviceSentence in adviceSentenceConfigs)
			{
				list.Add(adviceSentence.Id);
			}
		}
		this.AdviceWordScroller.RefreshByData<int>(list, null);
		this.AdviceWordFlag = 0;
		this.AdviceWordScroller.UnBindLateUpdate();
		this.AdviceWordScrollerScrollToDirty = true;
		this.AdviceWordScroller.BindLateUpdate(new Action<float>(this.AdviceWordScrollerLateUpdate));
	}

	// Token: 0x0600A9EC RID: 43500 RVA: 0x002D519C File Offset: 0x002D339C
	private void AdviceWordScrollerLateUpdate(float deltaTime)
	{
		if (this.AdviceWordScrollerScrollToDirty && this.AdviceWordFlag >= 1)
		{
			this.AdviceWordScrollerScrollToDirty = false;
			float wordProgress = this.GetWordProgress();
			base.GetScrollViewWithScrollbar(2).SetScrollProgress(wordProgress);
		}
		if (this.AdviceWordFlag >= 2)
		{
			float wordProgress2 = this.GetWordProgress();
			UUIScrollbarComponent scrollScrollbar = base.GetScrollScrollbar(6);
			if (scrollScrollbar != null)
			{
				scrollScrollbar.SetValue(wordProgress2, true);
			}
			this.AdviceWordScroller.UnBindLateUpdate();
		}
		this.AdviceWordFlag++;
	}

	// Token: 0x0600A9ED RID: 43501 RVA: 0x002D5214 File Offset: 0x002D3414
	private float GetWordProgress()
	{
		int num;
		ModelBase<AdviceModel>.Instance.CurrentPreSentenceWordMap.TryGetValue(ModelBase<AdviceModel>.Instance.CurrentSentenceSelectIndex, out num);
		IReadOnlyList<AdviceSentence> adviceSentenceConfigs = ConfigBase<AdviceConfig>.Instance.GetAdviceSentenceConfigs();
		int num2 = 0;
		if (adviceSentenceConfigs == null)
		{
			return 0f;
		}
		for (int i = 0; i < adviceSentenceConfigs.Count; i++)
		{
			if (adviceSentenceConfigs[i].Id == num)
			{
				num2 = i;
				break;
			}
		}
		if (adviceSentenceConfigs.Count > 1)
		{
			return (float)num2 / (float)(adviceSentenceConfigs.Count - 1);
		}
		return 0f;
	}

	// Token: 0x0600A9EE RID: 43502 RVA: 0x002D5296 File Offset: 0x002D3496
	protected override void OnBeforeDestroy()
	{
		GenericScrollView<AdviceSentenceSelectItem> adviceSentenceSelectScroller = this.AdviceSentenceSelectScroller;
		if (adviceSentenceSelectScroller != null)
		{
			adviceSentenceSelectScroller.ClearChildren();
		}
		this.AdviceSentenceSelectScroller = null;
		GenericScrollView<AdviceSentenceSelectItemContent> adviceWordScroller = this.AdviceWordScroller;
		if (adviceWordScroller != null)
		{
			adviceWordScroller.ClearChildren();
		}
		this.AdviceWordScroller = null;
	}

	// Token: 0x04004FEE RID: 20462
	private const int WAITUPDATECOUNT = 1;

	// Token: 0x04004FEF RID: 20463
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollView<AdviceSentenceSelectItem> AdviceSentenceSelectScroller;

	// Token: 0x04004FF0 RID: 20464
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollView<AdviceSentenceSelectItemContent> AdviceWordScroller;

	// Token: 0x04004FF1 RID: 20465
	private bool AdviceWordScrollerScrollToDirty;

	// Token: 0x04004FF2 RID: 20466
	private int AdviceWordFlag;

	// Token: 0x04004FF3 RID: 20467
	private bool AdviceSentenceSelectScrollerScrollToDirty;

	// Token: 0x04004FF4 RID: 20468
	private int AdviceWordTypeFlag;

	// Token: 0x02007AE9 RID: 31465
	[NullableContext(0)]
	private static class EComponents
	{
		// Token: 0x0402A172 RID: 172402
		public const int SortScroller = 0;

		// Token: 0x0402A173 RID: 172403
		public const int SortItem = 1;

		// Token: 0x0402A174 RID: 172404
		public const int WordScroller = 2;

		// Token: 0x0402A175 RID: 172405
		public const int WordItem = 3;

		// Token: 0x0402A176 RID: 172406
		public const int ConfirmBtn = 4;

		// Token: 0x0402A177 RID: 172407
		public const int CancelBtn = 5;

		// Token: 0x0402A178 RID: 172408
		public const int ScrollerBar = 6;

		// Token: 0x0402A179 RID: 172409
		public const int TitleText = 7;
	}
}
