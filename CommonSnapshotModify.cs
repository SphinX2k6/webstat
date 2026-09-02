using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002F63 RID: 12131
[NullableContext(1)]
[Nullable(0)]
public class CommonSnapshotModify : ModifierCalculator
{
	// Token: 0x06018CB2 RID: 101554 RVA: 0x007029BD File Offset: 0x00700BBD
	public CommonSnapshotModify(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018CB3 RID: 101555 RVA: 0x007029CC File Offset: 0x00700BCC
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		float[] extraEffectGrowParameters = parameters.ExtraEffectGrowParameters1;
		float[] extraEffectGrowParameters2 = parameters.ExtraEffectGrowParameters2;
		int level = this.Level;
		this.TargetType = new ESnapTargetType?((ESnapTargetType)int.Parse(extraEffectParameters_[0]));
		this.AttrId = (EAttributeType)int.Parse(extraEffectParameters_[1]);
		this.CalculationPolicy = (ESnapCalculateType)int.Parse(extraEffectParameters_[2]);
		if (extraEffectParameters_.Length > 3 && !string.IsNullOrEmpty(extraEffectParameters_[3]))
		{
			string[] array = extraEffectParameters_[3].Split('#', StringSplitOptions.None);
			this.RefAttrId = (EAttributeType)int.Parse(array[0]);
			this.AttributeThreshold = (float)((array.Length > 1) ? int.Parse(array[1]) : 0);
			this.ModifierMax = (float)((array.Length > 2) ? int.Parse(array[2]) : 0);
		}
		if (this.CalculationPolicy == ESnapCalculateType.AddPerTenThousand)
		{
			this.RefAttrId = this.AttrId;
		}
		this.RefTargetType = (ESnapAttributeSourceType)int.Parse(extraEffectParameters_[4]);
		this.RefValueType = (EAttributeRefType)int.Parse(extraEffectParameters_[5]);
		long[] stackParam;
		if (extraEffectParameters_.Length <= 6)
		{
			stackParam = new long[1];
		}
		else
		{
			IEnumerable<string> source = extraEffectParameters_[6].Split('#', StringSplitOptions.None);
			Func<string, long> selector;
			if ((selector = CommonSnapshotModify.<>O.<0>__Parse) == null)
			{
				selector = (CommonSnapshotModify.<>O.<0>__Parse = new Func<string, long>(long.Parse));
			}
			stackParam = source.Select(selector).ToArray<long>();
		}
		this.StackParam = stackParam;
		this.RefParam1 = AbilityUtils.GetLevelValue<float>(extraEffectGrowParameters, level, 0f);
		this.RefParam2 = AbilityUtils.GetLevelValue<float>(extraEffectGrowParameters2, level, 0f);
		this.NeedCheckCritical = this.RequireAndLimits.Requirements.Any((IRequirement require) => require.Type == EExtraEffectRequire.ShouldCritical);
	}

	// Token: 0x06018CB4 RID: 101556 RVA: 0x00702B52 File Offset: 0x00700D52
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		if (parameters.Length < 2)
		{
			return false;
		}
		this.OnExecuteSnap((Dictionary<EAttributeType, float>)parameters[0], (SnapshotPayload)parameters[1]);
		return true;
	}

	// Token: 0x06018CB5 RID: 101557 RVA: 0x00702B80 File Offset: 0x00700D80
	protected override void OnExecuteSnap(Dictionary<EAttributeType, float> resultMap, SnapshotPayload snapshots)
	{
		EAttributeType attrId = this.AttrId;
		float num2;
		float num = resultMap.TryGetValue(attrId, out num2) ? num2 : 0f;
		float num3 = base.CalculateValue(snapshots);
		resultMap[attrId] = num + num3;
	}

	// Token: 0x0400C159 RID: 49497
	public EAttributeType AttrId;

	// Token: 0x02009331 RID: 37681
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x04031026 RID: 200742
		[Nullable(0)]
		public static Func<string, long> <0>__Parse;
	}
}
