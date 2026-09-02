using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Item
{
	// Token: 0x020068E9 RID: 26857
	public class DropCatchRewardStarItem : GridProxyAbstract<bool>
	{
		// Token: 0x06042BF9 RID: 273401 RVA: 0x01121751 File Offset: 0x0111F951
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUISprite))
			};
		}

		// Token: 0x06042BFA RID: 273402 RVA: 0x0112178A File Offset: 0x0111F98A
		public override void Refresh(bool visible, bool isSelected, int gridIndex)
		{
			base.GetSprite(0).SetUIActive(true);
			base.GetSprite(1).SetUIActive(visible);
		}
	}
}
