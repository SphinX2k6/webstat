using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001450 RID: 5200
public class NewbieCourseV2RewardBannerPanel : UiPanelBase
{
	// Token: 0x060090DF RID: 37087 RVA: 0x00261A3C File Offset: 0x0025FC3C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickWeaponPreview));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060090E0 RID: 37088 RVA: 0x00261B66 File Offset: 0x0025FD66
	public void SetActivityId(int activityId)
	{
		this.ActivityId = activityId;
	}

	// Token: 0x060090E1 RID: 37089 RVA: 0x00261B70 File Offset: 0x0025FD70
	public void RefreshWeaponPreviewEntrance()
	{
		bool flag = ((this.ActivityId > 0) ? ConfigBase<ActivityNewbieCourseV2Config>.Instance.GetWeaponPreviewIdsForActivity(this.ActivityId) : Array.Empty<int>()).Length != 0;
		UUIButtonComponent button = base.GetButton(5);
		if (button != null)
		{
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(flag);
			}
		}
		if (button == null)
		{
			return;
		}
		UUIItem uuiitem2 = button.RootUIComp.Get();
		if (uuiitem2 == null)
		{
			return;
		}
		uuiitem2.SetRaycastTarget(flag);
	}

	// Token: 0x060090E2 RID: 37090 RVA: 0x00261BE8 File Offset: 0x0025FDE8
	private void OnClickWeaponPreview()
	{
		if (this.ActivityId <= 0)
		{
			return;
		}
		int[] weaponPreviewIdsForActivity = ConfigBase<ActivityNewbieCourseV2Config>.Instance.GetWeaponPreviewIdsForActivity(this.ActivityId);
		if (weaponPreviewIdsForActivity.Length == 0)
		{
			return;
		}
		List<WeaponTrialData> list = this.BuildWeaponPreviewTrialDataList(weaponPreviewIdsForActivity);
		if (list.Count == 0)
		{
			return;
		}
		WeaponPreviewViewParam weaponPreviewViewParam = new WeaponPreviewViewParam();
		WeaponDataBase[] weaponDataList = list.ToArray();
		weaponPreviewViewParam.WeaponDataList = weaponDataList;
		weaponPreviewViewParam.SelectedIndex = 0;
		WeaponPreviewViewParam param = weaponPreviewViewParam;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WeaponPreviewView, param, null);
	}

	// Token: 0x060090E3 RID: 37091 RVA: 0x00261C54 File Offset: 0x0025FE54
	[NullableContext(1)]
	private List<WeaponTrialData> BuildWeaponPreviewTrialDataList(IReadOnlyList<int> previewIds)
	{
		List<WeaponTrialData> list = new List<WeaponTrialData>();
		foreach (int num in previewIds)
		{
			if (num > 0)
			{
				TrialWeaponInfo? trialWeaponConfig = ConfigBase<WeaponConfig>.Instance.GetTrialWeaponConfig(num);
				if (trialWeaponConfig != null)
				{
					WeaponTrialData weaponTrialData = new WeaponTrialData();
					weaponTrialData.SetTrialId(trialWeaponConfig.Value.Id, true);
					list.Add(weaponTrialData);
				}
			}
		}
		return list;
	}

	// Token: 0x04004334 RID: 17204
	private int ActivityId;

	// Token: 0x0200784E RID: 30798
	private static class ERewardBannerComponents
	{
		// Token: 0x040295F6 RID: 169462
		public const int SprIconLock = 0;

		// Token: 0x040295F7 RID: 169463
		public const int SprIcon = 1;

		// Token: 0x040295F8 RID: 169464
		public const int TxtRewardTitle = 2;

		// Token: 0x040295F9 RID: 169465
		public const int TxtRewardDesc = 3;

		// Token: 0x040295FA RID: 169466
		public const int RedDot = 4;

		// Token: 0x040295FB RID: 169467
		public const int BtnLookA = 5;
	}
}
