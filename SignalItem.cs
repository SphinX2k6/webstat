using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02002A1A RID: 10778
[NullableContext(1)]
[Nullable(0)]
public class SignalItem : SignalItemBase
{
	// Token: 0x06015820 RID: 88096 RVA: 0x005F68A0 File Offset: 0x005F4AA0
	public SignalItem(ESignalType type, float rootHalfWidth, int startDecisionSize, int endDecisionSize) : base(type, rootHalfWidth, startDecisionSize, endDecisionSize)
	{
	}

	// Token: 0x06015821 RID: 88097 RVA: 0x005F68B0 File Offset: 0x005F4AB0
	public void Init(UUIItem uiItem, float offsetX)
	{
		base.SetRootActor(uiItem.GetOwner(), true);
		this.Width = this.RootItem.GetWidth();
		this.RootItem.SetAnchorOffsetX(offsetX);
		this.BgOverSpriteYellowColor = new FColor?(FColor.FromHex("E8CD74"));
		this.BgOverSpriteRedColor = new FColor?(FColor.FromHex("FF6A6A"));
		this.BgOverSpriteGreenColor = new FColor?(FColor.FromHex("9DED87"));
		this.BgOverSpriteOrangeColor = new FColor?(FColor.FromHex("FF6827"));
	}

	// Token: 0x06015822 RID: 88098 RVA: 0x005F693C File Offset: 0x005F4B3C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUINiagara)),
			new ValueTuple<int, Type>(2, typeof(UUINiagara)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUISprite))
		};
	}

	// Token: 0x06015823 RID: 88099 RVA: 0x005F69C4 File Offset: 0x005F4BC4
	protected override void OnStart()
	{
		this.BgSprite = base.GetSprite(0);
		this.BgOverSprite = base.GetSprite(4);
		this.GraySignal = base.GetUiNiagara(1);
		this.HighlightSignal = base.GetUiNiagara(2);
		this.Line = base.GetSprite(3);
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x06015824 RID: 88100 RVA: 0x005F6A24 File Offset: 0x005F4C24
	protected override void OnReset()
	{
		this.BgSprite.SetFillAmount(1f);
		this.BgSprite.SetAlpha(1f);
		this.BgSprite.SetUIActive(true);
		this.BgOverSprite.SetFillAmount(0f);
		ESignalGameplayType currentGameplayType = ModelBase<SignalDecodeModel>.Instance.CurrentGameplayType;
		FColor? fcolor = (currentGameplayType == ESignalGameplayType.Send) ? this.BgOverSpriteGreenColor : this.BgOverSpriteYellowColor;
		if (currentGameplayType == ESignalGameplayType.DrawSword)
		{
			fcolor = this.BgOverSpriteOrangeColor;
			this.BgSprite.SetColor(fcolor.Value);
		}
		this.BgOverSprite.SetColor(fcolor.Value);
		this.BgSprite.SetAlpha(1f);
		this.BgOverSprite.SetUIActive(false);
		UUINiagara graySignal = this.GraySignal;
		if (graySignal != null)
		{
			graySignal.SetUIActive(currentGameplayType == ESignalGameplayType.Catch);
		}
		this.GraySignal.SetUIItemScale(Vector.OneVector);
		this.GraySignal.SetAlpha(1f);
		this.HighlightSignal.SetNiagaraVarFloat("Dissolve", 1f);
		this.HighlightSignal.SetUIActive(true);
		this.HighlightSignal.SetUIItemScale(Vector.OneVector);
		this.HighlightSignal.SetAlpha(1f);
		this.ResetHighlightSignalColor();
		this.Line.SetAlpha(0f);
		this.State = ESignalState.NotReach;
	}

	// Token: 0x06015825 RID: 88101 RVA: 0x005F6B6C File Offset: 0x005F4D6C
	public override void InitByGameplayType(ESignalGameplayType type)
	{
		base.InitByGameplayType(type);
		string resourceId = (type == ESignalGameplayType.Send) ? "SP_SignalNoteSolidLineGreen" : "SP_SignalNoteSolidLineYellow";
		if (type == ESignalGameplayType.DrawSword)
		{
			resourceId = "SP_SignalNoteSolidLineOrange";
		}
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		this.SetSpriteByPath(resourcePath, this.Line, false, null, null);
		base.Reset();
	}

	// Token: 0x06015826 RID: 88102 RVA: 0x005F6BC8 File Offset: 0x005F4DC8
	private void ResetHighlightSignalColor()
	{
		string hexStr = (this.GameplayType == ESignalGameplayType.Send) ? "E0FCDEFF" : "FFFBE8FF";
		if (this.GameplayType == ESignalGameplayType.DrawSword)
		{
			hexStr = "FFBCA4FF";
		}
		this.HighlightSignal.SetColor(FColor.FromHex(hexStr));
	}

	// Token: 0x06015827 RID: 88103 RVA: 0x005F6C0D File Offset: 0x005F4E0D
	protected override bool OnUpdate()
	{
		if (!base.OnUpdate())
		{
			return false;
		}
		this.UpdateState();
		if (this.State == ESignalState.Catching)
		{
			this.UpdateOnCatching();
		}
		return true;
	}

	// Token: 0x06015828 RID: 88104 RVA: 0x005F6C30 File Offset: 0x005F4E30
	protected void UpdateState()
	{
		float num = (float)(-(float)this.StartDecisionSize) / 2f;
		if (this.CurrentRelativeX < num)
		{
			this.SetState(ESignalState.NotReach);
			return;
		}
		float num2 = (float)this.EndDecisionSize / 2f;
		if (this.CurrentRelativeX - this.Width > num2 && this.State != ESignalState.CatchSuccess)
		{
			this.SetState(ESignalState.CatchFailed);
			return;
		}
		float num3 = (float)this.StartDecisionSize / 2f;
		if (this.CurrentRelativeX > num3 && this.State == ESignalState.NotReach)
		{
			this.SetState(ESignalState.CatchFailed);
		}
	}

	// Token: 0x06015829 RID: 88105 RVA: 0x005F6CB4 File Offset: 0x005F4EB4
	private void SetState(ESignalState value)
	{
		if (this.State == value)
		{
			return;
		}
		this.State = value;
		switch (value)
		{
		case ESignalState.Catching:
			Singleton<EventSystem>.Instance.Emit(EEventName.OnSignalCatchStart);
			return;
		case ESignalState.CatchSuccess:
			this.OnSignalCatchSuccess();
			Singleton<EventSystem>.Instance.Emit(EEventName.OnSignalCatchSuccess);
			return;
		case ESignalState.CatchFailed:
			this.OnSignalCatchFailed();
			Singleton<EventSystem>.Instance.Emit(EEventName.OnSignalCatchFailed);
			return;
		default:
			return;
		}
	}

	// Token: 0x0601582A RID: 88106 RVA: 0x005F6D28 File Offset: 0x005F4F28
	private void UpdateOnCatching()
	{
		float progress = this.GetProgress();
		this.HighlightSignal.SetNiagaraVarFloat("Dissolve", 1f - progress);
		this.BgOverSprite.SetUIActive(true);
		this.BgSprite.SetFillAmount(1f - progress);
		this.BgOverSprite.SetFillAmount(progress);
	}

	// Token: 0x0601582B RID: 88107 RVA: 0x005F6D80 File Offset: 0x005F4F80
	private void OnSignalCatchFailed()
	{
		ESignalType type = this.Type;
		if (type == ESignalType.Short)
		{
			this.SkipFailedAnim();
			return;
		}
		if (type != ESignalType.Long)
		{
			return;
		}
		if (this.BgOverSprite.bIsUIActive)
		{
			this.BgOverSprite.SetColor(this.BgOverSpriteRedColor.Value);
			this.HighlightSignal.SetColor(FColor.FromHex("FFD6D6FF"));
			this.LevelSequencePlayer.PlayLevelSequenceByName("Trans", false, null, false);
			return;
		}
		if (ModelBase<SignalDecodeModel>.Instance.CurrentGameplayType == ESignalGameplayType.Send)
		{
			this.SkipFailedAnim();
			return;
		}
		this.LevelSequencePlayer.PlayLevelSequenceByName("Trans", false, null, false);
	}

	// Token: 0x0601582C RID: 88108 RVA: 0x005F6E28 File Offset: 0x005F5028
	private void OnSignalCatchSuccess()
	{
		this.HighlightSignal.SetNiagaraVarFloat("Dissolve", 0f);
		this.HighlightSignal.SetUIActive(true);
		this.GraySignal.SetUIActive(false);
		this.BgSprite.SetUIActive(false);
		this.BgOverSprite.SetUIActive(false);
		this.Line.SetAlpha(0f);
	}

	// Token: 0x0601582D RID: 88109 RVA: 0x005F6E8A File Offset: 0x005F508A
	public override void OnCatchBtnDown()
	{
		base.OnCatchBtnDown();
		if (this.State != ESignalState.NotReach)
		{
			return;
		}
		if (this.CheckMeetCatch())
		{
			this.SetState(ESignalState.Catching);
		}
	}

	// Token: 0x0601582E RID: 88110 RVA: 0x005F6EAC File Offset: 0x005F50AC
	public override void OnCatchBtnUp()
	{
		base.OnCatchBtnUp();
		if (this.State == ESignalState.Catching)
		{
			this.SetState(this.CheckMeetSuccess() ? ESignalState.CatchSuccess : ESignalState.CatchFailed);
		}
	}

	// Token: 0x0601582F RID: 88111 RVA: 0x005F6EDC File Offset: 0x005F50DC
	private bool CheckMeetCatch()
	{
		float num = (float)(-(float)this.StartDecisionSize) / 2f;
		float num2 = (float)this.StartDecisionSize / 2f;
		return this.RelativeXWhenCatchDown > num && this.RelativeXWhenCatchDown < num2;
	}

	// Token: 0x06015830 RID: 88112 RVA: 0x005F6F1C File Offset: 0x005F511C
	private bool CheckMeetSuccess()
	{
		float num = (float)this.EndDecisionSize / 2f;
		float num2 = (float)(-(float)this.EndDecisionSize) / 2f;
		float num3 = this.RelativeXWhenCatchUp - this.Width;
		return num3 > num2 && num3 < num;
	}

	// Token: 0x06015831 RID: 88113 RVA: 0x005F6F60 File Offset: 0x005F5160
	public override float GetProgress()
	{
		float num = (float)(-(float)this.DecisionShowSize) / 2f;
		return MathCommon.Clamp((this.CurrentRelativeX - num) / this.Width, 0f, 1f);
	}

	// Token: 0x06015832 RID: 88114 RVA: 0x005F6F9C File Offset: 0x005F519C
	public float GetCompleteness()
	{
		float result = 0f;
		switch (this.State)
		{
		case ESignalState.NotReach:
		case ESignalState.CatchFailed:
			result = 0f;
			break;
		case ESignalState.Catching:
			result = this.GetProgress();
			break;
		case ESignalState.CatchSuccess:
			result = 1f;
			break;
		}
		return result;
	}

	// Token: 0x06015833 RID: 88115 RVA: 0x005F6FE8 File Offset: 0x005F51E8
	private void SkipFailedAnim()
	{
		this.BgOverSprite.SetUIActive(false);
		this.HighlightSignal.SetUIActive(false);
		this.GraySignal.SetUIActive(false);
		this.BgSprite.SetUIActive(false);
		this.Line.SetAlpha(1f);
	}

	// Token: 0x06015834 RID: 88116 RVA: 0x005F7038 File Offset: 0x005F5238
	public override bool TestCanBtnDown()
	{
		if (this.State != ESignalState.NotReach)
		{
			return false;
		}
		float num = (float)(-(float)this.StartDecisionSize) / 2f;
		float num2 = (float)this.StartDecisionSize / 2f;
		return this.CurrentRelativeX > num && this.CurrentRelativeX < num2;
	}

	// Token: 0x06015835 RID: 88117 RVA: 0x005F7080 File Offset: 0x005F5280
	public override bool TestCanBtnUp()
	{
		if (this.State == ESignalState.Catching)
		{
			float num = (float)this.EndDecisionSize / 2f;
			float num2 = (float)(-(float)this.EndDecisionSize) / 2f;
			float num3 = this.CurrentRelativeX - this.Width;
			return num3 > num2 && num3 < num;
		}
		return false;
	}

	// Token: 0x0400A597 RID: 42391
	private const string NIAGARA_PARAM_NAME = "Dissolve";

	// Token: 0x0400A598 RID: 42392
	private const string NIAGARA_YELLOW_COLOR = "FFFBE8FF";

	// Token: 0x0400A599 RID: 42393
	private const string NIAGARA_RED_COLOR = "FFD6D6FF";

	// Token: 0x0400A59A RID: 42394
	private const string NIAGARA_GREEN_COLOR = "E0FCDEFF";

	// Token: 0x0400A59B RID: 42395
	private const string NIAGARA_ORANGE_COLOR = "FFBCA4FF";

	// Token: 0x0400A59C RID: 42396
	[Nullable(2)]
	private UUISprite BgSprite;

	// Token: 0x0400A59D RID: 42397
	[Nullable(2)]
	private UUISprite BgOverSprite;

	// Token: 0x0400A59E RID: 42398
	[Nullable(2)]
	private UUINiagara GraySignal;

	// Token: 0x0400A59F RID: 42399
	[Nullable(2)]
	private UUINiagara HighlightSignal;

	// Token: 0x0400A5A0 RID: 42400
	[Nullable(2)]
	private UUISprite Line;

	// Token: 0x0400A5A1 RID: 42401
	private FColor? BgOverSpriteYellowColor;

	// Token: 0x0400A5A2 RID: 42402
	private FColor? BgOverSpriteGreenColor;

	// Token: 0x0400A5A3 RID: 42403
	private FColor? BgOverSpriteRedColor;

	// Token: 0x0400A5A4 RID: 42404
	private FColor? BgOverSpriteOrangeColor;

	// Token: 0x0400A5A5 RID: 42405
	[Nullable(2)]
	protected LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400A5A6 RID: 42406
	private ESignalState State;

	// Token: 0x02008D9E RID: 36254
	[NullableContext(0)]
	private static class EChildComponent
	{
		// Token: 0x0402F9EB RID: 195051
		public const int BgSprite = 0;

		// Token: 0x0402F9EC RID: 195052
		public const int GraySignal = 1;

		// Token: 0x0402F9ED RID: 195053
		public const int HighlightSignal = 2;

		// Token: 0x0402F9EE RID: 195054
		public const int Line = 3;

		// Token: 0x0402F9EF RID: 195055
		public const int BgOverSprite = 4;
	}
}
