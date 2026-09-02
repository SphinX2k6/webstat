using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.HonamiStory;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200603F RID: 24639
	public class HonamiStoryMonsterLevelItem : StateExtraItemBase
	{
		// Token: 0x0603E265 RID: 254565 RVA: 0x00FDD520 File Offset: 0x00FDB720
		[NullableContext(1)]
		protected override void OnInitExtraParams(ExtraItemParams param)
		{
			int honamiStoryLevel = ((HonamiStoryLevelItemParams)param).HonamiStoryLevel;
			int powerLevel = ModelBase<HonamiStoryModel>.Instance.PlayerData.PowerLevel;
			this.OriginLevel = honamiStoryLevel;
			int pollutionLevel = ModelBase<HonamiStoryModel>.Instance.PollutionLevel;
			Dictionary<int, IHonamiStoryPollution> pollutionLevelMap = ModelBase<HonamiStoryModel>.Instance.PollutionLevelMap;
			int? num;
			if (pollutionLevelMap == null)
			{
				num = null;
			}
			else
			{
				IHonamiStoryPollution valueOrDefault = pollutionLevelMap.GetValueOrDefault(pollutionLevel);
				num = ((valueOrDefault != null) ? new int?(valueOrDefault.MonsterEnhanceLevel) : null);
			}
			int? num2 = num;
			int valueOrDefault2 = num2.GetValueOrDefault();
			int newLevel = honamiStoryLevel + valueOrDefault2 + ModelBase<HonamiStoryModel>.Instance.MonsterBaseEnhanceLevel;
			this.RefreshLevel(newLevel, powerLevel, true);
			if (!Singleton<EventSystem>.Instance.Has(EEventName.OnHonamiStoryPowerLevelUpdate, new Action<int, int>(this.OnRefreshPlayerLevel)))
			{
				Singleton<EventSystem>.Instance.Add(EEventName.OnHonamiStoryPowerLevelUpdate, new Action<int, int>(this.OnRefreshPlayerLevel));
			}
			if (!Singleton<EventSystem>.Instance.Has(EEventName.OnHonamiStoryPollutionUpdate, new Action<int>(this.OnRefreshPollutionLevel)))
			{
				Singleton<EventSystem>.Instance.Add<int>(EEventName.OnHonamiStoryPollutionUpdate, new Action<int>(this.OnRefreshPollutionLevel));
			}
		}

		// Token: 0x0603E266 RID: 254566 RVA: 0x00FDD62C File Offset: 0x00FDB82C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E267 RID: 254567 RVA: 0x00FDD6D7 File Offset: 0x00FDB8D7
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnHonamiStoryPowerLevelUpdate, new Action<int, int>(this.OnRefreshPlayerLevel));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnHonamiStoryPollutionUpdate, new Action<int>(this.OnRefreshPollutionLevel));
		}

		// Token: 0x0603E268 RID: 254568 RVA: 0x00FDD714 File Offset: 0x00FDB914
		private void OnRefreshPollutionLevel(int monsterEnhanceLevel)
		{
			int newLevel = this.OriginLevel + monsterEnhanceLevel + ModelBase<HonamiStoryModel>.Instance.MonsterBaseEnhanceLevel;
			this.RefreshLevel(newLevel, this.PlayerLevel, false);
		}

		// Token: 0x0603E269 RID: 254569 RVA: 0x00FDD743 File Offset: 0x00FDB943
		private void OnRefreshPlayerLevel(int oldValue, int newValue)
		{
			this.RefreshLevel(this.CurrentLevel, newValue, false);
		}

		// Token: 0x0603E26A RID: 254570 RVA: 0x00FDD754 File Offset: 0x00FDB954
		private void RefreshLevel(int newLevel, int playerLevel, bool isInit = false)
		{
			this.PlayerLevel = playerLevel;
			HonamiStoryMonsterLevelItem.ELevelStateType levelState = this.GetLevelState(newLevel, playerLevel);
			if (isInit || this.CurrentState != levelState)
			{
				this.RefreshLevelState(levelState);
				this.CurrentState = levelState;
			}
			if (isInit || this.CurrentLevel != newLevel)
			{
				base.GetText(0).SetText(newLevel.ToString(), true);
				this.CurrentLevel = newLevel;
			}
		}

		// Token: 0x0603E26B RID: 254571 RVA: 0x00FDD7B4 File Offset: 0x00FDB9B4
		private void RefreshLevelState(HonamiStoryMonsterLevelItem.ELevelStateType state)
		{
			string hexStr = "#a5f3cbff";
			string hexStr2 = "#a5f3cb99";
			if (state == HonamiStoryMonsterLevelItem.ELevelStateType.Normal)
			{
				hexStr = "#f8dc97ff";
				hexStr2 = "#fae8bd99";
			}
			else if (state == HonamiStoryMonsterLevelItem.ELevelStateType.Danger)
			{
				hexStr = "#f47d89ff";
				hexStr2 = "#90586099";
			}
			base.GetText(0).SetColor(FColor.FromHex(hexStr));
			FColor color = FColor.FromHex(hexStr2);
			base.GetSprite(1).SetColor(color);
			base.GetSprite(2).SetColor(color);
			base.GetSprite(3).SetColor(color);
		}

		// Token: 0x0603E26C RID: 254572 RVA: 0x00FDD830 File Offset: 0x00FDBA30
		private HonamiStoryMonsterLevelItem.ELevelStateType GetLevelState(int newLevel, int playerLevel)
		{
			int num = playerLevel - newLevel;
			if (num > ModelBase<HonamiStoryModel>.Instance.MonsterLevelSafeOffset)
			{
				return HonamiStoryMonsterLevelItem.ELevelStateType.Safe;
			}
			if (num < ModelBase<HonamiStoryModel>.Instance.MonsterLevelDangerOffset)
			{
				return HonamiStoryMonsterLevelItem.ELevelStateType.Danger;
			}
			return HonamiStoryMonsterLevelItem.ELevelStateType.Normal;
		}

		// Token: 0x04022D6C RID: 142700
		private int OriginLevel;

		// Token: 0x04022D6D RID: 142701
		private int PlayerLevel;

		// Token: 0x04022D6E RID: 142702
		private int CurrentLevel;

		// Token: 0x04022D6F RID: 142703
		private HonamiStoryMonsterLevelItem.ELevelStateType CurrentState;

		// Token: 0x0200C101 RID: 49409
		private enum ELevelStateType
		{
			// Token: 0x0403B6F3 RID: 243443
			Safe,
			// Token: 0x0403B6F4 RID: 243444
			Normal,
			// Token: 0x0403B6F5 RID: 243445
			Danger
		}

		// Token: 0x0200C102 RID: 49410
		private enum EComponentType
		{
			// Token: 0x0403B6F7 RID: 243447
			LevelText,
			// Token: 0x0403B6F8 RID: 243448
			LevelBgSprite,
			// Token: 0x0403B6F9 RID: 243449
			LevelIconSprite,
			// Token: 0x0403B6FA RID: 243450
			LevelCircleSprite
		}
	}
}
