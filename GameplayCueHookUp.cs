using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x02002FAB RID: 12203
public class GameplayCueHookUp : GameplayCueBase
{
	// Token: 0x06018E25 RID: 101925 RVA: 0x0070C637 File Offset: 0x0070A837
	protected override void OnInit()
	{
	}

	// Token: 0x06018E26 RID: 101926 RVA: 0x0070C639 File Offset: 0x0070A839
	protected override void OnTick(float delta)
	{
	}

	// Token: 0x06018E27 RID: 101927 RVA: 0x0070C63C File Offset: 0x0070A83C
	protected override void OnCreate()
	{
		this.HookItem = GameplayCueHookCommonItem.Spawn(this.ActorInternal, FNameUtil.GetDynamicFName(this.CueConfig.Socket).Value, this.GetTargetPosition(), this.CueConfig.Resources(), true);
	}

	// Token: 0x06018E28 RID: 101928 RVA: 0x0070C684 File Offset: 0x0070A884
	protected override void OnDestroy()
	{
		this.HookItem.Destroy();
	}

	// Token: 0x06018E29 RID: 101929 RVA: 0x0070C694 File Offset: 0x0070A894
	private FVectorDouble GetTargetPosition()
	{
		Aki.Config.Vector value = this.CueConfig.Location.Value;
		FTransformDouble ftransformDouble = this.ActorInternal.D_GetTransform();
		FVectorDouble fvectorDouble = new FVectorDouble((double)value.X, (double)value.Y, (double)value.Z);
		return ftransformDouble.TransformPositionNoScale(fvectorDouble);
	}

	// Token: 0x0400C26B RID: 49771
	[Nullable(2)]
	private GameplayCueHookCommonItem HookItem;
}
