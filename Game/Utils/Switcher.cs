using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Utils
{
	// Token: 0x020046FB RID: 18171
	[NullableContext(1)]
	[Nullable(0)]
	public class Switcher
	{
		// Token: 0x0602F40D RID: 193549 RVA: 0x00B34C5D File Offset: 0x00B32E5D
		[NullableContext(2)]
		public Switcher(bool defaultActive, Action<bool> cb = null)
		{
		}

		// Token: 0x1700815F RID: 33119
		// (get) Token: 0x0602F40E RID: 193550 RVA: 0x00B34C7E File Offset: 0x00B32E7E
		public bool Active
		{
			get
			{
				return this.Handlers.Count > 0 != this.<defaultActive>P;
			}
		}

		// Token: 0x0602F40F RID: 193551 RVA: 0x00B34C9C File Offset: 0x00B32E9C
		public void SetActive(object handler, bool active)
		{
			bool active2 = this.Active;
			if (this.<defaultActive>P != active)
			{
				this.Handlers.Add(handler);
			}
			else
			{
				this.Handlers.Remove(handler);
			}
			if (active2 != this.Active)
			{
				Action<bool> action = this.<cb>P;
				if (action == null)
				{
					return;
				}
				action(this.Active);
			}
		}

		// Token: 0x0401AEBD RID: 110269
		[CompilerGenerated]
		private bool <defaultActive>P = defaultActive;

		// Token: 0x0401AEBE RID: 110270
		[Nullable(2)]
		[CompilerGenerated]
		private Action<bool> <cb>P = cb;

		// Token: 0x0401AEBF RID: 110271
		private readonly HashSet<object> Handlers = new HashSet<object>();
	}
}
