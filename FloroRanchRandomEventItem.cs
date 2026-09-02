using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001C69 RID: 7273
public class FloroRanchRandomEventItem : GridProxyAbstract<int>
{
	// Token: 0x0600D446 RID: 54342 RVA: 0x0038A1A0 File Offset: 0x003883A0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D447 RID: 54343 RVA: 0x0038A248 File Offset: 0x00388448
	protected override void OnStart()
	{
		TermExplanationRegistryParam param = new TermExplanationRegistryParam
		{
			UiText = base.GetText(1),
			ViewType = ETermExplanationViewType.Center,
			Style = new ETermExplanationViewStyle?(ETermExplanationViewStyle.FloroRanch),
			ReportType = ETermExplanationReportType.FloroRanch
		};
		ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlinkByParam(param);
	}

	// Token: 0x0600D448 RID: 54344 RVA: 0x0038A290 File Offset: 0x00388490
	public override void Refresh(int choiceId, bool isSelected, int gridIndex)
	{
		this.ChoiceId = choiceId;
		FloroRanchWeeklyChoice? floroRanchWeeklyChoiceById = ConfigBase<FloroRanchConfig>.Instance.GetFloroRanchWeeklyChoiceById(this.ChoiceId);
		if (floroRanchWeeklyChoiceById != null)
		{
			string desc = floroRanchWeeklyChoiceById.Value.Desc;
			if (!string.IsNullOrEmpty(desc))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), desc, floroRanchWeeklyChoiceById.Value.NameParam());
				return;
			}
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			text.SetText(this.ChoiceId.ToString(), true);
			return;
		}
		else
		{
			UUIText text2 = base.GetText(1);
			if (text2 == null)
			{
				return;
			}
			text2.ShowTextNew("Farm_Skip");
			return;
		}
	}

	// Token: 0x0600D449 RID: 54345 RVA: 0x0038A32C File Offset: 0x0038852C
	[NullableContext(1)]
	public void BindClickCallback(Action<int, int> callback)
	{
		this.ClickCallback = callback;
	}

	// Token: 0x0600D44A RID: 54346 RVA: 0x0038A335 File Offset: 0x00388535
	private void OnClickToggle(EToggleState state)
	{
		this.ClickCallback(base.GridIndex, this.ChoiceId);
	}

	// Token: 0x0600D44B RID: 54347 RVA: 0x0038A34E File Offset: 0x0038854E
	public override void OnSelected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x0600D44C RID: 54348 RVA: 0x0038A360 File Offset: 0x00388560
	public override void OnDeselected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600D44D RID: 54349 RVA: 0x0038A372 File Offset: 0x00388572
	protected override void OnBeforeDestroy()
	{
		ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(base.GetText(1));
	}

	// Token: 0x04006504 RID: 25860
	[Nullable(1)]
	private Action<int, int> ClickCallback;

	// Token: 0x04006505 RID: 25861
	private int ChoiceId;

	// Token: 0x02007F91 RID: 32657
	private class EItemComponent
	{
		// Token: 0x0402B6E4 RID: 177892
		public const int Toggle = 0;

		// Token: 0x0402B6E5 RID: 177893
		public const int Desc = 1;
	}
}
