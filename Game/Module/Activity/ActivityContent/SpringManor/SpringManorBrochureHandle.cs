using System;
using Aki.Config;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x020062F6 RID: 25334
	public class SpringManorBrochureHandle : SpringManorGameHandleBase
	{
		// Token: 0x0603FAE3 RID: 260835 RVA: 0x010532E8 File Offset: 0x010514E8
		public override int GetCurrentProgress()
		{
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			int? num;
			if (instance == null)
			{
				num = null;
			}
			else
			{
				SpringManorData activityData = instance.ActivityData;
				num = ((activityData != null) ? new int?(activityData.Id) : null);
			}
			int? num2 = num;
			if (num2 == null)
			{
				return 0;
			}
			int num3 = 0;
			SpringManorConfig instance2 = ConfigBase<SpringManorConfig>.Instance;
			Brochure? brochure = (instance2 != null) ? instance2.GetSpringManorBrochureByActivityAndType(num2.Value, EBrochureType.Brochure) : null;
			if (brochure != null)
			{
				for (int i = 0; i < brochure.Value.BookItemIdsLength; i++)
				{
					int id = brochure.Value.BookItemIds(i);
					if (ModelBase<SpringManorModel>.Instance.ActivityData.GetBookItemStateById(id) == EBrochureState.Rewarded)
					{
						num3++;
					}
				}
			}
			return num3;
		}

		// Token: 0x0603FAE4 RID: 260836 RVA: 0x010533B0 File Offset: 0x010515B0
		public override int GetTotalProgress()
		{
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			int? num;
			if (instance == null)
			{
				num = null;
			}
			else
			{
				SpringManorData activityData = instance.ActivityData;
				num = ((activityData != null) ? new int?(activityData.Id) : null);
			}
			int? num2 = num;
			if (num2 == null)
			{
				return 0;
			}
			SpringManorConfig instance2 = ConfigBase<SpringManorConfig>.Instance;
			Brochure? brochure;
			return ((instance2 != null) ? ((instance2.GetSpringManorBrochureByActivityAndType(num2.Value, EBrochureType.Brochure) != null) ? new int?(brochure.GetValueOrDefault().BookItemIdsLength) : null) : null).GetValueOrDefault();
		}

		// Token: 0x0603FAE5 RID: 260837 RVA: 0x0105344D File Offset: 0x0105164D
		public override void EnterGame()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SpringManorBrochureView, null, null);
		}

		// Token: 0x0603FAE6 RID: 260838 RVA: 0x01053460 File Offset: 0x01051660
		public override ERedDotName? GetRedDotName()
		{
			return new ERedDotName?(ERedDotName.SpringManorBrochureReward);
		}
	}
}
