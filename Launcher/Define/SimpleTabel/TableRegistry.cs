using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Define.SimpleTabel
{
	// Token: 0x0200466E RID: 18030
	public class TableRegistry : IStaticVariableResetter
	{
		// Token: 0x0602F01F RID: 192543 RVA: 0x00B22C6F File Offset: 0x00B20E6F
		static TableRegistry()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(TableRegistry.CreateStaticDefaultValue), new Action(TableRegistry.ResetStaticDefaultValue));
		}

		// Token: 0x0602F020 RID: 192544 RVA: 0x00B22C90 File Offset: 0x00B20E90
		[NullableContext(1)]
		public static void Register<[Nullable(0)] TRow>(string name, Func<TableReader<TRow>> tableClass) where TRow : TableBaseRow
		{
			if (TableRegistry.TableMap.ContainsKey(name))
			{
				Singleton<LauncherLog>.Instance.Warn("TableRegistry: 表 " + name + " 已经注册过了", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			TableReader<TRow> value = tableClass();
			TableRegistry.TableMap[name] = value;
		}

		// Token: 0x0602F021 RID: 192545 RVA: 0x00B22CE1 File Offset: 0x00B20EE1
		public static void CreateStaticDefaultValue()
		{
			TableRegistry.TableMap = new Dictionary<string, object>();
		}

		// Token: 0x0602F022 RID: 192546 RVA: 0x00B22CED File Offset: 0x00B20EED
		public static void ResetStaticDefaultValue()
		{
			TableRegistry.TableMap = null;
		}

		// Token: 0x0401AC4D RID: 109645
		[Nullable(1)]
		private static Dictionary<string, object> TableMap;
	}
}
