using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.QuickTimeAction
{
	// Token: 0x020052B4 RID: 21172
	public class QtaActionNames
	{
		// Token: 0x060361E1 RID: 221665 RVA: 0x00DA0B64 File Offset: 0x00D9ED64
		private static void InitQtaActionNames()
		{
			if (QtaActionNames.QtaActionsCache.Count == 0)
			{
				IReadOnlyList<QteInputActionMapping> configList = ConfigQteInputActionMappingAll.GetConfigList(true);
				if (configList != null)
				{
					foreach (QteInputActionMapping qteInputActionMapping in configList)
					{
						while (QtaActionNames.QtaActionsCache.Count <= qteInputActionMapping.QteInputActionId)
						{
							QtaActionNames.QtaActionsCache.Add(null);
						}
						QtaActionNames.QtaActionsCache[qteInputActionMapping.QteInputActionId] = qteInputActionMapping.QteInputActionName;
					}
				}
			}
		}

		// Token: 0x060361E2 RID: 221666 RVA: 0x00DA0BF4 File Offset: 0x00D9EDF4
		public static bool Has(int index)
		{
			QtaActionNames.InitQtaActionNames();
			return index > 0 && index < QtaActionNames.QtaActionsCache.Count && !string.IsNullOrEmpty(QtaActionNames.QtaActionsCache[index]);
		}

		// Token: 0x060361E3 RID: 221667 RVA: 0x00DA0C24 File Offset: 0x00D9EE24
		[NullableContext(1)]
		public static string Get(int index)
		{
			QtaActionNames.InitQtaActionNames();
			if (index >= QtaActionNames.QtaActionsCache.Count || string.IsNullOrEmpty(QtaActionNames.QtaActionsCache[index]))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.HWR;
				string message = "[qta] 输入行为映射不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("index", index);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return string.Empty;
			}
			return QtaActionNames.QtaActionsCache[index] ?? string.Empty;
		}

		// Token: 0x0401F17D RID: 127357
		[Nullable(new byte[]
		{
			1,
			2
		})]
		[StaticVariableRuleIgnore]
		private static readonly List<string> QtaActionsCache = new List<string>();
	}
}
