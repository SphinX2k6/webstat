using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020027C5 RID: 10181
[NullableContext(1)]
[Nullable(0)]
public class RoleDefine : IStaticVariableResetter
{
	// Token: 0x06014254 RID: 82516 RVA: 0x005A032D File Offset: 0x0059E52D
	static RoleDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(RoleDefine.CreateStaticDefaultValue), new Action(RoleDefine.ResetStaticDefaultValue));
	}

	// Token: 0x17001984 RID: 6532
	// (get) Token: 0x06014255 RID: 82517 RVA: 0x005A034C File Offset: 0x0059E54C
	public static EUiTabViewName[] UI_ROLE_CAN_ROTATE_TABVIEW
	{
		get
		{
			return RoleDefine._UI_ROLE_CAN_ROTATE_TABVIEW;
		}
	}

	// Token: 0x17001985 RID: 6533
	// (get) Token: 0x06014256 RID: 82518 RVA: 0x005A0353 File Offset: 0x0059E553
	public static Dictionary<ETrialRoleType, string> trialRoleHexColor
	{
		get
		{
			return RoleDefine._trialRoleHexColor;
		}
	}

	// Token: 0x17001986 RID: 6534
	// (get) Token: 0x06014257 RID: 82519 RVA: 0x005A035A File Offset: 0x0059E55A
	public static Dictionary<ERoleViewSource, bool> RoleViewSourceHideRoleChange
	{
		get
		{
			return RoleDefine._RoleViewSourceHideRoleChange;
		}
	}

	// Token: 0x17001987 RID: 6535
	// (get) Token: 0x06014258 RID: 82520 RVA: 0x005A0361 File Offset: 0x0059E561
	public static Dictionary<ERoleViewSource, bool> RoleViewSourceHideHomeInInstance
	{
		get
		{
			return RoleDefine._RoleViewSourceHideHomeInInstance;
		}
	}

	// Token: 0x06014259 RID: 82521 RVA: 0x005A0368 File Offset: 0x0059E568
	public static void CreateStaticDefaultValue()
	{
		RoleDefine.UI_SCENE_ROLE_TAG = new FName("TsUiSceneRoleActor");
		RoleDefine.UI_SKELETAL_OBSERVER_TAG = new FName("TsSkeletalObserver");
		RoleDefine.UI_CAMERA_TAG = new FName("UICineCamera");
		RoleDefine._UI_ROLE_CAN_ROTATE_TABVIEW = new EUiTabViewName[]
		{
			EUiTabViewName.RoleAttributeTabView,
			EUiTabViewName.RoleFavorTabView,
			EUiTabViewName.RolePreviewAttributeTabView
		};
		RoleDefine._trialRoleHexColor = new Dictionary<ETrialRoleType, string>
		{
			{
				ETrialRoleType.NormalTrial,
				"ffffff"
			},
			{
				ETrialRoleType.NewbieSupportTrial,
				"fffca0"
			},
			{
				ETrialRoleType.ReturnSupportTrial,
				"bcf3ff"
			},
			{
				ETrialRoleType.NewbieSupportTrialV2,
				"fffca0"
			}
		};
		RoleDefine._RoleViewSourceHideRoleChange = new Dictionary<ERoleViewSource, bool>
		{
			{
				ERoleViewSource.Normal,
				false
			},
			{
				ERoleViewSource.WheelTower,
				true
			},
			{
				ERoleViewSource.BabelTower,
				true
			}
		};
		RoleDefine._RoleViewSourceHideHomeInInstance = new Dictionary<ERoleViewSource, bool>
		{
			{
				ERoleViewSource.Normal,
				false
			},
			{
				ERoleViewSource.WheelTower,
				false
			},
			{
				ERoleViewSource.BabelTower,
				true
			}
		};
	}

	// Token: 0x0601425A RID: 82522 RVA: 0x005A044F File Offset: 0x0059E64F
	public static void ResetStaticDefaultValue()
	{
		RoleDefine.UI_SCENE_ROLE_TAG = default(FName);
		RoleDefine.UI_SKELETAL_OBSERVER_TAG = default(FName);
		RoleDefine.UI_CAMERA_TAG = default(FName);
		RoleDefine._UI_ROLE_CAN_ROTATE_TABVIEW = null;
		RoleDefine._trialRoleHexColor = null;
		RoleDefine._RoleViewSourceHideRoleChange = null;
		RoleDefine._RoleViewSourceHideHomeInInstance = null;
	}

	// Token: 0x04009C92 RID: 40082
	public const int HP_ATTR_ID = 2;

	// Token: 0x04009C93 RID: 40083
	public const int ATTACK_ATTR_ID = 7;

	// Token: 0x04009C94 RID: 40084
	public const int CRIT_ATTR_ID = 8;

	// Token: 0x04009C95 RID: 40085
	public const int DEF_ATTR_ID = 10;

	// Token: 0x04009C96 RID: 40086
	public const int RESPONSE_PROFICIENCY_ID = 13;

	// Token: 0x04009C97 RID: 40087
	public const int STRENGTH_MAX_ID = 69;

	// Token: 0x04009C98 RID: 40088
	public const int ROBOT_DATA_MIN_ID = 100000;

	// Token: 0x04009C99 RID: 40089
	public const int PROP_RATIO_PER = 10000;

	// Token: 0x04009C9A RID: 40090
	public const float MUL_RATIO = 0.0001f;

	// Token: 0x04009C9B RID: 40091
	public const string UI_ABP_PATH = "/Game/Aki/Character/Role/Common/ABP_PerformanceRole.ABP_PerformanceRole_C";

	// Token: 0x04009C9C RID: 40092
	public const string ROLE_CAMERA_SETTING_NAME = "1020";

	// Token: 0x04009C9D RID: 40093
	public const string ROLE_CHANGEROLE_BLENDNAME = "10007";

	// Token: 0x04009C9E RID: 40094
	[Nullable(2)]
	private static EUiTabViewName[] _UI_ROLE_CAN_ROTATE_TABVIEW;

	// Token: 0x04009C9F RID: 40095
	public static FName UI_SCENE_ROLE_TAG;

	// Token: 0x04009CA0 RID: 40096
	public static FName UI_SKELETAL_OBSERVER_TAG;

	// Token: 0x04009CA1 RID: 40097
	public static FName UI_CAMERA_TAG;

	// Token: 0x04009CA2 RID: 40098
	public const string ROLE_MUTE_NATURE_AUDIO_GROUP = "mute_nature_voice";

	// Token: 0x04009CA3 RID: 40099
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Dictionary<ETrialRoleType, string> _trialRoleHexColor;

	// Token: 0x04009CA4 RID: 40100
	[Nullable(2)]
	private static Dictionary<ERoleViewSource, bool> _RoleViewSourceHideRoleChange;

	// Token: 0x04009CA5 RID: 40101
	[Nullable(2)]
	private static Dictionary<ERoleViewSource, bool> _RoleViewSourceHideHomeInInstance;
}
