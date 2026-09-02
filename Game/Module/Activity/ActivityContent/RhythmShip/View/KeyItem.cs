using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x02006513 RID: 25875
	internal class KeyItem : GridProxyAbstract<int>
	{
		// Token: 0x06040BAD RID: 265133 RVA: 0x01099374 File Offset: 0x01097574
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
		}

		// Token: 0x06040BAE RID: 265134 RVA: 0x010993B0 File Offset: 0x010975B0
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			RhythmShipAction? rhythmShipActionById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipActionById(data);
			if (rhythmShipActionById == null)
			{
				return;
			}
			base.SetTextureByPath(rhythmShipActionById.Value.Icon, base.GetTexture(0), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), rhythmShipActionById.Value.Name, Array.Empty<object>());
		}
	}
}
