using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.QuickTimeAction.Context;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020026CB RID: 9931
[NullableContext(2)]
[Nullable(0)]
public class QtaCustomizationLimitedHoldItemBar : UiPanelBase
{
	// Token: 0x06013988 RID: 80264 RVA: 0x005781BC File Offset: 0x005763BC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUINiagara));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUINiagara));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06013989 RID: 80265 RVA: 0x00578268 File Offset: 0x00576468
	protected override void OnStart()
	{
		base.OnStart();
		this.SetActive(true);
		this.TexBarA = base.GetTexture(0);
		this.TexBarB = base.GetTexture(1);
		this.FxBarA = base.GetUiNiagara(2);
		this.FxBarB = base.GetUiNiagara(3);
	}

	// Token: 0x0601398A RID: 80266 RVA: 0x005782B8 File Offset: 0x005764B8
	public void SetValid(bool isValid)
	{
		if (this.LastBgValue != null)
		{
			this.SetBgParam(this.LastBgValue);
		}
		if (this.LastBgPercent != null && this.LastBgPercent.Value != 0f)
		{
			this.SetBgPercent(this.LastBgPercent.Value);
		}
	}

	// Token: 0x0601398B RID: 80267 RVA: 0x0057830C File Offset: 0x0057650C
	[NullableContext(1)]
	public void SetBgParam(QtaCzBgBarValue bgValue)
	{
		this.LastBgValue = bgValue;
		this.TmpRotation.Yaw = bgValue.Angle;
		if (this.IsTexMode)
		{
			this.TexBarA.SetUIRelativeRotation(this.TmpRotation);
			this.TexBarA.SetCustomMaterialVectorParameter(this.P1Name, bgValue.Anchor ?? this.TmpAnchor);
			this.TexBarA.SetCustomMaterialScalarParameter(this.P2Name, bgValue.Progress);
			this.TexBarB.SetUIRelativeRotation(this.TmpRotation);
			this.TexBarB.SetCustomMaterialVectorParameter(this.P1Name, bgValue.Anchor ?? this.TmpAnchor);
			this.TexBarB.SetCustomMaterialScalarParameter(this.P2Name, bgValue.Progress);
			return;
		}
		this.FxBarA.SetUIRelativeRotation(this.TmpRotation);
		this.FxBarB.SetUIRelativeRotation(this.TmpRotation);
	}

	// Token: 0x0601398C RID: 80268 RVA: 0x00578410 File Offset: 0x00576610
	public void SetBgPercent(float p)
	{
		this.LastBgPercent = new float?(p);
		if (this.IsTexMode)
		{
			this.TexBarA.SetCustomMaterialScalarParameter(this.P2Name, p);
			this.TexBarB.SetCustomMaterialScalarParameter(this.P2Name, p);
			return;
		}
		this.FxBarA.SetNiagaraVarFloat("Dissolve", p);
		this.FxBarA.ActivateSystem(true);
		this.FxBarB.SetNiagaraVarFloat("Dissolve", p);
		this.FxBarB.ActivateSystem(true);
	}

	// Token: 0x04009888 RID: 39048
	private UUITexture TexBarA;

	// Token: 0x04009889 RID: 39049
	private UUITexture TexBarB;

	// Token: 0x0400988A RID: 39050
	private UUINiagara FxBarA;

	// Token: 0x0400988B RID: 39051
	private UUINiagara FxBarB;

	// Token: 0x0400988C RID: 39052
	private bool IsTexMode;

	// Token: 0x0400988D RID: 39053
	private readonly FName P1Name = new FName("Anchor");

	// Token: 0x0400988E RID: 39054
	private readonly FName P2Name = new FName("Progress");

	// Token: 0x0400988F RID: 39055
	private FRotator TmpRotation = new FRotator();

	// Token: 0x04009890 RID: 39056
	private FLinearColor TmpAnchor = new FLinearColor(0f, 0.25f, 0.5f, 0.75f);

	// Token: 0x04009891 RID: 39057
	private QtaCzBgBarValue LastBgValue;

	// Token: 0x04009892 RID: 39058
	private float? LastBgPercent;

	// Token: 0x02008A84 RID: 35460
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402EB90 RID: 191376
		public const int TexBarA = 0;

		// Token: 0x0402EB91 RID: 191377
		public const int TexBarB = 1;

		// Token: 0x0402EB92 RID: 191378
		public const int FxBarA = 2;

		// Token: 0x0402EB93 RID: 191379
		public const int FxBarB = 3;
	}
}
