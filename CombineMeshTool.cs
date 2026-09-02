using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using AkiClient.Game.Aki.Character.NPC.Common;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Npc;
using UnrealEngine;

// Token: 0x02002E2D RID: 11821
[NullableContext(1)]
[Nullable(0)]
public class CombineMeshTool
{
	// Token: 0x06017F5D RID: 98141 RVA: 0x006B5C98 File Offset: 0x006B3E98
	[NullableContext(2)]
	public static void LoadDaConfig(AActor actor, FTransform defaultTransform, USkeletalMeshComponent mainMeshComp, PD_NpcSetupData_C config)
	{
		if (actor == null || mainMeshComp == null || config == null)
		{
			return;
		}
		UKuroMaterialControllerComponent ukuroMaterialControllerComponent = UKuroMaterialControllerComponent.AddOrGetMaterialControllerComponentFromActor(actor);
		if (ukuroMaterialControllerComponent == null)
		{
			return;
		}
		CombineMeshTool.ResetMesh(mainMeshComp, config);
		CombineMeshTool.LoadHair(actor, defaultTransform, mainMeshComp, config.Skel_Hair, config, ukuroMaterialControllerComponent);
		CombineMeshTool.LoadFace(actor, defaultTransform, mainMeshComp, config.Skel_Face, config, ukuroMaterialControllerComponent);
		if (config.NpcSetupType == ENpcSetupType.NpcSetupType2)
		{
			CombineMeshTool.LoadBodyUp(actor, defaultTransform, mainMeshComp, config.Skel_BodyUp, config, ukuroMaterialControllerComponent);
			CombineMeshTool.LoadBodyDown(actor, defaultTransform, mainMeshComp, config.Skel_BodyDown, config, ukuroMaterialControllerComponent);
		}
		else
		{
			CombineMeshTool.LoadBody(actor, defaultTransform, mainMeshComp, config.Skel_Body, config, ukuroMaterialControllerComponent);
		}
		CombineMeshTool.SetupSocket(actor, mainMeshComp, config.Hook_Arm, config.Hook_Arm_Socket, config, ukuroMaterialControllerComponent);
		CombineMeshTool.SetupSocket(actor, mainMeshComp, config.Hook_Back, config.Hook_Back_Socket, config, ukuroMaterialControllerComponent);
		CombineMeshTool.SetupSocket(actor, mainMeshComp, config.Hook_Leg, config.Hook_Leg_Socket, config, ukuroMaterialControllerComponent);
		CombineMeshTool.SetupSocket(actor, mainMeshComp, config.Hook_Waist, config.Hook_Waist_Socket, config, ukuroMaterialControllerComponent);
		CombineMeshTool.SetupSocket(actor, mainMeshComp, config.Hook_Weapon, config.Hook_Weapon_Socket, config, ukuroMaterialControllerComponent);
		CombineMeshTool.SetupSocket(actor, mainMeshComp, config.Hook_Head, config.Hook_Head_Socket, config, ukuroMaterialControllerComponent);
		CombineMeshTool.SetupChildPart(actor, mainMeshComp, defaultTransform, config.ChildParts, config, ukuroMaterialControllerComponent);
		CombineMeshTool.SetupHideBones(mainMeshComp, config.HideParentBoneNames);
		ukuroMaterialControllerComponent.UpdateEffects();
	}

	// Token: 0x06017F5E RID: 98142 RVA: 0x006B5DC1 File Offset: 0x006B3FC1
	private static void ResetMesh(USkeletalMeshComponent mainMeshComp, PD_NpcSetupData_C config)
	{
		mainMeshComp.SetSkeletalMesh(null, true);
		mainMeshComp.SetVisibility(true, false);
		mainMeshComp.bRenderInMainPass = false;
		mainMeshComp.CastShadow = true;
		if (!ObjectUtils.IsValid(config.Skel_Main))
		{
			return;
		}
		mainMeshComp.SetSkeletalMesh(config.Skel_Main, true);
	}

	// Token: 0x06017F5F RID: 98143 RVA: 0x006B5DFC File Offset: 0x006B3FFC
	[return: Nullable(2)]
	private static USkeletalMeshComponent SetupPartSkeletalMesh(PD_NpcSetupData_C npcData, AActor actor, FTransform transform, USkeletalMeshComponent mainMeshComp, [Nullable(2)] USkeletalMesh partMesh, FName partMeshName, bool isSocket = false, int index = 0)
	{
		if (partMesh == null || !ObjectUtils.IsValid(partMesh))
		{
			return null;
		}
		if (!ObjectUtils.IsValid(actor))
		{
			return null;
		}
		USkeletalMeshComponent uskeletalMeshComponent = actor.AddComponentByClass(USkeletalMeshComponent.StaticClass(), true, transform, false, CombineMeshTool.GetPartMeshName(partMeshName, index)) as USkeletalMeshComponent;
		if (!ObjectUtils.IsValid(uskeletalMeshComponent))
		{
			return null;
		}
		uskeletalMeshComponent.bUseAttachParentBound = true;
		uskeletalMeshComponent.bUseBoundsFromMasterPoseComponent = true;
		uskeletalMeshComponent.SetSkeletalMesh(partMesh, true);
		if (!isSocket)
		{
			uskeletalMeshComponent.SetMasterPoseComponent(mainMeshComp, false);
		}
		uskeletalMeshComponent.CastShadow = false;
		uskeletalMeshComponent.bForceCastRaytracingShadow = true;
		if (!uskeletalMeshComponent.K2_AttachToComponent(mainMeshComp, isSocket ? partMeshName : FName.NAME_None, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.KeepRelative, true, true))
		{
			uskeletalMeshComponent.K2_DestroyComponent(actor);
			return null;
		}
		if (isSocket)
		{
			uskeletalMeshComponent.K2_SetRelativeTransform(transform, false, ref WorldGlobal.SweepHitResult, false);
		}
		uskeletalMeshComponent.ComponentTags.Add(CombineMeshTool.PartMeshComp);
		return uskeletalMeshComponent;
	}

	// Token: 0x06017F60 RID: 98144 RVA: 0x006B5EC8 File Offset: 0x006B40C8
	private static void LoadHair(AActor actor, FTransform defaultTransform, USkeletalMeshComponent mainMeshComp, USkeletalMesh hairMesh, PD_NpcSetupData_C config, UKuroMaterialControllerComponent controllerComp)
	{
		USkeletalMeshComponent uskeletalMeshComponent = CombineMeshTool.SetupPartSkeletalMesh(config, actor, defaultTransform, mainMeshComp, hairMesh, CombineMeshTool.HairName, false, 0);
		if (uskeletalMeshComponent == null)
		{
			return;
		}
		uskeletalMeshComponent.bRunPostUpdateTick = false;
		controllerComp.AddSkeletalMeshComponent(uskeletalMeshComponent, CombineMeshTool.HairName, false);
		if (!config.bDyeColor)
		{
			return;
		}
		FColor skel_Hair_Color = config.Skel_Hair_Color;
		FLinearColor value = new FLinearColor(ref skel_Hair_Color);
		value.A = 1f;
		CombineMeshTool.SetupMaterialColor(controllerComp, CombineMeshTool.HairName, config.SkinDyeColor, new FLinearColor?(value), null);
		UMaterialInstance hair_Mat = config.Hair_Mat;
		TArray<UMaterialInstance> hair_Mat_Extra = config.Hair_Mat_Extra;
		int num = hair_Mat_Extra.Num() + 1;
		TArray<UMaterialInterface> referencedOulineMaterials = config.ReferencedOulineMaterials;
		CombineMeshTool.SetupCustomMaterial(controllerComp, CombineMeshTool.HairName, hair_Mat, 0, num, referencedOulineMaterials);
		for (int i = 1; i < num; i++)
		{
			CombineMeshTool.SetupCustomMaterial(controllerComp, CombineMeshTool.HairName, hair_Mat_Extra.Get(i - 1), i, num, referencedOulineMaterials);
		}
	}

	// Token: 0x06017F61 RID: 98145 RVA: 0x006B5FB0 File Offset: 0x006B41B0
	private static void LoadFace(AActor actor, FTransform defaultTransform, USkeletalMeshComponent mainMeshComp, USkeletalMesh faceMesh, PD_NpcSetupData_C config, UKuroMaterialControllerComponent controllerComp)
	{
		USkeletalMeshComponent uskeletalMeshComponent = CombineMeshTool.SetupPartSkeletalMesh(config, actor, defaultTransform, mainMeshComp, faceMesh, CombineMeshTool.FaceName, false, 0);
		if (uskeletalMeshComponent == null)
		{
			return;
		}
		controllerComp.AddSkeletalMeshComponent(uskeletalMeshComponent, CombineMeshTool.FaceName, false);
		BP_BaseNPC_C bp_BaseNPC_C = actor as BP_BaseNPC_C;
		if (bp_BaseNPC_C != null)
		{
			bp_BaseNPC_C.CombineFaceMesh = uskeletalMeshComponent;
		}
		if (!config.bDyeColor)
		{
			return;
		}
		CombineMeshTool.SetupMaterialColor(controllerComp, CombineMeshTool.FaceName, config.SkinDyeColor, null, null);
		UMaterialInstance face_Mat = config.Face_Mat;
		TArray<UMaterialInstance> face_Mat_Extra = config.Face_Mat_Extra;
		int num = face_Mat_Extra.Num() + 1;
		TArray<UMaterialInterface> referencedOulineMaterials = config.ReferencedOulineMaterials;
		CombineMeshTool.SetupCustomMaterial(controllerComp, CombineMeshTool.FaceName, face_Mat, 0, num, referencedOulineMaterials);
		for (int i = 1; i < num; i++)
		{
			CombineMeshTool.SetupCustomMaterial(controllerComp, CombineMeshTool.FaceName, face_Mat_Extra.Get(i - 1), i, num, referencedOulineMaterials);
		}
	}

	// Token: 0x06017F62 RID: 98146 RVA: 0x006B6088 File Offset: 0x006B4288
	private static void LoadBodyUp(AActor actor, FTransform defaultTransform, USkeletalMeshComponent mainMeshComp, USkeletalMesh bodyUpMesh, PD_NpcSetupData_C config, UKuroMaterialControllerComponent controllerComp)
	{
		USkeletalMeshComponent uskeletalMeshComponent = CombineMeshTool.SetupPartSkeletalMesh(config, actor, defaultTransform, mainMeshComp, bodyUpMesh, CombineMeshTool.BodyUpName, false, 0);
		if (uskeletalMeshComponent == null)
		{
			return;
		}
		uskeletalMeshComponent.bRunPostUpdateTick = false;
		controllerComp.AddSkeletalMeshComponent(uskeletalMeshComponent, CombineMeshTool.BodyUpName, false);
		if (!config.bDyeColor)
		{
			return;
		}
		FColor skel_BodyUp_Color = config.Skel_BodyUp_Color;
		FLinearColor value = new FLinearColor(ref skel_BodyUp_Color);
		value.A = 1f;
		CombineMeshTool.SetupMaterialColor(controllerComp, CombineMeshTool.BodyUpName, config.SkinDyeColor, new FLinearColor?(value), null);
		UMaterialInstance skel_BodyUp_Mat = config.Skel_BodyUp_Mat;
		TArray<UMaterialInstance> skel_BodyUp_Mat_Extra = config.Skel_BodyUp_Mat_Extra;
		int num = skel_BodyUp_Mat_Extra.Num() + 1;
		TArray<UMaterialInterface> referencedOulineMaterials = config.ReferencedOulineMaterials;
		CombineMeshTool.SetupCustomMaterial(controllerComp, CombineMeshTool.BodyUpName, skel_BodyUp_Mat, 0, num, referencedOulineMaterials);
		for (int i = 1; i < num; i++)
		{
			CombineMeshTool.SetupCustomMaterial(controllerComp, CombineMeshTool.BodyUpName, skel_BodyUp_Mat_Extra.Get(i - 1), i, num, referencedOulineMaterials);
		}
	}

	// Token: 0x06017F63 RID: 98147 RVA: 0x006B6170 File Offset: 0x006B4370
	private static void LoadBodyDown(AActor actor, FTransform defaultTransform, USkeletalMeshComponent mainMeshComp, USkeletalMesh bodyDownMesh, PD_NpcSetupData_C config, UKuroMaterialControllerComponent controllerComp)
	{
		USkeletalMeshComponent uskeletalMeshComponent = CombineMeshTool.SetupPartSkeletalMesh(config, actor, defaultTransform, mainMeshComp, bodyDownMesh, CombineMeshTool.BodyDownName, false, 0);
		if (uskeletalMeshComponent == null)
		{
			return;
		}
		uskeletalMeshComponent.bRunPostUpdateTick = false;
		controllerComp.AddSkeletalMeshComponent(uskeletalMeshComponent, CombineMeshTool.BodyDownName, false);
		if (!config.bDyeColor)
		{
			return;
		}
		FColor skel_BodyDown_Color = config.Skel_BodyDown_Color;
		FLinearColor value = new FLinearColor(ref skel_BodyDown_Color);
		value.A = 1f;
		CombineMeshTool.SetupMaterialColor(controllerComp, CombineMeshTool.BodyDownName, config.SkinDyeColor, new FLinearColor?(value), null);
		UMaterialInstance skel_BodyDown_Mat = config.Skel_BodyDown_Mat;
		TArray<UMaterialInstance> skel_BodyDown_Mat_Extra = config.Skel_BodyDown_Mat_Extra;
		int num = skel_BodyDown_Mat_Extra.Num() + 1;
		TArray<UMaterialInterface> referencedOulineMaterials = config.ReferencedOulineMaterials;
		CombineMeshTool.SetupCustomMaterial(controllerComp, CombineMeshTool.BodyDownName, skel_BodyDown_Mat, 0, num, referencedOulineMaterials);
		for (int i = 1; i < num; i++)
		{
			CombineMeshTool.SetupCustomMaterial(controllerComp, CombineMeshTool.BodyDownName, skel_BodyDown_Mat_Extra.Get(i - 1), i, num, referencedOulineMaterials);
		}
	}

	// Token: 0x06017F64 RID: 98148 RVA: 0x006B6258 File Offset: 0x006B4458
	private static void LoadBody(AActor actor, FTransform defaultTransform, USkeletalMeshComponent mainMeshComp, USkeletalMesh bodyMesh, PD_NpcSetupData_C config, UKuroMaterialControllerComponent controllerComp)
	{
		USkeletalMeshComponent uskeletalMeshComponent = CombineMeshTool.SetupPartSkeletalMesh(config, actor, defaultTransform, mainMeshComp, bodyMesh, CombineMeshTool.BodyName, false, 0);
		if (uskeletalMeshComponent == null)
		{
			return;
		}
		uskeletalMeshComponent.bRunPostUpdateTick = false;
		controllerComp.AddSkeletalMeshComponent(uskeletalMeshComponent, CombineMeshTool.BodyName, false);
		if (!config.bDyeColor)
		{
			return;
		}
		FColor fcolor = config.Body_Dyecolor01;
		FLinearColor value = new FLinearColor(ref fcolor);
		value.A = 1f;
		fcolor = config.Body_Dyecolor02;
		FLinearColor value2 = new FLinearColor(ref fcolor);
		value2.A = 1f;
		CombineMeshTool.SetupMaterialColor(controllerComp, CombineMeshTool.BodyName, config.SkinDyeColor, new FLinearColor?(value), new FLinearColor?(value2));
		UMaterialInstance skel_Body_Mat = config.Skel_Body_Mat;
		TArray<UMaterialInstance> skel_Body_Mat_Extra = config.Skel_Body_Mat_Extra;
		int num = skel_Body_Mat_Extra.Num() + 1;
		TArray<UMaterialInterface> referencedOulineMaterials = config.ReferencedOulineMaterials;
		CombineMeshTool.SetupCustomMaterial(controllerComp, CombineMeshTool.BodyName, skel_Body_Mat, 0, num, referencedOulineMaterials);
		for (int i = 1; i < num; i++)
		{
			CombineMeshTool.SetupCustomMaterial(controllerComp, CombineMeshTool.BodyName, skel_Body_Mat_Extra.Get(i - 1), i, num, referencedOulineMaterials);
		}
	}

	// Token: 0x06017F65 RID: 98149 RVA: 0x006B635C File Offset: 0x006B455C
	private static void SetupMaterialColor(UKuroMaterialControllerComponent controllerComp, FName bodyName, FLinearColor skinColor, FLinearColor? color1 = null, FLinearColor? color2 = null)
	{
		if (controllerComp != null)
		{
			controllerComp.AddColorUpdateParamPermanentCustom(CombineMeshTool.SkinDyeColor, skinColor, bodyName, EKuroCharSlotSpecifiedType.All, "");
		}
		if (color1 != null && controllerComp != null)
		{
			controllerComp.AddColorUpdateParamPermanentCustom(CombineMeshTool.BaseColorTint1, color1.Value, bodyName, EKuroCharSlotSpecifiedType.All, "");
		}
		if (color2 != null && controllerComp != null)
		{
			controllerComp.AddColorUpdateParamPermanentCustom(CombineMeshTool.BaseColorTint2, color2.Value, bodyName, EKuroCharSlotSpecifiedType.All, "");
		}
	}

	// Token: 0x06017F66 RID: 98150 RVA: 0x006B63CC File Offset: 0x006B45CC
	private static void SetupCustomMaterial(UKuroMaterialControllerComponent controllerComp, FName bodyName, [Nullable(2)] UMaterialInstance mat, int index = 0, int numBodySlots = 1, [Nullable(new byte[]
	{
		2,
		1
	})] TArray<UMaterialInterface> outlineRefs = null)
	{
		if (mat == null || !mat.IsValid())
		{
			return;
		}
		controllerComp.SetBaseMaterialByIndex(mat, bodyName, index);
		List<string> candidates = CombineMeshTool.BuildOutlineCandidates(UKismetSystemLibrary.GetPathName(mat));
		CombineMeshTool.SetupOutlineFromRefs(controllerComp, bodyName, index + numBodySlots, candidates, outlineRefs);
	}

	// Token: 0x06017F67 RID: 98151 RVA: 0x006B6408 File Offset: 0x006B4608
	private static List<string> BuildOutlineCandidates(string matPath)
	{
		string[] array = matPath.Split('.', StringSplitOptions.None);
		string text = array[0];
		string text2 = array[1];
		if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(text2))
		{
			return new List<string>();
		}
		CombineMeshTool.<>c__DisplayClass20_0 CS$<>8__locals1;
		CS$<>8__locals1.dir = text.Substring(0, text.LastIndexOf('/'));
		List<string> list = new List<string>();
		list.Add(CombineMeshTool.<BuildOutlineCandidates>g__Build|20_0(text2, ref CS$<>8__locals1));
		if (text2.Contains("_Seq"))
		{
			list.Add(CombineMeshTool.<BuildOutlineCandidates>g__Build|20_0(text2.Replace("_Seq", ""), ref CS$<>8__locals1));
		}
		if (Regex.IsMatch(text2, "_\\d\\d$"))
		{
			list.Add(CombineMeshTool.<BuildOutlineCandidates>g__Build|20_0(Regex.Replace(text2, "_\\d\\d$", "").Replace("_Seq", ""), ref CS$<>8__locals1));
		}
		if (Regex.IsMatch(text2, "_\\d\\dHair"))
		{
			list.Add(CombineMeshTool.<BuildOutlineCandidates>g__Build|20_0(Regex.Replace(text2, "_\\d\\d(?=Hair)", ""), ref CS$<>8__locals1));
		}
		return list;
	}

	// Token: 0x06017F68 RID: 98152 RVA: 0x006B64F4 File Offset: 0x006B46F4
	private static void SetupOutlineFromRefs(UKuroMaterialControllerComponent controllerComp, FName bodyName, int slotIndex, List<string> candidates, [Nullable(new byte[]
	{
		2,
		1
	})] TArray<UMaterialInterface> outlineRefs)
	{
		if (outlineRefs == null || outlineRefs.Num() == 0)
		{
			return;
		}
		foreach (string b in candidates)
		{
			for (int i = 0; i < outlineRefs.Num(); i++)
			{
				UMaterialInterface umaterialInterface = outlineRefs.Get(i);
				if (umaterialInterface != null && umaterialInterface.IsValid() && UKismetSystemLibrary.GetPathName(umaterialInterface) == b)
				{
					controllerComp.SetBaseMaterialByIndex(umaterialInterface, bodyName, slotIndex);
					return;
				}
			}
		}
		UMaterialInterface umaterialInterface2 = outlineRefs.Get(0);
		if (umaterialInterface2 != null && umaterialInterface2.IsValid())
		{
			controllerComp.SetBaseMaterialByIndex(umaterialInterface2, bodyName, slotIndex);
		}
	}

	// Token: 0x06017F69 RID: 98153 RVA: 0x006B65AC File Offset: 0x006B47AC
	private static bool SetupMorphTargets(USkeletalMeshComponent meshComp, TArray<FMorphTargetPreviewItem> morphTargets)
	{
		if (!ObjectUtils.IsValid(meshComp))
		{
			return false;
		}
		if (morphTargets == null || morphTargets.Num() <= 0)
		{
			return true;
		}
		for (int i = 0; i < morphTargets.Num(); i++)
		{
			FMorphTargetPreviewItem fmorphTargetPreviewItem = morphTargets.Get(i);
			FName morphTargetName = new FName(fmorphTargetPreviewItem.MorphName);
			meshComp.SetMorphTarget(morphTargetName, fmorphTargetPreviewItem.PreviewValue, true);
		}
		return true;
	}

	// Token: 0x06017F6A RID: 98154 RVA: 0x006B6608 File Offset: 0x006B4808
	private unsafe static void SetupSocket(AActor actor, USkeletalMeshComponent mainMeshComp, TArray<SNpcHookPart> parts, FName socketName, PD_NpcSetupData_C config, UKuroMaterialControllerComponent controllerComp)
	{
		if (socketName == FName.NAME_None)
		{
			return;
		}
		if (parts == null || parts.Num() == 0)
		{
			return;
		}
		if (!mainMeshComp.DoesSocketExist(socketName))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Level;
			ELogAuthor author = ELogAuthor.CJH;
			string message = "目标不存在挂点";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Actor", actor);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Socket", socketName);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		for (int i = 0; i < parts.Num(); i++)
		{
			SNpcHookPart snpcHookPart = parts.Get(i);
			FTransform transform = snpcHookPart.Transform;
			USkeletalMesh mesh = snpcHookPart.Mesh;
			TArray<FMorphTargetPreviewItem> morphTargets = snpcHookPart.MorphTargets;
			TArray<SNpcHookPartMaterial> materialInfos = snpcHookPart.MaterialInfos;
			USkeletalMeshComponent uskeletalMeshComponent = CombineMeshTool.SetupPartSkeletalMesh(config, actor, transform, mainMeshComp, mesh, socketName, true, i);
			if (uskeletalMeshComponent != null)
			{
				uskeletalMeshComponent.bRunPostUpdateTick = false;
				CombineMeshTool.SetupMorphTargets(uskeletalMeshComponent, morphTargets);
				controllerComp.AddSkeletalMeshComponent(uskeletalMeshComponent, socketName, false);
				if (materialInfos != null && materialInfos.Num() > 0)
				{
					for (int j = 0; j < materialInfos.Num(); j++)
					{
						SNpcHookPartMaterial snpcHookPartMaterial = materialInfos.Get(j);
						int slotID = snpcHookPartMaterial.SlotID;
						UMaterialInstance material = snpcHookPartMaterial.Material;
						if (material != null && material.IsValid())
						{
							controllerComp.SetBaseMaterialByIndex(material, socketName, slotID);
						}
					}
				}
			}
		}
	}

	// Token: 0x06017F6B RID: 98155 RVA: 0x006B6754 File Offset: 0x006B4954
	private static void SetupChildPart(AActor actor, USkeletalMeshComponent mainMeshComp, FTransform defaultTransform, TArray<SNpcChildPart> parts, PD_NpcSetupData_C config, UKuroMaterialControllerComponent controllerComp)
	{
		if (parts == null || parts.Num() == 0)
		{
			return;
		}
		for (int i = 0; i < parts.Num(); i++)
		{
			SNpcChildPart snpcChildPart = parts.Get(i);
			USkeletalMesh mesh = snpcChildPart.Mesh;
			TArray<SNpcHookPartMaterial> materialInfos = snpcChildPart.MaterialInfos;
			USkeletalMeshComponent uskeletalMeshComponent = CombineMeshTool.SetupPartSkeletalMesh(config, actor, defaultTransform, mainMeshComp, mesh, CombineMeshTool.ChildPartName, false, i);
			if (uskeletalMeshComponent != null)
			{
				uskeletalMeshComponent.bAllowBoneVisibilityStatesDifferentWithMaster = true;
				mainMeshComp.bRequireHiddenBonesCalculation = true;
				controllerComp.AddSkeletalMeshComponent(uskeletalMeshComponent, default(FName), false);
				FName skeletalMeshComponentBodyName = controllerComp.GetSkeletalMeshComponentBodyName(uskeletalMeshComponent);
				if (materialInfos != null && materialInfos.Num() > 0)
				{
					for (int j = 0; j < materialInfos.Num(); j++)
					{
						SNpcHookPartMaterial snpcHookPartMaterial = materialInfos.Get(j);
						int slotID = snpcHookPartMaterial.SlotID;
						UMaterialInstance material = snpcHookPartMaterial.Material;
						if (material != null && material.IsValid())
						{
							controllerComp.SetBaseMaterialByIndex(material, skeletalMeshComponentBodyName, slotID);
						}
					}
				}
			}
		}
	}

	// Token: 0x06017F6C RID: 98156 RVA: 0x006B682C File Offset: 0x006B4A2C
	private static void SetupHideBones(USkeletalMeshComponent mainMeshComp, TArray<FName> bonesToHide)
	{
		for (int i = 0; i < bonesToHide.Num(); i++)
		{
			mainMeshComp.HideBoneByName(bonesToHide.Get(i), EPhysBodyOp.PBO_None);
		}
	}

	// Token: 0x06017F6D RID: 98157 RVA: 0x006B6858 File Offset: 0x006B4A58
	public static void SetFace(TsBaseCharacter actor, USkeletalMesh face)
	{
		UKuroMaterialControllerComponent ukuroMaterialControllerComponent = UKuroMaterialControllerComponent.AddOrGetMaterialControllerComponentFromActor(actor);
		if (ukuroMaterialControllerComponent == null)
		{
			return;
		}
		USkeletalMeshComponent registeredSkeletalMeshComponent = ukuroMaterialControllerComponent.GetRegisteredSkeletalMeshComponent(CombineMeshTool.FaceName);
		if (registeredSkeletalMeshComponent == null || !registeredSkeletalMeshComponent.IsValid())
		{
			return;
		}
		CharRenderingComponent charRenderingComponent = actor.CharRenderingComponent;
		if (charRenderingComponent != null)
		{
			charRenderingComponent.TempRemoveDither();
		}
		registeredSkeletalMeshComponent.SetSkeletalMesh(face, true);
		CharRenderingComponent charRenderingComponent2 = actor.CharRenderingComponent;
		if (charRenderingComponent2 != null)
		{
			charRenderingComponent2.UpdateMaterialEffectsOnly();
		}
		CharRenderingComponent charRenderingComponent3 = actor.CharRenderingComponent;
		if (charRenderingComponent3 == null)
		{
			return;
		}
		charRenderingComponent3.TempRecoverDither();
	}

	// Token: 0x06017F6E RID: 98158 RVA: 0x006B68C4 File Offset: 0x006B4AC4
	public static FName GetPartMeshName(FName prefix, int index)
	{
		if (index == 0)
		{
			return prefix;
		}
		string str = prefix.ToString();
		if (index < 10)
		{
			str += "0";
		}
		return new FName(str + index.ToString());
	}

	// Token: 0x06017F71 RID: 98161 RVA: 0x006B69B3 File Offset: 0x006B4BB3
	[CompilerGenerated]
	internal static string <BuildOutlineCandidates>g__Build|20_0(string n, ref CombineMeshTool.<>c__DisplayClass20_0 A_1)
	{
		return string.Concat(new string[]
		{
			A_1.dir,
			"/",
			n,
			"_OL.",
			n,
			"_OL"
		});
	}

	// Token: 0x0400B9FF RID: 47615
	[StaticVariableRuleIgnore]
	private static readonly FName PartMeshComp = new FName("PartMeshComp");

	// Token: 0x0400BA00 RID: 47616
	[StaticVariableRuleIgnore]
	private static readonly FName SkinDyeColor = new FName("5BaseColorTint");

	// Token: 0x0400BA01 RID: 47617
	[StaticVariableRuleIgnore]
	private static readonly FName BaseColorTint1 = new FName("1BaseColorTint");

	// Token: 0x0400BA02 RID: 47618
	[StaticVariableRuleIgnore]
	private static readonly FName BaseColorTint2 = new FName("2BaseColorTint");

	// Token: 0x0400BA03 RID: 47619
	[StaticVariableRuleIgnore]
	private static readonly FName FaceName = new FName("Face");

	// Token: 0x0400BA04 RID: 47620
	[StaticVariableRuleIgnore]
	private static readonly FName HairName = new FName("Hair");

	// Token: 0x0400BA05 RID: 47621
	[StaticVariableRuleIgnore]
	private static readonly FName BodyName = new FName("Body");

	// Token: 0x0400BA06 RID: 47622
	[StaticVariableRuleIgnore]
	private static readonly FName BodyUpName = new FName("BodyUp");

	// Token: 0x0400BA07 RID: 47623
	[StaticVariableRuleIgnore]
	private static readonly FName BodyDownName = new FName("BodyDown");

	// Token: 0x0400BA08 RID: 47624
	[StaticVariableRuleIgnore]
	private static readonly FName ChildPartName = new FName("ChildPart");
}
