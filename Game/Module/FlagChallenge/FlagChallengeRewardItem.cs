using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D6D RID: 23917
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class FlagChallengeRewardItem : GridProxyAbstract<FlagChallengeTaskData>
	{
		// Token: 0x0603C40D RID: 246797 RVA: 0x00F496E4 File Offset: 0x00F478E4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(8, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(7, new Action(this.OnReceiveClick))
			};
		}

		// Token: 0x0603C40E RID: 246798 RVA: 0x00F497E5 File Offset: 0x00F479E5
		protected override void OnStart()
		{
			this.ItemListScrollView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(5), () => new CommonItemSmallItemGrid(), null, false, null);
		}

		// Token: 0x0603C40F RID: 246799 RVA: 0x00F4981B File Offset: 0x00F47A1B
		protected override void OnBeforeDestroy()
		{
			this.ReceiveCallback = null;
		}

		// Token: 0x0603C410 RID: 246800 RVA: 0x00F49824 File Offset: 0x00F47A24
		public override void Refresh(FlagChallengeTaskData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			if (this.Data == null)
			{
				return;
			}
			base.GetButton(0).GetRootComponent().SetUIActive(false);
			base.GetButton(7).GetRootComponent().SetUIActive(data.CanReceiveReward());
			base.GetText(1).SetUIActive(!data.CanReceiveReward() && !data.IsTaskReceived());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), data.GetRewardName(), Array.Empty<object>());
			base.GetItem(6).SetUIActive(false);
			base.GetItem(3).SetUIActive(data.IsTaskReceived());
			base.GetSprite(2).SetUIActive(data.IsTaskReceived());
			base.GetText(8).SetText(data.GetProgressText(), true);
			this.ItemListScrollView.RefreshByData(data.GetRewardList(), null, false);
		}

		// Token: 0x0603C411 RID: 246801 RVA: 0x00F498FD File Offset: 0x00F47AFD
		public void SetReceiveCallback(Action<FlagChallengeTaskData> callback)
		{
			this.ReceiveCallback = callback;
		}

		// Token: 0x0603C412 RID: 246802 RVA: 0x00F49906 File Offset: 0x00F47B06
		private void OnReceiveClick()
		{
			Action<FlagChallengeTaskData> receiveCallback = this.ReceiveCallback;
			if (receiveCallback == null)
			{
				return;
			}
			receiveCallback(this.Data);
		}

		// Token: 0x04021DF1 RID: 138737
		[Nullable(2)]
		private FlagChallengeTaskData Data;

		// Token: 0x04021DF2 RID: 138738
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> ItemListScrollView;

		// Token: 0x04021DF3 RID: 138739
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<FlagChallengeTaskData> ReceiveCallback;
	}
}
