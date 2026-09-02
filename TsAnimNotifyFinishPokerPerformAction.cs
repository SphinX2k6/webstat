using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DCE RID: 3534
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyFinishPokerPerformAction.TsAnimNotifyFinishPokerPerformAction_C")]
public class TsAnimNotifyFinishPokerPerformAction : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700052D RID: 1325
	// (get) Token: 0x060050A0 RID: 20640 RVA: 0x000BA72F File Offset: 0x000B892F
	// (set) Token: 0x060050A1 RID: 20641 RVA: 0x000BA73F File Offset: 0x000B893F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EPokerStateType PokerState
	{
		get
		{
			return (EPokerStateType)(*(base.NativePtr + (IntPtr)TsAnimNotifyFinishPokerPerformAction.__PropertyOffset_PokerState));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyFinishPokerPerformAction.__PropertyOffset_PokerState) = (byte)value;
		}
	}

	// Token: 0x060050A2 RID: 20642 RVA: 0x000BA750 File Offset: 0x000B8950
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

	// Token: 0x060050A3 RID: 20643 RVA: 0x000BA7EF File Offset: 0x000B89EF
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		Singleton<EventSystem>.Instance.Emit<EPokerStateType>(EEventName.GuessJokerFinishPokerPerformAction, this.PokerState);
		return true;
	}

	// Token: 0x060050A4 RID: 20644 RVA: 0x000BA808 File Offset: 0x000B8A08
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

	// Token: 0x060050A5 RID: 20645 RVA: 0x000BA883 File Offset: 0x000B8A83
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "猜鬼牌完成动作动画通知";
	}

	// Token: 0x060050A6 RID: 20646 RVA: 0x000BA88A File Offset: 0x000B8A8A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyFinishPokerPerformAction._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyFinishPokerPerformAction.TsAnimNotifyFinishPokerPerformAction_C");
		}
		return TsAnimNotifyFinishPokerPerformAction._ClassPtr;
	}

	// Token: 0x060050A7 RID: 20647 RVA: 0x000BA8B0 File Offset: 0x000B8AB0
	public TsAnimNotifyFinishPokerPerformAction() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyFinishPokerPerformAction.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060050A8 RID: 20648 RVA: 0x000BA8D8 File Offset: 0x000B8AD8
	[NullableContext(1)]
	public TsAnimNotifyFinishPokerPerformAction(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyFinishPokerPerformAction.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060050A9 RID: 20649 RVA: 0x000BA90B File Offset: 0x000B8B0B
	protected TsAnimNotifyFinishPokerPerformAction(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060050AA RID: 20650 RVA: 0x000BA914 File Offset: 0x000B8B14
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060050AB RID: 20651 RVA: 0x000BA947 File Offset: 0x000B8B47
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001799 RID: 6041
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyFinishPokerPerformAction.TsAnimNotifyFinishPokerPerformAction_C";

	// Token: 0x0400179A RID: 6042
	private static IntPtr _ClassPtr;

	// Token: 0x0400179B RID: 6043
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400179C RID: 6044
	private static int __PropertyOffset_PokerState;
}
