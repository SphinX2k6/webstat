using System;

// Token: 0x02001FA6 RID: 8102
public class AiMiSiHudUnitRotateMachine
{
	// Token: 0x0600F3A7 RID: 62375 RVA: 0x0042A728 File Offset: 0x00428928
	public bool Update(float delta, double yaw)
	{
		if (!this.IsInit)
		{
			this.LastYaw = yaw;
			this.IsInit = true;
			return false;
		}
		double num = yaw - this.LastYaw;
		if (num < -180.0)
		{
			num += 360.0;
		}
		else if (num > 180.0)
		{
			num -= 360.0;
		}
		this.LastYaw = yaw;
		double num2 = num / (double)delta;
		if (num2 > this.YawSpeedMin)
		{
			this.SetTargetDir(1);
		}
		else if (num2 < -this.YawSpeedMin)
		{
			this.SetTargetDir(-1);
		}
		else
		{
			this.SetTargetDir(0);
		}
		double curValue = this.CurValue;
		this.UpdateAnim(delta);
		return curValue != this.CurValue;
	}

	// Token: 0x0600F3A8 RID: 62376 RVA: 0x0042A7D8 File Offset: 0x004289D8
	private void SetTargetDir(int dir)
	{
		this.TargetDir = dir;
	}

	// Token: 0x0600F3A9 RID: 62377 RVA: 0x0042A7E4 File Offset: 0x004289E4
	private void UpdateAnim(float delta)
	{
		if (this.NextChangeDirCountdown > 0f)
		{
			this.NextChangeDirCountdown -= delta;
			if (this.NextChangeDirCountdown <= 0f)
			{
				this.NextChangeDirCountdown = 0f;
			}
		}
		else if (this.TargetDir != this.CurDir)
		{
			this.CurDir = this.TargetDir;
			this.NextChangeDirCountdown = (float)this.Countdown;
		}
		if (this.CurValue == (double)this.CurDir)
		{
			return;
		}
		if (this.CurValue < (double)this.CurDir)
		{
			this.CurValue += this.Speed * (double)delta;
			if (this.CurValue > (double)this.CurDir)
			{
				this.CurValue = (double)this.CurDir;
				return;
			}
		}
		else
		{
			this.CurValue -= this.Speed * (double)delta;
			if (this.CurValue < (double)this.CurDir)
			{
				this.CurValue = (double)this.CurDir;
			}
		}
	}

	// Token: 0x04007532 RID: 30002
	public double YawSpeedMin = 0.02;

	// Token: 0x04007533 RID: 30003
	public double Speed = 0.002;

	// Token: 0x04007534 RID: 30004
	public int Countdown = 500;

	// Token: 0x04007535 RID: 30005
	private double LastYaw;

	// Token: 0x04007536 RID: 30006
	private bool IsInit;

	// Token: 0x04007537 RID: 30007
	private int TargetDir;

	// Token: 0x04007538 RID: 30008
	private int CurDir;

	// Token: 0x04007539 RID: 30009
	private float NextChangeDirCountdown;

	// Token: 0x0400753A RID: 30010
	public double CurValue;
}
