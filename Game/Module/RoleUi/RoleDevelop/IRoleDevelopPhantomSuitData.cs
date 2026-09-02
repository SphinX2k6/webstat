using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop
{
	// Token: 0x02005093 RID: 20627
	[NullableContext(1)]
	public interface IRoleDevelopPhantomSuitData
	{
		// Token: 0x17008BC5 RID: 35781
		// (get) Token: 0x0603527F RID: 217727
		// (set) Token: 0x06035280 RID: 217728
		int DevelopRoleId { get; set; }

		// Token: 0x17008BC6 RID: 35782
		// (get) Token: 0x06035281 RID: 217729
		// (set) Token: 0x06035282 RID: 217730
		int FetterGroupId { get; set; }

		// Token: 0x17008BC7 RID: 35783
		// (get) Token: 0x06035283 RID: 217731
		// (set) Token: 0x06035284 RID: 217732
		VisionFetterRecommendInfo VisionFetterRecommendInfo { get; set; }

		// Token: 0x17008BC8 RID: 35784
		// (get) Token: 0x06035285 RID: 217733
		// (set) Token: 0x06035286 RID: 217734
		int? FirstVisionMonsterId { get; set; }

		// Token: 0x17008BC9 RID: 35785
		// (get) Token: 0x06035287 RID: 217735
		// (set) Token: 0x06035288 RID: 217736
		bool? IsNeedFetterButton { get; set; }
	}
}
