using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x0200650C RID: 25868
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public class RhythmShipSetItemBtnData : MultiTemplateGridDataBase<RhythmShipSetData, RhythmShipSetItemBtn>
	{
		// Token: 0x06040B97 RID: 265111 RVA: 0x01098FBE File Offset: 0x010971BE
		public RhythmShipSetItemBtnData(RhythmShipSetData data)
		{
			base.Data = data;
		}

		// Token: 0x06040B98 RID: 265112 RVA: 0x01098FCD File Offset: 0x010971CD
		public override int GetTemplateIndex()
		{
			return 1;
		}

		// Token: 0x06040B99 RID: 265113 RVA: 0x01098FD0 File Offset: 0x010971D0
		public override RhythmShipSetItemBtn CreateProxy()
		{
			return new RhythmShipSetItemBtn();
		}
	}
}
