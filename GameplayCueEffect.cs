using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.Utils;
using UnrealEngine;

// Token: 0x02002FA2 RID: 12194
[NullableContext(1)]
[Nullable(0)]
public class GameplayCueEffect : GameplayCueMagnitude
{
	// Token: 0x06018DD2 RID: 101842 RVA: 0x0070A054 File Offset: 0x00708254
	protected unsafe override void OnInit()
	{
		base.OnInit();
		if (this.IsInstant && this.CueConfig.Magni != 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.HXY;
			string message = "瞬间型Buff特效不能应用特效幅度，因为瞬间型Buff特效依赖特效自身管理生命周期";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("BuffId", this.BuffId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CueId", this.CueConfig.Id);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		Aki.Config.Vector value = this.CueConfig.Location.Value;
		Aki.Config.Vector value2 = this.CueConfig.Rotation.Value;
		Aki.Config.Vector value3 = this.CueConfig.Scale.Value;
		FVector fvector = new FVector(value.X, value.Y, value.Z);
		FRotator frotator = new FRotator(value2.X, value2.Y, value2.Z);
		FVector fvector2 = new FVector(value3.X, value3.Y, value3.Z);
		this.RelativeTransform = Transform.Create(frotator.Quaternion(), fvector, fvector2);
		this.ApplyRelativeTransformOverride(base.InitCueParam.RelativePositionOverride, base.InitCueParam.RelativeRotationOverride, base.InitCueParam.ScaleOverride);
		if (this.CueConfig.ParametersLength == 0 || this.CueConfig.Parameters(0) != "0")
		{
			this.IsSeekNeedProcess = true;
			return;
		}
		this.IsSeekNeedProcess = false;
	}

	// Token: 0x06018DD3 RID: 101843 RVA: 0x0070A1FA File Offset: 0x007083FA
	protected override void OnTick(float delta)
	{
		base.OnTick(delta);
	}

	// Token: 0x06018DD4 RID: 101844 RVA: 0x0070A204 File Offset: 0x00708404
	protected override void OnCreate()
	{
		this.SetTargetMeshAndSocket();
		EffectSystem instance = Singleton<EffectSystem>.Instance;
		UObject world = GlobalData.World;
		FTransformDouble? ftransformDouble = new FTransformDouble?(this.RelativeTransform.ToUeTransform());
		this.EffectViewHandle = instance.SpawnEffect(world, ftransformDouble, base.GetPath(), "[GameplayCueEffect.OnCreate]", this.CreateEffectContext(), EEffectType.Fight, delegate(int handle)
		{
			Action beginCallback = this.BeginCallback;
			if (beginCallback != null)
			{
				beginCallback();
			}
			if (this.UseMagnitude())
			{
				Singleton<EffectSystem>.Instance.FreezeHandle(handle, true, false);
			}
		}, null, null, false, false);
		if (!this.IsValidEffect())
		{
			return;
		}
		this.EffectTimeScaleType = this.GetEffectTimeScaleType();
		this.CueComp.AddCueEffectToSet(this.EffectViewHandle, this.EffectTimeScaleType, (ECueHideRule)this.CueConfig.HideRule);
		this.AttachEffect(false);
		this.AddFinishCallback();
		base.OnCreate();
	}

	// Token: 0x06018DD5 RID: 101845 RVA: 0x0070A2AC File Offset: 0x007084AC
	protected override void OnDestroy()
	{
		base.OnDestroy();
		if (Singleton<EffectSystem>.Instance.IsValid(this.EffectViewHandle))
		{
			Singleton<EffectSystem>.Instance.SetTimeScale(this.EffectViewHandle, 1f, false);
			switch (this.CueConfig.EndRule)
			{
			case 0:
				Singleton<EffectSystem>.Instance.StopEffectById(this.EffectViewHandle, "[GameplayCueEffect.OnDestroy]", true, null);
				break;
			case 1:
				this.ListenForeverTimeScale();
				Singleton<EffectSystem>.Instance.StopEffectById(this.EffectViewHandle, "[GameplayCueEffect.OnDestroy]", this.IsForceRecycle, null);
				break;
			case 2:
				Singleton<EffectSystem>.Instance.FreezeHandle(this.EffectViewHandle, false, false);
				this.ListenForeverTimeScale();
				Singleton<EffectSystem>.Instance.StopEffectById(this.EffectViewHandle, "[GameplayCueEffect.OnDestroy]", this.IsForceRecycle, null);
				break;
			}
		}
		if (this.CueConfig.Comp == 2)
		{
			CharacterWeapon targetCharacterWeapon = this.TargetCharacterWeapon;
			if (targetCharacterWeapon != null)
			{
				targetCharacterWeapon.RemoveBuffEffect(this.EffectViewHandle);
			}
			this.RemoveWeaponRefreshListener();
		}
		if (this.IsListenScaleChanged)
		{
			this.RemoveMorphTypeChangedListener();
		}
	}

	// Token: 0x06018DD6 RID: 101846 RVA: 0x0070A3D2 File Offset: 0x007085D2
	protected override void OnSetMagnitude(float normalizedValue)
	{
		if (this.IsSeekNeedProcess)
		{
			Singleton<EffectSystem>.Instance.HandleSeekToTimeWithProcess(this.EffectViewHandle, normalizedValue, true, -1f);
			return;
		}
		Singleton<EffectSystem>.Instance.HandleSeekToTime(this.EffectViewHandle, normalizedValue, true, false);
	}

	// Token: 0x06018DD7 RID: 101847 RVA: 0x0070A408 File Offset: 0x00708608
	public override void OnChangeRole(EntityHandle newEntityHandle)
	{
		base.OnChangeRole(newEntityHandle);
		this.RefreshEffectStatus(true);
	}

	// Token: 0x06018DD8 RID: 101848 RVA: 0x0070A418 File Offset: 0x00708618
	public void SyncMagnitude(GameplayCueEffect cueRef)
	{
		float passTime = Singleton<EffectSystem>.Instance.GetPassTime(cueRef.EffectViewHandle);
		Singleton<EffectSystem>.Instance.HandleSeekToTime(this.EffectViewHandle, passTime, true, false);
	}

	// Token: 0x06018DD9 RID: 101849 RVA: 0x0070A44A File Offset: 0x0070864A
	protected virtual void RefreshEffectStatus(bool onChangeRole)
	{
		this.SetTargetMeshAndSocket();
		this.AttachEffect(onChangeRole);
		Singleton<EffectSystem>.Instance.AttachSkeletalMesh(this.EffectViewHandle, this.CreateEffectContext());
	}

	// Token: 0x06018DDA RID: 101850 RVA: 0x0070A470 File Offset: 0x00708670
	protected virtual void AttachEffect(bool onChangeRole = false)
	{
		OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(this.EffectViewHandle);
		if (this.CueConfig.Comp == 1 || this.CueConfig.Comp == 2)
		{
			this.ScaleEffect(effectActor);
			effectActor.K2_AttachToComponent(this.TargetMesh, new FName?(this.TargetSocket), (EAttachmentRule)this.CueConfig.LocRule, (EAttachmentRule)this.CueConfig.RotaRule, (EAttachmentRule)this.CueConfig.SclRule, false);
			if (this.CueConfig.Comp == 2)
			{
				CharacterWeapon targetCharacterWeapon = this.TargetCharacterWeapon;
				if (targetCharacterWeapon == null)
				{
					return;
				}
				targetCharacterWeapon.AddBuffEffect(this.EffectViewHandle);
				return;
			}
		}
		else if (!onChangeRole)
		{
			Transform socketTransform = this.SocketTransform;
			FTransformDouble ftransformDouble = this.TargetMesh.D_GetSocketTransform(this.TargetSocket, ERelativeTransformSpace.RTS_World);
			socketTransform.FromUeTransform(ftransformDouble);
			this.RelativeTransform.ComposeTransforms(this.SocketTransform, this.TargetTransform);
			OneOf<KuroEffectActorHandle, AActor> self = effectActor;
			ftransformDouble = this.TargetTransform.ToUeTransform();
			self.D_K2_SetActorTransform(ftransformDouble, false, ref WorldGlobal.SweepHitResult, true);
		}
	}

	// Token: 0x06018DDB RID: 101851 RVA: 0x0070A568 File Offset: 0x00708768
	protected unsafe virtual void SetTargetMeshAndSocket()
	{
		if (this.CueConfig.Comp == 2)
		{
			this.TargetCharacterWeapon = this.GetCharacterWeapon();
			CharacterWeapon targetCharacterWeapon = this.TargetCharacterWeapon;
			USkeletalMeshComponent uskeletalMeshComponent = ((targetCharacterWeapon != null) ? targetCharacterWeapon.Mesh : null) as USkeletalMeshComponent;
			if (uskeletalMeshComponent != null)
			{
				this.TargetMesh = uskeletalMeshComponent;
			}
		}
		else
		{
			this.TargetMesh = this.GetAttachedComponent();
		}
		this.TargetSocket = FNameUtil.GetDynamicFName(this.CueConfig.Socket).Value;
		USkeletalMeshComponent targetMesh = this.TargetMesh;
		if (targetMesh == null || !targetMesh.DoesSocketExist(this.TargetSocket))
		{
			this.TargetSocket = Singleton<CharacterNameDefines>.Instance.ROOT;
			if (this.CueConfig.Comp == 2)
			{
				this.AddWeaponRefreshListener();
			}
		}
		string socketNameOverride = base.InitCueParam.SocketNameOverride;
		if (socketNameOverride != null)
		{
			FName? dynamicFName = FNameUtil.GetDynamicFName(socketNameOverride);
			if (dynamicFName != null)
			{
				USkeletalMeshComponent targetMesh2 = this.TargetMesh;
				if (targetMesh2 != null && targetMesh2.DoesSocketExist(dynamicFName.Value))
				{
					this.TargetSocket = dynamicFName.Value;
					return;
				}
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderEffect;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "[FxEmote] 覆盖挂点不存在于目标Mesh，保持原挂点";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CueId", this.CueConfig.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SocketOverride", socketNameOverride);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
	}

	// Token: 0x06018DDC RID: 101852 RVA: 0x0070A6CC File Offset: 0x007088CC
	public override void OnGameplayCueEffectOverride(IGameplayCueEffectOverride @override)
	{
		if (@override.SocketName != null)
		{
			this.SetSocketAndReattach(@override.SocketName);
		}
		if (@override.RelativePosition == null && @override.RelativeRotation == null && @override.Scale == null)
		{
			return;
		}
		this.ApplyRelativeTransformOverride(@override.RelativePosition, @override.RelativeRotation, @override.Scale);
		this.AttachEffect(false);
	}

	// Token: 0x06018DDD RID: 101853 RVA: 0x0070A740 File Offset: 0x00708940
	private void ApplyRelativeTransformOverride(FVector? position, FVector? rotation, FVector? scale)
	{
		if (this.RelativeTransform == null)
		{
			return;
		}
		if (position != null)
		{
			this.RelativeTransform.SetLocation(global::Vector.Create((double)position.Value.X, (double)position.Value.Y, (double)position.Value.Z));
		}
		if (rotation != null)
		{
			FRotator frotator = new FRotator(rotation.Value.X, rotation.Value.Y, rotation.Value.Z);
			this.RelativeTransform.SetRotation(frotator.Quaternion());
		}
		if (scale != null)
		{
			this.RelativeTransform.SetScale3D(global::Vector.Create((double)scale.Value.X, (double)scale.Value.Y, (double)scale.Value.Z));
		}
	}

	// Token: 0x06018DDE RID: 101854 RVA: 0x0070A824 File Offset: 0x00708A24
	public void SetSocketAndReattach(string socketName)
	{
		if (this.TargetMesh == null)
		{
			return;
		}
		FName? dynamicFName = FNameUtil.GetDynamicFName(socketName);
		if (dynamicFName != null && this.TargetMesh.DoesSocketExist(dynamicFName.Value))
		{
			this.TargetSocket = dynamicFName.Value;
		}
		else
		{
			this.TargetSocket = Singleton<CharacterNameDefines>.Instance.ROOT;
		}
		this.AttachEffect(false);
	}

	// Token: 0x06018DDF RID: 101855 RVA: 0x0070A884 File Offset: 0x00708A84
	protected virtual SkeletalMeshEffectContext CreateEffectContext()
	{
		return new SkeletalMeshEffectContext(null, null, false)
		{
			SkeletalMeshComp = this.TargetMesh,
			EntityId = new int?(this.EntityHandle.Id)
		};
	}

	// Token: 0x06018DE0 RID: 101856 RVA: 0x0070A8C4 File Offset: 0x00708AC4
	private void ListenForeverTimeScale()
	{
		WorldEntity entity = this.EntityHandle.Entity;
		PawnTimeScaleComponent pawnTimeScaleComponent = (entity != null) ? entity.GetComponent<PawnTimeScaleComponent>() : null;
		if (!pawnTimeScaleComponent)
		{
			return;
		}
		if (this.EffectTimeScaleType == ETimeScaleType.FollowEntity)
		{
			EffectUtil.ListenForeverTimeScale(this.EffectViewHandle, pawnTimeScaleComponent);
		}
	}

	// Token: 0x06018DE1 RID: 101857 RVA: 0x0070A908 File Offset: 0x00708B08
	[NullableContext(2)]
	private USkeletalMeshComponent GetAttachedComponent()
	{
		if (!this.ActorInternal.IsValid())
		{
			return null;
		}
		if (this.CueConfig.CompName == "Mesh")
		{
			return this.ActorInternal.Mesh;
		}
		foreach (UActorComponent uactorComponent in this.ActorInternal.K2_GetComponentsByClass(UMeshComponent.StaticClass()))
		{
			USkeletalMeshComponent uskeletalMeshComponent = uactorComponent as USkeletalMeshComponent;
			if (uskeletalMeshComponent != null && uactorComponent.GetName() == this.CueConfig.CompName)
			{
				return uskeletalMeshComponent;
			}
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Battle;
		ELogAuthor author = ELogAuthor.HXY;
		string message = "Cue信息错误！或者无法找到合适的组件";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CueId", this.CueConfig.Id);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x06018DE2 RID: 101858 RVA: 0x0070A9F0 File Offset: 0x00708BF0
	[NullableContext(2)]
	private CharacterWeaponComponent GetWeaponComponent()
	{
		if (!this.ActorInternal.IsValid() || this.CueConfig.Comp != 2)
		{
			return null;
		}
		WorldEntity entity = this.EntityHandle.Entity;
		CharacterWeaponComponent characterWeaponComponent = (entity != null) ? entity.GetComponent<CharacterWeaponComponent>() : null;
		if (characterWeaponComponent == null || !characterWeaponComponent.Valid)
		{
			return null;
		}
		return characterWeaponComponent;
	}

	// Token: 0x06018DE3 RID: 101859 RVA: 0x0070AA40 File Offset: 0x00708C40
	[NullableContext(2)]
	private CharacterWeapon GetCharacterWeapon()
	{
		if (!this.ActorInternal.IsValid() || this.CueConfig.Comp != 2)
		{
			return null;
		}
		CharacterWeaponComponent weaponComponent = this.GetWeaponComponent();
		if (weaponComponent == null)
		{
			return null;
		}
		CharacterWeaponMesh weaponMesh = weaponComponent.GetWeaponMesh();
		if (weaponMesh == null)
		{
			return null;
		}
		int num;
		if (!int.TryParse(this.CueConfig.CompName.Replace("WeaponCase", ""), out num))
		{
			return null;
		}
		if (num < 0 || num >= weaponMesh.CharacterWeapons.Length)
		{
			return null;
		}
		return weaponMesh.CharacterWeapons[num];
	}

	// Token: 0x06018DE4 RID: 101860 RVA: 0x0070AAC0 File Offset: 0x00708CC0
	private void ScaleEffect([Nullable(new byte[]
	{
		0,
		1,
		1
	})] OneOf<KuroEffectActorHandle, AActor> effectActor)
	{
		float num = this.CueConfig.TargetScaleUp(0);
		float num2 = this.CueConfig.TargetScaleUp(1);
		if (num >= num2)
		{
			return;
		}
		if (!this.IsInitScaleEffect)
		{
			this.IsInitScaleEffect = true;
			this.OriginScale = effectActor.D_GetActorScale3D();
			WorldEntity entity = this.EntityHandle.Entity;
			bool flag;
			if (entity == null)
			{
				flag = false;
			}
			else
			{
				CharacterMorphComponent component = entity.GetComponent<CharacterMorphComponent>();
				flag = ((component != null) ? new bool?(component.IsEnableMorph()) : null).GetValueOrDefault();
			}
			if (flag)
			{
				this.IsListenScaleChanged = true;
				this.AddMorphTypeChangedListener();
			}
		}
		FVector fvector = new FVector();
		FVector fvector2 = new FVector();
		float num3 = 0f;
		UKismetSystemLibrary.GetComponentBounds(this.TargetMesh, ref fvector, ref fvector2, ref num3);
		float num4 = fvector2.X / 50f * fvector2.Y / 50f * fvector2.Z / 50f;
		num4 = Singleton<MathUtils>.Instance.Clamp(num4, 5f, 60f);
		float num5 = (num4 - 5f) / 55f * (num2 - num) + num;
		FVectorDouble fvectorDouble = this.OriginScale * (double)num5;
		effectActor.D_SetActorScale3D(fvectorDouble);
	}

	// Token: 0x06018DE5 RID: 101861 RVA: 0x0070ABE4 File Offset: 0x00708DE4
	private bool IsValidEffect()
	{
		return Singleton<EffectSystem>.Instance.IsValid(this.EffectViewHandle) && Singleton<EffectSystem>.Instance.GetEffectActor(this.EffectViewHandle).IsValid();
	}

	// Token: 0x06018DE6 RID: 101862 RVA: 0x0070AC14 File Offset: 0x00708E14
	private void AddFinishCallback()
	{
		if (this.EndCallback != null && !this.IsInstant)
		{
			Singleton<EffectSystem>.Instance.AddFinishCallback(this.EffectViewHandle, delegate(int _)
			{
				Action endCallback = this.EndCallback;
				if (endCallback == null)
				{
					return;
				}
				endCallback();
			});
		}
	}

	// Token: 0x06018DE7 RID: 101863 RVA: 0x0070AC44 File Offset: 0x00708E44
	private ETimeScaleType GetEffectTimeScaleType()
	{
		if (this.BuffHandleId <= 0)
		{
			return ETimeScaleType.FollowEntity;
		}
		WorldEntity entity = this.EntityHandle.Entity;
		BaseBuffComponent baseBuffComponent = (entity != null) ? entity.GetComponent<BaseBuffComponent>() : null;
		IActiveBuff activeBuff = (baseBuffComponent != null) ? baseBuffComponent.GetBuffByHandle(this.BuffHandleId) : null;
		if (activeBuff == null)
		{
			return ETimeScaleType.FollowEntity;
		}
		Entity instigator = activeBuff.GetInstigator();
		bool? flag;
		if (instigator == null)
		{
			flag = null;
		}
		else
		{
			CreatureDataComponent component = instigator.GetComponent<CreatureDataComponent>();
			flag = ((component != null) ? new bool?(component.IsRole()) : null);
		}
		bool? flag2 = flag;
		if (!flag2.GetValueOrDefault())
		{
			return ETimeScaleType.FollowEntity;
		}
		return ETimeScaleType.ImmuneForeverTimeScale;
	}

	// Token: 0x06018DE8 RID: 101864 RVA: 0x0070ACCC File Offset: 0x00708ECC
	private void AddWeaponRefreshListener()
	{
		if (this.IsInstant)
		{
			return;
		}
		WorldEntity entity = this.EntityHandle.Entity;
		if (entity == null || !entity.Valid)
		{
			return;
		}
		if (!Singleton<EventSystem>.Instance.HasWithTarget(entity, EEventName.CharacterWeaponLoaded, new Action<string>(this.OnCharacterWeaponLoaded)))
		{
			Singleton<EventSystem>.Instance.AddWithTarget<string>(entity, EEventName.CharacterWeaponLoaded, new Action<string>(this.OnCharacterWeaponLoaded));
		}
	}

	// Token: 0x06018DE9 RID: 101865 RVA: 0x0070AD3C File Offset: 0x00708F3C
	private void RemoveWeaponRefreshListener()
	{
		WorldEntity entity = this.EntityHandle.Entity;
		if (entity == null)
		{
			return;
		}
		if (Singleton<EventSystem>.Instance.HasWithTarget(entity, EEventName.CharacterWeaponLoaded, new Action<string>(this.OnCharacterWeaponLoaded)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<string>(entity, EEventName.CharacterWeaponLoaded, new Action<string>(this.OnCharacterWeaponLoaded));
		}
	}

	// Token: 0x06018DEA RID: 101866 RVA: 0x0070AD94 File Offset: 0x00708F94
	private void OnCharacterWeaponLoaded(string weaponCaseName)
	{
		USkeletalMeshComponent targetMesh = this.TargetMesh;
		if (targetMesh == null || !targetMesh.IsValid() || this.TargetMesh.GetName() != weaponCaseName)
		{
			return;
		}
		this.SetTargetMeshAndSocket();
		this.AttachEffect(false);
		this.RemoveWeaponRefreshListener();
	}

	// Token: 0x06018DEB RID: 101867 RVA: 0x0070ADD4 File Offset: 0x00708FD4
	private void AddMorphTypeChangedListener()
	{
		if (this.IsInstant)
		{
			return;
		}
		WorldEntity entity = this.EntityHandle.Entity;
		if (entity == null || !entity.Valid)
		{
			return;
		}
		if (!Singleton<EventSystem>.Instance.HasWithTarget(entity, EEventName.OnCharacterMorphTypeChanged, new Action<Entity, EMorphType, EMorphType>(this.OnCharacterMorphTypeChanged)))
		{
			Singleton<EventSystem>.Instance.AddWithTarget<Entity, EMorphType, EMorphType>(entity, EEventName.OnCharacterMorphTypeChanged, new Action<Entity, EMorphType, EMorphType>(this.OnCharacterMorphTypeChanged));
		}
	}

	// Token: 0x06018DEC RID: 101868 RVA: 0x0070AE44 File Offset: 0x00709044
	private void RemoveMorphTypeChangedListener()
	{
		WorldEntity entity = this.EntityHandle.Entity;
		if (entity == null)
		{
			return;
		}
		if (Singleton<EventSystem>.Instance.HasWithTarget(entity, EEventName.OnCharacterMorphTypeChanged, new Action<Entity, EMorphType, EMorphType>(this.OnCharacterMorphTypeChanged)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<Entity, EMorphType, EMorphType>(entity, EEventName.OnCharacterMorphTypeChanged, new Action<Entity, EMorphType, EMorphType>(this.OnCharacterMorphTypeChanged));
		}
	}

	// Token: 0x06018DED RID: 101869 RVA: 0x0070AE9C File Offset: 0x0070909C
	private void OnCharacterMorphTypeChanged(Entity entity, EMorphType morphType, EMorphType oldMorphType)
	{
		OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(this.EffectViewHandle);
		if (effectActor.HasValue)
		{
			this.ScaleEffect(effectActor);
		}
	}

	// Token: 0x0400C230 RID: 49712
	private const float RATE = 50f;

	// Token: 0x0400C231 RID: 49713
	private const float VOLUME_MIN = 5f;

	// Token: 0x0400C232 RID: 49714
	private const float VOLUME_MAX = 60f;

	// Token: 0x0400C233 RID: 49715
	public int EffectViewHandle;

	// Token: 0x0400C234 RID: 49716
	[Nullable(2)]
	protected USkeletalMeshComponent TargetMesh;

	// Token: 0x0400C235 RID: 49717
	protected FName TargetSocket;

	// Token: 0x0400C236 RID: 49718
	[Nullable(2)]
	private CharacterWeapon TargetCharacterWeapon;

	// Token: 0x0400C237 RID: 49719
	[Nullable(2)]
	protected Transform RelativeTransform;

	// Token: 0x0400C238 RID: 49720
	protected bool IsSeekNeedProcess;

	// Token: 0x0400C239 RID: 49721
	protected readonly Transform SocketTransform = Transform.Create();

	// Token: 0x0400C23A RID: 49722
	protected readonly Transform TargetTransform = Transform.Create();

	// Token: 0x0400C23B RID: 49723
	protected ETimeScaleType EffectTimeScaleType;

	// Token: 0x0400C23C RID: 49724
	protected bool IsInitScaleEffect;

	// Token: 0x0400C23D RID: 49725
	protected FVectorDouble OriginScale;

	// Token: 0x0400C23E RID: 49726
	protected bool IsListenScaleChanged;

	// Token: 0x0400C23F RID: 49727
	public bool IsForceRecycle;
}
