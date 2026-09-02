using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D67 RID: 23911
	public class FlagChallengeLevelInfoItem : UiPanelBase
	{
		// Token: 0x0603C3DD RID: 246749 RVA: 0x00F47FC1 File Offset: 0x00F461C1
		public FlagChallengeLevelInfoItem(int activityId)
		{
			this.ActivityId = activityId;
		}

		// Token: 0x0603C3DE RID: 246750 RVA: 0x00F47FD0 File Offset: 0x00F461D0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIArtText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(3, new Action(this.OnHelpBtnClick))
			};
		}

		// Token: 0x0603C3DF RID: 246751 RVA: 0x00F4807C File Offset: 0x00F4627C
		protected override void OnStart()
		{
			int roleLevelHelpId = ConfigBase<FlagChallengeConfig>.Instance.GetRoleLevelHelpId();
			base.GetButton(3).RootUIComp.Get().SetUIActive(roleLevelHelpId > 0);
		}

		// Token: 0x0603C3E0 RID: 246752 RVA: 0x00F480B4 File Offset: 0x00F462B4
		public void RefreshView()
		{
			FlagChallengeModel instance = ModelBase<FlagChallengeModel>.Instance;
			int totalLevel = instance.GetTotalLevel(this.ActivityId);
			int totalLevelExp = instance.GetTotalLevelExp(this.ActivityId);
			base.GetArtText(0).SetText(totalLevel.ToString());
			int targetLevelExp = instance.GetTargetLevelExp(this.ActivityId, new int?(totalLevel), new int?(totalLevelExp));
			int targetLevelUpExp = instance.GetTargetLevelUpExp(this.ActivityId, new int?(totalLevel));
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(targetLevelExp);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(targetLevelUpExp);
			string newText = defaultInterpolatedStringHandler.ToStringAndClear();
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.SetText(newText, true);
			}
			float targetLevelExpProgress = instance.GetTargetLevelExpProgress(this.ActivityId, new int?(totalLevel), new int?(totalLevelExp));
			UUISprite sprite = base.GetSprite(2);
			if (sprite != null)
			{
				sprite.SetFillAmount(targetLevelExpProgress);
			}
			base.GetText(4).ShowTextNew("Morale_32_Main_Lv");
		}

		// Token: 0x0603C3E1 RID: 246753 RVA: 0x00F481A0 File Offset: 0x00F463A0
		private void OnHelpBtnClick()
		{
			int roleLevelHelpId = ConfigBase<FlagChallengeConfig>.Instance.GetRoleLevelHelpId();
			ControllerBase<HelpController>.Instance.OpenHelpById(roleLevelHelpId);
		}

		// Token: 0x04021D9F RID: 138655
		private readonly int ActivityId;
	}
}
