using System;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Anniversary
{
	// Token: 0x020069E0 RID: 27104
	public class AnniversarySubActivityPinballUiItem : AnniversaryActivityEnterItem
	{
		// Token: 0x060432F2 RID: 275186 RVA: 0x011435F0 File Offset: 0x011417F0
		public override void ChildUpdateTips()
		{
			UUIText text = base.GetText(1);
			if (text == null || this.Data == null)
			{
				return;
			}
			text.SetUIActive(false);
			AnniversarySubActivityPinball anniversarySubActivityPinball = this.Data as AnniversarySubActivityPinball;
			if (anniversarySubActivityPinball == null || anniversarySubActivityPinball.ActivityData == null || !anniversarySubActivityPinball.ActivityData.IsUnLock())
			{
				return;
			}
			if (anniversarySubActivityPinball.GetNewChapter())
			{
				text.SetUIActive(true);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "Activity_Anniversary2_01_New", Array.Empty<object>());
				return;
			}
			long nextLockedChapterTime = anniversarySubActivityPinball.GetNextLockedChapterTime();
			if (nextLockedChapterTime > 0L)
			{
				string text2 = ConfigBase<TextConfig>.Instance.GetMultiTextByKey("Activity_Anniversary2_01_Time") ?? "";
				string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(nextLockedChapterTime, text2);
				if (string.IsNullOrEmpty(remainTimeText))
				{
					return;
				}
				text.SetUIActive(true);
				text.SetText(remainTimeText, true);
			}
		}
	}
}
