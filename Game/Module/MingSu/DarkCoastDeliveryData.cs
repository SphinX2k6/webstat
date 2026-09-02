using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.MingSu
{
	// Token: 0x0200572E RID: 22318
	[NullableContext(1)]
	[Nullable(0)]
	public class DarkCoastDeliveryData : MingSuInstance
	{
		// Token: 0x06038CD2 RID: 232658 RVA: 0x00E63A00 File Offset: 0x00E61C00
		public DarkCoastDeliveryData(int id) : base(id)
		{
			if (this.DragonPoolConfig == null)
			{
				return;
			}
			DragonPool value = this.DragonPoolConfig.Value;
			for (int i = 0; i < value.DarkCoastDeliveryListLength; i++)
			{
				int id2 = value.DarkCoastDeliveryList(i);
				DarkCoastDelivery? darkCoastDeliveryById = ConfigBase<CollectItemConfig>.Instance.GetDarkCoastDeliveryById(id2);
				if (darkCoastDeliveryById != null)
				{
					DarkCoastDelivery value2 = darkCoastDeliveryById.Value;
					int goal = (i < value.GoalLength) ? value.Goal(i) : 0;
					int dropId = (i < value.DropIdsLength) ? value.DropIds(i) : 0;
					this.LevelDataList.Add(new DarkCoastDeliveryLevelData(value2, goal, dropId));
				}
			}
		}

		// Token: 0x06038CD3 RID: 232659 RVA: 0x00E63AB8 File Offset: 0x00E61CB8
		public override void SetDragonPoolLevel(int level)
		{
			base.SetDragonPoolLevel(level);
			for (int i = 0; i < this.LevelDataList.Count; i++)
			{
				this.LevelDataList[i].SetIsUnLockState(level);
			}
		}

		// Token: 0x06038CD4 RID: 232660 RVA: 0x00E63AF4 File Offset: 0x00E61CF4
		public override void SetLevelGainList(int levelGain)
		{
			for (int i = 0; i < this.LevelDataList.Count; i++)
			{
				DarkCoastDeliveryLevelData darkCoastDeliveryLevelData = this.LevelDataList[i];
				darkCoastDeliveryLevelData.SetReceiveRewardState(levelGain >= darkCoastDeliveryLevelData.Id);
			}
		}

		// Token: 0x06038CD5 RID: 232661 RVA: 0x00E63B38 File Offset: 0x00E61D38
		public void RefreshLevelDataState(int[] defeatGuardIds, int[] receivedGuardList)
		{
			for (int i = 0; i < defeatGuardIds.Length; i++)
			{
				DarkCoastDeliveryLevelData levelData = this.GetLevelData(defeatGuardIds[i]);
				if (levelData != null)
				{
					levelData.SetDefeatedGuardState(true);
				}
			}
			for (int j = 0; j < receivedGuardList.Length; j++)
			{
				DarkCoastDeliveryLevelData levelData2 = this.GetLevelData(receivedGuardList[j]);
				if (levelData2 != null)
				{
					levelData2.SetReceivedGuardRewardState(true);
				}
			}
		}

		// Token: 0x06038CD6 RID: 232662 RVA: 0x00E63B8C File Offset: 0x00E61D8C
		[NullableContext(2)]
		public DarkCoastDeliveryLevelData GetLevelData(int level)
		{
			for (int i = 0; i < this.LevelDataList.Count; i++)
			{
				DarkCoastDeliveryLevelData darkCoastDeliveryLevelData = this.LevelDataList[i];
				if (darkCoastDeliveryLevelData.Id == level)
				{
					return darkCoastDeliveryLevelData;
				}
			}
			return null;
		}

		// Token: 0x06038CD7 RID: 232663 RVA: 0x00E63BC8 File Offset: 0x00E61DC8
		public List<DarkCoastDeliveryLevelData> GetLevelDataList()
		{
			return this.LevelDataList;
		}

		// Token: 0x06038CD8 RID: 232664 RVA: 0x00E63BD0 File Offset: 0x00E61DD0
		public string GetCurLevelTexturePath()
		{
			return this.GetLevelTexturePath(base.GetDragonPoolLevel());
		}

		// Token: 0x06038CD9 RID: 232665 RVA: 0x00E63BE0 File Offset: 0x00E61DE0
		public string GetLevelTexturePath(int level)
		{
			DarkCoastDeliveryLevelData levelData = this.GetLevelData(level);
			if (levelData != null)
			{
				return levelData.Config.LevelTexture ?? "";
			}
			return ConfigCommonParamById.GetStringConfig("DarkShoreDefaultLevel") ?? "";
		}

		// Token: 0x06038CDA RID: 232666 RVA: 0x00E63C24 File Offset: 0x00E61E24
		public IActivityRewardViewData GetActivityRewardViewData()
		{
			List<IActivityRewardData> activityRewardDataList = this.GetActivityRewardDataList();
			ActivityRewardDataPage item = new ActivityRewardDataPage
			{
				DataList = activityRewardDataList
			};
			return new ActivityRewardViewData
			{
				DataPageList = new List<IActivityRewardDataPage>
				{
					item
				},
				Source = EActivityRewardSource.DarkCoastDelivery
			};
		}

		// Token: 0x06038CDB RID: 232667 RVA: 0x00E63C68 File Offset: 0x00E61E68
		private List<IActivityRewardData> GetActivityRewardDataList()
		{
			List<IActivityRewardData> list = new List<IActivityRewardData>();
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("DarkShoreRewardGet", null);
			string localTextNew2 = ConfigMultiTextLang.GetLocalTextNew("DarkShoreRewardNotAchieved", null);
			for (int i = 0; i < this.LevelDataList.Count; i++)
			{
				DarkCoastDeliveryLevelData darkCoastDeliveryLevelData = this.LevelDataList[i];
				List<TItem> rewardItems = darkCoastDeliveryLevelData.GetRewardItems();
				EActivityRewardState darkCoastDeliveryRewardState = darkCoastDeliveryLevelData.GetDarkCoastDeliveryRewardState();
				string text = (darkCoastDeliveryRewardState == EActivityRewardState.Enable) ? localTextNew : localTextNew2;
				TItem[] array = new TItem[rewardItems.Count];
				for (int j = 0; j < rewardItems.Count; j++)
				{
					array[j] = rewardItems[j];
				}
				ActivityRewardData item = new ActivityRewardData
				{
					RewardList = array,
					NameText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("DarkCoastDelivery_Reward", null) ?? "", new string[]
					{
						darkCoastDeliveryLevelData.Id.ToString()
					}),
					RewardState = darkCoastDeliveryRewardState,
					RewardButtonRedDot = new bool?(darkCoastDeliveryRewardState == EActivityRewardState.Enable),
					RewardButtonText = (text ?? ""),
					ClickFunction = delegate
					{
						MingSuController.SendMingSuHandRewardRequest(this.DragonPoolId);
					}
				};
				list.Add(item);
			}
			return list;
		}

		// Token: 0x06038CDC RID: 232668 RVA: 0x00E63DA4 File Offset: 0x00E61FA4
		public bool GetRewardRedDotState()
		{
			for (int i = 0; i < this.LevelDataList.Count; i++)
			{
				if (this.LevelDataList[i].GetDarkCoastDeliveryRewardState() == EActivityRewardState.Enable)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x040205C3 RID: 132547
		private readonly List<DarkCoastDeliveryLevelData> LevelDataList = new List<DarkCoastDeliveryLevelData>();
	}
}
