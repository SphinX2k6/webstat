using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x020047DF RID: 18399
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class SceneItemGuidePathVisibilityProvider : ISceneItemGuidePathVisibilityProvider
	{
		// Token: 0x170081E1 RID: 33249
		// (get) Token: 0x0602FBAF RID: 195503 RVA: 0x00B6E235 File Offset: 0x00B6C435
		// (set) Token: 0x0602FBB0 RID: 195504 RVA: 0x00B6E23D File Offset: 0x00B6C43D
		[RequiredMember]
		public Func<bool> IsVisible { get; set; }

		// Token: 0x170081E2 RID: 33250
		// (get) Token: 0x0602FBB1 RID: 195505 RVA: 0x00B6E246 File Offset: 0x00B6C446
		// (set) Token: 0x0602FBB2 RID: 195506 RVA: 0x00B6E24E File Offset: 0x00B6C44E
		[Nullable(2)]
		public Action OnDetached { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x0602FBB3 RID: 195507 RVA: 0x00B6E257 File Offset: 0x00B6C457
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public SceneItemGuidePathVisibilityProvider()
		{
		}
	}
}
