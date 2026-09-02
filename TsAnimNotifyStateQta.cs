using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.QuickTimeAction;
using CSharpScript.Game.Module.QuickTimeAction.Context;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D69 RID: 3433
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateQta.TsAnimNotifyStateQta_C")]
public class TsAnimNotifyStateQta : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000428 RID: 1064
	// (get) Token: 0x06004A0C RID: 18956 RVA: 0x000A0CDD File Offset: 0x0009EEDD
	// (set) Token: 0x06004A0D RID: 18957 RVA: 0x000A0CED File Offset: 0x0009EEED
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int QtaId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateQta.__PropertyOffset_QtaId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateQta.__PropertyOffset_QtaId) = value;
		}
	}

	// Token: 0x17000429 RID: 1065
	// (get) Token: 0x06004A0E RID: 18958 RVA: 0x000A0CFE File Offset: 0x0009EEFE
	// (set) Token: 0x06004A0F RID: 18959 RVA: 0x000A0D0E File Offset: 0x0009EF0E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 当前实体为玩家控制时才触发
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateQta.__PropertyOffset_当前实体为玩家控制时才触发) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateQta.__PropertyOffset_当前实体为玩家控制时才触发) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700042A RID: 1066
	// (get) Token: 0x06004A10 RID: 18960 RVA: 0x000A0D1F File Offset: 0x0009EF1F
	// (set) Token: 0x06004A11 RID: 18961 RVA: 0x000A0D33 File Offset: 0x0009EF33
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag 存在Tag时才触发
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateQta.__PropertyOffset_存在Tag时才触发);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateQta.__PropertyOffset_存在Tag时才触发) = value;
		}
	}

	// Token: 0x1700042B RID: 1067
	// (get) Token: 0x06004A12 RID: 18962 RVA: 0x000A0D48 File Offset: 0x0009EF48
	// (set) Token: 0x06004A13 RID: 18963 RVA: 0x000A0D58 File Offset: 0x0009EF58
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 开始时直接结束其它Qta
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateQta.__PropertyOffset_开始时直接结束其它Qta) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateQta.__PropertyOffset_开始时直接结束其它Qta) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700042C RID: 1068
	// (get) Token: 0x06004A14 RID: 18964 RVA: 0x000A0D69 File Offset: 0x0009EF69
	// (set) Token: 0x06004A15 RID: 18965 RVA: 0x000A0D79 File Offset: 0x0009EF79
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool ANS结束时再结算Qta
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateQta.__PropertyOffset_ANS结束时再结算Qta) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateQta.__PropertyOffset_ANS结束时再结算Qta) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700042D RID: 1069
	// (get) Token: 0x06004A16 RID: 18966 RVA: 0x000A0D8A File Offset: 0x0009EF8A
	// (set) Token: 0x06004A17 RID: 18967 RVA: 0x000A0D9A File Offset: 0x0009EF9A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool ANS结束时尝试结算
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateQta.__PropertyOffset_ANS结束时尝试结算) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateQta.__PropertyOffset_ANS结束时尝试结算) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700042E RID: 1070
	// (get) Token: 0x06004A18 RID: 18968 RVA: 0x000A0DAB File Offset: 0x0009EFAB
	// (set) Token: 0x06004A19 RID: 18969 RVA: 0x000A0DBB File Offset: 0x0009EFBB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 技能被打断时不结算
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateQta.__PropertyOffset_技能被打断时不结算) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateQta.__PropertyOffset_技能被打断时不结算) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700042F RID: 1071
	// (get) Token: 0x06004A1A RID: 18970 RVA: 0x000A0DCC File Offset: 0x0009EFCC
	// (set) Token: 0x06004A1B RID: 18971 RVA: 0x000A0DDC File Offset: 0x0009EFDC
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool ANS结束时停止Qta
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateQta.__PropertyOffset_ANS结束时停止Qta) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateQta.__PropertyOffset_ANS结束时停止Qta) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004A1C RID: 18972 RVA: 0x000A0DF0 File Offset: 0x0009EFF0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyBegin(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyBegin"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->TotalDuration = totalDuration;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004A1D RID: 18973 RVA: 0x000A0E98 File Offset: 0x0009F098
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
		Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
		if (this.当前实体为玩家控制时才触发 && (characterActorComponent == null || !characterActorComponent.Valid || !characterActorComponent.IsAutonomousProxy))
		{
			return false;
		}
		if (!string.IsNullOrEmpty(this.存在Tag时才触发.TagName.ToString()) && this.存在Tag时才触发.TagName != "None")
		{
			BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
			if (baseTagComponent == null || !baseTagComponent.HasTag(this.存在Tag时才触发.TagId()))
			{
				return false;
			}
		}
		BaseSkillComponent baseSkillComponent = (entity != null) ? entity.GetComponent<BaseSkillComponent>() : null;
		if ((baseSkillComponent != null && !baseSkillComponent.Valid) || (baseSkillComponent != null && baseSkillComponent.IsSkillMontageInvalid(animation.GetName())))
		{
			return false;
		}
		EntityHandle handleByEntity = ModelBase<CharacterModel>.Instance.GetHandleByEntity(entity);
		BaseBuffComponent baseBuffComponent = (entity != null) ? entity.GetComponent<BaseBuffComponent>() : null;
		long? num = (baseBuffComponent != null) ? baseBuffComponent.CreateAnimNotifyContent(animation.GetName(), base.exportIndex) : null;
		if (handleByEntity != null && num != null)
		{
			if (this.开始时直接结束其它Qta)
			{
				ControllerBase<QtaController>.Instance.StopCurrentQta();
			}
			QtaContextBase qtaContextBase = ControllerBase<QtaController>.Instance.StartQta(this.QtaId, null, EQtaSource.AnimNotifyState, new IQtaExtraParams
			{
				MessageId = new long?(num.Value),
				EntityHandle = handleByEntity,
				IsPendingExternalCompletion = new bool?(this.ANS结束时再结算Qta)
			});
			int qtaHandleId = (qtaContextBase != null) ? qtaContextBase.HandleId : 0;
			string key = TsAnimNotifyStateQtaParam.GetKey(handleByEntity.Id, base.exportIndex);
			TsAnimNotifyStateQta.ParamCachedMap.Add(key, new TsAnimNotifyStateQtaParam(qtaHandleId));
		}
		return true;
	}

	// Token: 0x06004A1E RID: 18974 RVA: 0x000A1058 File Offset: 0x0009F258
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyEnd(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyEnd"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004A1F RID: 18975 RVA: 0x000A10F8 File Offset: 0x0009F2F8
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return true;
		}
		CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
		Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
		string key = TsAnimNotifyStateQtaParam.GetKey(entity.Id, base.exportIndex);
		TsAnimNotifyStateQtaParam tsAnimNotifyStateQtaParam;
		if (!TsAnimNotifyStateQta.ParamCachedMap.TryGetValue(key, out tsAnimNotifyStateQtaParam))
		{
			return false;
		}
		TsAnimNotifyStateQta.ParamCachedMap.Remove(key);
		int num = (tsAnimNotifyStateQtaParam != null) ? tsAnimNotifyStateQtaParam.QtaHandleId : 0;
		if (num > 0)
		{
			BaseSkillComponent baseSkillComponent = (entity != null) ? entity.GetComponent<BaseSkillComponent>() : null;
			bool flag = baseSkillComponent != null && baseSkillComponent.IsSkillMontageInvalid(animation.GetName());
			if (ControllerBase<QtaController>.Instance.GetCurrentQtaHandleId() != num)
			{
				return false;
			}
			if (this.技能被打断时不结算 && flag)
			{
				ControllerBase<QtaController>.Instance.StopQta(num, true);
				return true;
			}
			if (this.ANS结束时再结算Qta)
			{
				ControllerBase<QtaController>.Instance.OnExternalConditionMet(num, EQtaExternalReason.AnsEnd);
				if (!this.技能被打断时不结算 || !flag)
				{
					ControllerBase<QtaController>.Instance.ResolveQta(num);
					return true;
				}
			}
			else if (this.ANS结束时尝试结算 && (!this.技能被打断时不结算 || !flag))
			{
				ControllerBase<QtaController>.Instance.ResolveQta(num);
				return true;
			}
			if (this.ANS结束时停止Qta)
			{
				ControllerBase<QtaController>.Instance.StopQta(num, false);
			}
		}
		return true;
	}

	// Token: 0x06004A20 RID: 18976 RVA: 0x000A1220 File Offset: 0x0009F420
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotifyState.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotifyState.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotifyState.__GetNotifyName_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		string result = FString.ToString((void*)(&ptr2->__Result));
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}

	// Token: 0x06004A21 RID: 18977 RVA: 0x000A129B File Offset: 0x0009F49B
	protected override string GetNotifyName_Implementation()
	{
		return "特殊交互QTA";
	}

	// Token: 0x06004A22 RID: 18978 RVA: 0x000A12A2 File Offset: 0x0009F4A2
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateQta._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateQta.TsAnimNotifyStateQta_C");
		}
		return TsAnimNotifyStateQta._ClassPtr;
	}

	// Token: 0x06004A23 RID: 18979 RVA: 0x000A12C8 File Offset: 0x0009F4C8
	public TsAnimNotifyStateQta() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateQta.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004A24 RID: 18980 RVA: 0x000A12F0 File Offset: 0x0009F4F0
	public TsAnimNotifyStateQta(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateQta.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004A25 RID: 18981 RVA: 0x000A1323 File Offset: 0x0009F523
	protected TsAnimNotifyStateQta(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004A26 RID: 18982 RVA: 0x000A132C File Offset: 0x0009F52C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004A27 RID: 18983 RVA: 0x000A1368 File Offset: 0x0009F568
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004A28 RID: 18984 RVA: 0x000A139B File Offset: 0x0009F59B
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040014F2 RID: 5362
	[StaticVariableRuleIgnore]
	private static Dictionary<string, TsAnimNotifyStateQtaParam> ParamCachedMap = new Dictionary<string, TsAnimNotifyStateQtaParam>();

	// Token: 0x040014F3 RID: 5363
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateQta.TsAnimNotifyStateQta_C";

	// Token: 0x040014F4 RID: 5364
	private static IntPtr _ClassPtr;

	// Token: 0x040014F5 RID: 5365
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040014F6 RID: 5366
	private static int __PropertyOffset_QtaId;

	// Token: 0x040014F7 RID: 5367
	private static int __PropertyOffset_当前实体为玩家控制时才触发;

	// Token: 0x040014F8 RID: 5368
	private static int __PropertyOffset_存在Tag时才触发;

	// Token: 0x040014F9 RID: 5369
	private static int __PropertyOffset_开始时直接结束其它Qta;

	// Token: 0x040014FA RID: 5370
	private static int __PropertyOffset_ANS结束时再结算Qta;

	// Token: 0x040014FB RID: 5371
	private static int __PropertyOffset_ANS结束时尝试结算;

	// Token: 0x040014FC RID: 5372
	private static int __PropertyOffset_技能被打断时不结算;

	// Token: 0x040014FD RID: 5373
	private static int __PropertyOffset_ANS结束时停止Qta;
}
