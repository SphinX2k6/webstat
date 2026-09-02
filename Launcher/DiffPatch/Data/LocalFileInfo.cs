using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.DiffPatch.Data
{
	// Token: 0x0200464C RID: 17996
	[NullableContext(1)]
	[Nullable(0)]
	public class LocalFileInfo
	{
		// Token: 0x0602EF70 RID: 192368 RVA: 0x00B20E2C File Offset: 0x00B1F02C
		public LocalFileInfo(string keyName, string filePath, long expectSize)
		{
			this.KeyName = keyName;
			this.FilePath = filePath;
			this.ExpectSize = expectSize;
			this.LocalSize = UKuroLauncherLibrary.GetFileSize(this.FilePath);
			this.IsChunk0or1 = ChunkTool.IsChunk0or1(this.FilePath);
			this.IsRestartRequiredAfterHotPatchChunk = ChunkTool.IsRestartRequiredAfterHotPatchChunk(this.FilePath);
		}

		// Token: 0x0602EF71 RID: 192369 RVA: 0x00B20E8F File Offset: 0x00B1F08F
		public virtual long GetSelfSize()
		{
			if (this.LocalSize < 0L)
			{
				return 0L;
			}
			return this.LocalSize;
		}

		// Token: 0x0602EF72 RID: 192370 RVA: 0x00B20EA4 File Offset: 0x00B1F0A4
		public virtual long GetLocalSize()
		{
			return this.GetSelfSize();
		}

		// Token: 0x0602EF73 RID: 192371 RVA: 0x00B20EAC File Offset: 0x00B1F0AC
		public virtual bool IsCompleteFile()
		{
			return this.ExpectSize <= 0L || (this.ExpectSize > 0L && this.LocalSize == this.ExpectSize);
		}

		// Token: 0x0602EF74 RID: 192372 RVA: 0x00B20ED4 File Offset: 0x00B1F0D4
		public void DeleteSelf()
		{
			if (UBlueprintPathsLibrary.FileExists(this.FilePath))
			{
				UKuroLauncherLibrary.DeleteFile(this.FilePath);
			}
		}

		// Token: 0x0602EF75 RID: 192373 RVA: 0x00B20EEF File Offset: 0x00B1F0EF
		public virtual void DeleteAll()
		{
			LauncherFileLib.RemoveDownloadFile(this.FilePath);
			this.LocalSize = -1L;
		}

		// Token: 0x0602EF76 RID: 192374 RVA: 0x00B20F04 File Offset: 0x00B1F104
		public virtual string GetHash()
		{
			throw new Exception("LocalFileInfo.GetHash is not implement. file:" + this.FilePath);
		}

		// Token: 0x0602EF77 RID: 192375 RVA: 0x00B20F1B File Offset: 0x00B1F11B
		public virtual RequireFileInfo GetRequireInfo()
		{
			throw new Exception("LocalFileInfo.GetRequireInfo is not implement. file:" + this.FilePath);
		}

		// Token: 0x0401ABBA RID: 109498
		private long LocalSize = -1L;

		// Token: 0x0401ABBB RID: 109499
		public readonly bool IsChunk0or1;

		// Token: 0x0401ABBC RID: 109500
		public readonly bool IsRestartRequiredAfterHotPatchChunk;

		// Token: 0x0401ABBD RID: 109501
		protected readonly string KeyName;

		// Token: 0x0401ABBE RID: 109502
		public readonly string FilePath;

		// Token: 0x0401ABBF RID: 109503
		public readonly long ExpectSize;
	}
}
