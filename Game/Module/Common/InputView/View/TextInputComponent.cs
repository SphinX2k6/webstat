using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.InputView.Model;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Common.InputView.View
{
	// Token: 0x02005E7B RID: 24187
	[NullableContext(1)]
	[Nullable(0)]
	public class TextInputComponent : UiPanelBase
	{
		// Token: 0x0603CD48 RID: 249160 RVA: 0x00F712E4 File Offset: 0x00F6F4E4
		public TextInputComponent(UUIItem uiItem, ITextInputData inputData)
		{
			this.InputData = inputData;
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603CD49 RID: 249161 RVA: 0x00F71314 File Offset: 0x00F6F514
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITextInputComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action<bool>(this.ActiveInputText));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.ConfirmClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603CD4A RID: 249162 RVA: 0x00F71440 File Offset: 0x00F6F640
		private void ActiveInputText(bool active)
		{
			if (active && this.TipsType == ETipsType.NoneText)
			{
				this.RefreshTips(ETipsType.Normal);
			}
		}

		// Token: 0x0603CD4B RID: 249163 RVA: 0x00F71458 File Offset: 0x00F6F658
		private void ConfirmClick()
		{
			if (this.IsLockConfirm)
			{
				Singleton<Log>.Instance.Info(ELogModule.UiCommon, ELogAuthor.XXJ, "通用输入框锁住确认点击", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			string text = this.InputText.GetText();
			int stringRealCount = StringUtils.GetStringRealCount(text);
			if (stringRealCount > this.MaxLimit)
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
			if (stringRealCount < this.MinLimit)
			{
				this.RefreshTips(ETipsType.MsgTooShort);
				this.Timer = 0f;
				return;
			}
			this.IsLockConfirm = true;
			this.<ConfirmClick>g__Temp|14_0(text).Forget(delegate(Exception exception)
			{
				Singleton<Log>.Instance.Error(ELogModule.UiCommon, ELogAuthor.XXJ, "通用输入框执行出现未知错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.IsLockConfirm = false;
			}, true);
		}

		// Token: 0x0603CD4C RID: 249164 RVA: 0x00F71518 File Offset: 0x00F6F718
		private void RefreshTips(ETipsType type)
		{
			if (type == this.TipsType)
			{
				return;
			}
			this.TipsType = type;
			Action action = this.TipsTypeFunc[type];
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x0603CD4D RID: 249165 RVA: 0x00F71544 File Offset: 0x00F6F744
		protected override void OnStart()
		{
			Dictionary<ETipsType, Action> dictionary = new Dictionary<ETipsType, Action>();
			dictionary[ETipsType.Normal] = new Action(this.NormalHandle);
			dictionary[ETipsType.NoneText] = new Action(this.NoneTextHandle);
			dictionary[ETipsType.MsgTooLong] = new Action(this.MsgTooLongHandle);
			dictionary[ETipsType.MsgTooShort] = new Action(this.MsgTooShortHandle);
			dictionary[ETipsType.IllegalCharacters] = new Action(this.IllegalCharactersHandle);
			dictionary[ETipsType.Blank] = new Action(this.BlankTextHandle);
			dictionary[ETipsType.InValidCdKey] = null;
			dictionary[ETipsType.CdKeyInCd] = null;
			this.TipsTypeFunc = dictionary;
			this.ConfirmButton = base.GetButton(4);
			this.InputText = base.GetInputText(2);
			this.InputText.OnTextChange.Bind(new Action<string>(this.OnTextChange));
			this.InputText.SetText(this.InputData.InputText, true);
			if (!string.IsNullOrEmpty(this.InputData.DefaultText))
			{
				base.GetText(3).SetText(this.InputData.DefaultText, true);
			}
			this.TickId = Singleton<TickSystem>.Instance.Add(new Action<float>(this.Tick), "TextInputComponent", ETickingGroup.TG_PrePhysics, true, 0, true).Id;
		}

		// Token: 0x0603CD4E RID: 249166 RVA: 0x00F7167F File Offset: 0x00F6F87F
		private void UnBindTextChange()
		{
			this.InputText.OnTextChange.Unbind();
		}

		// Token: 0x0603CD4F RID: 249167 RVA: 0x00F71691 File Offset: 0x00F6F891
		private void OnTextChange(string inputText)
		{
			if (StringUtils.GetStringRealCount(inputText) <= this.MaxLimit)
			{
				this.RefreshTips(ETipsType.Normal);
				return;
			}
			this.RefreshTips(ETipsType.MsgTooLong);
		}

		// Token: 0x0603CD50 RID: 249168 RVA: 0x00F716B0 File Offset: 0x00F6F8B0
		private void NormalHandle()
		{
			base.GetItem(0).SetUIActive(false);
			this.ConfirmButton.SetSelfInteractive(true);
			this.Timer = -1f;
		}

		// Token: 0x0603CD51 RID: 249169 RVA: 0x00F716D6 File Offset: 0x00F6F8D6
		private void NoneTextHandle()
		{
			this.SetTipsAndTimer("PrefabTextItem_Entertext_Text", 0);
		}

		// Token: 0x0603CD52 RID: 249170 RVA: 0x00F716E4 File Offset: 0x00F6F8E4
		private void MsgTooLongHandle()
		{
			this.SetTipsAndTimer("PrefabTextItem_Textoverlength_Text", -1);
			this.ConfirmButton.SetSelfInteractive(false);
		}

		// Token: 0x0603CD53 RID: 249171 RVA: 0x00F716FE File Offset: 0x00F6F8FE
		private void MsgTooShortHandle()
		{
			this.SetTipsAndTimer("CDKey_TooShort", 0);
			this.ConfirmButton.SetSelfInteractive(false);
		}

		// Token: 0x0603CD54 RID: 249172 RVA: 0x00F71718 File Offset: 0x00F6F918
		private void IllegalCharactersHandle()
		{
			this.SetTipsAndTimer("PrefabTextItem_Textillegality_Text", 0);
		}

		// Token: 0x0603CD55 RID: 249173 RVA: 0x00F71726 File Offset: 0x00F6F926
		private void BlankTextHandle()
		{
			this.SetTipsAndTimer("PrefabTextItem_TextNull_Text", 0);
		}

		// Token: 0x0603CD56 RID: 249174 RVA: 0x00F71734 File Offset: 0x00F6F934
		private void SetTipsAndTimer(string textId, int timer)
		{
			base.GetItem(0).SetUIActive(true);
			UUIText text = base.GetText(1);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textId, Array.Empty<object>());
			this.Timer = (float)timer;
		}

		// Token: 0x0603CD57 RID: 249175 RVA: 0x00F7176F File Offset: 0x00F6F96F
		private void Tick(float delta)
		{
			if (Math.Abs(this.Timer - -1f) < 0.001f)
			{
				return;
			}
			this.Timer += delta;
			if (this.Timer >= 2000f)
			{
				this.RefreshTips(ETipsType.Normal);
			}
		}

		// Token: 0x0603CD58 RID: 249176 RVA: 0x00F717AC File Offset: 0x00F6F9AC
		protected override void OnBeforeDestroy()
		{
			this.UnBindTextChange();
			Singleton<TickSystem>.Instance.Remove(this.TickId);
		}

		// Token: 0x0603CD59 RID: 249177 RVA: 0x00F717C5 File Offset: 0x00F6F9C5
		public void ClearText()
		{
			this.InputText.SetText("", false);
		}

		// Token: 0x0603CD5A RID: 249178 RVA: 0x00F717D8 File Offset: 0x00F6F9D8
		[CompilerGenerated]
		private UniTask <ConfirmClick>g__Temp|14_0(string argInputText)
		{
			TextInputComponent.<<ConfirmClick>g__Temp|14_0>d <<ConfirmClick>g__Temp|14_0>d;
			<<ConfirmClick>g__Temp|14_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<ConfirmClick>g__Temp|14_0>d.<>4__this = this;
			<<ConfirmClick>g__Temp|14_0>d.argInputText = argInputText;
			<<ConfirmClick>g__Temp|14_0>d.<>1__state = -1;
			<<ConfirmClick>g__Temp|14_0>d.<>t__builder.Start<TextInputComponent.<<ConfirmClick>g__Temp|14_0>d>(ref <<ConfirmClick>g__Temp|14_0>d);
			return <<ConfirmClick>g__Temp|14_0>d.<>t__builder.Task;
		}

		// Token: 0x04022277 RID: 139895
		private ETipsType TipsType;

		// Token: 0x04022278 RID: 139896
		private float Timer = -1f;

		// Token: 0x04022279 RID: 139897
		private int TickId;

		// Token: 0x0402227A RID: 139898
		[Nullable(2)]
		private Dictionary<ETipsType, Action> TipsTypeFunc;

		// Token: 0x0402227B RID: 139899
		[Nullable(2)]
		private UUITextInputComponent InputText;

		// Token: 0x0402227C RID: 139900
		[Nullable(2)]
		private UUIButtonComponent ConfirmButton;

		// Token: 0x0402227D RID: 139901
		private readonly int MaxLimit = 12;

		// Token: 0x0402227E RID: 139902
		private readonly int MinLimit;

		// Token: 0x0402227F RID: 139903
		private bool IsLockConfirm;

		// Token: 0x04022280 RID: 139904
		private readonly ITextInputData InputData;

		// Token: 0x0200BE86 RID: 48774
		[NullableContext(0)]
		private class ECompDefine
		{
			// Token: 0x0403AA98 RID: 240280
			public const int TipsRootItem = 0;

			// Token: 0x0403AA99 RID: 240281
			public const int Tips = 1;

			// Token: 0x0403AA9A RID: 240282
			public const int InputText = 2;

			// Token: 0x0403AA9B RID: 240283
			public const int DefaultText = 3;

			// Token: 0x0403AA9C RID: 240284
			public const int ConfirmBtn = 4;
		}
	}
}
