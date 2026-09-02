using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F8F RID: 12175
public class LevelBuffSceneItem : LevelBuffBase
{
	// Token: 0x06018D63 RID: 101731 RVA: 0x007086AB File Offset: 0x007068AB
	[NullableContext(1)]
	public LevelBuffSceneItem(Entity entity, long buffId, string[] @params, float param1, float param2) : base(entity, buffId, @params, param1, param2)
	{
	}

	// Token: 0x06018D64 RID: 101732 RVA: 0x007086BA File Offset: 0x007068BA
	public override void OnRemoved(bool bPremature)
	{
	}

	// Token: 0x06018D65 RID: 101733 RVA: 0x007086BC File Offset: 0x007068BC
	public override void OnStackChanged(int newCount, int oldCount, bool bPremature)
	{
	}
}
