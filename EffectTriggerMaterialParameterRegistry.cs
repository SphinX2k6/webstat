using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.AnimNotifyInteraction.BP;
using UnrealEngine;

// Token: 0x02003408 RID: 13320
[NullableContext(1)]
[Nullable(0)]
public class EffectTriggerMaterialParameterRegistry
{
	// Token: 0x0601BD06 RID: 113926 RVA: 0x0084C640 File Offset: 0x0084A840
	private static FName CreateName(string name)
	{
		return FNameUtil.GetDynamicFName(name).Value;
	}

	// Token: 0x0601BD07 RID: 113927 RVA: 0x0084C65C File Offset: 0x0084A85C
	private static int? ResolveSlot(int index)
	{
		if (index < 0 || index > 4)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderEffect;
			ELogAuthor author = ELogAuthor.ZJL;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(65, 1);
			defaultInterpolatedStringHandler.AppendLiteral("EffectTriggerMaterialParameterRegistry ResolveSlot index无效 index=");
			defaultInterpolatedStringHandler.AppendFormatted<int>(index);
			instance.Warn(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		return new int?(index);
	}

	// Token: 0x0601BD08 RID: 113928 RVA: 0x0084C6BD File Offset: 0x0084A8BD
	private static bool IsValidAction(EEffectAction action)
	{
		return action >= EEffectAction.GroundPound && action < EEffectAction.EEffectAction_MAX;
	}

	// Token: 0x0601BD09 RID: 113929 RVA: 0x0084C6C9 File Offset: 0x0084A8C9
	[NullableContext(2)]
	private static EffectTriggerActionParameterNames GetActionParameterNames(EEffectAction action)
	{
		if (!EffectTriggerMaterialParameterRegistry.IsValidAction(action))
		{
			return null;
		}
		return EffectTriggerMaterialParameterRegistry.ActionParameterNames[(int)action];
	}

	// Token: 0x0601BD0A RID: 113930 RVA: 0x0084C6E0 File Offset: 0x0084A8E0
	public static bool IsValidActionAndIndex(EEffectAction action, int index)
	{
		return EffectTriggerMaterialParameterRegistry.IsValidAction(action) && EffectTriggerMaterialParameterRegistry.ResolveSlot(index) != null;
	}

	// Token: 0x0601BD0B RID: 113931 RVA: 0x0084C708 File Offset: 0x0084A908
	public static FName GetTriggerParameterName(EEffectAction action, int index)
	{
		int? num = EffectTriggerMaterialParameterRegistry.ResolveSlot(index);
		if (num == null)
		{
			return FNameUtil.EMPTY;
		}
		EffectTriggerActionParameterNames actionParameterNames = EffectTriggerMaterialParameterRegistry.GetActionParameterNames(action);
		if (actionParameterNames == null)
		{
			return FNameUtil.EMPTY;
		}
		return actionParameterNames.Trigger[num.Value];
	}

	// Token: 0x0601BD0C RID: 113932 RVA: 0x0084C74C File Offset: 0x0084A94C
	public static FName GetDurationParameterName(EEffectAction action, int index)
	{
		int? num = EffectTriggerMaterialParameterRegistry.ResolveSlot(index);
		if (num == null)
		{
			return FNameUtil.EMPTY;
		}
		EffectTriggerActionParameterNames actionParameterNames = EffectTriggerMaterialParameterRegistry.GetActionParameterNames(action);
		if (actionParameterNames == null)
		{
			return FNameUtil.EMPTY;
		}
		return actionParameterNames.Duration[num.Value];
	}

	// Token: 0x0601BD0D RID: 113933 RVA: 0x0084C790 File Offset: 0x0084A990
	public static FName GetAttackRadiusParameterName(EEffectAction action, int index)
	{
		int? num = EffectTriggerMaterialParameterRegistry.ResolveSlot(index);
		if (num == null)
		{
			return FNameUtil.EMPTY;
		}
		EffectTriggerActionParameterNames actionParameterNames = EffectTriggerMaterialParameterRegistry.GetActionParameterNames(action);
		if (actionParameterNames == null)
		{
			return FNameUtil.EMPTY;
		}
		return actionParameterNames.AttackRadius[num.Value];
	}

	// Token: 0x0601BD0E RID: 113934 RVA: 0x0084C7D4 File Offset: 0x0084A9D4
	public static FName GetAttackMagnitudeParameterName(EEffectAction action, int index)
	{
		int? num = EffectTriggerMaterialParameterRegistry.ResolveSlot(index);
		if (num == null)
		{
			return FNameUtil.EMPTY;
		}
		EffectTriggerActionParameterNames actionParameterNames = EffectTriggerMaterialParameterRegistry.GetActionParameterNames(action);
		if (actionParameterNames == null)
		{
			return FNameUtil.EMPTY;
		}
		return actionParameterNames.AttackMagnitude[num.Value];
	}

	// Token: 0x0601BD0F RID: 113935 RVA: 0x0084C818 File Offset: 0x0084AA18
	public static FName GetActorLocationParameterName(EEffectAction action, int index)
	{
		int? num = EffectTriggerMaterialParameterRegistry.ResolveSlot(index);
		if (num == null)
		{
			return FNameUtil.EMPTY;
		}
		EffectTriggerActionParameterNames actionParameterNames = EffectTriggerMaterialParameterRegistry.GetActionParameterNames(action);
		if (actionParameterNames == null)
		{
			return FNameUtil.EMPTY;
		}
		return actionParameterNames.ActorLocation[num.Value];
	}

	// Token: 0x0601BD10 RID: 113936 RVA: 0x0084C85C File Offset: 0x0084AA5C
	public static FName GetCurveFloatParameterName(EEffectAction action, int index)
	{
		int? num = EffectTriggerMaterialParameterRegistry.ResolveSlot(index);
		if (num == null)
		{
			return FNameUtil.EMPTY;
		}
		EffectTriggerActionParameterNames actionParameterNames = EffectTriggerMaterialParameterRegistry.GetActionParameterNames(action);
		if (actionParameterNames == null)
		{
			return FNameUtil.EMPTY;
		}
		return actionParameterNames.CurveFloat[num.Value];
	}

	// Token: 0x0601BD11 RID: 113937 RVA: 0x0084C8A0 File Offset: 0x0084AAA0
	public static FName GetElapsedTimeParameterName(EEffectAction action, int index)
	{
		int? num = EffectTriggerMaterialParameterRegistry.ResolveSlot(index);
		if (num == null)
		{
			return FNameUtil.EMPTY;
		}
		EffectTriggerActionParameterNames actionParameterNames = EffectTriggerMaterialParameterRegistry.GetActionParameterNames(action);
		if (actionParameterNames == null)
		{
			return FNameUtil.EMPTY;
		}
		return actionParameterNames.ElapsedTime[num.Value];
	}

	// Token: 0x0601BD12 RID: 113938 RVA: 0x0084C8E4 File Offset: 0x0084AAE4
	public static FName GetTextureHeightParameterName(EEffectAction action, int index)
	{
		int? num = EffectTriggerMaterialParameterRegistry.ResolveSlot(index);
		if (num == null)
		{
			return FNameUtil.EMPTY;
		}
		EffectTriggerActionParameterNames actionParameterNames = EffectTriggerMaterialParameterRegistry.GetActionParameterNames(action);
		if (actionParameterNames == null)
		{
			return FNameUtil.EMPTY;
		}
		return actionParameterNames.TextureHeight[num.Value];
	}

	// Token: 0x0400E097 RID: 57495
	public const int MaxSlotIndex = 4;

	// Token: 0x0400E098 RID: 57496
	private static readonly IReadOnlyList<EffectTriggerActionParameterNames> ActionParameterNames = new EffectTriggerActionParameterNames[]
	{
		new EffectTriggerActionParameterNames(new FName[]
		{
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundTrig0"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundTrig1"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundTrig2"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundTrig3"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundTrig4")
		}, new FName[]
		{
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundDurat0"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundDurat1"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundDurat2"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundDurat3"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundDurat4")
		}, new FName[]
		{
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundAtkRad0"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundAtkRad1"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundAtkRad2"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundAtkRad3"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundAtkRad4")
		}, new FName[]
		{
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundAtkMag0"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundAtkMag1"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundAtkMag2"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundAtkMag3"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundAtkMag4")
		}, new FName[]
		{
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundActorLoc0"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundActorLoc1"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundActorLoc2"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundActorLoc3"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundActorLoc4")
		}, new FName[]
		{
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundCurve0"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundCurve1"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundCurve2"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundCurve3"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundCurve4")
		}, new FName[]
		{
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundElapsedTime0"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundElapsedTime1"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundElapsedTime2"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundElapsedTime3"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundElapsedTime4")
		}, new FName[]
		{
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundTextureHeight0"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundTextureHeight1"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundTextureHeight2"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundTextureHeight3"),
			EffectTriggerMaterialParameterRegistry.CreateName("GroundPoundTextureHeight4")
		}),
		new EffectTriggerActionParameterNames(new FName[]
		{
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveTrig0"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveTrig1"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveTrig2"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveTrig3"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveTrig4")
		}, new FName[]
		{
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveDurat0"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveDurat1"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveDurat2"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveDurat3"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveDurat4")
		}, new FName[]
		{
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveAtkRad0"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveAtkRad1"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveAtkRad2"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveAtkRad3"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveAtkRad4")
		}, new FName[]
		{
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveAtkMag0"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveAtkMag1"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveAtkMag2"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveAtkMag3"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveAtkMag4")
		}, new FName[]
		{
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveActorLoc0"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveActorLoc1"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveActorLoc2"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveActorLoc3"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveActorLoc4")
		}, new FName[]
		{
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveCurve0"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveCurve1"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveCurve2"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveCurve3"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveCurve4")
		}, new FName[]
		{
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveElapsedTime0"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveElapsedTime1"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveElapsedTime2"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveElapsedTime3"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveElapsedTime4")
		}, new FName[]
		{
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveTextureHeight0"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveTextureHeight1"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveTextureHeight2"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveTextureHeight3"),
			EffectTriggerMaterialParameterRegistry.CreateName("ShockwaveTextureHeight4")
		}),
		new EffectTriggerActionParameterNames(new FName[]
		{
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalTrig0"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalTrig1"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalTrig2"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalTrig3"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalTrig4")
		}, new FName[]
		{
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalDurat0"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalDurat1"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalDurat2"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalDurat3"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalDurat4")
		}, new FName[]
		{
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalAtkRad0"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalAtkRad1"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalAtkRad2"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalAtkRad3"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalAtkRad4")
		}, new FName[]
		{
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalAtkMag0"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalAtkMag1"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalAtkMag2"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalAtkMag3"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalAtkMag4")
		}, new FName[]
		{
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalActorLoc0"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalActorLoc1"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalActorLoc2"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalActorLoc3"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalActorLoc4")
		}, new FName[]
		{
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalCurve0"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalCurve1"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalCurve2"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalCurve3"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalCurve4")
		}, new FName[]
		{
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalElapsedTime0"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalElapsedTime1"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalElapsedTime2"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalElapsedTime3"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalElapsedTime4")
		}, new FName[]
		{
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalTextureHeight0"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalTextureHeight1"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalTextureHeight2"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalTextureHeight3"),
			EffectTriggerMaterialParameterRegistry.CreateName("DiagonalTextureHeight4")
		})
	};
}
