using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x020064F5 RID: 25845
	internal class RhythmShipPauseStarItem : GridProxyAbstract<bool>
	{
		// Token: 0x06040B61 RID: 265057 RVA: 0x01098114 File Offset: 0x01096314
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x06040B62 RID: 265058 RVA: 0x01098137 File Offset: 0x01096337
		public override void Refresh(bool data, bool isSelected, int gridIndex)
		{
			base.GetItem(1).SetUIActive(data);
		}
	}
}
