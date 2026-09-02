using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Extensions;
using CSharpScript.Typing;
using Google.FlatBuffers;
using UnrealEngine;

namespace CSharpScript.Launcher.Define.SimpleTabel
{
	// Token: 0x0200466F RID: 18031
	[NullableContext(1)]
	[Nullable(0)]
	public class TableReaderUtil : IStaticVariableResetter
	{
		// Token: 0x0602F024 RID: 192548 RVA: 0x00B22CFD File Offset: 0x00B20EFD
		static TableReaderUtil()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(TableReaderUtil.CreateStaticDefaultValue), new Action(TableReaderUtil.ResetStaticDefaultValue));
		}

		// Token: 0x0602F025 RID: 192549 RVA: 0x00B22D1C File Offset: 0x00B20F1C
		[NullableContext(0)]
		[return: Nullable(new byte[]
		{
			1,
			0
		})]
		public static T[] ReadArray<T>(int fieldOffset, [Nullable(1)] ByteBuffer byteBuffer, int bbPos, [Nullable(new byte[]
		{
			1,
			1,
			0
		})] Func<ByteBuffer, int, T> readItemFunc) where T : struct
		{
			Table table = new Table(bbPos, byteBuffer);
			return table.__vector_as_array<T>(fieldOffset) ?? Array.Empty<T>();
		}

		// Token: 0x0602F026 RID: 192550 RVA: 0x00B22D44 File Offset: 0x00B20F44
		public static int GetIntFromCommonConfig(string key, int defaultValue)
		{
			string dbPath = KuroApplication.ProjectContentDir() + "Aki/ConfigDB/db_common_param.db";
			UKuroSqliteResultSet ukuroSqliteResultSet = new UKuroSqliteResultSet();
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(41, 2);
			defaultInterpolatedStringHandler.AppendLiteral("select BinData from `");
			defaultInterpolatedStringHandler.AppendFormatted("CommonParam");
			defaultInterpolatedStringHandler.AppendLiteral("` where KeyName = '");
			defaultInterpolatedStringHandler.AppendFormatted(key);
			defaultInterpolatedStringHandler.AppendLiteral("'");
			string sql = defaultInterpolatedStringHandler.ToStringAndClear();
			int result;
			try
			{
				if (!UKuroSqliteLibrary.Query(dbPath, sql, ukuroSqliteResultSet) || !ukuroSqliteResultSet.HasValue())
				{
					LauncherLog instance = Singleton<LauncherLog>.Instance;
					string message = "查询CommonParam失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("key", key);
					instance.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					result = defaultValue;
				}
				else
				{
					FArrayBuffer farrayBuffer = default(FArrayBuffer);
					if (!ukuroSqliteResultSet.GetBytes("BinData", ref farrayBuffer))
					{
						Singleton<LauncherLog>.Instance.Error("获取CommonParam数据字段失败，没有BinData字段", default(ReadOnlySpan<ValueTuple<string, object>>));
						result = defaultValue;
					}
					else if (farrayBuffer.Length < 4UL)
					{
						result = defaultValue;
					}
					else
					{
						result = BitConverter.ToInt32(farrayBuffer.ToByteArray(), 0);
					}
				}
			}
			finally
			{
				ukuroSqliteResultSet.Release();
			}
			return result;
		}

		// Token: 0x0602F027 RID: 192551 RVA: 0x00B22E5C File Offset: 0x00B2105C
		public static void CreateStaticDefaultValue()
		{
			TableReaderUtil.ArrayCapacityObject = new Dictionary<int, int>();
			TableReaderUtil.ArrayElementInitFunc = (() => 0);
		}

		// Token: 0x0602F028 RID: 192552 RVA: 0x00B22E8C File Offset: 0x00B2108C
		public static void ResetStaticDefaultValue()
		{
			TableReaderUtil.ArrayCapacityObject = null;
			TableReaderUtil.ArrayElementInitFunc = null;
		}

		// Token: 0x0401AC4E RID: 109646
		private static Dictionary<int, int> ArrayCapacityObject;

		// Token: 0x0401AC4F RID: 109647
		private static Func<object> ArrayElementInitFunc;

		// Token: 0x0401AC50 RID: 109648
		private const string CommonConfigDb = "db_common_param.db";

		// Token: 0x0401AC51 RID: 109649
		private const string CommonConfigTableName = "CommonParam";
	}
}
