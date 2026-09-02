using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02000E9C RID: 3740
[NullableContext(1)]
[Nullable(0)]
public class GameUtils : IStaticVariableResetter
{
	// Token: 0x06005C3A RID: 23610 RVA: 0x001739D6 File Offset: 0x00171BD6
	static GameUtils()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(GameUtils.CreateStaticDefaultValue), new Action(GameUtils.ResetStaticDefaultValue));
	}

	// Token: 0x17000698 RID: 1688
	// (get) Token: 0x06005C3B RID: 23611 RVA: 0x001739FB File Offset: 0x00171BFB
	private static ImmutableArray<object> EmptyArray
	{
		get
		{
			return GameUtils._emptyArray;
		}
	}

	// Token: 0x17000699 RID: 1689
	// (get) Token: 0x06005C3C RID: 23612 RVA: 0x00173A02 File Offset: 0x00171C02
	private static ImmutableMap<object, object> EmptyMap
	{
		get
		{
			return GameUtils._emptyMap;
		}
	}

	// Token: 0x06005C3D RID: 23613 RVA: 0x00173A0C File Offset: 0x00171C0C
	public static UniTask WaitFrame()
	{
		GameUtils.<WaitFrame>d__9 <WaitFrame>d__;
		<WaitFrame>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<WaitFrame>d__.<>1__state = -1;
		<WaitFrame>d__.<>t__builder.Start<GameUtils.<WaitFrame>d__9>(ref <WaitFrame>d__);
		return <WaitFrame>d__.<>t__builder.Task;
	}

	// Token: 0x06005C3E RID: 23614 RVA: 0x00173A48 File Offset: 0x00171C48
	public static T[] ConvertToArray<[Nullable(2)] T>(int length, Func<int, T> getItemFunc)
	{
		if (length <= 0)
		{
			return Array.Empty<T>();
		}
		T[] array = new T[length];
		for (int i = 0; i < length; i++)
		{
			array[i] = getItemFunc(i);
		}
		return array;
	}

	// Token: 0x06005C3F RID: 23615 RVA: 0x00173A84 File Offset: 0x00171C84
	[NullableContext(2)]
	[return: Nullable(1)]
	public static Dictionary<TKey, TValue> ConvertToMap<TKey, TValue, TPair>(int length, [Nullable(1)] Func<int, TPair> getPairFunc)
	{
		if (length <= 0)
		{
			return new Dictionary<TKey, TValue>();
		}
		Type type = typeof(TPair);
		if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
		{
			type = type.GenericTypeArguments[0];
		}
		PropertyInfo property = type.GetProperty("Key", BindingFlags.Instance | BindingFlags.Public);
		PropertyInfo property2 = type.GetProperty("Value", BindingFlags.Instance | BindingFlags.Public);
		Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
		for (int i = 0; i < length; i++)
		{
			TPair tpair = getPairFunc(i);
			if (tpair != null)
			{
				dictionary[(TKey)((object)property.GetValue(tpair))] = (TValue)((object)property2.GetValue(tpair));
			}
		}
		return dictionary;
	}

	// Token: 0x06005C40 RID: 23616 RVA: 0x00173B3E File Offset: 0x00171D3E
	public static void InternalizedString(string str)
	{
		string.Intern(str);
	}

	// Token: 0x06005C41 RID: 23617 RVA: 0x00173B48 File Offset: 0x00171D48
	[NullableContext(0)]
	public static void SetNullableValue<T>(ref T? value, [Nullable(new byte[]
	{
		1,
		0
	})] GameUtils.ActionRef<T> callback) where T : struct
	{
		if (value == null)
		{
			value = new T?(default(T));
		}
		callback(Unsafe.AsRef<T>(Nullable.GetValueRefOrDefaultRef<T>(ref value)));
	}

	// Token: 0x06005C42 RID: 23618 RVA: 0x00173B82 File Offset: 0x00171D82
	public static void CreateStaticDefaultValue()
	{
		GameUtils._emptyArray = new ImmutableArray<object>();
		GameUtils._emptyMap = new ImmutableMap<object, object>();
	}

	// Token: 0x06005C43 RID: 23619 RVA: 0x00173B98 File Offset: 0x00171D98
	public static void ResetStaticDefaultValue()
	{
		GameUtils._emptyArray = null;
		GameUtils._emptyMap = null;
	}

	// Token: 0x04002C22 RID: 11298
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static ImmutableArray<object> _emptyArray;

	// Token: 0x04002C23 RID: 11299
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static ImmutableMap<object, object> _emptyMap;

	// Token: 0x04002C24 RID: 11300
	public static readonly bool IsOptimizeDbString = true;

	// Token: 0x020072CE RID: 29390
	// (Invoke) Token: 0x06046AAD RID: 289453
	[NullableContext(0)]
	public delegate void ActionRef<[Nullable(2)] T>(ref T value);
}
