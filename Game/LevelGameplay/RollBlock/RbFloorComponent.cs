using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.NewWorld.SceneItem.Jigsaw;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.LevelGamePlay.RollBlock
{
	// Token: 0x02006B19 RID: 27417
	public class RbFloorComponent : RbBaseComponent
	{
		// Token: 0x06043C01 RID: 277505 RVA: 0x0117C0B8 File Offset: 0x0117A2B8
		protected override bool OnStart()
		{
			this.CreatureDataComp = base.Entity.GetComponent<CreatureDataComponent>();
			if (this.CreatureDataComp == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.RollBlock, ELogAuthor.CH, "[RbItemComp] CreatureDataComp is null", default(ReadOnlySpan<ValueTuple<string, object>>));
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
				RbFloorComponentPb rbFloorInfo = creatureDataComp.RbFloorInfo;
				repeatedField = ((rbFloorInfo != null) ? rbFloorInfo.OccupiedCellPositions : null);
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

		// Token: 0x06043C02 RID: 277506 RVA: 0x0117C174 File Offset: 0x0117A374
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			RbFloorComponent rbFloorComponent = (RbFloorComponent)componentTemplate;
			if (base.CanResetComponentProperty("CreatureDataComp"))
			{
				if (rbFloorComponent.CreatureDataComp == null)
				{
					this.CreatureDataComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComp), "CreatureDataComp"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x04025E10 RID: 155152
		[Nullable(2)]
		private CreatureDataComponent CreatureDataComp;
	}
}
