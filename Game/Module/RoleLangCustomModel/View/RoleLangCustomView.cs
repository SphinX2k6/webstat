using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Module.ResManager;
using CSharpScript.Game.Module.RoleLangCustomModel.View.Item;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Update;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using FilterDefine;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleLangCustomModel.View
{
	// Token: 0x020050F5 RID: 20725
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleLangCustomView : UiTickViewBase
	{
		// Token: 0x060356A3 RID: 218787 RVA: 0x00D66301 File Offset: 0x00D64501
		public RoleLangCustomView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x060356A4 RID: 218788 RVA: 0x00D66330 File Offset: 0x00D64530
		protected unsafe override void OnRegisterComponent()
		{
			int num = 13;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIScrollViewWithScrollbarComponent));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickedBtnRoleVoiceActing));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(11, new Action(this.OnClickedBtnFunctionDel));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060356A5 RID: 218789 RVA: 0x00D6656A File Offset: 0x00D6476A
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RoleLangCustomRefresh, new Action<int>(this.OnRoleLangCustomRefresh));
		}

		// Token: 0x060356A6 RID: 218790 RVA: 0x00D66588 File Offset: 0x00D64788
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.RoleLangCustomRefresh, new Action<int>(this.OnRoleLangCustomRefresh));
		}

		// Token: 0x060356A7 RID: 218791 RVA: 0x00D665A8 File Offset: 0x00D647A8
		protected override UniTask OnBeforeStartAsync()
		{
			RoleLangCustomView.<OnBeforeStartAsync>d__29 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoleLangCustomView.<OnBeforeStartAsync>d__29>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060356A8 RID: 218792 RVA: 0x00D665EC File Offset: 0x00D647EC
		protected override void OnStart()
		{
			this.FromRoleView = (ModelBase<MenuModel>.Instance.GetMenuDataByFunctionId(53) == null);
			if (!this.FromRoleView)
			{
				ControllerBase<ResourceManagerController>.Instance.ChangeHttpTickFrequency();
			}
			this.CurRoleId = ModelBase<RoleLangCustomModel>.Instance.RoleViewRoleId;
			ModelBase<RoleLangCustomModel>.Instance.RoleViewRoleId = 0;
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.CaptionItem.SetCloseCallBack(new Action(this.OnClickedBtnClose));
			this.CaptionItem.SetHelpCallBack(new Action(this.OnClickedBtnInfo));
			this.FilterRuleMap[RoleLangCustomView.filterTypeId] = new Dictionary<int, string>();
			this.FilterRuleMap[RoleLangCustomView.filterTypeLanguageId] = new Dictionary<int, string>();
			this.RoleList = ModelBase<RoleLangCustomModel>.Instance.GetRoleList();
			this.TopElementScroll = new GenericScrollViewNew<RoleLangCustomElementTabItem, int>(base.GetScrollViewWithScrollbar(12), new Func<RoleLangCustomElementTabItem>(this.CreateTopElementItem), null, false, null);
			this.RoleItemScroll = new GenericScrollViewNew<RoleLangCustomRoleItem, RoleInstance>(base.GetScrollViewWithScrollbar(3), new Func<RoleLangCustomRoleItem>(this.CreateRoleItem), null, false, null);
			this.VoiceScroll = new GenericScrollViewNew<RoleLangCustomLangSelectItem, IRoleLangCustomLangSelectInfo>(base.GetScrollViewWithScrollbar(7), new Func<RoleLangCustomLangSelectItem>(this.CreateVoiceActingItem), null, false, null);
			this.ConfirmBtn = new ButtonItem(base.GetItem(10));
			this.ConfirmBtn.SetFunction(new Action<int>(this.OnClickedBtnConfirmB));
			bool uiactive = ModelBase<RoleLangCustomModel>.Instance.NeedDeleteButton();
			UUIButtonComponent button = base.GetButton(1);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(uiactive);
			}
			UUIButtonComponent button2 = base.GetButton(11);
			if (button2 != null)
			{
				button2.RootUIComp.Get().SetUIActive(uiactive);
			}
			this.InitTab();
		}

		// Token: 0x060356A9 RID: 218793 RVA: 0x00D66795 File Offset: 0x00D64995
		protected override void OnAfterShow()
		{
			ModelBase<RoleLangCustomModel>.Instance.CheckServerVoiceDataSame(true);
		}

		// Token: 0x060356AA RID: 218794 RVA: 0x00D667A3 File Offset: 0x00D649A3
		protected override void OnBeforeDestroy()
		{
			if (this.FromRoleView)
			{
				if (ModelBase<MenuModel>.Instance.GetMenuDataByFunctionId(53) != null)
				{
					ModelBase<MenuModel>.Instance.ClearMenuDataMap();
				}
			}
			else
			{
				ControllerBase<ResourceManagerController>.Instance.RestoreHttpTickFrequency();
			}
			this.StopCurrentAudioEvent();
		}

		// Token: 0x060356AB RID: 218795 RVA: 0x00D667DC File Offset: 0x00D649DC
		protected override void OnTick(float delta)
		{
			List<RoleLangCustomLangSelectItem> scrollItemList = this.VoiceScroll.GetScrollItemList();
			bool flag = false;
			foreach (RoleLangCustomLangSelectItem roleLangCustomLangSelectItem in scrollItemList)
			{
				flag = (roleLangCustomLangSelectItem.OnTick(delta) || flag);
			}
			if (flag)
			{
				this.OnVoiceItemToggleStateChanged(this.CurStateData);
			}
		}

		// Token: 0x060356AC RID: 218796 RVA: 0x00D66848 File Offset: 0x00D64A48
		protected void InitTab()
		{
			this.CurElement = -1;
			FilterRule? filterRuleConfig = ConfigBase<FilterConfig>.Instance.GetFilterRuleConfig(1);
			List<int> list = new List<int>
			{
				0
			};
			foreach (int item in filterRuleConfig.Value.IdListIter())
			{
				list.Add(item);
			}
			this.TopElementScroll.RefreshByData(list, delegate
			{
				this.TopElementScroll.GetScrollItemList()[0].SetSelected(true, true);
				if (this.CurRoleId != 0)
				{
					this.OnRoleItemToggleStateChanged(this.CurRoleId);
				}
			}, false);
		}

		// Token: 0x060356AD RID: 218797 RVA: 0x00D668DC File Offset: 0x00D64ADC
		protected void RefreshVoiceItemButtonState()
		{
			foreach (RoleLangCustomLangSelectItem roleLangCustomLangSelectItem in this.VoiceScroll.GetScrollItemList())
			{
				roleLangCustomLangSelectItem.RefreshButtonState();
			}
		}

		// Token: 0x060356AE RID: 218798 RVA: 0x00D66934 File Offset: 0x00D64B34
		protected void StopCurrentAudioEvent()
		{
			if (!string.IsNullOrEmpty(this.OldAudioCode))
			{
				string roleLangStateGroup = ConfigBase<RoleConfig>.Instance.GetRoleLangStateGroup(this.OldCodeRoleId.Value);
				Singleton<AudioSystem>.Instance.SetState(roleLangStateGroup, this.OldAudioCode, false);
			}
			if (this.PlayAudioHandle != null && this.PlayAudioHandle.Value != 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.PlayAudioHandle.Value, EAudioActionType.Stop, null);
			}
			this.PlayAudioHandle = null;
			this.OldAudioCode = null;
			this.OldCodeRoleId = null;
		}

		// Token: 0x060356AF RID: 218799 RVA: 0x00D669D0 File Offset: 0x00D64BD0
		protected void RefreshConfirmBtn()
		{
			IRoleLangCustomLangSelectInfo curStateData = this.CurStateData;
			RoleLangCustomLangPackageInfo info = new RoleLangCustomLangPackageInfo
			{
				RoleId = curStateData.RoleId,
				LangIndex = curStateData.LangIndex
			};
			switch (ModelBase<RoleLangCustomModel>.Instance.GetDownloadStatus(info))
			{
			case ELanguageDownloadStatus.None:
			{
				ButtonItem confirmBtn = this.ConfirmBtn;
				if (confirmBtn != null)
				{
					confirmBtn.SetEnableClick(true);
				}
				ButtonItem confirmBtn2 = this.ConfirmBtn;
				if (confirmBtn2 == null)
				{
					return;
				}
				confirmBtn2.SetShowText("Btn_Download_VoiceDIY");
				return;
			}
			case ELanguageDownloadStatus.Half:
				if (ModelBase<RoleLangCustomModel>.Instance.GetUpdateManager().IsDownloading(info))
				{
					ButtonItem confirmBtn3 = this.ConfirmBtn;
					if (confirmBtn3 != null)
					{
						confirmBtn3.SetEnableClick(false);
					}
					ButtonItem confirmBtn4 = this.ConfirmBtn;
					if (confirmBtn4 == null)
					{
						return;
					}
					confirmBtn4.SetShowText("Btn_Downloading_VoiceDIY");
					return;
				}
				else
				{
					ButtonItem confirmBtn5 = this.ConfirmBtn;
					if (confirmBtn5 != null)
					{
						confirmBtn5.SetEnableClick(true);
					}
					ButtonItem confirmBtn6 = this.ConfirmBtn;
					if (confirmBtn6 == null)
					{
						return;
					}
					confirmBtn6.SetShowText("Btn_Download_VoiceDIY");
					return;
				}
				break;
			case ELanguageDownloadStatus.Done:
			{
				bool flag = ModelBase<RoleLangCustomModel>.Instance.GetRoleLangType(curStateData.RoleId) == curStateData.LangIndex;
				ButtonItem confirmBtn7 = this.ConfirmBtn;
				if (confirmBtn7 != null)
				{
					confirmBtn7.SetEnableClick(!flag);
				}
				string showText = flag ? "Btn_Applying_VoiceDIY" : "Btn_Apply_VoiceDIY";
				ButtonItem confirmBtn8 = this.ConfirmBtn;
				if (confirmBtn8 == null)
				{
					return;
				}
				confirmBtn8.SetShowText(showText);
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x060356B0 RID: 218800 RVA: 0x00D66AFC File Offset: 0x00D64CFC
		private void OnClickedBtnClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x060356B1 RID: 218801 RVA: 0x00D66B08 File Offset: 0x00D64D08
		private void OnClickedBtnRoleVoiceActing()
		{
			if (this.FromRoleView && ModelBase<MenuModel>.Instance.GetMenuDataByFunctionId(53) == null)
			{
				ModelBase<MenuModel>.Instance.CreateConfigByBaseConfig();
			}
			UiManager instance = Singleton<UiManager>.Instance;
			EUiViewName voiceLanguageDownloadView = EUiViewName.VoiceLanguageDownloadView;
			object[] array = new object[2];
			array[0] = ModelBase<MenuModel>.Instance.GetMenuDataByFunctionId(53);
			instance.OpenView(voiceLanguageDownloadView, array, null);
		}

		// Token: 0x060356B2 RID: 218802 RVA: 0x00D66B60 File Offset: 0x00D64D60
		private void OnClickedBtnConfirmB(int id)
		{
			switch (ModelBase<RoleLangCustomModel>.Instance.GetDownloadStatus(new RoleLangCustomLangPackageInfo
			{
				RoleId = this.CurRoleId,
				LangIndex = this.CurVoiceIndex
			}))
			{
			case ELanguageDownloadStatus.None:
			{
				if (ModelBase<RoleLangCustomModel>.Instance.CheckPackageAudioDownloading(this.CurVoiceIndex))
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("VoiceDIY_Tips_DownloadingEntireVoice", Array.Empty<object>());
					return;
				}
				RoleLangCustomLangPackageInfo info = new RoleLangCustomLangPackageInfo
				{
					RoleId = this.CurRoleId,
					LangIndex = this.CurVoiceIndex
				};
				ModelBase<RoleLangCustomModel>.Instance.StartDownloading(info);
				this.SetCurStateItemNeedTick();
				return;
			}
			case ELanguageDownloadStatus.Half:
			{
				RoleLangCustomLangPackageInfo info2 = new RoleLangCustomLangPackageInfo
				{
					RoleId = this.CurRoleId,
					LangIndex = this.CurVoiceIndex
				};
				if (ModelBase<RoleLangCustomModel>.Instance.GetUpdateManager().IsDownloading(info2))
				{
					return;
				}
				this.SetCurStateItemNeedTick();
				ModelBase<RoleLangCustomModel>.Instance.StartDownloading(info2);
				return;
			}
			case ELanguageDownloadStatus.Done:
			{
				this.StopCurrentAudioEvent();
				RoleLangSetVoiceParam playerVoice = new RoleLangSetVoiceParam
				{
					RoleId = this.CurRoleId,
					Lang = this.CurVoiceIndex,
					NeedRequest = true,
					IsCustom = true,
					IsCover = false
				};
				ModelBase<RoleLangCustomModel>.Instance.SetPlayerVoice(playerVoice);
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Notice_VoiceDIY_Setting_Success", Array.Empty<object>());
				this.PlayAudioHandle = new int?(ModelBase<RoleLangCustomModel>.Instance.PlayVoiceOnSetVoice(this.CurRoleId));
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x060356B3 RID: 218803 RVA: 0x00D66CB8 File Offset: 0x00D64EB8
		private void SetCurStateItemNeedTick()
		{
			foreach (RoleLangCustomLangSelectItem roleLangCustomLangSelectItem in this.VoiceScroll.GetScrollItemList())
			{
				if (roleLangCustomLangSelectItem.ItemData.RoleId == this.CurStateData.RoleId && roleLangCustomLangSelectItem.ItemData.LangIndex == this.CurStateData.LangIndex)
				{
					roleLangCustomLangSelectItem.SetNeedTick(true);
					break;
				}
			}
		}

		// Token: 0x060356B4 RID: 218804 RVA: 0x00D66D44 File Offset: 0x00D64F44
		private void OnClickedBtnFunctionDel()
		{
			RoleLangCustomDeleteInfo param = new RoleLangCustomDeleteInfo
			{
				RoleId = this.CurRoleId,
				RefreshCallback = delegate
				{
					this.OnRoleLangCustomRefresh(this.CurRoleId);
				},
				CloseCallback = new Action(this.OnCloseDelete)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleLangRemoveView, param, null);
			base.GetScrollViewWithScrollbar(7).RootUIComp.Get().SetAlpha(0f);
		}

		// Token: 0x060356B5 RID: 218805 RVA: 0x00D66DB8 File Offset: 0x00D64FB8
		private void OnCloseDelete()
		{
			base.GetScrollViewWithScrollbar(7).RootUIComp.Get().SetAlpha(1f);
		}

		// Token: 0x060356B6 RID: 218806 RVA: 0x00D66DE3 File Offset: 0x00D64FE3
		private RoleLangCustomElementTabItem CreateTopElementItem()
		{
			return new RoleLangCustomElementTabItem
			{
				OnToggleStateChangedCallback = new Action<int>(this.OnTopElementItemToggleStateChanged),
				OnToggleSelectedCheck = new Func<int, bool>(this.CheckTopElementItemSelectedCallback)
			};
		}

		// Token: 0x060356B7 RID: 218807 RVA: 0x00D66E10 File Offset: 0x00D65010
		private void OnTopElementItemToggleStateChanged(int elementId)
		{
			this.CurElement = elementId;
			if (elementId == 0)
			{
				this.FilterRuleMap[RoleLangCustomView.filterTypeId].Clear();
			}
			else
			{
				this.FilterRuleMap[RoleLangCustomView.filterTypeId].Clear();
				this.FilterRuleMap[RoleLangCustomView.filterTypeId][elementId] = "";
			}
			List<RoleInstance> result = ModelBase<FilterModel>.Instance.GetFilterList<RoleInstance>(this.RoleList, (int)RoleLangCustomView.filterGroupId, this.FilterRuleMap);
			bool flag = result.Count == 0;
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			this.RoleItemScroll.SetActive(!flag);
			UUIItem item2 = base.GetItem(5);
			if (item2 != null)
			{
				item2.SetUIActive(!flag);
			}
			foreach (RoleLangCustomElementTabItem roleLangCustomElementTabItem in this.TopElementScroll.GetScrollItemList())
			{
				roleLangCustomElementTabItem.RefreshSelected();
			}
			this.RoleItemScroll.RefreshByData(result, delegate
			{
				bool flag2 = false;
				int index = 0;
				for (int i = 0; i < result.Count; i++)
				{
					if (result[i].GetRoleId() == this.CurRoleId)
					{
						flag2 = true;
						index = i;
						break;
					}
				}
				if (!flag2 && result.Count > 0)
				{
					this.CurRoleId = result[0].GetRoleId();
					RoleLangCustomRoleItem scrollItemByIndex = this.RoleItemScroll.GetScrollItemByIndex(0);
					if (scrollItemByIndex != null)
					{
						scrollItemByIndex.SetSelected(true, true);
					}
				}
				UUIItem itemByIndex = this.RoleItemScroll.GetItemByIndex(index);
				this.GetScrollViewWithScrollbar(3).ScrollToTopLater(itemByIndex, false);
			}, true);
		}

		// Token: 0x060356B8 RID: 218808 RVA: 0x00D66F4C File Offset: 0x00D6514C
		private bool CheckTopElementItemSelectedCallback(int elementId)
		{
			return elementId == this.CurElement;
		}

		// Token: 0x060356B9 RID: 218809 RVA: 0x00D66F57 File Offset: 0x00D65157
		private RoleLangCustomRoleItem CreateRoleItem()
		{
			return new RoleLangCustomRoleItem
			{
				OnToggleStateChangedCallback = new Action<int>(this.OnRoleItemToggleStateChanged),
				OnToggleSelectedCheck = new Func<int, bool>(this.CheckRoleSelectedCallback)
			};
		}

		// Token: 0x060356BA RID: 218810 RVA: 0x00D66F84 File Offset: 0x00D65184
		private void OnRoleItemToggleStateChanged(int roleId)
		{
			this.CurRoleId = roleId;
			this.CurVoiceIndex = ModelBase<RoleLangCustomModel>.Instance.GetRoleLangType(roleId);
			List<int> allLanguageTypeForAudio = Singleton<LanguageUpdateManager>.Instance.GetAllLanguageTypeForAudio();
			allLanguageTypeForAudio.Sort((int a, int b) => a - b);
			List<IRoleLangCustomLangSelectInfo> list = new List<IRoleLangCustomLangSelectInfo>();
			foreach (int num in allLanguageTypeForAudio)
			{
				RoleLangCustomLangSelectInfo roleLangCustomLangSelectInfo = new RoleLangCustomLangSelectInfo
				{
					RoleId = roleId,
					LangIndex = num
				};
				if (num == this.CurVoiceIndex)
				{
					this.CurStateData = roleLangCustomLangSelectInfo;
				}
				list.Add(roleLangCustomLangSelectInfo);
			}
			this.StopCurrentAudioEvent();
			this.CurrentIsPlayingInfo = null;
			this.VoiceScroll.RefreshByData(list, null, false);
			ButtonItem confirmBtn = this.ConfirmBtn;
			if (confirmBtn != null)
			{
				confirmBtn.SetEnableClick(false);
			}
			ButtonItem confirmBtn2 = this.ConfirmBtn;
			if (confirmBtn2 != null)
			{
				confirmBtn2.SetShowText("Btn_Applying_VoiceDIY");
			}
			foreach (RoleLangCustomRoleItem roleLangCustomRoleItem in this.RoleItemScroll.GetScrollItemList())
			{
				roleLangCustomRoleItem.RefreshByData();
			}
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId);
			if (ModelBase<RoleModel>.Instance.IsMainRole(roleId))
			{
				UUIText text = base.GetText(6);
				if (text == null)
				{
					return;
				}
				text.SetText(ModelBase<FunctionModel>.Instance.GetPlayerName() ?? "", true);
				return;
			}
			else
			{
				UUIText text2 = base.GetText(6);
				if (text2 == null)
				{
					return;
				}
				text2.ShowTextNew(roleConfig.Value.Name);
				return;
			}
		}

		// Token: 0x060356BB RID: 218811 RVA: 0x00D67130 File Offset: 0x00D65330
		private bool CheckRoleSelectedCallback(int roleId)
		{
			return roleId == this.CurRoleId;
		}

		// Token: 0x060356BC RID: 218812 RVA: 0x00D6713C File Offset: 0x00D6533C
		private RoleLangCustomLangSelectItem CreateVoiceActingItem()
		{
			return new RoleLangCustomLangSelectItem
			{
				OnToggleStateChangedCallback = new Action<IRoleLangCustomLangSelectInfo>(this.OnVoiceItemToggleStateChanged),
				OnToggleSelectedCheck = new Func<IRoleLangCustomLangSelectInfo, bool>(this.CheckVoiceSelectedCallback),
				CheckCurrentIsPlayingCallback = new Func<IRoleLangCustomLangSelectInfo, bool>(this.CheckVoiceCurrentIsPlayingCallback),
				OnPlayAudioCallback = new Action<IRoleLangCustomLangSelectInfo>(this.OnPlayAudio)
			};
		}

		// Token: 0x060356BD RID: 218813 RVA: 0x00D67198 File Offset: 0x00D65398
		private void OnVoiceItemToggleStateChanged(IRoleLangCustomLangSelectInfo data)
		{
			this.CurVoiceIndex = data.LangIndex;
			this.CurStateData = data;
			this.RefreshConfirmBtn();
			foreach (RoleLangCustomLangSelectItem roleLangCustomLangSelectItem in this.VoiceScroll.GetScrollItemList())
			{
				roleLangCustomLangSelectItem.SetSelected(this.CheckVoiceSelectedCallback(roleLangCustomLangSelectItem.ItemData), false);
			}
		}

		// Token: 0x060356BE RID: 218814 RVA: 0x00D67218 File Offset: 0x00D65418
		private bool CheckVoiceCurrentIsPlayingCallback(IRoleLangCustomLangSelectInfo data)
		{
			return this.PlayAudioHandle != null && data == this.CurrentIsPlayingInfo;
		}

		// Token: 0x060356BF RID: 218815 RVA: 0x00D67234 File Offset: 0x00D65434
		private void OnPlayAudio(IRoleLangCustomLangSelectInfo data)
		{
			this.StopCurrentAudioEvent();
			if (data == this.CurrentIsPlayingInfo)
			{
				this.CurrentIsPlayingInfo = null;
				return;
			}
			if (this.CurrentIsPlayingInfo != null)
			{
				this.IsNormalEnd = false;
				this.StopCurrentAudioEvent();
				this.RefreshVoiceItemButtonState();
			}
			this.CurrentIsPlayingInfo = data;
			int roleLangType = ModelBase<RoleLangCustomModel>.Instance.GetRoleLangType(data.RoleId);
			this.OldAudioCode = Singleton<LanguageSystem>.Instance.GetLanguageDefineByType(roleLangType).AudioCode;
			this.OldCodeRoleId = new int?(data.RoleId);
			int langIndex = data.LangIndex;
			global::LanguageDefine languageDefineByType = Singleton<LanguageSystem>.Instance.GetLanguageDefineByType(langIndex);
			string roleLangStateGroup = ConfigBase<RoleConfig>.Instance.GetRoleLangStateGroup(data.RoleId);
			Singleton<AudioSystem>.Instance.SetState(roleLangStateGroup, languageDefineByType.AudioCode, false);
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(data.RoleId, true);
			RoleSkinAudio? roleConfig = ConfigBase<AudioConfig>.Instance.GetRoleConfig(roleDataById.GetRoleSkinId());
			this.PlayAudioHandle = new int?(Singleton<AudioSystem>.Instance.PostEvent(roleConfig.Value.JoinTeamEvent, null, new PostEventArgs?(new PostEventArgs
			{
				CallbackMask = new ECallbackMask?(ECallbackMask.EndOfEvent),
				CallbackHandler = delegate(EAkCallbackType callbackType, UAkCallbackInfo callbackInfo)
				{
					if (callbackType == EAkCallbackType.EndOfEvent && this.IsNormalEnd)
					{
						this.PlayAudioHandle = null;
						this.StopCurrentAudioEvent();
						this.RefreshVoiceItemButtonState();
						this.CurrentIsPlayingInfo = null;
					}
					this.IsNormalEnd = true;
				}
			})));
		}

		// Token: 0x060356C0 RID: 218816 RVA: 0x00D67365 File Offset: 0x00D65565
		private bool CheckVoiceSelectedCallback(IRoleLangCustomLangSelectInfo data)
		{
			return this.CurVoiceIndex == data.LangIndex;
		}

		// Token: 0x060356C1 RID: 218817 RVA: 0x00D67375 File Offset: 0x00D65575
		private void OnRoleLangCustomRefresh(int roleId)
		{
			if (roleId != this.CurRoleId && roleId != -1)
			{
				return;
			}
			this.OnRoleItemToggleStateChanged(this.CurRoleId);
		}

		// Token: 0x060356C2 RID: 218818 RVA: 0x00D67391 File Offset: 0x00D65591
		private void OnClickedBtnInfo()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(615);
		}

		// Token: 0x060356C3 RID: 218819 RVA: 0x00D673A4 File Offset: 0x00D655A4
		private void OnChangeLanguageFilter(int langType)
		{
			if (langType < 0)
			{
				this.FilterRuleMap[RoleLangCustomView.filterTypeLanguageId].Clear();
			}
			else
			{
				this.FilterRuleMap[RoleLangCustomView.filterTypeLanguageId].Clear();
				this.FilterRuleMap[RoleLangCustomView.filterTypeLanguageId][langType] = "";
			}
			List<RoleInstance> result = ModelBase<FilterModel>.Instance.GetFilterList<RoleInstance>(this.RoleList, (int)RoleLangCustomView.filterGroupId, this.FilterRuleMap);
			bool flag = result.Count == 0;
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			this.RoleItemScroll.SetActive(!flag);
			UUIItem item2 = base.GetItem(5);
			if (item2 != null)
			{
				item2.SetUIActive(!flag);
			}
			foreach (RoleLangCustomElementTabItem roleLangCustomElementTabItem in this.TopElementScroll.GetScrollItemList())
			{
				roleLangCustomElementTabItem.RefreshSelected();
			}
			this.RoleItemScroll.RefreshByData(result, delegate
			{
				bool flag2 = false;
				using (List<RoleInstance>.Enumerator enumerator2 = result.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (enumerator2.Current.GetRoleId() == this.CurRoleId)
						{
							flag2 = true;
							break;
						}
					}
				}
				if (!flag2 && result.Count > 0)
				{
					this.CurRoleId = result[0].GetRoleId();
					RoleLangCustomRoleItem scrollItemByIndex = this.RoleItemScroll.GetScrollItemByIndex(0);
					if (scrollItemByIndex == null)
					{
						return;
					}
					scrollItemByIndex.SetSelected(true, true);
				}
			}, true);
		}

		// Token: 0x0401EAE4 RID: 125668
		private const int HELP_ID = 615;

		// Token: 0x0401EAE5 RID: 125669
		private const int FILTER_RULE_ID = 1;

		// Token: 0x0401EAE6 RID: 125670
		private static readonly EFilterSortGroupId filterGroupId = EFilterSortGroupId.Role;

		// Token: 0x0401EAE7 RID: 125671
		private static readonly FilterDefine.EFilterType filterTypeId = FilterDefine.EFilterType.Element;

		// Token: 0x0401EAE8 RID: 125672
		private static readonly FilterDefine.EFilterType filterTypeLanguageId = FilterDefine.EFilterType.RoleLangCustomType;

		// Token: 0x0401EAE9 RID: 125673
		private const int FILTER_ALL_ID = 0;

		// Token: 0x0401EAEA RID: 125674
		protected int CurElement = -1;

		// Token: 0x0401EAEB RID: 125675
		protected int CurRoleId;

		// Token: 0x0401EAEC RID: 125676
		protected int CurVoiceIndex;

		// Token: 0x0401EAED RID: 125677
		protected IRoleLangCustomLangSelectInfo CurStateData;

		// Token: 0x0401EAEE RID: 125678
		protected PopupCaptionItem CaptionItem;

		// Token: 0x0401EAEF RID: 125679
		protected RoleLangCustomLangFilter RoleCustomItem;

		// Token: 0x0401EAF0 RID: 125680
		protected GenericScrollViewNew<RoleLangCustomElementTabItem, int> TopElementScroll;

		// Token: 0x0401EAF1 RID: 125681
		protected GenericScrollViewNew<RoleLangCustomRoleItem, RoleInstance> RoleItemScroll;

		// Token: 0x0401EAF2 RID: 125682
		protected GenericScrollViewNew<RoleLangCustomLangSelectItem, IRoleLangCustomLangSelectInfo> VoiceScroll;

		// Token: 0x0401EAF3 RID: 125683
		protected List<RoleInstance> RoleList = new List<RoleInstance>();

		// Token: 0x0401EAF4 RID: 125684
		protected Dictionary<FilterDefine.EFilterType, Dictionary<int, string>> FilterRuleMap = new Dictionary<FilterDefine.EFilterType, Dictionary<int, string>>();

		// Token: 0x0401EAF5 RID: 125685
		[Nullable(2)]
		protected IRoleLangCustomLangSelectInfo CurrentIsPlayingInfo;

		// Token: 0x0401EAF6 RID: 125686
		protected int? PlayAudioHandle;

		// Token: 0x0401EAF7 RID: 125687
		[Nullable(2)]
		protected string OldAudioCode;

		// Token: 0x0401EAF8 RID: 125688
		protected int? OldCodeRoleId;

		// Token: 0x0401EAF9 RID: 125689
		protected bool IsNormalEnd = true;

		// Token: 0x0401EAFA RID: 125690
		[Nullable(2)]
		protected ButtonItem ConfirmBtn;

		// Token: 0x0401EAFB RID: 125691
		protected bool FromRoleView;

		// Token: 0x0200B08D RID: 45197
		[NullableContext(0)]
		private enum EDefine
		{
			// Token: 0x04036C74 RID: 224372
			Caption,
			// Token: 0x04036C75 RID: 224373
			BtnRoleVoiceActing,
			// Token: 0x04036C76 RID: 224374
			PanelEmpty,
			// Token: 0x04036C77 RID: 224375
			RoleItemScroll,
			// Token: 0x04036C78 RID: 224376
			RoleVoiceActingCardItem,
			// Token: 0x04036C79 RID: 224377
			PanelRight,
			// Token: 0x04036C7A RID: 224378
			TxtTitle,
			// Token: 0x04036C7B RID: 224379
			VoiceActingItemScroll,
			// Token: 0x04036C7C RID: 224380
			VoiceActingItem,
			// Token: 0x04036C7D RID: 224381
			RoleVoiceSort,
			// Token: 0x04036C7E RID: 224382
			BtnConfirmB,
			// Token: 0x04036C7F RID: 224383
			BtnFunctionDel,
			// Token: 0x04036C80 RID: 224384
			TopMenuItemScroll
		}
	}
}
