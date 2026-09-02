using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu
{
	// Token: 0x0200574E RID: 22350
	[NullableContext(1)]
	[Nullable(0)]
	public static class MenuDefine
	{
		// Token: 0x04020647 RID: 132679
		[StaticVariableRuleIgnore]
		public static readonly HashSet<EFunction> cloudGameImageShowSettingsSet = new HashSet<EFunction>
		{
			EFunction.MOTIONBLUR,
			EFunction.EnemyHitDisplayMode,
			EFunction.ShowDamage,
			EFunction.DynamicBones,
			EFunction.FlowAdaptation,
			EFunction.TeammateFx,
			EFunction.SkinDamageMode,
			EFunction.BasicGraphicSetting,
			EFunction.AutoExposure,
			EFunction.ImageDisplayMode,
			EFunction.Filter,
			EFunction.EyeProtection
		};

		// Token: 0x04020648 RID: 132680
		[StaticVariableRuleIgnore]
		public static readonly HashSet<EFunction> noticeConfigSet = new HashSet<EFunction>
		{
			EFunction.IMAGEQUALITY,
			EFunction.MOBILERESOLUTION,
			EFunction.RESOLUTION,
			EFunction.HIGHESTFPS,
			EFunction.SHADOWQUALITY,
			EFunction.NIAGARAQUALITY,
			EFunction.IMAGEDETAIL,
			EFunction.SCENEAO,
			EFunction.ANTIALISING,
			EFunction.VOLUMEFOG,
			EFunction.VOLUMELIGHT,
			EFunction.MOTIONBLUR,
			EFunction.FSR,
			EFunction.METALFX,
			EFunction.BLOOM,
			EFunction.NPCDENSITY,
			EFunction.VegetationDensity,
			EFunction.NVIDIADLSS,
			EFunction.NVIDIADLSSQUALITY,
			EFunction.XESS2,
			EFunction.XESS2_QUALITY,
			EFunction.FSR3,
			EFunction.FSR3_QUALITY,
			EFunction.RayTracing,
			EFunction.RayTracedReflection,
			EFunction.RayTracedGI,
			EFunction.RayTracedShadow,
			EFunction.LOADINGRANGESCALELEVEL,
			EFunction.AnisoLevel
		};

		// Token: 0x04020649 RID: 132681
		[StaticVariableRuleIgnore]
		public static readonly HashSet<EFunction> makeImageQualityCustomSet = new HashSet<EFunction>
		{
			EFunction.HIGHESTFPS,
			EFunction.SHADOWQUALITY,
			EFunction.NIAGARAQUALITY,
			EFunction.IMAGEDETAIL,
			EFunction.ANTIALISING,
			EFunction.SCENEAO,
			EFunction.VOLUMEFOG,
			EFunction.VOLUMELIGHT,
			EFunction.MOTIONBLUR,
			EFunction.PCVSYNC,
			EFunction.MOBILERESOLUTION,
			EFunction.NPCDENSITY,
			EFunction.VegetationDensity,
			EFunction.BLOOM,
			EFunction.FSR,
			EFunction.NVIDIADLSS,
			EFunction.NVIDIADLSSQUALITY,
			EFunction.XESS2,
			EFunction.XESS2_QUALITY,
			EFunction.FSR3,
			EFunction.FSR3_QUALITY,
			EFunction.LOADINGRANGESCALELEVEL
		};

		// Token: 0x0402064A RID: 132682
		[StaticVariableRuleIgnore]
		public static readonly HashSet<EFunction> mobileQualityUnRelativeSet = new HashSet<EFunction>
		{
			EFunction.FSR,
			EFunction.NVIDIADLSS,
			EFunction.NVIDIADLSSQUALITY,
			EFunction.XESS2,
			EFunction.XESS2_QUALITY,
			EFunction.FSR3,
			EFunction.FSR3_QUALITY
		};

		// Token: 0x0402064B RID: 132683
		[StaticVariableRuleIgnore]
		public static readonly EFilterSettingValueIndex[] filterSettingParams = new EFilterSettingValueIndex[]
		{
			EFilterSettingValueIndex.Horizontal,
			EFilterSettingValueIndex.Vertical,
			EFilterSettingValueIndex.Intensity,
			EFilterSettingValueIndex.SharpenIntensity,
			EFilterSettingValueIndex.Brightness,
			EFilterSettingValueIndex.Contrast,
			EFilterSettingValueIndex.ColorTemperature,
			EFilterSettingValueIndex.Saturation,
			EFilterSettingValueIndex.Bloom,
			EFilterSettingValueIndex.Gamma,
			EFilterSettingValueIndex.ShadowIntensity,
			EFilterSettingValueIndex.NoiseIntensity,
			EFilterSettingValueIndex.Halation
		};

		// Token: 0x0402064C RID: 132684
		public const int DEFAULT_FILTER_SETTING_INTENSITY_VALUE = 1;

		// Token: 0x0402064D RID: 132685
		public const double DEFAULT_FILTER_SETTING_VALUE = 0.5;

		// Token: 0x0402064E RID: 132686
		public const int DEFAULT_FILTER_SENIOR_SETTING_VALUE = 0;

		// Token: 0x0402064F RID: 132687
		public const string SEETING_LOAD_FLUID = "Text_SettingLoadFluid_text";

		// Token: 0x04020650 RID: 132688
		public const string SEETING_LOAD_LAGGY = "Text_SettingLoadLaggy_text";

		// Token: 0x04020651 RID: 132689
		public const string SEETING_LOAD_OVER = "Text_SettingLoadOver_text";

		// Token: 0x04020652 RID: 132690
		public const string SEETING_LOAD_FLUID_COLOR = "/Game/Aki/UI/UIResources/UiSet/Atlas/SP_BarGreen.SP_BarGreen";

		// Token: 0x04020653 RID: 132691
		public const string SEETING_LOAD_LAGGY_COLOR = "/Game/Aki/UI/UIResources/UiSet/Atlas/SP_BarOrange.SP_BarOrange";

		// Token: 0x04020654 RID: 132692
		public const string SEETING_LOAD_OVER_COLOR = "/Game/Aki/UI/UIResources/UiSet/Atlas/SP_BarRed.SP_BarRed";

		// Token: 0x04020655 RID: 132693
		[StaticVariableRuleIgnore]
		public static readonly int[] qualityLevelScores = new int[]
		{
			120,
			135,
			143,
			150,
			160
		};

		// Token: 0x04020656 RID: 132694
		[StaticVariableRuleIgnore]
		public static readonly int[] pcQualityLevelScores = new int[]
		{
			0,
			25,
			50,
			70,
			85,
			100
		};

		// Token: 0x04020657 RID: 132695
		[StaticVariableRuleIgnore]
		public static readonly float[] pcQualityLevelWeights = new float[]
		{
			1.35f,
			1.15f,
			1f,
			0.8f,
			0.65f,
			0.45f
		};

		// Token: 0x04020658 RID: 132696
		[StaticVariableRuleIgnore]
		public static readonly float[] mobileResolutionScores = new float[]
		{
			0.49f,
			0.64f,
			0.7225f,
			1f
		};

		// Token: 0x04020659 RID: 132697
		[StaticVariableRuleIgnore]
		public static readonly int[] shadowQualityScores = new int[]
		{
			0,
			6,
			10,
			12
		};

		// Token: 0x0402065A RID: 132698
		[StaticVariableRuleIgnore]
		public static readonly int[] niagaraQualityScores = new int[]
		{
			0,
			4,
			6
		};

		// Token: 0x0402065B RID: 132699
		[StaticVariableRuleIgnore]
		public static readonly int[] imageDetailScores = new int[]
		{
			0,
			6,
			12,
			20
		};

		// Token: 0x0402065C RID: 132700
		[StaticVariableRuleIgnore]
		public static readonly int[] sceneAoScores = new int[]
		{
			0,
			6,
			8,
			10
		};

		// Token: 0x0402065D RID: 132701
		[StaticVariableRuleIgnore]
		public static readonly int[] antiAliasingScores = new int[]
		{
			0,
			10
		};

		// Token: 0x0402065E RID: 132702
		[StaticVariableRuleIgnore]
		public static readonly int[] volumeFogScores = new int[]
		{
			0,
			3,
			6,
			10
		};

		// Token: 0x0402065F RID: 132703
		[StaticVariableRuleIgnore]
		public static readonly int[] volumeLightScores = new int[]
		{
			0,
			2
		};

		// Token: 0x04020660 RID: 132704
		[StaticVariableRuleIgnore]
		public static readonly int[] motionBlurScores = new int[]
		{
			0,
			6
		};

		// Token: 0x04020661 RID: 132705
		[StaticVariableRuleIgnore]
		public static readonly int[] amdFsrScores = new int[]
		{
			0,
			10
		};

		// Token: 0x04020662 RID: 132706
		[StaticVariableRuleIgnore]
		public static readonly int[] metalFxScores = new int[]
		{
			0,
			3
		};

		// Token: 0x04020663 RID: 132707
		[StaticVariableRuleIgnore]
		public static readonly int[] bloomScores = new int[]
		{
			0,
			3
		};

		// Token: 0x04020664 RID: 132708
		[StaticVariableRuleIgnore]
		public static readonly int[] npcDensityScores = new int[]
		{
			0,
			3,
			6
		};

		// Token: 0x04020665 RID: 132709
		[StaticVariableRuleIgnore]
		public static readonly int[] vegetationDensityScores = new int[]
		{
			0,
			3,
			6,
			10
		};

		// Token: 0x04020666 RID: 132710
		[StaticVariableRuleIgnore]
		public static readonly int[] superResolutionScores = new int[]
		{
			-70,
			-55,
			-45,
			-35,
			-10,
			-7,
			-3,
			0
		};

		// Token: 0x04020667 RID: 132711
		[StaticVariableRuleIgnore]
		public static readonly int[] nvidiaSuperResolutionScores = new int[]
		{
			-70,
			-62,
			-57,
			-46,
			-27,
			28,
			0
		};

		// Token: 0x04020668 RID: 132712
		[StaticVariableRuleIgnore]
		public static readonly int[] rayTracingGIScores = new int[]
		{
			0,
			8,
			15,
			15
		};

		// Token: 0x04020669 RID: 132713
		[StaticVariableRuleIgnore]
		public static readonly int[] rayTracingReflectionScores = new int[]
		{
			0,
			7,
			15,
			25
		};

		// Token: 0x0402066A RID: 132714
		[StaticVariableRuleIgnore]
		public static readonly int[] rayTracedShadowScores = new int[]
		{
			0,
			5,
			5,
			10
		};

		// Token: 0x0402066B RID: 132715
		[StaticVariableRuleIgnore]
		public static readonly int[] pcLoadingRangeScores = new int[]
		{
			0,
			40,
			80
		};

		// Token: 0x0402066C RID: 132716
		[StaticVariableRuleIgnore]
		public static readonly int[] mobileLoadingRangeScores = new int[]
		{
			0,
			80,
			160
		};

		// Token: 0x0402066D RID: 132717
		[StaticVariableRuleIgnore]
		public static readonly int[] anisotropyScores = new int[]
		{
			0,
			1,
			2,
			4,
			8
		};

		// Token: 0x0402066E RID: 132718
		public const string STOP_GUIDE_TAG = "MenuView";

		// Token: 0x0402066F RID: 132719
		public const string CUSTOM_TEXT_ID = "MenuConfig_5_OptionsName_4";

		// Token: 0x04020670 RID: 132720
		public const string TARGET_HIT_ITEM_FOR_FILTER = "TexFilter";

		// Token: 0x04020671 RID: 132721
		public const string TARGET_HIT_ITEM_FOR_LEFT_ARROW = "TexArrowL";

		// Token: 0x04020672 RID: 132722
		public const string TARGET_HIT_ITEM_FOR_RIGHT_ARROW = "TexArrowR";

		// Token: 0x04020673 RID: 132723
		public const int FILTER_SETTING_HELP_ID = 323;

		// Token: 0x04020674 RID: 132724
		public const string FILTER_SETTING_TITLE_TEXT_ID = "PrefabTextItem_3846974633_Text";

		// Token: 0x04020675 RID: 132725
		public const int EYE_PROTECT_SETTING_HELP_ID = 390;

		// Token: 0x04020676 RID: 132726
		public const string FILTER_SETTING_TITLE_ICON_RESOURCE_ID = "TexFilterIcon";

		// Token: 0x04020677 RID: 132727
		public const string FILTER_SETTING_COORDINATE_TEXT_ID = "PrefabTextItem_2070808429_Text";

		// Token: 0x04020678 RID: 132728
		public const int FILTER_SETTING_FILTER_TEXTURE_COUNT = 5;

		// Token: 0x04020679 RID: 132729
		public const int FILTER_SETTING_DEFAULT_FILTER_ID = 1;

		// Token: 0x0402067A RID: 132730
		public const string MENU_DETAIL_SPRITE_TEXT = "SP_BtnMenuDetailText";

		// Token: 0x0402067B RID: 132731
		public const string MENU_DETAIL_SPRITE_LOCK = "SP_BtnMenuDetailLock";

		// Token: 0x0402067C RID: 132732
		public const string MENU_DETAIL_SPRITE_POP = "SP_BtnMenuDetailPop";

		// Token: 0x0402067D RID: 132733
		public const string DETAIL_SPRITE_VISIBLE_COLOR_SRGB = "FFF7B6FF";
	}
}
