using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002FB7 RID: 12215
[NullableContext(1)]
[Nullable(0)]
public class GameplayCueRopeVerletPhysics : GameplayCueBase
{
	// Token: 0x06018E8B RID: 102027 RVA: 0x0070E66C File Offset: 0x0070C86C
	protected override void OnInit()
	{
		string[] array = this.CueConfig.Socket.Split('#', StringSplitOptions.None);
		this.Sockets = new List<FName>(array.Length);
		foreach (string key in array)
		{
			this.Sockets.Add(FNameUtil.GetDynamicFName(key).Value);
		}
		this.FallbackFollowActor = this.ParseParamBool("FallbackFollowActor", false);
	}

	// Token: 0x06018E8C RID: 102028 RVA: 0x0070E6DC File Offset: 0x0070C8DC
	protected override void OnTick(float delta)
	{
		if (this.RopeComponent == null || !this.RopeReady)
		{
			return;
		}
		if (!this.ActorInternal.bHidden)
		{
			AActor ropeActor = this.RopeActor;
			if (ropeActor != null)
			{
				ropeActor.SetActorHiddenInGame(false);
			}
			this.RefreshTarget();
			FVector selfPoint = this.GetSelfPoint();
			FVector fvector = this.ComputeTargetPoint();
			this.RopeComponent.SetStartPosition(selfPoint);
			this.RopeComponent.SetEndPosition(fvector);
			if (!this.RopeComponent.bEnablePhysics)
			{
				this.RopeComponent.SimulatePhysics(delta);
			}
			return;
		}
		AActor ropeActor2 = this.RopeActor;
		if (ropeActor2 == null)
		{
			return;
		}
		ropeActor2.SetActorHiddenInGame(true);
	}

	// Token: 0x06018E8D RID: 102029 RVA: 0x0070E774 File Offset: 0x0070C974
	protected override void OnCreate()
	{
		this.RefreshTarget();
		this.RopeActor = this.CreateRopeActor();
		if (this.RopeActor == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.TSL, "创建物理绳索Actor失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.RopeComponent = (this.RopeActor.GetComponentByClass(URopeVerletComponent.StaticClass()) as URopeVerletComponent);
		if (this.RopeComponent == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.TSL, "获取RopeVerletComponent失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.LoadGeneration++;
		this.LoadDataAssetAndSetup();
	}

	// Token: 0x06018E8E RID: 102030 RVA: 0x0070E814 File Offset: 0x0070CA14
	protected override void OnDestroy()
	{
		this.IsActive = false;
		this.RopeReady = false;
		this.LoadGeneration++;
		if (this.RopeActor != null)
		{
			Singleton<ActorSystem>.Instance.Put("GameplayCueRopeVerletPhysics.Destroy", this.RopeActor, null);
			this.RopeActor = null;
		}
		this.RopeComponent = null;
	}

	// Token: 0x06018E8F RID: 102031 RVA: 0x0070E86A File Offset: 0x0070CA6A
	public new static bool IsSingleInstance()
	{
		return false;
	}

	// Token: 0x06018E90 RID: 102032 RVA: 0x0070E86D File Offset: 0x0070CA6D
	private bool HasTarget()
	{
		TsBaseCharacter targetActor = this.TargetActor;
		return targetActor != null && targetActor.IsValid() && this.TargetActor != this.ActorInternal;
	}

	// Token: 0x06018E91 RID: 102033 RVA: 0x0070E898 File Offset: 0x0070CA98
	private void RefreshTarget()
	{
		ValueTuple<TsBaseCharacter, string> valueTuple = this.ResolveLockOnOrSkillTarget();
		TsBaseCharacter item = valueTuple.Item1;
		string item2 = valueTuple.Item2;
		this.TargetActor = item;
		this.TargetSocketName = item2;
	}

	// Token: 0x06018E92 RID: 102034 RVA: 0x0070E8C8 File Offset: 0x0070CAC8
	[return: TupleElementNames(new string[]
	{
		"Target",
		"Socket"
	})]
	[return: Nullable(new byte[]
	{
		0,
		2,
		1
	})]
	private ValueTuple<TsBaseCharacter, string> ResolveLockOnOrSkillTarget()
	{
		EntityHandle entityHandle = null;
		string item = string.Empty;
		WorldEntity entity = this.EntityHandle.Entity;
		CharacterLockOnComponent characterLockOnComponent = (entity != null) ? entity.GetComponent<CharacterLockOnComponent>() : null;
		WorldEntity entity2 = this.EntityHandle.Entity;
		CharacterActorComponent characterActorComponent = (entity2 != null) ? entity2.GetComponent<CharacterActorComponent>() : null;
		if (characterLockOnComponent != null && characterActorComponent != null && characterActorComponent.IsAutonomousProxy)
		{
			entityHandle = characterLockOnComponent.GetCurrentTarget();
			item = characterLockOnComponent.GetCurrentTargetSocketName();
		}
		bool flag;
		if (entityHandle == null)
		{
			flag = true;
		}
		else
		{
			WorldEntity entity3 = entityHandle.Entity;
			flag = !((entity3 != null) ? new bool?(entity3.Valid) : null).GetValueOrDefault();
		}
		if (flag)
		{
			WorldEntity entity4 = this.EntityHandle.Entity;
			CharacterSkillComponent characterSkillComponent = (entity4 != null) ? entity4.GetComponent<CharacterSkillComponent>() : null;
			if (characterSkillComponent != null)
			{
				entityHandle = characterSkillComponent.SkillTarget;
				item = characterSkillComponent.SkillTargetSocket;
			}
		}
		bool flag2;
		if (entityHandle == null)
		{
			flag2 = true;
		}
		else
		{
			WorldEntity entity5 = entityHandle.Entity;
			flag2 = !((entity5 != null) ? new bool?(entity5.Valid) : null).GetValueOrDefault();
		}
		if (flag2)
		{
			return new ValueTuple<TsBaseCharacter, string>(null, string.Empty);
		}
		CharacterActorComponent component = entityHandle.Entity.GetComponent<CharacterActorComponent>();
		return new ValueTuple<TsBaseCharacter, string>((component != null) ? component.Actor : null, item);
	}

	// Token: 0x06018E93 RID: 102035 RVA: 0x0070E9E8 File Offset: 0x0070CBE8
	private FVector GetSelfPoint()
	{
		List<FName> sockets = this.Sockets;
		FName? socket = (sockets != null) ? new FName?(sockets[0]) : null;
		return GameplayCueRopeVerletPhysics.GetMeshSocketLocation(this.ActorInternal, socket);
	}

	// Token: 0x06018E94 RID: 102036 RVA: 0x0070EA24 File Offset: 0x0070CC24
	private FVector ComputeTargetPoint()
	{
		if (!this.HasTarget())
		{
			if (!this.FallbackFollowActor && this.CachedFallbackPoint != null)
			{
				return this.CachedFallbackPoint.Value;
			}
			return this.GetFallbackPoint();
		}
		else
		{
			TsBaseCharacter targetActor = this.TargetActor;
			USkeletalMeshComponent mesh = targetActor.Mesh;
			if (mesh == null)
			{
				return targetActor.K2_GetActorLocation();
			}
			FName? fname;
			if (string.IsNullOrEmpty(this.TargetSocketName))
			{
				List<FName> sockets = this.Sockets;
				fname = ((sockets != null) ? new FName?(sockets[1]) : null);
			}
			else
			{
				fname = FNameUtil.GetDynamicFName(this.TargetSocketName);
			}
			FName? fname2 = fname;
			if (fname2 == null || !mesh.DoesSocketExist(fname2.Value))
			{
				fname2 = new FName?(Singleton<CharacterNameDefines>.Instance.HIT_CASE_NAME);
			}
			return mesh.GetSocketLocation(fname2.Value);
		}
	}

	// Token: 0x06018E95 RID: 102037 RVA: 0x0070EAEC File Offset: 0x0070CCEC
	private FVector GetFallbackPoint()
	{
		FVector fvector = this.ActorInternal.K2_GetActorLocation();
		FVector actorForwardVector = this.ActorInternal.GetActorForwardVector();
		float fallbackForwardOffset = this.FallbackForwardOffset;
		return new FVector(fvector.X + actorForwardVector.X * fallbackForwardOffset, fvector.Y + actorForwardVector.Y * fallbackForwardOffset, fvector.Z + actorForwardVector.Z * fallbackForwardOffset);
	}

	// Token: 0x06018E96 RID: 102038 RVA: 0x0070EB4C File Offset: 0x0070CD4C
	private static FVector GetMeshSocketLocation(ABaseCharacter actor, FName? socket)
	{
		USkeletalMeshComponent mesh = actor.Mesh;
		if (socket != null && mesh != null)
		{
			return mesh.GetSocketLocation(socket.Value);
		}
		return actor.K2_GetActorLocation();
	}

	// Token: 0x06018E97 RID: 102039 RVA: 0x0070EB80 File Offset: 0x0070CD80
	private void InitializeSpline(FVector point1, FVector point2)
	{
		URopeVerletComponent ropeComponent = this.RopeComponent;
		ropeComponent.ClearSplinePoints(true);
		ropeComponent.AddSplinePoint(point1, ESplineCoordinateSpace.World, false);
		ropeComponent.AddSplinePoint(point2, ESplineCoordinateSpace.World, false);
		ropeComponent.UpdateSpline();
		ropeComponent.InitializeVerlet();
		ropeComponent.SetStartPosition(point1);
		ropeComponent.SetEndPosition(point2);
	}

	// Token: 0x06018E98 RID: 102040 RVA: 0x0070EBC0 File Offset: 0x0070CDC0
	[NullableContext(2)]
	private AActor CreateRopeActor()
	{
		AActor aactor = Singleton<ActorSystem>.Instance.Get(AActor.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true);
		if (aactor == null)
		{
			return null;
		}
		if (!(aactor.AddComponentByClass(URopeVerletComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) is URopeVerletComponent))
		{
			Singleton<ActorSystem>.Instance.Put("GameplayCueRopeVerletPhysics.CreateFailed", aactor, null);
			return null;
		}
		return aactor;
	}

	// Token: 0x06018E99 RID: 102041 RVA: 0x0070EC30 File Offset: 0x0070CE30
	private void LoadDataAssetAndSetup()
	{
		URopeVerletComponent comp = this.RopeComponent;
		if (comp == null)
		{
			return;
		}
		int generation = this.LoadGeneration;
		string daPath = this.HasTarget() ? "/Game/Aki/Render/RuntimeBP/RopeEffectComponent/DA/DynamicRopeVerletDA.DynamicRopeVerletDA" : "/Game/Aki/Render/RuntimeBP/RopeEffectComponent/DA/StaticRopeVerletDA.StaticRopeVerletDA";
		Singleton<ResourceSystem>.Instance.LoadAsync<URopeVerletDataAsset>(daPath, delegate([Nullable(2)] URopeVerletDataAsset dataAsset, string _)
		{
			if (generation != this.LoadGeneration || !this.IsActive)
			{
				return;
			}
			if (dataAsset == null || !dataAsset.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.TSL;
				string message = "加载RopeVerletDataAsset失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", daPath);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (!comp.IsValid() || comp != this.RopeComponent)
			{
				return;
			}
			this.SetupRope(comp, dataAsset);
		}, 100, "js_undefined");
	}

	// Token: 0x06018E9A RID: 102042 RVA: 0x0070ECAC File Offset: 0x0070CEAC
	private void SetupRope(URopeVerletComponent rope, URopeVerletDataAsset dataAsset)
	{
		rope.ApplyDataAsset(dataAsset);
		this.FallbackForwardOffset = dataAsset.FallbackForwardOffset;
		rope.bEnablePhysics = false;
		if (!this.HasTarget() && !this.FallbackFollowActor)
		{
			this.CachedFallbackPoint = new FVector?(this.GetFallbackPoint());
		}
		FVector selfPoint = this.GetSelfPoint();
		FVector point = this.ComputeTargetPoint();
		this.InitializeSpline(selfPoint, point);
		if (!string.IsNullOrEmpty(this.CueConfig.Path))
		{
			this.LoadNiagaraEffect(this.LoadGeneration);
		}
		this.RopeReady = true;
	}

	// Token: 0x06018E9B RID: 102043 RVA: 0x0070ED30 File Offset: 0x0070CF30
	private void LoadNiagaraEffect(int generation)
	{
		if (this.RopeComponent == null || this.RopeActor == null)
		{
			return;
		}
		Singleton<ResourceSystem>.Instance.LoadAsync<UNiagaraSystem>(this.CueConfig.Path, delegate([Nullable(2)] UNiagaraSystem effectObject, string _)
		{
			if (generation != this.LoadGeneration || !this.IsActive)
			{
				return;
			}
			if (effectObject != null && effectObject.IsValid())
			{
				AActor ropeActor = this.RopeActor;
				if (ropeActor != null && ropeActor.IsValid())
				{
					UNiagaraComponent uniagaraComponent = this.RopeActor.AddComponentByClass(UNiagaraComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as UNiagaraComponent;
					if (uniagaraComponent == null)
					{
						Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.TSL, "创建NiagaraComponent失败", default(ReadOnlySpan<ValueTuple<string, object>>));
						return;
					}
					uniagaraComponent.SetAsset(effectObject, true);
					UKuroRenderingRuntimeBPPluginBPLibrary.SetNiagaraSplineComponent(uniagaraComponent, "NewSpline", this.RopeComponent);
					return;
				}
			}
		}, 100, "js_undefined");
	}

	// Token: 0x06018E9C RID: 102044 RVA: 0x0070ED8C File Offset: 0x0070CF8C
	private bool ParseParamBool(string key, bool defaultValue)
	{
		int parametersLength = this.CueConfig.ParametersLength;
		string text = key + "=";
		for (int i = 0; i < parametersLength; i++)
		{
			string text2 = this.CueConfig.Parameters(i);
			if (text2.StartsWith(text))
			{
				return text2.Substring(text.Length) == "1";
			}
		}
		return defaultValue;
	}

	// Token: 0x0400C2A8 RID: 49832
	[Nullable(2)]
	private TsBaseCharacter TargetActor;

	// Token: 0x0400C2A9 RID: 49833
	private string TargetSocketName = string.Empty;

	// Token: 0x0400C2AA RID: 49834
	[Nullable(2)]
	private List<FName> Sockets;

	// Token: 0x0400C2AB RID: 49835
	[Nullable(2)]
	private URopeVerletComponent RopeComponent;

	// Token: 0x0400C2AC RID: 49836
	[Nullable(2)]
	private AActor RopeActor;

	// Token: 0x0400C2AD RID: 49837
	private float FallbackForwardOffset;

	// Token: 0x0400C2AE RID: 49838
	private bool FallbackFollowActor;

	// Token: 0x0400C2AF RID: 49839
	private FVector? CachedFallbackPoint;

	// Token: 0x0400C2B0 RID: 49840
	private int LoadGeneration;

	// Token: 0x0400C2B1 RID: 49841
	private bool RopeReady;

	// Token: 0x0400C2B2 RID: 49842
	private const string STATIC_ROPE_DATA_ASSET_PATH = "/Game/Aki/Render/RuntimeBP/RopeEffectComponent/DA/StaticRopeVerletDA.StaticRopeVerletDA";

	// Token: 0x0400C2B3 RID: 49843
	private const string DYNAMIC_ROPE_DATA_ASSET_PATH = "/Game/Aki/Render/RuntimeBP/RopeEffectComponent/DA/DynamicRopeVerletDA.DynamicRopeVerletDA";
}
