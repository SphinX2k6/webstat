using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004E9B RID: 20123
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TowerDefenseRankItem : GridProxyAbstract<TowerDefenseRankItemData>
	{
		// Token: 0x06033FF5 RID: 212981 RVA: 0x00D01F01 File Offset: 0x00D00101
		public TowerDefenseRankItem(bool isShowInBottom)
		{
			this.IsShowInBottom = isShowInBottom;
		}

		// Token: 0x06033FF6 RID: 212982 RVA: 0x00D01F10 File Offset: 0x00D00110
		protected unsafe override void OnRegisterComponent()
		{
			this.ParentModel = (this.OpenParam as TowerDefenseRankViewModel);
			int num = 11;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033FF7 RID: 212983 RVA: 0x00D020B6 File Offset: 0x00D002B6
		protected override void OnStart()
		{
			this.InitOnlineNameLayout();
			this.InitRankGridLayout();
		}

		// Token: 0x06033FF8 RID: 212984 RVA: 0x00D020C4 File Offset: 0x00D002C4
		private void InitOnlineNameLayout()
		{
			this.OnlineNameLayout = new GenericLayout<OnlineItem, ITowerDefenseRankPlayerName>(base.GetLayoutBase(5), new Func<OnlineItem>(this.InitOnlineItem), base.GetItem(6).GetOwner() as AUIBaseActor, false, true);
		}

		// Token: 0x06033FF9 RID: 212985 RVA: 0x00D020F7 File Offset: 0x00D002F7
		private void InitRankGridLayout()
		{
			this.RankGridLayout = new GenericLayout<RankGridItem, TowerDefenseRankRoleData>(base.GetLayoutBase(8), new Func<RankGridItem>(this.InitRankGridItem), base.GetItem(9).GetOwner() as AUIBaseActor, false, true);
		}

		// Token: 0x06033FFA RID: 212986 RVA: 0x00D0212B File Offset: 0x00D0032B
		private OnlineItem InitOnlineItem()
		{
			return new OnlineItem(this.IsShowInBottom);
		}

		// Token: 0x06033FFB RID: 212987 RVA: 0x00D02138 File Offset: 0x00D00338
		private RankGridItem InitRankGridItem()
		{
			return new RankGridItem();
		}

		// Token: 0x06033FFC RID: 212988 RVA: 0x00D02140 File Offset: 0x00D00340
		private void RefreshEmpty()
		{
			base.GetText(1).SetUIActive(false);
			base.GetText(2).SetUIActive(false);
			base.GetItem(3).SetUIActive(true);
			UUIItem rootUiItem = this.OnlineNameLayout.GetRootUiItem();
			if (rootUiItem != null)
			{
				rootUiItem.SetUIActive(false);
			}
			string newText = ModelBase<PlayerInfoModel>.Instance.GetAccountName(true) ?? string.Empty;
			base.GetText(4).SetText(newText, true);
			base.GetText(4).SetUIActive(true);
			base.GetText(7).SetUIActive(false);
			UUIItem rootUiItem2 = this.RankGridLayout.GetRootUiItem();
			if (rootUiItem2 != null)
			{
				rootUiItem2.SetUIActive(false);
			}
			base.GetItem(10).SetUIActive(true);
			this.RefreshRankBg();
		}

		// Token: 0x06033FFD RID: 212989 RVA: 0x00D021F4 File Offset: 0x00D003F4
		private void RefreshRankBg()
		{
			bool flag = !this.IsShowInBottom || this.RankItemData.IsTopThree;
			base.GetTexture(0).SetUIActive(flag);
			if (flag)
			{
				string rankBg = this.RankItemData.RankBg;
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(rankBg);
				base.SetTextureByPath(resourcePath, base.GetTexture(0), null, null);
			}
		}

		// Token: 0x06033FFE RID: 212990 RVA: 0x00D02258 File Offset: 0x00D00458
		private void RefreshRankNum()
		{
			bool isTopThree = this.RankItemData.IsTopThree;
			UUIText text = base.GetText(1);
			UUIText text2 = base.GetText(2);
			text.SetUIActive(isTopThree);
			text2.SetUIActive(!isTopThree && this.RankItemData.IsInRank);
			base.GetItem(3).SetUIActive(!this.RankItemData.IsInRank);
			if (isTopThree)
			{
				text.SetText(this.RankItemData.Rank.ToString(), true);
				text.outlineColor = FColor.FromHex(this.RankItemData.TopThreeNumColor);
				return;
			}
			if (this.RankItemData.IsInRank)
			{
				text2.SetText(this.RankItemData.Rank.ToString(), true);
			}
		}

		// Token: 0x06033FFF RID: 212991 RVA: 0x00D02310 File Offset: 0x00D00510
		public UniTask RefreshPlayerName()
		{
			TowerDefenseRankItem.<RefreshPlayerName>d__16 <RefreshPlayerName>d__;
			<RefreshPlayerName>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshPlayerName>d__.<>4__this = this;
			<RefreshPlayerName>d__.<>1__state = -1;
			<RefreshPlayerName>d__.<>t__builder.Start<TowerDefenseRankItem.<RefreshPlayerName>d__16>(ref <RefreshPlayerName>d__);
			return <RefreshPlayerName>d__.<>t__builder.Task;
		}

		// Token: 0x06034000 RID: 212992 RVA: 0x00D02354 File Offset: 0x00D00554
		private void RefreshTimeScore()
		{
			base.GetText(7).SetUIActive(true);
			string newText = this.RankItemData.IsDifficult ? Singleton<TimeUtil>.Instance.GetTimeDataFormat((double)this.RankItemData.PassScore) : this.RankItemData.PassScore.ToString();
			base.GetText(7).SetText(newText, true);
		}

		// Token: 0x06034001 RID: 212993 RVA: 0x00D023B8 File Offset: 0x00D005B8
		private UniTask RefreshRankGrid()
		{
			TowerDefenseRankItem.<RefreshRankGrid>d__18 <RefreshRankGrid>d__;
			<RefreshRankGrid>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshRankGrid>d__.<>4__this = this;
			<RefreshRankGrid>d__.<>1__state = -1;
			<RefreshRankGrid>d__.<>t__builder.Start<TowerDefenseRankItem.<RefreshRankGrid>d__18>(ref <RefreshRankGrid>d__);
			return <RefreshRankGrid>d__.<>t__builder.Task;
		}

		// Token: 0x06034002 RID: 212994 RVA: 0x00D023FB File Offset: 0x00D005FB
		public override void Refresh(TowerDefenseRankItemData data, bool isSelected, int gridIndex)
		{
			this.RankItemData = data;
			if (data.IsEmpty)
			{
				this.RefreshEmpty();
				return;
			}
			this.RefreshRankBg();
			this.RefreshRankNum();
			this.RefreshPlayerName();
			this.RefreshTimeScore();
			this.RefreshRankGrid();
		}

		// Token: 0x06034003 RID: 212995 RVA: 0x00D02433 File Offset: 0x00D00633
		public bool IsSelfItem()
		{
			return this.RankItemData.IsSelfInData;
		}

		// Token: 0x0401E0D8 RID: 123096
		protected TowerDefenseRankViewModel ParentModel;

		// Token: 0x0401E0D9 RID: 123097
		private readonly bool IsShowInBottom;

		// Token: 0x0401E0DA RID: 123098
		private GenericLayout<OnlineItem, ITowerDefenseRankPlayerName> OnlineNameLayout;

		// Token: 0x0401E0DB RID: 123099
		private GenericLayout<RankGridItem, TowerDefenseRankRoleData> RankGridLayout;

		// Token: 0x0401E0DC RID: 123100
		private TowerDefenseRankItemData RankItemData;

		// Token: 0x0200AE42 RID: 44610
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x040361AD RID: 221613
			public const int RankBg = 0;

			// Token: 0x040361AE RID: 221614
			public const int RankTopThreeNum = 1;

			// Token: 0x040361AF RID: 221615
			public const int RankOtherNum = 2;

			// Token: 0x040361B0 RID: 221616
			public const int RankNoneItem = 3;

			// Token: 0x040361B1 RID: 221617
			public const int Name = 4;

			// Token: 0x040361B2 RID: 221618
			public const int OnlineNameLayout = 5;

			// Token: 0x040361B3 RID: 221619
			public const int OnlineNameItem = 6;

			// Token: 0x040361B4 RID: 221620
			public const int TimeScore = 7;

			// Token: 0x040361B5 RID: 221621
			public const int RankGridLayout = 8;

			// Token: 0x040361B6 RID: 221622
			public const int RankGridItem = 9;

			// Token: 0x040361B7 RID: 221623
			public const int RankGridEmptyItem = 10;
		}
	}
}
