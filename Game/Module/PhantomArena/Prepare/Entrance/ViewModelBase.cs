using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054D1 RID: 21713
	[NullableContext(1)]
	[Nullable(0)]
	public class ViewModelBase<[Nullable(2)] T>
	{
		// Token: 0x060374F5 RID: 226549 RVA: 0x00E083D6 File Offset: 0x00E065D6
		protected void SetData(T key, object value, bool notNotify = false)
		{
			this.DataMap[key] = value;
			if (!notNotify)
			{
				this.Notify(key);
			}
		}

		// Token: 0x060374F6 RID: 226550 RVA: 0x00E083EF File Offset: 0x00E065EF
		[return: Nullable(2)]
		protected object GetData(T key)
		{
			return this.DataMap.GetValueOrDefault(key);
		}

		// Token: 0x060374F7 RID: 226551 RVA: 0x00E083FD File Offset: 0x00E065FD
		public void Bind(Action<T> callback)
		{
			if (!this.CallbackList.Contains(callback))
			{
				this.CallbackList.Add(callback);
			}
		}

		// Token: 0x060374F8 RID: 226552 RVA: 0x00E08419 File Offset: 0x00E06619
		public void UnBind(Action<T> callback)
		{
			this.CallbackList.Remove(callback);
		}

		// Token: 0x060374F9 RID: 226553 RVA: 0x00E08428 File Offset: 0x00E06628
		public void Clear()
		{
			this.CallbackList.Clear();
		}

		// Token: 0x060374FA RID: 226554 RVA: 0x00E08438 File Offset: 0x00E06638
		protected void Notify(T key)
		{
			foreach (Action<T> action in this.CallbackList)
			{
				action(key);
			}
		}

		// Token: 0x0401FC7A RID: 130170
		protected readonly Dictionary<T, object> DataMap = new Dictionary<T, object>();

		// Token: 0x0401FC7B RID: 130171
		protected List<Action<T>> CallbackList = new List<Action<T>>();
	}
}
