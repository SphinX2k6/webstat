using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.SplineMoveTask
{
	// Token: 0x02006AC8 RID: 27336
	public class SceneItemSplineMoveSegmentConstantTimeConfig : ISceneItemSplineMoveSegmentConfig
	{
		// Token: 0x1700A29A RID: 41626
		// (get) Token: 0x0604397C RID: 276860 RVA: 0x011708A8 File Offset: 0x0116EAA8
		[Obsolete]
		public ESceneItemSplineMoveSegmentConfigType Type
		{
			get
			{
				return ESceneItemSplineMoveSegmentConfigType.ConstantTime;
			}
		}

		// Token: 0x1700A29B RID: 41627
		// (get) Token: 0x0604397D RID: 276861 RVA: 0x011708AB File Offset: 0x0116EAAB
		// (set) Token: 0x0604397E RID: 276862 RVA: 0x011708B3 File Offset: 0x0116EAB3
		public float? WaitTime { get; set; }

		// Token: 0x04025C6D RID: 154733
		public float Time;

		// Token: 0x04025C6E RID: 154734
		[Nullable(2)]
		public string TimeDisCurve;
	}
}
