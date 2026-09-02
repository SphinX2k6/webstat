using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Define
{
	// Token: 0x0200465B RID: 18011
	[NullableContext(1)]
	[Nullable(0)]
	public class LauncherDownLoadConfig
	{
		// Token: 0x170080AE RID: 32942
		// (get) Token: 0x0602EFCE RID: 192462 RVA: 0x00B221B6 File Offset: 0x00B203B6
		public string Title { get; }

		// Token: 0x170080AF RID: 32943
		// (get) Token: 0x0602EFCF RID: 192463 RVA: 0x00B221BE File Offset: 0x00B203BE
		public string ContentTitle { get; }

		// Token: 0x170080B0 RID: 32944
		// (get) Token: 0x0602EFD0 RID: 192464 RVA: 0x00B221C6 File Offset: 0x00B203C6
		public string Content { get; }

		// Token: 0x0602EFD1 RID: 192465 RVA: 0x00B221CE File Offset: 0x00B203CE
		public LauncherDownLoadConfig(string title, string contentTitle, string content)
		{
			this.Title = title;
			this.ContentTitle = contentTitle;
			this.Content = content;
		}

		// Token: 0x0602EFD2 RID: 192466 RVA: 0x00B221EB File Offset: 0x00B203EB
		public static string GetTableName()
		{
			return "DownLoadTab";
		}

		// Token: 0x0602EFD3 RID: 192467 RVA: 0x00B221F4 File Offset: 0x00B203F4
		public static LauncherDownLoadConfig Parse(UKuroSqliteResultSet rs)
		{
			string title = null;
			if (!rs.GetString("Title", ref title))
			{
				return null;
			}
			string contentTitle = null;
			if (!rs.GetString("ContentTitle", ref contentTitle))
			{
				return null;
			}
			string content = null;
			if (!rs.GetString("Content", ref content))
			{
				return null;
			}
			return new LauncherDownLoadConfig(title, contentTitle, content);
		}

		// Token: 0x0401AC03 RID: 109571
		private const string TableName = "DownLoadTab";
	}
}
