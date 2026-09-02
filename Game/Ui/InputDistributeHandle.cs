using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049F5 RID: 18933
	[NullableContext(1)]
	[Nullable(0)]
	public class InputDistributeHandle<[Nullable(2)] T>
	{
		// Token: 0x06031839 RID: 202809 RVA: 0x00C56CE1 File Offset: 0x00C54EE1
		public InputDistributeHandle(string inputDistributeTag, string name)
		{
			this.InputDistributeTag = inputDistributeTag;
			this.Callback = new InputCallback<T>(name);
			this.IgnoreLimitCallback = new InputCallback<T>(name);
		}

		// Token: 0x0603183A RID: 202810 RVA: 0x00C56D13 File Offset: 0x00C54F13
		public void Reset()
		{
			this.Callback.Clear();
			this.Callback = null;
			this.IgnoreLimitCallback.Clear();
			this.IgnoreLimitCallback = null;
		}

		// Token: 0x0603183B RID: 202811 RVA: 0x00C56D39 File Offset: 0x00C54F39
		protected void Bind(TInputHandle<T> callback)
		{
			this.Callback.Add(callback);
		}

		// Token: 0x0603183C RID: 202812 RVA: 0x00C56D47 File Offset: 0x00C54F47
		public void UnBind(TInputHandle<T> callback)
		{
			this.Callback.Remove(callback);
		}

		// Token: 0x0603183D RID: 202813 RVA: 0x00C56D55 File Offset: 0x00C54F55
		protected void Call(T value)
		{
			this.Callback.Call(value);
		}

		// Token: 0x0603183E RID: 202814 RVA: 0x00C56D63 File Offset: 0x00C54F63
		protected void BindIgnoreLimit(TInputHandle<T> callback)
		{
			this.IgnoreLimitCallback.Add(callback);
		}

		// Token: 0x0603183F RID: 202815 RVA: 0x00C56D71 File Offset: 0x00C54F71
		public void UnBindIgnoreLimit(TInputHandle<T> callback)
		{
			this.IgnoreLimitCallback.Remove(callback);
		}

		// Token: 0x06031840 RID: 202816 RVA: 0x00C56D7F File Offset: 0x00C54F7F
		protected void CallIgnoreLimit(T value)
		{
			this.IgnoreLimitCallback.Call(value);
		}

		// Token: 0x06031841 RID: 202817 RVA: 0x00C56D8D File Offset: 0x00C54F8D
		public bool HasIgnoreLimit()
		{
			return this.IgnoreLimitCallback.Length() > 0;
		}

		// Token: 0x06031842 RID: 202818 RVA: 0x00C56D9D File Offset: 0x00C54F9D
		public bool HasCallback()
		{
			return this.Callback.Length() > 0 || this.IgnoreLimitCallback.Length() > 0;
		}

		// Token: 0x06031843 RID: 202819 RVA: 0x00C56DBD File Offset: 0x00C54FBD
		public string GetInputDistributeTag()
		{
			return this.InputDistributeTag;
		}

		// Token: 0x0401CCBF RID: 117951
		private readonly string InputDistributeTag = "";

		// Token: 0x0401CCC0 RID: 117952
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private InputCallback<T> Callback;

		// Token: 0x0401CCC1 RID: 117953
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private InputCallback<T> IgnoreLimitCallback;
	}
}
