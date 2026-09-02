using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004C8A RID: 19594
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class FindActionBase
	{
		// Token: 0x06033141 RID: 209217
		public abstract void FindNavigation(FindNavigationResult result);

		// Token: 0x06033142 RID: 209218 RVA: 0x00CCB0E8 File Offset: 0x00CC92E8
		public void AddParam(object[] param)
		{
			object[] array = new object[this.Params.Length + param.Length];
			this.Params.CopyTo(array, 0);
			param.CopyTo(array, this.Params.Length);
			this.Params = array;
		}

		// Token: 0x0401DB51 RID: 121681
		protected object[] Params = new object[0];

		// Token: 0x0401DB52 RID: 121682
		[Nullable(2)]
		public TsUiNavigationPanelConfig PanelConfig;
	}
}
