using System;
using System.Runtime.CompilerServices;

// Token: 0x02002EA5 RID: 11941
[NullableContext(2)]
[Nullable(0)]
public abstract class CustomActionBase
{
	// Token: 0x06018829 RID: 100393 RVA: 0x006DF937 File Offset: 0x006DDB37
	public bool CheckStart()
	{
		return this.IsStart;
	}

	// Token: 0x0601882A RID: 100394 RVA: 0x006DF93F File Offset: 0x006DDB3F
	public bool CheckFinish(float delta)
	{
		this.OnCheckFinish(delta);
		return this.IsFinish;
	}

	// Token: 0x0601882B RID: 100395 RVA: 0x006DF94E File Offset: 0x006DDB4E
	public bool CheckSuccessful()
	{
		return this.IsSuccessful;
	}

	// Token: 0x0601882C RID: 100396 RVA: 0x006DF956 File Offset: 0x006DDB56
	public void RunAction()
	{
		if (this.IsStart)
		{
			return;
		}
		this.IsStart = true;
		Action onStart = this.OnStart;
		if (onStart != null)
		{
			onStart();
		}
		this.OnRunAction();
	}

	// Token: 0x0601882D RID: 100397 RVA: 0x006DF97F File Offset: 0x006DDB7F
	public void Abort(bool success)
	{
		this.OnAbort();
		this.Finish(success);
	}

	// Token: 0x0601882E RID: 100398
	protected abstract void OnRunAction();

	// Token: 0x0601882F RID: 100399 RVA: 0x006DF98E File Offset: 0x006DDB8E
	protected virtual void OnFinish(bool success)
	{
	}

	// Token: 0x06018830 RID: 100400 RVA: 0x006DF990 File Offset: 0x006DDB90
	protected virtual void OnCheckFinish(float delta)
	{
	}

	// Token: 0x06018831 RID: 100401 RVA: 0x006DF992 File Offset: 0x006DDB92
	protected virtual void OnAbort()
	{
	}

	// Token: 0x06018832 RID: 100402 RVA: 0x006DF994 File Offset: 0x006DDB94
	protected void Finish(bool success)
	{
		if (this.IsFinish)
		{
			return;
		}
		this.IsSuccessful = success;
		this.IsFinish = true;
		Action callback = this.Callback;
		if (callback != null)
		{
			callback();
		}
		this.OnFinish(success);
	}

	// Token: 0x0400BD1F RID: 48415
	protected const int MODEL_BUFFER_TIME = 200;

	// Token: 0x0400BD20 RID: 48416
	protected const float MAX_ROTATION_TIME = 1000f;

	// Token: 0x0400BD21 RID: 48417
	protected const float ROTATION_ANGLE_TOLERANCE = 10f;

	// Token: 0x0400BD22 RID: 48418
	protected bool IsStart;

	// Token: 0x0400BD23 RID: 48419
	protected bool IsFinish;

	// Token: 0x0400BD24 RID: 48420
	protected bool IsSuccessful;

	// Token: 0x0400BD25 RID: 48421
	protected Action OnStart;

	// Token: 0x0400BD26 RID: 48422
	protected Action Callback;
}
