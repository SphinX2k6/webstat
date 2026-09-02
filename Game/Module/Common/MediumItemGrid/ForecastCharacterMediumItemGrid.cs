using System;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;

namespace CSharpScript.Game.Module.Common.MediumItemGrid
{
	// Token: 0x02005E5D RID: 24157
	public class ForecastCharacterMediumItemGrid : MediumItemGridBase
	{
		// Token: 0x1700994D RID: 39245
		// (get) Token: 0x0603CCAD RID: 249005 RVA: 0x00F6FDF5 File Offset: 0x00F6DFF5
		public override EMediumItemGridType Type
		{
			get
			{
				return EMediumItemGridType.ForecastCharacter;
			}
		}

		// Token: 0x04022230 RID: 139824
		public ERoleDevelopHotRoleTag? RoleDevTag;
	}
}
