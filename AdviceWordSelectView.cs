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

// Token: 0x02001791 RID: 6033
[NullableContext(1)]
[Nullable(0)]
public class AdviceWordSelectView : UiViewBase
{
	// Token: 0x0600AA49 RID: 43593 RVA: 0x002D6B87 File Offset: 0x002D4D87
	public AdviceWordSelectView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600AA4A RID: 43594 RVA: 0x002D6B9C File Offset: 0x002D4D9C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickCancelBtn)),
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickConfirmBtn))
		};
	}

	// Token: 0x0600AA4B RID: 43595 RVA: 0x002D6C5D File Offset: 0x002D4E5D
	protected override void OnStart()
	{
		this.ScrollView = new GenericScrollView<AdviceWordSelectItem>(base.GetScrollViewWithScrollbar(0), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<AdviceWordSelectItem>(this.InitItem), null);
	}

	// Token: 0x0600AA4C RID: 43596 RVA: 0x002D6C80 File Offset: 0x002D4E80
	private ILayoutItem<AdviceWordSelectItem> InitItem(object wordIndex, UUIItem uiItem, int index)
	{
		AdviceWordSelectItem adviceWordSelectItem = new AdviceWordSelectItem(uiItem);
		adviceWordSelectItem.Update((int)wordIndex, ModelBase<AdviceModel>.Instance.CurrentChangeWordType);
		return new LayoutItem<AdviceWordSelectItem>
		{
			Key = index,
			Value = adviceWordSelectItem
		};
	}

	// Token: 0x0600AA4D RID: 43597 RVA: 0x002D6CC4 File Offset: 0x002D4EC4
	private void OnClickConfirmBtn()
	{
		if (ModelBase<AdviceModel>.Instance.CurrentChangeWordType == EChangeWordType.Sentence)
		{
			int currentPreSelectWordId = ModelBase<AdviceModel>.Instance.CurrentPreSelectWordId;
			int currentPreSelectSentenceIndex = ModelBase<AdviceModel>.Instance.CurrentPreSelectSentenceIndex;
			ModelBase<AdviceModel>.Instance.CurrentSentenceWordMap[currentPreSelectSentenceIndex] = currentPreSelectWordId;
			ModelBase<AdviceModel>.Instance.OnChangeSentence(currentPreSelectSentenceIndex);
		}
		else
		{
			ModelBase<AdviceModel>.Instance.CurrentConjunctionId = ModelBase<AdviceModel>.Instance.CurrentPreSelectWordId;
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnChangeAdviceWord);
		base.CloseMe(null);
	}

	// Token: 0x0600AA4E RID: 43598 RVA: 0x002D6D3C File Offset: 0x002D4F3C
	private void OnClickCancelBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600AA4F RID: 43599 RVA: 0x002D6D45 File Offset: 0x002D4F45
	protected override void OnAfterShow()
	{
		ModelBase<AdviceModel>.Instance.CurrentPreSelectWordId = ModelBase<AdviceModel>.Instance.CurrentSelectWordId;
		this.RefreshScroller();
		this.RefreshTitle();
	}

	// Token: 0x0600AA50 RID: 43600 RVA: 0x002D6D68 File Offset: 0x002D4F68
	private void RefreshTitle()
	{
		if (ModelBase<AdviceModel>.Instance.CurrentChangeWordType == EChangeWordType.Sentence)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(4), "AdvicePutSentence", Array.Empty<object>());
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(4), "AdvicePutWord", Array.Empty<object>());
	}

	// Token: 0x0600AA51 RID: 43601 RVA: 0x002D6DB8 File Offset: 0x002D4FB8
	private void RefreshScroller()
	{
		bool currentChangeWordType = ModelBase<AdviceModel>.Instance.CurrentChangeWordType != EChangeWordType.Sentence;
		List<int> list = new List<int>();
		if (!currentChangeWordType)
		{
			IReadOnlyList<AdviceSentence> adviceSentenceConfigs = ConfigBase<AdviceConfig>.Instance.GetAdviceSentenceConfigs();
			if (adviceSentenceConfigs == null)
			{
				goto IL_99;
			}
			using (IEnumerator<AdviceSentence> enumerator = adviceSentenceConfigs.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					AdviceSentence adviceSentence = enumerator.Current;
					list.Add(adviceSentence.Id);
				}
				goto IL_99;
			}
		}
		IReadOnlyList<AdviceConjunction> adviceConjunctionConfigs = ConfigBase<AdviceConfig>.Instance.GetAdviceConjunctionConfigs();
		if (adviceConjunctionConfigs != null)
		{
			foreach (AdviceConjunction adviceConjunction in adviceConjunctionConfigs)
			{
				list.Add(adviceConjunction.Id);
			}
		}
		IL_99:
		this.CurrentIds = list;
		this.ScrollView.RefreshByData<int>(this.CurrentIds, null);
		this.ScrollView.UnBindLateUpdate();
		this.ScrollToDirty = true;
		this.WaitingLateUpdateFlag = 0;
		this.ScrollView.BindLateUpdate(new Action<float>(this.LateUpdate));
	}

	// Token: 0x0600AA52 RID: 43602 RVA: 0x002D6ECC File Offset: 0x002D50CC
	private void LateUpdate(float deltaTime)
	{
		if (this.ScrollToDirty && this.WaitingLateUpdateFlag >= 1)
		{
			this.ScrollToDirty = false;
			float progress = this.GetProgress(this.CurrentIds.ToArray());
			base.GetScrollViewWithScrollbar(0).SetScrollProgress(progress);
			this.ScrollView.UnBindLateUpdate();
		}
		this.WaitingLateUpdateFlag++;
	}

	// Token: 0x0600AA53 RID: 43603 RVA: 0x002D6F2C File Offset: 0x002D512C
	private float GetProgress(int[] numbers)
	{
		int num = 0;
		for (int i = 0; i < numbers.Length; i++)
		{
			if (ModelBase<AdviceModel>.Instance.CurrentSelectWordId == numbers[i])
			{
				num = i;
				break;
			}
		}
		if (numbers.Length > 1)
		{
			return (float)num / (float)(numbers.Length - 1);
		}
		return 0f;
	}

	// Token: 0x0600AA54 RID: 43604 RVA: 0x002D6F71 File Offset: 0x002D5171
	protected override void OnBeforeDestroy()
	{
		GenericScrollView<AdviceWordSelectItem> scrollView = this.ScrollView;
		if (scrollView == null)
		{
			return;
		}
		scrollView.ClearChildren();
	}

	// Token: 0x0400500C RID: 20492
	private const int WAITUPDATECOUNT = 1;

	// Token: 0x0400500D RID: 20493
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollView<AdviceWordSelectItem> ScrollView;

	// Token: 0x0400500E RID: 20494
	private bool ScrollToDirty;

	// Token: 0x0400500F RID: 20495
	private int WaitingLateUpdateFlag;

	// Token: 0x04005010 RID: 20496
	private List<int> CurrentIds = new List<int>();

	// Token: 0x02007AF2 RID: 31474
	[NullableContext(0)]
	private static class EComponents
	{
		// Token: 0x0402A19B RID: 172443
		public const int WordScroller = 0;

		// Token: 0x0402A19C RID: 172444
		public const int WordItem = 1;

		// Token: 0x0402A19D RID: 172445
		public const int ConfirmBtn = 2;

		// Token: 0x0402A19E RID: 172446
		public const int CancelBtn = 3;

		// Token: 0x0402A19F RID: 172447
		public const int TitleText = 4;
	}
}
