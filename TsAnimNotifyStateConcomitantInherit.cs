using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D37 RID: 3383
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateConcomitantInherit.TsAnimNotifyStateConcomitantInherit_C")]
public class TsAnimNotifyStateConcomitantInherit : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000381 RID: 897
	// (get) Token: 0x06004657 RID: 18007 RVA: 0x0008E233 File Offset: 0x0008C433
	// (set) Token: 0x06004658 RID: 18008 RVA: 0x0008E243 File Offset: 0x0008C443
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 技能打断
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateConcomitantInherit.__PropertyOffset_技能打断) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateConcomitantInherit.__PropertyOffset_技能打断) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000382 RID: 898
	// (get) Token: 0x06004659 RID: 18009 RVA: 0x0008E254 File Offset: 0x0008C454
	// (set) Token: 0x0600465A RID: 18010 RVA: 0x0008E264 File Offset: 0x0008C464
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 受击打断
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateConcomitantInherit.__PropertyOffset_受击打断) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateConcomitantInherit.__PropertyOffset_受击打断) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000383 RID: 899
	// (get) Token: 0x0600465B RID: 18011 RVA: 0x0008E275 File Offset: 0x0008C475
	// (set) Token: 0x0600465C RID: 18012 RVA: 0x0008E285 File Offset: 0x0008C485
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 其他打断
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateConcomitantInherit.__PropertyOffset_其他打断) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateConcomitantInherit.__PropertyOffset_其他打断) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000384 RID: 900
	// (get) Token: 0x0600465D RID: 18013 RVA: 0x0008E298 File Offset: 0x0008C498
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<long> 技能Id
	{
		[NullableContext(1)]
		get
		{
			base.FastCheckIsValid();
			TArray<long> result;
			if ((result = this._技能Id) == null)
			{
				result = (this._技能Id = new TArray<long>(base.NativePtr + (IntPtr)TsAnimNotifyStateConcomitantInherit.__PropertyOffset_技能Id, this));
			}
			return result;
		}
	}

	// Token: 0x17000385 RID: 901
	// (get) Token: 0x0600465E RID: 18014 RVA: 0x0008E2D1 File Offset: 0x0008C4D1
	// (set) Token: 0x0600465F RID: 18015 RVA: 0x0008E2E1 File Offset: 0x0008C4E1
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe long 开始特效
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateConcomitantInherit.__PropertyOffset_开始特效);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateConcomitantInherit.__PropertyOffset_开始特效) = value;
		}
	}

	// Token: 0x17000386 RID: 902
	// (get) Token: 0x06004660 RID: 18016 RVA: 0x0008E2F2 File Offset: 0x0008C4F2
	// (set) Token: 0x06004661 RID: 18017 RVA: 0x0008E302 File Offset: 0x0008C502
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe long 结束特效
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateConcomitantInherit.__PropertyOffset_结束特效);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateConcomitantInherit.__PropertyOffset_结束特效) = value;
		}
	}

	// Token: 0x17000387 RID: 903
	// (get) Token: 0x06004662 RID: 18018 RVA: 0x0008E313 File Offset: 0x0008C513
	// (set) Token: 0x06004663 RID: 18019 RVA: 0x0008E323 File Offset: 0x0008C523
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EConcomitantDurationType 持续时间类型
	{
		get
		{
			return (EConcomitantDurationType)(*(base.NativePtr + (IntPtr)TsAnimNotifyStateConcomitantInherit.__PropertyOffset_持续时间类型));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateConcomitantInherit.__PropertyOffset_持续时间类型) = (byte)value;
		}
	}

	// Token: 0x17000388 RID: 904
	// (get) Token: 0x06004664 RID: 18020 RVA: 0x0008E334 File Offset: 0x0008C534
	// (set) Token: 0x06004665 RID: 18021 RVA: 0x0008E344 File Offset: 0x0008C544
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 持续时间
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateConcomitantInherit.__PropertyOffset_持续时间);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateConcomitantInherit.__PropertyOffset_持续时间) = value;
		}
	}

	// Token: 0x17000389 RID: 905
	// (get) Token: 0x06004666 RID: 18022 RVA: 0x0008E355 File Offset: 0x0008C555
	// (set) Token: 0x06004667 RID: 18023 RVA: 0x0008E365 File Offset: 0x0008C565
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int 伴生物编号
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateConcomitantInherit.__PropertyOffset_伴生物编号);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateConcomitantInherit.__PropertyOffset_伴生物编号) = value;
		}
	}

	// Token: 0x1700038A RID: 906
	// (get) Token: 0x06004668 RID: 18024 RVA: 0x0008E376 File Offset: 0x0008C576
	// (set) Token: 0x06004669 RID: 18025 RVA: 0x0008E386 File Offset: 0x0008C586
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe long BuffId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateConcomitantInherit.__PropertyOffset_BuffId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateConcomitantInherit.__PropertyOffset_BuffId) = value;
		}
	}

	// Token: 0x0600466A RID: 18026 RVA: 0x0008E398 File Offset: 0x0008C598
	[NullableContext(2)]
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

	// Token: 0x0600466B RID: 18027 RVA: 0x0008E440 File Offset: 0x0008C640
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			Entity entity;
			if (tsBaseCharacter == null)
			{
				entity = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
				entity = ((characterActorComponent != null) ? characterActorComponent.Entity : null);
			}
			Entity entity2 = entity;
			if (entity2 == null)
			{
				return false;
			}
			Singleton<CombatLog>.Instance.Info(CombatLog.EDebugModule.Skill, entity2, "TsAnimNotifyStateConcomitantInherit K2_NotifyBegin", default(ReadOnlySpan<ValueTuple<string, object>>));
			CreatureDataComponent component = entity2.GetComponent<CreatureDataComponent>();
			long? num = (component != null) ? new long?(component.GetSummonerId()) : null;
			if (num != null && num.Value != 0L)
			{
				return false;
			}
			CharacterFollowComponent component2 = entity2.GetComponent<CharacterFollowComponent>();
			CharacterBuffComponent component3 = entity2.GetComponent<CharacterBuffComponent>();
			long? preMessage = (component3 != null) ? component3.CreateAnimNotifyContent(animation.GetName(), base.exportIndex) : null;
			List<long> list = new List<long>();
			if (list != null)
			{
				for (int i = 0; i < this.技能Id.Num(); i++)
				{
					list.Add(this.技能Id.Get(i));
				}
			}
			if (component2 != null)
			{
				component2.ListenConcomitantInherit(new IConcomitantInheritContext
				{
					SkillInterrupt = this.技能打断,
					HitInterrupt = this.受击打断,
					OtherInterrupt = this.其他打断,
					NewSkillIds = list,
					SkillId = null,
					ConcomitantDurationType = this.持续时间类型,
					Duration = this.持续时间,
					StartCue = this.开始特效,
					EndCue = this.结束特效,
					SummonIndex = this.伴生物编号,
					BuffId = this.BuffId,
					PreMessage = preMessage
				});
			}
		}
		return true;
	}

	// Token: 0x0600466C RID: 18028 RVA: 0x0008E5D0 File Offset: 0x0008C7D0
	[NullableContext(2)]
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

	// Token: 0x0600466D RID: 18029 RVA: 0x0008E670 File Offset: 0x0008C870
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		Entity entity = null;
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			Entity entity2;
			if (tsBaseCharacter == null)
			{
				entity2 = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
				entity2 = ((characterActorComponent != null) ? characterActorComponent.Entity : null);
			}
			entity = entity2;
		}
		Singleton<CombatLog>.Instance.Info(CombatLog.EDebugModule.Skill, entity, "TsAnimNotifyStateConcomitantInherit K2_NotifyEnd", default(ReadOnlySpan<ValueTuple<string, object>>));
		long? num;
		if (entity == null)
		{
			num = null;
		}
		else
		{
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			num = ((component != null) ? new long?(component.GetSummonerId()) : null);
		}
		long? num2 = num;
		if (num2 == null || num2.Value == 0L)
		{
			CharacterFollowComponent characterFollowComponent = (entity != null) ? entity.GetComponent<CharacterFollowComponent>() : null;
			if (characterFollowComponent != null)
			{
				characterFollowComponent.RemoveListenConcomitantInherit();
			}
		}
		else if (this.持续时间类型 == EConcomitantDurationType.帧事件结束时消失)
		{
			EntityHandle entity3 = ModelBase<CreatureModel>.Instance.GetEntity(num2.Value);
			WorldEntity worldEntity = (entity3 != null) ? entity3.Entity : null;
			CharacterFollowComponent characterFollowComponent2 = (worldEntity != null) ? worldEntity.GetComponent<CharacterFollowComponent>() : null;
			if (characterFollowComponent2 != null)
			{
				characterFollowComponent2.EndConcomitantInherit(this.伴生物编号);
			}
		}
		return true;
	}

	// Token: 0x0600466E RID: 18030 RVA: 0x0008E760 File Offset: 0x0008C960
	[NullableContext(1)]
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

	// Token: 0x0600466F RID: 18031 RVA: 0x0008E7DB File Offset: 0x0008C9DB
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "技能打断时召唤伴生物继承技能";
	}

	// Token: 0x06004670 RID: 18032 RVA: 0x0008E7E2 File Offset: 0x0008C9E2
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateConcomitantInherit._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateConcomitantInherit.TsAnimNotifyStateConcomitantInherit_C");
		}
		return TsAnimNotifyStateConcomitantInherit._ClassPtr;
	}

	// Token: 0x06004671 RID: 18033 RVA: 0x0008E808 File Offset: 0x0008CA08
	public TsAnimNotifyStateConcomitantInherit() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateConcomitantInherit.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004672 RID: 18034 RVA: 0x0008E830 File Offset: 0x0008CA30
	[NullableContext(1)]
	public TsAnimNotifyStateConcomitantInherit(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateConcomitantInherit.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004673 RID: 18035 RVA: 0x0008E863 File Offset: 0x0008CA63
	protected TsAnimNotifyStateConcomitantInherit(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004674 RID: 18036 RVA: 0x0008E86C File Offset: 0x0008CA6C
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004675 RID: 18037 RVA: 0x0008E8A8 File Offset: 0x0008CAA8
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004676 RID: 18038 RVA: 0x0008E8DB File Offset: 0x0008CADB
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040012FE RID: 4862
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateConcomitantInherit.TsAnimNotifyStateConcomitantInherit_C";

	// Token: 0x040012FF RID: 4863
	private static IntPtr _ClassPtr;

	// Token: 0x04001300 RID: 4864
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001301 RID: 4865
	private static int __PropertyOffset_技能打断;

	// Token: 0x04001302 RID: 4866
	private static int __PropertyOffset_受击打断;

	// Token: 0x04001303 RID: 4867
	private static int __PropertyOffset_其他打断;

	// Token: 0x04001304 RID: 4868
	private static int __PropertyOffset_技能Id;

	// Token: 0x04001305 RID: 4869
	[Nullable(2)]
	private TArray<long> _技能Id;

	// Token: 0x04001306 RID: 4870
	private static int __PropertyOffset_开始特效;

	// Token: 0x04001307 RID: 4871
	private static int __PropertyOffset_结束特效;

	// Token: 0x04001308 RID: 4872
	private static int __PropertyOffset_持续时间类型;

	// Token: 0x04001309 RID: 4873
	private static int __PropertyOffset_持续时间;

	// Token: 0x0400130A RID: 4874
	private static int __PropertyOffset_伴生物编号;

	// Token: 0x0400130B RID: 4875
	private static int __PropertyOffset_BuffId;
}
