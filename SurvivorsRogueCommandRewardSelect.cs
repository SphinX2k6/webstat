using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002AEF RID: 10991
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueCommandRewardSelect : SurvivorsRogueCommandBaseObtain
{
	// Token: 0x06015FAC RID: 90028 RVA: 0x00619E28 File Offset: 0x00618028
	public SurvivorsRogueCommandRewardSelect(ESurvivorsRogueCommandType type) : base(type)
	{
	}

	// Token: 0x06015FAD RID: 90029 RVA: 0x00619E34 File Offset: 0x00618034
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
		defaultInterpolatedStringHandler.AppendLiteral("[RewardSelect] Count: ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.GetSurvivorsOption().GoodsDetails.Count);
		defaultInterpolatedStringHandler.AppendLiteral(" ");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06015FAE RID: 90030 RVA: 0x00619E81 File Offset: 0x00618081
	private SurvivorsOption GetSurvivorsOption()
	{
		return this.Data.TokenSelectView.SurvivorsOption;
	}

	// Token: 0x06015FAF RID: 90031 RVA: 0x00619E94 File Offset: 0x00618094
	[NullableContext(2)]
	public override ISurvivorsObtainViewInfo GetViewInfo()
	{
		SurvivorsOption survivorsOption = this.GetSurvivorsOption();
		return new SurvivorsObtainViewInfo
		{
			CaptionId = "SurvivorPropSelection_ScreenName",
			TitleId = "SurvivorsNewProp_Title",
			ButtonId = "SurvivorsNewProp_ConfirtButton",
			ChooseData = base.GetChooseData(survivorsOption, new ESurvivorsObtainMode?(ESurvivorsObtainMode.SingleSelect)),
			GoodsList = survivorsOption.GoodsDetails
		};
	}
}
