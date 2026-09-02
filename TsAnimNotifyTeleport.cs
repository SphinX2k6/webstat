using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DF3 RID: 3571
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyTeleport.TsAnimNotifyTeleport_C")]
public class TsAnimNotifyTeleport : TsAnimNotifyBase, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700058B RID: 1419
	// (get) Token: 0x060052C2 RID: 21186 RVA: 0x000C1E4F File Offset: 0x000C004F
	// (set) Token: 0x060052C3 RID: 21187 RVA: 0x000C1E5F File Offset: 0x000C005F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 传送基于角色坐标系
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyTeleport.__PropertyOffset_传送基于角色坐标系) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyTeleport.__PropertyOffset_传送基于角色坐标系) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700058C RID: 1420
	// (get) Token: 0x060052C4 RID: 21188 RVA: 0x000C1E70 File Offset: 0x000C0070
	// (set) Token: 0x060052C5 RID: 21189 RVA: 0x000C1E84 File Offset: 0x000C0084
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVectorDouble 传送偏移
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyTeleport.__PropertyOffset_传送偏移);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyTeleport.__PropertyOffset_传送偏移) = value;
		}
	}

	// Token: 0x1700058D RID: 1421
	// (get) Token: 0x060052C6 RID: 21190 RVA: 0x000C1E99 File Offset: 0x000C0099
	// (set) Token: 0x060052C7 RID: 21191 RVA: 0x000C1EA9 File Offset: 0x000C00A9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 镜头瞬移
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyTeleport.__PropertyOffset_镜头瞬移) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyTeleport.__PropertyOffset_镜头瞬移) = (value ? 1 : 0);
		}
	}

	// Token: 0x060052C8 RID: 21192 RVA: 0x000C1EBA File Offset: 0x000C00BA
	static TsAnimNotifyTeleport()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsAnimNotifyTeleport.CreateStaticDefaultValue), new Action(TsAnimNotifyTeleport.ResetStaticDefaultValue));
	}

	// Token: 0x060052C9 RID: 21193 RVA: 0x000C1EDC File Offset: 0x000C00DC
	public static void CreateStaticDefaultValue()
	{
		TsAnimNotifyTeleport.GravityQuat = Quat.Create(0f, 0f, 0f, 1f);
		TsAnimNotifyTeleport.InverseGravityQuat = Quat.Create(0f, 0f, 0f, 1f);
		TsAnimNotifyTeleport.TempVector = new Vector();
	}

	// Token: 0x060052CA RID: 21194 RVA: 0x000C1F2F File Offset: 0x000C012F
	public static void ResetStaticDefaultValue()
	{
		TsAnimNotifyTeleport.GravityQuat = null;
		TsAnimNotifyTeleport.InverseGravityQuat = null;
		TsAnimNotifyTeleport.TempVector = null;
	}

	// Token: 0x060052CB RID: 21195 RVA: 0x000C1F44 File Offset: 0x000C0144
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

	// Token: 0x060052CC RID: 21196 RVA: 0x000C1FE4 File Offset: 0x000C01E4
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		if (characterActorComponent == null || !characterActorComponent.Valid || (characterActorComponent == null || !characterActorComponent.IsAutonomousProxy))
		{
			return false;
		}
		TsAnimNotifyTeleport.Initialize();
		if (this.传送基于角色坐标系)
		{
			characterActorComponent.AddActorLocalOffset(this.传送偏移, "传送并设置镜头位置", true);
		}
		else
		{
			Vector tempVector = TsAnimNotifyTeleport.TempVector;
			FVectorDouble 传送偏移 = this.传送偏移;
			tempVector.DeepCopy(传送偏移);
			Singleton<GravityUtils>.Instance.GetBaseQuatInGravityForActor(characterActorComponent, TsAnimNotifyTeleport.GravityQuat);
			TsAnimNotifyTeleport.GravityQuat.Inverse(TsAnimNotifyTeleport.InverseGravityQuat);
			Singleton<GravityUtils>.Instance.GetVectorInNormal(TsAnimNotifyTeleport.TempVector, TsAnimNotifyTeleport.InverseGravityQuat, TsAnimNotifyTeleport.TempVector);
			characterActorComponent.AddActorWorldOffset(TsAnimNotifyTeleport.TempVector.ToUeVector(false), "传送并设置镜头位置", true);
		}
		if (this.镜头瞬移)
		{
			FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
			if (fightCamera != null)
			{
				FightCameraLogicComponent logicComponent = fightCamera.LogicComponent;
				if (logicComponent != null)
				{
					logicComponent.ResetFightCameraLogic(false, true);
				}
			}
		}
		return true;
	}

	// Token: 0x060052CD RID: 21197 RVA: 0x000C20E8 File Offset: 0x000C02E8
	private static void Initialize()
	{
		if (TsAnimNotifyTeleport.GravityQuat != null)
		{
			return;
		}
		TsAnimNotifyTeleport.GravityQuat = Quat.Create(0f, 0f, 0f, 1f);
		TsAnimNotifyTeleport.InverseGravityQuat = Quat.Create(0f, 0f, 0f, 1f);
		TsAnimNotifyTeleport.TempVector = Vector.Create();
	}

	// Token: 0x060052CE RID: 21198 RVA: 0x000C2144 File Offset: 0x000C0344
	[NullableContext(1)]
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

	// Token: 0x060052CF RID: 21199 RVA: 0x000C21BF File Offset: 0x000C03BF
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "传送并设置镜头位置";
	}

	// Token: 0x060052D0 RID: 21200 RVA: 0x000C21C6 File Offset: 0x000C03C6
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyTeleport._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyTeleport.TsAnimNotifyTeleport_C");
		}
		return TsAnimNotifyTeleport._ClassPtr;
	}

	// Token: 0x060052D1 RID: 21201 RVA: 0x000C21EC File Offset: 0x000C03EC
	public TsAnimNotifyTeleport() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyTeleport.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060052D2 RID: 21202 RVA: 0x000C2214 File Offset: 0x000C0414
	[NullableContext(1)]
	public TsAnimNotifyTeleport(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyTeleport.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060052D3 RID: 21203 RVA: 0x000C2247 File Offset: 0x000C0447
	protected TsAnimNotifyTeleport(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060052D4 RID: 21204 RVA: 0x000C2250 File Offset: 0x000C0450
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060052D5 RID: 21205 RVA: 0x000C2283 File Offset: 0x000C0483
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001872 RID: 6258
	[Nullable(2)]
	private static Quat GravityQuat;

	// Token: 0x04001873 RID: 6259
	[Nullable(2)]
	private static Quat InverseGravityQuat;

	// Token: 0x04001874 RID: 6260
	[Nullable(2)]
	private static Vector TempVector;

	// Token: 0x04001875 RID: 6261
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyTeleport.TsAnimNotifyTeleport_C";

	// Token: 0x04001876 RID: 6262
	private static IntPtr _ClassPtr;

	// Token: 0x04001877 RID: 6263
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001878 RID: 6264
	private static int __PropertyOffset_传送基于角色坐标系;

	// Token: 0x04001879 RID: 6265
	private static int __PropertyOffset_传送偏移;

	// Token: 0x0400187A RID: 6266
	private static int __PropertyOffset_镜头瞬移;
}
