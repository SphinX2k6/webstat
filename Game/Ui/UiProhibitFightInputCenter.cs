using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A11 RID: 18961
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class UiProhibitFightInputCenter : Singleton<UiProhibitFightInputCenter>
	{
		// Token: 0x060318EB RID: 202987 RVA: 0x00C59F70 File Offset: 0x00C58170
		public void RegisterExtraRefreshData(string tag, IUiProhibitRefreshData data)
		{
			this.ExtraUiProhibitRefreshDataMap[tag] = data;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Input;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "注册禁止战斗输入额外的输入刷新数据";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Tag", tag);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x060318EC RID: 202988 RVA: 0x00C59FB4 File Offset: 0x00C581B4
		public void UnRegisterExtraRefreshData(string tag)
		{
			this.ExtraUiProhibitRefreshDataMap.Remove(tag);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Input;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "注销禁止战斗输入额外的输入刷新数据";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Tag", tag);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x060318ED RID: 202989 RVA: 0x00C59FF8 File Offset: 0x00C581F8
		public string CheckExtraRefreshData()
		{
			foreach (KeyValuePair<string, IUiProhibitRefreshData> keyValuePair in this.ExtraUiProhibitRefreshDataMap)
			{
				string key = keyValuePair.Key;
				if (keyValuePair.Value.CheckCondition())
				{
					return key;
				}
			}
			return "";
		}

		// Token: 0x060318EE RID: 202990 RVA: 0x00C5A068 File Offset: 0x00C58268
		[return: Nullable(2)]
		public IUiProhibitRefreshData GetExtraRefreshData(string tag)
		{
			IUiProhibitRefreshData result;
			if (this.ExtraUiProhibitRefreshDataMap.TryGetValue(tag, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x0401CDCA RID: 118218
		private readonly Dictionary<string, IUiProhibitRefreshData> ExtraUiProhibitRefreshDataMap = new Dictionary<string, IUiProhibitRefreshData>();
	}
}
