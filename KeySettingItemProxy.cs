using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.KeySetting;
using CSharpScript.Game.Module.Menu;
using UnrealEngine;

// Token: 0x02002086 RID: 8326
[NullableContext(1)]
[Nullable(0)]
public class KeySettingItemProxy
{
	// Token: 0x0600FDA1 RID: 64929 RVA: 0x004591EF File Offset: 0x004573EF
	public KeySettingItemProxy(IKeySettingItem item)
	{
		this.Item = item;
	}

	// Token: 0x0600FDA2 RID: 64930 RVA: 0x00459200 File Offset: 0x00457400
	public void OnStart()
	{
		this.Item.GetKeySetToggle().OnStateChange.Add(new Action<EToggleState>(this.OnKeySetButtonClicked));
		UUIButtonComponent cancelButton = this.Item.GetCancelButton();
		if (cancelButton != null)
		{
			cancelButton.OnClickCallBack.Bind(new Action(this.OnCancelButtonClicked));
		}
		this.LoopSequencePlayer = new LevelSequencePlayer(this.Item.GetCursorItem());
		KeySettingViewModel.AddOnKeySelectedDelegate(new Action<KeySettingRowData>(this.OnKeySelected));
		KeySettingViewModel.AddOnKeyChangeDelegate(new Action<KeySettingRowData, CSharpScript.Game.Module.Menu.EInputControllerType>(this.OnKeyChange));
	}

	// Token: 0x0600FDA3 RID: 64931 RVA: 0x0045928C File Offset: 0x0045748C
	public void OnBeforeDestroy()
	{
		this.Item.GetKeySetToggle().OnStateChange.Remove(new Action<EToggleState>(this.OnKeySetButtonClicked));
		UUIButtonComponent cancelButton = this.Item.GetCancelButton();
		if (cancelButton != null)
		{
			cancelButton.OnClickCallBack.Unbind();
		}
		KeySettingViewModel.RemoveOnKeySelectedDelegate(new Action<KeySettingRowData>(this.OnKeySelected));
		KeySettingViewModel.RemoveOnKeyChangeDelegate(new Action<KeySettingRowData, CSharpScript.Game.Module.Menu.EInputControllerType>(this.OnKeyChange));
		LevelSequencePlayer loopSequencePlayer = this.LoopSequencePlayer;
		if (loopSequencePlayer == null)
		{
			return;
		}
		loopSequencePlayer.Clear();
	}

	// Token: 0x0600FDA4 RID: 64932 RVA: 0x00459308 File Offset: 0x00457508
	public void SetDetailItemVisible(bool bVisible)
	{
		UUIItem detailUiItem = this.Item.GetDetailUiItem();
		if (detailUiItem == null)
		{
			return;
		}
		if (this.KeySettingRowData == null)
		{
			detailUiItem.SetUIActive(false);
			return;
		}
		if (StringUtils.IsEmpty(this.KeySettingRowData.DetailTextId))
		{
			detailUiItem.SetUIActive(false);
			return;
		}
		detailUiItem.SetUIActive(bVisible);
		this.KeySettingRowData.IsExpandDetail = bVisible;
	}

	// Token: 0x0600FDA5 RID: 64933 RVA: 0x00459362 File Offset: 0x00457562
	public void Refresh(KeySettingRowData data, CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
	{
		this.KeySettingRowData = data;
		this.InputControllerType = inputControllerType;
		this.RefreshTitleText();
		this.RefreshKeyNameText();
		this.RefreshDetailText();
		this.RefreshLock();
		this.RefreshDisableButton();
	}

	// Token: 0x0600FDA6 RID: 64934 RVA: 0x00459390 File Offset: 0x00457590
	private void RefreshTitleText()
	{
		UUIText titleUiText = this.Item.GetTitleUiText();
		string settingName = this.KeySettingRowData.GetSettingName();
		if (StringUtils.IsEmpty(settingName))
		{
			titleUiText.SetText(this.KeySettingRowData.GetActionOrAxisName(), true);
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(titleUiText, settingName, Array.Empty<object>());
	}

	// Token: 0x0600FDA7 RID: 64935 RVA: 0x004593E4 File Offset: 0x004575E4
	private unsafe void RefreshKeyNameText()
	{
		string buttonTextId = this.KeySettingRowData.ButtonTextId;
		if (buttonTextId != null && !StringUtils.IsBlank(buttonTextId))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(this.Item.GetKeyNameUiText(), buttonTextId, Array.Empty<object>());
			return;
		}
		string linkString = "+";
		List<string> bothActionName = this.KeySettingRowData.BothActionName;
		if (bothActionName != null && bothActionName.Count > 1)
		{
			linkString = "/";
		}
		string currentKeyNameRichText = this.KeySettingRowData.GetCurrentKeyNameRichText(this.InputControllerType, linkString);
		if (currentKeyNameRichText == null || currentKeyNameRichText.Length <= 0)
		{
			InputCombinationActionBinding inputCombinationActionBinding = this.KeySettingRowData.FindCombinationActionBinding();
			InputCombinationAxisBinding combinationAxisBinding = this.KeySettingRowData.CombinationAxisBinding;
			InputActionBinding actionBinding = this.KeySettingRowData.ActionBinding;
			InputAxisBinding axisBinding = this.KeySettingRowData.AxisBinding;
			List<string> list = new List<string>();
			if (actionBinding != null)
			{
				actionBinding.GetKeyNameListByBindingType(list, this.KeySettingRowData.BindingType);
			}
			List<string> list2 = new List<string>();
			if (axisBinding != null)
			{
				axisBinding.GetKeyNameListByBindingType(list2, this.KeySettingRowData.BindingType);
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (inputCombinationActionBinding != null)
			{
				inputCombinationActionBinding.GetKeyMapByBindingType(dictionary, this.KeySettingRowData.BindingType);
			}
			Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
			if (combinationAxisBinding != null)
			{
				combinationAxisBinding.GetKeyMap(dictionary2, this.KeySettingRowData.BindingType);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InputSettings;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "刷新按键设置项时，按键名称为空";
			<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActionOrAxisName", this.KeySettingRowData.GetActionOrAxisName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("IsActionOrAxis", this.KeySettingRowData.IsActionOrAxis);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ActionBindingKeys", list);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("AxisBindingKeys", list2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("combinationActionBindingKeyMap", dictionary);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("combinationAxisBindingKeyMap", dictionary2);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(this.Item.GetKeyNameUiText(), "NoneText", Array.Empty<object>());
			return;
		}
		this.Item.GetKeyNameUiText().SetText(currentKeyNameRichText, true);
	}

	// Token: 0x0600FDA8 RID: 64936 RVA: 0x00459618 File Offset: 0x00457818
	private void RefreshDetailText()
	{
		if (this.Item.GetDetailUiItem() == null || this.Item.GetDetailUiText() == null || this.Item.GetDetailSprite() == null)
		{
			return;
		}
		if (this.KeySettingRowData.CanDisable)
		{
			this.Item.GetDetailSprite().SetUIActive(false);
			return;
		}
		string detailTextId = this.KeySettingRowData.DetailTextId;
		if (StringUtils.IsEmpty(detailTextId))
		{
			this.Item.GetDetailSprite().SetUIActive(false);
			return;
		}
		this.Item.GetDetailSprite().SetUIActive(true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(this.Item.GetDetailUiText(), detailTextId, Array.Empty<object>());
	}

	// Token: 0x0600FDA9 RID: 64937 RVA: 0x004596C0 File Offset: 0x004578C0
	private void RefreshLock()
	{
		if (this.Item.GetLockSprite() == null)
		{
			return;
		}
		bool isLock = this.KeySettingRowData.IsLock;
		this.Item.GetLockSprite().SetUIActive(isLock);
		this.Item.GetKeySetToggle().SetSelfInteractive(!isLock);
	}

	// Token: 0x0600FDAA RID: 64938 RVA: 0x0045970C File Offset: 0x0045790C
	private void RefreshDisableButton()
	{
		if (this.KeySettingRowData == null)
		{
			return;
		}
		UUIButtonComponent cancelButton = this.Item.GetCancelButton();
		if (cancelButton == null)
		{
			return;
		}
		AUIBaseActor auibaseActor = cancelButton.GetOwner() as AUIBaseActor;
		UUIItem uuiitem = (auibaseActor != null) ? auibaseActor.GetUIItem() : null;
		if (uuiitem == null)
		{
			return;
		}
		if (!this.KeySettingRowData.CanDisable)
		{
			uuiitem.SetUIActive(false);
			return;
		}
		if (this.KeySettingRowData.IsLock)
		{
			uuiitem.SetUIActive(false);
			return;
		}
		if (this.KeySettingRowData.IsBothAction())
		{
			uuiitem.SetUIActive(false);
			return;
		}
		if (this.KeySettingRowData.OpenViewType != EKeySettingOpenViewType.None)
		{
			uuiitem.SetUIActive(false);
			return;
		}
		uuiitem.SetUIActive(true);
	}

	// Token: 0x0600FDAB RID: 64939 RVA: 0x004597A9 File Offset: 0x004579A9
	private void OnKeySetButtonClicked(EToggleState state)
	{
		if (state != EToggleState.ETT_Checked)
		{
			return;
		}
		if (this.KeySettingRowData == null)
		{
			return;
		}
		KeySettingViewModel.WaitKeySetting(this.KeySettingRowData, this.Item);
	}

	// Token: 0x0600FDAC RID: 64940 RVA: 0x004597CC File Offset: 0x004579CC
	private void OnCancelButtonClicked()
	{
		if (this.KeySettingRowData == null)
		{
			return;
		}
		if (this.KeySettingRowData.IsBothAction())
		{
			return;
		}
		if (this.KeySettingRowData.OpenViewType != EKeySettingOpenViewType.None)
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.InputSettings;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "按下清空按键按钮，清空此输入按键";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActionOrAxisName", this.KeySettingRowData.GetActionOrAxisName());
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.KeySettingRowData.DisableKey(this.InputControllerType);
		this.RefreshKeyNameText();
		Singleton<InputSettings>.Instance.SaveKeyMappings();
	}

	// Token: 0x0600FDAD RID: 64941 RVA: 0x00459850 File Offset: 0x00457A50
	[NullableContext(2)]
	private void OnKeySelected(KeySettingRowData data)
	{
		UUISprite selectSprite = this.Item.GetSelectSprite();
		if (this.KeySettingRowData == null || selectSprite == null)
		{
			return;
		}
		bool flag = this.KeySettingRowData == data;
		selectSprite.SetUIActive(flag);
		this.Item.GetKeySetToggle().SetToggleState(flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		this.Item.GetKeyNameUiText().SetUIActive(!flag);
		this.Item.GetCursorItem().SetUIActive(flag);
		if (flag)
		{
			LevelSequencePlayer loopSequencePlayer = this.LoopSequencePlayer;
			if (loopSequencePlayer == null)
			{
				return;
			}
			loopSequencePlayer.PlayLevelSequenceByName("Loop".ToString(), false, null, false);
			return;
		}
		else
		{
			LevelSequencePlayer loopSequencePlayer2 = this.LoopSequencePlayer;
			if (loopSequencePlayer2 == null)
			{
				return;
			}
			loopSequencePlayer2.StopCurrentSequence(false, false);
			return;
		}
	}

	// Token: 0x0600FDAE RID: 64942 RVA: 0x00459901 File Offset: 0x00457B01
	private void OnKeyChange(KeySettingRowData data, CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
	{
		if (data == this.KeySettingRowData)
		{
			this.Refresh(data, KeySettingViewModel.InputControllerType);
		}
	}

	// Token: 0x040079B9 RID: 31161
	[Nullable(2)]
	private KeySettingRowData KeySettingRowData;

	// Token: 0x040079BA RID: 31162
	private CSharpScript.Game.Module.Menu.EInputControllerType InputControllerType;

	// Token: 0x040079BB RID: 31163
	[Nullable(2)]
	private LevelSequencePlayer LoopSequencePlayer;

	// Token: 0x040079BC RID: 31164
	private readonly IKeySettingItem Item;
}
