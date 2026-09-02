using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x0200571F RID: 22303
	public class MoraleSumAreaTitleItem : UiPanelBase
	{
		// Token: 0x06038C37 RID: 232503 RVA: 0x00E5F754 File Offset: 0x00E5D954
		[NullableContext(1)]
		public UniTask Init(UUIItem item, MoraleAreaData areaData)
		{
			MoraleSumAreaTitleItem.<Init>d__3 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.item = item;
			<Init>d__.areaData = areaData;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<MoraleSumAreaTitleItem.<Init>d__3>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06038C38 RID: 232504 RVA: 0x00E5F7A8 File Offset: 0x00E5D9A8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUISprite)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUISprite)),
				new ValueTuple<int, Type>(8, typeof(UUIText)),
				new ValueTuple<int, Type>(9, typeof(UUIItem))
			};
		}

		// Token: 0x06038C39 RID: 232505 RVA: 0x00E5F89D File Offset: 0x00E5DA9D
		protected override void OnStart()
		{
		}

		// Token: 0x06038C3A RID: 232506 RVA: 0x00E5F89F File Offset: 0x00E5DA9F
		protected override void OnBeforeShow()
		{
		}

		// Token: 0x06038C3B RID: 232507 RVA: 0x00E5F8A4 File Offset: 0x00E5DAA4
		public void UpdateData()
		{
			UUIText text = base.GetText(4);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "Morale_title_4", Array.Empty<object>());
			string textStringId = "Morale_title_16";
			int uiActiveFlagNum = this.AreaData.GetUiActiveFlagNum();
			int uiTotalFlagNum = this.AreaData.GetUiTotalFlagNum();
			UUIText text2 = base.GetText(3);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, textStringId, new <>z__ReadOnlyArray<object>(new object[]
			{
				uiActiveFlagNum,
				uiTotalFlagNum
			}));
			bool areaActiveState = this.AreaData.IsAllUiFlagActive();
			this.SetAreaActiveState(areaActiveState);
			bool flag = this.IsShowBoxProgress();
			this.SetBoxProgressActive(flag);
			if (flag)
			{
				int allBoxReceivedCount = this.AreaData.GetAllBoxReceivedCount();
				int allBoxTotalCount = this.AreaData.GetAllBoxTotalCount();
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(allBoxReceivedCount);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(allBoxTotalCount);
				string newText = defaultInterpolatedStringHandler.ToStringAndClear();
				UUIText text3 = base.GetText(8);
				if (text3 != null)
				{
					text3.SetText(newText, true);
				}
			}
			bool uiactive = this.AreaData.IsExistFlagRewardCanGet();
			UUIItem item = base.GetItem(9);
			if (item != null)
			{
				item.SetUIActive(uiactive);
			}
			bool uiactive2 = this.AreaData.IsPlayerInArea();
			UUISprite sprite = base.GetSprite(7);
			if (sprite != null)
			{
				sprite.SetUIActive(uiactive2);
			}
			this.CheckHighFlagNewActiveBefore();
		}

		// Token: 0x06038C3C RID: 232508 RVA: 0x00E5F9F0 File Offset: 0x00E5DBF0
		public bool IsShowBoxProgress()
		{
			return this.AreaData.IsExistBox() && this.AreaData.HighDifficultyFlagSomeActive();
		}

		// Token: 0x06038C3D RID: 232509 RVA: 0x00E5FA0C File Offset: 0x00E5DC0C
		public UniTask CheckPlayHighMonsterKillEffect()
		{
			MoraleSumAreaTitleItem.<CheckPlayHighMonsterKillEffect>d__9 <CheckPlayHighMonsterKillEffect>d__;
			<CheckPlayHighMonsterKillEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CheckPlayHighMonsterKillEffect>d__.<>4__this = this;
			<CheckPlayHighMonsterKillEffect>d__.<>1__state = -1;
			<CheckPlayHighMonsterKillEffect>d__.<>t__builder.Start<MoraleSumAreaTitleItem.<CheckPlayHighMonsterKillEffect>d__9>(ref <CheckPlayHighMonsterKillEffect>d__);
			return <CheckPlayHighMonsterKillEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06038C3E RID: 232510 RVA: 0x00E5FA4F File Offset: 0x00E5DC4F
		public void SetAreaActiveState(bool active)
		{
			UUISprite sprite = base.GetSprite(1);
			if (sprite != null)
			{
				sprite.SetUIActive(active);
			}
			UUISprite sprite2 = base.GetSprite(5);
			if (sprite2 == null)
			{
				return;
			}
			sprite2.SetUIActive(active);
		}

		// Token: 0x06038C3F RID: 232511 RVA: 0x00E5FA76 File Offset: 0x00E5DC76
		public void SetBoxProgressActive(bool active)
		{
			UUIItem item = base.GetItem(6);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(active);
		}

		// Token: 0x06038C40 RID: 232512 RVA: 0x00E5FA8A File Offset: 0x00E5DC8A
		public void CheckHighFlagNewActiveBefore()
		{
			if (!this.AreaData.HighDifficultyFlagSomeNewActive())
			{
				return;
			}
			this.SetAreaActiveState(false);
			this.SetBoxProgressActive(false);
		}

		// Token: 0x06038C41 RID: 232513 RVA: 0x00E5FAA8 File Offset: 0x00E5DCA8
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx([Nullable(new byte[]
		{
			2,
			1
		})] string[] configParams)
		{
			if (configParams == null || configParams.Length == 0)
			{
				return null;
			}
			if (!(configParams[0] == "FirstFinishedAreaBox"))
			{
				return null;
			}
			UUIItem item = base.GetItem(6);
			if (item == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				item,
				item
			};
		}

		// Token: 0x0402055E RID: 132446
		[Nullable(1)]
		public MoraleAreaData AreaData;

		// Token: 0x0402055F RID: 132447
		[Nullable(2)]
		public LevelSequencePlayer Sequence;

		// Token: 0x0200B7CE RID: 47054
		private class EChildType
		{
			// Token: 0x04038DAC RID: 232876
			public const int ItemSelf = 0;

			// Token: 0x04038DAD RID: 232877
			public const int SpriteFinish = 1;

			// Token: 0x04038DAE RID: 232878
			public const int SpriteAreaIndex = 2;

			// Token: 0x04038DAF RID: 232879
			public const int TextAreaProgress = 3;

			// Token: 0x04038DB0 RID: 232880
			public const int TextAreaName = 4;

			// Token: 0x04038DB1 RID: 232881
			public const int SpriteActive = 5;

			// Token: 0x04038DB2 RID: 232882
			public const int ItemBoxProgressRoot = 6;

			// Token: 0x04038DB3 RID: 232883
			public const int SpritePlayerPos = 7;

			// Token: 0x04038DB4 RID: 232884
			public const int TextBoxProgress = 8;

			// Token: 0x04038DB5 RID: 232885
			public const int ItemBoxCanGetTips = 9;
		}
	}
}
