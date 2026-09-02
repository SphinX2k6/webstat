using System;
using CSharpScript.Game.NewWorld.Pawn.Component;

namespace CSharpScript.Game.Utils
{
	// Token: 0x020046FC RID: 18172
	public class TimeScaleUtils
	{
		// Token: 0x0602F410 RID: 193552 RVA: 0x00B34CF2 File Offset: 0x00B32EF2
		public static int GetTimeScalePriority(ETimeScaleSourceType type)
		{
			return (int)(type * (ETimeScaleSourceType)100);
		}

		// Token: 0x0401AEC0 RID: 110272
		private const int PRIORITY_EXTEND = 100;
	}
}
