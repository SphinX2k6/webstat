using System;
using Aki.Config;
using UnrealEngine;

// Token: 0x02002210 RID: 8720
public class LordGymThirdLevelItem : LordGymDifficultyItem
{
	// Token: 0x06010775 RID: 67445 RVA: 0x0047F3C4 File Offset: 0x0047D5C4
	protected override void OnRegisterComponent()
	{
		base.OnRegisterComponent();
		this.ComponentRegisterInfos[1] = new ValueTuple<int, Type>(1, typeof(UUISprite));
	}

	// Token: 0x06010776 RID: 67446 RVA: 0x0047F3E8 File Offset: 0x0047D5E8
	protected override void SetLevelText(LordGym config)
	{
		string text = config.Difficulty.ToString();
		this.SetSpriteByPath(StringUtils.Format("/Game/Aki/UI/UIResources/Common/Atlas/SP_ComRomeText_0{0}.SP_ComRomeText_0{1}", new string[]
		{
			text,
			text
		}), base.GetSprite(1), true, null, null);
	}

	// Token: 0x020084F2 RID: 34034
	private class EComponent
	{
		// Token: 0x0402D069 RID: 184425
		public const int NumSprite = 1;
	}
}
