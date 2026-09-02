using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Ui.HotFix
{
	// Token: 0x0200450C RID: 17676
	[NullableContext(2)]
	[Nullable(0)]
	public class HotFixLguiUtils
	{
		// Token: 0x0602E923 RID: 190755 RVA: 0x00B08AC8 File Offset: 0x00B06CC8
		public static UUIItem CopyItem([Nullable(1)] UUIItem item, USceneComponent parent)
		{
			AActor aactor = HotFixLguiUtils.DuplicateActor(item.GetOwner(), parent);
			if (aactor == null)
			{
				return null;
			}
			return aactor.GetComponentByClass(UUIItem.StaticClass()) as UUIItem;
		}

		// Token: 0x0602E924 RID: 190756 RVA: 0x00B08AFC File Offset: 0x00B06CFC
		public static AActor DuplicateActor([Nullable(1)] AActor actor, USceneComponent parent)
		{
			return ULGUIBPLibrary.DuplicateActor(actor, parent);
		}
	}
}
