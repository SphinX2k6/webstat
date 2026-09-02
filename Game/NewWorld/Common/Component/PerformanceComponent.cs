using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Common.Struct;
using AkiClient.Game.Aki.Data.Entity.Struct;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.Enum;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.NewWorld.Pawn.Component;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Common.Component
{
	// Token: 0x020048C7 RID: 18631
	[NullableContext(1)]
	[Nullable(0)]
	public class PerformanceComponent : EntityComponent
	{
		// Token: 0x06030967 RID: 199015 RVA: 0x00BF2C0C File Offset: 0x00BF0E0C
		public void SetIsSceneInteractionJumpToEnd(bool value)
		{
			this.IsSceneInteractionJumpToEnd = value;
		}

		// Token: 0x06030968 RID: 199016 RVA: 0x00BF2C18 File Offset: 0x00BF0E18
		protected override bool OnStart()
		{
			this.CommonEffectTimerId = null;
			this.LevelTagComponent = base.Entity.CheckGetComponent<LevelTagComponent>();
			this.ActorComponent = base.Entity.GetComponent<BaseActorComponent>();
			this.ModelConfig = this.ActorComponent.CreatureData.GetModelConfig();
			this.IsSceneInteractionJumpToEnd = false;
			return true;
		}

		// Token: 0x06030969 RID: 199017 RVA: 0x00BF2C6C File Offset: 0x00BF0E6C
		protected override void OnActivate()
		{
			if (this.ActorComponent.SkeletalMesh == null)
			{
				this.LoadAndChangeStaticMesh();
			}
			this.InitSceneInteractionLevel();
			this.SceneInteractionEffectMap = new Dictionary<int, ESceneInteractionEffect>();
			SceneItemActorComponent sceneItemActorComponent = this.ActorComponent as SceneItemActorComponent;
			if (sceneItemActorComponent != null && !sceneItemActorComponent.GetIsSceneInteractionLoadCompleted())
			{
				Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnSceneInteractionLoadCompleted, new Action(this.OnSceneInteractionLoadCompleted));
			}
			this.InitCommonEffect();
			if (this.CheckAndUpdateCommonEffectTag())
			{
				this.SetCommonEffectParam();
			}
			this.OwnEffectMap = new Dictionary<int, int>();
			this.InitOwnEffects();
			Singleton<EventSystem>.Instance.AddWithTarget<IReadOnlyList<int>, IReadOnlyList<int>>(base.Entity, EEventName.OnLevelTagChanged, new Action<IReadOnlyList<int>, IReadOnlyList<int>>(this.CheckGameplayTagChange2));
		}

		// Token: 0x0603096A RID: 199018 RVA: 0x00BF2D20 File Offset: 0x00BF0F20
		protected override bool OnEnd()
		{
			if (Singleton<EventSystem>.Instance.HasWithTarget<IReadOnlyList<int>, IReadOnlyList<int>>(base.Entity, EEventName.OnLevelTagChanged, new Action<IReadOnlyList<int>, IReadOnlyList<int>>(this.CheckGameplayTagChange2)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<IReadOnlyList<int>, IReadOnlyList<int>>(base.Entity, EEventName.OnLevelTagChanged, new Action<IReadOnlyList<int>, IReadOnlyList<int>>(this.CheckGameplayTagChange2));
			}
			if (this.ActorComponent is SceneItemActorComponent && Singleton<EventSystem>.Instance.HasWithTarget(base.Entity, EEventName.OnSceneInteractionLoadCompleted, new Action(this.OnSceneInteractionLoadCompleted)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnSceneInteractionLoadCompleted, new Action(this.OnSceneInteractionLoadCompleted));
			}
			return true;
		}

		// Token: 0x0603096B RID: 199019 RVA: 0x00BF2DC8 File Offset: 0x00BF0FC8
		protected override bool OnClear()
		{
			if (this.SceneInteractionEffectMap != null)
			{
				this.SceneInteractionEffectMap.Clear();
				this.SceneInteractionEffectMap = null;
			}
			this.DisposeCommonEffectTimer();
			this.OnChangeCommonEffectFinished = null;
			if (this.OwnEffectMap != null)
			{
				foreach (int handle in this.OwnEffectMap.Values)
				{
					Singleton<EffectSystem>.Instance.StopEffectById(handle, "[PerformanceComponent.OnClear 1]", true, null);
				}
				this.OwnEffectMap.Clear();
				this.OwnEffectMap = null;
			}
			if (this.CommonEffect != 0)
			{
				this.CommonEffectNiagaraComp = null;
				Singleton<EffectSystem>.Instance.StopEffectById(this.CommonEffect, "[PerformanceComponent.OnClear 2]", false, null);
				this.CommonEffect = 0;
			}
			if (this.LastChangeEffect != 0)
			{
				Singleton<EffectSystem>.Instance.RemoveFinishCallback(this.LastChangeEffect, this.OnChangeEffectFinished);
				Singleton<EffectSystem>.Instance.StopEffectById(this.LastChangeEffect, "[PerformanceComponent.OnClear 3]", true, null);
				this.LastChangeEffect = 0;
			}
			this.OnChangeEffectFinished = null;
			return true;
		}

		// Token: 0x0603096C RID: 199020 RVA: 0x00BF2F00 File Offset: 0x00BF1100
		protected override void OnEnable()
		{
			Entity entity = base.Entity;
			if (entity != null && entity.IsInit)
			{
				this.SetPerformanceVisible(this.ActorComponent.CreatureData.GetVisible());
			}
		}

		// Token: 0x0603096D RID: 199021 RVA: 0x00BF2F2C File Offset: 0x00BF112C
		protected override void OnDisable(string reason)
		{
			this.SetPerformanceVisible(false);
		}

		// Token: 0x0603096E RID: 199022 RVA: 0x00BF2F38 File Offset: 0x00BF1138
		protected override void OnChangeTimeDilation(float timeDilation)
		{
			PawnTimeScaleComponent component = base.Entity.GetComponent<PawnTimeScaleComponent>();
			float num = (component != null) ? component.CurrentTimeScale : 1f;
			float timeScale = timeDilation * num;
			if (Singleton<EffectSystem>.Instance.IsValid(this.CommonEffect))
			{
				Singleton<EffectSystem>.Instance.SetTimeScale(this.CommonEffect, timeScale, false);
			}
			if (Singleton<EffectSystem>.Instance.IsValid(this.LastChangeEffect))
			{
				Singleton<EffectSystem>.Instance.SetTimeScale(this.LastChangeEffect, timeScale, false);
			}
			Dictionary<int, int> ownEffectMap = this.OwnEffectMap;
			if (ownEffectMap != null && ownEffectMap.Count > 0)
			{
				foreach (int id in this.OwnEffectMap.Values)
				{
					if (Singleton<EffectSystem>.Instance.IsValid(id))
					{
						Singleton<EffectSystem>.Instance.SetTimeScale(id, timeScale, false);
					}
				}
			}
		}

		// Token: 0x0603096F RID: 199023 RVA: 0x00BF3024 File Offset: 0x00BF1224
		private void CheckGameplayTagChange2(IReadOnlyList<int> added, IReadOnlyList<int> removed)
		{
			if (this.ActorComponent.SkeletalMesh == null)
			{
				this.LoadAndChangeStaticMesh();
			}
			if (this.CheckAndUpdateCommonEffectTag())
			{
				this.ChangeCommonEffectParam();
			}
			this.ChangeOwnEffects(added, removed);
			this.ChangeSceneInteractionLevel();
			this.ChangeSceneInteractionEffects(added, removed);
			this.ChangeSceneInteractionExtraEffects(added, removed);
			SceneItemActorComponent sceneItemActorComponent = this.ActorComponent as SceneItemActorComponent;
			if (sceneItemActorComponent != null)
			{
				sceneItemActorComponent.TryRefreshShowActor();
			}
		}

		// Token: 0x06030970 RID: 199024 RVA: 0x00BF3085 File Offset: 0x00BF1285
		private void InitSceneInteractionLevel()
		{
			this.UpdateSceneInteractionLevel(true);
		}

		// Token: 0x06030971 RID: 199025 RVA: 0x00BF308E File Offset: 0x00BF128E
		private void ChangeSceneInteractionLevel()
		{
			this.UpdateSceneInteractionLevel(false);
		}

		// Token: 0x06030972 RID: 199026 RVA: 0x00BF3098 File Offset: 0x00BF1298
		private void UpdateSceneInteractionLevel(bool needInit)
		{
			int? resTag = this.GetResTag<EKuroSceneInteractionState>(this.ModelConfig.场景交互物状态列表);
			if (resTag != null)
			{
				int? num = resTag;
				int curSceneInteractionLevelTagId = this.CurSceneInteractionLevelTagId;
				if (num.GetValueOrDefault() == curSceneInteractionLevelTagId & num != null)
				{
					return;
				}
				this.CurSceneInteractionLevelTagId = resTag.Value;
			}
			else
			{
				int num2 = GameplayTagDefine.EGameplayTagId["物体.表现.初始状态"];
				FGameplayTag? gameplayTagById = GameplayTagUtils.GetGameplayTagById(num2);
				if (num2 == this.CurSceneInteractionLevelTagId || !this.ModelConfig.场景交互物状态列表.Contains(gameplayTagById.Value))
				{
					SceneItemActorComponent sceneItemActorComponent = this.ActorComponent as SceneItemActorComponent;
					if (sceneItemActorComponent != null && sceneItemActorComponent.GetSceneInteractionLevelHandleId() == -1)
					{
						sceneItemActorComponent.SetIsSceneInteractionLoadCompleted(true);
					}
					return;
				}
				this.CurSceneInteractionLevelTagId = num2;
			}
			SceneItemActorComponent sceneItemActorComponent2 = this.ActorComponent as SceneItemActorComponent;
			if (sceneItemActorComponent2 != null)
			{
				EKuroSceneInteractionState? ekuroSceneInteractionState = null;
				if (this.CurSceneInteractionLevelTagId == GameplayTagDefine.EGameplayTagId["物体.表现.隐匿"])
				{
					ekuroSceneInteractionState = new EKuroSceneInteractionState?(EKuroSceneInteractionState.ConcealedState);
				}
				else
				{
					FGameplayTag? gameplayTagById2 = GameplayTagUtils.GetGameplayTagById(this.CurSceneInteractionLevelTagId);
					EKuroSceneInteractionState ekuroSceneInteractionState2;
					ekuroSceneInteractionState = new EKuroSceneInteractionState?(this.ModelConfig.场景交互物状态列表.TryGetValue(gameplayTagById2.Value, out ekuroSceneInteractionState2) ? ekuroSceneInteractionState2 : EKuroSceneInteractionState.Error);
				}
				if (needInit)
				{
					bool isInitShow = false;
					if (this.CurSceneInteractionLevelTagId == GameplayTagDefine.EGameplayTagId["关卡.Common.表现.出生"])
					{
						isInitShow = true;
					}
					sceneItemActorComponent2.LoadSceneInteractionLevel(ekuroSceneInteractionState.Value, isInitShow);
					return;
				}
				sceneItemActorComponent2.SwitchToState(ekuroSceneInteractionState.Value, !this.IsSceneInteractionJumpToEnd, this.IsSceneInteractionJumpToEnd);
			}
		}

		// Token: 0x06030973 RID: 199027 RVA: 0x00BF3214 File Offset: 0x00BF1414
		private void InitSceneInteractionEffects()
		{
			if (this.LevelTagComponent == null)
			{
				return;
			}
			SceneItemActorComponent sceneItemActorComponent = this.ActorComponent as SceneItemActorComponent;
			if (sceneItemActorComponent != null && this.SceneInteractionEffectMap != null && this.SceneInteractionEffectMap.Count > 0)
			{
				foreach (ESceneInteractionEffect effectKey in this.SceneInteractionEffectMap.Values)
				{
					if (sceneItemActorComponent != null)
					{
						sceneItemActorComponent.EndSceneInteractionEffect(effectKey);
					}
					if (sceneItemActorComponent != null)
					{
						sceneItemActorComponent.PlaySceneInteractionEndEffect(effectKey);
					}
				}
				Dictionary<int, ESceneInteractionEffect> sceneInteractionEffectMap = this.SceneInteractionEffectMap;
				if (sceneInteractionEffectMap != null)
				{
					sceneInteractionEffectMap.Clear();
				}
			}
			foreach (int tagId in this.LevelTagComponent.GetTagIds())
			{
				if (this.CheckAndAddSceneInteractionByTag(tagId))
				{
					break;
				}
			}
		}

		// Token: 0x06030974 RID: 199028 RVA: 0x00BF3300 File Offset: 0x00BF1500
		private void InitSceneInteractionExtraEffects()
		{
			if (this.LevelTagComponent == null)
			{
				return;
			}
			foreach (int tagId in this.LevelTagComponent.GetTagIds())
			{
				FGameplayTag? gameplayTagById = GameplayTagUtils.GetGameplayTagById(tagId);
				SceneItemActorComponent sceneItemActorComponent = this.ActorComponent as SceneItemActorComponent;
				if (sceneItemActorComponent != null && gameplayTagById != null)
				{
					sceneItemActorComponent.PlayExtraEffect(gameplayTagById.Value, true);
				}
			}
		}

		// Token: 0x06030975 RID: 199029 RVA: 0x00BF3380 File Offset: 0x00BF1580
		private bool CheckAndAddSceneInteractionByTag(int tagId)
		{
			if (this.SceneInteractionEffectMap.ContainsKey(tagId))
			{
				return false;
			}
			FGameplayTag? gameplayTagById = GameplayTagUtils.GetGameplayTagById(tagId);
			TEnumAsByte<ESceneInteractionEffect> value;
			if (!this.ModelConfig.场景交互物特效列表.TryGetValue(gameplayTagById.Value, out value))
			{
				return false;
			}
			SceneItemActorComponent sceneItemActorComponent = this.ActorComponent as SceneItemActorComponent;
			if (sceneItemActorComponent != null)
			{
				sceneItemActorComponent.PlaySceneInteractionEffect(value);
				this.SceneInteractionEffectMap.Add(tagId, value);
				return true;
			}
			return false;
		}

		// Token: 0x06030976 RID: 199030 RVA: 0x00BF33F4 File Offset: 0x00BF15F4
		private void ChangeSceneInteractionEffects(IReadOnlyList<int> added, IReadOnlyList<int> removed)
		{
			foreach (int key in removed)
			{
				if (this.SceneInteractionEffectMap.ContainsKey(key))
				{
					ESceneInteractionEffect effectKey = this.SceneInteractionEffectMap[key];
					this.SceneInteractionEffectMap.Remove(key);
					SceneItemActorComponent sceneItemActorComponent = this.ActorComponent as SceneItemActorComponent;
					if (sceneItemActorComponent != null)
					{
						sceneItemActorComponent.EndSceneInteractionEffect(effectKey);
						sceneItemActorComponent.PlaySceneInteractionEndEffect(effectKey);
					}
				}
			}
			foreach (int tagId in added)
			{
				this.CheckAndAddSceneInteractionByTag(tagId);
			}
		}

		// Token: 0x06030977 RID: 199031 RVA: 0x00BF34B4 File Offset: 0x00BF16B4
		private void ChangeSceneInteractionExtraEffects(IReadOnlyList<int> added, IReadOnlyList<int> removed)
		{
			foreach (int tagId in removed)
			{
				FGameplayTag? gameplayTagById = GameplayTagUtils.GetGameplayTagById(tagId);
				SceneItemActorComponent sceneItemActorComponent = this.ActorComponent as SceneItemActorComponent;
				if (sceneItemActorComponent != null && gameplayTagById != null)
				{
					sceneItemActorComponent.StopExtraEffect(gameplayTagById.Value);
				}
			}
			foreach (int tagId2 in added)
			{
				FGameplayTag? gameplayTagById2 = GameplayTagUtils.GetGameplayTagById(tagId2);
				SceneItemActorComponent sceneItemActorComponent2 = this.ActorComponent as SceneItemActorComponent;
				if (sceneItemActorComponent2 != null && gameplayTagById2 != null)
				{
					sceneItemActorComponent2.PlayExtraEffect(gameplayTagById2.Value, false);
				}
			}
		}

		// Token: 0x06030978 RID: 199032 RVA: 0x00BF3580 File Offset: 0x00BF1780
		public void LoadAndChangeStaticMesh()
		{
			if (this.ActorComponent.SkeletalMesh != null)
			{
				return;
			}
			int? resTag = this.GetResTag<FSoftObjectPath>(this.ModelConfig.静态网格体列表);
			if (resTag != null)
			{
				int? num = resTag;
				int curStaticMeshTagId = this.CurStaticMeshTagId;
				if (num.GetValueOrDefault() == curStaticMeshTagId & num != null)
				{
					return;
				}
				this.CurStaticMeshTagId = resTag.Value;
			}
			else
			{
				int num2 = GameplayTagDefine.EGameplayTagId["物体.表现.初始状态"];
				FGameplayTag? gameplayTagById = GameplayTagUtils.GetGameplayTagById(num2);
				if (num2 == this.CurStaticMeshTagId || !this.ModelConfig.静态网格体列表.Contains(gameplayTagById.Value) || this.ModelConfig.静态网格体列表.Get(gameplayTagById.Value) == null)
				{
					return;
				}
				this.CurStaticMeshTagId = num2;
			}
			SceneItemActorComponent sceneItemActorComponent = this.ActorComponent as SceneItemActorComponent;
			if (sceneItemActorComponent != null)
			{
				sceneItemActorComponent.LoadAndChangeStaticMesh(GameplayTagUtils.GetGameplayTagById(this.CurStaticMeshTagId).Value);
			}
		}

		// Token: 0x06030979 RID: 199033 RVA: 0x00BF3674 File Offset: 0x00BF1874
		private void InitCommonEffect()
		{
			FGameplayTag? gameplayTagById = GameplayTagUtils.GetGameplayTagById(GameplayTagDefine.EGameplayTagId["物体.表现.常驻特效"]);
			FSoftObjectPath fsoftObjectPath;
			if (!this.ModelConfig.常驻特效列表.TryGetValue(gameplayTagById.Value, out fsoftObjectPath))
			{
				return;
			}
			if (fsoftObjectPath == null)
			{
				return;
			}
			this.CommonEffect = this.SpawnEffectByPath(fsoftObjectPath.AssetPathName.ToString(), "[PerformanceComponent.InitCommonEffect]", new Action<ELoadEffectResult, int>(this.OnSpawnEffectByPathCompleted));
			if (!Singleton<EffectSystem>.Instance.IsValid(this.CommonEffect))
			{
				return;
			}
			OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(this.CommonEffect);
			AActor owner = this.ActorComponent.Owner;
			FName? fname = null;
			effectActor.K2_AttachToActor(owner, fname, EAttachmentRule.SnapToTarget, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, false);
			bool visible = this.ActorComponent.CreatureData.GetVisible();
			this.SetEffectVisibleById(this.CommonEffect, visible);
		}

		// Token: 0x0603097A RID: 199034 RVA: 0x00BF374C File Offset: 0x00BF194C
		private bool CheckAndUpdateCommonEffectTag()
		{
			if (this.CommonEffect == 0)
			{
				return false;
			}
			int? resTag = this.GetResTag<SNiagaraParam>(this.ModelConfig.通用特效常驻参数);
			int? num = resTag;
			int curCommonEffectTagId = this.CurCommonEffectTagId;
			if (num.GetValueOrDefault() == curCommonEffectTagId & num != null)
			{
				return false;
			}
			this.CurCommonEffectTagId = resTag.GetValueOrDefault();
			return this.CurCommonEffectTagId != 0;
		}

		// Token: 0x0603097B RID: 199035 RVA: 0x00BF37AC File Offset: 0x00BF19AC
		private void SetCommonEffectParam()
		{
			if (this.CommonEffect == 0)
			{
				return;
			}
			FGameplayTag? gameplayTagById = GameplayTagUtils.GetGameplayTagById(this.CurCommonEffectTagId);
			SNiagaraParam sniagaraParam;
			if (!this.ModelConfig.通用特效常驻参数.TryGetValue(gameplayTagById.Value, out sniagaraParam))
			{
				return;
			}
			if (sniagaraParam == null)
			{
				return;
			}
			this.SetCommonEffectByNiagaraParam(sniagaraParam);
		}

		// Token: 0x0603097C RID: 199036 RVA: 0x00BF37FC File Offset: 0x00BF19FC
		private void ChangeCommonEffectParam()
		{
			FGameplayTag? gameplayTagById = GameplayTagUtils.GetGameplayTagById(this.CurCommonEffectTagId);
			SNiagaraParam sniagaraParam;
			if (!this.ModelConfig.通用特效变化参数.TryGetValue(gameplayTagById.Value, out sniagaraParam))
			{
				return;
			}
			if (sniagaraParam == null)
			{
				this.SetCommonEffectParam();
				return;
			}
			if (sniagaraParam.ManualLifeTime > 0f)
			{
				if (this.OnChangeCommonEffectFinished == null)
				{
					this.OnChangeCommonEffectFinished = delegate(float delta)
					{
						this.SetCommonEffectParam();
					};
				}
				this.DisposeCommonEffectTimer();
				this.CommonEffectTimerId = TimerSystem.Instance.Loop(this.OnChangeCommonEffectFinished, (float)Singleton<TimeUtil>.Instance.SetTimeMillisecond((double)sniagaraParam.ManualLifeTime), 1, 0f, null, null, true);
			}
			this.SetCommonEffectByNiagaraParam(sniagaraParam);
		}

		// Token: 0x0603097D RID: 199037 RVA: 0x00BF38A8 File Offset: 0x00BF1AA8
		private void InitOwnEffects()
		{
			if (this.LevelTagComponent == null)
			{
				return;
			}
			foreach (int tagId in this.LevelTagComponent.GetTagIds())
			{
				this.CheckAndAddOwnEffectByTag(tagId);
			}
		}

		// Token: 0x0603097E RID: 199038 RVA: 0x00BF3904 File Offset: 0x00BF1B04
		private void CheckAndAddOwnEffectByTag(int tagId)
		{
			if (this.OwnEffectMap.ContainsKey(tagId))
			{
				return;
			}
			FGameplayTag? gameplayTagById = GameplayTagUtils.GetGameplayTagById(tagId);
			FSoftObjectPath fsoftObjectPath;
			if (!this.ModelConfig.常驻特效列表.TryGetValue(gameplayTagById.Value, out fsoftObjectPath))
			{
				return;
			}
			if (fsoftObjectPath == null)
			{
				return;
			}
			int num = this.SpawnEffectByPath(fsoftObjectPath.AssetPathName.ToString(), "[PerformanceComponent.CheckAndAddOwnEffectByTag]", null);
			if (num != 0)
			{
				this.OwnEffectMap.Add(tagId, num);
				bool visible = this.ActorComponent.CreatureData.GetVisible();
				this.SetEffectVisibleById(num, visible);
			}
		}

		// Token: 0x0603097F RID: 199039 RVA: 0x00BF399C File Offset: 0x00BF1B9C
		private void ChangeOwnEffects(IReadOnlyList<int> added, IReadOnlyList<int> removed)
		{
			foreach (int key in removed)
			{
				if (this.OwnEffectMap.ContainsKey(key))
				{
					int handle2 = this.OwnEffectMap[key];
					this.OwnEffectMap.Remove(key);
					Singleton<EffectSystem>.Instance.StopEffectById(handle2, "[PerformanceComponent.ChangeOwnEffects]", true, null);
				}
			}
			int? num = null;
			foreach (int tagId in added)
			{
				FGameplayTag? gameplayTagById = GameplayTagUtils.GetGameplayTagById(tagId);
				FSoftObjectPath fsoftObjectPath;
				if (this.ModelConfig.变化特效列表.TryGetValue(gameplayTagById.Value, out fsoftObjectPath))
				{
					if (fsoftObjectPath != null)
					{
						num = new int?(this.SpawnEffectByPath(fsoftObjectPath.AssetPathName.ToString(), "[PerformanceComponent.ChangeOwnEffects]", null));
					}
					else
					{
						this.CheckAndAddOwnEffectByTag(tagId);
					}
				}
				else
				{
					this.CheckAndAddOwnEffectByTag(tagId);
				}
			}
			if (num != null)
			{
				if (this.OnChangeEffectFinished == null)
				{
					this.OnChangeEffectFinished = delegate(int handle)
					{
						this.LastChangeEffect = 0;
						this.InitOwnEffects();
					};
				}
				Singleton<EffectSystem>.Instance.AddFinishCallback(this.LastChangeEffect, this.OnChangeEffectFinished);
				this.LastChangeEffect = num.Value;
			}
		}

		// Token: 0x06030980 RID: 199040 RVA: 0x00BF3B0C File Offset: 0x00BF1D0C
		private int? GetResTag<[Nullable(2)] T>(TMap<FGameplayTag, T> map)
		{
			if (this.LevelTagComponent.HasTag(PerformanceComponent.ConcealedGameplayTagId))
			{
				return new int?(PerformanceComponent.ConcealedGameplayTagId);
			}
			this.ResTagId = null;
			if (this.LevelTagComponent != null)
			{
				foreach (int num in this.LevelTagComponent.GetTagIds())
				{
					T t;
					if (num != PerformanceComponent.ConcealedGameplayTagId && map.TryGetValue(GameplayTagUtils.GetGameplayTagById(num).Value, out t) && t != null)
					{
						this.ResTagId = new int?(num);
						break;
					}
				}
			}
			return this.ResTagId;
		}

		// Token: 0x06030981 RID: 199041 RVA: 0x00BF3BC4 File Offset: 0x00BF1DC4
		[NullableContext(2)]
		private int SpawnEffectByPath(string effectDataPath, [Nullable(1)] string reason, Action<ELoadEffectResult, int> callback)
		{
			if (string.IsNullOrEmpty(effectDataPath))
			{
				return 0;
			}
			if (this.ActorComponent == null)
			{
				return 0;
			}
			EffectSystem instance = Singleton<EffectSystem>.Instance;
			UObject world = GlobalData.World;
			FTransformDouble? ftransformDouble = new FTransformDouble?(this.ActorComponent.ActorTransform);
			return instance.SpawnEffect(world, ftransformDouble, effectDataPath, reason, new EffectContext(new int?(base.Entity.Id), null, false), EEffectType.Scene, null, callback, null, false, false);
		}

		// Token: 0x06030982 RID: 199042 RVA: 0x00BF3C26 File Offset: 0x00BF1E26
		private void SetCommonEffectByNiagaraParam(SNiagaraParam niagaraParam)
		{
			Singleton<EffectSystem>.Instance.SetEffectDataByNiagaraParam(this.CommonEffect, niagaraParam, true);
		}

		// Token: 0x06030983 RID: 199043 RVA: 0x00BF3C3A File Offset: 0x00BF1E3A
		public bool ApplyNiagaraParameters(string key, FVector value)
		{
			if (this.CommonEffect == 0 || this.CommonEffectNiagaraComp == null)
			{
				return false;
			}
			this.CommonEffectNiagaraComp.Value.SetNiagaraVariableVec3(key, value);
			return true;
		}

		// Token: 0x06030984 RID: 199044 RVA: 0x00BF3C67 File Offset: 0x00BF1E67
		public bool ApplyNiagaraParameters(string key, float value)
		{
			if (this.CommonEffect == 0 || this.CommonEffectNiagaraComp == null)
			{
				return false;
			}
			this.CommonEffectNiagaraComp.Value.SetNiagaraVariableFloat(key, value);
			return true;
		}

		// Token: 0x06030985 RID: 199045 RVA: 0x00BF3C93 File Offset: 0x00BF1E93
		private void DisposeCommonEffectTimer()
		{
			if (TimerSystem.Instance.Has(this.CommonEffectTimerId))
			{
				TimerSystem.Instance.Remove(this.CommonEffectTimerId);
			}
		}

		// Token: 0x06030986 RID: 199046 RVA: 0x00BF3CB8 File Offset: 0x00BF1EB8
		private void OnSceneInteractionLoadCompleted()
		{
			this.InitSceneInteractionEffects();
			this.InitSceneInteractionExtraEffects();
		}

		// Token: 0x06030987 RID: 199047 RVA: 0x00BF3CC8 File Offset: 0x00BF1EC8
		private void OnSpawnEffectByPathCompleted(ELoadEffectResult result, int handle)
		{
			if (result != ELoadEffectResult.Success)
			{
				return;
			}
			Entity entity = base.Entity;
			if (entity == null || !entity.Valid || !Singleton<EffectSystem>.Instance.IsValid(handle))
			{
				return;
			}
			this.CommonEffectNiagaraComp = new OneOf<KuroEffectNiagaraComponentHandle, UNiagaraComponent>?(Singleton<EffectSystem>.Instance.GetNiagaraComponent(handle));
			if (this.CommonEffectNiagaraComp != null)
			{
				Singleton<EventSystem>.Instance.EmitWithTarget(base.Entity, EEventName.OnAddCommonEffect);
			}
		}

		// Token: 0x06030988 RID: 199048 RVA: 0x00BF3D38 File Offset: 0x00BF1F38
		public void SetPerformanceVisible(bool visible)
		{
			this.SetEffectVisibleById(this.CommonEffect, visible);
			if (this.OwnEffectMap != null)
			{
				foreach (int handleId in this.OwnEffectMap.Values)
				{
					this.SetEffectVisibleById(handleId, visible);
				}
			}
		}

		// Token: 0x06030989 RID: 199049 RVA: 0x00BF3DA8 File Offset: 0x00BF1FA8
		private void SetEffectVisibleById(int handleId, bool visible)
		{
			if (Singleton<EffectSystem>.Instance.IsValid(handleId))
			{
				Singleton<EffectSystem>.Instance.SetEffectHidden(handleId, !visible, "PerformanceComponent", false);
				Singleton<EffectSystem>.Instance.SetTimeScale(handleId, visible > false, false);
			}
		}

		// Token: 0x0603098A RID: 199050 RVA: 0x00BF3DE0 File Offset: 0x00BF1FE0
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			PerformanceComponent performanceComponent = (PerformanceComponent)componentTemplate;
			if (base.CanResetComponentProperty("LevelTagComponent"))
			{
				if (performanceComponent.LevelTagComponent == null)
				{
					this.LevelTagComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<LevelTagComponent>(this.LevelTagComponent), "LevelTagComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ActorComponent"))
			{
				if (performanceComponent.ActorComponent == null)
				{
					this.ActorComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseActorComponent>(this.ActorComponent), "ActorComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SceneInteractionEffectMap"))
			{
				if (performanceComponent.SceneInteractionEffectMap == null)
				{
					this.SceneInteractionEffectMap = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, ESceneInteractionEffect>>(this.SceneInteractionEffectMap), "SceneInteractionEffectMap"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CurSceneInteractionLevelTagId"))
			{
				this.CurSceneInteractionLevelTagId = performanceComponent.CurSceneInteractionLevelTagId;
			}
			if (base.CanResetComponentProperty("CurStaticMeshTagId"))
			{
				this.CurStaticMeshTagId = performanceComponent.CurStaticMeshTagId;
			}
			if (base.CanResetComponentProperty("CurCommonEffectTagId"))
			{
				this.CurCommonEffectTagId = performanceComponent.CurCommonEffectTagId;
			}
			if (base.CanResetComponentProperty("CommonEffect"))
			{
				this.CommonEffect = performanceComponent.CommonEffect;
			}
			if (base.CanResetComponentProperty("CommonEffectNiagaraComp"))
			{
				this.CommonEffectNiagaraComp = performanceComponent.CommonEffectNiagaraComp;
			}
			if (base.CanResetComponentProperty("OwnEffectMap"))
			{
				if (performanceComponent.OwnEffectMap == null)
				{
					this.OwnEffectMap = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, int>>(this.OwnEffectMap), "OwnEffectMap"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("LastChangeEffect"))
			{
				this.LastChangeEffect = performanceComponent.LastChangeEffect;
			}
			if (base.CanResetComponentProperty("OnChangeEffectFinished"))
			{
				if (performanceComponent.OnChangeEffectFinished == null)
				{
					this.OnChangeEffectFinished = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Action<int>>(this.OnChangeEffectFinished), "OnChangeEffectFinished"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("OnChangeCommonEffectFinished"))
			{
				if (performanceComponent.OnChangeCommonEffectFinished == null)
				{
					this.OnChangeCommonEffectFinished = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TTimerAction>(this.OnChangeCommonEffectFinished), "OnChangeCommonEffectFinished"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CommonEffectTimerId"))
			{
				if (performanceComponent.CommonEffectTimerId == null)
				{
					this.CommonEffectTimerId = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TimerHandle>(this.CommonEffectTimerId), "CommonEffectTimerId"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ModelConfig"))
			{
				if (performanceComponent.ModelConfig == null)
				{
					this.ModelConfig = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SModelConfig>(this.ModelConfig), "ModelConfig"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("IsSceneInteractionJumpToEnd"))
			{
				this.IsSceneInteractionJumpToEnd = performanceComponent.IsSceneInteractionJumpToEnd;
			}
			if (base.CanResetComponentProperty("ResTagId"))
			{
				this.ResTagId = performanceComponent.ResTagId;
			}
			return true;
		}

		// Token: 0x0401BEB2 RID: 114354
		[Nullable(2)]
		private LevelTagComponent LevelTagComponent;

		// Token: 0x0401BEB3 RID: 114355
		[Nullable(2)]
		private BaseActorComponent ActorComponent;

		// Token: 0x0401BEB4 RID: 114356
		[Nullable(2)]
		private Dictionary<int, ESceneInteractionEffect> SceneInteractionEffectMap;

		// Token: 0x0401BEB5 RID: 114357
		private int CurSceneInteractionLevelTagId;

		// Token: 0x0401BEB6 RID: 114358
		private int CurStaticMeshTagId;

		// Token: 0x0401BEB7 RID: 114359
		private int CurCommonEffectTagId;

		// Token: 0x0401BEB8 RID: 114360
		private int CommonEffect;

		// Token: 0x0401BEB9 RID: 114361
		[Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		private OneOf<KuroEffectNiagaraComponentHandle, UNiagaraComponent>? CommonEffectNiagaraComp;

		// Token: 0x0401BEBA RID: 114362
		[Nullable(2)]
		private Dictionary<int, int> OwnEffectMap;

		// Token: 0x0401BEBB RID: 114363
		private int LastChangeEffect;

		// Token: 0x0401BEBC RID: 114364
		[Nullable(2)]
		private Action<int> OnChangeEffectFinished;

		// Token: 0x0401BEBD RID: 114365
		[Nullable(2)]
		private TTimerAction OnChangeCommonEffectFinished;

		// Token: 0x0401BEBE RID: 114366
		[Nullable(2)]
		private TimerHandle CommonEffectTimerId;

		// Token: 0x0401BEBF RID: 114367
		[Nullable(2)]
		private SModelConfig ModelConfig;

		// Token: 0x0401BEC0 RID: 114368
		private bool IsSceneInteractionJumpToEnd;

		// Token: 0x0401BEC1 RID: 114369
		private int? ResTagId;

		// Token: 0x0401BEC2 RID: 114370
		private static readonly int ConcealedGameplayTagId = GameplayTagDefine.EGameplayTagId["物体.表现.隐匿"];
	}
}
