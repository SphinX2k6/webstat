using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Mail;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002228 RID: 8744
[NullableContext(1)]
[Nullable(0)]
public class MailBoxView : UiViewBase
{
	// Token: 0x06010822 RID: 67618 RVA: 0x00482769 File Offset: 0x00480969
	public MailBoxView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06010823 RID: 67619 RVA: 0x0048277C File Offset: 0x0048097C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 23;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIDynScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
	}

	// Token: 0x06010824 RID: 67620 RVA: 0x00482AB4 File Offset: 0x00480CB4
	protected override UniTask OnBeforeStartAsync()
	{
		MailBoxView.<OnBeforeStartAsync>d__20 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MailBoxView.<OnBeforeStartAsync>d__20>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010825 RID: 67621 RVA: 0x00482AF8 File Offset: 0x00480CF8
	protected override void OnStart()
	{
		this.InitCaptionUiStyle();
		this.InitLinkButtonObj();
		this.InitFavoriteToggle();
		this.InitAttachmentList();
		this.InitDropDownList();
		this.InitMailOpButtonObj();
		this.DeleteAllReadButton = new ButtonAndTextItem(base.GetItem(5));
		this.DeleteAllReadButton.BindCallback(new Action(this.DeleteAllExhaustedMail));
		this.DeleteAllReadButton.RefreshText("DeleteReadedMail", Array.Empty<object>());
		this.ReceiveAllRewardButton = new ButtonAndTextItem(base.GetItem(4));
		this.ReceiveAllRewardButton.BindCallback(new Action(this.PickAllAccessibleAttachment));
		this.ReceiveAllRewardButton.RefreshText("GetAllItem", Array.Empty<object>());
		this.MailSwitchSequence = new LevelSequencePlayer(this.RootItem);
		Singleton<Log>.Instance.Info(ELogModule.Mail, ELogAuthor.YZY, "邮件界面：OnStartFinish", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06010826 RID: 67622 RVA: 0x00482BD4 File Offset: 0x00480DD4
	protected override void OnBeforeShow()
	{
		this.RefreshInsufficientSpaceTip();
		ModelBase<MailModel>.Instance.ReloadMailList();
		EMailFilter[] filterTypeList = ConfigBase<MailConfig>.Instance.GetFilterTypeList();
		int defaultIndex = Math.Max(0, Array.IndexOf<EMailFilter>(filterTypeList, this.CurrentFilterState));
		if (this.CurrentMailDataList != null && this.SelectedMailData != null)
		{
			this.DropDownList.RefreshAllDropDownItem();
			MailDropDownItem mailDropDownItem = this.DropDownList.GetDropDownItemObject(this.DropDownList.GetSelectedIndex()) as MailDropDownItem;
			string selectedMailId = this.SelectedMailData.Id;
			this.CurrentMailDataList = mailDropDownItem.GetFilteredMailList().ToList<MailData>();
			int num = this.CurrentMailDataList.FindIndex((MailData mail) => mail.Id == selectedMailId);
			num = ((num >= 0) ? num : 0);
			this.RefreshMailScrollList(this.CurrentMailDataList, num);
			return;
		}
		this.DropDownList.InitScroll(filterTypeList, new Func<EMailFilter, MailFilter>(this.GetMailFilterConfigData), defaultIndex, true);
	}

	// Token: 0x06010827 RID: 67623 RVA: 0x00482CC4 File Offset: 0x00480EC4
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<string, int>(EEventName.SelectedMail, new Action<string, int>(this.CallBackSelected));
		Singleton<EventSystem>.Instance.Add<EMailAttachmentPickType>(EEventName.PickingAttachment, new Action<EMailAttachmentPickType>(this.CallBackPickMailView));
		Singleton<EventSystem>.Instance.Add<string, bool>(EEventName.MailFavoriteChanged, new Action<string, bool>(this.CallBackMailFavoriteChanged));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<string>>(EEventName.DeletingMail, new Action<IReadOnlyList<string>>(this.CallBackDeleteMailView));
		Singleton<EventSystem>.Instance.Add(EEventName.DeletingMailPassively, new Action(this.CallBackPassivelyDeleteMailView));
		Singleton<EventSystem>.Instance.Add(EEventName.AddingNewMail, new Action(this.CallBackAddMailView));
	}

	// Token: 0x06010828 RID: 67624 RVA: 0x00482D7C File Offset: 0x00480F7C
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.SelectedMail, new Action<string, int>(this.CallBackSelected));
		Singleton<EventSystem>.Instance.Remove(EEventName.PickingAttachment, new Action<EMailAttachmentPickType>(this.CallBackPickMailView));
		Singleton<EventSystem>.Instance.Remove(EEventName.MailFavoriteChanged, new Action<string, bool>(this.CallBackMailFavoriteChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.DeletingMail, new Action<IReadOnlyList<string>>(this.CallBackDeleteMailView));
		Singleton<EventSystem>.Instance.Remove(EEventName.DeletingMailPassively, new Action(this.CallBackPassivelyDeleteMailView));
		Singleton<EventSystem>.Instance.Remove(EEventName.AddingNewMail, new Action(this.CallBackAddMailView));
	}

	// Token: 0x06010829 RID: 67625 RVA: 0x00482E34 File Offset: 0x00481034
	protected override void OnBeforeDestroy()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(22);
		if (extendToggle != null)
		{
			extendToggle.OnStateChange.Remove(new Action<EToggleState>(this.OnFavoriteToggleStateChanged));
		}
		PopupCaptionItem caption = this.Caption;
		if (caption != null)
		{
			caption.Destroy(null);
		}
		CommonDropDown<MailFilter, EMailFilter> dropDownList = this.DropDownList;
		if (dropDownList != null)
		{
			dropDownList.Destroy(null);
		}
		MailLinkButton linkButton = this.LinkButton;
		if (linkButton != null)
		{
			linkButton.Destroy(null);
		}
		this.MailLoopScrollList.ClearChildren();
		this.MailSwitchSequence.Clear();
	}

	// Token: 0x0601082A RID: 67626 RVA: 0x00482EB4 File Offset: 0x004810B4
	private void InitCaptionUiStyle()
	{
		this.Caption = new PopupCaptionItem(base.GetItem(0));
		this.Caption.SetHelpBtnActive(true);
		this.Caption.SetCloseBtnActive(true);
		this.Caption.SetCloseCallBack(new Action(this.OnClickClose));
		this.Caption.SetTitle(ConfigBase<TextConfig>.Instance.GetTextById("Mail") ?? "");
	}

	// Token: 0x0601082B RID: 67627 RVA: 0x00482F25 File Offset: 0x00481125
	private void InitDropDownList()
	{
		this.DropDownList.SetOnSelectCall(new Action<int, EMailFilter>(this.OnSelectDropItem));
	}

	// Token: 0x0601082C RID: 67628 RVA: 0x00482F40 File Offset: 0x00481140
	private UniTask InitMailScrollView()
	{
		MailBoxView.<InitMailScrollView>d__28 <InitMailScrollView>d__;
		<InitMailScrollView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitMailScrollView>d__.<>4__this = this;
		<InitMailScrollView>d__.<>1__state = -1;
		<InitMailScrollView>d__.<>t__builder.Start<MailBoxView.<InitMailScrollView>d__28>(ref <InitMailScrollView>d__);
		return <InitMailScrollView>d__.<>t__builder.Task;
	}

	// Token: 0x0601082D RID: 67629 RVA: 0x00482F83 File Offset: 0x00481183
	private MailScrollItemNew OnItemCreate(MailData data, UUIItem uiItem, int index)
	{
		MailScrollItemNew mailScrollItemNew = new MailScrollItemNew();
		mailScrollItemNew.BindSelectCall(new Action<int, MailData>(this.OnSelectMailItem));
		mailScrollItemNew.BindGetSelectedIndexFunction(new Func<int>(this.GetSelectedIndex));
		mailScrollItemNew.BindFavoriteClickCall(new Action<int, MailData>(this.OnListMailFavoriteClick));
		return mailScrollItemNew;
	}

	// Token: 0x0601082E RID: 67630 RVA: 0x00482FC0 File Offset: 0x004811C0
	private void InitLinkButtonObj()
	{
		this.LinkButton = new MailLinkButton(base.GetItem(14));
		this.LinkButton.ClickDelegate = new Action(this.OnClickLink);
		base.GetItem(14).SetUIActive(false);
	}

	// Token: 0x0601082F RID: 67631 RVA: 0x00482FFC File Offset: 0x004811FC
	private void InitFavoriteToggle()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(22);
		extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		UUIItem uuiitem = extendToggle.RootUIComp.Get();
		if (uuiitem != null)
		{
			uuiitem.SetUIActive(false);
		}
		extendToggle.OnStateChange.Add(new Action<EToggleState>(this.OnFavoriteToggleStateChanged));
	}

	// Token: 0x06010830 RID: 67632 RVA: 0x0048304C File Offset: 0x0048124C
	private void RefreshFavoriteToggle(MailData mailData)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(22);
		bool flag = mailData.CanShowFavoriteControl();
		UUIItem uuiitem = extendToggle.RootUIComp.Get();
		if (uuiitem != null)
		{
			uuiitem.SetUIActive(flag);
		}
		if (flag)
		{
			extendToggle.SetToggleState(mailData.IsFavorite ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}
	}

	// Token: 0x06010831 RID: 67633 RVA: 0x0048309C File Offset: 0x0048129C
	private void RefreshInsufficientSpaceTip()
	{
		bool flag = this.CurrentFilterState == EMailFilter.FilterAll && ModelBase<MailModel>.Instance.IsMailSpaceNearFull();
		base.GetItem(23).SetUIActive(flag);
		if (flag)
		{
			UUIText insufficientTipText = this.GetInsufficientTipText();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(insufficientTipText, "Text_MailMaxTips_Text", Array.Empty<object>());
		}
	}

	// Token: 0x06010832 RID: 67634 RVA: 0x004830F0 File Offset: 0x004812F0
	private UUIText GetInsufficientTipText()
	{
		if (this.InsufficientTipText != null)
		{
			return this.InsufficientTipText;
		}
		UUIItem item = base.GetItem(23);
		if (item == null)
		{
			return null;
		}
		AActor owner = item.GetOwner();
		UUIText uuitext = ((owner != null) ? owner.GetComponentByClass(UUIText.StaticClass()) : null) as UUIText;
		if (uuitext != null)
		{
			this.InsufficientTipText = uuitext;
			return uuitext;
		}
		int num = item.GetAttachUIChildren().Num();
		for (int i = 0; i < num; i++)
		{
			UUIItem attachUIChild = item.GetAttachUIChild(i);
			object obj;
			if (attachUIChild == null)
			{
				obj = null;
			}
			else
			{
				AActor owner2 = attachUIChild.GetOwner();
				obj = ((owner2 != null) ? owner2.GetComponentByClass(UUIText.StaticClass()) : null);
			}
			UUIText uuitext2 = obj as UUIText;
			if (uuitext2 != null)
			{
				this.InsufficientTipText = uuitext2;
				return uuitext2;
			}
		}
		return null;
	}

	// Token: 0x06010833 RID: 67635 RVA: 0x004831A0 File Offset: 0x004813A0
	private void RefreshEmptyTipText()
	{
		UUIText emptyTipText = this.GetEmptyTipText();
		if (emptyTipText == null)
		{
			return;
		}
		string textStringId = (this.CurrentFilterState == EMailFilter.FilterFavorite) ? "Text_NoCollectedMail_Text" : "Text_NoMail_Text";
		Singleton<LguiUtil>.Instance.SetLocalTextNew(emptyTipText, textStringId, Array.Empty<object>());
	}

	// Token: 0x06010834 RID: 67636 RVA: 0x004831E0 File Offset: 0x004813E0
	private UUIText GetEmptyTipText()
	{
		if (this.EmptyTipText != null)
		{
			return this.EmptyTipText;
		}
		UUIItem item = base.GetItem(21);
		if (item == null)
		{
			return null;
		}
		AActor owner = item.GetOwner();
		UUIText uuitext = ((owner != null) ? owner.GetComponentByClass(UUIText.StaticClass()) : null) as UUIText;
		if (uuitext != null)
		{
			this.EmptyTipText = uuitext;
			return uuitext;
		}
		int num = item.GetAttachUIChildren().Num();
		for (int i = 0; i < num; i++)
		{
			UUIItem attachUIChild = item.GetAttachUIChild(i);
			object obj;
			if (attachUIChild == null)
			{
				obj = null;
			}
			else
			{
				AActor owner2 = attachUIChild.GetOwner();
				obj = ((owner2 != null) ? owner2.GetComponentByClass(UUIText.StaticClass()) : null);
			}
			UUIText uuitext2 = obj as UUIText;
			if (uuitext2 != null)
			{
				this.EmptyTipText = uuitext2;
				return uuitext2;
			}
		}
		return null;
	}

	// Token: 0x06010835 RID: 67637 RVA: 0x00483290 File Offset: 0x00481490
	private void RequestMailFavoriteForMail(MailData mail, bool isFavorite, Action onFailed = null)
	{
		if (isFavorite && !mail.IsFavorite && ModelBase<MailModel>.Instance.IsFavoriteMailFull())
		{
			MailController.ShowMailFloatTipsByTextKey("Text_CollectedMailMaxTips_Text");
			Action onFailed2 = onFailed;
			if (onFailed2 == null)
			{
				return;
			}
			onFailed2();
			return;
		}
		else
		{
			if (!isFavorite && mail.NeedExpiredUnfavoriteConfirm())
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ExpiredFavoriteMailUnfavoriteConfirm);
				confirmBoxDataNew.FunctionMap[1] = delegate()
				{
					Action onFailed3 = onFailed;
					if (onFailed3 == null)
					{
						return;
					}
					onFailed3();
				};
				confirmBoxDataNew.FunctionMap[2] = delegate()
				{
					MailController.RequestMailFavorite(mail.Id, false, onFailed, null);
				};
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			MailController.RequestMailFavorite(mail.Id, isFavorite, onFailed, null);
			return;
		}
	}

	// Token: 0x06010836 RID: 67638 RVA: 0x00483358 File Offset: 0x00481558
	private void OnFavoriteToggleStateChanged(EToggleState state)
	{
		if (this.SelectedMailData == null)
		{
			return;
		}
		bool flag = state == EToggleState.ETT_Checked;
		EToggleState rollbackState = flag ? EToggleState.ETT_UnChecked : EToggleState.ETT_Checked;
		this.RequestMailFavoriteForMail(this.SelectedMailData, flag, delegate
		{
			this.GetExtendToggle(22).SetToggleState(rollbackState, false, false, false);
		});
	}

	// Token: 0x06010837 RID: 67639 RVA: 0x004833A8 File Offset: 0x004815A8
	private void OnListMailFavoriteClick(int index, MailData data)
	{
		bool isFavorite = !data.IsFavorite;
		this.RequestMailFavoriteForMail(data, isFavorite, delegate
		{
			MailData mailInstanceById = ModelBase<MailModel>.Instance.GetMailInstanceById(data.Id);
			if (mailInstanceById != null)
			{
				MailScrollItemNew scrollItemFromIndex = this.MailLoopScrollList.GetScrollItemFromIndex(index);
				if (scrollItemFromIndex == null)
				{
					return;
				}
				scrollItemFromIndex.Update(mailInstanceById, index);
			}
		});
	}

	// Token: 0x06010838 RID: 67640 RVA: 0x004833F8 File Offset: 0x004815F8
	private void CallBackMailFavoriteChanged(string mailId, bool isFavorite)
	{
		this.DropDownList.RefreshAllDropDownItem();
		MailData mailInstanceById = ModelBase<MailModel>.Instance.GetMailInstanceById(mailId);
		if (mailInstanceById == null || this.CurrentMailDataList == null)
		{
			return;
		}
		if (this.CurrentFilterState == EMailFilter.FilterFavorite && !isFavorite)
		{
			MailDropDownItem dropDownItem = this.DropDownList.GetDropDownItemObject(this.DropDownList.GetSelectedIndex()) as MailDropDownItem;
			this.ReloadDisplayMailDataList(dropDownItem, 0);
			int num = Math.Min(this.SelectedMailIndex, Math.Max(0, this.CurrentMailDataList.Count - 1));
			this.RefreshMailScrollList(this.CurrentMailDataList, num);
			this.SelectedMailData = ((num >= 0 && num < this.CurrentMailDataList.Count) ? this.CurrentMailDataList[num] : null);
			if (this.SelectedMailData != null)
			{
				this.OnSelectMailItem(num, this.SelectedMailData);
			}
			return;
		}
		int num2 = this.CurrentMailDataList.FindIndex((MailData mail) => mail.Id == mailId);
		if (num2 >= 0)
		{
			this.CurrentMailDataList[num2] = mailInstanceById;
			MailScrollItemNew scrollItemFromIndex = this.MailLoopScrollList.GetScrollItemFromIndex(num2);
			if (scrollItemFromIndex != null)
			{
				scrollItemFromIndex.Update(mailInstanceById, num2);
			}
		}
		MailData selectedMailData = this.SelectedMailData;
		if (((selectedMailData != null) ? selectedMailData.Id : null) == mailId)
		{
			this.SelectedMailData = mailInstanceById;
			this.RefreshMailValidTime(mailInstanceById);
			this.RefreshFavoriteToggle(mailInstanceById);
			this.RefreshMailOpButtonState(mailInstanceById);
		}
	}

	// Token: 0x06010839 RID: 67641 RVA: 0x0048355C File Offset: 0x0048175C
	private void InitMailOpButtonObj()
	{
		this.MailOpButton = new ButtonAndTextItem(base.GetItem(18));
		this.MailOpButton.BindCallback(new Action(this.OnClickMailOp));
	}

	// Token: 0x0601083A RID: 67642 RVA: 0x00483588 File Offset: 0x00481788
	private void InitAttachmentList()
	{
		this.AttachmentsLayout = new LoopScrollView<CSharpScript.Game.Module.Mail.RewardItem, TItem>(base.GetLoopScrollViewComponent(16), base.GetItem(17).GetOwner() as AUIBaseActor, new Func<CSharpScript.Game.Module.Mail.RewardItem>(this.CreateAttachItem), false);
	}

	// Token: 0x0601083B RID: 67643 RVA: 0x004835BC File Offset: 0x004817BC
	private CSharpScript.Game.Module.Mail.RewardItem CreateAttachItem()
	{
		return new CSharpScript.Game.Module.Mail.RewardItem
		{
			Onwner = this
		};
	}

	// Token: 0x0601083C RID: 67644 RVA: 0x004835CC File Offset: 0x004817CC
	private MailDropDownItem CreateDropDownItemFunc(UUIItem uiItem, EMailFilter type)
	{
		MailDropDownItem result;
		switch (type)
		{
		case EMailFilter.FilterAll:
			result = new MailTotalDropDownItem(uiItem);
			break;
		case EMailFilter.FilterImportant:
			result = new MailImportantDropDownItem(uiItem);
			break;
		case EMailFilter.FilterUnScanned:
			result = new MailUnReadDropDownItem(uiItem);
			break;
		case EMailFilter.FilterFavorite:
			result = new MailFavoriteDropDownItem(uiItem);
			break;
		default:
			result = new MailTotalDropDownItem(uiItem);
			break;
		}
		return result;
	}

	// Token: 0x0601083D RID: 67645 RVA: 0x00483624 File Offset: 0x00481824
	private List<string> GetBatchDeletableMailIds()
	{
		List<MailData> currentMailDataList = this.CurrentMailDataList;
		List<string> list = new List<string>();
		if (this.CurrentFilterState == EMailFilter.FilterImportant)
		{
			using (List<MailData>.Enumerator enumerator = currentMailDataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					MailData mailData = enumerator.Current;
					if (mailData.GetWasScanned() && !mailData.IsFavorite && mailData.GetAttachmentStatus() != EMailAttachment.AttachmentRemained)
					{
						list.Add(mailData.Id);
					}
				}
				return list;
			}
		}
		foreach (MailData mailData2 in currentMailDataList)
		{
			if (mailData2.GetWasScanned() && !mailData2.IsFavorite && mailData2.GetMailLevel() != 2 && mailData2.GetAttachmentStatus() != EMailAttachment.AttachmentRemained)
			{
				list.Add(mailData2.Id);
			}
		}
		return list;
	}

	// Token: 0x0601083E RID: 67646 RVA: 0x00483714 File Offset: 0x00481914
	private void DeleteAllExhaustedMail()
	{
		if (this.CurrentFilterState == EMailFilter.FilterFavorite)
		{
			MailController.ShowMailFloatTipsByTextKey("Text_NoDeletedMailsTips_Text");
			return;
		}
		List<string> deletingMailIds = this.GetBatchDeletableMailIds();
		if (deletingMailIds.Count <= 0)
		{
			MailController.ShowMailFloatTipsByTextKey("Text_NoDeletedMailsTips_Text");
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ScannedMailsBeingDeleted);
		Action value = delegate()
		{
			MailController.RequestDeleteMail(deletingMailIds);
		};
		confirmBoxDataNew.FunctionMap[2] = value;
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0601083F RID: 67647 RVA: 0x00483790 File Offset: 0x00481990
	private void PickAllAccessibleAttachment()
	{
		Singleton<Log>.Instance.Info(ELogModule.Mail, ELogAuthor.YZY, "邮件界面：一键领取", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (this.CurrentFilterState == EMailFilter.FilterFavorite)
		{
			List<string> list = new List<string>();
			foreach (MailData mailData in this.CurrentMailDataList)
			{
				if (mailData.GetAttachmentStatus() == EMailAttachment.AttachmentRemained)
				{
					list.Add(mailData.Id);
				}
			}
			if (list.Count > 0)
			{
				MailController.RequestPickAttachment(list, EMailAttachmentPickType.PickAll);
				return;
			}
			MailController.ShowMailFloatTipsByTextKey("Text_NoRewardMailsTips_Text");
			return;
		}
		else
		{
			List<MailData> mailList = ModelBase<MailModel>.Instance.GetMailList();
			List<string> list2 = new List<string>();
			int num = (this.CurrentFilterState == EMailFilter.FilterImportant) ? 2 : 1;
			foreach (MailData mailData2 in mailList)
			{
				if (mailData2.GetAttachmentStatus() == EMailAttachment.AttachmentRemained && mailData2.Level >= num)
				{
					list2.Add(mailData2.Id);
				}
			}
			if (list2.Count > 0)
			{
				MailController.RequestPickAttachment(list2, EMailAttachmentPickType.PickAll);
				return;
			}
			EMailFilter currentFilterState = this.CurrentFilterState;
			if (currentFilterState == EMailFilter.FilterAll)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("MailClearAllAttachment", Array.Empty<object>());
				return;
			}
			if (currentFilterState != EMailFilter.FilterImportant)
			{
				return;
			}
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("MailClearImportantAttachment", Array.Empty<object>());
			return;
		}
	}

	// Token: 0x06010840 RID: 67648 RVA: 0x00483900 File Offset: 0x00481B00
	private void ClearMailSelection()
	{
		MailScrollItemNew scrollItemFromIndex = this.MailLoopScrollList.GetScrollItemFromIndex(this.SelectedMailIndex);
		if (scrollItemFromIndex != null)
		{
			scrollItemFromIndex.OnDeselected(true);
		}
		this.SelectedMailIndex = -1;
	}

	// Token: 0x06010841 RID: 67649 RVA: 0x00483928 File Offset: 0x00481B28
	private unsafe void RefreshMailScrollList(List<MailData> mailList, int selectedIndex = 0)
	{
		this.ClearMailSelection();
		this.SelectedMailIndex = selectedIndex;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Mail;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "邮件界面：刷新列表 RefreshMailScrollList";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("selectedIndex", selectedIndex);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("mailList长度", (mailList != null) ? new int?(mailList.Count) : null);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		this.MailLoopScrollList.RefreshByData(mailList.ToArray(), false, false);
		if (mailList.Count > 0)
		{
			base.GetItem(20).SetUIActive(true);
			base.GetItem(21).SetUIActive(false);
			this.ReceiveAllRewardButton.SetActive(true);
			this.DeleteAllReadButton.SetActive(this.CurrentFilterState == EMailFilter.FilterAll || this.CurrentFilterState == EMailFilter.FilterFavorite);
			this.ScrollToItemThenRefreshItem(mailList[selectedIndex], selectedIndex);
		}
		else
		{
			base.GetItem(20).SetUIActive(false);
			base.GetItem(21).SetUIActive(true);
			this.RefreshEmptyTipText();
			this.ReceiveAllRewardButton.SetActive(false);
			this.DeleteAllReadButton.SetActive(false);
			this.SelectedMailIndex = 0;
		}
		this.RefreshInsufficientSpaceTip();
	}

	// Token: 0x06010842 RID: 67650 RVA: 0x00483A74 File Offset: 0x00481C74
	private UniTask ScrollToItemThenRefreshItem(MailData data, int selectedIndex)
	{
		MailBoxView.<ScrollToItemThenRefreshItem>d__50 <ScrollToItemThenRefreshItem>d__;
		<ScrollToItemThenRefreshItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ScrollToItemThenRefreshItem>d__.<>4__this = this;
		<ScrollToItemThenRefreshItem>d__.data = data;
		<ScrollToItemThenRefreshItem>d__.selectedIndex = selectedIndex;
		<ScrollToItemThenRefreshItem>d__.<>1__state = -1;
		<ScrollToItemThenRefreshItem>d__.<>t__builder.Start<MailBoxView.<ScrollToItemThenRefreshItem>d__50>(ref <ScrollToItemThenRefreshItem>d__);
		return <ScrollToItemThenRefreshItem>d__.<>t__builder.Task;
	}

	// Token: 0x06010843 RID: 67651 RVA: 0x00483AC8 File Offset: 0x00481CC8
	private void RefreshMailValidTime(MailData selectedMail)
	{
		if (selectedMail.IsFavorite)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), "Text_LastingTimeCollectedMax_Text", Array.Empty<object>());
			return;
		}
		if (selectedMail.GetMailLevel() == 2)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(11), "ForeverValid", Array.Empty<object>());
			return;
		}
		long expiryTime = selectedMail.GetExpiryTime();
		double num = Singleton<TimeUtil>.Instance.CalculateHourGapBetweenNow((double)expiryTime, true);
		double num2 = Singleton<TimeUtil>.Instance.CalculateMinuteGapBetweenNow((double)expiryTime, true);
		if (num >= 24.0)
		{
			int num3 = Singleton<TimeUtil>.Instance.CalculateDayGapBetweenNow((double)expiryTime, true);
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(11), "AfterDayAutoDelete", new <>z__ReadOnlySingleElementList<object>(num3.ToString("F0")));
			return;
		}
		if (num > 1.0)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(11), "AfterTimeAutoDelete", new <>z__ReadOnlySingleElementList<object>(num.ToString("F0")));
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(11), "AfterMinAutoDelete", new <>z__ReadOnlySingleElementList<object>(num2.ToString("F0")));
		if (num2 < 1.0)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(11), "AutoDeleteInOneMinute", Array.Empty<object>());
		}
	}

	// Token: 0x06010844 RID: 67652 RVA: 0x00483C0C File Offset: 0x00481E0C
	private void RefreshMailAttachment(MailData selectedMail)
	{
		List<TItem> list = new List<TItem>();
		foreach (PbMailAttachment pbMailAttachment in selectedMail.GetAttachmentInfo())
		{
			InventoryDefine.IGetItemData itemData = new InventoryDefine.GetItemData(pbMailAttachment.Id, 0);
			list.Add(new TItem(itemData, pbMailAttachment.Count));
		}
		this.AttachmentsLayout.ReloadData(list, false);
		base.GetItem(15).SetUIActive(list.Count > 0);
	}

	// Token: 0x06010845 RID: 67653 RVA: 0x00483C7C File Offset: 0x00481E7C
	private void RefreshMailOpButtonState(MailData data)
	{
		if (data.GetAttachmentStatus() == EMailAttachment.AttachmentRemained)
		{
			this.MailOpButton.RefreshText("GetText", Array.Empty<object>());
			this.MailOpButton.RefreshEnable(true);
			return;
		}
		this.MailOpButton.RefreshText("DeleteText", Array.Empty<object>());
		this.MailOpButton.RefreshEnable(true);
	}

	// Token: 0x06010846 RID: 67654 RVA: 0x00483CD8 File Offset: 0x00481ED8
	private void RefreshMailContentView(MailData data)
	{
		base.GetText(7).SetText(data.Title, true);
		base.GetText(13).SetText(data.GetText(), true);
		base.GetText(13).bBestFit = false;
		base.GetText(8).SetText(data.Sender, true);
		base.GetText(9).SetText(Singleton<TimeUtil>.Instance.DateFormatString((double)data.Time), true);
		bool flag = data.GetSubContentJumpId() > 0 || !StringUtils.IsEmpty(data.GetSubUrl()) || data.IsQuestionMail();
		base.GetItem(14).SetUIActive(flag);
		if (flag)
		{
			string linkButtonTitle = data.GetLinkButtonTitle();
			MailTo? mailToConfigById = ConfigBase<MailConfig>.Instance.GetMailToConfigById(data.GetSubContentJumpId());
			if (!StringUtils.IsEmpty(linkButtonTitle))
			{
				this.LinkButton.SetTitle(linkButtonTitle);
			}
			else if (mailToConfigById != null)
			{
				this.LinkButton.SetTitleByTextKey(mailToConfigById.Value.Description);
			}
			string subTextColor = data.GetSubTextColor();
			if (!StringUtils.IsEmpty(subTextColor))
			{
				this.LinkButton.SetColor(subTextColor);
			}
			this.LinkButton.SetJumpIcon(data.GetSubContentJumpId());
		}
		this.RefreshMailValidTime(data);
		this.RefreshMailAttachment(data);
		this.RefreshMailOpButtonState(data);
		this.RefreshFavoriteToggle(data);
		base.GetItem(6).SetUIActive(data.GetMailLevel() == 2);
		this.MailSwitchSequence.StopSequenceByKey("Switch", false, true);
		this.MailSwitchSequence.PlayLevelSequenceByName("Switch", false, null, false);
	}

	// Token: 0x06010847 RID: 67655 RVA: 0x00483E5A File Offset: 0x0048205A
	private MailDropDownTitle CreateDropTitle(UUIItem uiItem)
	{
		return new MailDropDownTitle(uiItem);
	}

	// Token: 0x06010848 RID: 67656 RVA: 0x00483E62 File Offset: 0x00482062
	private MailFilter GetMailFilterConfigData(EMailFilter type)
	{
		return ModelBase<MailModel>.Instance.GetMailFilterConfigData(type);
	}

	// Token: 0x06010849 RID: 67657 RVA: 0x00483E70 File Offset: 0x00482070
	private void CallBackSelected(string mailId, int configId)
	{
		int index = this.CurrentMailDataList.FindIndex((MailData value) => value.Id == mailId);
		this.MailLoopScrollList.GetScrollItemFromIndex(index).Update(this.CurrentMailDataList[index], index);
		ModelBase<MailModel>.Instance.SetCurrentSelectMailId(mailId);
		if (this.SelectedMailData != null)
		{
			this.RefreshMailValidTime(this.SelectedMailData);
			this.RefreshFavoriteToggle(this.SelectedMailData);
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Mail;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "邮件界面：选择邮件";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("mailId", mailId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0601084A RID: 67658 RVA: 0x00483F1C File Offset: 0x0048211C
	private void ReloadDisplayMailDataList(MailDropDownItem dropDownItem, int defaultSelectedIndex = 0)
	{
		this.CurrentMailDataList = dropDownItem.GetFilteredMailList().ToList<MailData>();
		this.SelectedMailIndex = this.CurrentMailDataList.FindIndex(delegate(MailData value)
		{
			string id = value.Id;
			MailData selectedMailData = this.SelectedMailData;
			return id == ((selectedMailData != null) ? selectedMailData.Id : null);
		});
		this.SelectedMailIndex = ((this.SelectedMailIndex == -1) ? defaultSelectedIndex : this.SelectedMailIndex);
		this.SelectedMailIndex = Singleton<MathUtils>.Instance.Clamp(this.SelectedMailIndex, 0, Math.Max(0, this.CurrentMailDataList.Count - 1));
	}

	// Token: 0x0601084B RID: 67659 RVA: 0x00483F9C File Offset: 0x0048219C
	private void CallBackPickMailView(EMailAttachmentPickType pickType)
	{
		Singleton<Log>.Instance.Info(ELogModule.Mail, ELogAuthor.YZY, "邮件界面：CallBackPickMailView领取附件", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (this.SelectedMailData == null)
		{
			return;
		}
		if (pickType == EMailAttachmentPickType.PickAll && this.CurrentMailDataList != null)
		{
			for (int i = 0; i < this.CurrentMailDataList.Count; i++)
			{
				MailData mailInstanceById = ModelBase<MailModel>.Instance.GetMailInstanceById(this.CurrentMailDataList[i].Id);
				this.CurrentMailDataList[i] = mailInstanceById;
				MailScrollItemNew scrollItemFromIndex = this.MailLoopScrollList.GetScrollItemFromIndex(i);
				if (scrollItemFromIndex != null)
				{
					scrollItemFromIndex.Update(mailInstanceById, i);
				}
			}
		}
		else
		{
			int selectedMailIndex = this.SelectedMailIndex;
			MailData mailInstanceById2 = ModelBase<MailModel>.Instance.GetMailInstanceById(this.SelectedMailData.Id);
			if (this.CurrentMailDataList != null && selectedMailIndex >= 0 && selectedMailIndex < this.CurrentMailDataList.Count)
			{
				this.CurrentMailDataList[selectedMailIndex] = mailInstanceById2;
			}
			MailScrollItemNew scrollItemFromIndex2 = this.MailLoopScrollList.GetScrollItemFromIndex(selectedMailIndex);
			if (scrollItemFromIndex2 != null)
			{
				scrollItemFromIndex2.Update(mailInstanceById2, selectedMailIndex);
			}
		}
		this.SelectedMailData = (ModelBase<MailModel>.Instance.GetMailInstanceById(this.SelectedMailData.Id) ?? this.SelectedMailData);
		this.RefreshMailContentView(this.SelectedMailData);
		Singleton<Log>.Instance.Info(ELogModule.Mail, ELogAuthor.YZY, "邮件界面：CallBackPickMailView领取附件Finish", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0601084C RID: 67660 RVA: 0x004840E4 File Offset: 0x004822E4
	private void CallBackDeleteMailView(IReadOnlyList<string> deletedMails)
	{
		Singleton<Log>.Instance.Info(ELogModule.Mail, ELogAuthor.YZY, "邮件界面：CallBackDeleteMailView删除邮件", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (this.SelectedMailData == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.Mail, ELogAuthor.YZY, "邮件界面：CallBackDeleteMailView没有选择邮件,没有选择邮件的时候但是却删除了邮件", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.DropDownList.RefreshAllDropDownItem();
		MailDropDownItem mailDropDownItem = this.DropDownList.GetDropDownItemObject(this.DropDownList.GetSelectedIndex()) as MailDropDownItem;
		if (mailDropDownItem == null)
		{
			return;
		}
		int defaultSelectedIndex = (deletedMails.Count > 1) ? 0 : this.SelectedMailIndex;
		this.ReloadDisplayMailDataList(mailDropDownItem, defaultSelectedIndex);
		this.RefreshMailScrollList(this.CurrentMailDataList, this.SelectedMailIndex);
		this.SelectedMailData = ((this.SelectedMailIndex >= 0 && this.SelectedMailIndex < this.CurrentMailDataList.Count) ? this.CurrentMailDataList[this.SelectedMailIndex] : null);
		if (this.SelectedMailData != null)
		{
			this.OnSelectMailItem(this.SelectedMailIndex, this.SelectedMailData);
		}
		Singleton<Log>.Instance.Info(ELogModule.Mail, ELogAuthor.YZY, "邮件界面：CallBackDeleteMailView删除邮件结束", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0601084D RID: 67661 RVA: 0x004841F8 File Offset: 0x004823F8
	private void CallBackPassivelyDeleteMailView()
	{
		Singleton<Log>.Instance.Info(ELogModule.Mail, ELogAuthor.YZY, "邮件界面：CallBackPassivelyDeleteMailView被动删除邮件", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (this.SelectedMailData == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.Mail, ELogAuthor.YZY, "邮件界面：CallBackPassivelyDeleteMailView没有选择邮件", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.DropDownList.RefreshAllDropDownItem();
		MailDropDownItem mailDropDownItem = this.DropDownList.GetDropDownItemObject(this.DropDownList.GetSelectedIndex()) as MailDropDownItem;
		if (mailDropDownItem == null)
		{
			return;
		}
		this.ReloadDisplayMailDataList(mailDropDownItem, 0);
		this.RefreshMailScrollList(this.CurrentMailDataList, this.SelectedMailIndex);
		this.SelectedMailData = ((this.SelectedMailIndex >= 0 && this.SelectedMailIndex < this.CurrentMailDataList.Count) ? this.CurrentMailDataList[this.SelectedMailIndex] : null);
		if (this.SelectedMailData != null)
		{
			this.OnSelectMailItem(this.SelectedMailIndex, this.SelectedMailData);
		}
		Singleton<Log>.Instance.Info(ELogModule.Mail, ELogAuthor.YZY, "邮件界面：CallBackPassivelyDeleteMailView被动删除邮件结束", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0601084E RID: 67662 RVA: 0x004842F8 File Offset: 0x004824F8
	private void CallBackAddMailView()
	{
		Singleton<Log>.Instance.Info(ELogModule.Mail, ELogAuthor.YZY, "邮件界面：CallBackAddMailView,添加新邮件", default(ReadOnlySpan<ValueTuple<string, object>>));
		MailDropDownItem mailDropDownItem = this.DropDownList.GetDropDownItemObject(this.DropDownList.GetSelectedIndex()) as MailDropDownItem;
		if (mailDropDownItem == null)
		{
			return;
		}
		this.DropDownList.RefreshAllDropDownItem();
		this.ReloadDisplayMailDataList(mailDropDownItem, 0);
		this.RefreshMailScrollList(this.CurrentMailDataList, this.SelectedMailIndex);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Mail;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "邮件界面：CallBackAddMailView,添加新邮件结束";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CurrentMailDataList", this.CurrentMailDataList);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0601084F RID: 67663 RVA: 0x00484394 File Offset: 0x00482594
	private unsafe void OpenUrl(string link, string title = "", bool forceUseDefaultBrowser = false, bool ifLandscape = true)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Mail;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "邮件界面：OpenUrl";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("link", link);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("title", title);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("forceUseDefaultBrowser", forceUseDefaultBrowser);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("ifLandscape", ifLandscape);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		if (forceUseDefaultBrowser)
		{
			string extendExternalUrl = Singleton<PublicUtil>.Instance.GetExtendExternalUrl(link, forceUseDefaultBrowser);
			ModelBase<MailModel>.Instance.OpenWebBrowser(extendExternalUrl);
			return;
		}
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			string extendExternalUrl2 = Singleton<PublicUtil>.Instance.GetExtendExternalUrl(link, true);
			ControllerBase<KuroSdkController>.Instance.SdkOpenUrlWnd(title, extendExternalUrl2, ifLandscape, false, true);
			return;
		}
		string extendExternalUrl3 = Singleton<PublicUtil>.Instance.GetExtendExternalUrl(link, false);
		ModelBase<MailModel>.Instance.OpenWebBrowser(extendExternalUrl3);
	}

	// Token: 0x06010850 RID: 67664 RVA: 0x00484490 File Offset: 0x00482690
	private void OnClickLink()
	{
		MailController.RecordMailJumpLog(this.SelectedMailData);
		if (this.SelectedMailData.GetSubContentJumpId() > 0)
		{
			ModelBase<MailModel>.Instance.SetCurrentSelectMailId(this.SelectedMailData.Id);
			MailController.OpenMailJumpView(this.SelectedMailData);
			return;
		}
		string title = (this.SelectedMailData.GetSubTitle() == null) ? "" : this.SelectedMailData.GetSubTitle();
		if (this.SelectedMailData.IsQuestionMail())
		{
			this.OpenUrl(this.SelectedMailData.GetQuestionUrl(), title, this.SelectedMailData.GetUseDefaultBrowser(), this.SelectedMailData.GetIfLandscape());
			return;
		}
		string subUrl = this.SelectedMailData.GetSubUrl();
		if (!StringUtils.IsEmpty(subUrl))
		{
			this.OpenUrl(subUrl, title, this.SelectedMailData.GetUseDefaultBrowser(), this.SelectedMailData.GetIfLandscape());
		}
	}

	// Token: 0x06010851 RID: 67665 RVA: 0x0048455F File Offset: 0x0048275F
	private void OnClickClose()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.MailBoxView, null);
	}

	// Token: 0x06010852 RID: 67666 RVA: 0x00484574 File Offset: 0x00482774
	private unsafe void OnSelectDropItem(int index, EMailFilter data)
	{
		this.CurrentFilterState = data;
		this.CurrentMailDataList = (this.DropDownList.GetDropDownItemObject(index) as MailDropDownItem).GetFilteredMailList().ToList<MailData>();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Mail;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "邮件界面：选择下拉item OnSelectDropItem";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("index", index);
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
		string item = "this.CurrentMailDataList.length";
		List<MailData> currentMailDataList = this.CurrentMailDataList;
		ptr = new ValueTuple<string, object>(item, (currentMailDataList != null) ? new int?(currentMailDataList.Count) : null);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		this.SelectedMailIndex = 0;
		this.RefreshMailScrollList(this.CurrentMailDataList, 0);
	}

	// Token: 0x06010853 RID: 67667 RVA: 0x00484638 File Offset: 0x00482838
	private int GetSelectedIndex()
	{
		return this.SelectedMailIndex;
	}

	// Token: 0x06010854 RID: 67668 RVA: 0x00484640 File Offset: 0x00482840
	private void OnSelectMailItem(int index, MailData data)
	{
		if (index < 0 || index >= this.CurrentMailDataList.Count || data == null)
		{
			return;
		}
		MailScrollItemNew scrollItemFromIndex = this.MailLoopScrollList.GetScrollItemFromIndex(this.SelectedMailIndex);
		if (scrollItemFromIndex != null)
		{
			scrollItemFromIndex.OnDeselected(true);
		}
		this.SelectedMailData = data;
		this.SelectedMailIndex = index;
		this.RefreshMailContentView(data);
		MailController.SelectedMail(data);
		data.SetWasScanned(1);
	}

	// Token: 0x06010855 RID: 67669 RVA: 0x004846A4 File Offset: 0x004828A4
	private void OnClickMailOp()
	{
		if (this.SelectedMailData == null)
		{
			return;
		}
		MailData mail = ModelBase<MailModel>.Instance.GetMailInstanceById(this.SelectedMailData.Id) ?? this.SelectedMailData;
		if (mail.GetAttachmentStatus() == EMailAttachment.AttachmentRemained)
		{
			MailController.RequestPickAttachment(new List<string>
			{
				mail.Id
			}, EMailAttachmentPickType.PickOne);
			return;
		}
		if (!mail.IsFavorite)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.OneMailBeingDeleted);
			Action value = delegate()
			{
				MailController.RequestDeleteMail(new List<string>
				{
					mail.Id
				});
			};
			confirmBoxDataNew.FunctionMap[2] = value;
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		if (mail.NeedExpiredUnfavoriteConfirm())
		{
			ConfirmBoxDataNew confirmBoxDataNew2 = new ConfirmBoxDataNew(EConfirmBoxConfigId.ExpiredFavoriteMailUnfavoriteConfirm);
			confirmBoxDataNew2.FunctionMap[2] = delegate()
			{
				MailController.RequestMailFavorite(mail.Id, false, null, null);
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew2);
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew3 = new ConfirmBoxDataNew(EConfirmBoxConfigId.FavoriteMailDeleteConfirm);
		confirmBoxDataNew3.FunctionMap[2] = delegate()
		{
			MailController.RequestDeleteFavoriteMail(mail.Id);
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew3);
	}

	// Token: 0x040081E9 RID: 33257
	private const int DEFAULT_MAIL_INDEX = 0;

	// Token: 0x040081EA RID: 33258
	private const int HOUR_PER_DAY = 24;

	// Token: 0x040081EB RID: 33259
	[Nullable(2)]
	public MailData SelectedMailData;

	// Token: 0x040081EC RID: 33260
	private int SelectedMailIndex;

	// Token: 0x040081ED RID: 33261
	private PopupCaptionItem Caption;

	// Token: 0x040081EE RID: 33262
	private CommonDropDown<MailFilter, EMailFilter> DropDownList;

	// Token: 0x040081EF RID: 33263
	private DynamicScrollView<MailScrollItemNew, MailDynamicScrollItemNew, MailData> MailLoopScrollList;

	// Token: 0x040081F0 RID: 33264
	private MailLinkButton LinkButton;

	// Token: 0x040081F1 RID: 33265
	private LoopScrollView<CSharpScript.Game.Module.Mail.RewardItem, TItem> AttachmentsLayout;

	// Token: 0x040081F2 RID: 33266
	private List<MailData> CurrentMailDataList;

	// Token: 0x040081F3 RID: 33267
	private EMailFilter CurrentFilterState = EMailFilter.FilterAll;

	// Token: 0x040081F4 RID: 33268
	private ButtonAndTextItem MailOpButton;

	// Token: 0x040081F5 RID: 33269
	private ButtonAndTextItem DeleteAllReadButton;

	// Token: 0x040081F6 RID: 33270
	private ButtonAndTextItem ReceiveAllRewardButton;

	// Token: 0x040081F7 RID: 33271
	private LevelSequencePlayer MailSwitchSequence;

	// Token: 0x040081F8 RID: 33272
	private UUIText InsufficientTipText;

	// Token: 0x040081F9 RID: 33273
	private UUIText EmptyTipText;

	// Token: 0x02008501 RID: 34049
	[NullableContext(0)]
	private class EMailComponents
	{
		// Token: 0x0402D098 RID: 184472
		public const int Caption = 0;

		// Token: 0x0402D099 RID: 184473
		public const int Dropdown = 1;

		// Token: 0x0402D09A RID: 184474
		public const int MailLoopScrollView = 2;

		// Token: 0x0402D09B RID: 184475
		public const int MailScrollItem = 3;

		// Token: 0x0402D09C RID: 184476
		public const int BtnReceive = 4;

		// Token: 0x0402D09D RID: 184477
		public const int BtnDelete = 5;

		// Token: 0x0402D09E RID: 184478
		public const int SprStar = 6;

		// Token: 0x0402D09F RID: 184479
		public const int TxtMainTitle = 7;

		// Token: 0x0402D0A0 RID: 184480
		public const int TxtMainPoster = 8;

		// Token: 0x0402D0A1 RID: 184481
		public const int TxtPostTime = 9;

		// Token: 0x0402D0A2 RID: 184482
		public const int PnlLimitTime = 10;

		// Token: 0x0402D0A3 RID: 184483
		public const int TxtLimitTime = 11;

		// Token: 0x0402D0A4 RID: 184484
		public const int Content1 = 12;

		// Token: 0x0402D0A5 RID: 184485
		public const int TxtMainContent = 13;

		// Token: 0x0402D0A6 RID: 184486
		public const int BtnPageLink = 14;

		// Token: 0x0402D0A7 RID: 184487
		public const int PnlReward = 15;

		// Token: 0x0402D0A8 RID: 184488
		public const int AttachItemList = 16;

		// Token: 0x0402D0A9 RID: 184489
		public const int AttachItem = 17;

		// Token: 0x0402D0AA RID: 184490
		public const int BtnMailOp = 18;

		// Token: 0x0402D0AB RID: 184491
		public const int PnlLeft = 19;

		// Token: 0x0402D0AC RID: 184492
		public const int PnlRight = 20;

		// Token: 0x0402D0AD RID: 184493
		public const int PnlEmpty = 21;

		// Token: 0x0402D0AE RID: 184494
		public const int TogFavorite = 22;

		// Token: 0x0402D0AF RID: 184495
		public const int PnlInsufficient = 23;
	}
}
