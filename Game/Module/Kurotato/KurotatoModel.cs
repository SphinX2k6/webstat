using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Kurotato.Data;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A6D RID: 23149
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class KurotatoModel : ModelBase<KurotatoModel>
	{
		// Token: 0x0603A8EE RID: 239854 RVA: 0x00ED3B93 File Offset: 0x00ED1D93
		protected override bool OnClear()
		{
			this.ClearInGameData();
			return true;
		}

		// Token: 0x0603A8EF RID: 239855 RVA: 0x00ED3B9C File Offset: 0x00ED1D9C
		public void ClearInGameData()
		{
			this.StepInternal = EKurotatoStep.None;
			this.PrevStepInternal = EKurotatoStep.None;
			this.IsStepStartInternal = false;
			this.CurLevelIdInternal = 0;
			this.CurWaveStartLevelInternal = 0;
			this.SystemPropertyValueMap.Clear();
			this.LockedPropertyValueMap.Clear();
			this.BattleMusicStartedInternal = false;
			this.BattleData.Clear();
			this.WaveDurationInternal = 0;
			this.HasEndlessModeSelectionInternal = false;
			this.UpgradeRewardData = new List<KurotatoItemRewardPbData>();
			this.UpgradeRewardIndexInternal = 0;
			this.UpgradeRewardCountInternal = 0;
			this.ChestItemIdInternal = 0;
			this.ChestSoldPriceInternal = 0;
			this.ChestRewardIndexInternal = 0;
			this.ChestRewardCount = 0;
			this.ShopData = new List<KurotatoShopProductPbData>();
			this.HoldItemData.Clear();
			this.HoldWeaponData = new List<IKurotatoWeaponData>();
			this.RefreshCostInner = 0;
			this.RoleId = 10001;
			this.NextWaveTypeInternal = KurotatoNextWaveType.Default;
			this.NextWaveNumInternal = 0;
			this.SettlementDataInternal = null;
		}

		// Token: 0x0603A8F0 RID: 239856 RVA: 0x00ED3C7F File Offset: 0x00ED1E7F
		public bool GetBattleMusicStarted()
		{
			return this.BattleMusicStartedInternal;
		}

		// Token: 0x0603A8F1 RID: 239857 RVA: 0x00ED3C87 File Offset: 0x00ED1E87
		public void SetBattleMusicStarted(bool value)
		{
			this.BattleMusicStartedInternal = value;
		}

		// Token: 0x0603A8F2 RID: 239858 RVA: 0x00ED3C90 File Offset: 0x00ED1E90
		public void SetStepData(KurotatoStepUpdateNotify data)
		{
			this.IsStepStartInternal = data.IsStart;
			EKurotatoStep ekurotatoStep = this.StepInternal;
			if (data.CombatStepPbData != null)
			{
				ekurotatoStep = EKurotatoStep.Combat;
			}
			if (data.ChestRewardStepPbData != null)
			{
				ekurotatoStep = EKurotatoStep.ChestReward;
			}
			if (data.ShopStepPbData != null)
			{
				ekurotatoStep = EKurotatoStep.Shop;
			}
			if (data.UpdateWavePbData != null)
			{
				ekurotatoStep = EKurotatoStep.WaveUpdate;
			}
			if (data.UpgradeRewardStepPbData != null)
			{
				ekurotatoStep = EKurotatoStep.UpgradeReward;
			}
			if (data.PrepareStepPbData != null)
			{
				ekurotatoStep = EKurotatoStep.Prepare;
			}
			if (data.EndStepPbData != null)
			{
				ekurotatoStep = EKurotatoStep.End;
			}
			if (ekurotatoStep != this.StepInternal)
			{
				this.PrevStepInternal = this.StepInternal;
				this.StepInternal = ekurotatoStep;
			}
			switch (this.StepInternal)
			{
			case EKurotatoStep.Combat:
				this.WaveDurationInternal = data.CombatStepPbData.WaveDuration;
				this.CurWaveStartLevelInternal = this.BattleData.GetRoleLevel();
				this.ClearUpgradeRewardData();
				this.ClearChestRewardData();
				this.ClearShopData();
				break;
			case EKurotatoStep.Shop:
				this.HasEndlessModeSelectionInternal = data.ShopStepPbData.HasEndLessModeSelection;
				if (data.IsStart)
				{
					this.ClearShopData();
				}
				break;
			}
			Singleton<EventSystem>.Instance.Emit<EKurotatoStep>(EEventName.KurotatoOnStepChanged, this.StepInternal);
		}

		// Token: 0x0603A8F3 RID: 239859 RVA: 0x00ED3DA8 File Offset: 0x00ED1FA8
		public EKurotatoStep GetStep()
		{
			return this.StepInternal;
		}

		// Token: 0x0603A8F4 RID: 239860 RVA: 0x00ED3DB0 File Offset: 0x00ED1FB0
		public EKurotatoStep GetPrevStep()
		{
			return this.PrevStepInternal;
		}

		// Token: 0x0603A8F5 RID: 239861 RVA: 0x00ED3DB8 File Offset: 0x00ED1FB8
		public bool GetIsStepStart()
		{
			return this.IsStepStartInternal;
		}

		// Token: 0x0603A8F6 RID: 239862 RVA: 0x00ED3DC0 File Offset: 0x00ED1FC0
		public void SetCurLevelId(int levelId)
		{
			this.CurLevelIdInternal = levelId;
		}

		// Token: 0x0603A8F7 RID: 239863 RVA: 0x00ED3DC9 File Offset: 0x00ED1FC9
		public int GetCurLevelId()
		{
			return this.CurLevelIdInternal;
		}

		// Token: 0x0603A8F8 RID: 239864 RVA: 0x00ED3DD1 File Offset: 0x00ED1FD1
		public void SetCurWaveStartLevel(int level)
		{
			this.CurWaveStartLevelInternal = level;
		}

		// Token: 0x0603A8F9 RID: 239865 RVA: 0x00ED3DDA File Offset: 0x00ED1FDA
		public int GetCurWaveStartLevel()
		{
			return this.CurWaveStartLevelInternal;
		}

		// Token: 0x0603A8FA RID: 239866 RVA: 0x00ED3DE2 File Offset: 0x00ED1FE2
		public bool GetIsEndlessWave()
		{
			return this.BattleData.GetBatchType() == EKurotatoBatchType.Endless;
		}

		// Token: 0x0603A8FB RID: 239867 RVA: 0x00ED3DF2 File Offset: 0x00ED1FF2
		public bool GetIsSpecialWave()
		{
			return this.BattleData.GetBatchType() == EKurotatoBatchType.Special;
		}

		// Token: 0x0603A8FC RID: 239868 RVA: 0x00ED3E04 File Offset: 0x00ED2004
		public bool GetIsCurWaveElite()
		{
			List<KurotatoWave> list = ConfigBase<KurotatoConfig>.Instance.GetWaveByLevelId(this.CurLevelIdInternal) ?? new List<KurotatoWave>();
			int batch = this.BattleData.GetBatch();
			foreach (KurotatoWave kurotatoWave in list)
			{
				if (kurotatoWave.Wave == batch)
				{
					return kurotatoWave.IsPowerWave;
				}
			}
			return false;
		}

		// Token: 0x0603A8FD RID: 239869 RVA: 0x00ED3E88 File Offset: 0x00ED2088
		public bool GetIsCurWaveBoss()
		{
			KurotatoConfig instance = ConfigBase<KurotatoConfig>.Instance;
			List<KurotatoWave> list = instance.GetWaveByLevelId(this.CurLevelIdInternal) ?? new List<KurotatoWave>();
			int batch = this.BattleData.GetBatch();
			foreach (KurotatoWave waveConfig in list)
			{
				if (waveConfig.Wave == batch)
				{
					return instance.WaveHasRiskType(waveConfig, EKurotatoRiskType.BOSS);
				}
			}
			return false;
		}

		// Token: 0x0603A8FE RID: 239870 RVA: 0x00ED3F10 File Offset: 0x00ED2110
		public void SetNextWaveType(KurotatoNextWaveType nextWaveType, int nextWaveNum)
		{
			this.NextWaveTypeInternal = nextWaveType;
			this.NextWaveNumInternal = nextWaveNum;
		}

		// Token: 0x0603A8FF RID: 239871 RVA: 0x00ED3F20 File Offset: 0x00ED2120
		public int GetNextWaveNum()
		{
			return this.NextWaveNumInternal;
		}

		// Token: 0x0603A900 RID: 239872 RVA: 0x00ED3F28 File Offset: 0x00ED2128
		public bool GetIsNextWaveSpecial()
		{
			return this.NextWaveTypeInternal == KurotatoNextWaveType.Special;
		}

		// Token: 0x1700958A RID: 38282
		// (get) Token: 0x0603A901 RID: 239873 RVA: 0x00ED3F33 File Offset: 0x00ED2133
		public int CurWaveNum
		{
			get
			{
				return this.BattleData.GetBatch();
			}
		}

		// Token: 0x0603A902 RID: 239874 RVA: 0x00ED3F40 File Offset: 0x00ED2140
		public int GetWaveDuration()
		{
			return this.WaveDurationInternal;
		}

		// Token: 0x0603A903 RID: 239875 RVA: 0x00ED3F48 File Offset: 0x00ED2148
		public bool GetHasEndlessModeSelection()
		{
			return this.HasEndlessModeSelectionInternal;
		}

		// Token: 0x0603A904 RID: 239876 RVA: 0x00ED3F50 File Offset: 0x00ED2150
		public int GetRefreshCost()
		{
			return this.RefreshCostInner;
		}

		// Token: 0x0603A905 RID: 239877 RVA: 0x00ED3F58 File Offset: 0x00ED2158
		public int GetRoleId()
		{
			return this.RoleId;
		}

		// Token: 0x0603A906 RID: 239878 RVA: 0x00ED3F60 File Offset: 0x00ED2160
		public List<KurotatoItemRewardPbData> GetUpgradeRewardData()
		{
			return this.UpgradeRewardData;
		}

		// Token: 0x0603A907 RID: 239879 RVA: 0x00ED3F68 File Offset: 0x00ED2168
		public int GetUpgradeRewardIndex()
		{
			return this.UpgradeRewardIndexInternal;
		}

		// Token: 0x0603A908 RID: 239880 RVA: 0x00ED3F70 File Offset: 0x00ED2170
		public int GetUpgradeRewardCount()
		{
			return this.UpgradeRewardCountInternal;
		}

		// Token: 0x0603A909 RID: 239881 RVA: 0x00ED3F78 File Offset: 0x00ED2178
		public int GetChestItemId()
		{
			return this.ChestItemIdInternal;
		}

		// Token: 0x0603A90A RID: 239882 RVA: 0x00ED3F80 File Offset: 0x00ED2180
		public int GetChestSoldPrice()
		{
			return this.ChestSoldPriceInternal;
		}

		// Token: 0x0603A90B RID: 239883 RVA: 0x00ED3F88 File Offset: 0x00ED2188
		public int GetChestRewardIndex()
		{
			return this.ChestRewardIndexInternal;
		}

		// Token: 0x0603A90C RID: 239884 RVA: 0x00ED3F90 File Offset: 0x00ED2190
		public int GetChestRewardCount()
		{
			return this.ChestRewardCount;
		}

		// Token: 0x0603A90D RID: 239885 RVA: 0x00ED3F98 File Offset: 0x00ED2198
		public List<KurotatoShopProductPbData> GetShopData()
		{
			return this.ShopData;
		}

		// Token: 0x0603A90E RID: 239886 RVA: 0x00ED3FA0 File Offset: 0x00ED21A0
		public bool IsRecommendWeapon(int weaponId)
		{
			KurotatoConfig instance = ConfigBase<KurotatoConfig>.Instance;
			KurotatoCharacter? characterById = instance.GetCharacterById(this.GetRoleId());
			if (characterById == null || characterById.Value.ExcludedRecommendWeaponIdsIter().Contains(weaponId))
			{
				return false;
			}
			KurotatoWeapon? weaponConfigByWeaponId = instance.GetWeaponConfigByWeaponId(weaponId);
			KurotatoWeaponGroup? kurotatoWeaponGroup = (weaponConfigByWeaponId != null) ? instance.GetWeaponGroupById(weaponConfigByWeaponId.Value.GroupId) : null;
			List<string> weaponTags = ((kurotatoWeaponGroup != null) ? kurotatoWeaponGroup.GetValueOrDefault().TagsIter().ToList<string>() : null) ?? new List<string>();
			return characterById.Value.RecommendedTagsIter().Any((string tag) => weaponTags.Contains(tag));
		}

		// Token: 0x0603A90F RID: 239887 RVA: 0x00ED4070 File Offset: 0x00ED2270
		public bool IsRecommendItem(int itemId)
		{
			KurotatoConfig instance = ConfigBase<KurotatoConfig>.Instance;
			KurotatoCharacter? characterById = instance.GetCharacterById(this.GetRoleId());
			if (characterById == null || characterById.Value.ExcludedRecommendItemIdsIter().Contains(itemId))
			{
				return false;
			}
			KurotatoItem? kurotatoItem;
			List<string> itemTags = ((instance.GetItemConfigByItemId(itemId) != null) ? kurotatoItem.GetValueOrDefault().TagsIter().ToList<string>() : null) ?? new List<string>();
			return characterById.Value.RecommendedTagsIter().Any((string tag) => itemTags.Contains(tag));
		}

		// Token: 0x0603A910 RID: 239888 RVA: 0x00ED4111 File Offset: 0x00ED2311
		public void ClearShopData()
		{
			this.ShopData = new List<KurotatoShopProductPbData>();
			this.RefreshCostInner = 0;
			Singleton<EventSystem>.Instance.Emit(EEventName.KurotatoOnShopDataChanged);
		}

		// Token: 0x0603A911 RID: 239889 RVA: 0x00ED4135 File Offset: 0x00ED2335
		public void ClearUpgradeRewardData()
		{
			this.UpgradeRewardData = new List<KurotatoItemRewardPbData>();
			this.UpgradeRewardIndexInternal = 0;
			this.UpgradeRewardCountInternal = 0;
			Singleton<EventSystem>.Instance.Emit(EEventName.KurotatoOnUpgradeRewardDataChanged);
		}

		// Token: 0x0603A912 RID: 239890 RVA: 0x00ED4160 File Offset: 0x00ED2360
		public void ClearChestRewardData()
		{
			this.ChestItemIdInternal = 0;
			this.ChestSoldPriceInternal = 0;
			this.ChestRewardIndexInternal = 0;
			this.ChestRewardCount = 0;
			Singleton<EventSystem>.Instance.Emit(EEventName.KurotatoOnChestRewardDataChanged);
		}

		// Token: 0x0603A913 RID: 239891 RVA: 0x00ED4190 File Offset: 0x00ED2390
		public bool CanComposeWeapon(int weaponId)
		{
			KurotatoConfig instance = ConfigBase<KurotatoConfig>.Instance;
			KurotatoWeapon? weaponConfigByWeaponId = instance.GetWeaponConfigByWeaponId(weaponId);
			if (weaponConfigByWeaponId == null)
			{
				return false;
			}
			int maxQualityByGroupId = instance.GetMaxQualityByGroupId(weaponConfigByWeaponId.Value.GroupId);
			if (weaponConfigByWeaponId.Value.Quality >= maxQualityByGroupId)
			{
				return false;
			}
			foreach (IKurotatoWeaponData kurotatoWeaponData in this.HoldWeaponData)
			{
				KurotatoWeapon? weaponConfigByWeaponId2 = instance.GetWeaponConfigByWeaponId(kurotatoWeaponData.WeaponId);
				if (weaponConfigByWeaponId2 != null && weaponConfigByWeaponId2.Value.GroupId == weaponConfigByWeaponId.Value.GroupId && weaponConfigByWeaponId2.Value.Quality == weaponConfigByWeaponId.Value.Quality)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603A914 RID: 239892 RVA: 0x00ED4284 File Offset: 0x00ED2484
		public IKurotatoComposeHighlight GetComposeHighlight()
		{
			HashSet<int> hashSet = new HashSet<int>();
			HashSet<int> hashSet2 = new HashSet<int>();
			HashSet<int> hashSet3 = new HashSet<int>();
			KurotatoComposeHighlight result = new KurotatoComposeHighlight
			{
				UpgradeSelectionIds = hashSet,
				ArrowIncIds = hashSet2,
				BagPairArrowIncIds = hashSet3
			};
			KurotatoConfig instance = ConfigBase<KurotatoConfig>.Instance;
			List<KurotatoShopProductPbData> shopData = this.GetShopData();
			bool flag = shopData.Any((KurotatoShopProductPbData item) => item.WeaponData != null && !item.IsBought && this.IsRecommendWeapon(item.WeaponData.WeaponId));
			if (!this.IsWeaponBagFull() || !flag)
			{
				return result;
			}
			Dictionary<string, KurotatoModel.ComposeBucket> dictionary = new Dictionary<string, KurotatoModel.ComposeBucket>();
			foreach (IKurotatoWeaponData kurotatoWeaponData in this.GetHoldWeaponData())
			{
				KurotatoWeapon? weaponConfigByWeaponId = instance.GetWeaponConfigByWeaponId(kurotatoWeaponData.WeaponId);
				if (weaponConfigByWeaponId != null && weaponConfigByWeaponId.Value.Quality < instance.GetMaxQualityByGroupId(weaponConfigByWeaponId.Value.GroupId))
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
					defaultInterpolatedStringHandler.AppendFormatted<int>(weaponConfigByWeaponId.Value.GroupId);
					defaultInterpolatedStringHandler.AppendLiteral("_");
					defaultInterpolatedStringHandler.AppendFormatted<int>(weaponConfigByWeaponId.Value.Quality);
					string key = defaultInterpolatedStringHandler.ToStringAndClear();
					KurotatoModel.ComposeBucket composeBucket;
					if (!dictionary.TryGetValue(key, out composeBucket))
					{
						composeBucket = new KurotatoModel.ComposeBucket
						{
							Quality = weaponConfigByWeaponId.Value.Quality
						};
						dictionary[key] = composeBucket;
					}
					composeBucket.BagIncIds.Add(kurotatoWeaponData.IncId);
				}
			}
			foreach (KurotatoShopProductPbData kurotatoShopProductPbData in shopData)
			{
				if (kurotatoShopProductPbData.WeaponData != null && !kurotatoShopProductPbData.IsBought)
				{
					int weaponId = kurotatoShopProductPbData.WeaponData.WeaponId;
					if (this.IsRecommendWeapon(weaponId))
					{
						KurotatoWeapon? weaponConfigByWeaponId2 = instance.GetWeaponConfigByWeaponId(weaponId);
						if (weaponConfigByWeaponId2 != null)
						{
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
							defaultInterpolatedStringHandler.AppendFormatted<int>(weaponConfigByWeaponId2.Value.GroupId);
							defaultInterpolatedStringHandler.AppendLiteral("_");
							defaultInterpolatedStringHandler.AppendFormatted<int>(weaponConfigByWeaponId2.Value.Quality);
							string key2 = defaultInterpolatedStringHandler.ToStringAndClear();
							KurotatoModel.ComposeBucket composeBucket2;
							if (dictionary.TryGetValue(key2, out composeBucket2))
							{
								composeBucket2.RecommendSelectionIds.Add(kurotatoShopProductPbData.SelectionId);
							}
						}
					}
				}
			}
			List<KurotatoModel.ComposeBucket> source = dictionary.Values.ToList<KurotatoModel.ComposeBucket>();
			List<KurotatoModel.ComposeBucket> list = (from bucket in source
			where bucket.RecommendSelectionIds.Count > 0
			orderby bucket.Quality
			select bucket).ToList<KurotatoModel.ComposeBucket>();
			List<KurotatoModel.ComposeBucket> list2 = (from bucket in source
			where bucket.RecommendSelectionIds.Count == 0 && bucket.BagIncIds.Count >= 2
			orderby bucket.Quality
			select bucket).ToList<KurotatoModel.ComposeBucket>();
			foreach (KurotatoModel.ComposeBucket composeBucket3 in list)
			{
				if (hashSet2.Count >= 2)
				{
					break;
				}
				hashSet2.Add(composeBucket3.BagIncIds[0]);
				foreach (int item2 in composeBucket3.RecommendSelectionIds)
				{
					hashSet.Add(item2);
				}
			}
			if (hashSet2.Count > 0)
			{
				return result;
			}
			foreach (KurotatoModel.ComposeBucket composeBucket4 in list2)
			{
				if (2 - hashSet2.Count >= 2)
				{
					hashSet2.Add(composeBucket4.BagIncIds[0]);
					hashSet2.Add(composeBucket4.BagIncIds[1]);
					hashSet3.Add(composeBucket4.BagIncIds[0]);
					hashSet3.Add(composeBucket4.BagIncIds[1]);
				}
			}
			return result;
		}

		// Token: 0x0603A915 RID: 239893 RVA: 0x00ED46F8 File Offset: 0x00ED28F8
		public List<IKurotatoItemData> GetHoldItemData()
		{
			List<IKurotatoItemData> list = new List<IKurotatoItemData>();
			foreach (int num in this.HoldItemData.Keys)
			{
				int num2 = this.HoldItemData[num];
				if (num2 > 0)
				{
					list.Add(new KurotatoItemData
					{
						ItemId = num,
						Count = num2
					});
				}
			}
			return list;
		}

		// Token: 0x0603A916 RID: 239894 RVA: 0x00ED477C File Offset: 0x00ED297C
		public int GetHoldItemCount(int itemId)
		{
			int result;
			if (!this.HoldItemData.TryGetValue(itemId, out result))
			{
				return 0;
			}
			return result;
		}

		// Token: 0x0603A917 RID: 239895 RVA: 0x00ED479C File Offset: 0x00ED299C
		public List<IKurotatoWeaponData> GetHoldWeaponData()
		{
			return this.HoldWeaponData;
		}

		// Token: 0x0603A918 RID: 239896 RVA: 0x00ED47A4 File Offset: 0x00ED29A4
		public bool IsWeaponBagFull()
		{
			KurotatoActivityConfig? kurotatoActivityConfig;
			int num = (this.GetActivityConfig() != null) ? kurotatoActivityConfig.GetValueOrDefault().WeaponCount : this.HoldWeaponData.Count;
			return this.HoldWeaponData.Count >= num;
		}

		// Token: 0x0603A919 RID: 239897 RVA: 0x00ED47F0 File Offset: 0x00ED29F0
		[NullableContext(2)]
		public IKurotatoWeaponData GetWeaponDataByIncId(int incId)
		{
			foreach (IKurotatoWeaponData kurotatoWeaponData in this.HoldWeaponData)
			{
				if (kurotatoWeaponData.IncId == incId)
				{
					return kurotatoWeaponData;
				}
			}
			return null;
		}

		// Token: 0x0603A91A RID: 239898 RVA: 0x00ED484C File Offset: 0x00ED2A4C
		public int GetWeaponBuildLevelByBuildId(int weaponBuildId)
		{
			KurotatoConfig instance = ConfigBase<KurotatoConfig>.Instance;
			int num = 0;
			foreach (IKurotatoWeaponData kurotatoWeaponData in this.HoldWeaponData)
			{
				int groupId = instance.GetWeaponConfigByWeaponId(kurotatoWeaponData.WeaponId).Value.GroupId;
				using (IEnumerator<int> enumerator2 = instance.GetWeaponGroupById(groupId).Value.WeaponBuildIdsIter().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (enumerator2.Current == weaponBuildId)
						{
							num++;
							break;
						}
					}
				}
			}
			return num;
		}

		// Token: 0x0603A91B RID: 239899 RVA: 0x00ED4918 File Offset: 0x00ED2B18
		public void SetRoleId(int roleId)
		{
			this.RoleId = roleId;
		}

		// Token: 0x0603A91C RID: 239900 RVA: 0x00ED4921 File Offset: 0x00ED2B21
		public void SetSystemPropertyValues(IDictionary<int, int> propertyValues, IDictionary<int, int> lockedPropertyValues)
		{
			this.SystemPropertyValueMap.Clear();
			this.UpdateSystemPropertyValues(propertyValues, lockedPropertyValues);
		}

		// Token: 0x0603A91D RID: 239901 RVA: 0x00ED4938 File Offset: 0x00ED2B38
		public void UpdateSystemPropertyValues(IDictionary<int, int> propertyValues, IDictionary<int, int> lockedPropertyValues)
		{
			foreach (KeyValuePair<int, int> keyValuePair in propertyValues)
			{
				this.SystemPropertyValueMap[keyValuePair.Key] = keyValuePair.Value;
			}
			this.LockedPropertyValueMap.Clear();
			foreach (KeyValuePair<int, int> keyValuePair2 in lockedPropertyValues)
			{
				this.LockedPropertyValueMap[keyValuePair2.Key] = keyValuePair2.Value;
			}
		}

		// Token: 0x0603A91E RID: 239902 RVA: 0x00ED49E8 File Offset: 0x00ED2BE8
		public int GetSystemPropertyValue(int propertyId)
		{
			int result;
			if (!this.SystemPropertyValueMap.TryGetValue(propertyId, out result))
			{
				return 0;
			}
			return result;
		}

		// Token: 0x0603A91F RID: 239903 RVA: 0x00ED4A08 File Offset: 0x00ED2C08
		public bool IsSystemPropertyLocked(int propertyId)
		{
			return this.LockedPropertyValueMap.ContainsKey(propertyId);
		}

		// Token: 0x0603A920 RID: 239904 RVA: 0x00ED4A18 File Offset: 0x00ED2C18
		public int GetSystemPropertyLockedValue(int propertyId)
		{
			int result;
			if (!this.LockedPropertyValueMap.TryGetValue(propertyId, out result))
			{
				return 0;
			}
			return result;
		}

		// Token: 0x0603A921 RID: 239905 RVA: 0x00ED4A38 File Offset: 0x00ED2C38
		public int GetPropertyValue(int propertyId)
		{
			if (!ConfigBase<KurotatoConfig>.Instance.IsServerCtrlProperty(propertyId))
			{
				return this.BattleData.GetPlayerPropertyValue(propertyId);
			}
			return this.GetSystemPropertyValue(propertyId);
		}

		// Token: 0x0603A922 RID: 239906 RVA: 0x00ED4A5B File Offset: 0x00ED2C5B
		public bool IsPropertyLocked(int propertyId)
		{
			if (!ConfigBase<KurotatoConfig>.Instance.IsServerCtrlProperty(propertyId))
			{
				return this.BattleData.IsPlayerPropertyLocked(propertyId);
			}
			return this.IsSystemPropertyLocked(propertyId);
		}

		// Token: 0x0603A923 RID: 239907 RVA: 0x00ED4A7E File Offset: 0x00ED2C7E
		public int GetPropertyLockedValue(int propertyId)
		{
			if (!ConfigBase<KurotatoConfig>.Instance.IsServerCtrlProperty(propertyId))
			{
				return this.BattleData.GetPlayerPropertyLockedValue(propertyId);
			}
			return this.GetSystemPropertyLockedValue(propertyId);
		}

		// Token: 0x0603A924 RID: 239908 RVA: 0x00ED4AA4 File Offset: 0x00ED2CA4
		public void SetUpgradeRewardData(KurotatoItemRewardPanelPbData rewardData)
		{
			this.UpgradeRewardData = new List<KurotatoItemRewardPbData>(rewardData.RewardItemDatas);
			this.RefreshCostInner = rewardData.RefreshCost;
			this.UpgradeRewardIndexInternal = rewardData.RewardIndex;
			this.UpgradeRewardCountInternal = rewardData.TotalRewardCount;
			Singleton<EventSystem>.Instance.Emit(EEventName.KurotatoOnUpgradeRewardDataChanged);
		}

		// Token: 0x0603A925 RID: 239909 RVA: 0x00ED4AF6 File Offset: 0x00ED2CF6
		public void SetChestRewardData(int itemId, int soldPrice, int rewardIndex, int rewardCount)
		{
			this.ChestItemIdInternal = itemId;
			this.ChestSoldPriceInternal = soldPrice;
			this.ChestRewardIndexInternal = rewardIndex;
			this.ChestRewardCount = rewardCount;
			Singleton<EventSystem>.Instance.Emit(EEventName.KurotatoOnChestRewardDataChanged);
		}

		// Token: 0x0603A926 RID: 239910 RVA: 0x00ED4B25 File Offset: 0x00ED2D25
		public void SetShopData(KurotatoShopPanelPbData shopData)
		{
			this.ShopData = new List<KurotatoShopProductPbData>(shopData.ItemPbDatas);
			this.RefreshCostInner = shopData.RefreshCost;
			Singleton<EventSystem>.Instance.Emit(EEventName.KurotatoOnShopDataChanged);
		}

		// Token: 0x0603A927 RID: 239911 RVA: 0x00ED4B54 File Offset: 0x00ED2D54
		public void UpdateItem(IKurotatoItemData itemData, bool bIsAdd)
		{
			if (itemData.Count == 0)
			{
				this.HoldItemData.Remove(itemData.ItemId);
			}
			else
			{
				this.HoldItemData[itemData.ItemId] = itemData.Count;
			}
			Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.KurotatoOnItemUpdate, itemData.ItemId, bIsAdd);
		}

		// Token: 0x0603A928 RID: 239912 RVA: 0x00ED4BAC File Offset: 0x00ED2DAC
		[NullableContext(2)]
		public void UpdateItemPanel(KurotatoItemPanelPbData itemPanelData)
		{
			this.HoldItemData.Clear();
			if (itemPanelData != null)
			{
				foreach (KurotatoItemPbData kurotatoItemPbData in itemPanelData.ItemPbDatas)
				{
					if (kurotatoItemPbData.Count > 0)
					{
						this.HoldItemData[kurotatoItemPbData.ItemId] = kurotatoItemPbData.Count;
					}
				}
			}
			Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.KurotatoOnItemUpdate, 0, true);
		}

		// Token: 0x0603A929 RID: 239913 RVA: 0x00ED4C34 File Offset: 0x00ED2E34
		[NullableContext(2)]
		public void UpdateWeapon(KurotatoWeaponPanelPbData weaponData)
		{
			this.HoldWeaponData = new List<IKurotatoWeaponData>();
			if (weaponData != null)
			{
				foreach (KurotatoWeaponPbData kurotatoWeaponPbData in weaponData.WeaponPbDatas)
				{
					this.HoldWeaponData.Add(new KurotatoWeaponData
					{
						WeaponId = kurotatoWeaponPbData.WeaponId,
						IncId = kurotatoWeaponPbData.IncId,
						SellPrice = kurotatoWeaponPbData.SellPrice,
						PreWaveDealtDamage = kurotatoWeaponPbData.PreWaveDealtDamage
					});
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.KurotatoOnWeaponUpdate);
		}

		// Token: 0x0603A92A RID: 239914 RVA: 0x00ED4CD8 File Offset: 0x00ED2ED8
		public void SetSettlementData(KurotatoSettlementNotify notify)
		{
			KurotatoSettlementInfo kurotatoSettlementInfo = notify.KurotatoSettlementInfo;
			List<KurotatoItemData> list = new List<KurotatoItemData>();
			if (kurotatoSettlementInfo.ItemPanelPbData != null)
			{
				foreach (KurotatoItemPbData kurotatoItemPbData in kurotatoSettlementInfo.ItemPanelPbData.ItemPbDatas)
				{
					list.Add(new KurotatoItemData
					{
						ItemId = kurotatoItemPbData.ItemId,
						Count = kurotatoItemPbData.Count
					});
				}
			}
			List<KurotatoWeaponData> list2 = new List<KurotatoWeaponData>();
			if (kurotatoSettlementInfo.WeaponPanelPbData != null)
			{
				foreach (KurotatoWeaponPbData kurotatoWeaponPbData in kurotatoSettlementInfo.WeaponPanelPbData.WeaponPbDatas)
				{
					list2.Add(new KurotatoWeaponData
					{
						WeaponId = kurotatoWeaponPbData.WeaponId,
						IncId = kurotatoWeaponPbData.IncId,
						SellPrice = kurotatoWeaponPbData.SellPrice,
						PreWaveDealtDamage = kurotatoWeaponPbData.PreWaveDealtDamage
					});
				}
			}
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			if (kurotatoSettlementInfo.PropertyMap != null)
			{
				foreach (KeyValuePair<int, int> keyValuePair in kurotatoSettlementInfo.PropertyMap)
				{
					dictionary[keyValuePair.Key] = keyValuePair.Value;
				}
			}
			this.SettlementDataInternal = new KurotatoSettlementData
			{
				IsPass = kurotatoSettlementInfo.IsPass,
				CompletionTime = (long)kurotatoSettlementInfo.CompletionTime,
				ItemPanelData = list,
				WeaponPanelData = list2,
				PassWaveCount = kurotatoSettlementInfo.PassWaveCount,
				CumulativeKills = kurotatoSettlementInfo.CumulativeKills,
				PropertyMap = dictionary,
				UnlockWeapons = new List<int>(kurotatoSettlementInfo.UnlockWeapons),
				UnlockItems = new List<int>(kurotatoSettlementInfo.UnlockItems),
				UnlockRoles = new List<int>(kurotatoSettlementInfo.UnlockRoles)
			};
		}

		// Token: 0x0603A92B RID: 239915 RVA: 0x00ED4ED4 File Offset: 0x00ED30D4
		[NullableContext(2)]
		public IKurotatoSettlementData GetSettlementData()
		{
			return this.SettlementDataInternal;
		}

		// Token: 0x0603A92C RID: 239916 RVA: 0x00ED4EDC File Offset: 0x00ED30DC
		public void ClearSettlementData()
		{
			this.SettlementDataInternal = null;
		}

		// Token: 0x0603A92D RID: 239917 RVA: 0x00ED4EE5 File Offset: 0x00ED30E5
		public void SetRoleSaveState(KurotatoRoleSaveState state)
		{
			this.RoleSaveStateInternal = state;
		}

		// Token: 0x0603A92E RID: 239918 RVA: 0x00ED4EEE File Offset: 0x00ED30EE
		public KurotatoRoleSaveState GetRoleSaveState()
		{
			return this.RoleSaveStateInternal;
		}

		// Token: 0x0603A92F RID: 239919 RVA: 0x00ED4EF6 File Offset: 0x00ED30F6
		public void SetRoleSaveIsPopView(bool isPopView)
		{
			this.RoleSaveIsPopViewInternal = isPopView;
		}

		// Token: 0x0603A930 RID: 239920 RVA: 0x00ED4EFF File Offset: 0x00ED30FF
		public bool GetRoleSaveIsPopView()
		{
			return this.RoleSaveIsPopViewInternal;
		}

		// Token: 0x0603A931 RID: 239921 RVA: 0x00ED4F07 File Offset: 0x00ED3107
		public void SetRoleSaveInstInfos(List<KurotatoInstInfo> instInfos)
		{
			this.RoleSaveInstInfosInternal = instInfos;
		}

		// Token: 0x0603A932 RID: 239922 RVA: 0x00ED4F10 File Offset: 0x00ED3110
		public List<KurotatoInstInfo> GetRoleSaveInstInfos()
		{
			return this.RoleSaveInstInfosInternal;
		}

		// Token: 0x0603A933 RID: 239923 RVA: 0x00ED4F18 File Offset: 0x00ED3118
		public void MarkNeedShowSaveTip()
		{
			this.NeedShowSaveTipInternal = true;
		}

		// Token: 0x0603A934 RID: 239924 RVA: 0x00ED4F21 File Offset: 0x00ED3121
		public bool ConsumeNeedShowSaveTip()
		{
			if (!this.NeedShowSaveTipInternal)
			{
				return false;
			}
			this.NeedShowSaveTipInternal = false;
			return true;
		}

		// Token: 0x0603A935 RID: 239925 RVA: 0x00ED4F35 File Offset: 0x00ED3135
		public void SetReChallengeCount(int maxCount, int usedCount)
		{
			this.MaxReChallengeCountInternal = maxCount;
			this.UsedReChallengeCountInternal = usedCount;
		}

		// Token: 0x0603A936 RID: 239926 RVA: 0x00ED4F45 File Offset: 0x00ED3145
		public int GetMaxReChallengeCount()
		{
			return this.MaxReChallengeCountInternal;
		}

		// Token: 0x0603A937 RID: 239927 RVA: 0x00ED4F4D File Offset: 0x00ED314D
		public int GetUsedReChallengeCount()
		{
			return this.UsedReChallengeCountInternal;
		}

		// Token: 0x0603A938 RID: 239928 RVA: 0x00ED4F55 File Offset: 0x00ED3155
		public int GetRemainReChallengeCount()
		{
			return Math.Max(0, this.MaxReChallengeCountInternal - this.UsedReChallengeCountInternal);
		}

		// Token: 0x0603A939 RID: 239929 RVA: 0x00ED4F6A File Offset: 0x00ED316A
		public bool IsReChallengeCountUnlimited()
		{
			return this.MaxReChallengeCountInternal == -1;
		}

		// Token: 0x0603A93A RID: 239930 RVA: 0x00ED4F78 File Offset: 0x00ED3178
		public RoleDataBase GetRoleDataByKurotatoRoleId(int kurotatoRoleId)
		{
			int trialRole = ConfigBase<KurotatoConfig>.Instance.GetCharacterById(kurotatoRoleId).Value.TrialRole;
			KurotatoActivityController instance = ControllerBase<KurotatoActivityController>.Instance;
			KurotatoRoleData kurotatoRoleData;
			if (instance == null)
			{
				kurotatoRoleData = null;
			}
			else
			{
				CSharpScript.Game.Module.Kurotato.Data.KurotatoActivityData activityData = instance.GetActivityData();
				kurotatoRoleData = ((activityData != null) ? activityData.GetKurotatoRoleData(kurotatoRoleId) : null);
			}
			KurotatoRoleData kurotatoRoleData2 = kurotatoRoleData;
			if (kurotatoRoleData2 == null || !kurotatoRoleData2.IsUnLock)
			{
				return ModelBase<RoleModel>.Instance.GetRoleRobotData(trialRole);
			}
			return ModelBase<RoleModel>.Instance.GetRoleDataByTrialRoleId(trialRole);
		}

		// Token: 0x0603A93B RID: 239931 RVA: 0x00ED4FE4 File Offset: 0x00ED31E4
		public int GetActivityId()
		{
			KurotatoActivityController instance = ControllerBase<KurotatoActivityController>.Instance;
			int? num;
			if (instance == null)
			{
				num = null;
			}
			else
			{
				CSharpScript.Game.Module.Kurotato.Data.KurotatoActivityData activityData = instance.GetActivityData();
				num = ((activityData != null) ? new int?(activityData.Id) : null);
			}
			int? num2 = num;
			return num2.GetValueOrDefault();
		}

		// Token: 0x0603A93C RID: 239932 RVA: 0x00ED502B File Offset: 0x00ED322B
		public bool IsActivityOn()
		{
			return this.GetActivityId() != 0;
		}

		// Token: 0x0603A93D RID: 239933 RVA: 0x00ED5038 File Offset: 0x00ED3238
		public int GetRogueCurrencyItemId()
		{
			KurotatoActivityConfig? activityConfig = this.GetActivityConfig();
			if (activityConfig == null)
			{
				return 0;
			}
			return activityConfig.GetValueOrDefault().CurrencyItemId;
		}

		// Token: 0x0603A93E RID: 239934 RVA: 0x00ED5068 File Offset: 0x00ED3268
		public KurotatoActivityConfig? GetActivityConfig()
		{
			if (!this.IsActivityOn())
			{
				return null;
			}
			return ConfigBase<KurotatoConfig>.Instance.GetActivityConfig(this.GetActivityId());
		}

		// Token: 0x0402124D RID: 135757
		private EKurotatoStep StepInternal = EKurotatoStep.None;

		// Token: 0x0402124E RID: 135758
		private EKurotatoStep PrevStepInternal = EKurotatoStep.None;

		// Token: 0x0402124F RID: 135759
		private bool IsStepStartInternal;

		// Token: 0x04021250 RID: 135760
		private int CurLevelIdInternal;

		// Token: 0x04021251 RID: 135761
		private int CurWaveStartLevelInternal;

		// Token: 0x04021252 RID: 135762
		public KurotatoBattleData BattleData = KurotatoBattleData.Create();

		// Token: 0x04021253 RID: 135763
		private int WaveDurationInternal;

		// Token: 0x04021254 RID: 135764
		private bool HasEndlessModeSelectionInternal;

		// Token: 0x04021255 RID: 135765
		private List<KurotatoItemRewardPbData> UpgradeRewardData = new List<KurotatoItemRewardPbData>();

		// Token: 0x04021256 RID: 135766
		private int UpgradeRewardIndexInternal;

		// Token: 0x04021257 RID: 135767
		private int UpgradeRewardCountInternal;

		// Token: 0x04021258 RID: 135768
		private int ChestItemIdInternal;

		// Token: 0x04021259 RID: 135769
		private int ChestSoldPriceInternal;

		// Token: 0x0402125A RID: 135770
		private int ChestRewardIndexInternal;

		// Token: 0x0402125B RID: 135771
		private int ChestRewardCount;

		// Token: 0x0402125C RID: 135772
		private List<KurotatoShopProductPbData> ShopData = new List<KurotatoShopProductPbData>();

		// Token: 0x0402125D RID: 135773
		private readonly Dictionary<int, int> HoldItemData = new Dictionary<int, int>();

		// Token: 0x0402125E RID: 135774
		private List<IKurotatoWeaponData> HoldWeaponData = new List<IKurotatoWeaponData>();

		// Token: 0x0402125F RID: 135775
		private readonly Dictionary<int, int> SystemPropertyValueMap = new Dictionary<int, int>();

		// Token: 0x04021260 RID: 135776
		private readonly Dictionary<int, int> LockedPropertyValueMap = new Dictionary<int, int>();

		// Token: 0x04021261 RID: 135777
		private int RefreshCostInner;

		// Token: 0x04021262 RID: 135778
		private int RoleId = 10001;

		// Token: 0x04021263 RID: 135779
		private KurotatoNextWaveType NextWaveTypeInternal;

		// Token: 0x04021264 RID: 135780
		private int NextWaveNumInternal;

		// Token: 0x04021265 RID: 135781
		public bool HideShopNotBuyConfirmBox;

		// Token: 0x04021266 RID: 135782
		public bool HideSellWeaponConfirmBox;

		// Token: 0x04021267 RID: 135783
		private bool BattleMusicStartedInternal;

		// Token: 0x04021268 RID: 135784
		[Nullable(2)]
		private IKurotatoSettlementData SettlementDataInternal;

		// Token: 0x04021269 RID: 135785
		private KurotatoRoleSaveState RoleSaveStateInternal;

		// Token: 0x0402126A RID: 135786
		private bool RoleSaveIsPopViewInternal;

		// Token: 0x0402126B RID: 135787
		private List<KurotatoInstInfo> RoleSaveInstInfosInternal = new List<KurotatoInstInfo>();

		// Token: 0x0402126C RID: 135788
		private bool NeedShowSaveTipInternal;

		// Token: 0x0402126D RID: 135789
		private int MaxReChallengeCountInternal;

		// Token: 0x0402126E RID: 135790
		private int UsedReChallengeCountInternal;

		// Token: 0x0200BA2E RID: 47662
		[Nullable(0)]
		private class ComposeBucket
		{
			// Token: 0x040397FB RID: 235515
			public int Quality;

			// Token: 0x040397FC RID: 235516
			public List<int> BagIncIds = new List<int>();

			// Token: 0x040397FD RID: 235517
			public List<int> RecommendSelectionIds = new List<int>();
		}
	}
}
