using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058C2 RID: 22722
	public class FishingPointMarkCreateInfo : DynamicMarkCreateInfo
	{
		// Token: 0x1700933C RID: 37692
		// (get) Token: 0x06039B0E RID: 236302 RVA: 0x00EA00A6 File Offset: 0x00E9E2A6
		public EFishPointDetectSourceType FishPointDetectSourceType
		{
			get
			{
				return ((FishingPointMarkCreateParam)this.CreateParams).FishPointDetectSourceType;
			}
		}

		// Token: 0x06039B0F RID: 236303 RVA: 0x00EA00B8 File Offset: 0x00E9E2B8
		[NullableContext(1)]
		public FishingPointMarkCreateInfo(FishingPointMarkCreateParam param) : base(param)
		{
		}
	}
}
