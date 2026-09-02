using System;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.LinkageReward
{
	// Token: 0x02006759 RID: 26457
	internal sealed class LinkageRewardActivityTitle : ActivityTitleTypeA
	{
		// Token: 0x06041F37 RID: 270135 RVA: 0x010EB618 File Offset: 0x010E9818
		public void ApplyLinkageSubTitleVisible(bool bVisible)
		{
			UUIText text = base.GetText(3);
			if (text == null)
			{
				return;
			}
			text.SetUIActive(bVisible);
		}

		// Token: 0x04024CC0 RID: 150720
		private const int SubTitleComponentId = 3;
	}
}
