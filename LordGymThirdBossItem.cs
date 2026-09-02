using System;
using System.Collections.Generic;
using UnrealEngine;

// Token: 0x0200220D RID: 8717
public class LordGymThirdBossItem : LordGymLordEntranceItem
{
	// Token: 0x0601074E RID: 67406 RVA: 0x0047E820 File Offset: 0x0047CA20
	protected override void OnRegisterComponent()
	{
		base.OnRegisterComponent();
		this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(4, typeof(UUIItem)));
		this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(5, typeof(UUIItem)));
		this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(6, typeof(UUIItem)));
		this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(7, typeof(UUISprite)));
	}

	// Token: 0x0601074F RID: 67407 RVA: 0x0047E8A0 File Offset: 0x0047CAA0
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		if (data != 0)
		{
			UUIItem item = base.GetItem(6);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(5);
			if (item2 != null)
			{
				item2.SetUIActive(true);
			}
			List<int> lordGymEntranceWithNewTag = ModelBase<LordGymModel>.Instance.GetLordGymEntranceWithNewTag();
			UUIItem item3 = base.GetItem(4);
			if (item3 != null)
			{
				item3.SetUIActive(lordGymEntranceWithNewTag.Contains(data));
			}
			this.SetSpriteByPath(StringUtils.Format("/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity30/LordGym/SP_BossTogBgDecoration{0}.SP_BossTogBgDecoration{1}", new string[]
			{
				data.ToString(),
				data.ToString()
			}), base.GetSprite(7), true, null, null);
			base.Refresh(data, isSelected, gridIndex);
			return;
		}
		UUIItem item4 = base.GetItem(6);
		if (item4 != null)
		{
			item4.SetUIActive(true);
		}
		UUIItem item5 = base.GetItem(5);
		if (item5 != null)
		{
			item5.SetUIActive(false);
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(3);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(EToggleState.ETT_UnDetermined, false, false, false);
	}

	// Token: 0x020084E4 RID: 34020
	private class EComponent
	{
		// Token: 0x0402D037 RID: 184375
		public const int ItemToggle = 3;

		// Token: 0x0402D038 RID: 184376
		public const int NewItem = 4;

		// Token: 0x0402D039 RID: 184377
		public const int NormalItem = 5;

		// Token: 0x0402D03A RID: 184378
		public const int NoneItem = 6;

		// Token: 0x0402D03B RID: 184379
		public const int BossIconSprite = 7;
	}
}
