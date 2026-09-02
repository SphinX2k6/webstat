using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DF4 RID: 3572
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyTriggerGuide.TsAnimNotifyTriggerGuide_C")]
public class TsAnimNotifyTriggerGuide : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700058E RID: 1422
	// (get) Token: 0x060052D6 RID: 21206 RVA: 0x000C2297 File Offset: 0x000C0497
	// (set) Token: 0x060052D7 RID: 21207 RVA: 0x000C22A7 File Offset: 0x000C04A7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int EventGroupId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyTriggerGuide.__PropertyOffset_EventGroupId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyTriggerGuide.__PropertyOffset_EventGroupId) = value;
		}
	}

	// Token: 0x060052D8 RID: 21208 RVA: 0x000C22B8 File Offset: 0x000C04B8
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

	// Token: 0x060052D9 RID: 21209 RVA: 0x000C2358 File Offset: 0x000C0558
	[NullableContext(2)]
	protected unsafe virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num = this.ParseEventGroupId2GuideGroupId(this.EventGroupId);
		GuideTrigger @params = new GuideTrigger
		{
			Type = EGuideTriggerType.BeginnerGuide,
			GuideId = num
		};
		List<ActionInfo> actions = new List<ActionInfo>
		{
			new ActionInfo
			{
				Name = EAction.GuideTrigger,
				Params = @params
			}
		};
		ControllerBase<LevelGeneralController>.Instance.ExecuteActionsNew(actions, EntityContext.Create(0, null), null);
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.Guide;
		ELogAuthor author = ELogAuthor.WZ;
		string message = "由蒙太奇触发的引导";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EventGroupId", this.EventGroupId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("GuideGroupId", num);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		return true;
	}

	// Token: 0x060052DA RID: 21210 RVA: 0x000C2428 File Offset: 0x000C0628
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

	// Token: 0x060052DB RID: 21211 RVA: 0x000C24A3 File Offset: 0x000C06A3
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "执行行为组事件";
	}

	// Token: 0x060052DC RID: 21212 RVA: 0x000C24AC File Offset: 0x000C06AC
	private int ParseEventGroupId2GuideGroupId(int eventGroupId)
	{
		if (ConfigGuideFromMontageByEventGroupId.GetConfig(eventGroupId, true) == null)
		{
			return 0;
		}
		GuideFromMontage? guideFromMontage;
		return guideFromMontage.GetValueOrDefault().GuideGroupId;
	}

	// Token: 0x060052DD RID: 21213 RVA: 0x000C24DB File Offset: 0x000C06DB
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyTriggerGuide._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyTriggerGuide.TsAnimNotifyTriggerGuide_C");
		}
		return TsAnimNotifyTriggerGuide._ClassPtr;
	}

	// Token: 0x060052DE RID: 21214 RVA: 0x000C2500 File Offset: 0x000C0700
	public TsAnimNotifyTriggerGuide() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyTriggerGuide.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060052DF RID: 21215 RVA: 0x000C2528 File Offset: 0x000C0728
	[NullableContext(1)]
	public TsAnimNotifyTriggerGuide(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyTriggerGuide.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060052E0 RID: 21216 RVA: 0x000C255B File Offset: 0x000C075B
	protected TsAnimNotifyTriggerGuide(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060052E1 RID: 21217 RVA: 0x000C2564 File Offset: 0x000C0764
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060052E2 RID: 21218 RVA: 0x000C2597 File Offset: 0x000C0797
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400187B RID: 6267
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyTriggerGuide.TsAnimNotifyTriggerGuide_C";

	// Token: 0x0400187C RID: 6268
	private static IntPtr _ClassPtr;

	// Token: 0x0400187D RID: 6269
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400187E RID: 6270
	private static int __PropertyOffset_EventGroupId;
}
