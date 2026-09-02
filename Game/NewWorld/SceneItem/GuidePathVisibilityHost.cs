using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x020047E2 RID: 18402
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class GuidePathVisibilityHost : IGuidePathVisibilityHost
	{
		// Token: 0x170081E7 RID: 33255
		// (get) Token: 0x0602FBBC RID: 195516 RVA: 0x00B6E25F File Offset: 0x00B6C45F
		// (set) Token: 0x0602FBBD RID: 195517 RVA: 0x00B6E267 File Offset: 0x00B6C467
		[RequiredMember]
		public Action<ISceneItemGuidePathVisibilityProvider, EGuidePathProviderRemovedBehavior?> SetExternalVisibilityProvider { get; set; }

		// Token: 0x170081E8 RID: 33256
		// (get) Token: 0x0602FBBE RID: 195518 RVA: 0x00B6E270 File Offset: 0x00B6C470
		// (set) Token: 0x0602FBBF RID: 195519 RVA: 0x00B6E278 File Offset: 0x00B6C478
		[RequiredMember]
		public Action<ISceneItemGuidePathVisibilityProvider> ClearExternalVisibilityProvider { get; set; }

		// Token: 0x170081E9 RID: 33257
		// (get) Token: 0x0602FBC0 RID: 195520 RVA: 0x00B6E281 File Offset: 0x00B6C481
		// (set) Token: 0x0602FBC1 RID: 195521 RVA: 0x00B6E289 File Offset: 0x00B6C489
		[RequiredMember]
		public Action<ISceneItemGuidePathVisibilityProvider> NotifyExternalVisibilityChanged { get; set; }

		// Token: 0x170081EA RID: 33258
		// (get) Token: 0x0602FBC2 RID: 195522 RVA: 0x00B6E292 File Offset: 0x00B6C492
		// (set) Token: 0x0602FBC3 RID: 195523 RVA: 0x00B6E29A File Offset: 0x00B6C49A
		[RequiredMember]
		public Func<bool> HasExternalVisibilityProvider { get; set; }

		// Token: 0x0602FBC4 RID: 195524 RVA: 0x00B6E2A3 File Offset: 0x00B6C4A3
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public GuidePathVisibilityHost()
		{
		}
	}
}
