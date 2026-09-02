using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.OperationRestrict;
using CSharpScript.Game.NewWorld.SceneItem;
using CSharpScript.Game.NewWorld.SceneItem.Interface;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A33 RID: 27187
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class LevelGamePlayModel : ModelBase<LevelGamePlayModel>
	{
		// Token: 0x0604347B RID: 275579 RVA: 0x0114B0B4 File Offset: 0x011492B4
		private void HandleWorldDone()
		{
			this.SetWorldLoad(true);
		}

		// Token: 0x0604347C RID: 275580 RVA: 0x0114B0BD File Offset: 0x011492BD
		private void OnDisActiveBattleView()
		{
			if (this.LevelRestrictOperationBlockAll)
			{
				Singleton<OperationRestrictUtils>.Instance.SetInputBlockRestrict(false);
			}
		}

		// Token: 0x0604347D RID: 275581 RVA: 0x0114B0D2 File Offset: 0x011492D2
		private void OnActiveBattleView()
		{
			if (this.LevelRestrictOperationBlockAll)
			{
				Singleton<OperationRestrictUtils>.Instance.SetInputBlockRestrict(true);
			}
		}

		// Token: 0x0604347E RID: 275582 RVA: 0x0114B0E8 File Offset: 0x011492E8
		protected override bool OnInit()
		{
			this.WorldLoad = false;
			this.WorldTeleport = true;
			this.LoadHandle = new Queue<Action>(4);
			this.PreservedCollisionProfileMap = new WeakMap<UPrimitiveComponent, string>();
			this.EndPlayHookedActors = new WeakSet<AActor>();
			this.GuidePathRegistered = new Dictionary<int, int>();
			this.GuidePathPending = new Dictionary<int, List<Action<IGuidePathVisibilityHost>>>();
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.HandleWorldDone));
			Singleton<EventSystem>.Instance.Add(EEventName.DisActiveBattleView, new Action(this.OnDisActiveBattleView));
			Singleton<EventSystem>.Instance.Add(EEventName.ActiveBattleView, new Action(this.OnActiveBattleView));
			return true;
		}

		// Token: 0x0604347F RID: 275583 RVA: 0x0114B190 File Offset: 0x01149390
		public void AddLoadNotify(Action handle)
		{
			this.LoadHandle.Push(handle);
			this.UpdateLoadNotify();
		}

		// Token: 0x06043480 RID: 275584 RVA: 0x0114B1A4 File Offset: 0x011493A4
		public void SetWorldLoad(bool value)
		{
			this.WorldLoad = value;
			this.UpdateLoadNotify();
		}

		// Token: 0x06043481 RID: 275585 RVA: 0x0114B1B3 File Offset: 0x011493B3
		public void SetWorldTeleport(bool worldTeleport)
		{
			this.WorldTeleport = worldTeleport;
			this.UpdateLoadNotify();
		}

		// Token: 0x06043482 RID: 275586 RVA: 0x0114B1C4 File Offset: 0x011493C4
		public void UpdateLoadNotify()
		{
			if (!this.WorldTeleport || !this.WorldLoad)
			{
				return;
			}
			while (this.LoadHandle.Size > 0)
			{
				Action action = this.LoadHandle.Pop();
				if (action != null)
				{
					action();
				}
			}
		}

		// Token: 0x06043483 RID: 275587 RVA: 0x0114B205 File Offset: 0x01149405
		public void ExecuteActionsNew(List<ActionInfo> actions, GeneralContext context, [Nullable(2)] Action<ELevelEventState> finishCallback = null)
		{
			ControllerBase<LevelGeneralController>.Instance.ExecuteActionsNew(actions, context, finishCallback);
		}

		// Token: 0x06043484 RID: 275588 RVA: 0x0114B214 File Offset: 0x01149414
		public void RegisterGuidePathHost(int pbDataId, int entityId)
		{
			if (pbDataId <= 0 || entityId <= 0)
			{
				return;
			}
			if (this.GuidePathRegistered == null || this.GuidePathPending == null)
			{
				return;
			}
			this.GuidePathRegistered[pbDataId] = entityId;
			List<Action<IGuidePathVisibilityHost>> list;
			if (!this.GuidePathPending.TryGetValue(pbDataId, out list) || list.Count == 0)
			{
				return;
			}
			this.GuidePathPending.Remove(pbDataId);
			SceneItemGuidePathComponent component = Singleton<EntitySystem>.Instance.GetComponent<SceneItemGuidePathComponent>(entityId);
			if (component == null)
			{
				return;
			}
			foreach (Action<IGuidePathVisibilityHost> action in list)
			{
				action(component);
			}
		}

		// Token: 0x06043485 RID: 275589 RVA: 0x0114B2C0 File Offset: 0x011494C0
		public void UnregisterGuidePathHost(int pbDataId, int entityId)
		{
			if (pbDataId <= 0 || entityId <= 0)
			{
				return;
			}
			if (this.GuidePathRegistered == null)
			{
				return;
			}
			int num;
			if (this.GuidePathRegistered.TryGetValue(pbDataId, out num) && num == entityId)
			{
				this.GuidePathRegistered.Remove(pbDataId);
			}
		}

		// Token: 0x06043486 RID: 275590 RVA: 0x0114B300 File Offset: 0x01149500
		[NullableContext(2)]
		public IGuidePathVisibilityHost GetGuidePathHost(int pbDataId)
		{
			if (pbDataId <= 0)
			{
				return null;
			}
			int num;
			if (this.GuidePathRegistered == null || !this.GuidePathRegistered.TryGetValue(pbDataId, out num) || num <= 0)
			{
				return null;
			}
			return Singleton<EntitySystem>.Instance.GetComponent<SceneItemGuidePathComponent>(num);
		}

		// Token: 0x06043487 RID: 275591 RVA: 0x0114B33C File Offset: 0x0114953C
		[return: Nullable(2)]
		public Action RegisterPendingGuidePathHandler(int pbDataId, Action<IGuidePathVisibilityHost> handler)
		{
			if (pbDataId <= 0)
			{
				return null;
			}
			if (this.GuidePathRegistered == null || this.GuidePathPending == null)
			{
				return null;
			}
			IGuidePathVisibilityHost guidePathHost = this.GetGuidePathHost(pbDataId);
			if (guidePathHost != null)
			{
				handler(guidePathHost);
				return null;
			}
			List<Action<IGuidePathVisibilityHost>> list;
			if (!this.GuidePathPending.TryGetValue(pbDataId, out list))
			{
				list = new List<Action<IGuidePathVisibilityHost>>();
				this.GuidePathPending[pbDataId] = list;
			}
			list.Add(handler);
			return delegate()
			{
				List<Action<IGuidePathVisibilityHost>> list2;
				if (this.GuidePathPending == null || !this.GuidePathPending.TryGetValue(pbDataId, out list2))
				{
					return;
				}
				int num = list2.IndexOf(handler);
				if (num >= 0)
				{
					list2.RemoveAt(num);
				}
				if (list2.Count == 0)
				{
					Dictionary<int, List<Action<IGuidePathVisibilityHost>>> guidePathPending = this.GuidePathPending;
					if (guidePathPending == null)
					{
						return;
					}
					guidePathPending.Remove(pbDataId);
				}
			};
		}

		// Token: 0x06043488 RID: 275592 RVA: 0x0114B3E4 File Offset: 0x011495E4
		protected override bool OnClear()
		{
			this.WorldLoad = false;
			this.WorldTeleport = false;
			this.LoadHandle = null;
			this.PreservedCollisionProfileMap = null;
			this.EndPlayHookedActors = null;
			Dictionary<int, int> guidePathRegistered = this.GuidePathRegistered;
			if (guidePathRegistered != null)
			{
				guidePathRegistered.Clear();
			}
			this.GuidePathRegistered = null;
			Dictionary<int, List<Action<IGuidePathVisibilityHost>>> guidePathPending = this.GuidePathPending;
			if (guidePathPending != null)
			{
				guidePathPending.Clear();
			}
			this.GuidePathPending = null;
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.HandleWorldDone));
			Singleton<EventSystem>.Instance.Remove(EEventName.DisActiveBattleView, new Action(this.OnDisActiveBattleView));
			Singleton<EventSystem>.Instance.Remove(EEventName.ActiveBattleView, new Action(this.OnActiveBattleView));
			LevelEventLockMaskModule.Clear();
			return true;
		}

		// Token: 0x04025844 RID: 153668
		private bool WorldLoad;

		// Token: 0x04025845 RID: 153669
		private bool WorldTeleport;

		// Token: 0x04025846 RID: 153670
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Queue<Action> LoadHandle;

		// Token: 0x04025847 RID: 153671
		public bool LevelRestrictOperationBlockAll;

		// Token: 0x04025848 RID: 153672
		[Nullable(2)]
		public IFlowerPollutionManager FlowerPollutionManager;

		// Token: 0x04025849 RID: 153673
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public WeakMap<UPrimitiveComponent, string> PreservedCollisionProfileMap;

		// Token: 0x0402584A RID: 153674
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public WeakSet<AActor> EndPlayHookedActors;

		// Token: 0x0402584B RID: 153675
		[Nullable(2)]
		private Dictionary<int, int> GuidePathRegistered;

		// Token: 0x0402584C RID: 153676
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private Dictionary<int, List<Action<IGuidePathVisibilityHost>>> GuidePathPending;
	}
}
