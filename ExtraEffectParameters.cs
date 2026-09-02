using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F13 RID: 12051
[NullableContext(2)]
[Nullable(0)]
public class ExtraEffectParameters
{
	// Token: 0x0400C02D RID: 49197
	public EExtraEffectId ExtraEffectId = EExtraEffectId.AddBuff;

	// Token: 0x0400C02E RID: 49198
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public string[] ExtraEffectParameters_;

	// Token: 0x0400C02F RID: 49199
	public float[] ExtraEffectGrowParameters1;

	// Token: 0x0400C030 RID: 49200
	public float[] ExtraEffectGrowParameters2;

	// Token: 0x0400C031 RID: 49201
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public string[] ExtraEffectGrowParameters3;

	// Token: 0x0400C032 RID: 49202
	public int[] ExtraEffectRequirement;

	// Token: 0x0400C033 RID: 49203
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public string[] ExtraEffectRequirementPara;

	// Token: 0x0400C034 RID: 49204
	public int ExtraEffectRequirementSetting;

	// Token: 0x0400C035 RID: 49205
	public float[] ExtraEffectCd;

	// Token: 0x0400C036 RID: 49206
	public float[] ExtraEffectCdForTarget;

	// Token: 0x0400C037 RID: 49207
	public int ExtraEffectRemoveStackNum;

	// Token: 0x0400C038 RID: 49208
	public float[] ExtraEffectProbability;

	// Token: 0x0400C039 RID: 49209
	public BuffExecution ExecutionEffect;
}
