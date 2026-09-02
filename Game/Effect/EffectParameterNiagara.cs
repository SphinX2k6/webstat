using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Effect
{
	// Token: 0x02007046 RID: 28742
	public class EffectParameterNiagara
	{
		// Token: 0x1700A51D RID: 42269
		// (get) Token: 0x060458DD RID: 284893 RVA: 0x0122D8A3 File Offset: 0x0122BAA3
		// (set) Token: 0x060458DE RID: 284894 RVA: 0x0122D8AB File Offset: 0x0122BAAB
		[Nullable(new byte[]
		{
			2,
			0
		})]
		public List<ValueTuple<FName, float>> UserParameterFloat { [return: Nullable(new byte[]
		{
			2,
			0
		})] get; [param: Nullable(new byte[]
		{
			2,
			0
		})] set; }

		// Token: 0x1700A51E RID: 42270
		// (get) Token: 0x060458DF RID: 284895 RVA: 0x0122D8B4 File Offset: 0x0122BAB4
		// (set) Token: 0x060458E0 RID: 284896 RVA: 0x0122D8BC File Offset: 0x0122BABC
		[Nullable(new byte[]
		{
			2,
			0
		})]
		public List<ValueTuple<FName, FLinearColor>> UserParameterColor { [return: Nullable(new byte[]
		{
			2,
			0
		})] get; [param: Nullable(new byte[]
		{
			2,
			0
		})] set; }

		// Token: 0x1700A51F RID: 42271
		// (get) Token: 0x060458E1 RID: 284897 RVA: 0x0122D8C5 File Offset: 0x0122BAC5
		// (set) Token: 0x060458E2 RID: 284898 RVA: 0x0122D8CD File Offset: 0x0122BACD
		[Nullable(new byte[]
		{
			2,
			0
		})]
		public List<ValueTuple<FName, FVector>> UserParameterVector { [return: Nullable(new byte[]
		{
			2,
			0
		})] get; [param: Nullable(new byte[]
		{
			2,
			0
		})] set; }

		// Token: 0x1700A520 RID: 42272
		// (get) Token: 0x060458E3 RID: 284899 RVA: 0x0122D8D6 File Offset: 0x0122BAD6
		// (set) Token: 0x060458E4 RID: 284900 RVA: 0x0122D8DE File Offset: 0x0122BADE
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		public List<ValueTuple<FName, TArray<FVector>>> UserParameterArrayVector { [return: Nullable(new byte[]
		{
			2,
			0,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			0,
			1
		})] set; }

		// Token: 0x1700A521 RID: 42273
		// (get) Token: 0x060458E5 RID: 284901 RVA: 0x0122D8E7 File Offset: 0x0122BAE7
		// (set) Token: 0x060458E6 RID: 284902 RVA: 0x0122D8EF File Offset: 0x0122BAEF
		[Nullable(new byte[]
		{
			2,
			0
		})]
		public List<ValueTuple<FName, float>> MaterialParameterFloat { [return: Nullable(new byte[]
		{
			2,
			0
		})] get; [param: Nullable(new byte[]
		{
			2,
			0
		})] set; }

		// Token: 0x1700A522 RID: 42274
		// (get) Token: 0x060458E7 RID: 284903 RVA: 0x0122D8F8 File Offset: 0x0122BAF8
		// (set) Token: 0x060458E8 RID: 284904 RVA: 0x0122D900 File Offset: 0x0122BB00
		[Nullable(new byte[]
		{
			2,
			0
		})]
		public List<ValueTuple<FName, FLinearColor>> MaterialParameterColor { [return: Nullable(new byte[]
		{
			2,
			0
		})] get; [param: Nullable(new byte[]
		{
			2,
			0
		})] set; }

		// Token: 0x060458E9 RID: 284905 RVA: 0x0122D90C File Offset: 0x0122BB0C
		[NullableContext(1)]
		public void ToKuroEffectParameterNiagara(FKuroEffectNiagaraParametersStruct parameters)
		{
			if (this.UserParameterFloat != null)
			{
				foreach (ValueTuple<FName, float> valueTuple in this.UserParameterFloat)
				{
					FKuroParameterFloat value = new FKuroParameterFloat(valueTuple.Item1, valueTuple.Item2);
					parameters.UserParameterFloat.Add(value);
				}
			}
			if (this.UserParameterColor != null)
			{
				foreach (ValueTuple<FName, FLinearColor> valueTuple2 in this.UserParameterColor)
				{
					FKuroParameterLinearColor value2 = new FKuroParameterLinearColor(valueTuple2.Item1, valueTuple2.Item2);
					parameters.UserParameterColor.Add(value2);
				}
			}
			if (this.UserParameterVector != null)
			{
				foreach (ValueTuple<FName, FVector> valueTuple3 in this.UserParameterVector)
				{
					FKuroParameterVector value3 = new FKuroParameterVector(valueTuple3.Item1, valueTuple3.Item2);
					parameters.UserParameterVector.Add(value3);
				}
			}
			if (this.UserParameterArrayVector != null)
			{
				foreach (ValueTuple<FName, TArray<FVector>> valueTuple4 in this.UserParameterArrayVector)
				{
					FKuroParameterArrayVector value4 = new FKuroParameterArrayVector(valueTuple4.Item1, valueTuple4.Item2);
					parameters.UserParameterArrayVector.Add(value4);
				}
			}
			if (this.MaterialParameterFloat != null)
			{
				foreach (ValueTuple<FName, float> valueTuple5 in this.MaterialParameterFloat)
				{
					FKuroParameterFloat value5 = new FKuroParameterFloat(valueTuple5.Item1, valueTuple5.Item2);
					parameters.MaterialParameterFloat.Add(value5);
				}
			}
			if (this.MaterialParameterColor != null)
			{
				foreach (ValueTuple<FName, FLinearColor> valueTuple6 in this.MaterialParameterColor)
				{
					FKuroParameterLinearColor value6 = new FKuroParameterLinearColor(valueTuple6.Item1, valueTuple6.Item2);
					parameters.MaterialParameterColor.Add(value6);
				}
			}
		}
	}
}
