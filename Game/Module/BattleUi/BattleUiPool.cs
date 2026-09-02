using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F83 RID: 24451
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleUiPool
	{
		// Token: 0x0603D638 RID: 251448 RVA: 0x00F9DA14 File Offset: 0x00F9BC14
		[NullableContext(0)]
		public UniTask<bool> Init()
		{
			BattleUiPool.<Init>d__16 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<BattleUiPool.<Init>d__16>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0603D639 RID: 251449 RVA: 0x00F9DA58 File Offset: 0x00F9BC58
		private bool InitRoot()
		{
			UUIItem worldSpaceUiRootItem = Singleton<UiLayer>.Instance.WorldSpaceUiRootItem;
			if (worldSpaceUiRootItem == null || !worldSpaceUiRootItem.IsValid())
			{
				Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.CFT, "WorldSpaceUiRootItem为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			this.WorldRoot = worldSpaceUiRootItem;
			UUIItem layerRootUiItem = Singleton<UiLayer>.Instance.GetLayerRootUiItem(ELayerType.Pool);
			if (layerRootUiItem == null || !layerRootUiItem.IsValid())
			{
				Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.CFT, "PoolRoot为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			this.PoolRoot = layerRootUiItem;
			UUIItem uiRootItem = Singleton<UiLayer>.Instance.UiRootItem;
			if (uiRootItem == null || !uiRootItem.IsValid())
			{
				Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.CFT, "UiRootItem为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			this.UiRoot = uiRootItem;
			this.DamageViewRoot = Singleton<UiLayer>.Instance.GetBattleViewUnit(0);
			return true;
		}

		// Token: 0x0603D63A RID: 251450 RVA: 0x00F9DB40 File Offset: 0x00F9BD40
		[NullableContext(0)]
		private UniTask<bool> PreloadAllActor()
		{
			BattleUiPool.<PreloadAllActor>d__18 <PreloadAllActor>d__;
			<PreloadAllActor>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<PreloadAllActor>d__.<>4__this = this;
			<PreloadAllActor>d__.<>1__state = -1;
			<PreloadAllActor>d__.<>t__builder.Start<BattleUiPool.<PreloadAllActor>d__18>(ref <PreloadAllActor>d__);
			return <PreloadAllActor>d__.<>t__builder.Task;
		}

		// Token: 0x0603D63B RID: 251451 RVA: 0x00F9DB84 File Offset: 0x00F9BD84
		[return: Nullable(0)]
		private UniTask<bool> PreloadActor(IPreLoad config, UUIItem parentItem)
		{
			BattleUiPool.<PreloadActor>d__19 <PreloadActor>d__;
			<PreloadActor>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<PreloadActor>d__.<>4__this = this;
			<PreloadActor>d__.config = config;
			<PreloadActor>d__.parentItem = parentItem;
			<PreloadActor>d__.<>1__state = -1;
			<PreloadActor>d__.<>t__builder.Start<BattleUiPool.<PreloadActor>d__19>(ref <PreloadActor>d__);
			return <PreloadActor>d__.<>t__builder.Task;
		}

		// Token: 0x0603D63C RID: 251452 RVA: 0x00F9DBD8 File Offset: 0x00F9BDD8
		[return: Nullable(2)]
		public AActor GetActor(string resourceId, USceneComponent parent, bool setParent)
		{
			BattleUiPoolElement battleUiPoolElement;
			if (!this.ActorMap.TryGetValue(resourceId, out battleUiPoolElement) || battleUiPoolElement.ActorList == null || battleUiPoolElement.ActorList.Count == 0)
			{
				return null;
			}
			if (battleUiPoolElement.ExistMulti)
			{
				if (battleUiPoolElement.ActorList.Count > 1)
				{
					AActor aactor = battleUiPoolElement.ActorList.Pop<AActor>();
					if (aactor != null && aactor.IsValid())
					{
						if (setParent)
						{
							aactor.K2_AttachRootComponentTo(parent, default(FName), EAttachLocation.KeepRelativeOffset, true);
						}
						return aactor;
					}
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Battle;
					ELogAuthor author = ELogAuthor.HWR;
					string message = "BattleUiPool:Actor已无效";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("resourceId", resourceId);
					instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				return Singleton<LguiUtil>.Instance.DuplicateActor(battleUiPoolElement.ActorList[0], parent);
			}
			AActor aactor2;
			if (!battleUiPoolElement.ActorList.TryPop(out aactor2) || aactor2 == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Battle;
				ELogAuthor author2 = ELogAuthor.CFT;
				string message2 = "BattleUiPool重复获取单一预制体";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("resourceId", resourceId);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return null;
			}
			if (setParent)
			{
				aactor2.K2_AttachRootComponentTo(parent, default(FName), EAttachLocation.KeepRelativeOffset, true);
			}
			return aactor2;
		}

		// Token: 0x0603D63D RID: 251453 RVA: 0x00F9DCEC File Offset: 0x00F9BEEC
		public bool RecycleActor(string resourceId, AActor actor, bool resetParent = false)
		{
			BattleUiPoolElement battleUiPoolElement;
			if (!this.ActorMap.TryGetValue(resourceId, out battleUiPoolElement))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.CFT;
				string message = "BattleUiPool没有缓存该预制体";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("resourceId", resourceId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			(actor.RootComponent as UUIItem).SetUIActive(false);
			if (resetParent)
			{
				actor.K2_AttachRootComponentTo(this.PoolRoot, default(FName), EAttachLocation.KeepRelativeOffset, true);
			}
			if (battleUiPoolElement.ExistMulti)
			{
				battleUiPoolElement.ActorList.Add(actor);
				return true;
			}
			if (battleUiPoolElement.Actor != actor)
			{
				if (actor.IsValid())
				{
					ULGUIBPLibrary.DestroyActorWithHierarchy(actor, true);
				}
				return false;
			}
			if (battleUiPoolElement.ActorList.Count != 0)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Battle;
				ELogAuthor author2 = ELogAuthor.CFT;
				string message2 = "BattleUiPool重复Recycle单一预制体";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("resourceId", resourceId);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
			battleUiPoolElement.ActorList.Add(actor);
			return true;
		}

		// Token: 0x0603D63E RID: 251454 RVA: 0x00F9DDD0 File Offset: 0x00F9BFD0
		[return: Nullable(2)]
		public AActor GetSrcActor(string resourceId)
		{
			BattleUiPoolElement battleUiPoolElement;
			if (!this.ActorMap.TryGetValue(resourceId, out battleUiPoolElement) || battleUiPoolElement.Actor == null)
			{
				return null;
			}
			return battleUiPoolElement.Actor;
		}

		// Token: 0x0603D63F RID: 251455 RVA: 0x00F9DDFD File Offset: 0x00F9BFFD
		[return: Nullable(2)]
		public AActor GetHeadStateView(string resourceId)
		{
			return this.GetActor(resourceId, this.WorldRoot, false);
		}

		// Token: 0x0603D640 RID: 251456 RVA: 0x00F9DE0D File Offset: 0x00F9C00D
		public bool RecycleHeadStateView(string resourceId, AActor actor, bool resetParent = false)
		{
			return !this.Inited || this.RecycleActor(resourceId, actor, resetParent);
		}

		// Token: 0x0603D641 RID: 251457 RVA: 0x00F9DE22 File Offset: 0x00F9C022
		[NullableContext(2)]
		public AActor GetDamageView()
		{
			return this.GetActor(this.damageViewConfig.ResourceId, this.DamageViewRoot, false);
		}

		// Token: 0x0603D642 RID: 251458 RVA: 0x00F9DE3C File Offset: 0x00F9C03C
		public bool RecycleDamageView(AActor actor)
		{
			if (!this.Inited)
			{
				Singleton<ActorSystem>.Instance.Put("BattleUiPool.RecycleDamageView", actor, null);
				return true;
			}
			return this.RecycleActor(this.damageViewConfig.ResourceId, actor, false);
		}

		// Token: 0x0603D643 RID: 251459 RVA: 0x00F9DE6D File Offset: 0x00F9C06D
		[return: Nullable(2)]
		public AActor GetBuffItem(USceneComponent parentItem)
		{
			return this.GetActor(this.buffItemConfig.ResourceId, parentItem, true);
		}

		// Token: 0x0603D644 RID: 251460 RVA: 0x00F9DE82 File Offset: 0x00F9C082
		public bool RecycleBuffItem(AActor actor)
		{
			if (!this.Inited)
			{
				Singleton<ActorSystem>.Instance.Put("BattleUiPool.RecycleBuffItem", actor, null);
				return true;
			}
			return this.RecycleActor(this.buffItemConfig.ResourceId, actor, true);
		}

		// Token: 0x0603D645 RID: 251461 RVA: 0x00F9DEB3 File Offset: 0x00F9C0B3
		[return: Nullable(2)]
		public AActor GetQuickHackBuffItem(USceneComponent parentItem)
		{
			return this.GetActor(this.quickHackBuffItemConfig.ResourceId, parentItem, true);
		}

		// Token: 0x0603D646 RID: 251462 RVA: 0x00F9DEC8 File Offset: 0x00F9C0C8
		public bool RecycleQuickHackBuffItem(AActor actor)
		{
			if (!this.Inited)
			{
				Singleton<ActorSystem>.Instance.Put("BattleUiPool.RecycleQuickHackBuffItem", actor, null);
				return true;
			}
			return this.RecycleActor(this.quickHackBuffItemConfig.ResourceId, actor, true);
		}

		// Token: 0x0603D647 RID: 251463 RVA: 0x00F9DEF9 File Offset: 0x00F9C0F9
		[return: Nullable(2)]
		public AActor GetEnvironmentItem(USceneComponent parentItem)
		{
			return this.GetActor(this.environmentItemConfig.ResourceId, parentItem, true);
		}

		// Token: 0x0603D648 RID: 251464 RVA: 0x00F9DF0E File Offset: 0x00F9C10E
		public bool RecycleEnvironmentItem(AActor actor)
		{
			if (!this.Inited)
			{
				Singleton<ActorSystem>.Instance.Put("BattleUiPool.RecycleEnvironmentItem", actor, null);
				return true;
			}
			return this.RecycleActor(this.environmentItemConfig.ResourceId, actor, true);
		}

		// Token: 0x0603D649 RID: 251465 RVA: 0x00F9DF3F File Offset: 0x00F9C13F
		[return: Nullable(2)]
		public AActor GetWeaknessItem(USceneComponent parentItem)
		{
			return this.GetActor(this.weaknessItemConfig.ResourceId, parentItem, true);
		}

		// Token: 0x0603D64A RID: 251466 RVA: 0x00F9DF54 File Offset: 0x00F9C154
		public bool RecycleWeaknessItem(AActor actor)
		{
			if (!this.Inited)
			{
				Singleton<ActorSystem>.Instance.Put("BattleUiPool.RecycleWeaknessItem", actor, null);
				return true;
			}
			return this.RecycleActor(this.weaknessItemConfig.ResourceId, actor, true);
		}

		// Token: 0x0603D64B RID: 251467 RVA: 0x00F9DF88 File Offset: 0x00F9C188
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public UniTask<AActor> LoadActorNoCache(string path, UUIItem parentItem)
		{
			BattleUiPool.<LoadActorNoCache>d__35 <LoadActorNoCache>d__;
			<LoadActorNoCache>d__.<>t__builder = AsyncUniTaskMethodBuilder<AActor>.Create();
			<LoadActorNoCache>d__.<>4__this = this;
			<LoadActorNoCache>d__.path = path;
			<LoadActorNoCache>d__.parentItem = parentItem;
			<LoadActorNoCache>d__.<>1__state = -1;
			<LoadActorNoCache>d__.<>t__builder.Start<BattleUiPool.<LoadActorNoCache>d__35>(ref <LoadActorNoCache>d__);
			return <LoadActorNoCache>d__.<>t__builder.Task;
		}

		// Token: 0x0603D64C RID: 251468 RVA: 0x00F9DFDC File Offset: 0x00F9C1DC
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public UniTask<AActor> LoadActor(string path, USceneComponent parentItem)
		{
			BattleUiPool.<LoadActor>d__36 <LoadActor>d__;
			<LoadActor>d__.<>t__builder = AsyncUniTaskMethodBuilder<AActor>.Create();
			<LoadActor>d__.<>4__this = this;
			<LoadActor>d__.path = path;
			<LoadActor>d__.parentItem = parentItem;
			<LoadActor>d__.<>1__state = -1;
			<LoadActor>d__.<>t__builder.Start<BattleUiPool.<LoadActor>d__36>(ref <LoadActor>d__);
			return <LoadActor>d__.<>t__builder.Task;
		}

		// Token: 0x0603D64D RID: 251469 RVA: 0x00F9E030 File Offset: 0x00F9C230
		private AActor GetActorFromPoolElement(BattleUiPoolElement poolElement, USceneComponent parentItem)
		{
			AActor aactor;
			if (poolElement.ActorList.TryPop(out aactor))
			{
				aactor.K2_AttachRootComponentTo(parentItem, default(FName), EAttachLocation.KeepRelativeOffset, true);
				return aactor;
			}
			return Singleton<LguiUtil>.Instance.DuplicateActor(poolElement.Actor, parentItem);
		}

		// Token: 0x0603D64E RID: 251470 RVA: 0x00F9E074 File Offset: 0x00F9C274
		public bool RecycleActorByPath(string path, AActor actor, bool resetParent = false)
		{
			if (!this.Inited)
			{
				return true;
			}
			BattleUiPoolElement battleUiPoolElement;
			if (!this.ActorMap.TryGetValue(path, out battleUiPoolElement))
			{
				Singleton<ActorSystem>.Instance.Put("BattleUiPool.RecycleActorByPath", actor, null);
				return true;
			}
			battleUiPoolElement.ActorList.Add(actor);
			(actor.RootComponent as UUIItem).SetUIActive(false);
			if (resetParent)
			{
				actor.K2_AttachRootComponentTo(this.PoolRoot, default(FName), EAttachLocation.KeepRelativeOffset, true);
			}
			return true;
		}

		// Token: 0x0603D64F RID: 251471 RVA: 0x00F9E0E8 File Offset: 0x00F9C2E8
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public UniTask<AActor> LoadSingleActorByPath(string path, UUIItem parentItem)
		{
			BattleUiPool.<LoadSingleActorByPath>d__39 <LoadSingleActorByPath>d__;
			<LoadSingleActorByPath>d__.<>t__builder = AsyncUniTaskMethodBuilder<AActor>.Create();
			<LoadSingleActorByPath>d__.<>4__this = this;
			<LoadSingleActorByPath>d__.path = path;
			<LoadSingleActorByPath>d__.parentItem = parentItem;
			<LoadSingleActorByPath>d__.<>1__state = -1;
			<LoadSingleActorByPath>d__.<>t__builder.Start<BattleUiPool.<LoadSingleActorByPath>d__39>(ref <LoadSingleActorByPath>d__);
			return <LoadSingleActorByPath>d__.<>t__builder.Task;
		}

		// Token: 0x0603D650 RID: 251472 RVA: 0x00F9E13C File Offset: 0x00F9C33C
		public bool RecycleSingleActor(AActor actor, bool resetParent = false)
		{
			if (!this.Inited)
			{
				return true;
			}
			(actor.RootComponent as UUIItem).SetUIActive(false);
			if (resetParent)
			{
				actor.K2_AttachRootComponentTo(this.PoolRoot, default(FName), EAttachLocation.KeepRelativeOffset, true);
			}
			return true;
		}

		// Token: 0x0603D651 RID: 251473 RVA: 0x00F9E180 File Offset: 0x00F9C380
		[return: Nullable(0)]
		public UniTask<bool> PreloadSingleActorByPath(string path, UUIItem parentItem)
		{
			BattleUiPool.<PreloadSingleActorByPath>d__41 <PreloadSingleActorByPath>d__;
			<PreloadSingleActorByPath>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<PreloadSingleActorByPath>d__.<>4__this = this;
			<PreloadSingleActorByPath>d__.path = path;
			<PreloadSingleActorByPath>d__.parentItem = parentItem;
			<PreloadSingleActorByPath>d__.<>1__state = -1;
			<PreloadSingleActorByPath>d__.<>t__builder.Start<BattleUiPool.<PreloadSingleActorByPath>d__41>(ref <PreloadSingleActorByPath>d__);
			return <PreloadSingleActorByPath>d__.<>t__builder.Task;
		}

		// Token: 0x0603D652 RID: 251474 RVA: 0x00F9E1D4 File Offset: 0x00F9C3D4
		public void Clear()
		{
			this.UiPrefabLoadModule.Clear();
			foreach (BattleUiPoolElement battleUiPoolElement in this.ActorMap.Values)
			{
				battleUiPoolElement.Clear();
			}
			this.ActorMap.Clear();
			foreach (AActor actor in this.SingleActorMap.Values)
			{
				Singleton<ActorSystem>.Instance.Put("BattleUiPool.Clear", actor, null);
			}
			this.SingleActorMap.Clear();
			this.Inited = false;
			this.WorldRoot = null;
			this.PoolRoot = null;
			this.UiRoot = null;
		}

		// Token: 0x0603D654 RID: 251476 RVA: 0x00F9E39C File Offset: 0x00F9C59C
		// Note: this type is marked as 'beforefieldinit'.
		unsafe static BattleUiPool()
		{
			int num = 5;
			List<IPreLoad> list = new List<IPreLoad>(num);
			CollectionsMarshal.SetCount<IPreLoad>(list, num);
			Span<IPreLoad> span = CollectionsMarshal.AsSpan<IPreLoad>(list);
			int num2 = 0;
			*span[num2] = new BattleUiPool.PreLoadConfig
			{
				ResourceId = "UiItem_LittleMonsterState_Prefab",
				PreloadCount = 6
			};
			num2++;
			*span[num2] = new BattleUiPool.PreLoadConfig
			{
				ResourceId = "UiItem_MingsutiState_Prefab",
				PreloadCount = 1
			};
			num2++;
			*span[num2] = new BattleUiPool.PreLoadConfig
			{
				ResourceId = "UiItem_GuardianState_Prefab",
				PreloadCount = 1
			};
			num2++;
			*span[num2] = new BattleUiPool.PreLoadConfig
			{
				ResourceId = "UiItem_EliteMonsterState_Prefab",
				PreloadCount = 4
			};
			num2++;
			*span[num2] = new BattleUiPool.PreLoadConfig
			{
				ResourceId = "UiItem_DestructionState_Prefab",
				PreloadCount = 1
			};
			BattleUiPool.headStateConfigList = list;
		}

		// Token: 0x040227C2 RID: 141250
		[StaticVariableRuleIgnore]
		private static readonly List<IPreLoad> headStateConfigList;

		// Token: 0x040227C3 RID: 141251
		private readonly BattleUiPool.PreLoadConfig bossHeadStateConfig = new BattleUiPool.PreLoadConfig
		{
			ResourceId = "UiItem_BossState_Prefab",
			PreloadCount = 0
		};

		// Token: 0x040227C4 RID: 141252
		private readonly BattleUiPool.PreLoadConfig damageViewConfig = new BattleUiPool.PreLoadConfig
		{
			ResourceId = "UiItem_DamageView_Prefab",
			PreloadCount = 21
		};

		// Token: 0x040227C5 RID: 141253
		private readonly BattleUiPool.PreLoadConfig buffItemConfig = new BattleUiPool.PreLoadConfig
		{
			ResourceId = "UiItem_BuffItem_Prefab",
			PreloadCount = 5
		};

		// Token: 0x040227C6 RID: 141254
		private readonly BattleUiPool.PreLoadConfig environmentItemConfig = new BattleUiPool.PreLoadConfig
		{
			ResourceId = "UiItem_BuffEnvironmentItem_Prefab",
			PreloadCount = 5
		};

		// Token: 0x040227C7 RID: 141255
		private readonly BattleUiPool.PreLoadConfig weaknessItemConfig = new BattleUiPool.PreLoadConfig
		{
			ResourceId = "UiItem_FightBossConcertoState",
			PreloadCount = 5
		};

		// Token: 0x040227C8 RID: 141256
		private readonly BattleUiPool.PreLoadConfig quickHackBuffItemConfig = new BattleUiPool.PreLoadConfig
		{
			ResourceId = "UiItem_QuickHack_BuffItem__Prefab",
			PreloadCount = 5
		};

		// Token: 0x040227C9 RID: 141257
		private readonly Dictionary<string, BattleUiPoolElement> ActorMap = new Dictionary<string, BattleUiPoolElement>();

		// Token: 0x040227CA RID: 141258
		private readonly Dictionary<string, AActor> SingleActorMap = new Dictionary<string, AActor>();

		// Token: 0x040227CB RID: 141259
		private readonly UiPrefabLoadModule UiPrefabLoadModule = new UiPrefabLoadModule();

		// Token: 0x040227CC RID: 141260
		private bool Inited;

		// Token: 0x040227CD RID: 141261
		[Nullable(2)]
		private UUIItem WorldRoot;

		// Token: 0x040227CE RID: 141262
		[Nullable(2)]
		private UUIItem PoolRoot;

		// Token: 0x040227CF RID: 141263
		[Nullable(2)]
		private UUIItem UiRoot;

		// Token: 0x040227D0 RID: 141264
		[Nullable(2)]
		private UUIItem DamageViewRoot;

		// Token: 0x0200BF73 RID: 49011
		[Nullable(0)]
		private class PreLoadConfig : IPreLoad
		{
			// Token: 0x1700AA30 RID: 43568
			// (get) Token: 0x0604E22E RID: 320046 RVA: 0x01599E06 File Offset: 0x01598006
			// (set) Token: 0x0604E22F RID: 320047 RVA: 0x01599E0E File Offset: 0x0159800E
			public string ResourceId { get; set; } = string.Empty;

			// Token: 0x1700AA31 RID: 43569
			// (get) Token: 0x0604E230 RID: 320048 RVA: 0x01599E17 File Offset: 0x01598017
			// (set) Token: 0x0604E231 RID: 320049 RVA: 0x01599E1F File Offset: 0x0159801F
			public int PreloadCount { get; set; }
		}
	}
}
