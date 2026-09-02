using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E82 RID: 7810
[NullableContext(2)]
[Nullable(0)]
public class HandBookQuestPlotTalkItem : UiPanelBase
{
	// Token: 0x0600E6E3 RID: 59107 RVA: 0x003E4F40 File Offset: 0x003E3140
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIExtendToggle))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.OnPlayToggleClick))
		};
	}

	// Token: 0x0600E6E4 RID: 59108 RVA: 0x003E4FD4 File Offset: 0x003E31D4
	private void OnPlayToggleClick(EToggleState state)
	{
		if (this.PlotAudio == null)
		{
			return;
		}
		if (!this.IsPlayingAudio)
		{
			HandBookQuestPlotTalkAudioUtil.PlayAudio(this.PlotAudio.Value, new Action<string>(this.OnAudioPlayEnd));
		}
		else
		{
			HandBookQuestPlotTalkAudioUtil.ClearCurPlayAudio();
		}
		this.IsPlayingAudio = !this.IsPlayingAudio;
	}

	// Token: 0x0600E6E5 RID: 59109 RVA: 0x003E502C File Offset: 0x003E322C
	public void Refresh(string nameText, string constantText, PlotAudio? audio)
	{
		this.PlotAudio = audio;
		UUIText text = base.GetText(0);
		if (text != null)
		{
			text.SetText(nameText ?? "", true);
		}
		string text2 = ModelBase<PlotModel>.Instance.PlotTextReplacer.Replace(constantText, false);
		UUIText text3 = base.GetText(1);
		if (text3 != null)
		{
			text3.SetText(text2 ?? "", true);
		}
		bool havePlot = (this.PlotAudio != null) > false;
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(havePlot);
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(3);
		if (extendToggle != null)
		{
			extendToggle.CanExecuteChange.Bind(() => havePlot);
		}
		this.IsPlayingAudio = (havePlot && HandBookQuestPlotTalkAudioUtil.IsPlayingAudio((this.PlotAudio != null) ? this.PlotAudio.GetValueOrDefault().Id : null));
		if (this.IsPlayingAudio)
		{
			HandBookQuestPlotTalkAudioUtil.ResetPlayEndCallBack(new Action<string>(this.OnAudioPlayEnd));
		}
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(this.IsPlayingAudio ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600E6E6 RID: 59110 RVA: 0x003E514C File Offset: 0x003E334C
	private void OnAudioPlayEnd(string nextPlayingAudio = null)
	{
		if (nextPlayingAudio != null && nextPlayingAudio == ((this.PlotAudio != null) ? this.PlotAudio.GetValueOrDefault().Id : null))
		{
			return;
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(3);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.IsPlayingAudio = false;
	}

	// Token: 0x04006F5C RID: 28508
	private bool IsPlayingAudio;

	// Token: 0x04006F5D RID: 28509
	private PlotAudio? PlotAudio;
}
