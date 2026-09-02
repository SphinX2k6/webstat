using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Capability;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.LevelplayCapability
{
	// Token: 0x02006CA3 RID: 27811
	[NullableContext(2)]
	[Nullable(0)]
	public class DragActorPlayCameraConfigDataComponent : CapabilityData
	{
		// Token: 0x0604433F RID: 279359 RVA: 0x011B3B37 File Offset: 0x011B1D37
		public DragActorPlayCameraConfigDataComponent(ICapabilityGameObject ownerGameObject = null) : base(ownerGameObject)
		{
		}

		// Token: 0x06044340 RID: 279360 RVA: 0x011B3B40 File Offset: 0x011B1D40
		public override void OnAdded()
		{
		}

		// Token: 0x06044341 RID: 279361 RVA: 0x011B3B42 File Offset: 0x011B1D42
		public override void OnRemoved()
		{
		}

		// Token: 0x040260AC RID: 155820
		public IFixedCameraConfig CameraConfig;
	}
}
