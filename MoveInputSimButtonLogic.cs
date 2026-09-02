using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Input.Enum;
using CSharpScript.Core.Common;
using CSharpScript.Game.Input;

// Token: 0x0200304E RID: 12366
[NullableContext(1)]
[Nullable(0)]
public class MoveInputSimButtonLogic : IClear
{
	// Token: 0x06019592 RID: 103826 RVA: 0x0074D524 File Offset: 0x0074B724
	public void Init(List<InputEvent> hdInputEvents)
	{
		if (this.Inited)
		{
			return;
		}
		if (hdInputEvents == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.HWR, "[MoveInputSimButtonLogic.Init] 缺少初始化参数", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.RefInputEvents = hdInputEvents;
		this.Inited = true;
		this.CheckAxis = (ConfigCommonParamById.GetFloatConfig("MoveInputSimButtonEvent_CheckAxis") ?? this.CheckAxis);
		this.CheckHold = (ConfigCommonParamById.GetFloatConfig("MoveInputSimButtonEvent_CheckHold") ?? this.CheckHold);
		this.CheckYaw = (ConfigCommonParamById.GetFloatConfig("MoveInputSimButtonEvent_CheckYaw") ?? this.CheckYaw);
		this.CheckYawForKeyboard = (ConfigCommonParamById.GetFloatConfig("MoveInputSimButtonEvent_CheckYawForKeyboard") ?? this.CheckYawForKeyboard);
	}

	// Token: 0x06019593 RID: 103827 RVA: 0x0074D60C File Offset: 0x0074B80C
	public bool IsInited()
	{
		return this.Inited;
	}

	// Token: 0x06019594 RID: 103828 RVA: 0x0074D614 File Offset: 0x0074B814
	public void Reset()
	{
		this.FirstFrame = true;
		this.PressTime = -1.0;
		this.Inside = true;
		this.IsBothZero = false;
	}

	// Token: 0x06019595 RID: 103829 RVA: 0x0074D63A File Offset: 0x0074B83A
	public bool ClearObject()
	{
		this.Inited = false;
		this.RefInputEvents = null;
		return true;
	}

	// Token: 0x06019596 RID: 103830 RVA: 0x0074D64C File Offset: 0x0074B84C
	private void TestEmitInner(float axisValue, float yaw, float time)
	{
		if (!this.Inited)
		{
			return;
		}
		if (this.PressTime == -1.0)
		{
			if (axisValue > this.CheckAxis && this.Inside)
			{
				if (Singleton<Info>.Instance.IsInKeyBoard() && this.FirstFrame)
				{
					this.FirstFrame = false;
					return;
				}
				this.Inside = false;
				this.PressTime = (double)time;
				this.PressYaw = yaw;
				this.LastYaw = yaw;
				this.YawLimit = (Singleton<Info>.Instance.IsInKeyBoard() ? this.CheckYawForKeyboard : this.CheckYaw);
				this.RefInputEvents.Add(new InputEvent(CSharpScript.Game.Input.EInputAction.移动输入按键事件, EInputState.Press, time, yaw));
			}
		}
		else
		{
			this.FirstFrame = true;
			if (Math.Abs(yaw - this.PressYaw) > this.YawLimit || axisValue <= this.CheckAxis)
			{
				this.PressTime = -1.0;
				this.RefInputEvents.Add(new InputEvent(CSharpScript.Game.Input.EInputAction.移动输入按键事件, EInputState.Release, time, this.LastYaw));
			}
			else if ((double)time - this.PressTime > (double)this.CheckHold)
			{
				this.LastYaw = yaw;
				this.RefInputEvents.Add(new InputEvent(CSharpScript.Game.Input.EInputAction.移动输入按键事件, EInputState.Hold, time, yaw));
			}
		}
		if (!this.Inside)
		{
			this.Inside = (axisValue <= this.CheckAxis);
		}
	}

	// Token: 0x06019597 RID: 103831 RVA: 0x0074D7AC File Offset: 0x0074B9AC
	public void TestEmitWithAxis(Dictionary<EInputAxis, float> axisValues)
	{
		float num;
		axisValues.TryGetValue(EInputAxis.MoveForward, out num);
		float num2;
		axisValues.TryGetValue(EInputAxis.MoveRight, out num2);
		if (num == 0f && num2 == 0f)
		{
			if (this.IsBothZero)
			{
				return;
			}
			this.IsBothZero = true;
		}
		else
		{
			this.IsBothZero = false;
		}
		float axisValue = Math.Min((float)Math.Sqrt((double)(num * num + num2 * num2)), 1f);
		double num3 = Math.Atan2((double)num2, (double)num) * 57.295780181884766;
		this.TestEmitInner(axisValue, (float)num3, (float)Singleton<Time>.Instance.WorldTimeSeconds);
	}

	// Token: 0x0400C863 RID: 51299
	private float CheckAxis = 0.8f;

	// Token: 0x0400C864 RID: 51300
	private float CheckHold = 0.1f;

	// Token: 0x0400C865 RID: 51301
	private float CheckYaw = 22.5f;

	// Token: 0x0400C866 RID: 51302
	private float CheckYawForKeyboard = 50f;

	// Token: 0x0400C867 RID: 51303
	private float YawLimit;

	// Token: 0x0400C868 RID: 51304
	private float PressYaw;

	// Token: 0x0400C869 RID: 51305
	private float LastYaw;

	// Token: 0x0400C86A RID: 51306
	private List<InputEvent> RefInputEvents;

	// Token: 0x0400C86B RID: 51307
	private double PressTime = -1.0;

	// Token: 0x0400C86C RID: 51308
	private bool Inside = true;

	// Token: 0x0400C86D RID: 51309
	private bool Inited;

	// Token: 0x0400C86E RID: 51310
	private bool FirstFrame = true;

	// Token: 0x0400C86F RID: 51311
	private bool IsBothZero;
}
