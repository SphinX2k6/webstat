using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Personal;

// Token: 0x020017B8 RID: 6072
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class BirthdayModel : ModelBase<BirthdayModel>
{
	// Token: 0x0600AB44 RID: 43844 RVA: 0x002DC500 File Offset: 0x002DA700
	public bool IsDuringBirthday()
	{
		if (!this.IsReset)
		{
			return false;
		}
		int year = new DateTime(1970, 1, 1).AddSeconds(Singleton<TimeUtil>.Instance.GetServerTimeStamp() / (double)Singleton<TimeUtil>.Instance.InverseMillisecond).Year;
		this.ThisBirthdayYear = year;
		int num = ConfigBirthDayByYear.GetConfig(year, true).Value.ValidDay + 1;
		double num2;
		if (year - 1 >= this.ResetYear)
		{
			DateTime birthdayDate = this.GetBirthdayDate(year - 1);
			num2 = this.CalculateDayGapBetweenNow(birthdayDate);
			if (0.0 <= num2 && num2 <= (double)num)
			{
				this.ThisBirthdayYear = year - 1;
				return true;
			}
		}
		DateTime birthdayDate2 = this.GetBirthdayDate(year);
		num2 = this.CalculateDayGapBetweenNow(birthdayDate2);
		return 0.0 <= num2 && num2 <= (double)num;
	}

	// Token: 0x0600AB45 RID: 43845 RVA: 0x002DC5DC File Offset: 0x002DA7DC
	public DateTime GetBirthdayDate(int year)
	{
		int birthday = ModelBase<PersonalModel>.Instance.GetBirthday();
		int num = birthday / 100;
		int num2 = birthday % 100;
		if (!DateTime.IsLeapYear(year) && num == 2 && num2 == 29)
		{
			num2 = 28;
		}
		DateTime result = new DateTime(year, 1, 1);
		result = result.AddMonths(num - 1);
		result = result.AddDays((double)(num2 - 1));
		return result;
	}

	// Token: 0x0600AB46 RID: 43846 RVA: 0x002DC634 File Offset: 0x002DA834
	public double CalculateDayGapBetweenNow(DateTime birthdayDate)
	{
		double num = (Singleton<TimeUtil>.Instance.GetServerTimeStamp() - birthdayDate.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds) / (double)Singleton<TimeUtil>.Instance.InverseMillisecond;
		double num2 = 86400.0;
		return num / num2;
	}

	// Token: 0x0600AB47 RID: 43847 RVA: 0x002DC680 File Offset: 0x002DA880
	public void UpdateBirthdayInfo(BirthDayInfoNotify notify)
	{
		this.IsReset = notify.BirthDayReset;
		if (!notify.BirthDayReset)
		{
			return;
		}
		foreach (BirthRoleSelect birthRoleSelect in notify.Roles)
		{
			this.BirthdayRoleMap[birthRoleSelect.Year] = birthRoleSelect.Role;
		}
		bool flag = this.IsDuringBirthday();
		if (notify.RecentRewardTime == this.ThisBirthdayYear)
		{
			this.IsReceiveBirthdayReward = true;
		}
		if (!this.IsReceiveBirthdayReward && flag)
		{
			ControllerBase<BirthdayController>.Instance.TryOpenBirthdayView(false);
		}
	}

	// Token: 0x0600AB48 RID: 43848 RVA: 0x002DC728 File Offset: 0x002DA928
	public List<int> GetRoleIdList()
	{
		List<int> list = new List<int>();
		List<RoleBirthday> list2 = new List<RoleBirthday>(ConfigRoleBirthdayAll.GetConfigList(true) ?? new List<RoleBirthday>());
		list2.Sort(delegate(RoleBirthday roleBirthdayA, RoleBirthday roleBirthdayB)
		{
			int roleId = roleBirthdayA.RoleId;
			int roleId2 = roleBirthdayB.RoleId;
			int num = roleBirthdayB.Priority - roleBirthdayA.Priority;
			if (num != 0)
			{
				return num;
			}
			return roleId - roleId2;
		});
		foreach (RoleBirthday roleBirthday in list2)
		{
			list.Add(roleBirthday.RoleId);
		}
		return list;
	}

	// Token: 0x0600AB49 RID: 43849 RVA: 0x002DC7BC File Offset: 0x002DA9BC
	public void ResetBirthday()
	{
		this.IsReset = true;
		if (this.IsDuringBirthday())
		{
			ControllerBase<BirthdayController>.Instance.TryOpenBirthdayView(false);
		}
	}

	// Token: 0x0600AB4A RID: 43850 RVA: 0x002DC7D8 File Offset: 0x002DA9D8
	public bool IsRoleSelected(int roleId)
	{
		foreach (KeyValuePair<int, int> keyValuePair in this.BirthdayRoleMap)
		{
			int value = keyValuePair.Value;
			if (roleId == value)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600AB4B RID: 43851 RVA: 0x002DC838 File Offset: 0x002DAA38
	public int GetBirthdayCount()
	{
		int num = 0;
		foreach (KeyValuePair<int, int> keyValuePair in this.BirthdayRoleMap)
		{
			if (keyValuePair.Value != 0)
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x0600AB4C RID: 43852 RVA: 0x002DC894 File Offset: 0x002DAA94
	public int? GetSelectedRoleId(int year)
	{
		int value;
		if (this.BirthdayRoleMap.TryGetValue(year, out value))
		{
			return new int?(value);
		}
		return null;
	}

	// Token: 0x0600AB4D RID: 43853 RVA: 0x002DC8C1 File Offset: 0x002DAAC1
	public bool GetBirthdayRedDotState()
	{
		return ModelBase<FunctionModel>.Instance.IsOpen(10084) && !this.IsReset;
	}

	// Token: 0x0600AB4E RID: 43854 RVA: 0x002DC8DF File Offset: 0x002DAADF
	public bool GetBirthdayIsReset()
	{
		return this.IsReset;
	}

	// Token: 0x0600AB4F RID: 43855 RVA: 0x002DC8E7 File Offset: 0x002DAAE7
	public void SetIsReceiveBirthdayReward(bool isReceiveBirthdayReward)
	{
		this.IsReceiveBirthdayReward = isReceiveBirthdayReward;
	}

	// Token: 0x0600AB50 RID: 43856 RVA: 0x002DC8F0 File Offset: 0x002DAAF0
	public void SetSelectedRole(int roleId, int year)
	{
		this.BirthdayRoleMap[year] = roleId;
	}

	// Token: 0x0600AB51 RID: 43857 RVA: 0x002DC8FF File Offset: 0x002DAAFF
	public void SyncTsResetState(bool isReset)
	{
		this.IsReset = isReset;
		Singleton<EventSystem>.Instance.Emit(EEventName.OnBirthChange);
	}

	// Token: 0x0600AB52 RID: 43858 RVA: 0x002DC918 File Offset: 0x002DAB18
	public string GetLetterViewResource(int year)
	{
		if (year == 2025)
		{
			return "";
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 1);
		defaultInterpolatedStringHandler.AppendLiteral("UiView_BirthdayLetter");
		defaultInterpolatedStringHandler.AppendFormatted<int>(year % 2000);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0600AB53 RID: 43859 RVA: 0x002DC960 File Offset: 0x002DAB60
	public string GetRoleSelectViewResource(int year)
	{
		if (year == 2025)
		{
			return "";
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(19, 1);
		defaultInterpolatedStringHandler.AppendLiteral("UiView_BirthdayRole");
		defaultInterpolatedStringHandler.AppendFormatted<int>(year % 2000);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0600AB54 RID: 43860 RVA: 0x002DC9A8 File Offset: 0x002DABA8
	public string GetSelectConfirmViewResource(int year)
	{
		if (year == 2025)
		{
			return "";
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 1);
		defaultInterpolatedStringHandler.AppendLiteral("UiView_BirthdayConfirm");
		defaultInterpolatedStringHandler.AppendFormatted<int>(year % 2000);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0600AB55 RID: 43861 RVA: 0x002DC9F0 File Offset: 0x002DABF0
	public string GetLetterViewBgm(int year)
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(19, 1);
		defaultInterpolatedStringHandler.AppendLiteral("BirthdayLetterBGM20");
		defaultInterpolatedStringHandler.AppendFormatted<int>(year % 2000);
		return ConfigCommonParamById.GetStringConfig(defaultInterpolatedStringHandler.ToStringAndClear()) ?? "";
	}

	// Token: 0x0600AB56 RID: 43862 RVA: 0x002DCA38 File Offset: 0x002DAC38
	public EConfirmBoxConfigId GetLetterExitConfirmId(int year)
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 1);
		defaultInterpolatedStringHandler.AppendLiteral("BirthdayLetterExitConfirmId20");
		defaultInterpolatedStringHandler.AppendFormatted<int>(year % 2000);
		return (EConfirmBoxConfigId)ConfigCommonParamById.GetIntConfig(defaultInterpolatedStringHandler.ToStringAndClear()).GetValueOrDefault(302);
	}

	// Token: 0x0600AB57 RID: 43863 RVA: 0x002DCA84 File Offset: 0x002DAC84
	public float GetPlayTimeOffset()
	{
		return ConfigCommonParamById.GetFloatConfig("BirthdayTextPlayTimeOffset").GetValueOrDefault();
	}

	// Token: 0x04005178 RID: 20856
	private bool IsReset;

	// Token: 0x04005179 RID: 20857
	public int ResetYear;

	// Token: 0x0400517A RID: 20858
	private readonly Dictionary<int, int> BirthdayRoleMap = new Dictionary<int, int>();

	// Token: 0x0400517B RID: 20859
	public int ThisBirthdayYear;

	// Token: 0x0400517C RID: 20860
	public bool IsReceiveBirthdayReward;

	// Token: 0x0400517D RID: 20861
	private const int DefaultYear = 2025;

	// Token: 0x0400517E RID: 20862
	private const int TwoThousand = 2000;
}
