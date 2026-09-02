using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Advice;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200178F RID: 6031
public class AdviceWordSelectItem : UiPanelBase
{
	// Token: 0x0600AA3F RID: 43583 RVA: 0x002D6955 File Offset: 0x002D4B55
	[NullableContext(1)]
	public AdviceWordSelectItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600AA40 RID: 43584 RVA: 0x002D696C File Offset: 0x002D4B6C
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
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickItem))
		};
	}

	// Token: 0x0600AA41 RID: 43585 RVA: 0x002D69E9 File Offset: 0x002D4BE9
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnClickAdviceWord, new Action(this.OnClickAdviceWord));
	}

	// Token: 0x0600AA42 RID: 43586 RVA: 0x002D6A07 File Offset: 0x002D4C07
	private void OnClickAdviceWord()
	{
		this.RefreshView();
	}

	// Token: 0x0600AA43 RID: 43587 RVA: 0x002D6A0F File Offset: 0x002D4C0F
	private void OnClickItem(EToggleState state)
	{
		ModelBase<AdviceModel>.Instance.CurrentPreSelectWordId = this.WordId;
		Singleton<EventSystem>.Instance.Emit(EEventName.OnClickAdviceWord);
	}

	// Token: 0x0600AA44 RID: 43588 RVA: 0x002D6A31 File Offset: 0x002D4C31
	public void Update(int wordId, EChangeWordType type)
	{
		this.WordId = wordId;
		this.Type = type;
		this.RefreshView();
		this.RefreshText();
	}

	// Token: 0x0600AA45 RID: 43589 RVA: 0x002D6A50 File Offset: 0x002D4C50
	private void RefreshToggleView()
	{
		EToggleState toggleState = base.GetExtendToggle(0).ToggleState;
		if (this.WordId == ModelBase<AdviceModel>.Instance.CurrentPreSelectWordId)
		{
			if (toggleState != EToggleState.ETT_Checked)
			{
				base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
				return;
			}
		}
		else if (toggleState != EToggleState.ETT_UnChecked)
		{
			base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		}
	}

	// Token: 0x0600AA46 RID: 43590 RVA: 0x002D6AA8 File Offset: 0x002D4CA8
	private void RefreshText()
	{
		if (this.Type == EChangeWordType.Sentence)
		{
			string text = ConfigBase<AdviceConfig>.Instance.GetAdviceSentenceText(this.WordId);
			text = (((text != null) ? text.Replace("{}", "_") : null) ?? "");
			UUIText text2 = base.GetText(1);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(text, true);
			return;
		}
		else
		{
			string adviceConjunctionText = ConfigBase<AdviceConfig>.Instance.GetAdviceConjunctionText(this.WordId);
			UUIText text3 = base.GetText(1);
			if (text3 == null)
			{
				return;
			}
			text3.SetText(adviceConjunctionText ?? "", true);
			return;
		}
	}

	// Token: 0x0600AA47 RID: 43591 RVA: 0x002D6B30 File Offset: 0x002D4D30
	private void RefreshView()
	{
		bool uiactive = this.WordId == ModelBase<AdviceModel>.Instance.CurrentSelectWordId;
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(uiactive);
		}
		this.RefreshToggleView();
	}

	// Token: 0x0600AA48 RID: 43592 RVA: 0x002D6B69 File Offset: 0x002D4D69
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnClickAdviceWord, new Action(this.OnClickAdviceWord));
	}

	// Token: 0x04005007 RID: 20487
	private int WordId;

	// Token: 0x04005008 RID: 20488
	private EChangeWordType Type;

	// Token: 0x02007AF1 RID: 31473
	private static class EChildType
	{
		// Token: 0x0402A198 RID: 172440
		public const int Toggle = 0;

		// Token: 0x0402A199 RID: 172441
		public const int Text = 1;

		// Token: 0x0402A19A RID: 172442
		public const int SelectItem = 2;
	}
}
