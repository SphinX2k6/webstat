using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.IosAudit
{
	// Token: 0x02006FC9 RID: 28617
	[NullableContext(1)]
	[Nullable(0)]
	public class IosAuditDefine
	{
		// Token: 0x060453D3 RID: 283603 RVA: 0x01215704 File Offset: 0x01213904
		// Note: this type is marked as 'beforefieldinit'.
		static IosAuditDefine()
		{
			Dictionary<EDataTable, string> dictionary = new Dictionary<EDataTable, string>();
			dictionary[EDataTable.ModelConfig] = "/Game/Aki/Data/Entity/CDT_ModelConfig.CDT_ModelConfig";
			dictionary[EDataTable.EntityProperty] = "/Game/Aki/Data/Fight/DT_EntityProperty.DT_EntityProperty";
			dictionary[EDataTable.AiWeaponSocket] = "/Game/Aki/Character/Monster/Common/Data/DT_AiWeaponSocket.DT_AiWeaponSocket";
			dictionary[EDataTable.RoleQualityInfo] = "/Game/Aki/Data/Role/DT_RoleQualityInfo.DT_RoleQualityInfo";
			dictionary[EDataTable.CipherGameplay] = "/Game/Aki/GamePlay/Cipher/DT_SCipherGameplay.DT_SCipherGameplay";
			dictionary[EDataTable.ConditionGroup] = "/Game/Aki/Data/Condition/DT_ConditionGroup.DT_ConditionGroup";
			dictionary[EDataTable.HitMapping] = "/Game/Aki/Data/Fight/DT_HitMapping.DT_HitMapping";
			dictionary[EDataTable.InteractionConfigs] = "/Game/Aki/Data/Interaction/CDT_InteractionConfigs.CDT_InteractionConfigs";
			dictionary[EDataTable.ManipulateItem] = "/Game/Aki/Data/Manipulate/Item/DT_Manipulate_Item.DT_Manipulate_Item";
			dictionary[EDataTable.ManipulatePrecast] = "/Game/Aki/Data/Manipulate/Precast/DT_Manipulate_Precast.DT_Manipulate_Precast";
			dictionary[EDataTable.Parkour] = "/Game/Aki/Data/Parkour/DT_Parkour.DT_Parkour";
			dictionary[EDataTable.SceneDecorativeUi] = "/Game/Aki/Data/Scene3DUI/DT_SceneDecorativeUI.DT_SceneDecorativeUI";
			dictionary[EDataTable.SceneUiTag] = "/Game/Aki/Data/Scene3DUI/DT_SceneUITag.DT_SceneUITag";
			dictionary[EDataTable.ServerInfo] = "/Game/Aki/Data/Server/DT_ServerInfo.DT_ServerInfo";
			dictionary[EDataTable.UiCameraAnimationBlendSettings] = "/Game/Aki/Data/UiCameraAnimation/DT_UiCameraAnimationBlendSettings.DT_UiCameraAnimationBlendSettings";
			dictionary[EDataTable.UiCameraAnimationSettings] = "/Game/Aki/Data/UiCameraAnimation/DT_UiCameraSetting.DT_UiCameraSetting";
			dictionary[EDataTable.Vision] = "/Game/Aki/Character/Vision/DT_Vision.DT_Vision";
			dictionary[EDataTable.UiRoleCameraSettings] = "/Game/Aki/Data/UiRoleCamera/DT_UiRoleCameraSettings.DT_UiRoleCameraSettings";
			dictionary[EDataTable.UiRoleCameraOffsetSettings] = "/Game/Aki/Data/UiRoleCamera/DT_UiRoleCameraOffsetSettings.DT_UiRoleCameraOffsetSettings";
			dictionary[EDataTable.Footprint] = "/Game/Aki/Character/Role/Common/Data/DT/DT_Footprint.DT_Footprint";
			dictionary[EDataTable.SCharacterFootPrint] = "/Game/Aki/Character/Role/Common/Data/DT/DT_CharacterFootprint.DT_CharacterFootprint";
			dictionary[EDataTable.GachaWeaponTransform] = "/Game/Aki/Data/GaCha/GachaWeaponTransform.GachaWeaponTransform";
			dictionary[EDataTable.FightSettlementCamera] = "/Game/Aki/Data/Camera/DT_FightSettlementCamera.DT_FightSettlementCamera";
			dictionary[EDataTable.InputCommandTransform] = "/Game/Aki/Data/Fight/DT_InputCommandTransform.DT_InputCommandTransform";
			dictionary[EDataTable.FreeCameraConfig] = "/Game/Aki/Data/Camera/DT_FreeCameraConfigList.DT_FreeCameraConfigList";
			dictionary[EDataTable.FightPhotographCameraConfig] = "/Game/Aki/Data/UiCameraAnimation/DT_UiCameraFightPhotographSetting.DT_UiCameraFightPhotographSetting";
			dictionary[EDataTable.DestructibleTable] = "/Game/Aki/Data/Level/Destructible/DestructibleTable.DestructibleTable";
			dictionary[EDataTable.GameplayABP] = "/Game/Aki/Data/Character/DT_GameplayABPConfig.DT_GameplayABPConfig";
			dictionary[EDataTable.DecorationConfig] = "/Game/Aki/Data/Entity/CDT_DecorationConfig.CDT_DecorationConfig";
			IosAuditDefine.DataTablePaths = dictionary;
			IosAuditDefine.CommonEffectPaths = new List<string>
			{
				"/Game/Aki/Data/Camera/DA_FightCameraConfig.DA_FightCameraConfig",
				"/Game/Aki/Data/Fight/BulletDataAsset/DA_CommonBullet.DA_CommonBullet",
				"/Game/Aki/Effect/EffectGroup/Common/DA_Fx_Group_WeaponEnd.DA_Fx_Group_WeaponEnd",
				"/Game/Aki/Effect/EffectGroup/R2T1JinxiMd20011/DA_Fx_Group_R1s_Shoudao.DA_Fx_Group_R1s_Shoudao",
				"/Game/Aki/Effect/EffectGroup/Common/DA_Fx_Group_ChangeRole.DA_Fx_Group_ChangeRole",
				"/Game/Aki/Effect/EffectGroup/Common/DA_Fx_Group_ChangeRoleStart.DA_Fx_Group_ChangeRoleStart",
				"/Game/Aki/Effect/EffectGroup/Common/DA_Fx_Group_Control_Obj_Hand.DA_Fx_Group_Control_Obj_Hand",
				"/Game/Aki/Effect/DataAsset/Niagara/BigWorld/DA_Fx_Animal_Vanish.DA_Fx_Animal_Vanish",
				"/Game/Aki/Effect/EffectGroup/Common/DA_Fx_Group_XieZou_Qidong00.DA_Fx_Group_XieZou_Qidong00",
				"/Game/Aki/Effect/EffectGroup/Common/DA_Fx_Group_XieZou_Gaowen00.DA_Fx_Group_XieZou_Gaowen00",
				"/Game/Aki/Effect/MaterialController/Common/DA_Fx_HuluStart.DA_Fx_HuluStart",
				"/Game/Aki/Effect/MaterialController/Common/DA_Fx_TimeFreeze_LimitDodge.DA_Fx_TimeFreeze_LimitDodge",
				"/Game/Aki/Effect/EffectGroup/Common/DA_Fx_Group_Press_Smoke.DA_Fx_Group_Press_Smoke",
				"/Game/Aki/Effect/EffectGroup/Common/DA_Fx_Group_Hook_Miaodian_Lock.DA_Fx_Group_Hook_Miaodian_Lock",
				"/Game/Aki/Effect/EffectGroup/Common/DA_Fx_Group_Hook_Miaodian_LockDown.DA_Fx_Group_Hook_Miaodian_LockDown",
				"/Game/Aki/Effect/EffectGroup/Common/DA_Fx_Group_ChangeRole_Play.DA_Fx_Group_ChangeRole_Play"
			};
		}

		// Token: 0x04026A04 RID: 158212
		[StaticVariableRuleIgnore]
		public static IReadOnlyList<string> CommonMajorPaths = new List<string>
		{
			"/Game/Aki/Data/Fight/CDT_CommonBulletData.CDT_CommonBulletData",
			"/Game/Aki/Data/Fight/DT_CommonHitEffect.DT_CommonHitEffect",
			"/Game/Aki/Character/Vision/DT_Vision.DT_Vision",
			"/Game/Aki/Data/Fight/DT_Common_Role_SkillInfo.DT_Common_Role_SkillInfo",
			"/Game/Aki/Data/Fight/DT_Common_Monster_SkillInfo.DT_Common_Monster_SkillInfo",
			"/Game/Aki/Data/Fight/DT_Common_Vision_SkillInfo.DT_Common_Vision_SkillInfo",
			"/Game/Aki/Data/Fight/CDT_CharacterFightInfo.CDT_CharacterFightInfo",
			"/Game/Aki/Data/Fight/DT_CaughtInfo.DT_CaughtInfo",
			"/Game/Aki/Data/Fight/DA_DefaultBulletConfig.DA_DefaultBulletConfig",
			"/Game/Aki/Data/Fight/DT_QteTag.DT_QteTag"
		};

		// Token: 0x04026A05 RID: 158213
		[StaticVariableRuleIgnore]
		public static IReadOnlyList<string> CommonOtherPaths = new List<string>
		{
			"/Game/Aki/UI/UIResources/UiFight/Atlas/SP_FightPutong.SP_FightPutong",
			"/Game/Aki/Character/BaseCharacter/Abilities/GA/GA_Base.GA_Base_C",
			"/Game/Aki/Effect/UI/Niagaras/Common/NS_Fx_LGUI_FightQTE_001.NS_Fx_LGUI_FightQTE_001",
			"/Game/Aki/Effect/UI/Niagaras/Common/NS_Fx_LGUI_FightQTE_002.NS_Fx_LGUI_FightQTE_002",
			"/Game/Aki/Effect/MaterialController/Common/DA_Fx_Character_ChangeRole.DA_Fx_Character_ChangeRole",
			"/Game/Aki/Effect/BluePrint/BP_FX_Common/BP_Fx_Scanning.BP_Fx_Scanning_C",
			"/Game/Aki/Effect/BluePrint/BP_FX_Common/BP_Fx_Control_Obj.BP_Fx_Control_Obj_C",
			"/Game/Aki/Data/Fight/BulletCampAsset/DT_AllBulletCampAsset.DT_AllBulletCampAsset",
			"/Game/Aki/Data/Fight/BulletDataAsset/DT_AllBulletLogicTypeNew.DT_AllBulletLogicTypeNew",
			"/Game/Aki/Data/Fight/CommonGB/DT_AllKuroBpDataGroup.DT_AllKuroBpDataGroup",
			"/Game/Aki/Effect/Niagara/NI_Common/NS_Fx_Control_Obj_Beam.NS_Fx_Control_Obj_Beam",
			"/Game/Aki/Effect/MaterialController/Common/DA_Fx_HuluWarning.DA_Fx_HuluWarning",
			"/Game/Aki/Data/Fight/UI/DT_PanelQte.DT_PanelQte",
			"/Game/Aki/Data/Qte/DT_CommonQte.DT_CommonQte",
			"/Game/Aki/Data/Qte/DT_BattleQte.DT_BattleQte",
			"/Game/Aki/UI/Framework/PredefColor/DT_PredefColor.DT_PredefColor",
			"/Game/Aki/Effect/MaterialController/Common/DA_Fx_UIChangeRole.DA_Fx_UIChangeRole",
			"/Game/Aki/TypeScript/Game/Render/Scene/Item/SceneInteractionActor.SceneInteractionActor_C",
			"/Game/Aki/Render/RuntimeBP/Character/MaterialContainer/DA_CharacterMaterialContainerData.DA_CharacterMaterialContainerData",
			"/Game/Aki/Render/Shaders/Character/MI_Empty",
			"/Game/Aki/Character/Role/Common/ABP_PerformanceRole.ABP_PerformanceRole_C",
			"/Game/Aki/UI/UIResources/UiWorld/Curve/NPCHeadStateScaleCurve.NPCHeadStateScaleCurve",
			"/Game/Aki/UI/UIResources/UiWorld/Curve/NPCDialogScaleCurve.NPCDialogScaleCurve",
			"/Game/Aki/UI/UIResources/Common/LevelSequence/Curve/InertiaCurve.InertiaCurve",
			"/Game/Aki/UI/UIResources/Common/LevelSequence/Curve/VelocityCurve.VelocityCurve",
			"/Game/Aki/UI/UIResources/Common/LevelSequence/Curve/BoundaryCurve.BoundaryCurve",
			"/Game/Aki/Character/Role/Common/Data/Curves/CT_MoveFAcceleration.CT_MoveFAcceleration",
			"/Game/Aki/Character/Role/Common/Data/Curves/CT_SwimAcceleratorStrength.CT_SwimAcceleratorStrength",
			"/Game/Aki/Character/Role/Common/Data/Curves/CT_SwimRotateSpeed.CT_SwimRotateSpeed",
			"/Game/Aki/Character/BaseCharacter/Curves/CURVE_HorizontalVelocity.CURVE_HorizontalVelocity",
			CharacterSplineMoveComponent.DaPath,
			"/Game/Aki/Character/BaseCharacter/Curves/CharacterMovementCurves/AngleToStepFrequency.AngleToStepFrequency",
			"/Game/Aki/Character/BaseCharacter/Curves/CharacterMovementCurves/AngleToStepLength.AngleToStepLength",
			"/Game/Aki/Data/Fight/Curves/C_FightFinishSlowMo.C_FightFinishSlowMo",
			"/Game/Aki/Data/Fight/Movement/DA_SoarConfigBase.DA_SoarConfigBase",
			"/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Role_Soar.NCS_Role_Soar_C",
			"/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/CameraShake_Curve.CameraShake_Curve",
			"/Game/Aki/Character/Input/DataAsset/DA_CameraDrivenAutoFlightData.DA_CameraDrivenAutoFlightData",
			"/Game/Aki/Data/Fight/DT_InputCommandTransform.DT_InputCommandTransform"
		};

		// Token: 0x04026A06 RID: 158214
		[StaticVariableRuleIgnore]
		public static IReadOnlyDictionary<EDataTable, string> DataTablePaths;

		// Token: 0x04026A07 RID: 158215
		[StaticVariableRuleIgnore]
		public static IReadOnlyList<string> CommonEffectPaths;
	}
}
