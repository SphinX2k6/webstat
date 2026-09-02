using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.RollBlock.ItemLogic;
using CSharpScript.Game.NewWorld.SceneItem.Jigsaw;
using Google.Protobuf.Collections;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.RollBlock
{
	// Token: 0x02006B1A RID: 27418
	[NullableContext(1)]
	[Nullable(0)]
	public class RbItemComponent : RbBaseComponent
	{
		// Token: 0x06043C04 RID: 277508 RVA: 0x0117C1D4 File Offset: 0x0117A3D4
		protected override bool OnStart()
		{
			this.CreatureDataComp = base.Entity.GetComponent<CreatureDataComponent>();
			if (this.CreatureDataComp == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.RollBlock, ELogAuthor.CH, "[RbItemComp] CreatureDataComp is null", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			this.ActorCompInternal = base.Entity.GetComponent<SceneItemActorComponent>();
			if (this.ActorCompInternal == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.RollBlock, ELogAuthor.CH, "[RbItemComp] ActorCompInternal is null", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			CreatureDataComponent creatureDataComp = this.CreatureDataComp;
			RepeatedField<RbGridPosition> repeatedField;
			if (creatureDataComp == null)
			{
				repeatedField = null;
			}
			else
			{
				RbItemComponentPb rbItemInfo = creatureDataComp.RbItemInfo;
				repeatedField = ((rbItemInfo != null) ? rbItemInfo.OccupiedCellPositions : null);
			}
			RepeatedField<RbGridPosition> repeatedField2 = repeatedField;
			if (repeatedField2 != null)
			{
				foreach (RbGridPosition rbGridPosition in repeatedField2)
				{
					this.OccupiedCellIndex.Add(new JigsawIndex(rbGridPosition.X, rbGridPosition.Y));
				}
			}
			return true;
		}

		// Token: 0x06043C05 RID: 277509 RVA: 0x0117C2C8 File Offset: 0x0117A4C8
		public override void OnActualShow()
		{
			this.InitItemLogic();
		}

		// Token: 0x06043C06 RID: 277510 RVA: 0x0117C2D0 File Offset: 0x0117A4D0
		private void InitItemLogic()
		{
			RbItemComponentPb rbItemInfo = this.CreatureDataComp.RbItemInfo;
			if (rbItemInfo == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RollBlock;
				ELogAuthor author = ELogAuthor.CH;
				string message = "[RbItemComp] rbItemInfo is null";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CreatureDataId", this.CreatureDataComp.GetCreatureDataId());
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (rbItemInfo.BreakableObstacleType != null)
			{
				this.ItemLogic = new RbBreakableObstacleItemLogic(this);
				this.ItemLogic.Start(rbItemInfo.BreakableObstacleType);
			}
			if (rbItemInfo.RbLaserEmitterType != null)
			{
				this.ItemLogic = new RbLightBeamItemLogic(this);
				this.ItemLogic.Start(rbItemInfo.RbLaserEmitterType);
			}
		}

		// Token: 0x06043C07 RID: 277511 RVA: 0x0117C37C File Offset: 0x0117A57C
		protected override void OnEnable()
		{
			if (!Singleton<EventSystem>.Instance.HasWithTarget<int, bool>(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.OnSceneItemStateChange)))
			{
				Singleton<EventSystem>.Instance.AddWithTarget<int, bool>(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.OnSceneItemStateChange));
			}
			if (!Singleton<EventSystem>.Instance.HasWithTarget<int>(base.Entity, EEventName.OnSceneItemStatePreChange, new Action<int>(this.OnStateChange)))
			{
				Singleton<EventSystem>.Instance.AddWithTarget<int>(base.Entity, EEventName.OnSceneItemStatePreChange, new Action<int>(this.OnStateChange));
			}
			if (!Singleton<EventSystem>.Instance.HasWithTarget(base.Entity, EEventName.OnSceneItemStatePreChangeInSequence, new Action<int>(this.OnStateChange)))
			{
				Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnSceneItemStatePreChangeInSequence, new Action<int>(this.OnStateChange));
			}
		}

		// Token: 0x06043C08 RID: 277512 RVA: 0x0117C458 File Offset: 0x0117A658
		protected override void OnDisable(string reason)
		{
			if (this.ItemLogic != null)
			{
				this.ItemLogic.End();
				this.ItemLogic = null;
			}
			if (Singleton<EventSystem>.Instance.HasWithTarget<int, bool>(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.OnSceneItemStateChange)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<int, bool>(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.OnSceneItemStateChange));
			}
			if (Singleton<EventSystem>.Instance.HasWithTarget<int>(base.Entity, EEventName.OnSceneItemStatePreChange, new Action<int>(this.OnStateChange)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<int>(base.Entity, EEventName.OnSceneItemStatePreChange, new Action<int>(this.OnStateChange));
			}
			if (Singleton<EventSystem>.Instance.HasWithTarget(base.Entity, EEventName.OnSceneItemStatePreChangeInSequence, new Action<int>(this.OnStateChange)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnSceneItemStatePreChangeInSequence, new Action<int>(this.OnStateChange));
			}
		}

		// Token: 0x06043C09 RID: 277513 RVA: 0x0117C550 File Offset: 0x0117A750
		public void UpdateRollBlockItem(RbItemComponentPb rbItemInfo)
		{
			if (rbItemInfo == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RollBlock;
				ELogAuthor author = ELogAuthor.FJH;
				string message = "[UpdateRollBlockItem] rbItemInfo is null";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CreatureDataId", this.CreatureDataComp.GetCreatureDataId());
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.CreatureDataComp.RbItemInfo = rbItemInfo;
			if (this.ItemLogic != null)
			{
				if (rbItemInfo.BreakableObstacleType != null)
				{
					this.ItemLogic.OnRbItemUpdate(rbItemInfo.BreakableObstacleType);
				}
				if (rbItemInfo.RbLaserEmitterType != null)
				{
					this.ItemLogic.OnRbItemUpdate(rbItemInfo.RbLaserEmitterType);
				}
			}
		}

		// Token: 0x1700A306 RID: 41734
		// (get) Token: 0x06043C0A RID: 277514 RVA: 0x0117C5EA File Offset: 0x0117A7EA
		public FTransformDouble ActorTransform
		{
			get
			{
				return this.ActorCompInternal.ActorTransform;
			}
		}

		// Token: 0x1700A307 RID: 41735
		// (get) Token: 0x06043C0B RID: 277515 RVA: 0x0117C5F7 File Offset: 0x0117A7F7
		public long CreatureDataId
		{
			get
			{
				return this.CreatureDataComp.GetCreatureDataId();
			}
		}

		// Token: 0x1700A308 RID: 41736
		// (get) Token: 0x06043C0C RID: 277516 RVA: 0x0117C604 File Offset: 0x0117A804
		public SceneItemActorComponent ActorComp
		{
			get
			{
				return this.ActorCompInternal;
			}
		}

		// Token: 0x06043C0D RID: 277517 RVA: 0x0117C60C File Offset: 0x0117A80C
		private void OnSceneItemStateChange(int stateId, bool _)
		{
			this.OnStateChange(stateId);
		}

		// Token: 0x06043C0E RID: 277518 RVA: 0x0117C615 File Offset: 0x0117A815
		public void OnStateChange(int stateId)
		{
			if (this.ItemLogic != null)
			{
				this.ItemLogic.OnStateChange(stateId);
			}
		}

		// Token: 0x06043C0F RID: 277519 RVA: 0x0117C62C File Offset: 0x0117A82C
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			RbItemComponent rbItemComponent = (RbItemComponent)componentTemplate;
			if (base.CanResetComponentProperty("CreatureDataComp"))
			{
				if (rbItemComponent.CreatureDataComp == null)
				{
					this.CreatureDataComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComp), "CreatureDataComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ActorCompInternal"))
			{
				if (rbItemComponent.ActorCompInternal == null)
				{
					this.ActorCompInternal = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemActorComponent>(this.ActorCompInternal), "ActorCompInternal"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ItemLogic"))
			{
				if (rbItemComponent.ItemLogic == null)
				{
					this.ItemLogic = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<RbItemLogicBase>(this.ItemLogic), "ItemLogic"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x04025E11 RID: 155153
		[Nullable(2)]
		private CreatureDataComponent CreatureDataComp;

		// Token: 0x04025E12 RID: 155154
		[Nullable(2)]
		private SceneItemActorComponent ActorCompInternal;

		// Token: 0x04025E13 RID: 155155
		[Nullable(2)]
		private RbItemLogicBase ItemLogic;
	}
}
