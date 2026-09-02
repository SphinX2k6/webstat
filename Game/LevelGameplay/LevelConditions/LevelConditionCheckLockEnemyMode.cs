using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D2A RID: 27946
	public class LevelConditionCheckLockEnemyMode : LevelConditionBase
	{
		// Token: 0x0604448F RID: 279695 RVA: 0x011BD438 File Offset: 0x011BB638
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			string limitParams = inConditionInfo.GetLimitParams("ModeIndex");
			if (limitParams == null)
			{
				return false;
			}
			int num = int.Parse(limitParams);
			int? currentValue = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.KeyboardLockEnemyMode, true, true);
			int? currentValue2 = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.GamepadLockEnemyMode, true, true);
			switch (Singleton<Info>.Instance.InputControllerMainType)
			{
			case EInputControllerMainType.Keyboard:
			{
				int num2 = num;
				int? num3 = currentValue;
				return num2 == num3.GetValueOrDefault() & num3 != null;
			}
			case EInputControllerMainType.Gamepad:
			{
				int num4 = num;
				int? num3 = currentValue2;
				return num4 == num3.GetValueOrDefault() & num3 != null;
			}
			case EInputControllerMainType.Touch:
				return num == 0;
			}
			return false;
		}
	}
}
