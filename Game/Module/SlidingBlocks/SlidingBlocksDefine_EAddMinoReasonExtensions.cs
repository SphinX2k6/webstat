using System;

namespace CSharpScript.Game.Module.SlidingBlocks
{
	// Token: 0x02004F07 RID: 20231
	public static class SlidingBlocksDefine_EAddMinoReasonExtensions
	{
		// Token: 0x060344CA RID: 214218 RVA: 0x00D15D24 File Offset: 0x00D13F24
		public static string ToEnumString(this SlidingBlocksDefine.EAddMinoReason value)
		{
			string result;
			switch (value)
			{
			case SlidingBlocksDefine.EAddMinoReason.LineClearFall:
				result = "LineClearFall";
				break;
			case SlidingBlocksDefine.EAddMinoReason.CreatePresetMino:
				result = "CreatePresetMino";
				break;
			case SlidingBlocksDefine.EAddMinoReason.TetrominoLock:
				result = "TetrominoLock";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x060344CB RID: 214219 RVA: 0x00D15D6C File Offset: 0x00D13F6C
		public static SlidingBlocksDefine.EAddMinoReason FromString(string name)
		{
			SlidingBlocksDefine.EAddMinoReason result;
			if (!SlidingBlocksDefine_EAddMinoReasonExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 SlidingBlocksDefine.EAddMinoReason 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x060344CC RID: 214220 RVA: 0x00D15D98 File Offset: 0x00D13F98
		public static bool TryFromString(string name, out SlidingBlocksDefine.EAddMinoReason value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = SlidingBlocksDefine.EAddMinoReason.LineClearFall;
				return false;
			}
			if (name == "LineClearFall")
			{
				value = SlidingBlocksDefine.EAddMinoReason.LineClearFall;
				return true;
			}
			if (name == "CreatePresetMino")
			{
				value = SlidingBlocksDefine.EAddMinoReason.CreatePresetMino;
				return true;
			}
			if (!(name == "TetrominoLock"))
			{
				value = SlidingBlocksDefine.EAddMinoReason.LineClearFall;
				return false;
			}
			value = SlidingBlocksDefine.EAddMinoReason.TetrominoLock;
			return true;
		}

		// Token: 0x060344CD RID: 214221 RVA: 0x00D15DEE File Offset: 0x00D13FEE
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"LineClearFall",
				"CreatePresetMino",
				"TetrominoLock"
			};
		}

		// Token: 0x060344CE RID: 214222 RVA: 0x00D15E0E File Offset: 0x00D1400E
		public static SlidingBlocksDefine.EAddMinoReason[] GetValues()
		{
			return new SlidingBlocksDefine.EAddMinoReason[]
			{
				SlidingBlocksDefine.EAddMinoReason.LineClearFall,
				SlidingBlocksDefine.EAddMinoReason.CreatePresetMino,
				SlidingBlocksDefine.EAddMinoReason.TetrominoLock
			};
		}

		// Token: 0x060344CF RID: 214223 RVA: 0x00D15E1E File Offset: 0x00D1401E
		public static string[] GetNames()
		{
			return new string[]
			{
				"LineClearFall",
				"CreatePresetMino",
				"TetrominoLock"
			};
		}
	}
}
