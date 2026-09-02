using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Common.InputView.View
{
	// Token: 0x02005E72 RID: 24178
	[NullableContext(1)]
	[Nullable(0)]
	public class CommonModifyNameInputView : CommonInputViewBase
	{
		// Token: 0x0603CD0E RID: 249102 RVA: 0x00F70FD7 File Offset: 0x00F6F1D7
		public CommonModifyNameInputView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603CD0F RID: 249103 RVA: 0x00F70FE0 File Offset: 0x00F6F1E0
		protected override void OnAddEventListener()
		{
			base.OnAddEventListener();
			Singleton<EventSystem>.Instance.Add(EEventName.OnModifyNameStateChange, new Action(this.OnModifyNameStateChange));
		}

		// Token: 0x0603CD10 RID: 249104 RVA: 0x00F71004 File Offset: 0x00F6F204
		protected override void OnRemoveEventListener()
		{
			base.OnRemoveEventListener();
			Singleton<EventSystem>.Instance.Remove(EEventName.OnModifyNameStateChange, new Action(this.OnModifyNameStateChange));
		}

		// Token: 0x0603CD11 RID: 249105 RVA: 0x00F71028 File Offset: 0x00F6F228
		protected override int GetMaxLimit()
		{
			return 12;
		}

		// Token: 0x0603CD12 RID: 249106 RVA: 0x00F7102C File Offset: 0x00F6F22C
		protected override bool IsAllowMultiLine()
		{
			return false;
		}

		// Token: 0x0603CD13 RID: 249107 RVA: 0x00F7102F File Offset: 0x00F6F22F
		protected override void InitExtraParam()
		{
			this.RefreshUi();
		}

		// Token: 0x0603CD14 RID: 249108 RVA: 0x00F71037 File Offset: 0x00F6F237
		protected override void RefreshDuplicateName(string inputText)
		{
			this.RefreshUi();
		}

		// Token: 0x0603CD15 RID: 249109 RVA: 0x00F71040 File Offset: 0x00F6F240
		private void RefreshUi()
		{
			EModifyNameState personalModifyNameState = ModelBase<PersonalModel>.Instance.GetPersonalModifyNameState();
			base.SetBottomTipsShowState(true);
			if (personalModifyNameState == EModifyNameState.CanBeModified || personalModifyNameState == EModifyNameState.UnModifiable)
			{
				base.SetBottomTipsTextAndColor("PersonalProfile_ChangeNameLimit", FColor.FromHex("6E6A62FF"));
			}
			else if (personalModifyNameState == EModifyNameState.UnderModification)
			{
				base.SetBottomTipsTextAndColor("PersonalProfile_ChangeNameProcess", FColor.FromHex("C25757FF"));
			}
			bool flag = personalModifyNameState == EModifyNameState.CanBeModified;
			bool flag2 = this.InputText.Text != this.InputData.InputText;
			bool flag3 = StringUtils.GetStringRealCount(this.InputText.Text) > this.GetMaxLimit();
			this.ConfirmButton.SetSelfInteractive(flag && flag2 && !flag3);
		}

		// Token: 0x0603CD16 RID: 249110 RVA: 0x00F710E7 File Offset: 0x00F6F2E7
		protected override void ExecuteInputConfirm(string inputText)
		{
			CommonModifyNameInputView.<>c__DisplayClass8_0 CS$<>8__locals1 = new CommonModifyNameInputView.<>c__DisplayClass8_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.inputText = inputText;
			CS$<>8__locals1.<ExecuteInputConfirm>g__Temp|0().Forget(delegate(Exception exception)
			{
				Singleton<Log>.Instance.Error(ELogModule.UiCommon, ELogAuthor.XXJ, "通用输入框执行出现未知错误", default(ReadOnlySpan<ValueTuple<string, object>>));
			}, true);
		}

		// Token: 0x0603CD17 RID: 249111 RVA: 0x00F71126 File Offset: 0x00F6F326
		private void OnModifyNameStateChange()
		{
			this.RefreshUi();
		}
	}
}
