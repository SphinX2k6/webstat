using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.MovieMode
{
	// Token: 0x020056F3 RID: 22259
	[NullableContext(1)]
	[Nullable(0)]
	public class MovieModeUtil
	{
		// Token: 0x06038A5D RID: 232029 RVA: 0x00E58148 File Offset: 0x00E56348
		public static void ApplyAspectOffsetToUi(IUiItemAspectOffsetConfig config, bool isApply, [Nullable(2)] IMovieModeAspectOffset aspectOffset)
		{
			if (aspectOffset == null || !isApply)
			{
				config.UiItem.SetAnchorOffsetX((float)config.OriginalOffset.X);
				config.UiItem.SetAnchorOffsetY((float)config.OriginalOffset.Y);
				return;
			}
			float offset = aspectOffset.Offset;
			bool isWidthBlend = aspectOffset.IsWidthBlend;
			float num = MovieModeUtil.CalculateOffset(config.OriginalOffset, isWidthBlend, offset, config.OffsetWidthDirection, config.OffsetHeightDirection);
			if (isWidthBlend)
			{
				config.UiItem.SetAnchorOffsetX(num);
				return;
			}
			config.UiItem.SetAnchorOffsetY(num);
		}

		// Token: 0x06038A5E RID: 232030 RVA: 0x00E581D0 File Offset: 0x00E563D0
		private static float CalculateOffset(Vector2D baseOffset, bool isWidthBlend, float offset, float offsetWidthDirection, float offsetHeightDirection)
		{
			float num = isWidthBlend ? ((float)baseOffset.X) : ((float)baseOffset.Y);
			float num2 = isWidthBlend ? (offsetWidthDirection * offset) : (offsetHeightDirection * offset);
			return num + num2;
		}
	}
}
