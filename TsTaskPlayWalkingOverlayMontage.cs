using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Character.Npc.Logics;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CCA RID: 3274
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskPlayWalkingOverlayMontage.TsTaskPlayWalkingOverlayMontage_C")]
public class TsTaskPlayWalkingOverlayMontage : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170002A2 RID: 674
	// (get) Token: 0x06003FA7 RID: 16295 RVA: 0x000631C7 File Offset: 0x000613C7
	// (set) Token: 0x06003FA8 RID: 16296 RVA: 0x000631D7 File Offset: 0x000613D7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MontageId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPlayWalkingOverlayMontage.__PropertyOffset_MontageId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPlayWalkingOverlayMontage.__PropertyOffset_MontageId) = value;
		}
	}

	// Token: 0x170002A3 RID: 675
	// (get) Token: 0x06003FA9 RID: 16297 RVA: 0x000631E8 File Offset: 0x000613E8
	// (set) Token: 0x06003FAA RID: 16298 RVA: 0x000631F8 File Offset: 0x000613F8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float LoopDuration
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPlayWalkingOverlayMontage.__PropertyOffset_LoopDuration);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPlayWalkingOverlayMontage.__PropertyOffset_LoopDuration) = value;
		}
	}

	// Token: 0x170002A4 RID: 676
	// (get) Token: 0x06003FAB RID: 16299 RVA: 0x00063209 File Offset: 0x00061409
	// (set) Token: 0x06003FAC RID: 16300 RVA: 0x00063219 File Offset: 0x00061419
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int RepeatTimes
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPlayWalkingOverlayMontage.__PropertyOffset_RepeatTimes);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPlayWalkingOverlayMontage.__PropertyOffset_RepeatTimes) = value;
		}
	}

	// Token: 0x06003FAD RID: 16301 RVA: 0x0006322A File Offset: 0x0006142A
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsMontageId = (int)this.MontageId;
			this.TsLoopDuration = this.LoopDuration;
			this.TsRepeatTimes = this.RepeatTimes;
		}
	}

	// Token: 0x06003FAE RID: 16302 RVA: 0x00063268 File Offset: 0x00061468
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

	// Token: 0x06003FAF RID: 16303 RVA: 0x00063304 File Offset: 0x00061504
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
			ELogAuthor author = ELogAuthor.CJH;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(true);
			return;
		}
		Entity entity = aiController.CharActorComp.Entity;
		this.AnimComp = ((entity != null) ? entity.GetComponent<CharacterAnimationComponent>() : null);
		if (this.AnimComp == null)
		{
			base.FinishExecute(true);
			return;
		}
		PlayMontageConfig config = new PlayMontageConfig(this.TsRepeatTimes, (double)this.TsLoopDuration, false, false);
		if (this.PlayingMontageId != 0)
		{
			Singleton<PlayMontageUtils>.Instance.ClearAndEndMontage(this.PlayingMontageId, true, null);
		}
		this.PlayingMontageId = Singleton<PlayMontageUtils>.Instance.LoadAndPlayMontageByOverlapId(this.AnimComp, this.TsMontageId, config, null, null, null);
		base.FinishExecute(true);
	}

	// Token: 0x06003FB0 RID: 16304 RVA: 0x000633EC File Offset: 0x000615EC
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskPlayWalkingOverlayMontage._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskPlayWalkingOverlayMontage.TsTaskPlayWalkingOverlayMontage_C");
		}
		return TsTaskPlayWalkingOverlayMontage._ClassPtr;
	}

	// Token: 0x06003FB1 RID: 16305 RVA: 0x00063410 File Offset: 0x00061610
	public TsTaskPlayWalkingOverlayMontage() : this(BuiltinUtils.AllocNativeUObject(TsTaskPlayWalkingOverlayMontage.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003FB2 RID: 16306 RVA: 0x00063438 File Offset: 0x00061638
	[NullableContext(1)]
	public TsTaskPlayWalkingOverlayMontage(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskPlayWalkingOverlayMontage.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003FB3 RID: 16307 RVA: 0x0006346B File Offset: 0x0006166B
	protected TsTaskPlayWalkingOverlayMontage(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003FB4 RID: 16308 RVA: 0x00063474 File Offset: 0x00061674
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000E54 RID: 3668
	private bool IsInitTsVariables;

	// Token: 0x04000E55 RID: 3669
	private int TsMontageId;

	// Token: 0x04000E56 RID: 3670
	private float TsLoopDuration;

	// Token: 0x04000E57 RID: 3671
	private int TsRepeatTimes;

	// Token: 0x04000E58 RID: 3672
	[Nullable(2)]
	private CharacterAnimationComponent AnimComp;

	// Token: 0x04000E59 RID: 3673
	private int PlayingMontageId;

	// Token: 0x04000E5A RID: 3674
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskPlayWalkingOverlayMontage.TsTaskPlayWalkingOverlayMontage_C";

	// Token: 0x04000E5B RID: 3675
	private static IntPtr _ClassPtr;

	// Token: 0x04000E5C RID: 3676
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000E5D RID: 3677
	private static int __PropertyOffset_MontageId;

	// Token: 0x04000E5E RID: 3678
	private static int __PropertyOffset_LoopDuration;

	// Token: 0x04000E5F RID: 3679
	private static int __PropertyOffset_RepeatTimes;
}
