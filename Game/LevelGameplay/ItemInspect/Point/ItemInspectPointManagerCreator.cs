using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.ItemInspect.Point
{
	// Token: 0x02006E53 RID: 28243
	public static class ItemInspectPointManagerCreator
	{
		// Token: 0x060448E0 RID: 280800 RVA: 0x011D2B88 File Offset: 0x011D0D88
		[NullableContext(1)]
		[return: Nullable(2)]
		public static ItemInspectPointManager createPointManager(ISequenceUnlockPoints config)
		{
			ItemInspectPointManager itemInspectPointManager = null;
			if (config.Type == EInteractUnlockType.Sequence)
			{
				itemInspectPointManager = new SequenceUnlockPointManager();
			}
			if (itemInspectPointManager == null)
			{
				return null;
			}
			itemInspectPointManager.Init(config);
			return itemInspectPointManager;
		}
	}
}
