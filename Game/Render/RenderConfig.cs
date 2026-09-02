using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialContainer;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004767 RID: 18279
	[NullableContext(1)]
	[Nullable(0)]
	public class RenderConfig : IStaticVariableResetter
	{
		// Token: 0x0602F6DB RID: 194267 RVA: 0x00B45068 File Offset: 0x00B43268
		static RenderConfig()
		{
			EKuroCharMeshPart[] array = new EKuroCharMeshPart[5];
			RuntimeHelpers.InitializeArray(array, fieldof(<PrivateImplementationDetails>.08BB5E5D6EAAC1049EDE0893D30ED022B1A4D9B5B48DB414871F51C9CB35283D).FieldHandle);
			RenderConfig.MeshPartsHeadArray = array;
			RenderConfig.MaterialControlBodyTypes = null;
			RenderConfig.EntityTypeToRenderPriorityMap = null;
			RenderConfig.SpecifiedTypeBodyNames = null;
			RenderConfig.UseRim = new FName("E_Rim_UseRim");
			RenderConfig.RimUseTex = new FName("E_Rim_UseTex");
			RenderConfig.RimChannel = new FName("E_Rim_Channel");
			RenderConfig.RimRange = new FName("E_Rim_RimRange");
			RenderConfig.RimColor = new FName("E_Rim_RimColor");
			RenderConfig.RimIntensity = new FName("E_Rim_Intensity");
			RenderConfig.UseDissolve = new FName("E_Dissolve_UseDissolve");
			RenderConfig.DissolveChannelSwitch = new FName("E_Dissolve_Channel");
			RenderConfig.DissolveProgress = new FName("E_Dissolve_Progress");
			RenderConfig.DissolveSmooth = new FName("E_Dissolve_Smooth");
			RenderConfig.DissolveMulti = new FName("E_Dissolve_Multi");
			RenderConfig.DissolveEmission = new FName("E_Dissolve_Emission");
			RenderConfig.OutlineUseTex = new FName("E_Outline_UseTex");
			RenderConfig.OutlineWidth = new FName("MaxOutlineWidth");
			RenderConfig.OutlineColor = new FName("E_Outline_EmissionColor");
			RenderConfig.OutlineColorIntensity = new FName("E_Outline_EmissionIntensity");
			RenderConfig.UseTexture = new FName("E_Tex_UseTex");
			RenderConfig.TextureUseMask = new FName("E_Tex_UseMask");
			RenderConfig.TextureMaskRange = new FName("E_Tex_MaskRange");
			RenderConfig.NoiseTexture = new FName("E_Tex_NoiseTex");
			RenderConfig.TextureUvSwitch = new FName("E_Tex_UVSwitch");
			RenderConfig.TextureUseScreenUv = new FName("E_Tex_UseScreenUV");
			RenderConfig.TextureScaleAndOffset = new FName("E_Tex_ScaleAndOffset");
			RenderConfig.TextureSpeed = new FName("E_Tex_Speed");
			RenderConfig.TextureColor = new FName("E_Tex_Color");
			RenderConfig.TextureRotation = new FName("E_Tex_Rotation");
			RenderConfig.BaseUseTex = new FName("E_Base_UseTex");
			RenderConfig.BaseColor = new FName("E_Base_Color");
			RenderConfig.BaseColorIntensity = new FName("E_Base_Intensity");
			RenderConfig.EmissionUseTex = new FName("E_Emission_UseTex");
			RenderConfig.EmissionColor = new FName("E_Emission_Color");
			RenderConfig.EmissionIntensity = new FName("E_Emission_Intensity");
			RenderConfig.UseHeadMaskHideEffect = new FName("E_UseHeadMaskHide");
			RenderConfig.DitherUseInRayTracing = new FName("E_UseInRayTracing");
			RenderConfig.UseDitherEffect = new FName("E_Dither_UseDither");
			RenderConfig.DitherValue = new FName("E_Dither_DitherValue");
			RenderConfig.DitherValueMainPass = new FName("E_Dither_DitherValue_MainPass");
			RenderConfig.UseDitherEffect2 = new FName("E_Dither_UseDither2");
			RenderConfig.DitherValue2 = new FName("E_Dither_DitherValue2");
			RenderConfig.CharacterAmbientColor = new FName("CharacterAmbientColor");
			RenderConfig.CharacterSkinAmbientColor = new FName("CharacterSkinAmbientColor");
			RenderConfig.EnableTransfer = new FName("E_Transfer_Enable");
			RenderConfig.TransferDensity = new FName("E_Transfer_Density");
			RenderConfig.TransferHardness = new FName("E_Transfer_Hardness");
			RenderConfig.TransferDirection = new FName("E_Transfer_Direction");
			RenderConfig.TransferHeight = new FName("E_Transfer_Height");
			RenderConfig.TransferOutlineColor = new FName("E_Transfer_OutlineColor");
			RenderConfig.MotionRange = new FName("E_MotionRange");
			RenderConfig.MotionOffset = new FName("E_Motion_Offset");
			RenderConfig.MotionNoiseSpeed = new FName("E_Motion_NoiseSpeed");
			RenderConfig.StarScarEnergyControl = new FName("XingHenControl");
			RenderConfig.TexMipOffset = new FName("Tex_Mip_Offset");
			RenderConfig.RootName = new FName("Root");
			RenderConfig.UIName = new FName("UI");
			RenderConfig.GlobalRainIntensity = new FName("GlobalRainIntensity");
			RenderConfig.GlobalSnowIntensity = new FName("GlobalSnowIntensity");
			RenderConfig.GlobalWindSpeed = new FName("GlobalWindSpeed");
			RenderConfig.GlobalGrassAO = new FName("GlobalGrassAO");
			RenderConfig.GlobalMainLightVector = new FName("GlobalSceneMainLightDirection");
			RenderConfig.GlobalLensFlareColorTint = new FName("GlobalLensFlareColorTint");
			RenderConfig.GlobalCharacterPreviousWP = new FName("GlobalCharacterPreviousWP");
			RenderConfig.GlobalCharacterWorldPosition = new FName("GlobalCharacterWorldPosition");
			RenderConfig.GlobalCharacterWeaponPosition = new FName("GlobalCharacterWeaponPosition");
			RenderConfig.GlobalCharacterWorldForwardDirection = new FName("GlobalCharacterWorldForwardDirection");
			RenderConfig.GlobalCharacterOnGround = new FName("GlobalCharacterOnGround");
			RenderConfig.GlobalCameraPosAndRadius = new FName("GlobalCameraPosAndRadius");
			RenderConfig.UseSocketTransform = new FName("UseSocketTransform");
			RenderConfig.UseClipboardTransform = new FName("UseClipboardTransform");
			RenderConfig.UseSocketTransform2 = new FName("使用插槽变换信息");
			RenderConfig.UseClipboardTransform2 = new FName("使用剪切板变换信息");
			RenderConfig.PhysicsActor = new FName("PhysicsActor");
			RenderConfig.WaterCollisionProfileName = new FName("水体");
			RenderConfig.UIShowBrightness = new FName("Lumin");
			RenderConfig.UIShowSaturation = new FName("Saturation");
			RenderConfig.UIShowContrast = new FName("Contrast");
			RenderConfig.GlobalTimeHour = new FName("GlobalTimeHour");
			RenderConfig.GlobalTimeMinutes = new FName("GlobalTimeMinutes");
			RenderConfig.GravityDirection = new FName("GravityDirection");
			RenderConfig.IsPlayerMale = new FName("IsPlayerMale");
			RenderConfig.E_Action_UseBaseColorScale = new FName("E_Action_UseBaseColorScale");
			RenderConfig.E_Action_BaseColorScale = new FName("E_Action_BaseColorScale");
			RenderConfig.E_Action_UseEmissionColor = new FName("E_Action_UseEmissionColor");
			RenderConfig.E_Action_EmissionColor = new FName("E_Action_EmissionColor");
			RenderConfig.E_Action_UseRimLight = new FName("E_Action_UseRimLight");
			RenderConfig.E_Action_RimLightColor = new FName("E_Action_RimLightColor");
			RenderConfig.E_Action_RimPower = new FName("E_Action_RimPower");
			RenderConfig.E_Action_UseEmissionChange = new FName("E_Action_UseEmissionChange");
			RenderConfig.E_Action_EmissionLightColorChangeColor = new FName("E_Action_EmissionLightColorChangeColor");
			RenderConfig.E_Action_EmissionLightColorChangeStrength = new FName("E_Action_EmissionLightColorChangeStrength");
			RenderConfig.E_Action_EmissionLightColorChangeProgress = new FName("E_Action_EmissionLightColorChangeProgress");
			RenderConfig.E_Action_UseDissolve = new FName("E_Action_UseDissolve");
			RenderConfig.E_Action_DissolveProgress = new FName("E_Action_DissolveProgress");
			RenderConfig.E_Action_DissolveAdjustment = new FName("E_Action_DissolveAdjustment");
			RenderConfig.E_Action_DissolveEdageWidth = new FName("E_Action_DissolveEdageWidth");
			RenderConfig.E_Action_DissolveEdageColor = new FName("E_Action_DissolveEdageColor");
			RenderConfig.E_Action_DissolveEdageStrength = new FName("E_Action_DissolveEdageStrength");
			RenderConfig.E_Action_DissolveTex_S_O = new FName("E_Action_DissolveTex_S_O");
			RenderConfig.E_Action_DissolveTexSpeed = new FName("E_Action_DissolveTexSpeed");
			RenderConfig.E_Tex_DissolveTexUVSwitch = new FName("E_Tex_DissolveTexUVSwitch");
			RenderConfig.E_Action_ScanningOutlineMixNoiseStrength = new FName("E_Action_ScanningOutlineMixNoiseStrength");
			RenderConfig.E_Action_GlobalBaseColorScale = new FName("E_Action_GlobalBaseColorScale");
			RenderConfig.E_Action_GlobalAddEmissionColor = new FName("E_Action_GlobalAddEmissionColor");
			RenderConfig.E_Action_ScanningOutline = new FName("E_Action_ScanningOutline");
			RenderConfig.E_Action_GlobalRimLight = new FName("E_Action_GlobalRimLight");
			RenderConfig.E_Action_UseScanning = new FName("E_Action_UseScanning");
			RenderConfig.E_Action_RimMix = new FName("E_Action_RimMix");
			RenderConfig.E_Action_ScanningOutlineStrength = new FName("E_Action_ScanningOutlineStrength");
			RenderConfig.E_Action_ScanningTex_S_O = new FName("E_Action_ScanningTex_S_O");
			RenderConfig.E_Action_ScanningOutlineColor = new FName("E_Action_ScanningOutlineColor");
			RenderConfig.E_Action_RimWidth = new FName("E_Action_RimWidth");
			RenderConfig.BrokenTex_S_O = new FName("BrokenTex_S_O");
			RenderConfig.OutlineTex_S_O = new FName("OutlineTex_S_O");
			RenderConfig.E_Action_VertexAnim_TimeDebug = new FName("E_Action_VertexAnim_TimeDebug");
			RenderConfig.E_Action_VertexAnim_Frame = new FName("E_Action_VertexAnim_Frame");
			RenderConfig.E_Action_PivotPainterTransform = new FName("E_Action_PivotPainterTransform");
			RenderConfig.E_Action_PivotPainter_FloatingThreshold = new FName("E_Action_PivotPainter_FloatingThreshold");
			RenderConfig.E_Action_UsePivotPainterWorldPositionOffset = new FName("E_Action_UsePivotPainterWorldPositionOffset");
			RenderConfig.E_Action_UseWPO = new FName("E_Action_UseWPO");
			RenderConfig.E_Action_DisableFoliageEffect = new FName("E_Action_DisableFoliageEffect");
			RenderConfig.E_Action_EnableFoliageEffect = new FName("E_Action_EnableFoliageEffect");
			RenderConfig.E_Action_RimLightColorSpecil = new FName("E_Action_RimLightColorSpecil");
			RenderConfig.E_Action_UseRimlightColorSpecil = new FName("E_Action_UseRimlightColorSpecil");
			RenderConfig.E_Action_RimlightColorStrength = new FName("E_Action_RimlightColorStrength");
			RenderConfig.E_Action_SimpleWPO_Normal = new FName("E_Action_SimpleWPO_Normal");
			RenderConfig.E_Action_SimpleWPO_Offset = new FName("E_Action_SimpleWPO_Offset");
			RenderConfig.E_Action_UseEmissionTex = new FName("E_Action_UseEmissionTex");
			RenderConfig.E_Action_EmissionTexStrength = new FName("E_Action_EmissionTexStrength");
			RenderConfig.E_Action_Simple_Uspeed = new FName("E_Action_Simple_Uspeed");
			RenderConfig.E_Action_Simple_Vspeed = new FName("E_Action_Simple_Vspeed");
			RenderConfig.E_Action_Simple_UseFlow = new FName("E_Action_Simple_UseFlow");
			RenderConfig.E_Action_UseQuanXiPinTu = new FName("E_Action_UseQuanXiPinTu");
			RenderConfig.E_Action_TransparencyQuanXiPinTu = new FName("E_Action_TransparencyQuanXiPinTu");
			RenderConfig.E_Action_TransparentColorQuanXiPinTu = new FName("E_Action_TransparentColorQuanXiPinTu");
			RenderConfig.E_Action_OpaqueColorQuanXiPinTu = new FName("E_Action_OpaqueColorQuanXiPinTu");
			RenderConfig.E_Action_UseQuanXiFengSuo = new FName("E_Action_UseQuanXiFengSuo");
			RenderConfig.E_Action_TransparencyQuanXiFengSuo = new FName("E_Action_TransparencyQuanXiFengSuo");
			RenderConfig.E_Action_TransparentColorQuanXiFengSuo = new FName("E_Action_TransparentColorQuanXiFengSuo");
			StaticVariableRegister.RegisterAndExecute(new Action(RenderConfig.CreateStaticDefaultValue), new Action(RenderConfig.ResetStaticDefaultValue));
		}

		// Token: 0x0602F6DC RID: 194268 RVA: 0x00B45A37 File Offset: 0x00B43C37
		public static string GenerateExtraMeshName(string sourceSkeletalName)
		{
			return sourceSkeletalName + "_ExtraMesh";
		}

		// Token: 0x0602F6DD RID: 194269 RVA: 0x00B45A44 File Offset: 0x00B43C44
		public static ECharacterBodyType GetBodyTypeByName(string bodyName)
		{
			if (RenderConfig.MaterialControlBodyTypes == null)
			{
				RenderConfig.MaterialControlBodyTypes = new Dictionary<string, ECharacterBodyType>
				{
					{
						"CharacterMesh0",
						ECharacterBodyType.Body
					},
					{
						"WeaponCase0",
						ECharacterBodyType.Weapon
					},
					{
						"WeaponCase1",
						ECharacterBodyType.Weapon
					},
					{
						"WeaponCase2",
						ECharacterBodyType.Weapon
					},
					{
						"WeaponCase3",
						ECharacterBodyType.Weapon
					},
					{
						"WeaponCase4",
						ECharacterBodyType.Weapon
					},
					{
						"HuluCase",
						ECharacterBodyType.Hulu
					},
					{
						"OtherCase0",
						ECharacterBodyType.Other
					},
					{
						"OtherCase1",
						ECharacterBodyType.Other
					},
					{
						"OtherCase2",
						ECharacterBodyType.Other
					},
					{
						"OtherCase3",
						ECharacterBodyType.Other
					},
					{
						"OtherCase4",
						ECharacterBodyType.Other
					}
				};
			}
			ECharacterBodyType result;
			if (!RenderConfig.MaterialControlBodyTypes.TryGetValue(bodyName, out result))
			{
				return ECharacterBodyType.Body;
			}
			return result;
		}

		// Token: 0x0602F6DE RID: 194270 RVA: 0x00B45B08 File Offset: 0x00B43D08
		public static EEntityTypePriority GetEntityRenderPriority(bool isBoss, EEntityType entityType)
		{
			if (isBoss)
			{
				return EEntityTypePriority.Boss;
			}
			if (RenderConfig.EntityTypeToRenderPriorityMap == null)
			{
				RenderConfig.EntityTypeToRenderPriorityMap = new Dictionary<EEntityType, EEntityTypePriority>
				{
					{
						EEntityType.Player,
						EEntityTypePriority.Player
					},
					{
						EEntityType.Npc,
						EEntityTypePriority.NPC
					},
					{
						EEntityType.Monster,
						EEntityTypePriority.Monster
					},
					{
						EEntityType.Vision,
						EEntityTypePriority.Vision
					},
					{
						EEntityType.Animal,
						EEntityTypePriority.Animal
					},
					{
						EEntityType.SceneItem,
						EEntityTypePriority.SceneItem
					},
					{
						EEntityType.Custom,
						EEntityTypePriority.Custom
					}
				};
			}
			EEntityTypePriority result;
			if (!RenderConfig.EntityTypeToRenderPriorityMap.TryGetValue(entityType, out result))
			{
				return EEntityTypePriority.None;
			}
			return result;
		}

		// Token: 0x0602F6DF RID: 194271 RVA: 0x00B45B78 File Offset: 0x00B43D78
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public static string[] GetBodyNamesByBodyType(ECharacterBodySpecifiedType bodyType)
		{
			if (RenderConfig.SpecifiedTypeBodyNames == null)
			{
				RenderConfig.SpecifiedTypeBodyNames = new Dictionary<ECharacterBodySpecifiedType, string[]>
				{
					{
						ECharacterBodySpecifiedType.All,
						RenderConfig.MaterialControlAllCaseArray.ToArray<string>()
					},
					{
						ECharacterBodySpecifiedType.Body,
						RenderConfig.MaterialControlBodyCaseArray.ToArray<string>()
					},
					{
						ECharacterBodySpecifiedType.Weapon,
						RenderConfig.MaterialControlWeaponCaseArray.ToArray<string>()
					},
					{
						ECharacterBodySpecifiedType.Hulu,
						RenderConfig.MaterialControlHuluCaseArray.ToArray<string>()
					},
					{
						ECharacterBodySpecifiedType.Other,
						RenderConfig.MaterialControlOtherCaseArray.ToArray<string>()
					},
					{
						ECharacterBodySpecifiedType.WeaponAndHulu,
						RenderConfig.MaterialControlWeaponAndHuluCaseArray.ToArray<string>()
					},
					{
						ECharacterBodySpecifiedType.ExtraBody,
						RenderConfig.MaterialControlExtraBodyCaseArray.ToArray<string>()
					}
				};
			}
			string[] result;
			if (!RenderConfig.SpecifiedTypeBodyNames.TryGetValue(bodyType, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x0602F6E0 RID: 194272 RVA: 0x00B45C24 File Offset: 0x00B43E24
		public static ECharacterSlotType GetMaterialSlotType(string slotName)
		{
			if (slotName.StartsWith("MI_"))
			{
				return ECharacterSlotType.Body;
			}
			if (slotName.StartsWith("OL_"))
			{
				return ECharacterSlotType.Outline;
			}
			if (slotName.StartsWith("HETA_"))
			{
				return ECharacterSlotType.HairEyeTransparent;
			}
			if (slotName.StartsWith("HET_"))
			{
				return ECharacterSlotType.EyeMask;
			}
			if (slotName.StartsWith("FS_"))
			{
				return ECharacterSlotType.FaceShadow;
			}
			return ECharacterSlotType.Error;
		}

		// Token: 0x0602F6E1 RID: 194273 RVA: 0x00B45C80 File Offset: 0x00B43E80
		public static ECharacterMeshPart GetMaterialPartType(string slotName)
		{
			string text = slotName.ToLower();
			if (text.Contains("bang"))
			{
				return ECharacterMeshPart.Bangs;
			}
			if (text.Contains("hair") || text.Contains("fur"))
			{
				return ECharacterMeshPart.Hair;
			}
			if (text.Contains("head"))
			{
				return ECharacterMeshPart.Head;
			}
			if (text.Contains("face"))
			{
				return ECharacterMeshPart.Face;
			}
			if (text.Contains("eye"))
			{
				return ECharacterMeshPart.Eye;
			}
			if (text.Contains("body"))
			{
				return ECharacterMeshPart.Body;
			}
			if (text.Contains("up"))
			{
				return ECharacterMeshPart.Up;
			}
			if (text.Contains("down"))
			{
				return ECharacterMeshPart.Down;
			}
			if (text.Contains("leg"))
			{
				return ECharacterMeshPart.Leg;
			}
			if (text.Contains("cloth"))
			{
				return ECharacterMeshPart.Cloth;
			}
			if (text.Contains("skirt"))
			{
				return ECharacterMeshPart.Skirt;
			}
			if (text.Contains("star"))
			{
				return ECharacterMeshPart.Star;
			}
			if (text.Contains("core"))
			{
				return ECharacterMeshPart.Core;
			}
			if (text.Contains("hand"))
			{
				return ECharacterMeshPart.Hand;
			}
			if (text.Contains("wing"))
			{
				return ECharacterMeshPart.Wings;
			}
			if (text.Contains("prop"))
			{
				return ECharacterMeshPart.Prop;
			}
			if (text.Contains("weapon"))
			{
				return ECharacterMeshPart.Weapon;
			}
			return ECharacterMeshPart.Error;
		}

		// Token: 0x0602F6E2 RID: 194274 RVA: 0x00B45DAA File Offset: 0x00B43FAA
		public static void CreateStaticDefaultValue()
		{
			RenderConfig.UseMaterialContainerV2 = true;
			RenderConfig.UseCharUnrealCacheObject = true;
		}

		// Token: 0x0602F6E3 RID: 194275 RVA: 0x00B45DB8 File Offset: 0x00B43FB8
		public static void ResetStaticDefaultValue()
		{
			RenderConfig.UseMaterialContainerV2 = true;
			RenderConfig.UseCharUnrealCacheObject = true;
			RenderConfig.MaterialControlBodyTypes = null;
			RenderConfig.EntityTypeToRenderPriorityMap = null;
			RenderConfig.SpecifiedTypeBodyNames = null;
		}

		// Token: 0x0401B0A5 RID: 110757
		public const int INVALID_SECTION_INDEX = 99999;

		// Token: 0x0401B0A6 RID: 110758
		public static bool UseMaterialContainerV2;

		// Token: 0x0401B0A7 RID: 110759
		public static bool UseCharUnrealCacheObject;

		// Token: 0x0401B0A8 RID: 110760
		[StaticVariableRuleIgnore]
		public static readonly string[] MaterialControlAllCaseArray = new string[]
		{
			"CharacterMesh0",
			"WeaponCase0",
			"WeaponCase1",
			"WeaponCase2",
			"WeaponCase3",
			"WeaponCase4",
			"HuluCase",
			"OtherCase0",
			"OtherCase1",
			"OtherCase2",
			"OtherCase3",
			"OtherCase4",
			"GenericCase0",
			"GenericCase1",
			"GenericCase2",
			"GenericCase3",
			"GenericCase4"
		};

		// Token: 0x0401B0A9 RID: 110761
		[StaticVariableRuleIgnore]
		public static readonly string[] MaterialControlBodyCaseArray = new string[]
		{
			"CharacterMesh0"
		};

		// Token: 0x0401B0AA RID: 110762
		[StaticVariableRuleIgnore]
		public static readonly string[] MaterialControlWeaponCaseArray = new string[]
		{
			"WeaponCase0",
			"WeaponCase1",
			"WeaponCase2",
			"WeaponCase3",
			"WeaponCase4"
		};

		// Token: 0x0401B0AB RID: 110763
		[StaticVariableRuleIgnore]
		public static readonly string[] MaterialControlHuluCaseArray = new string[]
		{
			"HuluCase"
		};

		// Token: 0x0401B0AC RID: 110764
		[StaticVariableRuleIgnore]
		public static readonly string[] MaterialControlWeaponAndHuluCaseArray = new string[]
		{
			"WeaponCase0",
			"WeaponCase1",
			"WeaponCase2",
			"WeaponCase3",
			"WeaponCase4",
			"HuluCase"
		};

		// Token: 0x0401B0AD RID: 110765
		[StaticVariableRuleIgnore]
		public static readonly string[] MaterialControlOtherCaseArray = new string[]
		{
			"OtherCase0",
			"OtherCase1",
			"OtherCase2",
			"OtherCase3",
			"OtherCase4"
		};

		// Token: 0x0401B0AE RID: 110766
		[StaticVariableRuleIgnore]
		public static readonly string[] MaterialControlExtraBodyCaseArray = new string[]
		{
			"CharacterMesh0_ExtraMesh"
		};

		// Token: 0x0401B0AF RID: 110767
		[StaticVariableRuleIgnore]
		public static readonly EKuroCharMeshPart[] MeshPartsHeadArray;

		// Token: 0x0401B0B0 RID: 110768
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private static Dictionary<string, ECharacterBodyType> MaterialControlBodyTypes;

		// Token: 0x0401B0B1 RID: 110769
		[Nullable(2)]
		private static Dictionary<EEntityType, EEntityTypePriority> EntityTypeToRenderPriorityMap;

		// Token: 0x0401B0B2 RID: 110770
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private static Dictionary<ECharacterBodySpecifiedType, string[]> SpecifiedTypeBodyNames;

		// Token: 0x0401B0B3 RID: 110771
		public const string CharMaterialContainerDataPath = "/Game/Aki/Render/RuntimeBP/Character/MaterialContainer/DA_CharacterMaterialContainerData.DA_CharacterMaterialContainerData";

		// Token: 0x0401B0B4 RID: 110772
		public const string HolographicPath = "/Game/Aki/Effect/EffectGroup/Sequence/Common/DA_Fx_Group_Seq_Communicate.DA_Fx_Group_Seq_Communicate";

		// Token: 0x0401B0B5 RID: 110773
		public const int RefErrorCount = 20;

		// Token: 0x0401B0B6 RID: 110774
		public static readonly FName UseRim;

		// Token: 0x0401B0B7 RID: 110775
		public static readonly FName RimUseTex;

		// Token: 0x0401B0B8 RID: 110776
		public static readonly FName RimChannel;

		// Token: 0x0401B0B9 RID: 110777
		public static readonly FName RimRange;

		// Token: 0x0401B0BA RID: 110778
		public static readonly FName RimColor;

		// Token: 0x0401B0BB RID: 110779
		public static readonly FName RimIntensity;

		// Token: 0x0401B0BC RID: 110780
		public static readonly FName UseDissolve;

		// Token: 0x0401B0BD RID: 110781
		public static readonly FName DissolveChannelSwitch;

		// Token: 0x0401B0BE RID: 110782
		public static readonly FName DissolveProgress;

		// Token: 0x0401B0BF RID: 110783
		public static readonly FName DissolveSmooth;

		// Token: 0x0401B0C0 RID: 110784
		public static readonly FName DissolveMulti;

		// Token: 0x0401B0C1 RID: 110785
		public static readonly FName DissolveEmission;

		// Token: 0x0401B0C2 RID: 110786
		public static readonly FName OutlineUseTex;

		// Token: 0x0401B0C3 RID: 110787
		public static readonly FName OutlineWidth;

		// Token: 0x0401B0C4 RID: 110788
		public static readonly FName OutlineColor;

		// Token: 0x0401B0C5 RID: 110789
		public static readonly FName OutlineColorIntensity;

		// Token: 0x0401B0C6 RID: 110790
		public static readonly FName UseTexture;

		// Token: 0x0401B0C7 RID: 110791
		public static readonly FName TextureUseMask;

		// Token: 0x0401B0C8 RID: 110792
		public static readonly FName TextureMaskRange;

		// Token: 0x0401B0C9 RID: 110793
		public static readonly FName NoiseTexture;

		// Token: 0x0401B0CA RID: 110794
		public static readonly FName TextureUvSwitch;

		// Token: 0x0401B0CB RID: 110795
		public static readonly FName TextureUseScreenUv;

		// Token: 0x0401B0CC RID: 110796
		public static readonly FName TextureScaleAndOffset;

		// Token: 0x0401B0CD RID: 110797
		public static readonly FName TextureSpeed;

		// Token: 0x0401B0CE RID: 110798
		public static readonly FName TextureColor;

		// Token: 0x0401B0CF RID: 110799
		public static readonly FName TextureRotation;

		// Token: 0x0401B0D0 RID: 110800
		public static readonly FName BaseUseTex;

		// Token: 0x0401B0D1 RID: 110801
		public static readonly FName BaseColor;

		// Token: 0x0401B0D2 RID: 110802
		public static readonly FName BaseColorIntensity;

		// Token: 0x0401B0D3 RID: 110803
		public static readonly FName EmissionUseTex;

		// Token: 0x0401B0D4 RID: 110804
		public static readonly FName EmissionColor;

		// Token: 0x0401B0D5 RID: 110805
		public static readonly FName EmissionIntensity;

		// Token: 0x0401B0D6 RID: 110806
		public static readonly FName UseHeadMaskHideEffect;

		// Token: 0x0401B0D7 RID: 110807
		public static readonly FName DitherUseInRayTracing;

		// Token: 0x0401B0D8 RID: 110808
		public static readonly FName UseDitherEffect;

		// Token: 0x0401B0D9 RID: 110809
		public static readonly FName DitherValue;

		// Token: 0x0401B0DA RID: 110810
		public static readonly FName DitherValueMainPass;

		// Token: 0x0401B0DB RID: 110811
		public static readonly FName UseDitherEffect2;

		// Token: 0x0401B0DC RID: 110812
		public static readonly FName DitherValue2;

		// Token: 0x0401B0DD RID: 110813
		public static readonly FName CharacterAmbientColor;

		// Token: 0x0401B0DE RID: 110814
		public static readonly FName CharacterSkinAmbientColor;

		// Token: 0x0401B0DF RID: 110815
		public static readonly FName EnableTransfer;

		// Token: 0x0401B0E0 RID: 110816
		public static readonly FName TransferDensity;

		// Token: 0x0401B0E1 RID: 110817
		public static readonly FName TransferHardness;

		// Token: 0x0401B0E2 RID: 110818
		public static readonly FName TransferDirection;

		// Token: 0x0401B0E3 RID: 110819
		public static readonly FName TransferHeight;

		// Token: 0x0401B0E4 RID: 110820
		public static readonly FName TransferOutlineColor;

		// Token: 0x0401B0E5 RID: 110821
		public static readonly FName MotionRange;

		// Token: 0x0401B0E6 RID: 110822
		public static readonly FName MotionOffset;

		// Token: 0x0401B0E7 RID: 110823
		public static readonly FName MotionNoiseSpeed;

		// Token: 0x0401B0E8 RID: 110824
		public static readonly FName StarScarEnergyControl;

		// Token: 0x0401B0E9 RID: 110825
		public static readonly FName TexMipOffset;

		// Token: 0x0401B0EA RID: 110826
		public static readonly FName RootName;

		// Token: 0x0401B0EB RID: 110827
		public static readonly FName UIName;

		// Token: 0x0401B0EC RID: 110828
		public static readonly FName GlobalRainIntensity;

		// Token: 0x0401B0ED RID: 110829
		public static readonly FName GlobalSnowIntensity;

		// Token: 0x0401B0EE RID: 110830
		public static readonly FName GlobalWindSpeed;

		// Token: 0x0401B0EF RID: 110831
		public static readonly FName GlobalGrassAO;

		// Token: 0x0401B0F0 RID: 110832
		public static readonly FName GlobalMainLightVector;

		// Token: 0x0401B0F1 RID: 110833
		public static readonly FName GlobalLensFlareColorTint;

		// Token: 0x0401B0F2 RID: 110834
		public static readonly FName GlobalCharacterPreviousWP;

		// Token: 0x0401B0F3 RID: 110835
		public static readonly FName GlobalCharacterWorldPosition;

		// Token: 0x0401B0F4 RID: 110836
		public static readonly FName GlobalCharacterWeaponPosition;

		// Token: 0x0401B0F5 RID: 110837
		public static readonly FName GlobalCharacterWorldForwardDirection;

		// Token: 0x0401B0F6 RID: 110838
		public static readonly FName GlobalCharacterOnGround;

		// Token: 0x0401B0F7 RID: 110839
		public static readonly FName GlobalCameraPosAndRadius;

		// Token: 0x0401B0F8 RID: 110840
		public static readonly FName UseSocketTransform;

		// Token: 0x0401B0F9 RID: 110841
		public static readonly FName UseClipboardTransform;

		// Token: 0x0401B0FA RID: 110842
		public static readonly FName UseSocketTransform2;

		// Token: 0x0401B0FB RID: 110843
		public static readonly FName UseClipboardTransform2;

		// Token: 0x0401B0FC RID: 110844
		public static readonly FName PhysicsActor;

		// Token: 0x0401B0FD RID: 110845
		public static readonly FName WaterCollisionProfileName;

		// Token: 0x0401B0FE RID: 110846
		public static readonly FName UIShowBrightness;

		// Token: 0x0401B0FF RID: 110847
		public static readonly FName UIShowSaturation;

		// Token: 0x0401B100 RID: 110848
		public static readonly FName UIShowContrast;

		// Token: 0x0401B101 RID: 110849
		public static readonly FName GlobalTimeHour;

		// Token: 0x0401B102 RID: 110850
		public static readonly FName GlobalTimeMinutes;

		// Token: 0x0401B103 RID: 110851
		public static readonly FName GravityDirection;

		// Token: 0x0401B104 RID: 110852
		public static readonly FName IsPlayerMale;

		// Token: 0x0401B105 RID: 110853
		public const int IdMaterialContainer = 1;

		// Token: 0x0401B106 RID: 110854
		public const int IdMaterialController = 2;

		// Token: 0x0401B107 RID: 110855
		public const int IdDitherEffect = 3;

		// Token: 0x0401B108 RID: 110856
		public const int IdBadSignal = 4;

		// Token: 0x0401B109 RID: 110857
		public const int IdSceneInteraction = 5;

		// Token: 0x0401B10A RID: 110858
		public const int IdPropertyModifier = 6;

		// Token: 0x0401B10B RID: 110859
		public const int IdComplexBroken = 7;

		// Token: 0x0401B10C RID: 110860
		public const int IdNpcDitherEffect = 8;

		// Token: 0x0401B10D RID: 110861
		public const int IdBodyEffect = 9;

		// Token: 0x0401B10E RID: 110862
		public const int IdDecalShadow = 10;

		// Token: 0x0401B10F RID: 110863
		public const int IdGrassInteraction = 11;

		// Token: 0x0401B110 RID: 110864
		public const int IdExtraMesh = 12;

		// Token: 0x0401B111 RID: 110865
		public const int IdMaterialContainerV2 = 13;

		// Token: 0x0401B112 RID: 110866
		public const int IdMaterialControllerV2 = 14;

		// Token: 0x0401B113 RID: 110867
		public const int IdEnviInteractionEffect = 15;

		// Token: 0x0401B114 RID: 110868
		public const string EmptyMaterialPath = "/Game/Aki/Render/Shaders/Character/MI_Empty";

		// Token: 0x0401B115 RID: 110869
		public static readonly FName E_Action_UseBaseColorScale;

		// Token: 0x0401B116 RID: 110870
		public static readonly FName E_Action_BaseColorScale;

		// Token: 0x0401B117 RID: 110871
		public static readonly FName E_Action_UseEmissionColor;

		// Token: 0x0401B118 RID: 110872
		public static readonly FName E_Action_EmissionColor;

		// Token: 0x0401B119 RID: 110873
		public static readonly FName E_Action_UseRimLight;

		// Token: 0x0401B11A RID: 110874
		public static readonly FName E_Action_RimLightColor;

		// Token: 0x0401B11B RID: 110875
		public static readonly FName E_Action_RimPower;

		// Token: 0x0401B11C RID: 110876
		public static readonly FName E_Action_UseEmissionChange;

		// Token: 0x0401B11D RID: 110877
		public static readonly FName E_Action_EmissionLightColorChangeColor;

		// Token: 0x0401B11E RID: 110878
		public static readonly FName E_Action_EmissionLightColorChangeStrength;

		// Token: 0x0401B11F RID: 110879
		public static readonly FName E_Action_EmissionLightColorChangeProgress;

		// Token: 0x0401B120 RID: 110880
		public static readonly FName E_Action_UseDissolve;

		// Token: 0x0401B121 RID: 110881
		public static readonly FName E_Action_DissolveProgress;

		// Token: 0x0401B122 RID: 110882
		public static readonly FName E_Action_DissolveAdjustment;

		// Token: 0x0401B123 RID: 110883
		public static readonly FName E_Action_DissolveEdageWidth;

		// Token: 0x0401B124 RID: 110884
		public static readonly FName E_Action_DissolveEdageColor;

		// Token: 0x0401B125 RID: 110885
		public static readonly FName E_Action_DissolveEdageStrength;

		// Token: 0x0401B126 RID: 110886
		public static readonly FName E_Action_DissolveTex_S_O;

		// Token: 0x0401B127 RID: 110887
		public static readonly FName E_Action_DissolveTexSpeed;

		// Token: 0x0401B128 RID: 110888
		public static readonly FName E_Tex_DissolveTexUVSwitch;

		// Token: 0x0401B129 RID: 110889
		public static readonly FName E_Action_ScanningOutlineMixNoiseStrength;

		// Token: 0x0401B12A RID: 110890
		public static readonly FName E_Action_GlobalBaseColorScale;

		// Token: 0x0401B12B RID: 110891
		public static readonly FName E_Action_GlobalAddEmissionColor;

		// Token: 0x0401B12C RID: 110892
		public static readonly FName E_Action_ScanningOutline;

		// Token: 0x0401B12D RID: 110893
		public static readonly FName E_Action_GlobalRimLight;

		// Token: 0x0401B12E RID: 110894
		public static readonly FName E_Action_UseScanning;

		// Token: 0x0401B12F RID: 110895
		public static readonly FName E_Action_RimMix;

		// Token: 0x0401B130 RID: 110896
		public static readonly FName E_Action_ScanningOutlineStrength;

		// Token: 0x0401B131 RID: 110897
		public static readonly FName E_Action_ScanningTex_S_O;

		// Token: 0x0401B132 RID: 110898
		public static readonly FName E_Action_ScanningOutlineColor;

		// Token: 0x0401B133 RID: 110899
		public static readonly FName E_Action_RimWidth;

		// Token: 0x0401B134 RID: 110900
		public static readonly FName BrokenTex_S_O;

		// Token: 0x0401B135 RID: 110901
		public static readonly FName OutlineTex_S_O;

		// Token: 0x0401B136 RID: 110902
		public static readonly FName E_Action_VertexAnim_TimeDebug;

		// Token: 0x0401B137 RID: 110903
		public static readonly FName E_Action_VertexAnim_Frame;

		// Token: 0x0401B138 RID: 110904
		public static readonly FName E_Action_PivotPainterTransform;

		// Token: 0x0401B139 RID: 110905
		public static readonly FName E_Action_PivotPainter_FloatingThreshold;

		// Token: 0x0401B13A RID: 110906
		public static readonly FName E_Action_UsePivotPainterWorldPositionOffset;

		// Token: 0x0401B13B RID: 110907
		public static readonly FName E_Action_UseWPO;

		// Token: 0x0401B13C RID: 110908
		public static readonly FName E_Action_DisableFoliageEffect;

		// Token: 0x0401B13D RID: 110909
		public static readonly FName E_Action_EnableFoliageEffect;

		// Token: 0x0401B13E RID: 110910
		public static readonly FName E_Action_RimLightColorSpecil;

		// Token: 0x0401B13F RID: 110911
		public static readonly FName E_Action_UseRimlightColorSpecil;

		// Token: 0x0401B140 RID: 110912
		public static readonly FName E_Action_RimlightColorStrength;

		// Token: 0x0401B141 RID: 110913
		public static readonly FName E_Action_SimpleWPO_Normal;

		// Token: 0x0401B142 RID: 110914
		public static readonly FName E_Action_SimpleWPO_Offset;

		// Token: 0x0401B143 RID: 110915
		public static readonly FName E_Action_UseEmissionTex;

		// Token: 0x0401B144 RID: 110916
		public static readonly FName E_Action_EmissionTexStrength;

		// Token: 0x0401B145 RID: 110917
		public static readonly FName E_Action_Simple_Uspeed;

		// Token: 0x0401B146 RID: 110918
		public static readonly FName E_Action_Simple_Vspeed;

		// Token: 0x0401B147 RID: 110919
		public static readonly FName E_Action_Simple_UseFlow;

		// Token: 0x0401B148 RID: 110920
		public static readonly FName E_Action_UseQuanXiPinTu;

		// Token: 0x0401B149 RID: 110921
		public static readonly FName E_Action_TransparencyQuanXiPinTu;

		// Token: 0x0401B14A RID: 110922
		public static readonly FName E_Action_TransparentColorQuanXiPinTu;

		// Token: 0x0401B14B RID: 110923
		public static readonly FName E_Action_OpaqueColorQuanXiPinTu;

		// Token: 0x0401B14C RID: 110924
		public static readonly FName E_Action_UseQuanXiFengSuo;

		// Token: 0x0401B14D RID: 110925
		public static readonly FName E_Action_TransparencyQuanXiFengSuo;

		// Token: 0x0401B14E RID: 110926
		public static readonly FName E_Action_TransparentColorQuanXiFengSuo;
	}
}
