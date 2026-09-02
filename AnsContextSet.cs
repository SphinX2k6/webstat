using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002C7C RID: 11388
[NullableContext(1)]
[Nullable(0)]
public class AnsContextSet<[Nullable(0)] T> where T : UiAnsContextBase
{
	// Token: 0x06016D85 RID: 93573 RVA: 0x00656704 File Offset: 0x00654904
	[return: Nullable(2)]
	public UiAnsContextBase Has(T value)
	{
		if (this.ContextSet.Contains(value))
		{
			return value;
		}
		foreach (UiAnsContextBase uiAnsContextBase in this.ContextSet)
		{
			if (uiAnsContextBase.IsEqual(value))
			{
				return uiAnsContextBase;
			}
		}
		return null;
	}

	// Token: 0x06016D86 RID: 93574 RVA: 0x00656780 File Offset: 0x00654980
	public void Add(T value)
	{
		if (this.Has(value) != null)
		{
			return;
		}
		this.ContextSet.Add(value);
	}

	// Token: 0x06016D87 RID: 93575 RVA: 0x0065679E File Offset: 0x0065499E
	public bool Delete(T value)
	{
		return this.ContextSet.Remove(value);
	}

	// Token: 0x06016D88 RID: 93576 RVA: 0x006567B1 File Offset: 0x006549B1
	public void Clear()
	{
		this.ContextSet.Clear();
	}

	// Token: 0x0400B024 RID: 45092
	public readonly HashSet<UiAnsContextBase> ContextSet = new HashSet<UiAnsContextBase>();
}
