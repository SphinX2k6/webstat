using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DA6 RID: 3494
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyAirAttack.TsAnimNotifyAirAttack_C")]
public class TsAnimNotifyAirAttack : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170004DC RID: 1244
	// (get) Token: 0x06004E71 RID: 20081 RVA: 0x000B2D23 File Offset: 0x000B0F23
	// (set) Token: 0x06004E72 RID: 20082 RVA: 0x000B2D33 File Offset: 0x000B0F33
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Speed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyAirAttack.__PropertyOffset_Speed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyAirAttack.__PropertyOffset_Speed) = value;
		}
	}

	// Token: 0x170004DD RID: 1245
	// (get) Token: 0x06004E73 RID: 20083 RVA: 0x000B2D44 File Offset: 0x000B0F44
	// (set) Token: 0x06004E74 RID: 20084 RVA: 0x000B2D54 File Offset: 0x000B0F54
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Offset
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyAirAttack.__PropertyOffset_Offset);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyAirAttack.__PropertyOffset_Offset) = value;
		}
	}

	// Token: 0x170004DE RID: 1246
	// (get) Token: 0x06004E75 RID: 20085 RVA: 0x000B2D65 File Offset: 0x000B0F65
	// (set) Token: 0x06004E76 RID: 20086 RVA: 0x000B2D75 File Offset: 0x000B0F75
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MaxDistance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyAirAttack.__PropertyOffset_MaxDistance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyAirAttack.__PropertyOffset_MaxDistance) = value;
		}
	}

	// Token: 0x170004DF RID: 1247
	// (get) Token: 0x06004E77 RID: 20087 RVA: 0x000B2D86 File Offset: 0x000B0F86
	// (set) Token: 0x06004E78 RID: 20088 RVA: 0x000B2D96 File Offset: 0x000B0F96
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MinTan
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyAirAttack.__PropertyOffset_MinTan);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyAirAttack.__PropertyOffset_MinTan) = value;
		}
	}

	// Token: 0x170004E0 RID: 1248
	// (get) Token: 0x06004E79 RID: 20089 RVA: 0x000B2DA7 File Offset: 0x000B0FA7
	// (set) Token: 0x06004E7A RID: 20090 RVA: 0x000B2DB7 File Offset: 0x000B0FB7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MaxTan
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyAirAttack.__PropertyOffset_MaxTan);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyAirAttack.__PropertyOffset_MaxTan) = value;
		}
	}

	// Token: 0x170004E1 RID: 1249
	// (get) Token: 0x06004E7B RID: 20091 RVA: 0x000B2DC8 File Offset: 0x000B0FC8
	// (set) Token: 0x06004E7C RID: 20092 RVA: 0x000B2DD8 File Offset: 0x000B0FD8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MaxTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyAirAttack.__PropertyOffset_MaxTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyAirAttack.__PropertyOffset_MaxTime) = value;
		}
	}

	// Token: 0x170004E2 RID: 1250
	// (get) Token: 0x06004E7D RID: 20093 RVA: 0x000B2DE9 File Offset: 0x000B0FE9
	// (set) Token: 0x06004E7E RID: 20094 RVA: 0x000B2DF9 File Offset: 0x000B0FF9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DrawDebug
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyAirAttack.__PropertyOffset_DrawDebug) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyAirAttack.__PropertyOffset_DrawDebug) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004E7F RID: 20095 RVA: 0x000B2E0C File Offset: 0x000B100C
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_Notify(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_Notify"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotify.__K2_Notify_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotify.__K2_Notify_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotify.__K2_Notify_FunctionParams) & -16L);
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

	// Token: 0x06004E80 RID: 20096 RVA: 0x000B2EAC File Offset: 0x000B10AC
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
		BaseMoveComponent baseMoveComponent = (characterActorComponent != null) ? characterActorComponent.Entity.GetComponent<BaseMoveComponent>() : null;
		BaseAbilityComponent baseAbilityComponent = (characterActorComponent != null) ? characterActorComponent.Entity.GetComponent<BaseAbilityComponent>() : null;
		if (characterActorComponent == null || baseMoveComponent == null || baseAbilityComponent == null)
		{
			return false;
		}
		if (this.Speed <= 0f)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
			Entity entity = characterActorComponent.Entity;
			string message = "下落攻击速度配置必须大于0";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("速度", this.Speed);
			instance.Error(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		if (this.MaxDistance < 0f)
		{
			CombatLog instance2 = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.Skill;
			Entity entity2 = characterActorComponent.Entity;
			string message2 = "下落攻击最大距离配置必须大于0";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("最大距离", this.MaxDistance);
			instance2.Error(flag2, entity2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return false;
		}
		BaseSkillComponent component = characterActorComponent.Entity.GetComponent<BaseSkillComponent>();
		EntityHandle entityHandle = (component != null) ? component.SkillTarget : null;
		if (entityHandle == null || !entityHandle.Valid)
		{
			this.SetVerticalSpeed(baseMoveComponent, baseAbilityComponent);
			return true;
		}
		BaseActorComponent component2 = entityHandle.Entity.GetComponent<BaseActorComponent>();
		Vector actorLocationProxy = component2.ActorLocationProxy;
		CharacterActorComponent characterActorComponent2 = component2 as CharacterActorComponent;
		if (characterActorComponent2 != null)
		{
			baseMoveComponent.GravityUp.Multiply((double)characterActorComponent2.ScaledHalfHeight, this.TempVector1);
			actorLocationProxy.Subtraction(this.TempVector1, this.TempVector1);
		}
		else
		{
			this.TempVector1.DeepCopy(actorLocationProxy);
		}
		Vector actorLocationProxy2 = characterActorComponent.ActorLocationProxy;
		baseMoveComponent.GravityUp.Multiply((double)characterActorComponent.ScaledHalfHeight, this.TempVector2);
		actorLocationProxy2.Subtraction(this.TempVector2, this.TempVector2);
		double distSquared2dForActor = Singleton<GravityUtils>.Instance.GetDistSquared2dForActor(characterActorComponent, this.TempVector1, this.TempVector2);
		this.TempVector1.SubtractionEqual(this.TempVector2);
		double num = Math.Sqrt(this.TempVector1.SizeSquared() - distSquared2dForActor);
		double num2 = Math.Sqrt(distSquared2dForActor);
		num2 -= (double)this.Offset;
		num2 = Singleton<MathUtils>.Instance.Clamp(num2, 0.0, (double)this.MaxDistance);
		double num3 = Math.Atan2(num2, num);
		float num4 = Singleton<MathUtils>.Instance.Clamp(this.MinTan, 0f, 90f) * 0.017453292f;
		float num5 = Singleton<MathUtils>.Instance.Clamp(this.MaxTan, 0f, 90f) * 0.017453292f;
		num3 = Singleton<MathUtils>.Instance.Clamp(num3, (double)num4, (double)num5);
		Vector actorForwardProxy = characterActorComponent.ActorForwardProxy;
		double num6 = num * Math.Tan(num3);
		actorForwardProxy.Multiply(num6, this.TempVector1);
		baseMoveComponent.GravityDirect.Multiply(num, this.TempVector3);
		this.TempVector3.AdditionEqual(this.TempVector1);
		this.TempVector3.AdditionEqual(this.TempVector2);
		this.Draw(this.TempVector2, this.TempVector3);
		double inB = (double)this.Speed * Math.Tan(num3);
		actorForwardProxy.Multiply(inB, this.TempVector1);
		float speed = this.Speed;
		baseMoveComponent.GravityDirect.Multiply((double)speed, this.TempVector3);
		this.TempVector3.Addition(this.TempVector1, this.TempVector1);
		this.TempVector1.Multiply((double)this.MaxTime, this.TempVector3);
		this.TempVector2.Addition(this.TempVector3, this.TempVector3);
		if (!this.IsHit(this.TempVector2, this.TempVector3))
		{
			this.SetVerticalSpeed(baseMoveComponent, baseAbilityComponent);
			return true;
		}
		this.SetSlopeSpeed(baseMoveComponent, baseAbilityComponent, num3, num6, num, this.TempVector1);
		return true;
	}

	// Token: 0x06004E81 RID: 20097 RVA: 0x000B3244 File Offset: 0x000B1444
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotify.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotify.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotify.__GetNotifyName_FunctionParams) & -16L);
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

	// Token: 0x06004E82 RID: 20098 RVA: 0x000B32BF File Offset: 0x000B14BF
	protected override string GetNotifyName_Implementation()
	{
		return "空中攻击位移";
	}

	// Token: 0x06004E83 RID: 20099 RVA: 0x000B32C8 File Offset: 0x000B14C8
	private void Draw(Vector start, Vector end)
	{
		if (!this.DrawDebug)
		{
			return;
		}
		UKismetSystemLibrary.D_DrawDebugArrow(GlobalData.World, start.ToUeVector(false), end.ToUeVector(false), 15f, new FLinearColor(1f, 0f, 0f, 1f), 5f, 5f);
	}

	// Token: 0x06004E84 RID: 20100 RVA: 0x000B3320 File Offset: 0x000B1520
	private bool IsHit(Vector start, Vector end)
	{
		UTraceLineElement staticLineTrace = SkillUtils.GetStaticLineTrace();
		Singleton<TraceElementCommon>.Instance.SetStartLocation(staticLineTrace, start);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(staticLineTrace, end);
		return Singleton<TraceElementCommon>.Instance.LineTrace(staticLineTrace, "TsAnimNotifyAirAttack.IsHit") && staticLineTrace.HitResult.bBlockingHit;
	}

	// Token: 0x06004E85 RID: 20101 RVA: 0x000B336C File Offset: 0x000B156C
	private void SetVerticalSpeed(BaseMoveComponent moveComp, BaseAbilityComponent abilityComp)
	{
		moveComp.GravityDirect.Multiply((double)this.Speed, this.TempVector1);
		CombatLog instance = Singleton<CombatLog>.Instance;
		CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
		Entity entity = moveComp.Entity;
		string message = "空中攻击（垂直）";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("速度", this.TempVector1);
		instance.Info(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		moveComp.SetForceSpeed(this.TempVector1);
		abilityComp.SendGameplayEventToActor(GameplayTagUtils.GetGameplayTagById(GameplayTagDefine.EGameplayTagId["角色.Common.下落攻击状态.垂直下落攻击"]).Value, null);
	}

	// Token: 0x06004E86 RID: 20102 RVA: 0x000B33F0 File Offset: 0x000B15F0
	private unsafe void SetSlopeSpeed(BaseMoveComponent moveComp, BaseAbilityComponent abilityComp, double angle, double dist2dFinal, double deltaHeight, Vector speed)
	{
		CombatLog instance = Singleton<CombatLog>.Instance;
		CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
		Entity entity = moveComp.Entity;
		string message = "空中攻击（斜向）";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("夹角", angle * 57.295780181884766);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("水平距离", dist2dFinal);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("高度差", deltaHeight);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("速度向量", speed);
		instance.Info(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		moveComp.SetForceSpeed(speed);
		abilityComp.SendGameplayEventToActor(GameplayTagUtils.GetGameplayTagById(GameplayTagDefine.EGameplayTagId["角色.Common.下落攻击状态.斜向下落攻击"]).Value, null);
	}

	// Token: 0x06004E87 RID: 20103 RVA: 0x000B34CA File Offset: 0x000B16CA
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyAirAttack._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyAirAttack.TsAnimNotifyAirAttack_C");
		}
		return TsAnimNotifyAirAttack._ClassPtr;
	}

	// Token: 0x06004E88 RID: 20104 RVA: 0x000B34F0 File Offset: 0x000B16F0
	public TsAnimNotifyAirAttack() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyAirAttack.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004E89 RID: 20105 RVA: 0x000B3518 File Offset: 0x000B1718
	public TsAnimNotifyAirAttack(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyAirAttack.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004E8A RID: 20106 RVA: 0x000B354B File Offset: 0x000B174B
	protected TsAnimNotifyAirAttack(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004E8B RID: 20107 RVA: 0x000B3578 File Offset: 0x000B1778
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004E8C RID: 20108 RVA: 0x000B35AB File Offset: 0x000B17AB
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040016BB RID: 5819
	private readonly Vector TempVector1 = Vector.Create();

	// Token: 0x040016BC RID: 5820
	private readonly Vector TempVector2 = Vector.Create();

	// Token: 0x040016BD RID: 5821
	private readonly Vector TempVector3 = Vector.Create();

	// Token: 0x040016BE RID: 5822
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyAirAttack.TsAnimNotifyAirAttack_C";

	// Token: 0x040016BF RID: 5823
	private static IntPtr _ClassPtr;

	// Token: 0x040016C0 RID: 5824
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040016C1 RID: 5825
	private static int __PropertyOffset_Speed;

	// Token: 0x040016C2 RID: 5826
	private static int __PropertyOffset_Offset;

	// Token: 0x040016C3 RID: 5827
	private static int __PropertyOffset_MaxDistance;

	// Token: 0x040016C4 RID: 5828
	private static int __PropertyOffset_MinTan;

	// Token: 0x040016C5 RID: 5829
	private static int __PropertyOffset_MaxTan;

	// Token: 0x040016C6 RID: 5830
	private static int __PropertyOffset_MaxTime;

	// Token: 0x040016C7 RID: 5831
	private static int __PropertyOffset_DrawDebug;
}
