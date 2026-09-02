using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x020047F5 RID: 18421
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneItemExhibitComponent : EntityComponent
	{
		// Token: 0x0602FCFE RID: 195838 RVA: 0x00B7C870 File Offset: 0x00B7AA70
		[NullableContext(2)]
		protected override bool OnInitData(IEntityArgs args = null)
		{
			CreateEntityData p = args.GetP1<CreateEntityData>();
			this.ExhibitData = (p.GetParam<SceneItemExhibitComponent>() as ExhibitComponent);
			if (this.ExhibitData == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.BB, "SceneItemExhibitComponent ExhibitData is undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return true;
		}

		// Token: 0x0602FCFF RID: 195839 RVA: 0x00B7C8BA File Offset: 0x00B7AABA
		protected override bool OnStart()
		{
			this.ActorComp = base.Entity.GetComponent<SceneItemActorComponent>();
			this.CreatureDataComp = base.Entity.GetComponent<CreatureDataComponent>();
			this.StateComponent = base.Entity.GetComponent<SceneItemStateComponent>();
			return true;
		}

		// Token: 0x0602FD00 RID: 195840 RVA: 0x00B7C8F0 File Offset: 0x00B7AAF0
		protected override void OnActivate()
		{
			Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnSceneInteractionShowCompleted, new Action(this.OnSceneInteractionShowCompleted));
		}

		// Token: 0x0602FD01 RID: 195841 RVA: 0x00B7C914 File Offset: 0x00B7AB14
		private void InitSkeletalMeshComponent()
		{
			SceneItemActorComponent actorComp = this.ActorComp;
			SceneInteractionActor sceneInteractionActor = ((actorComp != null) ? actorComp.GetInteractionMainActor() : null) as SceneInteractionActor;
			AActor aactor = (sceneInteractionActor != null) ? sceneInteractionActor.GetActorByKey("Model") : null;
			if (aactor == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.BB, "SceneItemExhibitComponent exhibitActor is undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			IExhibitEffect exhibitEffect = null;
			IWeaponExhibitConfig weaponExhibitConfig = this.ExhibitData.ExhibitConfig as IWeaponExhibitConfig;
			if (weaponExhibitConfig != null)
			{
				exhibitEffect = weaponExhibitConfig.ActiveEffect;
			}
			else
			{
				IPhantomExhibitConfig phantomExhibitConfig = this.ExhibitData.ExhibitConfig as IPhantomExhibitConfig;
				if (phantomExhibitConfig != null)
				{
					exhibitEffect = phantomExhibitConfig.ActiveEffect;
				}
			}
			if (exhibitEffect != null)
			{
				this.EffectPath = exhibitEffect.Path;
				global::Vector inB = global::Vector.Create((double)exhibitEffect.Offset.X.GetValueOrDefault(), (double)exhibitEffect.Offset.Y.GetValueOrDefault(), (double)exhibitEffect.Offset.Z.GetValueOrDefault());
				this.EffectTransform.SetLocation(this.ActorComp.Owner.D_K2_GetActorLocation());
				this.EffectTransform.GetLocation().Addition(inB, this.EffectTransform.GetLocation());
				this.EffectTransform.SetScale3D(global::Vector.Create((double)exhibitEffect.Scale, (double)exhibitEffect.Scale, (double)exhibitEffect.Scale));
			}
			aactor.SetActorTickEnabled(true);
			aactor.PrimaryActorTick.bCanEverTick = true;
			this.ExhibitActor = aactor;
			if (this.CreatureDataComp.ExhibitionItemId <= 0)
			{
				this.HideSkeletalMeshComponent();
				return;
			}
			this.RefreshSkeletalMeshComponent(this.CreatureDataComp.ExhibitionItemId, true);
		}

		// Token: 0x0602FD02 RID: 195842 RVA: 0x00B7CAA4 File Offset: 0x00B7ACA4
		protected override void OnTick(float delta)
		{
			if (this.ExhibitActor == null)
			{
				return;
			}
			if (!this.CanSelfRotate || this.DeltaSecondRotate == 0f)
			{
				return;
			}
			float yaw = this.DeltaSecondRotate * delta;
			this.Rotator.Yaw = yaw;
			this.ExhibitActor.K2_AddActorLocalRotation(this.Rotator.ToUeRotator(), false, ref WorldGlobal.SweepHitResult, false);
		}

		// Token: 0x0602FD03 RID: 195843 RVA: 0x00B7CB02 File Offset: 0x00B7AD02
		protected void OnDeactivate()
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnSceneInteractionShowCompleted, new Action(this.OnSceneInteractionShowCompleted));
		}

		// Token: 0x0602FD04 RID: 195844 RVA: 0x00B7CB26 File Offset: 0x00B7AD26
		protected override bool OnEnd()
		{
			this.CancelPreLoad();
			this.DestroyMeshComponent(this.SkeletonComponentList, this.ExhibitActor);
			CharRenderingComponent charRenderingComponent = this.CharRenderingComponent;
			if (charRenderingComponent != null)
			{
				charRenderingComponent.K2_DestroyComponent(this.ExhibitActor);
			}
			this.ReleaseEffect();
			return true;
		}

		// Token: 0x0602FD05 RID: 195845 RVA: 0x00B7CB60 File Offset: 0x00B7AD60
		private void ReleaseEffect()
		{
			if (!Singleton<EffectSystem>.Instance.IsValid(this.EffectHandleId))
			{
				return;
			}
			Singleton<EffectSystem>.Instance.StopEffectById(this.EffectHandleId, "SceneItemExhibitComponent", true, null);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.SceneItem;
			ELogAuthor author = ELogAuthor.BB;
			string message = "SceneItemExhibitComponent ReleaseEffect EffectHandleId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EffectHandleId", this.EffectHandleId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.EffectHandleId = 0;
		}

		// Token: 0x0602FD06 RID: 195846 RVA: 0x00B7CBD8 File Offset: 0x00B7ADD8
		public void RefreshSkeletalMeshComponent(int id, bool forceRefresh = false)
		{
			if (this.ExhibitData == null)
			{
				return;
			}
			if (this.CreatureDataComp.ExhibitionItemId == id && !forceRefresh)
			{
				return;
			}
			if (this.CharRenderingComponent == null)
			{
				this.CharRenderingComponent = this.CreateUiModelCharRenderingComponent();
			}
			this.CreatureDataComp.ExhibitionItemId = id;
			this.ReleaseEffect();
			if (this.ExhibitData.ExhibitConfig.Type == EExhibitItemType.Weapon)
			{
				this.LoadWeaponSkeletalMesh(id);
				return;
			}
			if (this.ExhibitData.ExhibitConfig.Type == EExhibitItemType.Phantom)
			{
				this.LoadPhantomSkeletalMesh(id);
				this.SetExhibitShowEffect(true);
			}
		}

		// Token: 0x0602FD07 RID: 195847 RVA: 0x00B7CC64 File Offset: 0x00B7AE64
		public void HideSkeletalMeshComponent()
		{
			if (this.ExhibitData.ExhibitConfig.Type == EExhibitItemType.Phantom)
			{
				this.SetExhibitShowEffect(false);
			}
			this.CreatureDataComp.ExhibitionItemId = 0;
			this.CanSelfRotate = false;
			this.StopAnimation();
			this.CancelPreLoad();
			if (this.SkeletonComponentList.Count == 0)
			{
				return;
			}
			foreach (USkeletalMeshComponent uskeletalMeshComponent in this.SkeletonComponentList)
			{
				uskeletalMeshComponent.SetHiddenInGame(true, false);
			}
		}

		// Token: 0x0602FD08 RID: 195848 RVA: 0x00B7CCFC File Offset: 0x00B7AEFC
		private CharRenderingComponent CreateUiModelCharRenderingComponent()
		{
			CharRenderingComponent charRenderingComponent = this.ExhibitActor.AddComponentByClass(CharRenderingComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as CharRenderingComponent;
			charRenderingComponent.Init(ECharacterRenderingType.Npc);
			charRenderingComponent.SetComponentTickEnabled(true);
			if (Singleton<Info>.Instance.IsPlayInEditor)
			{
				ULGUIBPLibrary.AddInstanceComponent(this.ExhibitActor, charRenderingComponent);
			}
			return charRenderingComponent;
		}

		// Token: 0x0602FD09 RID: 195849 RVA: 0x00B7CD60 File Offset: 0x00B7AF60
		private unsafe void LoadWeaponSkeletalMesh(int id)
		{
			this.CanSelfRotate = false;
			InventoryDefine.EItemDataType itemDataTypeByConfigId = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(id));
			List<int> modelIdList = new List<int>();
			List<string> list = new List<string>();
			if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.WeaponItem)
			{
				WeaponConf? weaponItemConfig = ConfigBase<InventoryConfig>.Instance.GetWeaponItemConfig(id);
				if (weaponItemConfig == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.SceneItem;
					ELogAuthor author = ELogAuthor.BB;
					string message = "WeaponConfig is undefined";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				modelIdList = new List<int>(weaponItemConfig.Value.ModelsIter());
				list = new List<string>(weaponItemConfig.Value.StandAnimIter());
			}
			else
			{
				if (itemDataTypeByConfigId != InventoryDefine.EItemDataType.WeaponSkinItem)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.SceneItem;
					ELogAuthor author2 = ELogAuthor.BB;
					string message2 = "Invalid ItemType";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("itemType", itemDataTypeByConfigId);
					instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return;
				}
				WeaponSkin? config = ConfigWeaponSkinById.GetConfig(id, true);
				if (config == null)
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.SceneItem;
					ELogAuthor author3 = ELogAuthor.BB;
					string message3 = "WeaponSkinConfig is undefined";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("id", id);
					instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					return;
				}
				modelIdList = new List<int>(config.Value.ModelsIter());
				list = new List<string>(config.Value.StandAnimIter());
			}
			this.ExhibitActor.SetActorHiddenInGame(true);
			CharRenderingComponent charRenderingComponent = this.CharRenderingComponent;
			if (charRenderingComponent != null)
			{
				charRenderingComponent.ResetAllRenderingState();
			}
			this.StopAnimation();
			this.CancelPreLoad();
			if (modelIdList.Count <= 0)
			{
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module4 = ELogModule.SceneItem;
				ELogAuthor author4 = ELogAuthor.BB;
				string message4 = "ModelIdList is empty";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("id", id);
				instance4.Error(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				return;
			}
			if (list.Count <= 0)
			{
				this.LoadModelByModelId(modelIdList, delegate
				{
					this.ExhibitActor.SetActorHiddenInGame(false);
					this.AnimHandleId = Singleton<UiModelResourcesManager>.Instance.InvalidValue;
					this.LoadHandleId = Singleton<UiModelResourcesManager>.Instance.InvalidValue;
					this.MeshStreamTaskId = -1;
					this.WeaponLoadComplete(id, new List<UAnimationAsset>());
				});
				return;
			}
			this.LoadWeaponAnimList(list, delegate(List<UAnimationAsset> animList)
			{
				this.LoadModelByModelId(modelIdList, delegate
				{
					this.ExhibitActor.SetActorHiddenInGame(false);
					this.ExhibitActor.K2_SetActorRotation(FRotator.ZeroRotator, false);
					this.AnimHandleId = Singleton<UiModelResourcesManager>.Instance.InvalidValue;
					this.LoadHandleId = Singleton<UiModelResourcesManager>.Instance.InvalidValue;
					this.MeshStreamTaskId = -1;
					this.WeaponLoadComplete(id, animList);
				});
			});
		}

		// Token: 0x0602FD0A RID: 195850 RVA: 0x00B7CFBC File Offset: 0x00B7B1BC
		private void LoadWeaponAnimList(List<string> standAnimList, Action<List<UAnimationAsset>> callback)
		{
			List<UAnimationAsset> animList = new List<UAnimationAsset>();
			if (standAnimList.Count <= 0)
			{
				callback(animList);
			}
			this.LoadAnimByAnimPath(standAnimList[0], delegate(UAnimationAsset animAsset)
			{
				animList.Add(animAsset);
				if (standAnimList.Count == animList.Count)
				{
					callback(animList);
				}
			});
			if (standAnimList.Count > 1)
			{
				this.LoadSecondAnimByAnimPath(standAnimList[1], delegate(UAnimationAsset animAsset)
				{
					animList.Add(animAsset);
					if (standAnimList.Count == animList.Count)
					{
						callback(animList);
					}
				});
			}
		}

		// Token: 0x0602FD0B RID: 195851 RVA: 0x00B7D054 File Offset: 0x00B7B254
		private void WeaponLoadComplete(int itemId, List<UAnimationAsset> animList)
		{
			if (this.SkeletonComponentList.Count == 0)
			{
				return;
			}
			ExhibitWeaponTransform? config = ConfigExhibitWeaponTransformById.GetConfig(ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(itemId).Value.TransformId, true);
			List<Transform> weaponExhibitTransform = this.GetWeaponExhibitTransform(config.Value, this.SkeletonComponentList.Count > 1);
			if (weaponExhibitTransform.Count != this.SkeletonComponentList.Count)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.BB;
				string message = "WeaponLoadComplete transformList length not equal SkeletonComponentList length";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("itemId", itemId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			for (int i = 0; i < this.SkeletonComponentList.Count; i++)
			{
				USkeletalMeshComponent uskeletalMeshComponent = this.SkeletonComponentList[i];
				USceneComponent usceneComponent = uskeletalMeshComponent;
				FTransform ftransform = weaponExhibitTransform[i].ToUeTransformOld();
				usceneComponent.K2_SetRelativeTransform(ftransform, false, ref WorldGlobal.SweepHitResult, false);
				uskeletalMeshComponent.SetAnimationMode(EAnimationMode.AnimationSingleNode);
				if (animList.Count > i)
				{
					uskeletalMeshComponent.PlayAnimation(animList[i], true);
				}
			}
			this.CanSelfRotate = true;
			this.DeltaSecondRotate = ((config.Value.RotateTime != 0) ? (360f / (float)config.Value.RotateTime) : 0f);
		}

		// Token: 0x0602FD0C RID: 195852 RVA: 0x00B7D198 File Offset: 0x00B7B398
		private unsafe void LoadPhantomSkeletalMesh(int id)
		{
			if (this.ExhibitData == null)
			{
				return;
			}
			this.ExhibitActor.SetActorHiddenInGame(true);
			PhantomItem? config = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemById(id);
			this.StopAnimation();
			this.CancelPreLoad();
			this.LoadAnimByAnimPath(config.Value.StandAnim, delegate(UAnimationAsset animAsset)
			{
				SceneItemExhibitComponent <>4__this = this;
				int num = 1;
				List<int> list = new List<int>(num);
				CollectionsMarshal.SetCount<int>(list, num);
				Span<int> span = CollectionsMarshal.AsSpan<int>(list);
				int index = 0;
				*span[index] = config.Value.MeshId;
				<>4__this.LoadModelByModelId(list, delegate
				{
					this.ExhibitActor.SetActorHiddenInGame(false);
					this.AnimHandleId = Singleton<UiModelResourcesManager>.Instance.InvalidValue;
					this.LoadHandleId = Singleton<UiModelResourcesManager>.Instance.InvalidValue;
					this.MeshStreamTaskId = -1;
					this.PhantomLoadComplete(animAsset);
				});
			});
		}

		// Token: 0x0602FD0D RID: 195853 RVA: 0x00B7D20C File Offset: 0x00B7B40C
		private void PhantomLoadComplete(UAnimationAsset animAsset)
		{
			if (this.SkeletonComponentList.Count == 0)
			{
				return;
			}
			USkeletalMeshComponent uskeletalMeshComponent = this.SkeletonComponentList[0];
			Transform phantomSkeletalMeshTransform = this.GetPhantomSkeletalMeshTransform(this.CreatureDataComp.ExhibitionItemId);
			FTransform ftransform = phantomSkeletalMeshTransform.ToUeTransformOld();
			uskeletalMeshComponent.K2_SetRelativeTransform(ftransform, false, ref WorldGlobal.SweepHitResult, false);
			uskeletalMeshComponent.SetAnimationMode(EAnimationMode.AnimationSingleNode);
			uskeletalMeshComponent.PlayAnimation(animAsset, true);
		}

		// Token: 0x0602FD0E RID: 195854 RVA: 0x00B7D26C File Offset: 0x00B7B46C
		private void LoadModelByModelId(List<int> modelIdList, Action finishCallBack)
		{
			List<string> meshPathList = new List<string>();
			foreach (int num in modelIdList)
			{
				string text = ModelUtil.GetModelConfig(num).网格体.ToAssetPathName();
				if (string.IsNullOrEmpty(text))
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.SceneItem;
					ELogAuthor author = ELogAuthor.BB;
					string message = "SceneItemExhibitComponent meshPath is empty";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("modelId", num);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					meshPathList.Add(text);
				}
			}
			this.CancelPreLoad();
			this.LoadHandleId = Singleton<UiModelResourcesManager>.Instance.LoadUiModelResources(meshPathList, delegate(EUiRoleLoadResult result, [Nullable(new byte[]
			{
				2,
				1,
				1
			})] Dictionary<string, UObject> resultMap)
			{
				List<USkeletalMesh> list = new List<USkeletalMesh>();
				foreach (string text2 in meshPathList)
				{
					USkeletalMesh uskeletalMesh = ((resultMap != null) ? resultMap[text2] : null) as USkeletalMesh;
					if (uskeletalMesh == null)
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.SceneItem;
						ELogAuthor author2 = ELogAuthor.BB;
						string message2 = "SceneItemExhibitComponent LoadUiModelResources mesh is undefined";
						ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("meshPath", text2);
						instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					}
					else
					{
						list.Add(uskeletalMesh);
					}
				}
				this.CancelPreMeshStreaming();
				this.DestroyMeshComponent(this.SkeletonComponentList, this.ExhibitActor);
				this.CreateSkeletalMeshComponentList(this.ExhibitActor, list);
				MeshStreamTaskContext meshStreamTaskContext = new MeshStreamTaskContext();
				TArray<USkeletalMesh> tarray = new TArray<USkeletalMesh>();
				foreach (USkeletalMesh value in list)
				{
					tarray.Add(value);
				}
				meshStreamTaskContext.SkeletalMeshes = tarray;
				meshStreamTaskContext.OnTaskFinish = finishCallBack;
				this.MeshStreamTaskId = ControllerBase<MeshStreamController>.Instance.AddMeshStreamTask(meshStreamTaskContext);
			});
		}

		// Token: 0x0602FD0F RID: 195855 RVA: 0x00B7D350 File Offset: 0x00B7B550
		private void CreateSkeletalMeshComponentList(AActor actor, List<USkeletalMesh> meshList)
		{
			foreach (USkeletalMesh newMesh in meshList)
			{
				USkeletalMeshComponent uskeletalMeshComponent = actor.AddComponentByClass(USkeletalMeshComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as USkeletalMeshComponent;
				uskeletalMeshComponent.SetSkeletalMesh(newMesh, true);
				uskeletalMeshComponent.bConsiderAllBodiesForBounds = true;
				uskeletalMeshComponent.KuroMaterialControllerUpdateGroupMode = EKuroMaterialControllerUpdateGroupMode.CharMesh;
				uskeletalMeshComponent.SetHiddenInGame(false, false);
				uskeletalMeshComponent.SetComponentTickEnabled(true);
				this.AttachToCharRenderingComponent(uskeletalMeshComponent);
				if (Singleton<Info>.Instance.IsPlayInEditor)
				{
					ULGUIBPLibrary.AddInstanceComponent(actor, uskeletalMeshComponent);
				}
				this.SkeletonComponentList.Add(uskeletalMeshComponent);
			}
		}

		// Token: 0x0602FD10 RID: 195856 RVA: 0x00B7D410 File Offset: 0x00B7B610
		private void AttachToCharRenderingComponent(USkeletalMeshComponent skeletalComponent)
		{
			if (this.ExhibitData.ExhibitConfig.Type == EExhibitItemType.Weapon)
			{
				this.CharRenderingComponent.AddComponent("WeaponCase0", skeletalComponent);
				return;
			}
			if (this.ExhibitData.ExhibitConfig.Type == EExhibitItemType.Phantom)
			{
				this.CharRenderingComponent.AddComponent("CharacterMesh0", skeletalComponent);
			}
		}

		// Token: 0x0602FD11 RID: 195857 RVA: 0x00B7D468 File Offset: 0x00B7B668
		private void DestroyMeshComponent(List<USkeletalMeshComponent> meshCompList, AActor actor)
		{
			foreach (USkeletalMeshComponent uskeletalMeshComponent in meshCompList)
			{
				uskeletalMeshComponent.K2_DestroyComponent(actor);
				if (Singleton<Info>.Instance.IsPlayInEditor)
				{
					ULGUIBPLibrary.RemoveInstanceComponent(actor, uskeletalMeshComponent);
				}
			}
			meshCompList.Clear();
		}

		// Token: 0x0602FD12 RID: 195858 RVA: 0x00B7D4D0 File Offset: 0x00B7B6D0
		private void CancelPreLoad()
		{
			if (this.AnimHandleId != Singleton<UiModelResourcesManager>.Instance.InvalidValue)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.AnimHandleId);
				this.AnimHandleId = Singleton<UiModelResourcesManager>.Instance.InvalidValue;
			}
			if (this.SecondAnimHandleId != Singleton<UiModelResourcesManager>.Instance.InvalidValue)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.SecondAnimHandleId);
				this.SecondAnimHandleId = Singleton<UiModelResourcesManager>.Instance.InvalidValue;
			}
			if (this.LoadHandleId != Singleton<UiModelResourcesManager>.Instance.InvalidValue)
			{
				Singleton<UiModelResourcesManager>.Instance.CancelUiModelResourceLoad(this.LoadHandleId);
				this.LoadHandleId = Singleton<UiModelResourcesManager>.Instance.InvalidValue;
			}
			this.CancelPreMeshStreaming();
		}

		// Token: 0x0602FD13 RID: 195859 RVA: 0x00B7D57C File Offset: 0x00B7B77C
		private void StopAnimation()
		{
			foreach (USkeletalMeshComponent uskeletalMeshComponent in this.SkeletonComponentList)
			{
				uskeletalMeshComponent.Stop();
			}
		}

		// Token: 0x0602FD14 RID: 195860 RVA: 0x00B7D5CC File Offset: 0x00B7B7CC
		private void CancelPreMeshStreaming()
		{
			if (this.MeshStreamTaskId != -1)
			{
				ControllerBase<MeshStreamController>.Instance.RemoveMeshStreamTask(this.MeshStreamTaskId);
				this.MeshStreamTaskId = -1;
			}
		}

		// Token: 0x0602FD15 RID: 195861 RVA: 0x00B7D5F0 File Offset: 0x00B7B7F0
		private void LoadAnimByAnimPath(string standAnim, Action<UAnimationAsset> finishCallBack)
		{
			this.AnimHandleId = Singleton<ResourceSystem>.Instance.LoadAsync<UAnimationAsset>(standAnim, delegate([Nullable(2)] UAnimationAsset animAsset, string path)
			{
				if (animAsset == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.SceneItem;
					ELogAuthor author = ELogAuthor.BB;
					string message = "SceneItemExhibitComponent LoadAnimByModelId animAsset is undefined";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("standAnim", standAnim);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				finishCallBack(animAsset);
			}, ResourceSystem.EResourceLoadPriority.Default, "Ui.PhantomUi");
		}

		// Token: 0x0602FD16 RID: 195862 RVA: 0x00B7D63C File Offset: 0x00B7B83C
		private void LoadSecondAnimByAnimPath(string secondAnim, Action<UAnimationAsset> finishCallBack)
		{
			this.SecondAnimHandleId = Singleton<ResourceSystem>.Instance.LoadAsync<UAnimationAsset>(secondAnim, delegate([Nullable(2)] UAnimationAsset animAsset, string path)
			{
				if (animAsset == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.SceneItem;
					ELogAuthor author = ELogAuthor.BB;
					string message = "SceneItemExhibitComponent LoadSecondAnimByModelId animAsset is undefined";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("secondAnim", secondAnim);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				finishCallBack(animAsset);
			}, ResourceSystem.EResourceLoadPriority.Default, "Ui.PhantomUi");
		}

		// Token: 0x0602FD17 RID: 195863 RVA: 0x00B7D688 File Offset: 0x00B7B888
		private List<Transform> GetWeaponExhibitTransform(ExhibitWeaponTransform transformConfig, bool hasSubMesh)
		{
			List<Transform> list = new List<Transform>();
			global::Vector inT = global::Vector.Create((double)transformConfig.Location.Value.X, (double)transformConfig.Location.Value.Y, (double)transformConfig.Location.Value.Z);
			Rotator rotator = Rotator.Create(transformConfig.Rotation.Value.Y, transformConfig.Rotation.Value.Z, transformConfig.Rotation.Value.X);
			global::Vector inS = global::Vector.Create((double)transformConfig.Size, (double)transformConfig.Size, (double)transformConfig.Size);
			Transform item = Transform.Create(rotator.Quaternion(null), inT, inS);
			list.Add(item);
			if (!hasSubMesh)
			{
				return list;
			}
			global::Vector inT2 = global::Vector.Create((double)transformConfig.ScabbardOffset.Value.X, (double)transformConfig.ScabbardOffset.Value.Y, (double)transformConfig.ScabbardOffset.Value.Z);
			Transform item2 = Transform.Create(Rotator.Create(transformConfig.ScabbardRotationOffset.Value.Y, transformConfig.ScabbardRotationOffset.Value.Z, transformConfig.ScabbardRotationOffset.Value.X).Quaternion(null), inT2, inS);
			list.Add(item2);
			return list;
		}

		// Token: 0x0602FD18 RID: 195864 RVA: 0x00B7D838 File Offset: 0x00B7BA38
		private Transform GetPhantomSkeletalMeshTransform(int itemId)
		{
			ExhibitPhantom? config = ConfigExhibitPhantomById.GetConfig(ConfigBase<InventoryConfig>.Instance.GetPhantomItemConfig(itemId).Value.MonsterId, true);
			float[] locationArray = config.Value.GetLocationArray();
			global::Vector inT = global::Vector.Create((double)locationArray[0], (double)locationArray[1], (double)locationArray[2]);
			float[] rotatorArray = config.Value.GetRotatorArray();
			Rotator rotator = Rotator.Create(rotatorArray[0], rotatorArray[1], rotatorArray[2]);
			float[] zoomArray = config.Value.GetZoomArray();
			global::Vector inS = global::Vector.Create((double)zoomArray[0], (double)zoomArray[1], (double)zoomArray[2]);
			return Transform.Create(rotator.Quaternion(null), inT, inS);
		}

		// Token: 0x0602FD19 RID: 195865 RVA: 0x00B7D8E4 File Offset: 0x00B7BAE4
		public void SetExhibitShowEffect(bool isActive)
		{
			if (!isActive)
			{
				this.ReleaseEffect();
				return;
			}
			if (Singleton<EffectSystem>.Instance.IsValid(this.EffectHandleId))
			{
				return;
			}
			if (string.IsNullOrEmpty(this.EffectPath))
			{
				return;
			}
			EffectSystem instance = Singleton<EffectSystem>.Instance;
			UObject owner = this.ActorComp.Owner;
			FTransformDouble? ftransformDouble = new FTransformDouble?(this.EffectTransform.ToUeTransform());
			this.EffectHandleId = instance.SpawnEffect(owner, ftransformDouble, this.EffectPath, "SceneItemExhibitComponent", null, EEffectType.Scene, null, null, null, false, false);
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.SceneItem;
			ELogAuthor author = ELogAuthor.BB;
			string message = "SceneItemExhibitComponent SetExhibitShowEffect EffectHandleId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EffectHandleId", this.EffectHandleId);
			instance2.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0602FD1A RID: 195866 RVA: 0x00B7D990 File Offset: 0x00B7BB90
		private void OnSceneInteractionShowCompleted()
		{
			this.InitSkeletalMeshComponent();
		}

		// Token: 0x0602FD1B RID: 195867 RVA: 0x00B7D998 File Offset: 0x00B7BB98
		[NullableContext(2)]
		public IExhibitItemType GetExhibitConfig()
		{
			if (this.ExhibitData == null)
			{
				return null;
			}
			return this.ExhibitData.ExhibitConfig;
		}

		// Token: 0x0602FD1C RID: 195868 RVA: 0x00B7D9AF File Offset: 0x00B7BBAF
		public int GetItemId()
		{
			return this.CreatureDataComp.ExhibitionItemId;
		}

		// Token: 0x0602FD1D RID: 195869 RVA: 0x00B7D9BC File Offset: 0x00B7BBBC
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneItemExhibitComponent sceneItemExhibitComponent = (SceneItemExhibitComponent)componentTemplate;
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (sceneItemExhibitComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CreatureDataComp"))
			{
				if (sceneItemExhibitComponent.CreatureDataComp == null)
				{
					this.CreatureDataComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComp), "CreatureDataComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("StateComponent"))
			{
				if (sceneItemExhibitComponent.StateComponent == null)
				{
					this.StateComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemStateComponent>(this.StateComponent), "StateComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ExhibitData"))
			{
				if (sceneItemExhibitComponent.ExhibitData == null)
				{
					this.ExhibitData = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ExhibitComponent>(this.ExhibitData), "ExhibitData"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ExhibitActor"))
			{
				if (sceneItemExhibitComponent.ExhibitActor == null)
				{
					this.ExhibitActor = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<AActor>(this.ExhibitActor), "ExhibitActor"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("LoadHandleId"))
			{
				this.LoadHandleId = sceneItemExhibitComponent.LoadHandleId;
			}
			if (base.CanResetComponentProperty("MeshStreamTaskId"))
			{
				this.MeshStreamTaskId = sceneItemExhibitComponent.MeshStreamTaskId;
			}
			if (base.CanResetComponentProperty("AnimHandleId"))
			{
				this.AnimHandleId = sceneItemExhibitComponent.AnimHandleId;
			}
			if (base.CanResetComponentProperty("SecondAnimHandleId"))
			{
				this.SecondAnimHandleId = sceneItemExhibitComponent.SecondAnimHandleId;
			}
			if (base.CanResetComponentProperty("CharRenderingComponent"))
			{
				this.CharRenderingComponent = sceneItemExhibitComponent.CharRenderingComponent;
			}
			if (base.CanResetComponentProperty("SkeletonComponentList"))
			{
				if (sceneItemExhibitComponent.SkeletonComponentList == null)
				{
					this.SkeletonComponentList = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<USkeletalMeshComponent>>(this.SkeletonComponentList), "SkeletonComponentList"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CanSelfRotate"))
			{
				this.CanSelfRotate = sceneItemExhibitComponent.CanSelfRotate;
			}
			if (base.CanResetComponentProperty("DeltaSecondRotate"))
			{
				this.DeltaSecondRotate = sceneItemExhibitComponent.DeltaSecondRotate;
			}
			if (base.CanResetComponentProperty("Rotator") && sceneItemExhibitComponent.Rotator != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Rotator>(this.Rotator), "Rotator"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("EffectPath"))
			{
				this.EffectPath = sceneItemExhibitComponent.EffectPath;
			}
			if (base.CanResetComponentProperty("EffectTransform") && sceneItemExhibitComponent.EffectTransform != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Transform>(this.EffectTransform), "EffectTransform"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("EffectHandleId"))
			{
				this.EffectHandleId = sceneItemExhibitComponent.EffectHandleId;
			}
			return true;
		}

		// Token: 0x0401B6AE RID: 112302
		private const string EXHIBIT_ACTOR_REFERENCE_KEY = "Model";

		// Token: 0x0401B6AF RID: 112303
		[Nullable(2)]
		protected SceneItemActorComponent ActorComp;

		// Token: 0x0401B6B0 RID: 112304
		[Nullable(2)]
		protected CreatureDataComponent CreatureDataComp;

		// Token: 0x0401B6B1 RID: 112305
		[Nullable(2)]
		protected SceneItemStateComponent StateComponent;

		// Token: 0x0401B6B2 RID: 112306
		[Nullable(2)]
		protected ExhibitComponent ExhibitData;

		// Token: 0x0401B6B3 RID: 112307
		[Nullable(2)]
		private AActor ExhibitActor;

		// Token: 0x0401B6B4 RID: 112308
		private int LoadHandleId = Singleton<UiModelResourcesManager>.Instance.InvalidValue;

		// Token: 0x0401B6B5 RID: 112309
		private int MeshStreamTaskId = -1;

		// Token: 0x0401B6B6 RID: 112310
		private int AnimHandleId = Singleton<UiModelResourcesManager>.Instance.InvalidValue;

		// Token: 0x0401B6B7 RID: 112311
		private int SecondAnimHandleId = Singleton<UiModelResourcesManager>.Instance.InvalidValue;

		// Token: 0x0401B6B8 RID: 112312
		[Nullable(2)]
		public CharRenderingComponent CharRenderingComponent;

		// Token: 0x0401B6B9 RID: 112313
		protected List<USkeletalMeshComponent> SkeletonComponentList = new List<USkeletalMeshComponent>();

		// Token: 0x0401B6BA RID: 112314
		private bool CanSelfRotate;

		// Token: 0x0401B6BB RID: 112315
		private float DeltaSecondRotate;

		// Token: 0x0401B6BC RID: 112316
		private readonly Rotator Rotator = Rotator.Create();

		// Token: 0x0401B6BD RID: 112317
		private string EffectPath = "";

		// Token: 0x0401B6BE RID: 112318
		private readonly Transform EffectTransform = Transform.Create();

		// Token: 0x0401B6BF RID: 112319
		private int EffectHandleId;
	}
}
