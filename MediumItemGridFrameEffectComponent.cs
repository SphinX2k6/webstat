using System;
using System.Runtime.CompilerServices;

// Token: 0x020019C3 RID: 6595
public class MediumItemGridFrameEffectComponent : MediumItemGridVisibleComponent
{
	// Token: 0x0600BD55 RID: 48469 RVA: 0x00323DC4 File Offset: 0x00321FC4
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemAFetterVfx";
	}

	// Token: 0x0600BD56 RID: 48470 RVA: 0x00323DCC File Offset: 0x00321FCC
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		this.LevelSequencePlayer.PlayLevelSequenceByName("Loop", false, null, false);
	}

	// Token: 0x0400595C RID: 22876
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;
}
