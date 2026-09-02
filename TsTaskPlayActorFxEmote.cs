using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.ActorFxEmote;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CC6 RID: 3270
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskPlayActorFxEmote.TsTaskPlayActorFxEmote_C")]
public class TsTaskPlayActorFxEmote : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000288 RID: 648
	// (get) Token: 0x06003F3C RID: 16188 RVA: 0x000617CF File Offset: 0x0005F9CF
	// (set) Token: 0x06003F3D RID: 16189 RVA: 0x000617DF File Offset: 0x0005F9DF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe long EffectBuffId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPlayActorFxEmote.__PropertyOffset_EffectBuffId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPlayActorFxEmote.__PropertyOffset_EffectBuffId) = value;
		}
	}

	// Token: 0x17000289 RID: 649
	// (get) Token: 0x06003F3E RID: 16190 RVA: 0x000617F0 File Offset: 0x0005F9F0
	// (set) Token: 0x06003F3F RID: 16191 RVA: 0x00061804 File Offset: 0x0005FA04
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string SocketName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskPlayActorFxEmote.__PropertyOffset_SocketName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskPlayActorFxEmote.__PropertyOffset_SocketName)), value);
		}
	}

	// Token: 0x1700028A RID: 650
	// (get) Token: 0x06003F40 RID: 16192 RVA: 0x00061819 File Offset: 0x0005FA19
	// (set) Token: 0x06003F41 RID: 16193 RVA: 0x0006182D File Offset: 0x0005FA2D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector RelativePosition
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPlayActorFxEmote.__PropertyOffset_RelativePosition);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPlayActorFxEmote.__PropertyOffset_RelativePosition) = value;
		}
	}

	// Token: 0x1700028B RID: 651
	// (get) Token: 0x06003F42 RID: 16194 RVA: 0x00061842 File Offset: 0x0005FA42
	// (set) Token: 0x06003F43 RID: 16195 RVA: 0x00061856 File Offset: 0x0005FA56
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FRotator RelativeRotation
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPlayActorFxEmote.__PropertyOffset_RelativeRotation);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPlayActorFxEmote.__PropertyOffset_RelativeRotation) = value;
		}
	}

	// Token: 0x1700028C RID: 652
	// (get) Token: 0x06003F44 RID: 16196 RVA: 0x0006186B File Offset: 0x0005FA6B
	// (set) Token: 0x06003F45 RID: 16197 RVA: 0x0006187F File Offset: 0x0005FA7F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector Scale
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPlayActorFxEmote.__PropertyOffset_Scale);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPlayActorFxEmote.__PropertyOffset_Scale) = value;
		}
	}

	// Token: 0x1700028D RID: 653
	// (get) Token: 0x06003F46 RID: 16198 RVA: 0x00061894 File Offset: 0x0005FA94
	// (set) Token: 0x06003F47 RID: 16199 RVA: 0x000618A8 File Offset: 0x0005FAA8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string TsSocketName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskPlayActorFxEmote.__PropertyOffset_TsSocketName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskPlayActorFxEmote.__PropertyOffset_TsSocketName)), value);
		}
	}

	// Token: 0x06003F48 RID: 16200 RVA: 0x000618C0 File Offset: 0x0005FAC0
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsEffectBuffId = this.EffectBuffId;
			this.TsSocketName = this.SocketName;
			Vector tsRelativePosition = this.TsRelativePosition;
			FVector fvector = this.RelativePosition;
			tsRelativePosition.FromUeVector(fvector);
			Rotator tsRelativeRotation = this.TsRelativeRotation;
			FRotator relativeRotation = this.RelativeRotation;
			tsRelativeRotation.FromUeRotator(relativeRotation);
			Vector tsScale = this.TsScale;
			fvector = this.Scale;
			tsScale.FromUeVector(fvector);
			if (this.TsScale.IsZero())
			{
				this.TsScale.Set(1.0, 1.0, 1.0);
				Singleton<Log>.Instance.Info(ELogModule.BehaviorTree, ELogAuthor.ZJL, "[TsTaskPlayActorFxEmote] Scale为零，兜底为单位缩放", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}
	}

	// Token: 0x06003F49 RID: 16201 RVA: 0x0006198C File Offset: 0x0005FB8C
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

	// Token: 0x06003F4A RID: 16202 RVA: 0x00061A28 File Offset: 0x0005FC28
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		if (aiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "[TsTaskPlayActorFxEmote] 错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(false);
			return;
		}
		if (this.TsEffectBuffId == 0L)
		{
			Singleton<Log>.Instance.Error(ELogModule.BehaviorTree, ELogAuthor.ZJL, "[TsTaskPlayActorFxEmote] 未配置EffectBuffId", default(ReadOnlySpan<ValueTuple<string, object>>));
			base.FinishExecute(false);
			return;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		if (charActorComp == null)
		{
			base.FinishExecute(false);
			return;
		}
		int id = charActorComp.Entity.Id;
		ControllerBase<ActorFxEmoteController>.Instance.Play(id, this.TsEffectBuffId, this.TsSocketName, this.TsRelativePosition, this.TsRelativeRotation, this.TsScale);
		base.FinishExecute(true);
	}

	// Token: 0x06003F4B RID: 16203 RVA: 0x00061B0A File Offset: 0x0005FD0A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskPlayActorFxEmote._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskPlayActorFxEmote.TsTaskPlayActorFxEmote_C");
		}
		return TsTaskPlayActorFxEmote._ClassPtr;
	}

	// Token: 0x06003F4C RID: 16204 RVA: 0x00061B30 File Offset: 0x0005FD30
	public TsTaskPlayActorFxEmote() : this(BuiltinUtils.AllocNativeUObject(TsTaskPlayActorFxEmote.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003F4D RID: 16205 RVA: 0x00061B58 File Offset: 0x0005FD58
	public TsTaskPlayActorFxEmote(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskPlayActorFxEmote.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003F4E RID: 16206 RVA: 0x00061B8C File Offset: 0x0005FD8C
	protected TsTaskPlayActorFxEmote(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003F4F RID: 16207 RVA: 0x00061BDC File Offset: 0x0005FDDC
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000E02 RID: 3586
	private bool IsInitTsVariables;

	// Token: 0x04000E03 RID: 3587
	private long TsEffectBuffId;

	// Token: 0x04000E04 RID: 3588
	private readonly Vector TsRelativePosition = Vector.Create();

	// Token: 0x04000E05 RID: 3589
	private readonly Rotator TsRelativeRotation = Rotator.Create();

	// Token: 0x04000E06 RID: 3590
	private readonly Vector TsScale = Vector.Create(1.0, 1.0, 1.0);

	// Token: 0x04000E07 RID: 3591
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskPlayActorFxEmote.TsTaskPlayActorFxEmote_C";

	// Token: 0x04000E08 RID: 3592
	private static IntPtr _ClassPtr;

	// Token: 0x04000E09 RID: 3593
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000E0A RID: 3594
	private static int __PropertyOffset_EffectBuffId;

	// Token: 0x04000E0B RID: 3595
	private static int __PropertyOffset_SocketName;

	// Token: 0x04000E0C RID: 3596
	private static int __PropertyOffset_RelativePosition;

	// Token: 0x04000E0D RID: 3597
	private static int __PropertyOffset_RelativeRotation;

	// Token: 0x04000E0E RID: 3598
	private static int __PropertyOffset_Scale;

	// Token: 0x04000E0F RID: 3599
	private static int __PropertyOffset_TsSocketName;
}
