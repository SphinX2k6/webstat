using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E30 RID: 20016
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseLevelRewardPanel : UiPanelBase
	{
		// Token: 0x06033BE4 RID: 211940 RVA: 0x00CEF608 File Offset: 0x00CED808
		public UniTask Init(UUIItem item)
		{
			TrapDefenseLevelRewardPanel.<Init>d__3 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.item = item;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<TrapDefenseLevelRewardPanel.<Init>d__3>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06033BE5 RID: 211941 RVA: 0x00CEF653 File Offset: 0x00CED853
		protected override void OnBeforeCreate()
		{
		}

		// Token: 0x06033BE6 RID: 211942 RVA: 0x00CEF658 File Offset: 0x00CED858
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033BE7 RID: 211943 RVA: 0x00CEF6E4 File Offset: 0x00CED8E4
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseLevelRewardPanel.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseLevelRewardPanel.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033BE8 RID: 211944 RVA: 0x00CEF727 File Offset: 0x00CED927
		protected override void OnStart()
		{
		}

		// Token: 0x06033BE9 RID: 211945 RVA: 0x00CEF729 File Offset: 0x00CED929
		protected override void OnBeforeShow()
		{
		}

		// Token: 0x06033BEA RID: 211946 RVA: 0x00CEF72B File Offset: 0x00CED92B
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x06033BEB RID: 211947 RVA: 0x00CEF730 File Offset: 0x00CED930
		public void UpdateData(TrapDefenseLevelData data)
		{
			this.LevelData = data;
			List<ITrapDefenseLevelRewardItemData> rewardShowList = data.GetRewardShowList();
			this.LayoutReward.RefreshByData(rewardShowList, null, false);
			this.SetActive(rewardShowList.Count > 0);
		}

		// Token: 0x06033BEC RID: 211948 RVA: 0x00CEF768 File Offset: 0x00CED968
		public TrapDefenseLevelRewardItem CreateItemReward()
		{
			return new TrapDefenseLevelRewardItem();
		}

		// Token: 0x0401DF39 RID: 122681
		public TrapDefenseLevelData LevelData;

		// Token: 0x0401DF3A RID: 122682
		public GenericLayout<TrapDefenseLevelRewardItem, ITrapDefenseLevelRewardItemData> LayoutReward;

		// Token: 0x0200ADB1 RID: 44465
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04035F07 RID: 220935
			public const int TextTitle = 0;

			// Token: 0x04035F08 RID: 220936
			public const int LayoutReward = 1;

			// Token: 0x04035F09 RID: 220937
			public const int ItemReward = 2;
		}
	}
}
