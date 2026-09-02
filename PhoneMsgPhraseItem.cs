using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200256D RID: 9581
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PhoneMsgPhraseItem : GridProxyAbstract<string>
{
	// Token: 0x06012A26 RID: 76326 RVA: 0x00522D28 File Offset: 0x00520F28
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x06012A27 RID: 76327 RVA: 0x00522D64 File Offset: 0x00520F64
	protected override void OnStart()
	{
		base.OnStart();
		UUIText text = base.GetText(1);
		text.bGameRichText = true;
		text.richText = true;
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		extendToggle.OnPointDownCallBack.Bind(new Action<EToggleState>(this.OnClickToggle));
		extendToggle.CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
	}

	// Token: 0x06012A28 RID: 76328 RVA: 0x00522DBF File Offset: 0x00520FBF
	[NullableContext(1)]
	public override void Refresh(string contentText, bool isSelected, int gridIndex)
	{
		this.Data = contentText;
		base.GetText(1).SetText(contentText, true);
	}

	// Token: 0x06012A29 RID: 76329 RVA: 0x00522DD6 File Offset: 0x00520FD6
	private void OnClickToggle(EToggleState state)
	{
		Action<int> onClickDelegate = this.OnClickDelegate;
		if (onClickDelegate == null)
		{
			return;
		}
		onClickDelegate(base.GridIndex);
	}

	// Token: 0x06012A2A RID: 76330 RVA: 0x00522DEE File Offset: 0x00520FEE
	private bool CanExecuteChange()
	{
		return false;
	}

	// Token: 0x04009196 RID: 37270
	protected string Data;

	// Token: 0x04009197 RID: 37271
	public Action<int> OnClickDelegate;

	// Token: 0x0200888B RID: 34955
	[NullableContext(0)]
	private enum ETogPhraseComponent
	{
		// Token: 0x0402E1E6 RID: 188902
		TogPhrase,
		// Token: 0x0402E1E7 RID: 188903
		TxtPhrase
	}
}
