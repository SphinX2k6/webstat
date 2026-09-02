using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Game.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DB2 RID: 3506
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyCameraModify.TsAnimNotifyCameraModify_C")]
public class TsAnimNotifyCameraModify : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170004F7 RID: 1271
	// (get) Token: 0x06004F20 RID: 20256 RVA: 0x000B55CF File Offset: 0x000B37CF
	// (set) Token: 0x06004F21 RID: 20257 RVA: 0x000B55E3 File Offset: 0x000B37E3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag Tag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyCameraModify.__PropertyOffset_Tag);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyCameraModify.__PropertyOffset_Tag) = value;
		}
	}

	// Token: 0x170004F8 RID: 1272
	// (get) Token: 0x06004F22 RID: 20258 RVA: 0x000B55F8 File Offset: 0x000B37F8
	// (set) Token: 0x06004F23 RID: 20259 RVA: 0x000B5608 File Offset: 0x000B3808
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 持续时间
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyCameraModify.__PropertyOffset_持续时间);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyCameraModify.__PropertyOffset_持续时间) = value;
		}
	}

	// Token: 0x170004F9 RID: 1273
	// (get) Token: 0x06004F24 RID: 20260 RVA: 0x000B5619 File Offset: 0x000B3819
	// (set) Token: 0x06004F25 RID: 20261 RVA: 0x000B5629 File Offset: 0x000B3829
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 淡入时间
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyCameraModify.__PropertyOffset_淡入时间);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyCameraModify.__PropertyOffset_淡入时间) = value;
		}
	}

	// Token: 0x170004FA RID: 1274
	// (get) Token: 0x06004F26 RID: 20262 RVA: 0x000B563A File Offset: 0x000B383A
	// (set) Token: 0x06004F27 RID: 20263 RVA: 0x000B564A File Offset: 0x000B384A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 淡出时间
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyCameraModify.__PropertyOffset_淡出时间);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyCameraModify.__PropertyOffset_淡出时间) = value;
		}
	}

	// Token: 0x170004FB RID: 1275
	// (get) Token: 0x06004F28 RID: 20264 RVA: 0x000B565C File Offset: 0x000B385C
	// (set) Token: 0x06004F29 RID: 20265 RVA: 0x000B5695 File Offset: 0x000B3895
	[UProperty(EPropertyFlags.CPF_None)]
	public SBaseCurve 淡入曲线
	{
		get
		{
			base.FastCheckIsValid();
			SBaseCurve result;
			if ((result = this._淡入曲线) == null)
			{
				result = (this._淡入曲线 = new SBaseCurve(base.NativePtr + (IntPtr)TsAnimNotifyCameraModify.__PropertyOffset_淡入曲线, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(SBaseCurve.StaticStruct(), base.NativePtr + (IntPtr)TsAnimNotifyCameraModify.__PropertyOffset_淡入曲线, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170004FC RID: 1276
	// (get) Token: 0x06004F2A RID: 20266 RVA: 0x000B56C0 File Offset: 0x000B38C0
	// (set) Token: 0x06004F2B RID: 20267 RVA: 0x000B56F9 File Offset: 0x000B38F9
	[UProperty(EPropertyFlags.CPF_None)]
	public SBaseCurve 淡出曲线
	{
		get
		{
			base.FastCheckIsValid();
			SBaseCurve result;
			if ((result = this._淡出曲线) == null)
			{
				result = (this._淡出曲线 = new SBaseCurve(base.NativePtr + (IntPtr)TsAnimNotifyCameraModify.__PropertyOffset_淡出曲线, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(SBaseCurve.StaticStruct(), base.NativePtr + (IntPtr)TsAnimNotifyCameraModify.__PropertyOffset_淡出曲线, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170004FD RID: 1277
	// (get) Token: 0x06004F2C RID: 20268 RVA: 0x000B5721 File Offset: 0x000B3921
	// (set) Token: 0x06004F2D RID: 20269 RVA: 0x000B5731 File Offset: 0x000B3931
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 打断淡出时间
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyCameraModify.__PropertyOffset_打断淡出时间);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyCameraModify.__PropertyOffset_打断淡出时间) = value;
		}
	}

	// Token: 0x170004FE RID: 1278
	// (get) Token: 0x06004F2E RID: 20270 RVA: 0x000B5744 File Offset: 0x000B3944
	// (set) Token: 0x06004F2F RID: 20271 RVA: 0x000B577D File Offset: 0x000B397D
	[UProperty(EPropertyFlags.CPF_None)]
	public SCameraModifier_Settings 相机修改配置
	{
		get
		{
			base.FastCheckIsValid();
			SCameraModifier_Settings result;
			if ((result = this._相机修改配置) == null)
			{
				result = (this._相机修改配置 = new SCameraModifier_Settings(base.NativePtr + (IntPtr)TsAnimNotifyCameraModify.__PropertyOffset_相机修改配置, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(SCameraModifier_Settings.StaticStruct(), base.NativePtr + (IntPtr)TsAnimNotifyCameraModify.__PropertyOffset_相机修改配置, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170004FF RID: 1279
	// (get) Token: 0x06004F30 RID: 20272 RVA: 0x000B57A5 File Offset: 0x000B39A5
	// (set) Token: 0x06004F31 RID: 20273 RVA: 0x000B57B5 File Offset: 0x000B39B5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe ECameraAnsEffectiveClientType 生效客户端类型
	{
		get
		{
			return (ECameraAnsEffectiveClientType)(*(base.NativePtr + (IntPtr)TsAnimNotifyCameraModify.__PropertyOffset_生效客户端类型));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyCameraModify.__PropertyOffset_生效客户端类型) = (byte)value;
		}
	}

	// Token: 0x17000500 RID: 1280
	// (get) Token: 0x06004F32 RID: 20274 RVA: 0x000B57C6 File Offset: 0x000B39C6
	// (set) Token: 0x06004F33 RID: 20275 RVA: 0x000B57DA File Offset: 0x000B39DA
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string CameraAttachSocket
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyCameraModify.__PropertyOffset_CameraAttachSocket)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyCameraModify.__PropertyOffset_CameraAttachSocket)), value);
		}
	}

	// Token: 0x17000501 RID: 1281
	// (get) Token: 0x06004F34 RID: 20276 RVA: 0x000B57F0 File Offset: 0x000B39F0
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<SCameraModifier_Condition> 条件
	{
		get
		{
			base.FastCheckIsValid();
			TArray<SCameraModifier_Condition> result;
			if ((result = this._条件) == null)
			{
				result = (this._条件 = new TArray<SCameraModifier_Condition>(base.NativePtr + (IntPtr)TsAnimNotifyCameraModify.__PropertyOffset_条件, this));
			}
			return result;
		}
	}

	// Token: 0x06004F35 RID: 20277 RVA: 0x000B582C File Offset: 0x000B3A2C
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

	// Token: 0x06004F36 RID: 20278 RVA: 0x000B58CC File Offset: 0x000B3ACC
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (owner == null)
		{
			return false;
		}
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		TsBaseVehicle tsBaseVehicle = owner as TsBaseVehicle;
		if (tsBaseCharacter == null && tsBaseVehicle == null)
		{
			return false;
		}
		EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById((tsBaseCharacter != null) ? tsBaseCharacter.EntityId : tsBaseVehicle.EntityId);
		if (entityById == null || !entityById.Valid)
		{
			return false;
		}
		if (!CharacterUtils.CanCharacterMonsterOrSummonedDisplayEffect(entityById))
		{
			return false;
		}
		FightCameraLogicComponent logicComponent = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent;
		if (logicComponent == null || !logicComponent.Valid)
		{
			return false;
		}
		UAnimMontage anim = null;
		UAnimMontage uanimMontage = animation as UAnimMontage;
		if (uanimMontage != null)
		{
			anim = uanimMontage;
		}
		if (CameraUtility.CheckApplyCameraModifyCondition(entityById, this.相机修改配置, this.生效客户端类型, this.条件))
		{
			AActor aactor = null;
			if (this.生效客户端类型 != ECameraAnsEffectiveClientType.单客户端_角色为中心_ && this.生效客户端类型 != ECameraAnsEffectiveClientType.全客户端_角色为中心_ && this.生效客户端类型 != ECameraAnsEffectiveClientType.锁定目标客户端_角色为中心_ && this.生效客户端类型 != ECameraAnsEffectiveClientType.仇恨目标客户端_角色为中心_ && this.生效客户端类型 != ECameraAnsEffectiveClientType.单客户端_载具为中心_ && this.生效客户端类型 != ECameraAnsEffectiveClientType.全客户端_载具为中心_)
			{
				aactor = owner;
				if (this.生效客户端类型 != ECameraAnsEffectiveClientType.单客户端_声骸为中心_ && this.生效客户端类型 != ECameraAnsEffectiveClientType.全客户端_声骸为中心_ && this.生效客户端类型 != ECameraAnsEffectiveClientType.单客户端_伴生物为中心_ && this.生效客户端类型 != ECameraAnsEffectiveClientType.全客户端_伴生物为中心_)
				{
					this.相机修改配置.IsLockInput = true;
					this.相机修改配置.OverrideCameraInput = true;
				}
			}
			OneOf<TsBaseCharacter, TsBaseVehicle> newLookAtActor = default(OneOf<TsBaseCharacter, TsBaseVehicle>);
			TsBaseCharacter tsBaseCharacter2 = aactor as TsBaseCharacter;
			if (tsBaseCharacter2 != null)
			{
				newLookAtActor = tsBaseCharacter2;
			}
			else
			{
				TsBaseVehicle tsBaseVehicle2 = aactor as TsBaseVehicle;
				if (tsBaseVehicle2 != null)
				{
					newLookAtActor = tsBaseVehicle2;
				}
			}
			OneOf<TsBaseCharacter, TsBaseVehicle> animOwner = default(OneOf<TsBaseCharacter, TsBaseVehicle>);
			TsBaseCharacter tsBaseCharacter3 = owner as TsBaseCharacter;
			if (tsBaseCharacter3 != null)
			{
				animOwner = tsBaseCharacter3;
			}
			else
			{
				TsBaseVehicle tsBaseVehicle3 = owner as TsBaseVehicle;
				if (tsBaseVehicle3 != null)
				{
					animOwner = tsBaseVehicle3;
				}
			}
			logicComponent.ApplyCameraModify(new FGameplayTag?(this.Tag), this.持续时间, this.淡入时间, this.淡出时间, this.相机修改配置, anim, this.打断淡出时间, this.淡入曲线, this.淡出曲线, newLookAtActor, this.CameraAttachSocket, animOwner);
		}
		return true;
	}

	// Token: 0x06004F37 RID: 20279 RVA: 0x000B5AC0 File Offset: 0x000B3CC0
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

	// Token: 0x06004F38 RID: 20280 RVA: 0x000B5B3B File Offset: 0x000B3D3B
	protected override string GetNotifyName_Implementation()
	{
		return "Modify镜头";
	}

	// Token: 0x06004F39 RID: 20281 RVA: 0x000B5B42 File Offset: 0x000B3D42
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyCameraModify._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyCameraModify.TsAnimNotifyCameraModify_C");
		}
		return TsAnimNotifyCameraModify._ClassPtr;
	}

	// Token: 0x06004F3A RID: 20282 RVA: 0x000B5B68 File Offset: 0x000B3D68
	public TsAnimNotifyCameraModify() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyCameraModify.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004F3B RID: 20283 RVA: 0x000B5B90 File Offset: 0x000B3D90
	public TsAnimNotifyCameraModify(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyCameraModify.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004F3C RID: 20284 RVA: 0x000B5BC3 File Offset: 0x000B3DC3
	protected TsAnimNotifyCameraModify(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004F3D RID: 20285 RVA: 0x000B5BCC File Offset: 0x000B3DCC
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004F3E RID: 20286 RVA: 0x000B5BFF File Offset: 0x000B3DFF
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001702 RID: 5890
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyCameraModify.TsAnimNotifyCameraModify_C";

	// Token: 0x04001703 RID: 5891
	private static IntPtr _ClassPtr;

	// Token: 0x04001704 RID: 5892
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001705 RID: 5893
	private static int __PropertyOffset_Tag;

	// Token: 0x04001706 RID: 5894
	private static int __PropertyOffset_持续时间;

	// Token: 0x04001707 RID: 5895
	private static int __PropertyOffset_淡入时间;

	// Token: 0x04001708 RID: 5896
	private static int __PropertyOffset_淡出时间;

	// Token: 0x04001709 RID: 5897
	private static int __PropertyOffset_淡入曲线;

	// Token: 0x0400170A RID: 5898
	[Nullable(2)]
	private SBaseCurve _淡入曲线;

	// Token: 0x0400170B RID: 5899
	private static int __PropertyOffset_淡出曲线;

	// Token: 0x0400170C RID: 5900
	[Nullable(2)]
	private SBaseCurve _淡出曲线;

	// Token: 0x0400170D RID: 5901
	private static int __PropertyOffset_打断淡出时间;

	// Token: 0x0400170E RID: 5902
	private static int __PropertyOffset_相机修改配置;

	// Token: 0x0400170F RID: 5903
	[Nullable(2)]
	private SCameraModifier_Settings _相机修改配置;

	// Token: 0x04001710 RID: 5904
	private static int __PropertyOffset_生效客户端类型;

	// Token: 0x04001711 RID: 5905
	private static int __PropertyOffset_CameraAttachSocket;

	// Token: 0x04001712 RID: 5906
	private static int __PropertyOffset_条件;

	// Token: 0x04001713 RID: 5907
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<SCameraModifier_Condition> _条件;
}
