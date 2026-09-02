using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EA9 RID: 20137
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TowerDefenseRankItemV2 : GridProxyAbstract<TowerDefenseRankItemData>
	{
		// Token: 0x0603406A RID: 213098 RVA: 0x00D03D4C File Offset: 0x00D01F4C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 12;
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
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(11, new Action(this.OnReviewClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603406B RID: 213099 RVA: 0x00D03F44 File Offset: 0x00D02144
		protected override void OnStart()
		{
			this.OnlineNameLayout = new GenericLayout<TowerDefenseRankOnlineItem, ITowerDefenseRankPlayerName>(base.GetLayoutBase(5), new Func<TowerDefenseRankOnlineItem>(this.InitOnlineItem), base.GetItem(6).GetOwner() as AUIBaseActor, false, true);
			this.FormationLayout = new GenericLayout<TowerDefenseRankFormationItemV2, TowerDefenseRankRoleData>(base.GetLayoutBase(8), new Func<TowerDefenseRankFormationItemV2>(this.InitFormationItem), base.GetItem(9).GetOwner() as AUIBaseActor, false, true);
		}

		// Token: 0x0603406C RID: 213100 RVA: 0x00D03FB4 File Offset: 0x00D021B4
		private TowerDefenseRankOnlineItem InitOnlineItem()
		{
			return new TowerDefenseRankOnlineItem();
		}

		// Token: 0x0603406D RID: 213101 RVA: 0x00D03FBB File Offset: 0x00D021BB
		private TowerDefenseRankFormationItemV2 InitFormationItem()
		{
			return new TowerDefenseRankFormationItemV2();
		}

		// Token: 0x0603406E RID: 213102 RVA: 0x00D03FC4 File Offset: 0x00D021C4
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
			UUIText text = base.GetText(4);
			text.SetText(newText, true);
			text.SetUIActive(true);
			base.GetText(7).SetUIActive(false);
			UUIItem rootUiItem2 = this.FormationLayout.GetRootUiItem();
			if (rootUiItem2 != null)
			{
				rootUiItem2.SetUIActive(false);
			}
			UUIText text2 = base.GetText(10);
			if (text2 != null)
			{
				text2.SetUIActive(true);
			}
			UUIButtonComponent button = base.GetButton(11);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(false);
			}
			this.RefreshRankBg();
		}

		// Token: 0x0603406F RID: 213103 RVA: 0x00D04098 File Offset: 0x00D02298
		protected virtual void RefreshRankBg()
		{
			UUITexture texture = base.GetTexture(0);
			if (!this.RankItemData.IsTopThree)
			{
				texture.SetUIActive(false);
				return;
			}
			texture.SetUIActive(true);
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(this.RankItemData.RankBg);
			base.SetTextureByPath(resourcePath, texture, null, null);
		}

		// Token: 0x06034070 RID: 213104 RVA: 0x00D040F4 File Offset: 0x00D022F4
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

		// Token: 0x06034071 RID: 213105 RVA: 0x00D041AC File Offset: 0x00D023AC
		public UniTask RefreshPlayerName()
		{
			TowerDefenseRankItemV2.<RefreshPlayerName>d__10 <RefreshPlayerName>d__;
			<RefreshPlayerName>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshPlayerName>d__.<>4__this = this;
			<RefreshPlayerName>d__.<>1__state = -1;
			<RefreshPlayerName>d__.<>t__builder.Start<TowerDefenseRankItemV2.<RefreshPlayerName>d__10>(ref <RefreshPlayerName>d__);
			return <RefreshPlayerName>d__.<>t__builder.Task;
		}

		// Token: 0x06034072 RID: 213106 RVA: 0x00D041F0 File Offset: 0x00D023F0
		private void RefreshTimeScore()
		{
			UUIText text = base.GetText(7);
			text.SetUIActive(true);
			string timeDataFormat = Singleton<TimeUtil>.Instance.GetTimeDataFormat((double)this.RankItemData.PassTime);
			text.SetText(timeDataFormat, true);
		}

		// Token: 0x06034073 RID: 213107 RVA: 0x00D0422C File Offset: 0x00D0242C
		private UniTask RefreshFormation()
		{
			TowerDefenseRankItemV2.<RefreshFormation>d__12 <RefreshFormation>d__;
			<RefreshFormation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshFormation>d__.<>4__this = this;
			<RefreshFormation>d__.<>1__state = -1;
			<RefreshFormation>d__.<>t__builder.Start<TowerDefenseRankItemV2.<RefreshFormation>d__12>(ref <RefreshFormation>d__);
			return <RefreshFormation>d__.<>t__builder.Task;
		}

		// Token: 0x06034074 RID: 213108 RVA: 0x00D0426F File Offset: 0x00D0246F
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
			this.RefreshFormation();
			this.RefreshReviewButton();
		}

		// Token: 0x06034075 RID: 213109 RVA: 0x00D042B0 File Offset: 0x00D024B0
		protected virtual void RefreshReviewButton()
		{
			UUIButtonComponent button = base.GetButton(11);
			if (button == null)
			{
				return;
			}
			button.RootUIComp.Get().SetUIActive(this.RankItemData.IsOnline);
		}

		// Token: 0x06034076 RID: 213110 RVA: 0x00D042E8 File Offset: 0x00D024E8
		private void OnReviewClick()
		{
			List<ISolarSpeedRolePanelData> list = new List<ISolarSpeedRolePanelData>();
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			RepeatedField<TowerDefencePassPlayerInfo> playerPassInfo = this.RankItemData.ServerData.PlayerPassInfo;
			int i = 0;
			int count = playerPassInfo.Count;
			while (i < count)
			{
				TowerDefencePassPlayerInfo towerDefencePassPlayerInfo = playerPassInfo[i];
				int playerId = towerDefencePassPlayerInfo.PlayerId;
				int num = playerId;
				int? num2 = id;
				bool flag = num == num2.GetValueOrDefault() & num2 != null;
				foreach (TowerDefenceRolePassInfo towerDefenceRolePassInfo in towerDefencePassPlayerInfo.RoleList)
				{
					List<ITowerDefenseRoleDescData> list2 = new List<ITowerDefenseRoleDescData>();
					foreach (TowerDefenceBattleScoreInfo towerDefenceBattleScoreInfo in towerDefenceRolePassInfo.ScoreList)
					{
						list2.Add(new TowerDefenseRoleDescData
						{
							Title = towerDefenceBattleScoreInfo.Id,
							Count = towerDefenceBattleScoreInfo.Score
						});
					}
					TowerDefenseRolePanelData item = new TowerDefenseRolePanelData
					{
						Rank = 0,
						PlayerId = playerId,
						IsAddButtonAvailable = (!flag && !ModelBase<FriendModel>.Instance.IsMyFriend(playerId)),
						IsSelf = flag,
						BgPath = SolarSpeedDefine.rankBgPathMap[0],
						MedalColorHex = SolarSpeedDefine.medalColorHex[0],
						FxColorHex = SolarSpeedDefine.fxColorHex[0],
						PlayerIndexIconPath = (flag ? SolarSpeedDefine.playerIndexSelfIconMap[i] : SolarSpeedDefine.playerIndexIconMap[i]),
						NameText = towerDefencePassPlayerInfo.Name,
						IconData = new SolarSpeedRoleIconPanelData
						{
							IconPath = ModelBase<PersonalModel>.Instance.GetPlayerHeadData(towerDefencePassPlayerInfo.HeadId, false).GetRoleHeadIconCircle()
						},
						BestTitle = towerDefenceRolePassInfo.Title,
						DescDataList = list2
					};
					list.Add(item);
				}
				i++;
			}
			SolarSpeedResultViewData solarSpeedResultViewData = new SolarSpeedResultViewData();
			solarSpeedResultViewData.TitleId = "TowerDefenceSettlement01";
			solarSpeedResultViewData.RoleDataList = list;
			solarSpeedResultViewData.PanelType = (() => new TowerDefenseRolePanel());
			solarSpeedResultViewData.ConfirmClick = delegate()
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.SolarSpeedResultView, null);
			};
			SolarSpeedResultViewData param = solarSpeedResultViewData;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SolarSpeedResultView, param, null);
		}

		// Token: 0x06034077 RID: 213111 RVA: 0x00D04580 File Offset: 0x00D02780
		public bool IsSelfItem()
		{
			return this.RankItemData.IsSelfInData;
		}

		// Token: 0x0401E110 RID: 123152
		private GenericLayout<TowerDefenseRankOnlineItem, ITowerDefenseRankPlayerName> OnlineNameLayout;

		// Token: 0x0401E111 RID: 123153
		private GenericLayout<TowerDefenseRankFormationItemV2, TowerDefenseRankRoleData> FormationLayout;

		// Token: 0x0401E112 RID: 123154
		protected TowerDefenseRankItemData RankItemData;

		// Token: 0x0200AE5C RID: 44636
		[NullableContext(0)]
		protected class ERankItemComponent
		{
			// Token: 0x0403621A RID: 221722
			public const int RankBgTex = 0;

			// Token: 0x0403621B RID: 221723
			public const int TopThreeRankTxt = 1;

			// Token: 0x0403621C RID: 221724
			public const int OtherRankTxt = 2;

			// Token: 0x0403621D RID: 221725
			public const int EmptyItem = 3;

			// Token: 0x0403621E RID: 221726
			public const int NameTxt = 4;

			// Token: 0x0403621F RID: 221727
			public const int OnlineLayout = 5;

			// Token: 0x04036220 RID: 221728
			public const int OnlineItem = 6;

			// Token: 0x04036221 RID: 221729
			public const int TimeTxt = 7;

			// Token: 0x04036222 RID: 221730
			public const int FormationLayout = 8;

			// Token: 0x04036223 RID: 221731
			public const int FormationItem = 9;

			// Token: 0x04036224 RID: 221732
			public const int EmptyTxt = 10;

			// Token: 0x04036225 RID: 221733
			public const int ReviewButton = 11;
		}
	}
}
