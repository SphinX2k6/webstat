using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x0200652D RID: 25901
	[NullableContext(1)]
	[Nullable(0)]
	public class IAreaTaskItemData
	{
		// Token: 0x0402451E RID: 148766
		public RealmBetweenAreaData AreaData;

		// Token: 0x0402451F RID: 148767
		public ActivityTaskData TaskData;

		// Token: 0x04024520 RID: 148768
		public int? UnlockJumpId;

		// Token: 0x04024521 RID: 148769
		[Nullable(2)]
		public string UnlockHintText;
	}
}
