using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.UiNavigation.Enum;
using AkiClient.Game.Aki.Data.UiNavigation.Struct;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CD2 RID: 19666
	[NullableContext(1)]
	[Nullable(0)]
	public class UiNavigationCursorModule
	{
		// Token: 0x060332CF RID: 209615 RVA: 0x00CCFBB6 File Offset: 0x00CCDDB6
		public UiNavigationCursorModule(SNavigationCursor cursor)
		{
			this.Cursor = cursor;
		}

		// Token: 0x060332D0 RID: 209616 RVA: 0x00CCFBC8 File Offset: 0x00CCDDC8
		public FVector2D GetCursorOffset()
		{
			switch (this.Cursor.OffsetType)
			{
			case ECursorOffsetType.Left:
				return new FVector2D(0f, 0.5f);
			case ECursorOffsetType.Top:
				return new FVector2D(0.5f, 1f);
			case ECursorOffsetType.Right:
				return new FVector2D(1f, 0.5f);
			case ECursorOffsetType.Down:
				return new FVector2D(0.5f, 0f);
			default:
				return new FVector2D(0f, 0f);
			}
		}

		// Token: 0x060332D1 RID: 209617 RVA: 0x00CCFC50 File Offset: 0x00CCDE50
		public int GetCursorRotation()
		{
			if (this.Cursor.OffsetType == ECursorOffsetType.Left)
			{
				return 0;
			}
			if (this.Cursor.OffsetType == ECursorOffsetType.Top)
			{
				return 270;
			}
			if (this.Cursor.OffsetType == ECursorOffsetType.Right)
			{
				return 180;
			}
			if (this.Cursor.OffsetType == ECursorOffsetType.Down)
			{
				return 90;
			}
			return 0;
		}

		// Token: 0x060332D2 RID: 209618 RVA: 0x00CCFCD0 File Offset: 0x00CCDED0
		public FVector2D GetBoundOffset()
		{
			switch (this.Cursor.OffsetType)
			{
			case ECursorOffsetType.Left:
				return new FVector2D((float)(-(float)this.Cursor.BoundOffset), 0f);
			case ECursorOffsetType.Top:
				return new FVector2D(0f, (float)this.Cursor.BoundOffset);
			case ECursorOffsetType.Right:
				return new FVector2D((float)this.Cursor.BoundOffset, 0f);
			case ECursorOffsetType.Down:
				return new FVector2D(0f, (float)(-(float)this.Cursor.BoundOffset));
			default:
				return new FVector2D(0f, 0f);
			}
		}

		// Token: 0x0401DB93 RID: 121747
		private readonly SNavigationCursor Cursor;
	}
}
