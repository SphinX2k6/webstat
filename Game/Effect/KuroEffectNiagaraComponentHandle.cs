using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Effect
{
	// Token: 0x0200704E RID: 28750
	[NullableContext(1)]
	[Nullable(0)]
	public class KuroEffectNiagaraComponentHandle
	{
		// Token: 0x1700A52D RID: 42285
		// (get) Token: 0x06045981 RID: 285057 RVA: 0x0122EC10 File Offset: 0x0122CE10
		[Nullable(2)]
		public UNiagaraComponent NiagaraComponent
		{
			[NullableContext(2)]
			get
			{
				return this.NiagaraComponentInternal;
			}
		}

		// Token: 0x06045982 RID: 285058 RVA: 0x0122EC18 File Offset: 0x0122CE18
		public KuroEffectNiagaraComponentHandle(int id)
		{
			this.Id = id;
		}

		// Token: 0x06045983 RID: 285059 RVA: 0x0122EC27 File Offset: 0x0122CE27
		public KuroEffectNiagaraComponentHandle(UNiagaraComponent niagaraComponent)
		{
			this.NiagaraComponentInternal = niagaraComponent;
		}

		// Token: 0x06045984 RID: 285060 RVA: 0x0122EC36 File Offset: 0x0122CE36
		public bool IsValid()
		{
			return UKuroEffectSystemHandleHelperLibrary.NiagaraComponentHandle_IsValid(this.Id);
		}

		// Token: 0x1700A52E RID: 42286
		// (get) Token: 0x06045985 RID: 285061 RVA: 0x0122EC43 File Offset: 0x0122CE43
		// (set) Token: 0x06045986 RID: 285062 RVA: 0x0122EC50 File Offset: 0x0122CE50
		public bool bForceSolo
		{
			get
			{
				return UKuroEffectSystemHandleHelperLibrary.NiagaraComponentHandle_GetForceSolo(this.Id);
			}
			set
			{
				UKuroEffectSystemHandleHelperLibrary.NiagaraComponentHandle_SetForceSolo(this.Id, value);
			}
		}

		// Token: 0x06045987 RID: 285063 RVA: 0x0122EC5E File Offset: 0x0122CE5E
		public void SetNiagaraVariableFloat(string inVariableName, float inValue)
		{
			UKuroEffectSystemHandleHelperLibrary.NiagaraComponentHandle_SetNiagaraVariableFloat(this.Id, inVariableName, inValue);
		}

		// Token: 0x06045988 RID: 285064 RVA: 0x0122EC6D File Offset: 0x0122CE6D
		public void SetNiagaraVariableVec3(string inVariableName, in FVector inValue)
		{
			UKuroEffectSystemHandleHelperLibrary.NiagaraComponentHandle_SetNiagaraVariableVec3(this.Id, inVariableName, inValue);
		}

		// Token: 0x06045989 RID: 285065 RVA: 0x0122EC7C File Offset: 0x0122CE7C
		public void SetIntParameter(in FName parameterName, int param)
		{
			UKuroEffectSystemHandleHelperLibrary.NiagaraComponentHandle_SetIntParameter(this.Id, parameterName, param);
		}

		// Token: 0x0604598A RID: 285066 RVA: 0x0122EC8B File Offset: 0x0122CE8B
		public void SetFloatParameter(in FName parameterName, float param)
		{
			UKuroEffectSystemHandleHelperLibrary.NiagaraComponentHandle_SetFloatParameter(this.Id, parameterName, param);
		}

		// Token: 0x0604598B RID: 285067 RVA: 0x0122EC9A File Offset: 0x0122CE9A
		public void SetColorParameter(in FName parameterName, in FLinearColor param)
		{
			UKuroEffectSystemHandleHelperLibrary.NiagaraComponentHandle_SetColorParameter(this.Id, parameterName, param);
		}

		// Token: 0x0604598C RID: 285068 RVA: 0x0122ECA9 File Offset: 0x0122CEA9
		public void SetVectorParameter(in FName parameterName, in FVector param)
		{
			UKuroEffectSystemHandleHelperLibrary.NiagaraComponentHandle_SetVectorParameter(this.Id, parameterName, param);
		}

		// Token: 0x0604598D RID: 285069 RVA: 0x0122ECB8 File Offset: 0x0122CEB8
		public void SetCastShadow(bool castShadow)
		{
			UKuroEffectSystemHandleHelperLibrary.NiagaraComponentHandle_SetCastShadow(this.Id, castShadow);
		}

		// Token: 0x0604598E RID: 285070 RVA: 0x0122ECC6 File Offset: 0x0122CEC6
		public void SetEnviInteractionComp(UKuroEnviInteractionComponent eIComp)
		{
			UKuroEffectSystemHandleHelperLibrary.NiagaraComponentHandle_SetEnviInteractionComp(this.Id, eIComp);
		}

		// Token: 0x0604598F RID: 285071 RVA: 0x0122ECD4 File Offset: 0x0122CED4
		public void SetKuroNiagaraEmitterFloatParam(string inEmitterName, string inVariableName, float value)
		{
			UKuroEffectSystemHandleHelperLibrary.NiagaraComponentHandle_SetKuroNiagaraEmitterFloatParam(this.Id, inEmitterName, inVariableName, value);
		}

		// Token: 0x06045990 RID: 285072 RVA: 0x0122ECE4 File Offset: 0x0122CEE4
		public void SetKuroNiagaraEmitterVectorParam(string inEmitterName, string inVariableName, in FVector4 inVector)
		{
			UKuroEffectSystemHandleHelperLibrary.NiagaraComponentHandle_SetKuroNiagaraEmitterVectorParam(this.Id, inEmitterName, inVariableName, inVector);
		}

		// Token: 0x06045991 RID: 285073 RVA: 0x0122ECF4 File Offset: 0x0122CEF4
		public void SetNiagaraVariableLinearColor(string variableName, in FLinearColor value)
		{
			UKuroEffectSystemHandleHelperLibrary.NiagaraComponentHandle_SetNiagaraVariableLinearColor(this.Id, variableName, value);
		}

		// Token: 0x06045992 RID: 285074 RVA: 0x0122ED03 File Offset: 0x0122CF03
		public void SetKuroNiagaraEmitterCustomTexture(string inEmitterName, string inVariableName, UTexture inTexture)
		{
			UKuroEffectSystemHandleHelperLibrary.NiagaraComponentHandle_SetKuroNiagaraEmitterCustomTexture(this.Id, inEmitterName, inVariableName, inTexture);
		}

		// Token: 0x04026D97 RID: 159127
		private readonly int Id;

		// Token: 0x04026D98 RID: 159128
		[Nullable(2)]
		private readonly UNiagaraComponent NiagaraComponentInternal;
	}
}
