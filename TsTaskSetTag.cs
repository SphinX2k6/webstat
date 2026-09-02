using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using CSharpScript.Game.NewWorld.Common.Component;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CD6 RID: 3286
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskSetTag.TsTaskSetTag_C")]
public class TsTaskSetTag : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170002D4 RID: 724
	// (get) Token: 0x06004072 RID: 16498 RVA: 0x0006669F File Offset: 0x0006489F
	// (set) Token: 0x06004073 RID: 16499 RVA: 0x000666B3 File Offset: 0x000648B3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag GameplayTag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskSetTag.__PropertyOffset_GameplayTag);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskSetTag.__PropertyOffset_GameplayTag) = value;
		}
	}

	// Token: 0x170002D5 RID: 725
	// (get) Token: 0x06004074 RID: 16500 RVA: 0x000666C8 File Offset: 0x000648C8
	// (set) Token: 0x06004075 RID: 16501 RVA: 0x000666DC File Offset: 0x000648DC
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string ActorTag
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskSetTag.__PropertyOffset_ActorTag)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskSetTag.__PropertyOffset_ActorTag)), value);
		}
	}

	// Token: 0x170002D6 RID: 726
	// (get) Token: 0x06004076 RID: 16502 RVA: 0x000666F1 File Offset: 0x000648F1
	// (set) Token: 0x06004077 RID: 16503 RVA: 0x00066705 File Offset: 0x00064905
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string TargetKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskSetTag.__PropertyOffset_TargetKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskSetTag.__PropertyOffset_TargetKey)), value);
		}
	}

	// Token: 0x170002D7 RID: 727
	// (get) Token: 0x06004078 RID: 16504 RVA: 0x0006671A File Offset: 0x0006491A
	// (set) Token: 0x06004079 RID: 16505 RVA: 0x0006672A File Offset: 0x0006492A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsCommonTag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskSetTag.__PropertyOffset_IsCommonTag) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskSetTag.__PropertyOffset_IsCommonTag) = (value ? 1 : 0);
		}
	}

	// Token: 0x170002D8 RID: 728
	// (get) Token: 0x0600407A RID: 16506 RVA: 0x0006673B File Offset: 0x0006493B
	// (set) Token: 0x0600407B RID: 16507 RVA: 0x0006674B File Offset: 0x0006494B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsAdd
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskSetTag.__PropertyOffset_IsAdd) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskSetTag.__PropertyOffset_IsAdd) = (value ? 1 : 0);
		}
	}

	// Token: 0x170002D9 RID: 729
	// (get) Token: 0x0600407C RID: 16508 RVA: 0x0006675C File Offset: 0x0006495C
	// (set) Token: 0x0600407D RID: 16509 RVA: 0x0006676C File Offset: 0x0006496C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool SetToPlayer
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskSetTag.__PropertyOffset_SetToPlayer) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskSetTag.__PropertyOffset_SetToPlayer) = (value ? 1 : 0);
		}
	}

	// Token: 0x0600407E RID: 16510 RVA: 0x00066780 File Offset: 0x00064980
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsGameplayTag = new FGameplayTag?(this.GameplayTag);
			this.TsActorTag = FNameUtil.GetDynamicFName(this.ActorTag);
			this.TsTargetKey = this.TargetKey;
			this.TsIsCommonTag = this.IsCommonTag;
			this.TsIsAdd = this.IsAdd;
			this.TsSetToPlayer = this.SetToPlayer;
		}
	}

	// Token: 0x0600407F RID: 16511 RVA: 0x000667F8 File Offset: 0x000649F8
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveTickAI(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveTickAI"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams*)ptr + 15L / (long)sizeof(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->OwnerController) = ((ownerController != null) ? ownerController.NativePtr : ((IntPtr)0));
			*(&ptr2->ControlledPawn) = ((controlledPawn != null) ? controlledPawn.NativePtr : ((IntPtr)0));
			ptr2->DeltaSeconds = deltaSeconds;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06004080 RID: 16512 RVA: 0x00066898 File Offset: 0x00064A98
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
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
		if (this.TsGameplayTag == null && this.TsActorTag == null)
		{
			base.FinishExecute(false);
			return;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		if (charActorComp == null || !charActorComp.Valid)
		{
			base.FinishExecute(false);
			return;
		}
		Entity entity = charActorComp.Entity;
		if (this.TsSetToPlayer)
		{
			entity = Global.BaseCharacter.CharacterActorComponent.Entity;
		}
		else if (this.TsTargetKey != "")
		{
			int? num = ControllerBase<BlackboardController>.Instance.GetIntValueByWorld(this.TsTargetKey);
			if (num == null || num.Value == 0)
			{
				num = ControllerBase<BlackboardController>.Instance.GetEntityIdByEntity(charActorComp.Entity.Id, this.TsTargetKey);
			}
			if (num != null && num.Value != 0)
			{
				entity = Singleton<EntitySystem>.Instance.Get(num.Value);
			}
			else
			{
				entity = null;
			}
		}
		if (entity == null)
		{
			base.FinishExecute(false);
			return;
		}
		if (this.TsGameplayTag != null)
		{
			this.SetGameplayTag(entity);
		}
		else
		{
			BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
			if (component != null)
			{
				TArray<FName> tags = component.Owner.Tags;
				TArray<FName> tarray = tags;
				FName value = this.TsActorTag.Value;
				int num2 = tarray.FindIndex(value);
				if (this.TsIsAdd && num2 < 0)
				{
					tags.Add(this.TsActorTag.Value);
				}
				else if (num2 > -1)
				{
					tags.RemoveAt(num2);
				}
			}
		}
		base.FinishExecute(true);
	}

	// Token: 0x06004081 RID: 16513 RVA: 0x00066A64 File Offset: 0x00064C64
	private void SetGameplayTag(Entity entity)
	{
		if (this.TsIsCommonTag)
		{
			LevelTagComponent component = entity.GetComponent<LevelTagComponent>();
			if (component != null)
			{
				int num = this.TsGameplayTag.Value.TagId();
				bool flag = component.HasTag(num);
				if (this.TsIsAdd && !flag)
				{
					component.AddTag(new int?(num));
				}
				else if (!this.TsIsAdd && flag)
				{
					component.RemoveTag(new int?(num));
				}
			}
		}
		BaseTagComponent component2 = entity.GetComponent<BaseTagComponent>();
		if (component2 != null)
		{
			int num2 = this.TsGameplayTag.Value.TagId();
			bool flag2 = component2.HasTag(num2);
			if (this.TsIsAdd && !flag2)
			{
				component2.AddTag(new int?(num2));
				return;
			}
			if (!this.TsIsAdd && flag2)
			{
				component2.RemoveTag(new int?(num2));
			}
		}
	}

	// Token: 0x06004082 RID: 16514 RVA: 0x00066B2B File Offset: 0x00064D2B
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskSetTag._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskSetTag.TsTaskSetTag_C");
		}
		return TsTaskSetTag._ClassPtr;
	}

	// Token: 0x06004083 RID: 16515 RVA: 0x00066B50 File Offset: 0x00064D50
	public TsTaskSetTag() : this(BuiltinUtils.AllocNativeUObject(TsTaskSetTag.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004084 RID: 16516 RVA: 0x00066B78 File Offset: 0x00064D78
	public TsTaskSetTag(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskSetTag.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004085 RID: 16517 RVA: 0x00066BAB File Offset: 0x00064DAB
	protected TsTaskSetTag(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004086 RID: 16518 RVA: 0x00066BC0 File Offset: 0x00064DC0
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000F07 RID: 3847
	private bool IsInitTsVariables;

	// Token: 0x04000F08 RID: 3848
	private FGameplayTag? TsGameplayTag;

	// Token: 0x04000F09 RID: 3849
	private FName? TsActorTag;

	// Token: 0x04000F0A RID: 3850
	private string TsTargetKey = "";

	// Token: 0x04000F0B RID: 3851
	private bool TsIsCommonTag;

	// Token: 0x04000F0C RID: 3852
	private bool TsIsAdd;

	// Token: 0x04000F0D RID: 3853
	private bool TsSetToPlayer;

	// Token: 0x04000F0E RID: 3854
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskSetTag.TsTaskSetTag_C";

	// Token: 0x04000F0F RID: 3855
	private static IntPtr _ClassPtr;

	// Token: 0x04000F10 RID: 3856
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000F11 RID: 3857
	private static int __PropertyOffset_GameplayTag;

	// Token: 0x04000F12 RID: 3858
	private static int __PropertyOffset_ActorTag;

	// Token: 0x04000F13 RID: 3859
	private static int __PropertyOffset_TargetKey;

	// Token: 0x04000F14 RID: 3860
	private static int __PropertyOffset_IsCommonTag;

	// Token: 0x04000F15 RID: 3861
	private static int __PropertyOffset_IsAdd;

	// Token: 0x04000F16 RID: 3862
	private static int __PropertyOffset_SetToPlayer;
}
