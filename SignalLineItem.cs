using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002A1C RID: 10780
public class SignalLineItem : SignalItemBase
{
	// Token: 0x06015841 RID: 88129 RVA: 0x005F71C2 File Offset: 0x005F53C2
	public SignalLineItem(ESignalType type, float rootHalfWidth, int startDecisionSize, int endDecisionSize) : base(type, rootHalfWidth, startDecisionSize, endDecisionSize)
	{
	}

	// Token: 0x06015842 RID: 88130 RVA: 0x005F71CF File Offset: 0x005F53CF
	[NullableContext(1)]
	public void Init(UUIItem uiItem, float offsetX)
	{
		base.SetRootActor(uiItem.GetOwner(), true);
		this.Width = this.RootItem.GetWidth();
		this.RootItem.SetAnchorOffsetX(offsetX);
	}

	// Token: 0x06015843 RID: 88131 RVA: 0x005F71FB File Offset: 0x005F53FB
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUISprite))
		};
	}

	// Token: 0x06015844 RID: 88132 RVA: 0x005F7234 File Offset: 0x005F5434
	protected override void OnStart()
	{
		this.GrayLine = base.GetSprite(0);
		this.HighlightLine = base.GetSprite(1);
	}

	// Token: 0x06015845 RID: 88133 RVA: 0x005F7250 File Offset: 0x005F5450
	public void AddWidth(float width)
	{
		this.Width += width;
		this.RootItem.SetWidth(this.Width);
	}

	// Token: 0x06015846 RID: 88134 RVA: 0x005F7271 File Offset: 0x005F5471
	protected override void OnReset()
	{
		this.GrayLine.SetUIActive(true);
		this.HighlightLine.SetFillAmount(0f);
		this.HighlightLine.SetUIActive(true);
	}

	// Token: 0x06015847 RID: 88135 RVA: 0x005F729C File Offset: 0x005F549C
	public override void InitByGameplayType(ESignalGameplayType type)
	{
		base.InitByGameplayType(type);
		string resourceId = (type == ESignalGameplayType.Send) ? "SP_SignalNoteSolidLineGreen" : "SP_SignalNoteSolidLineYellow";
		if (type == ESignalGameplayType.DrawSword)
		{
			resourceId = "SP_SignalNoteSolidLineOrange";
		}
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		this.SetSpriteByPath(resourcePath, this.HighlightLine, false, null, null);
		base.Reset();
	}

	// Token: 0x06015848 RID: 88136 RVA: 0x005F72F8 File Offset: 0x005F54F8
	protected override bool OnUpdate()
	{
		if (!base.OnUpdate())
		{
			return false;
		}
		float num = (float)(-(float)this.DecisionShowSize) / 2f;
		float fillAmount = this.HighlightLine.GetFillAmount();
		if (this.CurrentRelativeX < num)
		{
			if (fillAmount != 0f)
			{
				this.HighlightLine.SetFillAmount(0f);
			}
			return true;
		}
		float progress = this.GetProgress();
		if (fillAmount != progress)
		{
			this.HighlightLine.SetFillAmount(progress);
		}
		return true;
	}

	// Token: 0x06015849 RID: 88137 RVA: 0x005F7368 File Offset: 0x005F5568
	public override float GetProgress()
	{
		float num = (float)(-(float)this.DecisionShowSize) / 2f;
		return MathCommon.Clamp((this.CurrentRelativeX - num) / this.RootItem.GetWidth(), 0f, 1f);
	}

	// Token: 0x0400A5B2 RID: 42418
	[Nullable(2)]
	private UUISprite GrayLine;

	// Token: 0x0400A5B3 RID: 42419
	[Nullable(2)]
	private UUISprite HighlightLine;

	// Token: 0x02008D9F RID: 36255
	private static class EChildComponent
	{
		// Token: 0x0402F9F0 RID: 195056
		public const int GrayLine = 0;

		// Token: 0x0402F9F1 RID: 195057
		public const int HighlightLine = 1;
	}
}
