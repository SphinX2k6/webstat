using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E85 RID: 7813
[NullableContext(1)]
[Nullable(0)]
public class HandBookQuestPlotOption : UiPanelBase
{
	// Token: 0x0600E6ED RID: 59117 RVA: 0x003E51B4 File Offset: 0x003E33B4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x0600E6EE RID: 59118 RVA: 0x003E5224 File Offset: 0x003E3424
	protected override void OnStart()
	{
		this.Toggle = base.GetExtendToggle(1);
		UUIExtendToggle toggle = this.Toggle;
		if (toggle == null)
		{
			return;
		}
		toggle.OnStateChange.Add(new Action<EToggleState>(this.OnToggleClick));
	}

	// Token: 0x0600E6EF RID: 59119 RVA: 0x003E5254 File Offset: 0x003E3454
	public void RefreshByOption(ITalkOption option, int plotId, int talkItemId, int index, bool isChoseOption)
	{
		this.PlotId = plotId;
		this.TalkItemId = talkItemId;
		this.OptionIndex = index;
		string flowConfigLocalText = Singleton<PublicUtil>.Instance.GetFlowConfigLocalText(option.TidTalkOption);
		string newText = ModelBase<PlotModel>.Instance.PlotTextReplacer.Replace(flowConfigLocalText, false);
		UUIText text = base.GetText(0);
		if (text != null)
		{
			text.SetText(newText, true);
		}
		this.SetToggleState(isChoseOption ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked);
		this.SelectShow(isChoseOption);
	}

	// Token: 0x0600E6F0 RID: 59120 RVA: 0x003E52C4 File Offset: 0x003E34C4
	public void SetToggleState(EToggleState state)
	{
		UUIExtendToggle toggle = this.Toggle;
		if (toggle == null)
		{
			return;
		}
		toggle.SetToggleStateForce(state, false, false, false);
	}

	// Token: 0x0600E6F1 RID: 59121 RVA: 0x003E52DC File Offset: 0x003E34DC
	public void SelectShow(bool isSelect)
	{
		if (isSelect)
		{
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.SetColor(this.HandBookDefine.selectColor);
			}
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetAlpha(1f);
			}
			UUIItem item2 = base.GetItem(3);
			if (item2 == null)
			{
				return;
			}
			item2.SetAlpha(1f);
			return;
		}
		else
		{
			UUIText text2 = base.GetText(0);
			if (text2 != null)
			{
				text2.SetColor(this.HandBookDefine.noSelectColor);
			}
			UUIItem item3 = base.GetItem(2);
			if (item3 != null)
			{
				item3.SetAlpha(0f);
			}
			UUIItem item4 = base.GetItem(3);
			if (item4 == null)
			{
				return;
			}
			item4.SetAlpha(0f);
			return;
		}
	}

	// Token: 0x0600E6F2 RID: 59122 RVA: 0x003E5381 File Offset: 0x003E3581
	public void BindClickToggleBack(TSelectedOpenCallback onClickToggle)
	{
		this.OnClickToggleBack = onClickToggle;
	}

	// Token: 0x0600E6F3 RID: 59123 RVA: 0x003E538A File Offset: 0x003E358A
	private void OnToggleClick(EToggleState state)
	{
		if (this.OnClickToggleBack != null && state == EToggleState.ETT_Checked)
		{
			this.OnClickToggleBack(this.PlotId, this.TalkItemId, this.OptionIndex, this.Toggle);
		}
	}

	// Token: 0x04006F62 RID: 28514
	[Nullable(2)]
	public UUIExtendToggle Toggle;

	// Token: 0x04006F63 RID: 28515
	private int TalkItemId = -1;

	// Token: 0x04006F64 RID: 28516
	private int PlotId = -1;

	// Token: 0x04006F65 RID: 28517
	private int OptionIndex;

	// Token: 0x04006F66 RID: 28518
	[Nullable(2)]
	private TSelectedOpenCallback OnClickToggleBack;

	// Token: 0x04006F67 RID: 28519
	private HandBookDefine HandBookDefine = new HandBookDefine();
}
