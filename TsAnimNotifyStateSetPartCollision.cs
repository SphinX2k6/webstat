using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Fight.Struct;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D80 RID: 3456
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSetPartCollision.TsAnimNotifyStateSetPartCollision_C")]
public class TsAnimNotifyStateSetPartCollision : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000477 RID: 1143
	// (get) Token: 0x06004BD1 RID: 19409 RVA: 0x000A8203 File Offset: 0x000A6403
	// (set) Token: 0x06004BD2 RID: 19410 RVA: 0x000A8217 File Offset: 0x000A6417
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string CompName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateSetPartCollision.__PropertyOffset_CompName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateSetPartCollision.__PropertyOffset_CompName)), value);
		}
	}

	// Token: 0x17000478 RID: 1144
	// (get) Token: 0x06004BD3 RID: 19411 RVA: 0x000A822C File Offset: 0x000A642C
	// (set) Token: 0x06004BD4 RID: 19412 RVA: 0x000A8265 File Offset: 0x000A6465
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<string> CompNames
	{
		get
		{
			base.FastCheckIsValid();
			TArray<string> result;
			if ((result = this._CompNames) == null)
			{
				result = (this._CompNames = new TArray<string>(base.NativePtr + (IntPtr)TsAnimNotifyStateSetPartCollision.__PropertyOffset_CompNames, this));
			}
			return result;
		}
		set
		{
			this.CompNames.CopyAssign(value);
		}
	}

	// Token: 0x17000479 RID: 1145
	// (get) Token: 0x06004BD5 RID: 19413 RVA: 0x000A8273 File Offset: 0x000A6473
	// (set) Token: 0x06004BD6 RID: 19414 RVA: 0x000A8283 File Offset: 0x000A6483
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsBlockPawn
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSetPartCollision.__PropertyOffset_IsBlockPawn) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSetPartCollision.__PropertyOffset_IsBlockPawn) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700047A RID: 1146
	// (get) Token: 0x06004BD7 RID: 19415 RVA: 0x000A8294 File Offset: 0x000A6494
	// (set) Token: 0x06004BD8 RID: 19416 RVA: 0x000A82A4 File Offset: 0x000A64A4
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsBulletDetect
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSetPartCollision.__PropertyOffset_IsBulletDetect) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSetPartCollision.__PropertyOffset_IsBulletDetect) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700047B RID: 1147
	// (get) Token: 0x06004BD9 RID: 19417 RVA: 0x000A82B5 File Offset: 0x000A64B5
	// (set) Token: 0x06004BDA RID: 19418 RVA: 0x000A82C5 File Offset: 0x000A64C5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsBlockCamera
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSetPartCollision.__PropertyOffset_IsBlockCamera) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSetPartCollision.__PropertyOffset_IsBlockCamera) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700047C RID: 1148
	// (get) Token: 0x06004BDB RID: 19419 RVA: 0x000A82D6 File Offset: 0x000A64D6
	// (set) Token: 0x06004BDC RID: 19420 RVA: 0x000A82E6 File Offset: 0x000A64E6
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsActiveOcclusionDither
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSetPartCollision.__PropertyOffset_IsActiveOcclusionDither) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSetPartCollision.__PropertyOffset_IsActiveOcclusionDither) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004BDD RID: 19421 RVA: 0x000A82F8 File Offset: 0x000A64F8
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyBegin(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyBegin"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->TotalDuration = totalDuration;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004BDE RID: 19422 RVA: 0x000A83A0 File Offset: 0x000A65A0
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (owner is TsBaseCharacter)
		{
			if (!string.IsNullOrEmpty(this.CompName))
			{
				this.SetPartCollisionSwitch(owner as TsBaseCharacter, this.CompName, this.IsBlockPawn, this.IsBulletDetect, this.IsBlockCamera, this.IsActiveOcclusionDither, false);
			}
			for (int i = 0; i < this.CompNames.Num(); i++)
			{
				string text = this.CompNames.Get(i);
				if (text.Length > 0)
				{
					this.SetPartCollisionSwitch(owner as TsBaseCharacter, text.ToString(), this.IsBlockPawn, this.IsBulletDetect, this.IsBlockCamera, this.IsActiveOcclusionDither, false);
				}
			}
			return true;
		}
		return false;
	}

	// Token: 0x06004BDF RID: 19423 RVA: 0x000A8454 File Offset: 0x000A6654
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyEnd(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyEnd"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams) & -16L);
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

	// Token: 0x06004BE0 RID: 19424 RVA: 0x000A84F4 File Offset: 0x000A66F4
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (owner is TsBaseCharacter)
		{
			SPartHitEffect partConf = (owner as TsBaseCharacter).CharacterActorComponent.GetPartConf(this.CompName);
			if (partConf != null)
			{
				this.SetPartCollisionSwitch(owner as TsBaseCharacter, this.CompName, partConf.IsBlockPawn, partConf.IsBulletDetect, partConf.IsBlockCamera, partConf.IsActiveOcclusionDither, partConf.IsIgnoreAllChannel);
			}
			for (int i = 0; i < this.CompNames.Num(); i++)
			{
				string text = this.CompNames.Get(i);
				SPartHitEffect partConf2 = (owner as TsBaseCharacter).CharacterActorComponent.GetPartConf(text.ToString());
				if (partConf2 != null)
				{
					this.SetPartCollisionSwitch(owner as TsBaseCharacter, text.ToString(), partConf2.IsBlockPawn, partConf2.IsBulletDetect, partConf2.IsBlockCamera, partConf2.IsActiveOcclusionDither, false);
				}
			}
			return true;
		}
		return false;
	}

	// Token: 0x06004BE1 RID: 19425 RVA: 0x000A85DC File Offset: 0x000A67DC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotifyState.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotifyState.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotifyState.__GetNotifyName_FunctionParams) & -16L);
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

	// Token: 0x06004BE2 RID: 19426 RVA: 0x000A8657 File Offset: 0x000A6857
	protected override string GetNotifyName_Implementation()
	{
		return "设置部位碰撞";
	}

	// Token: 0x06004BE3 RID: 19427 RVA: 0x000A865E File Offset: 0x000A685E
	private void SetPartCollisionSwitch(TsBaseCharacter owner, string compName, bool isBlockPawn, bool isBulletDetect, bool isBlockCamera, bool isActiveOcclusionDither, bool isIgnoreAllChannel = false)
	{
		owner.CharacterActorComponent.SetPartCollisionSwitch(compName, isBlockPawn, isBulletDetect, isBlockCamera, isActiveOcclusionDither, isIgnoreAllChannel);
	}

	// Token: 0x06004BE4 RID: 19428 RVA: 0x000A8675 File Offset: 0x000A6875
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateSetPartCollision._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSetPartCollision.TsAnimNotifyStateSetPartCollision_C");
		}
		return TsAnimNotifyStateSetPartCollision._ClassPtr;
	}

	// Token: 0x06004BE5 RID: 19429 RVA: 0x000A869C File Offset: 0x000A689C
	public TsAnimNotifyStateSetPartCollision() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateSetPartCollision.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004BE6 RID: 19430 RVA: 0x000A86C4 File Offset: 0x000A68C4
	public TsAnimNotifyStateSetPartCollision(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateSetPartCollision.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004BE7 RID: 19431 RVA: 0x000A86F7 File Offset: 0x000A68F7
	protected TsAnimNotifyStateSetPartCollision(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004BE8 RID: 19432 RVA: 0x000A8700 File Offset: 0x000A6900
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004BE9 RID: 19433 RVA: 0x000A873C File Offset: 0x000A693C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004BEA RID: 19434 RVA: 0x000A876F File Offset: 0x000A696F
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040015AE RID: 5550
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSetPartCollision.TsAnimNotifyStateSetPartCollision_C";

	// Token: 0x040015AF RID: 5551
	private static IntPtr _ClassPtr;

	// Token: 0x040015B0 RID: 5552
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040015B1 RID: 5553
	private static int __PropertyOffset_CompName;

	// Token: 0x040015B2 RID: 5554
	private static int __PropertyOffset_CompNames;

	// Token: 0x040015B3 RID: 5555
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<string> _CompNames;

	// Token: 0x040015B4 RID: 5556
	private static int __PropertyOffset_IsBlockPawn;

	// Token: 0x040015B5 RID: 5557
	private static int __PropertyOffset_IsBulletDetect;

	// Token: 0x040015B6 RID: 5558
	private static int __PropertyOffset_IsBlockCamera;

	// Token: 0x040015B7 RID: 5559
	private static int __PropertyOffset_IsActiveOcclusionDither;
}
