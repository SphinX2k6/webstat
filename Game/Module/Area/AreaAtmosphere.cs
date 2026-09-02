using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Module.Area
{
	// Token: 0x02006174 RID: 24948
	[NullableContext(2)]
	[Nullable(0)]
	public class AreaAtmosphere
	{
		// Token: 0x0603F0BC RID: 258236 RVA: 0x0102A41B File Offset: 0x0102861B
		public AreaAtmosphere()
		{
			this.Init();
		}

		// Token: 0x0603F0BD RID: 258237 RVA: 0x0102A429 File Offset: 0x01028629
		private void Init()
		{
			this.AddEventListener();
		}

		// Token: 0x0603F0BE RID: 258238 RVA: 0x0102A431 File Offset: 0x01028631
		public void Destroy()
		{
			this.RemoveEventListener();
			this.ClearActorInfo();
		}

		// Token: 0x0603F0BF RID: 258239 RVA: 0x0102A43F File Offset: 0x0102863F
		private void ClearActorInfo()
		{
			if (this.CurActorInfo != null)
			{
				this.CurActorInfo.Clear();
				this.CurActorInfo = null;
			}
			if (this.LastActorInfo != null)
			{
				this.LastActorInfo.Clear();
				this.LastActorInfo = null;
			}
		}

		// Token: 0x0603F0C0 RID: 258240 RVA: 0x0102A475 File Offset: 0x01028675
		public void OnTick(float delta)
		{
			this.UpdateBlendWeight(this.CurActorInfo, delta);
			this.UpdateBlendWeight(this.LastActorInfo, delta);
		}

		// Token: 0x0603F0C1 RID: 258241 RVA: 0x0102A494 File Offset: 0x01028694
		private void UpdateBlendWeight(AreaAtmosphereActorInfo actorInfo, float delta)
		{
			if (actorInfo == null || !actorInfo.IsLoadCompleted)
			{
				return;
			}
			if (actorInfo.CurBlendWeight == actorInfo.TargetBlendWeight)
			{
				return;
			}
			float curBlendWeight = actorInfo.CurBlendWeight;
			if (actorInfo.ChangeSpeed == 0f)
			{
				actorInfo.CurBlendWeight = actorInfo.TargetBlendWeight;
			}
			else
			{
				if (delta <= 0f)
				{
					return;
				}
				if (actorInfo.TargetBlendWeight > actorInfo.CurBlendWeight)
				{
					actorInfo.CurBlendWeight += delta * actorInfo.ChangeSpeed;
					actorInfo.CurBlendWeight = Math.Min(actorInfo.CurBlendWeight, actorInfo.TargetBlendWeight);
				}
				else
				{
					actorInfo.CurBlendWeight -= delta * actorInfo.ChangeSpeed;
					actorInfo.CurBlendWeight = Math.Max(actorInfo.CurBlendWeight, actorInfo.TargetBlendWeight);
				}
			}
			actorInfo.KuroPostProcessComponent.BlendWeight = actorInfo.CurBlendWeight;
			if (curBlendWeight == 0f && actorInfo.CurBlendWeight > 0f)
			{
				actorInfo.KuroPostProcessComponent.bEnabled = true;
			}
			if (curBlendWeight > 0f && actorInfo.CurBlendWeight == 0f)
			{
				actorInfo.KuroPostProcessComponent.bEnabled = false;
			}
		}

		// Token: 0x0603F0C2 RID: 258242 RVA: 0x0102A5A4 File Offset: 0x010287A4
		private void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.ClearWorld, new Action(this.OnClearWorld));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Add<int?, int>(EEventName.ChangeArea, new Action<int?, int>(this.OnChangeAreaEvent));
		}

		// Token: 0x0603F0C3 RID: 258243 RVA: 0x0102A608 File Offset: 0x01028808
		private void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.ClearWorld, new Action(this.OnClearWorld));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Remove(EEventName.ChangeArea, new Action<int?, int>(this.OnChangeAreaEvent));
		}

		// Token: 0x0603F0C4 RID: 258244 RVA: 0x0102A669 File Offset: 0x01028869
		private void OnClearWorld()
		{
			this.ClearActorInfo();
		}

		// Token: 0x0603F0C5 RID: 258245 RVA: 0x0102A674 File Offset: 0x01028874
		private void OnWorldDone()
		{
			this.OnChangeArea(null, null);
		}

		// Token: 0x0603F0C6 RID: 258246 RVA: 0x0102A699 File Offset: 0x01028899
		private void OnChangeAreaEvent(int? preAreaId, int curAreaId)
		{
			this.OnChangeArea(preAreaId, new int?(curAreaId));
		}

		// Token: 0x0603F0C7 RID: 258247 RVA: 0x0102A6A8 File Offset: 0x010288A8
		private void OnChangeArea(int? preAreaId, int? curAreaId)
		{
			if (this.CurActorInfo != null)
			{
				this.CurActorInfo.TargetBlendWeight = 0f;
			}
			Area? areaInfo = ModelBase<AreaModel>.Instance.AreaInfo;
			if (areaInfo == null)
			{
				return;
			}
			int atmosphereId = areaInfo.Value.AtmosphereId;
			if (atmosphereId == 0)
			{
				if (areaInfo.Value.Father == 0)
				{
					return;
				}
				Area? areaInfo2 = ConfigBase<AreaConfig>.Instance.GetAreaInfo(areaInfo.Value.Father);
				if (areaInfo2 == null || areaInfo2.Value.AtmosphereId == 0)
				{
					return;
				}
				atmosphereId = areaInfo2.Value.AtmosphereId;
			}
			AreaAtmosphereInfo? areaAtmosphereInfo = ConfigBase<AreaConfig>.Instance.GetAreaAtmosphereInfo(atmosphereId);
			if (areaAtmosphereInfo == null)
			{
				return;
			}
			if (this.CurActorInfo == null)
			{
				this.CurActorInfo = new AreaAtmosphereActorInfo();
				this.UpdateCurAreaAtmosphereInfo(areaAtmosphereInfo.Value);
				this.CreateAtmosphereActor();
				return;
			}
			if (this.CurActorInfo.AreaAtmosphereInfo.Value.Id == areaAtmosphereInfo.Value.Id)
			{
				this.CurActorInfo.TargetBlendWeight = 1f;
				this.UpdateBlendWeight(this.CurActorInfo, 0f);
				this.UpdateCurActorTransform();
				return;
			}
			if (this.LastActorInfo == null)
			{
				this.LastActorInfo = this.CurActorInfo;
				this.CurActorInfo = new AreaAtmosphereActorInfo();
				this.UpdateCurAreaAtmosphereInfo(areaAtmosphereInfo.Value);
				this.CreateAtmosphereActor();
				return;
			}
			AreaAtmosphereActorInfo lastActorInfo = this.LastActorInfo;
			this.LastActorInfo = this.CurActorInfo;
			this.CurActorInfo = lastActorInfo;
			if (this.CurActorInfo.AreaAtmosphereInfo.Value.Id == areaAtmosphereInfo.Value.Id)
			{
				this.CurActorInfo.TargetBlendWeight = 1f;
				this.UpdateBlendWeight(this.CurActorInfo, 0f);
				this.UpdateCurActorTransform();
				return;
			}
			this.UpdateCurAreaAtmosphereInfo(areaAtmosphereInfo.Value);
			this.UpdateAtmosphereActor();
		}

		// Token: 0x0603F0C8 RID: 258248 RVA: 0x0102A898 File Offset: 0x01028A98
		private void UpdateCurAreaAtmosphereInfo(AreaAtmosphereInfo areaAtmosphereInfo)
		{
			this.CurActorInfo.AreaAtmosphereInfo = new AreaAtmosphereInfo?(areaAtmosphereInfo);
			if (areaAtmosphereInfo.FadeTime > 0)
			{
				this.CurActorInfo.ChangeSpeed = 1f / (float)(areaAtmosphereInfo.FadeTime * Singleton<TimeUtil>.Instance.InverseMillisecond);
				return;
			}
			this.CurActorInfo.ChangeSpeed = 0f;
		}

		// Token: 0x0603F0C9 RID: 258249 RVA: 0x0102A8F8 File Offset: 0x01028AF8
		private void UpdateCurActorTransform()
		{
			if (this.CurActorInfo != null)
			{
				AActor actor = this.CurActorInfo.Actor;
				if (actor != null && actor.IsValid())
				{
					if (Global.BaseCharacter != null)
					{
						FHitResult fhitResult = new FHitResult();
						this.CurActorInfo.Actor.D_K2_SetActorLocation(Global.BaseCharacter.D_K2_GetActorLocation(), false, ref fhitResult, true);
					}
					return;
				}
			}
		}

		// Token: 0x0603F0CA RID: 258250 RVA: 0x0102A958 File Offset: 0x01028B58
		private void CreateAtmosphereActor()
		{
			FTransformDouble? ftransformDouble = null;
			if (Global.BaseCharacter != null)
			{
				ftransformDouble = new FTransformDouble?(Global.BaseCharacter.D_GetTransform());
			}
			else
			{
				ftransformDouble = new FTransformDouble?(new FTransformDouble());
			}
			AActor aactor = Singleton<ActorSystem>.Instance.Get(AActor.StaticClass(), ftransformDouble.Value, null, true);
			UKuroPostProcessComponent ukuroPostProcessComponent = aactor.AddComponentByClass(UKuroPostProcessComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as UKuroPostProcessComponent;
			ukuroPostProcessComponent.bUnbound = true;
			ukuroPostProcessComponent.BlendWeight = 0f;
			ukuroPostProcessComponent.bEnabled = false;
			this.CurActorInfo.Actor = aactor;
			this.CurActorInfo.KuroPostProcessComponent = ukuroPostProcessComponent;
			this.CurActorInfo.TargetBlendWeight = 1f;
			this.CurActorInfo.CurBlendWeight = 0f;
			this.CurActorInfo.IsLoadCompleted = false;
			this.LoadDaAsset();
		}

		// Token: 0x0603F0CB RID: 258251 RVA: 0x0102AA3C File Offset: 0x01028C3C
		private void UpdateAtmosphereActor()
		{
			UKuroPostProcessComponent kuroPostProcessComponent = this.CurActorInfo.KuroPostProcessComponent;
			this.CurActorInfo.TargetBlendWeight = 1f;
			this.CurActorInfo.CurBlendWeight = 0f;
			this.CurActorInfo.IsLoadCompleted = false;
			kuroPostProcessComponent.PPTODDataAsset = null;
			kuroPostProcessComponent.WeatherDataAsset = null;
			kuroPostProcessComponent.BlendWeight = 0f;
			kuroPostProcessComponent.bEnabled = false;
			this.UpdateCurActorTransform();
			this.LoadDaAsset();
		}

		// Token: 0x0603F0CC RID: 258252 RVA: 0x0102AAAC File Offset: 0x01028CAC
		private void LoadDaAsset()
		{
			AreaAtmosphereInfo? areaAtmosphereInfo = this.CurActorInfo.AreaAtmosphereInfo;
			UKuroPostProcessComponent kuroPostProcessComponent = this.CurActorInfo.KuroPostProcessComponent;
			if (areaAtmosphereInfo.Value.IsTOD)
			{
				Singleton<ResourceSystem>.Instance.LoadAsync<UKuroTODData>(areaAtmosphereInfo.Value.DAPath, delegate([Nullable(2)] UKuroTODData dataAsset, string _)
				{
					if (dataAsset == null || !dataAsset.IsValid())
					{
						return;
					}
					if (this.CurActorInfo.AreaAtmosphereInfo.Value.Id != areaAtmosphereInfo.Value.Id)
					{
						return;
					}
					this.CurActorInfo.IsLoadCompleted = true;
					kuroPostProcessComponent.PPTODDataAsset = dataAsset;
					kuroPostProcessComponent.SetPriority((float)areaAtmosphereInfo.Value.Priority);
					this.UpdateBlendWeight(this.CurActorInfo, 0f);
				}, 100, "js_undefined");
				return;
			}
			Singleton<ResourceSystem>.Instance.LoadAsync<UKuroWeatherDataAsset>(areaAtmosphereInfo.Value.DAPath, delegate([Nullable(2)] UKuroWeatherDataAsset dataAsset, string _)
			{
				if (dataAsset == null || !dataAsset.IsValid())
				{
					return;
				}
				if (this.CurActorInfo.AreaAtmosphereInfo.Value.Id != areaAtmosphereInfo.Value.Id)
				{
					return;
				}
				this.CurActorInfo.IsLoadCompleted = true;
				kuroPostProcessComponent.WeatherDataAsset = dataAsset;
				kuroPostProcessComponent.SetPriority((float)areaAtmosphereInfo.Value.Priority);
				this.UpdateBlendWeight(this.CurActorInfo, 0f);
			}, 100, "js_undefined");
		}

		// Token: 0x040235EE RID: 144878
		private AreaAtmosphereActorInfo CurActorInfo;

		// Token: 0x040235EF RID: 144879
		private AreaAtmosphereActorInfo LastActorInfo;
	}
}
