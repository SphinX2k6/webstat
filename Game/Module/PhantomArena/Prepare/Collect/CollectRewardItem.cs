using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Collect
{
	// Token: 0x02005518 RID: 21784
	public class CollectRewardItem : GridProxyAbstract<int>
	{
		// Token: 0x0603791A RID: 227610 RVA: 0x00E18C30 File Offset: 0x00E16E30
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUISprite)),
				new ValueTuple<int, Type>(5, typeof(UUISprite)),
				new ValueTuple<int, Type>(6, typeof(UUISprite)),
				new ValueTuple<int, Type>(7, typeof(UUISprite)),
				new ValueTuple<int, Type>(8, typeof(UUISprite)),
				new ValueTuple<int, Type>(9, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickReward))
			};
		}

		// Token: 0x0603791B RID: 227611 RVA: 0x00E18D48 File Offset: 0x00E16F48
		public override void Refresh(int rewardId, bool isSelected, int gridIndex)
		{
			this.RewardId = rewardId;
			ECollectRewardState ecollectRewardState = ECollectRewardState.Pending;
			int num = 0;
			if (this.RewardType == ECollectRewardType.Badge)
			{
				ecollectRewardState = ModelBase<PhantomArenaModel>.Instance.GetBadgeRewardStateById(this.RewardId);
				num = ModelBase<PhantomArenaModel>.Instance.GetBadgeRewardNeedCountById(this.RewardId);
			}
			else if (this.RewardType == ECollectRewardType.Card)
			{
				ecollectRewardState = ModelBase<PhantomArenaModel>.Instance.GetCardRewardStateById(this.RewardId);
				num = ModelBase<PhantomArenaModel>.Instance.GetCardRewardNeedCountById(this.RewardId);
			}
			UUISprite sprite = base.GetSprite(1);
			if (sprite != null)
			{
				sprite.SetUIActive(true);
			}
			UUISprite sprite2 = base.GetSprite(2);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(ecollectRewardState == ECollectRewardState.Finish);
			}
			UUISprite sprite3 = base.GetSprite(3);
			if (sprite3 != null)
			{
				sprite3.SetUIActive(ecollectRewardState == ECollectRewardState.Taken);
			}
			UUISprite sprite4 = base.GetSprite(4);
			if (sprite4 != null)
			{
				sprite4.SetUIActive(ecollectRewardState == ECollectRewardState.Finish);
			}
			UUISprite sprite5 = base.GetSprite(5);
			if (sprite5 != null)
			{
				sprite5.SetUIActive(ecollectRewardState == ECollectRewardState.Pending);
			}
			UUISprite sprite6 = base.GetSprite(6);
			if (sprite6 != null)
			{
				sprite6.SetUIActive(ecollectRewardState == ECollectRewardState.Taken);
			}
			UUISprite sprite7 = base.GetSprite(7);
			if (sprite7 != null)
			{
				sprite7.SetUIActive(true);
			}
			UUISprite sprite8 = base.GetSprite(8);
			if (sprite8 != null)
			{
				sprite8.SetUIActive(ecollectRewardState != ECollectRewardState.Pending);
			}
			base.GetText(9).SetText(num.ToString(), true);
		}

		// Token: 0x0603791C RID: 227612 RVA: 0x00E18E7C File Offset: 0x00E1707C
		private void OnClickReward()
		{
			if (this.CallbackClickReward != null)
			{
				TWeakObjectPtr<UUIItem> rootUIComp = base.GetButton(0).RootUIComp;
				this.CallbackClickReward(this.RewardId, rootUIComp);
			}
		}

		// Token: 0x0401FDD6 RID: 130518
		private int RewardId = -1;

		// Token: 0x0401FDD7 RID: 130519
		public ECollectRewardType RewardType;

		// Token: 0x0401FDD8 RID: 130520
		[Nullable(1)]
		public Action<int, UUIItem> CallbackClickReward;

		// Token: 0x0200B4A7 RID: 46247
		private static class EComponents
		{
			// Token: 0x04037EBF RID: 229055
			public const int BtnReward = 0;

			// Token: 0x04037EC0 RID: 229056
			public const int SpriteBg = 1;

			// Token: 0x04037EC1 RID: 229057
			public const int SpriteBgFinish = 2;

			// Token: 0x04037EC2 RID: 229058
			public const int SpriteBoxTaken = 3;

			// Token: 0x04037EC3 RID: 229059
			public const int SpriteBoxFinish = 4;

			// Token: 0x04037EC4 RID: 229060
			public const int SpriteBoxPending = 5;

			// Token: 0x04037EC5 RID: 229061
			public const int SpriteIconTaken = 6;

			// Token: 0x04037EC6 RID: 229062
			public const int SpriteCubePending = 7;

			// Token: 0x04037EC7 RID: 229063
			public const int SpriteCubeTaken = 8;

			// Token: 0x04037EC8 RID: 229064
			public const int TextCount = 9;
		}
	}
}
