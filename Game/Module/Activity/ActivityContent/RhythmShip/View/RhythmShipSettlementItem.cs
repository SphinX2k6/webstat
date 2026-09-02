using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x02006519 RID: 25881
	internal class RhythmShipSettlementItem : GridProxyAbstract<ValueTuple<int, int>>
	{
		// Token: 0x06040BC7 RID: 265159 RVA: 0x010999D2 File Offset: 0x01097BD2
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
		}

		// Token: 0x06040BC8 RID: 265160 RVA: 0x01099A0B File Offset: 0x01097C0B
		public override void Refresh(ValueTuple<int, int> data, bool isSelected, int gridIndex)
		{
			base.GetText(0).SetText(RhythmShipDefine.rhythmShipSettlementText[data.Item1], true);
			base.GetText(1).SetText(data.Item2.ToString(), true);
		}
	}
}
