using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x0200131E RID: 4894
[NullableContext(1)]
[Nullable(0)]
public class FightPhotoLevelGroupData
{
	// Token: 0x06008575 RID: 34165 RVA: 0x002323E3 File Offset: 0x002305E3
	public FightPhotoLevelGroupData(PhotoFightActivityGroup config)
	{
		this.Config = config;
	}

	// Token: 0x06008576 RID: 34166 RVA: 0x00232408 File Offset: 0x00230608
	public void PushFightPhotoLevel(FightPhotoLevelData level)
	{
		this.FightPhotoLevelList.Add(level);
		foreach (int item in level.TargetRoles)
		{
			if (!this.TargetRoleIdListInternal.Contains(item))
			{
				this.TargetRoleIdListInternal.Add(item);
			}
		}
	}

	// Token: 0x17000B55 RID: 2901
	// (get) Token: 0x06008577 RID: 34167 RVA: 0x0023247C File Offset: 0x0023067C
	[Nullable(0)]
	public Span<int> LevelIdList
	{
		[NullableContext(0)]
		get
		{
			return this.Config.GetDifficultyBytes();
		}
	}

	// Token: 0x17000B56 RID: 2902
	// (get) Token: 0x06008578 RID: 34168 RVA: 0x00232489 File Offset: 0x00230689
	public List<FightPhotoLevelData> LevelDataList
	{
		get
		{
			return this.FightPhotoLevelList;
		}
	}

	// Token: 0x17000B57 RID: 2903
	// (get) Token: 0x0600857A RID: 34170 RVA: 0x002324A6 File Offset: 0x002306A6
	// (set) Token: 0x06008579 RID: 34169 RVA: 0x00232491 File Offset: 0x00230691
	public long UnlockTime
	{
		get
		{
			return this.UnlockTimeInterval;
		}
		set
		{
			this.UnlockTimeInterval = value / (long)Singleton<TimeUtil>.Instance.InverseMillisecond;
		}
	}

	// Token: 0x0600857B RID: 34171 RVA: 0x002324B0 File Offset: 0x002306B0
	public bool IsReachUnlockTime()
	{
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		return this.UnlockTimeInterval == 0L || (double)this.UnlockTime < serverTime;
	}

	// Token: 0x17000B58 RID: 2904
	// (get) Token: 0x0600857C RID: 34172 RVA: 0x002324DC File Offset: 0x002306DC
	public bool IsUnLock
	{
		get
		{
			return this.IsReachUnlockTime();
		}
	}

	// Token: 0x17000B59 RID: 2905
	// (get) Token: 0x0600857D RID: 34173 RVA: 0x002324E4 File Offset: 0x002306E4
	public bool IsFinished
	{
		get
		{
			using (List<FightPhotoLevelData>.Enumerator enumerator = this.FightPhotoLevelList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!enumerator.Current.IsFinished)
					{
						return false;
					}
				}
			}
			return true;
		}
	}

	// Token: 0x17000B5A RID: 2906
	// (get) Token: 0x0600857E RID: 34174 RVA: 0x00232540 File Offset: 0x00230740
	public FightPhotoLevelData FirstUnFinishedLevelData
	{
		get
		{
			FightPhotoLevelData fightPhotoLevelData = null;
			int i = 0;
			int count = this.FightPhotoLevelList.Count;
			while (i < count)
			{
				FightPhotoLevelData fightPhotoLevelData2 = this.FightPhotoLevelList[i];
				if (fightPhotoLevelData2.IsUnLock && !fightPhotoLevelData2.IsFinished)
				{
					fightPhotoLevelData = fightPhotoLevelData2;
					break;
				}
				i++;
			}
			if (fightPhotoLevelData == null)
			{
				int j = 0;
				int count2 = this.FightPhotoLevelList.Count;
				while (j < count2)
				{
					FightPhotoLevelData fightPhotoLevelData3 = this.FightPhotoLevelList[j];
					if (!fightPhotoLevelData3.IsUnLock)
					{
						fightPhotoLevelData = fightPhotoLevelData3;
						break;
					}
					j++;
				}
			}
			if (fightPhotoLevelData == null && this.FightPhotoLevelList.Count > 0)
			{
				fightPhotoLevelData = this.FightPhotoLevelList[this.FightPhotoLevelList.Count - 1];
			}
			return fightPhotoLevelData;
		}
	}

	// Token: 0x17000B5B RID: 2907
	// (get) Token: 0x0600857F RID: 34175 RVA: 0x002325F4 File Offset: 0x002307F4
	public bool HasRedDot
	{
		get
		{
			using (List<FightPhotoLevelData>.Enumerator enumerator = this.FightPhotoLevelList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.HasRedDot)
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	// Token: 0x17000B5C RID: 2908
	// (get) Token: 0x06008580 RID: 34176 RVA: 0x00232650 File Offset: 0x00230850
	public int Id
	{
		get
		{
			return this.Config.Id;
		}
	}

	// Token: 0x17000B5D RID: 2909
	// (get) Token: 0x06008581 RID: 34177 RVA: 0x0023265D File Offset: 0x0023085D
	public int SortId
	{
		get
		{
			return this.Config.SortId;
		}
	}

	// Token: 0x17000B5E RID: 2910
	// (get) Token: 0x06008582 RID: 34178 RVA: 0x0023266A File Offset: 0x0023086A
	public string ThemeName
	{
		get
		{
			return this.Config.ThemeName;
		}
	}

	// Token: 0x17000B5F RID: 2911
	// (get) Token: 0x06008583 RID: 34179 RVA: 0x00232677 File Offset: 0x00230877
	public string RoleTextureLight
	{
		get
		{
			return this.Config.RoleTextureLight;
		}
	}

	// Token: 0x17000B60 RID: 2912
	// (get) Token: 0x06008584 RID: 34180 RVA: 0x00232684 File Offset: 0x00230884
	public string RoleTextureDark
	{
		get
		{
			return this.Config.RoleTextureDark;
		}
	}

	// Token: 0x17000B61 RID: 2913
	// (get) Token: 0x06008585 RID: 34181 RVA: 0x00232691 File Offset: 0x00230891
	public string NumTexture
	{
		get
		{
			return this.Config.NumSprite;
		}
	}

	// Token: 0x17000B62 RID: 2914
	// (get) Token: 0x06008586 RID: 34182 RVA: 0x0023269E File Offset: 0x0023089E
	public string NumTexture2
	{
		get
		{
			return this.Config.NumTextureAdd;
		}
	}

	// Token: 0x17000B63 RID: 2915
	// (get) Token: 0x06008587 RID: 34183 RVA: 0x002326AC File Offset: 0x002308AC
	public unsafe string TargetRoleName
	{
		get
		{
			if (this.TargetRoleIdListInternal.Count > 1)
			{
				return this.Config.TargetRoleListName;
			}
			if (this.TargetRoleIdListInternal.Count == 0)
			{
				return string.Empty;
			}
			int num = this.TargetRoleIdListInternal[0];
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(num);
			if (roleConfig == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.FightPhotograph;
				ELogAuthor author = ELogAuthor.CXJ;
				string message = "关卡组拍照目标不存在";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("levelGroupId", this.Config.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("roleId", num);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return string.Empty;
			}
			return roleConfig.Value.Name;
		}
	}

	// Token: 0x17000B64 RID: 2916
	// (get) Token: 0x06008588 RID: 34184 RVA: 0x00232787 File Offset: 0x00230987
	public List<int> TargetRoleIds
	{
		get
		{
			return this.TargetRoleIdListInternal;
		}
	}

	// Token: 0x04003F27 RID: 16167
	private PhotoFightActivityGroup Config;

	// Token: 0x04003F28 RID: 16168
	private readonly List<FightPhotoLevelData> FightPhotoLevelList = new List<FightPhotoLevelData>();

	// Token: 0x04003F29 RID: 16169
	private long UnlockTimeInterval;

	// Token: 0x04003F2A RID: 16170
	private readonly List<int> TargetRoleIdListInternal = new List<int>();
}
