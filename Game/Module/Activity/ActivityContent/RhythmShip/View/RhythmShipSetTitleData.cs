using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x0200650A RID: 25866
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public class RhythmShipSetTitleData : MultiTemplateGridDataBase<RhythmShipSetData, RhythmShipSetTitle>
	{
		// Token: 0x06040B90 RID: 265104 RVA: 0x01098ED4 File Offset: 0x010970D4
		public RhythmShipSetTitleData(RhythmShipSetData data)
		{
			base.Data = data;
		}

		// Token: 0x06040B91 RID: 265105 RVA: 0x01098EE3 File Offset: 0x010970E3
		public override int GetTemplateIndex()
		{
			return 0;
		}

		// Token: 0x06040B92 RID: 265106 RVA: 0x01098EE6 File Offset: 0x010970E6
		public override RhythmShipSetTitle CreateProxy()
		{
			return new RhythmShipSetTitle();
		}
	}
}
