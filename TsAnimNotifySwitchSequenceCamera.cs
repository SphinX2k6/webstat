using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Module.Battle;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DF2 RID: 3570
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySwitchSequenceCamera.TsAnimNotifySwitchSequenceCamera_C")]
public class TsAnimNotifySwitchSequenceCamera : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000579 RID: 1401
	// (get) Token: 0x06005294 RID: 21140 RVA: 0x000C168F File Offset: 0x000BF88F
	// (set) Token: 0x06005295 RID: 21141 RVA: 0x000C169F File Offset: 0x000BF89F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe ESequenceCameraAnsEffectiveClientType 生效客户端
	{
		get
		{
			return (ESequenceCameraAnsEffectiveClientType)(*(base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_生效客户端));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_生效客户端) = (byte)value;
		}
	}

	// Token: 0x1700057A RID: 1402
	// (get) Token: 0x06005296 RID: 21142 RVA: 0x000C16B0 File Offset: 0x000BF8B0
	// (set) Token: 0x06005297 RID: 21143 RVA: 0x000C16E9 File Offset: 0x000BF8E9
	[UProperty(EPropertyFlags.CPF_None)]
	public SSequenceCamera_Settings 特写镜头配置
	{
		get
		{
			base.FastCheckIsValid();
			SSequenceCamera_Settings result;
			if ((result = this._特写镜头配置) == null)
			{
				result = (this._特写镜头配置 = new SSequenceCamera_Settings(base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_特写镜头配置, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(SSequenceCamera_Settings.StaticStruct(), base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_特写镜头配置, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x1700057B RID: 1403
	// (get) Token: 0x06005298 RID: 21144 RVA: 0x000C1711 File Offset: 0x000BF911
	// (set) Token: 0x06005299 RID: 21145 RVA: 0x000C1721 File Offset: 0x000BF921
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool bResetLockOnCamera
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_bResetLockOnCamera) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_bResetLockOnCamera) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700057C RID: 1404
	// (get) Token: 0x0600529A RID: 21146 RVA: 0x000C1732 File Offset: 0x000BF932
	// (set) Token: 0x0600529B RID: 21147 RVA: 0x000C1746 File Offset: 0x000BF946
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FRotator AdditiveRotation
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_AdditiveRotation);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_AdditiveRotation) = value;
		}
	}

	// Token: 0x1700057D RID: 1405
	// (get) Token: 0x0600529C RID: 21148 RVA: 0x000C175B File Offset: 0x000BF95B
	// (set) Token: 0x0600529D RID: 21149 RVA: 0x000C176F File Offset: 0x000BF96F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string CameraAttachSocket
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_CameraAttachSocket)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_CameraAttachSocket)), value);
		}
	}

	// Token: 0x1700057E RID: 1406
	// (get) Token: 0x0600529E RID: 21150 RVA: 0x000C1784 File Offset: 0x000BF984
	// (set) Token: 0x0600529F RID: 21151 RVA: 0x000C1798 File Offset: 0x000BF998
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string CameraDetectSocket
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_CameraDetectSocket)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_CameraDetectSocket)), value);
		}
	}

	// Token: 0x1700057F RID: 1407
	// (get) Token: 0x060052A0 RID: 21152 RVA: 0x000C17AD File Offset: 0x000BF9AD
	// (set) Token: 0x060052A1 RID: 21153 RVA: 0x000C17BD File Offset: 0x000BF9BD
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 强制播放Sequence
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_强制播放Sequence) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_强制播放Sequence) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000580 RID: 1408
	// (get) Token: 0x060052A2 RID: 21154 RVA: 0x000C17CE File Offset: 0x000BF9CE
	// (set) Token: 0x060052A3 RID: 21155 RVA: 0x000C17DE File Offset: 0x000BF9DE
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float ExtraDetectSphereRadius
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_ExtraDetectSphereRadius);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_ExtraDetectSphereRadius) = value;
		}
	}

	// Token: 0x17000581 RID: 1409
	// (get) Token: 0x060052A4 RID: 21156 RVA: 0x000C17EF File Offset: 0x000BF9EF
	// (set) Token: 0x060052A5 RID: 21157 RVA: 0x000C1803 File Offset: 0x000BFA03
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector ExtraSphereLocation
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_ExtraSphereLocation);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_ExtraSphereLocation) = value;
		}
	}

	// Token: 0x17000582 RID: 1410
	// (get) Token: 0x060052A6 RID: 21158 RVA: 0x000C1818 File Offset: 0x000BFA18
	// (set) Token: 0x060052A7 RID: 21159 RVA: 0x000C1828 File Offset: 0x000BFA28
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsShowExtraSphere
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_IsShowExtraSphere) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_IsShowExtraSphere) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000583 RID: 1411
	// (get) Token: 0x060052A8 RID: 21160 RVA: 0x000C1839 File Offset: 0x000BFA39
	// (set) Token: 0x060052A9 RID: 21161 RVA: 0x000C1849 File Offset: 0x000BFA49
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsIgnoreCharacterCollision
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_IsIgnoreCharacterCollision) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_IsIgnoreCharacterCollision) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000584 RID: 1412
	// (get) Token: 0x060052AA RID: 21162 RVA: 0x000C185A File Offset: 0x000BFA5A
	// (set) Token: 0x060052AB RID: 21163 RVA: 0x000C186A File Offset: 0x000BFA6A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DisableMovementInput
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_DisableMovementInput) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_DisableMovementInput) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000585 RID: 1413
	// (get) Token: 0x060052AC RID: 21164 RVA: 0x000C187B File Offset: 0x000BFA7B
	// (set) Token: 0x060052AD RID: 21165 RVA: 0x000C188B File Offset: 0x000BFA8B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DisableLookAtInput
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_DisableLookAtInput) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_DisableLookAtInput) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000586 RID: 1414
	// (get) Token: 0x060052AE RID: 21166 RVA: 0x000C189C File Offset: 0x000BFA9C
	// (set) Token: 0x060052AF RID: 21167 RVA: 0x000C18AC File Offset: 0x000BFAAC
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DisableMotionBlur
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_DisableMotionBlur) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_DisableMotionBlur) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000587 RID: 1415
	// (get) Token: 0x060052B0 RID: 21168 RVA: 0x000C18BD File Offset: 0x000BFABD
	// (set) Token: 0x060052B1 RID: 21169 RVA: 0x000C18CD File Offset: 0x000BFACD
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 启用特定功能下的镜头配置
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_启用特定功能下的镜头配置) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_启用特定功能下的镜头配置) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000588 RID: 1416
	// (get) Token: 0x060052B2 RID: 21170 RVA: 0x000C18E0 File Offset: 0x000BFAE0
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<SSequenceCamera_SpecificConfig> 特定功能下的镜头配置
	{
		get
		{
			base.FastCheckIsValid();
			TArray<SSequenceCamera_SpecificConfig> result;
			if ((result = this._特定功能下的镜头配置) == null)
			{
				result = (this._特定功能下的镜头配置 = new TArray<SSequenceCamera_SpecificConfig>(base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_特定功能下的镜头配置, this));
			}
			return result;
		}
	}

	// Token: 0x17000589 RID: 1417
	// (get) Token: 0x060052B3 RID: 21171 RVA: 0x000C1919 File Offset: 0x000BFB19
	// (set) Token: 0x060052B4 RID: 21172 RVA: 0x000C1929 File Offset: 0x000BFB29
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool ShotBeforePlaying
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_ShotBeforePlaying) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_ShotBeforePlaying) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700058A RID: 1418
	// (get) Token: 0x060052B5 RID: 21173 RVA: 0x000C193A File Offset: 0x000BFB3A
	// (set) Token: 0x060052B6 RID: 21174 RVA: 0x000C194A File Offset: 0x000BFB4A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float ShotDuration
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_ShotDuration);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifySwitchSequenceCamera.__PropertyOffset_ShotDuration) = value;
		}
	}

	// Token: 0x060052B7 RID: 21175 RVA: 0x000C195C File Offset: 0x000BFB5C
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_Notify(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_Notify"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotify.__K2_Notify_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotify.__K2_Notify_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotify.__K2_Notify_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x060052B8 RID: 21176 RVA: 0x000C19FC File Offset: 0x000BFBFC
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsAnimNotifySwitchSequenceCamera.<>c__DisplayClass54_0 CS$<>8__locals1 = new TsAnimNotifySwitchSequenceCamera.<>c__DisplayClass54_0();
		CS$<>8__locals1.<>4__this = this;
		AActor owner = meshComp.GetOwner();
		CS$<>8__locals1.tsBaseCharacter = (owner as TsBaseCharacter);
		if (CS$<>8__locals1.tsBaseCharacter == null)
		{
			return false;
		}
		EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(CS$<>8__locals1.tsBaseCharacter.EntityId);
		if (entityById == null || !entityById.Valid)
		{
			return false;
		}
		if (!CharacterUtils.CanCharacterMonsterOrSummonedDisplayEffect(entityById))
		{
			return false;
		}
		CS$<>8__locals1.specificConfig = null;
		ESequenceCameraAnsEffectiveClientType sequenceCameraAnsEffectiveClientType = this.生效客户端;
		if (this.启用特定功能下的镜头配置)
		{
			CS$<>8__locals1.specificConfig = this.GetSpecificConfig();
			if (CS$<>8__locals1.specificConfig != null)
			{
				sequenceCameraAnsEffectiveClientType = CS$<>8__locals1.specificConfig.OverrideCondition;
			}
		}
		if (!CameraUtility.CheckCameraSequenceCondition(CS$<>8__locals1.tsBaseCharacter, sequenceCameraAnsEffectiveClientType))
		{
			return false;
		}
		WorldEntity entity = entityById.Entity;
		BaseSkillComponent baseSkillComponent = (entity != null) ? entity.GetComponent<BaseSkillComponent>() : null;
		Skill skill = (baseSkillComponent != null) ? baseSkillComponent.CurrentSkill : null;
		CS$<>8__locals1.skillEntityId = ((skill != null) ? new int?(CS$<>8__locals1.tsBaseCharacter.EntityId) : null);
		TsAnimNotifySwitchSequenceCamera.<>c__DisplayClass54_0 CS$<>8__locals2 = CS$<>8__locals1;
		int? num = (skill != null) ? new int?(skill.SkillId) : null;
		CS$<>8__locals2.skillId = ((num != null) ? new long?((long)num.GetValueOrDefault()) : null);
		if (this.ShotBeforePlaying)
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.GetSceneColorShotBeforeTonemapNow 1", null);
			TimerSystem.Instance.Next(delegate(float _)
			{
				ControllerBase<CameraController>.Instance.MainModel.SequenceCamera.PlayerComponent.PlayCameraSequence(CS$<>8__locals1.<>4__this.特写镜头配置, CS$<>8__locals1.<>4__this.bResetLockOnCamera, CS$<>8__locals1.<>4__this.AdditiveRotation, CS$<>8__locals1.tsBaseCharacter, StringUtils.IsEmpty(CS$<>8__locals1.<>4__this.CameraAttachSocket) ? FNameUtil.EMPTY : FNameUtil.GetDynamicFName(CS$<>8__locals1.<>4__this.CameraAttachSocket).Value, StringUtils.IsEmpty(CS$<>8__locals1.<>4__this.CameraDetectSocket) ? FNameUtil.EMPTY : FNameUtil.GetDynamicFName(CS$<>8__locals1.<>4__this.CameraDetectSocket).Value, CS$<>8__locals1.<>4__this.ExtraSphereLocation, CS$<>8__locals1.<>4__this.ExtraDetectSphereRadius, CS$<>8__locals1.<>4__this.IsShowExtraSphere, CS$<>8__locals1.<>4__this.IsIgnoreCharacterCollision, CS$<>8__locals1.<>4__this.DisableMovementInput, CS$<>8__locals1.<>4__this.DisableLookAtInput, CS$<>8__locals1.<>4__this.DisableMotionBlur, CS$<>8__locals1.<>4__this.强制播放Sequence, CS$<>8__locals1.specificConfig, CS$<>8__locals1.skillEntityId, CS$<>8__locals1.skillId);
			}, null, null);
			TimerSystem.Instance.Delay(delegate(float _)
			{
				UKuroRenderingRuntimeBPPluginBPLibrary.ReleaseGetSceneColorShotBefore();
			}, this.ShotDuration, null, null, true, 1f);
		}
		else
		{
			ControllerBase<CameraController>.Instance.MainModel.SequenceCamera.PlayerComponent.PlayCameraSequence(this.特写镜头配置, this.bResetLockOnCamera, this.AdditiveRotation, CS$<>8__locals1.tsBaseCharacter, StringUtils.IsEmpty(this.CameraAttachSocket) ? FNameUtil.EMPTY : FNameUtil.GetDynamicFName(this.CameraAttachSocket).Value, StringUtils.IsEmpty(this.CameraDetectSocket) ? FNameUtil.EMPTY : FNameUtil.GetDynamicFName(this.CameraDetectSocket).Value, this.ExtraSphereLocation, this.ExtraDetectSphereRadius, this.IsShowExtraSphere, this.IsIgnoreCharacterCollision, this.DisableMovementInput, this.DisableLookAtInput, this.DisableMotionBlur, this.强制播放Sequence, CS$<>8__locals1.specificConfig, CS$<>8__locals1.skillEntityId, CS$<>8__locals1.skillId);
		}
		return true;
	}

	// Token: 0x060052B9 RID: 21177 RVA: 0x000C1C78 File Offset: 0x000BFE78
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotify.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotify.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotify.__GetNotifyName_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		string result = FString.ToString((void*)(&ptr2->__Result));
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}

	// Token: 0x060052BA RID: 21178 RVA: 0x000C1CF3 File Offset: 0x000BFEF3
	protected override string GetNotifyName_Implementation()
	{
		return "特写镜头";
	}

	// Token: 0x060052BB RID: 21179 RVA: 0x000C1CFC File Offset: 0x000BFEFC
	[NullableContext(2)]
	private SSequenceCamera_SpecificConfig GetSpecificConfig()
	{
		if (this.特定功能下的镜头配置 == null)
		{
			return null;
		}
		int num = this.特定功能下的镜头配置.Num();
		for (int i = 0; i < num; i++)
		{
			SSequenceCamera_SpecificConfig ssequenceCamera_SpecificConfig = this.特定功能下的镜头配置.Get(i);
			if (!(ssequenceCamera_SpecificConfig == null) && !(ssequenceCamera_SpecificConfig.SpecificType == ESequenceCameraSpecificType.无) && ssequenceCamera_SpecificConfig.SpecificType == ESequenceCameraSpecificType.梦境链接)
			{
				BattleLinkModel instance = ModelBase<BattleLinkModel>.Instance;
				if (instance != null && instance.CheckInDreamLink())
				{
					return ssequenceCamera_SpecificConfig;
				}
			}
		}
		return null;
	}

	// Token: 0x060052BC RID: 21180 RVA: 0x000C1D7D File Offset: 0x000BFF7D
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifySwitchSequenceCamera._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySwitchSequenceCamera.TsAnimNotifySwitchSequenceCamera_C");
		}
		return TsAnimNotifySwitchSequenceCamera._ClassPtr;
	}

	// Token: 0x060052BD RID: 21181 RVA: 0x000C1DA4 File Offset: 0x000BFFA4
	public TsAnimNotifySwitchSequenceCamera() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifySwitchSequenceCamera.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060052BE RID: 21182 RVA: 0x000C1DCC File Offset: 0x000BFFCC
	public TsAnimNotifySwitchSequenceCamera(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifySwitchSequenceCamera.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060052BF RID: 21183 RVA: 0x000C1DFF File Offset: 0x000BFFFF
	protected TsAnimNotifySwitchSequenceCamera(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060052C0 RID: 21184 RVA: 0x000C1E08 File Offset: 0x000C0008
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060052C1 RID: 21185 RVA: 0x000C1E3B File Offset: 0x000C003B
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400185B RID: 6235
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySwitchSequenceCamera.TsAnimNotifySwitchSequenceCamera_C";

	// Token: 0x0400185C RID: 6236
	private static IntPtr _ClassPtr;

	// Token: 0x0400185D RID: 6237
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400185E RID: 6238
	private static int __PropertyOffset_生效客户端;

	// Token: 0x0400185F RID: 6239
	private static int __PropertyOffset_特写镜头配置;

	// Token: 0x04001860 RID: 6240
	[Nullable(2)]
	private SSequenceCamera_Settings _特写镜头配置;

	// Token: 0x04001861 RID: 6241
	private static int __PropertyOffset_bResetLockOnCamera;

	// Token: 0x04001862 RID: 6242
	private static int __PropertyOffset_AdditiveRotation;

	// Token: 0x04001863 RID: 6243
	private static int __PropertyOffset_CameraAttachSocket;

	// Token: 0x04001864 RID: 6244
	private static int __PropertyOffset_CameraDetectSocket;

	// Token: 0x04001865 RID: 6245
	private static int __PropertyOffset_强制播放Sequence;

	// Token: 0x04001866 RID: 6246
	private static int __PropertyOffset_ExtraDetectSphereRadius;

	// Token: 0x04001867 RID: 6247
	private static int __PropertyOffset_ExtraSphereLocation;

	// Token: 0x04001868 RID: 6248
	private static int __PropertyOffset_IsShowExtraSphere;

	// Token: 0x04001869 RID: 6249
	private static int __PropertyOffset_IsIgnoreCharacterCollision;

	// Token: 0x0400186A RID: 6250
	private static int __PropertyOffset_DisableMovementInput;

	// Token: 0x0400186B RID: 6251
	private static int __PropertyOffset_DisableLookAtInput;

	// Token: 0x0400186C RID: 6252
	private static int __PropertyOffset_DisableMotionBlur;

	// Token: 0x0400186D RID: 6253
	private static int __PropertyOffset_启用特定功能下的镜头配置;

	// Token: 0x0400186E RID: 6254
	private static int __PropertyOffset_特定功能下的镜头配置;

	// Token: 0x0400186F RID: 6255
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<SSequenceCamera_SpecificConfig> _特定功能下的镜头配置;

	// Token: 0x04001870 RID: 6256
	private static int __PropertyOffset_ShotBeforePlaying;

	// Token: 0x04001871 RID: 6257
	private static int __PropertyOffset_ShotDuration;
}
