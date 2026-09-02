using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Effect
{
	// Token: 0x0200704B RID: 28747
	[NullableContext(1)]
	[Nullable(0)]
	public static class NiagaraComponentHandleExtension
	{
		// Token: 0x06045945 RID: 284997 RVA: 0x0122E158 File Offset: 0x0122C358
		public static bool IsValid([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectNiagaraComponentHandle, UNiagaraComponent> self)
		{
			if (self.IsT1)
			{
				return self.AsT1.IsValid();
			}
			return self.IsT2 && self.AsT2.IsValid();
		}

		// Token: 0x06045946 RID: 284998 RVA: 0x0122E187 File Offset: 0x0122C387
		public static bool GetForceSolo([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectNiagaraComponentHandle, UNiagaraComponent> self)
		{
			if (self.IsT1)
			{
				return self.AsT1.bForceSolo;
			}
			return self.IsT2 && self.AsT2.bForceSolo;
		}

		// Token: 0x06045947 RID: 284999 RVA: 0x0122E1B6 File Offset: 0x0122C3B6
		public static void SetForceSolo([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectNiagaraComponentHandle, UNiagaraComponent> self, bool value)
		{
			if (self.IsT1)
			{
				self.AsT1.bForceSolo = value;
				return;
			}
			if (self.IsT2)
			{
				self.AsT2.SetForceSolo(value);
			}
		}

		// Token: 0x06045948 RID: 285000 RVA: 0x0122E1E5 File Offset: 0x0122C3E5
		public static void SetNiagaraVariableFloat([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectNiagaraComponentHandle, UNiagaraComponent> self, string inVariableName, float inValue)
		{
			if (self.IsT1)
			{
				self.AsT1.SetNiagaraVariableFloat(inVariableName, inValue);
				return;
			}
			if (self.IsT2)
			{
				self.AsT2.SetNiagaraVariableFloat(inVariableName, inValue);
			}
		}

		// Token: 0x06045949 RID: 285001 RVA: 0x0122E216 File Offset: 0x0122C416
		public static void SetNiagaraVariableVec3([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectNiagaraComponentHandle, UNiagaraComponent> self, string inVariableName, in FVector inValue)
		{
			if (self.IsT1)
			{
				self.AsT1.SetNiagaraVariableVec3(inVariableName, inValue);
				return;
			}
			if (self.IsT2)
			{
				self.AsT2.SetNiagaraVariableVec3(inVariableName, inValue);
			}
		}

		// Token: 0x0604594A RID: 285002 RVA: 0x0122E24C File Offset: 0x0122C44C
		public static void SetIntParameter([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectNiagaraComponentHandle, UNiagaraComponent> self, in FName inParameterName, int inParam)
		{
			if (self.IsT1)
			{
				self.AsT1.SetIntParameter(inParameterName, inParam);
				return;
			}
			if (self.IsT2)
			{
				self.AsT2.SetIntParameter(inParameterName, inParam);
			}
		}

		// Token: 0x0604594B RID: 285003 RVA: 0x0122E282 File Offset: 0x0122C482
		public static void SetFloatParameter([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectNiagaraComponentHandle, UNiagaraComponent> self, in FName inParameterName, float inParam)
		{
			if (self.IsT1)
			{
				self.AsT1.SetFloatParameter(inParameterName, inParam);
				return;
			}
			if (self.IsT2)
			{
				self.AsT2.SetFloatParameter(inParameterName, inParam);
			}
		}

		// Token: 0x0604594C RID: 285004 RVA: 0x0122E2B8 File Offset: 0x0122C4B8
		public static void SetColorParameter([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectNiagaraComponentHandle, UNiagaraComponent> self, in FName inParameterName, in FLinearColor inParam)
		{
			if (self.IsT1)
			{
				self.AsT1.SetColorParameter(inParameterName, inParam);
				return;
			}
			if (self.IsT2)
			{
				self.AsT2.SetColorParameter(inParameterName, inParam);
			}
		}

		// Token: 0x0604594D RID: 285005 RVA: 0x0122E2F3 File Offset: 0x0122C4F3
		public static void SetVectorParameter([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectNiagaraComponentHandle, UNiagaraComponent> self, in FName inParameterName, in FVector inParam)
		{
			if (self.IsT1)
			{
				self.AsT1.SetVectorParameter(inParameterName, inParam);
				return;
			}
			if (self.IsT2)
			{
				self.AsT2.SetVectorParameter(inParameterName, inParam);
			}
		}

		// Token: 0x0604594E RID: 285006 RVA: 0x0122E32E File Offset: 0x0122C52E
		public static void SetCastShadow([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectNiagaraComponentHandle, UNiagaraComponent> self, bool castShadow)
		{
			if (self.IsT1)
			{
				self.AsT1.SetCastShadow(castShadow);
				return;
			}
			if (self.IsT2)
			{
				self.AsT2.SetCastShadow(castShadow);
			}
		}

		// Token: 0x0604594F RID: 285007 RVA: 0x0122E35D File Offset: 0x0122C55D
		public static void SetKuroNiagaraEmitterFloatParam([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectNiagaraComponentHandle, UNiagaraComponent> self, string inEmitterName, string inVariableName, float value)
		{
			if (self.IsT1)
			{
				self.AsT1.SetKuroNiagaraEmitterFloatParam(inEmitterName, inVariableName, value);
				return;
			}
			if (self.IsT2)
			{
				self.AsT2.SetKuroNiagaraEmitterFloatParam(inEmitterName, inVariableName, value);
			}
		}

		// Token: 0x06045950 RID: 285008 RVA: 0x0122E390 File Offset: 0x0122C590
		public static void SetKuroNiagaraEmitterVectorParam([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectNiagaraComponentHandle, UNiagaraComponent> self, string inEmitterName, string inVariableName, in FVector4 value)
		{
			if (self.IsT1)
			{
				self.AsT1.SetKuroNiagaraEmitterVectorParam(inEmitterName, inVariableName, value);
				return;
			}
			if (self.IsT2)
			{
				self.AsT2.SetKuroNiagaraEmitterVectorParam(inEmitterName, inVariableName, value);
			}
		}

		// Token: 0x06045951 RID: 285009 RVA: 0x0122E3C8 File Offset: 0x0122C5C8
		public static void SetNiagaraVariableLinearColor([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectNiagaraComponentHandle, UNiagaraComponent> self, string variableName, in FLinearColor value)
		{
			if (self.IsT1)
			{
				self.AsT1.SetNiagaraVariableLinearColor(variableName, value);
				return;
			}
			if (self.IsT2)
			{
				self.AsT2.SetNiagaraVariableLinearColor(variableName, value);
			}
		}

		// Token: 0x06045952 RID: 285010 RVA: 0x0122E3F9 File Offset: 0x0122C5F9
		public static void SetKuroNiagaraEmitterCustomTexture([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectNiagaraComponentHandle, UNiagaraComponent> self, string inEmitterName, string inVariableName, UTexture inTexture)
		{
			if (self.IsT1)
			{
				self.AsT1.SetKuroNiagaraEmitterCustomTexture(inEmitterName, inVariableName, inTexture);
				return;
			}
			if (self.IsT2)
			{
				self.AsT2.SetKuroNiagaraEmitterCustomTexture(inEmitterName, inVariableName, inTexture);
			}
		}
	}
}
