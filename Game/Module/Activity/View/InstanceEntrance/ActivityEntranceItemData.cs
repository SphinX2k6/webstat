using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.View.InstanceEntrance
{
	// Token: 0x020061E0 RID: 25056
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityEntranceItemData
	{
		// Token: 0x0603F399 RID: 258969 RVA: 0x0103A72C File Offset: 0x0103892C
		public int GetSelectDataIndex()
		{
			ActivityEntranceSelectItemBaseData activityEntranceSelectItemBaseData = (this.MainData != null) ? this.MainData : this.SubData;
			if (activityEntranceSelectItemBaseData != null)
			{
				return activityEntranceSelectItemBaseData.GetDataIndex();
			}
			return 0;
		}

		// Token: 0x0603F39A RID: 258970 RVA: 0x0103A75C File Offset: 0x0103895C
		public int GetSelectUiLogicIndex()
		{
			ActivityEntranceSelectItemBaseData activityEntranceSelectItemBaseData = (this.MainData != null) ? this.MainData : this.SubData;
			if (activityEntranceSelectItemBaseData != null)
			{
				return activityEntranceSelectItemBaseData.GetUiLogicIndex();
			}
			return 0;
		}

		// Token: 0x0603F39B RID: 258971 RVA: 0x0103A78C File Offset: 0x0103898C
		public bool GetLockState()
		{
			ActivityEntranceSelectItemBaseData activityEntranceSelectItemBaseData = (this.MainData != null) ? this.MainData : this.SubData;
			return activityEntranceSelectItemBaseData != null && activityEntranceSelectItemBaseData.GetLockState();
		}

		// Token: 0x0603F39C RID: 258972 RVA: 0x0103A7BC File Offset: 0x010389BC
		public string GetUnLockDesc()
		{
			ActivityEntranceSelectItemBaseData activityEntranceSelectItemBaseData = (this.MainData != null) ? this.MainData : this.SubData;
			if (activityEntranceSelectItemBaseData != null)
			{
				return activityEntranceSelectItemBaseData.GetUnlockDesc();
			}
			return string.Empty;
		}

		// Token: 0x0603F39D RID: 258973 RVA: 0x0103A7EF File Offset: 0x010389EF
		public int GetStyle()
		{
			if (this.MainData != null)
			{
				return 0;
			}
			return 1;
		}

		// Token: 0x0603F39E RID: 258974 RVA: 0x0103A7FC File Offset: 0x010389FC
		public bool GetSelectState()
		{
			ActivityEntranceSelectItemBaseData activityEntranceSelectItemBaseData = (this.MainData != null) ? this.MainData : this.SubData;
			return activityEntranceSelectItemBaseData != null && activityEntranceSelectItemBaseData.GetSelectState();
		}

		// Token: 0x0603F39F RID: 258975 RVA: 0x0103A82C File Offset: 0x01038A2C
		public bool GetFinishState()
		{
			ActivityEntranceSelectItemBaseData activityEntranceSelectItemBaseData = (this.MainData != null) ? this.MainData : this.SubData;
			return activityEntranceSelectItemBaseData != null && activityEntranceSelectItemBaseData.GetFinishState();
		}

		// Token: 0x0603F3A0 RID: 258976 RVA: 0x0103A85C File Offset: 0x01038A5C
		public int GetInstanceDungeonId()
		{
			ActivityEntranceSelectItemBaseData activityEntranceSelectItemBaseData = (this.MainData != null) ? this.MainData : this.SubData;
			if (activityEntranceSelectItemBaseData != null)
			{
				return activityEntranceSelectItemBaseData.GetInstanceDungeonId();
			}
			return 0;
		}

		// Token: 0x0603F3A1 RID: 258977 RVA: 0x0103A88C File Offset: 0x01038A8C
		public string GetDesc()
		{
			ActivityEntranceSelectItemBaseData activityEntranceSelectItemBaseData = (this.MainData != null) ? this.MainData : this.SubData;
			if (activityEntranceSelectItemBaseData != null)
			{
				return activityEntranceSelectItemBaseData.GetDesc();
			}
			return string.Empty;
		}

		// Token: 0x0603F3A2 RID: 258978 RVA: 0x0103A8C0 File Offset: 0x01038AC0
		public bool HaveChildData()
		{
			if (this.MainData != null)
			{
				ActivityEntranceSelectItemSubData[] subDataList = this.MainData.GetSubDataList();
				return subDataList != null && subDataList.Length != 0;
			}
			return false;
		}

		// Token: 0x0603F3A3 RID: 258979 RVA: 0x0103A8F0 File Offset: 0x01038AF0
		public InstanceDungeon? GetInstanceConfig()
		{
			int instanceDungeonId = this.GetInstanceDungeonId();
			if (instanceDungeonId == 0)
			{
				return null;
			}
			return ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceDungeonId);
		}

		// Token: 0x0603F3A4 RID: 258980 RVA: 0x0103A91C File Offset: 0x01038B1C
		public string GetInstanceDifficultIconPath()
		{
			InstanceDungeon? instanceDungeon;
			return ((this.GetInstanceConfig() != null) ? instanceDungeon.GetValueOrDefault().DifficultyIcon : null) ?? string.Empty;
		}

		// Token: 0x0603F3A5 RID: 258981 RVA: 0x0103A954 File Offset: 0x01038B54
		public string GetInstanceName()
		{
			InstanceDungeon? instanceDungeon;
			string text = (this.GetInstanceConfig() != null) ? instanceDungeon.GetValueOrDefault().MapName : null;
			if (!string.IsNullOrEmpty(text))
			{
				return ConfigMultiTextLang.GetLocalTextNew(text, null);
			}
			return string.Empty;
		}

		// Token: 0x0603F3A6 RID: 258982 RVA: 0x0103A99C File Offset: 0x01038B9C
		[NullableContext(2)]
		public Action<int> GetSelectCallBack()
		{
			ActivityEntranceSelectItemBaseData activityEntranceSelectItemBaseData = (this.MainData != null) ? this.MainData : this.SubData;
			if (activityEntranceSelectItemBaseData != null)
			{
				return activityEntranceSelectItemBaseData.GetClickCallBack();
			}
			return null;
		}

		// Token: 0x0603F3A7 RID: 258983 RVA: 0x0103A9CC File Offset: 0x01038BCC
		public bool GetRedDotState()
		{
			ActivityEntranceSelectItemBaseData activityEntranceSelectItemBaseData = (this.MainData != null) ? this.MainData : this.SubData;
			return activityEntranceSelectItemBaseData != null && activityEntranceSelectItemBaseData.GetRedDotState();
		}

		// Token: 0x0603F3A8 RID: 258984 RVA: 0x0103A9FC File Offset: 0x01038BFC
		public int GetRecommendLevel()
		{
			ActivityEntranceSelectItemBaseData activityEntranceSelectItemBaseData = (this.MainData != null) ? this.MainData : this.SubData;
			if (activityEntranceSelectItemBaseData != null)
			{
				return activityEntranceSelectItemBaseData.GetRecommendLevel();
			}
			return 0;
		}

		// Token: 0x0603F3A9 RID: 258985 RVA: 0x0103AA2C File Offset: 0x01038C2C
		public string GetSubTitle()
		{
			ActivityEntranceSelectItemBaseData activityEntranceSelectItemBaseData = (this.MainData != null) ? this.MainData : this.SubData;
			if (activityEntranceSelectItemBaseData != null)
			{
				return activityEntranceSelectItemBaseData.GetSubTitle();
			}
			return string.Empty;
		}

		// Token: 0x0603F3AA RID: 258986 RVA: 0x0103AA60 File Offset: 0x01038C60
		public int GetDefaultDifficultIndex()
		{
			ActivityEntranceSelectItemBaseData activityEntranceSelectItemBaseData = (this.MainData != null) ? this.MainData : this.SubData;
			if (activityEntranceSelectItemBaseData != null)
			{
				return activityEntranceSelectItemBaseData.GetDefaultDifficultIndex();
			}
			return 0;
		}

		// Token: 0x0603F3AB RID: 258987 RVA: 0x0103AA90 File Offset: 0x01038C90
		public string GetBgPath()
		{
			ActivityEntranceSelectItemBaseData activityEntranceSelectItemBaseData = (this.MainData != null) ? this.MainData : this.SubData;
			if (activityEntranceSelectItemBaseData != null)
			{
				return activityEntranceSelectItemBaseData.GetBgPath();
			}
			return string.Empty;
		}

		// Token: 0x04023804 RID: 145412
		[Nullable(2)]
		public ActivityEntranceSelectItemBaseData MainData;

		// Token: 0x04023805 RID: 145413
		[Nullable(2)]
		public ActivityEntranceSelectItemSubData SubData;
	}
}
