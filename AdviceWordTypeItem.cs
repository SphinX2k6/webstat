using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Advice;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001792 RID: 6034
public class AdviceWordTypeItem : UiPanelBase
{
	// Token: 0x0600AA55 RID: 43605 RVA: 0x002D6F83 File Offset: 0x002D5183
	[NullableContext(1)]
	public AdviceWordTypeItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600AA56 RID: 43606 RVA: 0x002D6F98 File Offset: 0x002D5198
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

	// Token: 0x0600AA57 RID: 43607 RVA: 0x002D7034 File Offset: 0x002D5234
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnClickAdviceSort, new Action(this.RefreshAdviceSort));
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.CanExecuteChange.Unbind();
			extendToggle.CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
		}
	}

	// Token: 0x0600AA58 RID: 43608 RVA: 0x002D708A File Offset: 0x002D528A
	private void RefreshAdviceSort()
	{
		this.RefreshView();
	}

	// Token: 0x0600AA59 RID: 43609 RVA: 0x002D7092 File Offset: 0x002D5292
	private bool CanExecuteChange()
	{
		return ModelBase<AdviceModel>.Instance.PreSelectSortTypeId != this.SortType;
	}

	// Token: 0x0600AA5A RID: 43610 RVA: 0x002D70AC File Offset: 0x002D52AC
	public void UpdateItem(int id)
	{
		base.GetExtendToggle(0).OnStateChange.Clear();
		base.GetExtendToggle(0).OnStateChange.Add(new Action<EToggleState>(this.ButtonClick));
		this.SortType = id;
		this.RefreshView();
		this.RefreshShowInfo();
	}

	// Token: 0x0600AA5B RID: 43611 RVA: 0x002D70FC File Offset: 0x002D52FC
	private void RefreshView()
	{
		EToggleState toggleState = base.GetExtendToggle(0).ToggleState;
		EToggleState etoggleState = (ModelBase<AdviceModel>.Instance.PreSelectSortTypeId != this.SortType) ? EToggleState.ETT_UnChecked : EToggleState.ETT_Checked;
		if (toggleState != etoggleState)
		{
			base.GetExtendToggle(0).SetToggleStateForce(etoggleState, false, false, false);
		}
	}

	// Token: 0x0600AA5C RID: 43612 RVA: 0x002D7140 File Offset: 0x002D5340
	private void RefreshShowInfo()
	{
		string adviceTypeText = ConfigBase<AdviceConfig>.Instance.GetAdviceTypeText(this.SortType);
		UUIText text = base.GetText(4);
		if (text == null)
		{
			return;
		}
		text.SetText(adviceTypeText ?? "", true);
	}

	// Token: 0x0600AA5D RID: 43613 RVA: 0x002D717A File Offset: 0x002D537A
	private void ButtonClick(EToggleState state)
	{
		if (ModelBase<AdviceModel>.Instance.PreSelectSortTypeId != this.SortType)
		{
			ModelBase<AdviceModel>.Instance.PreSelectSortTypeId = this.SortType;
			Singleton<EventSystem>.Instance.Emit(EEventName.OnClickAdviceSort);
		}
	}

	// Token: 0x0600AA5E RID: 43614 RVA: 0x002D71AE File Offset: 0x002D53AE
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnClickAdviceSort, new Action(this.RefreshAdviceSort));
	}

	// Token: 0x04005011 RID: 20497
	private int SortType;

	// Token: 0x02007AF3 RID: 31475
	private static class EAdviceWordTypeItemComponents
	{
		// Token: 0x0402A1A0 RID: 172448
		public const int Toggle = 0;

		// Token: 0x0402A1A1 RID: 172449
		public const int Texture = 1;

		// Token: 0x0402A1A2 RID: 172450
		public const int NotFoundActor = 2;

		// Token: 0x0402A1A3 RID: 172451
		public const int TextLv = 3;

		// Token: 0x0402A1A4 RID: 172452
		public const int TextName = 4;

		// Token: 0x0402A1A5 RID: 172453
		public const int CopyType = 5;
	}
}
