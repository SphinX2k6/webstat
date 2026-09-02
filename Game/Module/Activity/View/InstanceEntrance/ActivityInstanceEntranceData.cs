using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.View.InstanceEntrance
{
	// Token: 0x020061DB RID: 25051
	[NullableContext(2)]
	[Nullable(0)]
	public class ActivityInstanceEntranceData
	{
		// Token: 0x0603F378 RID: 258936 RVA: 0x0103A2F1 File Offset: 0x010384F1
		public ActivityEntrancePointData GetActivityEntrancePointData()
		{
			return this.ActivityEntrancePointData;
		}

		// Token: 0x0603F379 RID: 258937 RVA: 0x0103A2F9 File Offset: 0x010384F9
		public ActivityEntranceDescInfoData GetActivityEntranceDescInfoData()
		{
			return this.ActivityEntranceDescInfoData;
		}

		// Token: 0x0603F37A RID: 258938 RVA: 0x0103A301 File Offset: 0x01038501
		public ActivityEntranceSelectItemData GetActivityEntranceSelectItemData()
		{
			return this.ActivityEntranceSelectItemData;
		}

		// Token: 0x0603F37B RID: 258939 RVA: 0x0103A309 File Offset: 0x01038509
		public ActivityEntranceCaptionItemData GetActivityEntranceCaptionItemData()
		{
			return this.ActivityEntranceCaptionItemData;
		}

		// Token: 0x0603F37C RID: 258940 RVA: 0x0103A311 File Offset: 0x01038511
		public ActivityEntranceDropDownData GetActivityEntranceDropDownData()
		{
			return this.ActivityEntranceDropDownData;
		}

		// Token: 0x0603F37D RID: 258941 RVA: 0x0103A319 File Offset: 0x01038519
		public ActivityEntranceMonsterPreviewData GetActivityEntranceMonsterPreviewData()
		{
			return this.ActivityEntranceMonsterPreviewData;
		}

		// Token: 0x0603F37E RID: 258942 RVA: 0x0103A321 File Offset: 0x01038521
		public Action<int> GetClickConfirmCallBack()
		{
			return this.ClickConfirmCallBack;
		}

		// Token: 0x0603F37F RID: 258943 RVA: 0x0103A32C File Offset: 0x0103852C
		[NullableContext(1)]
		public static ActivityInstanceEntranceData Create(ActivityEntrancePointData activityEntrancePointData, ActivityEntranceDescInfoData activityEntranceDescInfoData, ActivityEntranceSelectItemData activityEntranceSelectItemData, ActivityEntranceCaptionItemData activityEntranceCaptionItemData, ActivityEntranceDropDownData activityEntranceDropDownData, ActivityEntranceMonsterPreviewData activityEntranceMonsterPreviewData, Action clickConfirmCallBack)
		{
			return new ActivityInstanceEntranceData
			{
				ActivityEntrancePointData = activityEntrancePointData,
				ActivityEntranceDescInfoData = activityEntranceDescInfoData,
				ActivityEntranceSelectItemData = activityEntranceSelectItemData,
				ActivityEntranceCaptionItemData = activityEntranceCaptionItemData,
				ActivityEntranceMonsterPreviewData = activityEntranceMonsterPreviewData,
				ActivityEntranceDropDownData = activityEntranceDropDownData,
				ClickConfirmCallBack = delegate(int _)
				{
					Action clickConfirmCallBack2 = clickConfirmCallBack;
					if (clickConfirmCallBack2 == null)
					{
						return;
					}
					clickConfirmCallBack2();
				}
			};
		}

		// Token: 0x040237EE RID: 145390
		private ActivityEntrancePointData ActivityEntrancePointData;

		// Token: 0x040237EF RID: 145391
		private ActivityEntranceDescInfoData ActivityEntranceDescInfoData;

		// Token: 0x040237F0 RID: 145392
		private ActivityEntranceSelectItemData ActivityEntranceSelectItemData;

		// Token: 0x040237F1 RID: 145393
		private ActivityEntranceCaptionItemData ActivityEntranceCaptionItemData;

		// Token: 0x040237F2 RID: 145394
		private ActivityEntranceDropDownData ActivityEntranceDropDownData;

		// Token: 0x040237F3 RID: 145395
		private ActivityEntranceMonsterPreviewData ActivityEntranceMonsterPreviewData;

		// Token: 0x040237F4 RID: 145396
		private Action<int> ClickConfirmCallBack;
	}
}
