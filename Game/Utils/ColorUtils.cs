using System;
using UnrealEngine;

namespace CSharpScript.Game.Utils
{
	// Token: 0x020046F3 RID: 18163
	public static class ColorUtils
	{
		// Token: 0x0401AE90 RID: 110224
		private const byte MAX_BYTE = 255;

		// Token: 0x0401AE91 RID: 110225
		public static readonly FLinearColor LinearYellow = new FLinearColor(1f, 1f, 0f, 0f);

		// Token: 0x0401AE92 RID: 110226
		public static readonly FLinearColor LinearGreen = new FLinearColor(0f, 1f, 0f, 0f);

		// Token: 0x0401AE93 RID: 110227
		public static readonly FLinearColor LinearRed = new FLinearColor(1f, 0f, 0f, 0f);

		// Token: 0x0401AE94 RID: 110228
		public static readonly FLinearColor LinearBlue = new FLinearColor(0f, 0f, 1f, 0f);

		// Token: 0x0401AE95 RID: 110229
		public static readonly FLinearColor LinearWhite = new FLinearColor(1f, 1f, 1f, 0f);

		// Token: 0x0401AE96 RID: 110230
		public static readonly FLinearColor LinearWhiteOpaque = new FLinearColor(1f, 1f, 1f, 1f);

		// Token: 0x0401AE97 RID: 110231
		public static readonly FLinearColor LinearCyan = new FLinearColor(0f, 1f, 1f, 0f);

		// Token: 0x0401AE98 RID: 110232
		public static readonly FLinearColor LinearBlack = new FLinearColor(0f, 0f, 0f, 1f);

		// Token: 0x0401AE99 RID: 110233
		public static readonly FLinearColor LinearClear = new FLinearColor(0f, 0f, 0f, 0f);

		// Token: 0x0401AE9A RID: 110234
		public static readonly FColor ColorWhile = new FColor(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

		// Token: 0x0401AE9B RID: 110235
		public static readonly FColor ColorBlack = new FColor(0, 0, 0, byte.MaxValue);

		// Token: 0x0401AE9C RID: 110236
		public static readonly FColor ColorYellow = new FColor(byte.MaxValue, byte.MaxValue, 0, 0);

		// Token: 0x0401AE9D RID: 110237
		public static readonly FColor ColorRed = new FColor(byte.MaxValue, 0, 0, 0);
	}
}
