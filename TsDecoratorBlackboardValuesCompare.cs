using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C30 RID: 3120
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/TsDecoratorBlackboardValuesCompare.TsDecoratorBlackboardValuesCompare_C")]
public class TsDecoratorBlackboardValuesCompare : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170000F0 RID: 240
	// (get) Token: 0x0600360C RID: 13836 RVA: 0x00033CBC File Offset: 0x00031EBC
	// (set) Token: 0x0600360D RID: 13837 RVA: 0x00033CF5 File Offset: 0x00031EF5
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<string, string> StringMap
	{
		get
		{
			base.FastCheckIsValid();
			TMap<string, string> result;
			if ((result = this._StringMap) == null)
			{
				result = (this._StringMap = new TMap<string, string>(base.NativePtr + (IntPtr)TsDecoratorBlackboardValuesCompare.__PropertyOffset_StringMap, this));
			}
			return result;
		}
		set
		{
			this.StringMap.CopyAssign(value);
		}
	}

	// Token: 0x170000F1 RID: 241
	// (get) Token: 0x0600360E RID: 13838 RVA: 0x00033D04 File Offset: 0x00031F04
	// (set) Token: 0x0600360F RID: 13839 RVA: 0x00033D3D File Offset: 0x00031F3D
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<string, float> FloatMap
	{
		get
		{
			base.FastCheckIsValid();
			TMap<string, float> result;
			if ((result = this._FloatMap) == null)
			{
				result = (this._FloatMap = new TMap<string, float>(base.NativePtr + (IntPtr)TsDecoratorBlackboardValuesCompare.__PropertyOffset_FloatMap, this));
			}
			return result;
		}
		set
		{
			this.FloatMap.CopyAssign(value);
		}
	}

	// Token: 0x170000F2 RID: 242
	// (get) Token: 0x06003610 RID: 13840 RVA: 0x00033D4C File Offset: 0x00031F4C
	// (set) Token: 0x06003611 RID: 13841 RVA: 0x00033D85 File Offset: 0x00031F85
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<string, int> IntMap
	{
		get
		{
			base.FastCheckIsValid();
			TMap<string, int> result;
			if ((result = this._IntMap) == null)
			{
				result = (this._IntMap = new TMap<string, int>(base.NativePtr + (IntPtr)TsDecoratorBlackboardValuesCompare.__PropertyOffset_IntMap, this));
			}
			return result;
		}
		set
		{
			this.IntMap.CopyAssign(value);
		}
	}

	// Token: 0x170000F3 RID: 243
	// (get) Token: 0x06003612 RID: 13842 RVA: 0x00033D94 File Offset: 0x00031F94
	// (set) Token: 0x06003613 RID: 13843 RVA: 0x00033DCD File Offset: 0x00031FCD
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<string, bool> BooleanMap
	{
		get
		{
			base.FastCheckIsValid();
			TMap<string, bool> result;
			if ((result = this._BooleanMap) == null)
			{
				result = (this._BooleanMap = new TMap<string, bool>(base.NativePtr + (IntPtr)TsDecoratorBlackboardValuesCompare.__PropertyOffset_BooleanMap, this));
			}
			return result;
		}
		set
		{
			this.BooleanMap.CopyAssign(value);
		}
	}

	// Token: 0x170000F4 RID: 244
	// (get) Token: 0x06003614 RID: 13844 RVA: 0x00033DDC File Offset: 0x00031FDC
	// (set) Token: 0x06003615 RID: 13845 RVA: 0x00033E15 File Offset: 0x00032015
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<string, FVector> VectorMap
	{
		get
		{
			base.FastCheckIsValid();
			TMap<string, FVector> result;
			if ((result = this._VectorMap) == null)
			{
				result = (this._VectorMap = new TMap<string, FVector>(base.NativePtr + (IntPtr)TsDecoratorBlackboardValuesCompare.__PropertyOffset_VectorMap, this));
			}
			return result;
		}
		set
		{
			this.VectorMap.CopyAssign(value);
		}
	}

	// Token: 0x06003616 RID: 13846 RVA: 0x00033E24 File Offset: 0x00032024
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
				this.TsStringMap.Add(key, value);
			}
			foreach (KeyValuePair<string, float> keyValuePair2 in this.FloatMap)
			{
				string text2;
				float num;
				keyValuePair2.Deconstruct(out text2, out num);
				string key2 = text2;
				float value2 = num;
				this.TsFloatMap.Add(key2, value2);
			}
			foreach (KeyValuePair<string, int> keyValuePair3 in this.IntMap)
			{
				string text2;
				int num2;
				keyValuePair3.Deconstruct(out text2, out num2);
				string key3 = text2;
				int value3 = num2;
				this.TsIntMap.Add(key3, value3);
			}
			foreach (KeyValuePair<string, bool> keyValuePair4 in this.BooleanMap)
			{
				string text2;
				bool flag;
				keyValuePair4.Deconstruct(out text2, out flag);
				string key4 = text2;
				bool value4 = flag;
				this.TsBooleanMap.Add(key4, value4);
			}
			foreach (KeyValuePair<string, FVector> keyValuePair5 in this.VectorMap)
			{
				string text2;
				FVector fvector;
				keyValuePair5.Deconstruct(out text2, out fvector);
				string key5 = text2;
				FVector value5 = fvector;
				this.TsVectorMap.Add(key5, value5);
			}
		}
	}

	// Token: 0x06003617 RID: 13847 RVA: 0x00034084 File Offset: 0x00032284
	private bool ExecuteStringMapCompare()
	{
		foreach (KeyValuePair<string, string> keyValuePair in this.TsStringMap)
		{
			string text;
			string text2;
			keyValuePair.Deconstruct(out text, out text2);
			string key = text;
			string b = text2;
			if (ControllerBase<BlackboardController>.Instance.GetStringValueByEntity(this.EntityId.Value, key) != b)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06003618 RID: 13848 RVA: 0x00034108 File Offset: 0x00032308
	private bool ExecuteFloatMapCompare()
	{
		foreach (KeyValuePair<string, float> keyValuePair in this.TsFloatMap)
		{
			string text;
			float num;
			keyValuePair.Deconstruct(out text, out num);
			string key = text;
			float num2 = num;
			float? floatValueByEntity = ControllerBase<BlackboardController>.Instance.GetFloatValueByEntity(this.EntityId.Value, key);
			num = num2;
			if (!(floatValueByEntity.GetValueOrDefault() == num & floatValueByEntity != null))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06003619 RID: 13849 RVA: 0x0003419C File Offset: 0x0003239C
	private bool ExecuteIntMapCompare()
	{
		foreach (KeyValuePair<string, int> keyValuePair in this.TsIntMap)
		{
			string text;
			int num;
			keyValuePair.Deconstruct(out text, out num);
			string key = text;
			int num2 = num;
			int? intValueByEntity = ControllerBase<BlackboardController>.Instance.GetIntValueByEntity(this.EntityId.Value, key);
			num = num2;
			if (!(intValueByEntity.GetValueOrDefault() == num & intValueByEntity != null))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0600361A RID: 13850 RVA: 0x00034230 File Offset: 0x00032430
	private bool ExecuteBooleanMapCompare()
	{
		foreach (KeyValuePair<string, bool> keyValuePair in this.TsBooleanMap)
		{
			string text;
			bool flag;
			keyValuePair.Deconstruct(out text, out flag);
			string key = text;
			bool flag2 = flag;
			bool? booleanValueByEntity = ControllerBase<BlackboardController>.Instance.GetBooleanValueByEntity(this.EntityId.Value, key);
			flag = flag2;
			if (!(booleanValueByEntity.GetValueOrDefault() == flag & booleanValueByEntity != null))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0600361B RID: 13851 RVA: 0x000342C4 File Offset: 0x000324C4
	private bool ExecuteVectorMapCompare()
	{
		foreach (KeyValuePair<string, FVector> keyValuePair in this.TsVectorMap)
		{
			string text;
			FVector fvector;
			keyValuePair.Deconstruct(out text, out fvector);
			string key = text;
			FVector fvector2 = fvector;
			Aki.Protocol.Vector vectorValueByEntity = ControllerBase<BlackboardController>.Instance.GetVectorValueByEntity(this.EntityId.Value, key);
			if (vectorValueByEntity == null)
			{
				return false;
			}
			if (!vectorValueByEntity.ToFVector().Equals(fvector2, 0.0001f))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0600361C RID: 13852 RVA: 0x00034364 File Offset: 0x00032564
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

	// Token: 0x0600361D RID: 13853 RVA: 0x00034404 File Offset: 0x00032604
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
		this.EntityId = new int?(aiController.CharActorComp.Entity.Id);
		return this.ExecuteIntMapCompare() && this.ExecuteStringMapCompare() && this.ExecuteBooleanMapCompare() && this.ExecuteFloatMapCompare() && this.ExecuteVectorMapCompare();
	}

	// Token: 0x0600361E RID: 13854 RVA: 0x0003449E File Offset: 0x0003269E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorBlackboardValuesCompare._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/TsDecoratorBlackboardValuesCompare.TsDecoratorBlackboardValuesCompare_C");
		}
		return TsDecoratorBlackboardValuesCompare._ClassPtr;
	}

	// Token: 0x0600361F RID: 13855 RVA: 0x000344C4 File Offset: 0x000326C4
	public TsDecoratorBlackboardValuesCompare() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorBlackboardValuesCompare.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003620 RID: 13856 RVA: 0x000344EC File Offset: 0x000326EC
	public TsDecoratorBlackboardValuesCompare(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorBlackboardValuesCompare.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003621 RID: 13857 RVA: 0x0003451F File Offset: 0x0003271F
	protected TsDecoratorBlackboardValuesCompare(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003622 RID: 13858 RVA: 0x00034528 File Offset: 0x00032728
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x040006D4 RID: 1748
	private bool IsInitTsVariables;

	// Token: 0x040006D5 RID: 1749
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Dictionary<string, string> TsStringMap;

	// Token: 0x040006D6 RID: 1750
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<string, float> TsFloatMap;

	// Token: 0x040006D7 RID: 1751
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<string, int> TsIntMap;

	// Token: 0x040006D8 RID: 1752
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<string, bool> TsBooleanMap;

	// Token: 0x040006D9 RID: 1753
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<string, FVector> TsVectorMap;

	// Token: 0x040006DA RID: 1754
	private int? EntityId;

	// Token: 0x040006DB RID: 1755
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/TsDecoratorBlackboardValuesCompare.TsDecoratorBlackboardValuesCompare_C";

	// Token: 0x040006DC RID: 1756
	private static IntPtr _ClassPtr;

	// Token: 0x040006DD RID: 1757
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040006DE RID: 1758
	private static int __PropertyOffset_StringMap;

	// Token: 0x040006DF RID: 1759
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private TMap<string, string> _StringMap;

	// Token: 0x040006E0 RID: 1760
	private static int __PropertyOffset_FloatMap;

	// Token: 0x040006E1 RID: 1761
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TMap<string, float> _FloatMap;

	// Token: 0x040006E2 RID: 1762
	private static int __PropertyOffset_IntMap;

	// Token: 0x040006E3 RID: 1763
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TMap<string, int> _IntMap;

	// Token: 0x040006E4 RID: 1764
	private static int __PropertyOffset_BooleanMap;

	// Token: 0x040006E5 RID: 1765
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TMap<string, bool> _BooleanMap;

	// Token: 0x040006E6 RID: 1766
	private static int __PropertyOffset_VectorMap;

	// Token: 0x040006E7 RID: 1767
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TMap<string, FVector> _VectorMap;
}
