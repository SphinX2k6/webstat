using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.DiffPatch.Data
{
	// Token: 0x0200464D RID: 17997
	[NullableContext(1)]
	[Nullable(0)]
	public class DestFileInfo : LocalFileInfo
	{
		// Token: 0x0602EF78 RID: 192376 RVA: 0x00B20F32 File Offset: 0x00B1F132
		public DestFileInfo(string keyName, string filePath, long expectSize, string remoteRoute, string expectHash) : base(keyName, filePath, expectSize)
		{
			this.RemoteRoute = remoteRoute;
			this.ExpectHash = expectHash;
			if (this.ExpectSize <= 0L)
			{
				throw new Exception("the new resource file size is unknown! file:{this.KeyName}");
			}
		}

		// Token: 0x0602EF79 RID: 192377 RVA: 0x00B20F64 File Offset: 0x00B1F164
		[NullableContext(0)]
		private ValueTuple<long, long> GetBothSize()
		{
			long num = UKuroLauncherLibrary.GetFileSize(this.FilePath);
			long num2 = -1L;
			string text = this.FilePath + ".download";
			if (num >= 0L)
			{
				if (UBlueprintPathsLibrary.FileExists(text))
				{
					LauncherLog instance = Singleton<LauncherLog>.Instance;
					string message = "delete local tmp file. both exist it and tmp.";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("file", this.KeyName);
					instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					UKuroLauncherLibrary.DeleteFile(text);
				}
				if (num > this.ExpectSize)
				{
					LauncherLog instance2 = Singleton<LauncherLog>.Instance;
					string message2 = "delete local file. size > expect";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("file", this.KeyName);
					instance2.Info(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					UKuroLauncherLibrary.DeleteFile(this.FilePath);
					num = -1L;
				}
			}
			else
			{
				num2 = UKuroLauncherLibrary.GetFileSize(text);
				if (num2 > this.ExpectSize)
				{
					LauncherLog instance3 = Singleton<LauncherLog>.Instance;
					string message3 = "delete local tmp file. size > expect";
					ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("path", text);
					instance3.Info(message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
					UKuroLauncherLibrary.DeleteFile(text);
					num2 = -1L;
				}
			}
			return new ValueTuple<long, long>(num, num2);
		}

		// Token: 0x0602EF7A RID: 192378 RVA: 0x00B21054 File Offset: 0x00B1F254
		public override long GetSelfSize()
		{
			long item = this.GetBothSize().Item1;
			if (item < 0L)
			{
				return 0L;
			}
			return item;
		}

		// Token: 0x0602EF7B RID: 192379 RVA: 0x00B21078 File Offset: 0x00B1F278
		public override long GetLocalSize()
		{
			ValueTuple<long, long> bothSize = this.GetBothSize();
			long item = bothSize.Item1;
			long item2 = bothSize.Item2;
			if (item >= 0L)
			{
				return item;
			}
			if (item2 < 0L)
			{
				return 0L;
			}
			return item2;
		}

		// Token: 0x0602EF7C RID: 192380 RVA: 0x00B210A8 File Offset: 0x00B1F2A8
		public unsafe override bool IsCompleteFile()
		{
			long item = this.GetBothSize().Item1;
			bool flag = this.ExpectSize == item;
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "is complete file?";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("complete", flag);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("file", this.KeyName);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return flag;
		}

		// Token: 0x0602EF7D RID: 192381 RVA: 0x00B21125 File Offset: 0x00B1F325
		public override void DeleteAll()
		{
			LauncherFileLib.RemoveDownloadFile(this.FilePath);
		}

		// Token: 0x0602EF7E RID: 192382 RVA: 0x00B21132 File Offset: 0x00B1F332
		public override string GetHash()
		{
			return this.ExpectHash;
		}

		// Token: 0x0602EF7F RID: 192383 RVA: 0x00B2113A File Offset: 0x00B1F33A
		public override RequireFileInfo GetRequireInfo()
		{
			return new RequireFileInfo(this.RemoteRoute, this.FilePath, this.ExpectSize, this.ExpectHash);
		}

		// Token: 0x0401ABC0 RID: 109504
		public readonly string RemoteRoute;

		// Token: 0x0401ABC1 RID: 109505
		public readonly string ExpectHash;
	}
}
