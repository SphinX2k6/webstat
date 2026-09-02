using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

// Token: 0x020034E9 RID: 13545
[NullableContext(1)]
[Nullable(0)]
public abstract class UnitTestBase
{
	// Token: 0x170026EA RID: 9962
	// (get) Token: 0x0601CA13 RID: 117267
	public abstract string Name { get; }

	// Token: 0x0601CA14 RID: 117268
	[NullableContext(0)]
	public abstract UniTask<bool> Run([Nullable(1)] params object[] args);

	// Token: 0x0601CA15 RID: 117269 RVA: 0x008968DB File Offset: 0x00894ADB
	protected void Debug(string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
	}

	// Token: 0x0601CA16 RID: 117270 RVA: 0x008968DD File Offset: 0x00894ADD
	protected void Info(string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		Singleton<Log>.Instance.Info(ELogModule.Test, ELogAuthor.LFJW, "[测试用例] [" + this.Name + "] " + message, pairs);
	}

	// Token: 0x0601CA17 RID: 117271 RVA: 0x00896903 File Offset: 0x00894B03
	protected void Warn(string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		Singleton<Log>.Instance.Warn(ELogModule.Test, ELogAuthor.LFJW, "[测试用例] [" + this.Name + "] " + message, pairs);
	}

	// Token: 0x0601CA18 RID: 117272 RVA: 0x00896929 File Offset: 0x00894B29
	protected void Error(string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		Singleton<Log>.Instance.Error(ELogModule.Test, ELogAuthor.LFJW, "[测试用例] [" + this.Name + "] " + message, pairs);
	}
}
