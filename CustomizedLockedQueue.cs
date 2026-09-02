using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020030B2 RID: 12466
[NullableContext(2)]
[Nullable(0)]
public class CustomizedLockedQueue
{
	// Token: 0x06019AE8 RID: 105192 RVA: 0x0077729C File Offset: 0x0077549C
	public bool Has(LockOnInfo info)
	{
		if (info == null)
		{
			return false;
		}
		for (int i = 0; i < this.LruLockedArray.Count; i++)
		{
			if (this.LruLockedArray[i].Equal(info))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06019AE9 RID: 105193 RVA: 0x007772DB File Offset: 0x007754DB
	public void Push(LockOnInfo info)
	{
		if (info != null && !this.Has(info))
		{
			this.LruLockedArray.Add(info);
		}
	}

	// Token: 0x06019AEA RID: 105194 RVA: 0x007772F5 File Offset: 0x007754F5
	public LockOnInfo Pop()
	{
		if (this.LruLockedArray.Count == 0)
		{
			return null;
		}
		LockOnInfo result = this.LruLockedArray[0];
		this.LruLockedArray.RemoveAt(0);
		return result;
	}

	// Token: 0x06019AEB RID: 105195 RVA: 0x0077731E File Offset: 0x0077551E
	public void Clear()
	{
		this.LruLockedArray.Clear();
	}

	// Token: 0x0400CC7A RID: 52346
	[Nullable(1)]
	private readonly List<LockOnInfo> LruLockedArray = new List<LockOnInfo>();
}
