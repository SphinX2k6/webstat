using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.WorldMap.SubViews.CommonGamePlay;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D29 RID: 23849
	[NullableContext(1)]
	[Nullable(0)]
	public class FlagChallengeStrongholdData
	{
		// Token: 0x17009887 RID: 39047
		// (get) Token: 0x0603C28F RID: 246415 RVA: 0x00F41AB8 File Offset: 0x00F3FCB8
		public bool IsPass
		{
			get
			{
				return this.IsPassIntl;
			}
		}

		// Token: 0x0603C290 RID: 246416 RVA: 0x00F41AC0 File Offset: 0x00F3FCC0
		public FlagChallengeStrongholdData(int id)
		{
			this.Id = id;
			this.StrongholdConfig = ConfigBase<FlagChallengeConfig>.Instance.GetStrongholdConfig(id).Value;
		}

		// Token: 0x0603C291 RID: 246417 RVA: 0x00F41AF3 File Offset: 0x00F3FCF3
		public void Refresh(FlagStrongholdInfo strongholdData)
		{
			this.IsPassIntl = strongholdData.IsPass;
		}

		// Token: 0x0603C292 RID: 246418 RVA: 0x00F41B01 File Offset: 0x00F3FD01
		public EFlagChallengeStrongholdType GetStrongholdType()
		{
			return (EFlagChallengeStrongholdType)this.StrongholdConfig.Type;
		}

		// Token: 0x0603C293 RID: 246419 RVA: 0x00F41B0E File Offset: 0x00F3FD0E
		public bool IsBossStronghold()
		{
			return this.GetStrongholdType() == EFlagChallengeStrongholdType.Boss;
		}

		// Token: 0x0603C294 RID: 246420 RVA: 0x00F41B1C File Offset: 0x00F3FD1C
		public unsafe FVector GetUiRelativePos()
		{
			Span<int> uiRelativePosBytes = this.StrongholdConfig.GetUiRelativePosBytes();
			return new FVector((float)(*uiRelativePosBytes[0]), (float)(*uiRelativePosBytes[1]), 0f);
		}

		// Token: 0x0603C295 RID: 246421 RVA: 0x00F41B53 File Offset: 0x00F3FD53
		public int GetIndex()
		{
			return this.StrongholdConfig.Index;
		}

		// Token: 0x0603C296 RID: 246422 RVA: 0x00F41B60 File Offset: 0x00F3FD60
		public IMapMoraleLvItemData GetMapFlagChallengeLvItemData()
		{
			int monsterLevel = this.StrongholdConfig.MonsterLevel;
			int strongholdActivityId = FlagChallengeUtils.GetStrongholdActivityId(this.Id);
			EFlagChallengeLevelDiffType levelDiffType = ModelBase<FlagChallengeModel>.Instance.GetLevelDiffType(strongholdActivityId, monsterLevel, null);
			string lvColor = "";
			string bgColor = "";
			switch (levelDiffType)
			{
			case EFlagChallengeLevelDiffType.Easy:
				lvColor = "#494A4AFF";
				bgColor = "#A1A0A0FF";
				break;
			case EFlagChallengeLevelDiffType.Normal:
				lvColor = "#5C4421FF";
				bgColor = "#B09A58FF";
				break;
			case EFlagChallengeLevelDiffType.Hard:
				lvColor = "#6A3838FF";
				bgColor = "#C38484FF";
				break;
			}
			return new MapMoraleLvItemData
			{
				TitleId = "Morale_32_MapIcon_EnemyLv_Title",
				Lv = monsterLevel,
				LvColor = lvColor,
				BgColor = bgColor
			};
		}

		// Token: 0x0603C297 RID: 246423 RVA: 0x00F41C10 File Offset: 0x00F3FE10
		public bool IsLowLevel()
		{
			if (this.IsPassIntl)
			{
				return false;
			}
			FlagChallengeModel instance = ModelBase<FlagChallengeModel>.Instance;
			int strongholdActivityId = FlagChallengeUtils.GetStrongholdActivityId(this.Id);
			return !instance.IsReachTargetLevel(strongholdActivityId, this.StrongholdConfig.RecommendLevel) && instance.GetTotalLevel(strongholdActivityId) < instance.GetMaxLevel(strongholdActivityId);
		}

		// Token: 0x0603C298 RID: 246424 RVA: 0x00F41C5F File Offset: 0x00F3FE5F
		public int GetMarkId()
		{
			return this.StrongholdConfig.MarkId;
		}

		// Token: 0x0603C299 RID: 246425 RVA: 0x00F41C6C File Offset: 0x00F3FE6C
		public bool CanTeleport()
		{
			int markId = this.GetMarkId();
			if (markId == 0)
			{
				return false;
			}
			MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(markId);
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(configMark.Value.EntityConfigId);
			if (entityByPbDataId == null)
			{
				return false;
			}
			WorldEntity entity = entityByPbDataId.Entity;
			bool flag;
			if (entity == null)
			{
				flag = true;
			}
			else
			{
				SceneItemStateComponent component = entity.GetComponent<SceneItemStateComponent>();
				flag = (((component != null) ? new SceneItemStateComponent.ESceneItemState?(component.State) : null).GetValueOrDefault() != SceneItemStateComponent.ESceneItemState.Active);
			}
			return !flag;
		}

		// Token: 0x0603C29A RID: 246426 RVA: 0x00F41CF0 File Offset: 0x00F3FEF0
		public bool IsUnlocked()
		{
			return ModelBase<FlagChallengeModel>.Instance.IsTeleportUnlock(this.GetMarkId());
		}

		// Token: 0x04021C27 RID: 138279
		public readonly int Id;

		// Token: 0x04021C28 RID: 138280
		public FlagStronghold StrongholdConfig;

		// Token: 0x04021C29 RID: 138281
		private bool IsPassIntl;
	}
}
