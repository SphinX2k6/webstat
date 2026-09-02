using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020024DC RID: 9436
[NullableContext(1)]
[Nullable(0)]
public class LongPressContext
{
	// Token: 0x17001759 RID: 5977
	// (get) Token: 0x06012509 RID: 75017 RVA: 0x00508940 File Offset: 0x00506B40
	// (set) Token: 0x0601250A RID: 75018 RVA: 0x00508948 File Offset: 0x00506B48
	public ILongPressParam Param { get; set; }

	// Token: 0x0601250B RID: 75019 RVA: 0x00508951 File Offset: 0x00506B51
	public LongPressContext(ILongPressParam param)
	{
		this.Param = param;
	}

	// Token: 0x0601250C RID: 75020 RVA: 0x00508960 File Offset: 0x00506B60
	public void Reset()
	{
		this.PressedTime = 0f;
		this.TriggeredLongPress = false;
		this.TriggeredStartLongPress = false;
	}

	// Token: 0x0601250D RID: 75021 RVA: 0x0050897C File Offset: 0x00506B7C
	public void Start()
	{
		FVector worldPointInPlane = Singleton<LguiEventSystemManager>.Instance.GetPointerEventData(0, false).GetWorldPointInPlane();
		this.OnPressPositionX = worldPointInPlane.X;
		this.OnPressPositionY = worldPointInPlane.Z;
	}

	// Token: 0x0601250E RID: 75022 RVA: 0x005089B4 File Offset: 0x00506BB4
	public bool CheckIsMoved()
	{
		FVector worldPointInPlane = Singleton<LguiEventSystemManager>.Instance.GetPointerEventData(0, false).GetWorldPointInPlane();
		float value = this.OnPressPositionX - worldPointInPlane.X;
		float value2 = this.OnPressPositionY - worldPointInPlane.Z;
		return Math.Abs(value) + Math.Abs(value2) > this.Param.InvalidMoveDistance;
	}

	// Token: 0x0601250F RID: 75023 RVA: 0x00508A0C File Offset: 0x00506C0C
	[NullableContext(0)]
	public ValueTuple<bool, bool> Update(float deltaTime)
	{
		this.PressedTime += deltaTime;
		bool item = false;
		bool item2 = false;
		if (!this.TriggeredStartLongPress && this.PressedTime >= this.Param.BeforeLongPressThreshold)
		{
			this.TriggeredStartLongPress = true;
			item = true;
		}
		if (!this.TriggeredLongPress && this.LongPressProgress >= 1f)
		{
			this.TriggeredLongPress = true;
			item2 = true;
		}
		return new ValueTuple<bool, bool>(item, item2);
	}

	// Token: 0x06012510 RID: 75024 RVA: 0x00508A74 File Offset: 0x00506C74
	public bool IsBeforeLongPressThreshold()
	{
		return this.PressedTime < this.Param.BeforeLongPressThreshold;
	}

	// Token: 0x06012511 RID: 75025 RVA: 0x00508A89 File Offset: 0x00506C89
	public bool IsLongPressing()
	{
		return this.PressedTime >= this.Param.BeforeLongPressThreshold;
	}

	// Token: 0x1700175A RID: 5978
	// (get) Token: 0x06012512 RID: 75026 RVA: 0x00508AA4 File Offset: 0x00506CA4
	public float LongPressProgress
	{
		get
		{
			float num = this.PressedTime - this.Param.BeforeLongPressThreshold;
			float num2 = Math.Max(this.Param.LongPressThreshold, 0.01f);
			return Math.Max(Math.Min(num / num2, 1f), 0f);
		}
	}

	// Token: 0x04008ED9 RID: 36569
	private float PressedTime;

	// Token: 0x04008EDA RID: 36570
	private bool TriggeredStartLongPress;

	// Token: 0x04008EDB RID: 36571
	private bool TriggeredLongPress;

	// Token: 0x04008EDC RID: 36572
	private float OnPressPositionX;

	// Token: 0x04008EDD RID: 36573
	private float OnPressPositionY;
}
