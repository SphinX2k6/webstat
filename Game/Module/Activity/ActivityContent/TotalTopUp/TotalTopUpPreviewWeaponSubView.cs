using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x0200627D RID: 25213
	[NullableContext(1)]
	[Nullable(0)]
	public class TotalTopUpPreviewWeaponSubView : TotalTopUpPreviewSubViewBase
	{
		// Token: 0x0603F7DF RID: 260063 RVA: 0x010474F8 File Offset: 0x010456F8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickCheck))
			};
		}

		// Token: 0x0603F7E0 RID: 260064 RVA: 0x01047549 File Offset: 0x01045749
		public override void ShowPreview(ITotalTopUpPreviewViewParam param)
		{
			if (param == null)
			{
				return;
			}
			TotalTopUpRewardData rewardData = param.RewardData;
			if (((rewardData != null) ? rewardData.TotalTopUpWeaponPackageData : null) == null)
			{
				return;
			}
			this.TrailIdList = new List<int>(param.RewardData.TotalTopUpWeaponPackageData.WeaponTrialIdList);
		}

		// Token: 0x0603F7E1 RID: 260065 RVA: 0x01047580 File Offset: 0x01045780
		private void OnClickCheck()
		{
			List<WeaponDataBase> list = new List<WeaponDataBase>();
			foreach (int num in this.TrailIdList)
			{
				WeaponTrialData weaponTrialData = new WeaponTrialData();
				weaponTrialData.SetTrialId(num, true);
				list.Add(weaponTrialData);
				string message = "预览武器试用ID";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TrialId", num);
				TotalTopUpUtil.Debug(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			WeaponPreviewViewParam param = new WeaponPreviewViewParam
			{
				WeaponDataList = list.ToArray(),
				SelectedIndex = 0
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.WeaponPreviewView, param, null);
		}

		// Token: 0x04023A47 RID: 145991
		private List<int> TrailIdList = new List<int>();
	}
}
