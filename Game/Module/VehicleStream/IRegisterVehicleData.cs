using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.Module.VehicleStream
{
	// Token: 0x02004C45 RID: 19525
	[NullableContext(1)]
	public interface IRegisterVehicleData
	{
		// Token: 0x17008751 RID: 34641
		// (get) Token: 0x06032E08 RID: 208392
		int VehiclePbDataId { get; }

		// Token: 0x17008752 RID: 34642
		// (get) Token: 0x06032E09 RID: 208393
		int StartRoadId { get; }

		// Token: 0x17008753 RID: 34643
		// (get) Token: 0x06032E0A RID: 208394
		int StartRoadIndex { get; }

		// Token: 0x17008754 RID: 34644
		// (get) Token: 0x06032E0B RID: 208395
		int DestRoadId { get; }

		// Token: 0x17008755 RID: 34645
		// (get) Token: 0x06032E0C RID: 208396
		int DestIndex { get; }

		// Token: 0x17008756 RID: 34646
		// (get) Token: 0x06032E0D RID: 208397
		Vector ActorLocation { get; }

		// Token: 0x17008757 RID: 34647
		// (get) Token: 0x06032E0E RID: 208398
		Rotator ActorRotator { get; }

		// Token: 0x17008758 RID: 34648
		// (get) Token: 0x06032E0F RID: 208399
		ITrafficNavigationConfig BaseConfig { get; }
	}
}
