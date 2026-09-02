using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062ED RID: 25325
	public class TetrisTipsEndLessStartView : TetrisTipsBaseView
	{
		// Token: 0x0603FABB RID: 260795 RVA: 0x01052C5A File Offset: 0x01050E5A
		[NullableContext(1)]
		public TetrisTipsEndLessStartView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603FABC RID: 260796 RVA: 0x01052C63 File Offset: 0x01050E63
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText))
			};
		}

		// Token: 0x0603FABD RID: 260797 RVA: 0x01052C86 File Offset: 0x01050E86
		protected override void OnBeforeShow()
		{
			this.Refresh();
		}

		// Token: 0x0603FABE RID: 260798 RVA: 0x01052C90 File Offset: 0x01050E90
		private void Refresh()
		{
			AchievementData achievementData = ModelBase<AchievementModel>.Instance.GetAchievementData(101119);
			if (achievementData == null || achievementData.GetFinishState() > EAchievementStateEnum.UnFinished)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "Tetristext_16", Array.Empty<object>());
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "Tetristext_15", Array.Empty<object>());
		}

		// Token: 0x04023C07 RID: 146439
		private const int ACHIEVEMENT_ID = 101119;
	}
}
