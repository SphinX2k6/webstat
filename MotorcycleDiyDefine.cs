using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020022F0 RID: 8944
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleDiyDefine : IStaticVariableResetter
{
	// Token: 0x06010E76 RID: 69238 RVA: 0x004A0A9F File Offset: 0x0049EC9F
	static MotorcycleDiyDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(MotorcycleDiyDefine.CreateStaticDefaultValue), new Action(MotorcycleDiyDefine.ResetStaticDefaultValue));
	}

	// Token: 0x06010E77 RID: 69239 RVA: 0x004A0AC0 File Offset: 0x0049ECC0
	public static void CreateStaticDefaultValue()
	{
		MotorcycleDiyDefine.MOTORCYCLE_DIY_STICKER_PART = new int[]
		{
			1,
			2,
			3
		};
		MotorcycleDiyDefine.MOTORCYCLE_DIY_DECORATION_PART = new int[]
		{
			1,
			2
		};
		MotorcycleDiyDefine.OutlookToSkinCustomizeIconMap = new Dictionary<EOutlookType, string>
		{
			{
				EOutlookType.Frame,
				"SP_MotorSkinFrameCustomlizeIcon"
			},
			{
				EOutlookType.Sticker,
				"SP_MotorSkinStickerCustomlizeIcon"
			},
			{
				EOutlookType.Decoration,
				"SP_MotorSkinDecorationCustomlizeIcon"
			}
		};
		MotorcycleDiyDefine.OutlookToSkinCustomizeNameMap = new Dictionary<EOutlookType, string>
		{
			{
				EOutlookType.Frame,
				"MotorFrame"
			},
			{
				EOutlookType.Sticker,
				"MotorSticker"
			},
			{
				EOutlookType.Decoration,
				"MotorDecorations"
			}
		};
	}

	// Token: 0x06010E78 RID: 69240 RVA: 0x004A0B52 File Offset: 0x0049ED52
	public static void ResetStaticDefaultValue()
	{
		MotorcycleDiyDefine.MOTORCYCLE_DIY_STICKER_PART = null;
		MotorcycleDiyDefine.MOTORCYCLE_DIY_DECORATION_PART = null;
		MotorcycleDiyDefine.OutlookToSkinCustomizeIconMap = null;
		MotorcycleDiyDefine.OutlookToSkinCustomizeNameMap = null;
	}

	// Token: 0x04008539 RID: 34105
	public const string MOTORCYCLE_DIY_TAB_VIEW_CAMERA_CONFIG_ID = "摩托车自定义界面";

	// Token: 0x0400853A RID: 34106
	public const string MOTORCYCLE_DIY_ROOT_VIEW_CAMERA_CONFIG_ID = "摩托车贴纸界面";

	// Token: 0x0400853B RID: 34107
	public const string MOTORCYCLE_DIY_IMPORT_VIEW_CAMERA_CONFIG_ID = "摩托车预设界面";

	// Token: 0x0400853C RID: 34108
	public const string MOTORCYCLE_DIY_SKIN_VIEW_MODEL_ROTATE_CONFIG_ID = "摩托车皮肤旋转";

	// Token: 0x0400853D RID: 34109
	public const string MOTORCYCLE_DIY_NONE_ICON_PATH = "/Game/Aki/UI/UIResources/Common/Image/Com/T_ComItemNoneIcon.T_ComItemNoneIcon";

	// Token: 0x0400853E RID: 34110
	public static int[] MOTORCYCLE_DIY_STICKER_PART;

	// Token: 0x0400853F RID: 34111
	public static int[] MOTORCYCLE_DIY_DECORATION_PART;

	// Token: 0x04008540 RID: 34112
	public static Dictionary<EOutlookType, string> OutlookToSkinCustomizeIconMap;

	// Token: 0x04008541 RID: 34113
	public static Dictionary<EOutlookType, string> OutlookToSkinCustomizeNameMap;
}
