using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace ActivityNamespace.MapTravel.MapTravelSubViewQuest
{
	// Token: 0x020043CF RID: 17359
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class AreaLayout : GridProxyAbstract<MapTravelAreaData>
	{
		// Token: 0x0602E245 RID: 188997 RVA: 0x00AD991C File Offset: 0x00AD7B1C
		public AreaLayout(ActivityMapTravelData activityBaseData)
		{
			this.ActivityBaseData = activityBaseData;
		}

		// Token: 0x0602E246 RID: 188998 RVA: 0x00AD992C File Offset: 0x00AD7B2C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIMultiTemplateLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0602E247 RID: 188999 RVA: 0x00AD99D7 File Offset: 0x00AD7BD7
		protected override void OnStart()
		{
			this.QuestLayout = new GenericLayout<QuestCardItem, int>(base.GetMultiTemplateLayout(1), new Func<QuestCardItem>(this.InitItem), null, false, true);
		}

		// Token: 0x0602E248 RID: 189000 RVA: 0x00AD99FA File Offset: 0x00AD7BFA
		private QuestCardItem InitItem()
		{
			return new QuestCardItem(this.ActivityBaseData);
		}

		// Token: 0x0602E249 RID: 189001 RVA: 0x00AD9A07 File Offset: 0x00AD7C07
		[NullableContext(2)]
		public UUIItem GetTitleItem()
		{
			return base.GetText(0);
		}

		// Token: 0x0602E24A RID: 189002 RVA: 0x00AD9A10 File Offset: 0x00AD7C10
		public override void Refresh(MapTravelAreaData data, bool isSelected, int gridIndex)
		{
			Area? areaInfo = ConfigBase<AreaConfig>.Instance.GetAreaInfo(data.AreaId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), areaInfo.Value.Title, Array.Empty<object>());
			int num = 0;
			int num2 = 0;
			List<int> list = data.PhantomTaskIdSet.ToList<int>();
			list.Sort(this.ActivityBaseData.SortPhantomQuestItem);
			foreach (int id in list)
			{
				TravelPhantomQuest? questConfig = ConfigBase<ActivityMapTravelConfig>.Instance.GetQuestConfig(id);
				int questState = (int)ModelBase<QuestNewModel>.Instance.GetQuestState(questConfig.Value.QuestId);
				int count = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(questConfig.Value.QuestReward)[0].Count;
				if (questState == 3)
				{
					num += count;
				}
				num2 += count;
			}
			this.QuestLayout.RefreshByData(list.ToList<int>(), null, true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "TravelPhantomQuest_Progress", new <>z__ReadOnlyArray<object>(new object[]
			{
				num,
				num2
			}));
		}

		// Token: 0x17007F0D RID: 32525
		// (get) Token: 0x0602E24B RID: 189003 RVA: 0x00AD9B54 File Offset: 0x00AD7D54
		// (set) Token: 0x0602E24C RID: 189004 RVA: 0x00AD9B5C File Offset: 0x00AD7D5C
		protected ActivityMapTravelData ActivityBaseData { get; set; }

		// Token: 0x0401A192 RID: 106898
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected GenericLayout<QuestCardItem, int> QuestLayout;

		// Token: 0x0200A649 RID: 42569
		[NullableContext(0)]
		private class ELayoutDefine
		{
			// Token: 0x040336AB RID: 210603
			public const int Title = 0;

			// Token: 0x040336AC RID: 210604
			public const int Layout = 1;

			// Token: 0x040336AD RID: 210605
			public const int CardItem = 2;

			// Token: 0x040336AE RID: 210606
			public const int TxtCount = 3;
		}
	}
}
