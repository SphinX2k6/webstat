using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C82 RID: 3202
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskNpcDisableEntityLookAt.TsTaskNpcDisableEntityLookAt_C")]
public class TsTaskNpcDisableEntityLookAt : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700018B RID: 395
	// (get) Token: 0x06003A0B RID: 14859 RVA: 0x00045944 File Offset: 0x00043B44
	// (set) Token: 0x06003A0C RID: 14860 RVA: 0x00045958 File Offset: 0x00043B58
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string Key
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskNpcDisableEntityLookAt.__PropertyOffset_Key)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskNpcDisableEntityLookAt.__PropertyOffset_Key)), value);
		}
	}

	// Token: 0x06003A0D RID: 14861 RVA: 0x00045970 File Offset: 0x00043B70
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveExecuteAI(AAIController ownerController, APawn controlledPawn)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveExecuteAI"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams*)ptr + 15L / (long)sizeof(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->OwnerController) = ((ownerController != null) ? ownerController.NativePtr : ((IntPtr)0));
			*(&ptr2->ControlledPawn) = ((controlledPawn != null) ? controlledPawn.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06003A0E RID: 14862 RVA: 0x00045A0C File Offset: 0x00043C0C
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		if (this.Key == "")
		{
			base.FinishExecute(true);
			return;
		}
		if (!ControllerBase<NpcPerformController>.Instance.EntityLookAtCacheForKey.ContainsKey(this.Key))
		{
			base.FinishExecute(true);
			return;
		}
		ControllerBase<NpcPerformController>.Instance.RemoveNpcLookAtParams(this.Key);
		base.FinishExecute(true);
	}

	// Token: 0x06003A0F RID: 14863 RVA: 0x00045A69 File Offset: 0x00043C69
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskNpcDisableEntityLookAt._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskNpcDisableEntityLookAt.TsTaskNpcDisableEntityLookAt_C");
		}
		return TsTaskNpcDisableEntityLookAt._ClassPtr;
	}

	// Token: 0x06003A10 RID: 14864 RVA: 0x00045A90 File Offset: 0x00043C90
	public TsTaskNpcDisableEntityLookAt() : this(BuiltinUtils.AllocNativeUObject(TsTaskNpcDisableEntityLookAt.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003A11 RID: 14865 RVA: 0x00045AB8 File Offset: 0x00043CB8
	public TsTaskNpcDisableEntityLookAt(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskNpcDisableEntityLookAt.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003A12 RID: 14866 RVA: 0x00045AEB File Offset: 0x00043CEB
	protected TsTaskNpcDisableEntityLookAt(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003A13 RID: 14867 RVA: 0x00045AF4 File Offset: 0x00043CF4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000997 RID: 2455
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskNpcDisableEntityLookAt.TsTaskNpcDisableEntityLookAt_C";

	// Token: 0x04000998 RID: 2456
	private static IntPtr _ClassPtr;

	// Token: 0x04000999 RID: 2457
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400099A RID: 2458
	private static int __PropertyOffset_Key;
}
