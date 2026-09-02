using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x0200650E RID: 25870
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public class RhythmShipSetItemSliderData : MultiTemplateGridDataBase<RhythmShipSetData, RhythmShipSetItemSlider>
	{
		// Token: 0x06040BA0 RID: 265120 RVA: 0x01099120 File Offset: 0x01097320
		public RhythmShipSetItemSliderData(RhythmShipSetData data)
		{
			base.Data = data;
		}

		// Token: 0x06040BA1 RID: 265121 RVA: 0x0109912F File Offset: 0x0109732F
		public override int GetTemplateIndex()
		{
			return 2;
		}

		// Token: 0x06040BA2 RID: 265122 RVA: 0x01099132 File Offset: 0x01097332
		public override RhythmShipSetItemSlider CreateProxy()
		{
			return new RhythmShipSetItemSlider
			{
				OnSliderValueChangeCallBack = this.OnSliderValueChangeCallBack
			};
		}

		// Token: 0x040244A0 RID: 148640
		[Nullable(2)]
		public Action<int> OnSliderValueChangeCallBack;
	}
}
