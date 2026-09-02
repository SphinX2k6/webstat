using System;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x020062F9 RID: 25337
	public class SpringManorGuessJokerHandle : SpringManorGameHandleBase
	{
		// Token: 0x0603FAF2 RID: 260850 RVA: 0x01053736 File Offset: 0x01051936
		public override int GetCurrentProgress()
		{
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			if (instance == null)
			{
				return 0;
			}
			return instance.ActivityData.GetGuessJokerCurrentProgress();
		}

		// Token: 0x0603FAF3 RID: 260851 RVA: 0x0105374D File Offset: 0x0105194D
		public override int GetTotalProgress()
		{
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			if (instance == null)
			{
				return 0;
			}
			return instance.ActivityData.GetGuessJokerTotalProgress();
		}

		// Token: 0x0603FAF4 RID: 260852 RVA: 0x01053764 File Offset: 0x01051964
		public override void EnterGame()
		{
			ModelBase<GuessJokerGamePlayModel>.Instance.OpenSelectRoleView(0).ContinueWith(delegate()
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.SpringManorGameplayEntryView, null);
			});
		}

		// Token: 0x0603FAF5 RID: 260853 RVA: 0x01053796 File Offset: 0x01051996
		public override ERedDotName? GetRedDotName()
		{
			return new ERedDotName?(ERedDotName.GuessJokerUnlockLevel);
		}
	}
}
