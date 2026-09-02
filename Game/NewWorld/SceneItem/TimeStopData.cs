using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Pawn.Component;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x02004812 RID: 18450
	public class TimeStopData
	{
		// Token: 0x06030030 RID: 196656 RVA: 0x00BA0026 File Offset: 0x00B9E226
		[NullableContext(1)]
		public TimeStopData(PawnTimeScaleComponent timeScaleComponent, int timeScaleId, bool isSceneItem)
		{
			this.TimeScaleComponent = timeScaleComponent;
			this.TimeScaleId = new int?(timeScaleId);
			this.IsSceneItem = isSceneItem;
		}

		// Token: 0x0401B8ED RID: 112877
		[Nullable(2)]
		public PawnTimeScaleComponent TimeScaleComponent;

		// Token: 0x0401B8EE RID: 112878
		public int? TimeScaleId;

		// Token: 0x0401B8EF RID: 112879
		public bool IsSceneItem;
	}
}
