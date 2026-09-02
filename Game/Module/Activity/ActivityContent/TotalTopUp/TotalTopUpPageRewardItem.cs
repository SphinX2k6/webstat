using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x02006282 RID: 25218
	public class TotalTopUpPageRewardItem : UiPanelBase
	{
		// Token: 0x0603F7F5 RID: 260085 RVA: 0x01047AA4 File Offset: 0x01045CA4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUITexture)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickReward))
			};
		}

		// Token: 0x0603F7F6 RID: 260086 RVA: 0x01047B8F File Offset: 0x01045D8F
		protected override void OnStart()
		{
			UUIItem item = base.GetItem(7);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x0603F7F7 RID: 260087 RVA: 0x01047BA4 File Offset: 0x01045DA4
		[NullableContext(1)]
		public void Refresh(TotalTopUpPageRewardViewModel viewModel)
		{
			this.ViewModel = viewModel;
			UUIText text = base.GetText(5);
			if (text != null)
			{
				text.SetText("x" + viewModel.RewardCount.ToString(), true);
			}
			UUIText text2 = base.GetText(4);
			if (text2 != null)
			{
				text2.SetText(viewModel.Score.ToString(), true);
			}
			bool flag = viewModel.State == ETotalTopUpRewardState.CanClaim;
			bool uiactive = viewModel.State == ETotalTopUpRewardState.Claimed;
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(uiactive);
			}
			UUIItem item2 = base.GetItem(7);
			if (item2 != null)
			{
				item2.SetUIActive(flag);
			}
			UUIItem item3 = base.GetItem(6);
			bool uiactive2 = viewModel.ShowCheckItem && !flag;
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(uiactive2);
		}

		// Token: 0x0603F7F8 RID: 260088 RVA: 0x01047C60 File Offset: 0x01045E60
		private void OnClickReward()
		{
			if (this.ViewModel == null)
			{
				return;
			}
			if (this.ViewModel.State == ETotalTopUpRewardState.CanClaim)
			{
				this.ViewModel.Claim();
				return;
			}
			this.ViewModel.PreviewReward();
		}

		// Token: 0x04023A51 RID: 146001
		[Nullable(2)]
		private TotalTopUpPageRewardViewModel ViewModel;

		// Token: 0x0200C367 RID: 50023
		private class ENode
		{
			// Token: 0x0403C374 RID: 246644
			public const int BtnReward = 0;

			// Token: 0x0403C375 RID: 246645
			public const int ItemNormalPanel = 1;

			// Token: 0x0403C376 RID: 246646
			public const int ItemClaimedPanel = 2;

			// Token: 0x0403C377 RID: 246647
			public const int TextureIcon = 3;

			// Token: 0x0403C378 RID: 246648
			public const int TextScore = 4;

			// Token: 0x0403C379 RID: 246649
			public const int TextRewardCount = 5;

			// Token: 0x0403C37A RID: 246650
			public const int ItemCheckIcon = 6;

			// Token: 0x0403C37B RID: 246651
			public const int ItemRedDot = 7;
		}
	}
}
