using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002107 RID: 8455
public class LoginAgeTipView : UiViewBase
{
	// Token: 0x060102D5 RID: 66261 RVA: 0x0047202F File Offset: 0x0047022F
	[NullableContext(1)]
	public LoginAgeTipView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060102D6 RID: 66262 RVA: 0x00472060 File Offset: 0x00470260
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, this.CloseAgeTipBtnClickCallBack);
		this.BtnBindInfo = list2;
	}

	// Token: 0x060102D7 RID: 66263 RVA: 0x00472164 File Offset: 0x00470364
	protected override void OnStart()
	{
		IUiPopFrameInterface childPopView = this.ChildPopView;
		if (childPopView != null)
		{
			CommonPopViewBase popItem = childPopView.PopItem;
			if (popItem != null)
			{
				popItem.OverrideBackBtnCallBack(delegate
				{
					this.CloseAgeTipBtnClickCallBack();
				});
			}
		}
		LoginAgeTipView.ELoginShowType type = (LoginAgeTipView.ELoginShowType)this.OpenParam;
		this.UpdateShowData(type);
		this.UpdateTitle(type);
	}

	// Token: 0x060102D8 RID: 66264 RVA: 0x004721B4 File Offset: 0x004703B4
	private void UpdateShowData(LoginAgeTipView.ELoginShowType type)
	{
		switch (type)
		{
		case LoginAgeTipView.ELoginShowType.AgeTip:
		{
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.SetUIActive(true);
			}
			UUIText text2 = base.GetText(0);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(ConfigBase<TextConfig>.Instance.GetTextById("AgeTip"), true);
			return;
		}
		case LoginAgeTipView.ELoginShowType.UserAgreement:
		case LoginAgeTipView.ELoginShowType.PrivacyAgreement:
		case LoginAgeTipView.ELoginShowType.ChildPrivacyAgreement:
			this.ShowAgreement(ConfigBase<TextConfig>.Instance.GetTextById(type.ToString()));
			return;
		case LoginAgeTipView.ELoginShowType.LoginNotice:
			if (ModelBase<LoginModel>.Instance.LoginNotice != null)
			{
				this.ShowAgreement(ModelBase<LoginModel>.Instance.LoginNotice.content);
			}
			return;
		default:
			return;
		}
	}

	// Token: 0x060102D9 RID: 66265 RVA: 0x00472250 File Offset: 0x00470450
	[NullableContext(1)]
	private void ShowAgreement(string content)
	{
		string text = content;
		int i = 0;
		while (i < 3)
		{
			int num = text.IndexOf('\n', 6000);
			if (num == -1)
			{
				if (text.Length >= 6000)
				{
					break;
				}
				UUIText text2 = base.GetText(i);
				if (text2 != null)
				{
					text2.SetUIActive(true);
				}
				UUIText text3 = base.GetText(i);
				if (text3 == null)
				{
					return;
				}
				text3.SetText(text, true);
				return;
			}
			else
			{
				string newText = text.Substring(0, num);
				UUIText text4 = base.GetText(i);
				if (text4 != null)
				{
					text4.SetUIActive(true);
				}
				UUIText text5 = base.GetText(i);
				if (text5 != null)
				{
					text5.SetText(newText, true);
				}
				text = text.Substring(num + 1);
				i++;
			}
		}
	}

	// Token: 0x060102DA RID: 66266 RVA: 0x004722F4 File Offset: 0x004704F4
	private void UpdateTitle(LoginAgeTipView.ELoginShowType type)
	{
		string id = null;
		switch (type)
		{
		case LoginAgeTipView.ELoginShowType.AgeTip:
			id = "AgeTipTitle";
			break;
		case LoginAgeTipView.ELoginShowType.UserAgreement:
			id = "UserTitle";
			break;
		case LoginAgeTipView.ELoginShowType.PrivacyAgreement:
			id = "PrivacyTitle";
			break;
		case LoginAgeTipView.ELoginShowType.ChildPrivacyAgreement:
			id = "ChildPrivacyTitle";
			break;
		case LoginAgeTipView.ELoginShowType.LoginNotice:
			if (ModelBase<LoginModel>.Instance.LoginNotice != null)
			{
				UUIText text = base.GetText(4);
				if (text == null)
				{
					return;
				}
				text.SetText(ModelBase<LoginModel>.Instance.LoginNotice.Title, true);
			}
			return;
		}
		string textById = ConfigBase<TextConfig>.Instance.GetTextById(id);
		UUIText text2 = base.GetText(4);
		if (text2 == null)
		{
			return;
		}
		text2.SetText(textById, true);
	}

	// Token: 0x04007C45 RID: 31813
	[Nullable(1)]
	private readonly Action CloseAgeTipBtnClickCallBack = delegate()
	{
		Singleton<UiLayer>.Instance.SetShowNormalMaskLayer(false, "");
		Singleton<UiManager>.Instance.CloseView(EUiViewName.LoginAgeTipView, null);
	};

	// Token: 0x0200848E RID: 33934
	public enum ELoginShowType
	{
		// Token: 0x0402CE7C RID: 183932
		AgeTip,
		// Token: 0x0402CE7D RID: 183933
		UserAgreement,
		// Token: 0x0402CE7E RID: 183934
		PrivacyAgreement,
		// Token: 0x0402CE7F RID: 183935
		ChildPrivacyAgreement,
		// Token: 0x0402CE80 RID: 183936
		LoginNotice
	}

	// Token: 0x0200848F RID: 33935
	private enum ELoginAgeTipChildCom
	{
		// Token: 0x0402CE82 RID: 183938
		Text1,
		// Token: 0x0402CE83 RID: 183939
		Text2,
		// Token: 0x0402CE84 RID: 183940
		Text3,
		// Token: 0x0402CE85 RID: 183941
		CloseBtn,
		// Token: 0x0402CE86 RID: 183942
		Title
	}
}
