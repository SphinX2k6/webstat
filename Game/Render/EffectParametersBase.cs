using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004771 RID: 18289
	[NullableContext(1)]
	[Nullable(0)]
	public class EffectParametersBase
	{
		// Token: 0x0602F731 RID: 194353 RVA: 0x00B4727B File Offset: 0x00B4547B
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

		// Token: 0x0602F732 RID: 194354 RVA: 0x00B472A7 File Offset: 0x00B454A7
		public virtual void CollectFloatConst(FName name, float value)
		{
			this.FloatConstMap[name] = value;
		}

		// Token: 0x0602F733 RID: 194355 RVA: 0x00B472B6 File Offset: 0x00B454B6
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

		// Token: 0x0602F734 RID: 194356 RVA: 0x00B472E2 File Offset: 0x00B454E2
		public virtual void CollectLinearColorConst(FName name, FLinearColor value)
		{
			this.LinearColorConstMap[name] = value;
		}

		// Token: 0x0602F735 RID: 194357 RVA: 0x00B472F1 File Offset: 0x00B454F1
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

		// Token: 0x0602F736 RID: 194358 RVA: 0x00B4731D File Offset: 0x00B4551D
		public virtual void CollectVectorConst(FName name, FVector value)
		{
			this.VectorConstMap[name] = value;
		}

		// Token: 0x0602F737 RID: 194359 RVA: 0x00B4732C File Offset: 0x00B4552C
		public virtual void RemoveFloatCurveOrConst(FName name)
		{
			this.FloatCurveMap.Remove(name);
			this.FloatConstMap.Remove(name);
		}

		// Token: 0x0602F738 RID: 194360 RVA: 0x00B47348 File Offset: 0x00B45548
		public virtual void RemoveLinearColorCurveOrConst(FName name)
		{
			this.LinearColorCurveMap.Remove(name);
			this.LinearColorConstMap.Remove(name);
		}

		// Token: 0x0602F739 RID: 194361 RVA: 0x00B47364 File Offset: 0x00B45564
		public virtual void RemoveVectorCurveOrConst(FName name)
		{
			this.VectorCurveMap.Remove(name);
			this.VectorConstMap.Remove(name);
		}

		// Token: 0x0602F73A RID: 194362 RVA: 0x00B47380 File Offset: 0x00B45580
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

		// Token: 0x0602F73B RID: 194363 RVA: 0x00B473B0 File Offset: 0x00B455B0
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

		// Token: 0x0602F73C RID: 194364 RVA: 0x00B47630 File Offset: 0x00B45830
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

		// Token: 0x0401B19E RID: 111006
		protected Dictionary<FName, FKuroCurveFloat> FloatCurveMap = new Dictionary<FName, FKuroCurveFloat>();

		// Token: 0x0401B19F RID: 111007
		protected Dictionary<FName, FKuroCurveLinearColor> LinearColorCurveMap = new Dictionary<FName, FKuroCurveLinearColor>();

		// Token: 0x0401B1A0 RID: 111008
		protected Dictionary<FName, FKuroCurveVector> VectorCurveMap = new Dictionary<FName, FKuroCurveVector>();

		// Token: 0x0401B1A1 RID: 111009
		protected Dictionary<FName, float> FloatConstMap = new Dictionary<FName, float>();

		// Token: 0x0401B1A2 RID: 111010
		protected Dictionary<FName, FLinearColor> LinearColorConstMap = new Dictionary<FName, FLinearColor>();

		// Token: 0x0401B1A3 RID: 111011
		protected Dictionary<FName, FVector> VectorConstMap = new Dictionary<FName, FVector>();

		// Token: 0x0401B1A4 RID: 111012
		protected bool HasCurveParameters;
	}
}
