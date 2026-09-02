using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D76 RID: 19830
	public abstract class HotKeyItem : UiPanelBase
	{
		// Token: 0x060335E9 RID: 210409
		[return: Nullable(new byte[]
		{
			1,
			2
		})]
		public abstract List<HotKeyComponent> GetHotKeyComponentArray();

		// Token: 0x060335EA RID: 210410 RVA: 0x00CD8EAB File Offset: 0x00CD70AB
		public void Clear()
		{
			this.OnClear();
		}

		// Token: 0x060335EB RID: 210411 RVA: 0x00CD8EB3 File Offset: 0x00CD70B3
		protected virtual void OnClear()
		{
		}
	}
}
