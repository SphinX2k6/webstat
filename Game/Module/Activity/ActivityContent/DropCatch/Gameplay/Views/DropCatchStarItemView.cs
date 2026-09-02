using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views
{
	// Token: 0x02006918 RID: 26904
	public class DropCatchStarItemView : GridProxyAbstract<bool>
	{
		// Token: 0x06042D11 RID: 273681 RVA: 0x01126A96 File Offset: 0x01124C96
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUISprite))
			};
		}

		// Token: 0x06042D12 RID: 273682 RVA: 0x01126ACF File Offset: 0x01124CCF
		public override void Refresh(bool data, bool isSelected, int gridIndex)
		{
			UUISprite sprite = base.GetSprite(1);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(data);
		}

		// Token: 0x06042D13 RID: 273683 RVA: 0x01126AE3 File Offset: 0x01124CE3
		public void Refresh(bool isActive)
		{
			UUISprite sprite = base.GetSprite(1);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(isActive);
		}
	}
}
