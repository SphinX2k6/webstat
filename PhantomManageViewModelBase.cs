using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200203E RID: 8254
[NullableContext(1)]
[Nullable(0)]
public class PhantomManageViewModelBase<[Nullable(0)] T> where T : Enum
{
	// Token: 0x0600FB80 RID: 64384 RVA: 0x00450CAC File Offset: 0x0044EEAC
	protected void SetData(T key, object value, bool notNotify = false)
	{
		if (this.DataMap.ContainsKey(key))
		{
			this.DataMap[key] = value;
		}
		else
		{
			this.DataMap.Add(key, value);
		}
		if (!notNotify)
		{
			this.Notify(key);
		}
	}

	// Token: 0x0600FB81 RID: 64385 RVA: 0x00450CE4 File Offset: 0x0044EEE4
	[return: Nullable(2)]
	protected object GetData(T key)
	{
		object result;
		if (this.DataMap.TryGetValue(key, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0600FB82 RID: 64386 RVA: 0x00450D04 File Offset: 0x0044EF04
	public void Bind(Action<T> callback)
	{
		if (!this.CallbackList.Contains(callback))
		{
			this.CallbackList.Add(callback);
		}
	}

	// Token: 0x0600FB83 RID: 64387 RVA: 0x00450D20 File Offset: 0x0044EF20
	public void UnBind(Action<T> callback)
	{
		int num = this.CallbackList.IndexOf(callback);
		if (num != -1)
		{
			this.CallbackList.RemoveAt(num);
		}
	}

	// Token: 0x0600FB84 RID: 64388 RVA: 0x00450D4A File Offset: 0x0044EF4A
	public void Clear()
	{
		this.CallbackList = new List<Action<T>>();
	}

	// Token: 0x0600FB85 RID: 64389 RVA: 0x00450D58 File Offset: 0x0044EF58
	protected void Notify(T key)
	{
		foreach (Action<T> action in this.CallbackList)
		{
			action(key);
		}
	}

	// Token: 0x040078C0 RID: 30912
	protected readonly Dictionary<T, object> DataMap = new Dictionary<T, object>();

	// Token: 0x040078C1 RID: 30913
	protected List<Action<T>> CallbackList = new List<Action<T>>();
}
