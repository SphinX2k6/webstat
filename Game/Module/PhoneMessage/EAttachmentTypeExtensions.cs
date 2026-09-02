using System;

namespace CSharpScript.Game.Module.PhoneMessage
{
	// Token: 0x0200545C RID: 21596
	public static class EAttachmentTypeExtensions
	{
		// Token: 0x0603703B RID: 225339 RVA: 0x00DF6BF8 File Offset: 0x00DF4DF8
		public static string ToEnumString(this EAttachmentType value)
		{
			string result;
			switch (value)
			{
			case EAttachmentType.Image:
				result = "Image";
				break;
			case EAttachmentType.Spine:
				result = "Spine";
				break;
			case EAttachmentType.Mp4:
				result = "Mp4";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x0603703C RID: 225340 RVA: 0x00DF6C40 File Offset: 0x00DF4E40
		public static EAttachmentType FromString(string name)
		{
			EAttachmentType result;
			if (!EAttachmentTypeExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 EAttachmentType 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x0603703D RID: 225341 RVA: 0x00DF6C6C File Offset: 0x00DF4E6C
		public static bool TryFromString(string name, out EAttachmentType value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = EAttachmentType.Image;
				return false;
			}
			if (name == "Image")
			{
				value = EAttachmentType.Image;
				return true;
			}
			if (name == "Spine")
			{
				value = EAttachmentType.Spine;
				return true;
			}
			if (!(name == "Mp4"))
			{
				value = EAttachmentType.Image;
				return false;
			}
			value = EAttachmentType.Mp4;
			return true;
		}

		// Token: 0x0603703E RID: 225342 RVA: 0x00DF6CC2 File Offset: 0x00DF4EC2
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"Image",
				"Spine",
				"Mp4"
			};
		}

		// Token: 0x0603703F RID: 225343 RVA: 0x00DF6CE2 File Offset: 0x00DF4EE2
		public static EAttachmentType[] GetValues()
		{
			return new EAttachmentType[]
			{
				EAttachmentType.Image,
				EAttachmentType.Spine,
				EAttachmentType.Mp4
			};
		}

		// Token: 0x06037040 RID: 225344 RVA: 0x00DF6CF2 File Offset: 0x00DF4EF2
		public static string[] GetNames()
		{
			return new string[]
			{
				"Image",
				"Spine",
				"Mp4"
			};
		}
	}
}
