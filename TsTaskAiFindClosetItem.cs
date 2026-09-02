using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C9B RID: 3227
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskAiFindClosetItem.TsTaskAiFindClosetItem_C")]
public class TsTaskAiFindClosetItem : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170001D3 RID: 467
	// (get) Token: 0x06003BD8 RID: 15320 RVA: 0x0004F87B File Offset: 0x0004DA7B
	// (set) Token: 0x06003BD9 RID: 15321 RVA: 0x0004F88B File Offset: 0x0004DA8B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Range
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskAiFindClosetItem.__PropertyOffset_Range);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskAiFindClosetItem.__PropertyOffset_Range) = value;
		}
	}

	// Token: 0x170001D4 RID: 468
	// (get) Token: 0x06003BDA RID: 15322 RVA: 0x0004F89C File Offset: 0x0004DA9C
	// (set) Token: 0x06003BDB RID: 15323 RVA: 0x0004F8B0 File Offset: 0x0004DAB0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string ItemBlackboardKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskAiFindClosetItem.__PropertyOffset_ItemBlackboardKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskAiFindClosetItem.__PropertyOffset_ItemBlackboardKey)), value);
		}
	}

	// Token: 0x170001D5 RID: 469
	// (get) Token: 0x06003BDC RID: 15324 RVA: 0x0004F8C5 File Offset: 0x0004DAC5
	// (set) Token: 0x06003BDD RID: 15325 RVA: 0x0004F8D9 File Offset: 0x0004DAD9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string ItemDistanceBlackboardKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskAiFindClosetItem.__PropertyOffset_ItemDistanceBlackboardKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskAiFindClosetItem.__PropertyOffset_ItemDistanceBlackboardKey)), value);
		}
	}

	// Token: 0x170001D6 RID: 470
	// (get) Token: 0x06003BDE RID: 15326 RVA: 0x0004F8EE File Offset: 0x0004DAEE
	// (set) Token: 0x06003BDF RID: 15327 RVA: 0x0004F902 File Offset: 0x0004DB02
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string ItemLocationBlackboardKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskAiFindClosetItem.__PropertyOffset_ItemLocationBlackboardKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskAiFindClosetItem.__PropertyOffset_ItemLocationBlackboardKey)), value);
		}
	}

	// Token: 0x170001D7 RID: 471
	// (get) Token: 0x06003BE0 RID: 15328 RVA: 0x0004F917 File Offset: 0x0004DB17
	// (set) Token: 0x06003BE1 RID: 15329 RVA: 0x0004F927 File Offset: 0x0004DB27
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool SearchFilterIsMarkByAi
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskAiFindClosetItem.__PropertyOffset_SearchFilterIsMarkByAi) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskAiFindClosetItem.__PropertyOffset_SearchFilterIsMarkByAi) = (value ? 1 : 0);
		}
	}

	// Token: 0x170001D8 RID: 472
	// (get) Token: 0x06003BE2 RID: 15330 RVA: 0x0004F938 File Offset: 0x0004DB38
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<string> Tag
	{
		get
		{
			base.FastCheckIsValid();
			TArray<string> result;
			if ((result = this._Tag) == null)
			{
				result = (this._Tag = new TArray<string>(base.NativePtr + (IntPtr)TsTaskAiFindClosetItem.__PropertyOffset_Tag, this));
			}
			return result;
		}
	}

	// Token: 0x170001D9 RID: 473
	// (get) Token: 0x06003BE3 RID: 15331 RVA: 0x0004F971 File Offset: 0x0004DB71
	// (set) Token: 0x06003BE4 RID: 15332 RVA: 0x0004F981 File Offset: 0x0004DB81
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool UseNavigation
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskAiFindClosetItem.__PropertyOffset_UseNavigation) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskAiFindClosetItem.__PropertyOffset_UseNavigation) = (value ? 1 : 0);
		}
	}

	// Token: 0x170001DA RID: 474
	// (get) Token: 0x06003BE5 RID: 15333 RVA: 0x0004F992 File Offset: 0x0004DB92
	// (set) Token: 0x06003BE6 RID: 15334 RVA: 0x0004F9A2 File Offset: 0x0004DBA2
	[UProperty(EPropertyFlags.CPF_None)]
	private unsafe bool TsUseNavigation
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskAiFindClosetItem.__PropertyOffset_TsUseNavigation) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskAiFindClosetItem.__PropertyOffset_TsUseNavigation) = (value ? 1 : 0);
		}
	}

	// Token: 0x06003BE7 RID: 15335 RVA: 0x0004F9B4 File Offset: 0x0004DBB4
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

	// Token: 0x06003BE8 RID: 15336 RVA: 0x0004FA24 File Offset: 0x0004DC24
	protected void InitTsVariables_Implementation()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsRange = this.Range;
			this.TsItemBlackboardKey = this.ItemBlackboardKey;
			this.TsItemDistanceBlackboardKey = this.ItemDistanceBlackboardKey;
			this.TsItemLocationBlackboardKey = this.ItemLocationBlackboardKey;
			this.TsSearchFilterIsMarkByAi = this.SearchFilterIsMarkByAi;
			this.TsFilter = new AiInteractionSearchFilter();
			TArray<string> tag = this.Tag;
			if (tag != null && tag.Num() == 0)
			{
				this.TsFilter.Tag = null;
			}
			else
			{
				for (int i = 0; i < this.Tag.Num(); i++)
				{
					this.TsFilter.Tag = new List<string>();
					this.TsFilter.Tag.Add(this.Tag.Get(i));
				}
			}
			this.TsUseNavigation = this.UseNavigation;
		}
	}

	// Token: 0x06003BE9 RID: 15337 RVA: 0x0004FB04 File Offset: 0x0004DD04
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

	// Token: 0x06003BEA RID: 15338 RVA: 0x0004FBA0 File Offset: 0x0004DDA0
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
			return;
		}
		this.InitTsVariables();
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		FVectorDouble origin = controlledPawn.D_K2_GetActorLocation();
		this.TsFilter.IsSearchedMarkByAi = new bool?(this.TsSearchFilterIsMarkByAi);
		this.TsFilter.Entity = charActorComp.Entity;
		ItemQueryResult closeActor = AiInteractionItemQueryManager.Get().GetCloseActor(origin, this.TsUseNavigation ? EItemQuerySearchType.Path : EItemQuerySearchType.Line, this.TsFilter, ownerController);
		if (closeActor == null)
		{
			base.FinishExecute(false);
			return;
		}
		if (closeActor.Length > (double)this.TsRange)
		{
			base.FinishExecute(false);
			return;
		}
		ControllerBase<BlackboardController>.Instance.SetIntValueByEntity(charActorComp.Entity.Id, this.TsItemBlackboardKey, closeActor.Entity.Id);
		ControllerBase<BlackboardController>.Instance.SetFloatValueByEntity(charActorComp.Entity.Id, this.TsItemDistanceBlackboardKey, (float)closeActor.Length);
		CreatureDataComponent component = closeActor.Entity.GetComponent<CreatureDataComponent>();
		if (component == null)
		{
			return;
		}
		if (component.GetEntityType() == EEntityType.SceneItem)
		{
			FVectorDouble actorLocation = closeActor.Entity.GetComponent<SceneItemActorComponent>().ActorLocation;
			ControllerBase<BlackboardController>.Instance.SetVectorValueByEntity(charActorComp.Entity.Id, this.TsItemLocationBlackboardKey, (double)((float)actorLocation.X), (double)((float)actorLocation.Y), (double)((float)actorLocation.Z));
		}
		base.FinishExecute(true);
	}

	// Token: 0x06003BEB RID: 15339 RVA: 0x0004FD27 File Offset: 0x0004DF27
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskAiFindClosetItem._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskAiFindClosetItem.TsTaskAiFindClosetItem_C");
		}
		return TsTaskAiFindClosetItem._ClassPtr;
	}

	// Token: 0x06003BEC RID: 15340 RVA: 0x0004FD4C File Offset: 0x0004DF4C
	public TsTaskAiFindClosetItem() : this(BuiltinUtils.AllocNativeUObject(TsTaskAiFindClosetItem.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003BED RID: 15341 RVA: 0x0004FD74 File Offset: 0x0004DF74
	public TsTaskAiFindClosetItem(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskAiFindClosetItem.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003BEE RID: 15342 RVA: 0x0004FDA7 File Offset: 0x0004DFA7
	protected TsTaskAiFindClosetItem(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003BEF RID: 15343 RVA: 0x0004FDD1 File Offset: 0x0004DFD1
	protected virtual void __CPPCALL_InitTsVariables_Implementation()
	{
		this.InitTsVariables_Implementation();
	}

	// Token: 0x06003BF0 RID: 15344 RVA: 0x0004FDDC File Offset: 0x0004DFDC
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000B11 RID: 2833
	private bool IsInitTsVariables;

	// Token: 0x04000B12 RID: 2834
	private float TsRange;

	// Token: 0x04000B13 RID: 2835
	private string TsItemBlackboardKey = "";

	// Token: 0x04000B14 RID: 2836
	private string TsItemDistanceBlackboardKey = "";

	// Token: 0x04000B15 RID: 2837
	private string TsItemLocationBlackboardKey = "";

	// Token: 0x04000B16 RID: 2838
	private bool TsSearchFilterIsMarkByAi;

	// Token: 0x04000B17 RID: 2839
	[Nullable(2)]
	private AiInteractionSearchFilter TsFilter;

	// Token: 0x04000B18 RID: 2840
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskAiFindClosetItem.TsTaskAiFindClosetItem_C";

	// Token: 0x04000B19 RID: 2841
	private static IntPtr _ClassPtr;

	// Token: 0x04000B1A RID: 2842
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000B1B RID: 2843
	private static int __PropertyOffset_Range;

	// Token: 0x04000B1C RID: 2844
	private static int __PropertyOffset_ItemBlackboardKey;

	// Token: 0x04000B1D RID: 2845
	private static int __PropertyOffset_ItemDistanceBlackboardKey;

	// Token: 0x04000B1E RID: 2846
	private static int __PropertyOffset_ItemLocationBlackboardKey;

	// Token: 0x04000B1F RID: 2847
	private static int __PropertyOffset_SearchFilterIsMarkByAi;

	// Token: 0x04000B20 RID: 2848
	private static int __PropertyOffset_Tag;

	// Token: 0x04000B21 RID: 2849
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<string> _Tag;

	// Token: 0x04000B22 RID: 2850
	private static int __PropertyOffset_UseNavigation;

	// Token: 0x04000B23 RID: 2851
	private static int __PropertyOffset_TsUseNavigation;
}
