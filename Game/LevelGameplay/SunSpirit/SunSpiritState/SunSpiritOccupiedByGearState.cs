using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.SunSpirit.SunSpiritPerform;
using CSharpScript.Game.NewWorld.SceneItem;

namespace CSharpScript.Game.LevelGamePlay.SunSpirit.SunSpiritState
{
	// Token: 0x02006AAD RID: 27309
	[NullableContext(1)]
	[Nullable(0)]
	public class SunSpiritOccupiedByGearState : SunSpiritBaseState
	{
		// Token: 0x0604386F RID: 276591 RVA: 0x01168904 File Offset: 0x01166B04
		public SunSpiritOccupiedByGearState(SunSpiritData sunSpiritData, int gearConfigId, int gearSocketIndex) : base(ESunSpiritStateType.OccupiedByGear, sunSpiritData)
		{
			this.GearConfigId = gearConfigId;
			this.GearSocketIndex = gearSocketIndex;
		}

		// Token: 0x06043870 RID: 276592 RVA: 0x0116891C File Offset: 0x01166B1C
		public override bool IsSameState(SunSpiritBaseState otherState)
		{
			if (base.IsSameState(otherState))
			{
				SunSpiritOccupiedByGearState sunSpiritOccupiedByGearState = otherState as SunSpiritOccupiedByGearState;
				if (sunSpiritOccupiedByGearState != null && this.GearConfigId == sunSpiritOccupiedByGearState.GearConfigId)
				{
					return this.GearSocketIndex == sunSpiritOccupiedByGearState.GearSocketIndex;
				}
			}
			return false;
		}

		// Token: 0x06043871 RID: 276593 RVA: 0x0116895C File Offset: 0x01166B5C
		protected override bool OnEnter()
		{
			CreatureModel instance = ModelBase<CreatureModel>.Instance;
			WorldEntity worldEntity;
			if (instance == null)
			{
				worldEntity = null;
			}
			else
			{
				EntityHandle entityByPbDataId = instance.GetEntityByPbDataId(this.GearConfigId);
				worldEntity = ((entityByPbDataId != null) ? entityByPbDataId.Entity : null);
			}
			WorldEntity worldEntity2 = worldEntity;
			SceneItemSunSpiritGearComponent sceneItemSunSpiritGearComponent = (worldEntity2 != null) ? worldEntity2.GetComponent<SceneItemSunSpiritGearComponent>() : null;
			Transform transform = Transform.Create();
			if (sceneItemSunSpiritGearComponent != null)
			{
				sceneItemSunSpiritGearComponent.GetSunSpiritSocketTransform(this.GearSocketIndex, transform);
			}
			SunSpiritBasePerform sunSpiritPerform = this.SunSpiritData.GetSunSpiritPerform();
			ESunSpiritGearPerformType? esunSpiritGearPerformType = (sceneItemSunSpiritGearComponent != null) ? sceneItemSunSpiritGearComponent.GetSunSpiritPerformType() : null;
			if (esunSpiritGearPerformType != null)
			{
				ESunSpiritGearPerformType valueOrDefault = esunSpiritGearPerformType.GetValueOrDefault();
				if (valueOrDefault != ESunSpiritGearPerformType.ToGearRelativePos)
				{
					if (valueOrDefault != ESunSpiritGearPerformType.ScaleUp)
					{
					}
				}
				else
				{
					if (!(sunSpiritPerform is SunSpiritCrowdPerform))
					{
						this.SunSpiritData.ChangeSunSpiritPerform(new SunSpiritCrowdPerform(this.SunSpiritData, transform, false, true));
						goto IL_E4;
					}
					((SunSpiritCrowdPerform)sunSpiritPerform).UpdateCtrlByCrowdAi(false);
					((SunSpiritCrowdPerform)sunSpiritPerform).UpdateForceSpawn(true);
					goto IL_E4;
				}
			}
			if (!(sunSpiritPerform is SunSpiritNonePerform))
			{
				this.SunSpiritData.ChangeSunSpiritPerform(new SunSpiritNonePerform(this.SunSpiritData, transform));
			}
			IL_E4:
			if (worldEntity2 != null && sceneItemSunSpiritGearComponent != null)
			{
				sceneItemSunSpiritGearComponent.OnSunSpiritTakeUp(this.SunSpiritData, this.GearSocketIndex);
				Singleton<EventSystem>.Instance.EmitWithTarget(worldEntity2, EEventName.OnSunSpiritOccupiedByGearChanged);
			}
			return true;
		}

		// Token: 0x06043872 RID: 276594 RVA: 0x01168A78 File Offset: 0x01166C78
		protected override void OnExit()
		{
			CreatureModel instance = ModelBase<CreatureModel>.Instance;
			WorldEntity worldEntity;
			if (instance == null)
			{
				worldEntity = null;
			}
			else
			{
				EntityHandle entityByPbDataId = instance.GetEntityByPbDataId(this.GearConfigId);
				worldEntity = ((entityByPbDataId != null) ? entityByPbDataId.Entity : null);
			}
			WorldEntity worldEntity2 = worldEntity;
			SceneItemSunSpiritGearComponent sceneItemSunSpiritGearComponent = (worldEntity2 != null) ? worldEntity2.GetComponent<SceneItemSunSpiritGearComponent>() : null;
			if (worldEntity2 != null && sceneItemSunSpiritGearComponent != null)
			{
				if (sceneItemSunSpiritGearComponent.GetSunSpiritPerformType().GetValueOrDefault() == ESunSpiritGearPerformType.ScaleUp)
				{
					Transform transform = Transform.Create();
					sceneItemSunSpiritGearComponent.GetSunSpiritSocketTransform(this.GearSocketIndex, transform);
					this.SunSpiritData.SetTransform(transform);
				}
				if (sceneItemSunSpiritGearComponent != null)
				{
					sceneItemSunSpiritGearComponent.OnSunSpiritRelease(this.SunSpiritData, this.GearSocketIndex);
				}
				Singleton<EventSystem>.Instance.EmitWithTarget(worldEntity2, EEventName.OnSunSpiritOccupiedByGearChanged);
			}
		}

		// Token: 0x04025BA5 RID: 154533
		public readonly int GearConfigId;

		// Token: 0x04025BA6 RID: 154534
		public readonly int GearSocketIndex;
	}
}
