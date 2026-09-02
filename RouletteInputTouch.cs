using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game;

// Token: 0x0200293E RID: 10558
[NullableContext(1)]
[Nullable(0)]
public class RouletteInputTouch : RouletteInputBase
{
	// Token: 0x06014F47 RID: 85831 RVA: 0x005CC6F4 File Offset: 0x005CA8F4
	[NullableContext(2)]
	public RouletteInputTouch(Vector2D pos = null, ERouletteViewType? rouletteViewType = null, int? touchId = null, float? limit = null) : base(pos, rouletteViewType, touchId, null)
	{
		this.TouchId = touchId.GetValueOrDefault(-1);
	}

	// Token: 0x06014F48 RID: 85832 RVA: 0x005CC754 File Offset: 0x005CA954
	public unsafe override void OnInit()
	{
		if (this.BeginPos == null)
		{
			TsCharacterController characterController = Global.CharacterController;
			if (characterController == null)
			{
				return;
			}
			if (this.TouchId < 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.Phantom, ELogAuthor.YYZ, "当前轮盘输入方式为触屏,未检测到对应触屏Id或初始位置", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.BeginPos = (characterController.GetTouchPosition(this.TouchId) ?? Vector2D.Create());
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Phantom;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "[轮盘界面]触屏开启信息";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TouchId", this.TouchId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Pos", this.BeginPos);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		this.BeginVectorPos.Set(this.BeginPos.X, this.BeginPos.Y, 0.0);
		this.TempVectorPos.Set(this.BeginPos.X, this.BeginPos.Y, 0.0);
		this.SubtractVectorPos.Set(0.0, 0.0, 0.0);
	}

	// Token: 0x06014F49 RID: 85833 RVA: 0x005CC893 File Offset: 0x005CAA93
	protected override void OnDestroy()
	{
		this.IsInTouch = false;
	}

	// Token: 0x06014F4A RID: 85834 RVA: 0x005CC89C File Offset: 0x005CAA9C
	protected override void InputTick(float delta)
	{
		if (this.RouletteViewType == ERouletteViewType.Assembly)
		{
			return;
		}
		TsCharacterController characterController = Global.CharacterController;
		if (characterController == null)
		{
			return;
		}
		if (this.TouchId < 0)
		{
			base.EndInput();
			return;
		}
		this.IsInTouch = characterController.IsInTouch((float)this.TouchId);
		if (!this.IsInTouch)
		{
			base.EndInput();
			return;
		}
		Vector2D touchPosition = characterController.GetTouchPosition(this.TouchId);
		if (touchPosition == null)
		{
			return;
		}
		this.CheckVectorPos.Set(touchPosition.X, touchPosition.Y, 0.0);
		if (this.CheckVectorPos.Equals(this.TempVectorPos, 9.999999747378752E-05))
		{
			return;
		}
		this.TempVectorPos.Set(this.CheckVectorPos.X, this.CheckVectorPos.Y, 0.0);
		this.CheckVectorPos.Subtraction(this.BeginVectorPos, this.SubtractVectorPos);
		this.Angle = (int)AngleCalculator.GetVectorAngle(this.ForwardVector, this.SubtractVectorPos);
		this.AreaIndex = AngleCalculator.AngleToAreaIndex((double)this.Angle);
	}

	// Token: 0x0400A184 RID: 41348
	private readonly Vector SubtractVectorPos = Vector.Create();

	// Token: 0x0400A185 RID: 41349
	private readonly Vector BeginVectorPos = Vector.Create();

	// Token: 0x0400A186 RID: 41350
	private readonly Vector TempVectorPos = Vector.Create();

	// Token: 0x0400A187 RID: 41351
	private readonly Vector CheckVectorPos = Vector.Create();

	// Token: 0x0400A188 RID: 41352
	private readonly int TouchId = -1;

	// Token: 0x0400A189 RID: 41353
	private bool IsInTouch;
}
