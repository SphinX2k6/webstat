using System;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058AF RID: 22703
	public class Circle
	{
		// Token: 0x1700931E RID: 37662
		// (get) Token: 0x06039AD3 RID: 236243 RVA: 0x00E9FBA7 File Offset: 0x00E9DDA7
		// (set) Token: 0x06039AD4 RID: 236244 RVA: 0x00E9FBAF File Offset: 0x00E9DDAF
		public float X { get; set; }

		// Token: 0x1700931F RID: 37663
		// (get) Token: 0x06039AD5 RID: 236245 RVA: 0x00E9FBB8 File Offset: 0x00E9DDB8
		// (set) Token: 0x06039AD6 RID: 236246 RVA: 0x00E9FBC0 File Offset: 0x00E9DDC0
		public float Y { get; set; }

		// Token: 0x17009320 RID: 37664
		// (get) Token: 0x06039AD7 RID: 236247 RVA: 0x00E9FBC9 File Offset: 0x00E9DDC9
		// (set) Token: 0x06039AD8 RID: 236248 RVA: 0x00E9FBD1 File Offset: 0x00E9DDD1
		public float R { get; set; }

		// Token: 0x06039AD9 RID: 236249 RVA: 0x00E9FBDA File Offset: 0x00E9DDDA
		public Circle(float x = 0f, float y = 0f, float r = 0f)
		{
			this.X = x;
			this.Y = y;
			this.R = r;
		}
	}
}
