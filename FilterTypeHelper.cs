using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02003451 RID: 13393
[NullableContext(1)]
[Nullable(0)]
public static class FilterTypeHelper
{
	// Token: 0x0601C16A RID: 115050 RVA: 0x00861458 File Offset: 0x0085F658
	[return: Nullable(2)]
	public unsafe static T TryCatchWrapper<[Nullable(2)] T>([Nullable(new byte[]
	{
		1,
		2
	})] Func<T> func, string errorMessage, string debugValue)
	{
		try
		{
			return func();
		}
		catch (Exception ex)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FilterWithState;
			ELogAuthor author = ELogAuthor.XDW;
			Exception error = ex;
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("debugValue", debugValue);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", ex.Message);
			instance.ErrorWithStack(module, author, errorMessage, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		return default(T);
	}

	// Token: 0x0400E2E0 RID: 58080
	[StaticVariableRuleIgnore]
	public static readonly EFilterType[] FilterTypePriority = new EFilterType[]
	{
		EFilterType.Top,
		EFilterType.BindGroup,
		EFilterType.Black
	};

	// Token: 0x0400E2E1 RID: 58081
	[StaticVariableRuleIgnore]
	public static readonly Dictionary<EFilterType, bool> FilterResult = new Dictionary<EFilterType, bool>
	{
		{
			EFilterType.Top,
			true
		},
		{
			EFilterType.BindGroup,
			true
		},
		{
			EFilterType.Black,
			false
		}
	};
}
