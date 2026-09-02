using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200517C RID: 20860
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoguelikeAchievementItem : GridProxyAbstract<AchievementData>
	{
		// Token: 0x06035AC8 RID: 219848 RVA: 0x00D7B79C File Offset: 0x00D7999C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnBtnRewardClickInternal));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035AC9 RID: 219849 RVA: 0x00D7B8E7 File Offset: 0x00D79AE7
		protected void OnBtnRewardClickInternal()
		{
			Action onBtnRewardClick = this.OnBtnRewardClick;
			if (onBtnRewardClick == null)
			{
				return;
			}
			onBtnRewardClick();
		}

		// Token: 0x06035ACA RID: 219850 RVA: 0x00D7B8F9 File Offset: 0x00D79AF9
		protected override void OnStart()
		{
			if (this.CommonGridItem == null)
			{
				this.CommonGridItem = new CommonItemSmallItemGrid();
				this.CommonGridItem.Initialize(base.GetItem(3).GetOwner());
			}
			this.CommonGridItem.SetActive(false);
		}

		// Token: 0x06035ACB RID: 219851 RVA: 0x00D7B931 File Offset: 0x00D79B31
		[NullableContext(1)]
		public override object GetKey(AchievementData data, int displayIndex)
		{
			return data.GetId();
		}

		// Token: 0x06035ACC RID: 219852 RVA: 0x00D7B93E File Offset: 0x00D79B3E
		[NullableContext(1)]
		public override void Refresh(AchievementData data, bool isSelected, int gridIndex)
		{
			this.Update(data);
		}

		// Token: 0x06035ACD RID: 219853 RVA: 0x00D7B948 File Offset: 0x00D79B48
		public void Update(AchievementData data = null)
		{
			this.Data = ((data != null) ? data : this.Data);
			base.GetText(0).SetText(this.Data.GetDesc(), true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Rogue_Achievement_Progress", new <>z__ReadOnlyArray<object>(new object[]
			{
				this.Data.GetCurrentProgress(),
				this.Data.GetMaxProgress()
			}));
			switch (this.Data.GetFinishState())
			{
			case EAchievementStateEnum.UnFinished:
				base.GetItem(2).SetUIActive(false);
				base.GetButton(4).RootUIComp.Get().SetUIActive(false);
				base.GetItem(6).SetUIActive(true);
				break;
			case EAchievementStateEnum.CanGetReward:
				base.GetItem(2).SetUIActive(false);
				base.GetButton(4).RootUIComp.Get().SetUIActive(true);
				base.GetItem(6).SetUIActive(false);
				break;
			case EAchievementStateEnum.HaveGetReward:
				base.GetItem(2).SetUIActive(true);
				base.GetButton(4).RootUIComp.Get().SetUIActive(false);
				base.GetItem(6).SetUIActive(false);
				break;
			}
			List<TItem> rewards = this.Data.GetRewards();
			if (rewards.Count > 0)
			{
				this.CommonGridItem.SetActive(true);
				this.CommonGridItem.Refresh(rewards[0]);
			}
		}

		// Token: 0x0401ECF6 RID: 126198
		public CommonItemSmallItemGrid CommonGridItem;

		// Token: 0x0401ECF7 RID: 126199
		public AchievementData Data;

		// Token: 0x0401ECF8 RID: 126200
		public Action OnBtnRewardClick;

		// Token: 0x0200B132 RID: 45362
		[NullableContext(0)]
		private class ERoguelikeAchievementItemDefine
		{
			// Token: 0x04036F4E RID: 225102
			public const int TxtTitle = 0;

			// Token: 0x04036F4F RID: 225103
			public const int TxtProgress = 1;

			// Token: 0x04036F50 RID: 225104
			public const int RewardedItem = 2;

			// Token: 0x04036F51 RID: 225105
			public const int CommonGridItem = 3;

			// Token: 0x04036F52 RID: 225106
			public const int BtnReward = 4;

			// Token: 0x04036F53 RID: 225107
			public const int TxtConfirm = 5;

			// Token: 0x04036F54 RID: 225108
			public const int DoingItem = 6;
		}
	}
}
