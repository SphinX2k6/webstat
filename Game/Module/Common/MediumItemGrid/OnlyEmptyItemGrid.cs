using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Common.MediumItemGrid
{
	// Token: 0x02005E57 RID: 24151
	public class OnlyEmptyItemGrid : IMediumItemGridBase
	{
		// Token: 0x17009948 RID: 39240
		// (get) Token: 0x0603CCA3 RID: 248995 RVA: 0x00F6FDC1 File Offset: 0x00F6DFC1
		public EMediumItemGridType Type
		{
			get
			{
				return EMediumItemGridType.OnlyEmpty;
			}
		}

		// Token: 0x040221C8 RID: 139720
		[Nullable(2)]
		public Action OnClickedCallback;

		// Token: 0x040221C9 RID: 139721
		public bool? IsClickable;

		// Token: 0x040221CA RID: 139722
		[Nullable(2)]
		public object Data;
	}
}
