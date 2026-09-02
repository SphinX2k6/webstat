using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001851 RID: 6225
public class ChatExpressionItem : GridProxyAbstract<ChatExpression>
{
	// Token: 0x0600B206 RID: 45574 RVA: 0x002F7DCC File Offset: 0x002F5FCC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedExpressionButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B207 RID: 45575 RVA: 0x002F7E93 File Offset: 0x002F6093
	private void OnClickedExpressionButton()
	{
		Action<int> onClicked = this.OnClicked;
		if (onClicked == null)
		{
			return;
		}
		onClicked(this.ExpressionId);
	}

	// Token: 0x0600B208 RID: 45576 RVA: 0x002F7EAC File Offset: 0x002F60AC
	public override void Refresh(ChatExpression expressionConfig, bool isSelected, int gridIndex)
	{
		this.ExpressionId = expressionConfig.Id;
		string expressionTexturePath = expressionConfig.ExpressionTexturePath;
		UUITexture expressionTexture = base.GetTexture(2);
		expressionTexture.SetUIActive(false);
		base.SetTextureByPath(expressionTexturePath, expressionTexture, null, delegate(bool _)
		{
			expressionTexture.SetUIActive(true);
		});
		string name = expressionConfig.Name;
		base.GetText(1).ShowTextNew(name);
	}

	// Token: 0x0600B209 RID: 45577 RVA: 0x002F7F24 File Offset: 0x002F6124
	[NullableContext(1)]
	public void BindOnClicked(Action<int> onClicked)
	{
		this.OnClicked = onClicked;
	}

	// Token: 0x0400545F RID: 21599
	private int ExpressionId;

	// Token: 0x04005460 RID: 21600
	[Nullable(2)]
	private Action<int> OnClicked;

	// Token: 0x02007BEF RID: 31727
	private class EChildType
	{
		// Token: 0x0402A590 RID: 173456
		public const int ExpressionButton = 0;

		// Token: 0x0402A591 RID: 173457
		public const int ExpressionNameText = 1;

		// Token: 0x0402A592 RID: 173458
		public const int ExpressionTexture = 2;
	}
}
