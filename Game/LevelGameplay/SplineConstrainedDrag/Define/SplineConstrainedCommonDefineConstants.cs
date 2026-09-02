using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.Define
{
	// Token: 0x02006AEA RID: 27370
	[NullableContext(1)]
	[Nullable(0)]
	public class SplineConstrainedCommonDefineConstants : IStaticVariableResetter
	{
		// Token: 0x06043AD2 RID: 277202 RVA: 0x01173C00 File Offset: 0x01171E00
		private static int GetMagneticCoarseSampleCountByQuality(EGameQualitySettingLevel level)
		{
			int result;
			switch (level)
			{
			case EGameQualitySettingLevel.VeryLow:
				result = 16;
				break;
			case EGameQualitySettingLevel.Low:
				result = 20;
				break;
			case EGameQualitySettingLevel.Middle:
				result = 28;
				break;
			case EGameQualitySettingLevel.High:
				result = 36;
				break;
			case EGameQualitySettingLevel.VeryHigh:
				result = 48;
				break;
			case EGameQualitySettingLevel.Highest:
				result = 64;
				break;
			default:
				<PrivateImplementationDetails>.ThrowSwitchExpressionException(level);
				break;
			}
			return result;
		}

		// Token: 0x06043AD3 RID: 277203 RVA: 0x01173C57 File Offset: 0x01171E57
		static SplineConstrainedCommonDefineConstants()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(SplineConstrainedCommonDefineConstants.CreateStaticDefaultValue), new Action(SplineConstrainedCommonDefineConstants.ResetStaticDefaultValue));
		}

		// Token: 0x06043AD4 RID: 277204 RVA: 0x01173C78 File Offset: 0x01171E78
		public static void CreateStaticDefaultValue()
		{
			SplineConstrainedCommonDefineConstants.magneticCoarseSampleCountByQuality = new Dictionary<EGameQualitySettingLevel, int>();
			foreach (object obj in Enum.GetValues(typeof(EGameQualitySettingLevel)))
			{
				EGameQualitySettingLevel egameQualitySettingLevel = (EGameQualitySettingLevel)obj;
				SplineConstrainedCommonDefineConstants.magneticCoarseSampleCountByQuality[egameQualitySettingLevel] = SplineConstrainedCommonDefineConstants.GetMagneticCoarseSampleCountByQuality(egameQualitySettingLevel);
			}
		}

		// Token: 0x06043AD5 RID: 277205 RVA: 0x01173CF0 File Offset: 0x01171EF0
		public static void ResetStaticDefaultValue()
		{
			SplineConstrainedCommonDefineConstants.magneticCoarseSampleCountByQuality = null;
		}

		// Token: 0x04025CC2 RID: 154818
		public const string DEBUG_KEY = "SplineConstrainedDrag";

		// Token: 0x04025CC3 RID: 154819
		public const int DEBUG_DRAW_SEGMENTS = 16;

		// Token: 0x04025CC4 RID: 154820
		public const int DEBUG_DRAW_DURATION = 0;

		// Token: 0x04025CC5 RID: 154821
		public const int DEBUG_MAGNETIC_SPHERE_RADIUS = 20;

		// Token: 0x04025CC6 RID: 154822
		public const int DEBUG_TEXT_VERTICAL_OFFSET = 80;

		// Token: 0x04025CC7 RID: 154823
		public const int GAMEPAD_AXIS_TO_PIXEL_PER_SECOND = 800;

		// Token: 0x04025CC8 RID: 154824
		public const float GAMEPAD_AXIS_DEADZONE = 0.05f;

		// Token: 0x04025CC9 RID: 154825
		public const float DRAGGABLE_SELECTED_MOVING_SPEED_THRESHOLD = 0.1f;

		// Token: 0x04025CCA RID: 154826
		public const float DRAGGABLE_MOVING_LATCH_RELEASE_DELAY_SECONDS = 0.2f;

		// Token: 0x04025CCB RID: 154827
		public const int MAGNETIC_TIMER_INTERVAL_MS = 20;

		// Token: 0x04025CCC RID: 154828
		public const float MIN_ACTOR_SCREEN_PX = 1f;

		// Token: 0x04025CCD RID: 154829
		public const int MAX_SCREEN_DEGENERATE_FRAMES = 5;

		// Token: 0x04025CCE RID: 154830
		public const float MAX_STEP_SECONDS = 0.033333335f;

		// Token: 0x04025CCF RID: 154831
		public const float CONVERGE_SPEED_THRESHOLD = 0.01f;

		// Token: 0x04025CD0 RID: 154832
		public const float CONVERGE_POS_THRESHOLD = 0.5f;

		// Token: 0x04025CD1 RID: 154833
		public const int MAGNETIC_STIFFNESS = 50;

		// Token: 0x04025CD2 RID: 154834
		public const int MAGNETIC_DAMPING = 10;

		// Token: 0x04025CD3 RID: 154835
		public const int MAGNETIC_BUFFER_CAPACITY = 128;

		// Token: 0x04025CD4 RID: 154836
		public static Dictionary<EGameQualitySettingLevel, int> magneticCoarseSampleCountByQuality;

		// Token: 0x04025CD5 RID: 154837
		public const double MAGNETIC_COARSE_SAMPLE_MIN_DISTANCE = 0.5;

		// Token: 0x04025CD6 RID: 154838
		public const string DRAGGABLE_STATE_PARAM_NAME_STATE1 = "EnableState1";

		// Token: 0x04025CD7 RID: 154839
		public const string DRAGGABLE_STATE_PARAM_NAME_STATE2 = "EnableState2";

		// Token: 0x04025CD8 RID: 154840
		public const string DRAGGABLE_STATE_PARAM_NAME_STATE3 = "EnableState3";

		// Token: 0x04025CD9 RID: 154841
		public const string DRAG_ACTOR_PLAY_GUIDE_ID_KEY = "DragActorPlayGuideGroupId";

		// Token: 0x04025CDA RID: 154842
		public const int DEFAULT_DRAG_ACTOR_PLAY_GUIDE_ID = 10001;
	}
}
