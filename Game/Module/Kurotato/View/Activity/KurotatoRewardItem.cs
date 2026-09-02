using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Kurotato.Data;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Activity
{
	// Token: 0x02005AE7 RID: 23271
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class KurotatoRewardItem : GridProxyAbstract<KurotatoRewardItemData>
	{
		// Token: 0x0603AD3F RID: 240959 RVA: 0x00EEB3E8 File Offset: 0x00EE95E8
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickReceive));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603AD40 RID: 240960 RVA: 0x00EEB576 File Offset: 0x00EE9776
		protected override void OnStart()
		{
			this.RewardScroll = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(2), () => new CommonItemSmallItemGrid(), null, false, null);
		}

		// Token: 0x0603AD41 RID: 240961 RVA: 0x00EEB5AC File Offset: 0x00EE97AC
		public void SetReceiveClickCallback(Action callback)
		{
			this.ReceiveClickCallback = callback;
		}

		// Token: 0x0603AD42 RID: 240962 RVA: 0x00EEB5B5 File Offset: 0x00EE97B5
		private void OnClickReceive()
		{
			Action receiveClickCallback = this.ReceiveClickCallback;
			if (receiveClickCallback == null)
			{
				return;
			}
			receiveClickCallback();
		}

		// Token: 0x0603AD43 RID: 240963 RVA: 0x00EEB5C8 File Offset: 0x00EE97C8
		public override void Refresh(KurotatoRewardItemData data, bool isSelected, int gridIndex)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.GetTitle(), Array.Empty<object>());
			UUIText text = base.GetText(1);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.Current);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.Target);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			List<TItem> dropPackagePreviewItemList = ConfigBase<RewardConfig>.Instance.GetDropPackagePreviewItemList(data.GetDropId());
			GenericScrollViewNew<CommonItemSmallItemGrid, TItem> rewardScroll = this.RewardScroll;
			if (rewardScroll != null)
			{
				rewardScroll.RefreshByData(dropPackagePreviewItemList, null, false);
			}
			GenericScrollViewNew<CommonItemSmallItemGrid, TItem> rewardScroll2 = this.RewardScroll;
			if (rewardScroll2 != null)
			{
				rewardScroll2.LateScrollToLeft(0);
			}
			bool uiactive = data.Status == EKurotatoRewardStatus.Doing;
			bool uiactive2 = data.Status == EKurotatoRewardStatus.Taken;
			bool uiactive3 = data.Status == EKurotatoRewardStatus.CanReceive;
			UUIText text2 = base.GetText(4);
			if (text2 != null)
			{
				text2.SetUIActive(uiactive);
			}
			UUIButtonComponent button = base.GetButton(5);
			if (button != null)
			{
				UUIItem uuiitem = button.RootUIComp.Get();
				if (uuiitem != null)
				{
					uuiitem.SetUIActive(uiactive3);
				}
			}
			UUISprite sprite = base.GetSprite(6);
			if (sprite != null)
			{
				sprite.SetUIActive(uiactive3);
			}
			UUIItem item = base.GetItem(7);
			if (item != null)
			{
				item.SetUIActive(uiactive3);
			}
			UUIItem item2 = base.GetItem(8);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(uiactive2);
		}

		// Token: 0x040213D2 RID: 136146
		[Nullable(2)]
		private Action ReceiveClickCallback;

		// Token: 0x040213D3 RID: 136147
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScroll;

		// Token: 0x0200BB18 RID: 47896
		[NullableContext(0)]
		private enum EComponents
		{
			// Token: 0x04039BF1 RID: 236529
			TextName,
			// Token: 0x04039BF2 RID: 236530
			TextProgress,
			// Token: 0x04039BF3 RID: 236531
			Scroll,
			// Token: 0x04039BF4 RID: 236532
			GridItem,
			// Token: 0x04039BF5 RID: 236533
			TextDoing,
			// Token: 0x04039BF6 RID: 236534
			BtnReceive,
			// Token: 0x04039BF7 RID: 236535
			SpriteReceive,
			// Token: 0x04039BF8 RID: 236536
			ItemRedDot,
			// Token: 0x04039BF9 RID: 236537
			PanelDone
		}
	}
}
