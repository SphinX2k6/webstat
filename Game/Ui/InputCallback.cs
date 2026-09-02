using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049F4 RID: 18932
	[NullableContext(1)]
	[Nullable(0)]
	internal class InputCallback<[Nullable(2)] T>
	{
		// Token: 0x06031831 RID: 202801 RVA: 0x00C56AB0 File Offset: 0x00C54CB0
		public InputCallback(string name)
		{
			this.InputIdentification = new InputIdentification(name);
		}

		// Token: 0x06031832 RID: 202802 RVA: 0x00C56AE8 File Offset: 0x00C54CE8
		public void Call(T value)
		{
			this.IsCalling = true;
			foreach (TInputHandle<T> tinputHandle in this.CallbackList)
			{
				tinputHandle(this.InputIdentification.Name, value, this.InputIdentification);
			}
			this.TryAddAllPendingCallback();
			this.TryRemoveAllPendingCallback();
			this.IsCalling = false;
		}

		// Token: 0x06031833 RID: 202803 RVA: 0x00C56B64 File Offset: 0x00C54D64
		public void Add(TInputHandle<T> callback)
		{
			if (this.IsCalling)
			{
				this.PendingAddCallbackList.Add(callback);
				return;
			}
			this.CallbackList.Add(callback);
		}

		// Token: 0x06031834 RID: 202804 RVA: 0x00C56B88 File Offset: 0x00C54D88
		private void TryAddAllPendingCallback()
		{
			if (this.PendingAddCallbackList.Count <= 0)
			{
				return;
			}
			foreach (TInputHandle<T> item in this.PendingAddCallbackList)
			{
				this.CallbackList.Add(item);
			}
			this.PendingAddCallbackList.Clear();
		}

		// Token: 0x06031835 RID: 202805 RVA: 0x00C56BFC File Offset: 0x00C54DFC
		public void Remove(TInputHandle<T> callback)
		{
			if (this.IsCalling)
			{
				this.PendingRemoveCallbackList.Add(callback);
				return;
			}
			int num = this.CallbackList.IndexOf(callback);
			if (num < 0)
			{
				return;
			}
			this.CallbackList.RemoveAt(num);
		}

		// Token: 0x06031836 RID: 202806 RVA: 0x00C56C3C File Offset: 0x00C54E3C
		private void TryRemoveAllPendingCallback()
		{
			if (this.PendingRemoveCallbackList.Count <= 0)
			{
				return;
			}
			foreach (TInputHandle<T> item in this.PendingRemoveCallbackList)
			{
				int num = this.CallbackList.IndexOf(item);
				if (num >= 0)
				{
					this.CallbackList.RemoveAt(num);
				}
			}
			this.PendingRemoveCallbackList.Clear();
		}

		// Token: 0x06031837 RID: 202807 RVA: 0x00C56CC0 File Offset: 0x00C54EC0
		public void Clear()
		{
			this.InputIdentification = null;
			this.CallbackList.Clear();
		}

		// Token: 0x06031838 RID: 202808 RVA: 0x00C56CD4 File Offset: 0x00C54ED4
		public int Length()
		{
			return this.CallbackList.Count;
		}

		// Token: 0x0401CCBA RID: 117946
		[Nullable(2)]
		private InputIdentification InputIdentification;

		// Token: 0x0401CCBB RID: 117947
		private readonly List<TInputHandle<T>> CallbackList = new List<TInputHandle<T>>();

		// Token: 0x0401CCBC RID: 117948
		private readonly List<TInputHandle<T>> PendingAddCallbackList = new List<TInputHandle<T>>();

		// Token: 0x0401CCBD RID: 117949
		private readonly List<TInputHandle<T>> PendingRemoveCallbackList = new List<TInputHandle<T>>();

		// Token: 0x0401CCBE RID: 117950
		private bool IsCalling;
	}
}
