using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000C10 RID: 3088
[NullableContext(1)]
[Nullable(0)]
public class KuroStringBuilder
{
	// Token: 0x170000D9 RID: 217
	// (get) Token: 0x06003356 RID: 13142 RVA: 0x000289D6 File Offset: 0x00026BD6
	public List<object> Store
	{
		get
		{
			return this.StoreInternal;
		}
	}

	// Token: 0x06003357 RID: 13143 RVA: 0x000289DE File Offset: 0x00026BDE
	public KuroStringBuilder(params object[] parameters)
	{
		this.StoreInternal = new List<object>(16);
		if (parameters.Length != 0)
		{
			this.Append(parameters);
		}
	}

	// Token: 0x06003358 RID: 13144 RVA: 0x00028A00 File Offset: 0x00026C00
	public void Append(params object[] parameters)
	{
		foreach (object obj in parameters)
		{
			if (obj is string)
			{
				this.StoreInternal.Add(obj);
			}
			else
			{
				Array array = obj as Array;
				if (array != null)
				{
					using (IEnumerator enumerator = array.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							object element = enumerator.Current;
							this.StoreInternal.Append(element);
						}
						goto IL_9A;
					}
				}
				if (obj is KuroStringBuilder)
				{
					this.StoreInternal.AddRange(((KuroStringBuilder)obj).Store);
				}
				else
				{
					this.StoreInternal.Add(obj);
				}
			}
			IL_9A:;
		}
	}

	// Token: 0x06003359 RID: 13145 RVA: 0x00028AC4 File Offset: 0x00026CC4
	public void RemoveLast(int removeNum)
	{
		for (int i = 0; i < removeNum; i++)
		{
			if (this.StoreInternal.Count > 0)
			{
				this.StoreInternal.RemoveAt(this.StoreInternal.Count - 1);
			}
		}
	}

	// Token: 0x0600335A RID: 13146 RVA: 0x00028B03 File Offset: 0x00026D03
	public override string ToString()
	{
		return string.Join<object>("", this.StoreInternal);
	}

	// Token: 0x0600335B RID: 13147 RVA: 0x00028B15 File Offset: 0x00026D15
	public void Clear()
	{
		this.StoreInternal.Clear();
	}

	// Token: 0x040005E5 RID: 1509
	private const int DEFAULT_SIZE = 16;

	// Token: 0x040005E6 RID: 1510
	private List<object> StoreInternal;
}
