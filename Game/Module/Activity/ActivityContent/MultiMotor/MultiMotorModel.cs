using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MultiMotor
{
	// Token: 0x0200665D RID: 26205
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class MultiMotorModel : ModelBase<MultiMotorModel>
	{
		// Token: 0x17009F8F RID: 40847
		// (get) Token: 0x0604170F RID: 268047 RVA: 0x010CB988 File Offset: 0x010C9B88
		public MultiMotorData ActivityData
		{
			get
			{
				ActivityBaseData activityById = ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId);
				if (activityById == null)
				{
					return null;
				}
				return activityById as MultiMotorData;
			}
		}

		// Token: 0x06041710 RID: 268048 RVA: 0x010CB9B4 File Offset: 0x010C9BB4
		[NullableContext(1)]
		public List<int> GetCurrentOpenActivityAllLevel()
		{
			IReadOnlyList<OnlineMotorLevel> allMotorMultiParkourLevel = ConfigBase<MultiMotorConfig>.Instance.GetAllMotorMultiParkourLevel();
			List<int> list = new List<int>();
			IReadOnlyList<OnlineMotorLevel> readOnlyList = allMotorMultiParkourLevel;
			foreach (OnlineMotorLevel onlineMotorLevel in (readOnlyList ?? new List<OnlineMotorLevel>()))
			{
				list.Add(onlineMotorLevel.Id);
			}
			return list;
		}

		// Token: 0x06041711 RID: 268049 RVA: 0x010CBA20 File Offset: 0x010C9C20
		public bool GetLevelUnLock(int levelId)
		{
			MultiMotorData activityData = this.ActivityData;
			MultiMotorLevelData multiMotorLevelData = (activityData != null) ? activityData.LevelDataMap.GetValueOrDefault(levelId) : null;
			return multiMotorLevelData != null && multiMotorLevelData.IsUnLock;
		}

		// Token: 0x06041712 RID: 268050 RVA: 0x010CBA51 File Offset: 0x010C9C51
		public Dictionary<int, int> GetLevelRankBattleMap()
		{
			if (this.ActivityData == null)
			{
				return null;
			}
			return this.ActivityData.LevelBattleRankMap;
		}

		// Token: 0x06041713 RID: 268051 RVA: 0x010CBA68 File Offset: 0x010C9C68
		public bool CheckInMultiMotorEditFormationState()
		{
			InstanceDungeon? getCurrentDungeonConfig = ModelBase<EditBattleTeamModel>.Instance.GetCurrentDungeonConfig;
			return getCurrentDungeonConfig != null && getCurrentDungeonConfig.Value.InstSubType == 57;
		}

		// Token: 0x04024976 RID: 149878
		public int ActivityId;

		// Token: 0x04024977 RID: 149879
		public long StartFlowTime;
	}
}
