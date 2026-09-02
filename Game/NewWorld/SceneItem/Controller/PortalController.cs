using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.GamePlay.Portal;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.Portal;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using CSharpScript.Game.NewWorld.SceneItem.Model;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.Controller
{
	// Token: 0x02004876 RID: 18550
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class PortalController : ControllerBase<PortalController>
	{
		// Token: 0x06030446 RID: 197702 RVA: 0x00BBE8C4 File Offset: 0x00BBCAC4
		public unsafe void RegisterPair(long entityId, PortalController.PortalPairParams paramsObj, bool isDynamic = false, bool isAddToCache = true)
		{
			if (ModelBase<PortalModel>.Instance.GetPortal(entityId) != null)
			{
				return;
			}
			if (isDynamic && this.HasDynamicPortal)
			{
				return;
			}
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(entityId);
			SceneItemPortalComponent sceneItemPortalComponent;
			if (entity == null)
			{
				sceneItemPortalComponent = null;
			}
			else
			{
				WorldEntity entity2 = entity.Entity;
				sceneItemPortalComponent = ((entity2 != null) ? entity2.GetComponent<SceneItemPortalComponent>() : null);
			}
			SceneItemPortalComponent sceneItemPortalComponent2 = sceneItemPortalComponent;
			EntityHandle entity3 = ModelBase<CreatureModel>.Instance.GetEntity((sceneItemPortalComponent2 != null) ? sceneItemPortalComponent2.GetPairCreatureDataId() : 0L);
			SceneItemPortalComponent sceneItemPortalComponent3;
			if (entity3 == null)
			{
				sceneItemPortalComponent3 = null;
			}
			else
			{
				WorldEntity entity4 = entity3.Entity;
				sceneItemPortalComponent3 = ((entity4 != null) ? entity4.GetComponent<SceneItemPortalComponent>() : null);
			}
			SceneItemPortalComponent sceneItemPortalComponent4 = sceneItemPortalComponent3;
			if (sceneItemPortalComponent2 == null || sceneItemPortalComponent4 == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "传送门: RegisterPair出错，PortalComp找不到";
				<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", entityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("IsDynamic", isDynamic);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("IsAddToCache", isAddToCache);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("APortalComp Valid", sceneItemPortalComponent2 != null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("BPortalComp Valid", sceneItemPortalComponent4 != null);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
				return;
			}
			if (!this.HasDynamicPortal)
			{
				long? currentActivatedPortalId = this.CurrentActivatedPortalId;
				if (currentActivatedPortalId != null && currentActivatedPortalId.GetValueOrDefault() != 0L)
				{
					this.UnRegisterPair(this.CurrentActivatedPortalId.Value, false, false, false);
				}
			}
			if (!isDynamic && isAddToCache)
			{
				this.StaticPortalPairsCache[entityId] = paramsObj;
				this.StaticPortalPairsStack.Delete(entityId);
				this.StaticPortalPairsStack.Push(entityId);
			}
			if (!isDynamic && this.HasDynamicPortal)
			{
				return;
			}
			if (isDynamic)
			{
				this.HasDynamicPortal = true;
			}
			this.CurrentActivatedPortalId = new long?(entityId);
			FTransformDouble ftransformDouble = new FTransformDouble();
			FVectorDouble location = paramsObj.Trans.GetLocation();
			ftransformDouble.SetLocation(location);
			BP_Portal_C bpPortalActor = ModelBase<PortalModel>.Instance.GetBpPortalActor();
			bpPortalActor.D_K2_SetActorLocation(ftransformDouble.GetLocation(), false, ref WorldGlobal.SweepHitResult, true);
			bpPortalActor.SetPortal1Transform(paramsObj.Trans, paramsObj.Owner.D_GetTransform());
			bpPortalActor.SetPortal2Transform(paramsObj.PairTrans, paramsObj.PairOwner.D_GetTransform());
			bpPortalActor.SetPortal1Bounds(paramsObj.PortalBounds.ToUeVectorOld());
			bpPortalActor.SetPortal2Bounds(paramsObj.PairPortalBounds.ToUeVectorOld());
			TArray<AActor> tarray = new TArray<AActor>();
			TArray<AActor> tarray2 = sceneItemPortalComponent4.GetPairCaptureForceShowActors() ?? tarray;
			TArray<AActor> tarray3 = sceneItemPortalComponent2.GetPairCaptureForceShowActors() ?? tarray;
			TArray<AActor> tarray4 = sceneItemPortalComponent4.GetPairCaptureIgnoredActors() ?? tarray;
			TArray<AActor> tarray5 = sceneItemPortalComponent2.GetPairCaptureIgnoredActors() ?? tarray;
			bpPortalActor.SetCaptureShowingActors(true, ref tarray4, ref tarray2);
			bpPortalActor.SetCaptureShowingActors(false, ref tarray5, ref tarray3);
			bpPortalActor.SetCaptureMaxViewDistance(true, sceneItemPortalComponent4.GetPairCaptureMaxViewDistance());
			bpPortalActor.SetCaptureMaxViewDistance(false, sceneItemPortalComponent2.GetPairCaptureMaxViewDistance());
			bpPortalActor.SetCaptureShowFlags(true, sceneItemPortalComponent4.GetPairCaptureShowFlags() ?? new TMap<string, bool>());
			bpPortalActor.SetCaptureShowFlags(false, sceneItemPortalComponent2.GetPairCaptureShowFlags() ?? new TMap<string, bool>());
			bpPortalActor.EnablePortal1Rendering();
			bpPortalActor.EnablePortal2Rendering();
			BP_KuroPortalCapture_C portalCapture = sceneItemPortalComponent2.PortalCapture;
			if (portalCapture != null)
			{
				portalCapture.SetPair(sceneItemPortalComponent4.PortalCapture);
			}
			BP_KuroPortalCapture_C portalCapture2 = sceneItemPortalComponent4.PortalCapture;
			if (portalCapture2 != null)
			{
				portalCapture2.SetPair(sceneItemPortalComponent2.PortalCapture);
			}
			ModelBase<PortalModel>.Instance.AddPortalPair(entityId, bpPortalActor);
			sceneItemPortalComponent2.AfterRegisterPair();
			sceneItemPortalComponent4.AfterRegisterPair();
			if (ModelBase<SundryModel>.Instance.GetModuleDebugLevel("Portal") > 0)
			{
				bpPortalActor.EnableDebugCamera1 = true;
				bpPortalActor.EnableDebugCamera2 = true;
			}
		}

		// Token: 0x06030447 RID: 197703 RVA: 0x00BBEC28 File Offset: 0x00BBCE28
		public void UnRegisterPair(long entityId, bool isDynamic = false, bool isRemoveFromCache = true, bool registerNewFromCache = false)
		{
			BP_Portal_C portal = ModelBase<PortalModel>.Instance.GetPortal(entityId);
			if (portal == null)
			{
				return;
			}
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(entityId);
			SceneItemPortalComponent sceneItemPortalComponent;
			if (entity == null)
			{
				sceneItemPortalComponent = null;
			}
			else
			{
				WorldEntity entity2 = entity.Entity;
				sceneItemPortalComponent = ((entity2 != null) ? entity2.GetComponent<SceneItemPortalComponent>() : null);
			}
			SceneItemPortalComponent sceneItemPortalComponent2 = sceneItemPortalComponent;
			EntityHandle entity3 = ModelBase<CreatureModel>.Instance.GetEntity((sceneItemPortalComponent2 != null) ? sceneItemPortalComponent2.GetPairCreatureDataId() : 0L);
			object obj;
			if (entity3 == null)
			{
				obj = null;
			}
			else
			{
				WorldEntity entity4 = entity3.Entity;
				obj = ((entity4 != null) ? entity4.GetComponent<SceneItemPortalComponent>() : null);
			}
			portal.DisablePortal1Rendering();
			portal.DisablePortal2Rendering();
			TArray<AActor> tarray = new TArray<AActor>();
			portal.SetCaptureShowingActors(true, ref tarray, ref tarray);
			portal.SetCaptureShowingActors(false, ref tarray, ref tarray);
			portal.SetCaptureMaxViewDistance(true, 0f);
			portal.SetCaptureMaxViewDistance(false, 0f);
			ModelBase<PortalModel>.Instance.RemovePortalPair(entityId);
			if (sceneItemPortalComponent2 != null)
			{
				BP_KuroPortalCapture_C portalCapture = sceneItemPortalComponent2.PortalCapture;
				if (portalCapture != null)
				{
					portalCapture.SetPair(null);
				}
			}
			object obj2 = obj;
			if (obj2 != null)
			{
				BP_KuroPortalCapture_C portalCapture2 = obj2.PortalCapture;
				if (portalCapture2 != null)
				{
					portalCapture2.SetPair(null);
				}
			}
			if (sceneItemPortalComponent2 != null)
			{
				sceneItemPortalComponent2.AfterUnRegisterPair();
			}
			if (obj2 != null)
			{
				obj2.AfterUnRegisterPair();
			}
			if (isDynamic)
			{
				this.HasDynamicPortal = false;
			}
			this.CurrentActivatedPortalId = null;
			if (isRemoveFromCache && !isDynamic)
			{
				this.StaticPortalPairsCache.Remove(entityId);
				this.StaticPortalPairsStack.Delete(entityId);
			}
			if (registerNewFromCache)
			{
				long num = this.StaticPortalPairsStack.Peek();
				if (num == 0L)
				{
					return;
				}
				PortalController.PortalPairParams paramsObj;
				if (!this.StaticPortalPairsCache.TryGetValue(num, out paramsObj))
				{
					return;
				}
				this.RegisterPair(num, paramsObj, false, false);
			}
		}

		// Token: 0x06030448 RID: 197704 RVA: 0x00BBED8C File Offset: 0x00BBCF8C
		public void RegisterDynamicPortals()
		{
			if (this.DynamicCreatureDataIds.Count >= 2)
			{
				long? num = this.DynamicCreatureDataIds[0];
				if (num != null && num.GetValueOrDefault() != 0L)
				{
					num = this.DynamicCreatureDataIds[1];
					if (num != null && num.GetValueOrDefault() != 0L)
					{
						if (this.HasDynamicPortal)
						{
							num = this.CurrentActivatedPortalId;
							if (num != null && num.GetValueOrDefault() != 0L)
							{
								EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(this.CurrentActivatedPortalId.Value);
								SceneItemPortalComponent sceneItemPortalComponent;
								if (entity == null)
								{
									sceneItemPortalComponent = null;
								}
								else
								{
									WorldEntity entity2 = entity.Entity;
									sceneItemPortalComponent = ((entity2 != null) ? entity2.GetComponent<SceneItemPortalComponent>() : null);
								}
								SceneItemPortalComponent sceneItemPortalComponent2 = sceneItemPortalComponent;
								num = this.CurrentActivatedPortalId;
								long? num2 = this.DynamicCreatureDataIds[0];
								if (num.GetValueOrDefault() == num2.GetValueOrDefault() & num != null == (num2 != null))
								{
									num2 = ((sceneItemPortalComponent2 != null) ? new long?(sceneItemPortalComponent2.GetPairCreatureDataId()) : null);
									num = this.DynamicCreatureDataIds[1];
									if (num2.GetValueOrDefault() == num.GetValueOrDefault() & num2 != null == (num != null))
									{
										return;
									}
								}
								this.UnRegisterDynamicPortals(false);
							}
						}
						EntityHandle entity3 = ModelBase<CreatureModel>.Instance.GetEntity(this.DynamicCreatureDataIds[0].Value);
						WorldEntity worldEntity = (entity3 != null) ? entity3.Entity : null;
						SceneItemPortalComponent sceneItemPortalComponent3 = (worldEntity != null) ? worldEntity.GetComponent<SceneItemPortalComponent>() : null;
						EntityHandle entity4 = ModelBase<CreatureModel>.Instance.GetEntity(this.DynamicCreatureDataIds[1].Value);
						WorldEntity worldEntity2 = (entity4 != null) ? entity4.Entity : null;
						SceneItemPortalComponent sceneItemPortalComponent4 = (worldEntity2 != null) ? worldEntity2.GetComponent<SceneItemPortalComponent>() : null;
						if (sceneItemPortalComponent3 != null && sceneItemPortalComponent3.CanRegisterPortal() && sceneItemPortalComponent4 != null && sceneItemPortalComponent4.CanRegisterPortal())
						{
							PortalController.PortalPairParams paramsObj = new PortalController.PortalPairParams(sceneItemPortalComponent3.PortalCapture.Plane.D_K2_GetComponentToWorld(), sceneItemPortalComponent4.PortalCapture.Plane.D_K2_GetComponentToWorld(), worldEntity.GetComponent<BaseActorComponent>().Owner, worldEntity2.GetComponent<BaseActorComponent>().Owner, sceneItemPortalComponent3.PortalBounds, sceneItemPortalComponent4.PortalBounds);
							sceneItemPortalComponent3.SetPairCreatureDataId(this.DynamicCreatureDataIds[1].Value);
							sceneItemPortalComponent4.SetPairCreatureDataId(this.DynamicCreatureDataIds[0].Value);
							this.RegisterPair(this.DynamicCreatureDataIds[0].Value, paramsObj, true, false);
						}
					}
				}
			}
		}

		// Token: 0x06030449 RID: 197705 RVA: 0x00BBF010 File Offset: 0x00BBD210
		public void UnRegisterDynamicPortals(bool registerNewFromCache = false)
		{
			if (this.HasDynamicPortal)
			{
				long? currentActivatedPortalId = this.CurrentActivatedPortalId;
				if (currentActivatedPortalId != null && currentActivatedPortalId.GetValueOrDefault() != 0L)
				{
					long value = this.CurrentActivatedPortalId.Value;
					EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(value);
					SceneItemPortalComponent sceneItemPortalComponent;
					if (entity == null)
					{
						sceneItemPortalComponent = null;
					}
					else
					{
						WorldEntity entity2 = entity.Entity;
						sceneItemPortalComponent = ((entity2 != null) ? entity2.GetComponent<SceneItemPortalComponent>() : null);
					}
					SceneItemPortalComponent sceneItemPortalComponent2 = sceneItemPortalComponent;
					EntityHandle entity3 = ModelBase<CreatureModel>.Instance.GetEntity((sceneItemPortalComponent2 != null) ? sceneItemPortalComponent2.GetPairCreatureDataId() : 0L);
					object obj;
					if (entity3 == null)
					{
						obj = null;
					}
					else
					{
						WorldEntity entity4 = entity3.Entity;
						obj = ((entity4 != null) ? entity4.GetComponent<SceneItemPortalComponent>() : null);
					}
					this.UnRegisterPair(value, true, false, registerNewFromCache);
					if (sceneItemPortalComponent2 != null)
					{
						sceneItemPortalComponent2.SetPairCreatureDataId(0L);
					}
					object obj2 = obj;
					if (obj2 == null)
					{
						return;
					}
					obj2.SetPairCreatureDataId(0L);
				}
			}
		}

		// Token: 0x0603044A RID: 197706 RVA: 0x00BBF0C8 File Offset: 0x00BBD2C8
		[return: Nullable(2)]
		public SceneItemPortalComponent GetPairDynamicPortal(SceneItemPortalComponent portal)
		{
			long creatureDataId = portal.GetCreatureDataId();
			EPortalModel portalModel = portal.GetPortalModel();
			if (portalModel != EPortalModel.A)
			{
				if (portalModel == EPortalModel.B)
				{
					bool flag;
					if (this.DynamicCreatureDataIds.Count >= 2)
					{
						long? num = this.DynamicCreatureDataIds[1];
						long num2 = creatureDataId;
						flag = !(num.GetValueOrDefault() == num2 & num != null);
					}
					else
					{
						flag = true;
					}
					bool flag2 = flag;
					if (!flag2)
					{
						bool flag3 = (this.DynamicCreatureDataIds[0] ?? 0L) == 0L;
						flag2 = flag3;
					}
					if (!flag2)
					{
						EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(this.DynamicCreatureDataIds[0].Value);
						if (entity == null)
						{
							return null;
						}
						WorldEntity entity2 = entity.Entity;
						if (entity2 == null)
						{
							return null;
						}
						return entity2.GetComponent<SceneItemPortalComponent>();
					}
				}
			}
			else
			{
				bool flag4;
				if (this.DynamicCreatureDataIds.Count >= 2)
				{
					long? num = this.DynamicCreatureDataIds[0];
					long num2 = creatureDataId;
					flag4 = !(num.GetValueOrDefault() == num2 & num != null);
				}
				else
				{
					flag4 = true;
				}
				bool flag2 = flag4;
				if (!flag2)
				{
					bool flag3 = (this.DynamicCreatureDataIds[1] ?? 0L) == 0L;
					flag2 = flag3;
				}
				if (!flag2)
				{
					EntityHandle entity3 = ModelBase<CreatureModel>.Instance.GetEntity(this.DynamicCreatureDataIds[1].Value);
					if (entity3 == null)
					{
						return null;
					}
					WorldEntity entity4 = entity3.Entity;
					if (entity4 == null)
					{
						return null;
					}
					return entity4.GetComponent<SceneItemPortalComponent>();
				}
			}
			return null;
		}

		// Token: 0x0603044B RID: 197707 RVA: 0x00BBF230 File Offset: 0x00BBD430
		public void AfterGenerateDynamicPortal(SceneItemPortalComponent portal)
		{
			long creatureDataId = portal.GetCreatureDataId();
			EPortalModel portalModel = portal.GetPortalModel();
			if (portalModel != EPortalModel.A)
			{
				if (portalModel != EPortalModel.B)
				{
					return;
				}
				if (this.DynamicCreatureDataIds.Count > 1)
				{
					long? num = this.DynamicCreatureDataIds[1];
					long num2 = creatureDataId;
					if (num.GetValueOrDefault() == num2 & num != null)
					{
						return;
					}
				}
				while (this.DynamicCreatureDataIds.Count < 2)
				{
					this.DynamicCreatureDataIds.Add(null);
				}
				this.DynamicCreatureDataIds[1] = new long?(creatureDataId);
			}
			else
			{
				if (this.DynamicCreatureDataIds.Count > 0)
				{
					long? num = this.DynamicCreatureDataIds[0];
					long num2 = creatureDataId;
					if (num.GetValueOrDefault() == num2 & num != null)
					{
						return;
					}
				}
				if (this.DynamicCreatureDataIds.Count == 0)
				{
					this.DynamicCreatureDataIds.Add(new long?(creatureDataId));
					return;
				}
				this.DynamicCreatureDataIds[0] = new long?(creatureDataId);
				return;
			}
		}

		// Token: 0x0603044C RID: 197708 RVA: 0x00BBF320 File Offset: 0x00BBD520
		public void AfterDeleteDynamicPortal(SceneItemPortalComponent portal)
		{
			long creatureDataId = portal.GetCreatureDataId();
			if (this.DynamicCreatureDataIds.Count > 0)
			{
				long? num = this.DynamicCreatureDataIds[0];
				long num2 = creatureDataId;
				if (num.GetValueOrDefault() == num2 & num != null)
				{
					this.DynamicCreatureDataIds[0] = null;
					return;
				}
			}
			if (this.DynamicCreatureDataIds.Count > 1)
			{
				long? num = this.DynamicCreatureDataIds[1];
				long num2 = creatureDataId;
				if (num.GetValueOrDefault() == num2 & num != null)
				{
					this.DynamicCreatureDataIds[1] = null;
				}
			}
		}

		// Token: 0x0603044D RID: 197709 RVA: 0x00BBF3C1 File Offset: 0x00BBD5C1
		protected override bool OnInit()
		{
			Singleton<EventSystem>.Instance.Add<string, int>(EEventName.OnChangeModuleDebugLevel, new Action<string, int>(this.OnChangeModuleDebugLevel));
			return true;
		}

		// Token: 0x0603044E RID: 197710 RVA: 0x00BBF3E0 File Offset: 0x00BBD5E0
		protected override bool OnClear()
		{
			Singleton<EventSystem>.Instance.Remove<string, int>(EEventName.OnChangeModuleDebugLevel, new Action<string, int>(this.OnChangeModuleDebugLevel));
			this.StaticPortalPairsCache.Clear();
			this.StaticPortalPairsStack.Clear();
			this.DynamicCreatureDataIds.Clear();
			this.CurrentActivatedPortalId = new long?(0L);
			this.HasDynamicPortal = false;
			return true;
		}

		// Token: 0x0603044F RID: 197711 RVA: 0x00BBF440 File Offset: 0x00BBD640
		public void OnChangeModuleDebugLevel(string key, int level)
		{
			if (key != "Portal")
			{
				return;
			}
			foreach (BP_Portal_C bp_Portal_C in ModelBase<PortalModel>.Instance.GetPortals().Values)
			{
				bp_Portal_C.EnableDebugCamera1 = (level > 0);
				bp_Portal_C.EnableDebugCamera2 = (level > 0);
			}
		}

		// Token: 0x0401BB82 RID: 113538
		private const string PORTAL_DEBUG_KEY = "Portal";

		// Token: 0x0401BB83 RID: 113539
		private readonly List<long?> DynamicCreatureDataIds = new List<long?>();

		// Token: 0x0401BB84 RID: 113540
		private readonly Dictionary<long, PortalController.PortalPairParams> StaticPortalPairsCache = new Dictionary<long, PortalController.PortalPairParams>();

		// Token: 0x0401BB85 RID: 113541
		private readonly global::Stack<long> StaticPortalPairsStack = new global::Stack<long>();

		// Token: 0x0401BB86 RID: 113542
		private long? CurrentActivatedPortalId;

		// Token: 0x0401BB87 RID: 113543
		private bool HasDynamicPortal;

		// Token: 0x0200A947 RID: 43335
		[Nullable(0)]
		public class PortalPairParams
		{
			// Token: 0x0604B142 RID: 307522 RVA: 0x0146FFF8 File Offset: 0x0146E1F8
			public PortalPairParams(FTransformDouble trans, FTransformDouble pairTrans, AActor owner, AActor pairOwner, Vector portalBounds, Vector pairPortalBounds)
			{
			}

			// Token: 0x04034724 RID: 214820
			[Nullable(2)]
			public BP_KuroPortalCapture_C ACapture;

			// Token: 0x04034725 RID: 214821
			[Nullable(2)]
			public BP_KuroPortalCapture_C BCapture;

			// Token: 0x04034726 RID: 214822
			public readonly FTransformDouble Trans = trans;

			// Token: 0x04034727 RID: 214823
			public FTransformDouble PairTrans = pairTrans;

			// Token: 0x04034728 RID: 214824
			public AActor Owner = owner;

			// Token: 0x04034729 RID: 214825
			public AActor PairOwner = pairOwner;

			// Token: 0x0403472A RID: 214826
			public Vector PortalBounds = portalBounds;

			// Token: 0x0403472B RID: 214827
			public Vector PairPortalBounds = pairPortalBounds;
		}
	}
}
