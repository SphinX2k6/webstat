using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DD5 RID: 3541
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyJoinTeamQte.TsAnimNotifyJoinTeamQte_C")]
public class TsAnimNotifyJoinTeamQte : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000539 RID: 1337
	// (get) Token: 0x060050FE RID: 20734 RVA: 0x000BB90B File Offset: 0x000B9B0B
	// (set) Token: 0x060050FF RID: 20735 RVA: 0x000BB91B File Offset: 0x000B9B1B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int QteId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyJoinTeamQte.__PropertyOffset_QteId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyJoinTeamQte.__PropertyOffset_QteId) = value;
		}
	}

	// Token: 0x1700053A RID: 1338
	// (get) Token: 0x06005100 RID: 20736 RVA: 0x000BB92C File Offset: 0x000B9B2C
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<int> PreloadRoleIdList
	{
		get
		{
			base.FastCheckIsValid();
			TArray<int> result;
			if ((result = this._PreloadRoleIdList) == null)
			{
				result = (this._PreloadRoleIdList = new TArray<int>(base.NativePtr + (IntPtr)TsAnimNotifyJoinTeamQte.__PropertyOffset_PreloadRoleIdList, this));
			}
			return result;
		}
	}

	// Token: 0x1700053B RID: 1339
	// (get) Token: 0x06005101 RID: 20737 RVA: 0x000BB965 File Offset: 0x000B9B65
	// (set) Token: 0x06005102 RID: 20738 RVA: 0x000BB975 File Offset: 0x000B9B75
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool ShowTrialRoleTips
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyJoinTeamQte.__PropertyOffset_ShowTrialRoleTips) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyJoinTeamQte.__PropertyOffset_ShowTrialRoleTips) = (value ? 1 : 0);
		}
	}

	// Token: 0x06005103 RID: 20739 RVA: 0x000BB988 File Offset: 0x000B9B88
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

	// Token: 0x06005104 RID: 20740 RVA: 0x000BBA28 File Offset: 0x000B9C28
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			return true;
		}
		if (this.PreloadRoleIdList == null)
		{
			return true;
		}
		long? preMessageId = null;
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return true;
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
		if (entity == null)
		{
			return true;
		}
		preMessageId = entity.GetComponent<BaseBuffComponent>().CreateAnimNotifyContent(animation.GetName(), base.exportIndex);
		int num = ControllerBase<PanelQteController>.Instance.StartAnimNotifyQte(this.QteId, meshComp, preMessageId);
		if (num <= 0)
		{
			return true;
		}
		List<int> list = new List<int>();
		for (int i = 0; i < this.PreloadRoleIdList.Num(); i++)
		{
			list.Add(this.PreloadRoleIdList.Get(i));
		}
		ControllerBase<SceneTeamController>.Instance.RegisterPanelQteJoinTeam(num, list.ToArray(), this.ShowTrialRoleTips);
		return true;
	}

	// Token: 0x06005105 RID: 20741 RVA: 0x000BBB04 File Offset: 0x000B9D04
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

	// Token: 0x06005106 RID: 20742 RVA: 0x000BBB7F File Offset: 0x000B9D7F
	protected override string GetNotifyName_Implementation()
	{
		return "角色入队QTE";
	}

	// Token: 0x06005107 RID: 20743 RVA: 0x000BBB86 File Offset: 0x000B9D86
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyJoinTeamQte._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyJoinTeamQte.TsAnimNotifyJoinTeamQte_C");
		}
		return TsAnimNotifyJoinTeamQte._ClassPtr;
	}

	// Token: 0x06005108 RID: 20744 RVA: 0x000BBBAC File Offset: 0x000B9DAC
	public TsAnimNotifyJoinTeamQte() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyJoinTeamQte.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005109 RID: 20745 RVA: 0x000BBBD4 File Offset: 0x000B9DD4
	public TsAnimNotifyJoinTeamQte(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyJoinTeamQte.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600510A RID: 20746 RVA: 0x000BBC07 File Offset: 0x000B9E07
	protected TsAnimNotifyJoinTeamQte(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600510B RID: 20747 RVA: 0x000BBC10 File Offset: 0x000B9E10
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0600510C RID: 20748 RVA: 0x000BBC43 File Offset: 0x000B9E43
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040017BA RID: 6074
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyJoinTeamQte.TsAnimNotifyJoinTeamQte_C";

	// Token: 0x040017BB RID: 6075
	private static IntPtr _ClassPtr;

	// Token: 0x040017BC RID: 6076
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040017BD RID: 6077
	private static int __PropertyOffset_QteId;

	// Token: 0x040017BE RID: 6078
	private static int __PropertyOffset_PreloadRoleIdList;

	// Token: 0x040017BF RID: 6079
	[Nullable(2)]
	private TArray<int> _PreloadRoleIdList;

	// Token: 0x040017C0 RID: 6080
	private static int __PropertyOffset_ShowTrialRoleTips;
}
