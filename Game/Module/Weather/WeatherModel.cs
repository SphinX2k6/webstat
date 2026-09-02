using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Area;

namespace CSharpScript.Game.Module.Weather
{
	// Token: 0x02004BFE RID: 19454
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class WeatherModel : ModelBase<WeatherModel>
	{
		// Token: 0x17008728 RID: 34600
		// (get) Token: 0x06032C47 RID: 207943 RVA: 0x00CB7BF6 File Offset: 0x00CB5DF6
		public int CurrentWeatherId
		{
			get
			{
				return this.WeatherId;
			}
		}

		// Token: 0x06032C48 RID: 207944 RVA: 0x00CB7BFE File Offset: 0x00CB5DFE
		public WeatherDefines.EWeatherType GetCurrentWeatherType()
		{
			if (this.WeatherId == 0)
			{
				return WeatherDefines.EWeatherType.None;
			}
			return ConfigBase<WeatherModuleConfig>.Instance.GetWeatherType(this.WeatherId);
		}

		// Token: 0x06032C49 RID: 207945 RVA: 0x00CB7C1A File Offset: 0x00CB5E1A
		public void SetCurrentWeatherId(int id)
		{
			this.WeatherId = id;
		}

		// Token: 0x06032C4A RID: 207946 RVA: 0x00CB7C23 File Offset: 0x00CB5E23
		public WeatherActor GetWorldWeatherActor()
		{
			return this.WorldWeatherActor;
		}

		// Token: 0x17008729 RID: 34601
		// (get) Token: 0x06032C4B RID: 207947 RVA: 0x00CB7C2C File Offset: 0x00CB5E2C
		private HashSet<int> ClickedWeatherSwitchConfigIdSet
		{
			get
			{
				if (this.ClickedWeatherSwitchConfigIdSetInternal == null)
				{
					this.ClickedWeatherSwitchConfigIdSetInternal = new HashSet<int>();
					foreach (int item in (LocalStorage.GetPlayer<List<int>>(ELocalStoragePlayerKey.WeatherCentralClicked, null) ?? new List<int>()))
					{
						this.ClickedWeatherSwitchConfigIdSetInternal.Add(item);
					}
				}
				return this.ClickedWeatherSwitchConfigIdSetInternal;
			}
		}

		// Token: 0x06032C4C RID: 207948 RVA: 0x00CB7CAC File Offset: 0x00CB5EAC
		public int GetSwitchConfigIdByWeatherId(int weatherId)
		{
			if (this.WeatherIdToWeatherSwitchConfigIdMap == null)
			{
				this.WeatherIdToWeatherSwitchConfigIdMap = new Dictionary<int, int>();
				foreach (WeatherSwitch weatherSwitch in ConfigBase<WeatherModuleConfig>.Instance.GetWeatherSwitchConfigAll())
				{
					foreach (DicIntInt dicIntInt in weatherSwitch.WeatherIter())
					{
						this.WeatherIdToWeatherSwitchConfigIdMap[dicIntInt.Value] = weatherSwitch.Id;
					}
				}
			}
			int result;
			if (!this.WeatherIdToWeatherSwitchConfigIdMap.TryGetValue(weatherId, out result))
			{
				return 0;
			}
			return result;
		}

		// Token: 0x06032C4D RID: 207949 RVA: 0x00CB7D6C File Offset: 0x00CB5F6C
		public int GetCurrentWeatherSwitchConfigId()
		{
			int currentAreaId = ModelBase<AreaModel>.Instance.GetCurrentAreaId(null);
			int levelOneAreaId = ConfigBase<AreaConfig>.Instance.GetLevelOneAreaId(currentAreaId);
			if (!this.IsInValidArea(levelOneAreaId))
			{
				return 0;
			}
			return this.GetSwitchConfigIdByWeatherId(this.CurrentWeatherId);
		}

		// Token: 0x06032C4E RID: 207950 RVA: 0x00CB7DB0 File Offset: 0x00CB5FB0
		public bool IsInValidArea(int levelOneAreaId)
		{
			if (this.ValidAreaIdSet == null)
			{
				this.ValidAreaIdSet = new HashSet<int>();
				foreach (Observatory observatory in ConfigObservatoryAll.GetConfigList(true))
				{
					this.ValidAreaIdSet.Add(observatory.AreaId);
				}
			}
			return this.ValidAreaIdSet.Contains(levelOneAreaId);
		}

		// Token: 0x06032C4F RID: 207951 RVA: 0x00CB7E28 File Offset: 0x00CB6028
		public bool IsWeatherBanArea(int weatherSwitchConfigId, int areaId)
		{
			WeatherSwitch? weatherSwitchConfig = ConfigBase<WeatherModuleConfig>.Instance.GetWeatherSwitchConfig(weatherSwitchConfigId);
			return weatherSwitchConfig != null && weatherSwitchConfig.Value.BanAreaList().Contains(areaId);
		}

		// Token: 0x06032C50 RID: 207952 RVA: 0x00CB7E64 File Offset: 0x00CB6064
		public bool IsCurrentTimeInValidTime(int id)
		{
			double hour = ModelBase<TimeOfDayModel>.Instance.GameTime.Hour;
			int[] array = ConfigBase<WeatherModuleConfig>.Instance.GetWeatherSwitchConfig(id).Value.ValidTime();
			int num = array[0];
			int num2 = array[1];
			if (num <= num2)
			{
				return hour >= (double)num && hour <= (double)num2;
			}
			return hour >= (double)num || hour <= (double)num2;
		}

		// Token: 0x06032C51 RID: 207953 RVA: 0x00CB7EC8 File Offset: 0x00CB60C8
		public int GetAccelerateWeatherTime(int id)
		{
			if (this.IsCurrentTimeInValidTime(id))
			{
				return 0;
			}
			int num = (int)ModelBase<TimeOfDayModel>.Instance.GameTime.Hour;
			int num2 = ConfigBase<WeatherModuleConfig>.Instance.GetWeatherSwitchConfig(id).Value.ValidTime()[0];
			int num3 = num2 - num;
			if (num3 < 0)
			{
				num3 += 24;
			}
			Singleton<Log>.Instance.Info(ELogModule.Weather, ELogAuthor.LJ, string.Concat(new string[]
			{
				"当前小时:",
				num.ToString(),
				" 目标小时:",
				num2.ToString(),
				" 相差小时数:",
				num3.ToString()
			}), default(ReadOnlySpan<ValueTuple<string, object>>));
			return num3 * 3600;
		}

		// Token: 0x06032C52 RID: 207954 RVA: 0x00CB7F80 File Offset: 0x00CB6180
		public void SetUnlockedWeatherSwitchConfigIdList(IEnumerable<int> list)
		{
			this.UnlockedWeatherSwitchConfigIdSet.Clear();
			foreach (int item in list)
			{
				this.UnlockedWeatherSwitchConfigIdSet.Add(item);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnWeatherCentralRedDotUpdate);
		}

		// Token: 0x06032C53 RID: 207955 RVA: 0x00CB7FEC File Offset: 0x00CB61EC
		public void AddUnlockedWeatherSwitchConfigId(int id)
		{
			this.UnlockedWeatherSwitchConfigIdSet.Add(id);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnWeatherCentralRedDotUpdate);
		}

		// Token: 0x06032C54 RID: 207956 RVA: 0x00CB800B File Offset: 0x00CB620B
		public bool IsWeatherSwitchConfigUnlocked(int id)
		{
			return this.UnlockedWeatherSwitchConfigIdSet.Contains(id);
		}

		// Token: 0x06032C55 RID: 207957 RVA: 0x00CB801C File Offset: 0x00CB621C
		public bool HasAnyNewWeather()
		{
			HashSet<int> unlockedWeatherSwitchConfigIdSet = this.UnlockedWeatherSwitchConfigIdSet;
			int num = (unlockedWeatherSwitchConfigIdSet != null) ? unlockedWeatherSwitchConfigIdSet.Count : 0;
			int count = this.ClickedWeatherSwitchConfigIdSet.Count;
			return num > count;
		}

		// Token: 0x06032C56 RID: 207958 RVA: 0x00CB804A File Offset: 0x00CB624A
		public bool IsWeatherClicked(int weatherSwitchConfigId)
		{
			return this.ClickedWeatherSwitchConfigIdSet.Contains(weatherSwitchConfigId);
		}

		// Token: 0x06032C57 RID: 207959 RVA: 0x00CB8058 File Offset: 0x00CB6258
		public void RecordWeatherClicked(int weatherSwitchConfigId)
		{
			this.ClickedWeatherSwitchConfigIdSet.Add(weatherSwitchConfigId);
			LocalStorage.SetPlayer<List<int>>(ELocalStoragePlayerKey.WeatherCentralClicked, this.ClickedWeatherSwitchConfigIdSet.ToList<int>());
			Singleton<EventSystem>.Instance.Emit(EEventName.OnWeatherCentralRedDotUpdate);
		}

		// Token: 0x06032C58 RID: 207960 RVA: 0x00CB808D File Offset: 0x00CB628D
		public void RecordSwitchTime()
		{
			this.LastSwitchTime = Singleton<Time>.Instance.WorldTime;
		}

		// Token: 0x06032C59 RID: 207961 RVA: 0x00CB80A0 File Offset: 0x00CB62A0
		public int GetRemainCoolDownTime()
		{
			double num = (Singleton<Time>.Instance.WorldTime - this.LastSwitchTime) * 0.0010000000474974513;
			return (int)Math.Ceiling((double)ConfigCommonParamById.GetIntConfig("WeatherControlCoolDown").Value - num);
		}

		// Token: 0x06032C5A RID: 207962 RVA: 0x00CB80E4 File Offset: 0x00CB62E4
		public bool CanSwitchWeather()
		{
			return this.GetRemainCoolDownTime() <= 0;
		}

		// Token: 0x1700872A RID: 34602
		// (get) Token: 0x06032C5B RID: 207963 RVA: 0x00CB80F2 File Offset: 0x00CB62F2
		public ObservatoryModule ObservatoryModule
		{
			get
			{
				if (this.ObservatoryModuleInternal == null)
				{
					this.ObservatoryModuleInternal = new ObservatoryModule();
				}
				return this.ObservatoryModuleInternal;
			}
		}

		// Token: 0x1700872B RID: 34603
		// (get) Token: 0x06032C5C RID: 207964 RVA: 0x00CB8110 File Offset: 0x00CB6310
		public int? TargetWeatherSwitchConfigId
		{
			get
			{
				if (this.TargetWeatherSwitchConfigIdInternal != null)
				{
					int value = this.TargetWeatherSwitchConfigIdInternal.Value;
					this.TargetWeatherSwitchConfigIdInternal = null;
					return new int?(value);
				}
				return null;
			}
		}

		// Token: 0x06032C5D RID: 207965 RVA: 0x00CB8150 File Offset: 0x00CB6350
		public void SetTargetWeatherSwitchConfigId(int weatherSwitchConfigId)
		{
			this.TargetWeatherSwitchConfigIdInternal = new int?(weatherSwitchConfigId);
		}

		// Token: 0x0401D8AA RID: 121002
		private readonly WeatherActor WorldWeatherActor = new WeatherActor();

		// Token: 0x0401D8AB RID: 121003
		private int WeatherId;

		// Token: 0x0401D8AC RID: 121004
		private readonly HashSet<int> UnlockedWeatherSwitchConfigIdSet = new HashSet<int>();

		// Token: 0x0401D8AD RID: 121005
		[Nullable(2)]
		private HashSet<int> ClickedWeatherSwitchConfigIdSetInternal;

		// Token: 0x0401D8AE RID: 121006
		[Nullable(2)]
		private Dictionary<int, int> WeatherIdToWeatherSwitchConfigIdMap;

		// Token: 0x0401D8AF RID: 121007
		[Nullable(2)]
		private HashSet<int> ValidAreaIdSet;

		// Token: 0x0401D8B0 RID: 121008
		public double LastSwitchTime;

		// Token: 0x0401D8B1 RID: 121009
		public bool TimeSwitchConfirmNeedShow = true;

		// Token: 0x0401D8B2 RID: 121010
		[Nullable(2)]
		private ObservatoryModule ObservatoryModuleInternal;

		// Token: 0x0401D8B3 RID: 121011
		private int? TargetWeatherSwitchConfigIdInternal;
	}
}
