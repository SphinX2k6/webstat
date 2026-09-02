using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Effect;
using UnrealEngine;

// Token: 0x02002C80 RID: 11392
[NullableContext(1)]
[Nullable(0)]
public class UiModelBuffComponent : UiModelComponentBase
{
	// Token: 0x06016D96 RID: 93590 RVA: 0x00656AF2 File Offset: 0x00654CF2
	protected override void OnInit()
	{
		this.ActorComponent = base.Owner.CheckGetComponent<UiModelActorComponent>();
		this.EffectComponent = base.Owner.CheckGetComponent<UiModelEffectComponent>();
		this.RenderingMaterialComponent = base.Owner.CheckGetComponent<UiModelRenderingMaterialComponent>();
	}

	// Token: 0x06016D97 RID: 93591 RVA: 0x00656B27 File Offset: 0x00654D27
	protected override void OnEnd()
	{
		this.RemoveAllBuffId();
	}

	// Token: 0x06016D98 RID: 93592 RVA: 0x00656B30 File Offset: 0x00654D30
	public void AddBuffByBuffId(long buffId)
	{
		if (this.BuffToHandlesMap.ContainsKey(buffId))
		{
			return;
		}
		Buff? config = ConfigBuffById.GetConfig(buffId, true);
		if (config == null)
		{
			return;
		}
		long[] array = config.Value.GameplayCueIds();
		if (array.Length == 0)
		{
			return;
		}
		BuffHandle buffHandle = new BuffHandle();
		long[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			GameplayCue? config2 = ConfigGameplayCueById.GetConfig(array2[i], true);
			if (config2 != null)
			{
				this.ApplyCueConfig(config.Value, config2.Value, buffHandle);
			}
		}
		this.BuffToHandlesMap[buffId] = buffHandle;
	}

	// Token: 0x06016D99 RID: 93593 RVA: 0x00656BC8 File Offset: 0x00654DC8
	private void ApplyCueConfig(Buff buffConfig, GameplayCue cueConfig, BuffHandle buffHandle)
	{
		ECueType cueType = (ECueType)cueConfig.CueType;
		if (cueType != ECueType.Effect)
		{
			if (cueType != ECueType.Material)
			{
				return;
			}
			int num = this.AddMaterialControllerByCueConfig(cueConfig);
			if (num > 0)
			{
				buffHandle.MaterialHandleSet.Add(num);
			}
		}
		else
		{
			int num2 = this.PlayEffectByConfig(buffConfig, cueConfig);
			if (num2 > 0)
			{
				buffHandle.EffectHandleSet.Add(num2);
				return;
			}
		}
	}

	// Token: 0x06016D9A RID: 93594 RVA: 0x00656C1C File Offset: 0x00654E1C
	public int AddMaterialControllerByCueConfig(GameplayCue config)
	{
		string path = config.Path;
		if (StringUtils.IsBlank(path))
		{
			return 0;
		}
		if (this.RenderingMaterialComponent == null)
		{
			return 0;
		}
		return this.RenderingMaterialComponent.AddRenderingMaterialByPath(path);
	}

	// Token: 0x06016D9B RID: 93595 RVA: 0x00656C54 File Offset: 0x00654E54
	public int PlayEffectByConfig(Buff buffConfig, GameplayCue cueConfig)
	{
		float buffDuration = 0f;
		if (buffConfig.DurationPolicy == 2 && buffConfig.DurationMagnitudeLength > 0)
		{
			buffDuration = buffConfig.DurationMagnitude(0);
		}
		UiModelEffectPlayContext cacheEffectContext = this.CacheEffectContext;
		cacheEffectContext.Reset();
		cacheEffectContext.EffectPath = cueConfig.Path;
		cacheEffectContext.AttachTargetComponent = this.ActorComponent.MainMeshComponent;
		cacheEffectContext.LocationRule = (EAttachmentRule)cueConfig.LocRule;
		cacheEffectContext.RotationRule = (EAttachmentRule)cueConfig.RotaRule;
		cacheEffectContext.ScaleRule = (EAttachmentRule)cueConfig.SclRule;
		Aki.Config.Vector? location = cueConfig.Location;
		if (location != null)
		{
			Aki.Config.Vector value = location.Value;
			this.CacheLocation.Set((double)value.X, (double)value.Y, (double)value.Z);
			this.CacheTransform.SetLocation(this.CacheLocation);
		}
		Aki.Config.Vector? rotation = cueConfig.Rotation;
		if (rotation != null)
		{
			Aki.Config.Vector value2 = rotation.Value;
			this.CacheRotator.Set(value2.X, value2.Y, value2.Z);
			this.CacheTransform.SetRotation(this.CacheRotator.Quaternion(null));
		}
		Aki.Config.Vector? scale = cueConfig.Scale;
		if (scale != null)
		{
			Aki.Config.Vector value3 = scale.Value;
			this.CacheScale.Set((double)value3.X, (double)value3.Y, (double)value3.Z);
			this.CacheTransform.SetScale3D(this.CacheScale);
		}
		cacheEffectContext.Transform = this.CacheTransform.ToUeTransform();
		cacheEffectContext.SocketName = (FNameUtil.GetDynamicFName(cueConfig.Socket) ?? FNameUtil.EMPTY);
		if (buffDuration > 0f)
		{
			cacheEffectContext.Callback = delegate(ELoadEffectResult result, int handle)
			{
				if (result == ELoadEffectResult.Success)
				{
					float interval = buffDuration * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
					TimerSystem.Instance.Delay(delegate(float _)
					{
						this.StopEffectByCueEndRule(handle, (ECueEndRule)cueConfig.EndRule);
					}, interval, null, null, true, 1f);
				}
			};
		}
		return this.EffectComponent.PlayEffectByContext(cacheEffectContext);
	}

	// Token: 0x06016D9C RID: 93596 RVA: 0x00656E6C File Offset: 0x0065506C
	public void StopEffectByCueEndRule(int effectHandle, ECueEndRule endRule)
	{
		bool bFastStop = false;
		if (Singleton<EffectSystem>.Instance.IsValid(effectHandle))
		{
			switch (endRule)
			{
			case ECueEndRule.Recycle:
				bFastStop = true;
				break;
			case ECueEndRule.End:
				bFastStop = false;
				break;
			case ECueEndRule.Continue:
				Singleton<EffectSystem>.Instance.FreezeHandle(effectHandle, false, false);
				bFastStop = false;
				break;
			}
			this.EffectComponent.StopEffect(effectHandle, bFastStop);
		}
	}

	// Token: 0x06016D9D RID: 93597 RVA: 0x00656EC0 File Offset: 0x006550C0
	public void RemoveBuffByBuffId(long buffId)
	{
		BuffHandle buffHandle;
		if (!this.BuffToHandlesMap.TryGetValue(buffId, out buffHandle))
		{
			return;
		}
		foreach (int effectHandle in buffHandle.EffectHandleSet)
		{
			this.EffectComponent.StopEffect(effectHandle, true);
		}
		buffHandle.EffectHandleSet.Clear();
		foreach (int materialId in buffHandle.MaterialHandleSet)
		{
			UiModelRenderingMaterialComponent renderingMaterialComponent = this.RenderingMaterialComponent;
			if (renderingMaterialComponent != null)
			{
				renderingMaterialComponent.RemoveRenderingMaterial(materialId);
			}
		}
		buffHandle.MaterialHandleSet.Clear();
		this.BuffToHandlesMap.Remove(buffId);
	}

	// Token: 0x06016D9E RID: 93598 RVA: 0x00656F9C File Offset: 0x0065519C
	public void RemoveAllBuffId()
	{
		if (this.BuffToHandlesMap.Count == 0)
		{
			return;
		}
		foreach (long buffId in new List<long>(this.BuffToHandlesMap.Keys))
		{
			this.RemoveBuffByBuffId(buffId);
		}
		this.BuffToHandlesMap.Clear();
	}

	// Token: 0x0400B02C RID: 45100
	[Nullable(2)]
	private UiModelActorComponent ActorComponent;

	// Token: 0x0400B02D RID: 45101
	[Nullable(2)]
	private UiModelEffectComponent EffectComponent;

	// Token: 0x0400B02E RID: 45102
	[Nullable(2)]
	private UiModelRenderingMaterialComponent RenderingMaterialComponent;

	// Token: 0x0400B02F RID: 45103
	protected readonly Dictionary<long, BuffHandle> BuffToHandlesMap = new Dictionary<long, BuffHandle>();

	// Token: 0x0400B030 RID: 45104
	public UiModelEffectPlayContext CacheEffectContext = new UiModelEffectPlayContext();

	// Token: 0x0400B031 RID: 45105
	protected readonly global::Vector CacheLocation = global::Vector.Create();

	// Token: 0x0400B032 RID: 45106
	protected readonly Rotator CacheRotator = Rotator.Create();

	// Token: 0x0400B033 RID: 45107
	protected readonly global::Vector CacheScale = global::Vector.Create();

	// Token: 0x0400B034 RID: 45108
	protected readonly Transform CacheTransform = Transform.Create();
}
