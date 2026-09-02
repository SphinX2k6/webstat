using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.QuickHack;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DDA RID: 3546
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyOpenQuickHack.TsAnimNotifyOpenQuickHack_C")]
public class TsAnimNotifyOpenQuickHack : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000540 RID: 1344
	// (get) Token: 0x0600513A RID: 20794 RVA: 0x000BC92B File Offset: 0x000BAB2B
	// (set) Token: 0x0600513B RID: 20795 RVA: 0x000BC93B File Offset: 0x000BAB3B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int DeviceId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyOpenQuickHack.__PropertyOffset_DeviceId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyOpenQuickHack.__PropertyOffset_DeviceId) = value;
		}
	}

	// Token: 0x17000541 RID: 1345
	// (get) Token: 0x0600513C RID: 20796 RVA: 0x000BC94C File Offset: 0x000BAB4C
	// (set) Token: 0x0600513D RID: 20797 RVA: 0x000BC95C File Offset: 0x000BAB5C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool CloseWhenInteractFinish
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyOpenQuickHack.__PropertyOffset_CloseWhenInteractFinish) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyOpenQuickHack.__PropertyOffset_CloseWhenInteractFinish) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000542 RID: 1346
	// (get) Token: 0x0600513E RID: 20798 RVA: 0x000BC96D File Offset: 0x000BAB6D
	// (set) Token: 0x0600513F RID: 20799 RVA: 0x000BC981 File Offset: 0x000BAB81
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag InteractFinishGameplayEventTag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyOpenQuickHack.__PropertyOffset_InteractFinishGameplayEventTag);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyOpenQuickHack.__PropertyOffset_InteractFinishGameplayEventTag) = value;
		}
	}

	// Token: 0x06005140 RID: 20800 RVA: 0x000BC998 File Offset: 0x000BAB98
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

	// Token: 0x06005141 RID: 20801 RVA: 0x000BCA38 File Offset: 0x000BAC38
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		int deviceId = this.DeviceId;
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			if (characterActorComponent != null && characterActorComponent.IsAutonomousProxy && deviceId > 0)
			{
				ControllerBase<QuickHackController>.Instance.OpenQuickHack(deviceId, tsBaseCharacter.GetEntityIdNoBlueprint(), this.CloseWhenInteractFinish, new FGameplayTag?(this.InteractFinishGameplayEventTag), null);
			}
		}
		return true;
	}

	// Token: 0x06005142 RID: 20802 RVA: 0x000BCA98 File Offset: 0x000BAC98
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

	// Token: 0x06005143 RID: 20803 RVA: 0x000BCB13 File Offset: 0x000BAD13
	protected override string GetNotifyName_Implementation()
	{
		return "开启快速破解";
	}

	// Token: 0x06005144 RID: 20804 RVA: 0x000BCB1A File Offset: 0x000BAD1A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyOpenQuickHack._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyOpenQuickHack.TsAnimNotifyOpenQuickHack_C");
		}
		return TsAnimNotifyOpenQuickHack._ClassPtr;
	}

	// Token: 0x06005145 RID: 20805 RVA: 0x000BCB40 File Offset: 0x000BAD40
	public TsAnimNotifyOpenQuickHack() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyOpenQuickHack.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005146 RID: 20806 RVA: 0x000BCB68 File Offset: 0x000BAD68
	public TsAnimNotifyOpenQuickHack(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyOpenQuickHack.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06005147 RID: 20807 RVA: 0x000BCB9B File Offset: 0x000BAD9B
	protected TsAnimNotifyOpenQuickHack(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005148 RID: 20808 RVA: 0x000BCBA4 File Offset: 0x000BADA4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06005149 RID: 20809 RVA: 0x000BCBD7 File Offset: 0x000BADD7
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040017D0 RID: 6096
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyOpenQuickHack.TsAnimNotifyOpenQuickHack_C";

	// Token: 0x040017D1 RID: 6097
	private static IntPtr _ClassPtr;

	// Token: 0x040017D2 RID: 6098
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040017D3 RID: 6099
	private static int __PropertyOffset_DeviceId;

	// Token: 0x040017D4 RID: 6100
	private static int __PropertyOffset_CloseWhenInteractFinish;

	// Token: 0x040017D5 RID: 6101
	private static int __PropertyOffset_InteractFinishGameplayEventTag;
}
