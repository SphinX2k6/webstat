using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move.AttachMove
{
	// Token: 0x0200493F RID: 18751
	[NullableContext(2)]
	[Nullable(0)]
	public class AttachMoveRelation
	{
		// Token: 0x0401C399 RID: 115609
		[Nullable(1)]
		public string Key = "";

		// Token: 0x0401C39A RID: 115610
		public CharacterActorComponent Leader;

		// Token: 0x0401C39B RID: 115611
		public BaseActorComponent FollowerActor;

		// Token: 0x0401C39C RID: 115612
		public BaseMoveComponent FollowerMoveComp;

		// Token: 0x0401C39D RID: 115613
		public int LeaderEntityId;

		// Token: 0x0401C39E RID: 115614
		public int FollowerEntityId;

		// Token: 0x0401C39F RID: 115615
		public Action StopFn;
	}
}
