using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine.Extension;

// Token: 0x02002247 RID: 8775
[NullableContext(1)]
[Nullable(0)]
public class PropertyMap<TK, [Nullable(2)] TV> : IEnumerable<KeyValuePair<TK, TV>>, IEnumerable
{
	// Token: 0x17001473 RID: 5235
	// (get) Token: 0x060108FA RID: 67834 RVA: 0x00487453 File Offset: 0x00485653
	public int Count
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return this.Entries.Count;
		}
	}

	// Token: 0x060108FB RID: 67835 RVA: 0x00487460 File Offset: 0x00485660
	public PropertyMap<TK, TV> Add(TK key, TV value)
	{
		return this.Set(key, value);
	}

	// Token: 0x060108FC RID: 67836 RVA: 0x0048746C File Offset: 0x0048566C
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public PropertyMap<TK, TV> Set(TK key, TV value)
	{
		ref PropertyEntry<TV> valueRefOrNullRef = ref CollectionsMarshal.GetValueRefOrNullRef<TK, PropertyEntry<TV>>(this.Entries, key);
		if (!Unsafe.IsNullRef<PropertyEntry<TV>>(ref valueRefOrNullRef))
		{
			if (EqualityComparer<TV>.Default.Equals(valueRefOrNullRef.Value, value))
			{
				return this;
			}
			valueRefOrNullRef.Value = value;
			valueRefOrNullRef.IsDirty = true;
		}
		else
		{
			this.Entries[key] = new PropertyEntry<TV>(value, true);
		}
		return this;
	}

	// Token: 0x060108FD RID: 67837 RVA: 0x004874C7 File Offset: 0x004856C7
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public TV Get(TK key)
	{
		ref PropertyEntry<TV> valueRefOrNullRef = ref CollectionsMarshal.GetValueRefOrNullRef<TK, PropertyEntry<TV>>(this.Entries, key);
		valueRefOrNullRef.IsDirty = false;
		return valueRefOrNullRef.Value;
	}

	// Token: 0x060108FE RID: 67838 RVA: 0x004874E4 File Offset: 0x004856E4
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public TV TryGet(TK key, TV defaultValue = default(TV), bool flushDirty = true)
	{
		ref PropertyEntry<TV> valueRefOrNullRef = ref CollectionsMarshal.GetValueRefOrNullRef<TK, PropertyEntry<TV>>(this.Entries, key);
		if (Unsafe.IsNullRef<PropertyEntry<TV>>(ref valueRefOrNullRef))
		{
			return defaultValue;
		}
		if (flushDirty && valueRefOrNullRef.IsDirty)
		{
			valueRefOrNullRef.IsDirty = false;
		}
		return valueRefOrNullRef.Value;
	}

	// Token: 0x060108FF RID: 67839 RVA: 0x00487520 File Offset: 0x00485720
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void CleanDirty(TK key)
	{
		ref PropertyEntry<TV> valueRefOrNullRef = ref CollectionsMarshal.GetValueRefOrNullRef<TK, PropertyEntry<TV>>(this.Entries, key);
		if (!Unsafe.IsNullRef<PropertyEntry<TV>>(ref valueRefOrNullRef) && valueRefOrNullRef.IsDirty)
		{
			valueRefOrNullRef.IsDirty = false;
		}
	}

	// Token: 0x06010900 RID: 67840 RVA: 0x00487554 File Offset: 0x00485754
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void SetDirty(TK key)
	{
		ref PropertyEntry<TV> valueRefOrNullRef = ref CollectionsMarshal.GetValueRefOrNullRef<TK, PropertyEntry<TV>>(this.Entries, key);
		if (!Unsafe.IsNullRef<PropertyEntry<TV>>(ref valueRefOrNullRef) && !valueRefOrNullRef.IsDirty)
		{
			valueRefOrNullRef.IsDirty = true;
		}
	}

	// Token: 0x06010901 RID: 67841 RVA: 0x00487588 File Offset: 0x00485788
	public void SetAllDirty()
	{
		using (PoolArray<TK> poolArray = this.Entries.Keys.ToPoolArray<TK>())
		{
			foreach (TK key in poolArray)
			{
				ref PropertyEntry<TV> valueRefOrNullRef = ref CollectionsMarshal.GetValueRefOrNullRef<TK, PropertyEntry<TV>>(this.Entries, key);
				if (!valueRefOrNullRef.IsDirty)
				{
					valueRefOrNullRef.IsDirty = true;
				}
			}
		}
	}

	// Token: 0x06010902 RID: 67842 RVA: 0x00487614 File Offset: 0x00485814
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool IsDirty(TK key)
	{
		PropertyEntry<TV> propertyEntry;
		return this.Entries.TryGetValue(key, out propertyEntry) && propertyEntry.IsDirty;
	}

	// Token: 0x17001474 RID: 5236
	public TV this[TK key]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return this.Get(key);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		set
		{
			this.Set(key, value);
		}
	}

	// Token: 0x06010905 RID: 67845 RVA: 0x0048764D File Offset: 0x0048584D
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool Remove(TK key)
	{
		return this.Entries.Remove(key);
	}

	// Token: 0x06010906 RID: 67846 RVA: 0x0048765B File Offset: 0x0048585B
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Clear()
	{
		this.Entries.Clear();
	}

	// Token: 0x06010907 RID: 67847 RVA: 0x00487668 File Offset: 0x00485868
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool ContainsKey(TK key)
	{
		return this.Entries.ContainsKey(key);
	}

	// Token: 0x06010908 RID: 67848 RVA: 0x00487678 File Offset: 0x00485878
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool TryGetValue(TK key, [Nullable(2)] out TV value)
	{
		PropertyEntry<TV> propertyEntry;
		if (this.Entries.TryGetValue(key, out propertyEntry))
		{
			value = propertyEntry.Value;
			return true;
		}
		value = default(TV);
		return false;
	}

	// Token: 0x17001475 RID: 5237
	// (get) Token: 0x06010909 RID: 67849 RVA: 0x004876AB File Offset: 0x004858AB
	public IEnumerable<TK> Keys
	{
		get
		{
			return this.Entries.Keys;
		}
	}

	// Token: 0x17001476 RID: 5238
	// (get) Token: 0x0601090A RID: 67850 RVA: 0x004876B8 File Offset: 0x004858B8
	public IEnumerable<TV> Values
	{
		get
		{
			PropertyMap<TK, TV>.<get_Values>d__21 <get_Values>d__ = new PropertyMap<TK, TV>.<get_Values>d__21(-2);
			<get_Values>d__.<>4__this = this;
			return <get_Values>d__;
		}
	}

	// Token: 0x0601090B RID: 67851 RVA: 0x004876C8 File Offset: 0x004858C8
	[return: Nullable(new byte[]
	{
		1,
		0,
		1,
		1
	})]
	public IEnumerator<KeyValuePair<TK, TV>> GetEnumerator()
	{
		PropertyMap<TK, TV>.<GetEnumerator>d__22 <GetEnumerator>d__ = new PropertyMap<TK, TV>.<GetEnumerator>d__22(0);
		<GetEnumerator>d__.<>4__this = this;
		return <GetEnumerator>d__;
	}

	// Token: 0x0601090C RID: 67852 RVA: 0x004876D7 File Offset: 0x004858D7
	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}

	// Token: 0x04008258 RID: 33368
	[Nullable(new byte[]
	{
		1,
		1,
		0,
		1
	})]
	private readonly Dictionary<TK, PropertyEntry<TV>> Entries = new Dictionary<TK, PropertyEntry<TV>>();
}
