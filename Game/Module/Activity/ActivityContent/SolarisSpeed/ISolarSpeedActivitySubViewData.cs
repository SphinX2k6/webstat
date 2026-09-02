using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x02006373 RID: 25459
	[NullableContext(1)]
	public interface ISolarSpeedActivitySubViewData
	{
		// Token: 0x17009CED RID: 40173
		// (get) Token: 0x0603FEE9 RID: 261865
		// (set) Token: 0x0603FEEA RID: 261866
		string RewardTextId { get; set; }

		// Token: 0x17009CEE RID: 40174
		// (get) Token: 0x0603FEEB RID: 261867
		// (set) Token: 0x0603FEEC RID: 261868
		string ButtonTextId { get; set; }

		// Token: 0x17009CEF RID: 40175
		// (get) Token: 0x0603FEED RID: 261869
		// (set) Token: 0x0603FEEE RID: 261870
		Func<bool> RewardRedDotStateGetter { get; set; }

		// Token: 0x17009CF0 RID: 40176
		// (get) Token: 0x0603FEEF RID: 261871
		// (set) Token: 0x0603FEF0 RID: 261872
		Func<bool> ConfirmRedDotStateGetter { get; set; }

		// Token: 0x17009CF1 RID: 40177
		// (get) Token: 0x0603FEF1 RID: 261873
		// (set) Token: 0x0603FEF2 RID: 261874
		Func<string> RewardProgressCurrentGetter { get; set; }

		// Token: 0x17009CF2 RID: 40178
		// (get) Token: 0x0603FEF3 RID: 261875
		// (set) Token: 0x0603FEF4 RID: 261876
		string RewardProgressTextId { get; set; }

		// Token: 0x17009CF3 RID: 40179
		// (get) Token: 0x0603FEF5 RID: 261877
		// (set) Token: 0x0603FEF6 RID: 261878
		string RewardProgressTotal { get; set; }
	}
}
