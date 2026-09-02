using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D78 RID: 19832
	public abstract class HotKeyTypeBase : UiPanelBase
	{
		// Token: 0x060335F5 RID: 210421 RVA: 0x00CD9ABE File Offset: 0x00CD7CBE
		public void SetIsMultiKeyItem(bool isMultiKeyItem)
		{
			this.IsMultiKeyItem = isMultiKeyItem;
		}

		// Token: 0x060335F6 RID: 210422 RVA: 0x00CD9AC7 File Offset: 0x00CD7CC7
		public void Clear()
		{
			this.OnClear();
		}

		// Token: 0x060335F7 RID: 210423 RVA: 0x00CD9ACF File Offset: 0x00CD7CCF
		protected virtual void OnClear()
		{
		}

		// Token: 0x060335F8 RID: 210424
		[return: Nullable(new byte[]
		{
			1,
			2
		})]
		public abstract List<HotKeyComponent> GetHotKeyComponents();

		// Token: 0x060335F9 RID: 210425
		public abstract void KeyItemNotifySetActive(bool value);

		// Token: 0x0401DC7D RID: 121981
		protected bool IsMultiKeyItem;
	}
}
