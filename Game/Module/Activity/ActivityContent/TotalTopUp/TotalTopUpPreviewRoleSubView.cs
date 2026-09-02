using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Item;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x0200627A RID: 25210
	[NullableContext(1)]
	[Nullable(0)]
	public class TotalTopUpPreviewRoleSubView : TotalTopUpPreviewSubViewBase
	{
		// Token: 0x0603F7D8 RID: 260056 RVA: 0x01047390 File Offset: 0x01045590
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickCheckItem)),
				new ValueTuple<int, Delegate>(1, new Action(this.OnClickCheckRole))
			};
		}

		// Token: 0x0603F7D9 RID: 260057 RVA: 0x01047410 File Offset: 0x01045610
		public override void ShowPreview(ITotalTopUpPreviewViewParam param)
		{
			if (param == null)
			{
				return;
			}
			TotalTopUpRewardData rewardData = param.RewardData;
			if (((rewardData != null) ? rewardData.TotalTopUpRolePackageData : null) == null)
			{
				return;
			}
			TotalTopUpRolePackageData totalTopUpRolePackageData = param.RewardData.TotalTopUpRolePackageData;
			this.TrailIdList = new List<int>(totalTopUpRolePackageData.RoleTrialIdList);
			this.PropsItemId = totalTopUpRolePackageData.ItemId;
		}

		// Token: 0x0603F7DA RID: 260058 RVA: 0x0104745F File Offset: 0x0104565F
		private void OnClickCheckItem()
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.PropsItemId, false, null);
		}

		// Token: 0x0603F7DB RID: 260059 RVA: 0x01047474 File Offset: 0x01045674
		private void OnClickCheckRole()
		{
			ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Preview, 0, this.TrailIdList, null, null);
		}

		// Token: 0x04023A42 RID: 145986
		private List<int> TrailIdList = new List<int>();

		// Token: 0x04023A43 RID: 145987
		private int PropsItemId;
	}
}
