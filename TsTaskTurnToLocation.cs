using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CE1 RID: 3297
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskTurnToLocation.TsTaskTurnToLocation_C")]
public class TsTaskTurnToLocation : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170002F6 RID: 758
	// (get) Token: 0x0600412B RID: 16683 RVA: 0x0006A71F File Offset: 0x0006891F
	// (set) Token: 0x0600412C RID: 16684 RVA: 0x0006A733 File Offset: 0x00068933
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string LocationKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskTurnToLocation.__PropertyOffset_LocationKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskTurnToLocation.__PropertyOffset_LocationKey)), value);
		}
	}

	// Token: 0x170002F7 RID: 759
	// (get) Token: 0x0600412D RID: 16685 RVA: 0x0006A748 File Offset: 0x00068948
	// (set) Token: 0x0600412E RID: 16686 RVA: 0x0006A75C File Offset: 0x0006895C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string DirectionKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskTurnToLocation.__PropertyOffset_DirectionKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskTurnToLocation.__PropertyOffset_DirectionKey)), value);
		}
	}

	// Token: 0x170002F8 RID: 760
	// (get) Token: 0x0600412F RID: 16687 RVA: 0x0006A771 File Offset: 0x00068971
	// (set) Token: 0x06004130 RID: 16688 RVA: 0x0006A781 File Offset: 0x00068981
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool Continuously
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskTurnToLocation.__PropertyOffset_Continuously) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskTurnToLocation.__PropertyOffset_Continuously) = (value ? 1 : 0);
		}
	}

	// Token: 0x170002F9 RID: 761
	// (get) Token: 0x06004131 RID: 16689 RVA: 0x0006A792 File Offset: 0x00068992
	// (set) Token: 0x06004132 RID: 16690 RVA: 0x0006A7A2 File Offset: 0x000689A2
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float TurnSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskTurnToLocation.__PropertyOffset_TurnSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskTurnToLocation.__PropertyOffset_TurnSpeed) = value;
		}
	}

	// Token: 0x06004133 RID: 16691 RVA: 0x0006A7B4 File Offset: 0x000689B4
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsLocationKey = this.LocationKey;
			this.TsDirectionKey = this.DirectionKey;
			this.TsTurnSpeed = this.TurnSpeed;
			this.TsContinuously = this.Continuously;
			this.TmpVector = global::Vector.Create();
			this.TmpVector2 = global::Vector.Create();
			this.TmpVector3 = global::Vector.Create();
			this.TmpRotator = global::Rotator.Create();
			this.TmpRotator2 = global::Rotator.Create();
		}
	}

	// Token: 0x06004134 RID: 16692 RVA: 0x0006A840 File Offset: 0x00068A40
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

	// Token: 0x06004135 RID: 16693 RVA: 0x0006A8E0 File Offset: 0x00068AE0
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		this.InitTsVariables();
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		if (((aiController != null) ? aiController.CharActorComp : null) == null)
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
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		if (this.TsLocationKey != "")
		{
			if (this.TsLocationKey == "_currentPlayer")
			{
				TsBaseCharacter baseCharacter = Global.BaseCharacter;
				global::Vector vector;
				if (baseCharacter == null)
				{
					vector = null;
				}
				else
				{
					CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
					vector = ((characterActorComponent != null) ? characterActorComponent.ActorLocationProxy : null);
				}
				global::Vector vector2 = vector;
				if (vector2 != null)
				{
					this.TmpVector3.DeepCopy(vector2);
				}
			}
			else
			{
				Aki.Protocol.Vector vectorValueByEntity = ControllerBase<BlackboardController>.Instance.GetVectorValueByEntity(aiController.CharAiDesignComp.Entity.Id, this.TsLocationKey);
				if (vectorValueByEntity != null)
				{
					this.TmpVector3.DeepCopy(vectorValueByEntity);
				}
			}
			if (!this.TmpVector3.IsNearlyZero(9.999999747378752E-05))
			{
				this.TmpVector3.SubtractionEqual(charActorComp.ActorLocationProxy);
			}
		}
		if (this.TsDirectionKey != "")
		{
			Aki.Protocol.Vector vectorValueByEntity2 = ControllerBase<BlackboardController>.Instance.GetVectorValueByEntity(aiController.CharAiDesignComp.Entity.Id, this.TsDirectionKey);
			if (vectorValueByEntity2 != null)
			{
				this.TmpVector3.DeepCopy(vectorValueByEntity2);
			}
		}
		this.TmpVector2.DeepCopy(charActorComp.ActorGravityDirectProxy);
		this.TmpVector2.UnaryNegation(this.TmpVector2);
		global::Vector.VectorPlaneProject(this.TmpVector3, this.TmpVector2, this.TmpVector);
		if (this.TmpVector.IsNearlyZero(9.999999747378752E-05))
		{
			base.FinishExecute(true);
			return;
		}
		this.TmpVector.Normalize(9.99999993922529E-09);
		Singleton<MathUtils>.Instance.LookRotationForwardFirst(this.TmpVector, this.TmpVector2, this.TmpRotator);
		if (this.TsContinuously)
		{
			Singleton<MathUtils>.Instance.RotatorInterpConstantTo(charActorComp.ActorRotationProxy, this.TmpRotator, deltaSeconds, this.TsTurnSpeed, this.TmpRotator2);
			charActorComp.SetActorRotation(this.TmpRotator2.ToUeRotator(), "TsTaskTurnToLocation", false);
			if (charActorComp.ActorRotationProxy.Equals2(this.TmpRotator, 0.0001f))
			{
				base.FinishExecute(true);
			}
			return;
		}
		charActorComp.SetActorRotation(this.TmpRotator.ToUeRotator(), "TsTaskTurnToLocation", false);
		base.FinishExecute(true);
	}

	// Token: 0x06004136 RID: 16694 RVA: 0x0006AB59 File Offset: 0x00068D59
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskTurnToLocation._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskTurnToLocation.TsTaskTurnToLocation_C");
		}
		return TsTaskTurnToLocation._ClassPtr;
	}

	// Token: 0x06004137 RID: 16695 RVA: 0x0006AB80 File Offset: 0x00068D80
	public TsTaskTurnToLocation() : this(BuiltinUtils.AllocNativeUObject(TsTaskTurnToLocation.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004138 RID: 16696 RVA: 0x0006ABA8 File Offset: 0x00068DA8
	public TsTaskTurnToLocation(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskTurnToLocation.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004139 RID: 16697 RVA: 0x0006ABDB File Offset: 0x00068DDB
	protected TsTaskTurnToLocation(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600413A RID: 16698 RVA: 0x0006ABFC File Offset: 0x00068DFC
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000FA2 RID: 4002
	private const string CURRENT_PLAYER = "_currentPlayer";

	// Token: 0x04000FA3 RID: 4003
	private bool IsInitTsVariables;

	// Token: 0x04000FA4 RID: 4004
	private string TsLocationKey = "";

	// Token: 0x04000FA5 RID: 4005
	private string TsDirectionKey = "";

	// Token: 0x04000FA6 RID: 4006
	private float TsTurnSpeed;

	// Token: 0x04000FA7 RID: 4007
	public bool TsContinuously;

	// Token: 0x04000FA8 RID: 4008
	[Nullable(2)]
	public global::Vector TmpVector;

	// Token: 0x04000FA9 RID: 4009
	[Nullable(2)]
	public global::Vector TmpVector2;

	// Token: 0x04000FAA RID: 4010
	[Nullable(2)]
	public global::Vector TmpVector3;

	// Token: 0x04000FAB RID: 4011
	[Nullable(2)]
	public global::Rotator TmpRotator;

	// Token: 0x04000FAC RID: 4012
	[Nullable(2)]
	public global::Rotator TmpRotator2;

	// Token: 0x04000FAD RID: 4013
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskTurnToLocation.TsTaskTurnToLocation_C";

	// Token: 0x04000FAE RID: 4014
	private static IntPtr _ClassPtr;

	// Token: 0x04000FAF RID: 4015
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000FB0 RID: 4016
	private static int __PropertyOffset_LocationKey;

	// Token: 0x04000FB1 RID: 4017
	private static int __PropertyOffset_DirectionKey;

	// Token: 0x04000FB2 RID: 4018
	private static int __PropertyOffset_Continuously;

	// Token: 0x04000FB3 RID: 4019
	private static int __PropertyOffset_TurnSpeed;
}
