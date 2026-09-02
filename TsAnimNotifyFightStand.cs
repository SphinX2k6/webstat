using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DCD RID: 3533
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyFightStand.TsAnimNotifyFightStand_C")]
public class TsAnimNotifyFightStand : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700052C RID: 1324
	// (get) Token: 0x06005094 RID: 20628 RVA: 0x000BA4B7 File Offset: 0x000B86B7
	// (set) Token: 0x06005095 RID: 20629 RVA: 0x000BA4C7 File Offset: 0x000B86C7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int BattleIdleTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyFightStand.__PropertyOffset_BattleIdleTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyFightStand.__PropertyOffset_BattleIdleTime) = value;
		}
	}

	// Token: 0x06005096 RID: 20630 RVA: 0x000BA4D8 File Offset: 0x000B86D8
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

	// Token: 0x06005097 RID: 20631 RVA: 0x000BA578 File Offset: 0x000B8778
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			object obj;
			if (characterActorComponent == null)
			{
				obj = null;
			}
			else
			{
				Entity entity = characterActorComponent.Entity;
				obj = ((entity != null) ? entity.GetComponent<CharacterAnimationComponent>() : null);
			}
			object obj2 = obj;
			if (obj2 != null)
			{
				obj2.EnterBattleIdle(new int?((this.BattleIdleTime > 0) ? this.BattleIdleTime : 5000));
			}
		}
		return true;
	}

	// Token: 0x06005098 RID: 20632 RVA: 0x000BA5DC File Offset: 0x000B87DC
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

	// Token: 0x06005099 RID: 20633 RVA: 0x000BA657 File Offset: 0x000B8857
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "设置战斗待机";
	}

	// Token: 0x0600509A RID: 20634 RVA: 0x000BA65E File Offset: 0x000B885E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyFightStand._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyFightStand.TsAnimNotifyFightStand_C");
		}
		return TsAnimNotifyFightStand._ClassPtr;
	}

	// Token: 0x0600509B RID: 20635 RVA: 0x000BA684 File Offset: 0x000B8884
	public TsAnimNotifyFightStand() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyFightStand.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600509C RID: 20636 RVA: 0x000BA6AC File Offset: 0x000B88AC
	[NullableContext(1)]
	public TsAnimNotifyFightStand(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyFightStand.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600509D RID: 20637 RVA: 0x000BA6DF File Offset: 0x000B88DF
	protected TsAnimNotifyFightStand(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600509E RID: 20638 RVA: 0x000BA6E8 File Offset: 0x000B88E8
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0600509F RID: 20639 RVA: 0x000BA71B File Offset: 0x000B891B
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001794 RID: 6036
	private const int BATLLE_IDLE_TIME = 5000;

	// Token: 0x04001795 RID: 6037
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyFightStand.TsAnimNotifyFightStand_C";

	// Token: 0x04001796 RID: 6038
	private static IntPtr _ClassPtr;

	// Token: 0x04001797 RID: 6039
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001798 RID: 6040
	private static int __PropertyOffset_BattleIdleTime;
}
