using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AutoAttach;
using CSharpScript.Game.Module.Common.InputView.Controller;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Platform.PlatformSdk;
using CSharpScript.Launcher.Update;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Functional
{
	// Token: 0x02005D22 RID: 23842
	[NullableContext(2)]
	[Nullable(0)]
	public class FunctionView : UiViewBase
	{
		// Token: 0x0603C1E0 RID: 246240 RVA: 0x00F3E4C0 File Offset: 0x00F3C6C0
		[NullableContext(1)]
		public FunctionView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603C1E1 RID: 246241 RVA: 0x00F3E4E0 File Offset: 0x00F3C6E0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 40;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(23, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(27, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(28, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(29, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(30, typeof(UUIGridLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(31, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(32, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(33, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(34, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(35, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(36, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(37, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(38, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(39, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 17;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.BackClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.EndClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.MailClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.HelpClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(12, new Action(this.TimeClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(13, new Action(this.SetUpClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(14, new Action(this.CopyUidClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(15, new Action(this.NoticeBtnClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(20, new Action(this.PhotoBtnClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(21, new Action(this.HeadIconButtonClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(22, new Action(this.MoreButtonClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(24, new Action(this.SignButtonClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(27, new Action(this.NameButtonClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(17, new Action(this.MoveToLeft));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(16, new Action(this.MoveToRight));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(32, new Action(this.OnClickOnlineButton));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(37, new Action(this.OnClickPreDownload));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603C1E2 RID: 246242 RVA: 0x00F3ECCC File Offset: 0x00F3CECC
		protected override UniTask OnBeforeStartAsync()
		{
			FunctionView.<OnBeforeStartAsync>d__19 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FunctionView.<OnBeforeStartAsync>d__19>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C1E3 RID: 246243 RVA: 0x00F3ED0F File Offset: 0x00F3CF0F
		private void RefreshPlayerTitle()
		{
			PlayerTitleItem titleItem = this.TitleItem;
			if (titleItem == null)
			{
				return;
			}
			titleItem.Refresh(new int?(ModelBase<PersonalModel>.Instance.GetDressedPlayerTitleId()), new int?(ModelBase<PersonalModel>.Instance.GetDressedPlayerTitleLevel()), new int?(ModelBase<PersonalModel>.Instance.GetSex()));
		}

		// Token: 0x0603C1E4 RID: 246244 RVA: 0x00F3ED4E File Offset: 0x00F3CF4E
		private void BackClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603C1E5 RID: 246245 RVA: 0x00F3ED57 File Offset: 0x00F3CF57
		private void EndClick()
		{
			ControllerBase<ConfirmBoxController>.Instance.ShowReturnLoginConfirmBox();
		}

		// Token: 0x0603C1E6 RID: 246246 RVA: 0x00F3ED64 File Offset: 0x00F3CF64
		private void ReportBottomButtonClick(EFunctionBottomButtonType buttonType)
		{
			OnClickFunctionItemLogEvent onClickFunctionItemLogEvent = new OnClickFunctionItemLogEvent();
			onClickFunctionItemLogEvent.i_id = (int)buttonType;
			onClickFunctionItemLogEvent.i_type = 2;
			ControllerBase<LogReportController>.Instance.LogReport(onClickFunctionItemLogEvent);
		}

		// Token: 0x0603C1E7 RID: 246247 RVA: 0x00F3ED90 File Offset: 0x00F3CF90
		private void NoticeBtnClick()
		{
			this.ReportBottomButtonClick(EFunctionBottomButtonType.Notice);
			ControllerBase<KuroSdkController>.Instance.OpenNotice(EOpenNoticeStage.Normal);
		}

		// Token: 0x0603C1E8 RID: 246248 RVA: 0x00F3EDA4 File Offset: 0x00F3CFA4
		private void MailClick()
		{
			this.ReportBottomButtonClick(EFunctionBottomButtonType.Mail);
			ControllerBase<FunctionController>.Instance.OpenFunctionRelateView(EFunctionType.Mail);
		}

		// Token: 0x0603C1E9 RID: 246249 RVA: 0x00F3EDBC File Offset: 0x00F3CFBC
		private void HelpClick()
		{
			ControllerBase<WorldLevelController>.Instance.OpenWorldLevelInfoView();
		}

		// Token: 0x0603C1EA RID: 246250 RVA: 0x00F3EDC8 File Offset: 0x00F3CFC8
		private void TimeClick()
		{
			this.ReportBottomButtonClick(EFunctionBottomButtonType.Time);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TimeOfDaySecondView, null, null);
		}

		// Token: 0x0603C1EB RID: 246251 RVA: 0x00F3EDE2 File Offset: 0x00F3CFE2
		private void SetUpClick()
		{
			this.ReportBottomButtonClick(EFunctionBottomButtonType.Setting);
			ControllerBase<FunctionController>.Instance.OpenFunctionRelateView(EFunctionType.Menu);
		}

		// Token: 0x0603C1EC RID: 246252 RVA: 0x00F3EDFC File Offset: 0x00F3CFFC
		private void CopyUidClick()
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("CopiedMyUid", Array.Empty<object>());
			ULGUIBPLibrary.ClipBoardCopy(ModelBase<PlayerInfoModel>.Instance.GetId().ToString());
		}

		// Token: 0x0603C1ED RID: 246253 RVA: 0x00F3EE3A File Offset: 0x00F3D03A
		private void PhotoBtnClick()
		{
			this.ReportBottomButtonClick(EFunctionBottomButtonType.Photograph);
			ControllerBase<FunctionController>.Instance.OpenFunctionRelateView(EFunctionType.Photograph);
		}

		// Token: 0x0603C1EE RID: 246254 RVA: 0x00F3EE52 File Offset: 0x00F3D052
		private void HeadIconButtonClick()
		{
			if (ModelBase<FunctionModel>.Instance.IsOpen(10060))
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.PersonalRootView, ModelBase<PersonalModel>.Instance.GetPersonalInfoData(), null);
			}
		}

		// Token: 0x0603C1EF RID: 246255 RVA: 0x00F3EE7F File Offset: 0x00F3D07F
		private void MoreButtonClick()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PersonalOptionView, null, null);
		}

		// Token: 0x0603C1F0 RID: 246256 RVA: 0x00F3EE92 File Offset: 0x00F3D092
		private void SignButtonClick()
		{
			ControllerBase<CommonInputViewController>.Instance.OpenPersonalSignInputView();
		}

		// Token: 0x0603C1F1 RID: 246257 RVA: 0x00F3EE9E File Offset: 0x00F3D09E
		private void NameButtonClick()
		{
			ControllerBase<CommonInputViewController>.Instance.OpenSetRoleNameInputView();
		}

		// Token: 0x0603C1F2 RID: 246258 RVA: 0x00F3EEAA File Offset: 0x00F3D0AA
		private void OpenPlayerTitleEditView()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PersonalEditView, EPersonalEditDefine.PlayerTitle, null);
		}

		// Token: 0x0603C1F3 RID: 246259 RVA: 0x00F3EEC4 File Offset: 0x00F3D0C4
		private void MoveToLeft()
		{
			if (this.NoCircleExhibitionView.MovingState())
			{
				return;
			}
			if (this.NoCircleExhibitionView.GetCurrentSelectIndex() <= 0)
			{
				return;
			}
			int showItemIndex = this.NoCircleExhibitionView.GetCurrentSelectIndex() - 1;
			this.NoCircleExhibitionView.AttachToIndex(showItemIndex, false);
		}

		// Token: 0x0603C1F4 RID: 246260 RVA: 0x00F3EF0C File Offset: 0x00F3D10C
		private void MoveToRight()
		{
			if (this.NoCircleExhibitionView.MovingState())
			{
				return;
			}
			if (this.NoCircleExhibitionView.GetCurrentSelectIndex() >= this.NoCircleExhibitionView.GetDataLength())
			{
				return;
			}
			int showItemIndex = this.NoCircleExhibitionView.GetCurrentSelectIndex() + 1;
			this.NoCircleExhibitionView.AttachToIndex(showItemIndex, false);
		}

		// Token: 0x0603C1F5 RID: 246261 RVA: 0x00F3EF5C File Offset: 0x00F3D15C
		private void OnClickOnlineButton()
		{
			if (!ModelBase<GameModeModel>.Instance.IsMulti)
			{
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew;
			if (ModelBase<OnlineModel>.Instance.GetIsMyTeam())
			{
				confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.QuitOnlineWorldAndReduceTeam);
			}
			else
			{
				confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.QuitOnlineWorld);
			}
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				ControllerBase<OnlineController>.Instance.LeaveWorldTeamRequest(ModelBase<FunctionModel>.Instance.PlayerId, null);
				base.CloseMe(null);
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603C1F6 RID: 246262 RVA: 0x00F3EFBA File Offset: 0x00F3D1BA
		private void OnClickPreDownload()
		{
			this.ReportBottomButtonClick(EFunctionBottomButtonType.PreDownload);
			ControllerBase<PreDownloadController>.Instance.OnPreDownloadBtnClick(false);
		}

		// Token: 0x0603C1F7 RID: 246263 RVA: 0x00F3EFD0 File Offset: 0x00F3D1D0
		protected override void OnStart()
		{
			this.RedTipsLeftBtn = base.GetButton(17).RootUIComp;
			this.RedTipsRightBtn = base.GetButton(16).RootUIComp;
			this.RedTipsLeft = base.GetItem(19);
			this.RedTipsRight = base.GetItem(18);
			this.TabLayout = new FunctionTabLayout(base.GetItem(28));
			this.NoCircleExhibitionView = new NoCircleAttachView<int[], FunctionAttachItemGrid>(base.GetItem(10).GetOwner(), false);
			UUIItem item = base.GetItem(29);
			item.SetUIActive(false);
			this.ReSizeDragContentSize();
			this.NoCircleExhibitionView.CreateItems(item.GetOwner(), 0f, new Func<AActor, int, int, FunctionAttachItemGrid>(this.InitFunctionGrid), EAttachDirection.Horizontal);
			this.NoCircleExhibitionView.SetDragBeginCallback(new Action(this.HideRedTipsBtn));
			this.NoCircleExhibitionView.SetMoveMultiFactor(50f);
			this.NoCircleExhibitionView.SetPageLimitState(true);
			this.BottomMailBtn = new FunctionBottomButtonItem(base.GetButton(8).RootUIComp.Get(), ERedDotName.FunctionMail);
			this.BottomNoticeBtn = new FunctionBottomButtonItem(base.GetButton(15).RootUIComp.Get(), ERedDotName.FunctionNotice);
			this.BottomPhotoBtn = new FunctionBottomButtonItem(base.GetButton(20).RootUIComp.Get(), ERedDotName.FunctionPhotograph);
			this.BottomSettingBtn = new FunctionBottomButtonItem(base.GetButton(13).RootUIComp.Get(), ERedDotName.FunctionSetting);
			this.BottomPreDownloadBtn = new PreDownloadButtonItemB(base.GetButton(37).RootUIComp.Get());
			bool raycastTarget = ModelBase<FunctionModel>.Instance.IsOpen(10060);
			UUIButtonComponent button = base.GetButton(21);
			if (button != null)
			{
				UUIItem uuiitem = button.RootUIComp.Get();
				if (uuiitem != null)
				{
					uuiitem.SetRaycastTarget(raycastTarget);
				}
			}
			this.RefreshEndButtonShowState();
			this.RefreshFunctionGrid();
			int currentSelectIndex = this.NoCircleExhibitionView.GetCurrentSelectIndex();
			this.RefreshRedDot(currentSelectIndex);
			this.TabLayout.SetToggleSelectByIndex(currentSelectIndex);
			if (Singleton<Info>.Instance.IsHomeConsolePlatform())
			{
				UUIButtonComponent button2 = base.GetButton(14);
				if (button2 != null)
				{
					button2.SetSelfInteractive(false);
				}
				UUISprite sprite = base.GetSprite(36);
				if (sprite == null)
				{
					return;
				}
				sprite.SetUIActive(false);
			}
		}

		// Token: 0x0603C1F8 RID: 246264 RVA: 0x00F3F200 File Offset: 0x00F3D400
		private void ReSizeDragContentSize()
		{
			UUIGridLayout gridLayout = base.GetGridLayout(30);
			FVector2D fvector2D = (gridLayout != null) ? gridLayout.GetCellSize() : FVector2D.ZeroVector;
			FVector2D fvector2D2 = (gridLayout != null) ? gridLayout.GetSpacing() : FVector2D.ZeroVector;
			float num = fvector2D.X + fvector2D2.X;
			float width = (float)this.CalculateGridNum().HorizontalGridNum * num;
			UUIItem item = base.GetItem(10);
			if (item == null)
			{
				return;
			}
			item.SetWidth(width);
		}

		// Token: 0x0603C1F9 RID: 246265 RVA: 0x00F3F268 File Offset: 0x00F3D468
		private void HideRedTipsBtn()
		{
			this.RedTipsRightBtn.SetUIActive(false);
			this.RedTipsLeftBtn.SetUIActive(false);
		}

		// Token: 0x0603C1FA RID: 246266 RVA: 0x00F3F284 File Offset: 0x00F3D484
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.CurWorldLevelChange, new Action(this.OnCurWorldLevelChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OnSignChange, new Action(this.OnSignChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OnNameChange, new Action(this.OnNameChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OnHeadIconChange, new Action<int>(this.OnHeadIconChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OnCardChange, new Action(this.OnCardChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OnBirthChange, new Action(this.OnBirthChange));
			Singleton<EventSystem>.Instance.Add(EEventName.FunctionGridSelected, new Action<int>(this.OnFunctionGridSelected));
			Singleton<EventSystem>.Instance.Add(EEventName.OnPlayerTitleChange, new Action(this.RefreshPlayerTitle));
			Singleton<EventSystem>.Instance.Add<EVideoDownloadStatus>(EEventName.ResDownLoadStateRefresh, new Action<EVideoDownloadStatus>(this.ResDownLoadStateRefresh));
			Singleton<EventSystem>.Instance.Add(EEventName.OnPreDownloadAvailableUpdate, new Action(this.OnPreDownloadUpdate));
			Singleton<EventSystem>.Instance.Emit(EEventName.OnFunctionViewShow);
		}

		// Token: 0x0603C1FB RID: 246267 RVA: 0x00F3F3BC File Offset: 0x00F3D5BC
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.CurWorldLevelChange, new Action(this.OnCurWorldLevelChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSignChange, new Action(this.OnSignChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnNameChange, new Action(this.OnNameChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnHeadIconChange, new Action<int>(this.OnHeadIconChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCardChange, new Action(this.OnCardChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBirthChange, new Action(this.OnBirthChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPlayerTitleChange, new Action(this.RefreshPlayerTitle));
			Singleton<EventSystem>.Instance.Remove(EEventName.FunctionGridSelected, new Action<int>(this.OnFunctionGridSelected));
			Singleton<EventSystem>.Instance.Remove<EVideoDownloadStatus>(EEventName.ResDownLoadStateRefresh, new Action<EVideoDownloadStatus>(this.ResDownLoadStateRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPreDownloadAvailableUpdate, new Action(this.OnPreDownloadUpdate));
		}

		// Token: 0x0603C1FC RID: 246268 RVA: 0x00F3F4E1 File Offset: 0x00F3D6E1
		private void OnCurWorldLevelChange()
		{
			this.RefreshWorldLevel();
		}

		// Token: 0x0603C1FD RID: 246269 RVA: 0x00F3F4E9 File Offset: 0x00F3D6E9
		private void OnSignChange()
		{
			this.RefreshSign();
		}

		// Token: 0x0603C1FE RID: 246270 RVA: 0x00F3F4F4 File Offset: 0x00F3D6F4
		private void OnNameChange()
		{
			string playerName = ModelBase<FunctionModel>.Instance.GetPlayerName();
			if (playerName != null)
			{
				base.GetText(0).SetText(playerName, true);
			}
		}

		// Token: 0x0603C1FF RID: 246271 RVA: 0x00F3F51D File Offset: 0x00F3D71D
		private void OnHeadIconChange(int headPhotoId)
		{
			this.RefreshHeadIcon();
		}

		// Token: 0x0603C200 RID: 246272 RVA: 0x00F3F525 File Offset: 0x00F3D725
		private void OnCardChange()
		{
			this.RefreshCard();
		}

		// Token: 0x0603C201 RID: 246273 RVA: 0x00F3F530 File Offset: 0x00F3D730
		private void OnBirthChange()
		{
			int birthday = ModelBase<PersonalModel>.Instance.GetBirthday();
			UUIText text = base.GetText(26);
			if (birthday == 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalText(text, "BirthDay", new <>z__ReadOnlyArray<object>(new object[]
				{
					"--",
					"--"
				}));
				return;
			}
			int num = (int)Math.Floor((double)birthday / 100.0);
			int num2 = birthday % 100;
			Singleton<LguiUtil>.Instance.SetLocalText(text, "BirthDay", new <>z__ReadOnlyArray<object>(new object[]
			{
				num,
				num2
			}));
		}

		// Token: 0x0603C202 RID: 246274 RVA: 0x00F3F5C5 File Offset: 0x00F3D7C5
		private void OnFunctionGridSelected(int index)
		{
			this.RefreshRedDot(index);
			this.TabLayout.SetToggleSelectByIndex(index);
		}

		// Token: 0x0603C203 RID: 246275 RVA: 0x00F3F5DC File Offset: 0x00F3D7DC
		private void RefreshRedDot(int index)
		{
			this.RedTipsLeftBtn.SetUIActive(index > 0);
			this.RedTipsRightBtn.SetUIActive(index < this.NoCircleExhibitionView.GetDataLength() - 1);
			this.RedTipsLeft.SetUIActive(this.IsRedLeftBtnActive(index));
			this.RedTipsRight.SetUIActive(this.IsRedRightBtnActive(index));
		}

		// Token: 0x0603C204 RID: 246276 RVA: 0x00F3F638 File Offset: 0x00F3D838
		private void RefreshEndButtonShowState()
		{
			bool uiactive = !Singleton<CloudGameManager>.Instance.IsCloudGame && !Singleton<Info>.Instance.IsPs5Platform() && (!Singleton<Info>.Instance.IsXboxPlatform() || Singleton<Info>.Instance.IsWinGDKPlatform());
			UUIButtonComponent button = base.GetButton(7);
			if (button == null)
			{
				return;
			}
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(uiactive);
		}

		// Token: 0x0603C205 RID: 246277 RVA: 0x00F3F6A0 File Offset: 0x00F3D8A0
		private bool IsRedLeftBtnActive(int index)
		{
			List<int> list = new List<int>();
			for (int i = 0; i < index; i++)
			{
				list.AddRange(this.DataList[i]);
			}
			foreach (int functionId in list)
			{
				ERedDotName? functionItemRedDotName = ModelBase<FunctionModel>.Instance.GetFunctionItemRedDotName(functionId);
				if (functionItemRedDotName != null)
				{
					RedDotBase redDot = ModelBase<RedDotModel>.Instance.GetRedDot(functionItemRedDotName.Value);
					if (redDot != null && redDot.IsRedDotActive())
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603C206 RID: 246278 RVA: 0x00F3F750 File Offset: 0x00F3D950
		private bool IsRedRightBtnActive(int index)
		{
			List<int> list = new List<int>();
			int i = index + 1;
			int count = this.DataList.Count;
			while (i < count)
			{
				list.AddRange(this.DataList[i]);
				i++;
			}
			foreach (int functionId in list)
			{
				ERedDotName? functionItemRedDotName = ModelBase<FunctionModel>.Instance.GetFunctionItemRedDotName(functionId);
				if (functionItemRedDotName != null)
				{
					RedDotBase redDot = ModelBase<RedDotModel>.Instance.GetRedDot(functionItemRedDotName.Value);
					if (redDot != null && redDot.IsRedDotActive())
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603C207 RID: 246279 RVA: 0x00F3F80C File Offset: 0x00F3DA0C
		protected override void OnBeforeShow()
		{
			this.SetPlayerInfo();
			this.RefreshOtherButton();
			this.BindRedDot();
			this.RefreshOnlineButton();
			this.RefreshResDownLoadTopPanelState();
			Singleton<GameSettingsDeviceRender>.Instance.TemporaryDisableFrameGeneration("FunctionView");
		}

		// Token: 0x0603C208 RID: 246280 RVA: 0x00F3F83B File Offset: 0x00F3DA3B
		protected override void OnAfterShow()
		{
			this.PrintCalculateData();
			this.TryShowParallelPackageUpdateBoxView();
		}

		// Token: 0x0603C209 RID: 246281 RVA: 0x00F3F849 File Offset: 0x00F3DA49
		protected override void OnAfterHide()
		{
			this.UnBindRedDot();
		}

		// Token: 0x0603C20A RID: 246282 RVA: 0x00F3F854 File Offset: 0x00F3DA54
		protected override void OnBeforeDestroy()
		{
			foreach (FunctionAttachItemGrid child in this.NoCircleExhibitionView.GetItems())
			{
				base.AddChild(child);
			}
			this.TabLayout.Destroy(null);
			this.BottomMailBtn.Destroy(null);
			this.BottomNoticeBtn.Destroy(null);
			this.BottomPhotoBtn.Destroy(null);
			this.BottomSettingBtn.Destroy(null);
			this.TitleItem.Destroy(null);
			this.BottomPreDownloadBtn.Destroy(null);
			this.BottomDownloadPanel.EndShow();
			Singleton<GameSettingsDeviceRender>.Instance.CancelTemporaryDisableFrameGeneration("FunctionView");
		}

		// Token: 0x0603C20B RID: 246283 RVA: 0x00F3F91C File Offset: 0x00F3DB1C
		private void BindRedDot()
		{
			this.BottomMailBtn.BindRedDot();
			this.BottomNoticeBtn.BindRedDot();
			this.BottomPhotoBtn.BindRedDot();
			this.BottomSettingBtn.BindRedDot();
			this.BottomPreDownloadBtn.BindRedDot();
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.PersonalizedInfo, base.GetItem(34), null, 0);
		}

		// Token: 0x0603C20C RID: 246284 RVA: 0x00F3F97C File Offset: 0x00F3DB7C
		private void UnBindRedDot()
		{
			this.BottomMailBtn.UnBindRedDot();
			this.BottomNoticeBtn.UnBindRedDot();
			this.BottomPhotoBtn.UnBindRedDot();
			this.BottomSettingBtn.UnBindRedDot();
			this.BottomPreDownloadBtn.UnBindRedDot();
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.PersonalizedInfo, base.GetItem(34), 0);
		}

		// Token: 0x0603C20D RID: 246285 RVA: 0x00F3F9D8 File Offset: 0x00F3DBD8
		private void SetPlayerInfo()
		{
			this.RefreshPlayerName();
			this.RefreshPlayerLevelAndExp();
			this.RefreshWorldLevel();
			this.RefreshHeadIcon();
			this.RefreshCard();
			this.RefreshSign();
			this.RefreshBirthDay();
			this.RefreshPlayerTitle();
		}

		// Token: 0x0603C20E RID: 246286 RVA: 0x00F3FA0C File Offset: 0x00F3DC0C
		private void RefreshPlayerName()
		{
			string playerName = ModelBase<FunctionModel>.Instance.GetPlayerName();
			base.GetText(0).SetText(playerName, true);
		}

		// Token: 0x0603C20F RID: 246287 RVA: 0x00F3FA34 File Offset: 0x00F3DC34
		private void RefreshPlayerLevelAndExp()
		{
			int? playerLevel = ModelBase<FunctionModel>.Instance.GetPlayerLevel();
			if (playerLevel == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(4), "PlayerLevelNum", new <>z__ReadOnlySingleElementList<object>(playerLevel));
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "UserId", new <>z__ReadOnlySingleElementList<object>(ModelBase<FunctionModel>.Instance.PlayerId));
			PlayerExp? config = ConfigPlayerExpByPlayerLevel.GetConfig(playerLevel.Value, true);
			bool flag;
			if (config == null)
			{
				flag = false;
			}
			else
			{
				int levelExp = config.GetValueOrDefault().LevelExp;
				flag = true;
			}
			if (flag)
			{
				int? playerExp = ModelBase<FunctionModel>.Instance.GetPlayerExp();
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(5), "ExpText", new <>z__ReadOnlyArray<object>(new object[]
				{
					playerExp,
					config.Value.LevelExp
				}));
				base.GetSprite(9).SetFillAmount((float)playerExp.Value / (float)config.Value.LevelExp);
			}
		}

		// Token: 0x0603C210 RID: 246288 RVA: 0x00F3FB40 File Offset: 0x00F3DD40
		private void RefreshWorldLevel()
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), "WorldLevelNum", new <>z__ReadOnlySingleElementList<object>(ModelBase<WorldLevelModel>.Instance.CurWorldLevel));
		}

		// Token: 0x0603C211 RID: 246289 RVA: 0x00F3FB6C File Offset: 0x00F3DD6C
		private void RefreshHeadIcon()
		{
			int? numberPropById = ModelBase<PlayerInfoModel>.Instance.GetNumberPropById(EPlayerInfoNumber.HeadPhoto);
			if (numberPropById == null)
			{
				return;
			}
			UUITexture playerTexture = base.GetTexture(11);
			PlayerHeadData playerHeadData = ModelBase<PersonalModel>.Instance.GetPlayerHeadData(numberPropById.Value, true);
			if (playerHeadData == null)
			{
				return;
			}
			playerTexture.SetUIActive(false);
			base.SetTextureShowUntilLoaded(playerHeadData.GetRoleHeadIconCircle(), playerTexture, delegate(bool _)
			{
				playerTexture.SetUIActive(true);
			});
			bool uiactive = ModelBase<PersonalModel>.Instance.CheckCanShowPersonalTip();
			base.GetItem(35).SetUIActive(uiactive);
		}

		// Token: 0x0603C212 RID: 246290 RVA: 0x00F3FC00 File Offset: 0x00F3DE00
		private void RefreshCard()
		{
			int curCardId = ModelBase<PersonalModel>.Instance.GetCurCardId();
			BackgroundCard? config = ConfigBackgroundCardById.GetConfig(curCardId, true);
			if (config != null)
			{
				base.SetTextureByPath(config.Value.FunctionViewCardPath, base.GetTexture(23), null, null);
			}
		}

		// Token: 0x0603C213 RID: 246291 RVA: 0x00F3FC50 File Offset: 0x00F3DE50
		private void RefreshSign()
		{
			string signature = ModelBase<PersonalModel>.Instance.GetSignature();
			UUIText text = base.GetText(25);
			if (string.IsNullOrEmpty(signature))
			{
				Singleton<LguiUtil>.Instance.SetLocalText(text, "ClickToSetSign", Array.Empty<object>());
				return;
			}
			text.SetText(signature, true);
		}

		// Token: 0x0603C214 RID: 246292 RVA: 0x00F3FC98 File Offset: 0x00F3DE98
		private void RefreshBirthDay()
		{
			int birthday = ModelBase<PersonalModel>.Instance.GetBirthday();
			UUIText text = base.GetText(26);
			if (birthday == 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalText(text, "BirthDay", new <>z__ReadOnlyArray<object>(new object[]
				{
					"--",
					"--"
				}));
				return;
			}
			int num = (int)Math.Floor((double)birthday / 100.0);
			int num2 = birthday % 100;
			Singleton<LguiUtil>.Instance.SetLocalText(text, "BirthDay", new <>z__ReadOnlyArray<object>(new object[]
			{
				num,
				num2
			}));
		}

		// Token: 0x0603C215 RID: 246293 RVA: 0x00F3FD30 File Offset: 0x00F3DF30
		private void SetPanelTabItemStretchRight(float offsetValue)
		{
			UUIItem item = base.GetItem(31);
			float stretchRight = item.GetStretchRight();
			item.SetStretchRight(stretchRight + offsetValue);
		}

		// Token: 0x0603C216 RID: 246294 RVA: 0x00F3FD54 File Offset: 0x00F3DF54
		private void RefreshFunctionGrid()
		{
			this.CalculateData = this.CalculateGridNum();
			this.SetPanelTabItemStretchRight(this.CalculateData.OffsetWidth);
			int[] showFunctionIdList = ModelBase<FunctionModel>.Instance.GetShowFunctionIdList();
			int i = showFunctionIdList.Length;
			this.DataList = new List<int[]>();
			int num = 0;
			while (i > num + this.CalculateData.TotalGridNumber)
			{
				int[] array = new int[this.CalculateData.TotalGridNumber];
				Array.Copy(showFunctionIdList.ToArray<int>(), num, array, 0, this.CalculateData.TotalGridNumber);
				this.DataList.Add(array);
				num += this.CalculateData.TotalGridNumber;
			}
			int[] array2 = new int[i - num];
			Array.Copy(showFunctionIdList.ToArray<int>(), num, array2, 0, i - num);
			this.DataList.Add(array2);
			int num2 = (int)Math.Ceiling((double)i / (double)this.CalculateData.TotalGridNumber);
			this.TabLayout.RefreshTab(num2);
			this.NoCircleExhibitionView.SetBoundDistance(0f);
			this.NoCircleExhibitionView.ReloadView(num2, this.DataList.ToArray(), 0);
		}

		// Token: 0x0603C217 RID: 246295 RVA: 0x00F3FE68 File Offset: 0x00F3E068
		[NullableContext(1)]
		private FunctionAttachItemGrid InitFunctionGrid(AActor actor, int index, int showNum)
		{
			FunctionAttachItemGrid functionAttachItemGrid = new FunctionAttachItemGrid(actor);
			functionAttachItemGrid.SetNeedAnim(index == 0);
			this.FunctionGridMap[index] = functionAttachItemGrid;
			return functionAttachItemGrid;
		}

		// Token: 0x0603C218 RID: 246296 RVA: 0x00F3FE94 File Offset: 0x00F3E094
		private int GetTargetIndex(int functionId)
		{
			List<int[]> dataList = this.DataList;
			int result = -1;
			int i = 0;
			int count = dataList.Count;
			Predicate<int> <>9__0;
			while (i < count)
			{
				int[] array = dataList[i];
				Predicate<int> match;
				if ((match = <>9__0) == null)
				{
					match = (<>9__0 = ((int id) => id == functionId));
				}
				if (Array.Exists<int>(array, match))
				{
					result = i;
				}
				i++;
			}
			return result;
		}

		// Token: 0x0603C219 RID: 246297 RVA: 0x00F3FF00 File Offset: 0x00F3E100
		private void RefreshOnlineButton()
		{
			UUIButtonComponent button = base.GetButton(32);
			TWeakObjectPtr<UUIItem>? tweakObjectPtr = (button != null) ? new TWeakObjectPtr<UUIItem>?(button.RootUIComp) : null;
			if (!ModelBase<GameModeModel>.Instance.IsMulti)
			{
				if (tweakObjectPtr != null)
				{
					UUIItem uuiitem = tweakObjectPtr.GetValueOrDefault().Get();
					if (uuiitem == null)
					{
						return;
					}
					uuiitem.SetUIActive(false);
				}
				return;
			}
			if (tweakObjectPtr != null)
			{
				UUIItem uuiitem2 = tweakObjectPtr.GetValueOrDefault().Get();
				if (uuiitem2 != null)
				{
					uuiitem2.SetUIActive(true);
				}
			}
			OnlineTeamData currentTeamListById = ModelBase<OnlineModel>.Instance.GetCurrentTeamListById(ModelBase<FunctionModel>.Instance.PlayerId);
			ENetPingState? ping = (currentTeamListById != null) ? new ENetPingState?(currentTeamListById.PingState) : null;
			this.RefreshPlayerPingItem(ping);
		}

		// Token: 0x0603C21A RID: 246298 RVA: 0x00F3FFBC File Offset: 0x00F3E1BC
		private void RefreshPlayerPingItem(ENetPingState? ping)
		{
			UUISprite sprite = base.GetSprite(33);
			sprite.SetUIActive(true);
			ENetPingState? enetPingState = ping;
			ENetPingState enetPingState2 = ENetPingState.Unknown;
			if (enetPingState.GetValueOrDefault() == enetPingState2 & enetPingState != null)
			{
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_SignalUnknown");
				this.SetSpriteByPath(resourcePath, sprite, false, null, null);
				return;
			}
			if (ping.GetValueOrDefault() == ENetPingState.Great)
			{
				string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_SignalGreat");
				this.SetSpriteByPath(resourcePath2, sprite, false, null, null);
				return;
			}
			if (ping.GetValueOrDefault() == ENetPingState.Good)
			{
				string resourcePath3 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_SignalGood");
				this.SetSpriteByPath(resourcePath3, sprite, false, null, null);
				return;
			}
			if (ping.GetValueOrDefault() == ENetPingState.Poor)
			{
				string resourcePath4 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_SignalPoor");
				this.SetSpriteByPath(resourcePath4, sprite, false, null, null);
			}
		}

		// Token: 0x0603C21B RID: 246299 RVA: 0x00F400A8 File Offset: 0x00F3E2A8
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			int num;
			if (configParams.Length > 1 || !int.TryParse(configParams[0], out num))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Guide;
				ELogAuthor author = ELogAuthor.TL;
				string message = "功能菜单聚焦引导的ExtraParam配置错误";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("configParams", configParams);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			int num2 = int.Parse(configParams[0]);
			int targetIndex = this.GetTargetIndex(num2);
			if (targetIndex == -1)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Guide;
				ELogAuthor author2 = ELogAuthor.TL;
				string message2 = "功能菜单聚焦引导的ExtraParam配置错误, 检查functionId";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("functionId", num2);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return null;
			}
			this.NoCircleExhibitionView.AttachToIndex(targetIndex, true);
			FunctionAttachItemGrid functionAttachItemGrid;
			if (!this.FunctionGridMap.TryGetValue(targetIndex, out functionAttachItemGrid))
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.Guide;
				ELogAuthor author3 = ELogAuthor.TL;
				string message3 = "功能菜单聚焦引导的ExtraParam配置错误, 检查functionId";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("functionId", num2);
				instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				return null;
			}
			FunctionItem functionItem = functionAttachItemGrid.GetFunctionItem(num2);
			if (!functionItem.GetActive())
			{
				return null;
			}
			UUIItem buttonItem = functionItem.GetButtonItem();
			if (buttonItem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				buttonItem,
				buttonItem
			};
		}

		// Token: 0x0603C21C RID: 246300 RVA: 0x00F401B0 File Offset: 0x00F3E3B0
		private void RefreshOtherButton()
		{
			base.GetButton(8).SetSelfInteractive(ModelBase<FunctionModel>.Instance.IsOpen(10020));
			base.GetButton(12).SetSelfInteractive(ModelBase<FunctionModel>.Instance.IsOpen(10018));
			base.GetButton(13).SetSelfInteractive(ModelBase<FunctionModel>.Instance.IsOpen(10019));
			base.GetButton(15).SetSelfInteractive(ControllerBase<KuroSdkController>.Instance.CanUseSdk() || Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn);
			base.GetButton(20).SetSelfInteractive(ModelBase<FunctionModel>.Instance.IsOpen(10049));
			bool uiactive = ModelBase<PreDownloadModel>.Instance.IsPreDownloadAvailable() || ModelBase<PreDownloadModel>.Instance.IsComplete();
			UUIButtonComponent button = base.GetButton(37);
			if (button == null)
			{
				return;
			}
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(uiactive);
		}

		// Token: 0x0603C21D RID: 246301 RVA: 0x00F40291 File Offset: 0x00F3E491
		private void TryShowParallelPackageUpdateBoxView()
		{
			ControllerBase<ParallelPackageController>.Instance.TryShowParallelPackageUpdateConfirmBox(ParallelPackageDownloadBoxShowReason.Auto);
		}

		// Token: 0x0603C21E RID: 246302 RVA: 0x00F402A0 File Offset: 0x00F3E4A0
		private unsafe void PrintCalculateData()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Functional;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "功能开启界面Start阶段计算数据输出";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("剩余宽度", this.CalculateData.OffsetWidth);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("显示数量", this.CalculateData.TotalGridNumber);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			ICalculateData calculateData = this.CalculateGridNum();
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Functional;
			ELogAuthor author2 = ELogAuthor.XXJ;
			string message2 = "功能开启界面AfterShow阶段计算数据输出";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("剩余宽度", calculateData.OffsetWidth);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("显示数量", calculateData.TotalGridNumber);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
		}

		// Token: 0x0603C21F RID: 246303 RVA: 0x00F4038C File Offset: 0x00F3E58C
		[NullableContext(1)]
		private ICalculateData CalculateGridNum()
		{
			UUIItem item = base.GetItem(29);
			UUIGridLayout gridLayout = base.GetGridLayout(30);
			FVector2D cellSize = gridLayout.GetCellSize();
			FVector2D spacing = gridLayout.GetSpacing();
			FMargin padding = gridLayout.GetPadding();
			float width = item.GetWidth();
			float height = item.GetHeight();
			float num = (width - padding.Left - padding.Right) % (cellSize.X + spacing.X);
			int num2 = (num >= cellSize.X) ? 1 : 0;
			int num3 = (int)Math.Floor((double)((width - padding.Left - padding.Right) / (cellSize.X + spacing.X))) + num2;
			int num4 = ((height - padding.Top - padding.Bottom) % (cellSize.Y + spacing.Y) > cellSize.Y) ? 1 : 0;
			int num5 = (int)Math.Floor((double)((height - padding.Top - padding.Bottom) / (cellSize.Y + spacing.Y))) + num4;
			float offsetWidth = (num >= cellSize.X) ? (num - cellSize.X) : (num + spacing.X);
			return new CalculateData
			{
				TotalGridNumber = num3 * num5,
				OffsetWidth = offsetWidth,
				HorizontalGridNum = num3,
				VerticalGridNum = num5
			};
		}

		// Token: 0x0603C220 RID: 246304 RVA: 0x00F404B7 File Offset: 0x00F3E6B7
		private void ResDownLoadStateRefresh(EVideoDownloadStatus state)
		{
			this.RefreshResDownLoadTopPanelState();
		}

		// Token: 0x0603C221 RID: 246305 RVA: 0x00F404C0 File Offset: 0x00F3E6C0
		private void RefreshResDownLoadTopPanelState()
		{
			if (ModelBase<SubPackageDownLoadModel>.Instance.NeedShowBattleViewButton())
			{
				FunctionResDownLoadItem bottomDownloadPanel = this.BottomDownloadPanel;
				if (bottomDownloadPanel != null)
				{
					bottomDownloadPanel.SetUiActive(true);
				}
				FunctionResDownLoadItem bottomDownloadPanel2 = this.BottomDownloadPanel;
				if (bottomDownloadPanel2 == null)
				{
					return;
				}
				bottomDownloadPanel2.StartShow();
				return;
			}
			else
			{
				FunctionResDownLoadItem bottomDownloadPanel3 = this.BottomDownloadPanel;
				if (bottomDownloadPanel3 != null)
				{
					bottomDownloadPanel3.SetUiActive(false);
				}
				FunctionResDownLoadItem bottomDownloadPanel4 = this.BottomDownloadPanel;
				if (bottomDownloadPanel4 == null)
				{
					return;
				}
				bottomDownloadPanel4.EndShow();
				return;
			}
		}

		// Token: 0x0603C222 RID: 246306 RVA: 0x00F40520 File Offset: 0x00F3E720
		private void OnPreDownloadUpdate()
		{
			bool uiactive = ModelBase<PreDownloadModel>.Instance.IsPreDownloadAvailable() || ModelBase<PreDownloadModel>.Instance.IsComplete();
			UUIButtonComponent button = base.GetButton(37);
			if (button == null)
			{
				return;
			}
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(uiactive);
		}

		// Token: 0x04021BF3 RID: 138227
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private NoCircleAttachView<int[], FunctionAttachItemGrid> NoCircleExhibitionView;

		// Token: 0x04021BF4 RID: 138228
		private FunctionTabLayout TabLayout;

		// Token: 0x04021BF5 RID: 138229
		private UUIItem RedTipsLeftBtn;

		// Token: 0x04021BF6 RID: 138230
		private UUIItem RedTipsRightBtn;

		// Token: 0x04021BF7 RID: 138231
		private UUIItem RedTipsLeft;

		// Token: 0x04021BF8 RID: 138232
		private UUIItem RedTipsRight;

		// Token: 0x04021BF9 RID: 138233
		private FunctionBottomButtonItem BottomMailBtn;

		// Token: 0x04021BFA RID: 138234
		private FunctionBottomButtonItem BottomNoticeBtn;

		// Token: 0x04021BFB RID: 138235
		private FunctionBottomButtonItem BottomPhotoBtn;

		// Token: 0x04021BFC RID: 138236
		private FunctionBottomButtonItem BottomSettingBtn;

		// Token: 0x04021BFD RID: 138237
		private PlayerTitleItem TitleItem;

		// Token: 0x04021BFE RID: 138238
		private PreDownloadButtonItemB BottomPreDownloadBtn;

		// Token: 0x04021BFF RID: 138239
		private FunctionResDownLoadItem BottomDownloadPanel;

		// Token: 0x04021C00 RID: 138240
		[Nullable(1)]
		private readonly Dictionary<int, FunctionAttachItemGrid> FunctionGridMap = new Dictionary<int, FunctionAttachItemGrid>();

		// Token: 0x04021C01 RID: 138241
		[Nullable(1)]
		private List<int[]> DataList = new List<int[]>();

		// Token: 0x04021C02 RID: 138242
		[Nullable(1)]
		private ICalculateData CalculateData;

		// Token: 0x0200BD91 RID: 48529
		[NullableContext(0)]
		private class ECompDefine
		{
			// Token: 0x0403A618 RID: 239128
			public const int PlayerName = 0;

			// Token: 0x0403A619 RID: 239129
			public const int PlayerId = 1;

			// Token: 0x0403A61A RID: 239130
			public const int WorldLevel = 2;

			// Token: 0x0403A61B RID: 239131
			public const int HelpBtn = 3;

			// Token: 0x0403A61C RID: 239132
			public const int PlayerLevel = 4;

			// Token: 0x0403A61D RID: 239133
			public const int PlayerExp = 5;

			// Token: 0x0403A61E RID: 239134
			public const int BackBtn = 6;

			// Token: 0x0403A61F RID: 239135
			public const int EndBtn = 7;

			// Token: 0x0403A620 RID: 239136
			public const int MailBtn = 8;

			// Token: 0x0403A621 RID: 239137
			public const int ExpProgressBar = 9;

			// Token: 0x0403A622 RID: 239138
			public const int FuncDraggable = 10;

			// Token: 0x0403A623 RID: 239139
			public const int PlayerTexture = 11;

			// Token: 0x0403A624 RID: 239140
			public const int TimeButton = 12;

			// Token: 0x0403A625 RID: 239141
			public const int SetUpButton = 13;

			// Token: 0x0403A626 RID: 239142
			public const int CopyUidButton = 14;

			// Token: 0x0403A627 RID: 239143
			public const int NoticeBtn = 15;

			// Token: 0x0403A628 RID: 239144
			public const int RedTipsRightBtn = 16;

			// Token: 0x0403A629 RID: 239145
			public const int RedTipsLeftBtn = 17;

			// Token: 0x0403A62A RID: 239146
			public const int RedTipsRight = 18;

			// Token: 0x0403A62B RID: 239147
			public const int RedTipsLeft = 19;

			// Token: 0x0403A62C RID: 239148
			public const int PhotoBtn = 20;

			// Token: 0x0403A62D RID: 239149
			public const int HeadIconButton = 21;

			// Token: 0x0403A62E RID: 239150
			public const int MoreButton = 22;

			// Token: 0x0403A62F RID: 239151
			public const int Card = 23;

			// Token: 0x0403A630 RID: 239152
			public const int SignButton = 24;

			// Token: 0x0403A631 RID: 239153
			public const int SignText = 25;

			// Token: 0x0403A632 RID: 239154
			public const int BirthText = 26;

			// Token: 0x0403A633 RID: 239155
			public const int NameButton = 27;

			// Token: 0x0403A634 RID: 239156
			public const int TabRoot = 28;

			// Token: 0x0403A635 RID: 239157
			public const int GridItem = 29;

			// Token: 0x0403A636 RID: 239158
			public const int GridInsideLayout = 30;

			// Token: 0x0403A637 RID: 239159
			public const int PanelTabItem = 31;

			// Token: 0x0403A638 RID: 239160
			public const int OnlineButton = 32;

			// Token: 0x0403A639 RID: 239161
			public const int NetStateSprite = 33;

			// Token: 0x0403A63A RID: 239162
			public const int PersonalRedDot = 34;

			// Token: 0x0403A63B RID: 239163
			public const int PersonalTipItem = 35;

			// Token: 0x0403A63C RID: 239164
			public const int CopyUidButtonSprite = 36;

			// Token: 0x0403A63D RID: 239165
			public const int MobilePreDownloadBtn = 37;

			// Token: 0x0403A63E RID: 239166
			public const int PlayerTitleItem = 38;

			// Token: 0x0403A63F RID: 239167
			public const int DownLoadPanel = 39;
		}
	}
}
