using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200178A RID: 6026
public class AdviceSentenceSelectItem : UiPanelBase
{
	// Token: 0x0600AA02 RID: 43522 RVA: 0x002D581A File Offset: 0x002D3A1A
	[NullableContext(1)]
	public AdviceSentenceSelectItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600AA03 RID: 43523 RVA: 0x002D5830 File Offset: 0x002D3A30
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
	}

	// Token: 0x0600AA04 RID: 43524 RVA: 0x002D58CC File Offset: 0x002D3ACC
	protected override void OnStart()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.CanExecuteChange.Unbind();
			extendToggle.CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
		}
	}

	// Token: 0x0600AA05 RID: 43525 RVA: 0x002D5908 File Offset: 0x002D3B08
	private bool CanExecuteChange()
	{
		int currentSentenceSelectIndex = ModelBase<AdviceModel>.Instance.CurrentSentenceSelectIndex;
		int? sortType = this.SortType;
		return !(currentSentenceSelectIndex == sortType.GetValueOrDefault() & sortType != null);
	}

	// Token: 0x0600AA06 RID: 43526 RVA: 0x002D593C File Offset: 0x002D3B3C
	public void UpdateItem(int id)
	{
		base.GetExtendToggle(0).OnStateChange.Clear();
		base.GetExtendToggle(0).OnStateChange.Add(new Action<EToggleState>(this.ButtonClick));
		this.SortType = new int?(id);
		this.RefreshView();
		this.RefreshShowInfo();
	}

	// Token: 0x0600AA07 RID: 43527 RVA: 0x002D5990 File Offset: 0x002D3B90
	private void RefreshView()
	{
		EToggleState toggleState = base.GetExtendToggle(0).ToggleState;
		int currentSentenceSelectIndex = ModelBase<AdviceModel>.Instance.CurrentSentenceSelectIndex;
		int? sortType = this.SortType;
		EToggleState etoggleState = (!(currentSentenceSelectIndex == sortType.GetValueOrDefault() & sortType != null)) ? EToggleState.ETT_UnChecked : EToggleState.ETT_Checked;
		if (toggleState != etoggleState)
		{
			base.GetExtendToggle(0).SetToggleStateForce(etoggleState, false, false, false);
		}
	}

	// Token: 0x0600AA08 RID: 43528 RVA: 0x002D59E8 File Offset: 0x002D3BE8
	private void RefreshShowInfo()
	{
		int? sortType = this.SortType;
		int num = 0;
		string textTableId = (sortType.GetValueOrDefault() == num & sortType != null) ? "AdviceFirstSentence" : "AdviceSecondSentence";
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(4), textTableId, Array.Empty<object>());
	}

	// Token: 0x0600AA09 RID: 43529 RVA: 0x002D5A38 File Offset: 0x002D3C38
	private void ButtonClick(EToggleState state)
	{
		int currentSentenceSelectIndex = ModelBase<AdviceModel>.Instance.CurrentSentenceSelectIndex;
		int? sortType = this.SortType;
		if (!(currentSentenceSelectIndex == sortType.GetValueOrDefault() & sortType != null) && this.SortType != null)
		{
			ModelBase<AdviceModel>.Instance.CurrentSentenceSelectIndex = this.SortType.Value;
			Singleton<EventSystem>.Instance.Emit(EEventName.OnClickAdviceSort);
		}
	}

	// Token: 0x04004FF8 RID: 20472
	private int? SortType;

	// Token: 0x02007AEC RID: 31468
	private static class EAdviceWordTypeItemComponents
	{
		// Token: 0x0402A180 RID: 172416
		public const int Toggle = 0;

		// Token: 0x0402A181 RID: 172417
		public const int Texture = 1;

		// Token: 0x0402A182 RID: 172418
		public const int NotFoundActor = 2;

		// Token: 0x0402A183 RID: 172419
		public const int TextLv = 3;

		// Token: 0x0402A184 RID: 172420
		public const int TextName = 4;

		// Token: 0x0402A185 RID: 172421
		public const int CopyType = 5;
	}
}
