using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Extensions;
using CSharpScript.Typing;
using Google.FlatBuffers;
using UnrealEngine;

namespace CSharpScript.Launcher.Define.SimpleTabel
{
	// Token: 0x0200466C RID: 18028
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class TableReader<[Nullable(0)] T> where T : TableBaseRow
	{
		// Token: 0x0602F013 RID: 192531
		protected abstract string GetTableName();

		// Token: 0x0602F014 RID: 192532
		protected abstract string GetDbFile();

		// Token: 0x0602F015 RID: 192533
		protected abstract string GetIdString();

		// Token: 0x0602F016 RID: 192534 RVA: 0x00B22912 File Offset: 0x00B20B12
		private string GetDbPath()
		{
			return KuroApplication.ProjectContentDir() + "Aki/ConfigDB/" + this.GetDbFile();
		}

		// Token: 0x0602F017 RID: 192535 RVA: 0x00B22929 File Offset: 0x00B20B29
		[NullableContext(2)]
		public T GetById([Nullable(new byte[]
		{
			0,
			1
		})] OneOf<int, string> id)
		{
			if (this.RowMap.ContainsKey(id))
			{
				return this.RowMap[id];
			}
			return this.LoadFromDbById(id);
		}

		// Token: 0x0602F018 RID: 192536 RVA: 0x00B22958 File Offset: 0x00B20B58
		[NullableContext(2)]
		protected T LoadFromDbById([Nullable(new byte[]
		{
			0,
			1
		})] OneOf<int, string> id)
		{
			string text = id.IsT1 ? id.AsT1.ToString() : id.AsT2;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 3);
			defaultInterpolatedStringHandler.AppendLiteral("SELECT BinData FROM `");
			defaultInterpolatedStringHandler.AppendFormatted(this.GetTableName());
			defaultInterpolatedStringHandler.AppendLiteral("` WHERE ");
			defaultInterpolatedStringHandler.AppendFormatted(this.GetIdString());
			defaultInterpolatedStringHandler.AppendLiteral("=");
			defaultInterpolatedStringHandler.AppendFormatted(text);
			string sql = defaultInterpolatedStringHandler.ToStringAndClear();
			UKuroSqliteResultSet ukuroSqliteResultSet = new UKuroSqliteResultSet();
			T t;
			try
			{
				if (!UKuroSqliteLibrary.Query(this.GetDbPath(), sql, ukuroSqliteResultSet) || !ukuroSqliteResultSet.HasValue())
				{
					LauncherLog instance = Singleton<LauncherLog>.Instance;
					string message = "查询" + this.GetTableName() + "失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", text);
					instance.Warn(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					t = default(T);
					t = t;
				}
				else
				{
					FArrayBuffer farrayBuffer = default(FArrayBuffer);
					if (!ukuroSqliteResultSet.GetBytes("BinData", ref farrayBuffer))
					{
						Singleton<LauncherLog>.Instance.Error("获取" + this.GetTableName() + "数据字段失败，没有BinData字段", default(ReadOnlySpan<ValueTuple<string, object>>));
						t = default(T);
					}
					else if (farrayBuffer.Length == 0UL)
					{
						t = default(T);
					}
					else
					{
						T t2 = this.Parse(new ByteBuffer(farrayBuffer.ToByteArray()));
						if (t2 != null)
						{
							this.RowMap[id] = t2;
						}
						t = t2;
					}
				}
			}
			finally
			{
				ukuroSqliteResultSet.Release();
			}
			return t;
		}

		// Token: 0x0602F019 RID: 192537 RVA: 0x00B22AF4 File Offset: 0x00B20CF4
		protected List<T> LoadFromDb()
		{
			string sql = "SELECT BinData FROM `" + this.GetTableName() + "`";
			UKuroSqliteResultSet ukuroSqliteResultSet = new UKuroSqliteResultSet();
			List<T> result;
			try
			{
				if (!UKuroSqliteLibrary.Query(this.GetDbPath(), sql, ukuroSqliteResultSet) || !ukuroSqliteResultSet.HasValue())
				{
					Singleton<LauncherLog>.Instance.Error("查询" + this.GetTableName() + "失败", default(ReadOnlySpan<ValueTuple<string, object>>));
					result = new List<T>();
				}
				else
				{
					List<T> list = new List<T>();
					for (;;)
					{
						FArrayBuffer farrayBuffer = default(FArrayBuffer);
						if (!ukuroSqliteResultSet.GetBytes("BinData", ref farrayBuffer))
						{
							break;
						}
						if (farrayBuffer.Length != 0UL)
						{
							T t = this.Parse(new ByteBuffer(farrayBuffer.ToByteArray()));
							if (t != null)
							{
								list.Add(t);
								this.RowMap[t.GetId()] = t;
							}
						}
						if (!ukuroSqliteResultSet.MoveToNext())
						{
							goto Block_7;
						}
					}
					Singleton<LauncherLog>.Instance.Error("获取" + this.GetTableName() + "数据字段失败，没有BinData字段", default(ReadOnlySpan<ValueTuple<string, object>>));
					return new List<T>();
					Block_7:
					result = list;
				}
			}
			finally
			{
				ukuroSqliteResultSet.Release();
			}
			return result;
		}

		// Token: 0x0602F01A RID: 192538
		public abstract T Parse(ByteBuffer byteBuffer);

		// Token: 0x0602F01B RID: 192539 RVA: 0x00B22C28 File Offset: 0x00B20E28
		public List<T> GetAll()
		{
			if (this.Rows.Count == 0)
			{
				this.Rows = this.LoadFromDb();
			}
			return this.Rows;
		}

		// Token: 0x0401AC4B RID: 109643
		protected List<T> Rows = new List<T>();

		// Token: 0x0401AC4C RID: 109644
		protected Dictionary<object, T> RowMap = new Dictionary<object, T>();
	}
}
