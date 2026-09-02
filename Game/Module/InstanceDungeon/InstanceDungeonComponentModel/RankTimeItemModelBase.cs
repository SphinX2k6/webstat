using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonComponentModel
{
	// Token: 0x02005BFD RID: 23549
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class RankTimeItemModelBase
	{
		// Token: 0x0603B95C RID: 244060 RVA: 0x00F1AFCB File Offset: 0x00F191CB
		public void RefreshInstance(int instanceId)
		{
			this.InstanceId = instanceId;
		}

		// Token: 0x0603B95D RID: 244061 RVA: 0x00F1AFD4 File Offset: 0x00F191D4
		public void ButtonClick()
		{
			this.OnButtonClick();
		}

		// Token: 0x0603B95E RID: 244062 RVA: 0x00F1AFDC File Offset: 0x00F191DC
		public TableTextArgNew GetContent()
		{
			return this.OnGetContent();
		}

		// Token: 0x0603B95F RID: 244063
		protected abstract void OnButtonClick();

		// Token: 0x0603B960 RID: 244064
		protected abstract TableTextArgNew OnGetContent();

		// Token: 0x0402189F RID: 137375
		protected int InstanceId;
	}
}
