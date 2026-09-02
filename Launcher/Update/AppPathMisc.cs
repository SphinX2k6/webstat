using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Platform;
using CSharpScript.Typing;
using UnrealEngine;

namespace CSharpScript.Launcher.Update
{
	// Token: 0x020044BA RID: 17594
	[NullableContext(1)]
	[Nullable(0)]
	public class AppPathMisc
	{
		// Token: 0x0602E6F6 RID: 190198 RVA: 0x00AFDD8A File Offset: 0x00AFBF8A
		public string GetPatchSaveDir()
		{
			if (string.IsNullOrEmpty(this.SaveDir))
			{
				this.SaveDir = UKuroLauncherLibrary.GameSavedDir() + "Resources/";
			}
			return this.SaveDir;
		}

		// Token: 0x0602E6F7 RID: 190199 RVA: 0x00AFDDB4 File Offset: 0x00AFBFB4
		public string GetPlatform()
		{
			if (string.IsNullOrEmpty(this.Platform))
			{
				this.Platform = KuroApplication.IniPlatformNameIncludeEditor();
			}
			return this.Platform;
		}

		// Token: 0x0602E6F8 RID: 190200 RVA: 0x00AFDDD4 File Offset: 0x00AFBFD4
		public string GetInternalUseType()
		{
			if (string.IsNullOrEmpty(this.InternalUse))
			{
				this.InternalUse = UKuroLauncherLibrary.GetAppInternalUseType();
			}
			return this.InternalUse;
		}

		// Token: 0x0602E6F9 RID: 190201 RVA: 0x00AFDDF4 File Offset: 0x00AFBFF4
		public string GetManifestRoute(string resUri, string latestVersion, string manifestName)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 4);
			defaultInterpolatedStringHandler.AppendFormatted(resUri);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(this.GetPlatform());
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(latestVersion);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(manifestName);
			defaultInterpolatedStringHandler.AppendLiteral(".txt");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0602E6FA RID: 190202 RVA: 0x00AFDE68 File Offset: 0x00AFC068
		public string GetResFileRoute(string resUri, string latestVersion, string fileName)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 4);
			defaultInterpolatedStringHandler.AppendFormatted(resUri);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(this.GetPlatform());
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(latestVersion);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(fileName);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0602E6FB RID: 190203 RVA: 0x00AFDED0 File Offset: 0x00AFC0D0
		public string GetManifestPath(string packageVersion, string latestVersion, string manifestName)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 4);
			defaultInterpolatedStringHandler.AppendFormatted(this.GetPatchSaveDir());
			defaultInterpolatedStringHandler.AppendFormatted(packageVersion);
			defaultInterpolatedStringHandler.AppendLiteral("/ResManifest/");
			defaultInterpolatedStringHandler.AppendFormatted(manifestName);
			defaultInterpolatedStringHandler.AppendLiteral("_");
			defaultInterpolatedStringHandler.AppendFormatted(latestVersion);
			defaultInterpolatedStringHandler.AppendLiteral(".txt");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0602E6FC RID: 190204 RVA: 0x00AFDF37 File Offset: 0x00AFC137
		public string GetResFilePath(string packageVersion, string patchVersion, string resType, string fileName)
		{
			return this.GetResFileDir(packageVersion, patchVersion, resType) + fileName;
		}

		// Token: 0x0602E6FD RID: 190205 RVA: 0x00AFDF4C File Offset: 0x00AFC14C
		public string GetResFileDir(string packageVersion, string patchVersion, string resType)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 4);
			defaultInterpolatedStringHandler.AppendFormatted(this.GetPatchSaveDir());
			defaultInterpolatedStringHandler.AppendFormatted(packageVersion);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(resType);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(patchVersion);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			string text = defaultInterpolatedStringHandler.ToStringAndClear();
			if (!Singleton<CSharpScript.Launcher.Platform.Platform>.Instance.IsPs5Platform())
			{
				return text;
			}
			return text.ToLower();
		}

		// Token: 0x0602E6FE RID: 190206 RVA: 0x00AFDFC7 File Offset: 0x00AFC1C7
		public string GetMountManifestPath(string packageVersion, string mountFileName)
		{
			return this.GetPatchSaveDir() + packageVersion + "/Mount/" + mountFileName;
		}

		// Token: 0x0602E6FF RID: 190207 RVA: 0x00AFDFDC File Offset: 0x00AFC1DC
		public string GetDiffFilePath(string packageVersion, string latestVersion, string resType, string fileName)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 5);
			defaultInterpolatedStringHandler.AppendFormatted(this.GetPatchSaveDir());
			defaultInterpolatedStringHandler.AppendFormatted(packageVersion);
			defaultInterpolatedStringHandler.AppendLiteral("/Diff/");
			defaultInterpolatedStringHandler.AppendFormatted(resType);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(latestVersion);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(fileName);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0602E700 RID: 190208 RVA: 0x00AFE04C File Offset: 0x00AFC24C
		[NullableContext(0)]
		public ValueTuple<long, long> GetTotalAndFreeSpace([Nullable(1)] string dirPath)
		{
			long item = 0L;
			return new ValueTuple<long, long>(UKuroLauncherLibrary.GetTotalAndFreeSpace(dirPath, ref item), item);
		}

		// Token: 0x0401A5F3 RID: 108019
		private string SaveDir = "";

		// Token: 0x0401A5F4 RID: 108020
		private string Platform = "";

		// Token: 0x0401A5F5 RID: 108021
		private string InternalUse = "";
	}
}
