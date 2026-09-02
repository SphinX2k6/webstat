using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Dango
{
	// Token: 0x02005DD6 RID: 24022
	[NullableContext(1)]
	[Nullable(0)]
	public class ViewModelBase<[Nullable(2)] T>
	{
		// Token: 0x0603C79D RID: 247709 RVA: 0x00F5C126 File Offset: 0x00F5A326
		protected void SetData(T key, [Nullable(2)] object value, bool notNotify = false)
		{
			this.DataMap[key] = value;
			if (!notNotify)
			{
				this.Notify(key);
			}
		}

		// Token: 0x0603C79E RID: 247710 RVA: 0x00F5C140 File Offset: 0x00F5A340
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

		// Token: 0x0603C79F RID: 247711 RVA: 0x00F5C160 File Offset: 0x00F5A360
		public void Bind(TCallback<T> callback)
		{
			if (!this.CallbackList.Contains(callback))
			{
				this.CallbackList.Add(callback);
			}
		}

		// Token: 0x0603C7A0 RID: 247712 RVA: 0x00F5C17C File Offset: 0x00F5A37C
		public void UnBind(TCallback<T> callback)
		{
			int num = this.CallbackList.IndexOf(callback);
			if (num != -1)
			{
				this.CallbackList.RemoveAt(num);
			}
		}

		// Token: 0x0603C7A1 RID: 247713 RVA: 0x00F5C1A6 File Offset: 0x00F5A3A6
		public void Clear()
		{
			this.CallbackList = new List<TCallback<T>>();
		}

		// Token: 0x0603C7A2 RID: 247714 RVA: 0x00F5C1B4 File Offset: 0x00F5A3B4
		protected void Notify(T key)
		{
			foreach (TCallback<T> tcallback in this.CallbackList)
			{
				tcallback(key);
			}
		}

		// Token: 0x0402200E RID: 139278
		[Nullable(new byte[]
		{
			1,
			1,
			2
		})]
		protected readonly Dictionary<T, object> DataMap = new Dictionary<T, object>();

		// Token: 0x0402200F RID: 139279
		protected List<TCallback<T>> CallbackList = new List<TCallback<T>>();
	}
}
