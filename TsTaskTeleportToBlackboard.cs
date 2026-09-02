using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CDF RID: 3295
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskTeleportToBlackboard.TsTaskTeleportToBlackboard_C")]
public class TsTaskTeleportToBlackboard : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170002EC RID: 748
	// (get) Token: 0x060040F9 RID: 16633 RVA: 0x000696D3 File Offset: 0x000678D3
	// (set) Token: 0x060040FA RID: 16634 RVA: 0x000696E7 File Offset: 0x000678E7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskTeleportToBlackboard.__PropertyOffset_BlackboardKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskTeleportToBlackboard.__PropertyOffset_BlackboardKey)), value);
		}
	}

	// Token: 0x170002ED RID: 749
	// (get) Token: 0x060040FB RID: 16635 RVA: 0x000696FC File Offset: 0x000678FC
	// (set) Token: 0x060040FC RID: 16636 RVA: 0x00069735 File Offset: 0x00067935
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<int> TeleportEffectBuffId
	{
		get
		{
			base.FastCheckIsValid();
			TArray<int> result;
			if ((result = this._TeleportEffectBuffId) == null)
			{
				result = (this._TeleportEffectBuffId = new TArray<int>(base.NativePtr + (IntPtr)TsTaskTeleportToBlackboard.__PropertyOffset_TeleportEffectBuffId, this));
			}
			return result;
		}
		set
		{
			this.TeleportEffectBuffId.CopyAssign(value);
		}
	}

	// Token: 0x060040FD RID: 16637 RVA: 0x00069744 File Offset: 0x00067944
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsBlackboardKey = this.BlackboardKey;
			this.TsTeleportEffectBuffId = new int[this.TeleportEffectBuffId.Num()];
			int i = 0;
			int num = this.TeleportEffectBuffId.Num();
			while (i < num)
			{
				this.TsTeleportEffectBuffId[i] = this.TeleportEffectBuffId.Get(i);
				i++;
			}
			this.Target = global::Vector.Create();
		}
	}

	// Token: 0x060040FE RID: 16638 RVA: 0x000697C0 File Offset: 0x000679C0
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

	// Token: 0x060040FF RID: 16639 RVA: 0x0006985C File Offset: 0x00067A5C
	[NullableContext(2)]
	protected void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		if (aiController == null)
		{
			base.FinishExecute(false);
			return;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		int id = aiController.CharAiDesignComp.Entity.Id;
		Aki.Protocol.Vector vectorValueByEntity = ControllerBase<BlackboardController>.Instance.GetVectorValueByEntity(id, this.TsBlackboardKey);
		if (vectorValueByEntity == null)
		{
			base.Finish(false);
			return;
		}
		if (this.TsTeleportEffectBuffId != null)
		{
			Entity entity = aiController.CharAiDesignComp.Entity;
			BaseGameplayCueComponent baseGameplayCueComponent = (entity != null) ? entity.GetComponent<BaseGameplayCueComponent>() : null;
			foreach (int num in this.TsTeleportEffectBuffId)
			{
				if (baseGameplayCueComponent != null)
				{
					baseGameplayCueComponent.AddCue((long)num, new GameplayCueParam?(new GameplayCueParam
					{
						Instant = true
					}));
				}
			}
		}
		this.Target.X = (double)vectorValueByEntity.X;
		this.Target.Y = (double)vectorValueByEntity.Y;
		this.Target.Z = (double)vectorValueByEntity.Z;
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(charActorComp, this.Target, (double)charActorComp.ScaledHalfHeight);
		charActorComp.TeleportTo(this.Target.ToUeVector(false), charActorComp.ActorRotationProxy.ToUeRotator(), "交互保底传送");
		base.Finish(true);
	}

	// Token: 0x06004100 RID: 16640 RVA: 0x000699A3 File Offset: 0x00067BA3
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskTeleportToBlackboard._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskTeleportToBlackboard.TsTaskTeleportToBlackboard_C");
		}
		return TsTaskTeleportToBlackboard._ClassPtr;
	}

	// Token: 0x06004101 RID: 16641 RVA: 0x000699C8 File Offset: 0x00067BC8
	public TsTaskTeleportToBlackboard() : this(BuiltinUtils.AllocNativeUObject(TsTaskTeleportToBlackboard.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004102 RID: 16642 RVA: 0x000699F0 File Offset: 0x00067BF0
	public TsTaskTeleportToBlackboard(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskTeleportToBlackboard.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004103 RID: 16643 RVA: 0x00069A23 File Offset: 0x00067C23
	protected TsTaskTeleportToBlackboard(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004104 RID: 16644 RVA: 0x00069A38 File Offset: 0x00067C38
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000F77 RID: 3959
	private bool IsInitTsVariables;

	// Token: 0x04000F78 RID: 3960
	private string TsBlackboardKey = "";

	// Token: 0x04000F79 RID: 3961
	[Nullable(2)]
	private int[] TsTeleportEffectBuffId;

	// Token: 0x04000F7A RID: 3962
	[Nullable(2)]
	private global::Vector Target;

	// Token: 0x04000F7B RID: 3963
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskTeleportToBlackboard.TsTaskTeleportToBlackboard_C";

	// Token: 0x04000F7C RID: 3964
	private static IntPtr _ClassPtr;

	// Token: 0x04000F7D RID: 3965
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000F7E RID: 3966
	private static int __PropertyOffset_BlackboardKey;

	// Token: 0x04000F7F RID: 3967
	private static int __PropertyOffset_TeleportEffectBuffId;

	// Token: 0x04000F80 RID: 3968
	[Nullable(2)]
	private TArray<int> _TeleportEffectBuffId;
}
