using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game;

// Token: 0x0200293D RID: 10557
[NullableContext(1)]
[Nullable(0)]
public class RouletteInputKeyboard : RouletteInputBase
{
	// Token: 0x06014F44 RID: 85828 RVA: 0x005CC4FC File Offset: 0x005CA6FC
	[NullableContext(2)]
	public RouletteInputKeyboard(Vector2D pos = null, ERouletteViewType? rouletteViewType = null, int? touchId = null, float? limit = null) : base(pos, rouletteViewType, null, null)
	{
	}

	// Token: 0x06014F45 RID: 85829 RVA: 0x005CC550 File Offset: 0x005CA750
	public override void OnInit()
	{
		if (this.BeginPos == null)
		{
			TsCharacterController characterController = Global.CharacterController;
			if (characterController == null)
			{
				return;
			}
			this.BeginPos = (characterController.GetCursorPosition() ?? Vector2D.Create());
		}
		this.BeginVectorPos.Set(this.BeginPos.X, this.BeginPos.Y, 0.0);
		this.TempVectorPos.Set(this.BeginPos.X, this.BeginPos.Y, 0.0);
		this.SubtractVectorPos.Set(0.0, 0.0, 0.0);
	}

	// Token: 0x06014F46 RID: 85830 RVA: 0x005CC600 File Offset: 0x005CA800
	protected override void InputTick(float delta)
	{
		TsCharacterController characterController = Global.CharacterController;
		if (characterController == null)
		{
			return;
		}
		Vector2D cursorPosition = characterController.GetCursorPosition();
		if (cursorPosition == null)
		{
			return;
		}
		this.CheckVectorPos.Set(cursorPosition.X, cursorPosition.Y, 0.0);
		if (this.CheckVectorPos.Equals(this.TempVectorPos, 1.0))
		{
			return;
		}
		this.CheckVectorPos.Subtraction(this.BeginVectorPos, this.SubtractVectorPos);
		if (this.NeedEmptyChoose && this.SubtractVectorPos.Size() <= 100.0)
		{
			this.AreaIndex = 0;
			return;
		}
		this.TempVectorPos.Set(this.CheckVectorPos.X, this.CheckVectorPos.Y, 0.0);
		this.Angle = (int)AngleCalculator.GetVectorAngle(this.ForwardVector, this.SubtractVectorPos);
		this.AreaIndex = AngleCalculator.AngleToAreaIndex((double)this.Angle);
	}

	// Token: 0x0400A180 RID: 41344
	private readonly Vector SubtractVectorPos = Vector.Create();

	// Token: 0x0400A181 RID: 41345
	private readonly Vector BeginVectorPos = Vector.Create();

	// Token: 0x0400A182 RID: 41346
	private readonly Vector TempVectorPos = Vector.Create();

	// Token: 0x0400A183 RID: 41347
	private readonly Vector CheckVectorPos = Vector.Create();
}
