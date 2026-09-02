using System;
using UnrealEngine;

// Token: 0x02002A1B RID: 10779
public class SignalItemBase : UiComponentAction
{
	// Token: 0x06015836 RID: 88118 RVA: 0x005F70CD File Offset: 0x005F52CD
	public SignalItemBase(ESignalType type, float rootHalfWidth, int startDecisionSize, int endDecisionSize)
	{
		this.Type = type;
		this.RootHalfWidth = rootHalfWidth;
		this.StartDecisionSize = startDecisionSize;
		this.EndDecisionSize = endDecisionSize;
	}

	// Token: 0x06015837 RID: 88119 RVA: 0x005F7101 File Offset: 0x005F5301
	public void Reset()
	{
		this.CurrentRelativeX = 0f;
		this.OnReset();
	}

	// Token: 0x06015838 RID: 88120 RVA: 0x005F7114 File Offset: 0x005F5314
	public virtual void InitByGameplayType(ESignalGameplayType type)
	{
		this.GameplayType = type;
	}

	// Token: 0x06015839 RID: 88121 RVA: 0x005F711D File Offset: 0x005F531D
	public void Update(float relativeX)
	{
		this.CurrentRelativeX = relativeX;
		this.OnUpdate();
	}

	// Token: 0x0601583A RID: 88122 RVA: 0x005F712D File Offset: 0x005F532D
	public virtual float GetProgress()
	{
		return 0f;
	}

	// Token: 0x0601583B RID: 88123 RVA: 0x005F7134 File Offset: 0x005F5334
	public virtual void OnCatchBtnDown()
	{
		this.IsCatchBtnDown = true;
		this.RelativeXWhenCatchDown = this.CurrentRelativeX;
	}

	// Token: 0x0601583C RID: 88124 RVA: 0x005F7149 File Offset: 0x005F5349
	public virtual void OnCatchBtnUp()
	{
		this.IsCatchBtnDown = false;
		this.RelativeXWhenCatchUp = this.CurrentRelativeX;
	}

	// Token: 0x0601583D RID: 88125 RVA: 0x005F715E File Offset: 0x005F535E
	protected virtual void OnReset()
	{
	}

	// Token: 0x0601583E RID: 88126 RVA: 0x005F7160 File Offset: 0x005F5360
	protected virtual bool OnUpdate()
	{
		if (this.RootHalfWidth == 0f)
		{
			return false;
		}
		float num = this.CurrentRelativeX - this.Width;
		bool flag = this.CurrentRelativeX >= -this.RootHalfWidth && num <= this.RootHalfWidth;
		UUIItem rootItem = this.RootItem;
		if (rootItem != null)
		{
			rootItem.SetUIActive(flag);
		}
		return flag;
	}

	// Token: 0x0601583F RID: 88127 RVA: 0x005F71BC File Offset: 0x005F53BC
	public virtual bool TestCanBtnDown()
	{
		return false;
	}

	// Token: 0x06015840 RID: 88128 RVA: 0x005F71BF File Offset: 0x005F53BF
	public virtual bool TestCanBtnUp()
	{
		return false;
	}

	// Token: 0x0400A5A7 RID: 42407
	public ESignalType Type;

	// Token: 0x0400A5A8 RID: 42408
	protected ESignalGameplayType GameplayType = ESignalGameplayType.Send;

	// Token: 0x0400A5A9 RID: 42409
	public float Width;

	// Token: 0x0400A5AA RID: 42410
	protected int DecisionShowSize = 36;

	// Token: 0x0400A5AB RID: 42411
	protected float CurrentRelativeX;

	// Token: 0x0400A5AC RID: 42412
	protected int StartDecisionSize;

	// Token: 0x0400A5AD RID: 42413
	protected int EndDecisionSize;

	// Token: 0x0400A5AE RID: 42414
	protected bool IsCatchBtnDown;

	// Token: 0x0400A5AF RID: 42415
	protected float RelativeXWhenCatchDown;

	// Token: 0x0400A5B0 RID: 42416
	protected float RelativeXWhenCatchUp;

	// Token: 0x0400A5B1 RID: 42417
	protected float RootHalfWidth;
}
