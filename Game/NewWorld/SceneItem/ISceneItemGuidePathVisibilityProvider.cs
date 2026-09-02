using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x020047DE RID: 18398
	[NullableContext(1)]
	public interface ISceneItemGuidePathVisibilityProvider
	{
		// Token: 0x170081DF RID: 33247
		// (get) Token: 0x0602FBAB RID: 195499
		// (set) Token: 0x0602FBAC RID: 195500
		Func<bool> IsVisible { get; set; }

		// Token: 0x170081E0 RID: 33248
		// (get) Token: 0x0602FBAD RID: 195501
		// (set) Token: 0x0602FBAE RID: 195502
		[Nullable(2)]
		Action OnDetached { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
