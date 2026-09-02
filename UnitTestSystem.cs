using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020034EA RID: 13546
[NullableContext(1)]
[Nullable(0)]
[StaticVariableRuleIgnore]
public static class UnitTestSystem
{
	// Token: 0x170026EB RID: 9963
	// (get) Token: 0x0601CA1A RID: 117274 RVA: 0x00896957 File Offset: 0x00894B57
	// (set) Token: 0x0601CA1B RID: 117275 RVA: 0x0089695E File Offset: 0x00894B5E
	public static bool Running { get; private set; }

	// Token: 0x0601CA1C RID: 117276 RVA: 0x00896968 File Offset: 0x00894B68
	public static void Initialize(bool run, params object[] args)
	{
		IList<Type> types = DllUtils.GetTypes(EDllType.Game);
		if (types == null)
		{
			DllUtils.Add(EDllType.Game, typeof(DllUtils).Assembly);
			types = DllUtils.GetTypes(EDllType.Game);
		}
		Type typeFromHandle = typeof(UnitTestBase);
		foreach (Type type in types)
		{
			if (typeFromHandle.IsAssignableFrom(type) && Attribute.IsDefined(type, typeof(UnitTestAttribute)) && type.GetCustomAttribute<UnitTestAttribute>() != null)
			{
				UnitTestSystem.UnitTestTypes.Add(type);
			}
		}
		if (!run)
		{
			return;
		}
		UnitTestSystem.RunAll(args);
	}

	// Token: 0x0601CA1D RID: 117277 RVA: 0x00896A14 File Offset: 0x00894C14
	[NullableContext(0)]
	public static UniTask<bool> RunAll([Nullable(1)] params object[] args)
	{
		UnitTestSystem.<RunAll>d__7 <RunAll>d__;
		<RunAll>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RunAll>d__.args = args;
		<RunAll>d__.<>1__state = -1;
		<RunAll>d__.<>t__builder.Start<UnitTestSystem.<RunAll>d__7>(ref <RunAll>d__);
		return <RunAll>d__.<>t__builder.Task;
	}

	// Token: 0x0601CA1E RID: 117278 RVA: 0x00896A58 File Offset: 0x00894C58
	[return: Nullable(0)]
	public static UniTask<ValueTuple<bool, int>> Run(Type type, params object[] args)
	{
		UnitTestSystem.<Run>d__8 <Run>d__;
		<Run>d__.<>t__builder = AsyncUniTaskMethodBuilder<ValueTuple<bool, int>>.Create();
		<Run>d__.type = type;
		<Run>d__.args = args;
		<Run>d__.<>1__state = -1;
		<Run>d__.<>t__builder.Start<UnitTestSystem.<Run>d__8>(ref <Run>d__);
		return <Run>d__.<>t__builder.Task;
	}

	// Token: 0x0601CA1F RID: 117279 RVA: 0x00896AA3 File Offset: 0x00894CA3
	public static void Debug(string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
	}

	// Token: 0x0601CA20 RID: 117280 RVA: 0x00896AA5 File Offset: 0x00894CA5
	public static void Info(string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Test;
		ELogAuthor author = ELogAuthor.LFJW;
		string str = "[测试用例] [";
		UnitTestBase currentUnitTest = UnitTestSystem.CurrentUnitTest;
		instance.Info(module, author, str + ((currentUnitTest != null) ? currentUnitTest.Name : null) + "] " + message, pairs);
	}

	// Token: 0x0601CA21 RID: 117281 RVA: 0x00896AD6 File Offset: 0x00894CD6
	public static void Warn(string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Test;
		ELogAuthor author = ELogAuthor.LFJW;
		string str = "[测试用例] [";
		UnitTestBase currentUnitTest = UnitTestSystem.CurrentUnitTest;
		instance.Warn(module, author, str + ((currentUnitTest != null) ? currentUnitTest.Name : null) + "] " + message, pairs);
	}

	// Token: 0x0601CA22 RID: 117282 RVA: 0x00896B07 File Offset: 0x00894D07
	public static void Error(string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Test;
		ELogAuthor author = ELogAuthor.LFJW;
		string str = "[测试用例] [";
		UnitTestBase currentUnitTest = UnitTestSystem.CurrentUnitTest;
		instance.Error(module, author, str + ((currentUnitTest != null) ? currentUnitTest.Name : null) + "] " + message, pairs);
	}

	// Token: 0x0400E68A RID: 59018
	public static readonly List<Type> UnitTestTypes = new List<Type>();

	// Token: 0x0400E68B RID: 59019
	[Nullable(2)]
	private static UnitTestBase CurrentUnitTest = null;
}
