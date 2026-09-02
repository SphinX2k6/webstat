using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Collect
{
	// Token: 0x02005519 RID: 21785
	[NullableContext(1)]
	[Nullable(0)]
	public class CollectRewardPopup : UiPanelBase
	{
		// Token: 0x0603791E RID: 227614 RVA: 0x00E18EC4 File Offset: 0x00E170C4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(3, new Action(this.OnMaskBtnClick))
			};
		}

		// Token: 0x0603791F RID: 227615 RVA: 0x00E18F57 File Offset: 0x00E17157
		protected override void OnBeforeCreateImplement()
		{
			this.Sequence = new UiBehaviorLevelSequence(this);
			base.AddUiBehavior(this.Sequence);
		}

		// Token: 0x06037920 RID: 227616 RVA: 0x00E18F74 File Offset: 0x00E17174
		protected override void OnStart()
		{
			this.RewardPanel = new GenericLayout<RewardPanelItem, RewardTuple>(base.GetHorizontalLayout(0), new Func<RewardPanelItem>(this.CreateRewardItem), null, false, true);
			this.SetActive(false);
			foreach (Action action in this.OperationMap.Values)
			{
				action();
			}
		}

		// Token: 0x06037921 RID: 227617 RVA: 0x00E18FF4 File Offset: 0x00E171F4
		protected override UniTask OnShowAsyncImplementImplement()
		{
			CollectRewardPopup.<OnShowAsyncImplementImplement>d__7 <OnShowAsyncImplementImplement>d__;
			<OnShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnShowAsyncImplementImplement>d__.<>4__this = this;
			<OnShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnShowAsyncImplementImplement>d__.<>t__builder.Start<CollectRewardPopup.<OnShowAsyncImplementImplement>d__7>(ref <OnShowAsyncImplementImplement>d__);
			return <OnShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06037922 RID: 227618 RVA: 0x00E19038 File Offset: 0x00E17238
		protected override UniTask OnHideAsyncImplementImplement()
		{
			CollectRewardPopup.<OnHideAsyncImplementImplement>d__8 <OnHideAsyncImplementImplement>d__;
			<OnHideAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnHideAsyncImplementImplement>d__.<>4__this = this;
			<OnHideAsyncImplementImplement>d__.<>1__state = -1;
			<OnHideAsyncImplementImplement>d__.<>t__builder.Start<CollectRewardPopup.<OnHideAsyncImplementImplement>d__8>(ref <OnHideAsyncImplementImplement>d__);
			return <OnHideAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06037923 RID: 227619 RVA: 0x00E1907B File Offset: 0x00E1727B
		protected override void OnBeforeDestroy()
		{
			this.RewardPanel.ClearChildren();
			this.RewardPanel = null;
			this.PopUpData = null;
			this.OperationMap.Clear();
		}

		// Token: 0x06037924 RID: 227620 RVA: 0x00E190A4 File Offset: 0x00E172A4
		public void Refresh(RewardPopupData data)
		{
			Action action = delegate()
			{
				if (this.PopUpData.RewardLists.Count == 0)
				{
					return;
				}
				FVector fvector = this.PopUpData.MountItem.GetLGUISpaceAbsolutePosition();
				if (this.PopUpData.PosBias != null)
				{
					FVector value = this.PopUpData.PosBias.Value;
					fvector = fvector + value;
				}
				base.GetItem(2).SetLGUISpaceAbsolutePosition(fvector);
				this.RewardPanel.RefreshByDataAsync(this.PopUpData.RewardLists, false, null).ContinueWith(delegate()
				{
					this.SetActive(true);
				});
			};
			this.PopUpData = data;
			if (base.InAsyncLoading())
			{
				this.OperationMap["Refresh"] = action;
				return;
			}
			action();
		}

		// Token: 0x06037925 RID: 227621 RVA: 0x00E190E5 File Offset: 0x00E172E5
		private RewardPanelItem CreateRewardItem()
		{
			return new RewardPanelItem();
		}

		// Token: 0x06037926 RID: 227622 RVA: 0x00E190EC File Offset: 0x00E172EC
		private void OnMaskBtnClick()
		{
			this.SetActive(false);
		}

		// Token: 0x0401FDD9 RID: 130521
		private GenericLayout<RewardPanelItem, RewardTuple> RewardPanel;

		// Token: 0x0401FDDA RID: 130522
		private RewardPopupData PopUpData;

		// Token: 0x0401FDDB RID: 130523
		private readonly Dictionary<string, Action> OperationMap = new Dictionary<string, Action>();

		// Token: 0x0401FDDC RID: 130524
		private UiBehaviorLevelSequence Sequence;

		// Token: 0x0200B4A8 RID: 46248
		[NullableContext(0)]
		private static class EPopupComponents
		{
			// Token: 0x04037EC9 RID: 229065
			public const int PanelLayout = 0;

			// Token: 0x04037ECA RID: 229066
			public const int RewardItem = 1;

			// Token: 0x04037ECB RID: 229067
			public const int Panel = 2;

			// Token: 0x04037ECC RID: 229068
			public const int MaskBtn = 3;
		}
	}
}
