using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020013B3 RID: 5043
public class BusinessSkipItem : UiPanelBase
{
	// Token: 0x06008B2E RID: 35630 RVA: 0x0024A9FC File Offset: 0x00248BFC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnSkipToOther))
		};
	}

	// Token: 0x06008B2F RID: 35631 RVA: 0x0024AA7C File Offset: 0x00248C7C
	private void OnSkipToOther()
	{
		if (this.UnlockData.Item1 != EMoonChasingUnlockType.Building)
		{
			if (this.UnlockData.Item1 == EMoonChasingUnlockType.BranchTask)
			{
				ControllerBase<MoonChasingController>.Instance.OpenTaskView(EMoonChasingTaskType.BranchLine, this.UnlockData.Item2, false);
			}
			return;
		}
		BusinessViewController vc = this.Vc;
		if (vc == null)
		{
			return;
		}
		vc.SkipToBuild();
	}

	// Token: 0x06008B30 RID: 35632 RVA: 0x0024AACC File Offset: 0x00248CCC
	[NullableContext(1)]
	public void RegisterViewController(BusinessViewController vc)
	{
		this.Vc = vc;
	}

	// Token: 0x06008B31 RID: 35633 RVA: 0x0024AAD8 File Offset: 0x00248CD8
	public void Refresh()
	{
		ValueTuple<EMoonChasingUnlockType, int>? firstUnlockData = ModelBase<MoonChasingModel>.Instance.GetFirstUnlockData();
		if (firstUnlockData == null)
		{
			return;
		}
		string textStringId = "";
		this.UnlockData = firstUnlockData.Value;
		if (this.UnlockData.Item1 == EMoonChasingUnlockType.Building)
		{
			textStringId = "Moonfiesta_PartnerTip2";
		}
		else if (this.UnlockData.Item1 == EMoonChasingUnlockType.BranchTask)
		{
			textStringId = "Moonfiesta_PartnerTip1";
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textStringId, Array.Empty<object>());
	}

	// Token: 0x04004104 RID: 16644
	[Nullable(2)]
	private BusinessViewController Vc;

	// Token: 0x04004105 RID: 16645
	private ValueTuple<EMoonChasingUnlockType, int> UnlockData;

	// Token: 0x02007777 RID: 30583
	private static class EComponentDefine
	{
		// Token: 0x0402922B RID: 168491
		public const int Tips = 0;

		// Token: 0x0402922C RID: 168492
		public const int RoleIcon = 1;

		// Token: 0x0402922D RID: 168493
		public const int Button = 2;
	}
}
