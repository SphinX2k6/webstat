using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Common.Component;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x0200480E RID: 18446
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneItemRotatorComponent : EntityComponent
	{
		// Token: 0x0602FFE7 RID: 196583 RVA: 0x00B9C7D4 File Offset: 0x00B9A9D4
		protected unsafe override bool OnInitData(IEntityArgs args = null)
		{
			RotatorComponent2 rotatorComponent = args.GetP1<CreateEntityData>().GetParam<SceneItemRotatorComponent>() as RotatorComponent2;
			this.CreatureDataComp = base.Entity.GetComponent<CreatureDataComponent>();
			this.StateRotationConfigMap = new Dictionary<int, IStateRotationConfig>();
			foreach (IStateRotationConfig stateRotationConfig in rotatorComponent.Config)
			{
				int tagIdByName = GameplayTagUtils.GetTagIdByName(stateRotationConfig.State);
				if (tagIdByName == 0)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.SceneItem;
					ELogAuthor author = ELogAuthor.ZYL;
					string message = "[SceneItemRotatorComponent] 配置出错，找不到" + stateRotationConfig.State + "对应的状态Id";
					string item = "PbDataId";
					CreatureDataComponent creatureDataComp = this.CreatureDataComp;
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (creatureDataComp != null) ? new int?(creatureDataComp.GetPbDataId()) : null);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return false;
				}
				List<IRotationConfig> list = (stateRotationConfig.RotationConfig != null && stateRotationConfig.RotationConfig.Count > 0) ? stateRotationConfig.RotationConfig : null;
				List<IKeyRotatorConfig> list2 = (stateRotationConfig.KeyRotatorConfig != null && stateRotationConfig.KeyRotatorConfig.Count > 0) ? stateRotationConfig.KeyRotatorConfig : null;
				if (list != null && list2 != null)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.SceneItem;
					ELogAuthor author2 = ELogAuthor.ZYL;
					string message2 = "[SceneItemRotatorComponent] 该状态同时存在两种旋转配置列表，配置有误，跳过该状态的配置";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
					string item2 = "PbDataId";
					CreatureDataComponent creatureDataComp2 = this.CreatureDataComp;
					ptr = new ValueTuple<string, object>(item2, (creatureDataComp2 != null) ? new int?(creatureDataComp2.GetPbDataId()) : null);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("State", stateRotationConfig.State);
					instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
				else if (list == null && list2 == null)
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.SceneItem;
					ELogAuthor author3 = ELogAuthor.ZYL;
					string message3 = "[SceneItemRotatorComponent] 该状态的旋转配置列表为空，跳过该状态的配置";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0);
					string item3 = "PbDataId";
					CreatureDataComponent creatureDataComp3 = this.CreatureDataComp;
					ptr2 = new ValueTuple<string, object>(item3, (creatureDataComp3 != null) ? new int?(creatureDataComp3.GetPbDataId()) : null);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("State", stateRotationConfig.State);
					instance3.Warn(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				}
				else
				{
					this.StateRotationConfigMap[tagIdByName] = stateRotationConfig;
				}
			}
			return true;
		}

		// Token: 0x0602FFE8 RID: 196584 RVA: 0x00B9CA48 File Offset: 0x00B9AC48
		protected override bool OnStart()
		{
			this.ActorComp = base.Entity.GetComponent<SceneItemActorComponent>();
			if (this.ActorComp == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "[SceneItemRotatorComponent] 实体缺少SceneItemActorComponent";
				string item = "PbDataId";
				CreatureDataComponent creatureDataComp = this.CreatureDataComp;
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (creatureDataComp != null) ? new int?(creatureDataComp.GetPbDataId()) : null);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			if (this.ActorComp.Owner == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.SceneItem;
				ELogAuthor author2 = ELogAuthor.ZYL;
				string message2 = "[SceneItemRotatorComponent] 实体的SceneItemActorComponent.Owner不可用";
				string item2 = "PbDataId";
				CreatureDataComponent creatureDataComp2 = this.CreatureDataComp;
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>(item2, (creatureDataComp2 != null) ? new int?(creatureDataComp2.GetPbDataId()) : null);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
			if (base.Entity.GameBudgetConfig.GroupName == FNameUtil.GetDynamicFName("MoveSceneItemEntity"))
			{
				this.NeedTickOutside = true;
			}
			this.UeMoveComp = (this.ActorComp.Owner.GetComponentByClass(UKuroSceneItemMoveComponent.StaticClass()) as UKuroSceneItemMoveComponent);
			UKuroSceneItemMoveComponent ueMoveComp = this.UeMoveComp;
			if (ueMoveComp == null || !ueMoveComp.IsValid())
			{
				AActor owner = this.ActorComp.Owner;
				TSubclassOf<UActorComponent> @class = UKuroSceneItemMoveComponent.StaticClass();
				bool bManualAttachment = false;
				FTransform ftransform = new FTransform();
				this.UeMoveComp = (owner.AddComponentByClass(@class, bManualAttachment, ftransform, false, default(FName)) as UKuroSceneItemMoveComponent);
				UKuroSceneItemMoveComponent ueMoveComp2 = this.UeMoveComp;
				if (ueMoveComp2 == null || !ueMoveComp2.IsValid())
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.SceneItem;
					ELogAuthor author3 = ELogAuthor.ZYL;
					string message3 = "[SceneItemRotatorComponent] 实体Actor缺少KuroSceneItemMoveComponent，且动态创建失败";
					string item3 = "PbDataId";
					CreatureDataComponent creatureDataComp3 = this.CreatureDataComp;
					ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>(item3, (creatureDataComp3 != null) ? new int?(creatureDataComp3.GetPbDataId()) : null);
					instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
					return false;
				}
				this.UeMoveComp.Kuro_SetGravityDirect(this.ActorComp.ActorGravityDirectProxy.ToUeVectorOld());
				this.UeMoveComp.SetTickingMoveEnable(false);
				if (this.NeedTickOutside)
				{
					this.UeMoveComp.SetKuroOnlyTickOutside(true);
				}
			}
			this.StateComp = base.Entity.GetComponent<SceneItemStateComponent>();
			if (this.StateComp == null)
			{
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module4 = ELogModule.SceneItem;
				ELogAuthor author4 = ELogAuthor.ZYL;
				string message4 = "[SceneItemRotatorComponent] 实体缺少SceneItemStateComponent";
				string item4 = "PbDataId";
				CreatureDataComponent creatureDataComp4 = this.CreatureDataComp;
				ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>(item4, (creatureDataComp4 != null) ? new int?(creatureDataComp4.GetPbDataId()) : null);
				instance4.Error(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
				return false;
			}
			this.TagComp = base.Entity.GetComponent<LevelTagComponent>();
			if (this.TagComp == null)
			{
				Log instance5 = Singleton<Log>.Instance;
				ELogModule module5 = ELogModule.SceneItem;
				ELogAuthor author5 = ELogAuthor.ZYL;
				string message5 = "[SceneItemRotatorComponent] 实体缺少LevelTagComponent";
				string item5 = "PbDataId";
				CreatureDataComponent creatureDataComp5 = this.CreatureDataComp;
				ValueTuple<string, object> valueTuple5 = new ValueTuple<string, object>(item5, (creatureDataComp5 != null) ? new int?(creatureDataComp5.GetPbDataId()) : null);
				instance5.Error(module5, author5, message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple5));
				return false;
			}
			this.UeTickComp = base.Entity.GetComponent<UeSceneItemMoveTickManagerComponent>();
			if (this.UeTickComp == null)
			{
				Log instance6 = Singleton<Log>.Instance;
				ELogModule module6 = ELogModule.SceneItem;
				ELogAuthor author6 = ELogAuthor.ZYL;
				string message6 = "[SceneItemRotatorComponent] 实体缺少UeSceneItemMoveTickManagerComponent";
				string item6 = "PbDataId";
				CreatureDataComponent creatureDataComp6 = this.CreatureDataComp;
				ValueTuple<string, object> valueTuple6 = new ValueTuple<string, object>(item6, (creatureDataComp6 != null) ? new int?(creatureDataComp6.GetPbDataId()) : null);
				instance6.Error(module6, author6, message6, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple6));
				return false;
			}
			return true;
		}

		// Token: 0x0602FFE9 RID: 196585 RVA: 0x00B9CDA4 File Offset: 0x00B9AFA4
		protected override void OnActivate()
		{
			this.IsAllCurvesLoaded = false;
			this.IsAllActorsLoaded = false;
			this.IsRotationDataInit = false;
			this.SetAndLoadCurves();
			this.SetAndLoadActors();
			if (!this.IsRotationDataInit && this.IsAllCurvesLoaded && this.IsAllActorsLoaded)
			{
				this.InitRotationData();
			}
		}

		// Token: 0x0602FFEA RID: 196586 RVA: 0x00B9CDF0 File Offset: 0x00B9AFF0
		protected override void OnTick(float delta)
		{
			if (this.NeedTickOutside)
			{
				UeSceneItemMoveTickManagerComponent ueTickComp = this.UeTickComp;
				if (ueTickComp == null)
				{
					return;
				}
				ueTickComp.TickMovement(delta, false);
			}
		}

		// Token: 0x0602FFEB RID: 196587 RVA: 0x00B9CE0C File Offset: 0x00B9B00C
		[NullableContext(1)]
		protected override void OnDisable(string reason)
		{
			this.IsAllActorsLoaded = false;
			this.IsRotationDataInit = false;
			this.CurStateTagId = 0;
			this.PauseRotateStateId = 0;
			UKuroSceneItemMoveComponent ueMoveComp = this.UeMoveComp;
			if (ueMoveComp != null && ueMoveComp.IsRotating())
			{
				this.UeMoveComp.StopRotate(EKuroSceneItemStopRotateMethod.KeepCurrent, true);
			}
		}

		// Token: 0x0602FFEC RID: 196588 RVA: 0x00B9CE4C File Offset: 0x00B9B04C
		protected override void OnEnable()
		{
			if (!this.IsAllActorsLoaded)
			{
				this.SetAndLoadActors();
			}
			if (!this.IsRotationDataInit && this.IsAllCurvesLoaded && this.IsAllActorsLoaded)
			{
				this.InitRotationData();
			}
		}

		// Token: 0x0602FFED RID: 196589 RVA: 0x00B9CE7C File Offset: 0x00B9B07C
		private void SetAndLoadCurves()
		{
			this.IsAllCurvesLoaded = true;
			foreach (KeyValuePair<int, IStateRotationConfig> keyValuePair in this.StateRotationConfigMap)
			{
				int num;
				IStateRotationConfig stateRotationConfig;
				keyValuePair.Deconstruct(out num, out stateRotationConfig);
				IStateRotationConfig stateRotationConfig2 = stateRotationConfig;
				List<IRotationConfig> list = (stateRotationConfig2.RotationConfig != null && stateRotationConfig2.RotationConfig.Count > 0) ? stateRotationConfig2.RotationConfig : null;
				List<IKeyRotatorConfig> list2 = (stateRotationConfig2.KeyRotatorConfig != null && stateRotationConfig2.KeyRotatorConfig.Count > 0) ? stateRotationConfig2.KeyRotatorConfig : null;
				IEnumerable<ICommonRotationConfig> enumerable;
				if (list != null)
				{
					enumerable = list;
				}
				else
				{
					enumerable = list2;
				}
				if (enumerable != null)
				{
					foreach (ICommonRotationConfig commonRotationConfig in enumerable)
					{
						if (!string.IsNullOrEmpty(commonRotationConfig.Curve))
						{
							if (this.CurveMap == null)
							{
								this.CurveMap = new Dictionary<string, UCurveFloat>();
							}
							if (!this.CurveMap.ContainsKey(commonRotationConfig.Curve))
							{
								UCurveFloat loadedAsset = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UCurveFloat>(commonRotationConfig.Curve);
								if (loadedAsset != null)
								{
									this.CurveMap[commonRotationConfig.Curve] = loadedAsset;
								}
								else
								{
									this.CurveMap[commonRotationConfig.Curve] = null;
									this.IsAllCurvesLoaded = false;
								}
							}
						}
					}
				}
			}
			if (!this.IsAllCurvesLoaded)
			{
				if (this.LoadCurveHandleMap == null)
				{
					this.LoadCurveHandleMap = new Dictionary<string, int>();
				}
				foreach (KeyValuePair<string, UCurveFloat> keyValuePair2 in this.CurveMap)
				{
					string text;
					UCurveFloat ucurveFloat;
					keyValuePair2.Deconstruct(out text, out ucurveFloat);
					string text2 = text;
					if (ucurveFloat == null)
					{
						int value = Singleton<ResourceSystem>.Instance.LoadAsync<UCurveFloat>(text2, new Action<UCurveFloat, string>(this.SetupSingleCurve), 100, "js_undefined");
						this.LoadCurveHandleMap[text2] = value;
					}
				}
			}
		}

		// Token: 0x0602FFEE RID: 196590 RVA: 0x00B9D0B8 File Offset: 0x00B9B2B8
		private void SetAndLoadActors()
		{
			this.IsAllActorsLoaded = false;
			foreach (IStateRotationConfig stateRotationConfig in this.StateRotationConfigMap.Values)
			{
				string key = stateRotationConfig.RotatePoint ?? "";
				if (this.RotatePointMap == null)
				{
					this.RotatePointMap = new Dictionary<string, AActor>();
				}
				if (!this.RotatePointMap.ContainsKey(key))
				{
					this.RotatePointMap[key] = null;
				}
			}
			if (!Singleton<EventSystem>.Instance.HasWithTarget(base.Entity, EEventName.OnSceneInteractionLoadCompleted, new Action(this.SetupAllActors)))
			{
				Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnSceneInteractionLoadCompleted, new Action(this.SetupAllActors));
			}
			if (this.ActorComp.GetIsSceneInteractionLoadCompleted())
			{
				this.SetupAllActors();
			}
		}

		// Token: 0x0602FFEF RID: 196591 RVA: 0x00B9D1A4 File Offset: 0x00B9B3A4
		protected override bool OnEnd()
		{
			if (Singleton<EventSystem>.Instance.HasWithTarget<int, bool>(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.OnSceneItemStateChange)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<int, bool>(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.OnSceneItemStateChange));
			}
			if (Singleton<EventSystem>.Instance.HasWithTarget(base.Entity, EEventName.OnSceneInteractionLoadCompleted, new Action(this.SetupAllActors)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnSceneInteractionLoadCompleted, new Action(this.SetupAllActors));
			}
			if (this.LoadCurveHandleMap != null)
			{
				foreach (KeyValuePair<string, int> keyValuePair in this.LoadCurveHandleMap)
				{
					string text;
					int num;
					keyValuePair.Deconstruct(out text, out num);
					int num2 = num;
					if (num2 != 0)
					{
						Singleton<ResourceSystem>.Instance.CancelAsyncLoad(num2);
					}
				}
			}
			return true;
		}

		// Token: 0x0602FFF0 RID: 196592 RVA: 0x00B9D2A0 File Offset: 0x00B9B4A0
		[NullableContext(1)]
		private unsafe void SetupSingleCurve([Nullable(2)] UCurveFloat asset, string path)
		{
			this.LoadCurveHandleMap.Remove(path);
			if (asset == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "[SceneItemRotatorComponent] 曲线加载失败，请检查实体配置";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CurvePath", path);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
				string item = "PbDataId";
				CreatureDataComponent creatureDataComp = this.CreatureDataComp;
				ptr = new ValueTuple<string, object>(item, (creatureDataComp != null) ? new int?(creatureDataComp.GetPbDataId()) : null);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			this.CurveMap[path] = asset;
			if (this.LoadCurveHandleMap.Count > 0)
			{
				return;
			}
			foreach (KeyValuePair<string, UCurveFloat> keyValuePair in this.CurveMap)
			{
				string text;
				UCurveFloat ucurveFloat;
				keyValuePair.Deconstruct(out text, out ucurveFloat);
				if (ucurveFloat == null)
				{
					return;
				}
			}
			this.IsAllCurvesLoaded = true;
			if (this.IsAllActorsLoaded)
			{
				this.InitRotationData();
			}
		}

		// Token: 0x0602FFF1 RID: 196593 RVA: 0x00B9D3B8 File Offset: 0x00B9B5B8
		private unsafe void SetupAllActors()
		{
			AActor interactionMainActor = this.ActorComp.GetInteractionMainActor();
			if (interactionMainActor == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "[SceneItemRotatorComponent] 找不到对应的场景交互物MainActor，请检查实体配置和预制体";
				string item = "PbDataId";
				CreatureDataComponent creatureDataComp = this.CreatureDataComp;
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (creatureDataComp != null) ? new int?(creatureDataComp.GetPbDataId()) : null);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			foreach (KeyValuePair<string, AActor> keyValuePair in (this.RotatePointMap ?? new Dictionary<string, AActor>()))
			{
				string text;
				AActor aactor;
				keyValuePair.Deconstruct(out text, out aactor);
				string text2 = text;
				AActor aactor2;
				if (!(text2 == ""))
				{
					SceneItemActorComponent actorComp = this.ActorComp;
					aactor2 = ((actorComp != null) ? actorComp.GetActorInSceneInteraction(text2) : null);
				}
				else
				{
					aactor2 = interactionMainActor;
				}
				AActor aactor3 = aactor2;
				if (aactor3 == null)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.SceneItem;
					ELogAuthor author2 = ELogAuthor.ZYL;
					string message2 = "[SceneItemRotatorComponent] 找不到对应的旋转Actor，请检查实体配置和预制体";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActorKey", text2);
					ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
					string item2 = "PbDataId";
					CreatureDataComponent creatureDataComp2 = this.CreatureDataComp;
					ptr = new ValueTuple<string, object>(item2, (creatureDataComp2 != null) ? new int?(creatureDataComp2.GetPbDataId()) : null);
					instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return;
				}
				this.RotatePointMap[text2] = aactor3;
			}
			if (this.ActorBornRotationMap == null)
			{
				this.ActorBornRotationMap = new Dictionary<string, Rotator>();
				foreach (KeyValuePair<string, AActor> keyValuePair in (this.RotatePointMap ?? new Dictionary<string, AActor>()))
				{
					string text;
					AActor aactor;
					keyValuePair.Deconstruct(out text, out aactor);
					string key = text;
					AActor aactor4 = aactor;
					this.ActorBornRotationMap[key] = Rotator.Create(aactor4.RootComponent.D_GetRelativeTransform().Rotator());
				}
			}
			this.IsAllActorsLoaded = true;
			if (this.IsAllCurvesLoaded)
			{
				this.InitRotationData();
			}
		}

		// Token: 0x0602FFF2 RID: 196594 RVA: 0x00B9D5E4 File Offset: 0x00B9B7E4
		private void InitRotationData()
		{
			if (this.IsRotationDataInit)
			{
				return;
			}
			if (!this.IsAllCurvesLoaded || !this.IsAllActorsLoaded)
			{
				return;
			}
			int newStateId = 0;
			foreach (KeyValuePair<int, IStateRotationConfig> keyValuePair in this.StateRotationConfigMap)
			{
				int num;
				IStateRotationConfig stateRotationConfig;
				keyValuePair.Deconstruct(out num, out stateRotationConfig);
				int num2 = num;
				if (this.TagComp.HasTag(num2))
				{
					newStateId = num2;
					break;
				}
			}
			if (!Singleton<EventSystem>.Instance.HasWithTarget<int, bool>(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.OnSceneItemStateChange)))
			{
				Singleton<EventSystem>.Instance.AddWithTarget<int, bool>(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.OnSceneItemStateChange));
			}
			this.IsRotationDataInit = true;
			this.SwitchToState(newStateId, true);
		}

		// Token: 0x0602FFF3 RID: 196595 RVA: 0x00B9D6C0 File Offset: 0x00B9B8C0
		private void OnSceneItemStateChange(int stateId, bool isReady)
		{
			if (!this.IsRotationDataInit)
			{
				return;
			}
			this.SwitchToState(stateId, false);
		}

		// Token: 0x0602FFF4 RID: 196596 RVA: 0x00B9D6D4 File Offset: 0x00B9B8D4
		private unsafe void SwitchToState(int newStateId, bool isInit)
		{
			if (!this.IsRotationDataInit)
			{
				return;
			}
			if (!isInit && this.CurStateTagId == newStateId)
			{
				return;
			}
			IStateRotationConfig stateRotationConfig;
			this.StateRotationConfigMap.TryGetValue(this.CurStateTagId, out stateRotationConfig);
			IStateRotationConfig stateRotationConfig2;
			this.StateRotationConfigMap.TryGetValue(newStateId, out stateRotationConfig2);
			if (stateRotationConfig != null && stateRotationConfig.KeepLastRotation.GetValueOrDefault() && stateRotationConfig2 == null && this.UeMoveComp.IsRotating())
			{
				this.PauseRotateStateId = this.CurStateTagId;
				this.CurStateTagId = newStateId;
				this.UeMoveComp.SetTickingRotateEnable(false);
				return;
			}
			if (stateRotationConfig2 != null && stateRotationConfig2.KeepLastRotation.GetValueOrDefault() && newStateId == this.PauseRotateStateId && stateRotationConfig == null && !this.UeMoveComp.IsRotating())
			{
				this.PauseRotateStateId = 0;
				this.CurStateTagId = newStateId;
				this.UeMoveComp.SetTickingRotateEnable(true);
				return;
			}
			bool flag = newStateId != 0 && this.StateRotationConfigMap.ContainsKey(newStateId);
			if (this.UeMoveComp.IsRotating())
			{
				this.UeMoveComp.StopRotate(EKuroSceneItemStopRotateMethod.KeepCurrent, !flag);
			}
			this.CurStateTagId = newStateId;
			if (flag && !this.UeMoveComp.IsRotating())
			{
				IStateRotationConfig stateRotationConfig3 = this.StateRotationConfigMap[newStateId];
				AActor aactor = (!string.IsNullOrEmpty(stateRotationConfig3.RotatePoint)) ? this.RotatePointMap.GetValueOrDefault(stateRotationConfig3.RotatePoint) : this.ActorComp.GetInteractionMainActor();
				if (!this.UeMoveComp.InitRotationData(aactor, stateRotationConfig3.IsLoop))
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.SceneItem;
					ELogAuthor author = ELogAuthor.ZYL;
					string message = "[SceneItemRotatorComponent] 初始化旋转数据失败";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("StateId", newStateId);
					ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
					string item = "PbDataId";
					CreatureDataComponent creatureDataComp = this.CreatureDataComp;
					ptr = new ValueTuple<string, object>(item, (creatureDataComp != null) ? new int?(creatureDataComp.GetPbDataId()) : null);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return;
				}
				Rotator inB = this.ActorBornRotationMap[stateRotationConfig3.RotatePoint ?? ""];
				Rotator inR = Rotator.Create(aactor.RootComponent.D_GetRelativeTransform().Rotator());
				List<IRotationConfig> rotationConfig = stateRotationConfig3.RotationConfig;
				List<IRotationConfig> list = (rotationConfig != null && rotationConfig.Count > 0) ? stateRotationConfig3.RotationConfig : null;
				List<IKeyRotatorConfig> keyRotatorConfig = stateRotationConfig3.KeyRotatorConfig;
				List<IKeyRotatorConfig> list2 = (keyRotatorConfig != null && keyRotatorConfig.Count > 0) ? stateRotationConfig3.KeyRotatorConfig : null;
				int? num = (list != null) ? new int?(list.Count) : ((list2 != null) ? new int?(list2.Count) : null);
				if (num == null)
				{
					return;
				}
				int num2 = 0;
				for (;;)
				{
					int num3 = num2;
					int? num4 = num;
					if (!(num3 < num4.GetValueOrDefault() & num4 != null))
					{
						break;
					}
					ICommonRotationConfig commonRotationConfig = null;
					Rotator rotator = Rotator.Create();
					FRotator frotator;
					if (list != null)
					{
						IRotationConfig rotationConfig2 = list[num2];
						commonRotationConfig = rotationConfig2;
						Vector vector = Vector.Create((double)rotationConfig2.Axis.X.GetValueOrDefault(), (double)rotationConfig2.Axis.Y.GetValueOrDefault(), (double)rotationConfig2.Axis.Z.GetValueOrDefault());
						Rotator rotator2 = rotator;
						frotator = UKismetMathLibrary.D_RotatorFromAxisAndAngle(vector.ToUeVector(false), rotationConfig2.Angle);
						rotator2.FromUeRotator(frotator);
					}
					else if (list2 != null)
					{
						IKeyRotatorConfig keyRotatorConfig2 = list2[num2];
						commonRotationConfig = keyRotatorConfig2;
						rotator.Set(keyRotatorConfig2.KeyRotator.Y.GetValueOrDefault(), keyRotatorConfig2.KeyRotator.Z.GetValueOrDefault(), keyRotatorConfig2.KeyRotator.X.GetValueOrDefault());
					}
					UCurveFloat rotateCurve = (!string.IsNullOrEmpty(commonRotationConfig.Curve)) ? this.CurveMap.GetValueOrDefault(commonRotationConfig.Curve) : null;
					Rotator rotator3 = null;
					Rotator rotator4 = null;
					if (commonRotationConfig.Type == ERotationType.Relative)
					{
						rotator3 = Rotator.Create(inR);
						Rotator inB2 = rotator;
						rotator4 = Rotator.Create(rotator3).AdditionEqual(inB2);
						inR = rotator4;
					}
					else if (commonRotationConfig.Type == ERotationType.Absolute)
					{
						rotator3 = Rotator.Create(inR);
						rotator4 = Rotator.Create(rotator).AdditionEqual(inB);
						inR = rotator4;
					}
					if (rotator3 == null || rotator4 == null)
					{
						goto IL_450;
					}
					UKuroSceneItemMoveComponent ueMoveComp = this.UeMoveComp;
					frotator = rotator3.ToUeRotator();
					FRotator frotator2 = rotator4.ToUeRotator();
					if (!ueMoveComp.AddRotationStep(frotator, frotator2, commonRotationConfig.Time, commonRotationConfig.Cd.GetValueOrDefault(), rotateCurve))
					{
						goto IL_450;
					}
					IL_4EA:
					num2++;
					continue;
					IL_450:
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.SceneItem;
					ELogAuthor author2 = ELogAuthor.ZYL;
					string message2 = "[SceneItemRotatorComponent] 添加旋转步骤失败";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("StateId", newStateId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("StepIndex", num2);
					ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2);
					string item2 = "PbDataId";
					CreatureDataComponent creatureDataComp2 = this.CreatureDataComp;
					ptr2 = new ValueTuple<string, object>(item2, (creatureDataComp2 != null) ? new int?(creatureDataComp2.GetPbDataId()) : null);
					instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
					goto IL_4EA;
				}
				if (!this.UeMoveComp.StartRotate())
				{
					return;
				}
				this.UeMoveComp.OnRotateStopCallback.Add(new Action(this.OnRotateStop));
			}
		}

		// Token: 0x0602FFF5 RID: 196597 RVA: 0x00B9DC17 File Offset: 0x00B9BE17
		private void OnRotateStop()
		{
			UKuroSceneItemMoveComponent ueMoveComp = this.UeMoveComp;
			if (ueMoveComp != null)
			{
				ueMoveComp.OnRotateStopCallback.Remove(new Action(this.OnRotateStop));
			}
			Singleton<EventSystem>.Instance.EmitWithTarget(base.Entity, EEventName.OnSceneItemRotateStopped);
		}

		// Token: 0x0602FFF6 RID: 196598 RVA: 0x00B9DC54 File Offset: 0x00B9BE54
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneItemRotatorComponent sceneItemRotatorComponent = (SceneItemRotatorComponent)componentTemplate;
			if (base.CanResetComponentProperty("CreatureDataComp"))
			{
				if (sceneItemRotatorComponent.CreatureDataComp == null)
				{
					this.CreatureDataComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComp), "CreatureDataComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (sceneItemRotatorComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("StateComp"))
			{
				if (sceneItemRotatorComponent.StateComp == null)
				{
					this.StateComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemStateComponent>(this.StateComp), "StateComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TagComp"))
			{
				if (sceneItemRotatorComponent.TagComp == null)
				{
					this.TagComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<LevelTagComponent>(this.TagComp), "TagComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("UeTickComp"))
			{
				if (sceneItemRotatorComponent.UeTickComp == null)
				{
					this.UeTickComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UeSceneItemMoveTickManagerComponent>(this.UeTickComp), "UeTickComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("UeMoveComp"))
			{
				if (sceneItemRotatorComponent.UeMoveComp == null)
				{
					this.UeMoveComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UKuroSceneItemMoveComponent>(this.UeMoveComp), "UeMoveComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("StateRotationConfigMap"))
			{
				if (sceneItemRotatorComponent.StateRotationConfigMap == null)
				{
					this.StateRotationConfigMap = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, IStateRotationConfig>>(this.StateRotationConfigMap), "StateRotationConfigMap"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CurveMap"))
			{
				if (sceneItemRotatorComponent.CurveMap == null)
				{
					this.CurveMap = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, UCurveFloat>>(this.CurveMap), "CurveMap"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("RotatePointMap"))
			{
				if (sceneItemRotatorComponent.RotatePointMap == null)
				{
					this.RotatePointMap = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, AActor>>(this.RotatePointMap), "RotatePointMap"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("LoadCurveHandleMap"))
			{
				if (sceneItemRotatorComponent.LoadCurveHandleMap == null)
				{
					this.LoadCurveHandleMap = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, int>>(this.LoadCurveHandleMap), "LoadCurveHandleMap"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("IsAllCurvesLoaded"))
			{
				this.IsAllCurvesLoaded = sceneItemRotatorComponent.IsAllCurvesLoaded;
			}
			if (base.CanResetComponentProperty("IsAllActorsLoaded"))
			{
				this.IsAllActorsLoaded = sceneItemRotatorComponent.IsAllActorsLoaded;
			}
			if (base.CanResetComponentProperty("IsRotationDataInit"))
			{
				this.IsRotationDataInit = sceneItemRotatorComponent.IsRotationDataInit;
			}
			if (base.CanResetComponentProperty("CurStateTagId"))
			{
				this.CurStateTagId = sceneItemRotatorComponent.CurStateTagId;
			}
			if (base.CanResetComponentProperty("ActorBornRotationMap"))
			{
				if (sceneItemRotatorComponent.ActorBornRotationMap == null)
				{
					this.ActorBornRotationMap = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, Rotator>>(this.ActorBornRotationMap), "ActorBornRotationMap"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("PauseRotateStateId"))
			{
				this.PauseRotateStateId = sceneItemRotatorComponent.PauseRotateStateId;
			}
			if (base.CanResetComponentProperty("NeedTickOutside"))
			{
				this.NeedTickOutside = sceneItemRotatorComponent.NeedTickOutside;
			}
			return true;
		}

		// Token: 0x0401B8C7 RID: 112839
		private CreatureDataComponent CreatureDataComp;

		// Token: 0x0401B8C8 RID: 112840
		private SceneItemActorComponent ActorComp;

		// Token: 0x0401B8C9 RID: 112841
		private SceneItemStateComponent StateComp;

		// Token: 0x0401B8CA RID: 112842
		private LevelTagComponent TagComp;

		// Token: 0x0401B8CB RID: 112843
		private UeSceneItemMoveTickManagerComponent UeTickComp;

		// Token: 0x0401B8CC RID: 112844
		private UKuroSceneItemMoveComponent UeMoveComp;

		// Token: 0x0401B8CD RID: 112845
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<int, IStateRotationConfig> StateRotationConfigMap;

		// Token: 0x0401B8CE RID: 112846
		[Nullable(new byte[]
		{
			2,
			1,
			2
		})]
		private Dictionary<string, UCurveFloat> CurveMap;

		// Token: 0x0401B8CF RID: 112847
		[Nullable(new byte[]
		{
			2,
			1,
			2
		})]
		private Dictionary<string, AActor> RotatePointMap;

		// Token: 0x0401B8D0 RID: 112848
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<string, int> LoadCurveHandleMap;

		// Token: 0x0401B8D1 RID: 112849
		private bool IsAllCurvesLoaded;

		// Token: 0x0401B8D2 RID: 112850
		private bool IsAllActorsLoaded;

		// Token: 0x0401B8D3 RID: 112851
		private bool IsRotationDataInit;

		// Token: 0x0401B8D4 RID: 112852
		private int CurStateTagId;

		// Token: 0x0401B8D5 RID: 112853
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Dictionary<string, Rotator> ActorBornRotationMap;

		// Token: 0x0401B8D6 RID: 112854
		private int PauseRotateStateId;

		// Token: 0x0401B8D7 RID: 112855
		private bool NeedTickOutside;
	}
}
