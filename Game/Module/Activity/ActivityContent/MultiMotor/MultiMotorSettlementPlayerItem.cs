using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MultiMotor
{
	// Token: 0x02006664 RID: 26212
	public class MultiMotorSettlementPlayerItem : UiPanelBase
	{
		// Token: 0x0604174D RID: 268109 RVA: 0x010CCB58 File Offset: 0x010CAD58
		protected unsafe override void OnRegisterComponent()
		{
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickAddFriendBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0604174E RID: 268110 RVA: 0x010CCD2C File Offset: 0x010CAF2C
		[NullableContext(2)]
		public void RefreshItemByData(OnlineMotorSettleInfo data)
		{
			if (data == null)
			{
				this.ShowNoPlayerState();
				return;
			}
			if (ModelBase<OnlineModel>.Instance.GetCurrentTeamListById(data.PlayerId) == null)
			{
				this.ShowNoPlayerState();
				return;
			}
			this.ShowHavePlayerState();
			this.RefreshTag(data);
			this.RefreshRoleTexture(data.SkinId);
			this.RefreshTime(data.ConsumeTime, data.IsFinished);
			this.RefreshPlayerInfo(data.PlayerId);
			this.RefreshChampionInfo(data);
		}

		// Token: 0x0604174F RID: 268111 RVA: 0x010CCD9A File Offset: 0x010CAF9A
		protected virtual void ShowNoPlayerState()
		{
			UUIItem item = base.GetItem(10);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIItem item2 = base.GetItem(9);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
		}

		// Token: 0x06041750 RID: 268112 RVA: 0x010CCDC3 File Offset: 0x010CAFC3
		protected virtual void ShowHavePlayerState()
		{
			UUIItem item = base.GetItem(10);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(9);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(true);
		}

		// Token: 0x06041751 RID: 268113 RVA: 0x010CCDEC File Offset: 0x010CAFEC
		[NullableContext(1)]
		protected virtual void RefreshChampionInfo(OnlineMotorSettleInfo data)
		{
		}

		// Token: 0x06041752 RID: 268114 RVA: 0x010CCDF0 File Offset: 0x010CAFF0
		[NullableContext(1)]
		protected virtual void RefreshTag(OnlineMotorSettleInfo data)
		{
			base.GetText(1).SetUIActive(true);
			base.GetText(2).SetUIActive(true);
			int ranking = data.Ranking;
			LguiUtil instance = Singleton<LguiUtil>.Instance;
			UUIText text = base.GetText(1);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 1);
			defaultInterpolatedStringHandler.AppendLiteral("MultiMotor_Rank_");
			defaultInterpolatedStringHandler.AppendFormatted<int>(ranking);
			defaultInterpolatedStringHandler.AppendLiteral("_Tag");
			instance.SetLocalTextNew(text, defaultInterpolatedStringHandler.ToStringAndClear(), Array.Empty<object>());
			if (ranking == 1)
			{
				ChampionExtra championExtra = data.ChampionExtra;
				if (championExtra == null || !championExtra.AbsoluteRule)
				{
					ChampionExtra championExtra2 = data.ChampionExtra;
					if (championExtra2 == null || !championExtra2.Destroyer)
					{
						goto IL_CD;
					}
				}
				ChampionExtra championExtra3 = data.ChampionExtra;
				string textStringId = (championExtra3 != null && championExtra3.AbsoluteRule) ? "MultiMotor_Rank_1_AbsoluteRule_Tag" : "MultiMotor_Rank_1_Destroyer_Tag";
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), textStringId, Array.Empty<object>());
				return;
			}
			IL_CD:
			if (data.IsFinished)
			{
				LguiUtil instance2 = Singleton<LguiUtil>.Instance;
				UUIText text2 = base.GetText(2);
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 1);
				defaultInterpolatedStringHandler.AppendLiteral("MultiMotor_Rank_");
				defaultInterpolatedStringHandler.AppendFormatted<int>(ranking);
				defaultInterpolatedStringHandler.AppendLiteral("_Finish_Tag");
				instance2.SetLocalTextNew(text2, defaultInterpolatedStringHandler.ToStringAndClear(), Array.Empty<object>());
				return;
			}
			base.GetText(2).SetUIActive(false);
		}

		// Token: 0x06041753 RID: 268115 RVA: 0x010CCF28 File Offset: 0x010CB128
		protected virtual void RefreshRoleTexture(int skinId)
		{
			RoleSkin? roleSkinConfig = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(skinId);
			if (roleSkinConfig == null)
			{
				return;
			}
			base.SetTextureByPath(roleSkinConfig.Value.FormationRoleCard, base.GetTexture(0), null, null);
		}

		// Token: 0x06041754 RID: 268116 RVA: 0x010CCF74 File Offset: 0x010CB174
		protected virtual void RefreshTime(int time, bool isFinish)
		{
			if (time <= 0 || !isFinish)
			{
				base.GetItem(8).SetUIActive(true);
				base.GetText(3).SetUIActive(false);
				return;
			}
			base.GetItem(8).SetActive(false, false);
			base.GetText(3).SetUIActive(true);
			string remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat5((double)time * Singleton<TimeUtil>.Instance.Millisecond);
			UUIText text = base.GetText(3);
			if (text == null)
			{
				return;
			}
			text.SetText(remainTimeDataFormat, true);
		}

		// Token: 0x06041755 RID: 268117 RVA: 0x010CCFEC File Offset: 0x010CB1EC
		protected void RefreshPlayerInfo(int playerId)
		{
			OnlineTeamData currentTeamListById = ModelBase<OnlineModel>.Instance.GetCurrentTeamListById(playerId);
			if (currentTeamListById == null)
			{
				return;
			}
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			bool flag = id.GetValueOrDefault() == playerId & id != null;
			string inString;
			if (flag)
			{
				inString = "SP_Online{0}PIcon_Self";
			}
			else
			{
				inString = "SP_Online{0}PIcon";
			}
			string resourceId = StringUtils.Format(inString, new string[]
			{
				currentTeamListById.PlayerNumber.ToString()
			});
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			this.SetSpriteByPath(resourcePath, base.GetSprite(4), false, null, null);
			base.GetText(5).SetText(currentTeamListById.PlayerName, true);
			bool isFriend = ModelBase<FriendModel>.Instance.IsMyFriend(playerId);
			bool hasApplied = ModelBase<FriendModel>.Instance.CurrentApplyFriendListHasPlayer(playerId);
			this.RefreshIsFriend(flag, isFriend, hasApplied);
		}

		// Token: 0x06041756 RID: 268118 RVA: 0x010CD0BC File Offset: 0x010CB2BC
		protected void RefreshIsFriend(bool isSelf, bool isFriend, bool hasApplied)
		{
			bool flag = isSelf || isFriend;
			base.GetItem(7).SetUIActive(!flag && hasApplied);
			base.GetButton(6).RootUIComp.Get().SetUIActive(!flag && !hasApplied);
		}

		// Token: 0x06041757 RID: 268119 RVA: 0x010CD102 File Offset: 0x010CB302
		protected virtual void OnClickAddFriendBtn()
		{
			ControllerBase<FriendController>.Instance.RequestFriendApplyAddSend(this.PlayerId, FriendApplyWay.RecentlyTeam);
			this.RefreshIsFriend(false, false, true);
		}

		// Token: 0x04024996 RID: 149910
		public int PlayerId;

		// Token: 0x0200C68C RID: 50828
		protected class EPlayerComponents
		{
			// Token: 0x0403D222 RID: 250402
			public const int RoleTexture = 0;

			// Token: 0x0403D223 RID: 250403
			public const int TagText = 1;

			// Token: 0x0403D224 RID: 250404
			public const int Tag2Text = 2;

			// Token: 0x0403D225 RID: 250405
			public const int TimeText = 3;

			// Token: 0x0403D226 RID: 250406
			public const int OnlineNumberSprite = 4;

			// Token: 0x0403D227 RID: 250407
			public const int PlayerNameText = 5;

			// Token: 0x0403D228 RID: 250408
			public const int AddFriendBtn = 6;

			// Token: 0x0403D229 RID: 250409
			public const int HaveApplyItem = 7;

			// Token: 0x0403D22A RID: 250410
			public const int FailItem = 8;

			// Token: 0x0403D22B RID: 250411
			public const int HavePlayerItem = 9;

			// Token: 0x0403D22C RID: 250412
			public const int NoPlayerItem = 10;
		}
	}
}
