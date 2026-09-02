using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C9C RID: 3228
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskAiGetItemInfo.TsTaskAiGetItemInfo_C")]
public class TsTaskAiGetItemInfo : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170001DB RID: 475
	// (get) Token: 0x06003BF1 RID: 15345 RVA: 0x0004FE09 File Offset: 0x0004E009
	// (set) Token: 0x06003BF2 RID: 15346 RVA: 0x0004FE1D File Offset: 0x0004E01D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string ItemBlackboardKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskAiGetItemInfo.__PropertyOffset_ItemBlackboardKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskAiGetItemInfo.__PropertyOffset_ItemBlackboardKey)), value);
		}
	}

	// Token: 0x170001DC RID: 476
	// (get) Token: 0x06003BF3 RID: 15347 RVA: 0x0004FE32 File Offset: 0x0004E032
	// (set) Token: 0x06003BF4 RID: 15348 RVA: 0x0004FE46 File Offset: 0x0004E046
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string ItemDistanceBlackboardKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskAiGetItemInfo.__PropertyOffset_ItemDistanceBlackboardKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskAiGetItemInfo.__PropertyOffset_ItemDistanceBlackboardKey)), value);
		}
	}

	// Token: 0x170001DD RID: 477
	// (get) Token: 0x06003BF5 RID: 15349 RVA: 0x0004FE5B File Offset: 0x0004E05B
	// (set) Token: 0x06003BF6 RID: 15350 RVA: 0x0004FE6F File Offset: 0x0004E06F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string ItemLocationBlackboardKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskAiGetItemInfo.__PropertyOffset_ItemLocationBlackboardKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskAiGetItemInfo.__PropertyOffset_ItemLocationBlackboardKey)), value);
		}
	}

	// Token: 0x170001DE RID: 478
	// (get) Token: 0x06003BF7 RID: 15351 RVA: 0x0004FE84 File Offset: 0x0004E084
	// (set) Token: 0x06003BF8 RID: 15352 RVA: 0x0004FE94 File Offset: 0x0004E094
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool UseNavigation
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskAiGetItemInfo.__PropertyOffset_UseNavigation) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskAiGetItemInfo.__PropertyOffset_UseNavigation) = (value ? 1 : 0);
		}
	}

	// Token: 0x06003BF9 RID: 15353 RVA: 0x0004FEA8 File Offset: 0x0004E0A8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void InitTsVariables()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("InitTsVariables"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x06003BFA RID: 15354 RVA: 0x0004FF18 File Offset: 0x0004E118
	protected void InitTsVariables_Implementation()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsItemBlackboardKey = this.ItemBlackboardKey;
			this.TsItemDistanceBlackboardKey = this.ItemDistanceBlackboardKey;
			this.TsItemLocationBlackboardKey = this.ItemLocationBlackboardKey;
			this.TsUseNavigation = this.UseNavigation;
		}
	}

	// Token: 0x06003BFB RID: 15355 RVA: 0x0004FF6C File Offset: 0x0004E16C
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

	// Token: 0x06003BFC RID: 15356 RVA: 0x00050008 File Offset: 0x0004E208
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		if (aiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(false);
			return;
		}
		this.InitTsVariables();
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		int? intValueByEntity = ControllerBase<BlackboardController>.Instance.GetIntValueByEntity(charActorComp.Entity.Id, this.TsItemBlackboardKey);
		Entity entity = Singleton<EntitySystem>.Instance.Get(intValueByEntity.Value);
		CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
		if (component == null)
		{
			return;
		}
		if (entity == null || component.GetEntityType() != EEntityType.SceneItem)
		{
			base.FinishExecute(false);
			return;
		}
		FVectorDouble actorLocation = entity.GetComponent<SceneItemActorComponent>().ActorLocation;
		if (this.VectorArray == null)
		{
			this.VectorArray = new List<global::Vector>();
		}
		FVectorDouble fvectorDouble = controlledPawn.D_K2_GetActorLocation();
		double num;
		if (this.TsUseNavigation)
		{
			AiControllerLibrary.NavigationFindPath(ownerController, fvectorDouble, actorLocation, this.VectorArray, null, null);
			num = AiControllerLibrary.GetPathLength(fvectorDouble, this.VectorArray);
		}
		else
		{
			global::Vector vector = global::Vector.Create(actorLocation);
			global::Vector inB = global::Vector.Create(fvectorDouble);
			num = vector.SubtractionEqual(inB).Size();
		}
		ControllerBase<BlackboardController>.Instance.SetFloatValueByEntity(charActorComp.Entity.Id, this.TsItemDistanceBlackboardKey, (float)num);
		ControllerBase<BlackboardController>.Instance.SetVectorValueByEntity(charActorComp.Entity.Id, this.TsItemLocationBlackboardKey, (double)((float)actorLocation.X), (double)((float)actorLocation.Y), (double)((float)actorLocation.Z));
		base.FinishExecute(true);
	}

	// Token: 0x06003BFD RID: 15357 RVA: 0x000501B8 File Offset: 0x0004E3B8
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskAiGetItemInfo._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskAiGetItemInfo.TsTaskAiGetItemInfo_C");
		}
		return TsTaskAiGetItemInfo._ClassPtr;
	}

	// Token: 0x06003BFE RID: 15358 RVA: 0x000501DC File Offset: 0x0004E3DC
	public TsTaskAiGetItemInfo() : this(BuiltinUtils.AllocNativeUObject(TsTaskAiGetItemInfo.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003BFF RID: 15359 RVA: 0x00050204 File Offset: 0x0004E404
	public TsTaskAiGetItemInfo(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskAiGetItemInfo.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003C00 RID: 15360 RVA: 0x00050237 File Offset: 0x0004E437
	protected TsTaskAiGetItemInfo(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003C01 RID: 15361 RVA: 0x00050261 File Offset: 0x0004E461
	protected virtual void __CPPCALL_InitTsVariables_Implementation()
	{
		this.InitTsVariables_Implementation();
	}

	// Token: 0x06003C02 RID: 15362 RVA: 0x0005026C File Offset: 0x0004E46C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000B24 RID: 2852
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<global::Vector> VectorArray;

	// Token: 0x04000B25 RID: 2853
	private bool IsInitTsVariables;

	// Token: 0x04000B26 RID: 2854
	private string TsItemBlackboardKey = "";

	// Token: 0x04000B27 RID: 2855
	private string TsItemDistanceBlackboardKey = "";

	// Token: 0x04000B28 RID: 2856
	private string TsItemLocationBlackboardKey = "";

	// Token: 0x04000B29 RID: 2857
	private bool TsUseNavigation;

	// Token: 0x04000B2A RID: 2858
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskAiGetItemInfo.TsTaskAiGetItemInfo_C";

	// Token: 0x04000B2B RID: 2859
	private static IntPtr _ClassPtr;

	// Token: 0x04000B2C RID: 2860
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000B2D RID: 2861
	private static int __PropertyOffset_ItemBlackboardKey;

	// Token: 0x04000B2E RID: 2862
	private static int __PropertyOffset_ItemDistanceBlackboardKey;

	// Token: 0x04000B2F RID: 2863
	private static int __PropertyOffset_ItemLocationBlackboardKey;

	// Token: 0x04000B30 RID: 2864
	private static int __PropertyOffset_UseNavigation;
}
