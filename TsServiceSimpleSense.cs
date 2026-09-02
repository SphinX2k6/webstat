using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C70 RID: 3184
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Service/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Service/TsServiceSimpleSense.TsServiceSimpleSense_C")]
public class TsServiceSimpleSense : UBTService_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700015B RID: 347
	// (get) Token: 0x060038ED RID: 14573 RVA: 0x0003FD23 File Offset: 0x0003DF23
	// (set) Token: 0x060038EE RID: 14574 RVA: 0x0003FD37 File Offset: 0x0003DF37
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FFloatRange SenseRadius
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsServiceSimpleSense.__PropertyOffset_SenseRadius);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsServiceSimpleSense.__PropertyOffset_SenseRadius) = value;
		}
	}

	// Token: 0x060038EF RID: 14575 RVA: 0x0003FD4C File Offset: 0x0003DF4C
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveTickAI(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveTickAI"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UBTService_BlueprintBase.__ReceiveTickAI_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UBTService_BlueprintBase.__ReceiveTickAI_FunctionParams*)ptr + 15L / (long)sizeof(UBTService_BlueprintBase.__ReceiveTickAI_FunctionParams) & -16L);
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

	// Token: 0x060038F0 RID: 14576 RVA: 0x0003FDEC File Offset: 0x0003DFEC
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		if (!(ownerController is TsAiController))
		{
			return;
		}
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		if (baseCharacter == null)
		{
			return;
		}
		AiController aiController = (ownerController as TsAiController).AiController;
		if (aiController == null)
		{
			return;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		if (charActorComp == null)
		{
			return;
		}
		Entity entity = charActorComp.Entity;
		PawnSensoryInfoComponent component = entity.GetComponent<PawnSensoryInfoComponent>();
		if (component == null)
		{
			return;
		}
		if (!this.IsInit)
		{
			this.IsInit = true;
			float value = this.SenseRadius.LowerBound.Value;
			float value2 = this.SenseRadius.UpperBound.Value;
			this.MinRangeSquared = (double)(value * value);
			this.MaxRangeSquared = (double)(value2 * value2);
			component.SetLogicRange(value2);
		}
		double playerDistSquared = component.PlayerDistSquared;
		int num;
		if (playerDistSquared > this.MaxRangeSquared)
		{
			num = 0;
			if (this.IsEnter)
			{
				this.IsEnter = false;
			}
		}
		else if (playerDistSquared > this.MinRangeSquared)
		{
			if (this.IsEnter)
			{
				num = baseCharacter.CharacterActorComponent.Entity.Id;
			}
			else
			{
				num = 0;
			}
		}
		else
		{
			num = baseCharacter.CharacterActorComponent.Entity.Id;
			if (!this.IsEnter)
			{
				this.IsEnter = true;
			}
		}
		if (num == 0)
		{
			if (this.IsSetNearerPlayerId)
			{
				this.IsSetNearerPlayerId = false;
				ControllerBase<BlackboardController>.Instance.RemoveValueByEntity(entity.Id, ENpcBlackBoardKeys.NearerPlayerId.ToString());
			}
		}
		else
		{
			ControllerBase<BlackboardController>.Instance.SetEntityIdByEntity(entity.Id, ENpcBlackBoardKeys.NearerPlayerId.ToString(), num);
			this.IsSetNearerPlayerId = true;
		}
		ControllerBase<BlackboardController>.Instance.SetIntValueByEntity(entity.Id, "NearerPlayerIntId", num);
	}

	// Token: 0x060038F1 RID: 14577 RVA: 0x0003FF7A File Offset: 0x0003E17A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsServiceSimpleSense._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Service/TsServiceSimpleSense.TsServiceSimpleSense_C");
		}
		return TsServiceSimpleSense._ClassPtr;
	}

	// Token: 0x060038F2 RID: 14578 RVA: 0x0003FFA0 File Offset: 0x0003E1A0
	public TsServiceSimpleSense() : this(BuiltinUtils.AllocNativeUObject(TsServiceSimpleSense.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060038F3 RID: 14579 RVA: 0x0003FFC8 File Offset: 0x0003E1C8
	[NullableContext(1)]
	public TsServiceSimpleSense(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsServiceSimpleSense.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060038F4 RID: 14580 RVA: 0x0003FFFB File Offset: 0x0003E1FB
	protected TsServiceSimpleSense(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060038F5 RID: 14581 RVA: 0x00040004 File Offset: 0x0003E204
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTService_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x040008B5 RID: 2229
	[Nullable(1)]
	private const string NRARER_PLAYER_INT_ID = "NearerPlayerIntId";

	// Token: 0x040008B6 RID: 2230
	private bool IsEnter;

	// Token: 0x040008B7 RID: 2231
	private bool IsInit;

	// Token: 0x040008B8 RID: 2232
	private double MinRangeSquared;

	// Token: 0x040008B9 RID: 2233
	private double MaxRangeSquared;

	// Token: 0x040008BA RID: 2234
	private bool IsSetNearerPlayerId;

	// Token: 0x040008BB RID: 2235
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Service/TsServiceSimpleSense.TsServiceSimpleSense_C";

	// Token: 0x040008BC RID: 2236
	private static IntPtr _ClassPtr;

	// Token: 0x040008BD RID: 2237
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040008BE RID: 2238
	private static int __PropertyOffset_SenseRadius;
}
