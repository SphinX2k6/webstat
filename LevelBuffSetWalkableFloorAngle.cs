using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002F90 RID: 12176
public class LevelBuffSetWalkableFloorAngle : LevelBuffBase
{
	// Token: 0x06018D66 RID: 101734 RVA: 0x007086BE File Offset: 0x007068BE
	[NullableContext(1)]
	public LevelBuffSetWalkableFloorAngle(Entity entity, long buffId, string[] @params, float param1, float param2) : base(entity, buffId, @params, param1, param2)
	{
	}

	// Token: 0x06018D67 RID: 101735 RVA: 0x007086D0 File Offset: 0x007068D0
	public override void OnCreated()
	{
		UCharacterMovementComponent characterMovement = this.Entity.GetComponent<CharacterMoveComponent>().CharacterMovement;
		this.OriginalWalkableFloorAngle = characterMovement.WalkableFloorAngle;
		float walkableFloorAngle;
		if (!float.TryParse(this.Params[0], out walkableFloorAngle))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Level;
			ELogAuthor author = ELogAuthor.HXY;
			string message = "LevelBuffSetWalkableFloorAngle玩法效果缺少参数";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Buff", this.BuffId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		characterMovement.SetWalkableFloorAngle(walkableFloorAngle);
	}

	// Token: 0x06018D68 RID: 101736 RVA: 0x00708744 File Offset: 0x00706944
	public override void OnRemoved(bool bPremature)
	{
		this.Entity.GetComponent<CharacterMoveComponent>().CharacterMovement.SetWalkableFloorAngle(this.OriginalWalkableFloorAngle);
	}

	// Token: 0x0400C1E5 RID: 49637
	private float OriginalWalkableFloorAngle;
}
