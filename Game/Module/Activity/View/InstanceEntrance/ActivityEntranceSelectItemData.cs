using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.View.InstanceEntrance
{
	// Token: 0x020061DF RID: 25055
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityEntranceSelectItemData
	{
		// Token: 0x0603F394 RID: 258964 RVA: 0x0103A4EA File Offset: 0x010386EA
		public static ActivityEntranceSelectItemData Create(List<ActivityEntranceSelectItemBaseData> mainDataList)
		{
			ActivityEntranceSelectItemData activityEntranceSelectItemData = new ActivityEntranceSelectItemData();
			activityEntranceSelectItemData.MainDataList = mainDataList;
			activityEntranceSelectItemData.InitEntranceData();
			return activityEntranceSelectItemData;
		}

		// Token: 0x0603F395 RID: 258965 RVA: 0x0103A500 File Offset: 0x01038700
		public ActivityEntranceItemData GetCurrentSelectData()
		{
			ActivityEntranceItemData activityEntranceItemData = null;
			foreach (ActivityEntranceItemData activityEntranceItemData2 in this.CurrentEntranceData)
			{
				if (activityEntranceItemData2.MainData != null)
				{
					if (activityEntranceItemData2.MainData.GetSelectState())
					{
						activityEntranceItemData = activityEntranceItemData2;
					}
				}
				else if (activityEntranceItemData2.SubData != null && activityEntranceItemData2.SubData.GetSelectState())
				{
					activityEntranceItemData = activityEntranceItemData2;
				}
			}
			if (activityEntranceItemData == null)
			{
				activityEntranceItemData = this.CurrentEntranceData[0];
			}
			return activityEntranceItemData;
		}

		// Token: 0x0603F396 RID: 258966 RVA: 0x0103A590 File Offset: 0x01038790
		private void InitEntranceData()
		{
			this.CurrentEntranceData = new List<ActivityEntranceItemData>(this.MainDataList.Count * 2);
			for (int i = 0; i < this.MainDataList.Count; i++)
			{
				ActivityEntranceItemData activityEntranceItemData = new ActivityEntranceItemData();
				activityEntranceItemData.MainData = this.MainDataList[i];
				this.CurrentEntranceData.Add(activityEntranceItemData);
				ActivityEntranceSelectItemSubData[] subDataList = this.MainDataList[i].GetSubDataList();
				if (subDataList != null)
				{
					for (int j = 0; j < subDataList.Length; j++)
					{
						ActivityEntranceItemData activityEntranceItemData2 = new ActivityEntranceItemData();
						activityEntranceItemData2.SubData = subDataList[j];
						this.CurrentEntranceData.Add(activityEntranceItemData2);
					}
				}
			}
		}

		// Token: 0x0603F397 RID: 258967 RVA: 0x0103A630 File Offset: 0x01038830
		public IReadOnlyList<ActivityEntranceItemData> GetShowDataBySelectElement(int selectMainLogicIndex, int selectSubLogicIndex)
		{
			this.CurrentEntranceData = new List<ActivityEntranceItemData>(this.MainDataList.Count * 2);
			for (int i = 0; i < this.MainDataList.Count; i++)
			{
				bool flag = this.MainDataList[i].GetUiLogicIndex() == selectMainLogicIndex;
				this.MainDataList[i].SetSelectState(flag);
				ActivityEntranceItemData activityEntranceItemData = new ActivityEntranceItemData();
				activityEntranceItemData.MainData = this.MainDataList[i];
				this.CurrentEntranceData.Add(activityEntranceItemData);
				if (flag)
				{
					ActivityEntranceSelectItemSubData[] subDataList = this.MainDataList[i].GetSubDataList();
					if (subDataList != null)
					{
						for (int j = 0; j < subDataList.Length; j++)
						{
							bool selectState = subDataList[j].GetUiLogicIndex() == selectSubLogicIndex;
							subDataList[j].SetSelectState(selectState);
							ActivityEntranceItemData activityEntranceItemData2 = new ActivityEntranceItemData();
							activityEntranceItemData2.SubData = subDataList[j];
							this.CurrentEntranceData.Add(activityEntranceItemData2);
						}
					}
				}
			}
			return this.CurrentEntranceData;
		}

		// Token: 0x04023802 RID: 145410
		private List<ActivityEntranceSelectItemBaseData> MainDataList;

		// Token: 0x04023803 RID: 145411
		private List<ActivityEntranceItemData> CurrentEntranceData;
	}
}
