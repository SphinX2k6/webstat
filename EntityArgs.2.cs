using System;
using System.Runtime.CompilerServices;

// Token: 0x0200008F RID: 143
[NullableContext(1)]
[Nullable(0)]
public readonly struct EntityArgs<[Nullable(2)] T1, [Nullable(2)] T2> : IEntityArgs
{
	// Token: 0x06000383 RID: 899 RVA: 0x000158C5 File Offset: 0x00013AC5
	public EntityArgs(T1 p1, T2 p2)
	{
		this.<p1>P = p1;
		this.<p2>P = p2;
	}

	// Token: 0x06000384 RID: 900 RVA: 0x000158D8 File Offset: 0x00013AD8
	public T GetP1<[Nullable(2)] T>()
	{
		T1 t = this.<p1>P;
		if (t is T)
		{
			return t as T;
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 2);
		defaultInterpolatedStringHandler.AppendLiteral("无法将 ");
		t = this.<p1>P;
		defaultInterpolatedStringHandler.AppendFormatted<Type>((t != null) ? t.GetType() : null);
		defaultInterpolatedStringHandler.AppendLiteral(" 转换为 ");
		defaultInterpolatedStringHandler.AppendFormatted<Type>(typeof(T));
		throw new InvalidCastException(defaultInterpolatedStringHandler.ToStringAndClear());
	}

	// Token: 0x06000385 RID: 901 RVA: 0x0001597C File Offset: 0x00013B7C
	public T GetP2<[Nullable(2)] T>()
	{
		T2 t = this.<p2>P;
		if (t is T)
		{
			return t as T;
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 2);
		defaultInterpolatedStringHandler.AppendLiteral("无法将 ");
		t = this.<p2>P;
		defaultInterpolatedStringHandler.AppendFormatted<Type>((t != null) ? t.GetType() : null);
		defaultInterpolatedStringHandler.AppendLiteral(" 转换为 ");
		defaultInterpolatedStringHandler.AppendFormatted<Type>(typeof(T));
		throw new InvalidCastException(defaultInterpolatedStringHandler.ToStringAndClear());
	}

	// Token: 0x06000386 RID: 902 RVA: 0x00015A1D File Offset: 0x00013C1D
	public T GetP3<[Nullable(2)] T>()
	{
		throw new InvalidCastException("无法获取参数");
	}

	// Token: 0x06000387 RID: 903 RVA: 0x00015A29 File Offset: 0x00013C29
	public T GetP4<[Nullable(2)] T>()
	{
		throw new InvalidCastException("无法获取参数");
	}

	// Token: 0x06000388 RID: 904 RVA: 0x00015A35 File Offset: 0x00013C35
	public T GetP5<[Nullable(2)] T>()
	{
		throw new InvalidCastException("无法获取参数");
	}

	// Token: 0x0400037D RID: 893
	[CompilerGenerated]
	private readonly T1 <p1>P;

	// Token: 0x0400037E RID: 894
	[CompilerGenerated]
	private readonly T2 <p2>P;
}
