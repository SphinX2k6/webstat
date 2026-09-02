using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x020064EC RID: 25836
	internal class StarItem : GridProxyAbstract<bool>
	{
		// Token: 0x06040B46 RID: 265030 RVA: 0x010978D6 File Offset: 0x01095AD6
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x06040B47 RID: 265031 RVA: 0x010978F9 File Offset: 0x01095AF9
		public override void Refresh(bool data, bool isSelected, int gridIndex)
		{
			base.GetItem(1).SetUIActive(data);
		}
	}
}
