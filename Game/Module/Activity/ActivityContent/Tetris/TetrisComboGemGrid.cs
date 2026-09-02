using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062C1 RID: 25281
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class TetrisComboGemGrid : GridProxyAbstract<ITetrisGemGetData>
	{
		// Token: 0x0603F9D3 RID: 260563 RVA: 0x0104DC88 File Offset: 0x0104BE88
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUIArtText))
			};
		}

		// Token: 0x0603F9D4 RID: 260564 RVA: 0x0104DCE4 File Offset: 0x0104BEE4
		public override void Refresh(ITetrisGemGetData data, bool isSelected, int gridIndex)
		{
			TetrisGem? gemConfig = ConfigBase<ActivityTetrisConfig>.Instance.GetGemConfig(data.GemId);
			if (gemConfig == null)
			{
				return;
			}
			this.SetSpriteByPath(gemConfig.Value.BgPath, base.GetSprite(0), false, null, null);
			this.SetSpriteByPath(gemConfig.Value.GemPath, base.GetSprite(1), false, null, null);
			base.GetArtText(2).SetText("+" + data.GetGemCount.ToString());
			UUIArtText artText = base.GetArtText(2);
			if (artText == null)
			{
				return;
			}
			artText.SetColor(FColor.FromHex(TetrisComboPanel.CurrentComboColorHex.ToEnumString()));
		}
	}
}
