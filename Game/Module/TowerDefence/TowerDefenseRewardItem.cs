using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EE2 RID: 20194
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TowerDefenseRewardItem : GridProxyAbstract<IActivityRewardData>
	{
		// Token: 0x0603427C RID: 213628 RVA: 0x00D0A94C File Offset: 0x00D08B4C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickJumpBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603427D RID: 213629 RVA: 0x00D0AADC File Offset: 0x00D08CDC
		protected override void OnStart()
		{
			UUIHorizontalLayout horizontalLayout = base.GetHorizontalLayout(2);
			if (horizontalLayout != null)
			{
				this.ItemLayout = new GenericLayout<CommonItemSmallItemGrid, TItem>(horizontalLayout, new Func<CommonItemSmallItemGrid>(this.InitGridItem), null, false, true);
			}
			UUIButtonComponent button = base.GetButton(4);
			if (button != null)
			{
				this.ReceiveButton = new ButtonItem(button.RootUIComp.Get());
				this.ReceiveButton.SetFunction(delegate(int _)
				{
					this.OnClickReceiveBtn();
				});
			}
			UUIItem item = base.GetItem(7);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x0603427E RID: 213630 RVA: 0x00D0AB5C File Offset: 0x00D08D5C
		public override void Refresh(IActivityRewardData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			this.RefreshTitle(data);
			this.RefreshDesc(data);
			this.RefreshRewardList(data);
			this.RefreshState(data);
		}

		// Token: 0x0603427F RID: 213631 RVA: 0x00D0AB81 File Offset: 0x00D08D81
		private CommonItemSmallItemGrid InitGridItem()
		{
			return new CommonItemSmallItemGrid();
		}

		// Token: 0x06034280 RID: 213632 RVA: 0x00D0AB88 File Offset: 0x00D08D88
		private void RefreshTitle(IActivityRewardData data)
		{
			UUIText text = base.GetText(0);
			if (text == null)
			{
				return;
			}
			if (!string.IsNullOrEmpty(data.NameTextId))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.NameTextId, data.NameTextArgs ?? Array.Empty<string>());
				return;
			}
			text.SetText(data.NameText, true);
		}

		// Token: 0x06034281 RID: 213633 RVA: 0x00D0ABDC File Offset: 0x00D08DDC
		private void RefreshDesc(IActivityRewardData data)
		{
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.SetUIActive(data.ProgressText != null);
			}
			if (text == null)
			{
				return;
			}
			text.SetText(data.ProgressText ?? "", true);
		}

		// Token: 0x06034282 RID: 213634 RVA: 0x00D0AC14 File Offset: 0x00D08E14
		private void RefreshRewardList(IActivityRewardData data)
		{
			if (this.ItemLayout == null)
			{
				return;
			}
			TItem[] array = data.RewardList ?? Array.Empty<TItem>();
			this.ItemLayout.SetActive(array.Length != 0);
			if (array.Length == 0)
			{
				return;
			}
			this.ItemLayout.RefreshByData(array, null, false);
		}

		// Token: 0x06034283 RID: 213635 RVA: 0x00D0AC60 File Offset: 0x00D08E60
		private void RefreshState(IActivityRewardData data)
		{
			EActivityRewardState rewardState = data.RewardState;
			UUIButtonComponent button = base.GetButton(8);
			UUIItem item = base.GetItem(6);
			UUIText text = base.GetText(5);
			bool flag = rewardState == EActivityRewardState.Enable;
			UUIButtonComponent button2 = base.GetButton(4);
			if (button2 != null)
			{
				UUIItem uuiitem = button2.RootUIComp.Get();
				if (uuiitem != null)
				{
					uuiitem.SetUIActive(flag);
				}
			}
			ButtonItem receiveButton = this.ReceiveButton;
			if (receiveButton != null)
			{
				receiveButton.SetRedDotVisible(flag && data.RewardButtonRedDot.GetValueOrDefault());
			}
			if (button != null)
			{
				UUIItem uuiitem2 = button.RootUIComp.Get();
				if (uuiitem2 != null)
				{
					uuiitem2.SetUIActive(false);
				}
			}
			if (item != null)
			{
				item.SetUIActive(rewardState == EActivityRewardState.Claimed);
			}
			if (text != null)
			{
				text.SetUIActive(rewardState == EActivityRewardState.Disabled);
			}
			if (rewardState == EActivityRewardState.Disabled && text != null)
			{
				if (data.RewardButtonTextId != null)
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.RewardButtonTextId, Array.Empty<object>());
					return;
				}
				if (data.RewardButtonText != null)
				{
					text.SetText(data.RewardButtonText, true);
				}
			}
		}

		// Token: 0x06034284 RID: 213636 RVA: 0x00D0AD51 File Offset: 0x00D08F51
		private void OnClickReceiveBtn()
		{
			if (this.Data == null)
			{
				return;
			}
			if (this.Data.RewardState != EActivityRewardState.Enable)
			{
				return;
			}
			Action clickFunction = this.Data.ClickFunction;
			if (clickFunction == null)
			{
				return;
			}
			clickFunction();
		}

		// Token: 0x06034285 RID: 213637 RVA: 0x00D0AD80 File Offset: 0x00D08F80
		private void OnClickJumpBtn()
		{
			if (this.Data == null)
			{
				return;
			}
			if (this.Data.RewardState != EActivityRewardState.Disabled)
			{
				return;
			}
			Action clickFunction = this.Data.ClickFunction;
			if (clickFunction == null)
			{
				return;
			}
			clickFunction();
		}

		// Token: 0x0401E1CE RID: 123342
		[Nullable(2)]
		private IActivityRewardData Data;

		// Token: 0x0401E1CF RID: 123343
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<CommonItemSmallItemGrid, TItem> ItemLayout;

		// Token: 0x0401E1D0 RID: 123344
		[Nullable(2)]
		private ButtonItem ReceiveButton;

		// Token: 0x0200AE96 RID: 44694
		[NullableContext(0)]
		private class ERewardComponent
		{
			// Token: 0x04036348 RID: 222024
			public const int TitleTxt = 0;

			// Token: 0x04036349 RID: 222025
			public const int DescTxt = 1;

			// Token: 0x0403634A RID: 222026
			public const int RewardLayout = 2;

			// Token: 0x0403634B RID: 222027
			public const int RewardItem = 3;

			// Token: 0x0403634C RID: 222028
			public const int ReceiveBtn = 4;

			// Token: 0x0403634D RID: 222029
			public const int InProgressTxt = 5;

			// Token: 0x0403634E RID: 222030
			public const int ReceivedSprite = 6;

			// Token: 0x0403634F RID: 222031
			public const int RedDotItem = 7;

			// Token: 0x04036350 RID: 222032
			public const int JumpBtn = 8;
		}
	}
}
