using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhoneMessage;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200256E RID: 9582
[NullableContext(1)]
[Nullable(0)]
public class PhoneMsgSettingView : UiViewBase
{
	// Token: 0x06012A2C RID: 76332 RVA: 0x00522DF9 File Offset: 0x00520FF9
	public PhoneMsgSettingView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06012A2D RID: 76333 RVA: 0x00522E28 File Offset: 0x00521028
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(3, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(4, typeof(UUIMultiTemplateScrollViewComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUITexture)),
			new ValueTuple<int, Type>(11, typeof(UUIText)),
			new ValueTuple<int, Type>(12, typeof(UUIText)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUITexture)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUIItem)),
			new ValueTuple<int, Type>(18, typeof(UUIItem)),
			new ValueTuple<int, Type>(19, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnClickDialogTab)),
			new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.OnClickBgTab))
		};
	}

	// Token: 0x06012A2E RID: 76334 RVA: 0x00523040 File Offset: 0x00521240
	protected override UniTask OnBeforeStartAsync()
	{
		PhoneMsgSettingView.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PhoneMsgSettingView.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012A2F RID: 76335 RVA: 0x00523083 File Offset: 0x00521283
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.PhoneMsgDialogAndBgUpdate, new Action(this.AfterDialogAndBgUpdate));
		this.RefreshRedDot();
	}

	// Token: 0x06012A30 RID: 76336 RVA: 0x005230A7 File Offset: 0x005212A7
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.PhoneMsgDialogAndBgUpdate, new Action(this.AfterDialogAndBgUpdate));
	}

	// Token: 0x06012A31 RID: 76337 RVA: 0x005230C8 File Offset: 0x005212C8
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhoneMsgChatShowChange, new Action(this.AfterChatShowChange));
		Singleton<EventSystem>.Instance.Add(EEventName.OnNameChange, new Action(this.OnNameChange));
		Singleton<EventSystem>.Instance.Add(EEventName.PhoneMsgDialogAndBgRedDotUpdate, new Action(this.RefreshRedDot));
	}

	// Token: 0x06012A32 RID: 76338 RVA: 0x0052312C File Offset: 0x0052132C
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhoneMsgChatShowChange, new Action(this.AfterChatShowChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnNameChange, new Action(this.OnNameChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.PhoneMsgDialogAndBgRedDotUpdate, new Action(this.RefreshRedDot));
	}

	// Token: 0x06012A33 RID: 76339 RVA: 0x0052318D File Offset: 0x0052138D
	private void OnNameChange()
	{
		this.RightChatItem.OnNameChange();
	}

	// Token: 0x06012A34 RID: 76340 RVA: 0x0052319A File Offset: 0x0052139A
	private void AfterChatShowChange()
	{
		this.BuildDialogItemDataList();
		this.BuildBgItemDataList();
		this.RefreshDataAndScrollView(true);
		this.RefreshConfirmBtnOrGetLinkBtnShow();
	}

	// Token: 0x06012A35 RID: 76341 RVA: 0x005231B5 File Offset: 0x005213B5
	private void AfterDialogAndBgUpdate()
	{
		this.BuildDialogItemDataList();
		this.BuildBgItemDataList();
		this.RefreshDataAndScrollView(false);
		this.RefreshConfirmBtnOrGetLinkBtnShow();
	}

	// Token: 0x06012A36 RID: 76342 RVA: 0x005231D0 File Offset: 0x005213D0
	private void RefreshRedDot()
	{
		List<IMultiTemplateGridData> dialogItemDataList = this.DialogItemDataList;
		bool uiactive = false;
		foreach (IMultiTemplateGridData multiTemplateGridData in dialogItemDataList)
		{
			SettingViewLeftDialogItemData settingViewLeftDialogItemData = multiTemplateGridData as SettingViewLeftDialogItemData;
			if (settingViewLeftDialogItemData != null && settingViewLeftDialogItemData.Data.IsHasRedDot())
			{
				uiactive = true;
				break;
			}
		}
		base.GetItem(18).SetUIActive(uiactive);
		List<IMultiTemplateGridData> bgItemDataList = this.BgItemDataList;
		bool uiactive2 = false;
		foreach (IMultiTemplateGridData multiTemplateGridData2 in bgItemDataList)
		{
			SettingViewLeftBgItemData settingViewLeftBgItemData = multiTemplateGridData2 as SettingViewLeftBgItemData;
			if (settingViewLeftBgItemData != null && settingViewLeftBgItemData.Data.IsHasRedDot())
			{
				uiactive2 = true;
				break;
			}
		}
		base.GetItem(19).SetUIActive(uiactive2);
	}

	// Token: 0x06012A37 RID: 76343 RVA: 0x005232AC File Offset: 0x005214AC
	private void OnClickDialogTab(EToggleState toggleState)
	{
		PhoneMsgSettingView.ETarget? curTarget = this.CurTarget;
		PhoneMsgSettingView.ETarget etarget = PhoneMsgSettingView.ETarget.Dialog;
		if (!(curTarget.GetValueOrDefault() == etarget & curTarget != null))
		{
			this.SwitchTarget(PhoneMsgSettingView.ETarget.Dialog);
		}
	}

	// Token: 0x06012A38 RID: 76344 RVA: 0x005232DD File Offset: 0x005214DD
	private void OnClickBgTab(EToggleState toggleState)
	{
		if (this.CurTarget.GetValueOrDefault() != PhoneMsgSettingView.ETarget.Bg)
		{
			this.SwitchTarget(PhoneMsgSettingView.ETarget.Bg);
		}
	}

	// Token: 0x06012A39 RID: 76345 RVA: 0x005232F4 File Offset: 0x005214F4
	private void RefreshDataAndScrollView(bool isNeedRefreshSelect = true)
	{
		if (this.CurTarget == null)
		{
			return;
		}
		PhoneMsgSettingView.ETarget value = this.CurTarget.Value;
		if (value != PhoneMsgSettingView.ETarget.Dialog)
		{
			if (value == PhoneMsgSettingView.ETarget.Bg)
			{
				if (this.BgItemDataList.Count > 0)
				{
					if (isNeedRefreshSelect)
					{
						((SettingViewLeftBgItemData)this.BgItemDataList[0]).Data.IsSelected = true;
						this.CurSelectedBgIndex = 0;
					}
					else
					{
						for (int i = 0; i < this.BgItemDataList.Count; i++)
						{
							SettingViewLeftBgItemData settingViewLeftBgItemData = (SettingViewLeftBgItemData)this.BgItemDataList[i];
							if (settingViewLeftBgItemData.GetBgId() == this.CurPreviewBgId)
							{
								settingViewLeftBgItemData.Data.IsSelected = true;
								this.CurSelectedBgIndex = i;
								break;
							}
						}
					}
				}
				MultiTemplateScrollViewRefreshContext context = new MultiTemplateScrollViewRefreshContext(this.BgItemDataList);
				this.LeftScrollView.RefreshByData(context);
			}
		}
		else
		{
			if (this.DialogItemDataList.Count > 0)
			{
				if (isNeedRefreshSelect)
				{
					((SettingViewLeftDialogItemData)this.DialogItemDataList[0]).Data.IsSelected = true;
					this.CurSelectedDialogIndex = 0;
				}
				else
				{
					for (int j = 0; j < this.DialogItemDataList.Count; j++)
					{
						SettingViewLeftDialogItemData settingViewLeftDialogItemData = (SettingViewLeftDialogItemData)this.DialogItemDataList[j];
						if (settingViewLeftDialogItemData.GetDialogId() == this.CurPreviewDialogId)
						{
							settingViewLeftDialogItemData.Data.IsSelected = true;
							this.CurSelectedDialogIndex = j;
							break;
						}
					}
				}
			}
			MultiTemplateScrollViewRefreshContext context2 = new MultiTemplateScrollViewRefreshContext(this.DialogItemDataList);
			this.LeftScrollView.RefreshByData(context2);
		}
		this.LeftChatItem.RefreshSpeakerNameTextColor(this.CurPreviewBgId);
		this.RightChatItem.RefreshSpeakerNameTextColor(this.CurPreviewBgId);
	}

	// Token: 0x06012A3A RID: 76346 RVA: 0x00523490 File Offset: 0x00521690
	private void SwitchTarget(PhoneMsgSettingView.ETarget target)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(2);
		UUIExtendToggle extendToggle2 = base.GetExtendToggle(3);
		if (target != PhoneMsgSettingView.ETarget.Dialog)
		{
			if (target == PhoneMsgSettingView.ETarget.Bg)
			{
				MultiTemplateScrollViewRefreshContext context = new MultiTemplateScrollViewRefreshContext(this.BgItemDataList);
				this.LeftScrollView.RefreshByData(context);
				extendToggle2.SetToggleState(EToggleState.ETT_Checked, false, false, false);
				this.CurTarget = new PhoneMsgSettingView.ETarget?(PhoneMsgSettingView.ETarget.Bg);
				extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
				this.RefreshBg();
			}
		}
		else
		{
			MultiTemplateScrollViewRefreshContext context2 = new MultiTemplateScrollViewRefreshContext(this.DialogItemDataList);
			this.LeftScrollView.RefreshByData(context2);
			extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
			this.CurTarget = new PhoneMsgSettingView.ETarget?(PhoneMsgSettingView.ETarget.Dialog);
			extendToggle2.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			this.RefreshDialog();
		}
		this.RefreshConfirmBtnOrGetLinkBtnShow();
	}

	// Token: 0x06012A3B RID: 76347 RVA: 0x00523544 File Offset: 0x00521744
	private void BuildDialogItemDataList()
	{
		this.DialogItemDataList.Clear();
		IReadOnlyList<ChatDialog> allChatDialogConfigList = ConfigBase<PhoneMsgConfig>.Instance.GetAllChatDialogConfigList();
		if (allChatDialogConfigList == null)
		{
			return;
		}
		List<SettingViewLeftDialogItemData> list = new List<SettingViewLeftDialogItemData>();
		List<SettingViewLeftDialogItemData> list2 = new List<SettingViewLeftDialogItemData>();
		int count = allChatDialogConfigList.Count;
		for (int i = 0; i < count; i++)
		{
			ChatDialog chatDialog = allChatDialogConfigList[i];
			PhoneMsgDialogItemData phoneMsgDialogItemData = new PhoneMsgDialogItemData();
			phoneMsgDialogItemData.DialogId = chatDialog.Id;
			phoneMsgDialogItemData.IsUnlocked = ModelBase<PhoneMsgModel>.Instance.IsChatDialogUnlocked(chatDialog.Id);
			phoneMsgDialogItemData.IsUsing = (ModelBase<PhoneMsgModel>.Instance.CurrentUsingChatDialogId == chatDialog.Id);
			phoneMsgDialogItemData.IsSelected = false;
			SettingViewLeftDialogItemData settingViewLeftDialogItemData = new SettingViewLeftDialogItemData(phoneMsgDialogItemData);
			settingViewLeftDialogItemData.OnToggleCallBack = new Action<int, PhoneMsgDialogItemData>(this.DialogItemToggleClick);
			if (phoneMsgDialogItemData.IsUsing)
			{
				this.DialogItemDataList.Add(settingViewLeftDialogItemData);
			}
			else if (phoneMsgDialogItemData.IsUnlocked)
			{
				list.Add(settingViewLeftDialogItemData);
			}
			else
			{
				list2.Add(settingViewLeftDialogItemData);
			}
		}
		this.SortItemDataListBySortId<SettingViewLeftDialogItemData>(list);
		this.SortItemDataListBySortId<SettingViewLeftDialogItemData>(list2);
		this.DialogItemDataList.AddRange(list);
		this.DialogItemDataList.AddRange(list2);
	}

	// Token: 0x06012A3C RID: 76348 RVA: 0x00523664 File Offset: 0x00521864
	private void BuildBgItemDataList()
	{
		this.BgItemDataList.Clear();
		IReadOnlyList<ChatBg> allChatBgConfigList = ConfigBase<PhoneMsgConfig>.Instance.GetAllChatBgConfigList();
		if (allChatBgConfigList == null)
		{
			return;
		}
		List<SettingViewLeftBgItemData> list = new List<SettingViewLeftBgItemData>();
		List<SettingViewLeftBgItemData> list2 = new List<SettingViewLeftBgItemData>();
		int count = allChatBgConfigList.Count;
		for (int i = 0; i < count; i++)
		{
			ChatBg chatBg = allChatBgConfigList[i];
			PhoneMsgBgItemData phoneMsgBgItemData = new PhoneMsgBgItemData();
			phoneMsgBgItemData.BgId = chatBg.Id;
			phoneMsgBgItemData.IsUnlocked = ModelBase<PhoneMsgModel>.Instance.IsChatBgUnlocked(chatBg.Id);
			phoneMsgBgItemData.IsUsing = (ModelBase<PhoneMsgModel>.Instance.CurrentUsingChatBgId == chatBg.Id);
			phoneMsgBgItemData.IsSelected = false;
			SettingViewLeftBgItemData settingViewLeftBgItemData = new SettingViewLeftBgItemData(phoneMsgBgItemData);
			settingViewLeftBgItemData.OnToggleCallBack = new Action<int, PhoneMsgBgItemData>(this.BgItemToggleClick);
			if (phoneMsgBgItemData.IsUsing)
			{
				this.BgItemDataList.Add(settingViewLeftBgItemData);
			}
			else if (phoneMsgBgItemData.IsUnlocked)
			{
				list.Add(settingViewLeftBgItemData);
			}
			else
			{
				list2.Add(settingViewLeftBgItemData);
			}
		}
		this.SortItemDataListBySortId<SettingViewLeftBgItemData>(list);
		this.SortItemDataListBySortId<SettingViewLeftBgItemData>(list2);
		this.BgItemDataList.AddRange(list);
		this.BgItemDataList.AddRange(list2);
	}

	// Token: 0x06012A3D RID: 76349 RVA: 0x00523782 File Offset: 0x00521982
	private void SortItemDataListBySortId<[Nullable(0)] T>(List<T> list) where T : IMultiTemplateGridData
	{
		list.Sort(delegate(T a, T b)
		{
			int num = 0;
			int num2 = 0;
			PhoneMsgDialogItemData phoneMsgDialogItemData = a.Data as PhoneMsgDialogItemData;
			if (phoneMsgDialogItemData != null)
			{
				ChatDialog? chatDialogConfig = ConfigBase<PhoneMsgConfig>.Instance.GetChatDialogConfig(phoneMsgDialogItemData.DialogId);
				num = ((chatDialogConfig != null) ? chatDialogConfig.GetValueOrDefault().SortId : 0);
			}
			else
			{
				PhoneMsgBgItemData phoneMsgBgItemData = a.Data as PhoneMsgBgItemData;
				if (phoneMsgBgItemData != null)
				{
					ChatBg? chatBgConfig = ConfigBase<PhoneMsgConfig>.Instance.GetChatBgConfig(phoneMsgBgItemData.BgId);
					num = ((chatBgConfig != null) ? chatBgConfig.GetValueOrDefault().SortId : 0);
				}
			}
			PhoneMsgDialogItemData phoneMsgDialogItemData2 = b.Data as PhoneMsgDialogItemData;
			if (phoneMsgDialogItemData2 != null)
			{
				ChatDialog? chatDialogConfig2 = ConfigBase<PhoneMsgConfig>.Instance.GetChatDialogConfig(phoneMsgDialogItemData2.DialogId);
				num2 = ((chatDialogConfig2 != null) ? chatDialogConfig2.GetValueOrDefault().SortId : 0);
			}
			else
			{
				PhoneMsgBgItemData phoneMsgBgItemData2 = b.Data as PhoneMsgBgItemData;
				if (phoneMsgBgItemData2 != null)
				{
					ChatBg? chatBgConfig2 = ConfigBase<PhoneMsgConfig>.Instance.GetChatBgConfig(phoneMsgBgItemData2.BgId);
					num2 = ((chatBgConfig2 != null) ? chatBgConfig2.GetValueOrDefault().SortId : 0);
				}
			}
			return num2 - num;
		});
	}

	// Token: 0x06012A3E RID: 76350 RVA: 0x005237AC File Offset: 0x005219AC
	private void RefreshDialog()
	{
		ChatDialog? chatDialogConfig = ConfigBase<PhoneMsgConfig>.Instance.GetChatDialogConfig(this.CurPreviewDialogId);
		if (chatDialogConfig == null)
		{
			return;
		}
		this.RightChatItem.RefreshDialog(this.CurPreviewDialogId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), chatDialogConfig.Value.Name, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), chatDialogConfig.Value.Desc, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), chatDialogConfig.Value.GetWay, Array.Empty<object>());
	}

	// Token: 0x06012A3F RID: 76351 RVA: 0x00523858 File Offset: 0x00521A58
	private void RefreshBg()
	{
		ChatBg? chatBgConfig = ConfigBase<PhoneMsgConfig>.Instance.GetChatBgConfig(this.CurPreviewBgId);
		if (chatBgConfig == null)
		{
			return;
		}
		UUITexture texture = base.GetTexture(10);
		base.SetTextureByPath(chatBgConfig.Value.ChatBgPathBig, texture, null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), chatBgConfig.Value.Name, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), chatBgConfig.Value.Desc, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), chatBgConfig.Value.GetWay, Array.Empty<object>());
		this.LeftChatItem.RefreshSpeakerNameTextColor(this.CurPreviewBgId);
		this.RightChatItem.RefreshSpeakerNameTextColor(this.CurPreviewBgId);
	}

	// Token: 0x06012A40 RID: 76352 RVA: 0x00523940 File Offset: 0x00521B40
	private void RefreshConfirmBtnOrGetLinkBtnShow()
	{
		bool flag = false;
		bool enableClick = false;
		bool flag2 = false;
		object obj = null;
		PhoneMsgModel instance = ModelBase<PhoneMsgModel>.Instance;
		if (this.CurTarget == null)
		{
			return;
		}
		PhoneMsgSettingView.ETarget value = this.CurTarget.Value;
		if (value != PhoneMsgSettingView.ETarget.Dialog)
		{
			if (value == PhoneMsgSettingView.ETarget.Bg)
			{
				flag = instance.IsChatBgUnlocked(this.CurPreviewBgId);
				obj = ConfigBase<PhoneMsgConfig>.Instance.GetChatBgConfig(this.CurPreviewBgId);
				enableClick = (flag && instance.CurrentUsingChatBgId != this.CurPreviewBgId);
				flag2 = (instance.CurrentUsingChatBgId == this.CurPreviewBgId);
			}
		}
		else
		{
			flag = instance.IsChatDialogUnlocked(this.CurPreviewDialogId);
			obj = ConfigBase<PhoneMsgConfig>.Instance.GetChatDialogConfig(this.CurPreviewDialogId);
			enableClick = (flag && instance.CurrentUsingChatDialogId != this.CurPreviewDialogId);
			flag2 = (instance.CurrentUsingChatDialogId == this.CurPreviewDialogId);
		}
		if (obj == null)
		{
			return;
		}
		bool flag3 = false;
		if (obj is ChatDialog)
		{
			flag3 = (((ChatDialog)obj).ItemAccessLength > 0);
		}
		else if (obj is ChatBg)
		{
			flag3 = (((ChatBg)obj).ItemAccessLength > 0);
		}
		base.GetItem(8).SetUIActive(false);
		base.GetItem(15).SetUIActive(false);
		if (flag || !flag3)
		{
			base.GetItem(8).SetUIActive(true);
			this.ConfirmBtn.SetEnableClick(enableClick);
			string textId = flag2 ? "Text_InUse_Text" : "ChatBubble_SettingUse";
			this.ConfirmBtn.SetLocalTextNew(textId, Array.Empty<object>());
			return;
		}
		base.GetItem(15).SetUIActive(true);
		if (obj is ChatDialog)
		{
			ChatDialog chatDialog = (ChatDialog)obj;
			this.GetLinkBtn.RefreshByGetWayId(chatDialog.ItemAccess(0));
			return;
		}
		if (obj is ChatBg)
		{
			ChatBg chatBg = (ChatBg)obj;
			this.GetLinkBtn.RefreshByGetWayId(chatBg.ItemAccess(0));
		}
	}

	// Token: 0x06012A41 RID: 76353 RVA: 0x00523B18 File Offset: 0x00521D18
	private void DialogItemToggleClick(int gridIndex, PhoneMsgDialogItemData newDialogData)
	{
		if (this.CurSelectedDialogIndex >= 0)
		{
			int curSelectedDialogIndex = this.CurSelectedDialogIndex;
			((PhoneMsgDialogItemData)this.DialogItemDataList[curSelectedDialogIndex].Data).IsSelected = false;
			PhoneMsgDialogItem phoneMsgDialogItem = this.LeftScrollView.GetProxyByGridIndex(curSelectedDialogIndex) as PhoneMsgDialogItem;
			if (phoneMsgDialogItem != null)
			{
				phoneMsgDialogItem.SetToggleState(false, false);
			}
		}
		this.CurSelectedDialogIndex = gridIndex;
		this.CurPreviewDialogId = newDialogData.DialogId;
		newDialogData.IsSelected = true;
		PhoneMsgDialogItem phoneMsgDialogItem2 = this.LeftScrollView.GetProxyByGridIndex(gridIndex) as PhoneMsgDialogItem;
		if (phoneMsgDialogItem2 != null)
		{
			phoneMsgDialogItem2.SetToggleState(true, false);
		}
		this.RefreshConfirmBtnOrGetLinkBtnShow();
		this.RefreshDialog();
	}

	// Token: 0x06012A42 RID: 76354 RVA: 0x00523BB4 File Offset: 0x00521DB4
	private void BgItemToggleClick(int gridIndex, PhoneMsgBgItemData newBgData)
	{
		if (this.CurSelectedBgIndex >= 0)
		{
			int curSelectedBgIndex = this.CurSelectedBgIndex;
			((PhoneMsgBgItemData)this.BgItemDataList[curSelectedBgIndex].Data).IsSelected = false;
			PhoneMsgBgItem phoneMsgBgItem = this.LeftScrollView.GetProxyByGridIndex(curSelectedBgIndex) as PhoneMsgBgItem;
			if (phoneMsgBgItem != null)
			{
				phoneMsgBgItem.SetToggleState(false, false);
			}
		}
		this.CurSelectedBgIndex = gridIndex;
		this.CurPreviewBgId = newBgData.BgId;
		newBgData.IsSelected = true;
		PhoneMsgBgItem phoneMsgBgItem2 = this.LeftScrollView.GetProxyByGridIndex(gridIndex) as PhoneMsgBgItem;
		if (phoneMsgBgItem2 != null)
		{
			phoneMsgBgItem2.SetToggleState(true, false);
		}
		this.RefreshConfirmBtnOrGetLinkBtnShow();
		this.RefreshBg();
	}

	// Token: 0x06012A43 RID: 76355 RVA: 0x00523C50 File Offset: 0x00521E50
	private void OnBtnConfirmClick(int _)
	{
		PhoneMsgModel instance = ModelBase<PhoneMsgModel>.Instance;
		int chatDialogId = instance.CurrentUsingChatDialogId;
		int chatBgId = instance.CurrentUsingChatBgId;
		PhoneMsgSettingView.ETarget? curTarget = this.CurTarget;
		if (curTarget != null)
		{
			PhoneMsgSettingView.ETarget valueOrDefault = curTarget.GetValueOrDefault();
			if (valueOrDefault != PhoneMsgSettingView.ETarget.Dialog)
			{
				if (valueOrDefault == PhoneMsgSettingView.ETarget.Bg)
				{
					chatBgId = this.CurPreviewBgId;
					instance.RemoveChatShowRedDotById(this.CurPreviewBgId);
					PhoneMsgBgItem phoneMsgBgItem = this.LeftScrollView.GetProxyByGridIndex(this.CurSelectedBgIndex) as PhoneMsgBgItem;
					if (phoneMsgBgItem != null)
					{
						phoneMsgBgItem.HideRedDot();
					}
				}
			}
			else
			{
				chatDialogId = this.CurPreviewDialogId;
				instance.RemoveChatShowRedDotById(this.CurPreviewDialogId);
				PhoneMsgDialogItem phoneMsgDialogItem = this.LeftScrollView.GetProxyByGridIndex(this.CurSelectedDialogIndex) as PhoneMsgDialogItem;
				if (phoneMsgDialogItem != null)
				{
					phoneMsgDialogItem.HideRedDot();
				}
			}
		}
		ControllerBase<PhoneMsgController>.Instance.SendChangeChatDialogAndBgRequest(chatDialogId, chatBgId);
	}

	// Token: 0x06012A44 RID: 76356 RVA: 0x00523D0B File Offset: 0x00521F0B
	private void OnClickCloseBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x06012A45 RID: 76357 RVA: 0x00523D14 File Offset: 0x00521F14
	private bool HandleOpenParamJump()
	{
		if (this.OpenParam == null)
		{
			return false;
		}
		int num = Convert.ToInt32(this.OpenParam);
		if (num <= 0)
		{
			return false;
		}
		if (ConfigBase<PhoneMsgConfig>.Instance.GetChatDialogConfig(num) != null)
		{
			int num2 = this.FindDialogIndexById(num);
			if (num2 >= 0)
			{
				this.SwitchToDialogTabAndSelect(num2);
				return true;
			}
		}
		if (ConfigBase<PhoneMsgConfig>.Instance.GetChatBgConfig(num) != null)
		{
			int num3 = this.FindBgIndexById(num);
			if (num3 >= 0)
			{
				this.SwitchToBgTabAndSelect(num3);
				return true;
			}
		}
		return false;
	}

	// Token: 0x06012A46 RID: 76358 RVA: 0x00523D98 File Offset: 0x00521F98
	private int FindDialogIndexById(int dialogId)
	{
		for (int i = 0; i < this.DialogItemDataList.Count; i++)
		{
			if (((SettingViewLeftDialogItemData)this.DialogItemDataList[i]).GetDialogId() == dialogId)
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x06012A47 RID: 76359 RVA: 0x00523DD8 File Offset: 0x00521FD8
	private int FindBgIndexById(int bgId)
	{
		for (int i = 0; i < this.BgItemDataList.Count; i++)
		{
			if (((SettingViewLeftBgItemData)this.BgItemDataList[i]).GetBgId() == bgId)
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x06012A48 RID: 76360 RVA: 0x00523E18 File Offset: 0x00522018
	private void SwitchToDialogTabAndSelect(int index)
	{
		PhoneMsgSettingView.ETarget? curTarget = this.CurTarget;
		PhoneMsgSettingView.ETarget etarget = PhoneMsgSettingView.ETarget.Dialog;
		if (curTarget.GetValueOrDefault() == etarget & curTarget != null)
		{
			this.SelectDialogItemByIndex(index);
			return;
		}
		this.OnClickDialogTab(EToggleState.ETT_Checked);
		this.SelectDialogItemByIndex(index);
	}

	// Token: 0x06012A49 RID: 76361 RVA: 0x00523E58 File Offset: 0x00522058
	private void SwitchToBgTabAndSelect(int index)
	{
		if (this.CurTarget.GetValueOrDefault() != PhoneMsgSettingView.ETarget.Bg)
		{
			this.OnClickBgTab(EToggleState.ETT_Checked);
		}
		this.SelectBgItemByIndex(index);
	}

	// Token: 0x06012A4A RID: 76362 RVA: 0x00523E78 File Offset: 0x00522078
	private void SelectDialogItemByIndex(int index)
	{
		if (index < 0 || index >= this.DialogItemDataList.Count)
		{
			return;
		}
		if (this.CurSelectedDialogIndex >= 0 && this.CurSelectedDialogIndex < this.DialogItemDataList.Count)
		{
			((SettingViewLeftDialogItemData)this.DialogItemDataList[this.CurSelectedDialogIndex]).Data.IsSelected = false;
			PhoneMsgDialogItem phoneMsgDialogItem = this.LeftScrollView.GetProxyByGridIndex(this.CurSelectedDialogIndex) as PhoneMsgDialogItem;
			if (phoneMsgDialogItem != null)
			{
				phoneMsgDialogItem.SetToggleState(false, false);
			}
		}
		this.CurSelectedDialogIndex = index;
		this.CurPreviewDialogId = ((SettingViewLeftDialogItemData)this.DialogItemDataList[index]).GetDialogId();
		((SettingViewLeftDialogItemData)this.DialogItemDataList[index]).Data.IsSelected = true;
		PhoneMsgDialogItem phoneMsgDialogItem2 = this.LeftScrollView.GetProxyByGridIndex(index) as PhoneMsgDialogItem;
		if (phoneMsgDialogItem2 != null)
		{
			phoneMsgDialogItem2.SetToggleState(true, false);
		}
		this.RefreshConfirmBtnOrGetLinkBtnShow();
		this.RefreshDialog();
	}

	// Token: 0x06012A4B RID: 76363 RVA: 0x00523F64 File Offset: 0x00522164
	private void SelectBgItemByIndex(int index)
	{
		if (index < 0 || index >= this.BgItemDataList.Count)
		{
			return;
		}
		if (this.CurSelectedBgIndex >= 0 && this.CurSelectedBgIndex < this.BgItemDataList.Count)
		{
			((SettingViewLeftBgItemData)this.BgItemDataList[this.CurSelectedBgIndex]).Data.IsSelected = false;
			PhoneMsgBgItem phoneMsgBgItem = this.LeftScrollView.GetProxyByGridIndex(this.CurSelectedBgIndex) as PhoneMsgBgItem;
			if (phoneMsgBgItem != null)
			{
				phoneMsgBgItem.SetToggleState(false, false);
			}
		}
		this.CurSelectedBgIndex = index;
		this.CurPreviewBgId = ((SettingViewLeftBgItemData)this.BgItemDataList[index]).GetBgId();
		((SettingViewLeftBgItemData)this.BgItemDataList[index]).Data.IsSelected = true;
		PhoneMsgBgItem phoneMsgBgItem2 = this.LeftScrollView.GetProxyByGridIndex(index) as PhoneMsgBgItem;
		if (phoneMsgBgItem2 != null)
		{
			phoneMsgBgItem2.SetToggleState(true, false);
		}
		this.RefreshConfirmBtnOrGetLinkBtnShow();
		this.RefreshBg();
	}

	// Token: 0x04009198 RID: 37272
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04009199 RID: 37273
	private PhoneMsgSettingView.ETarget? CurTarget;

	// Token: 0x0400919A RID: 37274
	[Nullable(2)]
	private MultiTemplateScrollView LeftScrollView;

	// Token: 0x0400919B RID: 37275
	[Nullable(2)]
	private ButtonItem ConfirmBtn;

	// Token: 0x0400919C RID: 37276
	[Nullable(2)]
	private GetLinkBtn GetLinkBtn;

	// Token: 0x0400919D RID: 37277
	[Nullable(2)]
	private SettingPanelChatItem LeftChatItem;

	// Token: 0x0400919E RID: 37278
	[Nullable(2)]
	private SettingPanelChatRightItem RightChatItem;

	// Token: 0x0400919F RID: 37279
	private readonly List<IMultiTemplateGridData> DialogItemDataList = new List<IMultiTemplateGridData>();

	// Token: 0x040091A0 RID: 37280
	private readonly List<IMultiTemplateGridData> BgItemDataList = new List<IMultiTemplateGridData>();

	// Token: 0x040091A1 RID: 37281
	private int CurPreviewDialogId;

	// Token: 0x040091A2 RID: 37282
	private int CurSelectedDialogIndex = -1;

	// Token: 0x040091A3 RID: 37283
	private int CurPreviewBgId;

	// Token: 0x040091A4 RID: 37284
	private int CurSelectedBgIndex = -1;

	// Token: 0x0200888C RID: 34956
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402E1E9 RID: 188905
		ItemCaption,
		// Token: 0x0402E1EA RID: 188906
		PanelHLayout,
		// Token: 0x0402E1EB RID: 188907
		TogDialogTab,
		// Token: 0x0402E1EC RID: 188908
		TogBgTab,
		// Token: 0x0402E1ED RID: 188909
		LeftScroll,
		// Token: 0x0402E1EE RID: 188910
		Content,
		// Token: 0x0402E1EF RID: 188911
		TogBgItem,
		// Token: 0x0402E1F0 RID: 188912
		TogDialogItem,
		// Token: 0x0402E1F1 RID: 188913
		BtnConfirm,
		// Token: 0x0402E1F2 RID: 188914
		TxtTitle,
		// Token: 0x0402E1F3 RID: 188915
		TexBg,
		// Token: 0x0402E1F4 RID: 188916
		TxtDesc,
		// Token: 0x0402E1F5 RID: 188917
		TxtGetWay,
		// Token: 0x0402E1F6 RID: 188918
		PlayerChatItem,
		// Token: 0x0402E1F7 RID: 188919
		TexChatBgDefault,
		// Token: 0x0402E1F8 RID: 188920
		PanelGetLink,
		// Token: 0x0402E1F9 RID: 188921
		BtnGetLink,
		// Token: 0x0402E1FA RID: 188922
		NpcChatItem,
		// Token: 0x0402E1FB RID: 188923
		TogDialogTabRedDot,
		// Token: 0x0402E1FC RID: 188924
		TogBgTabRedDot
	}

	// Token: 0x0200888D RID: 34957
	[NullableContext(0)]
	private enum ETarget
	{
		// Token: 0x0402E1FE RID: 188926
		Dialog,
		// Token: 0x0402E1FF RID: 188927
		Bg
	}
}
