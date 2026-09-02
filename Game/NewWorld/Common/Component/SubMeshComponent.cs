using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Game.Effect;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Common.Component
{
	// Token: 0x020048CD RID: 18637
	[NullableContext(1)]
	[Nullable(0)]
	public class SubMeshComponent : EntityComponent
	{
		// Token: 0x060309F7 RID: 199159 RVA: 0x00BF7EA4 File Offset: 0x00BF60A4
		protected override bool OnStart()
		{
			this.ActorComp = base.Entity.GetComponent<BaseActorComponent>();
			this.CharActorComp = base.Entity.GetComponent<CharacterActorComponent>();
			CharacterActorComponent charActorComp = this.CharActorComp;
			this.CharRenderComp = ((charActorComp != null) ? charActorComp.Actor.CharRenderingComponent : null);
			return true;
		}

		// Token: 0x060309F8 RID: 199160 RVA: 0x00BF7EF1 File Offset: 0x00BF60F1
		protected override bool OnClear()
		{
			this.HideMeshMap.Clear();
			this.HideMeshChildActors.Clear();
			return true;
		}

		// Token: 0x060309F9 RID: 199161 RVA: 0x00BF7F0C File Offset: 0x00BF610C
		protected override void OnActivate()
		{
			if (this.ActorComp == null)
			{
				return;
			}
			TArray<UActorComponent> tarray = this.ActorComp.Owner.K2_GetComponentsByClass(USkeletalMeshComponent.StaticClass());
			for (int i = tarray.Num() - 1; i >= 0; i--)
			{
				UActorComponent uactorComponent = tarray.Get(i);
				string name = uactorComponent.GetName();
				if (!SubMeshComponent.standardMeshNames.Contains(name))
				{
					this.SubMeshMap[name] = new SubMeshComponent.SubMeshItem(name, uactorComponent as USkeletalMeshComponent);
				}
			}
		}

		// Token: 0x060309FA RID: 199162 RVA: 0x00BF7F84 File Offset: 0x00BF6184
		protected override void OnAfterTick(float delta)
		{
			this.DealSubMeshOrder(true);
		}

		// Token: 0x060309FB RID: 199163 RVA: 0x00BF7F8D File Offset: 0x00BF618D
		protected override void OnEnable()
		{
			this.DealSubMeshOrder(false);
		}

		// Token: 0x060309FC RID: 199164 RVA: 0x00BF7F98 File Offset: 0x00BF6198
		private void DealSubMeshOrder(bool allowEffect = true)
		{
			foreach (KeyValuePair<string, SubMeshComponent.SubMeshOrder> keyValuePair in this.SubMeshOrderMap)
			{
				this.SetSubMeshVisible(keyValuePair.Key, keyValuePair.Value, allowEffect);
			}
			this.SubMeshOrderMap.Clear();
		}

		// Token: 0x060309FD RID: 199165 RVA: 0x00BF8004 File Offset: 0x00BF6204
		protected void SetSubMeshVisible(string meshName, SubMeshComponent.SubMeshOrder order, bool allowEffect = true)
		{
			SubMeshComponent.SubMeshItem subMeshItem;
			if (!this.SubMeshMap.TryGetValue(meshName, out subMeshItem))
			{
				return;
			}
			if (subMeshItem.IsFrozen)
			{
				subMeshItem.Unfreeze();
			}
			if (subMeshItem.Visible == order.Visible)
			{
				return;
			}
			this.ApplySubMeshMaterialAndEffect(subMeshItem, order, allowEffect);
			subMeshItem.SetVisible(order.Visible, order.DelayTime);
		}

		// Token: 0x060309FE RID: 199166 RVA: 0x00BF805C File Offset: 0x00BF625C
		protected void ApplySubMeshMaterialAndEffect(SubMeshComponent.SubMeshItem subMeshItem, SubMeshComponent.SubMeshOrder order, bool allowEffect = true)
		{
			if (subMeshItem.CurrentPdHandle != 0)
			{
				CharRenderingComponent charRenderComp = this.CharRenderComp;
				if (charRenderComp != null)
				{
					charRenderComp.RemoveMaterialControllerData(subMeshItem.CurrentPdHandle);
				}
				subMeshItem.CurrentPdHandle = 0;
			}
			if (allowEffect && order.CharControllerData != null)
			{
				CharRenderingComponent charRenderComp2 = this.CharRenderComp;
				subMeshItem.CurrentPdHandle = ((charRenderComp2 != null) ? charRenderComp2.AddMaterialControllerData(order.CharControllerData) : 0);
			}
			if (subMeshItem.CurrentEffectHandle != 0)
			{
				Singleton<EffectSystem>.Instance.StopEffectById(subMeshItem.CurrentEffectHandle, "SubMesh", true, new bool?(true));
				subMeshItem.CurrentEffectHandle = 0;
			}
			if (allowEffect && order.EffectDataAssetRef != null)
			{
				string text = order.EffectDataAssetRef.ToAssetPathName();
				if (!string.IsNullOrEmpty(text))
				{
					CharacterActorComponent charActorComp = this.CharActorComp;
					string path = ((charActorComp != null) ? charActorComp.GetReplaceEffect(text) : null) ?? text;
					SkeletalMeshEffectContext skeletalMeshEffectContext = new SkeletalMeshEffectContext(new int?(base.Entity.Id), null, false);
					skeletalMeshEffectContext.SkeletalMeshComp = subMeshItem.Mesh;
					EffectSystem instance = Singleton<EffectSystem>.Instance;
					UObject mesh = subMeshItem.Mesh;
					FTransformDouble? ftransformDouble = new FTransformDouble?(new FTransformDouble());
					int num = instance.SpawnEffect(mesh, ftransformDouble, path, "SubMeshComponent", skeletalMeshEffectContext, EEffectType.Scene, null, null, null, false, false);
					if (num != 0 && Singleton<EffectSystem>.Instance.IsValid(num))
					{
						OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(num);
						subMeshItem.CurrentEffectHandle = num;
						effectActor.K2_AttachToComponent(subMeshItem.Mesh, new FName?(FNameUtil.NONE), EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, false);
						FTransformDouble ftransformDouble2 = new FTransformDouble();
						effectActor.D_K2_SetActorRelativeTransform(ftransformDouble2, false, ref WorldGlobal.SweepHitResult, true);
						Singleton<EffectSystem>.Instance.ForceCheckPendingInit(num);
					}
				}
			}
		}

		// Token: 0x060309FF RID: 199167 RVA: 0x00BF81D7 File Offset: 0x00BF63D7
		public void SetSubMeshOrder(string meshName, bool visible, [Nullable(2)] PD_CharacterControllerData_C charControllerData, [Nullable(new byte[]
		{
			2,
			1
		})] TSoftObjectPtr<UEffectModelBase> effectDataAssetRef, float delayTime)
		{
			this.SubMeshOrderMap[meshName] = new SubMeshComponent.SubMeshOrder(visible, charControllerData, effectDataAssetRef, delayTime);
		}

		// Token: 0x06030A00 RID: 199168 RVA: 0x00BF81F0 File Offset: 0x00BF63F0
		public void SetSubMeshAttach(string componentName, FName attachName, FTransform transform)
		{
			SubMeshComponent.SubMeshItem subMeshItem;
			if (this.SubMeshMap.TryGetValue(componentName, out subMeshItem))
			{
				subMeshItem.AttachToNewSocket(attachName, transform);
			}
		}

		// Token: 0x06030A01 RID: 199169 RVA: 0x00BF8218 File Offset: 0x00BF6418
		public void ResetSubMeshAttach(string componentName)
		{
			SubMeshComponent.SubMeshItem subMeshItem;
			if (this.SubMeshMap.TryGetValue(componentName, out subMeshItem))
			{
				subMeshItem.ResetAttach();
			}
		}

		// Token: 0x06030A02 RID: 199170 RVA: 0x00BF823C File Offset: 0x00BF643C
		public void FreezeSubMesh(string meshName)
		{
			SubMeshComponent.SubMeshItem subMeshItem;
			if (this.SubMeshMap.TryGetValue(meshName, out subMeshItem))
			{
				subMeshItem.FreezeToWorld(true);
			}
		}

		// Token: 0x06030A03 RID: 199171 RVA: 0x00BF8260 File Offset: 0x00BF6460
		public void FreezeSubMeshWithEffect(string meshName, bool visible, [Nullable(2)] PD_CharacterControllerData_C charControllerData, [Nullable(new byte[]
		{
			2,
			1
		})] TSoftObjectPtr<UEffectModelBase> effectDataAssetRef)
		{
			SubMeshComponent.SubMeshItem subMeshItem;
			if (!this.SubMeshMap.TryGetValue(meshName, out subMeshItem))
			{
				return;
			}
			subMeshItem.FreezeToWorld(visible);
			if (charControllerData != null || effectDataAssetRef != null)
			{
				this.ApplySubMeshMaterialAndEffect(subMeshItem, new SubMeshComponent.SubMeshOrder(visible, charControllerData, effectDataAssetRef, 0f), true);
			}
		}

		// Token: 0x06030A04 RID: 199172 RVA: 0x00BF82A8 File Offset: 0x00BF64A8
		public void PlaySubMeshEffectOnly(string meshName, bool visible, [Nullable(2)] PD_CharacterControllerData_C charControllerData, [Nullable(new byte[]
		{
			2,
			1
		})] TSoftObjectPtr<UEffectModelBase> effectDataAssetRef)
		{
			SubMeshComponent.SubMeshItem subMeshItem;
			if (!this.SubMeshMap.TryGetValue(meshName, out subMeshItem))
			{
				return;
			}
			if (charControllerData != null || effectDataAssetRef != null)
			{
				this.ApplySubMeshMaterialAndEffect(subMeshItem, new SubMeshComponent.SubMeshOrder(visible, charControllerData, effectDataAssetRef, 0f), true);
			}
			subMeshItem.SetVisible(visible, 0f);
		}

		// Token: 0x06030A05 RID: 199173 RVA: 0x00BF82F8 File Offset: 0x00BF64F8
		public void SnapshotSubMesh(string meshName)
		{
			SubMeshComponent.SubMeshItem subMeshItem;
			if (this.SubMeshMap.TryGetValue(meshName, out subMeshItem))
			{
				subMeshItem.TakeSnapshot();
			}
		}

		// Token: 0x06030A06 RID: 199174 RVA: 0x00BF831C File Offset: 0x00BF651C
		public void UnfreezeSubMesh(string meshName)
		{
			SubMeshComponent.SubMeshItem subMeshItem;
			if (this.SubMeshMap.TryGetValue(meshName, out subMeshItem))
			{
				subMeshItem.Unfreeze();
			}
		}

		// Token: 0x06030A07 RID: 199175 RVA: 0x00BF8340 File Offset: 0x00BF6540
		public void ShowSubMeshWithEffect(string meshName, bool visible, [Nullable(2)] PD_CharacterControllerData_C charControllerData, [Nullable(new byte[]
		{
			2,
			1
		})] TSoftObjectPtr<UEffectModelBase> effectDataAssetRef)
		{
			SubMeshComponent.SubMeshItem subMeshItem;
			if (!this.SubMeshMap.TryGetValue(meshName, out subMeshItem))
			{
				return;
			}
			if (subMeshItem.IsFrozen)
			{
				subMeshItem.Unfreeze();
			}
			if (charControllerData != null || effectDataAssetRef != null)
			{
				this.ApplySubMeshMaterialAndEffect(subMeshItem, new SubMeshComponent.SubMeshOrder(visible, charControllerData, effectDataAssetRef, 0f), true);
			}
			subMeshItem.SetVisible(visible, 0f);
		}

		// Token: 0x06030A08 RID: 199176 RVA: 0x00BF839C File Offset: 0x00BF659C
		public int SetHideMesh(UMeshComponent meshComp, bool visible, bool withChild, bool withChildActor, int inputKey = 0)
		{
			int num;
			if (inputKey != 0 && this.HideMeshMap.TryGetValue(meshComp, out num) && num != inputKey)
			{
				return num;
			}
			ValueTuple<bool, List<AActor>> valueTuple;
			if (this.HideMeshChildActors.TryGetValue(meshComp, out valueTuple))
			{
				foreach (AActor aactor in valueTuple.Item2)
				{
					aactor.SetActorHiddenInGame(!valueTuple.Item1);
				}
				this.HideMeshChildActors.Remove(meshComp);
			}
			int nextHideMeshKey = this.NextHideMeshKey;
			this.NextHideMeshKey = nextHideMeshKey + 1;
			int num2 = nextHideMeshKey;
			this.HideMeshMap[meshComp] = num2;
			meshComp.SetVisibility(visible, withChild);
			if (withChildActor)
			{
				bool flag = !visible;
				List<AActor> list = new List<AActor>();
				this.HideMeshChildActors[meshComp] = new ValueTuple<bool, List<AActor>>(flag, list);
				CharacterActorComponent component = base.Entity.GetComponent<CharacterActorComponent>();
				List<AActor> list2 = new List<AActor>();
				if (component != null && component.Actor.Mesh == meshComp)
				{
					TArray<AActor> tarray = new TArray<AActor>();
					component.Actor.GetAllChildActors(ref tarray, true);
					for (int i = tarray.Num() - 1; i >= 0; i--)
					{
						list2.Add(tarray.Get(i));
					}
				}
				else
				{
					TArray<USceneComponent> attachChildren = meshComp.AttachChildren;
					for (int j = attachChildren.Num() - 1; j >= 0; j--)
					{
						AActor owner = attachChildren.Get(j).GetOwner();
						if (owner != null)
						{
							list2.Add(owner);
						}
					}
				}
				foreach (AActor aactor2 in list2)
				{
					if (aactor2.bHidden != flag)
					{
						list.Add(aactor2);
						aactor2.SetActorHiddenInGame(flag);
					}
				}
			}
			return num2;
		}

		// Token: 0x06030A09 RID: 199177 RVA: 0x00BF857C File Offset: 0x00BF677C
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SubMeshComponent subMeshComponent = (SubMeshComponent)componentTemplate;
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (subMeshComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CharActorComp"))
			{
				if (subMeshComponent.CharActorComp == null)
				{
					this.CharActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.CharActorComp), "CharActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CharRenderComp"))
			{
				if (subMeshComponent.CharRenderComp == null)
				{
					this.CharRenderComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharRenderingComponent>(this.CharRenderComp), "CharRenderComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SubMeshMap"))
			{
				if (subMeshComponent.SubMeshMap == null)
				{
					this.SubMeshMap = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, SubMeshComponent.SubMeshItem>>(this.SubMeshMap), "SubMeshMap"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SubMeshOrderMap"))
			{
				if (subMeshComponent.SubMeshOrderMap == null)
				{
					this.SubMeshOrderMap = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, SubMeshComponent.SubMeshOrder>>(this.SubMeshOrderMap), "SubMeshOrderMap"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("NextHideMeshKey"))
			{
				this.NextHideMeshKey = subMeshComponent.NextHideMeshKey;
			}
			return (!base.CanResetComponentProperty("HideMeshMap") || subMeshComponent.HideMeshMap == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<UMeshComponent, int>>(this.HideMeshMap), "HideMeshMap")) && (!base.CanResetComponentProperty("HideMeshChildActors") || subMeshComponent.HideMeshChildActors == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<UMeshComponent, ValueTuple<bool, List<AActor>>>>(this.HideMeshChildActors), "HideMeshChildActors"));
		}

		// Token: 0x0401BF0C RID: 114444
		[StaticVariableRuleIgnore]
		private static readonly HashSet<string> standardMeshNames = new HashSet<string>
		{
			"Mesh",
			"Hulu",
			"OtherCase0",
			"WeaponCase0",
			"WeaponCase1"
		};

		// Token: 0x0401BF0D RID: 114445
		[Nullable(2)]
		protected BaseActorComponent ActorComp;

		// Token: 0x0401BF0E RID: 114446
		[Nullable(2)]
		protected CharacterActorComponent CharActorComp;

		// Token: 0x0401BF0F RID: 114447
		[Nullable(2)]
		protected CharRenderingComponent CharRenderComp;

		// Token: 0x0401BF10 RID: 114448
		protected Dictionary<string, SubMeshComponent.SubMeshItem> SubMeshMap = new Dictionary<string, SubMeshComponent.SubMeshItem>();

		// Token: 0x0401BF11 RID: 114449
		protected Dictionary<string, SubMeshComponent.SubMeshOrder> SubMeshOrderMap = new Dictionary<string, SubMeshComponent.SubMeshOrder>();

		// Token: 0x0401BF12 RID: 114450
		private int NextHideMeshKey = 1;

		// Token: 0x0401BF13 RID: 114451
		private readonly Dictionary<UMeshComponent, int> HideMeshMap = new Dictionary<UMeshComponent, int>();

		// Token: 0x0401BF14 RID: 114452
		[Nullable(new byte[]
		{
			1,
			1,
			0,
			1,
			1
		})]
		private readonly Dictionary<UMeshComponent, ValueTuple<bool, List<AActor>>> HideMeshChildActors = new Dictionary<UMeshComponent, ValueTuple<bool, List<AActor>>>();

		// Token: 0x0200A998 RID: 43416
		[Nullable(0)]
		public class SubMeshItem
		{
			// Token: 0x1700A92D RID: 43309
			// (get) Token: 0x0604B1D2 RID: 307666 RVA: 0x0147260E File Offset: 0x0147080E
			public bool Visible
			{
				get
				{
					return this.VisibleInternal;
				}
			}

			// Token: 0x0604B1D3 RID: 307667 RVA: 0x01472618 File Offset: 0x01470818
			public void SetVisible(bool v, float delay = 0f)
			{
				if (this.VisibleInternal == v)
				{
					return;
				}
				this.VisibleInternal = v;
				if (this.InvisibleTimer != null)
				{
					TimerSystem.Instance.Remove(this.InvisibleTimer);
					this.InvisibleTimer = null;
				}
				if (!this.VisibleInternal && delay > 0f)
				{
					this.InvisibleTimer = TimerSystem.Instance.Delay(new TTimerAction(this.DelayInvisible), delay, null, null, true, 1f);
					return;
				}
				this.Mesh.SetVisibility(v, false);
			}

			// Token: 0x0604B1D4 RID: 307668 RVA: 0x01472699 File Offset: 0x01470899
			private void DelayInvisible(float delta)
			{
				this.Mesh.SetVisibility(false, false);
				this.InvisibleTimer = null;
			}

			// Token: 0x1700A92E RID: 43310
			// (get) Token: 0x0604B1D5 RID: 307669 RVA: 0x014726AF File Offset: 0x014708AF
			public bool IsFrozen
			{
				get
				{
					return this.FrozenInternal;
				}
			}

			// Token: 0x0604B1D6 RID: 307670 RVA: 0x014726B8 File Offset: 0x014708B8
			public SubMeshItem(string name, USkeletalMeshComponent mesh)
			{
				this.Name = name;
				this.Mesh = mesh;
				this.VisibleInternal = mesh.bVisible;
				this.OriginAttachComp = mesh.GetAttachParent();
				this.OriginAttachSocketName = mesh.GetAttachSocketName();
				Transform originRelativeTransform = this.OriginRelativeTransform;
				FTransform relativeTransform = mesh.GetRelativeTransform();
				originRelativeTransform.FromUeTransform(relativeTransform);
			}

			// Token: 0x1700A92F RID: 43311
			// (get) Token: 0x0604B1D7 RID: 307671 RVA: 0x01472727 File Offset: 0x01470927
			public string Name { get; }

			// Token: 0x1700A930 RID: 43312
			// (get) Token: 0x0604B1D8 RID: 307672 RVA: 0x0147272F File Offset: 0x0147092F
			public USkeletalMeshComponent Mesh { get; }

			// Token: 0x0604B1D9 RID: 307673 RVA: 0x01472737 File Offset: 0x01470937
			public void AttachToNewSocket(FName attachName, FTransform transform)
			{
				this.Mesh.K2_AttachToComponent(this.OriginAttachComp, attachName, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, true, true);
				this.Mesh.K2_SetRelativeTransform(transform, false, ref WorldGlobal.SweepHitResult, true);
			}

			// Token: 0x0604B1DA RID: 307674 RVA: 0x01472768 File Offset: 0x01470968
			public void ResetAttach()
			{
				this.Mesh.K2_AttachToComponent(this.OriginAttachComp, this.OriginAttachSocketName, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, true, true);
				USceneComponent mesh = this.Mesh;
				FTransform ftransform = this.OriginRelativeTransform.ToUeTransformOld();
				mesh.K2_SetRelativeTransform(ftransform, false, ref WorldGlobal.SweepHitResult, true);
			}

			// Token: 0x0604B1DB RID: 307675 RVA: 0x014727B4 File Offset: 0x014709B4
			public void TakeSnapshot()
			{
				this.SnapshotWorldTransform = new FTransform?(this.Mesh.K2_GetComponentToWorld());
				UKuroAnimInstance ukuroAnimInstance = this.Mesh.GetAnimInstance() as UKuroAnimInstance;
				if (ukuroAnimInstance != null)
				{
					ukuroAnimInstance.SaveExtraFollowSnapshot();
				}
			}

			// Token: 0x0604B1DC RID: 307676 RVA: 0x014727F1 File Offset: 0x014709F1
			public void ClearSnapshot()
			{
				this.SnapshotWorldTransform = null;
			}

			// Token: 0x0604B1DD RID: 307677 RVA: 0x01472800 File Offset: 0x01470A00
			public void FreezeToWorld(bool visible = true)
			{
				if (this.FrozenInternal)
				{
					return;
				}
				UKuroAnimInstance ukuroAnimInstance = this.Mesh.GetAnimInstance() as UKuroAnimInstance;
				if (ukuroAnimInstance != null)
				{
					FTransform ftransform = this.SnapshotWorldTransform ?? this.Mesh.K2_GetComponentToWorld();
					ukuroAnimInstance.FreezeExtraFollowAtWorldTransform(ftransform);
				}
				else
				{
					this.Mesh.K2_DetachFromComponent(EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, true);
					if (this.SnapshotWorldTransform != null)
					{
						USceneComponent mesh = this.Mesh;
						FTransform value = this.SnapshotWorldTransform.Value;
						mesh.K2_SetWorldTransform(value, false, ref WorldGlobal.SweepHitResult, true);
					}
				}
				this.SetVisible(visible, 0f);
				this.FrozenInternal = true;
			}

			// Token: 0x0604B1DE RID: 307678 RVA: 0x014728A8 File Offset: 0x01470AA8
			public void Unfreeze()
			{
				if (!this.FrozenInternal)
				{
					return;
				}
				UKuroAnimInstance ukuroAnimInstance = this.Mesh.GetAnimInstance() as UKuroAnimInstance;
				if (ukuroAnimInstance != null)
				{
					ukuroAnimInstance.UnfreezeExtraFollow();
				}
				this.ResetAttach();
				this.ClearSnapshot();
				this.FrozenInternal = false;
			}

			// Token: 0x04034844 RID: 215108
			protected bool VisibleInternal;

			// Token: 0x04034845 RID: 215109
			[Nullable(2)]
			private TimerHandle InvisibleTimer;

			// Token: 0x04034846 RID: 215110
			public int CurrentPdHandle;

			// Token: 0x04034847 RID: 215111
			public int CurrentEffectHandle;

			// Token: 0x04034848 RID: 215112
			[Nullable(2)]
			private readonly USceneComponent OriginAttachComp;

			// Token: 0x04034849 RID: 215113
			private readonly FName OriginAttachSocketName = FNameUtil.NONE;

			// Token: 0x0403484A RID: 215114
			private readonly Transform OriginRelativeTransform = Transform.Create();

			// Token: 0x0403484B RID: 215115
			private bool FrozenInternal;

			// Token: 0x0403484C RID: 215116
			private FTransform? SnapshotWorldTransform;
		}

		// Token: 0x0200A999 RID: 43417
		[NullableContext(2)]
		[Nullable(0)]
		public class SubMeshOrder
		{
			// Token: 0x0604B1DF RID: 307679 RVA: 0x014728EB File Offset: 0x01470AEB
			public SubMeshOrder(bool visible, PD_CharacterControllerData_C charControllerData, [Nullable(new byte[]
			{
				2,
				1
			})] TSoftObjectPtr<UEffectModelBase> effectDataAssetRef, float delayTime)
			{
				this.Visible = visible;
				this.CharControllerData = charControllerData;
				this.EffectDataAssetRef = effectDataAssetRef;
				this.DelayTime = delayTime;
			}

			// Token: 0x1700A931 RID: 43313
			// (get) Token: 0x0604B1E0 RID: 307680 RVA: 0x01472910 File Offset: 0x01470B10
			public bool Visible { get; }

			// Token: 0x1700A932 RID: 43314
			// (get) Token: 0x0604B1E1 RID: 307681 RVA: 0x01472918 File Offset: 0x01470B18
			public PD_CharacterControllerData_C CharControllerData { get; }

			// Token: 0x1700A933 RID: 43315
			// (get) Token: 0x0604B1E2 RID: 307682 RVA: 0x01472920 File Offset: 0x01470B20
			[Nullable(new byte[]
			{
				2,
				1
			})]
			public TSoftObjectPtr<UEffectModelBase> EffectDataAssetRef { [return: Nullable(new byte[]
			{
				2,
				1
			})] get; }

			// Token: 0x1700A934 RID: 43316
			// (get) Token: 0x0604B1E3 RID: 307683 RVA: 0x01472928 File Offset: 0x01470B28
			public float DelayTime { get; }
		}
	}
}
