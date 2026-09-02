using System;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x0200534A RID: 21322
	public class CameraParam
	{
		// Token: 0x17008D62 RID: 36194
		// (get) Token: 0x0603664A RID: 222794 RVA: 0x00DB663E File Offset: 0x00DB483E
		public bool ApertureEnable
		{
			get
			{
				return this.Aperture != null;
			}
		}

		// Token: 0x17008D63 RID: 36195
		// (get) Token: 0x0603664B RID: 222795 RVA: 0x00DB664C File Offset: 0x00DB484C
		public bool FocalLengthEnable
		{
			get
			{
				if (this.FocalLength != null)
				{
					double? focalLength = this.FocalLength;
					double num = 0.0;
					return !(focalLength.GetValueOrDefault() == num & focalLength != null);
				}
				return false;
			}
		}

		// Token: 0x17008D64 RID: 36196
		// (get) Token: 0x0603664C RID: 222796 RVA: 0x00DB668E File Offset: 0x00DB488E
		public bool FocusDistanceEnable
		{
			get
			{
				return this.FocusDistance != null;
			}
		}

		// Token: 0x17008D65 RID: 36197
		// (get) Token: 0x0603664D RID: 222797 RVA: 0x00DB669B File Offset: 0x00DB489B
		public bool FocalRegionEnable
		{
			get
			{
				return this.FocalRegion != null;
			}
		}

		// Token: 0x0401F472 RID: 128114
		public double? Aperture;

		// Token: 0x0401F473 RID: 128115
		public double? FocalLength = new double?(0.0);

		// Token: 0x0401F474 RID: 128116
		public double? FocusDistance = new double?(0.0);

		// Token: 0x0401F475 RID: 128117
		public double? FocalRegion = new double?(0.0);
	}
}
