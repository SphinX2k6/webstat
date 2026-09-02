using System;
using System.Runtime.CompilerServices;

// Token: 0x02000072 RID: 114
[NullableContext(2)]
[Nullable(0)]
internal class RbNode<T>
{
	// Token: 0x060002B1 RID: 689 RVA: 0x0000E7C8 File Offset: 0x0000C9C8
	[NullableContext(1)]
	public void BreakChildLink(RbNode<T> node)
	{
		if (this.Left == node)
		{
			this.Left = null;
			return;
		}
		if (this.Right == node)
		{
			this.Right = null;
			return;
		}
		Singleton<Log>.Instance.Error(ELogModule.Core, ELogAuthor.LCZ, "待移除的节点并非其子节点", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x060002B2 RID: 690 RVA: 0x0000E811 File Offset: 0x0000CA11
	public void Clear()
	{
		this.Parent = null;
		this.Left = null;
		this.Right = null;
		this.Item = default(T);
		this.IsRed = false;
	}

	// Token: 0x040001F9 RID: 505
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public RbNode<T> Parent;

	// Token: 0x040001FA RID: 506
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public RbNode<T> Left;

	// Token: 0x040001FB RID: 507
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public RbNode<T> Right;

	// Token: 0x040001FC RID: 508
	public T Item;

	// Token: 0x040001FD RID: 509
	public bool IsRed;
}
