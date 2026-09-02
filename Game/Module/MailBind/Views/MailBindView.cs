using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.MailBind.Views
{
	// Token: 0x020059FB RID: 23035
	[NullableContext(2)]
	[Nullable(0)]
	public class MailBindView : UiViewBase
	{
		// Token: 0x0603A5B5 RID: 239029 RVA: 0x00ECBE75 File Offset: 0x00ECA075
		[NullableContext(1)]
		public MailBindView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603A5B6 RID: 239030 RVA: 0x00ECBE80 File Offset: 0x00ECA080
		protected override UniTask OnCreateAsync()
		{
			MailBindView.<OnCreateAsync>d__8 <OnCreateAsync>d__;
			<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnCreateAsync>d__.<>1__state = -1;
			<OnCreateAsync>d__.<>t__builder.Start<MailBindView.<OnCreateAsync>d__8>(ref <OnCreateAsync>d__);
			return <OnCreateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A5B7 RID: 239031 RVA: 0x00ECBEBC File Offset: 0x00ECA0BC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(7, new Action(this.OnRewardButtonClick))
			};
		}

		// Token: 0x0603A5B8 RID: 239032 RVA: 0x00ECBFA8 File Offset: 0x00ECA1A8
		protected override UniTask OnBeforeStartAsync()
		{
			MailBindView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MailBindView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A5B9 RID: 239033 RVA: 0x00ECBFEC File Offset: 0x00ECA1EC
		protected override void OnStart()
		{
			string textId = this.IsGlobalSdk ? "Mail_Activity_Function_Entry02" : "Mail_Activity_Function_Entry01";
			this.CaptionItem.SetTitleByTextIdAndArgNew(textId, Array.Empty<object>());
			this.CaptionItem.SetCloseCallBack(new Action(this.OnBackBtnClick));
			PopupCaptionItem captionItem = this.CaptionItem;
			if (captionItem != null)
			{
				captionItem.SetHelpCallBack(new Action(this.OnHelpButtonClick));
			}
			string titleIconByResourceId = this.IsGlobalSdk ? "SP_MailBindIcon" : "SP_KuroStreetIcon";
			this.CaptionItem.SetTitleIconByResourceId(titleIconByResourceId);
			string textId2 = this.IsGlobalSdk ? "Mail_Activity_Title02" : "Mail_Activity_Title";
			this.TitleComponent.SetTitleByTextId(textId2, Array.Empty<string>());
			this.TitleComponent.SetSubTitleVisible(false);
			string textId3 = this.IsGlobalSdk ? "Mail_Activity_Desc02" : "Mail_Activity_Desc01";
			this.DescriptionComponent.SetContentByTextId(textId3, Array.Empty<string>());
			int? intConfig = ConfigCommonParamById.GetIntConfig("MailBindReward");
			if (intConfig == null)
			{
				return;
			}
			List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(intConfig.Value);
			this.RewardListComponent.InitGridLayout(new Func<CommonItemSmallItemGrid>(this.RewardListComponent.InitCommonGridItem));
			this.RewardListComponent.RefreshItemLayout(dropPackagePreviewItemList, null);
			string textId4 = this.IsGlobalSdk ? "Mail_Activity_Binding" : "Mail_Activity_Login";
			this.FunctionalComponent.FunctionButton.SetFunction(new Action(this.OnGotoMailBindBtnClick));
			this.FunctionalComponent.FunctionButton.SetLocalTextNew(textId4, Array.Empty<object>());
			string textId5 = this.IsGlobalSdk ? "Mail_Activity_Finish02" : "Mail_Activity_Finish01";
			this.FunctionalComponent.SetActivateTextByTextId(textId5, Array.Empty<string>());
			ControllerBase<MailBindController>.Instance.RecordMailBindNextShowRedDotTime();
		}

		// Token: 0x0603A5BA RID: 239034 RVA: 0x00ECC19B File Offset: 0x00ECA39B
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnMailBindInfoNotify, new Action(this.OnMailBindInfoNotify));
		}

		// Token: 0x0603A5BB RID: 239035 RVA: 0x00ECC1B9 File Offset: 0x00ECA3B9
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMailBindInfoNotify, new Action(this.OnMailBindInfoNotify));
		}

		// Token: 0x0603A5BC RID: 239036 RVA: 0x00ECC1D7 File Offset: 0x00ECA3D7
		protected override void OnBeforeShow()
		{
			this.Refresh();
		}

		// Token: 0x0603A5BD RID: 239037 RVA: 0x00ECC1DF File Offset: 0x00ECA3DF
		private void OnGotoMailBindBtnClick()
		{
			ControllerBase<MailBindController>.Instance.MailBindRequest();
			if (this.IsGlobalSdk)
			{
				ControllerBase<KuroSdkController>.Instance.PostKuroSdkEvent(EKuroSdkEventKey.KuroOpenUserCenter);
			}
			else
			{
				ControllerBase<ChannelController>.Instance.OpenKuroStreet();
			}
			ControllerBase<MailBindController>.Instance.RecordMailBindJumpToWebView();
		}

		// Token: 0x0603A5BE RID: 239038 RVA: 0x00ECC215 File Offset: 0x00ECA415
		private void OnBackBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603A5BF RID: 239039 RVA: 0x00ECC21E File Offset: 0x00ECA41E
		private void OnRewardButtonClick()
		{
			ControllerBase<MailBindController>.Instance.MailBindRewardRequest();
		}

		// Token: 0x0603A5C0 RID: 239040 RVA: 0x00ECC22C File Offset: 0x00ECA42C
		private void OnHelpButtonClick()
		{
			int? intConfig = ConfigCommonParamById.GetIntConfig(this.IsGlobalSdk ? "Mail_Activity_HelpId02" : "Mail_Activity_HelpId01");
			if (intConfig == null)
			{
				return;
			}
			ControllerBase<HelpController>.Instance.OpenHelpById(intConfig.Value);
		}

		// Token: 0x0603A5C1 RID: 239041 RVA: 0x00ECC26E File Offset: 0x00ECA46E
		private void OnMailBindInfoNotify()
		{
			this.Refresh();
		}

		// Token: 0x0603A5C2 RID: 239042 RVA: 0x00ECC276 File Offset: 0x00ECA476
		public void Refresh()
		{
			this.RefreshTimerText();
			this.RefreshState();
		}

		// Token: 0x0603A5C3 RID: 239043 RVA: 0x00ECC284 File Offset: 0x00ECA484
		private void RefreshTimerText()
		{
			MailBindModel instance = ModelBase<MailBindModel>.Instance;
			bool flag = this.IsGlobalSdk && instance.GetIsReward();
			this.TitleComponent.SetTimeTextVisible(flag);
			if (flag)
			{
				string timeTextByText = instance.GetRemainTimeText(instance.GetCloseTime()) ?? "";
				this.TitleComponent.SetTimeTextByText(timeTextByText);
			}
		}

		// Token: 0x0603A5C4 RID: 239044 RVA: 0x00ECC2DC File Offset: 0x00ECA4DC
		private void RefreshState()
		{
			EMailBindState state = ModelBase<MailBindModel>.Instance.GetState();
			UUIItem item = base.GetItem(6);
			if (item != null)
			{
				item.SetUIActive(state == EMailBindState.NotBind);
			}
			UUIButtonComponent button = base.GetButton(7);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(state == EMailBindState.CanReward);
			}
			UUIItem item2 = base.GetItem(5);
			if (item2 != null)
			{
				item2.SetUIActive(state == EMailBindState.HasReward);
			}
			this.FunctionalComponent.SetLockConditionButtonVisible(false);
			this.FunctionalComponent.SetActivatePanelConditionVisible(state > EMailBindState.NotBind);
			ActivityButtonItem functionButton = this.FunctionalComponent.FunctionButton;
			if (functionButton == null)
			{
				return;
			}
			functionButton.SetUiActive(state == EMailBindState.NotBind);
		}

		// Token: 0x040210B6 RID: 135350
		private ActivityTitleTypeA TitleComponent;

		// Token: 0x040210B7 RID: 135351
		private ActivityDescriptionTypeA DescriptionComponent;

		// Token: 0x040210B8 RID: 135352
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;

		// Token: 0x040210B9 RID: 135353
		private ActivityFunctionalTypeA FunctionalComponent;

		// Token: 0x040210BA RID: 135354
		private PopupCaptionItem CaptionItem;

		// Token: 0x040210BB RID: 135355
		private bool IsGlobalSdk;

		// Token: 0x0200B9C8 RID: 47560
		[NullableContext(0)]
		private enum EComponents
		{
			// Token: 0x0403967F RID: 235135
			TitleItem,
			// Token: 0x04039680 RID: 235136
			DescriptionItem,
			// Token: 0x04039681 RID: 235137
			RewardListItem,
			// Token: 0x04039682 RID: 235138
			FunctionAreaItem,
			// Token: 0x04039683 RID: 235139
			CaptionItem,
			// Token: 0x04039684 RID: 235140
			HasRewardItem,
			// Token: 0x04039685 RID: 235141
			UnDoneItem,
			// Token: 0x04039686 RID: 235142
			ReceiveButton
		}
	}
}
