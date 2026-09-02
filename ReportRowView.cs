using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002764 RID: 10084
public class ReportRowView : GridProxyAbstract<ReportPlayerInfo>
{
	// Token: 0x06013E5E RID: 81502 RVA: 0x0058B5E4 File Offset: 0x005897E4
	public override void Refresh(ReportPlayerInfo data, bool isSelected, int gridIndex)
	{
		this.SetData(data);
		this.SetToggleState(isSelected);
	}

	// Token: 0x06013E5F RID: 81503 RVA: 0x0058B5F4 File Offset: 0x005897F4
	public override void OnSelected(bool fireEvent)
	{
		this.ToggleFunction(this.Id);
	}

	// Token: 0x06013E60 RID: 81504 RVA: 0x0058B608 File Offset: 0x00589808
	protected override void OnRegisterComponent()
	{
		base.OnRegisterComponent();
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggle))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.ToggleClick))
		};
	}

	// Token: 0x06013E61 RID: 81505 RVA: 0x0058B675 File Offset: 0x00589875
	protected void ToggleClick(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.ToggleFunction(this.Id);
			return;
		}
		this.ToggleFunction(-1);
	}

	// Token: 0x06013E62 RID: 81506 RVA: 0x0058B69C File Offset: 0x0058989C
	public void SetData(ReportPlayerInfo data)
	{
		this.Id = data.Id;
		UUIText text = base.GetText(0);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.Reason, Array.Empty<object>());
	}

	// Token: 0x06013E63 RID: 81507 RVA: 0x0058B6D5 File Offset: 0x005898D5
	[NullableContext(1)]
	public void SetToggleFunction(Action<int> toggleFunction)
	{
		this.ToggleFunction = toggleFunction;
	}

	// Token: 0x06013E64 RID: 81508 RVA: 0x0058B6DE File Offset: 0x005898DE
	public void SetToggleState(bool isChecked)
	{
		base.GetExtendToggle(1).SetToggleState(isChecked ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, true, false, false);
	}

	// Token: 0x04009ADD RID: 39645
	[Nullable(2)]
	protected Action<int> ToggleFunction;

	// Token: 0x04009ADE RID: 39646
	public int Id;

	// Token: 0x02008B1C RID: 35612
	private static class EReportRowDefine
	{
		// Token: 0x0402EE85 RID: 192133
		public const int Describe = 0;

		// Token: 0x0402EE86 RID: 192134
		public const int Toggle = 1;
	}
}
