using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x020064DF RID: 25823
	internal class RhythmShipChoseStarItem : UiPanelBase
	{
		// Token: 0x06040B0E RID: 264974 RVA: 0x01096237 File Offset: 0x01094437
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x06040B0F RID: 264975 RVA: 0x01096270 File Offset: 0x01094470
		public void SetLightItemActive(bool value)
		{
			base.GetItem(1).SetUIActive(value);
		}
	}
}
