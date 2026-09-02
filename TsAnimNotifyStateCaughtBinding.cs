using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D32 RID: 3378
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateCaughtBinding.TsAnimNotifyStateCaughtBinding_C")]
public class TsAnimNotifyStateCaughtBinding : TsAnimNotifyStateBase, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x060045FF RID: 17919 RVA: 0x0008C99F File Offset: 0x0008AB9F
	static TsAnimNotifyStateCaughtBinding()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsAnimNotifyStateCaughtBinding.CreateStaticDefaultValue), new Action(TsAnimNotifyStateCaughtBinding.ResetStaticDefaultValue));
	}

	// Token: 0x06004600 RID: 17920 RVA: 0x0008C9BE File Offset: 0x0008ABBE
	public static void CreateStaticDefaultValue()
	{
		TsAnimNotifyStateCaughtBinding._sphereTrace = null;
	}

	// Token: 0x06004601 RID: 17921 RVA: 0x0008C9C6 File Offset: 0x0008ABC6
	public static void ResetStaticDefaultValue()
	{
		TsAnimNotifyStateCaughtBinding._sphereTrace = null;
	}

	// Token: 0x17000376 RID: 886
	// (get) Token: 0x06004602 RID: 17922 RVA: 0x0008C9D0 File Offset: 0x0008ABD0
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<string> CaughtIds
	{
		get
		{
			base.FastCheckIsValid();
			TArray<string> result;
			if ((result = this._CaughtIds) == null)
			{
				result = (this._CaughtIds = new TArray<string>(base.NativePtr + (IntPtr)TsAnimNotifyStateCaughtBinding.__PropertyOffset_CaughtIds, this));
			}
			return result;
		}
	}

	// Token: 0x17000377 RID: 887
	// (get) Token: 0x06004603 RID: 17923 RVA: 0x0008CA09 File Offset: 0x0008AC09
	// (set) Token: 0x06004604 RID: 17924 RVA: 0x0008CA19 File Offset: 0x0008AC19
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float DetectionRadius
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCaughtBinding.__PropertyOffset_DetectionRadius);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCaughtBinding.__PropertyOffset_DetectionRadius) = value;
		}
	}

	// Token: 0x06004605 RID: 17925 RVA: 0x0008CA2C File Offset: 0x0008AC2C
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

	// Token: 0x06004606 RID: 17926 RVA: 0x0008CAD4 File Offset: 0x0008ACD4
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
		Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
		if (entity == null)
		{
			return false;
		}
		CharacterBuffComponent component = entity.GetComponent<CharacterBuffComponent>();
		long? caughtBindingAnsInfo = (component != null) ? component.CreateAnimNotifyContent(animation.GetName(), base.exportIndex) : null;
		CharacterSkillComponent component2 = entity.GetComponent<CharacterSkillComponent>();
		CharacterCaughtNewComponent component3 = entity.GetComponent<CharacterCaughtNewComponent>();
		if (component3 != null)
		{
			if (this.DetectionRadius > 0f)
			{
				this.CheckPosition(component3);
			}
			component3.SetCaughtBindingAnsInfo(caughtBindingAnsInfo);
			CharacterCaughtNewComponent characterCaughtNewComponent = component3;
			TArray<string> caughtIds = this.CaughtIds;
			int? num;
			if (component2 == null)
			{
				num = null;
			}
			else
			{
				Skill currentSkill = component2.CurrentSkill;
				num = ((currentSkill != null) ? new int?(currentSkill.SkillId) : null);
			}
			int? num2 = num;
			characterCaughtNewComponent.BeginCaught(caughtIds, num2.GetValueOrDefault());
			return true;
		}
		return false;
	}

	// Token: 0x06004607 RID: 17927 RVA: 0x0008CBAC File Offset: 0x0008ADAC
	private void CheckPosition(CharacterCaughtNewComponent caughtComponent)
	{
		for (int i = 0; i < this.CaughtIds.Num(); i++)
		{
			string key = this.CaughtIds.Get(i);
			CharacterActorComponent component = caughtComponent.Entity.GetComponent<CharacterActorComponent>();
			if (component == null)
			{
				return;
			}
			ValueTuple<Entity, long, float> valueTuple;
			if (!caughtComponent.PendingCaughtList.TryGetValue(key, out valueTuple))
			{
				return;
			}
			TsAnimNotifyStateCaughtBinding.InitTrace();
			global::Vector actorLocationProxy = component.ActorLocationProxy;
			UTraceSphereElement sphereTrace = TsAnimNotifyStateCaughtBinding._sphereTrace;
			Singleton<TraceElementCommon>.Instance.SetStartLocation(sphereTrace, actorLocationProxy);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(sphereTrace, actorLocationProxy);
			sphereTrace.Radius = this.DetectionRadius;
			if (!Singleton<TraceElementCommon>.Instance.SphereTrace(sphereTrace, "FightCameraLogicComponent_CheckCollision_ExecutionAdjust"))
			{
				return;
			}
			bool flag = false;
			UKuroHitResult hitResult = sphereTrace.HitResult;
			TArray<int> itemArray = hitResult.ItemArray;
			for (int j = 0; j < hitResult.GetHitCount(); j++)
			{
				int instanceIndex = itemArray.Get(j);
				if (UKuroCollisionLibrary.GetCollisionProfileName(hitResult.Components.Get(j), instanceIndex).ToString().Contains("InvisibleWall"))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return;
			}
			CreatureDataComponent component2 = valueTuple.Item1.GetComponent<CreatureDataComponent>();
			if (component2 != null && component2.GetEntityType() == EEntityType.Monster)
			{
				global::Vector vector = global::Vector.Create(component2.GetInitLocation());
				global::Vector inB = global::Vector.Create(actorLocationProxy);
				global::Vector vector2 = global::Vector.Create();
				vector.Subtraction(inB, vector2);
				vector2.Normalize(9.99999993922529E-09);
				vector2.Multiply((double)this.DetectionRadius, vector2);
				global::Vector vector3 = global::Vector.Create(component.ActorLocation).AdditionEqual(vector2);
				component.SetActorLocation(vector3.ToUeVector(false), "ExecutionAdjustMove", false);
				CharacterActorComponent component3 = valueTuple.Item1.GetComponent<CharacterActorComponent>();
				if (component3 == null)
				{
					return;
				}
				global::Vector vector4 = global::Vector.Create(component3.ActorLocation).AdditionEqual(vector2);
				component3.SetActorLocation(vector4.ToUeVector(false), "ExecutionAdjustMove", false);
			}
		}
	}

	// Token: 0x06004608 RID: 17928 RVA: 0x0008CDA4 File Offset: 0x0008AFA4
	public static void InitTrace()
	{
		TsAnimNotifyStateCaughtBinding._sphereTrace = new UTraceSphereElement();
		TsAnimNotifyStateCaughtBinding._sphereTrace.bIsSingle = false;
		TsAnimNotifyStateCaughtBinding._sphereTrace.bIgnoreSelf = true;
		TsAnimNotifyStateCaughtBinding._sphereTrace.bTraceComplex = true;
		TsAnimNotifyStateCaughtBinding._sphereTrace.AddObjectTypeQuery(KuroObjectTypeQuery.WorldStatic);
		TsAnimNotifyStateCaughtBinding._sphereTrace.AddObjectTypeQuery(KuroObjectTypeQuery.WorldStaticIgnoreBullet);
		TsAnimNotifyStateCaughtBinding._sphereTrace.WorldContextObject = GlobalData.World;
	}

	// Token: 0x06004609 RID: 17929 RVA: 0x0008CE0C File Offset: 0x0008B00C
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

	// Token: 0x0600460A RID: 17930 RVA: 0x0008CEAC File Offset: 0x0008B0AC
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		if (tsBaseCharacter.CharacterActorComponent == null)
		{
			return false;
		}
		Entity entity = tsBaseCharacter.CharacterActorComponent.Entity;
		if (entity == null)
		{
			return false;
		}
		CharacterCaughtNewComponent component = entity.GetComponent<CharacterCaughtNewComponent>();
		if (component != null)
		{
			component.EndCaught();
			return true;
		}
		return false;
	}

	// Token: 0x0600460B RID: 17931 RVA: 0x0008CEF8 File Offset: 0x0008B0F8
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

	// Token: 0x0600460C RID: 17932 RVA: 0x0008CF73 File Offset: 0x0008B173
	protected override string GetNotifyName_Implementation()
	{
		return "抓取绑定";
	}

	// Token: 0x0600460D RID: 17933 RVA: 0x0008CF7A File Offset: 0x0008B17A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateCaughtBinding._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateCaughtBinding.TsAnimNotifyStateCaughtBinding_C");
		}
		return TsAnimNotifyStateCaughtBinding._ClassPtr;
	}

	// Token: 0x0600460E RID: 17934 RVA: 0x0008CFA0 File Offset: 0x0008B1A0
	public TsAnimNotifyStateCaughtBinding() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateCaughtBinding.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600460F RID: 17935 RVA: 0x0008CFC8 File Offset: 0x0008B1C8
	public TsAnimNotifyStateCaughtBinding(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateCaughtBinding.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004610 RID: 17936 RVA: 0x0008CFFB File Offset: 0x0008B1FB
	protected TsAnimNotifyStateCaughtBinding(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004611 RID: 17937 RVA: 0x0008D004 File Offset: 0x0008B204
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004612 RID: 17938 RVA: 0x0008D040 File Offset: 0x0008B240
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004613 RID: 17939 RVA: 0x0008D073 File Offset: 0x0008B273
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040012DB RID: 4827
	private const string PROFILE_KEY = "FightCameraLogicComponent_CheckCollision_ExecutionAdjust";

	// Token: 0x040012DC RID: 4828
	private const string AIRWALL_PORFILENAME = "InvisibleWall";

	// Token: 0x040012DD RID: 4829
	[Nullable(2)]
	private static UTraceSphereElement _sphereTrace;

	// Token: 0x040012DE RID: 4830
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateCaughtBinding.TsAnimNotifyStateCaughtBinding_C";

	// Token: 0x040012DF RID: 4831
	private static IntPtr _ClassPtr;

	// Token: 0x040012E0 RID: 4832
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040012E1 RID: 4833
	private static int __PropertyOffset_CaughtIds;

	// Token: 0x040012E2 RID: 4834
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<string> _CaughtIds;

	// Token: 0x040012E3 RID: 4835
	private static int __PropertyOffset_DetectionRadius;
}
