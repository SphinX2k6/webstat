using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Extension;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C51 RID: 3153
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCheckInbound.TsDecoratorCheckInbound_C")]
public class TsDecoratorCheckInbound : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000131 RID: 305
	// (get) Token: 0x0600379C RID: 14236 RVA: 0x0003A2F8 File Offset: 0x000384F8
	// (set) Token: 0x0600379D RID: 14237 RVA: 0x0003A331 File Offset: 0x00038531
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<string, float> SocketHeight
	{
		get
		{
			base.FastCheckIsValid();
			TMap<string, float> result;
			if ((result = this._SocketHeight) == null)
			{
				result = (this._SocketHeight = new TMap<string, float>(base.NativePtr + (IntPtr)TsDecoratorCheckInbound.__PropertyOffset_SocketHeight, this));
			}
			return result;
		}
		set
		{
			this.SocketHeight.CopyAssign(value);
		}
	}

	// Token: 0x0600379E RID: 14238 RVA: 0x0003A33F File Offset: 0x0003853F
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.LastCheckResult = true;
			this.LastCheckTimeStamp = 0.0;
			this.InitData();
		}
	}

	// Token: 0x0600379F RID: 14239 RVA: 0x0003A374 File Offset: 0x00038574
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

	// Token: 0x060037A0 RID: 14240 RVA: 0x0003A414 File Offset: 0x00038614
	[NullableContext(2)]
	protected virtual bool PerformConditionCheckAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		if ((ownerController as TsAiController).AiController == null)
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
		this.InitTraceElement();
		if (Singleton<Time>.Instance.WorldTime < this.LastCheckTimeStamp + 200.0)
		{
			return this.LastCheckResult;
		}
		this.LastCheckTimeStamp = Singleton<Time>.Instance.WorldTime;
		USkeletalMeshComponent skeletalMesh = (ownerController as TsAiController).AiController.CharActorComp.SkeletalMesh;
		Vector vector = Vector.Create();
		bool flag = true;
		foreach (KeyValuePair<string, float> keyValuePair in this.SocketHeightInternal)
		{
			string text;
			float num;
			keyValuePair.Deconstruct(out text, out num);
			string key = text;
			float height = num;
			Vector vector2 = vector;
			FVectorDouble fvectorDouble = skeletalMesh.D_GetSocketLocation(FNameUtil.GetDynamicFName(key).Value);
			vector2.FromUeVector(fvectorDouble);
			flag = (flag && this.CheckInbound(vector, height));
		}
		this.LastCheckResult = flag;
		return flag;
	}

	// Token: 0x060037A1 RID: 14241 RVA: 0x0003A550 File Offset: 0x00038750
	private void InitTraceElement()
	{
		if (this.TsTraceElement == null)
		{
			this.TsTraceElement = new UTraceLineElement();
			this.TsTraceElement.bIsSingle = true;
			this.TsTraceElement.bIgnoreSelf = true;
			this.TsTraceElement.SetTraceTypeQuery(KuroTraceTypeQuery.Visible);
		}
		this.TsTraceElement.WorldContextObject = this.GetWorld();
	}

	// Token: 0x060037A2 RID: 14242 RVA: 0x0003A5AC File Offset: 0x000387AC
	private void InitData()
	{
		if (this.SocketHeightInternal == null)
		{
			int num = this.SocketHeight.Num();
			this.SocketHeightInternal = new Dictionary<string, float>(num);
			if (num > 0)
			{
				foreach (KeyValuePair<string, float> keyValuePair in this.SocketHeight)
				{
					string text;
					float num2;
					keyValuePair.Deconstruct(out text, out num2);
					string key = text;
					float value = num2;
					this.SocketHeightInternal.Add(key, value);
				}
			}
		}
	}

	// Token: 0x060037A3 RID: 14243 RVA: 0x0003A638 File Offset: 0x00038838
	private bool CheckInbound(Vector location, float height)
	{
		Singleton<TraceElementCommon>.Instance.SetStartLocation(this.TsTraceElement, location);
		Vector vector = Vector.Create();
		Vector.DownVectorProxy.Multiply((double)height, vector);
		vector.AdditionEqual(location);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(this.TsTraceElement, vector);
		return Singleton<TraceElementCommon>.Instance.LineTrace(this.TsTraceElement, "TsDecoratorCheckInbound") && this.TsTraceElement.HitResult.bBlockingHit;
	}

	// Token: 0x060037A4 RID: 14244 RVA: 0x0003A6AF File Offset: 0x000388AF
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorCheckInbound._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCheckInbound.TsDecoratorCheckInbound_C");
		}
		return TsDecoratorCheckInbound._ClassPtr;
	}

	// Token: 0x060037A5 RID: 14245 RVA: 0x0003A6D4 File Offset: 0x000388D4
	public TsDecoratorCheckInbound() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckInbound.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060037A6 RID: 14246 RVA: 0x0003A6FC File Offset: 0x000388FC
	public TsDecoratorCheckInbound(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckInbound.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060037A7 RID: 14247 RVA: 0x0003A72F File Offset: 0x0003892F
	protected TsDecoratorCheckInbound(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060037A8 RID: 14248 RVA: 0x0003A738 File Offset: 0x00038938
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x040007E0 RID: 2016
	private const string PROFILE_KEY = "TsDecoratorCheckInbound";

	// Token: 0x040007E1 RID: 2017
	private const int MIN_CEHCK_TIME_INTERVAL = 200;

	// Token: 0x040007E2 RID: 2018
	private bool IsInitTsVariables;

	// Token: 0x040007E3 RID: 2019
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<string, float> SocketHeightInternal;

	// Token: 0x040007E4 RID: 2020
	[Nullable(2)]
	private UTraceLineElement TsTraceElement;

	// Token: 0x040007E5 RID: 2021
	private bool LastCheckResult;

	// Token: 0x040007E6 RID: 2022
	private double LastCheckTimeStamp;

	// Token: 0x040007E7 RID: 2023
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCheckInbound.TsDecoratorCheckInbound_C";

	// Token: 0x040007E8 RID: 2024
	private static IntPtr _ClassPtr;

	// Token: 0x040007E9 RID: 2025
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040007EA RID: 2026
	private static int __PropertyOffset_SocketHeight;

	// Token: 0x040007EB RID: 2027
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TMap<string, float> _SocketHeight;
}
