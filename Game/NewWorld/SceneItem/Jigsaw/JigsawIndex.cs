using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.SceneItem.Jigsaw
{
	// Token: 0x0200485F RID: 18527
	[NullableContext(1)]
	[Nullable(0)]
	public class JigsawIndex
	{
		// Token: 0x06030302 RID: 197378 RVA: 0x00BB2F1C File Offset: 0x00BB111C
		public JigsawIndex(int row, int col)
		{
		}

		// Token: 0x06030303 RID: 197379 RVA: 0x00BB2F32 File Offset: 0x00BB1132
		public void DeepCopy(JigsawIndex other)
		{
			this.Row = other.Row;
			this.Col = other.Col;
		}

		// Token: 0x06030304 RID: 197380 RVA: 0x00BB2F4C File Offset: 0x00BB114C
		public void SetValue(int row, int col)
		{
			this.Row = row;
			this.Col = col;
		}

		// Token: 0x06030305 RID: 197381 RVA: 0x00BB2F5C File Offset: 0x00BB115C
		public bool Equels(JigsawIndex other)
		{
			return this.Row == other.Row && this.Col == other.Col;
		}

		// Token: 0x06030306 RID: 197382 RVA: 0x00BB2F7C File Offset: 0x00BB117C
		public string GetKey()
		{
			if (this.Key == null || this.KeyRow != this.Row || this.KeyCol != this.Col)
			{
				this.Key = this.Row.ToString() + "," + this.Col.ToString();
				this.KeyRow = this.Row;
				this.KeyCol = this.Col;
			}
			return this.Key;
		}

		// Token: 0x06030307 RID: 197383 RVA: 0x00BB2FF4 File Offset: 0x00BB11F4
		public static JigsawIndex GenObjFromKey(string key)
		{
			string[] array = key.Split(',', StringSplitOptions.None);
			return new JigsawIndex(int.Parse(array[0]), int.Parse(array[1]));
		}

		// Token: 0x06030308 RID: 197384 RVA: 0x00BB3020 File Offset: 0x00BB1220
		public static string GenKey(int row, int col)
		{
			return row.ToString() + "," + col.ToString();
		}

		// Token: 0x0401BABC RID: 113340
		public int Row = row;

		// Token: 0x0401BABD RID: 113341
		public int Col = col;

		// Token: 0x0401BABE RID: 113342
		[Nullable(2)]
		private string Key;

		// Token: 0x0401BABF RID: 113343
		private int KeyRow;

		// Token: 0x0401BAC0 RID: 113344
		private int KeyCol;
	}
}
