using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Common.MediumItemGrid
{
	// Token: 0x02005E56 RID: 24150
	[NullableContext(2)]
	[Nullable(0)]
	public class EmptyItemGrid : IMediumItemGridBase
	{
		// Token: 0x17009947 RID: 39239
		// (get) Token: 0x0603CCA1 RID: 248993 RVA: 0x00F6FDB6 File Offset: 0x00F6DFB6
		public EMediumItemGridType Type
		{
			get
			{
				return EMediumItemGridType.Empty;
			}
		}

		// Token: 0x040221C4 RID: 139716
		public object Data;

		// Token: 0x040221C5 RID: 139717
		public string BottomTextId;

		// Token: 0x040221C6 RID: 139718
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public object[] BottomTextParameter;

		// Token: 0x040221C7 RID: 139719
		public string BottomText;
	}
}
