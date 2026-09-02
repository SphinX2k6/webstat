using System;
using Aki.Config;
using CSharpScript.Core.Model;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02000D11 RID: 3345
public class AsyncAiSenseObject
{
	// Token: 0x17000320 RID: 800
	// (get) Token: 0x0600432D RID: 17197 RVA: 0x0007D14B File Offset: 0x0007B34B
	public static int Size
	{
		get
		{
			return sizeof(FAiSenseObject);
		}
	}

	// Token: 0x17000321 RID: 801
	// (get) Token: 0x0600432E RID: 17198 RVA: 0x0007D153 File Offset: 0x0007B353
	public static int MinAlignment
	{
		get
		{
			return 4;
		}
	}

	// Token: 0x0600432F RID: 17199 RVA: 0x0007D158 File Offset: 0x0007B358
	public unsafe AsyncAiSenseObject(AiSense AiSense)
	{
		this.AiSenseObjectData = (FAiSenseObject*)BuiltinUtils.Malloc((UIntPtr)((IntPtr)AsyncAiSenseObject.Size), (uint)AsyncAiSenseObject.MinAlignment);
		this.AiSense = AiSense;
		this.AiSenseObjectData->AiSenseId = AiSense.Id;
		this.AiSenseObjectData->AiSenseHorizontalAngle = new FVector2D(AiSense.HorizontalAngle.Value.Min, AiSense.HorizontalAngle.Value.Max);
		this.AiSenseObjectData->AiSenseVerticalAngle = new FVector2D(AiSense.VerticalAngle.Value.Min, AiSense.VerticalAngle.Value.Max);
		this.AiSenseObjectData->AiSenseCantBeBlock = AiSense.CantBeBlock;
		this.AiSenseObjectData->AiSenseBlockType = AiSense.BlockType;
		this.AiSenseObjectData->WithAngleHorizontal = (AiSense.HorizontalAngle.Value.Min > -180f || AiSense.HorizontalAngle.Value.Max < 180f);
		this.AiSenseObjectData->WithAngleVertical = (AiSense.VerticalAngle.Value.Min > -90f || AiSense.VerticalAngle.Value.Max < 90f);
		this.AiSenseObjectData->SenseDistanceRangeMin = AiSense.SenseDistanceRange.Value.Min;
		this.AiSenseObjectData->SenseDistanceRangeMax = AiSense.SenseDistanceRange.Value.Max;
		this.AiSenseObjectData->SquaredWalkSenseRate = AiSense.WalkSenseRate * AiSense.WalkSenseRate;
		this.AiSenseObjectData->SquaredAirSenseRate = AiSense.AirSenseRate * AiSense.AirSenseRate;
	}

	// Token: 0x06004330 RID: 17200 RVA: 0x0007D348 File Offset: 0x0007B548
	unsafe ~AsyncAiSenseObject()
	{
		if (this.AiSenseObjectData != null)
		{
			BuiltinUtils.Free((void*)this.AiSenseObjectData);
			this.AiSenseObjectData = null;
		}
	}

	// Token: 0x06004331 RID: 17201 RVA: 0x0007D38C File Offset: 0x0007B58C
	public unsafe void Clear()
	{
		if (this.AiPerceptionDataHandle != 0)
		{
			FKuroJsModelCSharpInterface.RemoveActivateAiSenseObjects(this.AiPerceptionDataHandle, (byte)this.AiSense.SenseTarget, (void*)this.AiSenseObjectData);
			this.AiPerceptionDataHandle = 0;
		}
	}

	// Token: 0x0400117E RID: 4478
	public unsafe FAiSenseObject* AiSenseObjectData;

	// Token: 0x0400117F RID: 4479
	public int AiPerceptionDataHandle;

	// Token: 0x04001180 RID: 4480
	private const float MINUS_HALF = -180f;

	// Token: 0x04001181 RID: 4481
	private const float MINUS_QUATER = -90f;

	// Token: 0x04001182 RID: 4482
	public readonly AiSense AiSense;
}
