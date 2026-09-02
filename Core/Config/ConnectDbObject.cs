using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Core.Config
{
	// Token: 0x02007146 RID: 28998
	[NullableContext(1)]
	[Nullable(0)]
	public class ConnectDbObject : IStaticVariableResetter
	{
		// Token: 0x06046357 RID: 287575 RVA: 0x01270FDB File Offset: 0x0126F1DB
		static ConnectDbObject()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(ConnectDbObject.CreateStaticDefaultValue), new Action(ConnectDbObject.ResetStaticDefaultValue));
		}

		// Token: 0x06046358 RID: 287576 RVA: 0x01270FFA File Offset: 0x0126F1FA
		private static string GetProjectContentDir()
		{
			if (string.IsNullOrEmpty(ConnectDbObject.ProjectContentDir))
			{
				ConnectDbObject.ProjectContentDir = UBlueprintPathsLibrary.ProjectContentDir();
			}
			return ConnectDbObject.ProjectContentDir;
		}

		// Token: 0x1700A5FD RID: 42493
		// (get) Token: 0x06046359 RID: 287577 RVA: 0x01271017 File Offset: 0x0126F217
		public int HandleId
		{
			get
			{
				return this.HandleIdInternal;
			}
		}

		// Token: 0x0604635A RID: 287578 RVA: 0x01271020 File Offset: 0x0126F220
		private unsafe int CreateDbConnection(string dbPath, string command)
		{
			int num = ConfigStatementLibSync.CreateStatement(dbPath, command);
			if (num != -2)
			{
				if (num == -1)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.CommonDbConnect;
					ELogAuthor author = ELogAuthor.XXJ;
					string message = "找不到Db连接";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", dbPath);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
			}
			else
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.CommonDbConnect;
				ELogAuthor author2 = ELogAuthor.XXJ;
				string message2 = "创建语句失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("path", dbPath);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("command", command);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			return num;
		}

		// Token: 0x0604635B RID: 287579 RVA: 0x012710BB File Offset: 0x0126F2BB
		public void DisConnectStatement()
		{
			if (this.HandleIdInternal > 0)
			{
				UKuroPrepareStatementLib.CloseConnection(this.HandleIdInternal);
			}
		}

		// Token: 0x0604635C RID: 287580 RVA: 0x012710D4 File Offset: 0x0126F2D4
		public void ConnectStatement(CommonDbData dbData)
		{
			if (!string.IsNullOrEmpty(dbData.Culture))
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 3);
				defaultInterpolatedStringHandler.AppendFormatted(ConnectDbObject.GetProjectContentDir());
				defaultInterpolatedStringHandler.AppendLiteral("Aki/ConfigDB/");
				defaultInterpolatedStringHandler.AppendFormatted(dbData.Culture);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted(dbData.DbName);
				string dbPath = defaultInterpolatedStringHandler.ToStringAndClear();
				this.HandleIdInternal = this.CreateDbConnection(dbPath, dbData.Command);
				return;
			}
			string dbPath2 = ConnectDbObject.GetProjectContentDir() + "Aki/ConfigDB/" + dbData.DbName;
			this.HandleIdInternal = this.CreateDbConnection(dbPath2, dbData.Command);
		}

		// Token: 0x0604635D RID: 287581 RVA: 0x0127117B File Offset: 0x0126F37B
		public static void CreateStaticDefaultValue()
		{
			ConnectDbObject.ProjectContentDir = null;
		}

		// Token: 0x0604635E RID: 287582 RVA: 0x01271183 File Offset: 0x0126F383
		public static void ResetStaticDefaultValue()
		{
			ConnectDbObject.ProjectContentDir = null;
		}

		// Token: 0x040275BB RID: 161211
		[Nullable(2)]
		private static string ProjectContentDir;

		// Token: 0x040275BC RID: 161212
		private int HandleIdInternal;
	}
}
