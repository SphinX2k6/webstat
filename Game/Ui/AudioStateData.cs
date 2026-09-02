using System;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049A1 RID: 18849
	public class AudioStateData
	{
		// Token: 0x170083FE RID: 33790
		// (get) Token: 0x06031385 RID: 201605 RVA: 0x00C41C42 File Offset: 0x00C3FE42
		// (set) Token: 0x06031386 RID: 201606 RVA: 0x00C41C5E File Offset: 0x00C3FE5E
		public float Alpha
		{
			get
			{
				return Singleton<MathUtils>.Instance.Clamp(this.AlphaInternal, 0f, 1f);
			}
			set
			{
				this.AlphaInternal = value;
			}
		}

		// Token: 0x170083FF RID: 33791
		// (get) Token: 0x06031387 RID: 201607 RVA: 0x00C41C67 File Offset: 0x00C3FE67
		// (set) Token: 0x06031388 RID: 201608 RVA: 0x00C41C83 File Offset: 0x00C3FE83
		public float Level
		{
			get
			{
				return Singleton<MathUtils>.Instance.Clamp(this.LevelInternal, 0f, 1f);
			}
			set
			{
				this.LevelInternal = value;
			}
		}

		// Token: 0x0401C524 RID: 116004
		private float AlphaInternal;

		// Token: 0x0401C525 RID: 116005
		private float LevelInternal;
	}
}
