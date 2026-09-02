using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using CSharpScript.Game.NewWorld.Pawn.Component;
using UnrealEngine;

// Token: 0x02003232 RID: 12850
[NullableContext(1)]
[Nullable(0)]
public class UeSkeletalTickManageComponent : EntityComponent, IComponentDependency
{
	// Token: 0x17002448 RID: 9288
	// (get) Token: 0x0601ABBB RID: 109499 RVA: 0x007F67CD File Offset: 0x007F49CD
	// (set) Token: 0x0601ABBC RID: 109500 RVA: 0x007F67D8 File Offset: 0x007F49D8
	public ESkeletalMeshTickMode TickMode
	{
		get
		{
			return this.TickModeInternal;
		}
		protected set
		{
			if (this.TickModeInternal == value)
			{
				return;
			}
			ESkeletalMeshTickMode tickModeInternal = this.TickModeInternal;
			this.TickModeInternal = value;
			if (value == ESkeletalMeshTickMode.TsProxy)
			{
				if (tickModeInternal == ESkeletalMeshTickMode.TsProxyMainMeshNotParallel)
				{
					if (this.SkeletalComps.Count > 0)
					{
						Singleton<TickSystem>.Instance.SetSkeletalMeshProxyTickFunction(ETickingGroup.TG_PrePhysics, this.SkeletalComps[0], 0);
						goto IL_33E;
					}
					goto IL_33E;
				}
				else
				{
					foreach (USkeletalMeshComponent comp in this.SkeletalComps)
					{
						Singleton<TickSystem>.Instance.SetSkeletalMeshProxyTickFunction(ETickingGroup.TG_PrePhysics, comp, 0);
					}
					using (List<USkeletalMeshComponent>.Enumerator enumerator = this.FollowSkeletalComps.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							USkeletalMeshComponent comp2 = enumerator.Current;
							Singleton<TickSystem>.Instance.SetSkeletalMeshProxyTickFunction(ETickingGroup.TG_PostPhysics, comp2, 0);
						}
						goto IL_33E;
					}
				}
			}
			if (value == ESkeletalMeshTickMode.TsProxyMainMeshNotParallel)
			{
				if (tickModeInternal == ESkeletalMeshTickMode.TsProxy)
				{
					if (this.SkeletalComps.Count > 0)
					{
						Singleton<TickSystem>.Instance.CleanSkeletalMeshProxyTickFunction(this.SkeletalComps[0]);
						goto IL_33E;
					}
					goto IL_33E;
				}
				else
				{
					int num = 0;
					foreach (USkeletalMeshComponent comp3 in this.SkeletalComps)
					{
						if (num > 0)
						{
							Singleton<TickSystem>.Instance.SetSkeletalMeshProxyTickFunction(ETickingGroup.TG_PrePhysics, comp3, 0);
						}
						num++;
					}
					using (List<USkeletalMeshComponent>.Enumerator enumerator = this.FollowSkeletalComps.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							USkeletalMeshComponent comp4 = enumerator.Current;
							Singleton<TickSystem>.Instance.SetSkeletalMeshProxyTickFunction(ETickingGroup.TG_PostPhysics, comp4, 0);
						}
						goto IL_33E;
					}
				}
			}
			foreach (USkeletalMeshComponent uskeletalMeshComponent in this.SkeletalComps)
			{
				if (!uskeletalMeshComponent.IsValid())
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Test;
					ELogAuthor author = ELogAuthor.LCZ;
					string message = "NoSkeletalMesh";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
					string item = "EntityId";
					Entity entity = base.Entity;
					ptr = new ValueTuple<string, object>(item, (entity != null) ? new int?(entity.Id) : null);
					ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
					string item2 = "Actor";
					BaseActorComponent actorComp = this.ActorComp;
					ptr2 = new ValueTuple<string, object>(item2, (actorComp != null) ? actorComp.Owner : null);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
				Singleton<TickSystem>.Instance.CleanSkeletalMeshProxyTickFunction(uskeletalMeshComponent);
			}
			foreach (USkeletalMeshComponent uskeletalMeshComponent2 in this.FollowSkeletalComps)
			{
				if (!uskeletalMeshComponent2.IsValid())
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Test;
					ELogAuthor author2 = ELogAuthor.LCZ;
					string message2 = "NoSkeletalMesh";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					ref ValueTuple<string, object> ptr3 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0);
					string item3 = "EntityId";
					Entity entity2 = base.Entity;
					ptr3 = new ValueTuple<string, object>(item3, (entity2 != null) ? new int?(entity2.Id) : null);
					ref ValueTuple<string, object> ptr4 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1);
					string item4 = "Actor";
					BaseActorComponent actorComp2 = this.ActorComp;
					ptr4 = new ValueTuple<string, object>(item4, (actorComp2 != null) ? actorComp2.Owner : null);
					instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				}
				Singleton<TickSystem>.Instance.CleanSkeletalMeshProxyTickFunction(uskeletalMeshComponent2);
			}
			IL_33E:
			UeSkeletalTickController.DeleteManager(this);
			if (value == ESkeletalMeshTickMode.TsProxy || value == ESkeletalMeshTickMode.TsProxyMainMeshNotParallel)
			{
				UeSkeletalTickController.AddManager(this);
			}
			if (value == ESkeletalMeshTickMode.UeUpdate)
			{
				foreach (USkeletalMeshComponent uskeletalMeshComponent3 in this.SkeletalComps)
				{
					uskeletalMeshComponent3.SetTickGroup(ETickingGroup.TG_StartPhysics);
					uskeletalMeshComponent3.SetComponentTickEnabled(base.Active && !this.DisabledSet.Contains(uskeletalMeshComponent3));
					uskeletalMeshComponent3.SetKuroOnlyTickOutside(false);
				}
				using (List<USkeletalMeshComponent>.Enumerator enumerator = this.FollowSkeletalComps.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						USkeletalMeshComponent uskeletalMeshComponent4 = enumerator.Current;
						uskeletalMeshComponent4.SetTickGroup(ETickingGroup.TG_StartPhysics);
						uskeletalMeshComponent4.SetComponentTickEnabled(base.Active && !this.DisabledSet.Contains(uskeletalMeshComponent4));
						uskeletalMeshComponent4.SetKuroOnlyTickOutside(false);
					}
					return;
				}
			}
			foreach (USkeletalMeshComponent uskeletalMeshComponent5 in this.SkeletalComps)
			{
				uskeletalMeshComponent5.SetTickGroup(ETickingGroup.TG_PrePhysics);
				uskeletalMeshComponent5.SetComponentTickEnabled(false);
				uskeletalMeshComponent5.SetKuroOnlyTickOutside(true);
			}
			foreach (USkeletalMeshComponent uskeletalMeshComponent6 in this.FollowSkeletalComps)
			{
				uskeletalMeshComponent6.SetTickGroup(ETickingGroup.TG_PostPhysics);
				uskeletalMeshComponent6.SetComponentTickEnabled(false);
				uskeletalMeshComponent6.SetKuroOnlyTickOutside(true);
			}
		}
	}

	// Token: 0x17002449 RID: 9289
	// (get) Token: 0x0601ABBD RID: 109501 RVA: 0x007F6D08 File Offset: 0x007F4F08
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public static Type[] Dependencies
	{
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		get
		{
			return new Type[]
			{
				typeof(BaseActorComponent)
			};
		}
	}

	// Token: 0x0601ABBE RID: 109502 RVA: 0x007F6D1D File Offset: 0x007F4F1D
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x0601ABBF RID: 109503 RVA: 0x007F6D20 File Offset: 0x007F4F20
	protected override void OnActivate()
	{
		this.ActorComp = base.Entity.GetComponent<BaseActorComponent>();
		this.UnifiedStateComp = base.Entity.GetComponent<BaseUnifiedStateComponent>();
		TArray<UActorComponent> tarray = this.ActorComp.Owner.K2_GetComponentsByClass(USkeletalMeshComponent.StaticClass());
		int num = tarray.Num();
		for (int i = 0; i < num; i++)
		{
			USkeletalMeshComponent uskeletalMeshComponent = tarray.Get(i) as USkeletalMeshComponent;
			if (uskeletalMeshComponent != null)
			{
				uskeletalMeshComponent.bConsumeAllRootMotion = true;
				if (uskeletalMeshComponent.MasterPoseComponent.IsValid(false, false))
				{
					this.FollowSkeletalComps.Add(uskeletalMeshComponent);
				}
				else
				{
					this.SkeletalComps.Add(uskeletalMeshComponent);
					if (this.MainSkelComp == null)
					{
						this.MainSkelComp = uskeletalMeshComponent;
					}
					else
					{
						uskeletalMeshComponent.PrerequisiteComp = this.MainSkelComp;
					}
				}
				if (this.MainAnimInstance == null)
				{
					this.MainAnimInstance = uskeletalMeshComponent.GetAnimInstance();
				}
			}
		}
		if (this.MainAnimInstance != null)
		{
			this.MainAnimInstance.SetDelayAnimTime(0f, 0f);
		}
		if (Singleton<PerformanceController>.Instance.IsEntityTickPerformanceTest)
		{
			this.TickMode = ESkeletalMeshTickMode.TsProxy;
		}
		else
		{
			this.RefreshTickMode();
		}
		CharacterAnimationComponent component = base.Entity.GetComponent<CharacterAnimationComponent>();
		if (!base.Active && component != null)
		{
			Singleton<TickProcessSystem>.Instance.RegisterOnceTickProcess(ETickingGroup.TG_PostUpdateWork, true, new Action<float>(component.EndAnimNotifyStates));
		}
		this.TickType = ESkeletalMeshTickType.AlwaysTick;
	}

	// Token: 0x0601ABC0 RID: 109504 RVA: 0x007F6E70 File Offset: 0x007F5070
	protected override bool OnEnd()
	{
		this.TickMode = ESkeletalMeshTickMode.None;
		this.TickType = ESkeletalMeshTickType.Unknown;
		foreach (USkeletalMeshComponent uskeletalMeshComponent in this.SkeletalComps)
		{
			uskeletalMeshComponent.SetComponentTickEnabled(false);
		}
		return true;
	}

	// Token: 0x0601ABC1 RID: 109505 RVA: 0x007F6ED0 File Offset: 0x007F50D0
	protected override void OnTick(float delta)
	{
		float num = delta * 0.001f;
		PawnTimeScaleComponent component = base.Entity.GetComponent<PawnTimeScaleComponent>();
		float num2 = num * ((component != null) ? component.CurrentTimeScale : 1f);
		if (base.Entity.GetTickInterval() > 1 && this.ForceDisableAnimDelaySet.Count == 0)
		{
			UAnimInstance mainAnimInstance = this.MainAnimInstance;
			if (mainAnimInstance != null)
			{
				mainAnimInstance.SetDelayAnimTime(Math.Min(2f, num2), Math.Min(0.125f, num2 / 2f));
			}
		}
		else
		{
			BaseUnifiedStateComponent unifiedStateComp = this.UnifiedStateComp;
			if (unifiedStateComp != null && unifiedStateComp.IsInFighting)
			{
				UAnimInstance mainAnimInstance2 = this.MainAnimInstance;
				if (mainAnimInstance2 != null)
				{
					mainAnimInstance2.SetDelayAnimTime(0f, 2f);
				}
			}
			else
			{
				UAnimInstance mainAnimInstance3 = this.MainAnimInstance;
				if (mainAnimInstance3 != null)
				{
					mainAnimInstance3.SetDelayAnimTime(0f, Math.Min(0.125f, num2));
				}
			}
		}
		if (this.TickMode == ESkeletalMeshTickMode.TsTakeOver)
		{
			this.TakeOverModeTick(num2);
		}
		this.RefreshTickMode();
	}

	// Token: 0x0601ABC2 RID: 109506 RVA: 0x007F6FB4 File Offset: 0x007F51B4
	protected void TakeOverModeTick(float realTimeSeconds)
	{
		if (this.TickMode != ESkeletalMeshTickMode.TsTakeOver)
		{
			return;
		}
		this.LastTickFrame = Singleton<Time>.Instance.Frame;
		UAnimInstance mainAnimInstance = this.MainAnimInstance;
		if (mainAnimInstance != null)
		{
			mainAnimInstance.AddDeltaForDelayAnim(realTimeSeconds);
		}
		this.CleanupInvalidSkeletalComps();
		foreach (USkeletalMeshComponent uskeletalMeshComponent in this.SkeletalComps)
		{
			if (!this.DisabledSet.Contains(uskeletalMeshComponent) && (this.TickType != ESkeletalMeshTickType.OnlyMainMeshTick || this.CheckMainMesh(uskeletalMeshComponent)))
			{
				uskeletalMeshComponent.KuroTickComponentOutside(realTimeSeconds);
			}
		}
		if (this.TickType != ESkeletalMeshTickType.OnlyMainMeshTick)
		{
			foreach (USkeletalMeshComponent uskeletalMeshComponent2 in this.FollowSkeletalComps)
			{
				if (!this.DisabledSet.Contains(uskeletalMeshComponent2))
				{
					uskeletalMeshComponent2.KuroTickComponentOutside(realTimeSeconds);
				}
			}
		}
	}

	// Token: 0x0601ABC3 RID: 109507 RVA: 0x007F70B4 File Offset: 0x007F52B4
	public void ProxyTick(float deltaSeconds, bool delayCompleteParallel = false)
	{
		if (this.TickType != ESkeletalMeshTickType.AlwaysTick && this.TickType != ESkeletalMeshTickType.OnlyMainMeshTick)
		{
			return;
		}
		this.LastTickFrame = Singleton<Time>.Instance.Frame;
		PawnTimeScaleComponent component = base.Entity.GetComponent<PawnTimeScaleComponent>();
		float? num = (component != null) ? new float?(component.CurrentTimeScale) : null;
		float num2 = deltaSeconds * base.TimeDilation;
		float num5;
		if (num != null)
		{
			if (this.EnableFirstFrame)
			{
				float? num3 = num;
				float num4 = 0f;
				if (num3.GetValueOrDefault() == num4 & num3 != null)
				{
					goto IL_86;
				}
			}
			num5 = num.Value;
			goto IL_8B;
		}
		IL_86:
		num5 = 1f;
		IL_8B:
		float num6 = num2 * num5;
		UAnimInstance mainAnimInstance = this.MainAnimInstance;
		if (mainAnimInstance != null)
		{
			mainAnimInstance.AddDeltaForDelayAnim(num6);
		}
		this.CleanupInvalidSkeletalComps();
		this.TickedComps.Clear();
		foreach (USkeletalMeshComponent uskeletalMeshComponent in this.SkeletalComps)
		{
			bool flag = this.CheckMainMesh(uskeletalMeshComponent);
			if ((this.TickType != ESkeletalMeshTickType.OnlyMainMeshTick || flag) && !this.DisabledSet.Contains(uskeletalMeshComponent))
			{
				if (delayCompleteParallel && (!flag || this.TickMode != ESkeletalMeshTickMode.TsProxyMainMeshNotParallel))
				{
					this.TickedComps.Add(uskeletalMeshComponent);
				}
				uskeletalMeshComponent.KuroTickComponentOutside(num6);
			}
		}
	}

	// Token: 0x0601ABC4 RID: 109508 RVA: 0x007F7200 File Offset: 0x007F5400
	public void UnlockEvaluation()
	{
		foreach (USkeletalMeshComponent uskeletalMeshComponent in this.TickedComps)
		{
			uskeletalMeshComponent.UnlockKuroEvaluation();
		}
	}

	// Token: 0x0601ABC5 RID: 109509 RVA: 0x007F7250 File Offset: 0x007F5450
	public void DealComplete()
	{
		foreach (USkeletalMeshComponent uskeletalMeshComponent in this.TickedComps)
		{
			uskeletalMeshComponent.DealCompleteParallelEvaluation();
		}
	}

	// Token: 0x0601ABC6 RID: 109510 RVA: 0x007F72A0 File Offset: 0x007F54A0
	public void AfterProxyTick(float deltaSeconds)
	{
		if (this.TickType != ESkeletalMeshTickType.AlwaysTick)
		{
			return;
		}
		this.CleanupInvalidSkeletalComps();
		PawnTimeScaleComponent component = base.Entity.GetComponent<PawnTimeScaleComponent>();
		float? num = (component != null) ? new float?(component.CurrentTimeScale) : null;
		float num2 = deltaSeconds * base.TimeDilation;
		float num5;
		if (num != null)
		{
			if (this.EnableFirstFrame)
			{
				float? num3 = num;
				float num4 = 0f;
				if (num3.GetValueOrDefault() == num4 & num3 != null)
				{
					goto IL_73;
				}
			}
			num5 = num.Value;
			goto IL_78;
		}
		IL_73:
		num5 = 1f;
		IL_78:
		float deltaSeconds2 = num2 * num5;
		if (this.EnableFirstFrame)
		{
			this.EnableFirstFrame = false;
			if (this.LastTickFrame != Singleton<Time>.Instance.Frame)
			{
				foreach (USkeletalMeshComponent uskeletalMeshComponent in this.SkeletalComps)
				{
					uskeletalMeshComponent.KuroTickComponentOutside(deltaSeconds);
				}
			}
		}
		USkeletalMeshComponent mainSkelComp = this.MainSkelComp;
		if (mainSkelComp != null && mainSkelComp.RenderedAndNotSkipUpdate())
		{
			foreach (USkeletalMeshComponent uskeletalMeshComponent2 in this.FollowSkeletalComps)
			{
				if (!this.DisabledSet.Contains(uskeletalMeshComponent2))
				{
					uskeletalMeshComponent2.KuroTickComponentOutside(deltaSeconds2);
				}
			}
		}
	}

	// Token: 0x0601ABC7 RID: 109511 RVA: 0x007F73F8 File Offset: 0x007F55F8
	protected override void OnEnable()
	{
		if (this.TickMode != ESkeletalMeshTickMode.TsTakeOver)
		{
			this.EnableFirstFrame = true;
		}
		if (this.TickMode == ESkeletalMeshTickMode.UeUpdate)
		{
			foreach (USkeletalMeshComponent uskeletalMeshComponent in this.SkeletalComps)
			{
				uskeletalMeshComponent.SetComponentTickEnabled(true);
			}
		}
	}

	// Token: 0x0601ABC8 RID: 109512 RVA: 0x007F7464 File Offset: 0x007F5664
	protected override void OnDisable(string reason)
	{
		if (this.TickMode == ESkeletalMeshTickMode.UeUpdate)
		{
			foreach (USkeletalMeshComponent uskeletalMeshComponent in this.SkeletalComps)
			{
				uskeletalMeshComponent.SetComponentTickEnabled(false);
			}
		}
		UAnimInstance mainAnimInstance = this.MainAnimInstance;
		if (mainAnimInstance == null)
		{
			return;
		}
		mainAnimInstance.SetDelayAnimTime(0f, 2f);
	}

	// Token: 0x0601ABC9 RID: 109513 RVA: 0x007F74D8 File Offset: 0x007F56D8
	public void SetTakeOverTick(bool takeOver)
	{
		this.IsTakeOver = takeOver;
		this.RefreshTickMode();
	}

	// Token: 0x0601ABCA RID: 109514 RVA: 0x007F74E8 File Offset: 0x007F56E8
	public void SetLodBias(int lodBias)
	{
		foreach (USkeletalMeshComponent uskeletalMeshComponent in this.SkeletalComps)
		{
			uskeletalMeshComponent.SetLODBias(lodBias);
		}
	}

	// Token: 0x0601ABCB RID: 109515 RVA: 0x007F753C File Offset: 0x007F573C
	public unsafe bool SetSkeletalMeshTickType(ESkeletalMeshTickType type)
	{
		if (this.TickType == type)
		{
			return true;
		}
		BaseActorComponent actorComp = this.ActorComp;
		int? num = (actorComp != null) ? new int?(actorComp.CreatureData.GetPbDataId()) : null;
		long? num2 = (num != null) ? new long?((long)num.GetValueOrDefault()) : null;
		this.TickType = type;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Character;
		ELogAuthor author = ELogAuthor.YJX;
		string message = "[SetSkeletalMeshTickType] 设置SkeletalMeshTickType";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Type", type);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PbDataId", num2);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		return true;
	}

	// Token: 0x0601ABCC RID: 109516 RVA: 0x007F7601 File Offset: 0x007F5801
	protected bool CheckMainMesh(USkeletalMeshComponent skeletalComp)
	{
		return skeletalComp.IsValid() && skeletalComp.GetFName() == UeSkeletalTickManageComponent.MainMeshName;
	}

	// Token: 0x0601ABCD RID: 109517 RVA: 0x007F761D File Offset: 0x007F581D
	private void RefreshTickMode()
	{
		if (this.IsTakeOver)
		{
			this.TickMode = ESkeletalMeshTickMode.TsTakeOver;
			return;
		}
		if (!UeSkeletalTickController.MainRoleParallel && this.IsMainRole())
		{
			this.TickMode = ESkeletalMeshTickMode.TsProxyMainMeshNotParallel;
			return;
		}
		this.TickMode = ESkeletalMeshTickMode.TsProxy;
	}

	// Token: 0x0601ABCE RID: 109518 RVA: 0x007F764D File Offset: 0x007F584D
	protected bool IsMainRole()
	{
		BaseActorComponent actorComp = this.ActorComp;
		return ((actorComp != null) ? actorComp.Owner : null) == Global.BaseCharacter;
	}

	// Token: 0x0601ABCF RID: 109519 RVA: 0x007F7668 File Offset: 0x007F5868
	public bool StartForceDisableAnimDelay(EForceDisableAnimDelayReason reason)
	{
		if (this.ForceDisableAnimDelaySet.Contains(reason))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CH;
			string message = "动画缓动强制关闭 - 重复";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Reason", reason);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		this.ForceDisableAnimDelaySet.Add(reason);
		return true;
	}

	// Token: 0x0601ABD0 RID: 109520 RVA: 0x007F76BF File Offset: 0x007F58BF
	public void CancelForceDisableAnimDelay(EForceDisableAnimDelayReason reason)
	{
		this.ForceDisableAnimDelaySet.Remove(reason);
	}

	// Token: 0x0601ABD1 RID: 109521 RVA: 0x007F76CE File Offset: 0x007F58CE
	public void RefreshCharacterAnimInstance()
	{
		BaseActorComponent actorComp = this.ActorComp;
		UAnimInstance mainAnimInstance;
		if (actorComp == null)
		{
			mainAnimInstance = null;
		}
		else
		{
			USkeletalMeshComponent skeletalMesh = actorComp.SkeletalMesh;
			mainAnimInstance = ((skeletalMesh != null) ? skeletalMesh.GetAnimInstance() : null);
		}
		this.MainAnimInstance = mainAnimInstance;
		UAnimInstance mainAnimInstance2 = this.MainAnimInstance;
		if (mainAnimInstance2 == null)
		{
			return;
		}
		mainAnimInstance2.SetDelayAnimTime(0f, 0f);
	}

	// Token: 0x0601ABD2 RID: 109522 RVA: 0x007F7710 File Offset: 0x007F5910
	public void AddOrRefreshSkeletalMeshComponent(USkeletalMeshComponent component)
	{
		if (this.ActorComp == null)
		{
			return;
		}
		if (component.GetOwner() != this.ActorComp.Owner)
		{
			Singleton<Log>.Instance.Error(ELogModule.Test, ELogAuthor.LCZ, "只能添加自身Actor的Component", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.MainSkelComp == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.Test, ELogAuthor.LCZ, "在初始化前不能添加SkelComp。会在OnActivate时自动加入", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (component.MasterPoseComponent.IsValid(false, false))
		{
			int num = this.FollowSkeletalComps.IndexOf(component);
			if (num < 0)
			{
				this.FollowSkeletalComps.Add(component);
			}
			num = this.SkeletalComps.IndexOf(component);
			if (num >= 0)
			{
				this.SkeletalComps[num] = this.SkeletalComps[this.SkeletalComps.Count - 1];
				this.SkeletalComps.RemoveAt(this.SkeletalComps.Count - 1);
			}
		}
		else
		{
			int num2 = this.SkeletalComps.IndexOf(component);
			if (num2 < 0)
			{
				this.SkeletalComps.Add(component);
			}
			num2 = this.FollowSkeletalComps.IndexOf(component);
			if (num2 >= 0)
			{
				this.FollowSkeletalComps[num2] = this.FollowSkeletalComps[this.FollowSkeletalComps.Count - 1];
				this.FollowSkeletalComps.RemoveAt(this.FollowSkeletalComps.Count - 1);
			}
		}
		if (this.TickMode == ESkeletalMeshTickMode.UeUpdate)
		{
			component.SetTickGroup(ETickingGroup.TG_StartPhysics);
			component.SetComponentTickEnabled(base.Active && !this.DisabledSet.Contains(component));
			component.SetKuroOnlyTickOutside(false);
			return;
		}
		component.SetTickGroup(component.MasterPoseComponent.IsValid(false, false) ? ETickingGroup.TG_PostPhysics : ETickingGroup.TG_PrePhysics);
		component.SetComponentTickEnabled(false);
		component.SetKuroOnlyTickOutside(true);
	}

	// Token: 0x0601ABD3 RID: 109523 RVA: 0x007F78C8 File Offset: 0x007F5AC8
	public void EnableOrDisableSkelTick(USkeletalMeshComponent component, bool enable = true)
	{
		if (enable)
		{
			this.DisabledSet.Remove(component);
		}
		else
		{
			this.DisabledSet.Add(component);
		}
		if (this.TickMode == ESkeletalMeshTickMode.UeUpdate)
		{
			component.SetComponentTickEnabled(base.Active && !this.DisabledSet.Contains(component));
		}
	}

	// Token: 0x0601ABD4 RID: 109524 RVA: 0x007F7920 File Offset: 0x007F5B20
	private void CleanupInvalidSkeletalComps()
	{
		for (int i = this.SkeletalComps.Count - 1; i >= 0; i--)
		{
			USkeletalMeshComponent uskeletalMeshComponent = this.SkeletalComps[i];
			if (!uskeletalMeshComponent.IsValid())
			{
				this.SkeletalComps[i] = this.SkeletalComps[this.SkeletalComps.Count - 1];
				this.SkeletalComps.RemoveAt(this.SkeletalComps.Count - 1);
				this.DisabledSet.Remove(uskeletalMeshComponent);
				if (this.MainSkelComp == uskeletalMeshComponent)
				{
					this.MainSkelComp = null;
				}
			}
		}
		for (int j = this.FollowSkeletalComps.Count - 1; j >= 0; j--)
		{
			USkeletalMeshComponent uskeletalMeshComponent2 = this.FollowSkeletalComps[j];
			if (!uskeletalMeshComponent2.IsValid())
			{
				this.FollowSkeletalComps[j] = this.FollowSkeletalComps[this.FollowSkeletalComps.Count - 1];
				this.FollowSkeletalComps.RemoveAt(this.FollowSkeletalComps.Count - 1);
				this.DisabledSet.Remove(uskeletalMeshComponent2);
			}
		}
	}

	// Token: 0x0601ABD5 RID: 109525 RVA: 0x007F7A2C File Offset: 0x007F5C2C
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		UeSkeletalTickManageComponent ueSkeletalTickManageComponent = (UeSkeletalTickManageComponent)componentTemplate;
		if (base.CanResetComponentProperty("EnableFirstFrame"))
		{
			this.EnableFirstFrame = ueSkeletalTickManageComponent.EnableFirstFrame;
		}
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (ueSkeletalTickManageComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("UnifiedStateComp"))
		{
			if (ueSkeletalTickManageComponent.UnifiedStateComp == null)
			{
				this.UnifiedStateComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseUnifiedStateComponent>(this.UnifiedStateComp), "UnifiedStateComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("LastTickFrame"))
		{
			this.LastTickFrame = ueSkeletalTickManageComponent.LastTickFrame;
		}
		if (base.CanResetComponentProperty("IsTakeOver"))
		{
			this.IsTakeOver = ueSkeletalTickManageComponent.IsTakeOver;
		}
		if (base.CanResetComponentProperty("TickModeInternal"))
		{
			this.TickModeInternal = ueSkeletalTickManageComponent.TickModeInternal;
		}
		if (base.CanResetComponentProperty("ProxyTickStat"))
		{
			if (ueSkeletalTickManageComponent.ProxyTickStat == null)
			{
				this.ProxyTickStat = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.ProxyTickStat), "ProxyTickStat"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MainSkelComp"))
		{
			if (ueSkeletalTickManageComponent.MainSkelComp == null)
			{
				this.MainSkelComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<USkeletalMeshComponent>(this.MainSkelComp), "MainSkelComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MainAnimInstance"))
		{
			if (ueSkeletalTickManageComponent.MainAnimInstance == null)
			{
				this.MainAnimInstance = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UAnimInstance>(this.MainAnimInstance), "MainAnimInstance"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ForceDisableAnimDelaySet") && ueSkeletalTickManageComponent.ForceDisableAnimDelaySet != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<EForceDisableAnimDelayReason>(this.ForceDisableAnimDelaySet), "ForceDisableAnimDelaySet"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TickType"))
		{
			this.TickType = ueSkeletalTickManageComponent.TickType;
		}
		return (!base.CanResetComponentProperty("SkeletalComps") || ueSkeletalTickManageComponent.SkeletalComps == null || base.CheckClearObject(EntityComponentSystem.ClearObject<List<USkeletalMeshComponent>>(this.SkeletalComps), "SkeletalComps")) && (!base.CanResetComponentProperty("FollowSkeletalComps") || ueSkeletalTickManageComponent.FollowSkeletalComps == null || base.CheckClearObject(EntityComponentSystem.ClearObject<List<USkeletalMeshComponent>>(this.FollowSkeletalComps), "FollowSkeletalComps")) && (!base.CanResetComponentProperty("TickedComps") || ueSkeletalTickManageComponent.TickedComps == null || base.CheckClearObject(EntityComponentSystem.ClearObject<List<USkeletalMeshComponent>>(this.TickedComps), "TickedComps")) && (!base.CanResetComponentProperty("DisabledSet") || ueSkeletalTickManageComponent.DisabledSet == null || base.CheckClearObject(EntityComponentSystem.ClearObject<USkeletalMeshComponent>(this.DisabledSet), "DisabledSet"));
	}

	// Token: 0x0400D8D1 RID: 55505
	public const float MAX_TIME_DELAY_ANIM = 2f;

	// Token: 0x0400D8D2 RID: 55506
	public const float MAX_COLLECT_PERIOD_DELAY_ANIM = 0.125f;

	// Token: 0x0400D8D3 RID: 55507
	private bool EnableFirstFrame;

	// Token: 0x0400D8D4 RID: 55508
	[Nullable(2)]
	private BaseActorComponent ActorComp;

	// Token: 0x0400D8D5 RID: 55509
	[Nullable(2)]
	private BaseUnifiedStateComponent UnifiedStateComp;

	// Token: 0x0400D8D6 RID: 55510
	private int LastTickFrame = -1;

	// Token: 0x0400D8D7 RID: 55511
	private bool IsTakeOver;

	// Token: 0x0400D8D8 RID: 55512
	private ESkeletalMeshTickMode TickModeInternal;

	// Token: 0x0400D8D9 RID: 55513
	[Nullable(2)]
	private Stat ProxyTickStat;

	// Token: 0x0400D8DA RID: 55514
	[Nullable(2)]
	public USkeletalMeshComponent MainSkelComp;

	// Token: 0x0400D8DB RID: 55515
	[Nullable(2)]
	private UAnimInstance MainAnimInstance;

	// Token: 0x0400D8DC RID: 55516
	protected readonly HashSet<EForceDisableAnimDelayReason> ForceDisableAnimDelaySet = new HashSet<EForceDisableAnimDelayReason>();

	// Token: 0x0400D8DD RID: 55517
	protected ESkeletalMeshTickType TickType;

	// Token: 0x0400D8DE RID: 55518
	public readonly List<USkeletalMeshComponent> SkeletalComps = new List<USkeletalMeshComponent>();

	// Token: 0x0400D8DF RID: 55519
	private readonly List<USkeletalMeshComponent> FollowSkeletalComps = new List<USkeletalMeshComponent>();

	// Token: 0x0400D8E0 RID: 55520
	private readonly List<USkeletalMeshComponent> TickedComps = new List<USkeletalMeshComponent>();

	// Token: 0x0400D8E1 RID: 55521
	private readonly HashSet<USkeletalMeshComponent> DisabledSet = new HashSet<USkeletalMeshComponent>();

	// Token: 0x0400D8E2 RID: 55522
	private static readonly FName MainMeshName = new FName("CharacterMesh0");
}
