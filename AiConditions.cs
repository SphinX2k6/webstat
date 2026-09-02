using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.Monster.Common;
using AkiClient.Game.Aki.Data.Condition.Enum;
using AkiClient.Game.Aki.Protocol;
using UnrealEngine;

// Token: 0x02000CF2 RID: 3314
[NullableContext(1)]
[Nullable(0)]
public class AiConditions
{
	// Token: 0x06004200 RID: 16896 RVA: 0x00071820 File Offset: 0x0006FA20
	public AiConditions(SAiConditions aiConditions)
	{
		this.Logic = (SConditionGroupType)aiConditions.Logic;
		this.Tags.EnsureCapacity(aiConditions.Tags.Num());
		foreach (KeyValuePair<FGameplayTag, FFloatRange> keyValuePair in aiConditions.Tags)
		{
			FGameplayTag fgameplayTag;
			FFloatRange ffloatRange;
			keyValuePair.Deconstruct(out fgameplayTag, out ffloatRange);
			FGameplayTag tag = fgameplayTag;
			FFloatRange ffloatRange2 = ffloatRange;
			this.Tags[tag.TagId()] = new TsFloatRange(ffloatRange2.LowerBound.Type == 0, ffloatRange2.LowerBound.Value, ffloatRange2.UpperBound.Value);
		}
		this.Attributes.EnsureCapacity(aiConditions.Attributes.Num());
		foreach (KeyValuePair<TEnumAsByte<AkiClient.Game.Aki.Protocol.EAttributeType>, FFloatRange> keyValuePair2 in aiConditions.Attributes)
		{
			FFloatRange ffloatRange;
			TEnumAsByte<AkiClient.Game.Aki.Protocol.EAttributeType> tenumAsByte;
			keyValuePair2.Deconstruct(out tenumAsByte, out ffloatRange);
			TEnumAsByte<AkiClient.Game.Aki.Protocol.EAttributeType> value = tenumAsByte;
			FFloatRange ffloatRange3 = ffloatRange;
			this.Attributes[(Aki.Protocol.EAttributeType)value] = new TsFloatRange(ffloatRange3.LowerBound.Type == 0, ffloatRange3.LowerBound.Value, ffloatRange3.UpperBound.Value);
		}
		int num = aiConditions.AttributeRates.Num();
		this.AttributeRates.EnsureCapacity(num);
		for (int i = 0; i < num; i++)
		{
			AiAttributeRate aiAttributeRate = new AiAttributeRate(aiConditions.AttributeRates.Get(i));
			this.AttributeRates.Add(aiAttributeRate);
			List<int> list;
			if (!this.AttributeRateDenominatorMap.TryGetValue(aiAttributeRate.Denominator, out list))
			{
				list = (this.AttributeRateDenominatorMap[aiAttributeRate.Denominator] = new List<int>());
			}
			list.Add(i);
			if (!this.AttributeRateNumeratorMap.TryGetValue(aiAttributeRate.Numerator, out list))
			{
				list = (this.AttributeRateNumeratorMap[aiAttributeRate.Numerator] = new List<int>());
			}
			list.Add(i);
		}
	}

	// Token: 0x0400104A RID: 4170
	public Dictionary<int, TsFloatRange> Tags = new Dictionary<int, TsFloatRange>();

	// Token: 0x0400104B RID: 4171
	public Dictionary<Aki.Protocol.EAttributeType, TsFloatRange> Attributes = new Dictionary<Aki.Protocol.EAttributeType, TsFloatRange>();

	// Token: 0x0400104C RID: 4172
	public List<AiAttributeRate> AttributeRates = new List<AiAttributeRate>();

	// Token: 0x0400104D RID: 4173
	public Dictionary<Aki.Protocol.EAttributeType, List<int>> AttributeRateDenominatorMap = new Dictionary<Aki.Protocol.EAttributeType, List<int>>();

	// Token: 0x0400104E RID: 4174
	public Dictionary<Aki.Protocol.EAttributeType, List<int>> AttributeRateNumeratorMap = new Dictionary<Aki.Protocol.EAttributeType, List<int>>();

	// Token: 0x0400104F RID: 4175
	public SConditionGroupType Logic;
}
