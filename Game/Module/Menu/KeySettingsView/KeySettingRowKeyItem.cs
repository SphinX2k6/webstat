using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.KeySettingsView
{
	// Token: 0x020057C9 RID: 22473
	public class KeySettingRowKeyItem : UiPanelBase
	{
		// Token: 0x060391EB RID: 233963 RVA: 0x00E79BFC File Offset: 0x00E77DFC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUISprite)),
				new ValueTuple<int, Type>(6, typeof(UUISprite)),
				new ValueTuple<int, Type>(7, typeof(UUISprite)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnKeySetButtonClicked)),
				new ValueTuple<int, Delegate>(9, new Action(this.OnDisableButtonClicked))
			};
		}

		// Token: 0x060391EC RID: 233964 RVA: 0x00E79D2D File Offset: 0x00E77F2D
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
			Action<KeySettingRowData, KeySettingRowKeyItem> onWaitInput = this.OnWaitInput;
			if (onWaitInput == null)
			{
				return;
			}
			onWaitInput(this.KeySettingRowData, this);
		}

		// Token: 0x060391ED RID: 233965 RVA: 0x00E79D54 File Offset: 0x00E77F54
		private void OnDisableButtonClicked()
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

		// Token: 0x060391EE RID: 233966 RVA: 0x00E79DD8 File Offset: 0x00E77FD8
		protected override void OnStart()
		{
			this.LoopSequencePlayer = new LevelSequencePlayer(base.GetItem(8));
		}

		// Token: 0x060391EF RID: 233967 RVA: 0x00E79DEC File Offset: 0x00E77FEC
		protected override void OnBeforeDestroy()
		{
			this.ClearData();
			this.OnWaitInput = null;
			LevelSequencePlayer loopSequencePlayer = this.LoopSequencePlayer;
			if (loopSequencePlayer != null)
			{
				loopSequencePlayer.Clear();
			}
			this.LoopSequencePlayer = null;
		}

		// Token: 0x060391F0 RID: 233968 RVA: 0x00E79E13 File Offset: 0x00E78013
		public void ClearData()
		{
			this.KeySettingRowData = null;
			this.InputControllerType = EInputControllerType.None;
		}

		// Token: 0x060391F1 RID: 233969 RVA: 0x00E79E23 File Offset: 0x00E78023
		[NullableContext(1)]
		public void BindOnWaitInput(Action<KeySettingRowData, KeySettingRowKeyItem> onWaitInput)
		{
			this.OnWaitInput = onWaitInput;
		}

		// Token: 0x060391F2 RID: 233970 RVA: 0x00E79E2C File Offset: 0x00E7802C
		[NullableContext(1)]
		public void Refresh(KeySettingRowData keySettingRowData, EInputControllerType inputControllerType)
		{
			if (keySettingRowData.GetRowType() != EKeySettingRowType.KeySetting)
			{
				return;
			}
			this.KeySettingRowData = keySettingRowData;
			this.InputControllerType = inputControllerType;
			this.RefreshTitleText();
			this.RefreshKeyNameText();
			this.RefreshDetailText();
			this.RefreshLock();
			this.RefreshDisableButton();
			this.RefreshDetailItemVisible();
		}

		// Token: 0x060391F3 RID: 233971 RVA: 0x00E79E6C File Offset: 0x00E7806C
		private void RefreshTitleText()
		{
			UUIText text = base.GetText(0);
			string settingName = this.KeySettingRowData.GetSettingName();
			if (StringUtils.IsEmpty(settingName))
			{
				text.SetText(this.KeySettingRowData.GetActionOrAxisName(), true);
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, settingName, Array.Empty<object>());
		}

		// Token: 0x060391F4 RID: 233972 RVA: 0x00E79EBC File Offset: 0x00E780BC
		private unsafe void RefreshKeyNameText()
		{
			string buttonTextId = this.KeySettingRowData.ButtonTextId;
			if (buttonTextId != null && !StringUtils.IsBlank(buttonTextId))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), buttonTextId, Array.Empty<object>());
				return;
			}
			string linkString = "+";
			List<string> bothActionName = this.KeySettingRowData.BothActionName;
			if (bothActionName != null && bothActionName.Count > 1)
			{
				linkString = "/";
			}
			string currentKeyNameRichText = this.KeySettingRowData.GetCurrentKeyNameRichText(this.InputControllerType, linkString);
			if (currentKeyNameRichText.Length <= 0)
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
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "NoneText", Array.Empty<object>());
				return;
			}
			UUIText text = base.GetText(2);
			if (text == null)
			{
				return;
			}
			text.SetText(currentKeyNameRichText, true);
		}

		// Token: 0x060391F5 RID: 233973 RVA: 0x00E7A0E8 File Offset: 0x00E782E8
		private void RefreshDetailText()
		{
			if (this.KeySettingRowData.CanDisable)
			{
				UUISprite sprite = base.GetSprite(5);
				if (sprite == null)
				{
					return;
				}
				sprite.SetUIActive(false);
				return;
			}
			else
			{
				string detailTextId = this.KeySettingRowData.DetailTextId;
				if (!StringUtils.IsEmpty(detailTextId))
				{
					UUISprite sprite2 = base.GetSprite(5);
					if (sprite2 != null)
					{
						sprite2.SetUIActive(true);
					}
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), detailTextId, Array.Empty<object>());
					return;
				}
				UUISprite sprite3 = base.GetSprite(5);
				if (sprite3 == null)
				{
					return;
				}
				sprite3.SetUIActive(false);
				return;
			}
		}

		// Token: 0x060391F6 RID: 233974 RVA: 0x00E7A168 File Offset: 0x00E78368
		private void RefreshLock()
		{
			bool isLock = this.KeySettingRowData.IsLock;
			UUISprite sprite = base.GetSprite(6);
			if (sprite != null)
			{
				sprite.SetUIActive(isLock);
			}
			UUIButtonComponent button = base.GetButton(1);
			if (button == null)
			{
				return;
			}
			button.SetSelfInteractive(!isLock);
		}

		// Token: 0x060391F7 RID: 233975 RVA: 0x00E7A1AC File Offset: 0x00E783AC
		private void RefreshDisableButton()
		{
			if (this.KeySettingRowData == null)
			{
				return;
			}
			UUIButtonComponent button = base.GetButton(9);
			AUIBaseActor auibaseActor = ((button != null) ? button.GetOwner() : null) as AUIBaseActor;
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

		// Token: 0x060391F8 RID: 233976 RVA: 0x00E7A247 File Offset: 0x00E78447
		private void RefreshDetailItemVisible()
		{
			if (this.KeySettingRowData == null)
			{
				this.SetDetailItemVisible(false);
				return;
			}
			this.SetDetailItemVisible(this.KeySettingRowData.IsExpandDetail);
		}

		// Token: 0x060391F9 RID: 233977 RVA: 0x00E7A26C File Offset: 0x00E7846C
		public void SetSelected(bool bSelected)
		{
			UUISprite sprite = base.GetSprite(7);
			if (sprite != null)
			{
				sprite.SetUIActive(bSelected);
			}
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(bSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			}
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.SetUIActive(!bSelected);
			}
			UUIItem item = base.GetItem(8);
			if (item != null)
			{
				item.SetUIActive(bSelected);
			}
			if (bSelected)
			{
				this.LoopSequencePlayer.PlayLevelSequenceByName("Loop", false, null, false);
				return;
			}
			this.LoopSequencePlayer.StopCurrentSequence(false, false);
		}

		// Token: 0x060391FA RID: 233978 RVA: 0x00E7A300 File Offset: 0x00E78500
		public void SetDetailItemVisible(bool bVisible)
		{
			UUIItem item = base.GetItem(3);
			if (this.KeySettingRowData == null)
			{
				item.SetUIActive(false);
				return;
			}
			if (StringUtils.IsEmpty(this.KeySettingRowData.DetailTextId))
			{
				item.SetUIActive(false);
				return;
			}
			item.SetUIActive(bVisible);
			this.KeySettingRowData.IsExpandDetail = bVisible;
		}

		// Token: 0x04020838 RID: 133176
		[Nullable(2)]
		private KeySettingRowData KeySettingRowData;

		// Token: 0x04020839 RID: 133177
		private EInputControllerType InputControllerType;

		// Token: 0x0402083A RID: 133178
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Action<KeySettingRowData, KeySettingRowKeyItem> OnWaitInput;

		// Token: 0x0402083B RID: 133179
		[Nullable(2)]
		private LevelSequencePlayer LoopSequencePlayer;

		// Token: 0x0200B84D RID: 47181
		public class EChildType
		{
			// Token: 0x0403900A RID: 233482
			public const int TitleText = 0;

			// Token: 0x0403900B RID: 233483
			public const int KeySetToggle = 1;

			// Token: 0x0403900C RID: 233484
			public const int KeyNameText = 2;

			// Token: 0x0403900D RID: 233485
			public const int DetailItem = 3;

			// Token: 0x0403900E RID: 233486
			public const int DetailText = 4;

			// Token: 0x0403900F RID: 233487
			public const int DetailArrowSprite = 5;

			// Token: 0x04039010 RID: 233488
			public const int LockSprite = 6;

			// Token: 0x04039011 RID: 233489
			public const int SelectedSprite = 7;

			// Token: 0x04039012 RID: 233490
			public const int CursorItem = 8;

			// Token: 0x04039013 RID: 233491
			public const int DisableButton = 9;
		}
	}
}
