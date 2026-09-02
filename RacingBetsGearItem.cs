using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002720 RID: 10016
public class RacingBetsGearItem : GridProxyAbstract<RacingBettingGear>
{
	// Token: 0x06013C17 RID: 80919 RVA: 0x0057F764 File Offset: 0x0057D964
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x06013C18 RID: 80920 RVA: 0x0057F7E1 File Offset: 0x0057D9E1
	protected override void OnStart()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.CanExecuteChange.Bind(new Func<bool>(this.CanToggleExecuteChange));
	}

	// Token: 0x06013C19 RID: 80921 RVA: 0x0057F808 File Offset: 0x0057DA08
	public override void Refresh(RacingBettingGear data, bool isSelected, int gridIndex)
	{
		this.Config = data;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>(data.Odds);
		defaultInterpolatedStringHandler.AppendLiteral("%");
		string newText = defaultInterpolatedStringHandler.ToStringAndClear();
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.SetText(newText, true);
		}
		UUIText text2 = base.GetText(2);
		if (text2 != null)
		{
			text2.SetText(newText, true);
		}
		this.RefreshSelect(isSelected);
	}

	// Token: 0x06013C1A RID: 80922 RVA: 0x0057F876 File Offset: 0x0057DA76
	public override void OnSelected(bool fireEvent)
	{
		this.RefreshSelect(true);
	}

	// Token: 0x06013C1B RID: 80923 RVA: 0x0057F87F File Offset: 0x0057DA7F
	public override void OnDeselected(bool fireEvent)
	{
		this.RefreshSelect(false);
	}

	// Token: 0x06013C1C RID: 80924 RVA: 0x0057F888 File Offset: 0x0057DA88
	private void RefreshSelect(bool isSelected)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06013C1D RID: 80925 RVA: 0x0057F8A5 File Offset: 0x0057DAA5
	[NullableContext(1)]
	public void BindClickGearItemCallBack(Action<RacingBettingGear> clickGearItemCallBack)
	{
		this.ClickGearItemCallBack = clickGearItemCallBack;
	}

	// Token: 0x06013C1E RID: 80926 RVA: 0x0057F8AE File Offset: 0x0057DAAE
	private void OnClickToggle(EToggleState toggleState)
	{
		Action<RacingBettingGear> clickGearItemCallBack = this.ClickGearItemCallBack;
		if (clickGearItemCallBack == null)
		{
			return;
		}
		clickGearItemCallBack(this.Config);
	}

	// Token: 0x06013C1F RID: 80927 RVA: 0x0057F8C6 File Offset: 0x0057DAC6
	private bool CanToggleExecuteChange()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		return extendToggle == null || extendToggle.GetToggleState() != EToggleState.ETT_Checked;
	}

	// Token: 0x040099E0 RID: 39392
	private RacingBettingGear Config;

	// Token: 0x040099E1 RID: 39393
	[Nullable(2)]
	private Action<RacingBettingGear> ClickGearItemCallBack;

	// Token: 0x02008AC7 RID: 35527
	private class EComponent
	{
		// Token: 0x0402ECA2 RID: 191650
		public const int Toggle = 0;

		// Token: 0x0402ECA3 RID: 191651
		public const int PercentNormalText = 1;

		// Token: 0x0402ECA4 RID: 191652
		public const int PercentSelectText = 2;
	}
}
