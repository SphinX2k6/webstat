using System;
using System.Runtime.CompilerServices;

// Token: 0x0200008E RID: 142
[NullableContext(1)]
[Nullable(0)]
public readonly struct EntityArgs<[Nullable(2)] T1> : IEntityArgs
{
	// Token: 0x0600037D RID: 893 RVA: 0x000157E8 File Offset: 0x000139E8
	public EntityArgs(T1 p1)
	{
		this.<p1>P = p1;
	}

	// Token: 0x0600037E RID: 894 RVA: 0x000157F4 File Offset: 0x000139F4
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

	// Token: 0x0600037F RID: 895 RVA: 0x00015895 File Offset: 0x00013A95
	public T GetP2<[Nullable(2)] T>()
	{
		throw new InvalidCastException("无法获取参数");
	}

	// Token: 0x06000380 RID: 896 RVA: 0x000158A1 File Offset: 0x00013AA1
	public T GetP3<[Nullable(2)] T>()
	{
		throw new InvalidCastException("无法获取参数");
	}

	// Token: 0x06000381 RID: 897 RVA: 0x000158AD File Offset: 0x00013AAD
	public T GetP4<[Nullable(2)] T>()
	{
		throw new InvalidCastException("无法获取参数");
	}

	// Token: 0x06000382 RID: 898 RVA: 0x000158B9 File Offset: 0x00013AB9
	public T GetP5<[Nullable(2)] T>()
	{
		throw new InvalidCastException("无法获取参数");
	}

	// Token: 0x0400037C RID: 892
	[CompilerGenerated]
	private readonly T1 <p1>P;
}
