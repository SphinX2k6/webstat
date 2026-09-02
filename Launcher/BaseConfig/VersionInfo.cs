using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.BaseConfig
{
	// Token: 0x0200468E RID: 18062
	[NullableContext(1)]
	[Nullable(0)]
	public class VersionInfo
	{
		// Token: 0x0602F075 RID: 192629 RVA: 0x00B24BEF File Offset: 0x00B22DEF
		private VersionInfo(int major, int minor, int patch)
		{
			this.MajVer = major;
			this.MinVer = minor;
			this.PatVer = patch;
		}

		// Token: 0x170080BB RID: 32955
		// (get) Token: 0x0602F076 RID: 192630 RVA: 0x00B24C0C File Offset: 0x00B22E0C
		public int Major
		{
			get
			{
				return this.MajVer;
			}
		}

		// Token: 0x170080BC RID: 32956
		// (get) Token: 0x0602F077 RID: 192631 RVA: 0x00B24C14 File Offset: 0x00B22E14
		public int Minor
		{
			get
			{
				return this.MinVer;
			}
		}

		// Token: 0x170080BD RID: 32957
		// (get) Token: 0x0602F078 RID: 192632 RVA: 0x00B24C1C File Offset: 0x00B22E1C
		public int Patch
		{
			get
			{
				return this.PatVer;
			}
		}

		// Token: 0x0602F079 RID: 192633 RVA: 0x00B24C24 File Offset: 0x00B22E24
		public string ToString(int num = 3)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
			if (num == 1)
			{
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.MajVer);
				return defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (num == 2)
			{
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.MajVer);
				defaultInterpolatedStringHandler.AppendLiteral(".");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.MinVer);
				return defaultInterpolatedStringHandler.ToStringAndClear();
			}
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.MajVer);
			defaultInterpolatedStringHandler.AppendLiteral(".");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.MinVer);
			defaultInterpolatedStringHandler.AppendLiteral(".");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.PatVer);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0602F07A RID: 192634 RVA: 0x00B24CE0 File Offset: 0x00B22EE0
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public static ValueTuple<bool, VersionInfo> TryParse(string version)
		{
			if (string.IsNullOrEmpty(version) || version.Length <= 0)
			{
				return new ValueTuple<bool, VersionInfo>(false, null);
			}
			string[] array = version.Split('.', StringSplitOptions.None);
			if (array.Length < 3)
			{
				return new ValueTuple<bool, VersionInfo>(false, null);
			}
			int major;
			int minor;
			int patch;
			if (!int.TryParse(array[0], out major) || !int.TryParse(array[1], out minor) || !int.TryParse(array[2], out patch))
			{
				return new ValueTuple<bool, VersionInfo>(false, null);
			}
			return new ValueTuple<bool, VersionInfo>(true, new VersionInfo(major, minor, patch));
		}

		// Token: 0x0602F07B RID: 192635 RVA: 0x00B24D58 File Offset: 0x00B22F58
		[NullableContext(2)]
		public static bool PackageEquals(VersionInfo a, VersionInfo b)
		{
			return a != null && b != null && a.MajVer == b.MajVer && a.MinVer == b.MinVer;
		}

		// Token: 0x0602F07C RID: 192636 RVA: 0x00B24D7E File Offset: 0x00B22F7E
		[NullableContext(2)]
		public static bool Equals(VersionInfo a, VersionInfo b)
		{
			return a != null && b != null && a.MajVer == b.MajVer && a.MinVer == b.MinVer && a.PatVer == b.PatVer;
		}

		// Token: 0x0602F07D RID: 192637 RVA: 0x00B24DB4 File Offset: 0x00B22FB4
		public static bool LessThanOrEqual(VersionInfo a, VersionInfo b)
		{
			return a.MajVer < b.MajVer || (a.MajVer <= b.MajVer && (a.MinVer < b.MinVer || (a.MinVer <= b.MinVer && a.PatVer <= b.PatVer)));
		}

		// Token: 0x0401ACD8 RID: 109784
		private readonly int MajVer;

		// Token: 0x0401ACD9 RID: 109785
		private readonly int MinVer;

		// Token: 0x0401ACDA RID: 109786
		private readonly int PatVer;
	}
}
