using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200177B RID: 6011
public class AdviceAllViewShowContent : UiPanelBase
{
	// Token: 0x0600A962 RID: 43362 RVA: 0x002D28EF File Offset: 0x002D0AEF
	[NullableContext(1)]
	public AdviceAllViewShowContent(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600A963 RID: 43363 RVA: 0x002D2904 File Offset: 0x002D0B04
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(7, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(8, typeof(UUIText))
		};
	}

	// Token: 0x0600A964 RID: 43364 RVA: 0x002D29E4 File Offset: 0x002D0BE4
	protected override void OnStart()
	{
		base.GetExtendToggle(6).RootUIComp.Get().SetUIActive(false);
		base.GetExtendToggle(7).RootUIComp.Get().SetUIActive(false);
		UUIText text = base.GetText(5);
		if (text != null)
		{
			text.SetUIActive(false);
		}
		UUIText text2 = base.GetText(8);
		if (text2 != null)
		{
			text2.SetUIActive(false);
		}
		Singleton<EventSystem>.Instance.Add(EEventName.OnSelectAdviceExpression, new Action(this.RefreshExpression));
		Singleton<EventSystem>.Instance.Add(EEventName.OnSelectAdviceWord, new Action(this.RefreshText));
		Singleton<EventSystem>.Instance.Add(EEventName.OnChangeAdviceWord, new Action(this.RefreshText));
		this.RefreshPlayerName();
		this.RefreshExpression();
		this.RefreshText();
	}

	// Token: 0x0600A965 RID: 43365 RVA: 0x002D2AB4 File Offset: 0x002D0CB4
	private void RefreshText()
	{
		if (ModelBase<AdviceModel>.Instance.CurrentLineModel == ELineMode.MutiLine)
		{
			UUIText text = base.GetText(8);
			if (text != null)
			{
				text.SetUIActive(true);
			}
			UUIText text2 = base.GetText(8);
			if (text2 != null)
			{
				text2.SetText(ModelBase<AdviceModel>.Instance.GetSecondLineText(), true);
			}
		}
		else
		{
			UUIText text3 = base.GetText(8);
			if (text3 != null)
			{
				text3.SetUIActive(false);
			}
		}
		string firstLineText = ModelBase<AdviceModel>.Instance.GetFirstLineText();
		UUIText text4 = base.GetText(4);
		if (text4 == null)
		{
			return;
		}
		text4.SetText(firstLineText, true);
	}

	// Token: 0x0600A966 RID: 43366 RVA: 0x002D2B34 File Offset: 0x002D0D34
	private void RefreshPlayerName()
	{
		string playerName = ModelBase<FunctionModel>.Instance.GetPlayerName();
		UUIText text = base.GetText(2);
		if (text == null)
		{
			return;
		}
		text.SetText(playerName ?? "", true);
	}

	// Token: 0x0600A967 RID: 43367 RVA: 0x002D2B68 File Offset: 0x002D0D68
	private void RefreshExpression()
	{
		int currentExpressionId = ModelBase<AdviceModel>.Instance.CurrentExpressionId;
		if (currentExpressionId > 0)
		{
			UUITexture texture = base.GetTexture(1);
			if (texture != null)
			{
				texture.SetUIActive(true);
			}
			ChatExpression? expressionConfig = ConfigBase<ChatConfig>.Instance.GetExpressionConfig(currentExpressionId);
			if (expressionConfig != null)
			{
				base.SetTextureByPath(expressionConfig.Value.ExpressionTexturePath, base.GetTexture(1), null, null);
				return;
			}
		}
		else
		{
			UUITexture texture2 = base.GetTexture(1);
			if (texture2 == null)
			{
				return;
			}
			texture2.SetUIActive(false);
		}
	}

	// Token: 0x0600A968 RID: 43368 RVA: 0x002D2BE5 File Offset: 0x002D0DE5
	public void RefreshView()
	{
		this.RefreshText();
	}

	// Token: 0x0600A969 RID: 43369 RVA: 0x002D2BF0 File Offset: 0x002D0DF0
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSelectAdviceExpression, new Action(this.RefreshExpression));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSelectAdviceWord, new Action(this.RefreshText));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeAdviceWord, new Action(this.RefreshText));
	}

	// Token: 0x02007ADE RID: 31454
	private static class EComponents
	{
		// Token: 0x0402A13B RID: 172347
		public const int ContentItem = 0;

		// Token: 0x0402A13C RID: 172348
		public const int EmojiTexture = 1;

		// Token: 0x0402A13D RID: 172349
		public const int NameText = 2;

		// Token: 0x0402A13E RID: 172350
		public const int TextLayout = 3;

		// Token: 0x0402A13F RID: 172351
		public const int ContentText = 4;

		// Token: 0x0402A140 RID: 172352
		public const int LikeNumText = 5;

		// Token: 0x0402A141 RID: 172353
		public const int DislikeToggle = 6;

		// Token: 0x0402A142 RID: 172354
		public const int LikeToggle = 7;

		// Token: 0x0402A143 RID: 172355
		public const int ContentText2 = 8;
	}
}
