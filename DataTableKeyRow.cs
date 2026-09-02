using System;
using System.Runtime.CompilerServices;

// Token: 0x02000C08 RID: 3080
[NullableContext(1)]
[Nullable(0)]
public class DataTableKeyRow<[Nullable(2)] T>
{
	// Token: 0x170000D3 RID: 211
	// (get) Token: 0x06003312 RID: 13074 RVA: 0x0002780F File Offset: 0x00025A0F
	// (set) Token: 0x06003313 RID: 13075 RVA: 0x00027817 File Offset: 0x00025A17
	public string Key
	{
		get
		{
			return this._key;
		}
		set
		{
			this._key = value;
		}
	}

	// Token: 0x170000D4 RID: 212
	// (get) Token: 0x06003314 RID: 13076 RVA: 0x00027820 File Offset: 0x00025A20
	// (set) Token: 0x06003315 RID: 13077 RVA: 0x00027828 File Offset: 0x00025A28
	public T Value
	{
		get
		{
			return this._value;
		}
		set
		{
			this._value = value;
		}
	}

	// Token: 0x170000D5 RID: 213
	public object this[int index]
	{
		get
		{
			if (index == 0)
			{
				return this.Key;
			}
			if (index != 1)
			{
				throw new IndexOutOfRangeException();
			}
			return this.Value;
		}
		set
		{
			if (index == 0)
			{
				this.Key = (string)value;
				return;
			}
			if (index != 1)
			{
				throw new IndexOutOfRangeException();
			}
			this.Value = (T)((object)value);
		}
	}

	// Token: 0x06003318 RID: 13080 RVA: 0x0002787E File Offset: 0x00025A7E
	public DataTableKeyRow()
	{
		this._key = null;
		this._value = default(T);
	}

	// Token: 0x06003319 RID: 13081 RVA: 0x00027899 File Offset: 0x00025A99
	public DataTableKeyRow(string key, T value)
	{
		this._key = key;
		this._value = value;
	}

	// Token: 0x040005B6 RID: 1462
	private string _key;

	// Token: 0x040005B7 RID: 1463
	private T _value;
}
