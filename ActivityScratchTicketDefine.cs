using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001598 RID: 5528
public class ActivityScratchTicketDefine : IStaticVariableResetter
{
	// Token: 0x06009B87 RID: 39815 RVA: 0x0028B9FD File Offset: 0x00289BFD
	static ActivityScratchTicketDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(ActivityScratchTicketDefine.CreateStaticDefaultValue), new Action(ActivityScratchTicketDefine.ResetStaticDefaultValue));
	}

	// Token: 0x06009B88 RID: 39816 RVA: 0x0028BA1C File Offset: 0x00289C1C
	public static void CreateStaticDefaultValue()
	{
		Dictionary<EScratchDirectionType, ECellSequenceType> dictionary = new Dictionary<EScratchDirectionType, ECellSequenceType>();
		dictionary[EScratchDirectionType.Center] = ECellSequenceType.Center;
		dictionary[EScratchDirectionType.Left] = ECellSequenceType.Left;
		dictionary[EScratchDirectionType.Right] = ECellSequenceType.Right;
		dictionary[EScratchDirectionType.Top] = ECellSequenceType.Top;
		dictionary[EScratchDirectionType.Bottom] = ECellSequenceType.Bottom;
		dictionary[EScratchDirectionType.LeftTop] = ECellSequenceType.Left;
		dictionary[EScratchDirectionType.LeftBottom] = ECellSequenceType.Left;
		dictionary[EScratchDirectionType.RightTop] = ECellSequenceType.Left;
		dictionary[EScratchDirectionType.RightBottom] = ECellSequenceType.Left;
		ActivityScratchTicketDefine.DirectionToSequenceMap = dictionary;
	}

	// Token: 0x06009B89 RID: 39817 RVA: 0x0028BA7B File Offset: 0x00289C7B
	public static void ResetStaticDefaultValue()
	{
		ActivityScratchTicketDefine.DirectionToSequenceMap = null;
	}

	// Token: 0x040047A5 RID: 18341
	[Nullable(2)]
	public static Dictionary<EScratchDirectionType, ECellSequenceType> DirectionToSequenceMap;

	// Token: 0x040047A6 RID: 18342
	public const int SCRATCH_TICKET_REWRAD_CONFIG_ID = 1009;

	// Token: 0x040047A7 RID: 18343
	public const int FIRST_SHOW_REWARD_INTERVAL = 700;

	// Token: 0x040047A8 RID: 18344
	public const int SHOW_SHAKE_INTERVAL = 500;

	// Token: 0x040047A9 RID: 18345
	public const int CELL_SHOW_REWRD_INTERVAL = 100;

	// Token: 0x040047AA RID: 18346
	public const int CELL_SHOW_WARNING_INTERVAL = 50;

	// Token: 0x040047AB RID: 18347
	public const int FOREVER_DELAY_INTERVAL = 50;

	// Token: 0x040047AC RID: 18348
	public const int LAST_DELAY_INTERVAL = 700;

	// Token: 0x040047AD RID: 18349
	public const int REVEAL_DELAY_INTERVAL = 30;

	// Token: 0x040047AE RID: 18350
	public const int TOUCH_BOUNDARY_INTERVAL = 250;

	// Token: 0x040047AF RID: 18351
	public const int HAMSTER_B_SEQUENCE_INTERVAL = 700;

	// Token: 0x040047B0 RID: 18352
	public const int HAMSTER_C_SEQUENCE_INTERVAL = 1000;
}
