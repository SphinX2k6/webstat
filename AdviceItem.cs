using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001785 RID: 6021
public class AdviceItem : UiPanelBase
{
	// Token: 0x0600A9C3 RID: 43459 RVA: 0x002D4490 File Offset: 0x002D2690
	[NullableContext(1)]
	public AdviceItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600A9C4 RID: 43460 RVA: 0x002D44A8 File Offset: 0x002D26A8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUITexture)),
			new ValueTuple<int, Type>(5, typeof(UUISprite))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickDeleteBtn))
		};
	}

	// Token: 0x0600A9C5 RID: 43461 RVA: 0x002D4567 File Offset: 0x002D2767
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnModifyAdviceSuccess, new Action<long>(this.OnOnModifyAdviceSuccess));
	}

	// Token: 0x0600A9C6 RID: 43462 RVA: 0x002D4585 File Offset: 0x002D2785
	private void OnOnModifyAdviceSuccess(long modifyId)
	{
		if (this.AdviceDataInstance != null && modifyId == this.AdviceDataInstance.GetAdviceId())
		{
			this.RefreshView();
		}
	}

	// Token: 0x0600A9C7 RID: 43463 RVA: 0x002D45A4 File Offset: 0x002D27A4
	private void OnClickDeleteBtn()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.AdviceDeleteTips);
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			ControllerBase<AdviceController>.Instance.RequestDeleteAdvice(this.AdviceDataInstance.GetAdviceId());
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600A9C8 RID: 43464 RVA: 0x002D45DD File Offset: 0x002D27DD
	[NullableContext(1)]
	public void Update(AdviceData adviceData)
	{
		this.AdviceDataInstance = adviceData;
		this.RefreshView();
	}

	// Token: 0x0600A9C9 RID: 43465 RVA: 0x002D45EC File Offset: 0x002D27EC
	private void RefreshView()
	{
		this.RefreshText();
		this.RefreshEmojiTexture();
		this.RefreshLikeNum();
		this.RefreshLocationText();
	}

	// Token: 0x0600A9CA RID: 43466 RVA: 0x002D4606 File Offset: 0x002D2806
	private void RefreshText()
	{
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetText(this.AdviceDataInstance.GetAdviceShowText(), true);
	}

	// Token: 0x0600A9CB RID: 43467 RVA: 0x002D4628 File Offset: 0x002D2828
	private void RefreshEmojiTexture()
	{
		bool flag = this.AdviceDataInstance.GetAdviceExpressionId() > 0;
		if (flag)
		{
			ChatExpression? expressionConfig = ConfigBase<ChatConfig>.Instance.GetExpressionConfig(this.AdviceDataInstance.GetAdviceExpressionId());
			if (expressionConfig != null)
			{
				base.SetTextureByPath(expressionConfig.Value.ExpressionTexturePath, base.GetTexture(4), null, null);
			}
		}
		UUISprite sprite = base.GetSprite(5);
		if (sprite != null)
		{
			sprite.SetUIActive(!flag);
		}
		UUITexture texture = base.GetTexture(4);
		if (texture == null)
		{
			return;
		}
		texture.SetUIActive(flag);
	}

	// Token: 0x0600A9CC RID: 43468 RVA: 0x002D46B4 File Offset: 0x002D28B4
	private void RefreshLikeNum()
	{
		long vote = this.AdviceDataInstance.GetVote();
		UUIText text = base.GetText(2);
		if (text == null)
		{
			return;
		}
		text.SetText(vote.ToString(), true);
	}

	// Token: 0x0600A9CD RID: 43469 RVA: 0x002D46E8 File Offset: 0x002D28E8
	private void RefreshLocationText()
	{
		int areaId = this.AdviceDataInstance.GetAreaId();
		Area? areaInfo = ConfigBase<AreaConfig>.Instance.GetAreaInfo(areaId);
		if (areaInfo != null)
		{
			string areaLocalName = ConfigBase<AreaConfig>.Instance.GetAreaLocalName(areaInfo.Value.Title);
			UUIText text = base.GetText(3);
			if (text == null)
			{
				return;
			}
			text.SetText(areaLocalName, true);
		}
	}

	// Token: 0x0600A9CE RID: 43470 RVA: 0x002D4743 File Offset: 0x002D2943
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnModifyAdviceSuccess, new Action<long>(this.OnOnModifyAdviceSuccess));
	}

	// Token: 0x04004FEC RID: 20460
	[Nullable(2)]
	private AdviceData AdviceDataInstance;

	// Token: 0x02007AE7 RID: 31463
	private static class EChildType
	{
		// Token: 0x0402A166 RID: 172390
		public const int DeleteBtn = 0;

		// Token: 0x0402A167 RID: 172391
		public const int DescText = 1;

		// Token: 0x0402A168 RID: 172392
		public const int LikeNumText = 2;

		// Token: 0x0402A169 RID: 172393
		public const int LocationText = 3;

		// Token: 0x0402A16A RID: 172394
		public const int EmojiTexture = 4;

		// Token: 0x0402A16B RID: 172395
		public const int DefaultSprite = 5;
	}
}
