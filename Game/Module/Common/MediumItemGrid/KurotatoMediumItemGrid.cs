using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Kurotato;

namespace CSharpScript.Game.Module.Common.MediumItemGrid
{
	// Token: 0x02005E5E RID: 24158
	public class KurotatoMediumItemGrid : MediumItemGridBase
	{
		// Token: 0x1700994E RID: 39246
		// (get) Token: 0x0603CCAF RID: 249007 RVA: 0x00F6FE00 File Offset: 0x00F6E000
		public override EMediumItemGridType Type
		{
			get
			{
				return EMediumItemGridType.Kurotato;
			}
		}

		// Token: 0x04022231 RID: 139825
		public int Id;

		// Token: 0x04022232 RID: 139826
		public EKurotatoCardType CardType;

		// Token: 0x04022233 RID: 139827
		public bool? IsNewVisible;

		// Token: 0x04022234 RID: 139828
		public bool? IsDisable;

		// Token: 0x04022235 RID: 139829
		[Nullable(2)]
		public string RightTopValue;
	}
}
