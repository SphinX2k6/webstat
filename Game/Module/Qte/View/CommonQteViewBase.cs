using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Qte.View
{
	// Token: 0x02005347 RID: 21319
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class CommonQteViewBase : UiTickViewBase
	{
		// Token: 0x06036617 RID: 222743 RVA: 0x00DB59A0 File Offset: 0x00DB3BA0
		protected CommonQteViewBase(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06036618 RID: 222744
		public abstract void SetQteContext(CommonQteContextBase context);

		// Token: 0x06036619 RID: 222745
		public abstract void PlayQteStart();

		// Token: 0x0603661A RID: 222746
		public abstract void OnInputTest();
	}
}
