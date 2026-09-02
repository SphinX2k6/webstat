using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Common.InputView.Model;
using CSharpScript.Game.Module.Common.InputView.View;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;

// Token: 0x0200182D RID: 6189
[NullableContext(1)]
[Nullable(0)]
public class CdKeyInputView : CommonInputViewBase
{
	// Token: 0x0600B0B4 RID: 45236 RVA: 0x002F2D53 File Offset: 0x002F0F53
	public CdKeyInputView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600B0B5 RID: 45237 RVA: 0x002F2D5C File Offset: 0x002F0F5C
	protected override void InitExtraParam()
	{
		IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("CdKeyLengthLimit");
		this.MinLimit = intArrayConfig[0];
		this.MaxLimit = intArrayConfig[1];
	}

	// Token: 0x0600B0B6 RID: 45238 RVA: 0x002F2D8E File Offset: 0x002F0F8E
	protected override int GetMaxLimit()
	{
		return this.MaxLimit;
	}

	// Token: 0x0600B0B7 RID: 45239 RVA: 0x002F2D96 File Offset: 0x002F0F96
	protected override int GetMinLimit()
	{
		return this.MinLimit;
	}

	// Token: 0x0600B0B8 RID: 45240 RVA: 0x002F2D9E File Offset: 0x002F0F9E
	protected override bool IsAllowMultiLine()
	{
		return false;
	}

	// Token: 0x0600B0B9 RID: 45241 RVA: 0x002F2DA1 File Offset: 0x002F0FA1
	protected override void ExecuteInputConfirm(string inputText)
	{
		ICommonInputViewData inputData = this.InputData;
		if (((inputData != null) ? inputData.ConfirmFunc : null) != null)
		{
			this.InputData.ConfirmFunc(inputText).ContinueWith(delegate(Aki.Protocol.ErrorCode errorCode)
			{
				if (errorCode == Aki.Protocol.ErrorCode.Success)
				{
					ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.CdKeyVerifySuccess);
					ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
					base.CloseMe(null);
					return;
				}
				string textByErrorId = ConfigBase<ErrorCodeConfig>.Instance.GetTextByErrorId(errorCode);
				this.CdKeyErrorText = (textByErrorId ?? this.CdKeyErrorText);
				this.RefreshTips(ETipsType.InValidCdKey);
			});
		}
	}

	// Token: 0x0600B0BA RID: 45242 RVA: 0x002F2DDA File Offset: 0x002F0FDA
	protected override bool ExtraConfirmCheck(int count, string text)
	{
		return !this.CheckTimeIntervalIllegal() && !this.CheckStringIllegal(text);
	}

	// Token: 0x0600B0BB RID: 45243 RVA: 0x002F2DF2 File Offset: 0x002F0FF2
	private bool CheckTimeIntervalIllegal()
	{
		bool flag = ControllerBase<CdKeyInputController>.Instance.CheckInCdKeyUseCd();
		if (flag)
		{
			this.RefreshTips(ETipsType.CdKeyInCd);
		}
		return flag;
	}

	// Token: 0x0600B0BC RID: 45244 RVA: 0x002F2E08 File Offset: 0x002F1008
	private bool CheckStringIllegal(string text)
	{
		bool flag = StringUtils.CheckIsOnlyLettersAndNumbers(text);
		if (!flag)
		{
			this.RefreshTips(ETipsType.IllegalCharacters);
		}
		return !flag;
	}

	// Token: 0x040053AC RID: 21420
	private int MaxLimit;

	// Token: 0x040053AD RID: 21421
	private int MinLimit;
}
