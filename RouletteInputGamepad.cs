using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x0200293F RID: 10559
[NullableContext(1)]
[Nullable(0)]
public class RouletteInputGamepad : RouletteInputBase
{
	// Token: 0x06014F4B RID: 85835 RVA: 0x005CC9A8 File Offset: 0x005CABA8
	[NullableContext(2)]
	public RouletteInputGamepad(Vector2D pos = null, ERouletteViewType? rouletteViewType = null, int? touchId = null, float? limit = null) : base(pos, rouletteViewType, touchId, limit)
	{
		this.GamepadDeadLimit = (limit ?? this.GamepadDeadLimit);
	}

	// Token: 0x06014F4C RID: 85836 RVA: 0x005CC9F7 File Offset: 0x005CABF7
	public override void OnInit()
	{
		this.GamepadVectorPos.Set(0.0, 0.0, 0.0);
	}

	// Token: 0x06014F4D RID: 85837 RVA: 0x005CCA20 File Offset: 0x005CAC20
	public override void BindEvent()
	{
		if (this.RouletteViewType == ERouletteViewType.Assembly)
		{
			this.BindAxisList = new List<string>
			{
				"UiMoveForward",
				"UiMoveRight"
			};
		}
		else
		{
			this.BindAxisList = new List<string>
			{
				"UiScroll1",
				"UiScroll2"
			};
		}
		ControllerBase<InputDistributeController>.Instance.BindAxes(this.BindAxisList, new TInputHandle<float>(this.OnInputNavigationAxis));
	}

	// Token: 0x06014F4E RID: 85838 RVA: 0x005CCA95 File Offset: 0x005CAC95
	protected override void UnBindEvent()
	{
		if (this.BindAxisList != null)
		{
			ControllerBase<InputDistributeController>.Instance.UnBindAxes(this.BindAxisList, new TInputHandle<float>(this.OnInputNavigationAxis));
		}
	}

	// Token: 0x06014F4F RID: 85839 RVA: 0x005CCABC File Offset: 0x005CACBC
	private void OnInputNavigationAxis(string axisName, float value, InputIdentification inputIdentification)
	{
		if (axisName == "UiMoveForward")
		{
			this.GamepadVectorPos.Y = (double)(-(double)value);
			return;
		}
		if (axisName == "UiScroll1")
		{
			this.GamepadVectorPos.Y = (double)value;
			return;
		}
		if (axisName == "UiMoveRight")
		{
			this.GamepadVectorPos.X = (double)value;
			return;
		}
		if (axisName == "UiScroll2")
		{
			this.GamepadVectorPos.X = (double)value;
		}
	}

	// Token: 0x06014F50 RID: 85840 RVA: 0x005CCB38 File Offset: 0x005CAD38
	protected override void InputTick(float delta)
	{
		if (!this.NeedEmptyChoose && this.GamepadVectorPos.X == 0.0 && this.GamepadVectorPos.Y == 0.0)
		{
			return;
		}
		if (this.NeedEmptyChoose && Math.Abs(this.GamepadVectorPos.X) <= (double)this.GamepadDeadLimit && Math.Abs(this.GamepadVectorPos.Y) <= (double)this.GamepadDeadLimit)
		{
			this.AreaIndex = 0;
			return;
		}
		this.Angle = (int)AngleCalculator.GetVectorAngle(this.ForwardVector, this.GamepadVectorPos);
		this.AreaIndex = AngleCalculator.AngleToAreaIndex((double)this.Angle);
	}

	// Token: 0x0400A18A RID: 41354
	private readonly Vector GamepadVectorPos = Vector.Create();

	// Token: 0x0400A18B RID: 41355
	private float GamepadDeadLimit = 0.4f;

	// Token: 0x0400A18C RID: 41356
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<string> BindAxisList;
}
