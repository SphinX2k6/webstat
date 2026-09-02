using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200512B RID: 20779
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoguelikeAchieveSmallTokenGrid : LoopScrollSmallItemGrid<RogueGainEntry>
	{
		// Token: 0x060357FE RID: 219134 RVA: 0x00D6E557 File Offset: 0x00D6C757
		protected override void OnStart()
		{
			base.SetToggleInteractive(false);
			base.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
		}

		// Token: 0x060357FF RID: 219135 RVA: 0x00D6E588 File Offset: 0x00D6C788
		protected override void OnRefresh(RogueGainEntry data, bool isSelected, int gridIndex)
		{
			RogueBuffPool? rogueBuffConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueBuffConfig(data.ConfigId);
			PropSmallItemGrid parameters = new PropSmallItemGrid
			{
				Data = data,
				IconPath = rogueBuffConfig.Value.BuffIcon,
				QualityId = new int?(rogueBuffConfig.Value.Quality)
			};
			base.Apply<PropSmallItemGrid>(parameters);
		}
	}
}
