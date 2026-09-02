using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Skin
{
	// Token: 0x02004F62 RID: 20322
	[NullableContext(1)]
	[Nullable(0)]
	public class ViewModelBase<[Nullable(2)] T>
	{
		// Token: 0x0603468C RID: 214668 RVA: 0x00D1CBFC File Offset: 0x00D1ADFC
		protected void SetData(T key, object value, bool notNotify = false)
		{
			this.DataMap[key] = value;
			if (!notNotify)
			{
				this.Notify(key);
			}
		}

		// Token: 0x0603468D RID: 214669 RVA: 0x00D1CC18 File Offset: 0x00D1AE18
		[return: Nullable(2)]
		protected object GetData(T key)
		{
			object result;
			this.DataMap.TryGetValue(key, out result);
			return result;
		}

		// Token: 0x0603468E RID: 214670 RVA: 0x00D1CC35 File Offset: 0x00D1AE35
		public void Bind(Action<T> callback)
		{
			if (!this.CallbackList.Contains(callback))
			{
				this.CallbackList.Add(callback);
			}
		}

		// Token: 0x0603468F RID: 214671 RVA: 0x00D1CC54 File Offset: 0x00D1AE54
		public void UnBind(Action<T> callback)
		{
			int num = this.CallbackList.IndexOf(callback);
			if (num != -1)
			{
				this.CallbackList.RemoveAt(num);
			}
		}

		// Token: 0x06034690 RID: 214672 RVA: 0x00D1CC7E File Offset: 0x00D1AE7E
		public void Clear()
		{
			this.CallbackList = new List<Action<T>>();
		}

		// Token: 0x06034691 RID: 214673 RVA: 0x00D1CC8C File Offset: 0x00D1AE8C
		protected void Notify(T key)
		{
			for (int i = 0; i < this.CallbackList.Count; i++)
			{
				this.CallbackList[i](key);
			}
		}

		// Token: 0x0401E339 RID: 123705
		protected readonly Dictionary<T, object> DataMap = new Dictionary<T, object>();

		// Token: 0x0401E33A RID: 123706
		protected List<Action<T>> CallbackList = new List<Action<T>>();
	}
}
