using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C3B RID: 3131
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/TsDecoratorDistanceCheck.TsDecoratorDistanceCheck_C")]
public class TsDecoratorDistanceCheck : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170000F9 RID: 249
	// (get) Token: 0x06003672 RID: 13938 RVA: 0x000358F3 File Offset: 0x00033AF3
	// (set) Token: 0x06003673 RID: 13939 RVA: 0x00035907 File Offset: 0x00033B07
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe TEnumAsByte<EArithmeticKeyOperation> CheckType
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorDistanceCheck.__PropertyOffset_CheckType);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorDistanceCheck.__PropertyOffset_CheckType) = value;
		}
	}

	// Token: 0x170000FA RID: 250
	// (get) Token: 0x06003674 RID: 13940 RVA: 0x0003591C File Offset: 0x00033B1C
	// (set) Token: 0x06003675 RID: 13941 RVA: 0x0003592C File Offset: 0x00033B2C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int SourcePbDataId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorDistanceCheck.__PropertyOffset_SourcePbDataId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorDistanceCheck.__PropertyOffset_SourcePbDataId) = value;
		}
	}

	// Token: 0x170000FB RID: 251
	// (get) Token: 0x06003676 RID: 13942 RVA: 0x0003593D File Offset: 0x00033B3D
	// (set) Token: 0x06003677 RID: 13943 RVA: 0x0003594D File Offset: 0x00033B4D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int TargetPbDataId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorDistanceCheck.__PropertyOffset_TargetPbDataId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorDistanceCheck.__PropertyOffset_TargetPbDataId) = value;
		}
	}

	// Token: 0x170000FC RID: 252
	// (get) Token: 0x06003678 RID: 13944 RVA: 0x0003595E File Offset: 0x00033B5E
	// (set) Token: 0x06003679 RID: 13945 RVA: 0x0003596E File Offset: 0x00033B6E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Distance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorDistanceCheck.__PropertyOffset_Distance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorDistanceCheck.__PropertyOffset_Distance) = value;
		}
	}

	// Token: 0x170000FD RID: 253
	// (get) Token: 0x0600367A RID: 13946 RVA: 0x0003597F File Offset: 0x00033B7F
	// (set) Token: 0x0600367B RID: 13947 RVA: 0x0003598F File Offset: 0x00033B8F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IgnoreZ
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorDistanceCheck.__PropertyOffset_IgnoreZ) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorDistanceCheck.__PropertyOffset_IgnoreZ) = (value ? 1 : 0);
		}
	}

	// Token: 0x170000FE RID: 254
	// (get) Token: 0x0600367C RID: 13948 RVA: 0x000359A0 File Offset: 0x00033BA0
	// (set) Token: 0x0600367D RID: 13949 RVA: 0x000359B0 File Offset: 0x00033BB0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Tolerance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorDistanceCheck.__PropertyOffset_Tolerance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorDistanceCheck.__PropertyOffset_Tolerance) = value;
		}
	}

	// Token: 0x0600367E RID: 13950 RVA: 0x000359C4 File Offset: 0x00033BC4
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsCheckType = this.CheckType;
			this.TsSourcePbDataId = this.SourcePbDataId;
			this.TsTargetPbDataId = this.TargetPbDataId;
			this.TsDistance = this.Distance;
			this.TsIgnoreZ = this.IgnoreZ;
			this.TsTolerance = this.Tolerance;
		}
	}

	// Token: 0x0600367F RID: 13951 RVA: 0x00035A34 File Offset: 0x00033C34
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

	// Token: 0x06003680 RID: 13952 RVA: 0x00035AD4 File Offset: 0x00033CD4
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
		BaseActorComponent actorCompByConfig = this.GetActorCompByConfig(this.TsSourcePbDataId, aiController);
		BaseActorComponent actorCompByConfig2 = this.GetActorCompByConfig(this.TsTargetPbDataId, aiController);
		if (!actorCompByConfig || !actorCompByConfig2)
		{
			return false;
		}
		double num = this.NeedBias ? ((double)this.TsTolerance) : 0.0001;
		double num2 = this.TsIgnoreZ ? Vector.Dist2D(actorCompByConfig.ActorLocationProxy, actorCompByConfig2.ActorLocationProxy) : Vector.Dist(actorCompByConfig.ActorLocationProxy, actorCompByConfig2.ActorLocationProxy);
		bool flag = false;
		switch (this.TsCheckType)
		{
		case EArithmeticKeyOperation.Equal:
			flag = (Math.Abs((double)this.TsDistance - num2) <= num);
			break;
		case EArithmeticKeyOperation.NotEqual:
			flag = (Math.Abs((double)this.TsDistance - num2) > num);
			break;
		case EArithmeticKeyOperation.Less:
			flag = (num2 < (double)this.TsDistance + num);
			break;
		case EArithmeticKeyOperation.LessOrEqual:
			flag = (num2 <= (double)this.TsDistance + num);
			break;
		case EArithmeticKeyOperation.Greater:
			flag = (num2 > (double)this.TsDistance - num);
			break;
		case EArithmeticKeyOperation.GreaterOrEqual:
			flag = (num2 >= (double)this.TsDistance - num);
			break;
		}
		this.NeedBias = flag;
		return flag;
	}

	// Token: 0x06003681 RID: 13953 RVA: 0x00035C50 File Offset: 0x00033E50
	[NullableContext(1)]
	[return: Nullable(2)]
	private BaseActorComponent GetActorCompByConfig(int configId, AiController aiController)
	{
		switch (configId)
		{
		case -2:
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter == null)
			{
				return null;
			}
			return baseCharacter.CharacterActorComponent;
		}
		case -1:
			if (aiController == null)
			{
				return null;
			}
			return aiController.CharActorComp;
		case 0:
			return null;
		default:
		{
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(this.TsTargetPbDataId);
			WorldEntity worldEntity = (entityByPbDataId != null) ? entityByPbDataId.Entity : null;
			if (worldEntity == null)
			{
				return null;
			}
			return worldEntity.GetComponent<BaseActorComponent>();
		}
		}
	}

	// Token: 0x06003682 RID: 13954 RVA: 0x00035CBA File Offset: 0x00033EBA
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorDistanceCheck._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/TsDecoratorDistanceCheck.TsDecoratorDistanceCheck_C");
		}
		return TsDecoratorDistanceCheck._ClassPtr;
	}

	// Token: 0x06003683 RID: 13955 RVA: 0x00035CE0 File Offset: 0x00033EE0
	public TsDecoratorDistanceCheck() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorDistanceCheck.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003684 RID: 13956 RVA: 0x00035D08 File Offset: 0x00033F08
	[NullableContext(1)]
	public TsDecoratorDistanceCheck(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorDistanceCheck.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003685 RID: 13957 RVA: 0x00035D3B File Offset: 0x00033F3B
	protected TsDecoratorDistanceCheck(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003686 RID: 13958 RVA: 0x00035D50 File Offset: 0x00033F50
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0400070C RID: 1804
	private const int SELF_TOKEN_ID = -1;

	// Token: 0x0400070D RID: 1805
	private const int PLAYER_TOKEN_ID = -2;

	// Token: 0x0400070E RID: 1806
	private const int DEFAULT_TOLERANCE = 20;

	// Token: 0x0400070F RID: 1807
	private bool IsInitTsVariables;

	// Token: 0x04000710 RID: 1808
	private EArithmeticKeyOperation TsCheckType;

	// Token: 0x04000711 RID: 1809
	private int TsSourcePbDataId;

	// Token: 0x04000712 RID: 1810
	private int TsTargetPbDataId;

	// Token: 0x04000713 RID: 1811
	private float TsDistance;

	// Token: 0x04000714 RID: 1812
	private bool TsIgnoreZ;

	// Token: 0x04000715 RID: 1813
	private float TsTolerance = 20f;

	// Token: 0x04000716 RID: 1814
	private bool NeedBias;

	// Token: 0x04000717 RID: 1815
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/TsDecoratorDistanceCheck.TsDecoratorDistanceCheck_C";

	// Token: 0x04000718 RID: 1816
	private static IntPtr _ClassPtr;

	// Token: 0x04000719 RID: 1817
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400071A RID: 1818
	private static int __PropertyOffset_CheckType;

	// Token: 0x0400071B RID: 1819
	private static int __PropertyOffset_SourcePbDataId;

	// Token: 0x0400071C RID: 1820
	private static int __PropertyOffset_TargetPbDataId;

	// Token: 0x0400071D RID: 1821
	private static int __PropertyOffset_Distance;

	// Token: 0x0400071E RID: 1822
	private static int __PropertyOffset_IgnoreZ;

	// Token: 0x0400071F RID: 1823
	private static int __PropertyOffset_Tolerance;
}
