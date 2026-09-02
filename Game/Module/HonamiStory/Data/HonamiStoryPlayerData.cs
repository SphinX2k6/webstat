using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.HonamiStory.Data
{
	// Token: 0x02005C9C RID: 23708
	[NullableContext(1)]
	[Nullable(0)]
	public class HonamiStoryPlayerData
	{
		// Token: 0x0603BDA0 RID: 245152 RVA: 0x00F2B85D File Offset: 0x00F29A5D
		public static HonamiStoryPlayerData Create()
		{
			return new HonamiStoryPlayerData();
		}

		// Token: 0x0603BDA1 RID: 245153 RVA: 0x00F2B864 File Offset: 0x00F29A64
		public void SetLifeSupportLevel(int value)
		{
			if (this.LifeSupportLevelMap.Count == 0)
			{
				int activityId = ModelBase<HonamiStoryModel>.Instance.ActivityId;
				IReadOnlyList<HonamiStoryLifeSupport> lifeSupportList = ConfigBase<HonamiStoryConfig>.Instance.GetLifeSupportList(activityId);
				if (lifeSupportList == null)
				{
					return;
				}
				foreach (HonamiStoryLifeSupport honamiStoryLifeSupport in lifeSupportList)
				{
					this.LifeSupportLevelMap[honamiStoryLifeSupport.Level] = honamiStoryLifeSupport.Id;
				}
			}
			int id;
			if (!this.LifeSupportLevelMap.TryGetValue(value, out id))
			{
				return;
			}
			HonamiStoryLifeSupport? lifeSupport = ConfigBase<HonamiStoryConfig>.Instance.GetLifeSupport(id);
			if (lifeSupport == null)
			{
				return;
			}
			this.LifeSupportLevel = value;
			this.LifeSupportId = lifeSupport.Value.Id;
		}

		// Token: 0x0603BDA2 RID: 245154 RVA: 0x00F2B930 File Offset: 0x00F29B30
		public int GetCurLevelId(int level)
		{
			return this.LifeSupportLevelMap.GetValueOrDefault(level, 0);
		}

		// Token: 0x0603BDA3 RID: 245155 RVA: 0x00F2B940 File Offset: 0x00F29B40
		public int GetCurMaxValue()
		{
			int id;
			if (!this.LifeSupportLevelMap.TryGetValue(this.LifeSupportLevel, out id))
			{
				return 0;
			}
			return ConfigBase<HonamiStoryConfig>.Instance.GetLifeSupport(id).Value.SteadyValue;
		}

		// Token: 0x0603BDA4 RID: 245156 RVA: 0x00F2B97F File Offset: 0x00F29B7F
		public void UpdatePowerLevel()
		{
			this.PowerLevel = ModelBase<HonamiStoryModel>.Instance.GetPlayerBackpackData().GetPowerLevel(true);
		}

		// Token: 0x0603BDA5 RID: 245157 RVA: 0x00F2B998 File Offset: 0x00F29B98
		public int GetLifeSupportMaxLevel()
		{
			int num = 0;
			foreach (KeyValuePair<int, int> keyValuePair in this.LifeSupportLevelMap)
			{
				int val;
				int num2;
				keyValuePair.Deconstruct(out val, out num2);
				num = Math.Max(val, num);
			}
			return num;
		}

		// Token: 0x0603BDA6 RID: 245158 RVA: 0x00F2B9FC File Offset: 0x00F29BFC
		public string GetLifeSupportIcon()
		{
			if (!ModelBase<FunctionModel>.Instance.IsOpen(10105))
			{
				if (string.IsNullOrEmpty(this.MainInstPath))
				{
					this.MainInstPath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_MainBarIconFirst");
				}
				return this.MainInstPath;
			}
			EFormationAttributeId attrId = EFormationAttributeId.HonamiStoryLifeSupport;
			float value = ControllerBase<FormationAttributeController>.Instance.GetValue(attrId);
			float max = ControllerBase<FormationAttributeController>.Instance.GetMax(attrId);
			if (value > max / 2f)
			{
				if (string.IsNullOrEmpty(this.NormalIconPath))
				{
					this.NormalIconPath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_MainBarIcon");
				}
				return this.NormalIconPath;
			}
			if (string.IsNullOrEmpty(this.NormalDangerPath))
			{
				this.NormalDangerPath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_MainBarIconDanger");
			}
			return this.NormalDangerPath;
		}

		// Token: 0x04021A5D RID: 137821
		private const int INVALID_NUM = -1;

		// Token: 0x04021A5E RID: 137822
		public int PowerLevel = -1;

		// Token: 0x04021A5F RID: 137823
		public int LifeSupportLevel = -1;

		// Token: 0x04021A60 RID: 137824
		public int LifeSupportId = -1;

		// Token: 0x04021A61 RID: 137825
		private string NormalIconPath = string.Empty;

		// Token: 0x04021A62 RID: 137826
		private string NormalDangerPath = string.Empty;

		// Token: 0x04021A63 RID: 137827
		private string MainInstPath = string.Empty;

		// Token: 0x04021A64 RID: 137828
		private readonly Dictionary<int, int> LifeSupportLevelMap = new Dictionary<int, int>();
	}
}
