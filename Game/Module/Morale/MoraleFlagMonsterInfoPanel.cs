using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.Controller;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Morale.Data;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x02005714 RID: 22292
	[NullableContext(1)]
	[Nullable(0)]
	public class MoraleFlagMonsterInfoPanel : UiPanelBase
	{
		// Token: 0x06038BD8 RID: 232408 RVA: 0x00E5E048 File Offset: 0x00E5C248
		public UniTask Init(UUIItem item)
		{
			MoraleFlagMonsterInfoPanel.<Init>d__6 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.item = item;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<MoraleFlagMonsterInfoPanel.<Init>d__6>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06038BD9 RID: 232409 RVA: 0x00E5E094 File Offset: 0x00E5C294
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIArtText)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIText)),
				new ValueTuple<int, Type>(11, typeof(UUIText)),
				new ValueTuple<int, Type>(12, typeof(UUITexture))
			};
		}

		// Token: 0x06038BDA RID: 232410 RVA: 0x00E5E1D0 File Offset: 0x00E5C3D0
		protected override UniTask OnBeforeStartAsync()
		{
			MoraleFlagMonsterInfoPanel.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MoraleFlagMonsterInfoPanel.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038BDB RID: 232411 RVA: 0x00E5E214 File Offset: 0x00E5C414
		public void OnBtnTrack()
		{
			int markId = this.FlagData.Config.MarkId;
			if (markId <= 0)
			{
				return;
			}
			if (ConfigBase<MoraleConfig>.Instance.GetMoraleMarkIsAutoTrack() && !ModelBase<MapModel>.Instance.IsMarkTracking(markId))
			{
				ControllerBase<MapController>.Instance.RequestTrackMapMark(new TrackMapMarkParams
				{
					MarkType = EMarkType.CommonGamePlay,
					MarkId = markId,
					Track = true
				}, null);
			}
			SkipTaskManager.Run(ESkipName.SkipToMapTempMark, new object[]
			{
				markId
			});
		}

		// Token: 0x06038BDC RID: 232412 RVA: 0x00E5E28C File Offset: 0x00E5C48C
		public void OnBtnTeleport()
		{
			ControllerBase<WorldMapController>.Instance.TryTeleport(this.FlagData.Config.MarkId, delegate
			{
				Singleton<UiManager>.Instance.ResetToBattleView(null);
			});
		}

		// Token: 0x06038BDD RID: 232413 RVA: 0x00E5E2C8 File Offset: 0x00E5C4C8
		public void UpdateData(MoraleAreaFlagData flagData)
		{
			this.FlagData = flagData;
			UUITexture texture = base.GetTexture(12);
			string monsterIconPath = this.FlagData.Config.MonsterIconPath;
			base.SetTextureByPath(monsterIconPath, texture, null, null);
			base.GetArtText(1).SetText(this.FlagData.Config.MaxMonsterLv.ToString());
			this.UpdateLvDiffBg();
			UUIItem sprite = base.GetSprite(2);
			bool isActive = this.FlagData.IsActive;
			sprite.SetUIActive(isActive);
			this.DescriptionComponent.SetContentByTextId(this.FlagData.Config.MonsterDesc, Array.Empty<string>());
			this.UpdateRewardList();
			bool flag = this.FlagData.HasBoxCanGet();
			base.GetItem(8).SetUIActive(flag);
			if (flag)
			{
				base.GetText(11).ShowTextNew("Morale_title_9");
			}
			bool flag2 = this.FlagData.IsLowMoraleLv();
			base.GetItem(7).SetUIActive(flag2);
			if (flag2)
			{
				base.GetText(10).ShowTextNew("Morale_title_7");
			}
			bool uiactive = this.FlagData.IsHighDifficultyChallenge();
			base.GetItem(3).SetUIActive(uiactive);
			this.UpdateTrackOrTeleport();
		}

		// Token: 0x06038BDE RID: 232414 RVA: 0x00E5E3F4 File Offset: 0x00E5C5F4
		public void UpdateLvDiffBg()
		{
			int maxMonsterLv = this.FlagData.Config.MaxMonsterLv;
			switch (ModelBase<MoraleBattleModel>.Instance.GetMoraleLevelDiffType(maxMonsterLv, null))
			{
			case EMoraleLevelDiffType.Easy:
				this.SetLvDiffBg("T_EnemyMoraleLevelGrayBg");
				return;
			case EMoraleLevelDiffType.Normal:
				this.SetLvDiffBg("T_EnemyMoraleLevelYellowBg");
				return;
			case EMoraleLevelDiffType.Hard:
				this.SetLvDiffBg("T_EnemyMoraleLevelRedBg");
				return;
			default:
				return;
			}
		}

		// Token: 0x06038BDF RID: 232415 RVA: 0x00E5E460 File Offset: 0x00E5C660
		public void SetLvDiffBg(string resId)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resId);
			UUITexture texture = base.GetTexture(0);
			base.SetTextureByPath(resourcePath, texture, null, null);
		}

		// Token: 0x06038BE0 RID: 232416 RVA: 0x00E5E494 File Offset: 0x00E5C694
		public void UpdateRewardList()
		{
			List<TItem> rewardItemList = this.GetRewardItemList();
			if (rewardItemList.Count <= 0)
			{
				this.RewardListComponent.SetActive(false);
				return;
			}
			this.RewardListComponent.SetActive(true);
			this.RewardListComponent.SetTitleByTextId("Morale_title_18");
			this.RewardListComponent.InitGridLayout(new Func<CommonItemSmallItemGrid>(this.InitCommonGridItem));
			this.RewardListComponent.RefreshItemLayout(rewardItemList, null);
		}

		// Token: 0x06038BE1 RID: 232417 RVA: 0x00E5E500 File Offset: 0x00E5C700
		public List<TItem> GetRewardItemList()
		{
			int boxRewardId = this.FlagData.Config.BoxRewardId;
			if (boxRewardId <= 0)
			{
				return new List<TItem>();
			}
			return ConfigBase<RewardConfig>.Instance.GetDropPackagePreviewItemList(boxRewardId);
		}

		// Token: 0x06038BE2 RID: 232418 RVA: 0x00E5E533 File Offset: 0x00E5C733
		private CommonItemSmallItemGrid InitCommonGridItem()
		{
			return new CommonItemSmallItemGrid
			{
				ShowReceivedCallBack = new Func<TItem, bool>(this.ShowReceivedCallBack)
			};
		}

		// Token: 0x06038BE3 RID: 232419 RVA: 0x00E5E54C File Offset: 0x00E5C74C
		private bool ShowReceivedCallBack(TItem data)
		{
			return this.FlagData.IsGetBox;
		}

		// Token: 0x06038BE4 RID: 232420 RVA: 0x00E5E55C File Offset: 0x00E5C75C
		public void PlayEnter()
		{
			LevelSequencePlayer sequence = this.Sequence;
			if (sequence == null)
			{
				return;
			}
			sequence.PlaySequencePurely("Start", false, false, null, null, false);
		}

		// Token: 0x06038BE5 RID: 232421 RVA: 0x00E5E58C File Offset: 0x00E5C78C
		public void UpdateTrackOrTeleport()
		{
			bool flag = ModelBase<MoraleModel>.Instance.IsMoraleGameOver();
			bool isGetBox = this.FlagData.IsGetBox;
			bool active = !flag || !isGetBox;
			this.BtnTrackOrTeleportComponent.SetActive(active);
			bool flag2 = this.FlagMarkIsCanTeleport();
			this.BtnTrackOrTeleportComponent.SetFunction(flag2 ? delegate(int _)
			{
				this.OnBtnTeleport();
			} : delegate(int _)
			{
				this.OnBtnTrack();
			});
			this.BtnTrackOrTeleportComponent.SetShowText(flag2 ? "Text_TeleportFastMove_Text" : "Morale_title_6");
		}

		// Token: 0x06038BE6 RID: 232422 RVA: 0x00E5E60C File Offset: 0x00E5C80C
		public bool FlagMarkIsCanTeleport()
		{
			int markId = this.FlagData.Config.MarkId;
			return ModelBase<MapModel>.Instance.MapMarkIsCanTeleport(markId);
		}

		// Token: 0x0402054D RID: 132429
		public MoraleAreaFlagData FlagData;

		// Token: 0x0402054E RID: 132430
		public ActivityDescriptionTypeA DescriptionComponent;

		// Token: 0x0402054F RID: 132431
		public ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;

		// Token: 0x04020550 RID: 132432
		public ButtonItem BtnTrackOrTeleportComponent;

		// Token: 0x04020551 RID: 132433
		[Nullable(2)]
		public LevelSequencePlayer Sequence;

		// Token: 0x0200B7B3 RID: 47027
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04038D2B RID: 232747
			public const int TextureDifficulty = 0;

			// Token: 0x04038D2C RID: 232748
			public const int ArtTxtLv = 1;

			// Token: 0x04038D2D RID: 232749
			public const int SpriteFinish = 2;

			// Token: 0x04038D2E RID: 232750
			public const int ItemTipsHighDifficulty = 3;

			// Token: 0x04038D2F RID: 232751
			public const int ItemDescPanel = 4;

			// Token: 0x04038D30 RID: 232752
			public const int ItemRewardPanel = 5;

			// Token: 0x04038D31 RID: 232753
			public const int ItemTipsRoot = 6;

			// Token: 0x04038D32 RID: 232754
			public const int ItemTipsWarning = 7;

			// Token: 0x04038D33 RID: 232755
			public const int ItemTipsCanReceived = 8;

			// Token: 0x04038D34 RID: 232756
			public const int ItemButtonComponent = 9;

			// Token: 0x04038D35 RID: 232757
			public const int TextTipsWarning = 10;

			// Token: 0x04038D36 RID: 232758
			public const int TextTipsCanReceived = 11;

			// Token: 0x04038D37 RID: 232759
			public const int TextureIcon = 12;
		}
	}
}
