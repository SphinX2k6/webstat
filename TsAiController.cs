using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.Json;
using Aki.Config;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.Monster.Common;
using CSharpScript.Game.AI.StateMachine;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D14 RID: 3348
[UClass("/Game/Aki/TypeScript/Game/AI/Controller/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/Controller/TsAiController.TsAiController_C")]
public class TsAiController : AKuroAIController, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000322 RID: 802
	// (get) Token: 0x06004351 RID: 17233 RVA: 0x0007EDFE File Offset: 0x0007CFFE
	// (set) Token: 0x06004352 RID: 17234 RVA: 0x0007EE12 File Offset: 0x0007D012
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	private unsafe UBehaviorTree BehaviorTree
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UBehaviorTree>(base.NativePtr / (IntPtr)sizeof(void*) + TsAiController.__PropertyOffset_BehaviorTree);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAiController.__PropertyOffset_BehaviorTree, value);
		}
	}

	// Token: 0x17000323 RID: 803
	// (get) Token: 0x06004353 RID: 17235 RVA: 0x0007EE27 File Offset: 0x0007D027
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UKuroStateMachineGroup StateMachineGroup
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UKuroStateMachineGroup>(base.NativePtr / (IntPtr)sizeof(void*) + TsAiController.__PropertyOffset_StateMachineGroup);
		}
	}

	// Token: 0x06004354 RID: 17236 RVA: 0x0007EE3B File Offset: 0x0007D03B
	[NullableContext(2)]
	public Entity GetEntity()
	{
		CharacterAiComponent charAiDesignComp = this.CharAiDesignComp;
		if (charAiDesignComp == null)
		{
			return null;
		}
		return charAiDesignComp.Entity;
	}

	// Token: 0x06004355 RID: 17237 RVA: 0x0007EE4E File Offset: 0x0007D04E
	[NullableContext(2)]
	public CharacterAiComponent GetAiComp()
	{
		return this.CharAiDesignComp;
	}

	// Token: 0x06004356 RID: 17238 RVA: 0x0007EE56 File Offset: 0x0007D056
	[NullableContext(2)]
	public bool SetupBehaviorTree(UBehaviorTree behaviorTree)
	{
		if (this.BehaviorTree == behaviorTree)
		{
			return false;
		}
		this.BehaviorTree = behaviorTree;
		base.RunBehaviorTree(behaviorTree);
		return true;
	}

	// Token: 0x06004357 RID: 17239 RVA: 0x0007EE74 File Offset: 0x0007D074
	[NullableContext(1)]
	public void InitAiController(CharacterAiComponent aiComp)
	{
		this.CharAiDesignComp = aiComp;
		this.AiController = aiComp.AiController;
		this.CharBuffComp = aiComp.Entity.GetComponent<CharacterBuffComponent>();
		this.CharTagComp = aiComp.Entity.GetComponent<BaseTagComponent>();
		this.CharStateMachineComp = aiComp.Entity.GetComponent<CharacterStateMachineNewComponent>();
	}

	// Token: 0x06004358 RID: 17240 RVA: 0x0007EEC8 File Offset: 0x0007D0C8
	public void DrawDebugLines(float deltaSeconds)
	{
		CharacterAiComponent charAiDesignComp = this.CharAiDesignComp;
		if (charAiDesignComp == null || !charAiDesignComp.Valid)
		{
			return;
		}
		global::Vector actorLocationProxy = this.AiController.CharActorComp.ActorLocationProxy;
		EntityHandle currentTarget = this.AiController.AiHateList.GetCurrentTarget();
		this.DrawPerception(actorLocationProxy, currentTarget);
		if (currentTarget != null && currentTarget.Valid)
		{
			CharacterActorComponent component = currentTarget.Entity.GetComponent<CharacterActorComponent>();
			this.DrawArrow(actorLocationProxy, component.ActorLocationProxy, TsAiController.targetLinkColor);
			AiAreaMemberData aiTeamAreaMemberData = this.AiController.AiTeam.GetAiTeamAreaMemberData(this.AiController);
			if (aiTeamAreaMemberData != null && aiTeamAreaMemberData.IsAttacker)
			{
				TsAiController.TmpVector.DeepCopy(actorLocationProxy);
				Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.AiController.CharActorComp, TsAiController.TmpVector, (double)this.AiController.CharActorComp.HalfHeight);
				UKismetSystemLibrary.D_DrawDebugBox(this, TsAiController.TmpVector.ToUeVector(false), new FVectorDouble(10.0, 10.0, 10.0), TsAiController.enemyLinkColor, this.AiController.CharActorComp.ActorRotation, 0f, 3f);
			}
			if (aiTeamAreaMemberData != null && aiTeamAreaMemberData.AreaIndex >= 0)
			{
				global::Vector tmpVector = TsAiController.TmpVector3;
				global::Vector tmpVector2 = TsAiController.TmpVector2;
				tmpVector.DeepCopy(actorLocationProxy);
				Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.AiController.CharActorComp, tmpVector, (double)(10f - this.AiController.CharActorComp.HalfHeight));
				float num = (aiTeamAreaMemberData.CachedControllerYaw + aiTeamAreaMemberData.AngleCenter) * 0.017453292f;
				tmpVector2.Set(Math.Cos((double)num) * (double)aiTeamAreaMemberData.DistanceCenter, Math.Sin((double)num) * (double)aiTeamAreaMemberData.DistanceCenter, 0.0);
				aiTeamAreaMemberData.Group.GravityQuat.RotateVector(tmpVector2, tmpVector2);
				tmpVector2.AdditionEqual(tmpVector);
				this.DrawArrow(tmpVector, tmpVector2, TsAiController.areaCenterColor);
			}
		}
	}

	// Token: 0x06004359 RID: 17241 RVA: 0x0007F0BC File Offset: 0x0007D2BC
	[NullableContext(1)]
	protected void DrawPerception(global::Vector myLocation, [Nullable(2)] EntityHandle currentTarget)
	{
		IAiPerception aiPerception = this.AiController.AiPerception;
		if (aiPerception != null)
		{
			foreach (int id in aiPerception.ShareAllyLink)
			{
				CharacterActorComponent characterActorComponentById = ControllerBase<CharacterController>.Instance.GetCharacterActorComponentById(id);
				if (characterActorComponentById != null)
				{
					this.DrawArrow(myLocation, characterActorComponentById.ActorLocationProxy, TsAiController.teamMemberLinkColor);
				}
			}
			foreach (int num in aiPerception.Allies)
			{
				if (!aiPerception.ShareAllyLink.Contains(num))
				{
					CharacterActorComponent characterActorComponentById2 = ControllerBase<CharacterController>.Instance.GetCharacterActorComponentById(num);
					if (characterActorComponentById2 != null)
					{
						this.DrawArrow(myLocation, characterActorComponentById2.ActorLocationProxy, TsAiController.allyLinkColor);
					}
				}
			}
			foreach (int num2 in aiPerception.AllEnemies)
			{
				if (currentTarget == null || !currentTarget.Valid || num2 != currentTarget.Id)
				{
					CharacterActorComponent characterActorComponentById3 = ControllerBase<CharacterController>.Instance.GetCharacterActorComponentById(num2);
					if (characterActorComponentById3 != null)
					{
						this.DrawArrow(myLocation, characterActorComponentById3.ActorLocationProxy, TsAiController.enemyLinkColor);
					}
				}
			}
			foreach (int id2 in aiPerception.Neutrals)
			{
				CharacterActorComponent characterActorComponentById4 = ControllerBase<CharacterController>.Instance.GetCharacterActorComponentById(id2);
				if (characterActorComponentById4 != null)
				{
					this.DrawArrow(myLocation, characterActorComponentById4.ActorLocationProxy, TsAiController.neutralLinkColor);
				}
			}
		}
		CharacterActorComponent charActorComp = this.AiController.CharActorComp;
		TsAiController.TmpVector.FromUeVector(this.AiController.CharAiDesignComp.HatredInitLocation);
		UKismetSystemLibrary.D_DrawDebugSphere(this, TsAiController.TmpVector.ToUeVector(false), 30f, 24, new FLinearColor?(TsAiController.initLocationColor), 0f, 0f);
		global::Vector tmpVector = TsAiController.TmpVector;
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(charActorComp, tmpVector, (double)(-(double)charActorComp.HalfHeight));
		AiHate value = this.AiController.AiHateList.AiHate.Value;
		global::Vector floorLocation = charActorComp.FloorLocation;
		UKismetSystemLibrary.D_DrawDebugSphere(this, floorLocation.ToUeVector(false), value.DisengageDistanceRange.Value.Min, 24, new FLinearColor?(TsAiController.minHateAreaColor), 0f, 0f);
		UKismetSystemLibrary.D_DrawDebugSphere(this, floorLocation.ToUeVector(false), value.DisengageDistanceRange.Value.Max, 24, new FLinearColor?(TsAiController.maxHateAreaColor), 0f, 0f);
		UKismetSystemLibrary.D_DrawDebugSphere(this, tmpVector.ToUeVector(false), value.DisengageBornDistance.Value.Min, 24, new FLinearColor?(TsAiController.minHateInitAreaColor), 0f, 0f);
		UKismetSystemLibrary.D_DrawDebugSphere(this, tmpVector.ToUeVector(false), value.DisengageBornDistance.Value.Max, 24, new FLinearColor?(TsAiController.maxHateInitAreaColor), 0f, 0f);
	}

	// Token: 0x0600435A RID: 17242 RVA: 0x0007F414 File Offset: 0x0007D614
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void OnStart()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnStart"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0600435B RID: 17243 RVA: 0x0007F484 File Offset: 0x0007D684
	protected void OnStart_Implementation()
	{
	}

	// Token: 0x0600435C RID: 17244 RVA: 0x0007F488 File Offset: 0x0007D688
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void 获取控制权时()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("获取控制权时"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0600435D RID: 17245 RVA: 0x0007F4F8 File Offset: 0x0007D6F8
	protected void 获取控制权时_Implementation()
	{
	}

	// Token: 0x0600435E RID: 17246 RVA: 0x0007F4FC File Offset: 0x0007D6FC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void 状态切换时(ECharacterState oldState, ECharacterState newState, bool isAutonomousProxy)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("状态切换时"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__状态切换时_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__状态切换时_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__状态切换时_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->oldState) = (byte)oldState;
			*(&ptr2->newState) = (byte)newState;
			ptr2->isAutonomousProxy = isAutonomousProxy;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0600435F RID: 17247 RVA: 0x0007F584 File Offset: 0x0007D784
	protected void 状态切换时_Implementation(ECharacterState oldState, ECharacterState newState, bool isAutonomousProxy)
	{
	}

	// Token: 0x06004360 RID: 17248 RVA: 0x0007F588 File Offset: 0x0007D788
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void 渲染状态改变时(bool wasRendered)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("渲染状态改变时"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__渲染状态改变时_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__渲染状态改变时_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__渲染状态改变时_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->wasRendered = wasRendered;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06004361 RID: 17249 RVA: 0x0007F5FE File Offset: 0x0007D7FE
	protected void 渲染状态改变时_Implementation(bool wasRendered)
	{
	}

	// Token: 0x06004362 RID: 17250 RVA: 0x0007F600 File Offset: 0x0007D800
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void AddComplicatedEventBinder(SAiConditions conditions, UKuroBooleanEventBinder eventBinder)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddComplicatedEventBinder"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AddComplicatedEventBinder_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AddComplicatedEventBinder_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AddComplicatedEventBinder_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			UnrealReflectionUtils.CopyNativeStruct(SAiConditions.StaticStruct(), &ptr2->conditions, (conditions != null) ? conditions.NativePtr : ((IntPtr)0), 1, false);
			*(&ptr2->eventBinder) = ((eventBinder != null) ? eventBinder.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06004363 RID: 17251 RVA: 0x0007F6A4 File Offset: 0x0007D8A4
	[NullableContext(1)]
	protected void AddComplicatedEventBinder_Implementation(SAiConditions conditions, UKuroBooleanEventBinder eventBinder)
	{
		if (this.AiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "Error Call AddComplicatedEventBinder";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("AIC", this);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.AiController.AiConditionEvents.AddConditionEvent(conditions, eventBinder);
	}

	// Token: 0x06004364 RID: 17252 RVA: 0x0007F6F4 File Offset: 0x0007D8F4
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void AddSceneItemDestroyEventBinder(float distance, UKuroActorEventBinder eventBinder)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddSceneItemDestroyEventBinder"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AddSceneItemDestroyEventBinder_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AddSceneItemDestroyEventBinder_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AddSceneItemDestroyEventBinder_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->distance = distance;
			*(&ptr2->eventBinder) = ((eventBinder != null) ? eventBinder.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06004365 RID: 17253 RVA: 0x0007F780 File Offset: 0x0007D980
	[NullableContext(1)]
	protected void AddSceneItemDestroyEventBinder_Implementation(float distance, UKuroActorEventBinder eventBinder)
	{
		if (this.AiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "Error Call AddSceneItemDestroyEventBinder";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("AIC", this);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.AiController.AiPerceptionEvents.AddSceneItemDestroyEvent(distance, eventBinder);
	}

	// Token: 0x06004366 RID: 17254 RVA: 0x0007F7D0 File Offset: 0x0007D9D0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void AddLevelVarBoolEventBinder(SAiLevelVar levelVar, UKuroBooleanEventBinder eventBinder)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddLevelVarBoolEventBinder"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AddLevelVarBoolEventBinder_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AddLevelVarBoolEventBinder_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AddLevelVarBoolEventBinder_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			UnrealReflectionUtils.CopyNativeStruct(SAiLevelVar.StaticStruct(), &ptr2->levelVar, (levelVar != null) ? levelVar.NativePtr : ((IntPtr)0), 1, false);
			*(&ptr2->eventBinder) = ((eventBinder != null) ? eventBinder.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06004367 RID: 17255 RVA: 0x0007F874 File Offset: 0x0007DA74
	[NullableContext(1)]
	protected void AddLevelVarBoolEventBinder_Implementation(SAiLevelVar levelVar, UKuroBooleanEventBinder eventBinder)
	{
		if (this.AiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.CH;
			string message = "Error Call AddLevelVarBoolEventBinder";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("AIC", this);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.AiController.AiLevelVarEvents.AddLevelVarEvent(levelVar, eventBinder);
	}

	// Token: 0x06004368 RID: 17256 RVA: 0x0007F8C4 File Offset: 0x0007DAC4
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void AddLevelVarIntEventBinder(SAiLevelVar levelVar, UKuroIntEventBinder eventBinder)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddLevelVarIntEventBinder"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AddLevelVarIntEventBinder_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AddLevelVarIntEventBinder_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AddLevelVarIntEventBinder_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			UnrealReflectionUtils.CopyNativeStruct(SAiLevelVar.StaticStruct(), &ptr2->levelVar, (levelVar != null) ? levelVar.NativePtr : ((IntPtr)0), 1, false);
			*(&ptr2->eventBinder) = ((eventBinder != null) ? eventBinder.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06004369 RID: 17257 RVA: 0x0007F968 File Offset: 0x0007DB68
	[NullableContext(1)]
	protected void AddLevelVarIntEventBinder_Implementation(SAiLevelVar levelVar, UKuroIntEventBinder eventBinder)
	{
		if (this.AiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.CH;
			string message = "Error Call AddLevelVarBoolEventBinder";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("AIC", this);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.AiController.AiLevelVarEvents.AddLevelVarEvent(levelVar, eventBinder);
	}

	// Token: 0x0600436A RID: 17258 RVA: 0x0007F9B8 File Offset: 0x0007DBB8
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void AddHateEventBinder(UKuroPerceptionEventBinder handler)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddHateEventBinder"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AddHateEventBinder_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AddHateEventBinder_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AddHateEventBinder_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->handler) = ((handler != null) ? handler.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0600436B RID: 17259 RVA: 0x0007FA3C File Offset: 0x0007DC3C
	[NullableContext(1)]
	protected void AddHateEventBinder_Implementation(UKuroPerceptionEventBinder handler)
	{
		AiController aiController = this.AiController;
		if (aiController == null)
		{
			return;
		}
		aiController.AiPerceptionEvents.AddAiHateEvent(handler);
	}

	// Token: 0x0600436C RID: 17260 RVA: 0x0007FA54 File Offset: 0x0007DC54
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void AddPerceptionEventBinder(UKuroPerceptionEventBinder handler)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddPerceptionEventBinder"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AddPerceptionEventBinder_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AddPerceptionEventBinder_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AddPerceptionEventBinder_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->handler) = ((handler != null) ? handler.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0600436D RID: 17261 RVA: 0x0007FAD8 File Offset: 0x0007DCD8
	[NullableContext(1)]
	protected void AddPerceptionEventBinder_Implementation(UKuroPerceptionEventBinder handler)
	{
		AiController aiController = this.AiController;
		if (aiController == null)
		{
			return;
		}
		aiController.AiPerceptionEvents.AddAiPerceptionEvent(handler, false, true, false);
	}

	// Token: 0x0600436E RID: 17262 RVA: 0x0007FAF4 File Offset: 0x0007DCF4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetPerceptionEventState(bool includeFriend, bool includeEnemy, bool includeNeutral)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetPerceptionEventState"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__SetPerceptionEventState_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__SetPerceptionEventState_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__SetPerceptionEventState_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->includeFriend = includeFriend;
			ptr2->includeEnemy = includeEnemy;
			ptr2->includeNeutral = includeNeutral;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0600436F RID: 17263 RVA: 0x0007FB78 File Offset: 0x0007DD78
	protected void SetPerceptionEventState_Implementation(bool includeFriend, bool includeEnemy, bool includeNeutral)
	{
		AiController aiController = this.AiController;
		if (aiController == null)
		{
			return;
		}
		aiController.AiPerceptionEvents.SetPerceptionEventState(includeFriend, includeEnemy, includeNeutral);
	}

	// Token: 0x06004370 RID: 17264 RVA: 0x0007FB94 File Offset: 0x0007DD94
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void AddHateOutRangeEventBinder(UKuroPerceptionEventBinder handler)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddHateOutRangeEventBinder"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AddHateOutRangeEventBinder_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AddHateOutRangeEventBinder_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AddHateOutRangeEventBinder_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->handler) = ((handler != null) ? handler.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06004371 RID: 17265 RVA: 0x0007FC18 File Offset: 0x0007DE18
	[NullableContext(1)]
	protected void AddHateOutRangeEventBinder_Implementation(UKuroPerceptionEventBinder handler)
	{
		AiController aiController = this.AiController;
		if (aiController == null)
		{
			return;
		}
		aiController.AiPerceptionEvents.AddAiHateOutRangeEvent(handler);
	}

	// Token: 0x06004372 RID: 17266 RVA: 0x0007FC30 File Offset: 0x0007DE30
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ActivateSkillGroup(int skillGroupIndex, bool activate)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ActivateSkillGroup"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__ActivateSkillGroup_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__ActivateSkillGroup_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__ActivateSkillGroup_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->skillGroupIndex = skillGroupIndex;
			ptr2->activate = activate;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06004373 RID: 17267 RVA: 0x0007FCAD File Offset: 0x0007DEAD
	protected void ActivateSkillGroup_Implementation(int skillGroupIndex, bool activate)
	{
		AiController aiController = this.AiController;
		if (((aiController != null) ? aiController.AiSkill : null) != null)
		{
			this.AiController.AiSkill.ActivateSkillGroup(skillGroupIndex, activate);
		}
	}

	// Token: 0x06004374 RID: 17268 RVA: 0x0007FCD8 File Offset: 0x0007DED8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void AddSkillCd(int skillInfoId, float cdAdd)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddSkillCd"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AddSkillCd_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AddSkillCd_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AddSkillCd_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->skillInfoId = skillInfoId;
			ptr2->cdAdd = cdAdd;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06004375 RID: 17269 RVA: 0x0007FD55 File Offset: 0x0007DF55
	protected void AddSkillCd_Implementation(int skillInfoId, float cdAdd)
	{
		AiController aiController = this.AiController;
		if (((aiController != null) ? aiController.AiSkill : null) != null)
		{
			this.AiController.AiSkill.AddSkillCd(skillInfoId, cdAdd);
		}
	}

	// Token: 0x06004376 RID: 17270 RVA: 0x0007FD80 File Offset: 0x0007DF80
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void AicApplyBuff(long buffId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AicApplyBuff"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AicApplyBuff_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AicApplyBuff_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AicApplyBuff_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->buffId = buffId;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06004377 RID: 17271 RVA: 0x0007FDF8 File Offset: 0x0007DFF8
	protected void AicApplyBuff_Implementation(long buffId)
	{
		CharacterBuffComponent charBuffComp = this.CharBuffComp;
		if (charBuffComp != null && charBuffComp.Valid)
		{
			this.CharBuffComp.AddBuffFromAi(this.AiController.AiCombatMessageId, buffId, new AddBuffParam
			{
				InstigatorId = this.CharBuffComp.CreatureDataId,
				Reason = "AIC蓝图添加buff(AicApplyBuff)"
			});
		}
	}

	// Token: 0x06004378 RID: 17272 RVA: 0x0007FE54 File Offset: 0x0007E054
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void AicApplyBuffToTarget(int targetId, long buffId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AicApplyBuffToTarget"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AicApplyBuffToTarget_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AicApplyBuffToTarget_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AicApplyBuffToTarget_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->targetId = targetId;
			ptr2->buffId = buffId;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06004379 RID: 17273 RVA: 0x0007FED4 File Offset: 0x0007E0D4
	protected void AicApplyBuffToTarget_Implementation(int targetId, long buffId)
	{
		BaseBuffComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseBuffComponent>(targetId);
		if (component != null)
		{
			CharacterBuffComponent charBuffComp = this.CharBuffComp;
			if (charBuffComp != null && charBuffComp.Valid)
			{
				component.AddBuffFromAi(this.AiController.AiCombatMessageId, buffId, new AddBuffParam
				{
					InstigatorId = this.CharBuffComp.CreatureDataId,
					Reason = "AIC蓝图添加buff(AicApplyBuffToTarget)"
				});
			}
		}
	}

	// Token: 0x0600437A RID: 17274 RVA: 0x0007FF38 File Offset: 0x0007E138
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void AicRemoveBuff(long buffId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AicRemoveBuff"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AicRemoveBuff_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AicRemoveBuff_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AicRemoveBuff_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->buffId = buffId;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0600437B RID: 17275 RVA: 0x0007FFB0 File Offset: 0x0007E1B0
	protected void AicRemoveBuff_Implementation(long buffId)
	{
		CharacterBuffComponent charBuffComp = this.CharBuffComp;
		if (charBuffComp != null && charBuffComp.Valid)
		{
			this.CharBuffComp.RemoveBuff(buffId, -1, "AIC蓝图移除buff（AIC Remove Buff）", null, null, null);
		}
	}

	// Token: 0x0600437C RID: 17276 RVA: 0x00080000 File Offset: 0x0007E200
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void AicAddTag(FGameplayTag tag)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AicAddTag"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AicAddTag_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AicAddTag_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AicAddTag_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->tag = tag;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0600437D RID: 17277 RVA: 0x00080076 File Offset: 0x0007E276
	protected void AicAddTag_Implementation(FGameplayTag tag)
	{
		BaseTagComponent charTagComp = this.CharTagComp;
		if (charTagComp != null && charTagComp.Valid)
		{
			this.CharTagComp.AddTag(new int?(tag.TagId()));
		}
	}

	// Token: 0x0600437E RID: 17278 RVA: 0x000800A4 File Offset: 0x0007E2A4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void AicRemoveTag(FGameplayTag tag)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AicRemoveTag"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AicRemoveTag_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AicRemoveTag_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AicRemoveTag_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->tag = tag;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0600437F RID: 17279 RVA: 0x0008011C File Offset: 0x0007E31C
	protected void AicRemoveTag_Implementation(FGameplayTag tag)
	{
		BaseTagComponent charTagComp = this.CharTagComp;
		if (charTagComp != null && charTagComp.Valid)
		{
			this.CharTagComp.RemoveTag(new int?(tag.TagId()));
		}
		CharacterBuffComponent charBuffComp = this.CharBuffComp;
		if (charBuffComp != null && charBuffComp.Valid)
		{
			this.CharBuffComp.RemoveBuffByTag(new int?(tag.TagId()), "AIC蓝图移除buff", null);
		}
	}

	// Token: 0x06004380 RID: 17280 RVA: 0x0008018C File Offset: 0x0007E38C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetBattleWanderTime(float min, float max)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetBattleWanderTime"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__SetBattleWanderTime_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__SetBattleWanderTime_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__SetBattleWanderTime_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->min = min;
			ptr2->max = max;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06004381 RID: 17281 RVA: 0x0008020C File Offset: 0x0007E40C
	protected void SetBattleWanderTime_Implementation(float min, float max)
	{
		AiWanderInfos aiWanderInfos = this.AiController.AiWanderInfos;
		if (((aiWanderInfos != null) ? aiWanderInfos.AiBattleWanderGroups : null) == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.AI;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "没有配置战斗游荡，不能设置战斗游荡时长";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("AiBaseConfigId", this.AiController.AiBase.Value.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.AiController.AiWanderInfos.SetOverrideBattleWanderTime(min, max);
	}

	// Token: 0x06004382 RID: 17282 RVA: 0x00080288 File Offset: 0x0007E488
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetBattleWanderIndex(int index)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetBattleWanderIndex"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__SetBattleWanderIndex_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__SetBattleWanderIndex_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__SetBattleWanderIndex_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->index = index;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06004383 RID: 17283 RVA: 0x00080300 File Offset: 0x0007E500
	protected unsafe void SetBattleWanderIndex_Implementation(int index)
	{
		AiWanderInfos aiWanderInfos = this.AiController.AiWanderInfos;
		if (((aiWanderInfos != null) ? aiWanderInfos.AiBattleWanderGroups : null) == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.AI;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "没有配置战斗游荡，不能设置战斗游荡组";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("AiBaseConfigId", this.AiController.AiBase.Value.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (index < 0 || this.AiController.AiWanderInfos.AiBattleWanderGroups.Count <= index)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.AI;
			ELogAuthor author2 = ELogAuthor.LCZ;
			string message2 = "设置战斗游荡组不合法";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("AiBaseConfigId", this.AiController.AiBase.Value.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TargetIndex", index);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		this.AiController.AiWanderInfos.CurrentBattleWanderIndex = index;
	}

	// Token: 0x06004384 RID: 17284 RVA: 0x0008040C File Offset: 0x0007E60C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void AddBattleWanderEndTime(float addTime)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddBattleWanderEndTime"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AddBattleWanderEndTime_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AddBattleWanderEndTime_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AddBattleWanderEndTime_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->addTime = addTime;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06004385 RID: 17285 RVA: 0x00080484 File Offset: 0x0007E684
	protected void AddBattleWanderEndTime_Implementation(float addTime)
	{
		AiWanderInfos aiWanderInfos = this.AiController.AiWanderInfos;
		if (((aiWanderInfos != null) ? aiWanderInfos.AiBattleWanderGroups : null) == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.AI;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "没有配置战斗游荡，不能增加游荡结束时间";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("AiBaseConfigId", this.AiController.AiBase.Value.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.AiController.AiWanderInfos.BattleWanderAddTime += addTime;
	}

	// Token: 0x06004386 RID: 17286 RVA: 0x00080508 File Offset: 0x0007E708
	[NullableContext(1)]
	private void DrawArrow(global::Vector from, global::Vector to, FLinearColor color)
	{
		to.Subtraction(from, TsAiController.TmpVector);
		double num = TsAiController.TmpVector.Size();
		TsAiController.TmpVector.MultiplyEqual((num - 20.0) / num);
		TsAiController.TmpVector.AdditionEqual(from);
		UKismetSystemLibrary.D_DrawDebugArrow(this, from.ToUeVector(false), TsAiController.TmpVector.ToUeVector(false), 100f, color, 0f, 3f);
	}

	// Token: 0x06004387 RID: 17287 RVA: 0x0008057C File Offset: 0x0007E77C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetAiSenseEnable(int index, bool enable)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetAiSenseEnable"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__SetAiSenseEnable_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__SetAiSenseEnable_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__SetAiSenseEnable_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->index = index;
			ptr2->enable = enable;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06004388 RID: 17288 RVA: 0x000805F9 File Offset: 0x0007E7F9
	protected void SetAiSenseEnable_Implementation(int index, bool enable)
	{
		IAiPerception aiPerception = this.AiController.AiPerception;
		if (aiPerception == null)
		{
			return;
		}
		aiPerception.SetAiSenseEnable(index, enable);
	}

	// Token: 0x06004389 RID: 17289 RVA: 0x00080614 File Offset: 0x0007E814
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void AddOrRemoveAiSense(int aiSenseId, bool add)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddOrRemoveAiSense"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AddOrRemoveAiSense_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AddOrRemoveAiSense_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AddOrRemoveAiSense_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->aiSenseId = aiSenseId;
			ptr2->add = add;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0600438A RID: 17290 RVA: 0x00080691 File Offset: 0x0007E891
	protected void AddOrRemoveAiSense_Implementation(int aiSenseId, bool add)
	{
		IAiPerception aiPerception = this.AiController.AiPerception;
		if (aiPerception == null)
		{
			return;
		}
		aiPerception.AddOrRemoveAiSense(aiSenseId, add);
	}

	// Token: 0x0600438B RID: 17291 RVA: 0x000806AC File Offset: 0x0007E8AC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void EnableAiSenseByType(int type, bool enable)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("EnableAiSenseByType"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__EnableAiSenseByType_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__EnableAiSenseByType_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__EnableAiSenseByType_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->type = type;
			ptr2->enable = enable;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0600438C RID: 17292 RVA: 0x00080729 File Offset: 0x0007E929
	protected void EnableAiSenseByType_Implementation(int type, bool enable)
	{
		IAiPerception aiPerception = this.AiController.AiPerception;
		if (aiPerception == null)
		{
			return;
		}
		aiPerception.EnableAiSenseByType(type, enable);
	}

	// Token: 0x0600438D RID: 17293 RVA: 0x00080744 File Offset: 0x0007E944
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetAiHateConfig(string configId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetAiHateConfig"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__SetAiHateConfig_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__SetAiHateConfig_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__SetAiHateConfig_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->configId), configId);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0600438E RID: 17294 RVA: 0x000807C0 File Offset: 0x0007E9C0
	[NullableContext(1)]
	protected void SetAiHateConfig_Implementation(string configId)
	{
		if (!string.IsNullOrEmpty(configId))
		{
			this.AiController.AiHateList.AiHate = ConfigBase<AiConfig>.Instance.LoadAiHate(int.Parse(configId));
			return;
		}
		this.AiController.AiHateList.AiHate = ConfigBase<AiConfig>.Instance.LoadAiHateByController(this.AiController, null, null);
	}

	// Token: 0x0600438F RID: 17295 RVA: 0x00080828 File Offset: 0x0007EA28
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ChangeHatred(int entityId, float rate, float abs)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ChangeHatred"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__ChangeHatred_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__ChangeHatred_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__ChangeHatred_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->entityId = entityId;
			ptr2->rate = rate;
			ptr2->abs = abs;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06004390 RID: 17296 RVA: 0x000808AC File Offset: 0x0007EAAC
	protected void ChangeHatred_Implementation(int entityId, float rate, float abs)
	{
		this.AiController.AiHateList.ChangeHatred(entityId, rate, abs);
	}

	// Token: 0x06004391 RID: 17297 RVA: 0x000808C4 File Offset: 0x0007EAC4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ClearHatred(int entityId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ClearHatred"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__ClearHatred_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__ClearHatred_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__ClearHatred_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->entityId = entityId;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06004392 RID: 17298 RVA: 0x0008093A File Offset: 0x0007EB3A
	protected void ClearHatred_Implementation(int entityId)
	{
		this.AiController.AiHateList.ClearHatred(entityId);
	}

	// Token: 0x06004393 RID: 17299 RVA: 0x00080950 File Offset: 0x0007EB50
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void BindPlayerDamageEvents()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("BindPlayerDamageEvents"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x06004394 RID: 17300 RVA: 0x000809C0 File Offset: 0x0007EBC0
	protected void BindPlayerDamageEvents_Implementation()
	{
		this.AiController.AiHateList.BindPlayerDamageEvents();
	}

	// Token: 0x06004395 RID: 17301 RVA: 0x000809D4 File Offset: 0x0007EBD4
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void AddAlertEventBinder(UKuroBooleanEventBinder eventBinder)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddAlertEventBinder"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AddAlertEventBinder_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AddAlertEventBinder_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AddAlertEventBinder_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->eventBinder) = ((eventBinder != null) ? eventBinder.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06004396 RID: 17302 RVA: 0x00080A58 File Offset: 0x0007EC58
	[NullableContext(1)]
	protected void AddAlertEventBinder_Implementation(UKuroBooleanEventBinder eventBinder)
	{
		this.AiController.AiAlert.CallbackEvent = eventBinder;
	}

	// Token: 0x06004397 RID: 17303 RVA: 0x00080A6C File Offset: 0x0007EC6C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetAiAlertConfig(string configId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetAiAlertConfig"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__SetAiAlertConfig_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__SetAiAlertConfig_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__SetAiAlertConfig_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->configId), configId);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06004398 RID: 17304 RVA: 0x00080AE8 File Offset: 0x0007ECE8
	[NullableContext(1)]
	protected void SetAiAlertConfig_Implementation(string configId)
	{
		if (!string.IsNullOrEmpty(configId))
		{
			this.AiController.AiAlert.AiAlertConfig = ConfigBase<AiConfig>.Instance.LoadAiAlert(configId);
			return;
		}
		this.AiController.AiAlert.AiAlertConfig = ConfigBase<AiConfig>.Instance.LoadAiAlert(this.AiController.AiBase.Value.GetSubBehaviorConfigs("AiAlert"));
	}

	// Token: 0x06004399 RID: 17305 RVA: 0x00080B50 File Offset: 0x0007ED50
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetAiEnable(bool enable, string key)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetAiEnable"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__SetAiEnable_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__SetAiEnable_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__SetAiEnable_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->enable = enable;
			FString.CopyFrom((void*)(&ptr2->key), key);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0600439A RID: 17306 RVA: 0x00080BD4 File Offset: 0x0007EDD4
	[NullableContext(1)]
	protected void SetAiEnable_Implementation(bool enable, string key)
	{
		string key2 = "TsAiController_" + key;
		if (enable)
		{
			this.CharAiDesignComp.EnableAi(key2);
			return;
		}
		this.CharAiDesignComp.DisableAi(key2);
	}

	// Token: 0x0600439B RID: 17307 RVA: 0x00080C0C File Offset: 0x0007EE0C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void TestChangeAi(string id)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("TestChangeAi"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__TestChangeAi_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__TestChangeAi_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__TestChangeAi_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->id), id);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0600439C RID: 17308 RVA: 0x00080C88 File Offset: 0x0007EE88
	[NullableContext(1)]
	protected void TestChangeAi_Implementation(string id)
	{
		this.CharAiDesignComp.LoadAiConfigs(int.Parse(id));
	}

	// Token: 0x0600439D RID: 17309 RVA: 0x00080C9C File Offset: 0x0007EE9C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void LogReport(int logId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("LogReport"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__LogReport_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__LogReport_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__LogReport_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->logId = logId;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0600439E RID: 17310 RVA: 0x00080D14 File Offset: 0x0007EF14
	protected void LogReport_Implementation(int logId)
	{
		Singleton<Log>.Instance.Error(ELogModule.BehaviorTree, ELogAuthor.ZJC, "埋点废弃,请删除相关配置", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0600439F RID: 17311 RVA: 0x00080D3C File Offset: 0x0007EF3C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual bool 逻辑主控()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("逻辑主控"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__逻辑主控_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__逻辑主控_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__逻辑主控_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x060043A0 RID: 17312 RVA: 0x00080DB1 File Offset: 0x0007EFB1
	protected bool 逻辑主控_Implementation()
	{
		return this.AiController.CharActorComp.IsAutonomousProxy;
	}

	// Token: 0x060043A1 RID: 17313 RVA: 0x00080DC4 File Offset: 0x0007EFC4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual bool 移动主控()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("移动主控"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__移动主控_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__移动主控_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__移动主控_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x060043A2 RID: 17314 RVA: 0x00080E39 File Offset: 0x0007F039
	protected bool 移动主控_Implementation()
	{
		return this.AiController.CharActorComp.IsMoveAutonomousProxy;
	}

	// Token: 0x060043A3 RID: 17315 RVA: 0x00080E4C File Offset: 0x0007F04C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual bool 检查状态机状态(ref TArray<string> states)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("检查状态机状态"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__检查状态机状态_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__检查状态机状态_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__检查状态机状态_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			TArray<string> tarray = states;
			if (tarray != null)
			{
				tarray.CopyTo(&ptr2->states, default(UScriptStructStackOnlyPtr));
			}
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		states = new TArray<string>(&ptr2->states, true, true);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x060043A4 RID: 17316 RVA: 0x00080EEF File Offset: 0x0007F0EF
	[NullableContext(1)]
	protected bool 检查状态机状态_Implementation(ref TArray<string> states)
	{
		return false;
	}

	// Token: 0x060043A5 RID: 17317 RVA: 0x00080EF4 File Offset: 0x0007F0F4
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void 切换状态机状态(ref TArray<string> states)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("切换状态机状态"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__切换状态机状态_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__切换状态机状态_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__切换状态机状态_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			TArray<string> tarray = states;
			if (tarray != null)
			{
				tarray.CopyTo(&ptr2->states, default(UScriptStructStackOnlyPtr));
			}
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		states = new TArray<string>(&ptr2->states, true, true);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x060043A6 RID: 17318 RVA: 0x00080F91 File Offset: 0x0007F191
	[NullableContext(1)]
	protected void 切换状态机状态_Implementation(ref TArray<string> states)
	{
	}

	// Token: 0x060043A7 RID: 17319 RVA: 0x00080F94 File Offset: 0x0007F194
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual bool GetCoolDownDone(int id)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetCoolDownDone"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__GetCoolDownDone_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__GetCoolDownDone_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__GetCoolDownDone_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->id = id;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x060043A8 RID: 17320 RVA: 0x00081010 File Offset: 0x0007F210
	protected bool GetCoolDownDone_Implementation(int id)
	{
		return this.AiController.GetCoolDownRemainTime(id) == 0.0;
	}

	// Token: 0x060043A9 RID: 17321 RVA: 0x0008102C File Offset: 0x0007F22C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual float GetCoolDownRemainTime(int id)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetCoolDownRemainTime"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__GetCoolDownRemainTime_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__GetCoolDownRemainTime_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__GetCoolDownRemainTime_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->id = id;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		float _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x060043AA RID: 17322 RVA: 0x000810A8 File Offset: 0x0007F2A8
	protected float GetCoolDownRemainTime_Implementation(int id)
	{
		return (float)this.AiController.GetCoolDownRemainTime(id);
	}

	// Token: 0x060043AB RID: 17323 RVA: 0x000810B8 File Offset: 0x0007F2B8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetCoolDown(int id, float cd)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetCoolDown"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__SetCoolDown_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__SetCoolDown_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__SetCoolDown_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->id = id;
			ptr2->cd = cd;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x060043AC RID: 17324 RVA: 0x00081138 File Offset: 0x0007F338
	protected void SetCoolDown_Implementation(int id, float cd)
	{
		double num = ModelBase<GameModeModel>.Instance.IsMulti ? Singleton<Time>.Instance.ServerTimeStamp : Singleton<Time>.Instance.WorldTime;
		this.AiController.SetCoolDownTime(id, num + (double)cd, true, "蓝图");
	}

	// Token: 0x060043AD RID: 17325 RVA: 0x00081180 File Offset: 0x0007F380
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void InitCooldownEvent(int id, UKuroBooleanEventBinder eventBinder)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("InitCooldownEvent"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__InitCooldownEvent_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__InitCooldownEvent_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__InitCooldownEvent_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->id = id;
			*(&ptr2->eventBinder) = ((eventBinder != null) ? eventBinder.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x060043AE RID: 17326 RVA: 0x0008120B File Offset: 0x0007F40B
	[NullableContext(1)]
	protected void InitCooldownEvent_Implementation(int id, UKuroBooleanEventBinder eventBinder)
	{
		this.AiController.InitCooldownTimer(id, eventBinder);
	}

	// Token: 0x060043AF RID: 17327 RVA: 0x0008121C File Offset: 0x0007F41C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void StartCooldownTimer(int id, float duration)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("StartCooldownTimer"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__StartCooldownTimer_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__StartCooldownTimer_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__StartCooldownTimer_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->id = id;
			ptr2->duration = duration;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x060043B0 RID: 17328 RVA: 0x0008129C File Offset: 0x0007F49C
	protected void StartCooldownTimer_Implementation(int id, float duration)
	{
		double num = ModelBase<GameModeModel>.Instance.IsMulti ? Singleton<Time>.Instance.ServerTimeStamp : Singleton<Time>.Instance.WorldTime;
		this.AiController.SetCoolDownTime(id, num + (double)duration, true, "蓝图AIC延迟节点");
	}

	// Token: 0x060043B1 RID: 17329 RVA: 0x000812E4 File Offset: 0x0007F4E4
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void GetDebugStateMachine(ref TArray<FText> output)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetDebugStateMachine"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__GetDebugStateMachine_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__GetDebugStateMachine_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__GetDebugStateMachine_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			TArray<FText> tarray = output;
			if (tarray != null)
			{
				tarray.CopyTo(&ptr2->output, default(UScriptStructStackOnlyPtr));
			}
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		output = new TArray<FText>(&ptr2->output, true, true);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x060043B2 RID: 17330 RVA: 0x00081384 File Offset: 0x0007F584
	[NullableContext(1)]
	protected void GetDebugStateMachine_Implementation(ref TArray<FText> output)
	{
		CharacterStateMachineNewComponent charStateMachineComp = this.CharStateMachineComp;
		if (charStateMachineComp != null)
		{
			AiStateMachineGroup stateMachineGroup = charStateMachineComp.StateMachineGroup;
			if (stateMachineGroup != null)
			{
				stateMachineGroup.RequestServerDebugInfo();
			}
		}
		CharacterStateMachineNewComponent charStateMachineComp2 = this.CharStateMachineComp;
		string[] array;
		if (charStateMachineComp2 == null)
		{
			array = null;
		}
		else
		{
			AiStateMachineGroup stateMachineGroup2 = charStateMachineComp2.StateMachineGroup;
			array = ((stateMachineGroup2 != null) ? stateMachineGroup2.ToString(false, false) : null);
		}
		string[] array2 = array;
		if (array2 != null)
		{
			foreach (string text in array2)
			{
				output.Add(text.ToString());
			}
		}
	}

	// Token: 0x060043B3 RID: 17331 RVA: 0x000813F8 File Offset: 0x0007F5F8
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual FText GetDebugText()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetDebugText"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__GetDebugText_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__GetDebugText_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__GetDebugText_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		FText result = new FText(&ptr2->__Result, true, true);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}

	// Token: 0x060043B4 RID: 17332 RVA: 0x00081478 File Offset: 0x0007F678
	[NullableContext(1)]
	protected FText GetDebugText_Implementation()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(83, 12);
		defaultInterpolatedStringHandler.AppendLiteral("激活的技能组：\n ");
		defaultInterpolatedStringHandler.AppendFormatted(JsonSerializer.Serialize<HashSet<int>>(this.AiController.AiSkill.ActiveSkillGroup, null));
		defaultInterpolatedStringHandler.AppendLiteral("\n");
		defaultInterpolatedStringHandler.AppendLiteral("技能CD：");
		defaultInterpolatedStringHandler.AppendFormatted(this.AiController.AiSkill.GetCdDebugString());
		defaultInterpolatedStringHandler.AppendLiteral("\n");
		defaultInterpolatedStringHandler.AppendLiteral("战斗游荡组：");
		AiWanderInfos aiWanderInfos = this.AiController.AiWanderInfos;
		defaultInterpolatedStringHandler.AppendFormatted<int?>((aiWanderInfos != null) ? new int?(aiWanderInfos.CurrentBattleWanderIndex) : null);
		defaultInterpolatedStringHandler.AppendLiteral("\n");
		defaultInterpolatedStringHandler.AppendLiteral("仇恨：\n");
		defaultInterpolatedStringHandler.AppendFormatted(this.AiController.AiHateList.GetHatredMapDebugText());
		defaultInterpolatedStringHandler.AppendLiteral("\n");
		defaultInterpolatedStringHandler.AppendLiteral("团队AI：\n");
		defaultInterpolatedStringHandler.AppendLiteral("逻辑主控：");
		defaultInterpolatedStringHandler.AppendFormatted<bool>(this.AiController.CharActorComp.IsAutonomousProxy);
		defaultInterpolatedStringHandler.AppendLiteral("\n");
		defaultInterpolatedStringHandler.AppendLiteral("移动主控：");
		defaultInterpolatedStringHandler.AppendFormatted<bool>(this.AiController.CharActorComp.IsMoveAutonomousProxy);
		defaultInterpolatedStringHandler.AppendLiteral("\n");
		defaultInterpolatedStringHandler.AppendLiteral("等待切换主控：");
		defaultInterpolatedStringHandler.AppendFormatted<bool>(this.AiController.IsWaitingSwitchControl());
		defaultInterpolatedStringHandler.AppendLiteral("\n");
		defaultInterpolatedStringHandler.AppendLiteral("感知：");
		IAiPerception aiPerception = this.AiController.AiPerception;
		defaultInterpolatedStringHandler.AppendFormatted((aiPerception != null) ? aiPerception.GetEnableAiSenseDebug() : null);
		defaultInterpolatedStringHandler.AppendLiteral("\n");
		defaultInterpolatedStringHandler.AppendLiteral("怪物仇恨组： ");
		defaultInterpolatedStringHandler.AppendFormatted<long?>(this.AiController.HatredGroupId);
		defaultInterpolatedStringHandler.AppendLiteral("\n");
		defaultInterpolatedStringHandler.AppendLiteral("部位血量: ");
		CharacterBuffComponent charBuffComp = this.CharBuffComp;
		string value;
		if (charBuffComp == null)
		{
			value = null;
		}
		else
		{
			Entity entity = charBuffComp.Entity;
			if (entity == null)
			{
				value = null;
			}
			else
			{
				CharacterPartComponent component = entity.GetComponent<CharacterPartComponent>();
				value = ((component != null) ? component.GetDebugText() : null);
			}
		}
		defaultInterpolatedStringHandler.AppendFormatted(value);
		defaultInterpolatedStringHandler.AppendLiteral("\n");
		defaultInterpolatedStringHandler.AppendLiteral("集群Id：");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.AiController.GetTeamLevelId());
		defaultInterpolatedStringHandler.AppendLiteral("\n");
		defaultInterpolatedStringHandler.AppendLiteral("阵营: ");
		Entity entity2 = this.GetEntity();
		ECamp? value2;
		if (entity2 == null)
		{
			value2 = null;
		}
		else
		{
			CreatureDataComponent component2 = entity2.GetComponent<CreatureDataComponent>();
			value2 = ((component2 != null) ? new ECamp?(component2.GetEntityCamp()) : null);
		}
		defaultInterpolatedStringHandler.AppendFormatted<ECamp?>(value2);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x060043B5 RID: 17333 RVA: 0x00081720 File Offset: 0x0007F920
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveDestroyed()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveDestroyed"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x060043B6 RID: 17334 RVA: 0x00081790 File Offset: 0x0007F990
	protected virtual void ReceiveDestroyed_Implementation()
	{
		if (!ObjectUtils.IsValid(this))
		{
			return;
		}
		this.Clear();
	}

	// Token: 0x060043B7 RID: 17335 RVA: 0x000817A1 File Offset: 0x0007F9A1
	public void Clear()
	{
		this.CharAiDesignComp = null;
		this.CharBuffComp = null;
		this.CharTagComp = null;
		this.AiController = null;
		this.BehaviorTree = null;
		this.CharStateMachineComp = null;
	}

	// Token: 0x060043B8 RID: 17336 RVA: 0x000817CD File Offset: 0x0007F9CD
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAiController._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/Controller/TsAiController.TsAiController_C");
		}
		return TsAiController._ClassPtr;
	}

	// Token: 0x060043B9 RID: 17337 RVA: 0x000817F4 File Offset: 0x0007F9F4
	public TsAiController() : this(BuiltinUtils.AllocNativeUObject(TsAiController.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060043BA RID: 17338 RVA: 0x0008181C File Offset: 0x0007FA1C
	[NullableContext(1)]
	public TsAiController(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAiController.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060043BB RID: 17339 RVA: 0x0008184F File Offset: 0x0007FA4F
	protected TsAiController(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060043BC RID: 17340 RVA: 0x00081858 File Offset: 0x0007FA58
	protected virtual void __CPPCALL_OnStart_Implementation()
	{
		this.OnStart_Implementation();
	}

	// Token: 0x060043BD RID: 17341 RVA: 0x00081860 File Offset: 0x0007FA60
	protected virtual void __CPPCALL_获取控制权时_Implementation()
	{
		this.获取控制权时_Implementation();
	}

	// Token: 0x060043BE RID: 17342 RVA: 0x00081868 File Offset: 0x0007FA68
	protected unsafe virtual void __CPPCALL_状态切换时_Implementation(TsAiController.__状态切换时_FunctionParams* __Params)
	{
		ECharacterState oldState = (ECharacterState)__Params->oldState;
		ECharacterState newState = (ECharacterState)__Params->newState;
		this.状态切换时_Implementation(oldState, newState, __Params->isAutonomousProxy);
	}

	// Token: 0x060043BF RID: 17343 RVA: 0x00081891 File Offset: 0x0007FA91
	protected unsafe virtual void __CPPCALL_渲染状态改变时_Implementation(TsAiController.__渲染状态改变时_FunctionParams* __Params)
	{
		this.渲染状态改变时_Implementation(__Params->wasRendered);
	}

	// Token: 0x060043C0 RID: 17344 RVA: 0x000818A0 File Offset: 0x0007FAA0
	protected unsafe virtual void __CPPCALL_AddComplicatedEventBinder_Implementation(TsAiController.__AddComplicatedEventBinder_FunctionParams* __Params)
	{
		SAiConditions conditions = new SAiConditions(&__Params->conditions, true, true);
		UKuroBooleanEventBinder orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroBooleanEventBinder>(__Params->eventBinder);
		this.AddComplicatedEventBinder_Implementation(conditions, orCreateUObjectByNativePointer);
	}

	// Token: 0x060043C1 RID: 17345 RVA: 0x000818D0 File Offset: 0x0007FAD0
	protected unsafe virtual void __CPPCALL_AddSceneItemDestroyEventBinder_Implementation(TsAiController.__AddSceneItemDestroyEventBinder_FunctionParams* __Params)
	{
		UKuroActorEventBinder orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroActorEventBinder>(__Params->eventBinder);
		this.AddSceneItemDestroyEventBinder_Implementation(__Params->distance, orCreateUObjectByNativePointer);
	}

	// Token: 0x060043C2 RID: 17346 RVA: 0x000818F8 File Offset: 0x0007FAF8
	protected unsafe virtual void __CPPCALL_AddLevelVarBoolEventBinder_Implementation(TsAiController.__AddLevelVarBoolEventBinder_FunctionParams* __Params)
	{
		SAiLevelVar levelVar = new SAiLevelVar(&__Params->levelVar, true, true);
		UKuroBooleanEventBinder orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroBooleanEventBinder>(__Params->eventBinder);
		this.AddLevelVarBoolEventBinder_Implementation(levelVar, orCreateUObjectByNativePointer);
	}

	// Token: 0x060043C3 RID: 17347 RVA: 0x00081928 File Offset: 0x0007FB28
	protected unsafe virtual void __CPPCALL_AddLevelVarIntEventBinder_Implementation(TsAiController.__AddLevelVarIntEventBinder_FunctionParams* __Params)
	{
		SAiLevelVar levelVar = new SAiLevelVar(&__Params->levelVar, true, true);
		UKuroIntEventBinder orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroIntEventBinder>(__Params->eventBinder);
		this.AddLevelVarIntEventBinder_Implementation(levelVar, orCreateUObjectByNativePointer);
	}

	// Token: 0x060043C4 RID: 17348 RVA: 0x00081958 File Offset: 0x0007FB58
	protected unsafe virtual void __CPPCALL_AddHateEventBinder_Implementation(TsAiController.__AddHateEventBinder_FunctionParams* __Params)
	{
		UKuroPerceptionEventBinder orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroPerceptionEventBinder>(__Params->handler);
		this.AddHateEventBinder_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x060043C5 RID: 17349 RVA: 0x00081978 File Offset: 0x0007FB78
	protected unsafe virtual void __CPPCALL_AddPerceptionEventBinder_Implementation(TsAiController.__AddPerceptionEventBinder_FunctionParams* __Params)
	{
		UKuroPerceptionEventBinder orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroPerceptionEventBinder>(__Params->handler);
		this.AddPerceptionEventBinder_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x060043C6 RID: 17350 RVA: 0x00081998 File Offset: 0x0007FB98
	protected unsafe virtual void __CPPCALL_SetPerceptionEventState_Implementation(TsAiController.__SetPerceptionEventState_FunctionParams* __Params)
	{
		this.SetPerceptionEventState_Implementation(__Params->includeFriend, __Params->includeEnemy, __Params->includeNeutral);
	}

	// Token: 0x060043C7 RID: 17351 RVA: 0x000819B4 File Offset: 0x0007FBB4
	protected unsafe virtual void __CPPCALL_AddHateOutRangeEventBinder_Implementation(TsAiController.__AddHateOutRangeEventBinder_FunctionParams* __Params)
	{
		UKuroPerceptionEventBinder orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroPerceptionEventBinder>(__Params->handler);
		this.AddHateOutRangeEventBinder_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x060043C8 RID: 17352 RVA: 0x000819D4 File Offset: 0x0007FBD4
	protected unsafe virtual void __CPPCALL_ActivateSkillGroup_Implementation(TsAiController.__ActivateSkillGroup_FunctionParams* __Params)
	{
		this.ActivateSkillGroup_Implementation(__Params->skillGroupIndex, __Params->activate);
	}

	// Token: 0x060043C9 RID: 17353 RVA: 0x000819E8 File Offset: 0x0007FBE8
	protected unsafe virtual void __CPPCALL_AddSkillCd_Implementation(TsAiController.__AddSkillCd_FunctionParams* __Params)
	{
		this.AddSkillCd_Implementation(__Params->skillInfoId, __Params->cdAdd);
	}

	// Token: 0x060043CA RID: 17354 RVA: 0x000819FC File Offset: 0x0007FBFC
	protected unsafe virtual void __CPPCALL_AicApplyBuff_Implementation(TsAiController.__AicApplyBuff_FunctionParams* __Params)
	{
		this.AicApplyBuff_Implementation(__Params->buffId);
	}

	// Token: 0x060043CB RID: 17355 RVA: 0x00081A0A File Offset: 0x0007FC0A
	protected unsafe virtual void __CPPCALL_AicApplyBuffToTarget_Implementation(TsAiController.__AicApplyBuffToTarget_FunctionParams* __Params)
	{
		this.AicApplyBuffToTarget_Implementation(__Params->targetId, __Params->buffId);
	}

	// Token: 0x060043CC RID: 17356 RVA: 0x00081A1E File Offset: 0x0007FC1E
	protected unsafe virtual void __CPPCALL_AicRemoveBuff_Implementation(TsAiController.__AicRemoveBuff_FunctionParams* __Params)
	{
		this.AicRemoveBuff_Implementation(__Params->buffId);
	}

	// Token: 0x060043CD RID: 17357 RVA: 0x00081A2C File Offset: 0x0007FC2C
	protected unsafe virtual void __CPPCALL_AicAddTag_Implementation(TsAiController.__AicAddTag_FunctionParams* __Params)
	{
		this.AicAddTag_Implementation(__Params->tag);
	}

	// Token: 0x060043CE RID: 17358 RVA: 0x00081A3A File Offset: 0x0007FC3A
	protected unsafe virtual void __CPPCALL_AicRemoveTag_Implementation(TsAiController.__AicRemoveTag_FunctionParams* __Params)
	{
		this.AicRemoveTag_Implementation(__Params->tag);
	}

	// Token: 0x060043CF RID: 17359 RVA: 0x00081A48 File Offset: 0x0007FC48
	protected unsafe virtual void __CPPCALL_SetBattleWanderTime_Implementation(TsAiController.__SetBattleWanderTime_FunctionParams* __Params)
	{
		this.SetBattleWanderTime_Implementation(__Params->min, __Params->max);
	}

	// Token: 0x060043D0 RID: 17360 RVA: 0x00081A5C File Offset: 0x0007FC5C
	protected unsafe virtual void __CPPCALL_SetBattleWanderIndex_Implementation(TsAiController.__SetBattleWanderIndex_FunctionParams* __Params)
	{
		this.SetBattleWanderIndex_Implementation(__Params->index);
	}

	// Token: 0x060043D1 RID: 17361 RVA: 0x00081A6A File Offset: 0x0007FC6A
	protected unsafe virtual void __CPPCALL_AddBattleWanderEndTime_Implementation(TsAiController.__AddBattleWanderEndTime_FunctionParams* __Params)
	{
		this.AddBattleWanderEndTime_Implementation(__Params->addTime);
	}

	// Token: 0x060043D2 RID: 17362 RVA: 0x00081A78 File Offset: 0x0007FC78
	protected unsafe virtual void __CPPCALL_SetAiSenseEnable_Implementation(TsAiController.__SetAiSenseEnable_FunctionParams* __Params)
	{
		this.SetAiSenseEnable_Implementation(__Params->index, __Params->enable);
	}

	// Token: 0x060043D3 RID: 17363 RVA: 0x00081A8C File Offset: 0x0007FC8C
	protected unsafe virtual void __CPPCALL_AddOrRemoveAiSense_Implementation(TsAiController.__AddOrRemoveAiSense_FunctionParams* __Params)
	{
		this.AddOrRemoveAiSense_Implementation(__Params->aiSenseId, __Params->add);
	}

	// Token: 0x060043D4 RID: 17364 RVA: 0x00081AA0 File Offset: 0x0007FCA0
	protected unsafe virtual void __CPPCALL_EnableAiSenseByType_Implementation(TsAiController.__EnableAiSenseByType_FunctionParams* __Params)
	{
		this.EnableAiSenseByType_Implementation(__Params->type, __Params->enable);
	}

	// Token: 0x060043D5 RID: 17365 RVA: 0x00081AB4 File Offset: 0x0007FCB4
	protected unsafe virtual void __CPPCALL_SetAiHateConfig_Implementation(TsAiController.__SetAiHateConfig_FunctionParams* __Params)
	{
		string aiHateConfig_Implementation = FString.ToString((void*)(&__Params->configId));
		this.SetAiHateConfig_Implementation(aiHateConfig_Implementation);
	}

	// Token: 0x060043D6 RID: 17366 RVA: 0x00081AD5 File Offset: 0x0007FCD5
	protected unsafe virtual void __CPPCALL_ChangeHatred_Implementation(TsAiController.__ChangeHatred_FunctionParams* __Params)
	{
		this.ChangeHatred_Implementation(__Params->entityId, __Params->rate, __Params->abs);
	}

	// Token: 0x060043D7 RID: 17367 RVA: 0x00081AEF File Offset: 0x0007FCEF
	protected unsafe virtual void __CPPCALL_ClearHatred_Implementation(TsAiController.__ClearHatred_FunctionParams* __Params)
	{
		this.ClearHatred_Implementation(__Params->entityId);
	}

	// Token: 0x060043D8 RID: 17368 RVA: 0x00081AFD File Offset: 0x0007FCFD
	protected virtual void __CPPCALL_BindPlayerDamageEvents_Implementation()
	{
		this.BindPlayerDamageEvents_Implementation();
	}

	// Token: 0x060043D9 RID: 17369 RVA: 0x00081B08 File Offset: 0x0007FD08
	protected unsafe virtual void __CPPCALL_AddAlertEventBinder_Implementation(TsAiController.__AddAlertEventBinder_FunctionParams* __Params)
	{
		UKuroBooleanEventBinder orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroBooleanEventBinder>(__Params->eventBinder);
		this.AddAlertEventBinder_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x060043DA RID: 17370 RVA: 0x00081B28 File Offset: 0x0007FD28
	protected unsafe virtual void __CPPCALL_SetAiAlertConfig_Implementation(TsAiController.__SetAiAlertConfig_FunctionParams* __Params)
	{
		string aiAlertConfig_Implementation = FString.ToString((void*)(&__Params->configId));
		this.SetAiAlertConfig_Implementation(aiAlertConfig_Implementation);
	}

	// Token: 0x060043DB RID: 17371 RVA: 0x00081B4C File Offset: 0x0007FD4C
	protected unsafe virtual void __CPPCALL_SetAiEnable_Implementation(TsAiController.__SetAiEnable_FunctionParams* __Params)
	{
		string key = FString.ToString((void*)(&__Params->key));
		this.SetAiEnable_Implementation(__Params->enable, key);
	}

	// Token: 0x060043DC RID: 17372 RVA: 0x00081B74 File Offset: 0x0007FD74
	protected unsafe virtual void __CPPCALL_TestChangeAi_Implementation(TsAiController.__TestChangeAi_FunctionParams* __Params)
	{
		string id = FString.ToString((void*)(&__Params->id));
		this.TestChangeAi_Implementation(id);
	}

	// Token: 0x060043DD RID: 17373 RVA: 0x00081B95 File Offset: 0x0007FD95
	protected unsafe virtual void __CPPCALL_LogReport_Implementation(TsAiController.__LogReport_FunctionParams* __Params)
	{
		this.LogReport_Implementation(__Params->logId);
	}

	// Token: 0x060043DE RID: 17374 RVA: 0x00081BA3 File Offset: 0x0007FDA3
	protected unsafe virtual void __CPPCALL_逻辑主控_Implementation(TsAiController.__逻辑主控_FunctionParams* __Params)
	{
		__Params->__Result = this.逻辑主控_Implementation();
	}

	// Token: 0x060043DF RID: 17375 RVA: 0x00081BB1 File Offset: 0x0007FDB1
	protected unsafe virtual void __CPPCALL_移动主控_Implementation(TsAiController.__移动主控_FunctionParams* __Params)
	{
		__Params->__Result = this.移动主控_Implementation();
	}

	// Token: 0x060043E0 RID: 17376 RVA: 0x00081BC0 File Offset: 0x0007FDC0
	protected unsafe virtual void __CPPCALL_检查状态机状态_Implementation(TsAiController.__检查状态机状态_FunctionParams* __Params)
	{
		TArray<string> tarray = new TArray<string>(&__Params->states, true, true);
		__Params->__Result = this.检查状态机状态_Implementation(ref tarray);
		if (tarray != null)
		{
			tarray.CopyTo(&__Params->states, default(UScriptStructStackOnlyPtr));
		}
	}

	// Token: 0x060043E1 RID: 17377 RVA: 0x00081C04 File Offset: 0x0007FE04
	protected unsafe virtual void __CPPCALL_切换状态机状态_Implementation(TsAiController.__切换状态机状态_FunctionParams* __Params)
	{
		TArray<string> tarray = new TArray<string>(&__Params->states, true, true);
		this.切换状态机状态_Implementation(ref tarray);
		if (tarray != null)
		{
			tarray.CopyTo(&__Params->states, default(UScriptStructStackOnlyPtr));
		}
	}

	// Token: 0x060043E2 RID: 17378 RVA: 0x00081C41 File Offset: 0x0007FE41
	protected unsafe virtual void __CPPCALL_GetCoolDownDone_Implementation(TsAiController.__GetCoolDownDone_FunctionParams* __Params)
	{
		__Params->__Result = this.GetCoolDownDone_Implementation(__Params->id);
	}

	// Token: 0x060043E3 RID: 17379 RVA: 0x00081C55 File Offset: 0x0007FE55
	protected unsafe virtual void __CPPCALL_GetCoolDownRemainTime_Implementation(TsAiController.__GetCoolDownRemainTime_FunctionParams* __Params)
	{
		__Params->__Result = this.GetCoolDownRemainTime_Implementation(__Params->id);
	}

	// Token: 0x060043E4 RID: 17380 RVA: 0x00081C69 File Offset: 0x0007FE69
	protected unsafe virtual void __CPPCALL_SetCoolDown_Implementation(TsAiController.__SetCoolDown_FunctionParams* __Params)
	{
		this.SetCoolDown_Implementation(__Params->id, __Params->cd);
	}

	// Token: 0x060043E5 RID: 17381 RVA: 0x00081C80 File Offset: 0x0007FE80
	protected unsafe virtual void __CPPCALL_InitCooldownEvent_Implementation(TsAiController.__InitCooldownEvent_FunctionParams* __Params)
	{
		UKuroBooleanEventBinder orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroBooleanEventBinder>(__Params->eventBinder);
		this.InitCooldownEvent_Implementation(__Params->id, orCreateUObjectByNativePointer);
	}

	// Token: 0x060043E6 RID: 17382 RVA: 0x00081CA6 File Offset: 0x0007FEA6
	protected unsafe virtual void __CPPCALL_StartCooldownTimer_Implementation(TsAiController.__StartCooldownTimer_FunctionParams* __Params)
	{
		this.StartCooldownTimer_Implementation(__Params->id, __Params->duration);
	}

	// Token: 0x060043E7 RID: 17383 RVA: 0x00081CBC File Offset: 0x0007FEBC
	protected unsafe virtual void __CPPCALL_GetDebugStateMachine_Implementation(TsAiController.__GetDebugStateMachine_FunctionParams* __Params)
	{
		TArray<FText> tarray = new TArray<FText>(&__Params->output, true, true);
		this.GetDebugStateMachine_Implementation(ref tarray);
		if (tarray != null)
		{
			tarray.CopyTo(&__Params->output, default(UScriptStructStackOnlyPtr));
		}
	}

	// Token: 0x060043E8 RID: 17384 RVA: 0x00081CF9 File Offset: 0x0007FEF9
	protected unsafe virtual void __CPPCALL_GetDebugText_Implementation(TsAiController.__GetDebugText_FunctionParams* __Params)
	{
		void* dest = (void*)(&__Params->__Result);
		FText debugText_Implementation = this.GetDebugText_Implementation();
		FText.NativeCopy(dest, (debugText_Implementation != null) ? debugText_Implementation.NativePtr : null, 1);
	}

	// Token: 0x060043E9 RID: 17385 RVA: 0x00081D1B File Offset: 0x0007FF1B
	protected virtual void __CPPCALL_ReceiveDestroyed_Implementation()
	{
		this.ReceiveDestroyed_Implementation();
	}

	// Token: 0x040011A7 RID: 4519
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly global::Vector TmpVector = global::Vector.Create();

	// Token: 0x040011A8 RID: 4520
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly global::Vector TmpVector2 = global::Vector.Create();

	// Token: 0x040011A9 RID: 4521
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly global::Vector TmpVector3 = global::Vector.Create();

	// Token: 0x040011AA RID: 4522
	[Nullable(2)]
	private CharacterAiComponent CharAiDesignComp;

	// Token: 0x040011AB RID: 4523
	[Nullable(2)]
	private BaseTagComponent CharTagComp;

	// Token: 0x040011AC RID: 4524
	[Nullable(2)]
	private CharacterBuffComponent CharBuffComp;

	// Token: 0x040011AD RID: 4525
	[Nullable(2)]
	private CharacterStateMachineNewComponent CharStateMachineComp;

	// Token: 0x040011AE RID: 4526
	[Nullable(2)]
	public AiController AiController;

	// Token: 0x040011AF RID: 4527
	private const float DRAW_ARROW_SIZE = 100f;

	// Token: 0x040011B0 RID: 4528
	private const float DRAW_LINE_THICKNESS = 3f;

	// Token: 0x040011B1 RID: 4529
	private const float ARROW_LENGTH_SUB = 20f;

	// Token: 0x040011B2 RID: 4530
	private const int DEFAULT_SEGMENTS = 24;

	// Token: 0x040011B3 RID: 4531
	[StaticVariableRuleIgnore]
	private static readonly FLinearColor initLocationColor = new FLinearColor(0.5f, 0.5f, 0.5f, 1f);

	// Token: 0x040011B4 RID: 4532
	[StaticVariableRuleIgnore]
	private static readonly FLinearColor targetLinkColor = new FLinearColor(1f, 0f, 0f, 1f);

	// Token: 0x040011B5 RID: 4533
	[StaticVariableRuleIgnore]
	private static readonly FLinearColor teamMemberLinkColor = new FLinearColor(0f, 1f, 0f, 1f);

	// Token: 0x040011B6 RID: 4534
	[StaticVariableRuleIgnore]
	private static readonly FLinearColor allyLinkColor = new FLinearColor(0.6f, 1f, 0.6f, 1f);

	// Token: 0x040011B7 RID: 4535
	[StaticVariableRuleIgnore]
	private static readonly FLinearColor neutralLinkColor = new FLinearColor(1f, 1f, 0f, 1f);

	// Token: 0x040011B8 RID: 4536
	[StaticVariableRuleIgnore]
	private static readonly FLinearColor enemyLinkColor = new FLinearColor(1f, 0f, 1f, 1f);

	// Token: 0x040011B9 RID: 4537
	[StaticVariableRuleIgnore]
	private static readonly FLinearColor areaCenterColor = new FLinearColor(0f, 1f, 1f, 1f);

	// Token: 0x040011BA RID: 4538
	[StaticVariableRuleIgnore]
	private static readonly FLinearColor minHateAreaColor = new FLinearColor(1f, 0f, 1f, 1f);

	// Token: 0x040011BB RID: 4539
	[StaticVariableRuleIgnore]
	private static readonly FLinearColor maxHateAreaColor = new FLinearColor(0f, 1f, 1f, 1f);

	// Token: 0x040011BC RID: 4540
	[StaticVariableRuleIgnore]
	private static readonly FLinearColor minHateInitAreaColor = new FLinearColor(1f, 0f, 0f, 1f);

	// Token: 0x040011BD RID: 4541
	[StaticVariableRuleIgnore]
	private static readonly FLinearColor maxHateInitAreaColor = new FLinearColor(0f, 1f, 0f, 1f);

	// Token: 0x040011BE RID: 4542
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly Stat StatSetAiHateConfig = Stat.Create("SetAiHateConfig", "", "");

	// Token: 0x040011BF RID: 4543
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/Controller/TsAiController.TsAiController_C";

	// Token: 0x040011C0 RID: 4544
	private static IntPtr _ClassPtr;

	// Token: 0x040011C1 RID: 4545
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040011C2 RID: 4546
	private static int __PropertyOffset_BehaviorTree;

	// Token: 0x040011C3 RID: 4547
	private static int __PropertyOffset_StateMachineGroup;

	// Token: 0x020071E3 RID: 29155
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 3)]
	protected ref struct __状态切换时_FunctionParams
	{
		// Token: 0x040279E6 RID: 162278
		[FieldOffset(0)]
		public byte oldState;

		// Token: 0x040279E7 RID: 162279
		[FieldOffset(1)]
		public byte newState;

		// Token: 0x040279E8 RID: 162280
		[FieldOffset(2)]
		public bool isAutonomousProxy;
	}

	// Token: 0x020071E4 RID: 29156
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __渲染状态改变时_FunctionParams
	{
		// Token: 0x040279E9 RID: 162281
		[FieldOffset(0)]
		public bool wasRendered;
	}

	// Token: 0x020071E5 RID: 29157
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 192)]
	protected ref struct __AddComplicatedEventBinder_FunctionParams
	{
		// Token: 0x040279EA RID: 162282
		[FieldOffset(0)]
		public byte conditions;

		// Token: 0x040279EB RID: 162283
		[FieldOffset(184)]
		public IntPtr eventBinder;
	}

	// Token: 0x020071E6 RID: 29158
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __AddSceneItemDestroyEventBinder_FunctionParams
	{
		// Token: 0x040279EC RID: 162284
		[FieldOffset(0)]
		public float distance;

		// Token: 0x040279ED RID: 162285
		[FieldOffset(8)]
		public IntPtr eventBinder;
	}

	// Token: 0x020071E7 RID: 29159
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __AddLevelVarBoolEventBinder_FunctionParams
	{
		// Token: 0x040279EE RID: 162286
		[FieldOffset(0)]
		public byte levelVar;

		// Token: 0x040279EF RID: 162287
		[FieldOffset(32)]
		public IntPtr eventBinder;
	}

	// Token: 0x020071E8 RID: 29160
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __AddLevelVarIntEventBinder_FunctionParams
	{
		// Token: 0x040279F0 RID: 162288
		[FieldOffset(0)]
		public byte levelVar;

		// Token: 0x040279F1 RID: 162289
		[FieldOffset(32)]
		public IntPtr eventBinder;
	}

	// Token: 0x020071E9 RID: 29161
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __AddHateEventBinder_FunctionParams
	{
		// Token: 0x040279F2 RID: 162290
		[FieldOffset(0)]
		public IntPtr handler;
	}

	// Token: 0x020071EA RID: 29162
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __AddPerceptionEventBinder_FunctionParams
	{
		// Token: 0x040279F3 RID: 162291
		[FieldOffset(0)]
		public IntPtr handler;
	}

	// Token: 0x020071EB RID: 29163
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 3)]
	protected ref struct __SetPerceptionEventState_FunctionParams
	{
		// Token: 0x040279F4 RID: 162292
		[FieldOffset(0)]
		public bool includeFriend;

		// Token: 0x040279F5 RID: 162293
		[FieldOffset(1)]
		public bool includeEnemy;

		// Token: 0x040279F6 RID: 162294
		[FieldOffset(2)]
		public bool includeNeutral;
	}

	// Token: 0x020071EC RID: 29164
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __AddHateOutRangeEventBinder_FunctionParams
	{
		// Token: 0x040279F7 RID: 162295
		[FieldOffset(0)]
		public IntPtr handler;
	}

	// Token: 0x020071ED RID: 29165
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __ActivateSkillGroup_FunctionParams
	{
		// Token: 0x040279F8 RID: 162296
		[FieldOffset(0)]
		public int skillGroupIndex;

		// Token: 0x040279F9 RID: 162297
		[FieldOffset(4)]
		public bool activate;
	}

	// Token: 0x020071EE RID: 29166
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __AddSkillCd_FunctionParams
	{
		// Token: 0x040279FA RID: 162298
		[FieldOffset(0)]
		public int skillInfoId;

		// Token: 0x040279FB RID: 162299
		[FieldOffset(4)]
		public float cdAdd;
	}

	// Token: 0x020071EF RID: 29167
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __AicApplyBuff_FunctionParams
	{
		// Token: 0x040279FC RID: 162300
		[FieldOffset(0)]
		public long buffId;
	}

	// Token: 0x020071F0 RID: 29168
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __AicApplyBuffToTarget_FunctionParams
	{
		// Token: 0x040279FD RID: 162301
		[FieldOffset(0)]
		public int targetId;

		// Token: 0x040279FE RID: 162302
		[FieldOffset(8)]
		public long buffId;
	}

	// Token: 0x020071F1 RID: 29169
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __AicRemoveBuff_FunctionParams
	{
		// Token: 0x040279FF RID: 162303
		[FieldOffset(0)]
		public long buffId;
	}

	// Token: 0x020071F2 RID: 29170
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 12)]
	protected ref struct __AicAddTag_FunctionParams
	{
		// Token: 0x04027A00 RID: 162304
		[FieldOffset(0)]
		public FGameplayTag tag;
	}

	// Token: 0x020071F3 RID: 29171
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 12)]
	protected ref struct __AicRemoveTag_FunctionParams
	{
		// Token: 0x04027A01 RID: 162305
		[FieldOffset(0)]
		public FGameplayTag tag;
	}

	// Token: 0x020071F4 RID: 29172
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __SetBattleWanderTime_FunctionParams
	{
		// Token: 0x04027A02 RID: 162306
		[FieldOffset(0)]
		public float min;

		// Token: 0x04027A03 RID: 162307
		[FieldOffset(4)]
		public float max;
	}

	// Token: 0x020071F5 RID: 29173
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __SetBattleWanderIndex_FunctionParams
	{
		// Token: 0x04027A04 RID: 162308
		[FieldOffset(0)]
		public int index;
	}

	// Token: 0x020071F6 RID: 29174
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __AddBattleWanderEndTime_FunctionParams
	{
		// Token: 0x04027A05 RID: 162309
		[FieldOffset(0)]
		public float addTime;
	}

	// Token: 0x020071F7 RID: 29175
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __SetAiSenseEnable_FunctionParams
	{
		// Token: 0x04027A06 RID: 162310
		[FieldOffset(0)]
		public int index;

		// Token: 0x04027A07 RID: 162311
		[FieldOffset(4)]
		public bool enable;
	}

	// Token: 0x020071F8 RID: 29176
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __AddOrRemoveAiSense_FunctionParams
	{
		// Token: 0x04027A08 RID: 162312
		[FieldOffset(0)]
		public int aiSenseId;

		// Token: 0x04027A09 RID: 162313
		[FieldOffset(4)]
		public bool add;
	}

	// Token: 0x020071F9 RID: 29177
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __EnableAiSenseByType_FunctionParams
	{
		// Token: 0x04027A0A RID: 162314
		[FieldOffset(0)]
		public int type;

		// Token: 0x04027A0B RID: 162315
		[FieldOffset(4)]
		public bool enable;
	}

	// Token: 0x020071FA RID: 29178
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetAiHateConfig_FunctionParams
	{
		// Token: 0x04027A0C RID: 162316
		[FieldOffset(0)]
		public FString configId;
	}

	// Token: 0x020071FB RID: 29179
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 12)]
	protected ref struct __ChangeHatred_FunctionParams
	{
		// Token: 0x04027A0D RID: 162317
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04027A0E RID: 162318
		[FieldOffset(4)]
		public float rate;

		// Token: 0x04027A0F RID: 162319
		[FieldOffset(8)]
		public float abs;
	}

	// Token: 0x020071FC RID: 29180
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __ClearHatred_FunctionParams
	{
		// Token: 0x04027A10 RID: 162320
		[FieldOffset(0)]
		public int entityId;
	}

	// Token: 0x020071FD RID: 29181
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __AddAlertEventBinder_FunctionParams
	{
		// Token: 0x04027A11 RID: 162321
		[FieldOffset(0)]
		public IntPtr eventBinder;
	}

	// Token: 0x020071FE RID: 29182
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetAiAlertConfig_FunctionParams
	{
		// Token: 0x04027A12 RID: 162322
		[FieldOffset(0)]
		public FString configId;
	}

	// Token: 0x020071FF RID: 29183
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __SetAiEnable_FunctionParams
	{
		// Token: 0x04027A13 RID: 162323
		[FieldOffset(0)]
		public bool enable;

		// Token: 0x04027A14 RID: 162324
		[FieldOffset(8)]
		public FString key;
	}

	// Token: 0x02007200 RID: 29184
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __TestChangeAi_FunctionParams
	{
		// Token: 0x04027A15 RID: 162325
		[FieldOffset(0)]
		public FString id;
	}

	// Token: 0x02007201 RID: 29185
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __LogReport_FunctionParams
	{
		// Token: 0x04027A16 RID: 162326
		[FieldOffset(0)]
		public int logId;
	}

	// Token: 0x02007202 RID: 29186
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __逻辑主控_FunctionParams
	{
		// Token: 0x04027A17 RID: 162327
		[FieldOffset(0)]
		public bool __Result;
	}

	// Token: 0x02007203 RID: 29187
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __移动主控_FunctionParams
	{
		// Token: 0x04027A18 RID: 162328
		[FieldOffset(0)]
		public bool __Result;
	}

	// Token: 0x02007204 RID: 29188
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __检查状态机状态_FunctionParams
	{
		// Token: 0x04027A19 RID: 162329
		[FieldOffset(0)]
		public byte states;

		// Token: 0x04027A1A RID: 162330
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x02007205 RID: 29189
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __切换状态机状态_FunctionParams
	{
		// Token: 0x04027A1B RID: 162331
		[FieldOffset(0)]
		public byte states;
	}

	// Token: 0x02007206 RID: 29190
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __GetCoolDownDone_FunctionParams
	{
		// Token: 0x04027A1C RID: 162332
		[FieldOffset(0)]
		public int id;

		// Token: 0x04027A1D RID: 162333
		[FieldOffset(4)]
		public bool __Result;
	}

	// Token: 0x02007207 RID: 29191
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __GetCoolDownRemainTime_FunctionParams
	{
		// Token: 0x04027A1E RID: 162334
		[FieldOffset(0)]
		public int id;

		// Token: 0x04027A1F RID: 162335
		[FieldOffset(4)]
		public float __Result;
	}

	// Token: 0x02007208 RID: 29192
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __SetCoolDown_FunctionParams
	{
		// Token: 0x04027A20 RID: 162336
		[FieldOffset(0)]
		public int id;

		// Token: 0x04027A21 RID: 162337
		[FieldOffset(4)]
		public float cd;
	}

	// Token: 0x02007209 RID: 29193
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __InitCooldownEvent_FunctionParams
	{
		// Token: 0x04027A22 RID: 162338
		[FieldOffset(0)]
		public int id;

		// Token: 0x04027A23 RID: 162339
		[FieldOffset(8)]
		public IntPtr eventBinder;
	}

	// Token: 0x0200720A RID: 29194
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __StartCooldownTimer_FunctionParams
	{
		// Token: 0x04027A24 RID: 162340
		[FieldOffset(0)]
		public int id;

		// Token: 0x04027A25 RID: 162341
		[FieldOffset(4)]
		public float duration;
	}

	// Token: 0x0200720B RID: 29195
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetDebugStateMachine_FunctionParams
	{
		// Token: 0x04027A26 RID: 162342
		[FieldOffset(0)]
		public byte output;
	}

	// Token: 0x0200720C RID: 29196
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetDebugText_FunctionParams
	{
		// Token: 0x04027A27 RID: 162343
		[FieldOffset(0)]
		public byte __Result;
	}
}
