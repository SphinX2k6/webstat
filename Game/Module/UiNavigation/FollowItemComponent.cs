using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CF6 RID: 19702
	[NullableContext(1)]
	[Nullable(0)]
	public class FollowItemComponent : HotKeyComponent
	{
		// Token: 0x060333FB RID: 209915 RVA: 0x00CD4B0D File Offset: 0x00CD2D0D
		public FollowItemComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060333FC RID: 209916 RVA: 0x00CD4B16 File Offset: 0x00CD2D16
		public void ResetFollowItem()
		{
		}

		// Token: 0x060333FD RID: 209917 RVA: 0x00CD4B18 File Offset: 0x00CD2D18
		public void FollowItem(UUIItem item, int length)
		{
		}

		// Token: 0x060333FE RID: 209918 RVA: 0x00CD4B1A File Offset: 0x00CD2D1A
		public void OnInteractionHintChangeItemCountEvent(int length)
		{
		}

		// Token: 0x060333FF RID: 209919 RVA: 0x00CD4B1C File Offset: 0x00CD2D1C
		protected override void OnInputAxis(string axisName, float value)
		{
		}
	}
}
