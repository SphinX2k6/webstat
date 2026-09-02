using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200203A RID: 8250
[NullableContext(1)]
[Nullable(0)]
public class ViewModelBase<[Nullable(0)] T> where T : Enum
{
	// Token: 0x0600FB57 RID: 64343 RVA: 0x00450328 File Offset: 0x0044E528
	protected void SetData(T key, object value, bool? notNotify = false)
	{
		if (this.DataMap.ContainsKey(key))
		{
			this.DataMap[key] = value;
		}
		else
		{
			this.DataMap.Add(key, value);
		}
		bool? flag = notNotify;
		bool flag2 = false;
		if (flag.GetValueOrDefault() == flag2 & flag != null)
		{
			this.Notify(key);
		}
	}

	// Token: 0x0600FB58 RID: 64344 RVA: 0x00450380 File Offset: 0x0044E580
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

	// Token: 0x0600FB59 RID: 64345 RVA: 0x004503A0 File Offset: 0x0044E5A0
	public void Bind(Action<T> callback)
	{
		if (!this.CallbackList.Contains(callback))
		{
			this.CallbackList.Add(callback);
		}
	}

	// Token: 0x0600FB5A RID: 64346 RVA: 0x004503BC File Offset: 0x0044E5BC
	public void UnBind(Action<T> callback)
	{
		int num = this.CallbackList.IndexOf(callback);
		if (num != -1)
		{
			this.CallbackList.RemoveAt(num);
		}
	}

	// Token: 0x0600FB5B RID: 64347 RVA: 0x004503E6 File Offset: 0x0044E5E6
	public void Clear()
	{
		this.CallbackList = new List<Action<T>>();
	}

	// Token: 0x0600FB5C RID: 64348 RVA: 0x004503F4 File Offset: 0x0044E5F4
	protected void Notify(T key)
	{
		foreach (Action<T> action in this.CallbackList)
		{
			action(key);
		}
	}

	// Token: 0x040078B1 RID: 30897
	protected readonly Dictionary<T, object> DataMap = new Dictionary<T, object>();

	// Token: 0x040078B2 RID: 30898
	protected List<Action<T>> CallbackList = new List<Action<T>>();
}
