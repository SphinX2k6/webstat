using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.PathLine;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.NewWorld.SceneItem;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using CSharpScript.Game.NewWorld.SceneItem.Model;
using CSharpScript.Game.Render;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.AimLine
{
	// Token: 0x02006F71 RID: 28529
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class LevelAimLineController : ControllerBase<LevelAimLineController>
	{
		// Token: 0x060450B1 RID: 282801 RVA: 0x011FAE64 File Offset: 0x011F9064
		protected override bool OnInit()
		{
			Singleton<ResourceSystem>.Instance.LoadTypeAsync("BP_Miaozhunxian_C", delegate
			{
				this.Actor = (Singleton<ActorSystem>.Instance.Get(BP_Miaozhunxian_C.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true) as BP_Miaozhunxian_C);
				if (this.Actor != null && this.Actor.IsValid())
				{
					this.SplineComp = (this.Actor.GetComponentByClass(USplineComponent.StaticClass()) as USplineComponent);
					this.Actor.Init();
				}
			}, "js_undefined");
			Singleton<ResourceSystem>.Instance.LoadTypeAsync("BP_Miaozhunxian_Bullet_C", delegate
			{
				this.BulletActor = (Singleton<ActorSystem>.Instance.Get(BP_Miaozhunxian_Bullet_C.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true) as BP_Miaozhunxian_Bullet_C);
				if (this.BulletActor != null && this.BulletActor.IsValid())
				{
					this.BulletActor.OnActorBeginOverlap.Add(new Action<AActor, AActor>(this.BeginOverlap));
				}
			}, "js_undefined");
			Singleton<ResourceSystem>.Instance.LoadAsync<ItemMaterialControllerActorData>("/Game/Aki/Effect/MaterialController/ItemMaterial/DA_Fx_ActorItem_Scanning.DA_Fx_ActorItem_Scanning", delegate([Nullable(2)] ItemMaterialControllerActorData asset, string _)
			{
				this.MatData = asset;
			}, 100, "js_undefined");
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
			return true;
		}

		// Token: 0x060450B2 RID: 282802 RVA: 0x011FAEF4 File Offset: 0x011F90F4
		protected override bool OnClear()
		{
			if (this.Actor != null && this.Actor.IsValid())
			{
				Singleton<ActorSystem>.Instance.Put("LevelAimLineController.OnClear1", this.Actor, null);
			}
			if (this.BulletActor != null && this.BulletActor.IsValid())
			{
				Singleton<ActorSystem>.Instance.Put("LevelAimLineController.OnClear2", this.BulletActor, null);
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.WorldDone, new Action(this.OnWorldDone)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
			}
			return true;
		}

		// Token: 0x060450B3 RID: 282803 RVA: 0x011FAF94 File Offset: 0x011F9194
		[NullableContext(2)]
		public bool PlayEffect(string effectPath = null)
		{
			if (this.IsPlaying)
			{
				return false;
			}
			this.IsPlaying = true;
			if (string.IsNullOrEmpty(effectPath))
			{
				this.IsShowMesh = true;
				this.Actor.ShowMesh();
			}
			else
			{
				EffectSystem instance = Singleton<EffectSystem>.Instance;
				UObject world = GlobalData.World;
				FTransformDouble? ftransformDouble = new FTransformDouble?(Singleton<MathUtils>.Instance.DefaultTransformDouble);
				this.InstructionEffect = new int?(instance.SpawnEffect(world, ftransformDouble, effectPath, "[LevelAimLineController.PlayEffect]", new EffectContext(null, this.Actor, false), EEffectType.Scene, null, null, null, false, false));
				if (!Singleton<EffectSystem>.Instance.IsValid(this.InstructionEffect.GetValueOrDefault()))
				{
					return false;
				}
				OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(this.InstructionEffect.Value);
				AActor actor = this.Actor;
				FName? fname = null;
				effectActor.K2_AttachToActor(actor, fname, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, false);
			}
			return true;
		}

		// Token: 0x060450B4 RID: 282804 RVA: 0x011FB068 File Offset: 0x011F9268
		public bool StopEffect()
		{
			if (!this.IsPlaying)
			{
				return false;
			}
			this.IsPlaying = false;
			if (this.IsShowMesh)
			{
				this.Actor.HideMesh();
			}
			else
			{
				Singleton<EffectSystem>.Instance.StopEffectById(this.InstructionEffect.GetValueOrDefault(), "[LevelAimLineController.StopEffect]", true, null);
				this.InstructionEffect = null;
			}
			this.ClearTagOrMat();
			return true;
		}

		// Token: 0x060450B5 RID: 282805 RVA: 0x011FB0D4 File Offset: 0x011F92D4
		public bool UpdatePoints(List<Vector> points, EAimLineType type)
		{
			if (points == null || points.Count <= 0)
			{
				return false;
			}
			Vector vector = points[0];
			Vector vector2 = Vector.Create();
			this.Actor.D_K2_SetActorLocation(vector.ToUeVector(false), false, ref WorldGlobal.SweepHitResult, true);
			TArray<FSplinePoint> tarray = new TArray<FSplinePoint>();
			ESplinePointType value;
			if (type == EAimLineType.Line)
			{
				value = ESplinePointType.Linear;
			}
			else
			{
				value = ESplinePointType.Curve;
			}
			for (int i = 0; i < points.Count; i++)
			{
				points[i].Subtraction(vector, vector2);
				FSplinePoint value2 = new FSplinePoint((float)i, vector2.ToUeVectorOld(), points[(i == 0) ? i : (i - 1)].ToUeVectorOld(), points[(i == points.Count - 1) ? i : (i + 1)].ToUeVectorOld(), Rotator.ZeroRotator, Vector.OneVector, value);
				tarray.Add(value2);
			}
			this.SplineComp.ClearSplinePoints(true);
			this.SplineComp.AddPoints(tarray, true);
			this.SplineComp.UpdateSpline();
			this.Actor.UpdateMesh();
			if (Singleton<Time>.Instance.WorldTime - this.LastTraceTime > 1000.0)
			{
				this.LastTraceTime = Singleton<Time>.Instance.WorldTime;
				this.CheckCollision();
			}
			return true;
		}

		// Token: 0x060450B6 RID: 282806 RVA: 0x011FB210 File Offset: 0x011F9410
		[NullableContext(2)]
		private void BeginOverlap(AActor overlappedActor, AActor otherActor)
		{
			if (otherActor.Tags.Contains(this.sightingTag))
			{
				if (!this.NeedModifyMatActors.Contains(otherActor))
				{
					this.NeedModifyMatActors.Add(otherActor);
				}
				return;
			}
			EntityHandle entityByActor = ModelBase<SceneInteractionModel>.Instance.GetEntityByActor(otherActor, false);
			if (entityByActor != null)
			{
				SceneItemHitComponent component = entityByActor.Entity.GetComponent<SceneItemHitComponent>();
				if (component != null && component.Valid && !this.NeedAddTagEntities.Contains(entityByActor))
				{
					this.NeedAddTagEntities.Add(entityByActor);
				}
			}
		}

		// Token: 0x060450B7 RID: 282807 RVA: 0x011FB290 File Offset: 0x011F9490
		private void CheckCollision()
		{
			this.BulletActor.D_K2_SetActorLocation(this.Actor.D_K2_GetActorLocation(), true, ref WorldGlobal.SweepHitResult, false);
			float num = this.SplineComp.GetSplineLength() / (this.Actor.SamplingNum - 1f);
			int num2 = 0;
			while ((float)num2 < this.Actor.SamplingNum)
			{
				FVectorDouble newLocation = this.SplineComp.D_GetLocationAtDistanceAlongSpline((float)(num2 + 1) * num, ESplineCoordinateSpace.World);
				this.BulletActor.D_K2_SetActorLocation(newLocation, true, ref WorldGlobal.SweepHitResult, false);
				num2++;
			}
			List<AActor> list = new List<AActor>();
			foreach (AActor item in this.ModifyMatActors)
			{
				if (!this.NeedModifyMatActors.Contains(item))
				{
					list.Add(item);
				}
			}
			foreach (AActor key in list)
			{
				int handle;
				if (this.ActorMatDataHandleMap.TryGetValue(key, out handle))
				{
					Singleton<ItemMaterialManager>.Instance.DisableActorData(handle);
					this.ActorMatDataHandleMap.Remove(key);
				}
			}
			List<AActor> list2 = new List<AActor>();
			foreach (AActor item2 in this.NeedModifyMatActors)
			{
				if (!this.ModifyMatActors.Contains(item2))
				{
					list2.Add(item2);
				}
			}
			foreach (AActor aactor in list2)
			{
				int value = Singleton<ItemMaterialManager>.Instance.AddMaterialData(aactor, this.MatData);
				this.ActorMatDataHandleMap[aactor] = value;
			}
			this.ModifyMatActors = this.NeedModifyMatActors;
			this.NeedModifyMatActors = new List<AActor>();
			List<EntityHandle> list3 = new List<EntityHandle>();
			foreach (EntityHandle item3 in this.AddTagEntities)
			{
				if (!this.NeedAddTagEntities.Contains(item3))
				{
					list3.Add(item3);
				}
			}
			foreach (EntityHandle entityHandle in list3)
			{
				if (entityHandle != null && entityHandle.Valid)
				{
					entityHandle.Entity.GetComponent<SceneItemPropertyComponent>().SetIsBeingTargeted(false);
				}
			}
			List<EntityHandle> list4 = new List<EntityHandle>();
			foreach (EntityHandle item4 in this.NeedAddTagEntities)
			{
				if (!this.AddTagEntities.Contains(item4))
				{
					list4.Add(item4);
				}
			}
			foreach (EntityHandle entityHandle2 in list4)
			{
				if (entityHandle2 != null && entityHandle2.Valid)
				{
					entityHandle2.Entity.GetComponent<SceneItemPropertyComponent>().SetIsBeingTargeted(true);
				}
			}
			this.AddTagEntities = this.NeedAddTagEntities;
			this.NeedAddTagEntities = new List<EntityHandle>();
		}

		// Token: 0x060450B8 RID: 282808 RVA: 0x011FB628 File Offset: 0x011F9828
		private void ClearTagOrMat()
		{
			foreach (EntityHandle entityHandle in this.AddTagEntities)
			{
				if (entityHandle != null && entityHandle.Valid)
				{
					entityHandle.Entity.GetComponent<SceneItemPropertyComponent>().SetIsBeingTargeted(false);
				}
			}
			foreach (AActor key in this.ModifyMatActors)
			{
				int handle;
				if (this.ActorMatDataHandleMap.TryGetValue(key, out handle))
				{
					Singleton<ItemMaterialManager>.Instance.DisableActorData(handle);
					this.ActorMatDataHandleMap.Remove(key);
				}
			}
		}

		// Token: 0x060450B9 RID: 282809 RVA: 0x011FB6F8 File Offset: 0x011F98F8
		private void OnWorldDone()
		{
			if (this.Actor == null || !this.Actor.IsValid())
			{
				this.Actor = (Singleton<ActorSystem>.Instance.Get(BP_Miaozhunxian_C.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true) as BP_Miaozhunxian_C);
				this.SplineComp = (this.Actor.GetComponentByClass(USplineComponent.StaticClass()) as USplineComponent);
				this.Actor.Init();
			}
			if (this.BulletActor == null || !this.BulletActor.IsValid())
			{
				this.BulletActor = (Singleton<ActorSystem>.Instance.Get(BP_Miaozhunxian_Bullet_C.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true) as BP_Miaozhunxian_Bullet_C);
				this.BulletActor.OnActorBeginOverlap.Add(new Action<AActor, AActor>(this.BeginOverlap));
			}
		}

		// Token: 0x04026848 RID: 157768
		private const int UPDATE_MESH_INTERVAL = 1000;

		// Token: 0x04026849 RID: 157769
		private const string DATA_PATH = "/Game/Aki/Effect/MaterialController/ItemMaterial/DA_Fx_ActorItem_Scanning.DA_Fx_ActorItem_Scanning";

		// Token: 0x0402684A RID: 157770
		private readonly FName sightingTag = new FName("Manipulate_Targeted");

		// Token: 0x0402684B RID: 157771
		[Nullable(2)]
		private BP_Miaozhunxian_C Actor;

		// Token: 0x0402684C RID: 157772
		[Nullable(2)]
		private USplineComponent SplineComp;

		// Token: 0x0402684D RID: 157773
		private int? InstructionEffect;

		// Token: 0x0402684E RID: 157774
		private bool IsPlaying;

		// Token: 0x0402684F RID: 157775
		private bool IsShowMesh;

		// Token: 0x04026850 RID: 157776
		private double LastTraceTime;

		// Token: 0x04026851 RID: 157777
		[Nullable(2)]
		private BP_Miaozhunxian_Bullet_C BulletActor;

		// Token: 0x04026852 RID: 157778
		private List<AActor> ModifyMatActors = new List<AActor>();

		// Token: 0x04026853 RID: 157779
		private List<AActor> NeedModifyMatActors = new List<AActor>();

		// Token: 0x04026854 RID: 157780
		private readonly Dictionary<AActor, int> ActorMatDataHandleMap = new Dictionary<AActor, int>();

		// Token: 0x04026855 RID: 157781
		private List<EntityHandle> AddTagEntities = new List<EntityHandle>();

		// Token: 0x04026856 RID: 157782
		private List<EntityHandle> NeedAddTagEntities = new List<EntityHandle>();

		// Token: 0x04026857 RID: 157783
		[Nullable(2)]
		private ItemMaterialControllerActorData MatData;
	}
}
