using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D5F RID: 23903
	[NullableContext(1)]
	[Nullable(0)]
	public class FlagChallengeBuffView : UiViewBase
	{
		// Token: 0x170098A0 RID: 39072
		// (get) Token: 0x0603C3B5 RID: 246709 RVA: 0x00F472B4 File Offset: 0x00F454B4
		[Nullable(2)]
		public new FlagChallengeBuffViewParams OpenParam
		{
			[NullableContext(2)]
			get
			{
				return this.OpenParam as FlagChallengeBuffViewParams;
			}
		}

		// Token: 0x0603C3B6 RID: 246710 RVA: 0x00F472C1 File Offset: 0x00F454C1
		public FlagChallengeBuffView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603C3B7 RID: 246711 RVA: 0x00F472E0 File Offset: 0x00F454E0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIArtText)),
				new ValueTuple<int, Type>(8, typeof(UUIArtText)),
				new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(14, typeof(UUIText)),
				new ValueTuple<int, Type>(15, typeof(UUIItem)),
				new ValueTuple<int, Type>(16, typeof(UUIText)),
				new ValueTuple<int, Type>(17, typeof(UUIItem)),
				new ValueTuple<int, Type>(18, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(9, new Action(this.OnBuffDetailButtonClick))
			};
		}

		// Token: 0x0603C3B8 RID: 246712 RVA: 0x00F474C8 File Offset: 0x00F456C8
		protected override UniTask OnBeforeStartAsync()
		{
			FlagChallengeBuffView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FlagChallengeBuffView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C3B9 RID: 246713 RVA: 0x00F4750C File Offset: 0x00F4570C
		protected override void OnBeforeShow()
		{
			this.RefreshView();
			UUIScrollViewWithScrollbarComponent scroll = base.GetScrollViewWithScrollbar(13);
			scroll.OnLateUpdate.Bind(delegate(float _)
			{
				TimerSystem.Instance.Next(new TTimerAction(this.UpdateProgressAndJump), null, null);
				UUIScrollViewWithScrollbarComponent scroll = scroll;
				if (scroll == null)
				{
					return;
				}
				scroll.OnLateUpdate.Unbind();
			});
		}

		// Token: 0x0603C3BA RID: 246714 RVA: 0x00F47556 File Offset: 0x00F45756
		protected override void OnBeforeDestroy()
		{
			ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(this.ActivityId).ClearBuffNewlyUnlocked();
		}

		// Token: 0x0603C3BB RID: 246715 RVA: 0x00F47570 File Offset: 0x00F45770
		private UniTask InitBuffList()
		{
			FlagChallengeBuffView.<InitBuffList>d__16 <InitBuffList>d__;
			<InitBuffList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBuffList>d__.<>4__this = this;
			<InitBuffList>d__.<>1__state = -1;
			<InitBuffList>d__.<>t__builder.Start<FlagChallengeBuffView.<InitBuffList>d__16>(ref <InitBuffList>d__);
			return <InitBuffList>d__.<>t__builder.Task;
		}

		// Token: 0x0603C3BC RID: 246716 RVA: 0x00F475B4 File Offset: 0x00F457B4
		private void RefreshView()
		{
			foreach (FlagChallengeBuffItem flagChallengeBuffItem in this.BuffItemList)
			{
				flagChallengeBuffItem.RefreshView();
			}
			if (this.SelectBuff != null)
			{
				this.BuffInfoPanel.RefreshView(this.SelectBuff);
				this.BuffInfoPanel.SetUiActive(true);
			}
			else
			{
				this.BuffInfoPanel.SetUiActive(false);
			}
			this.LevelInfoItem.RefreshView();
			int num = 0;
			using (List<FlagChallengeBuffData>.Enumerator enumerator2 = this.BuffDataList.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					if (enumerator2.Current.IsActiveOrTempActive())
					{
						num++;
					}
				}
			}
			base.GetArtText(7).SetText(num.ToString());
			base.GetArtText(8).SetText(this.BuffDataList.Count.ToString());
			this.RefreshBoxLevel();
		}

		// Token: 0x0603C3BD RID: 246717 RVA: 0x00F476C4 File Offset: 0x00F458C4
		private void RefreshBoxLevel()
		{
			UUIText text = base.GetText(18);
			if (!FlagChallengeUtils.IsInFlagChallengeDungeon())
			{
				text.SetUIActive(false);
				return;
			}
			text.SetUIActive(true);
			int boxLevel = ModelBase<FlagChallengeBattleModel>.Instance.GetBoxLevel();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "Morale_32_Buff_ChestLv", new <>z__ReadOnlySingleElementList<object>(boxLevel));
		}

		// Token: 0x0603C3BE RID: 246718 RVA: 0x00F47718 File Offset: 0x00F45918
		private void UpdateProgressAndJump(float delta)
		{
			if (base.IsDestroyOrDestroying)
			{
				return;
			}
			this.UpdateLevelProgress(null, null);
			this.UpdateScrollJumpPos();
		}

		// Token: 0x0603C3BF RID: 246719 RVA: 0x00F4774C File Offset: 0x00F4594C
		private void UpdateLevelProgress(int? fixedLevel = null, int? tempLevel = null)
		{
			UUISprite sprite = base.GetSprite(2);
			float num = (sprite != null) ? sprite.GetWidth() : 0f;
			if (num <= 0f)
			{
				return;
			}
			int num2 = fixedLevel ?? ModelBase<FlagChallengeModel>.Instance.GetCalculatedLevel(this.ActivityId);
			float levelProgress = this.GetLevelProgress(num2);
			if (sprite != null)
			{
				sprite.SetFillAmount(levelProgress);
			}
			if (sprite != null)
			{
				sprite.SetUIActive(true);
			}
			int num3 = tempLevel ?? ModelBase<FlagChallengeModel>.Instance.GetTempLevel(this.ActivityId);
			bool flag = num3 > 0 || levelProgress < 1f;
			UUISprite sprite2 = base.GetSprite(3);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(flag);
			}
			if (!flag)
			{
				return;
			}
			float stretchLeft = num * levelProgress;
			if (sprite2 != null)
			{
				sprite2.SetStretchLeft(stretchLeft);
			}
			int level = num2 + num3;
			float levelProgress2 = this.GetLevelProgress(level);
			float num4 = 1f - levelProgress2;
			float stretchRight = num * num4;
			if (sprite2 != null)
			{
				sprite2.SetStretchRight(stretchRight);
			}
		}

		// Token: 0x0603C3C0 RID: 246720 RVA: 0x00F47850 File Offset: 0x00F45A50
		public float GetLevelProgress(int level)
		{
			int num = this.BuffItemList.Count * 2 - 1;
			FlagChallengeBuffData buffDataByLevel = ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(this.ActivityId).GetBuffDataByLevel(level);
			int num2 = Math.Max(buffDataByLevel.GetStartLevel() - 1, 0);
			int num3 = (buffDataByLevel.GetIndex() > 0) ? 2 : 1;
			int num4 = (level - num2) / (buffDataByLevel.GetEndLevel() - num2) * num3;
			return (float)((Math.Max(buffDataByLevel.GetIndex() * 2 - 1, 0) + num4) / num);
		}

		// Token: 0x0603C3C1 RID: 246721 RVA: 0x00F478C8 File Offset: 0x00F45AC8
		private void UpdateScrollJumpPos()
		{
			if (this.SelectBuff == null)
			{
				return;
			}
			int num = 2;
			int num2 = Math.Max(0, this.SelectBuff.GetIndex() - num);
			if (num2 >= this.BuffItemList.Count)
			{
				return;
			}
			FlagChallengeBuffItem flagChallengeBuffItem = this.BuffItemList[num2];
			if (flagChallengeBuffItem == null)
			{
				return;
			}
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(13);
			FVector relativeLocation = scrollViewWithScrollbar.ContentUIItem.Get().RelativeLocation;
			FVector2D fvector2D = new FVector2D(ref relativeLocation);
			scrollViewWithScrollbar.ScrollToLeft(ref fvector2D, flagChallengeBuffItem.GetRootItem(), false);
		}

		// Token: 0x0603C3C2 RID: 246722 RVA: 0x00F4794B File Offset: 0x00F45B4B
		[NullableContext(2)]
		private void SetSelectBuff(FlagChallengeBuffData buff)
		{
			this.SelectBuff = buff;
			this.UpdateSelectBuffState();
		}

		// Token: 0x0603C3C3 RID: 246723 RVA: 0x00F4795C File Offset: 0x00F45B5C
		private void UpdateSelectBuffState()
		{
			foreach (FlagChallengeBuffData flagChallengeBuffData in this.BuffDataList)
			{
				int id = flagChallengeBuffData.Id;
				FlagChallengeBuffData selectBuff = this.SelectBuff;
				int? num = (selectBuff != null) ? new int?(selectBuff.Id) : null;
				flagChallengeBuffData.IsSelected = (id == num.GetValueOrDefault() & num != null);
			}
		}

		// Token: 0x0603C3C4 RID: 246724 RVA: 0x00F479E4 File Offset: 0x00F45BE4
		private void OnCloseClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603C3C5 RID: 246725 RVA: 0x00F479F0 File Offset: 0x00F45BF0
		private void OnHelpClick()
		{
			int buffHelpId = ConfigBase<FlagChallengeConfig>.Instance.GetBuffHelpId();
			ControllerBase<HelpController>.Instance.OpenHelpById(buffHelpId);
		}

		// Token: 0x0603C3C6 RID: 246726 RVA: 0x00F47A14 File Offset: 0x00F45C14
		private void OnBuffItemClick(FlagChallengeBuffData data)
		{
			this.SetSelectBuff(data);
			this.BuffInfoPanel.RefreshView(data);
			foreach (FlagChallengeBuffItem flagChallengeBuffItem in this.BuffItemList)
			{
				flagChallengeBuffItem.UpdateToggleState();
			}
			ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(this.ActivityId).SetBuffNewlyUnlockedState(data.Id, false);
		}

		// Token: 0x0603C3C7 RID: 246727 RVA: 0x00F47A94 File Offset: 0x00F45C94
		private void OnBuffDetailButtonClick()
		{
			this.RoleAttrAddPanel.SetActive(true);
		}

		// Token: 0x04021D79 RID: 138617
		private int ActivityId;

		// Token: 0x04021D7A RID: 138618
		private List<FlagChallengeBuffData> BuffDataList;

		// Token: 0x04021D7B RID: 138619
		[Nullable(2)]
		private FlagChallengeBuffData SelectBuff;

		// Token: 0x04021D7C RID: 138620
		private PopupCaptionItem PopupCaption;

		// Token: 0x04021D7D RID: 138621
		private FlagChallengeBuffInfoPanel BuffInfoPanel;

		// Token: 0x04021D7E RID: 138622
		private FlagChallengeLevelInfoItem LevelInfoItem;

		// Token: 0x04021D7F RID: 138623
		private FlagChallengeBuffAddPanel RoleAttrAddPanel;

		// Token: 0x04021D80 RID: 138624
		private readonly List<FlagChallengeBuffItem> BuffItemList = new List<FlagChallengeBuffItem>();

		// Token: 0x04021D81 RID: 138625
		private readonly Dictionary<int, FlagChallengeBuffItem> BuffItemMap = new Dictionary<int, FlagChallengeBuffItem>();
	}
}
