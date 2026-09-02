using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.SceneItem;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C9D RID: 3229
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskAiMarkItem.TsTaskAiMarkItem_C")]
public class TsTaskAiMarkItem : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170001DF RID: 479
	// (get) Token: 0x06003C03 RID: 15363 RVA: 0x00050299 File Offset: 0x0004E499
	// (set) Token: 0x06003C04 RID: 15364 RVA: 0x000502AD File Offset: 0x0004E4AD
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string ItemBlackboardKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskAiMarkItem.__PropertyOffset_ItemBlackboardKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskAiMarkItem.__PropertyOffset_ItemBlackboardKey)), value);
		}
	}

	// Token: 0x170001E0 RID: 480
	// (get) Token: 0x06003C05 RID: 15365 RVA: 0x000502C2 File Offset: 0x0004E4C2
	// (set) Token: 0x06003C06 RID: 15366 RVA: 0x000502D2 File Offset: 0x0004E4D2
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool SearchFilterIsMarkByAi
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskAiMarkItem.__PropertyOffset_SearchFilterIsMarkByAi) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskAiMarkItem.__PropertyOffset_SearchFilterIsMarkByAi) = (value ? 1 : 0);
		}
	}

	// Token: 0x06003C07 RID: 15367 RVA: 0x000502E4 File Offset: 0x0004E4E4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void InitTsVariables()
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

	// Token: 0x06003C08 RID: 15368 RVA: 0x00050354 File Offset: 0x0004E554
	protected void InitTsVariables_Implementation()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsItemBlackboardKey = this.ItemBlackboardKey;
			this.TsSearchFilterIsMarkByAi = this.SearchFilterIsMarkByAi;
		}
	}

	// Token: 0x06003C09 RID: 15369 RVA: 0x00050384 File Offset: 0x0004E584
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

	// Token: 0x06003C0A RID: 15370 RVA: 0x00050420 File Offset: 0x0004E620
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
		CharacterWeaponComponent component = charActorComp.Entity.GetComponent<CharacterWeaponComponent>();
		int? intValueByEntity = ControllerBase<BlackboardController>.Instance.GetIntValueByEntity(charActorComp.Entity.Id, this.TsItemBlackboardKey);
		if (component.AiItemMarkId != 0 && this.TsSearchFilterIsMarkByAi)
		{
			int aiItemMarkId = component.AiItemMarkId;
			int? num = intValueByEntity;
			if (aiItemMarkId == num.GetValueOrDefault() & num != null)
			{
				base.FinishExecute(true);
				return;
			}
			base.FinishExecute(false);
			return;
		}
		else
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get(intValueByEntity.Value);
			if (entity == null)
			{
				base.FinishExecute(false);
				return;
			}
			SceneItemAiInteractionComponent component2 = entity.GetComponent<SceneItemAiInteractionComponent>();
			if (component2 == null)
			{
				base.FinishExecute(false);
				return;
			}
			if (!component2.IsSearchByOther(charActorComp.Entity.Id))
			{
				if (this.TsSearchFilterIsMarkByAi)
				{
					component.AiItemMarkId = entity.Id;
					component2.SetSearched(charActorComp.Entity);
				}
				else
				{
					component.AiItemMarkId = 0;
					component2.SetUnSearched();
				}
				base.FinishExecute(true);
				return;
			}
			base.FinishExecute(false);
			return;
		}
	}

	// Token: 0x06003C0B RID: 15371 RVA: 0x00050579 File Offset: 0x0004E779
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskAiMarkItem._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskAiMarkItem.TsTaskAiMarkItem_C");
		}
		return TsTaskAiMarkItem._ClassPtr;
	}

	// Token: 0x06003C0C RID: 15372 RVA: 0x000505A0 File Offset: 0x0004E7A0
	public TsTaskAiMarkItem() : this(BuiltinUtils.AllocNativeUObject(TsTaskAiMarkItem.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003C0D RID: 15373 RVA: 0x000505C8 File Offset: 0x0004E7C8
	public TsTaskAiMarkItem(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskAiMarkItem.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003C0E RID: 15374 RVA: 0x000505FB File Offset: 0x0004E7FB
	protected TsTaskAiMarkItem(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003C0F RID: 15375 RVA: 0x0005060F File Offset: 0x0004E80F
	protected virtual void __CPPCALL_InitTsVariables_Implementation()
	{
		this.InitTsVariables_Implementation();
	}

	// Token: 0x06003C10 RID: 15376 RVA: 0x00050618 File Offset: 0x0004E818
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000B31 RID: 2865
	private bool IsInitTsVariables;

	// Token: 0x04000B32 RID: 2866
	private string TsItemBlackboardKey = "";

	// Token: 0x04000B33 RID: 2867
	private bool TsSearchFilterIsMarkByAi;

	// Token: 0x04000B34 RID: 2868
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskAiMarkItem.TsTaskAiMarkItem_C";

	// Token: 0x04000B35 RID: 2869
	private static IntPtr _ClassPtr;

	// Token: 0x04000B36 RID: 2870
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000B37 RID: 2871
	private static int __PropertyOffset_ItemBlackboardKey;

	// Token: 0x04000B38 RID: 2872
	private static int __PropertyOffset_SearchFilterIsMarkByAi;
}
