using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A27 RID: 18983
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class InputExtraShowCursorCenter : Singleton<InputExtraShowCursorCenter>
	{
		// Token: 0x06031995 RID: 203157 RVA: 0x00C5B524 File Offset: 0x00C59724
		public void RegisterExtraRefreshData(string tag, IExtraShowCursor data)
		{
			this.ExtraShowCursorDataMap[tag] = data;
			Singleton<EventSystem>.Instance.Emit(EEventName.RefreshCursor);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Input;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "注册额外的显示鼠标数据";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Tag", tag);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x06031996 RID: 203158 RVA: 0x00C5B578 File Offset: 0x00C59778
		public void UnRegisterExtraRefreshData(string tag)
		{
			this.ExtraShowCursorDataMap.Remove(tag);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Input;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "注销额外的显示鼠标数据";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Tag", tag);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x06031997 RID: 203159 RVA: 0x00C5B5BC File Offset: 0x00C597BC
		public bool CheckShowCursorData()
		{
			using (Dictionary<string, IExtraShowCursor>.ValueCollection.Enumerator enumerator = this.ExtraShowCursorDataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsShowCursor())
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06031998 RID: 203160 RVA: 0x00C5B61C File Offset: 0x00C5981C
		public bool HasExtraShowCursorData()
		{
			return this.ExtraShowCursorDataMap.Count > 0;
		}

		// Token: 0x0401CE10 RID: 118288
		private readonly Dictionary<string, IExtraShowCursor> ExtraShowCursorDataMap = new Dictionary<string, IExtraShowCursor>();
	}
}
