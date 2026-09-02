using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.BossRush
{
	// Token: 0x020069CB RID: 27083
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class BossRushRewardItem : GridProxyAbstract<RewardContentData>
	{
		// Token: 0x0604323C RID: 275004 RVA: 0x0113F860 File Offset: 0x0113DA60
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0604323D RID: 275005 RVA: 0x0113F9AB File Offset: 0x0113DBAB
		protected override void OnStart()
		{
			this.ItemLayout = new GenericLayout<CommonItemSmallItemGrid, TItem>(base.GetHorizontalLayout(2), new Func<CommonItemSmallItemGrid>(this.InitGridItem), null, false, true);
		}

		// Token: 0x0604323E RID: 275006 RVA: 0x0113F9CE File Offset: 0x0113DBCE
		private CommonItemSmallItemGrid InitGridItem()
		{
			return new CommonItemSmallItemGrid();
		}

		// Token: 0x0604323F RID: 275007 RVA: 0x0113F9D8 File Offset: 0x0113DBD8
		public override void Refresh(RewardContentData contentData, bool isSelected, int gridIndex)
		{
			this.RewardData = contentData;
			IActivityRewardData rewardData = contentData.RewardData;
			if (rewardData.NameTextArgs != null)
			{
				base.GetText(1).SetText(rewardData.NameTextArgs[0] + "/" + rewardData.NameTextArgs[1], true);
				base.GetText(0).SetText(rewardData.NameText ?? "", true);
			}
			base.GetButton(4).RootUIComp.Get().SetUIActive(rewardData.RewardState == EActivityRewardState.Enable);
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(rewardData.RewardState == EActivityRewardState.Disabled);
			}
			UUIItem item2 = base.GetItem(6);
			if (item2 != null)
			{
				item2.SetUIActive(rewardData.RewardState == EActivityRewardState.Claimed);
			}
			GenericLayout<CommonItemSmallItemGrid, TItem> itemLayout = this.ItemLayout;
			if (itemLayout == null)
			{
				return;
			}
			itemLayout.RefreshByData(rewardData.RewardList.ToList<TItem>() ?? new List<TItem>(), null, false);
		}

		// Token: 0x06043240 RID: 275008 RVA: 0x0113FABC File Offset: 0x0113DCBC
		private void OnClickButton()
		{
			RewardContentData rewardData = this.RewardData;
			if (rewardData == null)
			{
				return;
			}
			IActivityRewardData rewardData2 = rewardData.RewardData;
			if (rewardData2 == null)
			{
				return;
			}
			Action clickFunction = rewardData2.ClickFunction;
			if (clickFunction == null)
			{
				return;
			}
			clickFunction();
		}

		// Token: 0x0402569E RID: 153246
		private RewardContentData RewardData;

		// Token: 0x0402569F RID: 153247
		private GenericLayout<CommonItemSmallItemGrid, TItem> ItemLayout;

		// Token: 0x0200C94F RID: 51535
		[NullableContext(0)]
		public class EBossRushRewardItemComponent
		{
			// Token: 0x0403DE9B RID: 253595
			public const int NameText = 0;

			// Token: 0x0403DE9C RID: 253596
			public const int NumText = 1;

			// Token: 0x0403DE9D RID: 253597
			public const int RewardLayout = 2;

			// Token: 0x0403DE9E RID: 253598
			public const int RewardItem = 3;

			// Token: 0x0403DE9F RID: 253599
			public const int Button = 4;

			// Token: 0x0403DEA0 RID: 253600
			public const int DoingItem = 5;

			// Token: 0x0403DEA1 RID: 253601
			public const int ClaimedItem = 6;
		}
	}
}
