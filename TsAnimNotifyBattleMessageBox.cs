using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DA9 RID: 3497
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyBattleMessageBox.TsAnimNotifyBattleMessageBox_C")]
public class TsAnimNotifyBattleMessageBox : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170004E8 RID: 1256
	// (get) Token: 0x06004EA8 RID: 20136 RVA: 0x000B3DA7 File Offset: 0x000B1FA7
	// (set) Token: 0x06004EA9 RID: 20137 RVA: 0x000B3DB7 File Offset: 0x000B1FB7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int BoardId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyBattleMessageBox.__PropertyOffset_BoardId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyBattleMessageBox.__PropertyOffset_BoardId) = value;
		}
	}

	// Token: 0x06004EAA RID: 20138 RVA: 0x000B3DC8 File Offset: 0x000B1FC8
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

	// Token: 0x06004EAB RID: 20139 RVA: 0x000B3E67 File Offset: 0x000B2067
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (this.BoardId > 0)
		{
			ControllerBase<SoundAreaPlayTipsController>.Instance.OpenSoundAreaPlayTips(this.BoardId);
		}
		return true;
	}

	// Token: 0x06004EAC RID: 20140 RVA: 0x000B3E84 File Offset: 0x000B2084
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

	// Token: 0x06004EAD RID: 20141 RVA: 0x000B3EFF File Offset: 0x000B20FF
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "战斗弹窗";
	}

	// Token: 0x06004EAE RID: 20142 RVA: 0x000B3F06 File Offset: 0x000B2106
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyBattleMessageBox._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyBattleMessageBox.TsAnimNotifyBattleMessageBox_C");
		}
		return TsAnimNotifyBattleMessageBox._ClassPtr;
	}

	// Token: 0x06004EAF RID: 20143 RVA: 0x000B3F2C File Offset: 0x000B212C
	public TsAnimNotifyBattleMessageBox() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyBattleMessageBox.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004EB0 RID: 20144 RVA: 0x000B3F54 File Offset: 0x000B2154
	[NullableContext(1)]
	public TsAnimNotifyBattleMessageBox(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyBattleMessageBox.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004EB1 RID: 20145 RVA: 0x000B3F87 File Offset: 0x000B2187
	protected TsAnimNotifyBattleMessageBox(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004EB2 RID: 20146 RVA: 0x000B3F90 File Offset: 0x000B2190
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004EB3 RID: 20147 RVA: 0x000B3FC3 File Offset: 0x000B21C3
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040016D6 RID: 5846
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyBattleMessageBox.TsAnimNotifyBattleMessageBox_C";

	// Token: 0x040016D7 RID: 5847
	private static IntPtr _ClassPtr;

	// Token: 0x040016D8 RID: 5848
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040016D9 RID: 5849
	private static int __PropertyOffset_BoardId;
}
