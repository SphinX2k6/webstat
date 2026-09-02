using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CBA RID: 3258
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskFollowTarget.TsTaskFollowTarget_C")]
public class TsTaskFollowTarget : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000247 RID: 583
	// (get) Token: 0x06003E1C RID: 15900 RVA: 0x0005BD7B File Offset: 0x00059F7B
	// (set) Token: 0x06003E1D RID: 15901 RVA: 0x0005BD8B File Offset: 0x00059F8B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Angle
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFollowTarget.__PropertyOffset_Angle);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFollowTarget.__PropertyOffset_Angle) = value;
		}
	}

	// Token: 0x17000248 RID: 584
	// (get) Token: 0x06003E1E RID: 15902 RVA: 0x0005BD9C File Offset: 0x00059F9C
	// (set) Token: 0x06003E1F RID: 15903 RVA: 0x0005BDAC File Offset: 0x00059FAC
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Length
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFollowTarget.__PropertyOffset_Length);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFollowTarget.__PropertyOffset_Length) = value;
		}
	}

	// Token: 0x17000249 RID: 585
	// (get) Token: 0x06003E20 RID: 15904 RVA: 0x0005BDBD File Offset: 0x00059FBD
	// (set) Token: 0x06003E21 RID: 15905 RVA: 0x0005BDCD File Offset: 0x00059FCD
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Speed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFollowTarget.__PropertyOffset_Speed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFollowTarget.__PropertyOffset_Speed) = value;
		}
	}

	// Token: 0x1700024A RID: 586
	// (get) Token: 0x06003E22 RID: 15906 RVA: 0x0005BDDE File Offset: 0x00059FDE
	// (set) Token: 0x06003E23 RID: 15907 RVA: 0x0005BDEE File Offset: 0x00059FEE
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float StandSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFollowTarget.__PropertyOffset_StandSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFollowTarget.__PropertyOffset_StandSpeed) = value;
		}
	}

	// Token: 0x1700024B RID: 587
	// (get) Token: 0x06003E24 RID: 15908 RVA: 0x0005BDFF File Offset: 0x00059FFF
	// (set) Token: 0x06003E25 RID: 15909 RVA: 0x0005BE0F File Offset: 0x0005A00F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Radius
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFollowTarget.__PropertyOffset_Radius);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFollowTarget.__PropertyOffset_Radius) = value;
		}
	}

	// Token: 0x1700024C RID: 588
	// (get) Token: 0x06003E26 RID: 15910 RVA: 0x0005BE20 File Offset: 0x0005A020
	// (set) Token: 0x06003E27 RID: 15911 RVA: 0x0005BE30 File Offset: 0x0005A030
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float NavigationRadius
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFollowTarget.__PropertyOffset_NavigationRadius);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFollowTarget.__PropertyOffset_NavigationRadius) = value;
		}
	}

	// Token: 0x1700024D RID: 589
	// (get) Token: 0x06003E28 RID: 15912 RVA: 0x0005BE41 File Offset: 0x0005A041
	// (set) Token: 0x06003E29 RID: 15913 RVA: 0x0005BE51 File Offset: 0x0005A051
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MaxNavigationMillisecond
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFollowTarget.__PropertyOffset_MaxNavigationMillisecond);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFollowTarget.__PropertyOffset_MaxNavigationMillisecond) = value;
		}
	}

	// Token: 0x1700024E RID: 590
	// (get) Token: 0x06003E2A RID: 15914 RVA: 0x0005BE62 File Offset: 0x0005A062
	// (set) Token: 0x06003E2B RID: 15915 RVA: 0x0005BE76 File Offset: 0x0005A076
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string FollowPointName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskFollowTarget.__PropertyOffset_FollowPointName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskFollowTarget.__PropertyOffset_FollowPointName)), value);
		}
	}

	// Token: 0x1700024F RID: 591
	// (get) Token: 0x06003E2C RID: 15916 RVA: 0x0005BE8B File Offset: 0x0005A08B
	// (set) Token: 0x06003E2D RID: 15917 RVA: 0x0005BE9B File Offset: 0x0005A09B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsShowCube
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFollowTarget.__PropertyOffset_IsShowCube) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFollowTarget.__PropertyOffset_IsShowCube) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000250 RID: 592
	// (get) Token: 0x06003E2E RID: 15918 RVA: 0x0005BEAC File Offset: 0x0005A0AC
	// (set) Token: 0x06003E2F RID: 15919 RVA: 0x0005BEE5 File Offset: 0x0005A0E5
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<FGameplayTag> Tags
	{
		get
		{
			base.FastCheckIsValid();
			TArray<FGameplayTag> result;
			if ((result = this._Tags) == null)
			{
				result = (this._Tags = new TArray<FGameplayTag>(base.NativePtr + (IntPtr)TsTaskFollowTarget.__PropertyOffset_Tags, this));
			}
			return result;
		}
		set
		{
			this.Tags.CopyAssign(value);
		}
	}

	// Token: 0x17000251 RID: 593
	// (get) Token: 0x06003E30 RID: 15920 RVA: 0x0005BEF3 File Offset: 0x0005A0F3
	// (set) Token: 0x06003E31 RID: 15921 RVA: 0x0005BF07 File Offset: 0x0005A107
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string WaitTimeName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskFollowTarget.__PropertyOffset_WaitTimeName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskFollowTarget.__PropertyOffset_WaitTimeName)), value);
		}
	}

	// Token: 0x17000252 RID: 594
	// (get) Token: 0x06003E32 RID: 15922 RVA: 0x0005BF1C File Offset: 0x0005A11C
	// (set) Token: 0x06003E33 RID: 15923 RVA: 0x0005BF2C File Offset: 0x0005A12C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float WaitTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFollowTarget.__PropertyOffset_WaitTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFollowTarget.__PropertyOffset_WaitTime) = value;
		}
	}

	// Token: 0x17000253 RID: 595
	// (get) Token: 0x06003E34 RID: 15924 RVA: 0x0005BF3D File Offset: 0x0005A13D
	// (set) Token: 0x06003E35 RID: 15925 RVA: 0x0005BF51 File Offset: 0x0005A151
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BeginTimeName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskFollowTarget.__PropertyOffset_BeginTimeName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskFollowTarget.__PropertyOffset_BeginTimeName)), value);
		}
	}

	// Token: 0x17000254 RID: 596
	// (get) Token: 0x06003E36 RID: 15926 RVA: 0x0005BF66 File Offset: 0x0005A166
	// (set) Token: 0x06003E37 RID: 15927 RVA: 0x0005BF7A File Offset: 0x0005A17A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string IsHasName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskFollowTarget.__PropertyOffset_IsHasName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskFollowTarget.__PropertyOffset_IsHasName)), value);
		}
	}

	// Token: 0x17000255 RID: 597
	// (get) Token: 0x06003E38 RID: 15928 RVA: 0x0005BF8F File Offset: 0x0005A18F
	// (set) Token: 0x06003E39 RID: 15929 RVA: 0x0005BF9F File Offset: 0x0005A19F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsInTag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFollowTarget.__PropertyOffset_IsInTag) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFollowTarget.__PropertyOffset_IsInTag) = (value ? 1 : 0);
		}
	}

	// Token: 0x06003E3A RID: 15930 RVA: 0x0005BFB0 File Offset: 0x0005A1B0
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsAngle = this.Angle;
			this.TsLength = this.Length;
			this.TsSpeed = this.Speed;
			this.TsStandSpeed = this.StandSpeed;
			this.TsRadius = this.Radius;
			this.TsNavigationRadius = this.NavigationRadius;
			this.TsMaxNavigationMillisecond = (double)this.MaxNavigationMillisecond;
			this.TsFollowPointName = this.FollowPointName;
			this.TsIsShowCube = this.IsShowCube;
			this.TsTags = new List<FGameplayTag>();
			int i = 0;
			int count = this.Tags.Count;
			while (i < count)
			{
				this.TsTags.Add(this.Tags.Get(i));
				i++;
			}
			this.TsWaitTime = this.WaitTime;
			this.TsBeginTimeName = this.BeginTimeName;
			this.TsIsHasName = this.IsHasName;
			this.TsIsInTag = this.IsInTag;
		}
	}

	// Token: 0x06003E3B RID: 15931 RVA: 0x0005C0B0 File Offset: 0x0005A2B0
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

	// Token: 0x06003E3C RID: 15932 RVA: 0x0005C149 File Offset: 0x0005A349
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		this.GetPath(ownerController, controlledPawn);
	}

	// Token: 0x06003E3D RID: 15933 RVA: 0x0005C15C File Offset: 0x0005A35C
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

	// Token: 0x06003E3E RID: 15934 RVA: 0x0005C1FC File Offset: 0x0005A3FC
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
		this.DelayDie(ownerController);
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		if (charActorComp.Entity.CheckGetComponent<BaseTagComponent>().HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"]))
		{
			charActorComp.SetInputDirect(Vector.ZeroVectorProxy, false);
			this.OnClear();
			return;
		}
		this.GetPath(ownerController, controlledPawn);
		if (!this.FoundPath)
		{
			return;
		}
		if (Singleton<Time>.Instance.WorldTime > this.NavigationEndTime)
		{
			base.Finish(false);
			return;
		}
		Vector vector = Vector.Create(this.NavigationPath[this.CurrentNavigationIndex]);
		vector.Subtraction(charActorComp.ActorLocationProxy, vector);
		vector.Z = 0.0;
		double num = vector.Size();
		TsBaseCharacter tsBaseCharacter = charActorComp.Owner as TsBaseCharacter;
		float? num2;
		if (tsBaseCharacter == null)
		{
			num2 = null;
		}
		else
		{
			UPawnMovementComponent movementComponent = tsBaseCharacter.GetMovementComponent();
			num2 = ((movementComponent != null) ? new float?(movementComponent.Velocity.Size()) : null);
		}
		float? num3 = num2;
		float valueOrDefault = num3.GetValueOrDefault();
		float num4 = ((this.TsSpeed != 0f) ? this.TsSpeed : 1f) * 0.017453292f;
		float num5 = valueOrDefault / num4 + 10f;
		if (num < (double)num5)
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
		AiControllerLibrary.TurnToDirect(charActorComp, vector, this.TsSpeed, false, 0f);
	}

	// Token: 0x06003E3F RID: 15935 RVA: 0x0005C3A8 File Offset: 0x0005A5A8
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void GetPath(AAIController ownerController, APawn controlledPawn)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetPath"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsTaskFollowTarget.__GetPath_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsTaskFollowTarget.__GetPath_FunctionParams*)ptr + 15L / (long)sizeof(TsTaskFollowTarget.__GetPath_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->ownerController) = ((ownerController != null) ? ownerController.NativePtr : ((IntPtr)0));
			*(&ptr2->controlledPawn) = ((controlledPawn != null) ? controlledPawn.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06003E40 RID: 15936 RVA: 0x0005C444 File Offset: 0x0005A644
	[NullableContext(2)]
	protected void GetPath_Implementation(AAIController ownerController, APawn controlledPawn)
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
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		CreatureDataComponent creatureDataComponent = charActorComp.Entity.CheckGetComponent<CreatureDataComponent>();
		int entityId = ModelBase<CreatureModel>.Instance.GetEntityId(creatureDataComponent.GetSummonerId());
		if (entityId != 0)
		{
			this.Source = ControllerBase<CharacterController>.Instance.GetCharacterActorComponentById(entityId);
			Vector vector = Vector.Create();
			this.Source.ActorForwardProxy.RotateAngleAxis((double)this.TsAngle, Vector.UpVectorProxy, vector);
			vector.Normalize(0.0001);
			vector.Multiply((double)this.TsLength, vector);
			vector.Addition(this.Source.ActorLocationProxy, vector);
			int num = 5;
			int num2 = 156;
			if (this.TsIsShowCube)
			{
				FVectorDouble fvectorDouble = vector.ToUeVector(false);
				this.DrawCube(new FTransformDouble?(new FTransformDouble(ref fvectorDouble)), (float)num, (float)num2);
			}
			double num3 = Vector.DistSquared(vector, charActorComp.ActorLocationProxy);
			if (this.TsIsShowCube)
			{
				FVectorDouble fvectorDouble = charActorComp.ActorLocation;
				this.DrawCube(new FTransformDouble?(new FTransformDouble(ref fvectorDouble)), (float)num, 0f);
			}
			if (num3 > (double)(this.TsNavigationRadius * this.TsNavigationRadius) || charActorComp.Entity.CheckGetComponent<BaseTagComponent>().HasTag(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.行走"]))
			{
				if (this.NavigationPath == null)
				{
					this.NavigationPath = new List<Vector>();
				}
				this.NavigationPath.Clear();
				if (num3 <= (double)(this.TsRadius * this.TsRadius))
				{
					ControllerBase<BlackboardController>.Instance.SetBooleanValueByEntity(aiController.CharAiDesignComp.Entity.Id, "FollowIsCanInput", true);
					charActorComp.Entity.CheckGetComponent<CharacterUnifiedStateComponent>().SetMoveState(ECharMoveState.Stand);
					this.OnClear();
					return;
				}
				this.FoundPath = AiControllerLibrary.NavigationFindPath(ownerController, charActorComp.ActorLocation, vector.ToUeVector(false), this.NavigationPath, null, null);
				if (this.NavigationPath.Count > 0)
				{
					ControllerBase<BlackboardController>.Instance.SetVectorValueByEntity(aiController.CharAiDesignComp.Entity.Id, this.TsFollowPointName, (double)((float)this.NavigationPath[this.NavigationPath.Count - 1].X), (double)((float)this.NavigationPath[this.NavigationPath.Count - 1].Y), (double)((float)this.NavigationPath[this.NavigationPath.Count - 1].Z));
				}
				this.CurrentNavigationIndex = 1;
				this.NavigationEndTime = Singleton<Time>.Instance.WorldTime + this.TsMaxNavigationMillisecond;
				charActorComp.Entity.CheckGetComponent<CharacterUnifiedStateComponent>().SetMoveState(ECharMoveState.Walk);
				ControllerBase<BlackboardController>.Instance.SetBooleanValueByEntity(aiController.CharAiDesignComp.Entity.Id, "FollowIsCanInput", false);
			}
			if (num3 <= (double)(this.TsRadius * this.TsRadius) && charActorComp.Entity.CheckGetComponent<BaseTagComponent>().HasTag(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.站立"]))
			{
				AiControllerLibrary.TurnToDirect(charActorComp, this.Source.ActorForwardProxy, this.TsStandSpeed, false, 0f);
				return;
			}
		}
		else
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.BehaviorTree;
			ELogAuthor author2 = ELogAuthor.ZQ;
			string message2 = "没有召唤Source对象 或者没有setRole";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			base.FinishExecute(false);
		}
	}

	// Token: 0x06003E41 RID: 15937 RVA: 0x0005C7E4 File Offset: 0x0005A9E4
	[NullableContext(2)]
	private bool DelayDie(AAIController ownerController)
	{
		TsAiController tsAiController = ownerController as TsAiController;
		if (tsAiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.ZQ;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		CharacterActorComponent charActorComp = tsAiController.AiController.CharActorComp;
		if (charActorComp == null)
		{
			return false;
		}
		CreatureDataComponent creatureDataComponent = charActorComp.Entity.CheckGetComponent<CreatureDataComponent>();
		int entityId = ModelBase<CreatureModel>.Instance.GetEntityId(creatureDataComponent.GetSummonerId());
		this.IsHas = ControllerBase<BlackboardController>.Instance.GetBooleanValueByEntity(tsAiController.AiController.CharAiDesignComp.Entity.Id, this.TsIsHasName).GetValueOrDefault();
		if (this.Source == null && entityId != 0)
		{
			this.Source = ControllerBase<CharacterController>.Instance.GetCharacterActorComponentById(entityId);
		}
		if (this.Source == null)
		{
			return false;
		}
		bool flag = false;
		foreach (FGameplayTag tag in this.TsTags)
		{
			bool flag2 = this.Source.Entity.CheckGetComponent<BaseTagComponent>().HasTag(tag.TagId());
			if ((this.TsIsInTag && flag2) || (!this.TsIsInTag && !flag2))
			{
				if (!this.IsHas)
				{
					ControllerBase<BlackboardController>.Instance.SetIntValueByEntity(tsAiController.AiController.CharAiDesignComp.Entity.Id, this.TsBeginTimeName, (int)Singleton<Time>.Instance.WorldTime);
					ControllerBase<BlackboardController>.Instance.SetBooleanValueByEntity(tsAiController.AiController.CharAiDesignComp.Entity.Id, this.TsIsHasName, true);
					this.IsHas = true;
				}
				flag = true;
			}
		}
		if (!flag)
		{
			ControllerBase<BlackboardController>.Instance.SetBooleanValueByEntity(tsAiController.AiController.CharAiDesignComp.Entity.Id, this.TsIsHasName, false);
			return false;
		}
		int? intValueByEntity = ControllerBase<BlackboardController>.Instance.GetIntValueByEntity(tsAiController.AiController.CharAiDesignComp.Entity.Id, this.TsBeginTimeName);
		double worldTime = Singleton<Time>.Instance.WorldTime;
		int? num = intValueByEntity;
		int num2 = 0;
		int? num3 = (!(num.GetValueOrDefault() == num2 & num != null)) ? intValueByEntity : new int?(0);
		intValueByEntity = new int?((int)(worldTime - ((num3 != null) ? new double?((double)num3.GetValueOrDefault()) : null)).Value);
		num3 = intValueByEntity;
		float? num4 = (num3 != null) ? new float?((float)num3.GetValueOrDefault()) : null;
		float tsWaitTime = this.TsWaitTime;
		if (num4.GetValueOrDefault() >= tsWaitTime & num4 != null)
		{
			if (entityId != 0 && ControllerBase<CharacterController>.Instance.GetCharacterActorComponentById(entityId) != null)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnClearFollowData, tsAiController.AiController.CharAiDesignComp.Entity.Id);
			}
			return true;
		}
		return false;
	}

	// Token: 0x06003E42 RID: 15938 RVA: 0x0005CB04 File Offset: 0x0005AD04
	protected override void OnClear()
	{
		TsAiController tsAiController = base.AIOwner as TsAiController;
		if (tsAiController != null)
		{
			AiControllerLibrary.ClearInput(tsAiController);
		}
		this.NavigationPath = null;
		this.Source = null;
		this.FoundPath = false;
	}

	// Token: 0x06003E43 RID: 15939 RVA: 0x0005CB3C File Offset: 0x0005AD3C
	protected void DrawCube(FTransformDouble? transform, float duration, float colorValue)
	{
		if (transform == null)
		{
			return;
		}
		FTransformDouble value = transform.Value;
		FLinearColor lineColor = new FLinearColor(colorValue, colorValue, colorValue, colorValue);
		FVectorDouble location = value.GetLocation();
		FVector fvector = new FVector(10f, 10f, 10f);
		FVectorDouble extent = new FVectorDouble((double)fvector.X * 0.5, (double)fvector.Y * 0.5, (double)fvector.Z * 0.5);
		FRotator rotation = value.Rotator();
		float thickness = 30f;
		UKismetSystemLibrary.D_DrawDebugBox(GlobalData.World, location, extent, lineColor, rotation, duration, thickness);
		FVectorDouble lineStart = UKismetMathLibrary.D_TransformLocation(value, new FVectorDouble(0.5, 0.5, 0.5));
		FVectorDouble lineEnd = UKismetMathLibrary.D_TransformLocation(value, new FVectorDouble(-0.5, -0.5, -0.5));
		float thickness2 = 15f;
		UKismetSystemLibrary.D_DrawDebugLine(GlobalData.World, lineStart, lineEnd, lineColor, duration, thickness2);
		FVectorDouble lineStart2 = UKismetMathLibrary.D_TransformLocation(value, new FVectorDouble(0.5, -0.5, 0.5));
		FVectorDouble lineEnd2 = UKismetMathLibrary.D_TransformLocation(value, new FVectorDouble(-0.5, 0.5, 0.5));
		UKismetSystemLibrary.D_DrawDebugLine(GlobalData.World, lineStart2, lineEnd2, lineColor, duration, thickness2);
	}

	// Token: 0x06003E44 RID: 15940 RVA: 0x0005CCB0 File Offset: 0x0005AEB0
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskFollowTarget._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskFollowTarget.TsTaskFollowTarget_C");
		}
		return TsTaskFollowTarget._ClassPtr;
	}

	// Token: 0x06003E45 RID: 15941 RVA: 0x0005CCD4 File Offset: 0x0005AED4
	public TsTaskFollowTarget() : this(BuiltinUtils.AllocNativeUObject(TsTaskFollowTarget.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003E46 RID: 15942 RVA: 0x0005CCFC File Offset: 0x0005AEFC
	public TsTaskFollowTarget(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskFollowTarget.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003E47 RID: 15943 RVA: 0x0005CD2F File Offset: 0x0005AF2F
	protected TsTaskFollowTarget(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003E48 RID: 15944 RVA: 0x0005CD5C File Offset: 0x0005AF5C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06003E49 RID: 15945 RVA: 0x0005CD8C File Offset: 0x0005AF8C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x06003E4A RID: 15946 RVA: 0x0005CDC0 File Offset: 0x0005AFC0
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetPath_Implementation(TsTaskFollowTarget.__GetPath_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->ownerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->controlledPawn);
		this.GetPath_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000D18 RID: 3352
	private const float NAVIGATION_COMPLETE_DISTANCE = 10f;

	// Token: 0x04000D19 RID: 3353
	[Nullable(2)]
	private CharacterActorComponent Source;

	// Token: 0x04000D1A RID: 3354
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<Vector> NavigationPath;

	// Token: 0x04000D1B RID: 3355
	private double NavigationEndTime;

	// Token: 0x04000D1C RID: 3356
	private bool FoundPath;

	// Token: 0x04000D1D RID: 3357
	private int CurrentNavigationIndex;

	// Token: 0x04000D1E RID: 3358
	protected double BeginTime;

	// Token: 0x04000D1F RID: 3359
	protected bool IsHas;

	// Token: 0x04000D20 RID: 3360
	private bool IsInitTsVariables;

	// Token: 0x04000D21 RID: 3361
	private float TsAngle;

	// Token: 0x04000D22 RID: 3362
	private float TsLength;

	// Token: 0x04000D23 RID: 3363
	private float TsSpeed;

	// Token: 0x04000D24 RID: 3364
	private float TsStandSpeed;

	// Token: 0x04000D25 RID: 3365
	private float TsRadius;

	// Token: 0x04000D26 RID: 3366
	private float TsNavigationRadius;

	// Token: 0x04000D27 RID: 3367
	private double TsMaxNavigationMillisecond;

	// Token: 0x04000D28 RID: 3368
	private string TsFollowPointName = "";

	// Token: 0x04000D29 RID: 3369
	private bool TsIsShowCube;

	// Token: 0x04000D2A RID: 3370
	[Nullable(2)]
	private List<FGameplayTag> TsTags;

	// Token: 0x04000D2B RID: 3371
	private float TsWaitTime;

	// Token: 0x04000D2C RID: 3372
	private string TsBeginTimeName = "";

	// Token: 0x04000D2D RID: 3373
	private string TsIsHasName = "";

	// Token: 0x04000D2E RID: 3374
	private bool TsIsInTag;

	// Token: 0x04000D2F RID: 3375
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskFollowTarget.TsTaskFollowTarget_C";

	// Token: 0x04000D30 RID: 3376
	private static IntPtr _ClassPtr;

	// Token: 0x04000D31 RID: 3377
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000D32 RID: 3378
	private static int __PropertyOffset_Angle;

	// Token: 0x04000D33 RID: 3379
	private static int __PropertyOffset_Length;

	// Token: 0x04000D34 RID: 3380
	private static int __PropertyOffset_Speed;

	// Token: 0x04000D35 RID: 3381
	private static int __PropertyOffset_StandSpeed;

	// Token: 0x04000D36 RID: 3382
	private static int __PropertyOffset_Radius;

	// Token: 0x04000D37 RID: 3383
	private static int __PropertyOffset_NavigationRadius;

	// Token: 0x04000D38 RID: 3384
	private static int __PropertyOffset_MaxNavigationMillisecond;

	// Token: 0x04000D39 RID: 3385
	private static int __PropertyOffset_FollowPointName;

	// Token: 0x04000D3A RID: 3386
	private static int __PropertyOffset_IsShowCube;

	// Token: 0x04000D3B RID: 3387
	private static int __PropertyOffset_Tags;

	// Token: 0x04000D3C RID: 3388
	[Nullable(2)]
	private TArray<FGameplayTag> _Tags;

	// Token: 0x04000D3D RID: 3389
	private static int __PropertyOffset_WaitTimeName;

	// Token: 0x04000D3E RID: 3390
	private static int __PropertyOffset_WaitTime;

	// Token: 0x04000D3F RID: 3391
	private static int __PropertyOffset_BeginTimeName;

	// Token: 0x04000D40 RID: 3392
	private static int __PropertyOffset_IsHasName;

	// Token: 0x04000D41 RID: 3393
	private static int __PropertyOffset_IsInTag;

	// Token: 0x020071D4 RID: 29140
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetPath_FunctionParams
	{
		// Token: 0x040279C4 RID: 162244
		[FieldOffset(0)]
		public IntPtr ownerController;

		// Token: 0x040279C5 RID: 162245
		[FieldOffset(8)]
		public IntPtr controlledPawn;
	}
}
