using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Card
{
	// Token: 0x02005621 RID: 22049
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaCardComponentLogic
	{
		// Token: 0x06038323 RID: 230179 RVA: 0x00E3B05F File Offset: 0x00E3925F
		public void SetCardShowComponent(PhantomArenaCardShowComponent component)
		{
			this.Component = component;
			this.SetActive(this.IsActive);
		}

		// Token: 0x06038324 RID: 230180 RVA: 0x00E3B074 File Offset: 0x00E39274
		public void SetActive(bool isActive)
		{
			this.IsActive = isActive;
			if (this.Component == null)
			{
				return;
			}
			if (!isActive)
			{
				this.Component.PlayClose();
				return;
			}
			if (this.IsNeedAutoHide)
			{
				this.Component.PlayStart();
				return;
			}
			this.Component.PlayLoop();
		}

		// Token: 0x0402018F RID: 131471
		protected PhantomArenaCardShowComponent Component;

		// Token: 0x04020190 RID: 131472
		protected bool IsActive;

		// Token: 0x04020191 RID: 131473
		public bool IsNeedAutoHide = true;
	}
}
