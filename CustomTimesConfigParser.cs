using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002E8C RID: 11916
public static class CustomTimesConfigParser
{
	// Token: 0x0601877E RID: 100222 RVA: 0x006DA460 File Offset: 0x006D8660
	[return: Nullable(new byte[]
	{
		1,
		2
	})]
	public static CustomTimesConfig[] ParseConfigs([Nullable(new byte[]
	{
		2,
		1
	})] string[] grow3Params, long buffId)
	{
		string[] array = grow3Params ?? Array.Empty<string>();
		CustomTimesConfig[] array2 = new CustomTimesConfig[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			string text = array[i];
			string[] array3 = (text != null) ? text.Split('#', StringSplitOptions.None) : null;
			int num;
			if (array3 != null && array3.Length != 0 && int.TryParse(array3[0], out num) && num == 1)
			{
				array2[i] = CustomTimesConfigParser.ParseConfig(text, buffId);
			}
			else
			{
				array2[i] = null;
			}
		}
		return array2;
	}

	// Token: 0x0601877F RID: 100223 RVA: 0x006DA4D0 File Offset: 0x006D86D0
	[NullableContext(2)]
	private unsafe static CustomTimesConfig ParseConfig(string config, long buffId)
	{
		if (string.IsNullOrEmpty(config))
		{
			return null;
		}
		string[] array = (from v in config.Split('#', StringSplitOptions.None)
		select v.Trim()).ToArray<string>();
		if (array.Length < 6)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.GHY;
			string message = "自定义Times(Buff配置的ExtraEffectParametersGrow3)参数个数错误";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", buffId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("config", config);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		int num = 0;
		int calcType;
		int attributeId;
		int valueTarget;
		int valueType;
		float rate;
		float limit;
		if (!int.TryParse(array[num++], out calcType) || !int.TryParse(array[num++], out attributeId) || !int.TryParse(array[num++], out valueTarget) || !int.TryParse(array[num++], out valueType) || !float.TryParse(array[num++], out rate) || !float.TryParse(array[num++], out limit))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Battle;
			ELogAuthor author2 = ELogAuthor.GHY;
			string message2 = "自定义Times(Buff配置的ExtraEffectParametersGrow3)存在无法解析为数字的字段";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("buffId", buffId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("config", config);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return null;
		}
		return new CustomTimesConfig
		{
			CalcType = (ECustomTimesCalcType)calcType,
			AttributeId = attributeId,
			ValueTarget = (ECustomTimesValueTarget)valueTarget,
			ValueType = (ECustomTimesValueType)valueType,
			Rate = rate,
			Limit = limit
		};
	}

	// Token: 0x06018780 RID: 100224 RVA: 0x006DA669 File Offset: 0x006D8869
	[NullableContext(1)]
	public static float CalcCustomTimes(CustomTimesConfig config, BaseAttributeComponent attrComp)
	{
		return Math.Min((float)Math.Floor((double)(((config.ValueType == ECustomTimesValueType.CurrentValue) ? attrComp.GetCurrentValue((EAttributeType)config.AttributeId) : attrComp.GetBaseValue((EAttributeType)config.AttributeId)) * config.Rate)), config.Limit);
	}

	// Token: 0x0400BCAA RID: 48298
	private const int CUSTOM_TIMES_PARAM_COUNT = 6;
}
