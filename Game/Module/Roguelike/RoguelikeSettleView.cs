using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200519E RID: 20894
	[NullableContext(2)]
	[Nullable(0)]
	public class RoguelikeSettleView : UiViewBase
	{
		// Token: 0x06035BC7 RID: 220103 RVA: 0x00D81C2F File Offset: 0x00D7FE2F
		[NullableContext(1)]
		public RoguelikeSettleView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06035BC8 RID: 220104 RVA: 0x00D81C4C File Offset: 0x00D7FE4C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 24;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(17, new Action(this.OnBtnBackClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035BC9 RID: 220105 RVA: 0x00D81FDC File Offset: 0x00D801DC
		protected override UniTask OnBeforeStartAsync()
		{
			RoguelikeSettleView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoguelikeSettleView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035BCA RID: 220106 RVA: 0x00D8201F File Offset: 0x00D8021F
		protected override void OnAfterShow()
		{
			if (this.FirstShowFlag)
			{
				this.FirstShowFlag = false;
				this.SkillPointRewardItem.StartAnim();
				this.OutSideRewardItem.StartAnim();
			}
		}

		// Token: 0x06035BCB RID: 220107 RVA: 0x00D82048 File Offset: 0x00D80248
		protected override void OnStart()
		{
			this.InitBaseInfo();
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RoguelikeArchiveSaved, new Action<int>(this.OnArchiveSaved));
		}

		// Token: 0x06035BCC RID: 220108 RVA: 0x00D8206C File Offset: 0x00D8026C
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.RoguelikeArchiveSaved, new Action<int>(this.OnArchiveSaved));
			this.RecordItemList.ForEach(delegate(RoguelikeSettleRecordItem item)
			{
				item.Destroy(null);
			});
			this.RecordItemList = new List<RoguelikeSettleRecordItem>();
		}

		// Token: 0x06035BCD RID: 220109 RVA: 0x00D820CC File Offset: 0x00D802CC
		private void InitBaseInfo()
		{
			RoguelikeResultInfo roguelikeResultInfo = (RoguelikeResultInfo)this.OpenParam;
			RoleDataBase roguelikeRoleData = ModelBase<RoguelikeModel>.Instance.GetRoguelikeRoleData(roguelikeResultInfo.RoleEntry.ConfigId);
			RoleInfo roleConfig = roguelikeRoleData.GetRoleConfig();
			RoguePokemon? roguePhantomConfig = ConfigBase<RoguelikeConfig>.Instance.GetRoguePhantomConfig(roguelikeResultInfo.PhantomEntry.ConfigId);
			string timeString = Singleton<TimeUtil>.Instance.GetTimeString((double)roguelikeResultInfo.TotalCostTime);
			base.GetText(21).SetText(timeString, true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), roleConfig.Name, Array.Empty<object>());
			string formationRoleCard = roleConfig.FormationRoleCard;
			int roleSkinId = roguelikeRoleData.GetRoleSkinId();
			if (roleSkinId != -1)
			{
				formationRoleCard = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(roleSkinId).Value.FormationRoleCard;
			}
			base.SetTextureByPath(formationRoleCard, base.GetTexture(1), null, null);
			if (roguePhantomConfig != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), roguePhantomConfig.Value.PokemonName, Array.Empty<object>());
				base.SetTextureByPath(roguePhantomConfig.Value.PokemonSettleIcon, base.GetTexture(3), null, null);
			}
			else
			{
				base.GetText(4).SetUIActive(false);
				base.GetTexture(3).SetUIActive(false);
			}
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(roguelikeResultInfo.InstId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), config.Value.MapName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), (config.Value.DifficultyDescLength > 0) ? config.Value.DifficultyDesc(0) : "", Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), "RoguelikeSettlePlayerName", new <>z__ReadOnlySingleElementList<object>(ModelBase<FunctionModel>.Instance.GetPlayerName()));
			string newText = Singleton<TimeUtil>.Instance.DateFormatString(roguelikeResultInfo.Time);
			base.GetText(9).SetText(newText, true);
			int num = (int)Math.Floor((double)roguelikeResultInfo.CurLayer / (double)roguelikeResultInfo.MaxLayer * 100.0);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(13), "RoguelikeSettleProgress", new <>z__ReadOnlySingleElementList<object>(num));
			RogueParam? paramConfigBySeasonId = ModelBase<RoguelikeModel>.Instance.GetParamConfigBySeasonId(null);
			UUIItem item = base.GetItem(0);
			UUITexture texture = base.GetTexture(19);
			if (num >= paramConfigBySeasonId.Value.RoguelikeSettleS)
			{
				item.SetUIActive(true);
				base.SetTextureByPath(paramConfigBySeasonId.Value.RoguelikeSettleBgS, texture, null, null);
			}
			else if (num >= paramConfigBySeasonId.Value.RoguelikeSettleA)
			{
				item.SetUIActive(false);
				base.SetTextureByPath(paramConfigBySeasonId.Value.RoguelikeSettleBgNormal, texture, null, null);
			}
			else if (num >= paramConfigBySeasonId.Value.RoguelikeSettleB)
			{
				item.SetUIActive(false);
				base.SetTextureByPath(paramConfigBySeasonId.Value.RoguelikeSettleBgNormal, texture, null, null);
			}
			else
			{
				item.SetUIActive(false);
				base.SetTextureByPath(paramConfigBySeasonId.Value.RoguelikeSettleBgNormal, texture, null, null);
			}
			UUITexture texture2 = base.GetTexture(5);
			int selectHotEntryGroupId = roguelikeResultInfo.SelectHotEntryGroupId;
			RogueHotEntryGroup? rogueHotEntryGroupConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueHotEntryGroupConfig(selectHotEntryGroupId);
			if (rogueHotEntryGroupConfig != null)
			{
				base.SetTextureByPath(rogueHotEntryGroupConfig.Value.SettleIcon, texture2, null, null);
				base.GetText(6).SetColor(FColor.FromHex(rogueHotEntryGroupConfig.Value.SettleTextColor));
				base.GetText(22).SetColor(FColor.FromHex(rogueHotEntryGroupConfig.Value.SettleTextColor));
				base.GetText(14).SetText(((float)rogueHotEntryGroupConfig.Value.Rate / 100f).ToString() + "%", true);
				int settleAudioState = rogueHotEntryGroupConfig.Value.SettleAudioState;
				if (settleAudioState == 1)
				{
					Singleton<AudioSystem>.Instance.SetState("ui_rogue_settle", "settle_s", true);
				}
				else if (settleAudioState == 2)
				{
					Singleton<AudioSystem>.Instance.SetState("ui_rogue_settle", "settle_a", true);
				}
				else if (settleAudioState == 3)
				{
					Singleton<AudioSystem>.Instance.SetState("ui_rogue_settle", "settle_b", true);
				}
				else if (settleAudioState == 4)
				{
					Singleton<AudioSystem>.Instance.SetState("ui_rogue_settle", "settle_c", true);
				}
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(22), "RogueEnd_Progress", new <>z__ReadOnlyArray<object>(new object[]
			{
				roguelikeResultInfo.CurLayer,
				roguelikeResultInfo.MaxLayer
			}));
			UUIItem uuiitem = Singleton<LguiUtil>.Instance.CopyItem(base.GetItem(12), base.GetItem(11));
			UUIItem uuiitem2 = Singleton<LguiUtil>.Instance.CopyItem(base.GetItem(12), base.GetItem(11));
			int count = 0;
			int count2 = 0;
			int num2 = 0;
			RogueParam? paramConfigBySeasonId2 = ModelBase<RoguelikeModel>.Instance.GetParamConfigBySeasonId(null);
			foreach (int num3 in roguelikeResultInfo.Rewards.Keys)
			{
				if (num3 == paramConfigBySeasonId2.Value.SkillPoint)
				{
					count = roguelikeResultInfo.Rewards[num3];
				}
				else if (num3 == paramConfigBySeasonId2.Value.TokenItem)
				{
					count2 = roguelikeResultInfo.Rewards[num3];
				}
				else if (num3 == paramConfigBySeasonId2.Value.InsideCurrency)
				{
					num2 = roguelikeResultInfo.Rewards[num3];
				}
			}
			RoguelikeSettleRecordItem roguelikeSettleRecordItem = new RoguelikeSettleRecordItem(ERoguelikeSettleItemType.KillCount, roguelikeResultInfo.KillEnemyCount);
			roguelikeSettleRecordItem.CreateThenShowByActorAsync(base.GetItem(12).GetOwner(), null, false);
			RoguelikeSettleRecordItem roguelikeSettleRecordItem2 = new RoguelikeSettleRecordItem(ERoguelikeSettleItemType.TokenCount, roguelikeResultInfo.GetGainCount);
			roguelikeSettleRecordItem2.CreateThenShowByActorAsync(uuiitem.GetOwner(), null, false);
			RoguelikeSettleRecordItem roguelikeSettleRecordItem3 = new RoguelikeSettleRecordItem(ERoguelikeSettleItemType.MoneyCount, num2);
			roguelikeSettleRecordItem3.CreateThenShowByActorAsync(uuiitem2.GetOwner(), null, false);
			this.RecordItemList = new List<RoguelikeSettleRecordItem>
			{
				roguelikeSettleRecordItem,
				roguelikeSettleRecordItem2,
				roguelikeSettleRecordItem3
			};
			this.SkillPointRewardItem.Refresh(paramConfigBySeasonId2.Value.SkillPoint, count, roguelikeResultInfo.Rate);
			this.OutSideRewardItem.Refresh(paramConfigBySeasonId2.Value.TokenItem, count2, roguelikeResultInfo.Rate);
			RogueArchiveState rogueArchiveState = roguelikeResultInfo.RogueArchiveState;
			bool flag = rogueArchiveState > RogueArchiveState.CantSave;
			ButtonItem btnAchieveItem = this.BtnAchieveItem;
			if (btnAchieveItem != null)
			{
				btnAchieveItem.SetUiActive(flag);
			}
			if (flag)
			{
				if (rogueArchiveState == RogueArchiveState.Saved)
				{
					ButtonItem btnAchieveItem2 = this.BtnAchieveItem;
					if (btnAchieveItem2 != null)
					{
						btnAchieveItem2.SetLocalTextNew("Rogue_NormalResult_Saved", Array.Empty<object>());
					}
					ButtonItem btnAchieveItem3 = this.BtnAchieveItem;
					if (btnAchieveItem3 == null)
					{
						return;
					}
					btnAchieveItem3.SetEnableClick(false);
					return;
				}
				else
				{
					ButtonItem btnAchieveItem4 = this.BtnAchieveItem;
					if (btnAchieveItem4 != null)
					{
						btnAchieveItem4.SetLocalTextNew("Rogue_NormalResult_CanSave", Array.Empty<object>());
					}
					ButtonItem btnAchieveItem5 = this.BtnAchieveItem;
					if (btnAchieveItem5 == null)
					{
						return;
					}
					btnAchieveItem5.SetEnableClick(true);
				}
			}
		}

		// Token: 0x06035BCE RID: 220110 RVA: 0x00D82814 File Offset: 0x00D80A14
		private void OnBtnAchieveClick(int _)
		{
			RoguelikeResultInfo roguelikeResultInfo = (RoguelikeResultInfo)this.OpenParam;
			if (roguelikeResultInfo.RogueArchiveState == RogueArchiveState.CanSave)
			{
				this.OpenAchieveViewAsync(roguelikeResultInfo.RogueArchiveInfo);
			}
		}

		// Token: 0x06035BCF RID: 220111 RVA: 0x00D82842 File Offset: 0x00D80A42
		private void OnArchiveSaved(int slotId)
		{
			((RoguelikeResultInfo)this.OpenParam).RogueArchiveState = RogueArchiveState.Saved;
			ButtonItem btnAchieveItem = this.BtnAchieveItem;
			if (btnAchieveItem != null)
			{
				btnAchieveItem.SetLocalTextNew("Rogue_NormalResult_Saved", Array.Empty<object>());
			}
			ButtonItem btnAchieveItem2 = this.BtnAchieveItem;
			if (btnAchieveItem2 == null)
			{
				return;
			}
			btnAchieveItem2.SetEnableClick(false);
		}

		// Token: 0x06035BD0 RID: 220112 RVA: 0x00D82884 File Offset: 0x00D80A84
		private void OnBtnBackClick()
		{
			RoguelikeResultInfo settleData = (RoguelikeResultInfo)this.OpenParam;
			RogueArchiveState rogueArchiveState = settleData.RogueArchiveState;
			Action<bool> <>9__3;
			Action<bool> exit = delegate(bool fireEvent)
			{
				if (ModelBase<RoguelikeModel>.Instance.CheckInRoguelike())
				{
					UniTask<bool> task = ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon();
					Action<bool> continuationFunction;
					if ((continuationFunction = <>9__3) == null)
					{
						continuationFunction = (<>9__3 = delegate(bool _)
						{
							if (Singleton<UiManager>.Instance.IsViewShow(this.ViewInfo.Name))
							{
								this.CloseMe(null);
							}
						});
					}
					task.ContinueWith(continuationFunction);
					return;
				}
				this.CloseMe(null);
			};
			Action value = delegate()
			{
				ControllerBase<RoguelikeController>.Instance.RoguelikeAchieveGiveUpRequest(exit);
			};
			Action value2 = delegate()
			{
				this.OpenAchieveViewAsync(settleData.RogueArchiveInfo);
			};
			if (rogueArchiveState == RogueArchiveState.CanSave)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RoguelikeGiveUpArchiveConfirm);
				confirmBoxDataNew.FunctionMap[1] = value;
				confirmBoxDataNew.FunctionMap[2] = value2;
				confirmBoxDataNew.IsEscViewTriggerCallBack = false;
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			exit(true);
		}

		// Token: 0x06035BD1 RID: 220113 RVA: 0x00D82938 File Offset: 0x00D80B38
		private void OpenAchieveViewAsync(RogueArchiveInfo achieveData)
		{
			RoguelikeSettleView.<>c__DisplayClass16_0 CS$<>8__locals1 = new RoguelikeSettleView.<>c__DisplayClass16_0();
			CS$<>8__locals1.achieveData = achieveData;
			new UiAsyncTask("RoguelikeSettleView.OpenRoguelikeAchieveView", delegate()
			{
				RoguelikeSettleView.<>c__DisplayClass16_0.<<OpenAchieveViewAsync>b__0>d <<OpenAchieveViewAsync>b__0>d;
				<<OpenAchieveViewAsync>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<OpenAchieveViewAsync>b__0>d.<>4__this = CS$<>8__locals1;
				<<OpenAchieveViewAsync>b__0>d.<>1__state = -1;
				<<OpenAchieveViewAsync>b__0>d.<>t__builder.Start<RoguelikeSettleView.<>c__DisplayClass16_0.<<OpenAchieveViewAsync>b__0>d>(ref <<OpenAchieveViewAsync>b__0>d);
				return <<OpenAchieveViewAsync>b__0>d.<>t__builder.Task;
			}, null).Run().Forget();
		}

		// Token: 0x0401ED6A RID: 126314
		[Nullable(1)]
		public List<RoguelikeSettleRecordItem> RecordItemList = new List<RoguelikeSettleRecordItem>();

		// Token: 0x0401ED6B RID: 126315
		public RoguelikeSettleCurrencyItem SkillPointRewardItem;

		// Token: 0x0401ED6C RID: 126316
		public RoguelikeSettleCurrencyItem OutSideRewardItem;

		// Token: 0x0401ED6D RID: 126317
		private ButtonItem BtnAchieveItem;

		// Token: 0x0401ED6E RID: 126318
		private bool FirstShowFlag = true;

		// Token: 0x0200B169 RID: 45417
		[NullableContext(0)]
		public static class ERoguelikeSettleViewDefine
		{
			// Token: 0x0403703E RID: 225342
			public const int QualityPanel = 0;

			// Token: 0x0403703F RID: 225343
			public const int RoleSprite = 1;

			// Token: 0x04037040 RID: 225344
			public const int TxtRoleName = 2;

			// Token: 0x04037041 RID: 225345
			public const int PhantomSprite = 3;

			// Token: 0x04037042 RID: 225346
			public const int TxtPhantomName = 4;

			// Token: 0x04037043 RID: 225347
			public const int ResultTex = 5;

			// Token: 0x04037044 RID: 225348
			public const int ResultTxt = 6;

			// Token: 0x04037045 RID: 225349
			public const int TxtTitle = 7;

			// Token: 0x04037046 RID: 225350
			public const int TxtDifficulty = 8;

			// Token: 0x04037047 RID: 225351
			public const int TxtTime = 9;

			// Token: 0x04037048 RID: 225352
			public const int TxtPlayer = 10;

			// Token: 0x04037049 RID: 225353
			public const int RecordPanel = 11;

			// Token: 0x0403704A RID: 225354
			public const int RecordItem = 12;

			// Token: 0x0403704B RID: 225355
			public const int TxtProgress = 13;

			// Token: 0x0403704C RID: 225356
			public const int TxtRate = 14;

			// Token: 0x0403704D RID: 225357
			public const int RewardPanel = 15;

			// Token: 0x0403704E RID: 225358
			public const int RewardItem = 16;

			// Token: 0x0403704F RID: 225359
			public const int BtnBack = 17;

			// Token: 0x04037050 RID: 225360
			public const int RewardItem2 = 18;

			// Token: 0x04037051 RID: 225361
			public const int TextureQualityBg = 19;

			// Token: 0x04037052 RID: 225362
			public const int TxtPassTitle = 20;

			// Token: 0x04037053 RID: 225363
			public const int TxtPassTime = 21;

			// Token: 0x04037054 RID: 225364
			public const int TxtLevelProgress = 22;

			// Token: 0x04037055 RID: 225365
			public const int BtnAchieve = 23;
		}
	}
}
