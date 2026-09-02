using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x020062F8 RID: 25336
	public class SpringManorDrinkHandle : SpringManorGameHandleBase
	{
		// Token: 0x0603FAED RID: 260845 RVA: 0x010536E7 File Offset: 0x010518E7
		public override int GetCurrentProgress()
		{
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			if (instance == null)
			{
				return 0;
			}
			return instance.ActivityData.GetDrinksCurrentProgress();
		}

		// Token: 0x0603FAEE RID: 260846 RVA: 0x010536FE File Offset: 0x010518FE
		public override int GetTotalProgress()
		{
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			if (instance == null)
			{
				return 0;
			}
			return instance.ActivityData.GetDrinksTotalProgress();
		}

		// Token: 0x0603FAEF RID: 260847 RVA: 0x01053715 File Offset: 0x01051915
		public override void EnterGame()
		{
			ControllerBase<DrinksController>.Instance.OpenMainView(EDrinksGameplayOpenWay.FromView);
		}

		// Token: 0x0603FAF0 RID: 260848 RVA: 0x01053722 File Offset: 0x01051922
		public override ERedDotName? GetRedDotName()
		{
			return new ERedDotName?(ERedDotName.DrinksUnlockLevel);
		}
	}
}
