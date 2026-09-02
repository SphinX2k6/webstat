using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002227 RID: 8743
[NullableContext(1)]
[Nullable(0)]
public class MailLinkButton : UiPanelBase
{
	// Token: 0x06010819 RID: 67609 RVA: 0x00482580 File Offset: 0x00480780
	public MailLinkButton(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0601081A RID: 67610 RVA: 0x00482595 File Offset: 0x00480795
	public void SetTitle(string text)
	{
		base.GetText(0).SetText(text, true);
	}

	// Token: 0x0601081B RID: 67611 RVA: 0x004825A5 File Offset: 0x004807A5
	public void SetTitleByTextKey(string textKey)
	{
		if (StringUtils.IsEmpty(textKey))
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textKey, Array.Empty<object>());
	}

	// Token: 0x0601081C RID: 67612 RVA: 0x004825C7 File Offset: 0x004807C7
	public void SetColor(string hex)
	{
		base.GetText(0).SetColor(FColor.FromHex(hex));
	}

	// Token: 0x0601081D RID: 67613 RVA: 0x004825DC File Offset: 0x004807DC
	public void SetJumpIcon(int jumpId)
	{
		UUISprite sprite = base.GetSprite(1);
		sprite.SetUIActive(true);
		MailTo? mailToConfigById = ConfigBase<MailConfig>.Instance.GetMailToConfigById(jumpId);
		if (mailToConfigById != null && !StringUtils.IsEmpty(mailToConfigById.Value.IconPath))
		{
			this.SetSpriteByPath(mailToConfigById.Value.IconPath, sprite, false, null, null);
			return;
		}
		if (jumpId <= 0)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_IconPageLink");
			this.SetSpriteByPath(resourcePath, sprite, false, null, null);
			return;
		}
		string functionIconPath = ConfigBase<FunctionConfig>.Instance.GetFunctionIconPath(jumpId);
		if (StringUtils.IsEmpty(functionIconPath))
		{
			return;
		}
		this.SetSpriteByPath(functionIconPath, sprite, false, null, null);
	}

	// Token: 0x0601081E RID: 67614 RVA: 0x0048269C File Offset: 0x0048089C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
	}

	// Token: 0x0601081F RID: 67615 RVA: 0x00482710 File Offset: 0x00480910
	protected override void OnStart()
	{
		this.Button = (this.RootActor.GetComponentByClass(UUIButtonComponent.StaticClass()) as UUIButtonComponent);
		this.Button.OnClickCallBack.Bind(new Action(this.OnClick));
	}

	// Token: 0x06010820 RID: 67616 RVA: 0x0048274E File Offset: 0x0048094E
	protected override void OnBeforeDestroy()
	{
		this.ClickDelegate = null;
	}

	// Token: 0x06010821 RID: 67617 RVA: 0x00482757 File Offset: 0x00480957
	private void OnClick()
	{
		Action clickDelegate = this.ClickDelegate;
		if (clickDelegate == null)
		{
			return;
		}
		clickDelegate();
	}

	// Token: 0x040081E7 RID: 33255
	public Action ClickDelegate;

	// Token: 0x040081E8 RID: 33256
	private UUIButtonComponent Button;
}
