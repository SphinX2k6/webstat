using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine
{
	// Token: 0x02006EC1 RID: 28353
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class DollViewCameraInfo
	{
		// Token: 0x1700A3E4 RID: 41956
		// (get) Token: 0x06044BA1 RID: 281505 RVA: 0x011DE0C9 File Offset: 0x011DC2C9
		// (set) Token: 0x06044BA2 RID: 281506 RVA: 0x011DE0D1 File Offset: 0x011DC2D1
		[RequiredMember]
		public Vector Location { get; set; }

		// Token: 0x1700A3E5 RID: 41957
		// (get) Token: 0x06044BA3 RID: 281507 RVA: 0x011DE0DA File Offset: 0x011DC2DA
		// (set) Token: 0x06044BA4 RID: 281508 RVA: 0x011DE0E2 File Offset: 0x011DC2E2
		[RequiredMember]
		public Rotator Rotation { get; set; }

		// Token: 0x1700A3E6 RID: 41958
		// (get) Token: 0x06044BA5 RID: 281509 RVA: 0x011DE0EB File Offset: 0x011DC2EB
		// (set) Token: 0x06044BA6 RID: 281510 RVA: 0x011DE0F3 File Offset: 0x011DC2F3
		[RequiredMember]
		public float Fov { get; set; }

		// Token: 0x06044BA7 RID: 281511 RVA: 0x011DE0FC File Offset: 0x011DC2FC
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public DollViewCameraInfo()
		{
		}
	}
}
