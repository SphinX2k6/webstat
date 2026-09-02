using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.PrizeDrawing.Components.TearItem
{
	// Token: 0x0200656F RID: 25967
	[NullableContext(1)]
	[Nullable(0)]
	internal static class PrizeDrawingTearCoverItemConstants
	{
		// Token: 0x04024661 RID: 149089
		public static readonly float[] ShineDissolve = new float[]
		{
			0.2f,
			0.3f,
			0.4f,
			0.5f,
			1f
		};

		// Token: 0x04024662 RID: 149090
		public static readonly float[] GlowMaskOffsetV = new float[]
		{
			-2.5f,
			-2f,
			-1.5f,
			-1.3f,
			-0.6f
		};

		// Token: 0x04024663 RID: 149091
		public static readonly float[] GlowAlpha = new float[]
		{
			1f,
			0.9f,
			0.7f,
			0.5f,
			0.25f
		};

		// Token: 0x04024664 RID: 149092
		public static readonly FName GLOW_MASK_UV_NAME = new FName("MaskUV");

		// Token: 0x04024665 RID: 149093
		public const float DEFAULT_GLOW_MASK_UV_OFFSET = -4f;

		// Token: 0x04024666 RID: 149094
		public const string AUDIO_TEAR_FIRST = "play_ui_prizedrawing_ticket_tear_new_click";

		// Token: 0x04024667 RID: 149095
		public const string AUDIO_TEAR_AGAIN = "play_ui_prizedrawing_ticket_tear_torn_click";

		// Token: 0x04024668 RID: 149096
		public const string AUDIO_TEAR_BACK = "play_ui_prizedrawing_ticket_tear_back";

		// Token: 0x04024669 RID: 149097
		public const string AUDIO_TEAR_LOOP = "play_ui_prizedrawing_ticket_bigprize_light_loop";

		// Token: 0x0402466A RID: 149098
		public const string AUDIO_TEAR_LOOP_STOP = "stop_ui_prizedrawing_ticket_bigprize_light_loop";

		// Token: 0x0402466B RID: 149099
		public const string AUDIO_TEAR_OPEN = "play_ui_prizedrawing_ticket_bigprize_light_finish";

		// Token: 0x0402466C RID: 149100
		public const string AUDIO_TEAR_OPEN_MINOR = "play_ui_prizedrawing_ticket_normalprize_light_finish";

		// Token: 0x0402466D RID: 149101
		public const string AUDIO_TEAR_START = "play_ui_prizedrawing_ticket_bigprize_light_start";

		// Token: 0x0402466E RID: 149102
		public const string AUDIO_RTPC_TEAR = "sys_game_prizedrawing_ticket_torn";

		// Token: 0x0402466F RID: 149103
		public const int AUDIO_FADE_OUT_TIME = 1000;

		// Token: 0x04024670 RID: 149104
		public const float DRAG_START_DISTANCE = 0.1f;
	}
}
