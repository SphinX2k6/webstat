using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;

namespace CSharpScript.Game.NewWorld.Character.Custom.Components
{
	// Token: 0x020048E6 RID: 18662
	[NullableContext(1)]
	[Nullable(0)]
	public class DungeonEntranceComponent : EntityComponent
	{
		// Token: 0x06030AED RID: 199405 RVA: 0x00C01044 File Offset: 0x00BFF244
		protected override bool OnStart()
		{
			this.StateComponent = base.Entity.GetComponent<SceneItemStateComponent>();
			this.RestoreCbList = new List<Action>();
			Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.OnEntityStateChange));
			Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnSceneItemStatePreChangeInSequence, new Action<int>(this.OnEntityStatePrechangeInSequence));
			this.HandlePerformanceState(null);
			return true;
		}

		// Token: 0x06030AEE RID: 199406 RVA: 0x00C010C1 File Offset: 0x00BFF2C1
		protected override void OnActivate()
		{
		}

		// Token: 0x06030AEF RID: 199407 RVA: 0x00C010C4 File Offset: 0x00BFF2C4
		protected override bool OnEnd()
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.OnEntityStateChange));
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnSceneItemStatePreChangeInSequence, new Action<int>(this.OnEntityStatePrechangeInSequence));
			this.RestoreCbList = null;
			return true;
		}

		// Token: 0x06030AF0 RID: 199408 RVA: 0x00C01120 File Offset: 0x00BFF320
		private void OnEntityStateChange(int stateId, bool isReady)
		{
			this.HandlePerformanceState(null);
		}

		// Token: 0x06030AF1 RID: 199409 RVA: 0x00C0113C File Offset: 0x00BFF33C
		private void OnEntityStatePrechangeInSequence(int stateId)
		{
			this.HandlePerformanceState(new int?(stateId));
		}

		// Token: 0x06030AF2 RID: 199410 RVA: 0x00C0114A File Offset: 0x00BFF34A
		public void RegisterRestoreCb(Action cb)
		{
			this.RestoreCbList.Add(cb);
		}

		// Token: 0x06030AF3 RID: 199411 RVA: 0x00C01158 File Offset: 0x00BFF358
		public void Restore()
		{
			if (this.RestoreCbList == null || this.RestoreCbList.Count == 0)
			{
				return;
			}
			foreach (Action action in this.RestoreCbList)
			{
				action();
			}
			this.RestoreCbList.Clear();
		}

		// Token: 0x06030AF4 RID: 199412 RVA: 0x00C011CC File Offset: 0x00BFF3CC
		private void HandlePerformanceState(int? stateId = null)
		{
			if (stateId != null)
			{
				int? num = stateId;
				int num2 = 0;
				if (!(num.GetValueOrDefault() == num2 & num != null))
				{
					num = stateId;
					num2 = GameplayTagDefine.EGameplayTagId["关卡.Common.状态.激活"];
					if (num.GetValueOrDefault() == num2 & num != null)
					{
						this.StateComponent.ChangePerformanceState(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.激活"], false, false);
					}
					return;
				}
			}
			SceneItemStateComponent stateComponent = this.StateComponent;
			if (!(((stateComponent != null) ? new SceneItemStateComponent.ESceneItemState?(stateComponent.State) : null) != SceneItemStateComponent.ESceneItemState.Active))
			{
				this.StateComponent.ChangePerformanceState(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.激活"], false, false);
			}
		}

		// Token: 0x06030AF5 RID: 199413 RVA: 0x00C0128C File Offset: 0x00BFF48C
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			DungeonEntranceComponent dungeonEntranceComponent = (DungeonEntranceComponent)componentTemplate;
			if (base.CanResetComponentProperty("StateComponent"))
			{
				if (dungeonEntranceComponent.StateComponent == null)
				{
					this.StateComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemStateComponent>(this.StateComponent), "StateComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("RestoreCbList"))
			{
				if (dungeonEntranceComponent.RestoreCbList == null)
				{
					this.RestoreCbList = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<Action>>(this.RestoreCbList), "RestoreCbList"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401BFBD RID: 114621
		[Nullable(2)]
		private SceneItemStateComponent StateComponent;

		// Token: 0x0401BFBE RID: 114622
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<Action> RestoreCbList;
	}
}
