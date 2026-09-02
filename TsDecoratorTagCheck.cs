using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Condition.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C69 RID: 3177
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorTagCheck.TsDecoratorTagCheck_C")]
public class TsDecoratorTagCheck : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000151 RID: 337
	// (get) Token: 0x0600389F RID: 14495 RVA: 0x0003E343 File Offset: 0x0003C543
	// (set) Token: 0x060038A0 RID: 14496 RVA: 0x0003E357 File Offset: 0x0003C557
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKeyTarget
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorTagCheck.__PropertyOffset_BlackboardKeyTarget)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorTagCheck.__PropertyOffset_BlackboardKeyTarget)), value);
		}
	}

	// Token: 0x17000152 RID: 338
	// (get) Token: 0x060038A1 RID: 14497 RVA: 0x0003E36C File Offset: 0x0003C56C
	// (set) Token: 0x060038A2 RID: 14498 RVA: 0x0003E3A5 File Offset: 0x0003C5A5
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<FGameplayTag, bool> Checks
	{
		get
		{
			base.FastCheckIsValid();
			TMap<FGameplayTag, bool> result;
			if ((result = this._Checks) == null)
			{
				result = (this._Checks = new TMap<FGameplayTag, bool>(base.NativePtr + (IntPtr)TsDecoratorTagCheck.__PropertyOffset_Checks, this));
			}
			return result;
		}
		set
		{
			this.Checks.CopyAssign(value);
		}
	}

	// Token: 0x17000153 RID: 339
	// (get) Token: 0x060038A3 RID: 14499 RVA: 0x0003E3B3 File Offset: 0x0003C5B3
	// (set) Token: 0x060038A4 RID: 14500 RVA: 0x0003E3C3 File Offset: 0x0003C5C3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe SConditionGroupType Logic
	{
		get
		{
			return (SConditionGroupType)(*(base.NativePtr + (IntPtr)TsDecoratorTagCheck.__PropertyOffset_Logic));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorTagCheck.__PropertyOffset_Logic) = (byte)value;
		}
	}

	// Token: 0x17000154 RID: 340
	// (get) Token: 0x060038A5 RID: 14501 RVA: 0x0003E3D4 File Offset: 0x0003C5D4
	// (set) Token: 0x060038A6 RID: 14502 RVA: 0x0003E3E4 File Offset: 0x0003C5E4
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DebugLog
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorTagCheck.__PropertyOffset_DebugLog) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorTagCheck.__PropertyOffset_DebugLog) = (value ? 1 : 0);
		}
	}

	// Token: 0x060038A7 RID: 14503 RVA: 0x0003E3F8 File Offset: 0x0003C5F8
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsLogic = new SConditionGroupType?(this.Logic);
			this.TsBlackBoardKeyTarget = this.BlackboardKeyTarget;
			this.TsDebugLog = this.DebugLog;
			int capacity = this.Checks.Num();
			this.TsCheckTags = new List<int>(capacity);
			this.TsCheckTagValues = new List<bool>(capacity);
			foreach (KeyValuePair<FGameplayTag, bool> keyValuePair in this.Checks)
			{
				FGameplayTag fgameplayTag;
				bool flag;
				keyValuePair.Deconstruct(out fgameplayTag, out flag);
				FGameplayTag tag = fgameplayTag;
				bool item = flag;
				this.TsCheckTags.Add(tag.TagId());
				this.TsCheckTagValues.Add(item);
			}
		}
	}

	// Token: 0x060038A8 RID: 14504 RVA: 0x0003E4D4 File Offset: 0x0003C6D4
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

	// Token: 0x060038A9 RID: 14505 RVA: 0x0003E574 File Offset: 0x0003C774
	[NullableContext(2)]
	protected unsafe virtual bool PerformConditionCheckAI_Implementation(AAIController ownerController, APawn controlledPawn)
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
		if (!aiController.CharActorComp)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.BehaviorTree;
			ELogAuthor author2 = ELogAuthor.LCZ;
			string message2 = "错误的Controller类型";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Id", (ownerController as TsAiController).GetEntity().Id);
			instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		this.InitTsVariables();
		if (this.TsDebugLog)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.BehaviorTree;
			ELogAuthor author3 = ELogAuthor.LCZ;
			string message3 = "TagCheck";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("controller", (ownerController != null) ? ownerController.GetName() : null);
			instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}
		Entity entity = aiController.CharActorComp.Entity;
		if (this.TsBlackBoardKeyTarget != "")
		{
			int? entityIdByEntity = ControllerBase<BlackboardController>.Instance.GetEntityIdByEntity(entity.Id, this.TsBlackBoardKeyTarget);
			if (entityIdByEntity == null)
			{
				if (this.TsDebugLog)
				{
					Singleton<Log>.Instance.Info(ELogModule.BehaviorTree, ELogAuthor.LCZ, "TagCheck false. Blackboard1", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				return false;
			}
			entity = Singleton<EntitySystem>.Instance.Get(entityIdByEntity.Value);
			if (entity == null || !entity.Valid)
			{
				if (this.TsDebugLog)
				{
					Singleton<Log>.Instance.Info(ELogModule.BehaviorTree, ELogAuthor.LCZ, "TagCheck false. Blackboard2", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				return false;
			}
		}
		BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
		SConditionGroupType? tsLogic = this.TsLogic;
		if (tsLogic != null)
		{
			SConditionGroupType valueOrDefault = tsLogic.GetValueOrDefault();
			if (valueOrDefault != SConditionGroupType.AND && valueOrDefault == SConditionGroupType.OR)
			{
				for (int i = this.TsCheckTags.Count - 1; i >= 0; i--)
				{
					int num = this.TsCheckTags[i];
					bool flag = this.TsCheckTagValues[i];
					if (component != null && component.HasTag(num) == flag)
					{
						if (this.TsDebugLog)
						{
							Log instance4 = Singleton<Log>.Instance;
							ELogModule module4 = ELogModule.BehaviorTree;
							ELogAuthor author4 = ELogAuthor.LCZ;
							string message4 = "TagCheck true. Or";
							ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("tag", num);
							instance4.Info(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
						}
						return true;
					}
				}
				if (this.TsDebugLog)
				{
					Log instance5 = Singleton<Log>.Instance;
					ELogModule module5 = ELogModule.BehaviorTree;
					ELogAuthor author5 = ELogAuthor.LCZ;
					string message5 = "TagCheck false. Or";
					string item = "tagCount";
					List<int> tsCheckTags = this.TsCheckTags;
					ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>(item, (tsCheckTags != null) ? new int?(tsCheckTags.Count) : null);
					instance5.Info(module5, author5, message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
				}
				return false;
			}
		}
		for (int j = this.TsCheckTags.Count - 1; j >= 0; j--)
		{
			int num2 = this.TsCheckTags[j];
			bool flag2 = this.TsCheckTagValues[j];
			if (component == null || component.HasTag(num2) != flag2)
			{
				if (this.TsDebugLog)
				{
					Log instance6 = Singleton<Log>.Instance;
					ELogModule module6 = ELogModule.BehaviorTree;
					ELogAuthor author6 = ELogAuthor.LCZ;
					string message6 = "TagCheck false. And";
					ValueTuple<string, object> valueTuple5 = new ValueTuple<string, object>("tag", num2);
					instance6.Info(module6, author6, message6, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple5));
				}
				return false;
			}
		}
		if (this.TsDebugLog)
		{
			Log instance7 = Singleton<Log>.Instance;
			ELogModule module7 = ELogModule.BehaviorTree;
			ELogAuthor author7 = ELogAuthor.LCZ;
			string message7 = "TagCheck true. And";
			string item2 = "tagCount";
			List<int> tsCheckTags2 = this.TsCheckTags;
			ValueTuple<string, object> valueTuple6 = new ValueTuple<string, object>(item2, (tsCheckTags2 != null) ? new int?(tsCheckTags2.Count) : null);
			instance7.Info(module7, author7, message7, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple6));
		}
		return true;
	}

	// Token: 0x060038AA RID: 14506 RVA: 0x0003E919 File Offset: 0x0003CB19
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorTagCheck._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorTagCheck.TsDecoratorTagCheck_C");
		}
		return TsDecoratorTagCheck._ClassPtr;
	}

	// Token: 0x060038AB RID: 14507 RVA: 0x0003E940 File Offset: 0x0003CB40
	public TsDecoratorTagCheck() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorTagCheck.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060038AC RID: 14508 RVA: 0x0003E968 File Offset: 0x0003CB68
	public TsDecoratorTagCheck(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorTagCheck.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060038AD RID: 14509 RVA: 0x0003E99B File Offset: 0x0003CB9B
	protected TsDecoratorTagCheck(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060038AE RID: 14510 RVA: 0x0003E9B0 File Offset: 0x0003CBB0
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000882 RID: 2178
	private bool IsInitTsVariables;

	// Token: 0x04000883 RID: 2179
	[Nullable(2)]
	private List<int> TsCheckTags;

	// Token: 0x04000884 RID: 2180
	[Nullable(2)]
	private List<bool> TsCheckTagValues;

	// Token: 0x04000885 RID: 2181
	private SConditionGroupType? TsLogic;

	// Token: 0x04000886 RID: 2182
	private string TsBlackBoardKeyTarget = "";

	// Token: 0x04000887 RID: 2183
	private bool TsDebugLog;

	// Token: 0x04000888 RID: 2184
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorTagCheck.TsDecoratorTagCheck_C";

	// Token: 0x04000889 RID: 2185
	private static IntPtr _ClassPtr;

	// Token: 0x0400088A RID: 2186
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400088B RID: 2187
	private static int __PropertyOffset_BlackboardKeyTarget;

	// Token: 0x0400088C RID: 2188
	private static int __PropertyOffset_Checks;

	// Token: 0x0400088D RID: 2189
	[Nullable(2)]
	private TMap<FGameplayTag, bool> _Checks;

	// Token: 0x0400088E RID: 2190
	private static int __PropertyOffset_Logic;

	// Token: 0x0400088F RID: 2191
	private static int __PropertyOffset_DebugLog;
}
