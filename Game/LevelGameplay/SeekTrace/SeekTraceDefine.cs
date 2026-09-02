using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.SeekTrace
{
	// Token: 0x02006B05 RID: 27397
	[NullableContext(1)]
	[Nullable(0)]
	public class SeekTraceDefine
	{
		// Token: 0x06043B6B RID: 277355 RVA: 0x01178554 File Offset: 0x01176754
		// Note: this type is marked as 'beforefieldinit'.
		static SeekTraceDefine()
		{
			int[][] array = new int[4][];
			array[0] = new int[]
			{
				0,
				1
			};
			array[1] = new int[]
			{
				0,
				-1
			};
			int num = 2;
			int[] array2 = new int[2];
			array2[0] = 1;
			array[num] = array2;
			int num2 = 3;
			int[] array3 = new int[2];
			array3[0] = -1;
			array[num2] = array3;
			SeekTraceDefine.preSelectedOffsetList = array;
		}

		// Token: 0x04025D75 RID: 154997
		[StaticVariableRuleIgnore]
		public static readonly int[][] preSelectedOffsetList;

		// Token: 0x04025D76 RID: 154998
		public const int BIG_CONTENT_SIZE = 8;

		// Token: 0x04025D77 RID: 154999
		public const string BIG_CONTENT_KEY = "UiItem_CrosslGridB";

		// Token: 0x04025D78 RID: 155000
		public const int SMALL_CONTNET_SIZE = 5;

		// Token: 0x04025D79 RID: 155001
		public const string SMALL_CONTENT_KEY = "UiItem_CrosslGridS";
	}
}
