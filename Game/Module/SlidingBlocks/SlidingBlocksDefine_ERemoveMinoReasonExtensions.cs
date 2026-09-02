using System;

namespace CSharpScript.Game.Module.SlidingBlocks
{
	// Token: 0x02004F09 RID: 20233
	public static class SlidingBlocksDefine_ERemoveMinoReasonExtensions
	{
		// Token: 0x060344D3 RID: 214227 RVA: 0x00D15E7C File Offset: 0x00D1407C
		public static string ToEnumString(this SlidingBlocksDefine.ERemoveMinoReason value)
		{
			string result;
			if (value != SlidingBlocksDefine.ERemoveMinoReason.LineClearFall)
			{
				if (value != SlidingBlocksDefine.ERemoveMinoReason.LineClear)
				{
					result = value.ToString();
				}
				else
				{
					result = "LineClear";
				}
			}
			else
			{
				result = "LineClearFall";
			}
			return result;
		}

		// Token: 0x060344D4 RID: 214228 RVA: 0x00D15EB4 File Offset: 0x00D140B4
		public static SlidingBlocksDefine.ERemoveMinoReason FromString(string name)
		{
			SlidingBlocksDefine.ERemoveMinoReason result;
			if (!SlidingBlocksDefine_ERemoveMinoReasonExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 SlidingBlocksDefine.ERemoveMinoReason 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x060344D5 RID: 214229 RVA: 0x00D15EDD File Offset: 0x00D140DD
		public static bool TryFromString(string name, out SlidingBlocksDefine.ERemoveMinoReason value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = SlidingBlocksDefine.ERemoveMinoReason.LineClearFall;
				return false;
			}
			if (name == "LineClearFall")
			{
				value = SlidingBlocksDefine.ERemoveMinoReason.LineClearFall;
				return true;
			}
			if (!(name == "LineClear"))
			{
				value = SlidingBlocksDefine.ERemoveMinoReason.LineClearFall;
				return false;
			}
			value = SlidingBlocksDefine.ERemoveMinoReason.LineClear;
			return true;
		}

		// Token: 0x060344D6 RID: 214230 RVA: 0x00D15F16 File Offset: 0x00D14116
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"LineClearFall",
				"LineClear"
			};
		}

		// Token: 0x060344D7 RID: 214231 RVA: 0x00D15F2E File Offset: 0x00D1412E
		public static SlidingBlocksDefine.ERemoveMinoReason[] GetValues()
		{
			return new SlidingBlocksDefine.ERemoveMinoReason[]
			{
				SlidingBlocksDefine.ERemoveMinoReason.LineClearFall,
				SlidingBlocksDefine.ERemoveMinoReason.LineClear
			};
		}

		// Token: 0x060344D8 RID: 214232 RVA: 0x00D15F3A File Offset: 0x00D1413A
		public static string[] GetNames()
		{
			return new string[]
			{
				"LineClearFall",
				"LineClear"
			};
		}
	}
}
