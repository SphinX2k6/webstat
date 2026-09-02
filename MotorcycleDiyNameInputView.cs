using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.InputView.Model;
using CSharpScript.Game.Module.Common.InputView.View;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002303 RID: 8963
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleDiyNameInputView : CommonInputViewBase
{
	// Token: 0x06011012 RID: 69650 RVA: 0x004AA8EC File Offset: 0x004A8AEC
	public MotorcycleDiyNameInputView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06011013 RID: 69651 RVA: 0x004AA8F8 File Offset: 0x004A8AF8
	protected override int GetMaxLimit()
	{
		return ConfigCommonParamById.GetIntConfig("MotorOutlookPresetNameLength").GetValueOrDefault();
	}

	// Token: 0x06011014 RID: 69652 RVA: 0x004AA917 File Offset: 0x004A8B17
	protected override void InitExtraParam()
	{
		this.RefreshUi();
	}

	// Token: 0x06011015 RID: 69653 RVA: 0x004AA91F File Offset: 0x004A8B1F
	protected override void RefreshDuplicateName(string inputText)
	{
		this.RefreshUi();
	}

	// Token: 0x06011016 RID: 69654 RVA: 0x004AA927 File Offset: 0x004A8B27
	protected override void RefreshTips(ETipsType type)
	{
		base.RefreshTips(type);
		if (type == ETipsType.Normal)
		{
			this.RefreshUi();
		}
	}

	// Token: 0x06011017 RID: 69655 RVA: 0x004AA939 File Offset: 0x004A8B39
	protected override bool IsAllowMultiLine()
	{
		return false;
	}

	// Token: 0x06011018 RID: 69656 RVA: 0x004AA93C File Offset: 0x004A8B3C
	private void RefreshUi()
	{
		string text = this.InputText.Text;
		int stringRealCount = StringUtils.GetStringRealCount(text);
		if (stringRealCount > this.GetMaxLimit())
		{
			this.ConfirmButton.SetSelfInteractive(false);
			return;
		}
		bool flag = this.InputData.NeedCheckBlank.GetValueOrDefault() && text.Length > 0 && StringUtils.CheckIsOnlyBlank(text);
		if (this.InputData.IsCheckNone && (stringRealCount == 0 || flag))
		{
			if (stringRealCount == 0)
			{
				UUIText text2 = base.GetText(6);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, "DIYProjectTips01", Array.Empty<object>());
			}
			base.RefreshTips(flag ? ETipsType.Blank : ETipsType.NoneText);
			this.ConfirmButton.SetSelfInteractive(false);
			return;
		}
		base.RefreshTips(ETipsType.Normal);
		this.ConfirmButton.SetSelfInteractive(true);
	}

	// Token: 0x040085D3 RID: 34259
	private const int DEFAULT_TEXT_COMPONENT_INDEX = 6;
}
