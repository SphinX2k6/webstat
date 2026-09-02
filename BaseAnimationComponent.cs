using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02003009 RID: 12297
[NullableContext(1)]
[Nullable(0)]
public class BaseAnimationComponent : EntityComponent, IComponentDependency, IStaticVariableResetter
{
	// Token: 0x060190C1 RID: 102593 RVA: 0x0071C83C File Offset: 0x0071AA3C
	static BaseAnimationComponent()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(BaseAnimationComponent.CreateStaticDefaultValue), new Action(BaseAnimationComponent.ResetStaticDefaultValue));
	}

	// Token: 0x060190C2 RID: 102594 RVA: 0x0071C8A9 File Offset: 0x0071AAA9
	public static void CreateStaticDefaultValue()
	{
		BaseAnimationComponent._xAngleLimits = new float[]
		{
			-0.54105204f,
			0.54105204f
		};
		BaseAnimationComponent._yAngleLimits = new float[]
		{
			-0.31415927f,
			0.54105204f
		};
	}

	// Token: 0x060190C3 RID: 102595 RVA: 0x0071C8E1 File Offset: 0x0071AAE1
	public static void ResetStaticDefaultValue()
	{
		BaseAnimationComponent._xAngleLimits = null;
		BaseAnimationComponent._yAngleLimits = null;
	}

	// Token: 0x170021BC RID: 8636
	// (get) Token: 0x060190C4 RID: 102596 RVA: 0x0071C8EF File Offset: 0x0071AAEF
	private static float[] xAngleLimits
	{
		get
		{
			return BaseAnimationComponent._xAngleLimits;
		}
	}

	// Token: 0x170021BD RID: 8637
	// (get) Token: 0x060190C5 RID: 102597 RVA: 0x0071C8F6 File Offset: 0x0071AAF6
	private static float[] yAngleLimits
	{
		get
		{
			return BaseAnimationComponent._yAngleLimits;
		}
	}

	// Token: 0x170021BE RID: 8638
	// (get) Token: 0x060190C6 RID: 102598 RVA: 0x0071C8FD File Offset: 0x0071AAFD
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public static Type[] Dependencies { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; } = new Type[]
	{
		typeof(BaseCharacterComponent),
		typeof(CreatureDataComponent)
	};

	// Token: 0x170021BF RID: 8639
	// (get) Token: 0x060190C7 RID: 102599 RVA: 0x0071C904 File Offset: 0x0071AB04
	// (set) Token: 0x060190C8 RID: 102600 RVA: 0x0071C90C File Offset: 0x0071AB0C
	[Nullable(2)]
	public TsBaseCharacter Actor { [NullableContext(2)] get; [NullableContext(2)] protected set; }

	// Token: 0x060190C9 RID: 102601 RVA: 0x0071C915 File Offset: 0x0071AB15
	[NullableContext(2)]
	public USkeleton GetSkeleton()
	{
		USkeletalMeshComponent mesh = this.Mesh;
		if (mesh == null)
		{
			return null;
		}
		USkeletalMesh skeletalMesh = mesh.SkeletalMesh;
		if (skeletalMesh == null)
		{
			return null;
		}
		return skeletalMesh.Skeleton;
	}

	// Token: 0x170021C0 RID: 8640
	// (get) Token: 0x060190CA RID: 102602 RVA: 0x0071C933 File Offset: 0x0071AB33
	// (set) Token: 0x060190CB RID: 102603 RVA: 0x0071C93B File Offset: 0x0071AB3B
	public bool EnableSightDirect
	{
		get
		{
			return this.EnableSightDirectInternal;
		}
		set
		{
			if (this.EnableSightDirectInternal != value)
			{
				this.EnableSightDirectInternal = value;
				if (!value)
				{
					this.SightDirect.DeepCopy(global::Vector.RightVectorProxy);
					this.SightDirect2.DeepCopy(global::Vector.RightVectorProxy);
					this.SightDirectIsEqual = true;
				}
			}
		}
	}

	// Token: 0x170021C1 RID: 8641
	// (get) Token: 0x060190CC RID: 102604 RVA: 0x0071C977 File Offset: 0x0071AB77
	public bool EnableBlendSpaceLookAt
	{
		get
		{
			return this.EnableBlendSpaceLookAtInner;
		}
	}

	// Token: 0x170021C2 RID: 8642
	// (get) Token: 0x060190CD RID: 102605 RVA: 0x0071C97F File Offset: 0x0071AB7F
	[Nullable(2)]
	public UAnimInstance ShellAnimInstance
	{
		[NullableContext(2)]
		get
		{
			return this.ShellAnimInstanceInternal;
		}
	}

	// Token: 0x170021C3 RID: 8643
	// (get) Token: 0x060190CE RID: 102606 RVA: 0x0071C987 File Offset: 0x0071AB87
	[Nullable(2)]
	public UAnimInstance MainAnimInstance
	{
		[NullableContext(2)]
		get
		{
			return this.MainAnimInstanceInternal;
		}
	}

	// Token: 0x170021C4 RID: 8644
	// (get) Token: 0x060190CF RID: 102607 RVA: 0x0071C98F File Offset: 0x0071AB8F
	[Nullable(2)]
	public UAnimInstance SpecialAnimInstance
	{
		[NullableContext(2)]
		get
		{
			return this.SpecialAnimInstanceInternal;
		}
	}

	// Token: 0x170021C5 RID: 8645
	// (get) Token: 0x060190D0 RID: 102608 RVA: 0x0071C997 File Offset: 0x0071AB97
	public MontageManager MontageManager
	{
		get
		{
			return this.GetMontageManager(EPerformGroup.DefaultGroup);
		}
	}

	// Token: 0x060190D1 RID: 102609 RVA: 0x0071C9A0 File Offset: 0x0071ABA0
	public MontageManager GetMontageManager(EPerformGroup group = EPerformGroup.DefaultGroup)
	{
		MontageManager montageManager;
		if (this.MontageManagerMap.TryGetValue(group, out montageManager))
		{
			return montageManager;
		}
		montageManager = new MontageManager();
		montageManager.Init(this, group);
		this.MontageManagerMap[group] = montageManager;
		return montageManager;
	}

	// Token: 0x060190D2 RID: 102610 RVA: 0x0071C9DC File Offset: 0x0071ABDC
	public EPerformGroup? FindGroupByMontageHandleId(int handleId)
	{
		foreach (KeyValuePair<EPerformGroup, MontageManager> keyValuePair in this.MontageManagerMap)
		{
			EPerformGroup eperformGroup;
			MontageManager montageManager;
			keyValuePair.Deconstruct(out eperformGroup, out montageManager);
			EPerformGroup value = eperformGroup;
			if (montageManager.IsMontagePlaying(new int?(handleId)))
			{
				return new EPerformGroup?(value);
			}
		}
		return null;
	}

	// Token: 0x060190D3 RID: 102611 RVA: 0x0071CA5C File Offset: 0x0071AC5C
	public void StopMontageByHandleId(IStopMontageParam param)
	{
		foreach (MontageManager montageManager in this.MontageManagerMap.Values)
		{
			montageManager.StopMontage(param);
		}
	}

	// Token: 0x060190D4 RID: 102612 RVA: 0x0071CAB4 File Offset: 0x0071ACB4
	public void ClearCallbackByHandleId(int handleId)
	{
		foreach (MontageManager montageManager in this.MontageManagerMap.Values)
		{
			montageManager.ClearCallback(new int?(handleId));
		}
	}

	// Token: 0x060190D5 RID: 102613 RVA: 0x0071CB10 File Offset: 0x0071AD10
	protected override bool OnInit()
	{
		Array.Copy(BaseAnimationComponent.xAngleLimits, this.XAngleLimits, 2);
		Array.Copy(BaseAnimationComponent.yAngleLimits, this.YAngleLimits, 2);
		Array.Copy(BaseAnimationComponent.xAngleLimits, this.XAngleLimitsDefault, 2);
		Array.Copy(BaseAnimationComponent.yAngleLimits, this.YAngleLimitsDefault, 2);
		this.GetMontageManager(EPerformGroup.DefaultGroup);
		return true;
	}

	// Token: 0x060190D6 RID: 102614 RVA: 0x0071CB6C File Offset: 0x0071AD6C
	protected override bool OnClear()
	{
		foreach (MontageManager montageManager in this.MontageManagerMap.Values)
		{
			montageManager.Clear();
		}
		this.MontageManagerMap.Clear();
		HashSet<USkeletalMeshComponent> noUpdateMeshes = this.NoUpdateMeshes;
		if (noUpdateMeshes != null)
		{
			noUpdateMeshes.Clear();
		}
		return true;
	}

	// Token: 0x060190D7 RID: 102615 RVA: 0x0071CBE0 File Offset: 0x0071ADE0
	protected override void OnEnable()
	{
		Singleton<EventSystem>.Instance.EmitWithTarget<bool>(base.Entity, EEventName.AnimCompActiveStateChange, true);
	}

	// Token: 0x060190D8 RID: 102616 RVA: 0x0071CBF9 File Offset: 0x0071ADF9
	protected override void OnDisable(string reason)
	{
		Singleton<EventSystem>.Instance.EmitWithTarget<bool>(base.Entity, EEventName.AnimCompActiveStateChange, false);
	}

	// Token: 0x060190D9 RID: 102617 RVA: 0x0071CC14 File Offset: 0x0071AE14
	public void SetSightLimit(float[] xLimits, float[] yLimits, bool changeDefaultValue = false)
	{
		this.XAngleLimits[0] = xLimits[0] * 0.017453292f;
		this.XAngleLimits[1] = xLimits[1] * 0.017453292f;
		this.YAngleLimits[0] = yLimits[0] * 0.017453292f;
		this.YAngleLimits[1] = yLimits[1] * 0.017453292f;
		if (changeDefaultValue)
		{
			this.XAngleLimitsDefault[0] = this.XAngleLimits[0];
			this.XAngleLimitsDefault[1] = this.XAngleLimits[1];
			this.YAngleLimitsDefault[0] = this.YAngleLimits[0];
			this.YAngleLimitsDefault[1] = this.YAngleLimits[1];
		}
		this.NoLimitForXAngle = ((double)this.XAngleLimits[0] <= -3.141592653589793 && (double)this.XAngleLimits[1] >= 3.141592653589793);
	}

	// Token: 0x060190DA RID: 102618 RVA: 0x0071CCE0 File Offset: 0x0071AEE0
	public void ResetSightLimit()
	{
		this.XAngleLimits[0] = this.XAngleLimitsDefault[0];
		this.XAngleLimits[1] = this.XAngleLimitsDefault[1];
		this.YAngleLimits[0] = this.YAngleLimitsDefault[0];
		this.YAngleLimits[1] = this.YAngleLimitsDefault[1];
	}

	// Token: 0x060190DB RID: 102619 RVA: 0x0071CD2D File Offset: 0x0071AF2D
	public void SetHeadBaseYaw(float angle)
	{
		this.HeadBaseYaw = Singleton<MathUtils>.Instance.WrapAngle(angle);
	}

	// Token: 0x060190DC RID: 102620 RVA: 0x0071CD40 File Offset: 0x0071AF40
	public void SetSightTargetItem(BaseActorComponent target)
	{
		this.SightTargetPoint = null;
		this.SightTargetActor = null;
		this.SightTargetItemId = ((target != null) ? target.Entity.Id : 0);
	}

	// Token: 0x060190DD RID: 102621 RVA: 0x0071CD67 File Offset: 0x0071AF67
	[NullableContext(2)]
	public BaseActorComponent GetSightTargetItem()
	{
		if (this.SightTargetItemId == 0)
		{
			return null;
		}
		BaseActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseActorComponent>(this.SightTargetItemId);
		if (component == null)
		{
			this.SightTargetItemId = 0;
		}
		return component;
	}

	// Token: 0x060190DE RID: 102622 RVA: 0x0071CD8D File Offset: 0x0071AF8D
	public void SetSightTargetPoint(global::Vector point)
	{
		this.SightTargetItemId = 0;
		this.SightTargetActor = null;
		this.SightTargetPoint = point;
	}

	// Token: 0x060190DF RID: 102623 RVA: 0x0071CDA4 File Offset: 0x0071AFA4
	[NullableContext(2)]
	public global::Vector GetSightTargetPoint()
	{
		return this.SightTargetPoint;
	}

	// Token: 0x060190E0 RID: 102624 RVA: 0x0071CDAC File Offset: 0x0071AFAC
	[NullableContext(2)]
	public void SetSightTargetActor(AActor actor)
	{
		this.SightTargetPoint = null;
		this.SightTargetItemId = 0;
		this.SightTargetActor = ((actor != null && actor.IsValid()) ? actor : null);
	}

	// Token: 0x060190E1 RID: 102625 RVA: 0x0071CDD1 File Offset: 0x0071AFD1
	[NullableContext(2)]
	public AActor GetSightTargetActor()
	{
		AActor sightTargetActor = this.SightTargetActor;
		if (sightTargetActor == null || !sightTargetActor.IsValid())
		{
			this.SightTargetActor = null;
			return null;
		}
		return this.SightTargetActor;
	}

	// Token: 0x060190E2 RID: 102626 RVA: 0x0071CDF9 File Offset: 0x0071AFF9
	public FVector GetSightDirect()
	{
		return this.SightDirect.ToUeVectorOld();
	}

	// Token: 0x060190E3 RID: 102627 RVA: 0x0071CE06 File Offset: 0x0071B006
	public float GetHeadBaseYawBuffer()
	{
		return this.HeadBaseYawBuffer;
	}

	// Token: 0x060190E4 RID: 102628 RVA: 0x0071CE0E File Offset: 0x0071B00E
	public global::Vector GetTsSightDirect()
	{
		return this.SightDirect;
	}

	// Token: 0x060190E5 RID: 102629 RVA: 0x0071CE16 File Offset: 0x0071B016
	public global::Vector GetWorldSightDirect(global::Vector outV)
	{
		if (this.Mesh == null)
		{
			outV.DeepCopy(this.SightDirect);
			return outV;
		}
		BaseAnimationComponent.TmpSightQuat.FromUeQuat(this.Mesh.K2_GetComponentQuaternion());
		BaseAnimationComponent.TmpSightQuat.RotateVector(this.SightDirect, outV);
		return outV;
	}

	// Token: 0x060190E6 RID: 102630 RVA: 0x0071CE55 File Offset: 0x0071B055
	public global::Vector GetWorldDefaultSightDirect(global::Vector outV)
	{
		if (this.Mesh == null)
		{
			outV.DeepCopy(global::Vector.RightVectorProxy);
			return outV;
		}
		BaseAnimationComponent.TmpSightQuat.FromUeQuat(this.Mesh.K2_GetComponentQuaternion());
		BaseAnimationComponent.TmpSightQuat.RotateVector(global::Vector.RightVectorProxy, outV);
		return outV;
	}

	// Token: 0x060190E7 RID: 102631 RVA: 0x0071CE94 File Offset: 0x0071B094
	public global::Vector GetBoneWorldLocation(FName boneName, global::Vector outV)
	{
		if (this.Mesh != null)
		{
			FVectorDouble fvectorDouble = this.Mesh.D_GetSocketLocation(boneName);
			outV.FromUeVector(fvectorDouble);
		}
		return outV;
	}

	// Token: 0x060190E8 RID: 102632 RVA: 0x0071CEBF File Offset: 0x0071B0BF
	public Vector2D GetTsLookAt()
	{
		return this.LookAtBlendSpaceVector2D;
	}

	// Token: 0x060190E9 RID: 102633 RVA: 0x0071CEC8 File Offset: 0x0071B0C8
	[return: Nullable(2)]
	public string GetMontageResPathByName(string montageName)
	{
		if (string.IsNullOrEmpty(montageName) || montageName.Contains("/"))
		{
			return montageName;
		}
		if (!string.IsNullOrEmpty(this.ActorComp.ModelResPath))
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
			defaultInterpolatedStringHandler.AppendFormatted(this.ActorComp.ModelResPath);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(montageName);
			defaultInterpolatedStringHandler.AppendLiteral(".");
			defaultInterpolatedStringHandler.AppendFormatted(montageName);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
		return null;
	}

	// Token: 0x060190EA RID: 102634 RVA: 0x0071CF4C File Offset: 0x0071B14C
	protected unsafe void CheckNpcAnimationAssets()
	{
		if (!GlobalData.IsPlayInEditor)
		{
			return;
		}
		BaseCharacterComponent actorComp = this.ActorComp;
		if (actorComp == null || !actorComp.Valid)
		{
			return;
		}
		if (this.Mesh.AnimationMode == 1)
		{
			return;
		}
		if (this.ActorComp.CreatureData.GetEntityType() != EEntityType.Npc)
		{
			return;
		}
		UAnimInstance mainAnimInstance = this.MainAnimInstance;
		if (mainAnimInstance == null || !mainAnimInstance.IsValid())
		{
			return;
		}
		TSet<UAnimationAsset> tset = new TSet<UAnimationAsset>();
		UKuroStaticLibrary.GetAnimAssetsByAnimInstance(mainAnimInstance, ref tset);
		if (tset.Num() == 0)
		{
			return;
		}
		for (int i = 0; i < tset.Num(); i++)
		{
			UAnimSequence uanimSequence = tset.GetElement(i) as UAnimSequence;
			if (uanimSequence != null)
			{
				string name = uanimSequence.GetName();
				if ((name.Contains("Run_F") || name.Contains("Run_Pose_F") || name.Contains("Walk_F") || name.Contains("Walk_Pose_F")) && uanimSequence.bEnableRootMotion)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Pawn;
					ELogAuthor author = ELogAuthor.CJH;
					string message = "Npc移动相关动画资源错误使用了RootMotion";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("AssetName", this.ActorComp.Actor.GetName());
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("AnimName", name);
					instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
			}
		}
	}

	// Token: 0x060190EB RID: 102635 RVA: 0x0071D0AC File Offset: 0x0071B2AC
	protected virtual void GetAnimInstanceFromMesh()
	{
		this.CheckLinkAnimInstance();
		this.ShellAnimInstanceInternal = this.Mesh.GetAnimInstance();
		this.MainAnimInstanceInternal = this.Mesh.GetLinkedAnimGraphInstanceByTag(Singleton<CharacterNameDefines>.Instance.ABP_BASE);
		if (this.MainAnimInstanceInternal == null)
		{
			this.MainAnimInstanceInternal = this.ShellAnimInstanceInternal;
		}
		this.SpecialAnimInstanceInternal = this.Mesh.GetLinkedAnimGraphInstanceByTag(Singleton<CharacterNameDefines>.Instance.ABP_SPECIAL);
	}

	// Token: 0x060190EC RID: 102636 RVA: 0x0071D11C File Offset: 0x0071B31C
	protected void StartAnimInstance()
	{
		UKuroAnimInstance ukuroAnimInstance = this.MainAnimInstanceInternal as UKuroAnimInstance;
		if (ukuroAnimInstance != null)
		{
			ukuroAnimInstance.OnComponentStart();
		}
		if (this.SpecialAnimInstanceInternal != null)
		{
			UKuroAnimInstance ukuroAnimInstance2 = this.SpecialAnimInstanceInternal as UKuroAnimInstance;
			if (ukuroAnimInstance2 != null)
			{
				ukuroAnimInstance2.OnComponentStart();
			}
		}
		this.StartAllAttachedAnimInstance();
	}

	// Token: 0x060190ED RID: 102637 RVA: 0x0071D164 File Offset: 0x0071B364
	protected void ClampSightDirect(global::Vector inV, global::Vector outV)
	{
		double num = inV.Z / inV.Size();
		double num2 = Singleton<MathUtils>.Instance.Clamp(Math.Asin(num), (double)this.YAngleLimits[0], (double)this.YAngleLimits[1]);
		num = Math.Sin(num2);
		double num3 = Math.Cos(num2);
		double num4 = inV.Y;
		double num5 = -inV.X;
		double num6 = (Math.Abs(num4) > 0.0001 || Math.Abs(num5) > 0.0001) ? Singleton<MathUtils>.Instance.Clamp(Math.Atan2(num5, num4), (double)this.XAngleLimits[0], (double)this.XAngleLimits[1]) : 0.0;
		num4 = Math.Cos(num6) * num3;
		num5 = Math.Sin(num6) * num3;
		outV.X = -num5;
		outV.Y = num4;
		outV.Z = num;
	}

	// Token: 0x060190EE RID: 102638 RVA: 0x0071D234 File Offset: 0x0071B434
	private void StartAllAttachedAnimInstance()
	{
		TArray<UActorComponent> tarray = this.ActorComp.Actor.K2_GetComponentsByClass(USkeletalMeshComponent.StaticClass());
		for (int i = 0; i < tarray.Num(); i++)
		{
			USkeletalMeshComponent uskeletalMeshComponent = tarray.Get(i) as USkeletalMeshComponent;
			if (uskeletalMeshComponent != null)
			{
				UAnimInstance animInstance = uskeletalMeshComponent.GetAnimInstance();
				if (animInstance != null)
				{
					UKuroAnimInstance ukuroAnimInstance = animInstance as UKuroAnimInstance;
					if (ukuroAnimInstance != null && animInstance != this.MainAnimInstance)
					{
						ukuroAnimInstance.OnComponentStart();
					}
				}
				UAnimInstance linkedAnimGraphInstanceByTag = uskeletalMeshComponent.GetLinkedAnimGraphInstanceByTag(Singleton<CharacterNameDefines>.Instance.ABP_BASE);
				if (linkedAnimGraphInstanceByTag != null)
				{
					UKuroAnimInstance ukuroAnimInstance2 = linkedAnimGraphInstanceByTag as UKuroAnimInstance;
					if (ukuroAnimInstance2 != null && linkedAnimGraphInstanceByTag != this.MainAnimInstance)
					{
						ukuroAnimInstance2.OnComponentStart();
					}
				}
			}
		}
	}

	// Token: 0x060190EF RID: 102639 RVA: 0x0071D2D8 File Offset: 0x0071B4D8
	private unsafe void CheckLinkAnimInstance()
	{
		if (this.Actor.Mesh.GetLinkedAnimGraphInstanceByTag(FNameUtil.NONE) != null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "检测出该Actor有空的动画LinkGraph节点,将会影响同步,GAS等功能,请找对应策划修复";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "Actor";
			BaseCharacterComponent actorComp = this.ActorComp;
			ptr = new ValueTuple<string, object>(item, (actorComp != null) ? actorComp.Owner : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("AnimInstance", this.Actor.Mesh.GetAnimInstance());
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
	}

	// Token: 0x060190F0 RID: 102640 RVA: 0x0071D370 File Offset: 0x0071B570
	public static void LerpDirect2dByMaxAngle(global::Vector from, global::Vector to, float maxAngle, global::Vector outV, bool noLimitForXAngle = false)
	{
		double num = Singleton<MathUtils>.Instance.GetAngleByVector2D(from);
		if (num < -90.0)
		{
			num += 360.0;
		}
		double num2 = Singleton<MathUtils>.Instance.GetAngleByVector2D(to);
		if (num2 < -90.0)
		{
			num2 += 360.0;
		}
		double num3 = Math.Asin(from.Z) * 57.295780181884766;
		double num4 = Math.Asin(to.Z) * 57.295780181884766;
		double num5 = num2 - num;
		if (noLimitForXAngle)
		{
			if (num5 > 180.0)
			{
				num5 -= 360.0;
			}
			else if (num5 < -180.0)
			{
				num5 += 360.0;
			}
		}
		double num6 = num4 - num3;
		double num7 = Math.Sqrt(num5 * num5 + num6 * num6);
		if (num7 > (double)maxAngle)
		{
			num5 *= (double)maxAngle / num7;
			num6 *= (double)maxAngle / num7;
		}
		double num8 = num + num5;
		double num9 = (num3 + num6) * 0.01745329238474369;
		outV.Z = Math.Sin(num9);
		double num10 = Math.Cos(num9);
		outV.X = Math.Cos(num8 * 0.01745329238474369) * num10;
		outV.Y = Math.Sin(num8 * 0.01745329238474369) * num10;
	}

	// Token: 0x060190F1 RID: 102641 RVA: 0x0071D4B8 File Offset: 0x0071B6B8
	public static void LerpVector2dByAlpha(global::Vector from, global::Vector to, float alpha, global::Vector outV, bool noLimitForXAngle = false)
	{
		double num = Singleton<MathUtils>.Instance.GetAngleByVector2D(from);
		if (num < -90.0)
		{
			num += 360.0;
		}
		double num2 = Singleton<MathUtils>.Instance.GetAngleByVector2D(to);
		if (num2 < -90.0)
		{
			num2 += 360.0;
		}
		double num3 = Math.Asin(from.Z) * 57.295780181884766;
		double num4 = Math.Asin(to.Z) * 57.295780181884766;
		double num5 = num2 - num;
		if (noLimitForXAngle)
		{
			if (num5 > 180.0)
			{
				num5 -= 360.0;
			}
			else if (num5 < -180.0)
			{
				num5 += 360.0;
			}
		}
		double num6 = num4 - num3;
		num5 *= (double)alpha;
		num6 *= (double)alpha;
		double num7 = num + num5;
		double num8 = (num3 + num6) * 0.01745329238474369;
		outV.Z = Math.Sin(num8);
		double num9 = Math.Cos(num8);
		outV.X = Math.Cos(num7 * 0.01745329238474369) * num9;
		outV.Y = Math.Sin(num7 * 0.01745329238474369) * num9;
	}

	// Token: 0x060190F2 RID: 102642 RVA: 0x0071D5E1 File Offset: 0x0071B7E1
	protected virtual void InitBaseInfo()
	{
	}

	// Token: 0x060190F3 RID: 102643 RVA: 0x0071D5E3 File Offset: 0x0071B7E3
	public EVisibilityBasedAnimTickOption GetAnimDefaultTickOption()
	{
		return this.DefaultVisibilityBasedAnimTickOption;
	}

	// Token: 0x060190F4 RID: 102644 RVA: 0x0071D5EC File Offset: 0x0071B7EC
	public bool StartForceDisableAnimOptimization(EForceDisableAnimOptimization reason, bool enableAutoCancel = true)
	{
		if (this.ForceDisableAnimOptimizationSet.Contains(reason))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.ZFJ;
			string message = "动画优化强制关闭-重复";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("reason", reason);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		this.ForceDisableAnimOptimizationSet.Add(reason);
		this.RefreshAnimOptimization();
		if (enableAutoCancel)
		{
			TimerSystem.Instance.Delay(delegate(float _)
			{
				this.CancelForceDisableAnimOptimization(reason);
			}, 100f, null, null, true, 1f);
		}
		return true;
	}

	// Token: 0x060190F5 RID: 102645 RVA: 0x0071D694 File Offset: 0x0071B894
	public bool StartForceDisableAnimOptimization2(EForceDisableAnimOptimization reason)
	{
		if (this.ForceDisableAnimOptimizationSet.Contains(reason))
		{
			return false;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Character;
		ELogAuthor author = ELogAuthor.ZFJ;
		string message = "动画优化强制关闭-开始";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("reason", reason);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.ForceDisableAnimOptimizationSet.Add(reason);
		this.RefreshAnimOptimization();
		return true;
	}

	// Token: 0x060190F6 RID: 102646 RVA: 0x0071D6F1 File Offset: 0x0071B8F1
	public void CancelForceDisableAnimOptimization(EForceDisableAnimOptimization reason)
	{
		if (!this.ForceDisableAnimOptimizationSet.Remove(reason))
		{
			return;
		}
		this.RefreshAnimOptimization();
	}

	// Token: 0x060190F7 RID: 102647 RVA: 0x0071D708 File Offset: 0x0071B908
	public void RefreshAnimOptimization()
	{
		if (this.Actor == null)
		{
			return;
		}
		CharacterUnifiedStateComponent component = base.Entity.GetComponent<CharacterUnifiedStateComponent>();
		bool flag = component != null && component.IsInFighting;
		bool flag2 = this.ForceDisableAnimOptimizationSet.Count > 0;
		bool flag3 = flag2 || flag;
		TArray<UActorComponent> tarray = this.Actor.K2_GetComponentsByClass(USkeletalMeshComponent.StaticClass());
		EVisibilityBasedAnimTickOption visibilityBasedAnimTickOption = this.RefreshVisibilityBasedAnimTickOption(flag2, flag);
		for (int i = 0; i < tarray.Num(); i++)
		{
			USkeletalMeshComponent uskeletalMeshComponent = tarray.Get(i) as USkeletalMeshComponent;
			uskeletalMeshComponent.bEnableUpdateRateOptimizations = !flag3;
			HashSet<USkeletalMeshComponent> noUpdateMeshes = this.NoUpdateMeshes;
			if (noUpdateMeshes != null && noUpdateMeshes.Contains(uskeletalMeshComponent))
			{
				uskeletalMeshComponent.VisibilityBasedAnimTickOption = EVisibilityBasedAnimTickOption.OnlyTickPoseWhenRendered;
			}
			else
			{
				uskeletalMeshComponent.VisibilityBasedAnimTickOption = visibilityBasedAnimTickOption;
			}
		}
	}

	// Token: 0x060190F8 RID: 102648 RVA: 0x0071D7C4 File Offset: 0x0071B9C4
	public void SetNoUpdateMeshes(HashSet<USkeletalMeshComponent> meshes)
	{
		if (this.NoUpdateMeshes == null)
		{
			this.NoUpdateMeshes = new HashSet<USkeletalMeshComponent>();
		}
		else
		{
			this.NoUpdateMeshes.Clear();
		}
		foreach (USkeletalMeshComponent item in meshes)
		{
			this.NoUpdateMeshes.Add(item);
		}
		this.RefreshAnimOptimization();
	}

	// Token: 0x060190F9 RID: 102649 RVA: 0x0071D840 File Offset: 0x0071BA40
	protected EVisibilityBasedAnimTickOption RefreshVisibilityBasedAnimTickOption(bool forceDisableAnimOptimization, bool inFight)
	{
		EVisibilityBasedAnimTickOption evisibilityBasedAnimTickOption = this.DefaultVisibilityBasedAnimTickOption;
		if (!forceDisableAnimOptimization && !inFight)
		{
			return evisibilityBasedAnimTickOption;
		}
		if (inFight)
		{
			return EVisibilityBasedAnimTickOption.AlwaysTickPoseAndRefreshBones;
		}
		foreach (EForceDisableAnimOptimization eforceDisableAnimOptimization in this.ForceDisableAnimOptimizationSet)
		{
			evisibilityBasedAnimTickOption = (EVisibilityBasedAnimTickOption)Math.Min((int)evisibilityBasedAnimTickOption, (int)Singleton<CharacterAnimOptimizationSetting>.Instance.DisableAnimOptimizationTypeDefines[(int)eforceDisableAnimOptimization]);
		}
		return evisibilityBasedAnimTickOption;
	}

	// Token: 0x060190FA RID: 102650 RVA: 0x0071D8B8 File Offset: 0x0071BAB8
	public void UpdateLoopState(UAnimMontage montage, bool? isLoop)
	{
		if (isLoop == null)
		{
			return;
		}
		bool flag = false;
		bool flag2 = false;
		for (int i = 0; i < montage.CompositeSections.Num(); i++)
		{
			FCompositeSection fcompositeSection = montage.CompositeSections.Get(i);
			if (fcompositeSection.SectionName.Equals(Singleton<CharacterNameDefines>.Instance.LOOP_SECTION))
			{
				flag = true;
				break;
			}
			if (fcompositeSection.SectionName.Equals(Singleton<CharacterNameDefines>.Instance.DEFAULT_SECTION_NAME))
			{
				flag2 = true;
				break;
			}
		}
		if (isLoop.Value)
		{
			if (flag)
			{
				this.MainAnimInstance.Montage_SetNextSection(Singleton<CharacterNameDefines>.Instance.LOOP_SECTION, Singleton<CharacterNameDefines>.Instance.LOOP_SECTION, montage);
				return;
			}
			if (flag2)
			{
				this.MainAnimInstance.Montage_SetNextSection(Singleton<CharacterNameDefines>.Instance.DEFAULT_SECTION_NAME, Singleton<CharacterNameDefines>.Instance.DEFAULT_SECTION_NAME, montage);
				return;
			}
		}
		else
		{
			if (flag)
			{
				this.MainAnimInstance.Montage_SetNextSection(Singleton<CharacterNameDefines>.Instance.LOOP_SECTION, Singleton<CharacterNameDefines>.Instance.END_SECTION, montage);
				return;
			}
			if (flag2)
			{
				this.MainAnimInstance.Montage_SetNextSection(Singleton<CharacterNameDefines>.Instance.DEFAULT_SECTION_NAME, Singleton<CharacterNameDefines>.Instance.NULL_SECTION, montage);
			}
		}
	}

	// Token: 0x060190FB RID: 102651 RVA: 0x0071D9CC File Offset: 0x0071BBCC
	public void StopMontageForLoopState(UAnimMontage montage, bool singleSecForceStop = true)
	{
		TArray<FCompositeSection> compositeSections = montage.CompositeSections;
		int num = compositeSections.Num();
		bool flag = false;
		for (int i = 0; i < num; i++)
		{
			if (compositeSections.Get(i).SectionName.Equals(Singleton<CharacterNameDefines>.Instance.END_SECTION))
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			if (!this.MainAnimInstance.Montage_GetCurrentSection(null).Equals(Singleton<CharacterNameDefines>.Instance.END_SECTION))
			{
				this.MainAnimInstance.Montage_JumpToSection(Singleton<CharacterNameDefines>.Instance.END_SECTION, montage);
			}
			return;
		}
		if (singleSecForceStop)
		{
			this.MainAnimInstance.Montage_Stop(0.5f, montage);
			return;
		}
		this.UpdateLoopState(montage, new bool?(false));
	}

	// Token: 0x060190FC RID: 102652 RVA: 0x0071DA78 File Offset: 0x0071BC78
	protected override void OnTick(float delta)
	{
		foreach (MontageManager montageManager in this.MontageManagerMap.Values)
		{
			montageManager.OnTick(delta);
		}
	}

	// Token: 0x060190FD RID: 102653 RVA: 0x0071DAD0 File Offset: 0x0071BCD0
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		BaseAnimationComponent baseAnimationComponent = (BaseAnimationComponent)componentTemplate;
		if (base.CanResetComponentProperty("<Actor>k__BackingField"))
		{
			if (baseAnimationComponent.Actor == null)
			{
				this.Actor = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TsBaseCharacter>(this.Actor), "<Actor>k__BackingField"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("Mesh"))
		{
			if (baseAnimationComponent.Mesh == null)
			{
				this.Mesh = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<USkeletalMeshComponent>(this.Mesh), "Mesh"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (baseAnimationComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseCharacterComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SightTargetItemId"))
		{
			this.SightTargetItemId = baseAnimationComponent.SightTargetItemId;
		}
		if (base.CanResetComponentProperty("SightTargetPoint"))
		{
			if (baseAnimationComponent.SightTargetPoint == null)
			{
				this.SightTargetPoint = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.SightTargetPoint), "SightTargetPoint"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SightTargetActor"))
		{
			if (baseAnimationComponent.SightTargetActor == null)
			{
				this.SightTargetActor = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<AActor>(this.SightTargetActor), "SightTargetActor"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("HeadBaseYaw"))
		{
			this.HeadBaseYaw = baseAnimationComponent.HeadBaseYaw;
		}
		if (base.CanResetComponentProperty("HeadBaseYawBuffer"))
		{
			this.HeadBaseYawBuffer = baseAnimationComponent.HeadBaseYawBuffer;
		}
		if (base.CanResetComponentProperty("EnableSightDirectInternal"))
		{
			this.EnableSightDirectInternal = baseAnimationComponent.EnableSightDirectInternal;
		}
		if (base.CanResetComponentProperty("IgnoreMontageBlinkCurve"))
		{
			this.IgnoreMontageBlinkCurve = baseAnimationComponent.IgnoreMontageBlinkCurve;
		}
		if (base.CanResetComponentProperty("DisableBlink"))
		{
			this.DisableBlink = baseAnimationComponent.DisableBlink;
		}
		if (base.CanResetComponentProperty("DisableHumanIk"))
		{
			this.DisableHumanIk = baseAnimationComponent.DisableHumanIk;
		}
		if (base.CanResetComponentProperty("XAngleLimits"))
		{
			if (baseAnimationComponent.XAngleLimits == null)
			{
				this.XAngleLimits = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<float[]>(this.XAngleLimits), "XAngleLimits"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("YAngleLimits"))
		{
			if (baseAnimationComponent.YAngleLimits == null)
			{
				this.YAngleLimits = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<float[]>(this.YAngleLimits), "YAngleLimits"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("NoLimitForXAngle"))
		{
			this.NoLimitForXAngle = baseAnimationComponent.NoLimitForXAngle;
		}
		if (base.CanResetComponentProperty("SightDirect") && baseAnimationComponent.SightDirect != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.SightDirect), "SightDirect"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("LookAtBlendSpaceVector2D"))
		{
			if (baseAnimationComponent.LookAtBlendSpaceVector2D == null)
			{
				this.LookAtBlendSpaceVector2D = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector2D>(this.LookAtBlendSpaceVector2D), "LookAtBlendSpaceVector2D"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("EnableBlendSpaceLookAtInner"))
		{
			this.EnableBlendSpaceLookAtInner = baseAnimationComponent.EnableBlendSpaceLookAtInner;
		}
		if (base.CanResetComponentProperty("SightDirect2") && baseAnimationComponent.SightDirect2 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.SightDirect2), "SightDirect2"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("SightDirectIsEqual"))
		{
			this.SightDirectIsEqual = baseAnimationComponent.SightDirectIsEqual;
		}
		if (base.CanResetComponentProperty("ShellAnimInstanceInternal"))
		{
			if (baseAnimationComponent.ShellAnimInstanceInternal == null)
			{
				this.ShellAnimInstanceInternal = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UAnimInstance>(this.ShellAnimInstanceInternal), "ShellAnimInstanceInternal"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MainAnimInstanceInternal"))
		{
			if (baseAnimationComponent.MainAnimInstanceInternal == null)
			{
				this.MainAnimInstanceInternal = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UAnimInstance>(this.MainAnimInstanceInternal), "MainAnimInstanceInternal"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SpecialAnimInstanceInternal"))
		{
			if (baseAnimationComponent.SpecialAnimInstanceInternal == null)
			{
				this.SpecialAnimInstanceInternal = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UAnimInstance>(this.SpecialAnimInstanceInternal), "SpecialAnimInstanceInternal"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsPlayer"))
		{
			this.IsPlayer = baseAnimationComponent.IsPlayer;
		}
		if (base.CanResetComponentProperty("ForceDisableAnimOptimizationSet") && baseAnimationComponent.ForceDisableAnimOptimizationSet != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<EForceDisableAnimOptimization>(this.ForceDisableAnimOptimizationSet), "ForceDisableAnimOptimizationSet"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("DefaultVisibilityBasedAnimTickOption"))
		{
			this.DefaultVisibilityBasedAnimTickOption = baseAnimationComponent.DefaultVisibilityBasedAnimTickOption;
		}
		if (base.CanResetComponentProperty("MontageManagerMap") && baseAnimationComponent.MontageManagerMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<EPerformGroup, MontageManager>>(this.MontageManagerMap), "MontageManagerMap"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("NoUpdateMeshes"))
		{
			if (baseAnimationComponent.NoUpdateMeshes == null)
			{
				this.NoUpdateMeshes = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<USkeletalMeshComponent>(this.NoUpdateMeshes), "NoUpdateMeshes"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CurMontageTimerHandle"))
		{
			if (baseAnimationComponent.CurMontageTimerHandle == null)
			{
				this.CurMontageTimerHandle = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TimerHandle>(this.CurMontageTimerHandle), "CurMontageTimerHandle"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400C425 RID: 50213
	private const int SPLIT_LINE = -90;

	// Token: 0x0400C426 RID: 50214
	private const int FORCE_DISABLE_ANIM_OPTIMIZATION_TIME = 100;

	// Token: 0x0400C427 RID: 50215
	private const string RUN_F = "Run_F";

	// Token: 0x0400C428 RID: 50216
	private const string RUN_POSE_F = "Run_Pose_F";

	// Token: 0x0400C429 RID: 50217
	private const string WALK_F = "Walk_F";

	// Token: 0x0400C42A RID: 50218
	private const string WALK_POSE_F = "Walk_Pose_F";

	// Token: 0x0400C42B RID: 50219
	[Nullable(2)]
	private static float[] _xAngleLimits;

	// Token: 0x0400C42C RID: 50220
	[Nullable(2)]
	private static float[] _yAngleLimits;

	// Token: 0x0400C42F RID: 50223
	[Nullable(2)]
	protected USkeletalMeshComponent Mesh;

	// Token: 0x0400C430 RID: 50224
	[Nullable(2)]
	protected BaseCharacterComponent ActorComp;

	// Token: 0x0400C431 RID: 50225
	protected int SightTargetItemId;

	// Token: 0x0400C432 RID: 50226
	[Nullable(2)]
	protected global::Vector SightTargetPoint;

	// Token: 0x0400C433 RID: 50227
	[Nullable(2)]
	protected AActor SightTargetActor;

	// Token: 0x0400C434 RID: 50228
	protected float HeadBaseYaw;

	// Token: 0x0400C435 RID: 50229
	protected float HeadBaseYawBuffer;

	// Token: 0x0400C436 RID: 50230
	protected bool EnableSightDirectInternal;

	// Token: 0x0400C437 RID: 50231
	public bool IgnoreMontageBlinkCurve;

	// Token: 0x0400C438 RID: 50232
	public bool DisableBlink;

	// Token: 0x0400C439 RID: 50233
	public bool DisableHumanIk;

	// Token: 0x0400C43A RID: 50234
	private float[] XAngleLimits = new float[2];

	// Token: 0x0400C43B RID: 50235
	private float[] YAngleLimits = new float[2];

	// Token: 0x0400C43C RID: 50236
	private readonly float[] XAngleLimitsDefault = new float[2];

	// Token: 0x0400C43D RID: 50237
	private readonly float[] YAngleLimitsDefault = new float[2];

	// Token: 0x0400C43E RID: 50238
	protected bool NoLimitForXAngle;

	// Token: 0x0400C43F RID: 50239
	protected readonly global::Vector SightDirect = global::Vector.Create();

	// Token: 0x0400C440 RID: 50240
	protected Vector2D LookAtBlendSpaceVector2D = Vector2D.Create();

	// Token: 0x0400C441 RID: 50241
	protected bool EnableBlendSpaceLookAtInner;

	// Token: 0x0400C442 RID: 50242
	protected readonly global::Vector SightDirect2 = global::Vector.Create();

	// Token: 0x0400C443 RID: 50243
	protected bool SightDirectIsEqual = true;

	// Token: 0x0400C444 RID: 50244
	[Nullable(2)]
	protected UAnimInstance ShellAnimInstanceInternal;

	// Token: 0x0400C445 RID: 50245
	[Nullable(2)]
	protected UAnimInstance MainAnimInstanceInternal;

	// Token: 0x0400C446 RID: 50246
	[Nullable(2)]
	protected UAnimInstance SpecialAnimInstanceInternal;

	// Token: 0x0400C447 RID: 50247
	protected bool IsPlayer;

	// Token: 0x0400C448 RID: 50248
	protected readonly HashSet<EForceDisableAnimOptimization> ForceDisableAnimOptimizationSet = new HashSet<EForceDisableAnimOptimization>();

	// Token: 0x0400C449 RID: 50249
	protected EVisibilityBasedAnimTickOption DefaultVisibilityBasedAnimTickOption = EVisibilityBasedAnimTickOption.OnlyTickPoseWhenRendered;

	// Token: 0x0400C44A RID: 50250
	private readonly Dictionary<EPerformGroup, MontageManager> MontageManagerMap = new Dictionary<EPerformGroup, MontageManager>();

	// Token: 0x0400C44B RID: 50251
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public HashSet<USkeletalMeshComponent> NoUpdateMeshes;

	// Token: 0x0400C44C RID: 50252
	[StaticVariableRuleIgnore]
	private static readonly Quat TmpSightQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400C44D RID: 50253
	[Nullable(2)]
	public TimerHandle CurMontageTimerHandle;
}
