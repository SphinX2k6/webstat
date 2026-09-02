using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Condition.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C5C RID: 3164
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorGeCheck.TsDecoratorGeCheck_C")]
public class TsDecoratorGeCheck : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700013F RID: 319
	// (get) Token: 0x06003816 RID: 14358 RVA: 0x0003C26B File Offset: 0x0003A46B
	// (set) Token: 0x06003817 RID: 14359 RVA: 0x0003C27F File Offset: 0x0003A47F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKeyTarget
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorGeCheck.__PropertyOffset_BlackboardKeyTarget)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorGeCheck.__PropertyOffset_BlackboardKeyTarget)), value);
		}
	}

	// Token: 0x17000140 RID: 320
	// (get) Token: 0x06003818 RID: 14360 RVA: 0x0003C294 File Offset: 0x0003A494
	// (set) Token: 0x06003819 RID: 14361 RVA: 0x0003C2CD File Offset: 0x0003A4CD
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<long, bool> Checks
	{
		get
		{
			base.FastCheckIsValid();
			TMap<long, bool> result;
			if ((result = this._Checks) == null)
			{
				result = (this._Checks = new TMap<long, bool>(base.NativePtr + (IntPtr)TsDecoratorGeCheck.__PropertyOffset_Checks, this));
			}
			return result;
		}
		set
		{
			this.Checks.CopyAssign(value);
		}
	}

	// Token: 0x17000141 RID: 321
	// (get) Token: 0x0600381A RID: 14362 RVA: 0x0003C2DB File Offset: 0x0003A4DB
	// (set) Token: 0x0600381B RID: 14363 RVA: 0x0003C2EB File Offset: 0x0003A4EB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe SConditionGroupType Logic
	{
		get
		{
			return (SConditionGroupType)(*(base.NativePtr + (IntPtr)TsDecoratorGeCheck.__PropertyOffset_Logic));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorGeCheck.__PropertyOffset_Logic) = (byte)value;
		}
	}

	// Token: 0x0600381C RID: 14364 RVA: 0x0003C2FC File Offset: 0x0003A4FC
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsBlackboardKeyTarget = this.BlackboardKeyTarget;
			int num = this.Checks.Num();
			this.TsChecks = new Dictionary<long, bool>(num);
			if (num > 0)
			{
				foreach (KeyValuePair<long, bool> keyValuePair in this.Checks)
				{
					long num2;
					bool flag;
					keyValuePair.Deconstruct(out num2, out flag);
					long key = num2;
					bool value = flag;
					this.TsChecks.Add(key, value);
				}
			}
			this.TsLogic = new SConditionGroupType?(this.Logic);
		}
	}

	// Token: 0x0600381D RID: 14365 RVA: 0x0003C3B4 File Offset: 0x0003A5B4
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool PerformConditionCheckAI(AAIController ownerController, APawn controlledPawn)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("PerformConditionCheckAI"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams*)ptr + 15L / (long)sizeof(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->OwnerController) = ((ownerController != null) ? ownerController.NativePtr : ((IntPtr)0));
			*(&ptr2->ControlledPawn) = ((controlledPawn != null) ? controlledPawn.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0600381E RID: 14366 RVA: 0x0003C454 File Offset: 0x0003A654
	[NullableContext(2)]
	protected virtual bool PerformConditionCheckAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		AiController aiController = (ownerController as TsAiController).AiController;
		if (aiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		this.InitTsVariables();
		CharacterActorComponent characterActorComponent = aiController.CharActorComp;
		if (this.TsBlackboardKeyTarget != "")
		{
			int? entityIdByEntity = ControllerBase<BlackboardController>.Instance.GetEntityIdByEntity(aiController.CharAiDesignComp.Entity.Id, this.TsBlackboardKeyTarget);
			if (entityIdByEntity == null)
			{
				return false;
			}
			CharacterActorComponent characterActorComponentById = ControllerBase<CharacterController>.Instance.GetCharacterActorComponentById(entityIdByEntity.Value);
			if (characterActorComponentById == null)
			{
				return false;
			}
			characterActorComponent = characterActorComponentById;
		}
		CharacterBuffComponent characterBuffComponent = characterActorComponent.Entity.CheckGetComponent<CharacterBuffComponent>();
		if (characterBuffComponent == null)
		{
			return false;
		}
		SConditionGroupType? tsLogic = this.TsLogic;
		if (tsLogic != null)
		{
			SConditionGroupType valueOrDefault = tsLogic.GetValueOrDefault();
			if (valueOrDefault != SConditionGroupType.AND && valueOrDefault == SConditionGroupType.OR)
			{
				foreach (KeyValuePair<long, bool> keyValuePair in this.TsChecks)
				{
					long num;
					bool flag;
					keyValuePair.Deconstruct(out num, out flag);
					long buffId = num;
					bool flag2 = flag;
					if (characterBuffComponent.GetBuffTotalStackById(buffId, false) > 0 == flag2)
					{
						return true;
					}
				}
				return false;
			}
		}
		foreach (KeyValuePair<long, bool> keyValuePair in this.Checks)
		{
			long num;
			bool flag3;
			keyValuePair.Deconstruct(out num, out flag3);
			long buffId2 = num;
			bool flag4 = flag3;
			if (characterBuffComponent.GetBuffTotalStackById(buffId2, false) > 0 != flag4)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0600381F RID: 14367 RVA: 0x0003C618 File Offset: 0x0003A818
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorGeCheck._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorGeCheck.TsDecoratorGeCheck_C");
		}
		return TsDecoratorGeCheck._ClassPtr;
	}

	// Token: 0x06003820 RID: 14368 RVA: 0x0003C63C File Offset: 0x0003A83C
	public TsDecoratorGeCheck() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorGeCheck.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003821 RID: 14369 RVA: 0x0003C664 File Offset: 0x0003A864
	public TsDecoratorGeCheck(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorGeCheck.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003822 RID: 14370 RVA: 0x0003C697 File Offset: 0x0003A897
	protected TsDecoratorGeCheck(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003823 RID: 14371 RVA: 0x0003C6AC File Offset: 0x0003A8AC
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0400082D RID: 2093
	private bool IsInitTsVariables;

	// Token: 0x0400082E RID: 2094
	private string TsBlackboardKeyTarget = "";

	// Token: 0x0400082F RID: 2095
	private Dictionary<long, bool> TsChecks;

	// Token: 0x04000830 RID: 2096
	private SConditionGroupType? TsLogic;

	// Token: 0x04000831 RID: 2097
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorGeCheck.TsDecoratorGeCheck_C";

	// Token: 0x04000832 RID: 2098
	private static IntPtr _ClassPtr;

	// Token: 0x04000833 RID: 2099
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000834 RID: 2100
	private static int __PropertyOffset_BlackboardKeyTarget;

	// Token: 0x04000835 RID: 2101
	private static int __PropertyOffset_Checks;

	// Token: 0x04000836 RID: 2102
	[Nullable(2)]
	private TMap<long, bool> _Checks;

	// Token: 0x04000837 RID: 2103
	private static int __PropertyOffset_Logic;
}
