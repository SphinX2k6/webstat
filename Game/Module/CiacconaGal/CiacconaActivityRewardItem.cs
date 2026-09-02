using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EDB RID: 24283
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CiacconaActivityRewardItem : GridProxyAbstract<CiacconaGalRewardData>
	{
		// Token: 0x0603D041 RID: 249921 RVA: 0x00F7F578 File Offset: 0x00F7D778
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIScrollViewWithScrollbarComponent));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D042 RID: 249922 RVA: 0x00F7F688 File Offset: 0x00F7D888
		protected override UniTask OnBeforeStartAsync()
		{
			CiacconaActivityRewardItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CiacconaActivityRewardItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D043 RID: 249923 RVA: 0x00F7F6CB File Offset: 0x00F7D8CB
		protected override void OnStart()
		{
			this.ScrollView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(6), new Func<CommonItemSmallItemGrid>(this.CreateItem), null, false, null);
		}

		// Token: 0x0603D044 RID: 249924 RVA: 0x00F7F6F0 File Offset: 0x00F7D8F0
		[NullableContext(1)]
		public override void Refresh(CiacconaGalRewardData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), data.Title, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), data.Desc, Array.Empty<object>());
			this.BtnB.SetActive(data.CanReceive && !data.IsReceived);
			this.BtnB.SetRedDotVisible(data.CanReceive && !data.IsReceived);
			this.BtnE.SetActive(false);
			base.GetText(2).SetUIActive(!data.CanReceive);
			base.GetItem(3).SetUIActive(data.IsReceived);
			this.ScrollView.RefreshByData(data.RewardItemDataList.ToList<TItem>(), null, false);
		}

		// Token: 0x0603D045 RID: 249925 RVA: 0x00F7F7C5 File Offset: 0x00F7D9C5
		[NullableContext(1)]
		private CommonItemSmallItemGrid CreateItem()
		{
			return new CommonItemSmallItemGrid();
		}

		// Token: 0x0603D046 RID: 249926 RVA: 0x00F7F7CC File Offset: 0x00F7D9CC
		private void OnReceive(int _)
		{
			int id = ModelBase<CiacconaGalModel>.Instance.ActivityData.Id;
			ControllerBase<CiacconaGalController>.Instance.RequestGetActivityProgressReward(id, this.Data.Id);
		}

		// Token: 0x040223D7 RID: 140247
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> ScrollView;

		// Token: 0x040223D8 RID: 140248
		private ButtonItem BtnE;

		// Token: 0x040223D9 RID: 140249
		private ButtonItem BtnB;

		// Token: 0x040223DA RID: 140250
		private CiacconaGalRewardData Data;

		// Token: 0x0200BEDA RID: 48858
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403ABD4 RID: 240596
			public const int BtnE = 0;

			// Token: 0x0403ABD5 RID: 240597
			public const int BtnB = 1;

			// Token: 0x0403ABD6 RID: 240598
			public const int TextUnfinished = 2;

			// Token: 0x0403ABD7 RID: 240599
			public const int ItemFinished = 3;

			// Token: 0x0403ABD8 RID: 240600
			public const int TextTitle = 4;

			// Token: 0x0403ABD9 RID: 240601
			public const int TextDesc = 5;

			// Token: 0x0403ABDA RID: 240602
			public const int ScrollView = 6;
		}
	}
}
