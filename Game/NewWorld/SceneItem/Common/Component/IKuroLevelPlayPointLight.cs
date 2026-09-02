using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.SceneItem.Common.Component
{
	// Token: 0x0200487C RID: 18556
	[NullableContext(1)]
	public interface IKuroLevelPlayPointLight
	{
		// Token: 0x17008281 RID: 33409
		// (get) Token: 0x06030471 RID: 197745
		// (set) Token: 0x06030472 RID: 197746
		float Radius { get; set; }

		// Token: 0x17008282 RID: 33410
		// (get) Token: 0x06030473 RID: 197747
		// (set) Token: 0x06030474 RID: 197748
		bool IsLit { get; set; }

		// Token: 0x17008283 RID: 33411
		// (get) Token: 0x06030475 RID: 197749
		// (set) Token: 0x06030476 RID: 197750
		Vector Position { get; set; }

		// Token: 0x06030477 RID: 197751
		bool Equals(IKuroLevelPlayPointLight b);
	}
}
