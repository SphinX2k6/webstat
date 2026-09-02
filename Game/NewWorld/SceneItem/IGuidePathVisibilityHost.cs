using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x020047E1 RID: 18401
	[NullableContext(1)]
	public interface IGuidePathVisibilityHost
	{
		// Token: 0x170081E3 RID: 33251
		// (get) Token: 0x0602FBB4 RID: 195508
		// (set) Token: 0x0602FBB5 RID: 195509
		Action<ISceneItemGuidePathVisibilityProvider, EGuidePathProviderRemovedBehavior?> SetExternalVisibilityProvider { get; set; }

		// Token: 0x170081E4 RID: 33252
		// (get) Token: 0x0602FBB6 RID: 195510
		// (set) Token: 0x0602FBB7 RID: 195511
		Action<ISceneItemGuidePathVisibilityProvider> ClearExternalVisibilityProvider { get; set; }

		// Token: 0x170081E5 RID: 33253
		// (get) Token: 0x0602FBB8 RID: 195512
		// (set) Token: 0x0602FBB9 RID: 195513
		Action<ISceneItemGuidePathVisibilityProvider> NotifyExternalVisibilityChanged { get; set; }

		// Token: 0x170081E6 RID: 33254
		// (get) Token: 0x0602FBBA RID: 195514
		// (set) Token: 0x0602FBBB RID: 195515
		Func<bool> HasExternalVisibilityProvider { get; set; }
	}
}
