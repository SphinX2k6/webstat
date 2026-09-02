using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui.Common.HudOnlyPopup
{
	// Token: 0x02004A65 RID: 19045
	[NullableContext(1)]
	[Nullable(0)]
	public class HudOnlyPopupQueue
	{
		// Token: 0x1700848D RID: 33933
		// (get) Token: 0x06031BB3 RID: 203699 RVA: 0x00C73CCB File Offset: 0x00C71ECB
		public bool IsEmpty
		{
			get
			{
				return this.Tasks.Count == 0;
			}
		}

		// Token: 0x1700848E RID: 33934
		// (get) Token: 0x06031BB4 RID: 203700 RVA: 0x00C73CDB File Offset: 0x00C71EDB
		public int Length
		{
			get
			{
				return this.Tasks.Count;
			}
		}

		// Token: 0x06031BB5 RID: 203701 RVA: 0x00C73CE8 File Offset: 0x00C71EE8
		public unsafe void Push(HudOnlyPopupTask task)
		{
			if (task.DedupKey != null && this.HasKey(task.DedupKey))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiCommon;
				ELogAuthor author = ELogAuthor.SYB;
				string message = "[HudOnlyPopup] 重复任务跳过";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ViewName", task.ViewName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("DedupKey", task.DedupKey);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			this.Tasks.Add(task);
		}

		// Token: 0x06031BB6 RID: 203702 RVA: 0x00C73D7A File Offset: 0x00C71F7A
		[NullableContext(2)]
		public HudOnlyPopupTask Shift()
		{
			if (this.Tasks.Count == 0)
			{
				return null;
			}
			HudOnlyPopupTask result = this.Tasks[0];
			this.Tasks.RemoveAt(0);
			return result;
		}

		// Token: 0x06031BB7 RID: 203703 RVA: 0x00C73DA4 File Offset: 0x00C71FA4
		public bool RemoveByKey(string dedupKey)
		{
			for (int i = 0; i < this.Tasks.Count; i++)
			{
				if (this.Tasks[i].DedupKey == dedupKey)
				{
					this.Tasks.RemoveAt(i);
					return true;
				}
			}
			return false;
		}

		// Token: 0x06031BB8 RID: 203704 RVA: 0x00C73DEF File Offset: 0x00C71FEF
		public void Clear()
		{
			this.Tasks.Clear();
		}

		// Token: 0x06031BB9 RID: 203705 RVA: 0x00C73DFC File Offset: 0x00C71FFC
		private bool HasKey(string dedupKey)
		{
			using (List<HudOnlyPopupTask>.Enumerator enumerator = this.Tasks.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.DedupKey == dedupKey)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0401D1CF RID: 119247
		private readonly List<HudOnlyPopupTask> Tasks = new List<HudOnlyPopupTask>();
	}
}
