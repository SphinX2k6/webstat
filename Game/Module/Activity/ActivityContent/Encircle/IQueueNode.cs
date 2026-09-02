using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Encircle
{
	// Token: 0x0200685B RID: 26715
	[NullableContext(1)]
	public interface IQueueNode
	{
		// Token: 0x1700A198 RID: 41368
		// (get) Token: 0x0604297A RID: 272762
		// (set) Token: 0x0604297B RID: 272763
		IHexPos Point { get; set; }

		// Token: 0x1700A199 RID: 41369
		// (get) Token: 0x0604297C RID: 272764
		// (set) Token: 0x0604297D RID: 272765
		[Nullable(2)]
		IQueueNode Next { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
