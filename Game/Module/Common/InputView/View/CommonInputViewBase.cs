using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.InputView.Model;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Platform;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Common.InputView.View
{
	// Token: 0x02005E71 RID: 24177
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class CommonInputViewBase : UiTickViewBase
	{
		// Token: 0x0603CCE4 RID: 249060 RVA: 0x00F70617 File Offset: 0x00F6E817
		protected CommonInputViewBase(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603CCE5 RID: 249061 RVA: 0x00F7063C File Offset: 0x00F6E83C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITextInputComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action<bool>(this.ActiveInputText));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.CancelClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.ConfirmClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603CCE6 RID: 249062 RVA: 0x00F70810 File Offset: 0x00F6EA10
		private void ActiveInputText(bool active)
		{
			if (active && this.TipsType.GetValueOrDefault() == ETipsType.NoneText)
			{
				this.RefreshTips(ETipsType.Normal);
			}
		}

		// Token: 0x0603CCE7 RID: 249063 RVA: 0x00F7082A File Offset: 0x00F6EA2A
		private void CancelClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603CCE8 RID: 249064 RVA: 0x00F70833 File Offset: 0x00F6EA33
		protected virtual bool ExtraConfirmCheck(int count, string text)
		{
			return true;
		}

		// Token: 0x0603CCE9 RID: 249065 RVA: 0x00F70838 File Offset: 0x00F6EA38
		private void ConfirmClick()
		{
			string text = this.InputText.GetText();
			int stringRealCount = StringUtils.GetStringRealCount(text);
			if (this.InputData.NeedCheckBlank != null && this.InputData.NeedCheckBlank.Value && text.Length > 0 && StringUtils.CheckIsOnlyBlank(text))
			{
				this.RefreshTips(ETipsType.Blank);
				return;
			}
			if (stringRealCount > this.GetMaxLimit())
			{
				this.RefreshTips(ETipsType.MsgTooLong);
				this.Timer = 0f;
				return;
			}
			if (stringRealCount == 0 && this.InputData.IsCheckNone)
			{
				this.RefreshTips(ETipsType.NoneText);
				this.Timer = 0f;
				return;
			}
			if (stringRealCount < this.GetMinLimit())
			{
				this.RefreshTips(ETipsType.MsgTooShort);
				this.Timer = 0f;
				return;
			}
			if (!this.ExtraConfirmCheck(stringRealCount, text))
			{
				return;
			}
			this.ExecuteInputConfirm(text);
		}

		// Token: 0x0603CCEA RID: 249066 RVA: 0x00F70908 File Offset: 0x00F6EB08
		protected virtual void ExecuteInputConfirm(string inputText)
		{
			CommonInputViewBase.<>c__DisplayClass14_0 CS$<>8__locals1 = new CommonInputViewBase.<>c__DisplayClass14_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.inputText = inputText;
			CS$<>8__locals1.<ExecuteInputConfirm>g__Temp|0().Forget(delegate(Exception exception)
			{
				Singleton<Log>.Instance.Error(ELogModule.UiCommon, ELogAuthor.XXJ, "通用输入框执行出现未知错误", default(ReadOnlySpan<ValueTuple<string, object>>));
			}, true);
		}

		// Token: 0x0603CCEB RID: 249067 RVA: 0x00F70948 File Offset: 0x00F6EB48
		protected override void OnBeforeCreate()
		{
			this.InputData = (this.OpenParam as ICommonInputViewData);
			Dictionary<ETipsType, Action> dictionary = new Dictionary<ETipsType, Action>();
			dictionary[ETipsType.Normal] = new Action(this.NormalHandle);
			dictionary[ETipsType.NoneText] = new Action(this.NoneTextHandle);
			dictionary[ETipsType.MsgTooLong] = new Action(this.MsgTooLongHandle);
			dictionary[ETipsType.MsgTooShort] = new Action(this.MsgTooShortHandle);
			dictionary[ETipsType.IllegalCharacters] = new Action(this.IllegalCharactersHandle);
			dictionary[ETipsType.Blank] = new Action(this.BlankTextHandle);
			dictionary[ETipsType.InValidCdKey] = new Action(this.InValidCdKeyHandle);
			dictionary[ETipsType.CdKeyInCd] = new Action(this.CdKeyInCdHandle);
			this.TipsTypeFunc = dictionary;
		}

		// Token: 0x0603CCEC RID: 249068 RVA: 0x00F70A09 File Offset: 0x00F6EC09
		private void NormalHandle()
		{
			this.SetTipsVisible(false);
			this.ConfirmButton.SetSelfInteractive(true);
			this.Timer = -1f;
		}

		// Token: 0x0603CCED RID: 249069 RVA: 0x00F70A29 File Offset: 0x00F6EC29
		private void NoneTextHandle()
		{
			this.SetTipsAndTimer("PrefabTextItem_Entertext_Text", 0, Array.Empty<string>());
		}

		// Token: 0x0603CCEE RID: 249070 RVA: 0x00F70A3C File Offset: 0x00F6EC3C
		private void MsgTooLongHandle()
		{
			this.SetTipsAndTimer("PrefabTextItem_Textoverlength_Text", -1, Array.Empty<string>());
			this.ConfirmButton.SetSelfInteractive(false);
		}

		// Token: 0x0603CCEF RID: 249071 RVA: 0x00F70A5B File Offset: 0x00F6EC5B
		private void MsgTooShortHandle()
		{
			this.SetTipsAndTimer("CDKey_TooShort", 0, Array.Empty<string>());
			this.ConfirmButton.SetSelfInteractive(false);
		}

		// Token: 0x0603CCF0 RID: 249072 RVA: 0x00F70A7A File Offset: 0x00F6EC7A
		private void IllegalCharactersHandle()
		{
			this.SetTipsAndTimer("PrefabTextItem_Textillegality_Text", 0, Array.Empty<string>());
		}

		// Token: 0x0603CCF1 RID: 249073 RVA: 0x00F70A8D File Offset: 0x00F6EC8D
		private void BlankTextHandle()
		{
			this.SetTipsAndTimer("PrefabTextItem_TextNull_Text", 0, Array.Empty<string>());
		}

		// Token: 0x0603CCF2 RID: 249074 RVA: 0x00F70AA0 File Offset: 0x00F6ECA0
		private void InValidCdKeyHandle()
		{
			this.SetTipsTextAndTimer(this.CdKeyErrorText, 0);
			this.ConfirmButton.SetSelfInteractive(false);
		}

		// Token: 0x0603CCF3 RID: 249075 RVA: 0x00F70ABC File Offset: 0x00F6ECBC
		private void CdKeyInCdHandle()
		{
			string text = CdKeyInputController.GetCdKeyUseCd().ToString();
			this.SetTipsAndTimer("CDKey_CDtime", 0, new string[]
			{
				text
			});
			this.ConfirmButton.SetSelfInteractive(false);
		}

		// Token: 0x0603CCF4 RID: 249076 RVA: 0x00F70AFC File Offset: 0x00F6ECFC
		private void SetTipsAndTimer(string textId, int timer, params string[] textParam)
		{
			this.SetTipsVisible(true);
			UUIText text = base.GetText(2);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textId, textParam);
			this.Timer = (float)timer;
		}

		// Token: 0x0603CCF5 RID: 249077 RVA: 0x00F70B2D File Offset: 0x00F6ED2D
		private void SetTipsTextAndTimer(string text, int timer)
		{
			this.SetTipsVisible(true);
			base.GetText(2).SetText(text, true);
			this.Timer = (float)timer;
		}

		// Token: 0x0603CCF6 RID: 249078 RVA: 0x00F70B4C File Offset: 0x00F6ED4C
		protected void SetBottomTipsTextAndColor(string text, FColor color)
		{
			UUIText text2 = base.GetText(8);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, text, Array.Empty<object>());
			text2.SetColor(color);
		}

		// Token: 0x0603CCF7 RID: 249079 RVA: 0x00F70B79 File Offset: 0x00F6ED79
		protected void SetBottomTipsShowState(bool state)
		{
			base.GetText(8).SetUIActive(state);
		}

		// Token: 0x0603CCF8 RID: 249080 RVA: 0x00F70B88 File Offset: 0x00F6ED88
		protected override void OnBeforeShow()
		{
			this.InitSelfParam();
			this.RefreshTitle();
			this.RefreshTips(ETipsType.Normal);
			this.InitExtraParam();
		}

		// Token: 0x0603CCF9 RID: 249081 RVA: 0x00F70BA4 File Offset: 0x00F6EDA4
		protected void SetClearOrPaste()
		{
			if (this.FunctionButton == null)
			{
				return;
			}
			if (this.InputText.GetText() == "")
			{
				this.FunctionButton.RefreshSprite("SP_Paste");
				this.FunctionButton.BindCallback(new Action(this.OnClickPasteBtn));
				return;
			}
			this.FunctionButton.RefreshSprite("SP_Clear");
			this.FunctionButton.BindCallback(new Action(this.OnClickClearBtn));
		}

		// Token: 0x0603CCFA RID: 249082 RVA: 0x00F70C20 File Offset: 0x00F6EE20
		private void OnClickClearBtn()
		{
			this.InputText.SetText("", true);
		}

		// Token: 0x0603CCFB RID: 249083 RVA: 0x00F70C34 File Offset: 0x00F6EE34
		private void OnClickPasteBtn()
		{
			if (Singleton<Platform>.Instance.IsCloudGame())
			{
				TimerSystem.Instance.Delay(delegate(float _)
				{
					string empty2 = string.Empty;
					ULGUIBPLibrary.ClipBoardPaste(ref empty2);
					if (!string.IsNullOrEmpty(empty2))
					{
						this.InputText.SetText(empty2, true);
					}
				}, 200f, null, null, true, 1f);
				return;
			}
			string empty = string.Empty;
			ULGUIBPLibrary.ClipBoardPaste(ref empty);
			if (!string.IsNullOrEmpty(empty))
			{
				this.InputText.SetText(empty, true);
			}
		}

		// Token: 0x0603CCFC RID: 249084 RVA: 0x00F70C94 File Offset: 0x00F6EE94
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnNameChange, new Action(this.OnNameChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OnSignChange, new Action(this.OnSignChange));
		}

		// Token: 0x0603CCFD RID: 249085 RVA: 0x00F70CCE File Offset: 0x00F6EECE
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnNameChange, new Action(this.OnNameChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSignChange, new Action(this.OnSignChange));
		}

		// Token: 0x0603CCFE RID: 249086 RVA: 0x00F70D08 File Offset: 0x00F6EF08
		private void OnNameChange()
		{
			string textById = ConfigBase<TextConfig>.Instance.GetTextById("SetNameSuccess");
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(textById);
		}

		// Token: 0x0603CCFF RID: 249087 RVA: 0x00F70D30 File Offset: 0x00F6EF30
		private void OnSignChange()
		{
			string textById = ConfigBase<TextConfig>.Instance.GetTextById("SetSignSuccess");
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(textById);
		}

		// Token: 0x0603CD00 RID: 249088 RVA: 0x00F70D58 File Offset: 0x00F6EF58
		protected override void OnTick(float delta)
		{
			if (this.Timer == -1f)
			{
				return;
			}
			this.Timer += delta;
			if (this.Timer >= 2000f)
			{
				this.RefreshTips(ETipsType.Normal);
			}
		}

		// Token: 0x0603CD01 RID: 249089 RVA: 0x00F70D8A File Offset: 0x00F6EF8A
		protected override void OnBeforeDestroy()
		{
			this.UnBindTextChange();
			this.FunctionButton = null;
			this.InputText = null;
			this.ConfirmButton = null;
		}

		// Token: 0x0603CD02 RID: 249090 RVA: 0x00F70DA8 File Offset: 0x00F6EFA8
		private void InitSelfParam()
		{
			bool flag = !Singleton<Info>.Instance.IsHomeConsolePlatform();
			if (flag)
			{
				this.FunctionButton = new ButtonAndSpriteItem(base.GetItem(7));
			}
			base.GetItem(7).SetUIActive(flag && this.InputData.NeedFunctionButton);
			this.ConfirmButton = base.GetButton(4);
			this.InputText = base.GetInputText(5);
			this.InputText.bAllowMultiLine = this.IsAllowMultiLine();
			this.InputText.OnTextChange.Bind(new Action<string>(this.OnTextChange));
			this.InputText.SetText(this.InputData.InputText, true);
			base.GetText(6).SetText(this.InputData.DefaultText, true);
			this.SetClearOrPaste();
			this.SetTipsVisible(false);
			string bottomTipsText = this.InputData.BottomTipsText;
			if (!string.IsNullOrEmpty(bottomTipsText))
			{
				this.SetBottomTipsShowState(true);
				base.GetText(8).SetText(bottomTipsText, true);
			}
			else
			{
				this.SetBottomTipsShowState(false);
			}
			string bottomTipsColor = this.InputData.BottomTipsColor;
			if (!string.IsNullOrEmpty(bottomTipsColor))
			{
				base.GetText(8).SetColor(FColor.FromHex(bottomTipsColor));
			}
		}

		// Token: 0x0603CD03 RID: 249091 RVA: 0x00F70ED0 File Offset: 0x00F6F0D0
		protected void SetTipsVisible(bool bVisible)
		{
			base.GetItem(1).SetUIActive(bVisible);
		}

		// Token: 0x0603CD04 RID: 249092 RVA: 0x00F70EDF File Offset: 0x00F6F0DF
		protected virtual void InitExtraParam()
		{
		}

		// Token: 0x0603CD05 RID: 249093 RVA: 0x00F70EE1 File Offset: 0x00F6F0E1
		private void UnBindTextChange()
		{
			this.InputText.OnTextChange.Unbind();
		}

		// Token: 0x0603CD06 RID: 249094 RVA: 0x00F70EF3 File Offset: 0x00F6F0F3
		protected void OnTextChange(string inputText)
		{
			this.SetClearOrPaste();
			if (StringUtils.GetStringRealCount(inputText) <= this.GetMaxLimit())
			{
				this.RefreshTips(ETipsType.Normal);
				this.RefreshDuplicateName(inputText);
				return;
			}
			this.RefreshTips(ETipsType.MsgTooLong);
			this.RefreshDuplicateName(inputText);
		}

		// Token: 0x0603CD07 RID: 249095 RVA: 0x00F70F26 File Offset: 0x00F6F126
		private void RefreshTitle()
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), this.InputData.TitleTextArgs.TextKey, this.InputData.TitleTextArgs.Params);
		}

		// Token: 0x0603CD08 RID: 249096 RVA: 0x00F70F5C File Offset: 0x00F6F15C
		protected virtual void RefreshTips(ETipsType type)
		{
			ETipsType? tipsType = this.TipsType;
			if (type == tipsType.GetValueOrDefault() & tipsType != null)
			{
				return;
			}
			this.TipsType = new ETipsType?(type);
			this.TipsTypeFunc[type]();
		}

		// Token: 0x0603CD09 RID: 249097 RVA: 0x00F70FA2 File Offset: 0x00F6F1A2
		protected virtual void RefreshDuplicateName(string inputText)
		{
		}

		// Token: 0x0603CD0A RID: 249098
		protected abstract int GetMaxLimit();

		// Token: 0x0603CD0B RID: 249099
		protected abstract bool IsAllowMultiLine();

		// Token: 0x0603CD0C RID: 249100 RVA: 0x00F70FA4 File Offset: 0x00F6F1A4
		protected virtual int GetMinLimit()
		{
			return 0;
		}

		// Token: 0x0402226A RID: 139882
		[Nullable(2)]
		protected ICommonInputViewData InputData;

		// Token: 0x0402226B RID: 139883
		private ETipsType? TipsType;

		// Token: 0x0402226C RID: 139884
		private float Timer = -1f;

		// Token: 0x0402226D RID: 139885
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<ETipsType, Action> TipsTypeFunc;

		// Token: 0x0402226E RID: 139886
		[Nullable(2)]
		protected UUIButtonComponent ConfirmButton;

		// Token: 0x0402226F RID: 139887
		[Nullable(2)]
		protected UUITextInputComponent InputText;

		// Token: 0x04022270 RID: 139888
		[Nullable(2)]
		private ButtonAndSpriteItem FunctionButton;

		// Token: 0x04022271 RID: 139889
		protected string CdKeyErrorText = ConfigMultiTextLang.GetLocalTextNew("CDKey_Error", null);

		// Token: 0x0200BE81 RID: 48769
		[NullableContext(0)]
		private class ECompDefine
		{
			// Token: 0x0403AA87 RID: 240263
			public const int Title = 0;

			// Token: 0x0403AA88 RID: 240264
			public const int TipsRootItem = 1;

			// Token: 0x0403AA89 RID: 240265
			public const int Tips = 2;

			// Token: 0x0403AA8A RID: 240266
			public const int CancelBtn = 3;

			// Token: 0x0403AA8B RID: 240267
			public const int ConfirmBtn = 4;

			// Token: 0x0403AA8C RID: 240268
			public const int InputText = 5;

			// Token: 0x0403AA8D RID: 240269
			public const int DefaultText = 6;

			// Token: 0x0403AA8E RID: 240270
			public const int ButtonFunction = 7;

			// Token: 0x0403AA8F RID: 240271
			public const int BottomTipsText = 8;
		}
	}
}
