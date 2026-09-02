using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006012 RID: 24594
	public abstract class FormationExtraButton : BattleChildView
	{
		// Token: 0x0603DF8D RID: 253837 RVA: 0x00FD07BF File Offset: 0x00FCE9BF
		[NullableContext(1)]
		public virtual void InitHandle(FormationUnitNodeHandle handle)
		{
			this.Handle = handle;
		}

		// Token: 0x0603DF8E RID: 253838 RVA: 0x00FD07C8 File Offset: 0x00FCE9C8
		public virtual void SetVisible(bool visibility)
		{
			this.SetActive(visibility);
			FormationUnitNodeHandle handle = this.Handle;
			if (handle == null)
			{
				return;
			}
			handle.SetNodeVisible(visibility);
		}

		// Token: 0x0603DF8F RID: 253839 RVA: 0x00FD07E2 File Offset: 0x00FCE9E2
		public virtual void Tick(float delta)
		{
		}

		// Token: 0x04022C24 RID: 142372
		[Nullable(2)]
		protected FormationUnitNodeHandle Handle;
	}
}
