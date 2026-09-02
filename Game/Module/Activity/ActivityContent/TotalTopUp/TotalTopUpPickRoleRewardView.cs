using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x02006287 RID: 25223
	[NullableContext(2)]
	[Nullable(0)]
	public class TotalTopUpPickRoleRewardView : UiViewBase
	{
		// Token: 0x0603F806 RID: 260102 RVA: 0x01047FC1 File Offset: 0x010461C1
		[NullableContext(1)]
		public TotalTopUpPickRoleRewardView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603F807 RID: 260103 RVA: 0x01047FCC File Offset: 0x010461CC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(5, new Action(this.OnClickConfirmButton))
			};
		}

		// Token: 0x0603F808 RID: 260104 RVA: 0x0104808C File Offset: 0x0104628C
		protected override UniTask OnBeforeStartAsync()
		{
			TotalTopUpPickRoleRewardView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TotalTopUpPickRoleRewardView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F809 RID: 260105 RVA: 0x010480CF File Offset: 0x010462CF
		protected override void OnStart()
		{
			TotalTopUpPickRoleChoicePanel choicePanel = this.ChoicePanel;
			if (choicePanel == null)
			{
				return;
			}
			TotalTopUpPickRoleViewModel viewModel = this.ViewModel;
			choicePanel.SelectItem((viewModel != null) ? viewModel.FirstCanClaimIndex : 0);
		}

		// Token: 0x0603F80A RID: 260106 RVA: 0x010480F3 File Offset: 0x010462F3
		private void OnClickedCloseButton()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603F80B RID: 260107 RVA: 0x010480FC File Offset: 0x010462FC
		private void OnClickConfirmButton()
		{
			TotalTopUpPickRoleViewModel viewModel = this.ViewModel;
			if (viewModel == null)
			{
				return;
			}
			viewModel.Claim(delegate
			{
				base.CloseMe(null);
			});
		}

		// Token: 0x0603F80C RID: 260108 RVA: 0x0104811A File Offset: 0x0104631A
		[NullableContext(1)]
		private void OnSelectItemCallback(ITotalTopUpPickRoleRewardItemData data)
		{
			TotalTopUpPickRoleViewModel viewModel = this.ViewModel;
			if (viewModel != null)
			{
				viewModel.SelectItem(data.Index);
			}
			this.Refresh();
		}

		// Token: 0x0603F80D RID: 260109 RVA: 0x0104813C File Offset: 0x0104633C
		private void Refresh()
		{
			if (this.ViewModel == null)
			{
				return;
			}
			bool canClaim = this.ViewModel.CanClaim;
			base.GetItem(4).SetUIActive(!canClaim);
			base.GetButton(5).RootUIComp.Get().SetUIActive(canClaim);
			base.GetItem(1).SetUIActive(this.ViewModel.IsRole);
			base.GetItem(2).SetUIActive(!this.ViewModel.IsRole);
			TotalTopUpPickRoleRolePanel rolePanel = this.RolePanel;
			if (rolePanel != null)
			{
				rolePanel.Refresh(this.ViewModel);
			}
			TotalTopUpPickRoleItemPanel itemPanel = this.ItemPanel;
			if (itemPanel == null)
			{
				return;
			}
			itemPanel.Refresh(this.ViewModel);
		}

		// Token: 0x04023A59 RID: 146009
		private TotalTopUpPickRoleViewModel ViewModel;

		// Token: 0x04023A5A RID: 146010
		private PopupCaptionItem CaptionItem;

		// Token: 0x04023A5B RID: 146011
		private TotalTopUpPickRoleChoicePanel ChoicePanel;

		// Token: 0x04023A5C RID: 146012
		private TotalTopUpPickRoleRolePanel RolePanel;

		// Token: 0x04023A5D RID: 146013
		private TotalTopUpPickRoleItemPanel ItemPanel;
	}
}
