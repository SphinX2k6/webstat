using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Tools;
using UnrealEngine;
using UnrealEngine.Extension;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D2B RID: 3371
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateBulletDuration.TsAnimNotifyStateBulletDuration_C")]
public class TsAnimNotifyStateBulletDuration : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700035A RID: 858
	// (get) Token: 0x06004567 RID: 17767 RVA: 0x0008A0AC File Offset: 0x000882AC
	// (set) Token: 0x06004568 RID: 17768 RVA: 0x0008A0E5 File Offset: 0x000882E5
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<string> BulletIds
	{
		get
		{
			base.FastCheckIsValid();
			TArray<string> result;
			if ((result = this._BulletIds) == null)
			{
				result = (this._BulletIds = new TArray<string>(base.NativePtr + (IntPtr)TsAnimNotifyStateBulletDuration.__PropertyOffset_BulletIds, this));
			}
			return result;
		}
		set
		{
			this.BulletIds.CopyAssign(value);
		}
	}

	// Token: 0x1700035B RID: 859
	// (get) Token: 0x06004569 RID: 17769 RVA: 0x0008A0F4 File Offset: 0x000882F4
	// (set) Token: 0x0600456A RID: 17770 RVA: 0x0008A12D File Offset: 0x0008832D
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<FVector> LocationOffsets
	{
		get
		{
			base.FastCheckIsValid();
			TArray<FVector> result;
			if ((result = this._LocationOffsets) == null)
			{
				result = (this._LocationOffsets = new TArray<FVector>(base.NativePtr + (IntPtr)TsAnimNotifyStateBulletDuration.__PropertyOffset_LocationOffsets, this));
			}
			return result;
		}
		set
		{
			this.LocationOffsets.CopyAssign(value);
		}
	}

	// Token: 0x1700035C RID: 860
	// (get) Token: 0x0600456B RID: 17771 RVA: 0x0008A13C File Offset: 0x0008833C
	// (set) Token: 0x0600456C RID: 17772 RVA: 0x0008A175 File Offset: 0x00088375
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<FRotator> RotatorOffsets
	{
		get
		{
			base.FastCheckIsValid();
			TArray<FRotator> result;
			if ((result = this._RotatorOffsets) == null)
			{
				result = (this._RotatorOffsets = new TArray<FRotator>(base.NativePtr + (IntPtr)TsAnimNotifyStateBulletDuration.__PropertyOffset_RotatorOffsets, this));
			}
			return result;
		}
		set
		{
			this.RotatorOffsets.CopyAssign(value);
		}
	}

	// Token: 0x1700035D RID: 861
	// (get) Token: 0x0600456D RID: 17773 RVA: 0x0008A183 File Offset: 0x00088383
	// (set) Token: 0x0600456E RID: 17774 RVA: 0x0008A193 File Offset: 0x00088393
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DestroyEffectImmediately
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateBulletDuration.__PropertyOffset_DestroyEffectImmediately) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateBulletDuration.__PropertyOffset_DestroyEffectImmediately) = (value ? 1 : 0);
		}
	}

	// Token: 0x0600456F RID: 17775 RVA: 0x0008A1A4 File Offset: 0x000883A4
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

	// Token: 0x06004570 RID: 17776 RVA: 0x0008A24C File Offset: 0x0008844C
	[NullableContext(2)]
	protected unsafe virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		this.Initialize();
		AActor owner = meshComp.GetOwner();
		if (owner is TsBaseCharacter || owner is TsBaseVehicle)
		{
			Entity entityNoBlueprint = (owner as TsBaseCharacter).GetEntityNoBlueprint();
			if (entityNoBlueprint != null && entityNoBlueprint.Valid)
			{
				BaseBuffComponent component = entityNoBlueprint.GetComponent<BaseBuffComponent>();
				long? preContextId = (component != null) ? component.CreateAnimNotifyContent(animation.GetName(), base.exportIndex) : null;
				BaseSkillComponent component2 = entityNoBlueprint.GetComponent<BaseSkillComponent>();
				int skillId = (component2 != null) ? component2.GetCurrentMontageCorrespondingSkillId() : 0;
				int num3 = this.BulletIds.Num();
				int num2 = this.LocationOffsets.Num();
				List<int> list = new List<int>();
				for (int i = 0; i < num3; i++)
				{
					FVector? locationOffset = null;
					if (num2 > i)
					{
						locationOffset = new FVector?(this.LocationOffsets.Get(i));
					}
					FRotator? beginRotatorOffset = null;
					if (num2 > i)
					{
						beginRotatorOffset = new FRotator?(this.RotatorOffsets.Get(i));
					}
					list.Add(BulletUtil.CreateBulletFromAN(owner as TsBaseCharacter, this.BulletIds.Get(i), new FTransformDouble?(this.UeTransform.Value), skillId, false, preContextId, null, locationOffset, beginRotatorOffset));
				}
				this.BulletEntityIdsMap.Add(meshComp, list.ToArray());
			}
			else
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Bullet;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "No Entity for TsBaseCharacter";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Name", owner);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("location", owner.D_K2_GetActorLocation());
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}
		TArray<string> bulletIdArray = this.BulletIds;
		int num = bulletIdArray.Num();
		if (num <= 0)
		{
			return false;
		}
		BP_EWorldType worldType = UKuroRenderingRuntimeBPPluginBPLibrary.GetWorldType(owner.GetWorld());
		if (worldType != BP_EWorldType.Editor && worldType != BP_EWorldType.EditorPreview)
		{
			return false;
		}
		Singleton<ResourceSystem>.Instance.LoadTypeAsync(EBpTypeName.BPL_BulletPreview.ToEnumString(), delegate
		{
			string pathName = UKismetSystemLibrary.GetPathName(UKismetSystemLibrary.GetOuterObject(this));
			this.ArrayPreviewActor = new AActor[num];
			for (int j = 0; j < num; j++)
			{
				AActor previewActor = new AActor();
				BPL_BulletPreview_C.ShowBulletPreview(pathName, new FName(bulletIdArray.Get(j)), owner, meshComp, owner.GetWorld(), ref previewActor);
				this.PreviewActor = previewActor;
				this.ArrayPreviewActor[j] = this.PreviewActor;
				this.PreviewActor = null;
			}
		}, "js_undefined");
		return false;
	}

	// Token: 0x06004571 RID: 17777 RVA: 0x0008A4B4 File Offset: 0x000886B4
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

	// Token: 0x06004572 RID: 17778 RVA: 0x0008A554 File Offset: 0x00088754
	[NullableContext(2)]
	protected unsafe virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (owner is TsBaseCharacter || owner is TsBaseVehicle)
		{
			Entity entityNoBlueprint = (owner as TsBaseCharacter).GetEntityNoBlueprint();
			if (entityNoBlueprint != null && entityNoBlueprint.Valid)
			{
				int[] array2;
				foreach (int id in this.BulletEntityIdsMap.TryGetValue(meshComp, out array2) ? array2 : new int[0])
				{
					ControllerBase<BulletController>.Instance.DestroyBullet(id, false, EBulletDestroyReason.Normal, this.DestroyEffectImmediately);
				}
				this.BulletEntityIdsMap.Remove(meshComp);
			}
			else
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Test;
				ELogAuthor author = ELogAuthor.LCZ;
				string message = "No Entity for TsBaseCharacter";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Name", owner);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("location", owner.D_K2_GetActorLocation());
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}
		if (this.ArrayPreviewActor == null)
		{
			return false;
		}
		AActor[] arrayPreviewActor = this.ArrayPreviewActor;
		for (int i = 0; i < arrayPreviewActor.Length; i++)
		{
			arrayPreviewActor[i].K2_DestroyActor();
		}
		this.ArrayPreviewActor = null;
		return false;
	}

	// Token: 0x06004573 RID: 17779 RVA: 0x0008A67C File Offset: 0x0008887C
	private void Initialize()
	{
		if (this.BulletEntityIdsMap == null)
		{
			this.BulletEntityIdsMap = new Dictionary<USkeletalMeshComponent, int[]>();
		}
		if (this.UeTransform == null)
		{
			this.UeTransform = new FTransformDouble?(new FTransformDouble());
		}
	}

	// Token: 0x06004574 RID: 17780 RVA: 0x0008A6B0 File Offset: 0x000888B0
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

	// Token: 0x06004575 RID: 17781 RVA: 0x0008A72B File Offset: 0x0008892B
	protected override string GetNotifyName_Implementation()
	{
		return "创建子弹";
	}

	// Token: 0x06004576 RID: 17782 RVA: 0x0008A732 File Offset: 0x00088932
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateBulletDuration._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateBulletDuration.TsAnimNotifyStateBulletDuration_C");
		}
		return TsAnimNotifyStateBulletDuration._ClassPtr;
	}

	// Token: 0x06004577 RID: 17783 RVA: 0x0008A758 File Offset: 0x00088958
	public TsAnimNotifyStateBulletDuration() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateBulletDuration.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004578 RID: 17784 RVA: 0x0008A780 File Offset: 0x00088980
	public TsAnimNotifyStateBulletDuration(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateBulletDuration.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004579 RID: 17785 RVA: 0x0008A7B3 File Offset: 0x000889B3
	protected TsAnimNotifyStateBulletDuration(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600457A RID: 17786 RVA: 0x0008A7BC File Offset: 0x000889BC
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x0600457B RID: 17787 RVA: 0x0008A7F8 File Offset: 0x000889F8
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0600457C RID: 17788 RVA: 0x0008A82B File Offset: 0x00088A2B
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001297 RID: 4759
	public Dictionary<USkeletalMeshComponent, int[]> BulletEntityIdsMap;

	// Token: 0x04001298 RID: 4760
	private FTransformDouble? UeTransform;

	// Token: 0x04001299 RID: 4761
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private AActor[] ArrayPreviewActor;

	// Token: 0x0400129A RID: 4762
	[Nullable(2)]
	private AActor PreviewActor;

	// Token: 0x0400129B RID: 4763
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateBulletDuration.TsAnimNotifyStateBulletDuration_C";

	// Token: 0x0400129C RID: 4764
	private static IntPtr _ClassPtr;

	// Token: 0x0400129D RID: 4765
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400129E RID: 4766
	private static int __PropertyOffset_BulletIds;

	// Token: 0x0400129F RID: 4767
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<string> _BulletIds;

	// Token: 0x040012A0 RID: 4768
	private static int __PropertyOffset_LocationOffsets;

	// Token: 0x040012A1 RID: 4769
	[Nullable(2)]
	private TArray<FVector> _LocationOffsets;

	// Token: 0x040012A2 RID: 4770
	private static int __PropertyOffset_RotatorOffsets;

	// Token: 0x040012A3 RID: 4771
	[Nullable(2)]
	private TArray<FRotator> _RotatorOffsets;

	// Token: 0x040012A4 RID: 4772
	private static int __PropertyOffset_DestroyEffectImmediately;
}
