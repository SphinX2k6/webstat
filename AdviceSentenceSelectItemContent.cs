using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Advice;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200178B RID: 6027
public class AdviceSentenceSelectItemContent : UiPanelBase
{
	// Token: 0x0600AA0A RID: 43530 RVA: 0x002D5A9B File Offset: 0x002D3C9B
	[NullableContext(1)]
	public AdviceSentenceSelectItemContent(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600AA0B RID: 43531 RVA: 0x002D5AB0 File Offset: 0x002D3CB0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.ButtonClick))
		};
	}

	// Token: 0x0600AA0C RID: 43532 RVA: 0x002D5B30 File Offset: 0x002D3D30
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnClickAdviceSortWord, new Action(this.OnClickAdviceSortWord));
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.CanExecuteChange.Unbind();
			extendToggle.CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
		}
	}

	// Token: 0x0600AA0D RID: 43533 RVA: 0x002D5B86 File Offset: 0x002D3D86
	private void OnClickAdviceSortWord()
	{
		this.RefreshView();
		this.RefreshToggleView();
	}

	// Token: 0x0600AA0E RID: 43534 RVA: 0x002D5B94 File Offset: 0x002D3D94
	private bool CanExecuteChange()
	{
		return ModelBase<AdviceModel>.Instance.PreSelectSortWordId != this.WordId;
	}

	// Token: 0x0600AA0F RID: 43535 RVA: 0x002D5BAB File Offset: 0x002D3DAB
	public void UpdateItem(int wordId)
	{
		this.WordId = wordId;
		this.RefreshView();
		this.RefreshShowInfo();
		this.RefreshToggleView();
	}

	// Token: 0x0600AA10 RID: 43536 RVA: 0x002D5BC8 File Offset: 0x002D3DC8
	private void RefreshView()
	{
		int num;
		ModelBase<AdviceModel>.Instance.CurrentPreSentenceWordMap.TryGetValue(ModelBase<AdviceModel>.Instance.CurrentSentenceSelectIndex, out num);
		bool uiactive = num == this.WordId;
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(uiactive);
	}

	// Token: 0x0600AA11 RID: 43537 RVA: 0x002D5C10 File Offset: 0x002D3E10
	private void RefreshShowInfo()
	{
		string text = ConfigBase<AdviceConfig>.Instance.GetAdviceSentenceText(this.WordId);
		text = (((text != null) ? text.Replace("{}", "_") : null) ?? "");
		UUIText text2 = base.GetText(1);
		if (text2 == null)
		{
			return;
		}
		text2.SetText(text, true);
	}

	// Token: 0x0600AA12 RID: 43538 RVA: 0x002D5C64 File Offset: 0x002D3E64
	private void ButtonClick(EToggleState state)
	{
		int num;
		ModelBase<AdviceModel>.Instance.CurrentPreSentenceWordMap.TryGetValue(ModelBase<AdviceModel>.Instance.CurrentSentenceSelectIndex, out num);
		if (num != this.WordId)
		{
			ModelBase<AdviceModel>.Instance.CurrentPreSentenceWordMap[ModelBase<AdviceModel>.Instance.CurrentSentenceSelectIndex] = this.WordId;
			Singleton<EventSystem>.Instance.Emit(EEventName.OnClickAdviceSortWord);
		}
	}

	// Token: 0x0600AA13 RID: 43539 RVA: 0x002D5CC8 File Offset: 0x002D3EC8
	private void RefreshToggleView()
	{
		EToggleState toggleState = base.GetExtendToggle(0).ToggleState;
		int num;
		ModelBase<AdviceModel>.Instance.CurrentPreSentenceWordMap.TryGetValue(ModelBase<AdviceModel>.Instance.CurrentSentenceSelectIndex, out num);
		EToggleState etoggleState = (this.WordId == num) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		if (toggleState != etoggleState)
		{
			base.GetExtendToggle(0).SetToggleStateForce(etoggleState, false, false, false);
		}
	}

	// Token: 0x0600AA14 RID: 43540 RVA: 0x002D5D1E File Offset: 0x002D3F1E
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnClickAdviceSortWord, new Action(this.OnClickAdviceSortWord));
	}

	// Token: 0x04004FF9 RID: 20473
	private int WordId;

	// Token: 0x02007AED RID: 31469
	private static class EAdviceSentenceSelectItemContentComponents
	{
		// Token: 0x0402A186 RID: 172422
		public const int Toggle = 0;

		// Token: 0x0402A187 RID: 172423
		public const int Text = 1;

		// Token: 0x0402A188 RID: 172424
		public const int SelectItem = 2;
	}
}
