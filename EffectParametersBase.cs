using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200341E RID: 13342
[NullableContext(1)]
[Nullable(0)]
public class EffectParametersBase
{
	// Token: 0x0601BD73 RID: 114035 RVA: 0x0084D5D8 File Offset: 0x0084B7D8
	public virtual void CollectFloatCurve(FName name, FKuroCurveFloat value)
	{
		this.HasCurveParameters = true;
		if (value.bUseCurve)
		{
			this.FloatCurveMap[name] = value;
			return;
		}
		this.CollectFloatConst(name, value.Constant);
	}

	// Token: 0x0601BD74 RID: 114036 RVA: 0x0084D604 File Offset: 0x0084B804
	public virtual void CollectFloatConst(FName name, float value)
	{
		this.FloatConstMap[name] = value;
	}

	// Token: 0x0601BD75 RID: 114037 RVA: 0x0084D613 File Offset: 0x0084B813
	public virtual void CollectLinearColorCurve(FName name, FKuroCurveLinearColor value)
	{
		this.HasCurveParameters = true;
		if (value.bUseCurve)
		{
			this.LinearColorCurveMap[name] = value;
			return;
		}
		this.CollectLinearColorConst(name, value.Constant);
	}

	// Token: 0x0601BD76 RID: 114038 RVA: 0x0084D63F File Offset: 0x0084B83F
	public virtual void CollectLinearColorConst(FName name, FLinearColor value)
	{
		this.LinearColorConstMap[name] = value;
	}

	// Token: 0x0601BD77 RID: 114039 RVA: 0x0084D64E File Offset: 0x0084B84E
	public virtual void CollectVectorCurve(FName name, FKuroCurveVector value)
	{
		this.HasCurveParameters = true;
		if (value.bUseCurve)
		{
			this.VectorCurveMap[name] = value;
			return;
		}
		this.CollectVectorConst(name, value.Constant);
	}

	// Token: 0x0601BD78 RID: 114040 RVA: 0x0084D67A File Offset: 0x0084B87A
	public virtual void CollectVectorConst(FName name, FVector value)
	{
		this.VectorConstMap[name] = value;
	}

	// Token: 0x0601BD79 RID: 114041 RVA: 0x0084D689 File Offset: 0x0084B889
	public virtual void RemoveFloatCurveOrConst(FName name)
	{
		this.FloatCurveMap.Remove(name);
		this.FloatConstMap.Remove(name);
	}

	// Token: 0x0601BD7A RID: 114042 RVA: 0x0084D6A5 File Offset: 0x0084B8A5
	public virtual void RemoveLinearColorCurveOrConst(FName name)
	{
		this.LinearColorCurveMap.Remove(name);
		this.LinearColorConstMap.Remove(name);
	}

	// Token: 0x0601BD7B RID: 114043 RVA: 0x0084D6C1 File Offset: 0x0084B8C1
	public virtual void RemoveVectorCurveOrConst(FName name)
	{
		this.VectorCurveMap.Remove(name);
		this.VectorConstMap.Remove(name);
	}

	// Token: 0x0601BD7C RID: 114044 RVA: 0x0084D6E0 File Offset: 0x0084B8E0
	[NullableContext(2)]
	public virtual void Apply(UObject target, float time, bool forceApply)
	{
		if (target == null)
		{
			return;
		}
		if (!forceApply && !this.HasCurveParameters)
		{
			return;
		}
		UMaterialInstanceDynamic umaterialInstanceDynamic = target as UMaterialInstanceDynamic;
		if (umaterialInstanceDynamic != null)
		{
			this.ApplyMaterial(umaterialInstanceDynamic, time, forceApply);
		}
	}

	// Token: 0x0601BD7D RID: 114045 RVA: 0x0084D710 File Offset: 0x0084B910
	[NullableContext(2)]
	protected void ApplyNiagara(UNiagaraComponent NiagaraComponent, float Time, bool bForceApply)
	{
		if (NiagaraComponent == null)
		{
			return;
		}
		if (bForceApply)
		{
			foreach (KeyValuePair<FName, float> keyValuePair in this.FloatConstMap)
			{
				NiagaraComponent.SetNiagaraVariableFloat(keyValuePair.Key.ToString(), keyValuePair.Value);
			}
			foreach (KeyValuePair<FName, FLinearColor> keyValuePair2 in this.LinearColorConstMap)
			{
				string inVariableName = keyValuePair2.Key.ToString();
				FLinearColor value = keyValuePair2.Value;
				NiagaraComponent.SetNiagaraVariableLinearColor(inVariableName, value);
			}
			foreach (KeyValuePair<FName, FVector> keyValuePair3 in this.VectorConstMap)
			{
				NiagaraComponent.SetNiagaraVariableVec3(keyValuePair3.Key.ToString(), keyValuePair3.Value);
			}
		}
		foreach (KeyValuePair<FName, FKuroCurveFloat> keyValuePair4 in this.FloatCurveMap)
		{
			FKuroCurveFloat value2 = keyValuePair4.Value;
			float value_Float = UKuroCurveLibrary.GetValue_Float(value2, Time);
			NiagaraComponent.SetNiagaraVariableFloat(keyValuePair4.Key.ToString(), value_Float);
		}
		foreach (KeyValuePair<FName, FKuroCurveVector> keyValuePair5 in this.VectorCurveMap)
		{
			FKuroCurveVector value3 = keyValuePair5.Value;
			FVector value_Vector = UKuroCurveLibrary.GetValue_Vector(value3, Time);
			NiagaraComponent.SetNiagaraVariableVec3(keyValuePair5.Key.ToString(), value_Vector);
		}
		foreach (KeyValuePair<FName, FKuroCurveLinearColor> keyValuePair6 in this.LinearColorCurveMap)
		{
			FKuroCurveLinearColor value4 = keyValuePair6.Value;
			FLinearColor value_LinearColor = UKuroCurveLibrary.GetValue_LinearColor(value4, Time);
			NiagaraComponent.SetNiagaraVariableLinearColor(keyValuePair6.Key.ToString(), value_LinearColor);
		}
	}

	// Token: 0x0601BD7E RID: 114046 RVA: 0x0084D990 File Offset: 0x0084BB90
	[NullableContext(2)]
	protected void ApplyMaterial(UMaterialInstanceDynamic MaterialInstanceDynamic, float Time, bool bForceApply)
	{
		if (MaterialInstanceDynamic == null)
		{
			return;
		}
		if (bForceApply)
		{
			foreach (KeyValuePair<FName, float> keyValuePair in this.FloatConstMap)
			{
				MaterialInstanceDynamic.SetScalarParameterValue(keyValuePair.Key, keyValuePair.Value);
			}
			foreach (KeyValuePair<FName, FVector> keyValuePair2 in this.VectorConstMap)
			{
				FVector value = keyValuePair2.Value;
				MaterialInstanceDynamic.SetVectorParameterValue(keyValuePair2.Key, new FLinearColor(value.X, value.Y, value.Z, 1f));
			}
			foreach (KeyValuePair<FName, FLinearColor> keyValuePair3 in this.LinearColorConstMap)
			{
				MaterialInstanceDynamic.SetVectorParameterValue(keyValuePair3.Key, keyValuePair3.Value);
			}
		}
		foreach (KeyValuePair<FName, FKuroCurveFloat> keyValuePair4 in this.FloatCurveMap)
		{
			FKuroCurveFloat value2 = keyValuePair4.Value;
			float value_Float = UKuroCurveLibrary.GetValue_Float(value2, Time);
			MaterialInstanceDynamic.SetScalarParameterValue(keyValuePair4.Key, value_Float);
		}
		foreach (KeyValuePair<FName, FKuroCurveVector> keyValuePair5 in this.VectorCurveMap)
		{
			FKuroCurveVector value3 = keyValuePair5.Value;
			FVector value_Vector = UKuroCurveLibrary.GetValue_Vector(value3, Time);
			MaterialInstanceDynamic.SetVectorParameterValue(keyValuePair5.Key, new FLinearColor(value_Vector.X, value_Vector.Y, value_Vector.Z, 1f));
		}
		foreach (KeyValuePair<FName, FKuroCurveLinearColor> keyValuePair6 in this.LinearColorCurveMap)
		{
			FKuroCurveLinearColor value4 = keyValuePair6.Value;
			FLinearColor value_LinearColor = UKuroCurveLibrary.GetValue_LinearColor(value4, Time);
			MaterialInstanceDynamic.SetVectorParameterValue(keyValuePair6.Key, value_LinearColor);
		}
	}

	// Token: 0x0400E0E3 RID: 57571
	protected Dictionary<FName, FKuroCurveFloat> FloatCurveMap = new Dictionary<FName, FKuroCurveFloat>();

	// Token: 0x0400E0E4 RID: 57572
	protected Dictionary<FName, FKuroCurveLinearColor> LinearColorCurveMap = new Dictionary<FName, FKuroCurveLinearColor>();

	// Token: 0x0400E0E5 RID: 57573
	protected Dictionary<FName, FKuroCurveVector> VectorCurveMap = new Dictionary<FName, FKuroCurveVector>();

	// Token: 0x0400E0E6 RID: 57574
	protected Dictionary<FName, float> FloatConstMap = new Dictionary<FName, float>();

	// Token: 0x0400E0E7 RID: 57575
	protected Dictionary<FName, FLinearColor> LinearColorConstMap = new Dictionary<FName, FLinearColor>();

	// Token: 0x0400E0E8 RID: 57576
	protected Dictionary<FName, FVector> VectorConstMap = new Dictionary<FName, FVector>();

	// Token: 0x0400E0E9 RID: 57577
	protected bool HasCurveParameters;
}
