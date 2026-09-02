using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop
{
	// Token: 0x02005082 RID: 20610
	[NullableContext(1)]
	public interface IRoleDevelopCategoryData
	{
		// Token: 0x17008BA3 RID: 35747
		// (get) Token: 0x06035235 RID: 217653
		// (set) Token: 0x06035236 RID: 217654
		ERoleDevelopCategoryType CategoryType { get; set; }

		// Token: 0x17008BA4 RID: 35748
		// (get) Token: 0x06035237 RID: 217655
		// (set) Token: 0x06035238 RID: 217656
		string CategoryName { get; set; }
	}
}
