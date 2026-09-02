using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Item
{
	// Token: 0x020068E7 RID: 26855
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DropCatchRewardPreviewItem : GridProxyAbstract<IDropCatchRewardPreviewData>
	{
		// Token: 0x06042BF0 RID: 273392 RVA: 0x0112137C File Offset: 0x0111F57C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUIArtText)),
				new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUISprite)),
				new ValueTuple<int, Type>(6, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(8, typeof(UUISprite))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(7, new Action(this.OnClicked))
			};
		}

		// Token: 0x06042BF1 RID: 273393 RVA: 0x01121480 File Offset: 0x0111F680
		protected override void OnStart()
		{
			if (this.RewardScrollView != null)
			{
				return;
			}
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(6);
			if (scrollViewWithScrollbar != null)
			{
				this.RewardScrollView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(scrollViewWithScrollbar, new Func<CommonItemSmallItemGrid>(this.CreateRewardItem), null, false, null);
			}
			this.StarLayout = new GenericLayout<DropCatchRewardStarItem, bool>(base.GetHorizontalLayout(3), new Func<DropCatchRewardStarItem>(this.CreateStarItem), null, false, true);
		}

		// Token: 0x06042BF2 RID: 273394 RVA: 0x011214DD File Offset: 0x0111F6DD
		private CommonItemSmallItemGrid CreateRewardItem()
		{
			return new CommonItemSmallItemGrid
			{
				ShowReceivedCallBack = ((TItem _) => this.IsRewarded)
			};
		}

		// Token: 0x06042BF3 RID: 273395 RVA: 0x011214F6 File Offset: 0x0111F6F6
		private DropCatchRewardStarItem CreateStarItem()
		{
			return new DropCatchRewardStarItem();
		}

		// Token: 0x06042BF4 RID: 273396 RVA: 0x01121500 File Offset: 0x0111F700
		public override void Refresh(IDropCatchRewardPreviewData data, bool isSelected, int gridIndex)
		{
			if (data == null)
			{
				return;
			}
			this.CfgId = data.CfgId;
			DropCatchReward? dropCatchRewardById = ConfigBase<DropCatchConfig>.Instance.GetDropCatchRewardById(this.CfgId);
			if (dropCatchRewardById == null)
			{
				return;
			}
			this.IsRewarded = (data.State.GetValueOrDefault() == EDropCatchLevelState.Rewarded);
			bool flag = data.State.GetValueOrDefault() == EDropCatchLevelState.Unlock || data.State.GetValueOrDefault() == EDropCatchLevelState.Rewarded;
			UUIArtText artText = base.GetArtText(2);
			UUIItem uuiitem = artText;
			bool bUseChangeColor = flag;
			FColor? fcolor = new FColor?(artText.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			UUISprite sprite = base.GetSprite(0);
			UUIItem uuiitem2 = sprite;
			bool bUseChangeColor2 = flag;
			fcolor = new FColor?(sprite.changeColor);
			uuiitem2.SetChangeColor(bUseChangeColor2, fcolor);
			UUISprite sprite2 = base.GetSprite(1);
			UUIItem uuiitem3 = sprite2;
			bool bUseChangeColor3 = flag;
			fcolor = new FColor?(sprite2.changeColor);
			uuiitem3.SetChangeColor(bUseChangeColor3, fcolor);
			UUIButtonComponent button = base.GetButton(7);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(data.State.GetValueOrDefault() == EDropCatchLevelState.Unlock);
			}
			UUISprite sprite3 = base.GetSprite(5);
			if (sprite3 != null)
			{
				sprite3.SetUIActive(this.IsRewarded);
			}
			UUISprite sprite4 = base.GetSprite(8);
			if (sprite4 != null)
			{
				sprite4.SetUIActive(flag);
			}
			if (artText != null)
			{
				artText.SetText(dropCatchRewardById.Value.Score.ToString().PadLeft(5, '0'));
			}
			List<TItem> data2 = (dropCatchRewardById.Value.DropId > 0) ? ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(dropCatchRewardById.Value.DropId) : new List<TItem>();
			GenericScrollViewNew<CommonItemSmallItemGrid, TItem> rewardScrollView = this.RewardScrollView;
			if (rewardScrollView != null)
			{
				rewardScrollView.RefreshByData(data2, null, false);
			}
			List<bool> list = new List<bool>();
			for (int i = 0; i < gridIndex + 1; i++)
			{
				list.Add(flag);
			}
			GenericLayout<DropCatchRewardStarItem, bool> starLayout = this.StarLayout;
			if (starLayout != null)
			{
				starLayout.RefreshByData(list, null, false);
			}
			if (sprite != null)
			{
				sprite.SetHeight((float)(data.IsLast ? 194 : 224));
			}
		}

		// Token: 0x06042BF5 RID: 273397 RVA: 0x011216FB File Offset: 0x0111F8FB
		public void SetClickCallback(Action<int> callback)
		{
			this.ClickCallback = callback;
		}

		// Token: 0x06042BF6 RID: 273398 RVA: 0x01121704 File Offset: 0x0111F904
		private void OnClicked()
		{
			Action<int> clickCallback = this.ClickCallback;
			if (clickCallback == null)
			{
				return;
			}
			clickCallback(this.CfgId);
		}

		// Token: 0x040252F8 RID: 152312
		private int CfgId;

		// Token: 0x040252F9 RID: 152313
		private Action<int> ClickCallback = delegate(int index)
		{
		};

		// Token: 0x040252FA RID: 152314
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScrollView;

		// Token: 0x040252FB RID: 152315
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<DropCatchRewardStarItem, bool> StarLayout;

		// Token: 0x040252FC RID: 152316
		private bool IsRewarded;

		// Token: 0x040252FD RID: 152317
		private const int PROGRESS_BAR_NORMAL_HEIGHT = 224;

		// Token: 0x040252FE RID: 152318
		private const int PROGRESS_BAR_LAST_HEIGHT = 194;
	}
}
