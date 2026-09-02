using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component
{
	// Token: 0x02004906 RID: 18694
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ManipulaterModel : ModelBase<ManipulaterModel>
	{
		// Token: 0x06030DB5 RID: 200117 RVA: 0x00C19EB2 File Offset: 0x00C180B2
		public void SetManipulateMode(ManipulaterModel.EManipulaterMode mode)
		{
			this.ManipulateMode = mode;
		}

		// Token: 0x06030DB6 RID: 200118 RVA: 0x00C19EBB File Offset: 0x00C180BB
		public ManipulaterModel.EManipulaterMode GetManipulateMode()
		{
			return this.ManipulateMode;
		}

		// Token: 0x06030DB7 RID: 200119 RVA: 0x00C19EC3 File Offset: 0x00C180C3
		public void SetTargetPartLocation(Vector offset)
		{
			this.TargetPartLocation = offset;
		}

		// Token: 0x06030DB8 RID: 200120 RVA: 0x00C19ECC File Offset: 0x00C180CC
		public Vector GetTargetPartLocation()
		{
			return this.TargetPartLocation;
		}

		// Token: 0x06030DB9 RID: 200121 RVA: 0x00C19ED4 File Offset: 0x00C180D4
		public bool NeedShowLandTips()
		{
			return this.ShowLandTipsCount > 0;
		}

		// Token: 0x06030DBA RID: 200122 RVA: 0x00C19EE0 File Offset: 0x00C180E0
		public void AddShowLandTipsCount(Entity entity)
		{
			if (this.InRangeShowLandTipsEntity.Contains(entity))
			{
				return;
			}
			if (this.ShowLandTipsCount == 0)
			{
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnManipulateShowLandTips, true);
			}
			this.ShowLandTipsCount++;
			this.InRangeShowLandTipsEntity.Add(entity);
		}

		// Token: 0x06030DBB RID: 200123 RVA: 0x00C19F30 File Offset: 0x00C18130
		public void RemoveShowLandTipsCount(Entity entity)
		{
			if (!this.InRangeShowLandTipsEntity.Contains(entity) || this.ShowLandTipsCount == 0)
			{
				return;
			}
			this.InRangeShowLandTipsEntity.Remove(entity);
			this.ShowLandTipsCount--;
			if (this.ShowLandTipsCount == 0)
			{
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnManipulateShowLandTips, false);
			}
		}

		// Token: 0x06030DBC RID: 200124 RVA: 0x00C19F88 File Offset: 0x00C18188
		public TArray<FVectorDouble> GetProjectilePath()
		{
			if (this.ProjectilePath == null)
			{
				this.ProjectilePath = new TArray<FVectorDouble>();
			}
			return this.ProjectilePath;
		}

		// Token: 0x06030DBD RID: 200125 RVA: 0x00C19FA3 File Offset: 0x00C181A3
		public void SetProjectilePath(TArray<FVectorDouble> path)
		{
			this.ProjectilePath = path;
		}

		// Token: 0x06030DBE RID: 200126 RVA: 0x00C19FAC File Offset: 0x00C181AC
		public TArray<FVectorDouble> GetAfterPortalProjectilePath()
		{
			if (this.AfterPortalProjectilePath == null)
			{
				this.AfterPortalProjectilePath = new TArray<FVectorDouble>();
			}
			return this.AfterPortalProjectilePath;
		}

		// Token: 0x06030DBF RID: 200127 RVA: 0x00C19FC7 File Offset: 0x00C181C7
		[NullableContext(2)]
		public void SetAfterPortalProjectilePath(TArray<FVectorDouble> path)
		{
			this.AfterPortalProjectilePath = path;
		}

		// Token: 0x06030DC0 RID: 200128 RVA: 0x00C19FD0 File Offset: 0x00C181D0
		public FVectorDouble? GetAfterPortalStartPosition()
		{
			return this.AfterPortalStartPosition;
		}

		// Token: 0x06030DC1 RID: 200129 RVA: 0x00C19FD8 File Offset: 0x00C181D8
		public void SetAfterPortalStartPosition(FVectorDouble? position)
		{
			this.AfterPortalStartPosition = position;
		}

		// Token: 0x0401C135 RID: 114997
		private ManipulaterModel.EManipulaterMode ManipulateMode;

		// Token: 0x0401C136 RID: 114998
		private Vector TargetPartLocation = Vector.ZeroVectorProxy;

		// Token: 0x0401C137 RID: 114999
		[Nullable(2)]
		public Vector ExitHoldingStateCameraLocation;

		// Token: 0x0401C138 RID: 115000
		private int ShowLandTipsCount;

		// Token: 0x0401C139 RID: 115001
		private readonly HashSet<Entity> InRangeShowLandTipsEntity = new HashSet<Entity>();

		// Token: 0x0401C13A RID: 115002
		[Nullable(2)]
		private TArray<FVectorDouble> ProjectilePath;

		// Token: 0x0401C13B RID: 115003
		[Nullable(2)]
		private TArray<FVectorDouble> AfterPortalProjectilePath;

		// Token: 0x0401C13C RID: 115004
		private FVectorDouble? AfterPortalStartPosition;

		// Token: 0x0200A9BE RID: 43454
		[NullableContext(0)]
		public enum EManipulaterMode
		{
			// Token: 0x040348B2 RID: 215218
			BigWorld,
			// Token: 0x040348B3 RID: 215219
			Boss
		}
	}
}
