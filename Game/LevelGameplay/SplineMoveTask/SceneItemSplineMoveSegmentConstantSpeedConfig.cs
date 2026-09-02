using System;

namespace CSharpScript.Game.LevelGamePlay.SplineMoveTask
{
	// Token: 0x02006AC7 RID: 27335
	public class SceneItemSplineMoveSegmentConstantSpeedConfig : ISceneItemSplineMoveSegmentConfig
	{
		// Token: 0x1700A298 RID: 41624
		// (get) Token: 0x06043978 RID: 276856 RVA: 0x0117088C File Offset: 0x0116EA8C
		[Obsolete]
		public ESceneItemSplineMoveSegmentConfigType Type
		{
			get
			{
				return ESceneItemSplineMoveSegmentConfigType.ConstantSpeed;
			}
		}

		// Token: 0x1700A299 RID: 41625
		// (get) Token: 0x06043979 RID: 276857 RVA: 0x0117088F File Offset: 0x0116EA8F
		// (set) Token: 0x0604397A RID: 276858 RVA: 0x01170897 File Offset: 0x0116EA97
		public float? WaitTime { get; set; }

		// Token: 0x04025C6B RID: 154731
		public float Speed;
	}
}
