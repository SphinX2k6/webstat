using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x0200268C RID: 9868
[NullableContext(1)]
[Nullable(0)]
public class QuestReviewNodeNormalItem : QuestReviewNodeItemBase
{
	// Token: 0x06013773 RID: 79731 RVA: 0x0056CBA5 File Offset: 0x0056ADA5
	public QuestReviewNodeNormalItem(UUIItem redDot)
	{
		this.RedDot = redDot;
	}

	// Token: 0x06013774 RID: 79732 RVA: 0x0056CBB4 File Offset: 0x0056ADB4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 15;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(13, new Action<EToggleState>(this.OnToggleNodeClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06013775 RID: 79733 RVA: 0x0056CE0F File Offset: 0x0056B00F
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnOpenQuestReviewDetail, new Action<int>(this.OnOpenQuestReviewDetail));
	}

	// Token: 0x06013776 RID: 79734 RVA: 0x0056CE2D File Offset: 0x0056B02D
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnOpenQuestReviewDetail, new Action<int>(this.OnOpenQuestReviewDetail));
	}

	// Token: 0x06013777 RID: 79735 RVA: 0x0056CE4C File Offset: 0x0056B04C
	public override void Refresh(IQuestReviewNodeParam param)
	{
		this.Data = param.Data;
		base.GetRootItem().SetAlpha(1f);
		this.SpriteLineHorizontal.SetAlpha(0.5f);
		this.SpriteLineVertical.SetAlpha(0.5f);
		base.SetTextureByPath(this.Data.ImageSmall, base.GetTexture(0), null, null);
		base.SetTextureByPath(this.Data.ImageSmall, base.GetTexture(14), null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), this.Data.TitleId, Array.Empty<object>());
		base.GetItem(8).SetUIActive(this.Data.LineType == EQuestReviewNodeLineType.Dotted);
		base.GetItem(9).SetUIActive(this.Data.LineType == EQuestReviewNodeLineType.Solid);
		int num = this.Data.IsBranching ? 320 : 50;
		this.SpriteLineVertical.SetHeight((float)num);
		this.SpriteLineVertical.SetUIActive(this.Data.IsBranching);
		base.GetSprite(4).SetUIActive(!param.IsLastSlotEmpty);
		this.SetSpriteByPath(param.RoundIcon, base.GetSprite(4), false, null, null);
		this.RefreshLineColor(param);
		QuestReviewLineData questReviewLineDataById = ModelBase<QuestReviewModel>.Instance.GetQuestReviewLineDataById(param.LineId);
		this.RedDot.SetUIActive(param.Data.HasRedDot && !questReviewLineDataById.IsDestroy);
	}

	// Token: 0x06013778 RID: 79736 RVA: 0x0056CFD9 File Offset: 0x0056B1D9
	public void SetToggleInteractive(bool interactive)
	{
		base.GetExtendToggle(13).SetSelfInteractive(interactive);
	}

	// Token: 0x17001866 RID: 6246
	// (get) Token: 0x06013779 RID: 79737 RVA: 0x0056CFE9 File Offset: 0x0056B1E9
	private UUISprite SpriteLineVertical
	{
		get
		{
			if (this.Data.LineType == EQuestReviewNodeLineType.Solid)
			{
				return base.GetSprite(2);
			}
			return base.GetSprite(12);
		}
	}

	// Token: 0x17001867 RID: 6247
	// (get) Token: 0x0601377A RID: 79738 RVA: 0x0056D008 File Offset: 0x0056B208
	private UUISprite SpriteLineHorizontal
	{
		get
		{
			if (this.Data.LineType == EQuestReviewNodeLineType.Solid)
			{
				return base.GetSprite(1);
			}
			return base.GetSprite(10);
		}
	}

	// Token: 0x17001868 RID: 6248
	// (get) Token: 0x0601377B RID: 79739 RVA: 0x0056D027 File Offset: 0x0056B227
	private UUISprite SpriteLineRound
	{
		get
		{
			if (this.Data.LineType == EQuestReviewNodeLineType.Solid)
			{
				return base.GetSprite(6);
			}
			return base.GetSprite(11);
		}
	}

	// Token: 0x0601377C RID: 79740 RVA: 0x0056D048 File Offset: 0x0056B248
	private void RefreshLineColor(IQuestReviewNodeParam param)
	{
		this.SpriteLineVertical.SetColor(FColor.FromHex(param.LineColorHex));
		this.SpriteLineHorizontal.SetColor(FColor.FromHex(param.LineColorHex));
		this.SpriteLineRound.SetColor(FColor.FromHex(param.LineColorHex));
	}

	// Token: 0x0601377D RID: 79741 RVA: 0x0056D098 File Offset: 0x0056B298
	private void OnToggleNodeClick(EToggleState toggleState)
	{
		ControllerBase<QuestReviewController>.Instance.OpenQuestNodeDetail(this.Data.Id);
		base.GetExtendToggle(13).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		this.Data.HasRedDot = false;
		this.RedDot.SetUIActive(false);
	}

	// Token: 0x0601377E RID: 79742 RVA: 0x0056D0E4 File Offset: 0x0056B2E4
	private void OnOpenQuestReviewDetail(int nodeId)
	{
		QuestReviewNodeData data = this.Data;
		if (data != null && data.Id == nodeId)
		{
			this.RedDot.SetUIActive(false);
		}
	}

	// Token: 0x040097B2 RID: 38834
	private QuestReviewNodeData Data;

	// Token: 0x040097B3 RID: 38835
	private UUIItem RedDot;

	// Token: 0x02008A34 RID: 35380
	[NullableContext(0)]
	private class ENodeNormalComponentDefine
	{
		// Token: 0x0402E9A1 RID: 190881
		public const int TextureQuest = 0;

		// Token: 0x0402E9A2 RID: 190882
		public const int SpriteLineHorizontalSolid = 1;

		// Token: 0x0402E9A3 RID: 190883
		public const int SpriteLineVerticalSolid = 2;

		// Token: 0x0402E9A4 RID: 190884
		public const int TextDesc = 3;

		// Token: 0x0402E9A5 RID: 190885
		public const int SpriteStartPoint = 4;

		// Token: 0x0402E9A6 RID: 190886
		public const int SpriteEndPoint = 5;

		// Token: 0x0402E9A7 RID: 190887
		public const int SpriteLineRoundSolid = 6;

		// Token: 0x0402E9A8 RID: 190888
		public const int SpriteDescLabel = 7;

		// Token: 0x0402E9A9 RID: 190889
		public const int ItemLineDotted = 8;

		// Token: 0x0402E9AA RID: 190890
		public const int ItemLineSolid = 9;

		// Token: 0x0402E9AB RID: 190891
		public const int SpriteLineHorizontalDotted = 10;

		// Token: 0x0402E9AC RID: 190892
		public const int SpriteLineRoundDotted = 11;

		// Token: 0x0402E9AD RID: 190893
		public const int SpriteLineVerticalDotted = 12;

		// Token: 0x0402E9AE RID: 190894
		public const int ToggleNode = 13;

		// Token: 0x0402E9AF RID: 190895
		public const int TextureSeq = 14;
	}
}
