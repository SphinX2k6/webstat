using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EAA RID: 20138
	public class TowerDefenseRankOwnerItemV2 : TowerDefenseRankItemV2
	{
		// Token: 0x06034079 RID: 213113 RVA: 0x00D04598 File Offset: 0x00D02798
		protected override void RefreshRankBg()
		{
			UUITexture texture = base.GetTexture(0);
			texture.SetUIActive(true);
			string resourceId = this.RankItemData.IsTopThree ? this.RankItemData.RankBg : "T_oNlineLordGymRankBgNor";
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			base.SetTextureByPath(resourcePath, texture, null, null);
		}

		// Token: 0x0401E113 RID: 123155
		[Nullable(1)]
		private const string OwnerNormalRankBg = "T_oNlineLordGymRankBgNor";
	}
}
