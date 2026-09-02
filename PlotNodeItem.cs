using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E7E RID: 7806
[NullableContext(1)]
[Nullable(0)]
public class PlotNodeItem : UiPanelBase
{
	// Token: 0x0600E6CD RID: 59085 RVA: 0x003E4A58 File Offset: 0x003E2C58
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
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickExtendToggle))
		};
	}

	// Token: 0x0600E6CE RID: 59086 RVA: 0x003E4AD5 File Offset: 0x003E2CD5
	protected override void OnStart()
	{
		this.ExtendToggle = base.GetExtendToggle(0);
		this.ExtendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600E6CF RID: 59087 RVA: 0x003E4AF4 File Offset: 0x003E2CF4
	private void OnClickExtendToggle(EToggleState state)
	{
		if (state != EToggleState.ETT_Checked)
		{
			return;
		}
		if (this.OnCallBack != null)
		{
			this.OnCallBack(this.TidText, this.ExtendToggle);
		}
	}

	// Token: 0x0600E6D0 RID: 59088 RVA: 0x003E4B1A File Offset: 0x003E2D1A
	public void BindClickCallback(TSelectedCallback onClickCallback)
	{
		this.OnCallBack = onClickCallback;
	}

	// Token: 0x0600E6D1 RID: 59089 RVA: 0x003E4B24 File Offset: 0x003E2D24
	public void Update(string data, bool isSelect)
	{
		this.TidText = data;
		string newText = Singleton<PublicUtil>.Instance.GetConfigTextByKey(data).Replace("{q_count}", "0").Replace("{q_countMax}", "-");
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.SetText(newText, true);
		}
		UUIExtendToggle extendToggle = this.ExtendToggle;
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(isSelect ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600E6D2 RID: 59090 RVA: 0x003E4B90 File Offset: 0x003E2D90
	public string GetTidText()
	{
		return this.TidText;
	}

	// Token: 0x0600E6D3 RID: 59091 RVA: 0x003E4B98 File Offset: 0x003E2D98
	public void SetToggleState(EToggleState state)
	{
		UUIExtendToggle extendToggle = this.ExtendToggle;
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(state, false, false, false);
	}

	// Token: 0x0600E6D4 RID: 59092 RVA: 0x003E4BAE File Offset: 0x003E2DAE
	public UUIExtendToggle GetNodeToggle()
	{
		return this.ExtendToggle;
	}

	// Token: 0x04006F4A RID: 28490
	[Nullable(2)]
	private TSelectedCallback OnCallBack;

	// Token: 0x04006F4B RID: 28491
	[Nullable(2)]
	private UUIExtendToggle ExtendToggle;

	// Token: 0x04006F4C RID: 28492
	private string TidText = "";
}
