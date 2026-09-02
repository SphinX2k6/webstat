using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002FB6 RID: 12214
[NullableContext(1)]
[Nullable(0)]
public class GameplayCueRopeEffectComponent : GameplayCueBase
{
	// Token: 0x06018E83 RID: 102019 RVA: 0x0070E3CD File Offset: 0x0070C5CD
	protected override void OnInit()
	{
	}

	// Token: 0x06018E84 RID: 102020 RVA: 0x0070E3D0 File Offset: 0x0070C5D0
	protected override void OnTick(float delta)
	{
		URopeEffectComponent ropeEffectComponent = this.RopeEffectComponent;
		ARopeEffectSplineActor aropeEffectSplineActor = (ropeEffectComponent != null) ? ropeEffectComponent.GetRopeActor() : null;
		if (aropeEffectSplineActor == null)
		{
			return;
		}
		bool bHidden = this.ActorInternal.bHidden;
		bool flag = bHidden;
		bool? lastHidden = this.LastHidden;
		if (!(flag == lastHidden.GetValueOrDefault() & lastHidden != null))
		{
			this.LastHidden = new bool?(bHidden);
			aropeEffectSplineActor.SetActorHiddenInGame(bHidden);
		}
	}

	// Token: 0x06018E85 RID: 102021 RVA: 0x0070E430 File Offset: 0x0070C630
	protected override void OnCreate()
	{
		if (this.ActorInternal == null || this.ActorInternal.Mesh == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.TSL, "创建切片绳索失败：目标角色无效", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		URopeEffectComponent uropeEffectComponent = this.ActorInternal.GetComponentByClass(URopeEffectComponent.StaticClass()) as URopeEffectComponent;
		if (uropeEffectComponent != null)
		{
			uropeEffectComponent.DestroyRope();
			this.ActorInternal.K2_DestroyComponent(uropeEffectComponent);
		}
		AActor actorInternal = this.ActorInternal;
		TSubclassOf<UActorComponent> @class = URopeEffectComponent.StaticClass();
		bool bManualAttachment = false;
		FTransform ftransform = new FTransform();
		this.RopeEffectComponent = (actorInternal.AddComponentByClass(@class, bManualAttachment, ftransform, false, default(FName)) as URopeEffectComponent);
		if (this.RopeEffectComponent == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.TSL, "创建切片绳索失败：AddComponentByClass 返回空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.RopeEffectComponent.bAutoFindSkeletalMesh = true;
		this.IsActive = true;
		this.LoadGeneration++;
		this.LoadRopeDataAsset();
	}

	// Token: 0x06018E86 RID: 102022 RVA: 0x0070E520 File Offset: 0x0070C720
	protected override void OnDestroy()
	{
		this.IsActive = false;
		this.LoadGeneration++;
		if (this.RopeEffectComponent != null)
		{
			this.RopeEffectComponent.DestroyRope();
			this.RopeEffectComponent.RopeDataAsset = null;
			if (this.ActorInternal != null)
			{
				this.ActorInternal.K2_DestroyComponent(this.RopeEffectComponent);
			}
		}
		this.RopeEffectComponent = null;
		this.LastHidden = null;
	}

	// Token: 0x06018E87 RID: 102023 RVA: 0x0070E58D File Offset: 0x0070C78D
	public new static bool IsSingleInstance()
	{
		return false;
	}

	// Token: 0x06018E88 RID: 102024 RVA: 0x0070E590 File Offset: 0x0070C790
	private unsafe void LoadRopeDataAsset()
	{
		URopeEffectComponent comp = this.RopeEffectComponent;
		if (comp == null)
		{
			return;
		}
		int generation = this.LoadGeneration;
		string path = "/Game/Aki/Render/RuntimeBP/RopeEffectComponent/DA/RopeDA.RopeDA";
		Singleton<ResourceSystem>.Instance.LoadAsync<URopeEffectDataAsset>(path, delegate([Nullable(2)] URopeEffectDataAsset dataAsset, string _)
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
				string message = "切片绳索 DataAsset 加载无效";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CueId", this.CueConfig.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("BuffId", this.BuffId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Path", path);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return;
			}
			if (!comp.IsValid() || comp != this.RopeEffectComponent)
			{
				return;
			}
			comp.RopeDataAsset = dataAsset;
			if (!comp.GenerateSlicedRopes())
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Battle;
				ELogAuthor author2 = ELogAuthor.TSL;
				string message2 = "切片绳索生成失败";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("CueId", this.CueConfig.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("BuffId", this.BuffId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Target", this.ActorInternal);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("DA", path);
				instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
				return;
			}
			ARopeEffectSplineActor ropeActor = comp.GetRopeActor();
			if (ropeActor != null)
			{
				this.LoadAndApplyNiagaraAsset(ropeActor, generation);
			}
		}, 100, "js_undefined");
	}

	// Token: 0x06018E89 RID: 102025 RVA: 0x0070E5FC File Offset: 0x0070C7FC
	private unsafe void LoadAndApplyNiagaraAsset(ARopeEffectSplineActor ropeActor, int generation)
	{
		string niagaraPath = base.GetPath();
		if (string.IsNullOrEmpty(niagaraPath))
		{
			return;
		}
		Singleton<ResourceSystem>.Instance.LoadAsync<UNiagaraSystem>(niagaraPath, delegate([Nullable(2)] UNiagaraSystem effectObject, string _)
		{
			if (generation != this.LoadGeneration || !this.IsActive)
			{
				return;
			}
			if (effectObject != null && effectObject.IsValid())
			{
				ARopeEffectSplineActor ropeActor2 = ropeActor;
				if (ropeActor2 != null && ropeActor2.IsValid())
				{
					ropeActor.SetRopeNiagaraAsset(effectObject);
					return;
				}
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.TSL;
			string message = "挂载 RopeNiagara 失败：资源或 RopeActor 无效";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CueId", this.CueConfig.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("BuffId", this.BuffId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Target", this.ActorInternal);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Path", niagaraPath);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}, 100, "js_undefined");
	}

	// Token: 0x0400C2A4 RID: 49828
	[Nullable(2)]
	private URopeEffectComponent RopeEffectComponent;

	// Token: 0x0400C2A5 RID: 49829
	private bool? LastHidden;

	// Token: 0x0400C2A6 RID: 49830
	private int LoadGeneration;

	// Token: 0x0400C2A7 RID: 49831
	private const string DEFAULT_ROPE_DATA_ASSET_PATH = "/Game/Aki/Render/RuntimeBP/RopeEffectComponent/DA/RopeDA.RopeDA";
}
