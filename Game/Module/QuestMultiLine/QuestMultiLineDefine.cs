using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.QuestMultiLine
{
	// Token: 0x0200531D RID: 21277
	public static class QuestMultiLineDefine
	{
		// Token: 0x060364C3 RID: 222403 RVA: 0x00DAF624 File Offset: 0x00DAD824
		[NullableContext(1)]
		public static string GetUiPrefab(EUiPrefab prefab)
		{
			string result;
			switch (prefab)
			{
			case EUiPrefab.ComponentId:
				result = "PnlMissionMapRoleItem";
				break;
			case EUiPrefab.DialogueLeft:
				result = "PnlDialogueL";
				break;
			case EUiPrefab.DialogueRight:
				result = "PnlDialogueR";
				break;
			default:
				result = string.Empty;
				break;
			}
			return result;
		}

		// Token: 0x0401F382 RID: 127874
		public const int HELP_ID = 617;

		// Token: 0x0401F383 RID: 127875
		public const float TIME_POINT_ALPHA = 0.5f;

		// Token: 0x0401F384 RID: 127876
		public const int FIGHT_AREA_MAX = 6;

		// Token: 0x0401F385 RID: 127877
		public const int PATH_POINT_COUNT = 100;

		// Token: 0x0401F386 RID: 127878
		public const int MILLISECONDS_PER_SECOND = 1000;

		// Token: 0x0401F387 RID: 127879
		public const int MAP_TEXTURE_SCALE = 1;

		// Token: 0x0401F388 RID: 127880
		public const int MAP_DRAG_REBOUND_X = 100;

		// Token: 0x0401F389 RID: 127881
		public const int MAP_DRAG_REBOUND_Y = 100;

		// Token: 0x0401F38A RID: 127882
		public const float MAP_DRAG_BOUNCE_DURATION = 0.3f;

		// Token: 0x0401F38B RID: 127883
		public const int MAP_DRAG_INERTIA_MULTIPLIER = 8;

		// Token: 0x0401F38C RID: 127884
		public const float MAP_DRAG_INERTIA_DURATION = 0.6f;

		// Token: 0x0401F38D RID: 127885
		public const float MAP_CENTER_ON_COMPONENT_DURATION = 0.35f;

		// Token: 0x0401F38E RID: 127886
		public const int MIN_TIME = 20;

		// Token: 0x0401F38F RID: 127887
		public const int TIPS_TIMER_DURATION_MS = 1000;

		// Token: 0x0401F390 RID: 127888
		public const float TIME_LINE_SCROLL_TOLERANCE = 0.1f;
	}
}
