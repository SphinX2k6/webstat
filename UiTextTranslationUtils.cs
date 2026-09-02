using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x02000C2B RID: 3115
[NullableContext(1)]
[Nullable(0)]
public class UiTextTranslationUtils : IStaticVariableResetter
{
	// Token: 0x060035DF RID: 13791 RVA: 0x00033122 File Offset: 0x00031322
	static UiTextTranslationUtils()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(UiTextTranslationUtils.CreateStaticDefaultValue), new Action(UiTextTranslationUtils.ResetStaticDefaultValue));
	}

	// Token: 0x060035E0 RID: 13792 RVA: 0x00033141 File Offset: 0x00031341
	private static void FixBestFit(UUIText uiText)
	{
		if (uiText.overflowType == UITextOverflowType.VerticalOverflow)
		{
			uiText.bBestFit = uiText.verticalOverflowBestFitSwitch;
		}
	}

	// Token: 0x060035E1 RID: 13793 RVA: 0x00033158 File Offset: 0x00031358
	public static void TranslateText(UUIText uiText)
	{
		if (uiText.TranslateId == 0U)
		{
			uiText.text = "";
			return;
		}
		PrefabTextItem? config = ConfigPrefabTextItemByItemId.GetConfig((long)((ulong)uiText.TranslateId), true);
		if (config != null)
		{
			UiTextTranslationUtils.FixBestFit(uiText);
			uiText.ShowTextNew(config.Value.Text);
		}
	}

	// Token: 0x060035E2 RID: 13794 RVA: 0x000331AB File Offset: 0x000313AB
	private static void HandleTextComponentRichText(string textKey, UUIText uiText)
	{
		uiText.SetGameRichText(true);
		uiText.SetRichText(true);
	}

	// Token: 0x060035E3 RID: 13795 RVA: 0x000331BC File Offset: 0x000313BC
	[return: Nullable(2)]
	private unsafe static string GetLocalTextNew(string textKey, UUIText uiText, bool isMainText)
	{
		if (UiTextTranslationUtils.TextShowTranslateId)
		{
			return uiText.TranslateId.ToString();
		}
		UiTextTranslationUtils.HandleTextComponentRichText(textKey, uiText);
		string text = ConfigMultiTextLang.GetLocalTextNew(textKey, null);
		if (isMainText)
		{
			if (text == null)
			{
				text = uiText.GetText();
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.TextLanguageSearch;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "[GetLocalTextNew]预制体固定文本多语言切换失败，该文本控件Id还没有收集到，将显示预制体上的文本";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("控件Id", uiText.TranslateId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("控件自身文本", text);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			if (text != uiText.GetText())
			{
				UiTextTranslationUtils.FixBestFit(uiText);
			}
		}
		else if (text == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.TextLanguageSearch;
			ELogAuthor author2 = ELogAuthor.XXJ;
			string message2 = "[GetLocalTextNew]格式化字符串传入的表名与文本id无效";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("文本id", textKey);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return text;
	}

	// Token: 0x060035E4 RID: 13796 RVA: 0x000332A4 File Offset: 0x000314A4
	public static void GmReplaceText(UUIText uiText)
	{
		if (UiTextTranslationUtils.AkiFontData != null)
		{
			uiText.SetFont(UiTextTranslationUtils.AkiFontData);
		}
	}

	// Token: 0x060035E5 RID: 13797 RVA: 0x000332B8 File Offset: 0x000314B8
	public static void Initialize()
	{
		Action<UUIText> callback;
		if ((callback = UiTextTranslationUtils.<>O.<0>__TranslateText) == null)
		{
			callback = (UiTextTranslationUtils.<>O.<0>__TranslateText = new Action<UUIText>(UiTextTranslationUtils.TranslateText));
		}
		FLGUITextTranslateDelegate flguitextTranslateDelegate = global::DelegateUtils.ToManualReleaseDelegate<FLGUITextTranslateDelegate>(callback);
		UUIText.SetTextTranslateDelegate(flguitextTranslateDelegate);
		Func<string, UUIText, bool, string> callback2;
		if ((callback2 = UiTextTranslationUtils.<>O.<1>__GetLocalTextNew) == null)
		{
			callback2 = (UiTextTranslationUtils.<>O.<1>__GetLocalTextNew = new Func<string, UUIText, bool, string>(UiTextTranslationUtils.GetLocalTextNew));
		}
		FLocalTextNewDelegate flocalTextNewDelegate = global::DelegateUtils.ToManualReleaseDelegate<FLocalTextNewDelegate>(callback2);
		UUIText.SetLocalTextNewDelegate(flocalTextNewDelegate);
	}

	// Token: 0x060035E6 RID: 13798 RVA: 0x00033318 File Offset: 0x00031518
	public static void Destroy()
	{
		FLGUITextTranslateDelegate flguitextTranslateDelegate = null;
		UUIText.SetTextTranslateDelegate(flguitextTranslateDelegate);
		FLocalTextDelegate flocalTextDelegate = null;
		UUIText.SetLocalTextDelegate(flocalTextDelegate);
		FLocalTextNewDelegate flocalTextNewDelegate = null;
		UUIText.SetLocalTextNewDelegate(flocalTextNewDelegate);
		Action<UUIText> callBack;
		if ((callBack = UiTextTranslationUtils.<>O.<0>__TranslateText) == null)
		{
			callBack = (UiTextTranslationUtils.<>O.<0>__TranslateText = new Action<UUIText>(UiTextTranslationUtils.TranslateText));
		}
		global::DelegateUtils.ReleaseManualReleaseDelegate(callBack);
		Func<string, UUIText, bool, string> callBack2;
		if ((callBack2 = UiTextTranslationUtils.<>O.<1>__GetLocalTextNew) == null)
		{
			callBack2 = (UiTextTranslationUtils.<>O.<1>__GetLocalTextNew = new Func<string, UUIText, bool, string>(UiTextTranslationUtils.GetLocalTextNew));
		}
		global::DelegateUtils.ReleaseManualReleaseDelegate(callBack2);
	}

	// Token: 0x060035E7 RID: 13799 RVA: 0x00033380 File Offset: 0x00031580
	public static void CreateStaticDefaultValue()
	{
	}

	// Token: 0x060035E8 RID: 13800 RVA: 0x00033382 File Offset: 0x00031582
	public static void ResetStaticDefaultValue()
	{
		UiTextTranslationUtils.AkiFontData = null;
		UiTextTranslationUtils.TextShowTranslateId = false;
	}

	// Token: 0x040006B5 RID: 1717
	[Nullable(2)]
	public static ULGUIFontData_BaseObject AkiFontData;

	// Token: 0x040006B6 RID: 1718
	public static bool TextShowTranslateId;

	// Token: 0x020071C7 RID: 29127
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x04027999 RID: 162201
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Action<UUIText> <0>__TranslateText;

		// Token: 0x0402799A RID: 162202
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			2
		})]
		public static Func<string, UUIText, bool, string> <1>__GetLocalTextNew;

		// Token: 0x0402799B RID: 162203
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Action<UUIText> <2>__GmReplaceText;
	}
}
