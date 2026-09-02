using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Utils;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CE7 RID: 3303
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskWander.TsTaskWander_C")]
public class TsTaskWander : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000305 RID: 773
	// (get) Token: 0x06004182 RID: 16770 RVA: 0x0006BFFB File Offset: 0x0006A1FB
	// (set) Token: 0x06004183 RID: 16771 RVA: 0x0006C00B File Offset: 0x0006A20B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float RandomRadius
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskWander.__PropertyOffset_RandomRadius);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskWander.__PropertyOffset_RandomRadius) = value;
		}
	}

	// Token: 0x17000306 RID: 774
	// (get) Token: 0x06004184 RID: 16772 RVA: 0x0006C01C File Offset: 0x0006A21C
	// (set) Token: 0x06004185 RID: 16773 RVA: 0x0006C02C File Offset: 0x0006A22C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MinWanderDistance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskWander.__PropertyOffset_MinWanderDistance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskWander.__PropertyOffset_MinWanderDistance) = value;
		}
	}

	// Token: 0x17000307 RID: 775
	// (get) Token: 0x06004186 RID: 16774 RVA: 0x0006C03D File Offset: 0x0006A23D
	// (set) Token: 0x06004187 RID: 16775 RVA: 0x0006C04D File Offset: 0x0006A24D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MaxNavigationMillisecond
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskWander.__PropertyOffset_MaxNavigationMillisecond);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskWander.__PropertyOffset_MaxNavigationMillisecond) = value;
		}
	}

	// Token: 0x17000308 RID: 776
	// (get) Token: 0x06004188 RID: 16776 RVA: 0x0006C05E File Offset: 0x0006A25E
	// (set) Token: 0x06004189 RID: 16777 RVA: 0x0006C06E File Offset: 0x0006A26E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool MoveStateForWanderOrReset
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskWander.__PropertyOffset_MoveStateForWanderOrReset) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskWander.__PropertyOffset_MoveStateForWanderOrReset) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000309 RID: 777
	// (get) Token: 0x0600418A RID: 16778 RVA: 0x0006C07F File Offset: 0x0006A27F
	// (set) Token: 0x0600418B RID: 16779 RVA: 0x0006C08F File Offset: 0x0006A28F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MaxStopTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskWander.__PropertyOffset_MaxStopTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskWander.__PropertyOffset_MaxStopTime) = value;
		}
	}

	// Token: 0x1700030A RID: 778
	// (get) Token: 0x0600418C RID: 16780 RVA: 0x0006C0A0 File Offset: 0x0006A2A0
	// (set) Token: 0x0600418D RID: 16781 RVA: 0x0006C0B0 File Offset: 0x0006A2B0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float BlinkTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskWander.__PropertyOffset_BlinkTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskWander.__PropertyOffset_BlinkTime) = value;
		}
	}

	// Token: 0x1700030B RID: 779
	// (get) Token: 0x0600418E RID: 16782 RVA: 0x0006C0C1 File Offset: 0x0006A2C1
	// (set) Token: 0x0600418F RID: 16783 RVA: 0x0006C0D1 File Offset: 0x0006A2D1
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool UsePatrolPointPriority
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskWander.__PropertyOffset_UsePatrolPointPriority) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskWander.__PropertyOffset_UsePatrolPointPriority) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700030C RID: 780
	// (get) Token: 0x06004190 RID: 16784 RVA: 0x0006C0E4 File Offset: 0x0006A2E4
	// (set) Token: 0x06004191 RID: 16785 RVA: 0x0006C11D File Offset: 0x0006A31D
	[UProperty(EPropertyFlags.CPF_None)]
	public FSoftObjectPath ShowEffectDa
	{
		get
		{
			base.FastCheckIsValid();
			FSoftObjectPath result;
			if ((result = this._ShowEffectDa) == null)
			{
				result = (this._ShowEffectDa = new FSoftObjectPath(base.NativePtr + (IntPtr)TsTaskWander.__PropertyOffset_ShowEffectDa, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)TsTaskWander.__PropertyOffset_ShowEffectDa, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x1700030D RID: 781
	// (get) Token: 0x06004192 RID: 16786 RVA: 0x0006C148 File Offset: 0x0006A348
	// (set) Token: 0x06004193 RID: 16787 RVA: 0x0006C181 File Offset: 0x0006A381
	[UProperty(EPropertyFlags.CPF_None)]
	public FSoftObjectPath HideEffectDa
	{
		get
		{
			base.FastCheckIsValid();
			FSoftObjectPath result;
			if ((result = this._HideEffectDa) == null)
			{
				result = (this._HideEffectDa = new FSoftObjectPath(base.NativePtr + (IntPtr)TsTaskWander.__PropertyOffset_HideEffectDa, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)TsTaskWander.__PropertyOffset_HideEffectDa, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x1700030E RID: 782
	// (get) Token: 0x06004194 RID: 16788 RVA: 0x0006C1AC File Offset: 0x0006A3AC
	// (set) Token: 0x06004195 RID: 16789 RVA: 0x0006C1E5 File Offset: 0x0006A3E5
	[UProperty(EPropertyFlags.CPF_None)]
	public FSoftObjectPath ShowMaterialDa
	{
		get
		{
			base.FastCheckIsValid();
			FSoftObjectPath result;
			if ((result = this._ShowMaterialDa) == null)
			{
				result = (this._ShowMaterialDa = new FSoftObjectPath(base.NativePtr + (IntPtr)TsTaskWander.__PropertyOffset_ShowMaterialDa, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)TsTaskWander.__PropertyOffset_ShowMaterialDa, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x1700030F RID: 783
	// (get) Token: 0x06004196 RID: 16790 RVA: 0x0006C210 File Offset: 0x0006A410
	// (set) Token: 0x06004197 RID: 16791 RVA: 0x0006C249 File Offset: 0x0006A449
	[UProperty(EPropertyFlags.CPF_None)]
	public FSoftObjectPath HideMaterialDa
	{
		get
		{
			base.FastCheckIsValid();
			FSoftObjectPath result;
			if ((result = this._HideMaterialDa) == null)
			{
				result = (this._HideMaterialDa = new FSoftObjectPath(base.NativePtr + (IntPtr)TsTaskWander.__PropertyOffset_HideMaterialDa, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)TsTaskWander.__PropertyOffset_HideMaterialDa, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x17000310 RID: 784
	// (get) Token: 0x06004198 RID: 16792 RVA: 0x0006C271 File Offset: 0x0006A471
	// (set) Token: 0x06004199 RID: 16793 RVA: 0x0006C281 File Offset: 0x0006A481
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool Debug
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskWander.__PropertyOffset_Debug) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskWander.__PropertyOffset_Debug) = (value ? 1 : 0);
		}
	}

	// Token: 0x0600419A RID: 16794 RVA: 0x0006C294 File Offset: 0x0006A494
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsRandomRadius = this.RandomRadius;
			this.TsMinWanderDistance = this.MinWanderDistance;
			this.TsMaxNavigationMillisecond = this.MaxNavigationMillisecond;
			this.TsMoveStateForWanderOrReset = this.MoveStateForWanderOrReset;
			this.TsMaxStopTime = this.MaxStopTime;
			this.TsBlinkTime = this.BlinkTime;
			this.TsUsePatrolPointPriority = this.UsePatrolPointPriority;
			this.TsShowEffectDa = this.ShowEffectDa.AssetPathName.ToString();
			this.TsShowEffectDa = ((this.TsShowEffectDa == "None") ? "" : this.TsShowEffectDa);
			this.TsHideEffectDa = this.HideEffectDa.AssetPathName.ToString();
			this.TsHideEffectDa = ((this.TsHideEffectDa == "None") ? "" : this.TsHideEffectDa);
			this.TsShowMaterialDa = this.ShowMaterialDa.AssetPathName.ToString();
			this.TsHideMaterialDa = this.HideMaterialDa.AssetPathName.ToString();
			this.TsDebug = this.Debug;
			this.SelectedTargetLocation = global::Vector.Create();
			this.CacheVector = global::Vector.Create();
		}
	}

	// Token: 0x0600419B RID: 16795 RVA: 0x0006C3F8 File Offset: 0x0006A5F8
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

	// Token: 0x0600419C RID: 16796 RVA: 0x0006C494 File Offset: 0x0006A694
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		if (aiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "[TsTaskWander]错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.FoundPath = false;
			return;
		}
		AiWanderInfos aiWanderInfos = aiController.AiWanderInfos;
		AiWander? aiWander = (aiWanderInfos != null) ? aiWanderInfos.AiWander : null;
		if (aiWander == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.BehaviorTree;
			ELogAuthor author2 = ELogAuthor.LCZ;
			string message2 = "[TsTaskWander]没有配置AiWander";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("AiBaseId", aiController.AiBase.Value.Id);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			this.MoveStateActural = 2;
		}
		else
		{
			this.MoveStateActural = (this.TsMoveStateForWanderOrReset ? aiWander.Value.WanderMoveState : aiWander.Value.ResetMoveState);
			this.TsShowEffectDa = aiWander.Value.ShowEffectDaPath;
			this.TsHideEffectDa = aiWander.Value.HideEffectDaPath;
			this.TsShowMaterialDa = aiWander.Value.ShowMaterialDaPath;
			this.TsHideMaterialDa = aiWander.Value.HideMaterialDaPath;
		}
		if (aiController.AiWanderRadiusConfig != null)
		{
			this.TsRandomRadius = aiController.AiWanderRadiusConfig.Value.RandomRadius;
			this.TsMinWanderDistance = aiController.AiWanderRadiusConfig.Value.MinWanderDistance;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		global::Vector vector = global::Vector.Create();
		if (this.TsUsePatrolPointPriority && aiController.AiPatrol.HasPatrolConfig())
		{
			global::Vector lastPatrolPoint = aiController.AiPatrol.GetLastPatrolPoint();
			if (lastPatrolPoint != null)
			{
				vector.DeepCopy(lastPatrolPoint);
			}
			else
			{
				vector.DeepCopy(aiController.CharActorComp.GetInitLocation());
			}
		}
		else
		{
			vector.DeepCopy(aiController.CharActorComp.GetInitLocation());
		}
		this.FindNavPoint(ownerController, vector, charActorComp);
		this.CheckPreLocationDistance(charActorComp, 0f);
		switch (this.MoveStateActural)
		{
		case 1:
		case 2:
		{
			if (this.NavigationPath == null)
			{
				this.NavigationPath = new List<global::Vector>();
			}
			BaseUnifiedStateComponent component = charActorComp.Entity.GetComponent<BaseUnifiedStateComponent>();
			if (component != null && component.PositionState == ECharPositionState.Ground)
			{
				this.CacheVector.DeepCopy(charActorComp.FloorLocation);
			}
			else
			{
				this.CacheVector.DeepCopy(charActorComp.ActorLocationProxy);
			}
			this.FoundPath = AiControllerLibrary.NavigationFindPath(ownerController, this.CacheVector.ToUeVector(false), this.SelectedTargetLocation.ToUeVector(false), this.NavigationPath, null, null);
			if (!this.FoundPath)
			{
				if (this.TsMoveStateForWanderOrReset)
				{
					base.Finish(false);
					return;
				}
				if (this.BlinkMoveBegin(charActorComp, true))
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.BehaviorTree;
					ELogAuthor author3 = ELogAuthor.LJM;
					string message3 = "[TsTaskWander]AiWander怪物复位寻路失败";
					ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
					instance3.Warn(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
					return;
				}
			}
			this.CurrentNavigationIndex = 1;
			this.NavigationEndTime = Singleton<Time>.Instance.WorldTime + (double)this.TsMaxNavigationMillisecond;
			BaseUnifiedStateComponent baseUnifiedStateComponent = charActorComp.Entity.CheckGetComponent<BaseUnifiedStateComponent>();
			if (baseUnifiedStateComponent.Valid)
			{
				int moveStateActural = this.MoveStateActural;
				if (moveStateActural != 1)
				{
					if (moveStateActural == 2)
					{
						baseUnifiedStateComponent.SetMoveState(ECharMoveState.Run);
					}
				}
				else
				{
					baseUnifiedStateComponent.SetMoveState(ECharMoveState.Walk);
				}
			}
			break;
		}
		case 3:
			this.BlinkMoveBegin(charActorComp, false);
			break;
		case 4:
			this.UseSkill(charActorComp, aiWander);
			break;
		}
		this.SetAiSceneEnable(aiController, false);
	}

	// Token: 0x0600419D RID: 16797 RVA: 0x0006C830 File Offset: 0x0006AA30
	private void FindNavPoint([Nullable(2)] AAIController ownerController, global::Vector initLocation, CharacterActorComponent character)
	{
		int i = 5;
		BaseMoveComponent moveComp = character.MoveComp;
		bool flag = moveComp == null || moveComp.IsStandardGravity;
		while (i > 0)
		{
			FVectorDouble fvectorDouble = default(FVectorDouble);
			bool flag2;
			if (flag)
			{
				FVectorDouble fvectorDouble2 = initLocation.ToUeVector(false);
				flag2 = UNavigationSystemV1.D_K2_GetRandomLocationInNavigableRadius(ownerController, fvectorDouble2, ref fvectorDouble, this.TsRandomRadius, null, default(TSubclassOf<UNavigationQueryFilter>));
				this.SelectedTargetLocation.FromUeVector(fvectorDouble);
			}
			else
			{
				flag2 = true;
				float randomFloatNumber = Singleton<MathUtils>.Instance.GetRandomFloatNumber(0f, 6.2831855f);
				this.SelectedTargetLocation.Set(Math.Cos((double)randomFloatNumber), Math.Sin((double)randomFloatNumber), 0.0);
				character.ActorQuatProxy.RotateVector(this.SelectedTargetLocation, this.SelectedTargetLocation);
				double inB = Math.Sqrt((double)Singleton<MathUtils>.Instance.GetRandomFloatNumber(this.TsMinWanderDistance * this.TsMinWanderDistance, this.TsRandomRadius * this.TsRandomRadius));
				this.SelectedTargetLocation.MultiplyEqual(inB);
				this.SelectedTargetLocation.AdditionEqual(character.FloorLocation);
			}
			if (flag2 && global::Vector.DistSquared(this.SelectedTargetLocation, character.ActorLocationProxy) > (double)(this.TsMinWanderDistance * this.TsMinWanderDistance))
			{
				break;
			}
			i--;
		}
		bool flag3 = false;
		if (global::Vector.DistSquared(this.SelectedTargetLocation, character.ActorLocationProxy) <= (double)(this.TsRandomRadius * this.TsRandomRadius))
		{
			flag3 = true;
		}
		if (!flag3)
		{
			this.FoundPath = false;
			this.NavigationPath = null;
			this.SelectedTargetLocation.DeepCopy(initLocation);
		}
	}

	// Token: 0x0600419E RID: 16798 RVA: 0x0006C9B0 File Offset: 0x0006ABB0
	private void SetAiSceneEnable(AiController aiController, bool enable)
	{
		if (!this.TsMoveStateForWanderOrReset)
		{
			AiPerception aiPerception = aiController.AiPerception as AiPerception;
			if (aiPerception != null)
			{
				aiPerception.SetAllAiSenseEnable(enable);
			}
		}
	}

	// Token: 0x0600419F RID: 16799 RVA: 0x0006C9DC File Offset: 0x0006ABDC
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveTickAI(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveTickAI"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams*)ptr + 15L / (long)sizeof(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->OwnerController) = ((ownerController != null) ? ownerController.NativePtr : ((IntPtr)0));
			*(&ptr2->ControlledPawn) = ((controlledPawn != null) ? controlledPawn.NativePtr : ((IntPtr)0));
			ptr2->DeltaSeconds = deltaSeconds;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x060041A0 RID: 16800 RVA: 0x0006CA7C File Offset: 0x0006AC7C
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		if (aiController == null)
		{
			base.FinishExecute(false);
			return;
		}
		if (!this.FoundPath && !this.InBlink)
		{
			base.Finish(false);
			return;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		if (this.TsDebug)
		{
			this.DrawDebugPath(charActorComp);
		}
		if (this.InBlink)
		{
			this.BlinkMoveTick(charActorComp, deltaSeconds);
			return;
		}
		if (!this.TsMoveStateForWanderOrReset && Singleton<Time>.Instance.WorldTime > this.NavigationEndTime)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[TsTaskWander]AiWander怪物复位超时，瞬移回目标点";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (this.BlinkMoveBegin(charActorComp, true))
			{
				return;
			}
		}
		global::Vector vector = global::Vector.Create(this.NavigationPath[this.CurrentNavigationIndex]);
		vector.Subtraction(charActorComp.ActorLocationProxy, vector);
		vector.Z = 0.0;
		double num = vector.Size();
		if (num <= (double)aiController.AiWanderInfos.AiWander.Value.CompleteDistance)
		{
			this.CurrentNavigationIndex++;
			if (this.CurrentNavigationIndex == this.NavigationPath.Count)
			{
				base.Finish(true);
				return;
			}
		}
		vector.DivisionEqual(num);
		charActorComp.SetInputDirect(vector, true);
		AiControllerLibrary.TurnToDirect(charActorComp, vector, aiController.AiWanderInfos.AiWander.Value.TurnSpeed, false, 0f);
		if (!this.TsMoveStateForWanderOrReset && !this.CheckPreLocationDistance(charActorComp, deltaSeconds))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.BehaviorTree;
			ELogAuthor author2 = ELogAuthor.LJM;
			string message2 = "[TsTaskWander]AiWander怪物游荡卡住超时，瞬移回目标点";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			this.BlinkMoveBegin(charActorComp, true);
		}
	}

	// Token: 0x060041A1 RID: 16801 RVA: 0x0006CC4C File Offset: 0x0006AE4C
	protected override void OnClear()
	{
		TsAiController tsAiController = base.AIOwner as TsAiController;
		if (tsAiController != null)
		{
			AiControllerLibrary.ClearInput(tsAiController);
			this.SetAiSceneEnable(tsAiController.AiController, true);
			TsBaseCharacter actor = tsAiController.AiController.CharActorComp.Actor;
			if (this.InBlink)
			{
				actor.SetActorEnableCollision(true);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.BehaviorTree;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "[TsTaskWander]AiWander[OnClear]怪物闪烁导致Actor碰撞为True";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor:", actor);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			CharRenderingComponent charRenderingComponent = actor.CharRenderingComponent;
			int? num = this.HideMaterialData;
			int num2 = 0;
			if (num.GetValueOrDefault() > num2 & num != null)
			{
				charRenderingComponent.RemoveMaterialControllerData(this.HideMaterialData.Value);
				charRenderingComponent.ResetAllRenderingState();
			}
			num = this.ShowMaterialData;
			num2 = 0;
			if (num.GetValueOrDefault() > num2 & num != null)
			{
				charRenderingComponent.RemoveMaterialControllerData(this.ShowMaterialData.Value);
				charRenderingComponent.ResetAllRenderingState();
			}
			if (!this.TsMoveStateForWanderOrReset)
			{
				Entity entity = tsAiController.AiController.CharActorComp.Entity;
				Singleton<EventSystem>.Instance.EmitWithTarget(entity, EEventName.AiTaskWanderForResetEnd);
			}
		}
		this.NavigationPath = null;
		this.FoundPath = false;
		this.InBlink = false;
		this.BlinkTimeCount = 0f;
		this.StopTimeCount = 0f;
		this.HideMaterialData = null;
		this.ShowMaterialData = null;
	}

	// Token: 0x060041A2 RID: 16802 RVA: 0x0006CDAC File Offset: 0x0006AFAC
	private bool CheckPreLocationDistance(CharacterActorComponent actor, float deltaSeconds)
	{
		if (this.PreLocation == null)
		{
			this.PreLocation = global::Vector.Create(actor.ActorLocation);
			this.StopTimeCount = 0f;
			return true;
		}
		global::Vector actorLocationProxy = actor.ActorLocationProxy;
		if (global::Vector.DistSquared(this.PreLocation, actorLocationProxy) < 0.0010000000474974513)
		{
			this.StopTimeCount += deltaSeconds;
		}
		else
		{
			this.StopTimeCount = 0f;
		}
		this.PreLocation.DeepCopy(actorLocationProxy);
		return this.StopTimeCount <= this.TsMaxStopTime;
	}

	// Token: 0x060041A3 RID: 16803 RVA: 0x0006CE3C File Offset: 0x0006B03C
	private bool BlinkMoveBegin(CharacterActorComponent actor, bool bForce = false)
	{
		if (this.MoveStateActural == 3 || bForce)
		{
			if (bForce)
			{
				this.MoveStateActural = 3;
			}
			this.InBlink = true;
			this.BlinkTimeCount = 0f;
			this.ShowMaterialData = null;
			this.HideMaterialData = null;
			actor.Actor.SetActorEnableCollision(false);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[TsTaskWander]AiWander[BlinkMoveBegin]怪物闪烁导致Actor碰撞为False";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor:", actor.Actor.GetName());
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (this.TsHideEffectDa != "")
			{
				EffectSystem instance2 = Singleton<EffectSystem>.Instance;
				UObject world = GlobalData.World;
				FTransformDouble? ftransformDouble = new FTransformDouble?(Singleton<MathUtils>.Instance.DefaultTransformDouble);
				int id = instance2.SpawnEffect(world, ftransformDouble, this.TsHideEffectDa, "[TsTaskWander.BlinkMoveBegin] hideEffect", new EffectContext(new int?(actor.Entity.Id), null, false), EEffectType.Scene, null, null, null, false, false);
				OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(id);
				if (effectActor.IsValid())
				{
					FHitResult fhitResult = null;
					OneOf<KuroEffectActorHandle, AActor> self = effectActor;
					FVectorDouble actorLocation = actor.ActorLocation;
					self.D_K2_SetActorLocation(actorLocation, false, ref fhitResult, false);
				}
				else
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.BehaviorTree;
					ELogAuthor author2 = ELogAuthor.LJM;
					string message2 = "[TsTaskWander]AiWander瞬移隐藏特效生成失败。";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Type", actor.Actor.GetName());
					instance3.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				}
			}
			if (this.TsHideMaterialDa != "")
			{
				Singleton<ResourceSystem>.Instance.LoadAsync<PD_CharacterControllerData_C>(this.TsHideMaterialDa, delegate([Nullable(2)] PD_CharacterControllerData_C hideMaterial, string _)
				{
					if (hideMaterial != null)
					{
						this.HideMaterialData = new int?(actor.Actor.CharRenderingComponent.AddMaterialControllerData(hideMaterial));
						return;
					}
					this.HideMaterialData = new int?(0);
					Log instance4 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.BehaviorTree;
					ELogAuthor author3 = ELogAuthor.LJM;
					string message3 = "[TsTaskWander]AiWander瞬移隐藏材质生成失败";
					ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("Type", actor.Actor.GetName());
					instance4.Warn(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				}, 100, "js_undefined");
			}
			else
			{
				this.HideMaterialData = new int?(-1);
			}
			return true;
		}
		return false;
	}

	// Token: 0x060041A4 RID: 16804 RVA: 0x0006D000 File Offset: 0x0006B200
	private void BlinkMoveTick(CharacterActorComponent actor, float deltaSeconds)
	{
		this.BlinkTimeCount += deltaSeconds;
		if (this.BlinkTimeCount >= this.TsBlinkTime - 1f && this.ShowMaterialData == null)
		{
			actor.SetActorLocation(this.SelectedTargetLocation.ToUeVector(false), "脱战节点.执行瞬移重置位置", false);
			actor.FixBornLocation("脱战节点.修正角色地面位置", true, null, false, false, true);
			actor.Actor.SetActorEnableCollision(true);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[TsTaskWander]AiWander[BlinkMoveTick]怪物闪烁导致Actor碰撞为True";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor:", actor.Actor.GetName());
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.ResetAiInfo(actor);
			if (this.TsShowEffectDa != "")
			{
				EffectSystem instance2 = Singleton<EffectSystem>.Instance;
				UObject world = GlobalData.World;
				FTransformDouble? ftransformDouble = new FTransformDouble?(Singleton<MathUtils>.Instance.DefaultTransformDouble);
				int id = instance2.SpawnEffect(world, ftransformDouble, this.TsShowEffectDa, "[TsTaskWander.BlinkMoveTick] showEffect", new EffectContext(new int?(actor.Entity.Id), null, false), EEffectType.Scene, null, null, null, false, false);
				OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(id);
				if (effectActor.IsValid())
				{
					FHitResult fhitResult = null;
					OneOf<KuroEffectActorHandle, AActor> self = effectActor;
					FVectorDouble actorLocation = actor.ActorLocation;
					self.D_K2_SetActorLocation(actorLocation, false, ref fhitResult, false);
				}
				else
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.BehaviorTree;
					ELogAuthor author2 = ELogAuthor.LJM;
					string message2 = "[TsTaskWander]AiWander瞬移显示特效生成失败";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Type", actor.Actor.GetName());
					instance3.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				}
			}
			if (this.HideMaterialData != null && this.HideMaterialData.Value > 0)
			{
				actor.Actor.CharRenderingComponent.RemoveMaterialControllerData(this.HideMaterialData.Value);
				this.HideMaterialData = null;
			}
			if (this.TsShowMaterialDa != "")
			{
				Singleton<ResourceSystem>.Instance.LoadAsync<PD_CharacterControllerData_C>(this.TsShowMaterialDa, delegate([Nullable(2)] PD_CharacterControllerData_C showMaterial, string _)
				{
					if (showMaterial != null)
					{
						this.ShowMaterialData = new int?(actor.Actor.CharRenderingComponent.AddMaterialControllerData(showMaterial));
						return;
					}
					this.ShowMaterialData = new int?(-1);
					Log instance4 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.BehaviorTree;
					ELogAuthor author3 = ELogAuthor.LJM;
					string message3 = "[TsTaskWander]AiWander瞬移显示材质生成失败";
					ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("Type", actor.Actor.GetName());
					instance4.Warn(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				}, 100, "js_undefined");
			}
			else
			{
				this.ShowMaterialData = new int?(-1);
			}
			actor.SetInputDirect(global::Vector.ZeroVectorProxy, false);
		}
		if (this.BlinkTimeCount >= this.TsBlinkTime)
		{
			this.BlinkMoveEnd(actor);
		}
	}

	// Token: 0x060041A5 RID: 16805 RVA: 0x0006D26C File Offset: 0x0006B46C
	private bool BlinkMoveEnd(CharacterActorComponent actor)
	{
		if (this.InBlink)
		{
			this.InBlink = false;
			if (!actor.Actor.bActorEnableCollision)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.BehaviorTree;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "[TsTaskWander]AiWander[BlinkMoveEnd]怪物闪烁此刻Actor碰撞不应该为False,查看[BlinkMoveTick]是否置为True";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor:", actor.Actor.GetName());
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			if (this.ShowMaterialData != null && this.ShowMaterialData.Value > 0)
			{
				actor.Actor.CharRenderingComponent.RemoveMaterialControllerData(this.ShowMaterialData.Value);
				this.ShowMaterialData = null;
			}
			actor.Actor.CharRenderingComponent.ResetAllRenderingState();
			base.Finish(true);
			return true;
		}
		return false;
	}

	// Token: 0x060041A6 RID: 16806 RVA: 0x0006D328 File Offset: 0x0006B528
	private void UseSkill(CharacterActorComponent actor, AiWander? aiWander)
	{
		CharacterSkillComponent component = actor.Entity.GetComponent<CharacterSkillComponent>();
		if (!component.Valid || aiWander == null)
		{
			base.Finish(false);
			return;
		}
		bool bSuccess = component.BeginSkill(aiWander.Value.MoveStateGA, new SkillParam
		{
			Reason = "TsTaskWander.UseSkill"
		});
		base.Finish(bSuccess);
	}

	// Token: 0x060041A7 RID: 16807 RVA: 0x0006D388 File Offset: 0x0006B588
	private void ResetAiInfo(CharacterActorComponent actor)
	{
		CreatureDataComponent component = actor.Entity.GetComponent<CreatureDataComponent>();
		FRotator? frotator = (component != null) ? new FRotator?(component.GetRotation()) : null;
		if (frotator != null)
		{
			actor.SetActorRotation(frotator.Value, "脱战节点.重置为基础方法", false);
		}
	}

	// Token: 0x060041A8 RID: 16808 RVA: 0x0006D3D8 File Offset: 0x0006B5D8
	private void DrawDebugPath(CharacterActorComponent actor)
	{
		int count = this.NavigationPath.Count;
		if (count == 0)
		{
			return;
		}
		int num = 0;
		UKismetSystemLibrary.D_DrawDebugSphere(actor.Actor, this.SelectedTargetLocation.ToUeVector(false), 40f, 10, new FLinearColor?(ColorUtils.LinearGreen), 0f, 2f);
		UKismetSystemLibrary.D_DrawDebugLine(actor.Actor, actor.ActorLocation, this.SelectedTargetLocation.ToUeVector(false), ColorUtils.LinearGreen, 0f, 2f);
		foreach (global::Vector vector in this.NavigationPath)
		{
			UKismetSystemLibrary.D_DrawDebugSphere(actor.Actor, vector.ToUeVector(false), 30f, 10, new FLinearColor?(ColorUtils.LinearRed), 0f, 2f);
			num++;
			if (num < count)
			{
				UKismetSystemLibrary.D_DrawDebugLine(actor.Actor, vector.ToUeVector(false), this.NavigationPath[num].ToUeVector(false), ColorUtils.LinearRed, 0f, 2f);
			}
		}
	}

	// Token: 0x060041A9 RID: 16809 RVA: 0x0006D4FC File Offset: 0x0006B6FC
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskWander._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskWander.TsTaskWander_C");
		}
		return TsTaskWander._ClassPtr;
	}

	// Token: 0x060041AA RID: 16810 RVA: 0x0006D520 File Offset: 0x0006B720
	public TsTaskWander() : this(BuiltinUtils.AllocNativeUObject(TsTaskWander.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060041AB RID: 16811 RVA: 0x0006D548 File Offset: 0x0006B748
	public TsTaskWander(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskWander.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060041AC RID: 16812 RVA: 0x0006D57C File Offset: 0x0006B77C
	protected TsTaskWander(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060041AD RID: 16813 RVA: 0x0006D5D4 File Offset: 0x0006B7D4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060041AE RID: 16814 RVA: 0x0006D604 File Offset: 0x0006B804
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000FE3 RID: 4067
	private const string NONE_PATH = "None";

	// Token: 0x04000FE4 RID: 4068
	private const int BLINK_STATE = 3;

	// Token: 0x04000FE5 RID: 4069
	private const int SKILL_STATE = 4;

	// Token: 0x04000FE6 RID: 4070
	private global::Vector SelectedTargetLocation = global::Vector.Create();

	// Token: 0x04000FE7 RID: 4071
	private bool FoundPath;

	// Token: 0x04000FE8 RID: 4072
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<global::Vector> NavigationPath;

	// Token: 0x04000FE9 RID: 4073
	private int CurrentNavigationIndex;

	// Token: 0x04000FEA RID: 4074
	private double NavigationEndTime;

	// Token: 0x04000FEB RID: 4075
	private bool InBlink;

	// Token: 0x04000FEC RID: 4076
	private float StopTimeCount;

	// Token: 0x04000FED RID: 4077
	private float BlinkTimeCount;

	// Token: 0x04000FEE RID: 4078
	[Nullable(2)]
	private global::Vector PreLocation;

	// Token: 0x04000FEF RID: 4079
	private int? ShowMaterialData;

	// Token: 0x04000FF0 RID: 4080
	private int? HideMaterialData;

	// Token: 0x04000FF1 RID: 4081
	private int MoveStateActural;

	// Token: 0x04000FF2 RID: 4082
	private bool IsInitTsVariables;

	// Token: 0x04000FF3 RID: 4083
	private float TsRandomRadius;

	// Token: 0x04000FF4 RID: 4084
	private float TsMinWanderDistance;

	// Token: 0x04000FF5 RID: 4085
	private float TsMaxNavigationMillisecond;

	// Token: 0x04000FF6 RID: 4086
	private bool TsMoveStateForWanderOrReset;

	// Token: 0x04000FF7 RID: 4087
	private float TsMaxStopTime;

	// Token: 0x04000FF8 RID: 4088
	private float TsBlinkTime;

	// Token: 0x04000FF9 RID: 4089
	private bool TsUsePatrolPointPriority;

	// Token: 0x04000FFA RID: 4090
	private string TsShowEffectDa = "";

	// Token: 0x04000FFB RID: 4091
	private string TsHideEffectDa = "";

	// Token: 0x04000FFC RID: 4092
	private string TsShowMaterialDa = "";

	// Token: 0x04000FFD RID: 4093
	private string TsHideMaterialDa = "";

	// Token: 0x04000FFE RID: 4094
	private bool TsDebug;

	// Token: 0x04000FFF RID: 4095
	private global::Vector CacheVector = global::Vector.Create();

	// Token: 0x04001000 RID: 4096
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskWander.TsTaskWander_C";

	// Token: 0x04001001 RID: 4097
	private static IntPtr _ClassPtr;

	// Token: 0x04001002 RID: 4098
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001003 RID: 4099
	private static int __PropertyOffset_RandomRadius;

	// Token: 0x04001004 RID: 4100
	private static int __PropertyOffset_MinWanderDistance;

	// Token: 0x04001005 RID: 4101
	private static int __PropertyOffset_MaxNavigationMillisecond;

	// Token: 0x04001006 RID: 4102
	private static int __PropertyOffset_MoveStateForWanderOrReset;

	// Token: 0x04001007 RID: 4103
	private static int __PropertyOffset_MaxStopTime;

	// Token: 0x04001008 RID: 4104
	private static int __PropertyOffset_BlinkTime;

	// Token: 0x04001009 RID: 4105
	private static int __PropertyOffset_UsePatrolPointPriority;

	// Token: 0x0400100A RID: 4106
	private static int __PropertyOffset_ShowEffectDa;

	// Token: 0x0400100B RID: 4107
	[Nullable(2)]
	private FSoftObjectPath _ShowEffectDa;

	// Token: 0x0400100C RID: 4108
	private static int __PropertyOffset_HideEffectDa;

	// Token: 0x0400100D RID: 4109
	[Nullable(2)]
	private FSoftObjectPath _HideEffectDa;

	// Token: 0x0400100E RID: 4110
	private static int __PropertyOffset_ShowMaterialDa;

	// Token: 0x0400100F RID: 4111
	[Nullable(2)]
	private FSoftObjectPath _ShowMaterialDa;

	// Token: 0x04001010 RID: 4112
	private static int __PropertyOffset_HideMaterialDa;

	// Token: 0x04001011 RID: 4113
	[Nullable(2)]
	private FSoftObjectPath _HideMaterialDa;

	// Token: 0x04001012 RID: 4114
	private static int __PropertyOffset_Debug;
}
