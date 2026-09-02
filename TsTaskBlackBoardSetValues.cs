using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CA5 RID: 3237
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskBlackBoardSetValues.TsTaskBlackBoardSetValues_C")]
public class TsTaskBlackBoardSetValues : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170001F3 RID: 499
	// (get) Token: 0x06003C9D RID: 15517 RVA: 0x000537B0 File Offset: 0x000519B0
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<string, string> StringMap
	{
		get
		{
			base.FastCheckIsValid();
			TMap<string, string> result;
			if ((result = this._StringMap) == null)
			{
				result = (this._StringMap = new TMap<string, string>(base.NativePtr + (IntPtr)TsTaskBlackBoardSetValues.__PropertyOffset_StringMap, this));
			}
			return result;
		}
	}

	// Token: 0x170001F4 RID: 500
	// (get) Token: 0x06003C9E RID: 15518 RVA: 0x000537EC File Offset: 0x000519EC
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<string, float> FloatMap
	{
		get
		{
			base.FastCheckIsValid();
			TMap<string, float> result;
			if ((result = this._FloatMap) == null)
			{
				result = (this._FloatMap = new TMap<string, float>(base.NativePtr + (IntPtr)TsTaskBlackBoardSetValues.__PropertyOffset_FloatMap, this));
			}
			return result;
		}
	}

	// Token: 0x170001F5 RID: 501
	// (get) Token: 0x06003C9F RID: 15519 RVA: 0x00053828 File Offset: 0x00051A28
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<string, int> IntMap
	{
		get
		{
			base.FastCheckIsValid();
			TMap<string, int> result;
			if ((result = this._IntMap) == null)
			{
				result = (this._IntMap = new TMap<string, int>(base.NativePtr + (IntPtr)TsTaskBlackBoardSetValues.__PropertyOffset_IntMap, this));
			}
			return result;
		}
	}

	// Token: 0x170001F6 RID: 502
	// (get) Token: 0x06003CA0 RID: 15520 RVA: 0x00053864 File Offset: 0x00051A64
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<string, bool> BooleanMap
	{
		get
		{
			base.FastCheckIsValid();
			TMap<string, bool> result;
			if ((result = this._BooleanMap) == null)
			{
				result = (this._BooleanMap = new TMap<string, bool>(base.NativePtr + (IntPtr)TsTaskBlackBoardSetValues.__PropertyOffset_BooleanMap, this));
			}
			return result;
		}
	}

	// Token: 0x170001F7 RID: 503
	// (get) Token: 0x06003CA1 RID: 15521 RVA: 0x000538A0 File Offset: 0x00051AA0
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<string, FVector> VectorMap
	{
		get
		{
			base.FastCheckIsValid();
			TMap<string, FVector> result;
			if ((result = this._VectorMap) == null)
			{
				result = (this._VectorMap = new TMap<string, FVector>(base.NativePtr + (IntPtr)TsTaskBlackBoardSetValues.__PropertyOffset_VectorMap, this));
			}
			return result;
		}
	}

	// Token: 0x06003CA2 RID: 15522 RVA: 0x000538DC File Offset: 0x00051ADC
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsStringMap = new Dictionary<string, string>(this.StringMap.Num());
			this.TsFloatMap = new Dictionary<string, float>(this.FloatMap.Num());
			this.TsIntMap = new Dictionary<string, int>(this.IntMap.Num());
			this.TsBooleanMap = new Dictionary<string, bool>(this.BooleanMap.Num());
			this.TsVectorMap = new Dictionary<string, FVector>(this.VectorMap.Num());
			foreach (KeyValuePair<string, string> keyValuePair in this.StringMap)
			{
				string text;
				string text2;
				keyValuePair.Deconstruct(out text, out text2);
				string key = text;
				string value = text2;
				this.TsStringMap[key] = value;
			}
			foreach (KeyValuePair<string, float> keyValuePair2 in this.FloatMap)
			{
				string text2;
				float num;
				keyValuePair2.Deconstruct(out text2, out num);
				string key2 = text2;
				float value2 = num;
				this.TsFloatMap[key2] = value2;
			}
			foreach (KeyValuePair<string, int> keyValuePair3 in this.IntMap)
			{
				string text2;
				int num2;
				keyValuePair3.Deconstruct(out text2, out num2);
				string key3 = text2;
				int value3 = num2;
				this.TsIntMap[key3] = value3;
			}
			foreach (KeyValuePair<string, bool> keyValuePair4 in this.BooleanMap)
			{
				string text2;
				bool flag;
				keyValuePair4.Deconstruct(out text2, out flag);
				string key4 = text2;
				bool value4 = flag;
				this.TsBooleanMap[key4] = value4;
			}
			foreach (KeyValuePair<string, FVector> keyValuePair5 in this.VectorMap)
			{
				string text2;
				FVector fvector;
				keyValuePair5.Deconstruct(out text2, out fvector);
				string key5 = text2;
				FVector value5 = fvector;
				this.TsVectorMap[key5] = value5;
			}
		}
	}

	// Token: 0x06003CA3 RID: 15523 RVA: 0x00053B3C File Offset: 0x00051D3C
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

	// Token: 0x06003CA4 RID: 15524 RVA: 0x00053BD8 File Offset: 0x00051DD8
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
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
		int id = aiController.CharActorComp.Entity.Id;
		this.ExecuteStringMap(id);
		this.ExecuteFloatMap(id);
		this.ExecuteIntMap(id);
		this.ExecuteBooleanMap(id);
		this.ExecuteVectorMap(id);
		base.FinishExecute(true);
	}

	// Token: 0x06003CA5 RID: 15525 RVA: 0x00053C78 File Offset: 0x00051E78
	private void ExecuteStringMap(int id)
	{
		foreach (KeyValuePair<string, string> keyValuePair in this.TsStringMap)
		{
			ControllerBase<BlackboardController>.Instance.SetStringValueByEntity(id, keyValuePair.Key, keyValuePair.Value);
		}
	}

	// Token: 0x06003CA6 RID: 15526 RVA: 0x00053CE0 File Offset: 0x00051EE0
	private void ExecuteFloatMap(int id)
	{
		foreach (KeyValuePair<string, float> keyValuePair in this.TsFloatMap)
		{
			ControllerBase<BlackboardController>.Instance.SetFloatValueByEntity(id, keyValuePair.Key, keyValuePair.Value);
		}
	}

	// Token: 0x06003CA7 RID: 15527 RVA: 0x00053D48 File Offset: 0x00051F48
	private void ExecuteIntMap(int id)
	{
		foreach (KeyValuePair<string, int> keyValuePair in this.TsIntMap)
		{
			ControllerBase<BlackboardController>.Instance.SetIntValueByEntity(id, keyValuePair.Key, keyValuePair.Value);
		}
	}

	// Token: 0x06003CA8 RID: 15528 RVA: 0x00053DB0 File Offset: 0x00051FB0
	private void ExecuteBooleanMap(int id)
	{
		foreach (KeyValuePair<string, bool> keyValuePair in this.TsBooleanMap)
		{
			ControllerBase<BlackboardController>.Instance.SetBooleanValueByEntity(id, keyValuePair.Key, keyValuePair.Value);
		}
	}

	// Token: 0x06003CA9 RID: 15529 RVA: 0x00053E18 File Offset: 0x00052018
	private void ExecuteVectorMap(int id)
	{
		foreach (KeyValuePair<string, FVector> keyValuePair in this.TsVectorMap)
		{
			string text;
			FVector fvector;
			keyValuePair.Deconstruct(out text, out fvector);
			string key = text;
			FVector fvector2 = fvector;
			ControllerBase<BlackboardController>.Instance.SetVectorValueByEntity(id, key, (double)fvector2.X, (double)fvector2.Y, (double)fvector2.Z);
		}
	}

	// Token: 0x06003CAA RID: 15530 RVA: 0x00053E98 File Offset: 0x00052098
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskBlackBoardSetValues._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskBlackBoardSetValues.TsTaskBlackBoardSetValues_C");
		}
		return TsTaskBlackBoardSetValues._ClassPtr;
	}

	// Token: 0x06003CAB RID: 15531 RVA: 0x00053EBC File Offset: 0x000520BC
	public TsTaskBlackBoardSetValues() : this(BuiltinUtils.AllocNativeUObject(TsTaskBlackBoardSetValues.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003CAC RID: 15532 RVA: 0x00053EE4 File Offset: 0x000520E4
	public TsTaskBlackBoardSetValues(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskBlackBoardSetValues.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003CAD RID: 15533 RVA: 0x00053F17 File Offset: 0x00052117
	protected TsTaskBlackBoardSetValues(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003CAE RID: 15534 RVA: 0x00053F20 File Offset: 0x00052120
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000BAD RID: 2989
	private bool IsInitTsVariables;

	// Token: 0x04000BAE RID: 2990
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Dictionary<string, string> TsStringMap;

	// Token: 0x04000BAF RID: 2991
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<string, float> TsFloatMap;

	// Token: 0x04000BB0 RID: 2992
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<string, int> TsIntMap;

	// Token: 0x04000BB1 RID: 2993
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<string, bool> TsBooleanMap;

	// Token: 0x04000BB2 RID: 2994
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<string, FVector> TsVectorMap;

	// Token: 0x04000BB3 RID: 2995
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskBlackBoardSetValues.TsTaskBlackBoardSetValues_C";

	// Token: 0x04000BB4 RID: 2996
	private static IntPtr _ClassPtr;

	// Token: 0x04000BB5 RID: 2997
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000BB6 RID: 2998
	private static int __PropertyOffset_StringMap;

	// Token: 0x04000BB7 RID: 2999
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private TMap<string, string> _StringMap;

	// Token: 0x04000BB8 RID: 3000
	private static int __PropertyOffset_FloatMap;

	// Token: 0x04000BB9 RID: 3001
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TMap<string, float> _FloatMap;

	// Token: 0x04000BBA RID: 3002
	private static int __PropertyOffset_IntMap;

	// Token: 0x04000BBB RID: 3003
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TMap<string, int> _IntMap;

	// Token: 0x04000BBC RID: 3004
	private static int __PropertyOffset_BooleanMap;

	// Token: 0x04000BBD RID: 3005
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TMap<string, bool> _BooleanMap;

	// Token: 0x04000BBE RID: 3006
	private static int __PropertyOffset_VectorMap;

	// Token: 0x04000BBF RID: 3007
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TMap<string, FVector> _VectorMap;
}
