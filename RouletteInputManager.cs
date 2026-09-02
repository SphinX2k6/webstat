using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002939 RID: 10553
public class RouletteInputManager : IStaticVariableResetter
{
	// Token: 0x06014F2B RID: 85803 RVA: 0x005CC11B File Offset: 0x005CA31B
	static RouletteInputManager()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(RouletteInputManager.CreateStaticDefaultValue), new Action(RouletteInputManager.ResetStaticDefaultValue));
	}

	// Token: 0x06014F2C RID: 85804 RVA: 0x005CC13C File Offset: 0x005CA33C
	public static void CreateStaticDefaultValue()
	{
		Dictionary<EInputControllerMainType, Func<Vector2D, ERouletteViewType?, int?, float?, RouletteInputBase>> dictionary = new Dictionary<EInputControllerMainType, Func<Vector2D, ERouletteViewType?, int?, float?, RouletteInputBase>>();
		dictionary.Add(EInputControllerMainType.None, ([Nullable(2)] Vector2D beginPos, ERouletteViewType? viewType, int? touchId, float? deadLimit) => new RouletteInputKeyboard(beginPos, viewType, touchId, deadLimit));
		dictionary.Add(EInputControllerMainType.Keyboard, ([Nullable(2)] Vector2D beginPos, ERouletteViewType? viewType, int? touchId, float? deadLimit) => new RouletteInputKeyboard(beginPos, viewType, touchId, deadLimit));
		dictionary.Add(EInputControllerMainType.Gamepad, ([Nullable(2)] Vector2D beginPos, ERouletteViewType? viewType, int? touchId, float? deadLimit) => new RouletteInputGamepad(beginPos, viewType, touchId, deadLimit));
		dictionary.Add(EInputControllerMainType.Touch, ([Nullable(2)] Vector2D beginPos, ERouletteViewType? viewType, int? touchId, float? deadLimit) => new RouletteInputTouch(beginPos, viewType, touchId, deadLimit));
		RouletteInputManager.InputManagerFactory = dictionary;
	}

	// Token: 0x06014F2D RID: 85805 RVA: 0x005CC1EB File Offset: 0x005CA3EB
	public static void ResetStaticDefaultValue()
	{
		RouletteInputManager.InputManagerFactory = null;
	}

	// Token: 0x06014F2E RID: 85806 RVA: 0x005CC1F4 File Offset: 0x005CA3F4
	[NullableContext(1)]
	public static RouletteInputBase CreateInput(EInputControllerMainType controllerType, [Nullable(2)] Vector2D beginPos, ERouletteViewType? viewType, int? touchId, float? gamepadDeadLimit)
	{
		Func<Vector2D, ERouletteViewType?, int?, float?, RouletteInputBase> func;
		if (RouletteInputManager.InputManagerFactory.TryGetValue(controllerType, out func))
		{
			return func(beginPos, viewType, touchId, gamepadDeadLimit);
		}
		return new RouletteInputKeyboard(beginPos, viewType, touchId, gamepadDeadLimit);
	}

	// Token: 0x0400A16C RID: 41324
	public const int KEYBOARD_DEAD_LIMIT = 100;

	// Token: 0x0400A16D RID: 41325
	[Nullable(new byte[]
	{
		1,
		1,
		2,
		1
	})]
	private static Dictionary<EInputControllerMainType, Func<Vector2D, ERouletteViewType?, int?, float?, RouletteInputBase>> InputManagerFactory;
}
