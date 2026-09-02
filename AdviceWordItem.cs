using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Advice;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200178E RID: 6030
public class AdviceWordItem : UiPanelBase
{
	// Token: 0x0600AA34 RID: 43572 RVA: 0x002D6720 File Offset: 0x002D4920
	[NullableContext(1)]
	public AdviceWordItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600AA35 RID: 43573 RVA: 0x002D6738 File Offset: 0x002D4938
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

	// Token: 0x0600AA36 RID: 43574 RVA: 0x002D67B8 File Offset: 0x002D49B8
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

	// Token: 0x0600AA37 RID: 43575 RVA: 0x002D680E File Offset: 0x002D4A0E
	private void OnClickAdviceSortWord()
	{
		this.RefreshView();
		this.RefreshToggleView();
	}

	// Token: 0x0600AA38 RID: 43576 RVA: 0x002D681C File Offset: 0x002D4A1C
	private bool CanExecuteChange()
	{
		return ModelBase<AdviceModel>.Instance.PreSelectSortWordId != this.WordId;
	}

	// Token: 0x0600AA39 RID: 43577 RVA: 0x002D6833 File Offset: 0x002D4A33
	public void UpdateItem(int wordId)
	{
		this.WordId = wordId;
		this.RefreshView();
		this.RefreshShowInfo();
		this.RefreshToggleView();
	}

	// Token: 0x0600AA3A RID: 43578 RVA: 0x002D6850 File Offset: 0x002D4A50
	private void RefreshView()
	{
		bool uiactive = ModelBase<AdviceModel>.Instance.CurrentSelectSortWordId == this.WordId;
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(uiactive);
	}

	// Token: 0x0600AA3B RID: 43579 RVA: 0x002D6884 File Offset: 0x002D4A84
	private void RefreshShowInfo()
	{
		string adviceWordText = ConfigBase<AdviceConfig>.Instance.GetAdviceWordText(this.WordId);
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetText(adviceWordText ?? "", true);
	}

	// Token: 0x0600AA3C RID: 43580 RVA: 0x002D68BE File Offset: 0x002D4ABE
	private void ButtonClick(EToggleState state)
	{
		if (ModelBase<AdviceModel>.Instance.PreSelectSortWordId != this.WordId)
		{
			ModelBase<AdviceModel>.Instance.PreSelectSortWordId = this.WordId;
			Singleton<EventSystem>.Instance.Emit(EEventName.OnClickAdviceSortWord);
		}
	}

	// Token: 0x0600AA3D RID: 43581 RVA: 0x002D68F4 File Offset: 0x002D4AF4
	private void RefreshToggleView()
	{
		EToggleState toggleState = base.GetExtendToggle(0).ToggleState;
		EToggleState etoggleState = (this.WordId == ModelBase<AdviceModel>.Instance.PreSelectSortWordId) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		if (toggleState != etoggleState)
		{
			base.GetExtendToggle(0).SetToggleStateForce(etoggleState, false, false, false);
		}
	}

	// Token: 0x0600AA3E RID: 43582 RVA: 0x002D6937 File Offset: 0x002D4B37
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnClickAdviceSortWord, new Action(this.OnClickAdviceSortWord));
	}

	// Token: 0x04005006 RID: 20486
	private int WordId;

	// Token: 0x02007AF0 RID: 31472
	private static class EAdviceWordItemComponents
	{
		// Token: 0x0402A195 RID: 172437
		public const int Toggle = 0;

		// Token: 0x0402A196 RID: 172438
		public const int Text = 1;

		// Token: 0x0402A197 RID: 172439
		public const int SelectItem = 2;
	}
}
