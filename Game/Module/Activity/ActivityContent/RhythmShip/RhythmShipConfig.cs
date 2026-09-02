using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip
{
	// Token: 0x020064C4 RID: 25796
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class RhythmShipConfig : ConfigBase<RhythmShipConfig>
	{
		// Token: 0x06040A20 RID: 264736 RVA: 0x01091516 File Offset: 0x0108F716
		public RhythmShipPlanet? GetRhythmShipPlanetById(int id)
		{
			return ConfigRhythmShipPlanetById.GetConfig(id, true);
		}

		// Token: 0x06040A21 RID: 264737 RVA: 0x01091520 File Offset: 0x0108F720
		public List<int> GetRhythmShipPlanetIdListByType(int type, int activityId)
		{
			List<int> list = new List<int>();
			foreach (RhythmShipPlanet rhythmShipPlanet in (ConfigRhythmShipPlanetByType.GetConfigList(type, true) ?? new List<RhythmShipPlanet>()))
			{
				if (type == 2 || rhythmShipPlanet.ActivityId == activityId)
				{
					list.Add(rhythmShipPlanet.Id);
				}
			}
			return list;
		}

		// Token: 0x06040A22 RID: 264738 RVA: 0x01091594 File Offset: 0x0108F794
		public RhythmShipLevel? GetRhythmShipLevelById(int id)
		{
			return ConfigRhythmShipLevelById.GetConfig(id, true);
		}

		// Token: 0x06040A23 RID: 264739 RVA: 0x0109159D File Offset: 0x0108F79D
		public RhythmSubLevel? GetRhythmShipSubLevelById(int id)
		{
			return ConfigRhythmSubLevelById.GetConfig(id, true);
		}

		// Token: 0x06040A24 RID: 264740 RVA: 0x010915A6 File Offset: 0x0108F7A6
		[NullableContext(2)]
		public IReadOnlyList<RhythmSubLevel> GetRhythmShipSubLevelByLevelId(int id)
		{
			return ConfigRhythmSubLevelByLevelId.GetConfigList(id, true);
		}

		// Token: 0x06040A25 RID: 264741 RVA: 0x010915B0 File Offset: 0x0108F7B0
		public List<int> GetRhythmShipSubLevelIdByLevelId(int id)
		{
			List<int> list = new List<int>();
			foreach (RhythmSubLevel rhythmSubLevel in (ConfigRhythmSubLevelByLevelId.GetConfigList(id, true) ?? new List<RhythmSubLevel>()))
			{
				list.Add(rhythmSubLevel.Id);
			}
			return list;
		}

		// Token: 0x06040A26 RID: 264742 RVA: 0x01091614 File Offset: 0x0108F814
		public List<int> GetRhythmShipLevelIdListByPlanet(int planet)
		{
			List<int> list = new List<int>();
			foreach (RhythmShipLevel rhythmShipLevel in (ConfigRhythmShipLevelByPlanet.GetConfigList(planet, true) ?? new List<RhythmShipLevel>()))
			{
				list.Add(rhythmShipLevel.Id);
			}
			return list;
		}

		// Token: 0x06040A27 RID: 264743 RVA: 0x01091678 File Offset: 0x0108F878
		public RhythmRole? GetRhythmRoleById(int id)
		{
			return ConfigRhythmRoleById.GetConfig(id, true);
		}

		// Token: 0x06040A28 RID: 264744 RVA: 0x01091684 File Offset: 0x0108F884
		public RhythmEffect? GetRhythmRoleEffectById(int id)
		{
			RhythmEffect? config = ConfigRhythmEffectById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RhythmGame;
				ELogAuthor author = ELogAuthor.BB;
				string message = "RhythmEffect not found";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return config;
		}

		// Token: 0x06040A29 RID: 264745 RVA: 0x010916DC File Offset: 0x0108F8DC
		public List<int> GetRhythmRoleAll()
		{
			List<int> list = new List<int>();
			foreach (RhythmRole rhythmRole in (ConfigRhythmRoleAll.GetConfigList(true) ?? new List<RhythmRole>()))
			{
				list.Add(rhythmRole.Id);
			}
			return list;
		}

		// Token: 0x06040A2A RID: 264746 RVA: 0x01091740 File Offset: 0x0108F940
		public RhythmTask? GetRhythmShipTaskById(int id)
		{
			return ConfigRhythmTaskById.GetConfig(id, true);
		}

		// Token: 0x06040A2B RID: 264747 RVA: 0x0109174C File Offset: 0x0108F94C
		public List<int> GetRhythmShipTaskIdByTypeAndActivityId(int type, int activityData)
		{
			List<int> list = new List<int>();
			foreach (RhythmTask rhythmTask in (ConfigRhythmTaskByActivityIdAndTaskType.GetConfigList(activityData, type, true) ?? new List<RhythmTask>()))
			{
				list.Add(rhythmTask.Id);
			}
			return list;
		}

		// Token: 0x06040A2C RID: 264748 RVA: 0x010917B4 File Offset: 0x0108F9B4
		public RhythmTaskTab? GetRhythmShipTaskTabById(int id)
		{
			return ConfigRhythmTaskTabById.GetConfig(id, true);
		}

		// Token: 0x06040A2D RID: 264749 RVA: 0x010917C0 File Offset: 0x0108F9C0
		public List<int> GetRhythmShipTaskTabByTabIdAndActivityId(int tab, int activityData)
		{
			List<int> list = new List<int>();
			foreach (RhythmTask rhythmTask in (ConfigRhythmTaskByActivityIdAndTaskTab.GetConfigList(activityData, tab, true) ?? new List<RhythmTask>()))
			{
				list.Add(rhythmTask.Id);
			}
			return list;
		}

		// Token: 0x06040A2E RID: 264750 RVA: 0x01091828 File Offset: 0x0108FA28
		public RhythmBg? GetRhythmShipBgById(int id)
		{
			return ConfigRhythmBgById.GetConfig(id, true);
		}

		// Token: 0x06040A2F RID: 264751 RVA: 0x01091834 File Offset: 0x0108FA34
		public List<int> GetRhythmShipActionAll()
		{
			List<int> list = new List<int>();
			foreach (RhythmShipAction rhythmShipAction in (ConfigRhythmShipActionAll.GetConfigList(true) ?? new List<RhythmShipAction>()))
			{
				list.Add(rhythmShipAction.Id);
			}
			return list;
		}

		// Token: 0x06040A30 RID: 264752 RVA: 0x01091898 File Offset: 0x0108FA98
		public RhythmShipAction? GetRhythmShipActionById(int id)
		{
			return ConfigRhythmShipActionById.GetConfig(id, true);
		}

		// Token: 0x06040A31 RID: 264753 RVA: 0x010918A1 File Offset: 0x0108FAA1
		public RhythmActivity? GetRhythmShipActivity(int id)
		{
			return ConfigRhythmActivityByActivityId.GetConfig(id, true);
		}
	}
}
