using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace CSharpScript.Launcher.DiffPatch.Data
{
	// Token: 0x02004647 RID: 17991
	[NullableContext(1)]
	[Nullable(0)]
	public class ChunkTool
	{
		// Token: 0x0602EF68 RID: 192360 RVA: 0x00B20CEC File Offset: 0x00B1EEEC
		private static string ExtractChunkNumber(string input)
		{
			MatchCollection matchCollection = new Regex("pakchunk(\\d+)").Matches(input);
			if (matchCollection.Count <= 0)
			{
				return "";
			}
			return matchCollection[0].Groups[1].Value;
		}

		// Token: 0x0602EF69 RID: 192361 RVA: 0x00B20D30 File Offset: 0x00B1EF30
		public static bool IsChunk0or1(string file)
		{
			string a = ChunkTool.ExtractChunkNumber(file);
			return a == "0" || a == "1";
		}

		// Token: 0x0602EF6A RID: 192362 RVA: 0x00B20D60 File Offset: 0x00B1EF60
		public static bool IsRestartRequiredAfterHotPatchChunk(string file)
		{
			string a = ChunkTool.ExtractChunkNumber(file);
			return a == "0" || a == "1" || a == "18";
		}
	}
}
